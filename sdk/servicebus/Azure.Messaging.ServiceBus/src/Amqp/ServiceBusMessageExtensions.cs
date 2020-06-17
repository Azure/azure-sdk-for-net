// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    /// Extension methods for <see cref="ServiceBusMessage"/>.
    /// </summary>
    public static class ServiceBusMessageExtensions
    {
        /// <summary>
        /// Gets the body type from an AMQP body.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the body type of the AMQP message.</returns>
        public static AmqpBodyType GetAmqpBodyType(this ServiceBusMessage message) =>
            ((AmqpTransportBody)message.TransportBody).BodyType;

        /// <summary>
        /// Gets the Data body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the Data body of the AMQP message.</returns>
        public static IEnumerable<ReadOnlyMemory<byte>> GetAmqpDataBody(this ServiceBusMessage message) =>
            ((AmqpTransportBody)message.TransportBody).Data;

        /// <summary>
        /// Gets the Sequence body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the Sequence body of the AMQP message.</returns>
        public static IEnumerable<IList> GetAmqpSequenceBody(this ServiceBusMessage message) =>
            ((AmqpTransportBody)message.TransportBody).Sequence;

        /// <summary>
        /// Gets the Value body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the Value body of the AMQP message.</returns>
        public static object GetAmqpValueBody(this ServiceBusMessage message) =>
            ((AmqpTransportBody)message.TransportBody).Value;
    }
}
