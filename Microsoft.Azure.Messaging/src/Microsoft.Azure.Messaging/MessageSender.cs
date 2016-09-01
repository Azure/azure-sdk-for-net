// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    abstract class MessageSender : ClientEntity
    {
        protected MessageSender(QueueClient queueClient)
            : base(nameof(MessageSender) + StringUtility.GetRandomString())
        {
            this.QueueClient = queueClient;
        }

        protected QueueClient QueueClient { get; }

        public Task SendAsync(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            return this.OnSendAsync(brokeredMessages);
        }

        protected abstract Task OnSendAsync(IEnumerable<BrokeredMessage> brokeredMessages);

        internal static int ValidateMessages(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            int count;
            if (brokeredMessages == null || (count = brokeredMessages.Count()) == 0)
            {
                throw Fx.Exception.Argument(nameof(brokeredMessages), Resources.BrokeredMessageListIsNullOrEmpty);
            }

            foreach (BrokeredMessage brokeredMessage in brokeredMessages)
            {
                if (brokeredMessage.IsLockTokenSet)
                {
                    throw Fx.Exception.Argument(nameof(brokeredMessages), "Cannot Send ReceivedMessages");
                }
            }
            return count;
        }


    }
}
