// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Xunit.Abstractions;

    public abstract class TopicClientTestBase : SenderReceiverClientTestBase
    {
        protected TopicClientTestBase(ITestOutputHelper output)
            : base(output)
        {
        }

        protected string ConnectionString { get; set; }

        protected string SubscriptionName { get; set; }

        public async Task TopicClientPeekLockTestCase(int messageCount)
        {
            TopicClient topicClient = TopicClient.CreateFromConnectionString(this.ConnectionString);
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(this.ConnectionString, this.SubscriptionName);
            try
            {
                await this.PeekLockTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                subscriptionClient.Close();
                topicClient.Close();
            }
        }

        public async Task TopicClientReceiveDeleteTestCase(int messageCount)
        {
            TopicClient topicClient = TopicClient.CreateFromConnectionString(this.ConnectionString);
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(this.ConnectionString, this.SubscriptionName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ReceiveDeleteTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                subscriptionClient.Close();
                topicClient.Close();
            }
        }

        public async Task TopicClientPeekLockWithAbandonTestCase(int messageCount)
        {
            TopicClient topicClient = TopicClient.CreateFromConnectionString(this.ConnectionString);
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(this.ConnectionString, this.SubscriptionName);
            try
            {
                await this.PeekLockWithAbandonTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                subscriptionClient.Close();
                topicClient.Close();
            }
        }

        public async Task TopicClientPeekLockWithDeadLetterTestCase(int messageCount)
        {
            TopicClient topicClient = TopicClient.CreateFromConnectionString(this.ConnectionString);
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(this.ConnectionString, this.SubscriptionName);

            // Create DLQ Client To Receive DeadLetteredMessages
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(this.ConnectionString);
            string subscriptionDeadletterPath = EntityNameHelper.FormatDeadLetterPath(this.SubscriptionName);
            SubscriptionClient deadLetterSubscriptionClient = SubscriptionClient.CreateFromConnectionString(this.ConnectionString, subscriptionDeadletterPath);

            try
            {
                await this.PeekLockWithDeadLetterTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, deadLetterSubscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                deadLetterSubscriptionClient.Close();
                topicClient.Close();
            }
        }

        public async Task TopicClientPeekLockDeferTestCase(int messageCount)
        {
            TopicClient topicClient = TopicClient.CreateFromConnectionString(this.ConnectionString);
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(this.ConnectionString, this.SubscriptionName);
            try
            {
                await this.PeekLockDeferTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                subscriptionClient.Close();
                topicClient.Close();
            }
        }

        public async Task TopicClientRenewLockTestCase(int messageCount)
        {
            TopicClient topicClient = TopicClient.CreateFromConnectionString(this.ConnectionString);
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(this.ConnectionString, this.SubscriptionName);
            try
            {
                await this.RenewLockTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, messageCount);
            }
            finally
            {
                subscriptionClient.Close();
                topicClient.Close();
            }
        }
    }
}