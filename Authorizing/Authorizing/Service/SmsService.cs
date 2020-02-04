using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Authorizing.Service
{
    public class SmsService
    {
        public Task SendAsync(IdentityMessage message)
        {
            string AccountSid = "AC60671f39f9c1edd419022c8f0f9efe9e";

            string AuthToken = "f62e1374032b4b2838d07f085b678d15";

            string twilioPhoneNumber = "+13095884640";

            // try twilio
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            twilio.SendMessage(twilioPhoneNumber, "кому", "text sms");

            return Task.FromResult(0);
        }
    }
}