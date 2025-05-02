using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Mriguel.Application.Common.Behaviors
{
    /// <summary>
    /// MediatR pipeline behavior for unhandled exceptions
    /// </summary>
    /// <typeparam name="TRequest">Request type</typeparam>
    /// <typeparam name="TResponse">Response type</typeparam>
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger;
        
        public UnhandledExceptionBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex) when (ex is not TaskCanceledException && ex is not OperationCanceledException)
            {
                var requestName = typeof(TRequest).Name;
                
                _logger.LogError(ex, "Mriguel Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                
                throw;
            }
        }
    }
}
