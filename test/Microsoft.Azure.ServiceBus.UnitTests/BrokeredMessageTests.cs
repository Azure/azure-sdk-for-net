// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class BrokeredMessageTests
    {
        [Fact]
        [DisplayTestMethodName]
        void DefaultMessageIdGenerator()
        {
            var message = new Message();

            Assert.Null(message.MessageId);
        }

        [Fact]
        [DisplayTestMethodName]
        void InvalidMessageIdGenerator()
        {
            var exceptionToThrow = new Exception("boom!");
            Func<string> idGenerator = () =>
            {
                throw exceptionToThrow;
            };
            Message.SetMessageIdGenerator(idGenerator);

            var exception = Assert.Throws<InvalidOperationException>(() => new Message());
            Assert.Equal(exceptionToThrow, exception.InnerException);

            Message.SetMessageIdGenerator(null);
        }

        [Fact]
        [DisplayTestMethodName]
        void CustomMessageIdGenerator()
        {
            var seed = 1;
            Message.SetMessageIdGenerator(() => $"id-{seed++}");

            var message1 = new Message();
            var message2 = new Message();

            Assert.Equal("id-1", message1.MessageId);
            Assert.Equal("id-2", message2.MessageId);

            Message.SetMessageIdGenerator(null);
        }

        public class WhenQueryingIsReceivedProperty
        {
            [Fact]
            [DisplayTestMethodName]
            void Should_return_false_for_message_that_was_not_sent()
            {
                var message = new Message();
                message.Properties["dummy"] = "dummy";
                Assert.False(message.IsReceived);
            }

            [Theory]
            [DisplayTestMethodName]
            [InlineData(ReceiveMode.ReceiveAndDelete)]
            [InlineData(ReceiveMode.PeekLock)]
            async Task Should_return_true_for_message_that_was_sent_and_received(ReceiveMode receiveMode)
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, Constants.NonPartitionedQueueName, receiveMode);

                try
                {
                    await TestUtility.SendMessagesAsync(queueClient.InnerClient.InnerSender, 1);
                    var receivedMessages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerClient.InnerReceiver, 1);
                    Assert.True(receivedMessages.First().IsReceived);

                    // TODO: remove when per test cleanup is possible
                    if (receiveMode == ReceiveMode.PeekLock)
                    {
                        await queueClient.CompleteAsync(receivedMessages.First().LockToken);
                    }
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            }

            [Fact]
            [DisplayTestMethodName]
            async Task Should_return_true_for_peeked_message()
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, Constants.NonPartitionedQueueName, ReceiveMode.PeekLock);

                try
                {
                    await TestUtility.SendMessagesAsync(queueClient.InnerClient.InnerSender, 1);
                    var peekedMessage = await TestUtility.PeekMessageAsync(queueClient.InnerClient.InnerReceiver);
                    var result = peekedMessage.IsReceived;
                    Assert.True(result);
                }
                finally
                {
                    var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerClient.InnerReceiver, 1);
                    await TestUtility.CompleteMessagesAsync(queueClient.InnerClient.InnerReceiver, messages);
                    await queueClient.CloseAsync();
                }
            }
        }
    }
}