// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Anchor class - all Queue client operations start here.
    /// See <see cref="QueueClient.Create(string)"/>
    /// </summary>
    public abstract class QueueClient : ClientEntity
    {
        MessageSender innerSender;
        MessageReceiver innerReceiver;


        internal QueueClient(ServiceBusConnectionSettings connectionSettings, ReceiveMode receiveMode)
            : base($"{nameof(QueueClient)}{ClientEntity.GetNextId()}({connectionSettings.EntityPath})")
        {
            this.ConnectionSettings = connectionSettings;
            this.QueueName = connectionSettings.EntityPath;
            this.Mode = receiveMode;
        }

        public string QueueName { get; }

        public ServiceBusConnectionSettings ConnectionSettings { get; }

        public ReceiveMode Mode { get; private set; }

        public int PrefetchCount { get; set; }

        protected object ThisLock { get; } = new object();

        MessageSender InnerSender
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

        MessageReceiver InnerReceiver
        {
            get
            {
                if(this.innerReceiver == null)
                {
                    lock(this.ThisLock)
                    {
                        if(this.innerReceiver == null)
                        {
                            this.innerReceiver = this.CreateMessageReceiver();
                        }
                    }
                }

                return this.innerReceiver;
            }
        }

        public static QueueClient Create(string connectionString)
        {
            return Create(connectionString, ReceiveMode.PeekLock);
        }

        public static QueueClient Create(string connectionString, ReceiveMode mode)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(connectionString));
            }

            var connectionSettings = new ServiceBusConnectionSettings(connectionString);
            return Create(connectionSettings, mode);
        }

        public static QueueClient Create(string connectionString, string path)
        {
            return Create(connectionString, path, ReceiveMode.PeekLock);
        }

        public static QueueClient Create(string connectionString, string path, ReceiveMode mode)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(connectionString));
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(path));
            }

            var connectionSettings = new ServiceBusConnectionSettings(connectionString) {EntityPath = path};

            return Create(connectionSettings, mode);
        }

        public static QueueClient Create(ServiceBusConnectionSettings connectionSettings)
        {
            return Create(connectionSettings, ReceiveMode.PeekLock);
        }

        public static QueueClient Create(ServiceBusConnectionSettings connectionSettings, ReceiveMode mode)
        {
            if (connectionSettings == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(connectionSettings));
            }
            else if (string.IsNullOrWhiteSpace(connectionSettings.EntityPath))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(connectionSettings.EntityPath));
            }

            QueueClient QueueClient;
            QueueClient = connectionSettings.CreateQueueClient(mode);
            return QueueClient;
        }

        public sealed override async Task CloseAsync()
        {
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
            return this.SendAsync(new[] { brokeredMessage });
        }

        public async Task SendAsync(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            try
            {
                await this.InnerSender.SendAsync(brokeredMessages).ConfigureAwait(false);
            }
            catch (Exception)
            {
                //TODO: Log Send Exception
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
                return await this.InnerReceiver.ReceiveAsync(maxMessageCount);
            }
            catch(Exception)
            {
                //TODO: Log Receive Exception
                throw;
            }
        }

        public Task CompleteAsync(Guid lockToken)
        {
            return this.CompleteAsync(new Guid[] {lockToken});
        }

        public async Task CompleteAsync(IEnumerable<Guid> lockTokens)
        {
            try
            {
                await this.InnerReceiver.CompleteAsync(lockTokens).ConfigureAwait(false);
            }
            catch (Exception)
            {
                //TODO: Log Complete Exception
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
                //TODO: Log Complete Exception
                throw;
            }
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
                //TODO: Log Complete Exception
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
                //TODO: Log Complete Exception
                throw;
            }
        }

        internal MessageSender CreateMessageSender()
        {
            return this.OnCreateMessageSender();
        }

        internal MessageReceiver CreateMessageReceiver()
        {
            return this.OnCreateMessageReceiver();
        }

        internal abstract MessageSender OnCreateMessageSender();

        internal abstract MessageReceiver OnCreateMessageReceiver();

        protected abstract Task OnCloseAsync();
    }
}
