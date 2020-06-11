// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Messaging.ServiceBus.Transports.Amqp
{
    /// <summary>
    /// Extension methods for <see cref="ServiceBusMessage"/>.
    /// </summary>
    public static class ServiceBusMessageExtensions
    {
        /// <summary>
        /// Checks if the message contains an AMQP body.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>True if the message contains an AMQP body. Otherwise, false.</returns>
        public static bool HasAmqpBody(this ServiceBusMessage message) => message.TransportBody is AmqpTransportBody;

        /// <summary>
        /// Gets the body type from an AMQP body.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>If the message contains an AMQP body, returns the body type. Otherwise, <see cref="AmqpBodyType.Unspecified"/>.</returns>
        public static AmqpBodyType GetAmqpBodyType(this ServiceBusMessage message) =>
            message.TransportBody is AmqpTransportBody body ? body.BodyType : AmqpBodyType.Unspecified;

        /// <summary>
        /// Gets the Data body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>If the message contains an AMQP body, returns the Data body. Otherwise, <see cref="Enumerable.Empty{T}()"/>.</returns>
        public static IEnumerable<ReadOnlyMemory<byte>> GetAmqpDataBody(this ServiceBusMessage message) =>
            message.TransportBody is AmqpTransportBody body ? body.Data : Enumerable.Empty<ReadOnlyMemory<byte>>();

        /// <summary>
        /// Gets the Sequence body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>If the message contains an AMQP body, returns the Sequence body. Otherwise, <see cref="Enumerable.Empty{T}()"/>.</returns>
        public static IEnumerable<IList> GetAmqpSequenceBody(this ServiceBusMessage message) =>
            message.TransportBody is AmqpTransportBody body ? body.Sequence : Enumerable.Empty<IList>();

        /// <summary>
        /// Gets the Value body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>If the message contains an AMQP body, returns the Value body. Otherwise, null.</returns>
        public static object GetAmqpValueBody(this ServiceBusMessage message) =>
            message.TransportBody is AmqpTransportBody body ? body.Value : null;
    }
}
