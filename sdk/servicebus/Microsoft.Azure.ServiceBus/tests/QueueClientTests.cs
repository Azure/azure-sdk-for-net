// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class QueueClientTests : SenderReceiverClientTestBase
    {
        public static IEnumerable<object[]> TestPermutations => new object[][]
        {
            // Expected structure: { usePartitionedQueue, useSessionQueue }
            new object[] { false, false },
            new object[] { true, false }
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekLockTest(bool partitioned, bool sessionEnabled,  int messageCount = 10)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekDeliveryCountTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekLockDeliveryCountTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }


        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReceiveDeleteTest(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);
                try
                {
                    await this.ReceiveDeleteTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount, TimeSpan.FromSeconds(10));
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekLockWithAbandonTest(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekLockWithDeadLetterTest(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task BasicRenewLockTest(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ScheduleMessagesAppearAfterScheduledTimeAsyncTest(bool partitioned, bool sessionEnabled, int messageCount = 1)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CancelScheduledMessagesAsyncTest(bool partitioned, bool sessionEnabled, int messageCount = 1)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
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
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task UpdatingPrefetchCountOnQueueClientUpdatesTheReceiverPrefetchCount()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
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
            });
        }
    }
}