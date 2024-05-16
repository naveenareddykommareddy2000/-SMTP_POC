﻿using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SMTP_Mail_POC.Models;

namespace SMTP_Mail_POC.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("cornell.strosin37@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject =request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailUserName").Value,_config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
