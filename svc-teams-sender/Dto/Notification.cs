using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public String Sender { get; set; }
        public String Receivers { get; set; }
        public int TemplateId { get; set; }
        public DateTime Date { get; set; }
    }
}
