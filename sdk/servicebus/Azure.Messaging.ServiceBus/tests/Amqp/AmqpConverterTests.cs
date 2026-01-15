// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            Assert.That(sbBody.ToArray(), Is.EqualTo(messageBody));
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

            Assert.That(convertedSbMessage.ApplicationProperties["UserProperty"], Is.EqualTo("SomeUserProperty"));
            Assert.That(convertedSbMessage.Body.ToArray(), Is.EqualTo(messageBody));
            Assert.That(convertedSbMessage.MessageId, Is.EqualTo(messageId));
            Assert.That(convertedSbMessage.PartitionKey, Is.EqualTo(partitionKey));
            Assert.That(convertedSbMessage.TransactionPartitionKey, Is.EqualTo(viaPartitionKey));
            Assert.That(convertedSbMessage.SessionId, Is.EqualTo(sessionId));
            Assert.That(convertedSbMessage.CorrelationId, Is.EqualTo(correlationId));
            Assert.That(convertedSbMessage.Subject, Is.EqualTo(label));
            Assert.That(convertedSbMessage.To, Is.EqualTo(to));
            Assert.That(convertedSbMessage.ContentType, Is.EqualTo(contentType));
            Assert.That(convertedSbMessage.ReplyTo, Is.EqualTo(replyTo));
            Assert.That(convertedSbMessage.ReplyToSessionId, Is.EqualTo(replyToSessionId));
            Assert.That(convertedSbMessage.TimeToLive, Is.EqualTo(timeToLive));
        }

        [Test]
        public void SBMessageWithNoTTLResultsInEmptyAmpqTTL()
        {
            var converter = new AmqpMessageConverter();
            var sbMessage = new ServiceBusMessage();

            var amqpMessage = converter.SBMessageToAmqpMessage(sbMessage);

            Assert.That(amqpMessage.Header.Ttl, Is.Null);
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

            Assert.That(sbMessage.DeliveryCount, Is.EqualTo(2));
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

            Assert.That(sbMessage.DeliveryCount, Is.EqualTo(3));
        }

        [Test]
        public void CanRoundTripDictionaryValueSection()
        {
            var annotatedMessage = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(new Dictionary<string, string> { { "key", "value" } }));
            Assert.That(annotatedMessage.Body.TryGetValue(out object val), Is.True);
            Assert.That(((Dictionary<string, string>)val)["key"], Is.EqualTo("value"));

            var amqpMessage = AmqpAnnotatedMessageConverter.ToAmqpMessage(annotatedMessage);

            annotatedMessage = AmqpAnnotatedMessageConverter.FromAmqpMessage(amqpMessage);
            Assert.That(annotatedMessage.Body.TryGetValue(out val), Is.True);
            Assert.That(((Dictionary<string, object>)val)["key"], Is.EqualTo("value"));
        }

        [Test]
        public void CanParseMaxAbsoluteExpiryTime()
        {
            var converter = new AmqpMessageConverter();
            var data = new Data();
            var amqpMessage = AmqpMessage.Create(data);
            amqpMessage.Properties.AbsoluteExpiryTime = DateTime.MaxValue;

            var convertedSbMessage = converter.AmqpMessageToSBReceivedMessage(amqpMessage);

            Assert.That(convertedSbMessage.ExpiresAt, Is.EqualTo(DateTimeOffset.MaxValue));
        }
    }
}
