// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class OnMessageTopicSubscriptionTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { Constants.NonPartitionedTopicName, 5 },
            new object[] { Constants.PartitionedTopicName, 5 },
        };

        string SubscriptionName => Constants.SubscriptionName;

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnMessagePeekLockWithAutoCompleteTrue(string topicName, int maxConcurrentCalls)
        {
            await this.OnMessageTestAsync(topicName, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnMessageReceiveDelete(string topicName, int maxConcurrentCalls)
        {
            await this.OnMessageTestAsync(topicName, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        async Task OnMessageTestAsync(string topicName, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            const int messageCount = 10;

            var entityConnectionString = TestUtility.GetEntityConnectionString(topicName);
            var topicClient = TopicClient.CreateFromConnectionString(entityConnectionString);
            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(entityConnectionString, this.SubscriptionName, mode);
            try
            {
                await this.OnMessageAsyncTestCase(topicClient.InnerSender, subscriptionClient.InnerReceiver, maxConcurrentCalls, autoComplete, messageCount);
            }
            finally
            {
                await subscriptionClient.CloseAsync();
                await topicClient.CloseAsync();
            }
        }
    }
}