namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for the current user service
    /// </summary>
    public interface ICurrentUserService
    {
        string? UserId { get; }
        
        bool IsAuthenticated { get; }
    }
}
