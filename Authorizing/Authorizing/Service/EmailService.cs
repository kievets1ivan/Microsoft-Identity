using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Authorizing.Service
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if(message.Subject.Equals("Confirmation"))
            {
                SendConfirmationEmail(message);
            }
            //else somthing other email
            
            return Task.FromResult<object>(null);
        }

        public void SendConfirmationEmail(IdentityMessage message)
        {
            message.Body = "Thx for registra, pls confirm email by click on link below";

            var smtp = new SmtpClient
            {
                Host = "localhost",
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                UseDefaultCredentials = false,
                PickupDirectoryLocation = @"c:\temp\"

            };
            using (var mess = new MailMessage("noreply@mail.com", "testmail@mail.com")
            {
                Subject = message.Subject,
                Body = message.Body
            })
            {
                smtp.Send(mess);
            }

        }
    }
}