using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mriguel.Application.Common.Interfaces;
using Mriguel.Application.Features.Users.Queries.GetUserById;
using Mriguel.Domain.Entities;
using Mriguel.Domain.Entities.Identity;

namespace Mriguel.Application.Features.Users.Commands.CreateUser
{
    /// <summary>
    /// Command to create a new user
    /// </summary>
    public record CreateUserCommand : IRequest<UserDto>
    {
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; init; }
        
        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; init; }
        
        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; init; }
        
        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; init; }
    }
    
    /// <summary>
    /// Handler for the CreateUserCommand
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;
        
        public CreateUserCommandHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IIdentityService identityService,
            IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
            _emailService = emailService;
        }
        
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Check if user already exists
            var existingUser = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
                
            if (existingUser != null)
            {
                throw new Exception($"User with email {request.Email} already exists.");
            }
            
            // Create identity user
            var (result, userId) = await _identityService.CreateUserAsync(request.Email, request.Password);
            
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create identity user: {string.Join(", ", result.Errors)}");
            }
            
            // Create domain user
            var applicationUser = new ApplicationUser { Id = userId };
            var user = new User(request.Email, request.FirstName, request.LastName, applicationUser);
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            
            // Send welcome email
            await _emailService.SendEmailAsync(
                request.Email,
                "Welcome to Mriguel",
                $"<h1>Welcome to Mriguel, {request.FirstName}!</h1><p>Thank you for joining our community.</p>",
                $"Welcome to Mriguel, {request.FirstName}! Thank you for joining our community."
            );
            
            return _mapper.Map<UserDto>(user);
        }
    }
}
