namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for getting information about the current user
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Gets the ID of the current user
        /// </summary>
        string UserId { get; }
        
        /// <summary>
        /// Indicates whether the current user is authenticated
        /// </summary>
        bool IsAuthenticated { get; }
    }
}
