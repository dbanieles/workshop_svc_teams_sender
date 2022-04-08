using Microsoft.EntityFrameworkCore;
using svc_teams_sender.Entity;
using svc_teams_sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Repository
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<NotificationEntity>();
            builder.Entity<TemplateEntity>();
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        public override void Dispose()
        {
            // TODO: Implement disposable correctly!
            //base.Dispose();
        }
    }
}
