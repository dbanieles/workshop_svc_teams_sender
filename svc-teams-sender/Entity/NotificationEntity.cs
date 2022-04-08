using Microsoft.EntityFrameworkCore.Metadata.Builders;
using svc_teams_sender.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Entity
{
    [Table("message_outbox")]
    public class NotificationEntity: IEntity
    {
        [Column("id")]
        [Key]
        public int Id {get; set;}  
        
        [Column("content")]
        public String Content {get; set;}        
        
        [Column("sender")]
        public String Sender {get; set;}

        [Column("receivers")]
        public String Receivers { get; set; }   
        
        [Column("template_id")]
        public int TemplateId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

    }
}
