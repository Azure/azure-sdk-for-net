// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class MessageTests
    {
        [Fact]
        void TestClone()
        {
            var messageBody = Encoding.UTF8.GetBytes("test");
            var messageId = Guid.NewGuid().ToString();
            var partitionKey = Guid.NewGuid().ToString();
            var sessionId = Guid.NewGuid().ToString();
            var correlationId = Guid.NewGuid().ToString();
            var label = Guid.NewGuid().ToString();
            var to = Guid.NewGuid().ToString();
            var contentType = Guid.NewGuid().ToString();
            var replyTo = Guid.NewGuid().ToString();
            var replyToSessionId = Guid.NewGuid().ToString();
            var publisher = Guid.NewGuid().ToString();
            var properties = Guid.NewGuid().ToString();

            var brokeredMessage = new Message(messageBody)
            {
                MessageId = messageId,
                PartitionKey = partitionKey,
                SessionId = sessionId,
                CorrelationId = correlationId,
                Label = label,
                To = to,
                ContentType = contentType,
                ReplyTo = replyTo,
                ReplyToSessionId = replyToSessionId
            };
            brokeredMessage.UserProperties.Add("UserProperty", "SomeUserProperty");

            var clone = brokeredMessage.Clone();
            brokeredMessage.Body = null;

            Assert.Null(brokeredMessage.Body);
            Assert.NotNull(clone.Body);
            Assert.Equal("SomeUserProperty", clone.UserProperties["UserProperty"]);
            Assert.Equal(messageId, clone.MessageId);
            Assert.Equal(partitionKey, clone.PartitionKey);
            Assert.Equal(sessionId, clone.SessionId);
            Assert.Equal(correlationId, clone.CorrelationId);
            Assert.Equal(label, clone.Label);
            Assert.Equal(to, clone.To);
            Assert.Equal(contentType, clone.ContentType);
            Assert.Equal(replyTo, clone.ReplyTo);
            Assert.Equal(replyToSessionId, clone.ReplyToSessionId);
        }

        public class WhenQueryingIsReceivedProperty
        {
            [Fact]
            [DisplayTestMethodName]
            void Should_return_false_for_message_that_was_not_sent()
            {
                var message = new Message();
                message.UserProperties["dummy"] = "dummy";
                Assert.False(message.SystemProperties.IsReceived);
            }

            [Theory]
            [DisplayTestMethodName]
            [InlineData(ReceiveMode.ReceiveAndDelete)]
            [InlineData(ReceiveMode.PeekLock)]
            async Task Should_return_true_for_message_that_was_sent_and_received(ReceiveMode receiveMode)
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName, receiveMode);

                try
                {
                    await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                    var receivedMessages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);
                    Assert.True(receivedMessages.First().SystemProperties.IsReceived);

                    // TODO: remove when per test cleanup is possible
                    if (receiveMode == ReceiveMode.PeekLock)
                    {
                        await queueClient.CompleteAsync(receivedMessages.First().SystemProperties.LockToken);
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
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName, ReceiveMode.PeekLock);

                try
                {
                    await TestUtility.SendMessagesAsync(queueClient.InnerSender, 1);
                    var peekedMessage = await TestUtility.PeekMessageAsync(queueClient.InnerReceiver);
                    var result = peekedMessage.SystemProperties.IsReceived;
                    Assert.True(result);
                }
                finally
                {
                    var messages = await TestUtility.ReceiveMessagesAsync(queueClient.InnerReceiver, 1);
                    await TestUtility.CompleteMessagesAsync(queueClient.InnerReceiver, messages);
                    await queueClient.CloseAsync();
                }
            }

            [Fact]
            [DisplayTestMethodName]
            public async Task MessageWithMaxMessageSizeShouldWorkAsExpected()
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, TestConstants.NonPartitionedQueueName, ReceiveMode.PeekLock);

                try
                {
                    int maxMessageSize = (256 * 1024) - 58;     // 58 bytes is the default serialization hit.
                    var maxPayload = Encoding.ASCII.GetBytes(new string('a', maxMessageSize));
                    var maxSizeMessage = new Message(maxPayload);

                    await queueClient.SendAsync(maxSizeMessage);

                    var receivedMaxSizeMessage = await queueClient.InnerReceiver.ReceiveAsync();
                    await queueClient.CompleteAsync(receivedMaxSizeMessage.SystemProperties.LockToken);
                    Assert.Equal(maxPayload, receivedMaxSizeMessage.Body);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                finally
                {
                    await queueClient.CloseAsync();
                }
            }
        }
    }
}