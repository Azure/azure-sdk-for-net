// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;
using Azure.Core.Amqp;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Message
{
    public class MessageTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("123")]
        [TestCase("jøbber-nå")]
        public void MessageToString(string id)
        {
            var message = new ServiceBusMessage();
            if (id != null)
            {
                message.MessageId = id;
            }
            var result = message.ToString();
            Assert.That(result, Is.EqualTo($"{{MessageId:{id}}}"));
        }

        [Test]
        public void SettingNullMessageIdThrows()
        {
            var message = new ServiceBusMessage();
            Assert.That(() => message.MessageId = null, Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void SettingEmptyMessageIdThrows()
        {
            var message = new ServiceBusMessage();
            Assert.That(() => message.MessageId = "", Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void SettingLongMessageIdThrows()
        {
            var message = new ServiceBusMessage();
            Assert.That(() => message.MessageId = string.Concat(Enumerable.Repeat("a", 130)), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void SettingNullSessionDoesNotThrow()
        {
            var message = new ServiceBusMessage
            {
                SessionId = null
            };
        }

        [Test]
        public void SettingLongSessionIdThrows()
        {
            var message = new ServiceBusMessage();
            Assert.That(() => message.SessionId = string.Concat(Enumerable.Repeat("a", 130)), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void SettingNullReplyToSessionDoesNotThrow()
        {
            var message = new ServiceBusMessage
            {
                ReplyToSessionId = null
            };
        }

        [Test]
        public void SettingLongReplyToSessionIdThrows()
        {
            var message = new ServiceBusMessage();
            Assert.That(() => message.ReplyToSessionId = string.Concat(Enumerable.Repeat("a", 130)), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void SettingNullPartitionKeyDoesNotThrow()
        {
            var message = new ServiceBusMessage
            {
                PartitionKey = null
            };
        }

        [Test]
        public void SettingLongPartitionKeyThrows()
        {
            var message = new ServiceBusMessage();
            Assert.That(() => message.PartitionKey = string.Concat(Enumerable.Repeat("a", 130)), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void PartitionKeyMustMatchSessionIdIfBothSet()
        {
            var message = new ServiceBusMessage
            {
                SessionId = "session"
            };
            Assert.That(
                () => message.PartitionKey = "partition",
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            message = new ServiceBusMessage
            {
                PartitionKey = "partition"
            };
            message.SessionId = "session";
            Assert.That(message.PartitionKey, Is.EqualTo("session"));
            Assert.That(message.PartitionKey, Is.EqualTo(message.SessionId));

            message = new ServiceBusMessage
            {
                SessionId = "session"
            };
            Assert.That(
                () => message.PartitionKey = null,
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            message = new ServiceBusMessage
            {
                PartitionKey = "partition"
            };
            message.SessionId = null;
            Assert.That(message.PartitionKey, Is.Null);

            message = new ServiceBusMessage
            {
                PartitionKey = null,
                SessionId = "session"
            };
            Assert.That(message.PartitionKey, Is.Null);

            message = new ServiceBusMessage
            {
                SessionId = null,
                PartitionKey = "partition"
            };
            Assert.That(message.SessionId, Is.Null);

            message = new ServiceBusMessage
            {
                SessionId = "partition",
                PartitionKey = "partition"
            };
            Assert.That(message.PartitionKey, Is.EqualTo(message.SessionId));

            message = new ServiceBusMessage
            {
                PartitionKey = "partition",
                SessionId = "partition"
            };
            Assert.That(message.PartitionKey, Is.EqualTo(message.SessionId));

            message = new ServiceBusMessage
            {
                PartitionKey = "partition",
                SessionId = "partition"
            };
            message.SessionId = "session";
            Assert.That(message.PartitionKey, Is.EqualTo(message.SessionId));
        }

        [Test]
        public void SetMessageBodyToString()
        {
            var messageBody = "some message";
            var message = new ServiceBusMessage(messageBody);
            Assert.That(messageBody, Is.EqualTo(message.Body.ToString()));
        }

        [Test]
        public void CanSetNullBody()
        {
            var message = new ServiceBusMessage();
            Assert.That(message.Body.ToMemory().IsEmpty, Is.True);

            message = new ServiceBusMessage((BinaryData) null);
            Assert.That(message.Body.ToMemory().IsEmpty, Is.True);
        }

        [Test]
        public void CreateReceivedMessageViaFactory()
        {
            var receivedMessage = ServiceBusModelFactory.ServiceBusReceivedMessage();
            Assert.That(receivedMessage.Body.ToMemory().IsEmpty, Is.True);
            Assert.That(receivedMessage.MessageId, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.PartitionKey, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.TransactionPartitionKey, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.SessionId, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.ReplyToSessionId, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.TimeToLive, Is.EqualTo(TimeSpan.MaxValue));
            Assert.That(receivedMessage.CorrelationId, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.Subject, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.To, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.ContentType, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.ReplyTo, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.ScheduledEnqueueTime, Is.EqualTo(default(DateTimeOffset)));
            Assert.That(receivedMessage.ApplicationProperties, Is.Not.Null);
            Assert.That(receivedMessage.ApplicationProperties, Is.Empty);
            Assert.That(receivedMessage.LockTokenGuid, Is.EqualTo(default(Guid)));
            Assert.That(receivedMessage.DeliveryCount, Is.EqualTo(default(int)));
            Assert.That(receivedMessage.LockedUntil, Is.EqualTo(default(DateTimeOffset)));
            Assert.That(receivedMessage.SequenceNumber, Is.EqualTo(-1));
            Assert.That(receivedMessage.DeadLetterSource, Is.EqualTo(default(string)));
            Assert.That(receivedMessage.EnqueuedSequenceNumber, Is.EqualTo(default(long)));
            Assert.That(receivedMessage.EnqueuedTime, Is.EqualTo(default(DateTimeOffset)));

            var fixedDate = new DateTime(2000, 1, 1);
            receivedMessage = ServiceBusModelFactory.ServiceBusReceivedMessage(
                new BinaryData("binaryData2468"),
                "messageId12345",
                "partitionKey98765",
                "viaPartitionKey8765",
                "sessionId8877",
                "replyToSessionId4556",
                TimeSpan.FromMinutes(5),
                "correlationId8877",
                "label4523",
                "to9887",
                "contentType0538",
                "replyTo2598",
                new DateTimeOffset(fixedDate, TimeSpan.FromHours(2)),
                new Dictionary<string, object> {
                    { "42", 6420 },
                    { "properties0864", "testValue" }
                },
                Guid.Parse("f5ae57c7-963b-4864-ae19-32b12451e5d8"),
                4321,
                new DateTimeOffset(fixedDate, TimeSpan.FromMinutes(18)),
                3456,
                "deadLetterSource5773",
                7632,
                new DateTimeOffset(fixedDate, TimeSpan.FromSeconds(120))
            );
            Assert.That(receivedMessage.Body.ToString(), Is.EqualTo("binaryData2468"));
            Assert.That(receivedMessage.MessageId, Is.EqualTo("messageId12345"));
            Assert.That(receivedMessage.PartitionKey, Is.EqualTo("partitionKey98765"));
            Assert.That(receivedMessage.TransactionPartitionKey, Is.EqualTo("viaPartitionKey8765"));
            Assert.That(receivedMessage.SessionId, Is.EqualTo("sessionId8877"));
            Assert.That(receivedMessage.ReplyToSessionId, Is.EqualTo("replyToSessionId4556"));
            Assert.That(receivedMessage.TimeToLive.ToString(), Is.EqualTo(TimeSpan.FromMinutes(5).ToString()));
            Assert.That(receivedMessage.CorrelationId, Is.EqualTo("correlationId8877"));
            Assert.That(receivedMessage.Subject, Is.EqualTo("label4523"));
            Assert.That(receivedMessage.To, Is.EqualTo("to9887"));
            Assert.That(receivedMessage.ContentType, Is.EqualTo("contentType0538"));
            Assert.That(receivedMessage.ReplyTo, Is.EqualTo("replyTo2598"));
            Assert.That(receivedMessage.ScheduledEnqueueTime.UtcDateTime, Is.EqualTo(new DateTimeOffset(fixedDate, TimeSpan.FromHours(2)).UtcDateTime));
            Assert.That(receivedMessage.ApplicationProperties, Is.Not.Null);
            Assert.That(receivedMessage.ApplicationProperties, Is.Not.Empty);
            Assert.That(receivedMessage.ApplicationProperties.Keys, Is.EqualTo(new[] { "42", "properties0864" }));
            Assert.That(receivedMessage.ApplicationProperties.Values, Is.EqualTo(new object[] { 6420, "testValue" }));
            Assert.That(receivedMessage.LockTokenGuid.ToString(), Is.EqualTo("f5ae57c7-963b-4864-ae19-32b12451e5d8"));
            Assert.That(receivedMessage.DeliveryCount, Is.EqualTo(4321));
            Assert.That(receivedMessage.LockedUntil.UtcDateTime, Is.EqualTo(new DateTimeOffset(fixedDate, TimeSpan.FromMinutes(18)).UtcDateTime));
            Assert.That(receivedMessage.SequenceNumber, Is.EqualTo(3456));
            Assert.That(receivedMessage.DeadLetterSource, Is.EqualTo("deadLetterSource5773"));
            Assert.That(receivedMessage.EnqueuedSequenceNumber, Is.EqualTo(7632));
            Assert.That(receivedMessage.EnqueuedTime.UtcDateTime, Is.EqualTo(new DateTimeOffset(fixedDate, TimeSpan.FromSeconds(120)).UtcDateTime));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void CanSerializeDeserializeAmqpBytes(bool useSession)
        {
            var message = new ServiceBusMessage(new BinaryData(ServiceBusTestUtilities.GetRandomBuffer(100)));
            message.ContentType = "contenttype";
            message.CorrelationId = "correlationid";
            message.Subject = "label";
            message.MessageId = "messageId";
            message.PartitionKey = "key";
            message.ApplicationProperties.Add("testProp", "my prop");
            message.ReplyTo = "replyto";

            message.ScheduledEnqueueTime = DateTimeOffset.Now;
            if (useSession)
            {
                message.SessionId = "key";
                message.ReplyToSessionId = "replytosession";
            }

            message.TimeToLive = TimeSpan.FromSeconds(60);
            message.To = "to";

            var serialized = message.GetRawAmqpMessage().ToBytes();

            var deserialized = new ServiceBusMessage(AmqpAnnotatedMessage.FromBytes(serialized));
            Assert.That(deserialized.ContentType, Is.EqualTo(message.ContentType));
            Assert.That(deserialized.CorrelationId, Is.EqualTo(message.CorrelationId));
            Assert.That(deserialized.Subject, Is.EqualTo(message.Subject));
            Assert.That(deserialized.MessageId, Is.EqualTo(message.MessageId));
            Assert.That(deserialized.PartitionKey, Is.EqualTo(message.PartitionKey));
            Assert.That(deserialized.ApplicationProperties["testProp"], Is.EqualTo(message.ApplicationProperties["testProp"]));
            Assert.That(deserialized.ReplyTo, Is.EqualTo(message.ReplyTo));
            Assert.That(deserialized.ReplyToSessionId, Is.EqualTo(message.ReplyToSessionId));
            // because AMQP only has millisecond resolution, allow for up to a 1ms difference when round-tripping
            Assert.That(deserialized.ScheduledEnqueueTime, Is.EqualTo(message.ScheduledEnqueueTime).Within(1).Milliseconds);
            Assert.That(deserialized.SessionId, Is.EqualTo(message.SessionId));
            Assert.That(deserialized.TimeToLive, Is.EqualTo(message.TimeToLive));
            Assert.That(deserialized.To, Is.EqualTo(message.To));
        }
    }
}
