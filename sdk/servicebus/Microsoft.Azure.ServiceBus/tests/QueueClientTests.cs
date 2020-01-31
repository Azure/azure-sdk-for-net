// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using Microsoft.Azure.ServiceBus.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
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
        public async Task PeekLockTest(bool partitioned, bool sessionEnabled, int messageCount = 10)
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

        [LiveTest]
        [DisplayTestMethodName]
        [Fact]
        public void Track1Receive_ReceiveAndDelete()
        {
            var queueName = "josh";
            var connString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONN_STRING");

            // default ReceiveMode of PeekLock is used
            var queueClient = new QueueClient(connString, queueName, ReceiveMode.ReceiveAndDelete);

            // Set the message handler options and register the Exception handler
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionHandlerAsync)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            // Register the function that will process messages
            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        [LiveTest]
        [DisplayTestMethodName]
        [Fact]
        public async Task Track1Receive_ReceiveAndDeleteSession()
        {
            var queueName = "josh";
            var connString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONN_STRING");

            var messageSender = new MessageReceiver(connString, queueName);
            IList<Message> messages = await messageSender.PeekAsync(maxMessageCount: 10);


            var topicName = "joshtopic";
            var topicClient = new TopicClient(connString, topicName);
            ServiceBusConnection connection = topicClient.ServiceBusConnection;
            var queueClient = new QueueClient(connection, queueName);
            queueClient.CompleteAsync()
            var sessionId = "1";

            var sessionClient = new SessionClient(connString, queueName);
            var sessionReceiver = await sessionClient.AcceptMessageSessionAsync(sessionId);
            Message receivedMessage = await sessionReceiver.ReceiveAsync();
            await sessionReceiver.CompleteAsync(message.SystemProperties.LockToken);

            IList<Message> peekedMessages = await sessionReceiver.PeekAsync(maxMessageCount: 10);


            Message message = GetMessages();
            await queueClient.SendAsync(message);

            // Set the message handler options and register the Exception handler
            var sessionHandlerOptions = new SessionHandlerOptions(ExceptionHandlerAsync)
            {
                MaxConcurrentSessions = 1,
                AutoComplete = false
            };

            // Register the function that will process messages
            queueClient.RegisterSessionHandler(ProcessMessagesAsync, sessionHandlerOptions);
        }


        [LiveTest]
        [DisplayTestMethodName]
        [Fact]
        public async Task Track1Receive_ReceiveByPull()
        {
            var queueName = "josh";
            var connString = Environment.GetEnvironmentVariable("SERVICE_BUS_CONN_STRING");

            // default ReceiveMode of PeekLock is used
            var receiverClient = new MessageReceiver(connString, queueName, ReceiveMode.ReceiveAndDelete);

            Message messages = await receiverClient.ReceiveAsync();

            // Set the message handler options and register the Exception handler
            var sessionHandlerOptions = new SessionHandlerOptions(ExceptionHandlerAsync)
            {
                MaxConcurrentSessions = 1,
                AutoComplete = false
            };

            // Register the function that will process messages
            queueClient.RegisterSessionHandler(ProcessMessagesAsync, sessionHandlerOptions);
        }

        static Task ExceptionHandlerAsync(ExceptionReceivedEventArgs args)
        {
            return Task.CompletedTask;
        }

        static async Task ProcessMessagesAsync(IMessageSession session, Message message, CancellationToken token)
        {
            // Process the message
            
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
            var queueClient = new QueueClient(connString, queueName, ReceiveMode.ReceiveAndDelete);
            // Complete the message so that it is not received again.
            await queueClient.CompleteAsync(message.SystemProperties.LockToken);
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
                    await this.ReceiveDeleteTestCase(queueClient.InnerSender, queueClient.InnerReceiver, messageCount);
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