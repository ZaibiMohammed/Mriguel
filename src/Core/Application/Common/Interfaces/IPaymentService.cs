using System;
using System.Threading.Tasks;
using Mriguel.Application.Common.Models;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Payment service interface
    /// </summary>
    public interface IPaymentService
    {
        /// <summary>
        /// Creates a payment intent/charge
        /// </summary>
        Task<PaymentResult> ProcessPaymentAsync(PaymentRequest request);
        
        /// <summary>
        /// Refunds a payment
        /// </summary>
        Task<PaymentResult> RefundPaymentAsync(string transactionId, decimal amount);
        
        /// <summary>
        /// Creates a customer in the payment provider
        /// </summary>
        Task<string> CreateCustomerAsync(string email, string name);
        
        /// <summary>
        /// Creates a payment method for a customer
        /// </summary>
        Task<string> CreatePaymentMethodAsync(string customerId, PaymentMethodRequest request);
        
        /// <summary>
        /// Gets payment methods for a customer
        /// </summary>
        Task<PaymentMethodResponse[]> GetPaymentMethodsAsync(string customerId);
        
        /// <summary>
        /// Deletes a payment method
        /// </summary>
        Task<bool> DeletePaymentMethodAsync(string paymentMethodId);
        
        /// <summary>
        /// Gets a payment by transaction ID
        /// </summary>
        Task<PaymentResponse> GetPaymentAsync(string transactionId);
    }
}
