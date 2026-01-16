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

                Assert.Multiple(() =>
                {
                    Assert.That(receivedMsg.ApplicationProperties["byte"], Is.InstanceOf(typeof(byte)));
                    Assert.That(receivedMsg.ApplicationProperties["sbyte"], Is.InstanceOf(typeof(sbyte)));
                    Assert.That(receivedMsg.ApplicationProperties["char"], Is.InstanceOf(typeof(char)));
                    Assert.That(receivedMsg.ApplicationProperties["short"], Is.InstanceOf(typeof(short)));
                    Assert.That(receivedMsg.ApplicationProperties["ushort"], Is.InstanceOf(typeof(ushort)));
                    Assert.That(receivedMsg.ApplicationProperties["int"], Is.InstanceOf(typeof(int)));
                    Assert.That(receivedMsg.ApplicationProperties["uint"], Is.InstanceOf(typeof(uint)));
                    Assert.That(receivedMsg.ApplicationProperties["long"], Is.InstanceOf(typeof(long)));
                    Assert.That(receivedMsg.ApplicationProperties["ulong"], Is.InstanceOf(typeof(ulong)));
                    Assert.That(receivedMsg.ApplicationProperties["float"], Is.InstanceOf(typeof(float)));
                    Assert.That(receivedMsg.ApplicationProperties["double"], Is.InstanceOf(typeof(double)));
                    Assert.That(receivedMsg.ApplicationProperties["decimal"], Is.InstanceOf(typeof(decimal)));
                    Assert.That(receivedMsg.ApplicationProperties["bool"], Is.InstanceOf(typeof(bool)));
                    Assert.That(receivedMsg.ApplicationProperties["Guid"], Is.InstanceOf(typeof(Guid)));
                    Assert.That(receivedMsg.ApplicationProperties["string"], Is.InstanceOf(typeof(string)));
                    Assert.That(receivedMsg.ApplicationProperties["Uri"], Is.InstanceOf(typeof(Uri)));
                    Assert.That(receivedMsg.ApplicationProperties["DateTime"], Is.InstanceOf(typeof(DateTime)));
                    Assert.That(receivedMsg.ApplicationProperties["DateTimeOffset"], Is.InstanceOf(typeof(DateTimeOffset)));
                    Assert.That(receivedMsg.ApplicationProperties["TimeSpan"], Is.InstanceOf(typeof(TimeSpan)));

                    Assert.That(receivedMsg.ApplicationProperties["null"], Is.Null);
                });
                var bytes = receivedMsg.GetRawAmqpMessage().ToBytes();

                var copyReceivedMessage = ServiceBusReceivedMessage.FromAmqpMessage(
                    AmqpAnnotatedMessage.FromBytes(bytes),
                    BinaryData.FromBytes(receivedMsg.LockTokenGuid.ToByteArray()));

                Assert.That(copyReceivedMessage.LockToken, Is.EqualTo(receivedMsg.LockToken));
                Assert.That(copyReceivedMessage.ApplicationProperties["byte"], Is.InstanceOf(typeof(byte)));
                Assert.That(copyReceivedMessage.ApplicationProperties["sbyte"], Is.InstanceOf(typeof(sbyte)));
                Assert.That(copyReceivedMessage.ApplicationProperties["char"], Is.InstanceOf(typeof(char)));
                Assert.That(copyReceivedMessage.ApplicationProperties["short"], Is.InstanceOf(typeof(short)));
                Assert.That(copyReceivedMessage.ApplicationProperties["ushort"], Is.InstanceOf(typeof(ushort)));
                Assert.That(copyReceivedMessage.ApplicationProperties["int"], Is.InstanceOf(typeof(int)));
                Assert.That(copyReceivedMessage.ApplicationProperties["uint"], Is.InstanceOf(typeof(uint)));
                Assert.That(copyReceivedMessage.ApplicationProperties["long"], Is.InstanceOf(typeof(long)));
                Assert.That(copyReceivedMessage.ApplicationProperties["ulong"], Is.InstanceOf(typeof(ulong)));
                Assert.That(copyReceivedMessage.ApplicationProperties["float"], Is.InstanceOf(typeof(float)));
                Assert.That(copyReceivedMessage.ApplicationProperties["double"], Is.InstanceOf(typeof(double)));
                Assert.That(copyReceivedMessage.ApplicationProperties["decimal"], Is.InstanceOf(typeof(decimal)));
                Assert.That(copyReceivedMessage.ApplicationProperties["bool"], Is.InstanceOf(typeof(bool)));
                Assert.That(copyReceivedMessage.ApplicationProperties["Guid"], Is.InstanceOf(typeof(Guid)));
                Assert.That(copyReceivedMessage.ApplicationProperties["string"], Is.InstanceOf(typeof(string)));
                Assert.That(copyReceivedMessage.ApplicationProperties["Uri"], Is.InstanceOf(typeof(Uri)));
                Assert.That(copyReceivedMessage.ApplicationProperties["DateTime"], Is.InstanceOf(typeof(DateTime)));
                Assert.That(copyReceivedMessage.ApplicationProperties["DateTimeOffset"], Is.InstanceOf(typeof(DateTimeOffset)));
                Assert.That(copyReceivedMessage.ApplicationProperties["TimeSpan"], Is.InstanceOf(typeof(TimeSpan)));
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
                Assert.That(receivedMaxSizeMessage.Body.ToArray(), Is.EqualTo(maxPayload));
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
                Assert.That(receivedMessage, Is.Not.Null);
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
                Assert.Multiple(() =>
                {
                    Assert.That(rawReceived.Header.DeliveryCount, Is.Not.Null);
                    Assert.That(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.LockedUntilName), Is.True);
                    Assert.That(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.SequenceNumberName), Is.True);
                    Assert.That(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueuedTimeUtcName), Is.True);
                    Assert.That(rawReceived.DeliveryAnnotations.Count > 0, Is.True);
                });

                AssertMessagesEqual(msg, received);
                var toSend = new ServiceBusMessage(received);
                AmqpAnnotatedMessage rawSend = toSend.GetRawAmqpMessage();

                Assert.Multiple(() =>
                {
                    // verify that all system set properties have been cleared out
                    Assert.That(rawSend.Header.DeliveryCount, Is.Null);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.LockedUntilName), Is.False);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.SequenceNumberName), Is.False);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.DeadLetterSourceName), Is.False);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueueSequenceNumberName), Is.False);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueuedTimeUtcName), Is.False);
                });
                Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.DeadLetterSourceName), Is.False);
                Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.MessageStateName), Is.False);
                Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.ScheduledEnqueueTimeUtcName), Is.False);
                Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.PartitionIdName), Is.False);
                Assert.That(toSend.ApplicationProperties.ContainsKey(AmqpMessageConstants.DeadLetterReasonHeader), Is.False);
                Assert.That(toSend.ApplicationProperties.ContainsKey(AmqpMessageConstants.DeadLetterErrorDescriptionHeader), Is.False);
                Assert.That(toSend.ApplicationProperties.ContainsKey(MessagingClientDiagnostics.DiagnosticIdAttribute), Is.False);

                // delivery annotations only apply to a single hop so they are cleared
                Assert.That(rawSend.DeliveryAnnotations.Count, Is.EqualTo(0));

                AssertMessagesEqual(toSend, received);

                void AssertMessagesEqual(ServiceBusMessage sentMessage, ServiceBusReceivedMessage received)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(received.Body.ToArray().SequenceEqual(sentMessage.Body.ToArray()), Is.True);
                        Assert.That(sentMessage.ContentType, Is.EqualTo(received.ContentType));
                        Assert.That(sentMessage.CorrelationId, Is.EqualTo(received.CorrelationId));
                    });
                    Assert.That(received.Subject, Is.EqualTo(sentMessage.Subject));
                    Assert.That(received.ContentType, Is.EqualTo(sentMessage.ContentType));
                    Assert.That(received.CorrelationId, Is.EqualTo(sentMessage.CorrelationId));
                    Assert.Multiple(() =>
                    {
                        Assert.That(sentMessage.MessageId, Is.EqualTo(received.MessageId));
                        Assert.That(sentMessage.PartitionKey, Is.EqualTo(received.PartitionKey));
                        Assert.That((string)sentMessage.ApplicationProperties["testProp"], Is.EqualTo((string)received.ApplicationProperties["testProp"]));
                        Assert.That(sentMessage.ReplyTo, Is.EqualTo(received.ReplyTo));
                        Assert.That(sentMessage.ReplyToSessionId, Is.EqualTo(received.ReplyToSessionId));
                        Assert.That(sentMessage.SessionId, Is.EqualTo(received.SessionId));
                        Assert.That(sentMessage.TimeToLive, Is.EqualTo(received.TimeToLive));
                        Assert.That(sentMessage.To, Is.EqualTo(received.To));
                        Assert.That(sentMessage.TransactionPartitionKey, Is.EqualTo(received.TransactionPartitionKey));
                    });
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

                Assert.Multiple(() =>
                {
                    Assert.That(received.TimeToLive, Is.EqualTo(TimeSpan.FromDays(100)));
                    Assert.That(received.ExpiresAt,
                        Is.EqualTo(received.GetRawAmqpMessage().Properties.CreationTime + TimeSpan.FromDays(100)));
                });
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

                Assert.Multiple(() =>
                {
                    Assert.That(received.TimeToLive, Is.EqualTo(TimeSpan.FromDays(100)));
                    Assert.That(received.ExpiresAt,
                        Is.EqualTo(received.GetRawAmqpMessage().Properties.CreationTime + TimeSpan.FromDays(100)));
                });
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
                Assert.Multiple(() =>
                {
                    Assert.That(rawReceived.Header.DeliveryCount, Is.Not.Null);
                    Assert.That(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.LockedUntilName), Is.True);
                    Assert.That(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.SequenceNumberName), Is.True);
                    Assert.That(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueueSequenceNumberName), Is.True);
                    Assert.That(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueuedTimeUtcName), Is.True);
                    Assert.That(rawReceived.MessageAnnotations.ContainsKey(AmqpMessageConstants.MessageStateName), Is.True);
                });

                AssertMessagesEqual(msg, received);
                var toSend = new ServiceBusMessage(received);
                AmqpAnnotatedMessage rawSend = toSend.GetRawAmqpMessage();

                Assert.Multiple(() =>
                {
                    // verify that all system set properties have been cleared out
                    Assert.That(rawSend.Header.DeliveryCount, Is.Null);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.LockedUntilName), Is.False);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.SequenceNumberName), Is.False);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.DeadLetterSourceName), Is.False);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueueSequenceNumberName), Is.False);
                    Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.EnqueuedTimeUtcName), Is.False);
                });
                Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.DeadLetterSourceName), Is.False);
                Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.MessageStateName), Is.False);
                Assert.That(rawSend.MessageAnnotations.ContainsKey(AmqpMessageConstants.ScheduledEnqueueTimeUtcName), Is.False);
                Assert.That(toSend.ApplicationProperties.ContainsKey(AmqpMessageConstants.DeadLetterReasonHeader), Is.False);
                Assert.That(toSend.ApplicationProperties.ContainsKey(AmqpMessageConstants.DeadLetterErrorDescriptionHeader), Is.False);

                AssertMessagesEqual(toSend, received);

                void AssertMessagesEqual(ServiceBusMessage sentMessage, ServiceBusReceivedMessage received)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(received.Body.ToArray().SequenceEqual(sentMessage.Body.ToArray()), Is.True);
                        Assert.That(sentMessage.ContentType, Is.EqualTo(received.ContentType));
                        Assert.That(sentMessage.CorrelationId, Is.EqualTo(received.CorrelationId));
                    });
                    Assert.That(received.Subject, Is.EqualTo(sentMessage.Subject));
                    Assert.That(received.ContentType, Is.EqualTo(sentMessage.ContentType));
                    Assert.That(received.CorrelationId, Is.EqualTo(sentMessage.CorrelationId));
                    Assert.Multiple(() =>
                    {
                        Assert.That(sentMessage.MessageId, Is.EqualTo(received.MessageId));
                        Assert.That(sentMessage.PartitionKey, Is.EqualTo(received.PartitionKey));
                        Assert.That((string)sentMessage.ApplicationProperties["testProp"], Is.EqualTo((string)received.ApplicationProperties["testProp"]));
                        Assert.That(sentMessage.ReplyTo, Is.EqualTo(received.ReplyTo));
                        Assert.That(sentMessage.ReplyToSessionId, Is.EqualTo(received.ReplyToSessionId));
                        Assert.That(sentMessage.SessionId, Is.EqualTo(received.SessionId));
                        Assert.That(sentMessage.TimeToLive, Is.EqualTo(received.TimeToLive));
                        Assert.That(sentMessage.To, Is.EqualTo(received.To));
                        Assert.That(sentMessage.TransactionPartitionKey, Is.EqualTo(received.TransactionPartitionKey));
                    });
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
                Assert.Multiple(() =>
                {
                    Assert.That(receivedBody.A, Is.EqualTo(testBody.A));
                    Assert.That(receivedBody.B, Is.EqualTo(testBody.B));
                    Assert.That(receivedBody.C, Is.EqualTo(testBody.C));
                });
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
                    Assert.That(bodyEnum.Current.ToArray(), Is.EqualTo(bytes));
                    if (ct++ == 0)
                    {
                        Assert.That(received.Body.ToMemory().Slice(0, 100).ToArray(), Is.EqualTo(bytes));
                    }
                    else
                    {
                        Assert.That(received.Body.ToMemory().Slice(100, 100).ToArray(), Is.EqualTo(bytes));
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
                Assert.That(receivedData, Is.EqualTo(value));

                Assert.That(
                    () => received.Body,
                    Throws.InstanceOf<NotSupportedException>());

                var sendable = new ServiceBusMessage(received);
                sendable.GetRawAmqpMessage().Body.TryGetValue(out var sendData);
                Assert.That(sendData, Is.EqualTo(value));
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
                        Assert.That(innerEnum.Current, Is.EqualTo(elem));
                    }
                }

                Assert.That(
                    () => received.Body,
                    Throws.InstanceOf<NotSupportedException>());

                var sendable = new ServiceBusMessage(received);
                sendable.GetRawAmqpMessage().Body.TryGetSequence(out var sendData);
                Assert.That(sendData, Is.EqualTo(sequence));
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
                Assert.That(received.MessageId, Is.EqualTo(guid.ToString()));
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
                Assert.Multiple(() =>
                {
                    Assert.That(body, Is.EqualTo("body"));

                    Assert.That(received.Header.TimeToLive, Is.EqualTo(TimeSpan.FromSeconds(50)));

                    // the broker will disregard the value set for delivery count
                    Assert.That(received.Header.DeliveryCount, Is.EqualTo(1));
                    Assert.That(received.Header.Durable, Is.True);
                    Assert.That(received.Header.FirstAcquirer, Is.True);
                    Assert.That(received.Header.Priority, Is.EqualTo(1));

                    Assert.That(received.Properties.ContentEncoding, Is.EqualTo("compress"));
                    Assert.That(received.Properties.ContentType, Is.EqualTo("application/json"));
                    Assert.That(received.Properties.CorrelationId, Is.EqualTo(new AmqpMessageId("correlationId")));
                    Assert.That(received.Properties.GroupId, Is.EqualTo("groupId"));
                    Assert.That(received.Properties.GroupSequence, Is.EqualTo(5));
                    Assert.That(received.Properties.MessageId, Is.EqualTo(new AmqpMessageId("messageId")));
                    Assert.That(received.Properties.ReplyTo, Is.EqualTo(new AmqpAddress("replyTo")));
                    Assert.That(received.Properties.ReplyToGroupId, Is.EqualTo("replyToGroupId"));
                    Assert.That(received.Properties.Subject, Is.EqualTo("subject"));
                    Assert.That(received.Properties.To, Is.EqualTo(new AmqpAddress("to")));
                    Assert.That(received.Properties.UserId.Value.ToArray(), Is.EqualTo(new byte[] { 1, 2, 3 }));

                    // since TTL was set these were overriden - provide some buffer since the Now time is
                    Assert.That(received.Properties.CreationTime, Is.EqualTo(now).Within(TimeSpan.FromSeconds(1)));
                    Assert.That(received.Properties.AbsoluteExpiryTime, Is.EqualTo(now.Add(TimeSpan.FromSeconds(50))).Within(TimeSpan.FromSeconds(1)));

                    // application properties
                    Assert.That(received.ApplicationProperties["applicationKey1"], Is.EqualTo("applicationVal1"));
                    Assert.That(received.ApplicationProperties["applicationKey2"], Is.EqualTo("applicationVal2"));

                    // message annotations
                    Assert.That(received.MessageAnnotations["messageAnnotationKey1"], Is.Null);
                    Assert.That(received.MessageAnnotations["messageAnnotationKey2"], Is.EqualTo("messageAnnotationVal2"));

                    // delivery annotations
                    Assert.That(received.DeliveryAnnotations["deliveryAnnotationKey1"], Is.Null);
                    Assert.That(received.DeliveryAnnotations["deliveryAnnotationKey2"], Is.EqualTo("deliveryAnnotationVal2"));

                    // footer
                    Assert.That(received.Footer["footerKey1"], Is.EqualTo("footerVal1"));
                    Assert.That(received.Footer["footerKey2"], Is.EqualTo("footerVal2"));
                    Assert.That(received.Footer["footerKey3"], Is.Null);
                });
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
                Assert.Multiple(() =>
                {
                    Assert.That(body, Is.EqualTo("body"));

                    Assert.That(received.Properties.AbsoluteExpiryTime.Value.ToUnixTimeSeconds(), Is.EqualTo(expiry.ToUnixTimeSeconds()));
                    Assert.That(received.Properties.CreationTime.Value.ToUnixTimeSeconds(), Is.EqualTo(creation.ToUnixTimeSeconds()));
                });
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
                Assert.Multiple(() =>
                {
                    Assert.That(deserialized.ContentType, Is.EqualTo(received.ContentType));
                    Assert.That(deserialized.CorrelationId, Is.EqualTo(received.CorrelationId));
                    Assert.That(deserialized.Subject, Is.EqualTo(received.Subject));
                    Assert.That(deserialized.MessageId, Is.EqualTo(received.MessageId));
                    Assert.That(deserialized.PartitionKey, Is.EqualTo(received.PartitionKey));
                    Assert.That(deserialized.ApplicationProperties["testProp"], Is.EqualTo(received.ApplicationProperties["testProp"]));
                    Assert.That(deserialized.ReplyTo, Is.EqualTo(received.ReplyTo));
                    Assert.That(deserialized.ReplyToSessionId, Is.EqualTo(received.ReplyToSessionId));
                    Assert.That(deserialized.ScheduledEnqueueTime, Is.EqualTo(received.ScheduledEnqueueTime));
                    Assert.That(deserialized.SessionId, Is.EqualTo(received.SessionId));
                    Assert.That(deserialized.TimeToLive, Is.EqualTo(received.TimeToLive));
                    Assert.That(deserialized.To, Is.EqualTo(received.To));
                    Assert.That(deserialized.LockTokenGuid, Is.EqualTo(received.LockTokenGuid));
                });
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