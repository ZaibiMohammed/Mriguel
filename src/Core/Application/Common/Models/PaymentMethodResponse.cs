namespace Mriguel.Application.Common.Models
{
    /// <summary>
    /// Model for payment method responses
    /// </summary>
    public class PaymentMethodResponse
    {
        /// <summary>
        /// Payment method ID
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Type of payment method (e.g., card)
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Last 4 digits of the card
        /// </summary>
        public string Last4 { get; set; }
        
        /// <summary>
        /// Card brand (e.g., Visa, Mastercard)
        /// </summary>
        public string Brand { get; set; }
        
        /// <summary>
        /// Expiration month
        /// </summary>
        public string ExpirationMonth { get; set; }
        
        /// <summary>
        /// Expiration year
        /// </summary>
        public string ExpirationYear { get; set; }
        
        /// <summary>
        /// Card holder name
        /// </summary>
        public string CardHolderName { get; set; }
        
        /// <summary>
        /// Whether this is the default payment method
        /// </summary>
        public bool IsDefault { get; set; }
        
        /// <summary>
        /// When the payment method was created
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
