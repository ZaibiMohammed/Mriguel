using System;

namespace Mriguel.Application.Common.Models
{
    /// <summary>
    /// Model for payment requests
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// Amount to be charged
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Currency code (e.g., USD, EUR)
        /// </summary>
        public string Currency { get; set; }
        
        /// <summary>
        /// Payment method ID
        /// </summary>
        public string PaymentMethodId { get; set; }
        
        /// <summary>
        /// Customer ID
        /// </summary>
        public string CustomerId { get; set; }
        
        /// <summary>
        /// Description of the payment
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Rental ID associated with the payment
        /// </summary>
        public Guid RentalId { get; set; }
        
        /// <summary>
        /// User ID of the customer
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// URL to redirect to after payment
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
