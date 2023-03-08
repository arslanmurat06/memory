using ChannelPubSub.Model;
using System.Threading.Tasks;

namespace ChannelPubSub
{
    public interface IMessageBroker
    {
        Task Publish(IMessage message);
        void Subscribe(Guid id, Action<IMessage> func);

    }
}