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

                await using var topicClientSender = topicClient.CreateSender();
                await using var subscriptionReceiver = subscriptionClient.CreateReceiver();
                await this.PeekLockTestCase(
                    topicClientSender,
                    subscriptionReceiver,
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
                    subscriptionName);
                await using var topicClientSender = topicClient.CreateSender();
                await using var subscriptionReceiver = subscriptionClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);
                await this.ReceiveDeleteTestCase(
                        topicClientSender,
                        subscriptionReceiver,
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
                await using var topicClientSender = topicClient.CreateSender();
                await using var subscriptionReceiver = subscriptionClient.CreateReceiver();
                await
                    this.PeekLockWithAbandonTestCase(
                        topicClientSender,
                        subscriptionReceiver,
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
                await using var deadLetterSubscriptionReceiver = deadLetterSubscriptionClient.CreateReceiver();

                await using var topicClientSender = topicClient.CreateSender();
                await using var subscriptionReceiver = subscriptionClient.CreateReceiver();
                await
                    this.PeekLockWithDeadLetterTestCase(
                        topicClientSender,
                        subscriptionReceiver,
                        deadLetterSubscriptionReceiver,
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
                await using var topicClientSender = topicClient.CreateSender();
                await using var subscriptionReceiver = subscriptionClient.CreateReceiver();
                await this.RenewLockTestCase(
                    topicClientSender,
                    subscriptionReceiver,
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
                    subscriptionName);
                await using var topicClientSender = topicClient.CreateSender();
                await using var subscriptionReceiver = subscriptionClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);
                await
                    this.ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(
                        topicClientSender,
                        subscriptionReceiver,
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
                    subscriptionName);
                await using var topicClientSender = topicClient.CreateSender();
                await using var subscriptionReceiver = subscriptionClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);
                await
                    this.CancelScheduledMessagesAsyncTestCase(
                        topicClientSender,
                        subscriptionReceiver,
                        messageCount);
            });
        }
    }
}