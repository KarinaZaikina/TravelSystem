using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace TripExpenses.Models
{
    public class EmailService
    {
        public void SendEmail(string email, string subject, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Бухгалтер сайта", "zaikineu@outlook.com"));
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp-mail.outlook.com", 587, false);
                    client.Authenticate("zaikineu@outlook.com", "Natali1977");
                    client.Send(emailMessage);

                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
            }
        }
    }
}

