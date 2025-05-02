using Mriguel.Application.Common.Models;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for identity services
    /// </summary>
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        
        Task<bool> IsInRoleAsync(string userId, string role);
        
        Task<bool> AuthorizeAsync(string userId, string policyName);
        
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string email, string password);
        
        Task<Result> DeleteUserAsync(string userId);
        
        Task<Result> UpdateUserAsync(string userId, string email, string phoneNumber);
        
        Task<string> GetUserIdByEmailAsync(string email);
    }
}
