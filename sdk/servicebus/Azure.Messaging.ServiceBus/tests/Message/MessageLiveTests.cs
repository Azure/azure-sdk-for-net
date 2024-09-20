// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Amqp;
using Azure.Core.Serialization;
using Azure.Core.Shared;
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
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
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
                msg.ApplicationProperties.Add("null", null);

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

                Assert.IsNull(receivedMsg.ApplicationProperties["null"]);
                var bytes = receivedMsg.GetRawAmqpMessage().ToBytes();

                var copyReceivedMessage = ServiceBusReceivedMessage.FromAmqpMessage(
                    AmqpAnnotatedMessage.FromBytes(bytes),
                    BinaryData.FromBytes(receivedMsg.LockTokenGuid.ToByteArray()));

                Assert.AreEqual(receivedMsg.LockToken, copyReceivedMessage.LockToken);
                Assert.IsInstanceOf(typeof(byte), copyReceivedMessage.ApplicationProperties["byte"]);
                Assert.IsInstanceOf(typeof(sbyte), copyReceivedMessage.ApplicationProperties["sbyte"]);
                Assert.IsInstanceOf(typeof(char), copyReceivedMessage.ApplicationProperties["char"]);
                Assert.IsInstanceOf(typeof(short), copyReceivedMessage.ApplicationProperties["short"]);
                Assert.IsInstanceOf(typeof(ushort), copyReceivedMessage.ApplicationProperties["ushort"]);
                Assert.IsInstanceOf(typeof(int), copyReceivedMessage.ApplicationProperties["int"]);
                Assert.IsInstanceOf(typeof(uint), copyReceivedMessage.ApplicationProperties["uint"]);
                Assert.IsInstanceOf(typeof(long), copyReceivedMessage.ApplicationProperties["long"]);
                Assert.IsInstanceOf(typeof(ulong), copyReceivedMessage.ApplicationProperties["ulong"]);
                Assert.IsInstanceOf(typeof(float), copyReceivedMessage.ApplicationProperties["float"]);
                Assert.IsInstanceOf(typeof(double), copyReceivedMessage.ApplicationProperties["double"]);
                Assert.IsInstanceOf(typeof(decimal), copyReceivedMessage.ApplicationProperties["decimal"]);
                Assert.IsInstanceOf(typeof(bool), copyReceivedMessage.ApplicationProperties["bool"]);
                Assert.IsInstanceOf(typeof(Guid), copyReceivedMessage.ApplicationProperties["Guid"]);
                Assert.IsInstanceOf(typeof(string), copyReceivedMessage.ApplicationProperties["string"]);
                Assert.IsInstanceOf(typeof(Uri), copyReceivedMessage.ApplicationProperties["Uri"]);
                Assert.IsInstanceOf(typeof(DateTime), copyReceivedMessage.ApplicationProperties["DateTime"]);
                Assert.IsInstanceOf(typeof(DateTimeOffset), copyReceivedMessage.ApplicationProperties["DateTimeOffset"]);
                Assert.IsInstanceOf(typeof(TimeSpan), copyReceivedMessage.ApplicationProperties["TimeSpan"]);
            }
        }

        [Test]
        public async Task CanSendMessageWithMaxSize()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                var maxMessageSize = (256 * 1024) - 77;     // 77 bytes is the current serialization hit.
                var maxPayload = Enumerable.Repeat<byte>(0x20, maxMessageSize).ToArray();
                var maxSizeMessage = new ServiceBusMessage(maxPayload);

                await client.CreateSender(scope.QueueName).SendMessageAsync(maxSizeMessage);
                var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMaxSizeMessage = await receiver.ReceiveMessageAsync();
                await receiver.CompleteMessageAsync(receivedMaxSizeMessage);
                Assert.AreEqual(maxPayload, receivedMaxSizeMessage.Body.ToArray());
            }
        }

        [Test]
        public async Task CanSendNullBodyMessage()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);

                var maxSizeMessage = new ServiceBusMessage((BinaryData)null);

                await client.CreateSender(scope.QueueName).SendMessageAsync(maxSizeMessage);
                var receiver = client.CreateReceiver(scope.QueueName);
                var receivedMessage = await receiver.ReceiveMessageAsync();
                Assert.IsNotNull(receivedMessage);
                await receiver.CompleteMessageAsync(receivedMessage);
            }
        }

        [Test]
        public async Task CreateFromReceivedMessageCopiesProperties()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                var msg = new ServiceBusMessage(new BinaryData(ServiceBusTestUtilities.GetRandomBuffer(100)));
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
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueuedTimeUtcName));
                Assert.IsTrue(rawReceived.DeliveryAnnotations.Count > 0);

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
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.MessageStateName));
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.ScheduledEnqueueTimeUtcName));
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.PartitionIdName));
                Assert.IsFalse(toSend.ApplicationProperties.ContainsKey(AmqpMessageConstants.DeadLetterReasonHeader));
                Assert.IsFalse(toSend.ApplicationProperties.ContainsKey(AmqpMessageConstants.DeadLetterErrorDescriptionHeader));
                Assert.IsFalse(toSend.ApplicationProperties.ContainsKey(MessagingClientDiagnostics.DiagnosticIdAttribute));

                // delivery annotations only apply to a single hop so they are cleared
                Assert.AreEqual(0, rawSend.DeliveryAnnotations.Count);

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
                    Assert.AreEqual(received.SessionId, sentMessage.SessionId);
                    Assert.AreEqual(received.TimeToLive, sentMessage.TimeToLive);
                    Assert.AreEqual(received.To, sentMessage.To);
                    Assert.AreEqual(received.TransactionPartitionKey, sentMessage.TransactionPartitionKey);
                }
            }
        }

        [Test]
        public async Task TimeToLiveSetBasedOnAbsoluteExpiryTimeAndQueueDefault()
        {
            // Use a message Time To Live of greater than 49 days so that we can verify the TTL is recalculated correctly on the client based on
            // the absolute expiry time. 49 days is the largest number of milliseconds that can be sent over AMQP, so the recalculation is a workaround.
            // See https://github.com/Azure/azure-sdk-for-net/issues/40915 for more details.
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false,
                             enableSession: false, defaultMessageTimeToLive: TimeSpan.FromDays(100)))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                var msg = new ServiceBusMessage();
                await sender.SendMessageAsync(msg);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = await receiver.ReceiveMessageAsync();

                Assert.AreEqual(TimeSpan.FromDays(100), received.TimeToLive);
                Assert.AreEqual(received.GetRawAmqpMessage().Properties.CreationTime + TimeSpan.FromDays(100),
                    received.ExpiresAt);
            }
        }

        [Test]
        public async Task TimeToLiveSetBasedOnAbsoluteExpiryTimeAndMessageValue()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false,
                             enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                // Use a message Time To Live of greater than 49 days so that we can verify the TTL is recalculated correctly on the client based on
                // the absolute expiry time. 49 days is the largest number of milliseconds that can be sent over AMQP, so the recalculation is a workaround.
                // See https://github.com/Azure/azure-sdk-for-net/issues/40915 for more details.
                var msg = new ServiceBusMessage
                {
                    TimeToLive = TimeSpan.FromDays(100)
                };
                await sender.SendMessageAsync(msg);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = await receiver.ReceiveMessageAsync();

                Assert.AreEqual(TimeSpan.FromDays(100), received.TimeToLive);
                Assert.AreEqual(received.GetRawAmqpMessage().Properties.CreationTime + TimeSpan.FromDays(100),
                    received.ExpiresAt);
            }
        }

        [Test]
        public async Task CreateFromReceivedMessageCopiesPropertiesTopic()
        {
            await using (var scope = await ServiceBusScope.CreateWithTopic(enablePartitioning: true, enableSession: true))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.TopicName);
                var msg = new ServiceBusMessage(new BinaryData(ServiceBusTestUtilities.GetRandomBuffer(100)));
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

                ServiceBusSessionReceiver receiver = await client.AcceptNextSessionAsync(scope.TopicName, scope.SubscriptionNames.First());
                ServiceBusReceivedMessage received = await receiver.ReceiveMessageAsync();

                // defer the message so we can verify that the Message State is cleared as expected by constructor
                await receiver.DeferMessageAsync(received);
                received = await receiver.PeekMessageAsync();
                AmqpAnnotatedMessage rawReceived = received.GetRawAmqpMessage();
                Assert.IsNotNull(rawReceived.Header.DeliveryCount);
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.LockedUntilName));
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.SequenceNumberName));
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueueSequenceNumberName));
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueuedTimeUtcName));
                Assert.IsTrue(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.MessageStateName));

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
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.MessageStateName));
                Assert.IsFalse(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.ScheduledEnqueueTimeUtcName));
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
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                var serializer = new JsonObjectSerializer();
                var testBody = new TestBody
                {
                    A = "text",
                    B = 5,
                    C = false
                };
                var body = serializer.Serialize(testBody);
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
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);

                var msg = new ServiceBusMessage();
                var amqp = new AmqpAnnotatedMessage(
                    AmqpMessageBody.FromData(
                    new ReadOnlyMemory<byte>[]
                    {
                        new ReadOnlyMemory<byte>(ServiceBusTestUtilities.GetRandomBuffer(100)),
                        new ReadOnlyMemory<byte>(ServiceBusTestUtilities.GetRandomBuffer(100))
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

        private static readonly object[] s_amqpValues =
        {
            "string",
            new List<string> {"first", "second"},
            'c',
            5,
            new int[] { 5 },
            long.MaxValue,
            new long[] { long.MaxValue },
            (byte) 1,
            (sbyte) 1,
            (short) 1,
            (ushort) 1,
            3.1415926,
            new double[] { 3.1415926 },
            new decimal(3.1415926),
            new decimal[] { new decimal(3.1415926) },
            DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture).UtcDateTime,
            new DateTime[] {DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture).UtcDateTime },
            DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture),
            new DateTimeOffset[] {DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture) },
            TimeSpan.FromSeconds(5),
            new TimeSpan[] {TimeSpan.FromSeconds(5)},
            new Uri("http://localHost"),
            new Uri[] { new Uri("http://localHost") },
            new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554"),
            new Guid[] { new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554"), new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554") },
            new Dictionary<string, string> { { "key", "value" } },
            new Dictionary<string, char> {{ "key", 'c' }},
            new Dictionary<string, int> {{ "key", 5 }},
            new Dictionary<string, byte> {{ "key", 1 } },
            new Dictionary<string, sbyte> {{ "key", 1 } },
            new Dictionary<string, short> {{ "key", 1 } },
            new Dictionary<string, double> {{ "key", 3.1415926 } },
            new Dictionary<string, decimal> {{ "key", new decimal(3.1415926) } },
            new Dictionary<string, DateTime> {{ "key", DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture).UtcDateTime } },
            // for some reason dictionaries with DateTimeOffset, Timespan, or Uri values are not supported in AMQP lib
            // new Dictionary<string, DateTimeOffset> {{ "key", DateTimeOffset.Parse("3/24/21") } },
            // new Dictionary<string, TimeSpan> {{ "key", TimeSpan.FromSeconds(5) } },
            // new Dictionary<string, Uri> {{ "key", new Uri("http://localHost") } },
            new Dictionary<string, Guid> {{ "key", new Guid("55f239a6-5d50-4f6d-8f84-deed326e4554") } },
            new Dictionary<string, object> { { "key1", "value" }, { "key2", 2 } },
        };

        [Test]
        [TestCaseSource(nameof(s_amqpValues))]
        public async Task CanSendValueSection(object value)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);

                var msg = new ServiceBusMessage();
                msg.GetRawAmqpMessage().Body = AmqpMessageBody.FromValue(value);

                await sender.SendMessageAsync(msg);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = await receiver.ReceiveMessageAsync();
                received.GetRawAmqpMessage().Body.TryGetValue(out var receivedData);
                Assert.AreEqual(value, receivedData);

                Assert.That(
                    () => received.Body,
                    Throws.InstanceOf<NotSupportedException>());

                var sendable = new ServiceBusMessage(received);
                sendable.GetRawAmqpMessage().Body.TryGetValue(out var sendData);
                Assert.AreEqual(value, sendData);
            }
        }

        private static readonly object[] s_amqpSequences =
{
            Enumerable.Repeat(new List<object> {"first", "second"}, 2),
            Enumerable.Repeat(new object[] {'c' }, 1),
            Enumerable.Repeat(new object[] { long.MaxValue }, 2),
            Enumerable.Repeat(new object[] { 1 }, 2),
            Enumerable.Repeat(new object[] { 3.1415926, true }, 2),
            Enumerable.Repeat(new object[] { DateTimeOffset.Parse("3/24/21", CultureInfo.InvariantCulture).UtcDateTime, true }, 2),
            new List<IList<object>> { new List<object> { "first", 1}, new List<object> { "second", 2 } }
        };

        [Test]
        [TestCaseSource(nameof(s_amqpSequences))]
        public async Task CanSendSequenceSection(IEnumerable<IList<object>> sequence)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);

                var msg = new ServiceBusMessage();
                msg.GetRawAmqpMessage().Body = AmqpMessageBody.FromSequence(sequence);

                await sender.SendMessageAsync(msg);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = await receiver.ReceiveMessageAsync();
                received.GetRawAmqpMessage().Body.TryGetSequence(out IEnumerable<IList<object>> receivedData);
                var outerEnum = receivedData.GetEnumerator();
                foreach (IList<object> seq in sequence)
                {
                    outerEnum.MoveNext();
                    var innerEnum = outerEnum.Current.GetEnumerator();
                    foreach (object elem in seq)
                    {
                        innerEnum.MoveNext();
                        Assert.AreEqual(elem, innerEnum.Current);
                    }
                }

                Assert.That(
                    () => received.Body,
                    Throws.InstanceOf<NotSupportedException>());

                var sendable = new ServiceBusMessage(received);
                sendable.GetRawAmqpMessage().Body.TryGetSequence(out var sendData);
                Assert.AreEqual(sequence, sendData);
            }
        }

        [Test]
        public async Task CanSetMessageId()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                var msg = new ServiceBusMessage();
                msg.GetRawAmqpMessage().Body = new AmqpMessageBody(new ReadOnlyMemory<byte>[]
                    {
                        new ReadOnlyMemory<byte>(ServiceBusTestUtilities.GetRandomBuffer(100)),
                        new ReadOnlyMemory<byte>(ServiceBusTestUtilities.GetRandomBuffer(100))
                    });
                Guid guid = Guid.NewGuid();
                msg.GetRawAmqpMessage().Properties.MessageId = new AmqpMessageId(guid.ToString());

                await sender.SendMessageAsync(msg);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = await receiver.ReceiveMessageAsync();
                Assert.AreEqual(guid.ToString(), received.MessageId);
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanRoundTripAmqpProperties(bool enableSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: enableSession))
            {
                var message = new ServiceBusMessage();
                var amqpMessage = message.GetRawAmqpMessage();

                // body
                amqpMessage.Body = AmqpMessageBody.FromValue("body");

                // header
                amqpMessage.Header.TimeToLive = TimeSpan.FromSeconds(50);
                amqpMessage.Header.DeliveryCount = 3;
                amqpMessage.Header.Durable = true;
                amqpMessage.Header.FirstAcquirer = true;
                amqpMessage.Header.Priority = 1;

                // footer
                amqpMessage.Footer.Add("footerKey1", "footerVal1");
                amqpMessage.Footer.Add("footerKey2", "footerVal2");
                amqpMessage.Footer.Add("footerKey3", null);

                // properties
                amqpMessage.Properties.AbsoluteExpiryTime = DateTimeOffset.Now.AddDays(1);
                amqpMessage.Properties.ContentEncoding = "compress";
                amqpMessage.Properties.ContentType = "application/json";
                amqpMessage.Properties.CorrelationId = new AmqpMessageId("correlationId");
                amqpMessage.Properties.CreationTime = DateTimeOffset.Now.AddDays(1);
                amqpMessage.Properties.GroupId = "groupId";
                amqpMessage.Properties.GroupSequence = 5;
                amqpMessage.Properties.MessageId = new AmqpMessageId("messageId");
                amqpMessage.Properties.ReplyTo = new AmqpAddress("replyTo");
                amqpMessage.Properties.ReplyToGroupId = "replyToGroupId";
                amqpMessage.Properties.Subject = "subject";
                amqpMessage.Properties.To = new AmqpAddress("to");
                amqpMessage.Properties.UserId = new byte[] { 1, 2, 3 };

                // application properties
                amqpMessage.ApplicationProperties.Add("applicationKey1", "applicationVal1");
                amqpMessage.ApplicationProperties.Add("applicationKey2", "applicationVal2");

                // message annotations
                amqpMessage.MessageAnnotations.Add("messageAnnotationKey1", null);
                amqpMessage.MessageAnnotations.Add("messageAnnotationKey2", "messageAnnotationVal2");

                // delivery annotations
                amqpMessage.DeliveryAnnotations.Add("deliveryAnnotationKey1", null);
                amqpMessage.DeliveryAnnotations.Add("deliveryAnnotationKey2", "deliveryAnnotationVal2");

                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);

                var now = DateTimeOffset.UtcNow;
                await sender.SendMessageAsync(message);

                var receiver = enableSession ? await client.AcceptNextSessionAsync(scope.QueueName)
                    : client.CreateReceiver(scope.QueueName);
                var received = (await receiver.ReceiveMessageAsync()).GetRawAmqpMessage();

                received.Body.TryGetValue(out var body);
                Assert.AreEqual("body", body);

                Assert.AreEqual(TimeSpan.FromSeconds(50), received.Header.TimeToLive);

                // the broker will disregard the value set for delivery count
                Assert.AreEqual(1, received.Header.DeliveryCount);
                Assert.IsTrue(received.Header.Durable);
                Assert.IsTrue(received.Header.FirstAcquirer);
                Assert.AreEqual(1, received.Header.Priority);

                Assert.AreEqual("compress", received.Properties.ContentEncoding);
                Assert.AreEqual("application/json", received.Properties.ContentType);
                Assert.AreEqual(new AmqpMessageId("correlationId"), received.Properties.CorrelationId);
                Assert.AreEqual("groupId", received.Properties.GroupId);
                Assert.AreEqual(5, received.Properties.GroupSequence);
                Assert.AreEqual(new AmqpMessageId("messageId"), received.Properties.MessageId);
                Assert.AreEqual(new AmqpAddress("replyTo"), received.Properties.ReplyTo);
                Assert.AreEqual("replyToGroupId", received.Properties.ReplyToGroupId);
                Assert.AreEqual("subject", received.Properties.Subject);
                Assert.AreEqual(new AmqpAddress("to"), received.Properties.To);
                Assert.AreEqual(new byte[] { 1, 2, 3 }, received.Properties.UserId.Value.ToArray());

                // since TTL was set these were overriden - provide some buffer since the Now time is
                Assert.That(received.Properties.CreationTime, Is.EqualTo(now).Within(TimeSpan.FromSeconds(1)));
                Assert.That(received.Properties.AbsoluteExpiryTime, Is.EqualTo(now.Add(TimeSpan.FromSeconds(50))).Within(TimeSpan.FromSeconds(1)));

                // application properties
                Assert.AreEqual(received.ApplicationProperties["applicationKey1"], "applicationVal1");
                Assert.AreEqual(received.ApplicationProperties["applicationKey2"], "applicationVal2");

                // message annotations
                Assert.IsNull(received.MessageAnnotations["messageAnnotationKey1"]);
                Assert.AreEqual(received.MessageAnnotations["messageAnnotationKey2"], "messageAnnotationVal2");

                // delivery annotations
                Assert.IsNull(received.DeliveryAnnotations["deliveryAnnotationKey1"]);
                Assert.AreEqual(received.DeliveryAnnotations["deliveryAnnotationKey2"], "deliveryAnnotationVal2");

                // footer
                Assert.AreEqual("footerVal1", received.Footer["footerKey1"]);
                Assert.AreEqual("footerVal2", received.Footer["footerKey2"]);
                Assert.IsNull(received.Footer["footerKey3"]);
            }
        }

        [Test]
        public async Task CanRoundTripAbsoluteExpiryCreationTime()
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: false, enableSession: false))
            {
                var message = new ServiceBusMessage();
                var amqpMessage = message.GetRawAmqpMessage();

                // body
                amqpMessage.Body = AmqpMessageBody.FromValue("body");

                // properties
                var expiry = DateTimeOffset.Now.AddDays(1);
                var creation = DateTimeOffset.Now.AddMinutes(1);
                amqpMessage.Properties.AbsoluteExpiryTime = expiry;
                amqpMessage.Properties.CreationTime = creation;

                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);

                var now = DateTimeOffset.UtcNow;
                await sender.SendMessageAsync(message);

                var receiver = client.CreateReceiver(scope.QueueName);
                var received = (await receiver.ReceiveMessageAsync()).GetRawAmqpMessage();

                received.Body.TryGetValue(out var body);
                Assert.AreEqual("body", body);

                Assert.AreEqual(expiry.ToUnixTimeSeconds(), received.Properties.AbsoluteExpiryTime.Value.ToUnixTimeSeconds());
                Assert.AreEqual(creation.ToUnixTimeSeconds(), received.Properties.CreationTime.Value.ToUnixTimeSeconds());
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CanSerializeDeserializeAmqpBytes(bool useSession)
        {
            await using (var scope = await ServiceBusScope.CreateWithQueue(enablePartitioning: true, enableSession: useSession))
            {
                await using var client = new ServiceBusClient(TestEnvironment.FullyQualifiedNamespace, TestEnvironment.Credential);
                var sender = client.CreateSender(scope.QueueName);
                var msg = new ServiceBusMessage(new BinaryData(ServiceBusTestUtilities.GetRandomBuffer(100)));
                msg.ContentType = "contenttype";
                msg.CorrelationId = "correlationid";
                msg.Subject = "label";
                msg.MessageId = "messageId";
                msg.PartitionKey = "key";
                msg.ApplicationProperties.Add("testProp", "my prop");
                msg.ReplyTo = "replyto";

                msg.ScheduledEnqueueTime = DateTimeOffset.Now;
                if (useSession)
                {
                    msg.SessionId = "key";
                    msg.ReplyToSessionId = "replytosession";
                }

                msg.TimeToLive = TimeSpan.FromSeconds(60);
                msg.To = "to";
                await sender.SendMessageAsync(msg);

                ServiceBusReceiver receiver;
                if (useSession)
                    receiver = await client.AcceptNextSessionAsync(scope.QueueName);
                else
                    receiver = client.CreateReceiver(scope.QueueName);

                ServiceBusReceivedMessage received = await receiver.ReceiveMessageAsync();
                received.AmqpMessage.MessageAnnotations[AmqpMessageConstants.MessageStateName] = 1;

                var serializedBytes = received.GetRawAmqpMessage().ToBytes();
                var deserialized = ServiceBusReceivedMessage.FromAmqpMessage(
                    AmqpAnnotatedMessage.FromBytes(serializedBytes),
                    BinaryData.FromBytes(received.LockTokenGuid.ToByteArray()));
                Assert.AreEqual(received.ContentType, deserialized.ContentType);
                Assert.AreEqual(received.CorrelationId, deserialized.CorrelationId);
                Assert.AreEqual(received.Subject, deserialized.Subject);
                Assert.AreEqual(received.MessageId, deserialized.MessageId);
                Assert.AreEqual(received.PartitionKey, deserialized.PartitionKey);
                Assert.AreEqual(received.ApplicationProperties["testProp"], deserialized.ApplicationProperties["testProp"]);
                Assert.AreEqual(received.ReplyTo, deserialized.ReplyTo);
                Assert.AreEqual(received.ReplyToSessionId, deserialized.ReplyToSessionId);
                Assert.AreEqual(received.ScheduledEnqueueTime, deserialized.ScheduledEnqueueTime);
                Assert.AreEqual(received.SessionId, deserialized.SessionId);
                Assert.AreEqual(received.TimeToLive, deserialized.TimeToLive);
                Assert.AreEqual(received.To, deserialized.To);
                Assert.AreEqual(received.LockTokenGuid, deserialized.LockTokenGuid);
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
