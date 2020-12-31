// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Text;
    using Azure.Amqp.Framing;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Amqp;
    using InteropExtensions;
    using Xunit;

    public class AmqpConverterTests
    {
        [Fact]
        [DisplayTestMethodName]
        public void Convert_Amqp_message_with_Amqp_value_array_segment_to_SB_message()
        {
            var messageBody = Encoding.UTF8.GetBytes("message1");

            var amqpValue = new AmqpValue();
            amqpValue.Value = new ArraySegment<byte>(messageBody);
            var amqpMessage = AmqpMessage.Create(amqpValue);

            var sbMessage = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
            Assert.Equal(messageBody, sbMessage.GetBody<byte[]>(null));
        }

        [Fact]
        [DisplayTestMethodName]
        public void Convert_Amqp_message_with_Amqp_value_byte_array_to_SB_message()
        {
            var messageBody = Encoding.UTF8.GetBytes("message1");

            var amqpValue = new AmqpValue();
            amqpValue.Value = messageBody;
            var amqpMessage = AmqpMessage.Create(amqpValue);

            var sbMessage = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
            Assert.Equal(messageBody, sbMessage.GetBody<byte[]>(null));
        }

        [Fact]
        [DisplayTestMethodName]
        public void Convert_Amqp_message_with_data_value_array_segment_to_SB_message()
        {
            var messageBody = Encoding.UTF8.GetBytes("message1");

            var data = new Data();
            data.Value = new ArraySegment<byte>(messageBody);
            var amqpMessage = AmqpMessage.Create(data);

            var sbMessage = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
            Assert.Equal(messageBody, sbMessage.Body);
        }

        [Fact]
        [DisplayTestMethodName]
        public void Convert_Amqp_message_with_data_value_byte_array_to_SB_message()
        {
            var messageBody = Encoding.UTF8.GetBytes("message1");

            var data = new Data();
            data.Value = messageBody;
            var amqpMessage = AmqpMessage.Create(data);

            var sbMessage = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);
            Assert.Equal(messageBody, sbMessage.Body);
        }

        [Fact]
        [DisplayTestMethodName]
        public void Convert_SB_message_to_Amqp_message_and_back()
        {
            var messageBody = Encoding.UTF8.GetBytes("hello");
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
            var timeToLive = TimeSpan.FromDays(5);

            var sbMessage = new Message(messageBody)
            {
                MessageId = messageId,
                ViaPartitionKey = viaPartitionKey,
                SessionId = sessionId,
                CorrelationId = correlationId,
                Label = label,
                To = to,
                ContentType = contentType,
                ReplyTo = replyTo,
                ReplyToSessionId = replyToSessionId,
                TimeToLive = timeToLive
            };
            sbMessage.UserProperties.Add("UserProperty", "SomeUserProperty");

            var amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(sbMessage);
            var convertedSbMessage = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);

            Assert.Equal("SomeUserProperty", convertedSbMessage.UserProperties["UserProperty"]);
            Assert.Equal(messageBody, convertedSbMessage.Body);
            Assert.Equal(messageId, convertedSbMessage.MessageId);
            Assert.Equal(viaPartitionKey, convertedSbMessage.ViaPartitionKey);
            Assert.Equal(sessionId, convertedSbMessage.SessionId);
            Assert.Equal(correlationId, convertedSbMessage.CorrelationId);
            Assert.Equal(label, convertedSbMessage.Label);
            Assert.Equal(to, convertedSbMessage.To);
            Assert.Equal(contentType, convertedSbMessage.ContentType);
            Assert.Equal(replyTo, convertedSbMessage.ReplyTo);
            Assert.Equal(replyToSessionId, convertedSbMessage.ReplyToSessionId);
            Assert.Equal(timeToLive, convertedSbMessage.TimeToLive);
        }

        [Fact]
        [DisplayTestMethodName]
        public void SB_message_with_no_TTL_results_in_empty_Ampq_TTL()
        {
            var sbMessage = new Message();

            var amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(sbMessage);

            Assert.Null(amqpMessage.Header.Ttl);
        }

        [Fact]
        [DisplayTestMethodName]
        public void When_message_is_peeked_should_have_delivery_count_set_to_zero()
        {
            var messageBody = Encoding.UTF8.GetBytes("message1");

            var amqpValue = new AmqpValue();
            amqpValue.Value = new ArraySegment<byte>(messageBody);
            var amqpMessage = AmqpMessage.Create(amqpValue);
            amqpMessage.Header.DeliveryCount = 2;

            var sbMessage = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage, isPeeked: true);
            sbMessage.SystemProperties.SequenceNumber = 1L;

            Assert.Equal(2, sbMessage.SystemProperties.DeliveryCount);
        }

        [Fact]
        [DisplayTestMethodName]
        public void When_message_is_received_should_have_delivery_count_increased()
        {
            var messageBody = Encoding.UTF8.GetBytes("message1");

            var amqpValue = new AmqpValue();
            amqpValue.Value = new ArraySegment<byte>(messageBody);
            var amqpMessage = AmqpMessage.Create(amqpValue);
            amqpMessage.Header.DeliveryCount = 2;

            var sbMessage = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage, isPeeked: false);
            sbMessage.SystemProperties.SequenceNumber = 1L;

            Assert.Equal(3, sbMessage.SystemProperties.DeliveryCount);
        }
    }
}