// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System.Threading.Tasks;
    using Azure.Amqp;
    using Core;
    using Primitives;

    class AmqpClient : IInnerSenderReceiver
    {
        MessageSender innerSender;
        MessageReceiver innerReceiver;

        internal AmqpClient(
            ServiceBusConnection servicebusConnection,
            string entityPath,
            MessagingEntityType entityType,
            RetryPolicy retryPolicy,
            ReceiveMode mode = ReceiveMode.ReceiveAndDelete)
        {
            this.ServiceBusConnection = servicebusConnection;
            this.EntityPath = entityPath;
            this.MessagingEntityType = entityType;
            this.ReceiveMode = mode;
            this.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                servicebusConnection.SasKeyName,
                servicebusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(this.TokenProvider, servicebusConnection.OperationTimeout);
            this.RetryPolicy = retryPolicy;
        }

        public MessageSender InnerSender
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

        public MessageReceiver InnerReceiver
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

        internal ServiceBusConnection ServiceBusConnection { get; set; }

        internal string EntityPath { get; set; }

        internal MessagingEntityType MessagingEntityType { get; set; }

        internal ReceiveMode ReceiveMode { get; set; }

        internal ICbsTokenProvider CbsTokenProvider { get; }

        internal RetryPolicy RetryPolicy { get; }

        protected object ThisLock { get; } = new object();

        TokenProvider TokenProvider { get; }

        public async Task CloseAsync()
        {
            // Closing the Connection will also close all Links associated with it.
            await this.ServiceBusConnection.CloseAsync().ConfigureAwait(false);
            await this.InnerReceiver.CloseAsync().ConfigureAwait(false);
            await this.InnerSender.CloseAsync().ConfigureAwait(false);
        }

        MessageSender CreateMessageSender()
        {
            return new AmqpMessageSender(
                this.EntityPath,
                this.MessagingEntityType,
                this.ServiceBusConnection,
                this.CbsTokenProvider,
                this.RetryPolicy);
        }

        MessageReceiver CreateMessageReceiver()
        {
            return new AmqpMessageReceiver(
                this.EntityPath,
                this.MessagingEntityType,
                this.ReceiveMode,
                this.ServiceBusConnection.PrefetchCount,
                this.ServiceBusConnection,
                this.CbsTokenProvider,
                this.RetryPolicy);
        }
    }
}