// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.Messaging
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

        internal QueueClient(ServiceBusConnectionSettings connectionSettings)
            : base($"{nameof(QueueClient)}{ClientEntity.GetNextId()}({connectionSettings.EntityPath})")
        {
            this.ConnectionSettings = connectionSettings;
            this.QueueName = connectionSettings.EntityPath;
        }

        public string QueueName { get; }

        public ServiceBusConnectionSettings ConnectionSettings { get; }

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

        public static QueueClient Create(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw Fx.Exception.ArgumentNullOrWhiteSpace(nameof(connectionString));
            }

            var connectionSettings = new ServiceBusConnectionSettings(connectionString);
            return Create(connectionSettings);
        }

        public static QueueClient Create(ServiceBusConnectionSettings connectionSettings)
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
            QueueClient = connectionSettings.CreateQueueClient();
            return QueueClient;
        }

        public sealed override async Task CloseAsync()
        {
            await this.OnCloseAsync();
        }

        /// <summary>
        /// Send <see cref="BrokeredMessage"/> to Queue. 
        /// <see cref="SendAsync(BrokeredMessage)"/> sends the <see cref="BrokeredMessage"/> to a Service Gateway, which in-turn will forward the BrokeredMessage to the queue.
        /// </summary>
        /// <param name="brokeredMessage">the <see cref="BrokeredMessage"/> to be sent.</param>
        /// <returns>A Task that completes when the send operations is done.</returns>
        public Task SendAsync(BrokeredMessage brokeredMessage)
        {
            if (brokeredMessage == null)
            {
                throw Fx.Exception.ArgumentNull(nameof(brokeredMessage));
            }

            return this.SendAsync(new[] { brokeredMessage });
        }

        public async Task SendAsync(IEnumerable<BrokeredMessage> brokeredMessages)
        {
            int count = MessageSender.ValidateMessages(brokeredMessages);

            try
            {
                await this.InnerSender.SendAsync(brokeredMessages);
            }
            catch (Exception)
            {
                //TODO: Log Send Exception
                throw;
            }
        }

        internal MessageSender CreateMessageSender()
        {
            return this.OnCreateMessageSender();
        }

        internal abstract MessageSender OnCreateMessageSender();

        protected abstract Task OnCloseAsync();
    }
}
