using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MailKit;
using demo.model.ApiModels.Helper;
using demo.model.ApiModels.Employee;

namespace DisprzDemo.Helpers
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendWelcomeEmailAsync(Employee emp);
    }

    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();

            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendWelcomeEmailAsync(Employee emp)
        {
            var mailRequest = new MailRequest
            {
                ToEmail = emp.Email,
                Subject = $"Welcome {emp.Name}",
                Body = @$"
<br>
<h4>Welcome to DEMO @{emp.Name},</h4>
<br>
<p>Welcome it is a greate comp, You will certinly enjoy it, </p>
<p.It will a great chance to learn and grow.</p>
<br>
<br>
<h4>Thanks,</h4>
<h5>Shravansingh</h5>
<br>
"
            };

            await SendEmailAsync(mailRequest);
        }
    }
}