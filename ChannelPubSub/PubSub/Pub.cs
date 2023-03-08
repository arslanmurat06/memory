using System;
using ChannelPubSub.Model;
using Microsoft.Extensions.Hosting;

namespace ChannelPubSub.PubSub
{
    public class Pub : IPub
    {
        IMessageBroker _messageBroker;

        public Pub(IMessageBroker messageBroker)
        {
            _messageBroker = messageBroker;
           
            Send();
        }

        private void Send()
        {
            Enumerable.Range(1, 10).ToList().ForEach(m =>
            {
                _messageBroker.Publish(new EmployeeCreatedMessage { Created = DateTime.UtcNow, ID = Guid.NewGuid() });
            });
        }
    }
}

