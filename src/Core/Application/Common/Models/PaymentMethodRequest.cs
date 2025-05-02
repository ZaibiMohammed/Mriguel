namespace Mriguel.Application.Common.Models
{
    /// <summary>
    /// Model for payment method requests
    /// </summary>
    public class PaymentMethodRequest
    {
        /// <summary>
        /// Card holder name
        /// </summary>
        public string CardHolderName { get; set; }
        
        /// <summary>
        /// Card number
        /// </summary>
        public string CardNumber { get; set; }
        
        /// <summary>
        /// Expiration month
        /// </summary>
        public string ExpirationMonth { get; set; }
        
        /// <summary>
        /// Expiration year
        /// </summary>
        public string ExpirationYear { get; set; }
        
        /// <summary>
        /// Card verification code
        /// </summary>
        public string Cvc { get; set; }
        
        /// <summary>
        /// Whether to set this payment method as the default
        /// </summary>
        public bool SetAsDefault { get; set; }
        
        /// <summary>
        /// Billing address
        /// </summary>
        public BillingAddress BillingAddress { get; set; }
    }
    
    /// <summary>
    /// Model for billing address
    /// </summary>
    public class BillingAddress
    {
        /// <summary>
        /// Address line 1
        /// </summary>
        public string Line1 { get; set; }
        
        /// <summary>
        /// Address line 2
        /// </summary>
        public string Line2 { get; set; }
        
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Postal code
        /// </summary>
        public string PostalCode { get; set; }
        
        /// <summary>
        /// State/province
        /// </summary>
        public string State { get; set; }
        
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }
    }
}
