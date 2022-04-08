using Microsoft.AspNetCore.Mvc;
using svc_teams_sender.Dto;
using svc_teams_sender.Entity;
using svc_teams_sender.Models;
using svc_teams_sender.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController
    {
        private INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("notifications")]
        public List<Message> notifications()
        {
            return _notificationService.getNotifications();
        }

        [HttpPost]
        public void sendMessage([FromBody] Message message)
        {
            _notificationService.sendNotification(message);
        }
    }
}
