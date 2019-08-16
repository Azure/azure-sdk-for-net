// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.ServiceBus.UnitTests
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

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekLockTest(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                await using var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                await using var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName);

                var topicClientSender = topicClient.CreateSender();
                await this.PeekLockTestCase(
                    topicClientSender,
                    subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                    messageCount);
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TopicClientReceiveDeleteTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                await using  var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                await using var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    ReceiveMode.ReceiveAndDelete);
                var topicClientSender = topicClient.CreateSender();
                await
                    this.ReceiveDeleteTestCase(
                        topicClientSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TopicClientPeekLockWithAbandonTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                await using var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                await using var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName);
                var topicClientSender = topicClient.CreateSender();
                await
                    this.PeekLockWithAbandonTestCase(
                        topicClientSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TopicClientPeekLockWithDeadLetterTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                await using var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                await using var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName);

                // Create DLQ Client To Receive DeadLetteredMessages
                var subscriptionDeadletterPath = EntityNameHelper.FormatDeadLetterPath(subscriptionName);
                await using var deadLetterSubscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionDeadletterPath);

                var topicClientSender = topicClient.CreateSender();
                await
                    this.PeekLockWithDeadLetterTestCase(
                        topicClientSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        deadLetterSubscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TopicClientRenewLockTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                await using var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                await using var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName);
                var topicClientSender = topicClient.CreateSender();
                await this.RenewLockTestCase(
                    topicClientSender,
                    subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                    messageCount);
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ScheduleMessagesAppearAfterScheduledTimeAsyncTest(bool partitioned, bool sessionEnabled, int messageCount = 1)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                await using var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                await using var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    ReceiveMode.ReceiveAndDelete);
                var topicClientSender = topicClient.CreateSender();
                await
                    this.ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(
                        topicClientSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CancelScheduledMessagesAsyncTest(bool partitioned, bool sessionEnabled, int messageCount = 1)
        {
            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                await using var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                await using var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    ReceiveMode.ReceiveAndDelete);
                var topicClientSender = topicClient.CreateSender();
                await
                    this.CancelScheduledMessagesAsyncTestCase(
                        topicClientSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        messageCount);
            });
        }
    }
}