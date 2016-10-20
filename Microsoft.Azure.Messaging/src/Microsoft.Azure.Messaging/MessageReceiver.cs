// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    abstract class MessageReceiver : ClientEntity
    {
        protected MessageReceiver()
            : base(nameof(MessageReceiver) + StringUtility.GetRandomString())
        {
        }

        public Task<IList<BrokeredMessage>> ReceiveAsync(int maxMessageCount)
        {
            return this.OnReceiveAsync(maxMessageCount);
        }

        public Task CompleteAsync(IEnumerable<Guid> lockTokens)
        {
            return this.OnCompleteAsync(lockTokens);
        }

        public Task AbandonAsync(IEnumerable<Guid> lockTokens)
        {
            return this.OnAbandonAsync(lockTokens);
        }

        public Task DeferAsync(IEnumerable<Guid> lockTokens)
        {
            return this.OnDeferAsync(lockTokens);
        }

        public Task DeadLetterAsync(IEnumerable<Guid> lockTokens)
        {
            return this.OnDeadLetterAsync(lockTokens);
        }

        protected abstract Task<IList<BrokeredMessage>> OnReceiveAsync(int maxMessageCount);

        protected abstract Task OnCompleteAsync(IEnumerable<Guid> lockTokens);

        protected abstract Task OnAbandonAsync(IEnumerable<Guid> lockTokens);

        protected abstract Task OnDeferAsync(IEnumerable<Guid> lockTokens);

        protected abstract Task OnDeadLetterAsync(IEnumerable<Guid> lockTokens);
    }
}
