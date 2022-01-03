using RabbitMQ.Client;
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
   
        }
    }
}