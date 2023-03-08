using System;
namespace ChannelPubSub.Model
{
	public abstract class Message:IMessage
	{
        public DateTime Created { get; set; }
        public Guid ID { get; set; }
    }
}

