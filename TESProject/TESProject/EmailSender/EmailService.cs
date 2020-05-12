using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MimeKit;

namespace TESProject.EmailSender
{
    public class EmailService
    {
        //public Lazy<SmtpClient> smtpClient = new Lazy<SmtpClient>(() =>
        //{
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = new NetworkCredential("pykelvl7mastery@gmail.com", "mak3387101");
        //    smtp.EnableSsl = true;
        //    return smtp;
        //}, true);

        //public async Task SendEmail(string email)
        //{
        //            MailAddress from = new MailAddress("pykelvl7mastery@gmail.com", "max");
        //            MailAddress to = new MailAddress(email);
        //            var message = MessageFabric.CreateMail(from, to);
        //            SendMessage(message);
           
        //}


        //public void SendMessage(object message)
        //{
        //    MailMessage mailMessage = (MailMessage)message;
        //    smtpClient.Value.Send(mailMessage);
        //}
       
        //public class MessageFabric
        //{
        //    public static MailMessage CreateMail(MailAddress from, MailAddress to)
        //    {
        //        MailMessage message = new MailMessage(from, to);
        //        message.Subject = "Party  invitation";
        //        message.Body = $"Follow the link to reset password: < a href = 'https://localhost:44313/Account/ResetPassword' > link </ a > ";
        //        message.IsBodyHtml = true;
        //        return message;
        //    }
        //}

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("TES Project master", "pykelvl7mastery@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("pykelvl7mastery@gmail.com", "mak3387101");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
