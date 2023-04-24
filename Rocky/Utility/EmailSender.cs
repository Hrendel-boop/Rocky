
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
            return Execute(email, subject, htmlMessage);
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
          email
         }, {
          "Name",
          "Danil"
         }
        }
       }
      }, {
       "Subject",
       subject
      },  {
       "HTMLPart",
       body
      }, 
     }
    });
           await client.PostAsync(request);
        }
    }
}
