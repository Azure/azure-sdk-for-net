// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
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
        public void CanParseDictionaryValueSection()
        {
            var converter = new AmqpMessageConverter();
            var amqpMessage = AmqpMessage.Create(new AmqpValue { Value = new Dictionary<string, string> { { "key", "value" } } });
            var sbMessage = converter.AmqpMessageToSBReceivedMessage(amqpMessage);
            var body = sbMessage.GetRawAmqpMessage().Body;
            Assert.IsTrue(body.TryGetValue(out object val));
            Assert.AreEqual("value", ((Dictionary<string, string>)val)["key"]);

            amqpMessage = AmqpMessage.Create(new AmqpValue { Value = new AmqpMap { { new MapKey("key"), "value" } } });
            sbMessage = converter.AmqpMessageToSBReceivedMessage(amqpMessage);
            body = sbMessage.GetRawAmqpMessage().Body;
            Assert.IsTrue(body.TryGetValue(out val));
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
