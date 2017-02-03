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
        async Task BrokeredMessageOperationsTest()
        {
            // Create QueueClient with ReceiveDelete,
            // Send and Receive a message, Try to Complete/Abandon/Defer/DeadLetter should throw InvalidOperationException()
            var queueClient = QueueClient.CreateFromConnectionString(
                TestUtility.GetEntityConnectionString(Constants.PartitionedQueueName),
                ReceiveMode.ReceiveAndDelete);

            await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
            var message = await queueClient.ReceiveAsync();
            Assert.NotNull(message);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.CompleteAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.AbandonAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.DeferAsync());
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await message.DeadLetterAsync());

            // Create a PeekLock queueClient and do rest of the operations
            // Send a Message, Receive/ Abandon and Complete it using BrokeredMessage methods
            queueClient = QueueClient.CreateFromConnectionString(
                TestUtility.GetEntityConnectionString(Constants.PartitionedQueueName),
                ReceiveMode.PeekLock);

            await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
            message = await queueClient.ReceiveAsync();
            Assert.NotNull(message);
            await message.AbandonAsync();
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            message = await queueClient.ReceiveAsync();
            await message.CompleteAsync();

            // Send a Message, Receive / DeadLetter using BrokeredMessage methods
            await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
            message = await queueClient.ReceiveAsync();
            await message.DeadLetterAsync();

            var builder = new ServiceBusConnectionStringBuilder(TestUtility.GetEntityConnectionString(Constants.PartitionedQueueName));
            builder.EntityPath = EntityNameHelper.FormatDeadLetterPath(queueClient.QueueName);
            var deadLetterQueueClient = QueueClient.CreateFromConnectionString(builder.ToString());
            message = await deadLetterQueueClient.ReceiveAsync();
            await message.CompleteAsync();

            // Send a Message, Receive/Defer using BrokeredMessage methods
            await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
            message = await queueClient.ReceiveAsync();
            var deferredSequenceNumber = message.SequenceNumber;
            await message.DeferAsync();

            var deferredMessage = await queueClient.ReceiveBySequenceNumberAsync(deferredSequenceNumber);
            await deferredMessage.CompleteAsync();

            await queueClient.CloseAsync();
        }

        [Fact]
        [DisplayTestMethodName]
        void DefaultMessageIdGenerator()
        {
            var message = new BrokeredMessage();

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
            BrokeredMessage.SetMessageIdGenerator(idGenerator);

            var exception = Assert.Throws<InvalidOperationException>(() => new BrokeredMessage());
            Assert.Equal(exceptionToThrow, exception.InnerException);

            BrokeredMessage.SetMessageIdGenerator(null);
        }

        [Fact]
        [DisplayTestMethodName]
        void CustomMessageIdGenerator()
        {
            var seed = 1;
            BrokeredMessage.SetMessageIdGenerator(() => $"id-{seed++}");

            var message1 = new BrokeredMessage();
            var message2 = new BrokeredMessage();

            Assert.Equal("id-1", message1.MessageId);
            Assert.Equal("id-2", message2.MessageId);

            BrokeredMessage.SetMessageIdGenerator(null);
        }

        public class When_querying_IsReceived_property
        {
            [Fact]
            [DisplayTestMethodName]
            void Should_return_false_for_message_that_was_not_sent()
            {
                var message = new BrokeredMessage();
                message.Properties["dummy"] = "dummy";
                Assert.False(message.IsReceived);
            }

            [Theory]
            [DisplayTestMethodName]
            [InlineData(ReceiveMode.ReceiveAndDelete)]
            [InlineData(ReceiveMode.PeekLock)]
            async Task Should_return_true_for_message_that_was_sent_and_received(ReceiveMode receiveMode)
            {
                var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(Constants.NonPartitionedQueueName), receiveMode);
                try
                {
                    await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                    var receivedMessages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);
                    Assert.True(receivedMessages.First().IsReceived);

                    // TODO: remove when per test cleanup is possible
                    if (receiveMode == ReceiveMode.PeekLock)
                    {
                        await receivedMessages.First().CompleteAsync();
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
                var queueClient = QueueClient.CreateFromConnectionString(TestUtility.GetEntityConnectionString(Constants.NonPartitionedQueueName), ReceiveMode.PeekLock);
                try
                {
                    await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                    var peekedMessage = await TestUtility.PeekMessageAsync(queueClient.InnerReceiver);
                    var result = peekedMessage.IsReceived;
                    Assert.True(result);
                }
                finally
                {
                    var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);
                    await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, messages);
                    await queueClient.CloseAsync();
                }
            }
        }
    }
}