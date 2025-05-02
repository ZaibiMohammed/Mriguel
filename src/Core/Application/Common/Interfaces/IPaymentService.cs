using Mriguel.Application.Common.Models;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for payment service operations
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Creates a payment intent
        /// </summary>
        Task<PaymentResult> CreatePaymentIntentAsync(PaymentRequest request);
        
        /// <summary>
        /// Captures a payment
        /// </summary>
        Task<PaymentResult> CapturePaymentAsync(string paymentIntentId);
        
        /// <summary>
        /// Refunds a payment
        /// </summary>
        Task<PaymentResult> RefundPaymentAsync(string paymentIntentId, decimal amount = 0);
        
        /// <summary>
        /// Gets a payment by its ID
        /// </summary>
        Task<PaymentInfo> GetPaymentAsync(string paymentIntentId);
    }
    
    /// <summary>
    /// Represents a payment request
    /// </summary>
    public class PaymentRequest
    {
        /// <summary>
        /// ID of the rental
        /// </summary>
        public Guid RentalId { get; set; }
        
        /// <summary>
        /// ID of the user making the payment
        /// </summary>
        public Guid UserId { get; set; }
        
        /// <summary>
        /// Amount to be paid
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Currency of the payment
        /// </summary>
        public string Currency { get; set; }
        
        /// <summary>
        /// ID of the payment method
        /// </summary>
        public string PaymentMethodId { get; set; }
        
        /// <summary>
        /// Description of the payment
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// URL to redirect to after payment
        /// </summary>
        public string ReturnUrl { get; set; }
    }
    
    /// <summary>
    /// Represents the result of a payment operation
    /// </summary>
    public class PaymentResult
    {
        /// <summary>
        /// Indicates whether the payment was successful
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// ID of the transaction
        /// </summary>
        public string TransactionId { get; set; }
        
        /// <summary>
        /// Status of the payment
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Error message if the payment failed
        /// </summary>
        public string ErrorMessage { get; set; }
    }
    
    /// <summary>
    /// Represents payment information
    /// </summary>
    public class PaymentInfo
    {
        /// <summary>
        /// ID of the payment
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Amount of the payment
        /// </summary>
        public decimal Amount { get; set; }
        
        /// <summary>
        /// Currency of the payment
        /// </summary>
        public string Currency { get; set; }
        
        /// <summary>
        /// Status of the payment
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Date and time when the payment was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
