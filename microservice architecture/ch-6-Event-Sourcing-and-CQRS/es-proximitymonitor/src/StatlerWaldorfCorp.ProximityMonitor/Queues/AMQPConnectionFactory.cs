using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;

namespace StatlerWaldorfCorp.ProximityMonitor.Queues
{
    public class AMQPConnectionFactory :IAMQPConnectionFactory
    {
        protected AMQPOptions amqpOptions;
        public ConnectionFactory connectionFactory = new ConnectionFactory();
        public AMQPConnectionFactory(
            ILogger<AMQPConnectionFactory> logger,
            IOptions<AMQPOptions> serviceOptions) 
        {
            this.amqpOptions = serviceOptions.Value;

            this.connectionFactory.UserName = amqpOptions.Username;
            this.connectionFactory.Password = amqpOptions.Password;
            this.connectionFactory.VirtualHost = amqpOptions.VirtualHost;
            this.connectionFactory.HostName = amqpOptions.HostName;
            this.connectionFactory.Uri = new Uri(amqpOptions.Uri);

            logger.LogInformation($"AMQP Connection configured for URI : {amqpOptions.Uri}");
        }

        public ConnectionFactory ConnectionFactory(){
            return this.connectionFactory;            
        }
    }


    public interface IAMQPConnectionFactory{
        ConnectionFactory ConnectionFactory();
    } 
}