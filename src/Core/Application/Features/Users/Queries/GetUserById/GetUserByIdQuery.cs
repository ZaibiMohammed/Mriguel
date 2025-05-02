using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mriguel.Application.Common.Exceptions;
using Mriguel.Application.Common.Interfaces;
using Mriguel.Domain.Entities;

namespace Mriguel.Application.Features.Users.Queries.GetUserById
{
    /// <summary>
    /// Query to get a user by ID
    /// </summary>
    public record GetUserByIdQuery : IRequest<UserDto>
    {
        /// <summary>
        /// User ID
        /// </summary>
        public Guid Id { get; init; }
    }
    
    /// <summary>
    /// Handler for the GetUserByIdQuery
    /// </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetUserByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            
            return _mapper.Map<UserDto>(entity);
        }
    }
}
