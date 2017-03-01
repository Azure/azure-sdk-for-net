// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class OnMessageQueueTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { Constants.NonPartitionedQueueName, 1 },
            new object[] { Constants.NonPartitionedQueueName, 10 },
            new object[] { Constants.PartitionedQueueName, 1 },
            new object[] { Constants.PartitionedQueueName, 10 },
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnMessagePeekLockWithAutoCompleteTrue(string queueName, int maxConcurrentCalls)
        {
            await this.OnMessageTestAsync(queueName, maxConcurrentCalls, ReceiveMode.PeekLock, true);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnMessagePeekLockWithAutoCompleteFalse(string queueName, int maxConcurrentCalls)
        {
            await this.OnMessageTestAsync(queueName, maxConcurrentCalls, ReceiveMode.PeekLock, false);
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task OnMessageReceiveDelete(string queueName, int maxConcurrentCalls)
        {
            await this.OnMessageTestAsync(queueName, maxConcurrentCalls, ReceiveMode.ReceiveAndDelete, false);
        }

        async Task OnMessageTestAsync(string queueName, int maxConcurrentCalls, ReceiveMode mode, bool autoComplete)
        {
            const int messageCount = 10;

            var queueClient = QueueClient.CreateFromConnectionString(
                TestUtility.GetEntityConnectionString(queueName),
                mode);
            try
            {
                await this.OnMessageAsyncTestCase(queueClient.InnerSender, queueClient.InnerReceiver, maxConcurrentCalls, autoComplete, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }
    }
}