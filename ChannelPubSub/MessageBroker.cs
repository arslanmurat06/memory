using System;
using System.Collections.Concurrent;
using System.Threading.Channels;
using ChannelPubSub.Model;

namespace ChannelPubSub
{
	public class MessageBroker: IMessageBroker
	{
		private readonly Channel<IMessage> _channel;

		private readonly ConcurrentDictionary<Guid, Action<IMessage>> Subscribers;

		public MessageBroker()
		{
			_channel = Channel.CreateBounded<IMessage>(options: new BoundedChannelOptions(int.MaxValue) { SingleReader = false});
			Subscribers = new ConcurrentDictionary<Guid, Action<IMessage>>();
			Task.Run(()=> Send());

        }

		public async Task Publish(IMessage message)
			=> await _channel.Writer.WriteAsync(message);

		public void Subscribe(Guid id, Action<IMessage> func)
			=> Subscribers.TryAdd(id, func);
		

		private async Task Send()
		{
            while (await _channel.Reader.WaitToReadAsync())
            {
                if (_channel.Reader.TryRead(out var message))
                {
					Subscribers.AsParallel().ForAll(k =>(k.Value as Action<IMessage>).Invoke(message));
                }
            }
        }
		
	}
}

