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
        public static AmqpBodyType GetAmqpBodyType(this ServiceBusReceivedMessage message) =>
            message.SentMessage.GetAmqpBodyType();

        /// <summary>
        /// Gets the Data body type from an AMQP <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>Returns the Data body of the AMQP message.</returns>
        public static IEnumerable<ReadOnlyMemory<byte>> GetAmqpDataBody(this ServiceBusReceivedMessage message) =>
            message.SentMessage.GetAmqpDataBody();

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
