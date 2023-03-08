using System;
using ChannelPubSub.Model;
using ChannelPubSub.PubSub;
using Microsoft.Extensions.Logging;

namespace ChannelPubSub.BackgroundServices
{
    public class Sub :ISub
    {
        IMessageBroker _messageBroker;
        ILogger<Sub> _logger;

        private readonly Guid ID;

        public Sub(IMessageBroker messageBroker, ILogger<Sub> logger)
        {
            _messageBroker = messageBroker;
            ID = Guid.NewGuid();
            _logger = logger;
            Subscribe();
        }

        private void Subscribe()
         => _messageBroker.Subscribe(ID, HandleEvent);


        private void HandleEvent(IMessage message)
             => _logger.LogInformation($"ID - {message.ID}");
        
    }
}

