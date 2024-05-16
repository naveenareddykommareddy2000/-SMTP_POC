using SMTP_Mail_POC.Models;

namespace SMTP_Mail_POC.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
