using svc_teams_sender.Entity;
using svc_teams_sender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace svc_teams_sender.Mapper
{
    public static class NotificationMapper
    {

        public static Notification EntityToDto(NotificationEntity entity)
        {
            Notification notification = new Notification();
            notification.Id = entity.Id;
            notification.Content = entity.Content;
            notification.Sender = entity.Sender;
            notification.Receivers = entity.Receivers;
            notification.TemplateId = entity.TemplateId;
            notification.Date = entity.Date;

            return notification;
        }

        public static NotificationEntity DtoToEntity(Notification entity)
        {
            NotificationEntity notificationEntity = new NotificationEntity();
            notificationEntity.Id = entity.Id;
            notificationEntity.Content = entity.Content;
            notificationEntity.Sender = entity.Sender;
            notificationEntity.Receivers = entity.Receivers;
            notificationEntity.TemplateId = entity.TemplateId;
            notificationEntity.Date = entity.Date;

            return notificationEntity;
        }
    }
}
