// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class QueueClientTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            new object[] { TestConstants.NonPartitionedQueueName },
            new object[] { TestConstants.PartitionedQueueName }
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task PeekLockTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
            try
            {
                await this.PeekLockTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task PeekDeliveryCountTest(string queueName)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
            try
            {
                await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);

                var message = await TestUtility.PeekMessageAsync(queueClient.InnerReceiver);

                Assert.Equal(0, message.SystemProperties.DeliveryCount);
            }
            finally
            {
                var messageToDelete = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);
                await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, messageToDelete);

                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task PeekLockDeliveryCountTest(string queueName)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
            try
            {
                await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);

                var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);

                await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, messages);

                Assert.Equal(1, messages.First().SystemProperties.DeliveryCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }


        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task ReceiveDeleteTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ReceiveDeleteTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task PeekLockWithAbandonTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
            try
            {
                await this.PeekLockWithAbandonTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task PeekLockWithDeadLetterTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);

            // Create DLQ Client To Receive DeadLetteredMessages
            var deadLetterQueueClient = new QueueClient(TestUtility.NamespaceConnectionString, EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName));

            try
            {
                await
                    this.PeekLockWithDeadLetterTestCase(
                        queueClient.InnerSender,
                        queueClient.InnerReceiver,
                        deadLetterQueueClient.InnerReceiver,
                        messageCount);
            }
            finally
            {
                await deadLetterQueueClient.CloseAsync();
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task BasicRenewLockTest(string queueName, int messageCount = 10)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
            try
            {
                await this.RenewLockTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task ScheduleMessagesAppearAfterScheduledTimeAsyncTest(string queueName, int messageCount = 1)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        async Task CancelScheduledMessagesAsyncTest(string queueName, int messageCount = 1)
        {
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
            try
            {
                await this.CancelScheduledMessagesAsyncTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        async Task UpdatingPrefetchCountOnQueueClientUpdatesTheReceiverPrefetchCount()
        {
            var queueName = TestConstants.NonPartitionedQueueName;
            var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

            try
            {
                Assert.Equal(0, queueClient.PrefetchCount);

                queueClient.PrefetchCount = 2;
                Assert.Equal(2, queueClient.PrefetchCount);

                // Message receiver should be created with latest prefetch count (lazy load).
                Assert.Equal(2, queueClient.InnerReceiver.PrefetchCount);

                queueClient.PrefetchCount = 3;
                Assert.Equal(3, queueClient.PrefetchCount);

                // Already created message receiver should have its prefetch value updated.
                Assert.Equal(3, queueClient.InnerReceiver.PrefetchCount);
            }
            finally
            {
                await queueClient.CloseAsync();
            }
        }
    }
}