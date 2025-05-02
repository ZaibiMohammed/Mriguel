namespace Mriguel.Application.Common.Models
{
    /// <summary>
    /// Model for payment results
    /// </summary>
    public class PaymentResult
    {
        /// <summary>
        /// Whether the payment was successful
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Transaction ID from the payment provider
        /// </summary>
        public string TransactionId { get; set; }
        
        /// <summary>
        /// Status of the payment (e.g., succeeded, failed, pending)
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Error message if the payment failed
        /// </summary>
        public string ErrorMessage { get; set; }
        
        /// <summary>
        /// URL to redirect the user to for additional authentication steps (e.g., 3D Secure)
        /// </summary>
        public string RedirectUrl { get; set; }
        
        /// <summary>
        /// Client secret for confirming the payment on the client side
        /// </summary>
        public string ClientSecret { get; set; }
    }
}
