using System.Threading.Tasks;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Email service interface
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="to">Recipient email address</param>
        /// <param name="subject">Email subject</param>
        /// <param name="htmlContent">Email content in HTML format</param>
        /// <param name="textContent">Email content in plain text format (optional)</param>
        /// <returns>True if the email was sent successfully</returns>
        Task<bool> SendEmailAsync(string to, string subject, string htmlContent, string textContent = null);
        
        /// <summary>
        /// Sends a templated email
        /// </summary>
        /// <param name="to">Recipient email address</param>
        /// <param name="templateId">Template ID</param>
        /// <param name="templateData">Template data</param>
        /// <returns>True if the email was sent successfully</returns>
        Task<bool> SendTemplatedEmailAsync(string to, string templateId, object templateData);
    }
}
