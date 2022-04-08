using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Entity
{
    [Table("message_template")]
    public class TemplateEntity: IEntity
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("template")]
        public String Template { get; set; }

        [Column("type")]
        public String Type { get; set; }

    }
}
