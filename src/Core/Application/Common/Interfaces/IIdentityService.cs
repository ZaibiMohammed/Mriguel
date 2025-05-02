using Mriguel.Application.Common.Models;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for identity service operations
    /// </summary>
    public interface IIdentityService
    {
        /// <summary>
        /// Gets the user ID for a given username
        /// </summary>
        Task<string> GetUserIdAsync(string userName);
        
        /// <summary>
        /// Creates a new user
        /// </summary>
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        
        /// <summary>
        /// Checks if a user with the given ID exists
        /// </summary>
        Task<bool> UserExistsAsync(string userId);
        
        /// <summary>
        /// Checks if a user belongs to a role
        /// </summary>
        Task<bool> IsInRoleAsync(string userId, string role);
        
        /// <summary>
        /// Authorizes a user against a policy
        /// </summary>
        Task<bool> AuthorizeAsync(string userId, string policyName);
        
        /// <summary>
        /// Deletes a user
        /// </summary>
        Task<Result> DeleteUserAsync(string userId);
    }
}
