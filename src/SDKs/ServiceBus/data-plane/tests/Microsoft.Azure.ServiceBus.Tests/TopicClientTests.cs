// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class TopicClientTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedTopic, useSessionTopic }
            new object[] { false, false },
            new object[] { true, false }
        };
        
        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekLockTest(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName);

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
            });
        }

        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientReceiveDeleteTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
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
            });
        }

        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockWithAbandonTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
            var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName);
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
            });
        }

        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockWithDeadLetterTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName);

                // Create DLQ Client To Receive DeadLetteredMessages
                var subscriptionDeadletterPath = EntityNameHelper.FormatDeadLetterPath(subscriptionName);
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
            });
        }

        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientRenewLockTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName);
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
            });
        }

        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ScheduleMessagesAppearAfterScheduledTimeAsyncTest(bool partitioned, bool sessionEnabled, int messageCount = 1)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
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
            });
        }

        [LiveTheory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task CancelScheduledMessagesAsyncTest(bool partitioned, bool sessionEnabled, int messageCount = 1)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
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
            });
        }
    }
}