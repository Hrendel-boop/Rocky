
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;

namespace Rocky.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            throw new NotImplementedException();
        }

        public static async Task Execute(string email, string subject, string body)
        {
            MailjetClient client = new MailjetClient("2e99cb9217a0b7adae72a60af69a1e06", "879c6facc5bd177573447c5778d146ae")
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
      new JObject {
      {
       "From",
       new JObject {
        {"Email", "giraffeguids@gmail.com"},
        {"Name", "Danil"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
          "giraffeguids@gmail.com"
         }, {
          "Name",
          "Danil"
         }
        }
       }
      }, {
       "Subject",
       "Greetings from Mailjet."
      }, {
       "TextPart",
       "My first Mailjet email"
      }, {
       "HTMLPart",
       "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
      }, {
       "CustomID",
       "AppGettingStartedTest"
      }
     }
    });
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
