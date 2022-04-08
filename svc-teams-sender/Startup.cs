using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using svc_teams_sender.Entity;
using svc_teams_sender.Jobs;
using svc_teams_sender.Models;
using svc_teams_sender.Repository;
using svc_teams_sender.Services;

namespace svc_teams_sender
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<TemplateEntity>), typeof(Repository<TemplateEntity>));
            services.AddScoped(typeof(IRepository<NotificationEntity>), typeof(Repository<NotificationEntity>));
            services.AddScoped(typeof(INotificationService),typeof(NotificationService));
            services.AddQuartz(q => {
                q.UseMicrosoftDependencyInjectionJobFactory();
                var jobKey = new JobKey("TeamsJob");
                q.AddJob<TeamsJob>(opts => opts.WithIdentity(jobKey));
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity("TeamsJob-trigger")
                    .WithCronSchedule("0 0/5 * * * ?"));
            });
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
