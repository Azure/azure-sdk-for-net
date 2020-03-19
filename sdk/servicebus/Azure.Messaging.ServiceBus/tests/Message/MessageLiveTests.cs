// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp.Framing;
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
                var sender = client.GetSender(scope.QueueName);
                var receiver = client.GetReceiver(scope.QueueName);

                /// Only following value types are supported:
                /// byte, sbyte, char, short, ushort, int, uint, long, ulong, float, double, decimal,
                /// bool, Guid, string, Uri, DateTime, DateTimeOffset, TimeSpan
                var msg = new ServiceBusMessage();
                msg.Properties.Add("byte", (byte)2);
                msg.Properties.Add("sbyte", (sbyte)3);
                msg.Properties.Add("char", 'c');
                msg.Properties.Add("short", (short)4);
                msg.Properties.Add("ushort", (ushort)5);
                msg.Properties.Add("int", (int)6);
                msg.Properties.Add("uint", (uint)7);
                msg.Properties.Add("long", (long)8);
                msg.Properties.Add("ulong", (ulong)9);
                msg.Properties.Add("float", (float)10.0);
                msg.Properties.Add("double", (double)11.0);
                msg.Properties.Add("decimal", (decimal)12.0);
                msg.Properties.Add("bool", true);
                msg.Properties.Add("Guid", Guid.NewGuid());
                msg.Properties.Add("string", "value");
                msg.Properties.Add("Uri", new Uri("http://nonExistingServiceBusWebsite.com"));
                msg.Properties.Add("DateTime", DateTime.UtcNow);
                msg.Properties.Add("DateTimeOffset", DateTimeOffset.UtcNow);
                msg.Properties.Add("TimeSpan", TimeSpan.FromMinutes(5));

                await sender.SendAsync(msg);
                var receivedMsg = await receiver.ReceiveAsync();

                Assert.IsInstanceOf(typeof(byte), receivedMsg.Properties["byte"]);
                Assert.IsInstanceOf(typeof(sbyte), receivedMsg.Properties["sbyte"]);
                Assert.IsInstanceOf(typeof(char), receivedMsg.Properties["char"]);
                Assert.IsInstanceOf(typeof(short), receivedMsg.Properties["short"]);
                Assert.IsInstanceOf(typeof(ushort), receivedMsg.Properties["ushort"]);
                Assert.IsInstanceOf(typeof(int), receivedMsg.Properties["int"]);
                Assert.IsInstanceOf(typeof(uint), receivedMsg.Properties["uint"]);
                Assert.IsInstanceOf(typeof(long), receivedMsg.Properties["long"]);
                Assert.IsInstanceOf(typeof(ulong), receivedMsg.Properties["ulong"]);
                Assert.IsInstanceOf(typeof(float), receivedMsg.Properties["float"]);
                Assert.IsInstanceOf(typeof(double), receivedMsg.Properties["double"]);
                Assert.IsInstanceOf(typeof(decimal), receivedMsg.Properties["decimal"]);
                Assert.IsInstanceOf(typeof(bool), receivedMsg.Properties["bool"]);
                Assert.IsInstanceOf(typeof(Guid), receivedMsg.Properties["Guid"]);
                Assert.IsInstanceOf(typeof(string), receivedMsg.Properties["string"]);
                Assert.IsInstanceOf(typeof(Uri), receivedMsg.Properties["Uri"]);
                Assert.IsInstanceOf(typeof(DateTime), receivedMsg.Properties["DateTime"]);
                Assert.IsInstanceOf(typeof(DateTimeOffset), receivedMsg.Properties["DateTimeOffset"]);
                Assert.IsInstanceOf(typeof(TimeSpan), receivedMsg.Properties["TimeSpan"]);
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

                await client.GetSender(scope.QueueName).SendAsync(maxSizeMessage);
                var receiver = client.GetReceiver(scope.QueueName);
                var receivedMaxSizeMessage = await receiver.ReceiveAsync();
                await receiver.CompleteAsync(receivedMaxSizeMessage.LockToken);
                Assert.AreEqual(maxPayload, receivedMaxSizeMessage.Body.ToArray());
            }
        }

        [Test]
        public async Task CreateFromReceivedMessageCopiesProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: true))
            {
                var client = new ServiceBusClient(TestEnvironment.ServiceBusConnectionString);
                var sender = client.GetSender(scope.QueueName);
                var msg = new ServiceBusMessage();
                msg.Body = GetRandomBuffer(100);
                msg.ContentType = "contenttype";
                msg.CorrelationId = "correlationid";
                msg.Label = "label";
                msg.MessageId = "messageId";
                msg.PartitionKey = "key";
                msg.Properties.Add("testProp", "my prop");
                msg.ReplyTo = "replyto";
                msg.ReplyToSessionId = "replytosession";
                msg.ScheduledEnqueueTime = DateTimeOffset.Now;
                msg.SessionId = "key";
                msg.TimeToLive = TimeSpan.FromSeconds(60);
                msg.To = "to";
                await sender.SendAsync(msg);

                var receiver = await client.GetSessionReceiverAsync(
                    scope.QueueName,
                    new ServiceBusReceiverOptions
                    {
                        ReceiveMode = ReceiveMode.ReceiveAndDelete
                    });
                var received = await receiver.ReceiveAsync();
                AssertMessagesEqual(msg, received);
                var toSend = ServiceBusMessage.CreateFrom(received);
                AssertMessagesEqual(toSend, received);

                void AssertMessagesEqual(ServiceBusMessage sentMessage, ServiceBusReceivedMessage received)
                {
                    Assert.IsTrue(received.Body.ToArray().SequenceEqual(sentMessage.Body.ToArray()));
                    Assert.AreEqual(received.ContentType, sentMessage.ContentType);
                    Assert.AreEqual(received.CorrelationId, sentMessage.CorrelationId);
                    Assert.AreEqual(received.Label, sentMessage.Label);
                    Assert.AreEqual(received.ContentType, sentMessage.ContentType);
                    Assert.AreEqual(received.CorrelationId, sentMessage.CorrelationId);
                    Assert.AreEqual(received.MessageId, sentMessage.MessageId);
                    Assert.AreEqual(received.PartitionKey, sentMessage.PartitionKey);
                    Assert.AreEqual((string)received.Properties["testProp"], (string)sentMessage.Properties["testProp"]);
                    Assert.AreEqual(received.ReplyTo, sentMessage.ReplyTo);
                    Assert.AreEqual(received.ReplyToSessionId, sentMessage.ReplyToSessionId);
                    Assert.AreEqual(received.ScheduledEnqueueTime.UtcDateTime.Second, sentMessage.ScheduledEnqueueTime.UtcDateTime.Second);
                    Assert.AreEqual(received.SessionId, sentMessage.SessionId);
                    Assert.AreEqual(received.TimeToLive, sentMessage.TimeToLive);
                    Assert.AreEqual(received.To, sentMessage.To);
                    Assert.AreEqual(received.ViaPartitionKey, sentMessage.ViaPartitionKey);
                }
            }
        }
    }
}
