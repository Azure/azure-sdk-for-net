// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Core;
using Azure.Core.Amqp;
using Azure.Core.Amqp.Shared;
using Azure.Messaging.ServiceBus.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests.Amqp
{
    public class AmqpConverterTests
    {
        [TestCase("")]
        [TestCase("ascii")]
        [TestCase("caf\u00e9-\u6771\u4eac")]
        [TestCase("\0\U0001F680")]
        public void Utf8ApplicationPropertyUsesStringWireEncoding(string text)
        {
            var converter = new AmqpMessageConverter();
            var source = new ServiceBusMessage();
            source.ApplicationProperties["value"] = AmqpUtf8String.FromBytes(Encoding.UTF8.GetBytes(text));
            using var native = converter.SBMessageToAmqpMessage(source);
            using var stream = native.ToStream();
            var received = AmqpAnnotatedMessage.FromBytes(BinaryData.FromStream(stream));
            Assert.AreEqual(text, received.ApplicationProperties["value"]);
        }

#if NETCOREAPP
        [Test]
        public void Utf8ApplicationPropertyDoesNotAddConversionAllocations()
        {
            var value = AmqpUtf8String.FromBytes(Encoding.UTF8.GetBytes("message-identifier"));
            for (int warmup = 0; warmup < 100; warmup++)
            {
                AmqpAnnotatedMessageConverter.TryCreateAmqpPropertyValueFromNetProperty(value, out _);
            }

            long before = GC.GetAllocatedBytesForCurrentThread();
            for (int iteration = 0; iteration < 1_000; iteration++)
            {
                AmqpAnnotatedMessageConverter.TryCreateAmqpPropertyValueFromNetProperty(value, out _);
            }
            long allocated = GC.GetAllocatedBytesForCurrentThread() - before;
            Assert.AreEqual(0, allocated);
        }

        [Test]
        public void Utf8ApplicationPropertiesReduceSerializationAllocations()
        {
            string[] keys = { "id", "time", "type", "source", "version" };
            string[] text = {
                "019a3c1b-97c0-7000-8000-000000000001",
                "2026-11-02T00:00:00.0000000Z",
                "example.order.created", "example", "1.0"
            };
            var bytes = new byte[text.Length][];
            var values = new AmqpUtf8String[text.Length];
            var source = new ServiceBusMessage(new byte[256]);
            var converter = new AmqpMessageConverter();
            for (int field = 0; field < text.Length; field++)
            {
                bytes[field] = Encoding.UTF8.GetBytes(text[field]);
                values[field] = AmqpUtf8String.FromBytes(bytes[field]);
            }

            long original = Measure(0);
            long decoded = Measure(1);
            long fresh = Measure(2);
            long reused = Measure(3);
            TestContext.Progress.WriteLine($"Serialization bytes/op: strings={original}, decoded={decoded}, fresh wrappers={fresh}, reused wrappers={reused}");
            Assert.Less(fresh, decoded);
            Assert.Less(reused, fresh);

            long Measure(int mode)
            {
                for (int warmup = 0; warmup < 100; warmup++)
                {
                    Serialize(mode);
                }
                long before = GC.GetAllocatedBytesForCurrentThread();
                for (int iteration = 0; iteration < 1_000; iteration++)
                {
                    Serialize(mode);
                }
                return (GC.GetAllocatedBytesForCurrentThread() - before) / 1_000;
            }

            void Serialize(int mode)
            {
                for (int field = 0; field < text.Length; field++)
                {
                    source.ApplicationProperties[keys[field]] = mode switch
                    {
                        0 => text[field],
                        1 => Encoding.UTF8.GetString(bytes[field]),
                        2 => AmqpUtf8String.FromBytes(bytes[field]),
                        _ => values[field]
                    };
                }
                using var native = converter.SBMessageToAmqpMessage(source);
                using var stream = native.ToStream();
                stream.CopyTo(Stream.Null);
            }
        }
#endif

        [Test]
        public void ConvertAmqpMessageToSBMessage()
        {
            var messageBody = Encoding.UTF8.GetBytes("message1");
            var converter = new AmqpMessageConverter();

            var data = new Data();
            data.Value = messageBody;
            var amqpMessage = AmqpMessage.Create(data);

            var sbMessage = converter.AmqpMessageToSBReceivedMessage(amqpMessage);
            ReadOnlyMemory<byte> sbBody = sbMessage.Body;
            Assert.AreEqual(messageBody, sbBody.ToArray());
        }

        [Test]
        public void ConvertSBMessageToAmqpMessageAndBack()
        {
            var converter = new AmqpMessageConverter();

            var messageBody = Encoding.UTF8.GetBytes("hello");
            var messageId = Guid.NewGuid().ToString();
            var partitionKey = Guid.NewGuid().ToString();
            var viaPartitionKey = Guid.NewGuid().ToString();
            var sessionId = partitionKey;
            var correlationId = Guid.NewGuid().ToString();
            var label = Guid.NewGuid().ToString();
            var to = Guid.NewGuid().ToString();
            var contentType = Guid.NewGuid().ToString();
            var replyTo = Guid.NewGuid().ToString();
            var replyToSessionId = Guid.NewGuid().ToString();
            var timeToLive = TimeSpan.FromDays(5);

            var sbMessage = new ServiceBusMessage(messageBody)
            {
                MessageId = messageId,
                PartitionKey = partitionKey,
                TransactionPartitionKey = viaPartitionKey,
                SessionId = sessionId,
                CorrelationId = correlationId,
                Subject = label,
                To = to,
                ContentType = contentType,
                ReplyTo = replyTo,
                ReplyToSessionId = replyToSessionId,
                TimeToLive = timeToLive,
            };
            sbMessage.ApplicationProperties.Add("UserProperty", "SomeUserProperty");

            var amqpMessage = converter.SBMessageToAmqpMessage(sbMessage);
            var convertedSbMessage = converter.AmqpMessageToSBReceivedMessage(amqpMessage);

            Assert.AreEqual("SomeUserProperty", convertedSbMessage.ApplicationProperties["UserProperty"]);
            Assert.AreEqual(messageBody, convertedSbMessage.Body.ToArray());
            Assert.AreEqual(messageId, convertedSbMessage.MessageId);
            Assert.AreEqual(partitionKey, convertedSbMessage.PartitionKey);
            Assert.AreEqual(viaPartitionKey, convertedSbMessage.TransactionPartitionKey);
            Assert.AreEqual(sessionId, convertedSbMessage.SessionId);
            Assert.AreEqual(correlationId, convertedSbMessage.CorrelationId);
            Assert.AreEqual(label, convertedSbMessage.Subject);
            Assert.AreEqual(to, convertedSbMessage.To);
            Assert.AreEqual(contentType, convertedSbMessage.ContentType);
            Assert.AreEqual(replyTo, convertedSbMessage.ReplyTo);
            Assert.AreEqual(replyToSessionId, convertedSbMessage.ReplyToSessionId);
            Assert.AreEqual(timeToLive, convertedSbMessage.TimeToLive);
        }

        [Test]
        public void SBMessageWithNoTTLResultsInEmptyAmpqTTL()
        {
            var converter = new AmqpMessageConverter();
            var sbMessage = new ServiceBusMessage();

            var amqpMessage = converter.SBMessageToAmqpMessage(sbMessage);

            Assert.Null(amqpMessage.Header.Ttl);
        }

        [Test]
        public void PeekedMessageShouldNotIncrementDeliveryCount()
        {
            var converter = new AmqpMessageConverter();
            var messageBody = Encoding.UTF8.GetBytes("message1");

            var amqpValue = new AmqpValue();
            amqpValue.Value = new ArraySegment<byte>(messageBody);
            var amqpMessage = AmqpMessage.Create(amqpValue);
            amqpMessage.Header.DeliveryCount = 2;

            var sbMessage = converter.AmqpMessageToSBReceivedMessage(amqpMessage, isPeeked: true);
            sbMessage.SequenceNumber = 1L;

            Assert.AreEqual(2, sbMessage.DeliveryCount);
        }

        [Test]
        public void ReceivedMessageShouldIncrementDeliveryCount()
        {
            var converter = new AmqpMessageConverter();
            var messageBody = Encoding.UTF8.GetBytes("message1");

            var amqpValue = new AmqpValue();
            amqpValue.Value = new ArraySegment<byte>(messageBody);
            var amqpMessage = AmqpMessage.Create(amqpValue);
            amqpMessage.Header.DeliveryCount = 2;

            var sbMessage = converter.AmqpMessageToSBReceivedMessage(amqpMessage, isPeeked: false);
            sbMessage.SequenceNumber = 1L;

            Assert.AreEqual(3, sbMessage.DeliveryCount);
        }

        [Test]
        public void CanRoundTripDictionaryValueSection()
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(new Dictionary<string, string> { { "key", "value" } }));
            Assert.IsTrue(annotatedMessage.Body.TryGetValue(out object val));
            Assert.AreEqual("value", ((Dictionary<string, string>)val)["key"]);

            var amqpMessage = AmqpAnnotatedMessageConverter.ToAmqpMessage(annotatedMessage);

            annotatedMessage = AmqpAnnotatedMessageConverter.FromAmqpMessage(amqpMessage);
            Assert.IsTrue(annotatedMessage.Body.TryGetValue(out val));
            Assert.AreEqual("value", ((Dictionary<string, object>)val)["key"]);
        }

        [Test]
        public void CanParseMaxAbsoluteExpiryTime()
        {
            var converter = new AmqpMessageConverter();
            var data = new Data();
            var amqpMessage = AmqpMessage.Create(data);
            amqpMessage.Properties.AbsoluteExpiryTime = DateTime.MaxValue;

            var convertedSbMessage = converter.AmqpMessageToSBReceivedMessage(amqpMessage);

            Assert.AreEqual(DateTimeOffset.MaxValue, convertedSbMessage.ExpiresAt);
        }
    }
}
