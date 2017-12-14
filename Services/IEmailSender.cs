using System.Threading.Tasks;

namespace Vidly.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
