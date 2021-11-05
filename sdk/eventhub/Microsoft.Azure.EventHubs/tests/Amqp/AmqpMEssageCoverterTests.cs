// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Amqp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.EventHubs.Amqp;
    using Xunit;

    public class AmqpMessageCoverterTests
    {
        /// <summary>
        /// Validating that properties from an Amqp message are forwarded to EventData SystemProperties
        /// </summary>
        [Fact]
        [DisplayTestMethodName]
        public void UpdateEventDataHeaderAndPropertiesReceiveCorrelationIdAndCopyItsValueToEventData()
        {
            // Arrange
            // the following simulates a message's round trip from client to broker to client
            var message = AmqpMessage.Create(new MemoryStream(new byte[12]), true);
            AddSection(message, SectionFlag.Properties);
            // serialize - send the message on client side
            ArraySegment<byte>[] buffers = ReadMessagePayLoad(message, 71);

            // Act
            var eventData = AmqpMessageConverter.AmqpMessageToEventData(message);

            // Assert
            Assert.NotNull(eventData);
            Assert.NotNull(eventData.SystemProperties);
            Assert.NotNull(eventData.SystemProperties[Properties.CorrelationIdName]);
            Assert.Equal("42", eventData.SystemProperties[Properties.CorrelationIdName].ToString());
        }

        [Fact]
        [DisplayTestMethodName]
        public void ContentTypeFromAmqpMessage()
        {
            var message = AmqpMessage.Create(new MemoryStream(new byte[12]), true);
            AddSection(message, SectionFlag.Properties);
            message.Properties.ContentType = "this content type";
            var eventData = AmqpMessageConverter.AmqpMessageToEventData(message);
            Assert.Equal(message.Properties.ContentType.Value, eventData.ContentType);
        }

        [Fact]
        [DisplayTestMethodName]
        public void ContentTypeToAmqpMessage()
        {
            var eventData = new EventData(new byte[10]);
            eventData.ContentType = "this content type";
            var message = AmqpMessageConverter.EventDataToAmqpMessage(eventData);
            Assert.Equal(message.Properties.ContentType.Value, eventData.ContentType);
        }

        // for more information please take a look at https://github.com/Azure/azure-amqp/blob/339708e6390447004c3eec8ae28e6577199a4328/test/TestCases/AmqpMessageTests.cs#L160
        private static void AddSection(AmqpMessage message, SectionFlag sections)
        {
            if ((sections & SectionFlag.Properties) != 0)
            {
                message.Properties.CorrelationId = "42";
            }
        }

        private static ArraySegment<byte>[] ReadMessagePayLoad(AmqpMessage message, int payloadSize)
        {
            List<ArraySegment<byte>> buffers = new List<ArraySegment<byte>>();
            bool more = true;
            while (more)
            {
                ArraySegment<byte>[] messageBuffers = message.GetPayload(payloadSize, out more);
                if (messageBuffers != null)
                {
                    foreach (var segment in messageBuffers)
                    { message.CompletePayload(segment.Count); }
                    buffers.AddRange(messageBuffers);
                }
            }

            return buffers.ToArray();
        }
    }
}
