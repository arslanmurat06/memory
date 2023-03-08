using System;
namespace ChannelPubSub.Model
{
	public interface IMessage
	{
		public DateTime Created { get; set; }
		public Guid ID { get; set; }
	}
}

