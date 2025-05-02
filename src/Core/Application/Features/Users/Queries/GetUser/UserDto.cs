using System;
using AutoMapper;
using Mriguel.Application.Mappings;
using Mriguel.Domain.Entities;
using Mriguel.Domain.Enums;

namespace Mriguel.Application.Features.Users.Queries.GetUser
{
    /// <summary>
    /// User dto for queries
    /// </summary>
    public class UserDto : IMapFrom<User>
    {
        /// <summary>
        /// User ID
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Full name (FirstName + LastName)
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";
        
        /// <summary>
        /// Phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Biography
        /// </summary>
        public string Biography { get; set; }
        
        /// <summary>
        /// Date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        
        /// <summary>
        /// Gender
        /// </summary>
        public Gender? Gender { get; set; }
        
        /// <summary>
        /// Profile picture URL
        /// </summary>
        public string ProfilePictureUrl { get; set; }
        
        /// <summary>
        /// User status
        /// </summary>
        public UserStatus Status { get; set; }
        
        /// <summary>
        /// Average rating
        /// </summary>
        public float AverageRating { get; set; }
        
        /// <summary>
        /// Ratings count
        /// </summary>
        public int RatingsCount { get; set; }
        
        /// <summary>
        /// When the user was created
        /// </summary>
        public DateTime Created { get; set; }
        
        /// <summary>
        /// Mapping configuration
        /// </summary>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>();
        }
    }
}
