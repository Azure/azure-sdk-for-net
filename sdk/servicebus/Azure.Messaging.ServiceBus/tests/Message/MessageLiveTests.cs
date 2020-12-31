// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Amqp;
using Azure.Core.Serialization;
using Azure.Messaging.ServiceBus.Amqp;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Message
{
    public class MessageLiveTests : ServiceBusLiveTestBase
    {
        [Test]
        public async Task MessagePropertiesShouldSupportValidPropertyTypes()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var receiver = client.CreateReceiver(scope.QueueName);

                /// Only following value types are supported:
                /// byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, decimal,
                /// bool, Guid, string, Uri, DateTime, DateTimeOffset, TimeSpan
                var msg = new ServiceBusMessage();
                msg.ApplicationProperties.Add("byte", (byte)2);
                msg.ApplicationProperties.Add("sbyte", (sbyte)3);
                msg.ApplicationProperties.Add("char", 'c');
                msg.ApplicationProperties.Add("short", (short)4);
                msg.ApplicationProperties.Add("ushort", (ushort)5);
                msg.ApplicationProperties.Add("int", (int)6);
                msg.ApplicationProperties.Add("uint", (uint)7);
                msg.ApplicationProperties.Add("long", (long)8);
                msg.ApplicationProperties.Add("ulong", (ulong)9);
                msg.ApplicationProperties.Add("float", (float)10.0);
                msg.ApplicationProperties.Add("double", (double)11.0);
                msg.ApplicationProperties.Add("decimal", (decimal)12.0);
                msg.ApplicationProperties.Add("bool", true);
                msg.ApplicationProperties.Add("Guid", Guid.NewGuid());
                msg.ApplicationProperties.Add("string", "value");
                msg.ApplicationProperties.Add("Uri", new Uri("http://nonExistingServiceBusWebsite.com"));
                msg.ApplicationProperties.Add("DateTime", DateTime.UtcNow);
                msg.ApplicationProperties.Add("DateTimeOffset", DateTimeOffset.UtcNow);
                msg.ApplicationProperties.Add("TimeSpan", TimeSpan.FromMinutes(5));

                await sender.SendMessageAsync(msg);
                var receivedMsg = await receiver.ReceiveMessageAsync();

                Assert.IsInstanceOf(typeof(byte), receivedMsg.ApplicationProperties["byte"]);
                Assert.IsInstanceOf(typeof(sbyte), receivedMsg.ApplicationProperties["sbyte"]);
                Assert.IsInstanceOf(typeof(char), receivedMsg.ApplicationProperties["char"]);
                Assert.IsInstanceOf(typeof(short), receivedMsg.ApplicationProperties["short"]);
                Assert.IsInstanceOf(typeof(ushort), receivedMsg.ApplicationProperties["ushort"]);
                Assert.IsInstanceOf(typeof(int), receivedMsg.ApplicationProperties["int"]);
                Assert.IsInstanceOf(typeof(uint), receivedMsg.ApplicationProperties["uint"]);
                Assert.IsInstanceOf(typeof(long), receivedMsg.ApplicationProperties["long"]);
                Assert.IsInstanceOf(typeof(ulong), receivedMsg.ApplicationProperties["ulong"]);
                Assert.IsInstanceOf(typeof(float), receivedMsg.ApplicationProperties["float"]);
                Assert.IsInstanceOf(typeof(double), receivedMsg.ApplicationProperties["double"]);
                Assert.IsInstanceOf(typeof(decimal), receivedMsg.ApplicationProperties["decimal"]);
                Assert.IsInstanceOf(typeof(bool), receivedMsg.ApplicationProperties["bool"]);
                Assert.IsInstanceOf(typeof(Guid), receivedMsg.ApplicationProperties["Guid"]);
                Assert.IsInstanceOf(typeof(string), receivedMsg.ApplicationProperties["string"]);
                Assert.IsInstanceOf(typeof(Uri), receivedMsg.ApplicationProperties["Uri"]);
                Assert.IsInstanceOf(typeof(DateTime), receivedMsg.ApplicationProperties["DateTime"]);
                Assert.IsInstanceOf(typeof(DateTimeOffset), receivedMsg.ApplicationProperties["DateTimeOffset"]);
                Assert.IsInstanceOf(typeof(TimeSpan), receivedMsg.ApplicationProperties["TimeSpan"]);
            }
        }

        [Test]
        public async Task CanSendMessageWithMaxSize()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                var maxMessageSize = (256 * 1024) - 77;     // 77 bytes is the current serialization hit.
                var maxPayload = Enumerable.Repeat<byte>(0x20, maxMessageSize).ToArray();
                var maxSizeMessage = new ServiceBusMessage(maxPayload);

                await client.CreateSender(scope.QueueName).SendMessageAsync(maxSizeMessage);
                var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMaxSizeMessage = await receiver.ReceiveMessageAsync();
                await receiver.CompleteMessageAsync(receivedMaxSizeMessage.LockToken);
                Assert.AreEqual(maxPayload, receivedMaxSizeMessage.Body.ToArray());
            }
        }

        [Test]
        public async Task CanSendNullBodyMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);

                var maxSizeMessage = new ServiceBusMessage((BinaryData)null);

                await client.CreateSender(scope.QueueName).SendMessageAsync(maxSizeMessage);
                var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.IsNotNull(receivedMessage);
                await receiver.CompleteMessageAsync(receivedMessage.LockToken);
            }
        }

        [Test]
        public async Task CreateFromReceivedMessageCopiesProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: true))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var msg = new ServiceBusMessage(new BinaryData(GetRandomBuffer(100)));
                msg.ContentType = "contenttype";
                msg.CorrelationId = "correlationid";
                msg.Subject = "label";
                msg.MessageId = "messageId";
                msg.PartitionKey = "key";
                msg.ApplicationProperties.Add("testProp", "my prop");
                msg.ReplyTo = "replyto";
                msg.ReplyToSessionId = "replytosession";
                msg.ScheduledEnqueueTime = DateTimeOffset.Now;
                msg.SessionId = "key";
                msg.TimeToLive = TimeSpan.FromSeconds(60);
                msg.To = "to";
                await sender.SendMessageAsync(msg);

                ServiceBusSessionReceiver receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                ServiceBusReceivedMessage received = await receiver.ReceiveMessageAsync();
                AmqpAnnotatedMessage rawReceived = received.GetRawAmqpMessage();
                Assert.IsNotNull(rawReceived.Header.DeliveryCount);
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.LockedUntilName));
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.SequenceNumberName));
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueueSequenceNumberName));
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueuedTimeUtcName));

                AssertMessagesEqual(msg, received);
                var toSend = new ServiceBusMessage(received);
                AmqpAnnotatedMessage rawSend = toSend.GetRawAmqpMessage();

                // verify that all system set properties have been cleared out
                Assert.IsNull(rawSend.Header.DeliveryCount);
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.LockedUntilName));
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.SequenceNumberName));
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.DeadLetterSourceName));
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueueSequenceNumberName));
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueuedTimeUtcName));
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.DeadLetterSourceName));
                Assert.IsFalse(toSend.ApplicationProperties.ContainsKey(AmqpMessageConstants.DeadLetterReasonHeader));
                Assert.IsFalse(toSend.ApplicationProperties.ContainsKey(AmqpMessageConstants.DeadLetterErrorDescriptionHeader));

                AssertMessagesEqual(toSend, received);

                void AssertMessagesEqual(ServiceBusMessage sentMessage, ServiceBusReceivedMessage received)
                {
                    Assert.IsTrue(received.Body.ToArray().SequenceEqual(sentMessage.Body.ToArray()));
                    Assert.AreEqual(received.ContentType, sentMessage.ContentType);
                    Assert.AreEqual(received.CorrelationId, sentMessage.CorrelationId);
                    Assert.AreEqual(received.Subject, sentMessage.Subject);
                    Assert.AreEqual(received.ContentType, sentMessage.ContentType);
                    Assert.AreEqual(received.CorrelationId, sentMessage.CorrelationId);
                    Assert.AreEqual(received.MessageId, sentMessage.MessageId);
                    Assert.AreEqual(received.PartitionKey, sentMessage.PartitionKey);
                    Assert.AreEqual((string)received.ApplicationProperties["testProp"], (string)sentMessage.ApplicationProperties["testProp"]);
                    Assert.AreEqual(received.ReplyTo, sentMessage.ReplyTo);
                    Assert.AreEqual(received.ReplyToSessionId, sentMessage.ReplyToSessionId);
                    Assert.AreEqual(received.ScheduledEnqueueTime.UtcDateTime.Second, sentMessage.ScheduledEnqueueTime.UtcDateTime.Second);
                    Assert.AreEqual(received.SessionId, sentMessage.SessionId);
                    Assert.AreEqual(received.TimeToLive, sentMessage.TimeToLive);
                    Assert.AreEqual(received.To, sentMessage.To);
                    Assert.AreEqual(received.TransactionPartitionKey, sentMessage.TransactionPartitionKey);
                }
            }
        }

        [Test]
        public async Task SendJsonBodyMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var serializer = new JsonObjectSerializer();
                var testBody = new TestBody
                {
                    A = "text",
                    B = 5,
                    C = false
                };
                var body = serializer.SerializeToBinaryData(testBody);
                var msg = new ServiceBusMessage(body);

                await sender.SendMessageAsync(msg);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = await receiver.ReceiveMessageAsync();
                var receivedBody = received.Body.ToObject<TestBody>(serializer);
                Assert.AreEqual(testBody.A, receivedBody.A);
                Assert.AreEqual(testBody.B, receivedBody.B);
                Assert.AreEqual(testBody.C, receivedBody.C);
            }
        }

        [Test]
        public async Task CanSendMultipleDataSections()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);

                var msg = new ServiceBusMessage();
                var amqp = new AmqpAnnotatedMessage(
                    new AmqpMessageBody(
                    new ReadOnlyMemory<byte>[]
                    {
                        new ReadOnlyMemory<byte>(GetRandomBuffer(100)),
                        new ReadOnlyMemory<byte>(GetRandomBuffer(100))
                    }));
                msg.AmqpMessage = amqp;

                await sender.SendMessageAsync(msg);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = await receiver.ReceiveMessageAsync();
                received.GetRawAmqpMessage().Body.TryGetData(out var receivedData);
                var bodyEnum = receivedData.GetEnumerator();
                int ct = 0;
                msg.GetRawAmqpMessage().Body.TryGetData(out var sentData);

                foreach (ReadOnlyMemory<byte> data in sentData)
                {
                    bodyEnum.MoveNext();
                    var bytes = data.ToArray();
                    Assert.AreEqual(bytes, bodyEnum.Current.ToArray());
                    if (ct++ == 0)
                    {
                        Assert.AreEqual(bytes, received.Body.ToMemory().Slice(0, 100).ToArray());
                    }
                    else
                    {
                        Assert.AreEqual(bytes, received.Body.ToMemory().Slice(100, 100).ToArray());
                    }
                }
            }
        }

        [Test]
        public async Task CanSetMessageId()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.CreateSender(scope.QueueName);
                var msg = new ServiceBusMessage();
                msg.GetRawAmqpMessage().Body = new AmqpMessageBody(new ReadOnlyMemory<byte>[]
                    {
                        new ReadOnlyMemory<byte>(GetRandomBuffer(100)),
                        new ReadOnlyMemory<byte>(GetRandomBuffer(100))
                    });
                Guid guid = Guid.NewGuid();
                msg.GetRawAmqpMessage().Properties.MessageId = new AmqpMessageId(guid.ToString());

                await sender.SendMessageAsync(msg);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = await receiver.ReceiveMessageAsync();
                Assert.AreEqual(guid.ToString(), received.MessageId);
            }
        }

        private class TestBody
        {
            public string A { get; set; }
            public int B { get; set; }
            public bool C { get; set; }
        }
    }
}
