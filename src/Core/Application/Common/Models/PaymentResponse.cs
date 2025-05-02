using System;

namespace Mriguel.Application.Common.Models
{
    /// <summary>
    /// Model for payment responses
    /// </summary>
    public class PaymentResponse
    {
        /// <summary>
        /// Transaction ID from the payment provider
        /// </summary>
        public string TransactionId { get; set; }
        
        /// <summary>
        /// Amount charged
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Currency code (e.g., USD, EUR)
        /// </summary>
        public string Currency { get; set; }
        
        /// <summary>
        /// Status of the payment (e.g., succeeded, failed, pending)
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Description of the payment
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// When the payment was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        /// <summary>
        /// Customer ID
        /// </summary>
        public string CustomerId { get; set; }
        
        /// <summary>
        /// Payment method ID
        /// </summary>
        public string PaymentMethodId { get; set; }
        
        /// <summary>
        /// Whether the payment was refunded
        /// </summary>
        public bool Refunded { get; set; }
        
        /// <summary>
        /// Refunded amount
        /// </summary>
        public decimal? RefundedAmount { get; set; }
        
        /// <summary>
        /// Receipt URL
        /// </summary>
        public string ReceiptUrl { get; set; }
    }
}
