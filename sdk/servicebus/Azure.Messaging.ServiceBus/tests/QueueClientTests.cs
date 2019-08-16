// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.ServiceBus.UnitTests
{
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver();
                await this.PeekLockTestCase(sender, receiver, messageCount);
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver();
                
                try
                {

                    await TestUtility.SendMessagesAsync(sender, 1);

                    var message = await TestUtility.PeekMessageAsync(receiver);

                    Assert.Equal(0, message.DeliveryCount);
                }
                finally
                {
                    var messageToDelete = await TestUtility.ReceiveMessagesAsync(receiver, 1);
                    await TestUtility.CompleteMessagesAsync(receiver, messageToDelete);
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver();

                await TestUtility.SendMessagesAsync(sender, 1);

                var messages = await TestUtility.ReceiveMessagesAsync(receiver, 1);

                await TestUtility.CompleteMessagesAsync(receiver, messages);

                Assert.Equal(1, messages.First().DeliveryCount);
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);
                await this.ReceiveDeleteTestCase(sender, receiver, messageCount);
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver();
                await this.PeekLockWithAbandonTestCase(sender, receiver, messageCount);
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver();

                // Create DLQ Client To Receive DeadLetteredMessages
                var deadLetterQueueClient = new QueueClient(TestUtility.NamespaceConnectionString, EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName));
                
                await using var deadLetterreceiver = deadLetterQueueClient.CreateReceiver();
                await
                    this.PeekLockWithDeadLetterTestCase(
                        sender,
                        receiver,
                        deadLetterreceiver,
                        messageCount);
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver();
                await this.RenewLockTestCase(sender, receiver, messageCount);
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);
                await this.ScheduleMessagesAppearAfterScheduledTimeAsyncTestCase(sender, receiver, messageCount);
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
                await using var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName);
                await using var sender = queueClient.CreateSender();
                await using var receiver = queueClient.CreateReceiver(ReceiveMode.ReceiveAndDelete);
                await this.CancelScheduledMessagesAsyncTestCase(sender, receiver, messageCount);
            });
        }
    }
}