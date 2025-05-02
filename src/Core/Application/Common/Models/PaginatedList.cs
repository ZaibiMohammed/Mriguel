using Microsoft.EntityFrameworkCore;

namespace Mriguel.Application.Common.Models
{
    /// <summary>
    /// Represents a paginated list of items
    /// </summary>
    public class PaginatedList<T>
    {
        /// <summary>
        /// Items in the current page
        /// </summary>
        public List<T> Items { get; }
        
        /// <summary>
        /// Current page index
        /// </summary>
        public int PageIndex { get; }
        
        /// <summary>
        /// Total number of pages
        /// </summary>
        public int TotalPages { get; }
        
        /// <summary>
        /// Total number of items
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Creates a new paginated list
        /// </summary>
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        /// <summary>
        /// Indicates whether there is a previous page
        /// </summary>
        public bool HasPreviousPage => PageIndex > 1;

        /// <summary>
        /// Indicates whether there is a next page
        /// </summary>
        public bool HasNextPage => PageIndex < TotalPages;

        /// <summary>
        /// Creates a paginated list from a query
        /// </summary>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
