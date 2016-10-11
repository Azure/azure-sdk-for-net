// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
