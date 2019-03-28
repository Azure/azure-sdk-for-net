﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class OnMessageTopicSubscriptionTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedTopic, useSessionTopic, maxCurrentCalls }
            new object[] { false, false, 5 },
            new object[] { true, false, 5 },
        };
                
        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        Task OnMessagePeekLockWithAutoCompleteTrue(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnMessageTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        Task OnMessageReceiveDelete(bool partitioned, bool sessionEnabled, int maxConcurrentCalls)
        {
            return this.OnMessageTestAsync(partitioned, sessionEnabled, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        async Task OnMessageTestAsync(bool partitioned, bool sessionEnabled, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
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
                    await this.OnMessageAsyncTestCase(
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