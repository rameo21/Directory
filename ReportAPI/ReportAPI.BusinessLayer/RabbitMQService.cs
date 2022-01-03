using MessagePack;
using RabbitMQ.Client;
using ReportAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAPI.BusinessLayer
{
    public class RabbitMQService : IMQService
    {
        ConnectionFactory factory = new ConnectionFactory()
        {
            HostName = "127.0.0.1",
            UserName = "administrator",
            Password = "123456aA!",
        };
        public void SendReportRequest(int reportId)
        {
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "ReportQueue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                    var queueData = new Dictionary<string, dynamic>();
                    queueData.Add("reportId", reportId);
                    var body = MessagePackSerializer.Serialize(queueData);
                    channel.BasicPublish(exchange: "", routingKey: "ReportQueue", basicProperties: null, body: body);
                }
            }
        }
    }
}
