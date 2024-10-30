using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace CollegeDatabaseManagementSystem.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // For now, just return a completed task. No email sending.
            return Task.CompletedTask;
        }
    }
}
