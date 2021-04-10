// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Message
{
    public class MessageTests : ServiceBusTestBase
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
            Assert.AreEqual($"{{MessageId:{id}}}", result);
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
            Assert.That(
                () => message.SessionId = "session",
                Throws.InstanceOf<ArgumentOutOfRangeException>());

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
            Assert.That(
                () => message.SessionId = null,
                Throws.InstanceOf<ArgumentOutOfRangeException>());

            message = new ServiceBusMessage
            {
                PartitionKey = null,
                SessionId = "session"
            };

            message = new ServiceBusMessage
            {
                SessionId = null,
                PartitionKey = "partition"
            };

            message = new ServiceBusMessage
            {
                SessionId = "partition",
                PartitionKey = "partition"
            };

            message = new ServiceBusMessage
            {
                PartitionKey = "partition",
                SessionId = "partition"
            };
        }

        [Test]
        public void SetMessageBodyToString()
        {
            var messageBody = "some message";
            var message = new ServiceBusMessage(messageBody);
            Assert.AreEqual(message.Body.ToString(), messageBody);
        }

        [Test]
        public void CanSetNullBody()
        {
            var message = new ServiceBusMessage();
            Assert.IsTrue(message.Body.ToMemory().IsEmpty);

            message = new ServiceBusMessage((BinaryData) null);
            Assert.IsTrue(message.Body.ToMemory().IsEmpty);
        }

        [Test]
        public void CreateReceivedMessageViaFactory()
        {
            var receivedMessage = ServiceBusModelFactory.ServiceBusReceivedMessage();
            Assert.IsTrue(receivedMessage.Body.ToMemory().IsEmpty);
            Assert.AreEqual(default(string), receivedMessage.MessageId);
            Assert.AreEqual(default(string), receivedMessage.PartitionKey);
            Assert.AreEqual(default(string), receivedMessage.TransactionPartitionKey);
            Assert.AreEqual(default(string), receivedMessage.SessionId);
            Assert.AreEqual(default(string), receivedMessage.ReplyToSessionId);
            Assert.AreEqual(TimeSpan.MaxValue, receivedMessage.TimeToLive);
            Assert.AreEqual(default(string), receivedMessage.CorrelationId);
            Assert.AreEqual(default(string), receivedMessage.Subject);
            Assert.AreEqual(default(string), receivedMessage.To);
            Assert.AreEqual(default(string), receivedMessage.ContentType);
            Assert.AreEqual(default(string), receivedMessage.ReplyTo);
            Assert.AreEqual(default(DateTimeOffset), receivedMessage.ScheduledEnqueueTime);
            Assert.IsNotNull(receivedMessage.ApplicationProperties);
            Assert.IsEmpty(receivedMessage.ApplicationProperties);
            Assert.AreEqual(default(Guid), receivedMessage.LockTokenGuid);
            Assert.AreEqual(default(int), receivedMessage.DeliveryCount);
            Assert.AreEqual(default(DateTimeOffset), receivedMessage.LockedUntil);
            Assert.AreEqual(-1, receivedMessage.SequenceNumber);
            Assert.AreEqual(default(string), receivedMessage.DeadLetterSource);
            Assert.AreEqual(default(long), receivedMessage.EnqueuedSequenceNumber);
            Assert.AreEqual(default(DateTimeOffset), receivedMessage.EnqueuedTime);

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
            Assert.AreEqual("binaryData2468", receivedMessage.Body.ToString());
            Assert.AreEqual("messageId12345", receivedMessage.MessageId);
            Assert.AreEqual("partitionKey98765", receivedMessage.PartitionKey);
            Assert.AreEqual("viaPartitionKey8765", receivedMessage.TransactionPartitionKey);
            Assert.AreEqual("sessionId8877", receivedMessage.SessionId);
            Assert.AreEqual("replyToSessionId4556", receivedMessage.ReplyToSessionId);
            Assert.AreEqual(TimeSpan.FromMinutes(5).ToString(), receivedMessage.TimeToLive.ToString());
            Assert.AreEqual("correlationId8877", receivedMessage.CorrelationId);
            Assert.AreEqual("label4523", receivedMessage.Subject);
            Assert.AreEqual("to9887", receivedMessage.To);
            Assert.AreEqual("contentType0538", receivedMessage.ContentType);
            Assert.AreEqual("replyTo2598", receivedMessage.ReplyTo);
            Assert.AreEqual(new DateTimeOffset(fixedDate, TimeSpan.FromHours(2)).UtcDateTime, receivedMessage.ScheduledEnqueueTime.UtcDateTime);
            Assert.IsNotNull(receivedMessage.ApplicationProperties);
            Assert.IsNotEmpty(receivedMessage.ApplicationProperties);
            Assert.AreEqual(new[] { "42", "properties0864" }, receivedMessage.ApplicationProperties.Keys);
            Assert.AreEqual(new object[] { 6420, "testValue" }, receivedMessage.ApplicationProperties.Values);
            Assert.AreEqual("f5ae57c7-963b-4864-ae19-32b12451e5d8", receivedMessage.LockTokenGuid.ToString());
            Assert.AreEqual(4321, receivedMessage.DeliveryCount);
            Assert.AreEqual(new DateTimeOffset(fixedDate, TimeSpan.FromMinutes(18)).UtcDateTime, receivedMessage.LockedUntil.UtcDateTime);
            Assert.AreEqual(3456, receivedMessage.SequenceNumber);
            Assert.AreEqual("deadLetterSource5773", receivedMessage.DeadLetterSource);
            Assert.AreEqual(7632, receivedMessage.EnqueuedSequenceNumber);
            Assert.AreEqual(new DateTimeOffset(fixedDate, TimeSpan.FromSeconds(120)).UtcDateTime, receivedMessage.EnqueuedTime.UtcDateTime);
        }
    }
}
