using Microsoft.Extensions.Logging;
using Quartz;
using svc_teams_sender.Services;
using System.Threading.Tasks;

namespace svc_teams_sender.Jobs
{
    public class TeamsJob : IJob
    {
        private readonly ILogger<TeamsJob> _logger;

        private INotificationService _notificationService;

        public TeamsJob(ILogger<TeamsJob> logger, INotificationService notificationService)
        {
            _logger = logger;
            _notificationService = notificationService;
        }
        public Task Execute(IJobExecutionContext context)
        {

            _logger.LogInformation("Scannning message_outbox table!");

            _notificationService.scanNotification();

            _logger.LogInformation("Scan completed!");

            return Task.CompletedTask;
        }
    }
}
