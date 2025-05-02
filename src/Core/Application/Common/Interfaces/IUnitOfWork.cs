using System.Threading;
using System.Threading.Tasks;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Unit of work interface for managing transactions
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all changes made to the database
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Begins a transaction
        /// </summary>
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Commits the transaction
        /// </summary>
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Rolls back the transaction
        /// </summary>
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
