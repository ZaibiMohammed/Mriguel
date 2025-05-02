using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mriguel.Application.Common.Models
{
    /// <summary>
    /// Paginated list for collections
    /// </summary>
    /// <typeparam name="T">Type of the items</typeparam>
    public class PaginatedList<T>
    {
        /// <summary>
        /// Current page items
        /// </summary>
        public List<T> Items { get; }
        
        /// <summary>
        /// Current page number (1-based)
        /// </summary>
        public int PageNumber { get; }
        
        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages { get; }
        
        /// <summary>
        /// Total number of items
        /// </summary>
        public int TotalCount { get; }
        
        /// <summary>
        /// Whether there is a previous page
        /// </summary>
        public bool HasPreviousPage => PageNumber > 1;
        
        /// <summary>
        /// Whether there is a next page
        /// </summary>
        public bool HasNextPage => PageNumber < TotalPages;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }
        
        /// <summary>
        /// Creates a paginated list from a collection
        /// </summary>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var count = await source.CountAsync(cancellationToken);
            
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;
            
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            
            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
        
        /// <summary>
        /// Creates a paginated list from a collection
        /// </summary>
        public static PaginatedList<T> Create(IEnumerable<T> source, int count, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;
            
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            
            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
