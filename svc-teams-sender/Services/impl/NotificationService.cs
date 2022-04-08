using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using svc_teams_sender.Dto;
using svc_teams_sender.Entity;
using svc_teams_sender.Mapper;
using svc_teams_sender.Models;
using svc_teams_sender.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace svc_teams_sender.Services
{
    public class NotificationService: INotificationService
    {

        private IRepository<TemplateEntity> _templateRepository;

        private IRepository<NotificationEntity> _notificationRepository;

        private readonly ILogger<NotificationService> _logger;

        private readonly string _TEAMS = "Teams";

        private HttpClient _httpClient;

        private readonly String _webhookUrl = "<webhook_url>";//https://bitsrl1.webhook.office.com/webhookb2/da2a88ef-48fd-452f-b505-a648ae2bf5dc@25189ba0-3d80-4d38-999a-b8f0c6b81194/IncomingWebhook/a7f793407d6c41bca87e5b456f35e918/29c2873d-2911-469f-8598-97258dedf8dd

        public NotificationService(ILogger<NotificationService> logger, IRepository<TemplateEntity> templateRepository, IRepository<NotificationEntity> notificationRepository) 
        {
            _logger = logger;
            _templateRepository = templateRepository;
            _notificationRepository = notificationRepository;
        }

        public List<Message> getNotifications()
        {
            List<Message> notificationList = new List<Message>();

            try
            {
                IQueryable<NotificationEntity> Notification = _notificationRepository.GetAll();
                IQueryable<TemplateEntity> Template = _templateRepository.GetAll();

                notificationList = (from notification in Notification
                        join template in Template on notification.TemplateId equals template.Id
                        where template.Type == _TEAMS
                        select new Message(notification.Id, notification.Content, notification.Sender, notification.Receivers, template.Template, notification.Date)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return notificationList;
        }

        async public void scanNotification()
        {
            List<Message> messageList = getNotifications();

            if (messageList.Count() > 0)
            {
                for (int i = 0; i < messageList.Count(); i++)
                {
                    await sendNotification(messageList.ElementAt(i));
                    deleteNotification(new Notification() { Id = messageList.ElementAt(i).Id });
                }
            }
        }

        async public Task sendNotification(Message message)
        {
            try
            {

                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                foreach (var receiver in message.Receivers)
                {
                    String template = message.composeTemplateProperties(receiver);
                    StringContent content = new StringContent(template, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync(_webhookUrl, content);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        public void deleteNotification(Notification notification)
        {
            try
            {
                if (notification.Id == null)
                {
                    throw new ArgumentException("ID PARAMETER CAN NOT BE NULL");
                }

                _notificationRepository.Delete(NotificationMapper.DtoToEntity(notification));
            }
            catch (Exception exception)
            {
                _logger.LogError("ERROR TO DELETE ENTITY FROM DATABASE");
                _logger.LogError(exception.Message);
            }

        }
    }
}
