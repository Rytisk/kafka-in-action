using System;
using System.Threading.Tasks;
using UserWebApi.Models;

namespace UserWebApi.Services
{
    public class UserService
    {
        private readonly MessageProducer _messageProducer;

        public UserService(MessageProducer messageProducer)
        {
            _messageProducer = messageProducer;
        }

        public async Task UpdateAsync(string userId)
        {
            await _messageProducer.ProduceAsync(UserEvent.Update(userId));
        }

        public async Task CreateAsync(string userId)
        {
            await _messageProducer.ProduceAsync(UserEvent.Create(userId));
        }

        public async Task DeleteAsync(string userId)
        {
            await _messageProducer.ProduceAsync(UserEvent.Delete(userId));
        }
    }
}
