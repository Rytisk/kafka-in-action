using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using UserWebApi.Models;

namespace UserWebApi.Services
{
    public class MessageProducer
    {
        private IProducer<string, UserEvent> _producer;
        private string _topic;
        public MessageProducer()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:19092"
            };

            _topic = "users-topic";

            _producer = new ProducerBuilder<string, UserEvent>(config)
                .SetValueSerializer(new JsonSerializer<UserEvent>())
                .Build();
        }

        public async Task ProduceAsync(UserEvent userEvent)
        {
            await _producer.ProduceAsync(_topic, new Message<string, UserEvent>
            {
                Key = userEvent.UserId,
                Value = userEvent
            });
        }
    }
}
