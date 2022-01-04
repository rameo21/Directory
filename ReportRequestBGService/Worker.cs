using MessagePack;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ReportAPI.Infrastructure;

namespace ReportRequestBGService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IReportService _reportService;
        private readonly IContactService _contactService;

        public Worker(ILogger<Worker> logger, IReportService reportService, IContactService contactService)
        {
            _logger = logger;
            _reportService = reportService;
            _contactService = contactService;
        }

        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "127.0.0.1",
            UserName = "administrator",
            Password = "123456aA!",
        };

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var connection = factory.CreateConnection())
            {
                var channel = connection.CreateModel();
                channel.BasicQos(0, 1, false);
                channel.QueueDeclare(queue: "ReportQueue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                var ReportQueue_Consumer = new EventingBasicConsumer(channel);

                ReportQueue_Consumer.Received += async (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var queueData = MessagePackSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                        int reportId = queueData["reportId"];

                        var report = await _reportService.GetById(reportId);
                        var contacts = await _contactService.GetAllByLocation(report.Location);

                        var locationContactCount = contacts.Count();
                        var locationPhoneCount = contacts.Sum(w => w.ContactDetailDtos.Where(w => w.InformationType == ReportAPI.EntityLayer.Enum.InformationType.Phone).Count());

                        report.Value = "/getReport";  
                        report.ReportStatus = ReportAPI.EntityLayer.Enum.ReportStatus.Done;
                        await _reportService.Update(report);

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "ReportQueue Queue Error");
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                };

                channel.BasicConsume(queue: "ReportQueue", autoAck: false, consumer: ReportQueue_Consumer);

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                    await Task.Delay(1000, stoppingToken);
                }
            }

        }
    }
}