// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
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
                for (int i = 0; i < 9; i++)
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
    }
}