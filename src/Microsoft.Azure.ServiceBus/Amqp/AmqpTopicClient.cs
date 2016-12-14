// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    sealed class AmqpTopicClient : TopicClient
    {
        public AmqpTopicClient(ServiceBusConnection servicebusConnection, string entityPath)
            : base(servicebusConnection, entityPath)
        {
            this.TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(this.ServiceBusConnection.SasKeyName, this.ServiceBusConnection.SasKey);
            this.CbsTokenProvider = new TokenProviderAdapter(this.TokenProvider, this.ServiceBusConnection.OperationTimeout);
        }

        internal ICbsTokenProvider CbsTokenProvider { get; }

        TokenProvider TokenProvider { get; }

        protected override MessageSender OnCreateMessageSender()
        {
            return new AmqpMessageSender(this.TopicName, MessagingEntityType.Topic, this.ServiceBusConnection, this.CbsTokenProvider);
        }

        protected override Task OnCloseAsync()
        {
            // Closing the Connection will also close all Links associated with it.
            return this.ServiceBusConnection.CloseAsync();
        }
    }
}