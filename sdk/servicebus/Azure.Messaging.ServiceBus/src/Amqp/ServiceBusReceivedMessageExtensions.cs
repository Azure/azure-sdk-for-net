// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    /// Extension methods for <see cref="ServiceBusReceivedMessage"/>.
    /// </summary>
    public static class ServiceBusReceivedMessageExtensions
    {
        /// <summary>
        /// Gets the body type from an AMQP <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the body type of the AMQP message.</returns>
        public static AmqpBodyType GetAmqpBodyType(this ServiceBusReceivedMessage message)
        {
            var transportBody = (AmqpTransportBody)message.SentMessage.TransportBody;
            // If DataCount is greater than 0, it means that data was received, and the message is non-Sequence/Value.
            // This won't be greater than 0 on user-constructed Data messages, but it will be on received Data messages.
            // The actual AmqpBodyType will be Unspecified on received Data messages with 0 or 1 data elements.
            // Therefore, a received message can be converted to a sent message, and the AmqpBodyType will be correct for that process.
            // However, we let the user know the actual AmqpBodyType here as they would expect.
            return transportBody.DataCount > 0 ? AmqpBodyType.Data : message.SentMessage.GetAmqpBodyType();
        }

        /// <summary>
        /// Gets the Data body type from an AMQP <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the Data body of the AMQP message.</returns>
        public static IEnumerable<ReadOnlyMemory<byte>> GetAmqpDataBody(this ServiceBusReceivedMessage message)
        {
            var transportBody = (AmqpTransportBody)message.SentMessage.TransportBody;
            // If it has 1 data element, Data will not be populated. However, we want to provide the data to the user like it is populated.
            // If it has 0 data elements, Data will be null, which is what we want to return.
            // If it has more than 1 data element, Data should be populated, which is what we want to return.
            return transportBody.DataCount == 1 ? new[] { transportBody.Body.AsBytes() } : transportBody.Data;
        }

        /// <summary>
        /// Gets the Sequence body type from an AMQP <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the Sequence body of the AMQP message.</returns>
        public static IEnumerable<IList> GetAmqpSequenceBody(this ServiceBusReceivedMessage message) =>
            message.SentMessage.GetAmqpSequenceBody();

        /// <summary>
        /// Gets the Value body type from an AMQP <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the Value body of the AMQP message.</returns>
        public static object GetAmqpValueBody(this ServiceBusReceivedMessage message) =>
            message.SentMessage.GetAmqpValueBody();
    }
}
