// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Xunit;

    public sealed class MessageReceiverTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedTopic, useSessionTopic, maxCurrentCalls }
            new object[] { false, false, 1 },
            new object[] { false, false, 5 },
            new object[] { true, false, 1 },
            new object[] { true, false, 5 },
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task UnregisterMessageHandlerPeekLockWithAutoCompleteTrue(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.UnregisterMessageHandlerAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task UnregisterMessageHandlerReceiveDelete(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.UnregisterMessageHandlerAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        private async Task UnregisterMessageHandlerAsync(bool partitioned, bool sessionEnabled, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            const int messageCount = 10;

            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    mode);

                try
                {
                    await this.MessageHandlerUnregisterAsyncTestCase(
                        topicClient.InnerSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        maxConcurrentCalls,
                        autoComplete,
                        messageCount);
                }
                finally
                {
                    await subscriptionClient.CloseAsync();
                    await topicClient.CloseAsync();
                }
            });
        }


        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task MultipleMessageHandlersPeekLockWithAutoCompleteTrue(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.MultipleMessageHandlersAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public Task MultipleMessageHandlersReceiveDelete(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.MultipleMessageHandlersAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        private async Task MultipleMessageHandlersAsync(bool partitioned, bool sessionEnabled, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            const int messageCount = 10;

            await ServiceBusScope.UsingTopicAsync(partitioned, sessionEnabled, async (topicName, subscriptionName) =>
            {
                var topicClient = new TopicClient(TestUtility.NamespaceConnectionString, topicName);
                var subscriptionClient = new SubscriptionClient(
                    TestUtility.NamespaceConnectionString,
                    topicName,
                    subscriptionName,
                    mode);

                try
                {
                    await this.MultipleMessageHandlerAsyncTestCase(
                        topicClient.InnerSender,
                        subscriptionClient.InnerSubscriptionClient.InnerReceiver,
                        maxConcurrentCalls,
                        autoComplete,
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