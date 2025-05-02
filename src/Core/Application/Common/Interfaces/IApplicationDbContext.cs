using Microsoft.EntityFrameworkCore;
using Mriguel.Domain.Entities;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for the application database context
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Item> Items { get; }
        DbSet<Rental> Rentals { get; }
        DbSet<Review> Reviews { get; }
        DbSet<ItemCategory> ItemCategories { get; }
        DbSet<ItemImage> ItemImages { get; }
        DbSet<ItemAvailability> ItemAvailabilities { get; }
        DbSet<Payment> Payments { get; }
        DbSet<RentalMessage> RentalMessages { get; }
        DbSet<Address> Addresses { get; }
        DbSet<UserVerification> UserVerifications { get; }
        DbSet<PaymentMethod> PaymentMethods { get; }
        
        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
