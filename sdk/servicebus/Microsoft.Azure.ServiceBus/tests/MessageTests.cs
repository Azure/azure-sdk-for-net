// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.ServiceBus.Core;
    using Xunit;

    public class MessageTests
    {
        [Fact]
        [DisplayTestMethodName]
        public void TestClone()
        {
            var messageBody = Encoding.UTF8.GetBytes("test");
            var messageId = Guid.NewGuid().ToString();
            var viaPartitionKey = Guid.NewGuid().ToString();
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
                ViaPartitionKey = viaPartitionKey,
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
            Assert.Equal(viaPartitionKey, clone.ViaPartitionKey);
            Assert.Equal(sessionId, clone.SessionId);
            Assert.Equal(correlationId, clone.CorrelationId);
            Assert.Equal(label, clone.Label);
            Assert.Equal(to, clone.To);
            Assert.Equal(contentType, clone.ContentType);
            Assert.Equal(replyTo, clone.ReplyTo);
            Assert.Equal(replyToSessionId, clone.ReplyToSessionId);
        }

        [Fact]
        [DisplayTestMethodName]
        public void TestSessionIdOverwritePartitionKey()
        {
            var messageBody = Encoding.UTF8.GetBytes("test");
            var brokeredMessage = new Message(messageBody);
            string partitionKey1 = "partitionKey1";
            string sessionId1 = "sessionId1";
            brokeredMessage.PartitionKey = partitionKey1;
            Assert.Equal(partitionKey1, brokeredMessage.PartitionKey);
            brokeredMessage.SessionId = sessionId1;
            Assert.Equal(sessionId1, brokeredMessage.PartitionKey);
            try
            {
                brokeredMessage.PartitionKey = partitionKey1;
                Assert.False(true, "PartitionKey should not be set to a value different from SessionId");
            }
            catch (InvalidOperationException)
            {
                // Expected
            }
        }

        public class WhenQueryingIsReceivedProperty
        {
            [Fact]
            [DisplayTestMethodName]
            public void Should_return_false_for_message_that_was_not_sent()
            {
                var message = new Message();
                message.UserProperties["dummy"] = "dummy";
                Assert.False(message.SystemProperties.IsReceived);
            }

            [Theory]
            [DisplayTestMethodName]
            [InlineData(ReceiveMode.ReceiveAndDelete)]
            [InlineData(ReceiveMode.PeekLock)]
            [LiveTest]
            public async Task Should_return_true_for_message_that_was_sent_and_received(ReceiveMode receiveMode)
            {
                await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
                {
                    var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, receiveMode);

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
                });
            }

            [Fact]
            [LiveTest]
            [DisplayTestMethodName]
            public async Task Should_return_true_for_peeked_message()
            {
                await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
                {
                    var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);

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
                });
            }

            [Fact]
            [LiveTest]
            [DisplayTestMethodName]
            public async Task MessageWithMaxMessageSizeShouldWorkAsExpected()
            {
                await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
                {
                    var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);

                    try
                    { 
                        var maxMessageSize = (256 * 1024) - 77;     // 77 bytes is the current serialization hit.
                        var maxPayload = Enumerable.Repeat<byte>(0x20, maxMessageSize).ToArray(); 
                        var maxSizeMessage = new Message(maxPayload);

                        await queueClient.SendAsync(maxSizeMessage);

                        var receivedMaxSizeMessage = await queueClient.InnerReceiver.ReceiveAsync();
                        await queueClient.CompleteAsync(receivedMaxSizeMessage.SystemProperties.LockToken);
                        Assert.Equal(maxPayload, receivedMaxSizeMessage.Body);
                    }
                    finally
                    {
                        await queueClient.CloseAsync();
                    }
                });
            }
        }

        [Theory]
        [DisplayTestMethodName]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData("jøbber-nå")]
        public void Should_return_string_representation_of_message(string id)
        {
            var message = new Message();
            if (id != null)
            {
                message.MessageId = id;
            }
            var result = message.ToString();
            Assert.Equal($"{{MessageId:{id}}}", result);
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task LargeMessageShouldThrowMessageSizeExceededException()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var queueClient = new QueueClient(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.PeekLock);

                try
                {
                    // 2 MB message.
                    var message = new Message(new byte[1024 * 1024 * 2]);
                    await Assert.ThrowsAsync<MessageSizeExceededException>(async () => await queueClient.SendAsync(message));
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
            });
        }

        [Fact]
        [LiveTest]
        [DisplayTestMethodName]
        public async Task MessagePropertiesShouldSupportValidPropertyTypes()
        {
            await ServiceBusScope.UsingQueueAsync(partitioned: false, sessionEnabled: false, async queueName =>
            {
                var sender = new MessageSender(TestUtility.NamespaceConnectionString, queueName);
                var receiver = new MessageReceiver(TestUtility.NamespaceConnectionString, queueName, ReceiveMode.ReceiveAndDelete);

                /// Only following value types are supported:
                /// byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, decimal,
                /// bool, Guid, string, Uri, DateTime, DateTimeOffset, TimeSpan
                var msg = new Message();
                msg.UserProperties.Add("byte", (byte)2);
                msg.UserProperties.Add("sbyte", (sbyte)3);
                msg.UserProperties.Add("char", 'c');
                msg.UserProperties.Add("short", (short)4);
                msg.UserProperties.Add("ushort", (ushort)5);
                msg.UserProperties.Add("int", (int)6);
                msg.UserProperties.Add("uint", (uint)7);
                msg.UserProperties.Add("long", (long)8);
                msg.UserProperties.Add("ulong", (ulong)9);
                msg.UserProperties.Add("float", (float)10.0);
                msg.UserProperties.Add("double", (double)11.0);
                msg.UserProperties.Add("decimal", (decimal)12.0);
                msg.UserProperties.Add("bool", true);
                msg.UserProperties.Add("Guid", Guid.NewGuid());
                msg.UserProperties.Add("string", "value");
                msg.UserProperties.Add("Uri", new Uri("http://nonExistingServiceBusWebsite.com"));
                msg.UserProperties.Add("DateTime", DateTime.UtcNow);
                msg.UserProperties.Add("DateTimeOffset", DateTimeOffset.UtcNow);
                msg.UserProperties.Add("TimeSpan", TimeSpan.FromMinutes(5));

                await sender.SendAsync(msg);
                var receivedMsg = await receiver.ReceiveAsync();

                Assert.IsType<byte>(receivedMsg.UserProperties["byte"]);
                Assert.IsType<sbyte>(receivedMsg.UserProperties["sbyte"]);
                Assert.IsType<char>(receivedMsg.UserProperties["char"]);
                Assert.IsType<short>(receivedMsg.UserProperties["short"]);
                Assert.IsType<ushort>(receivedMsg.UserProperties["ushort"]);
                Assert.IsType<int>(receivedMsg.UserProperties["int"]);
                Assert.IsType<uint>(receivedMsg.UserProperties["uint"]);
                Assert.IsType<long>(receivedMsg.UserProperties["long"]);
                Assert.IsType<ulong>(receivedMsg.UserProperties["ulong"]);
                Assert.IsType<float>(receivedMsg.UserProperties["float"]);
                Assert.IsType<double>(receivedMsg.UserProperties["double"]);
                Assert.IsType<decimal>(receivedMsg.UserProperties["decimal"]);
                Assert.IsType<bool>(receivedMsg.UserProperties["bool"]);
                Assert.IsType<Guid>(receivedMsg.UserProperties["Guid"]);
                Assert.IsType<string>(receivedMsg.UserProperties["string"]);
                Assert.IsType<Uri>(receivedMsg.UserProperties["Uri"]);
                Assert.IsType<DateTime>(receivedMsg.UserProperties["DateTime"]);
                Assert.IsType<DateTimeOffset>(receivedMsg.UserProperties["DateTimeOffset"]);
                Assert.IsType<TimeSpan>(receivedMsg.UserProperties["TimeSpan"]);            
            });
        }
    }
}