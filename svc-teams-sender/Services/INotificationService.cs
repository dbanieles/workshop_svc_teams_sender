using svc_teams_sender.Dto;
using svc_teams_sender.Entity;
using svc_teams_sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Services
{
    public interface INotificationService
    {
        List<Message> getNotifications();
        void deleteNotification(Notification notification);

        void scanNotification();

        Task sendNotification(Message Message);

    }
}
