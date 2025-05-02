using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Mriguel.Domain.Common;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Generic repository interface for all entities
    /// </summary>
    /// <typeparam name="T">Entity type that implements IAggregateRoot</typeparam>
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        /// <summary>
        /// Gets an entity by id
        /// </summary>
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Gets all entities
        /// </summary>
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Finds entities by a predicate
        /// </summary>
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Adds a new entity
        /// </summary>
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Updates an existing entity
        /// </summary>
        void Update(T entity);
        
        /// <summary>
        /// Removes an entity
        /// </summary>
        void Remove(T entity);
        
        /// <summary>
        /// Checks if any entity satisfies the given predicate
        /// </summary>
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Counts entities that satisfy the given predicate
        /// </summary>
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
