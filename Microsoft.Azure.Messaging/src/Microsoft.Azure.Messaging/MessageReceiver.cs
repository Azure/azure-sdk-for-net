using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Messaging
{
    abstract class MessageReceiver : ClientEntity
    {
        protected MessageReceiver(QueueClient queueClient)
            : base(nameof(MessageReceiver) + StringUtility.GetRandomString())
        {
            this.QueueClient = queueClient;
        }

        protected QueueClient QueueClient { get; }

        public Task<IList<BrokeredMessage>> ReceiveAsync(int maxMessageCount)
        {
            return this.OnReceiveAsync(maxMessageCount);
        }

        protected abstract Task<IList<BrokeredMessage>> OnReceiveAsync(int maxMessageCount);
    }
}
