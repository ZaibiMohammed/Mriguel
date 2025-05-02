using AutoMapper;
using Mriguel.Application.Common.Mappings;
using Mriguel.Domain.Entities;
using Mriguel.Domain.Enums;

namespace Mriguel.Application.Features.Users.Queries.GetUserById
{
    /// <summary>
    /// User DTO for queries
    /// </summary>
    public class UserDto : IMapFrom<User>
    {
        /// <summary>
        /// User ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// User full name
        /// </summary>
        public string FullName { get; set; }
        
        /// <summary>
        /// User phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// User biography
        /// </summary>
        public string Biography { get; set; }
        
        /// <summary>
        /// User profile picture URL
        /// </summary>
        public string ProfilePictureUrl { get; set; }
        
        /// <summary>
        /// User status
        /// </summary>
        public UserStatus Status { get; set; }
        
        /// <summary>
        /// User average rating
        /// </summary>
        public float AverageRating { get; set; }
        
        /// <summary>
        /// Number of ratings received by the user
        /// </summary>
        public int RatingsCount { get; set; }
        
        /// <summary>
        /// Date and time when the user was created
        /// </summary>
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Creates the mapping configuration
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>();
        }
    }
}
