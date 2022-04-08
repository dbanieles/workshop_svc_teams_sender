using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Dto
{
    public class Message
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public String Sender { get; set; }
        public String[] Receivers { get; set; }
        public String Template { get; set; }
        public DateTime Date { get; set; }


        public Message()
        {

        }

        public Message(int id, String content, String sender, String receivers, String template, DateTime date)
        {
            Id = id;
            Content = content;
            Sender = sender;
            Receivers = receivers.Split(",");
            Template = template;
            Date = date;
        }


        public String composeTemplateProperties(String email)
        {
            return Template.Replace("<mentionedname>", getNameByEmail(email)).Replace("<mentionedemail>", email).Replace("<messagecontent>", Content);
        }

        private String getNameByEmail(String email)
        {
            return char.ToUpper(email.Split(".")[0][0]) + email.Split(".")[0].Substring(1);
        }

    }
}
