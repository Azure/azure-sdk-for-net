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
        void Convert_Amqp_message_with_Amqp_value_array_segment_to_SB_message()
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
        void Convert_Amqp_message_with_Amqp_value_byte_array_to_SB_message()
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
        void Convert_Amqp_message_with_data_value_array_segment_to_SB_message()
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
        void Convert_Amqp_message_with_data_value_byte_array_to_SB_message()
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
        void Convert_SB_message_to_Amqp_message_and_back()
        {
            var messageBody = Encoding.UTF8.GetBytes("hello");
            var messageId = Guid.NewGuid().ToString();
            var partitionKey = Guid.NewGuid().ToString();
            var sessionId = Guid.NewGuid().ToString();
            var correlationId = Guid.NewGuid().ToString();
            var label = Guid.NewGuid().ToString();
            var to = Guid.NewGuid().ToString();
            var contentType = Guid.NewGuid().ToString();
            var replyTo = Guid.NewGuid().ToString();
            var replyToSessionId = Guid.NewGuid().ToString();
            var publisher = Guid.NewGuid().ToString();

            var sbMessage = new Message(messageBody)
            {
                MessageId = messageId,
                PartitionKey = partitionKey,
                SessionId = sessionId,
                CorrelationId = correlationId,
                Label = label,
                To = to,
                ContentType = contentType,
                ReplyTo = replyTo,
                ReplyToSessionId = replyToSessionId
            };
            sbMessage.UserProperties.Add("UserProperty", "SomeUserProperty");

            var amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(sbMessage);
            var convertedSbMessage = AmqpMessageConverter.AmqpMessageToSBMessage(amqpMessage);

            Assert.Equal("SomeUserProperty", convertedSbMessage.UserProperties["UserProperty"]);
            Assert.Equal(messageBody, convertedSbMessage.Body);
            Assert.Equal(messageId, convertedSbMessage.MessageId);
            Assert.Equal(partitionKey, convertedSbMessage.PartitionKey);
            Assert.Equal(sessionId, convertedSbMessage.SessionId);
            Assert.Equal(correlationId, convertedSbMessage.CorrelationId);
            Assert.Equal(label, convertedSbMessage.Label);
            Assert.Equal(to, convertedSbMessage.To);
            Assert.Equal(contentType, convertedSbMessage.ContentType);
            Assert.Equal(replyTo, convertedSbMessage.ReplyTo);
            Assert.Equal(replyToSessionId, convertedSbMessage.ReplyToSessionId);
        }
    }
}