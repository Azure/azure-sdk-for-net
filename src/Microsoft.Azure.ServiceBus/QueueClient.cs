// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Primitives;

    /// <summary>
    /// Anchor class - all Queue client operations start here.
    /// See <see cref="QueueClient.Create(string)"/>
    /// </summary>
    public abstract class QueueClient : ClientEntity
    {
        MessageSender innerSender;
        MessageReceiver innerReceiver;

        protected QueueClient(ServiceBusConnection serviceBusConnection, string entityPath, ReceiveMode receiveMode)
            : base($"{nameof(QueueClient)}{ClientEntity.GetNextId()}({entityPath})")
        {
            this.ServiceBusConnection = serviceBusConnection;
            this.QueueName = entityPath;
            this.Mode = receiveMode;
        }

        public string QueueName { get; }

        public ReceiveMode Mode { get; private set; }

        public int PrefetchCount
        {
            get
            {
                return this.InnerReceiver.PrefetchCount;
            }

            set
            {
                this.InnerReceiver.PrefetchCount = value;
            }
        }

        internal MessageSender InnerSender
        {
            get
            {
                if (this.innerSender == null)
                {
                    lock (this.ThisLock)
                    {
                        if (this.innerSender == null)
                        {
                            this.innerSender = this.CreateMessageSender();
                        }
                    }
                }

                return this.innerSender;
            }
        }

        internal MessageReceiver InnerReceiver
        {
            get
            {
                if (this.innerReceiver == null)
                {
                    lock (this.ThisLock)
                    {
                        if (this.innerReceiver == null)
                        {
                            this.innerReceiver = this.CreateMessageReceiver();
                        }
                    }
                }

                return this.innerReceiver;
            }
        }

        protected object ThisLock { get; } = new object();

        protected ServiceBusConnection ServiceBusConnection { get; }

        public static QueueClient CreateFromConnectionString(string entityConnectionString)
        {
            return CreateFromConnectionString(entityConnectionString, ReceiveMode.PeekLock);
        }

        public static QueueClient CreateFromConnectionString(string entityConnectionString, ReceiveMode mode)
        {
            if (string.IsNullOrWhiteSpace(entityConnectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(entityConnectionString));
            }

            ServiceBusEntityConnection entityConnection = new ServiceBusEntityConnection(entityConnectionString);
            return entityConnection.CreateQueueClient(entityConnection.EntityPath, mode);
        }

        public static QueueClient Create(ServiceBusNamespaceConnection namespaceConnection, string entityPath)
        {
            return QueueClient.Create(namespaceConnection, entityPath, ReceiveMode.PeekLock);
        }

        public static QueueClient Create(ServiceBusNamespaceConnection namespaceConnection, string entityPath, ReceiveMode mode)
        {
            if (namespaceConnection == null)
            {
                throw Fx.Exception.Argument(nameof(namespaceConnection), "Namespace Connection is null. Create a connection using the NamespaceConnection class");
            }

            if (string.IsNullOrWhiteSpace(entityPath))
            {
                throw Fx.Exception.Argument(nameof(namespaceConnection), "Entity Path is null");
            }

            return namespaceConnection.CreateQueueClient(entityPath, mode);
        }

        public static QueueClient Create(ServiceBusEntityConnection entityConnection)
        {
            return QueueClient.Create(entityConnection, ReceiveMode.PeekLock);
        }

        public static QueueClient Create(ServiceBusEntityConnection entityConnection, ReceiveMode mode)
        {
            if (entityConnection == null)
            {
                throw Fx.Exception.Argument(nameof(entityConnection), "Namespace Connection is null. Create a connection using the NamespaceConnection class");
            }

            return entityConnection.CreateQueueClient(entityConnection.EntityPath, mode);
        }

        public sealed override async Task CloseAsync()
        {
            await this.InnerReceiver.CloseAsync().ConfigureAwait(false);
            await this.OnCloseAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Send <see cref="BrokeredMessage"/> to Queue.
        /// <see cref="SendAsync(BrokeredMessage)"/> sends the <see cref="BrokeredMessage"/> to a Service Gateway, which in-turn will forward the BrokeredMessage to the queue.
        /// </summary>
        /// <param name="brokeredMessage">the <see cref="BrokeredMessage"/> to be sent.</param>
        /// <returns>A Task that completes when the send operations is done.</returns>
        public Task SendAsync(BrokeredMessage brokeredMessage)
        {
            return this.SendAsync(new BrokeredMessage[] { brokeredMessage });
        }

        public async Task SendAsync(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            try
            {
                await this.InnerSender.SendAsync(brokeredMessages).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Send Exception
                throw;
            }
        }

        public async Task<BrokeredMessage> ReceiveAsync()
        {
            IList<BrokeredMessage> messages = await this.ReceiveAsync(1).ConfigureAwait(false);
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

        public async Task<IList<BrokeredMessage>> ReceiveAsync(int maxMessageCount)
        {
            try
            {
                return await this.InnerReceiver.ReceiveAsync(maxMessageCount).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Receive Exception
                throw;
            }
        }

        public async Task<BrokeredMessage> ReceiveBySequenceNumberAsync(long sequenceNumber)
        {
            IList<BrokeredMessage> messages = await this.ReceiveBySequenceNumberAsync(new long[] { sequenceNumber });
            if (messages != null && messages.Count > 0)
            {
                return messages[0];
            }

            return null;
        }

        public async Task<IList<BrokeredMessage>> ReceiveBySequenceNumberAsync(IEnumerable<long> sequenceNumbers)
        {
            try
            {
                return await this.InnerReceiver.ReceiveBySequenceNumberAsync(sequenceNumbers).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Receive Exception
                throw;
            }
        }

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <returns>The asynchronous operation that returns the <see cref="Microsoft.Azure.ServiceBus.BrokeredMessage" /> that represents the next message to be read.</returns>
        public Task<BrokeredMessage> PeekAsync()
        {
            try
            {
                return this.innerReceiver.PeekAsync();
            }
            catch (Exception)
            {
                // TODO: Log Peek Exception
                throw;
            }
        }

        /// <summary>
        /// Asynchronously reads the next batch of message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="maxMessageCount">The number of messages.</param>
        /// <returns>The asynchronous operation that returns a list of <see cref="Microsoft.Azure.ServiceBus.BrokeredMessage" /> to be read.</returns>
        public Task<IList<BrokeredMessage>> PeekAsync(int maxMessageCount)
        {
            try
            {
                return this.innerReceiver.PeekAsync(maxMessageCount);
            }
            catch (Exception)
            {
                // TODO: Log Receive Exception
                throw;
            }
        }

        /// <summary>
        /// Asynchronously reads the next message without changing the state of the receiver or the message source.
        /// </summary>
        /// <param name="fromSequenceNumber">The sequence number from where to read the message.</param>
        /// <returns>The asynchronous operation that returns the <see cref="Microsoft.Azure.ServiceBus.BrokeredMessage" /> that represents the next message to be read.</returns>
        public Task<BrokeredMessage> PeekBySequenceNumberAsync(long fromSequenceNumber)
        {
            try
            {
                return this.innerReceiver.PeekBySequenceNumberAsync(fromSequenceNumber);
            }
            catch (Exception)
            {
                // TODO: Log Receive Exception
                throw;
            }
        }

        public Task CompleteAsync(Guid lockToken)
        {
            return this.CompleteAsync(new Guid[] { lockToken });
        }

        public async Task CompleteAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.InnerReceiver.CompleteAsync(lockTokens).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Complete Exception
                throw;
            }
        }

        public Task AbandonAsync(Guid lockToken)
        {
            return this.AbandonAsync(new Guid[] { lockToken });
        }

        public async Task AbandonAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.InnerReceiver.AbandonAsync(lockTokens).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Complete Exception
                throw;
            }
        }

        public Task<MessageSession> AcceptMessageSessionAsync()
        {
            return this.AcceptMessageSessionAsync(null);
        }

        public async Task<MessageSession> AcceptMessageSessionAsync(string sessionId)
        {
            MessageSession session = null;
            try
            {
                session = await this.OnAcceptMessageSessionAsync(sessionId).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Complete Exception
                throw;
            }

            return session;
        }

        public Task DeferAsync(Guid lockToken)
        {
            return this.DeferAsync(new Guid[] { lockToken });
        }

        public async Task DeferAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.InnerReceiver.DeferAsync(lockTokens).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Complete Exception
                throw;
            }
        }

        public Task DeadLetterAsync(Guid lockToken)
        {
            return this.DeadLetterAsync(new Guid[] { lockToken });
        }

        public async Task DeadLetterAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.InnerReceiver.DeadLetterAsync(lockTokens).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Complete Exception
                throw;
            }
        }

        public async Task<DateTime> RenewMessageLockAsync(Guid lockToken)
        {
            try
            {
                return await this.InnerReceiver.RenewLockAsync(lockToken).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // TODO: Log Complete Exception
                throw;
            }
        }

        protected MessageSender CreateMessageSender()
        {
            return this.OnCreateMessageSender();
        }

        protected MessageReceiver CreateMessageReceiver()
        {
            return this.OnCreateMessageReceiver();
        }

        protected abstract MessageSender OnCreateMessageSender();

        protected abstract MessageReceiver OnCreateMessageReceiver();

        protected abstract Task<MessageSession> OnAcceptMessageSessionAsync(string sessionId);

        protected abstract Task OnCloseAsync();
    }
}