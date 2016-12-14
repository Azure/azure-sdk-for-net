// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Amqp;

    public abstract class MessageReceiver : ClientEntity
    {
        readonly TimeSpan operationTimeout;
        int prefetchCount;

        protected MessageReceiver(ReceiveMode receiveMode, TimeSpan operationTimeout)
            : base(nameof(MessageReceiver) + StringUtility.GetRandomString())
        {
            this.ReceiveMode = receiveMode;
            this.operationTimeout = operationTimeout;
        }

        public abstract string Path { get; }

        public ReceiveMode ReceiveMode { get; protected set; }

        public virtual int PrefetchCount
        {
            get
            {
                return this.prefetchCount;
            }

            set
            {
                if (value < 0)
                {
                    throw Fx.Exception.ArgumentOutOfRange(nameof(this.PrefetchCount), value, "Value must be greater than 0");
                }

                this.prefetchCount = value;
            }
        }

        internal TimeSpan OperationTimeout
        {
            get { return this.operationTimeout; }
        }

        protected MessagingEntityType EntityType { get; set; }

        public async Task<BrokeredMessage> ReceiveAsync()
        {
            IList<BrokeredMessage> messages = await this.ReceiveAsync(1).ConfigureAwait(false);
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

        public Task<IList<BrokeredMessage>> ReceiveAsync(int maxMessageCount)
        {
            return this.OnReceiveAsync(maxMessageCount);
        }

        public Task<IList<BrokeredMessage>> ReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers)
        {
            return this.OnReceiveBySequenceNumberAsync(sequenceNumbers);
        }

        public Task CompleteAsync(IEnumerable<Guid> lockTokens)
        {
            this.ThrowIfNotPeekLockMode();
            MessageReceiver.ValidateLockTokens(lockTokens);

            return this.OnCompleteAsync(lockTokens);
        }

        public Task AbandonAsync(IEnumerable<Guid> lockTokens)
        {
            this.ThrowIfNotPeekLockMode();
            MessageReceiver.ValidateLockTokens(lockTokens);

            return this.OnAbandonAsync(lockTokens);
        }

        public Task DeferAsync(IEnumerable<Guid> lockTokens)
        {
            this.ThrowIfNotPeekLockMode();
            MessageReceiver.ValidateLockTokens(lockTokens);

            return this.OnDeferAsync(lockTokens);
        }

        public Task DeadLetterAsync(IEnumerable<Guid> lockTokens)
        {
            this.ThrowIfNotPeekLockMode();
            MessageReceiver.ValidateLockTokens(lockTokens);

            return this.OnDeadLetterAsync(lockTokens);
        }

        public Task<DateTime> RenewLockAsync(Guid lockToken)
        {
            this.ThrowIfNotPeekLockMode();
            MessageReceiver.ValidateLockTokens(new Guid[] { lockToken });

            return this.OnRenewLockAsync(lockToken);
        }

        internal Task<AmqpResponseMessage> ExecuteRequestResponseAsync(AmqpRequestMessage amqpRequestMessage)
        {
            return this.OnExecuteRequestResponseAsync(amqpRequestMessage);
        }

        protected abstract Task<IList<BrokeredMessage>> OnReceiveAsync(int maxMessageCount);

        protected abstract Task<IList<BrokeredMessage>> OnReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers);

        protected abstract Task OnCompleteAsync(IEnumerable<Guid> lockTokens);

        protected abstract Task OnAbandonAsync(IEnumerable<Guid> lockTokens);

        protected abstract Task OnDeferAsync(IEnumerable<Guid> lockTokens);

        protected abstract Task OnDeadLetterAsync(IEnumerable<Guid> lockTokens);

        protected abstract Task<DateTime> OnRenewLockAsync(Guid lockToken);

        protected abstract Task<AmqpResponseMessage> OnExecuteRequestResponseAsync(AmqpRequestMessage requestAmqpMessage);

        static void ValidateLockTokens(IEnumerable<Guid> lockTokens)
        {
            if (lockTokens == null || !lockTokens.Any())
            {
                throw Fx.Exception.ArgumentNull(nameof(lockTokens));
            }
        }

        void ThrowIfNotPeekLockMode()
        {
            if (this.ReceiveMode != ReceiveMode.PeekLock)
            {
                throw Fx.Exception.AsError(new InvalidOperationException("The operation is only supported in 'PeekLock' receive mode."));
            }
        }
    }
}