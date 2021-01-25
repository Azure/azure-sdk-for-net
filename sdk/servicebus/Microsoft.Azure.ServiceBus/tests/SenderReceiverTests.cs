// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Core;
    using Xunit;

    public class SenderReceiverTests : SenderReceiverClientTestBase
    {
        private static TimeSpan TwoSeconds = TimeSpan.FromSeconds(2);

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
        public async Task MessageReceiverAndMessageSenderCreationWorksAsExpected(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.PeekLock);

                try
                {
                    await this.PeekLockTestCase(sender, receiver, messageCount);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact(Skip="Flaky test. Tracked by #16265")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReceiveLotOfMessagesWithoutSettling()
        {
            // 5000 is the default limit on amqp session incoming window
            int messageCount = 5010;
            await ServiceBusScope.UsingQueueAsync(false, false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.PeekLock);

                try
                {
                    await this.ReceiveDeleteTestCase(sender, receiver, messageCount);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task TopicClientPeekLockDeferTestCase(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.PeekLock);

                try
                {
                    await
                        this.PeekLockDeferTestCase(sender, receiver, messageCount);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task PeekAsyncTest(bool partitioned, bool sessionEnabled, int messageCount = 10)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);

                try
                {
                    await this.PeekAsyncTestCase(sender, receiver, messageCount);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReceiveShouldReturnNoLaterThanServerWaitTimeTest(bool partitioned, bool sessionEnabled, int messageCount = 1)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);

                try
                {
                    await this.ReceiveShouldReturnNoLaterThanServerWaitTimeTestCase(sender, receiver, messageCount);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReceiveShouldThrowForServerTimeoutZeroTest(bool partitioned, bool sessionEnabled)
        {
            await ServiceBusScope.UsingQueueAsync(partitioned, sessionEnabled, async queueName =>
            {
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);

                try
                {
                    await this.ReceiveShouldThrowForServerTimeoutZero(receiver);
                }
                finally
                {
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ReceiverShouldUseTheLatestPrefetchCount()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);

                var receiver1 = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);
                var receiver2 = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete, prefetchCount: 1);

                Assert.Equal(0, receiver1.PrefetchCount);
                Assert.Equal(1, receiver2.PrefetchCount);

                try
                {
                    for (var i = 0; i < 9; i++)
                    {
                        var message = new Message(Encoding.UTF8.GetBytes("test" + i))
                        {
                            Label = "prefetch" + i
                        };
                        await sender.SendAsync(message).ConfigureAwait(false);
                    }

                    // Default prefetch count should be 0 for receiver 1.
                    Assert.Equal("prefetch0", (await receiver1.ReceiveAsync().ConfigureAwait(false)).Label);

                    // The first ReceiveAsync() would initialize the link and block prefetch2 for receiver2
                    Assert.Equal("prefetch1", (await receiver2.ReceiveAsync().ConfigureAwait(false)).Label);
                    await Task.Delay(TwoSeconds);

                    // Updating prefetch count on receiver1.
                    receiver1.PrefetchCount = 2;
                    await Task.Delay(TwoSeconds);

                    // The next operation should fetch prefetch3 and prefetch4.
                    Assert.Equal("prefetch3", (await receiver1.ReceiveAsync().ConfigureAwait(false)).Label);
                    await Task.Delay(TwoSeconds);

                    Assert.Equal("prefetch2", (await receiver2.ReceiveAsync().ConfigureAwait(false)).Label);
                    await Task.Delay(TwoSeconds);

                    // The next operation should block prefetch6 for receiver2.
                    Assert.Equal("prefetch5", (await receiver2.ReceiveAsync().ConfigureAwait(false)).Label);
                    await Task.Delay(TwoSeconds);

                    // Updates in prefetch count of receiver1 should not affect receiver2.
                    // Receiver2 should continue with 1 prefetch.
                    Assert.Equal("prefetch4", (await receiver1.ReceiveAsync().ConfigureAwait(false)).Label);
                    Assert.Equal("prefetch7", (await receiver1.ReceiveAsync().ConfigureAwait(false)).Label);
                    Assert.Equal("prefetch8", (await receiver1.ReceiveAsync().ConfigureAwait(false)).Label);
                }
                catch (Exception)
                {
                    // Cleanup
                    Message message;
                    do
                    {
                        message = await receiver1.ReceiveAsync(TimeSpan.FromSeconds(3)).ConfigureAwait(false);
                    } while (message != null);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver1.CloseAsync();
                    await receiver2.CloseAsync();
                }
            });
        }

        [Fact(Skip = "Flaky Test in Appveyor, fix and enable back")]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task WaitingReceiveShouldReturnImmediatelyWhenReceiverIsClosed()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                TestUtility.Log("Begin to receive from an empty queue.");
                Task quickTask;
                try
                {
                    quickTask = Task.Run(async () =>
                    {
                        try
                        {
                            await receiver.ReceiveAsync(TimeSpan.FromSeconds(40));
                        }
                        catch (Exception e)
                        {
                            TestUtility.Log("Unexpected exception: " + e);
                        }
                    });
                    await Task.Delay(2000);
                    TestUtility.Log("Waited for 2 Seconds for the ReceiveAsync to establish connection.");
                }
                finally
                {
                    await receiver.CloseAsync();
                    TestUtility.Log("Closed Receiver");
                }

                TestUtility.Log("Waiting for maximum 10 Secs");
                bool receiverReturnedInTime = false;
                using (var timeoutCancellationTokenSource = new CancellationTokenSource())
                {

                    var completedTask = await Task.WhenAny(quickTask, Task.Delay(10000, timeoutCancellationTokenSource.Token));
                    if (completedTask == quickTask)
                    {
                        timeoutCancellationTokenSource.Cancel();
                        receiverReturnedInTime = true;
                        TestUtility.Log("The Receiver closed in time.");
                    }
                    else
                    {
                        TestUtility.Log("The Receiver did not close in time.");
                    }
                }

                Assert.True(receiverReturnedInTime);
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task DeadLetterReasonShouldPropagateToTheReceivedMessage()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName);
                var dlqReceiver = new MessageReceiver(TestUtility.NamespaceConnectionString, EntityNameHelper.FormatDeadLetterPath(queueName), ReceiveMode.ReceiveAndDelete);

                try
                {
                    await sender.SendAsync(new Message(Encoding.UTF8.GetBytes("deadLetterTest2")));
                    var message = await receiver.ReceiveAsync();
                    Assert.NotNull(message);

                    await receiver.DeadLetterAsync(
                        message.SystemProperties.LockToken,
                        "deadLetterReason",
                        "deadLetterDescription");
                    var dlqMessage = await dlqReceiver.ReceiveAsync();

                    Assert.NotNull(dlqMessage);
                    Assert.True(dlqMessage.UserProperties.ContainsKey(Message.DeadLetterReasonHeader));
                    Assert.True(dlqMessage.UserProperties.ContainsKey(Message.DeadLetterErrorDescriptionHeader));
                    Assert.Equal("deadLetterReason", dlqMessage.UserProperties[Message.DeadLetterReasonHeader]);
                    Assert.Equal("deadLetterDescription", dlqMessage.UserProperties[Message.DeadLetterErrorDescriptionHeader]);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                    await dlqReceiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task DispositionWithUpdatedPropertiesShouldPropagateToReceivedMessage()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName);

                try
                {
                    await sender.SendAsync(new Message(Encoding.UTF8.GetBytes("propertiesToUpdate")));

                    var message = await receiver.ReceiveAsync();
                    Assert.NotNull(message);
                    await receiver.AbandonAsync(message.SystemProperties.LockToken, new Dictionary<string, object>
                    {
                        {"key", "value1"}
                    });

                    message = await receiver.ReceiveAsync();
                    Assert.NotNull(message);
                    Assert.True(message.UserProperties.ContainsKey("key"));
                    Assert.Equal("value1", message.UserProperties["key"]);

                    long sequenceNumber = message.SystemProperties.SequenceNumber;
                    await receiver.DeferAsync(message.SystemProperties.LockToken, new Dictionary<string, object>
                    {
                        {"key", "value2"}
                    });

                    message = await receiver.ReceiveDeferredMessageAsync(sequenceNumber);
                    Assert.NotNull(message);
                    Assert.True(message.UserProperties.ContainsKey("key"));
                    Assert.Equal("value2", message.UserProperties["key"]);

                    await receiver.CompleteAsync(message.SystemProperties.LockToken);
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task CancelScheduledMessageShouldThrowMessageNotFoundException()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);

                try
                {
                    long nonExistingSequenceNumber = 1000;
                    await Assert.ThrowsAsync<MessageNotFoundException>(
                        async () => await sender.CancelScheduledMessageAsync(nonExistingSequenceNumber));
                }
                finally
                {
                    await sender.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ClientThrowsUnauthorizedExceptionWhenUserDoesntHaveAccess()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var csb = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);
                csb.SasKeyName = "nonExistingKey";
                csb.EntityPath = queueName;

                var sender = new MessageSender(csb);

                try
                {
                    await Assert.ThrowsAsync<UnauthorizedException>(
                        async () => await sender.SendAsync(new Message()));

                    long nonExistingSequenceNumber = 1000;
                    await Assert.ThrowsAsync<UnauthorizedException>(
                        async () => await sender.CancelScheduledMessageAsync(nonExistingSequenceNumber));
                }
                finally
                {
                    await sender.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ClientThrowsObjectDisposedExceptionWhenUserCloseConnectionAndWouldUseOldSeviceBusConnection()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: true, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);
                try
                {
                    var messageBody = Encoding.UTF8.GetBytes("Message");
                    var message = new Message(messageBody);

                    await sender.SendAsync(message);
                    await sender.CloseAsync();

                    var recivedMessage = await receiver.ReceiveAsync().ConfigureAwait(false);
                    Assert.True(Encoding.UTF8.GetString(recivedMessage.Body) == Encoding.UTF8.GetString(messageBody));

                    var connection = sender.ServiceBusConnection;
                    Assert.Throws<ObjectDisposedException>(() => new MessageSender(connection, queueName));
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task SendMesageCloseConnectionCreateAnotherConnectionSendAgainMessage()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: true, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);
                try
                {
                    var messageBody = Encoding.UTF8.GetBytes("Message");
                    var message = new Message(messageBody);

                    await sender.SendAsync(message);
                    await sender.CloseAsync();

                    var recivedMessage = await receiver.ReceiveAsync().ConfigureAwait(false);
                    Assert.True(Encoding.UTF8.GetString(recivedMessage.Body) == Encoding.UTF8.GetString(messageBody));

                    var csb = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString)
                    {
                        EntityPath = queueName
                    };
                    ServiceBusConnection connection = new ServiceBusConnection(csb);
                    sender = new MessageSender(connection, queueName);

                    messageBody = Encoding.UTF8.GetBytes("Message 2");
                    message = new Message(messageBody);
                    await sender.SendAsync(message);

                    recivedMessage = await receiver.ReceiveAsync().ConfigureAwait(false);
                    Assert.True(Encoding.UTF8.GetString(recivedMessage.Body) == Encoding.UTF8.GetString(messageBody));
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task ClientsUseGlobalConnectionCloseFirstClientSecoundClientShouldSendMessage()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: true, sessionEnabled: false, async queueName =>
            {
                var csb = new ServiceBusConnectionStringBuilder(TestUtility.NamespaceConnectionString);
                var connection = new ServiceBusConnection(csb);
                var sender = new MessageSender(connection, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);
                try
                {
                    var messageBody = Encoding.UTF8.GetBytes("Message");
                    var message = new Message(messageBody);

                    await sender.SendAsync(message);
                    await sender.CloseAsync();

                    var recivedMessage = await receiver.ReceiveAsync().ConfigureAwait(false);
                    Assert.True(Encoding.UTF8.GetString(recivedMessage.Body) == Encoding.UTF8.GetString(messageBody));

                    connection = sender.ServiceBusConnection;
                    sender = new MessageSender(connection, queueName);
                    messageBody = Encoding.UTF8.GetBytes("Message 2");
                    message = new Message(messageBody);
                    await sender.SendAsync(message);
                    recivedMessage = await receiver.ReceiveAsync().ConfigureAwait(false);
                    Assert.True(Encoding.UTF8.GetString(recivedMessage.Body) == Encoding.UTF8.GetString(messageBody));

                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task MessageSenderShouldNotThrowWhenSendingEmptyCollection()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                try
                {
                    await sender.SendAsync(new List<Message>());
                    var message = await receiver.ReceiveAsync(TimeSpan.FromSeconds(3));
                    Assert.True(message == null, "Expected not to find any messages, but a message was received.");
                }
                finally
                {
                    await sender.CloseAsync();
                    await receiver.CloseAsync();
                }
            });
        }

    }
}