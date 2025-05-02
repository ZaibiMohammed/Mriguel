namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for email service operations
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email
        /// </summary>
        Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string textContent = null);
        
        /// <summary>
        /// Sends an email with attachments
        /// </summary>
        Task<bool> SendEmailWithAttachmentsAsync(string to, string subject, string htmlContent, string textContent = null, IEnumerable<EmailAttachment> attachments = null);
    }
    
    /// <summary>
    /// Represents an email attachment
    /// </summary>
    public class EmailAttachment
    {
        /// <summary>
        /// Name of the attachment
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Content of the attachment as a byte array
        /// </summary>
        public byte[] Content { get; set; }
        
        /// <summary>
        /// MIME type of the attachment
        /// </summary>
        public string ContentType { get; set; }
    }
}
