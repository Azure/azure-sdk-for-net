// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class TopicClientTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { TestConstants.NonPartitionedTopicName },
            new object[] { TestConstants.PartitionedTopicName }
        };

        string SubscriptionName => TestConstants.SubscriptionName;

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekLockTest(string topicName, int messageCount = 10)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName);

            try
            {
                await this.PeekLockTestCase(
                    topicClient.InnerSender,
                    subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                    messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientReceiveDeleteTestCase(string topicName, int messageCount = 10)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName,
                ReceiveMode.ReceiveAndDelete);
            try
            {
                await
                    this.ReceiveDeleteTestCase(
                        topicClient.InnerSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockWithAbandonTestCase(string topicName, int messageCount = 10)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName);
            try
            {
                await
                    this.PeekLockWithAbandonTestCase(
                        topicClient.InnerSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockWithDeadLetterTestCase(string topicName, int messageCount = 10)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName);

            // Create DLQ Client To Receive DeadLetteredMessages
            var subscriptionDeadletterPath = EntityNameHelper.FormatDeadLetterPath(this.SubscriptionName);
            var deadLetterSubscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                subscriptionDeadletterPath);

            try
            {
                await
                    this.PeekLockWithDeadLetterTestCase(
                        topicClient.InnerSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        deadLetterSubscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            }
            finally
            {
                await deadLetterSubscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
                await subscriptionClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientRenewLockTestCase(string topicName, int messageCount = 10)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName);
            try
            {
                await this.RenewLockTestCase(
                    topicClient.InnerSender,
                    subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                    messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ScheduleMessagesAppearAfterScheduledTimeAsyncTest(string topicName, int messageCount = 1)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName,
                ReceiveMode.ReceiveAndDelete);
            try
            {
                await
                    this.ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(
                        topicClient.InnerSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task CancelScheduledMessagesAsyncTest(string topicName, int messageCount = 1)
        {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
            var subscriptionClient = new SubscriptionClient(
                TestUtility.NamespaceConnectionString,
                topicName,
                this.SubscriptionName,
                ReceiveMode.ReceiveAndDelete);
            try
            {
                await
                    this.CancelScheduledMessagesAsyncTestCase(
                        topicClient.InnerSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }
    }
}