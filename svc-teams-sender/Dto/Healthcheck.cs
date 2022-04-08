using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Models
{
    public class Healthcheck
    {
        public String Service { get; set; }
        public String Status {get; set;}
        public DateTime Date {get; set;}

        public Healthcheck(String service, String status, DateTime date)
        {
            this.Service = service;
            this.Status = status;
            this.Date = date;
        }
    }
}
