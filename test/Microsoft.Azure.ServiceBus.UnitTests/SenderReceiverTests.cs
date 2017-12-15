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

        public static IEnumerable<object> TestPermutations => new object[]
        {
            new object[] { TestConstants.NonPartitionedQueueName },
            new object[] { TestConstants.PartitionedQueueName }
        };

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task MessageReceiverAndMessageSenderCreationWorksAsExpected(string queueName, int messageCount = 10)
        {
            var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
            var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.PeekLock);

            try
            {
                await this.PeekLockTestCase(sender, receiver, messageCount);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task TopicClientPeekLockDeferTestCase(string queueName, int messageCount = 10)
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
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task PeekAsyncTest(string queueName, int messageCount = 10)
        {
            var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
            var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);

            try
            {
                await this.PeekAsyncTestCase(sender, receiver, messageCount);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ReceiveShouldReturnNoLaterThanServerWaitTimeTest(string queueName, int messageCount = 1)
        {
            var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
            var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);

            try
            {
                await this.ReceiveShouldReturnNoLaterThanServerWaitTimeTestCase(sender, receiver, messageCount);
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        [Theory]
        [MemberData(nameof(TestPermutations))]
        [DisplayTestMethodName]
        async Task ReceiveShouldThrowForServerTimeoutZero(string queueName)
        {
            var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, receiveMode: ReceiveMode.ReceiveAndDelete);

            try
            {
                await this.ReceiveShouldThrowForServerTimeoutZero(receiver);
            }
            finally
            {
                await receiver.CloseAsync().ConfigureAwait(false);
            }
        }

        [Fact]
        [DisplayTestMethodName]
        async Task ReceiverShouldUseTheLatestPrefetchCount()
        {
            var queueName = TestConstants.NonPartitionedQueueName;

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
                await sender.CloseAsync().ConfigureAwait(false);
                await receiver1.CloseAsync().ConfigureAwait(false);
                await receiver2.CloseAsync().ConfigureAwait(false);
            }
        }

        [Fact(Skip = "Flaky Test in Appveyor, fix and enable back")]
        [DisplayTestMethodName]
        public async Task WaitingReceiveShouldReturnImmediatelyWhenReceiverIsClosed()
        {
            var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName, ReceiveMode.ReceiveAndDelete);

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
                await receiver.CloseAsync().ConfigureAwait(false);
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
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task DeadLetterReasonShouldPropagateToTheReceivedMessage()
        {
            var queueName = TestConstants.NonPartitionedQueueName;

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
                Assert.Equal(dlqMessage.UserProperties[Message.DeadLetterReasonHeader], "deadLetterReason");
                Assert.Equal(dlqMessage.UserProperties[Message.DeadLetterErrorDescriptionHeader], "deadLetterDescription");
            }
            finally
            {
                await sender.CloseAsync();
                await receiver.CloseAsync();
                await dlqReceiver.CloseAsync();
            }
        }

        [Fact]
        [DisplayTestMethodName]
        public async Task DispositionWithUpdatedPropertiesShouldPropagateToReceivedMessage()
        {
            var queueName = TestConstants.NonPartitionedQueueName;

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
                Assert.Equal(message.UserProperties["key"], "value1");

                long sequenceNumber = message.SystemProperties.SequenceNumber;
                await receiver.DeferAsync(message.SystemProperties.LockToken, new Dictionary<string, object>
                {
                    {"key", "value2"}
                });

                message = await receiver.ReceiveDeferredMessageAsync(sequenceNumber);
                Assert.NotNull(message);
                Assert.True(message.UserProperties.ContainsKey("key"));
                Assert.Equal(message.UserProperties["key"], "value2");

                await receiver.CompleteAsync(message.SystemProperties.LockToken);
            }
            finally
            {
                await sender.CloseAsync();
                await receiver.CloseAsync();
            }
        }
    }
}