// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Messaging.ServiceBus.Transports.Amqp
{
    /// <summary>
    /// Extension methods for <see cref="ServiceBusReceivedMessage"/>.
    /// </summary>
    public static class ServiceBusReceivedMessageExtensions
    {
        /// <summary>
        /// Gets the Data body type from an AMQP <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>If the message contains an AMQP body, returns the Data body. Otherwise, <see cref="Enumerable.Empty{T}()"/>.</returns>
        public static IEnumerable<ReadOnlyMemory<byte>> GetAmqpDataBody(this ServiceBusReceivedMessage message) =>
            message.SentMessage.GetAmqpDataBody();

        /// <summary>
        /// Gets the Sequence body type from an AMQP <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>If the message contains an AMQP body, returns the Sequence body. Otherwise, <see cref="Enumerable.Empty{T}()"/>.</returns>
        public static IEnumerable<IList> GetAmqpSequenceBody(this ServiceBusReceivedMessage message) =>
            message.SentMessage.GetAmqpSequenceBody();

        /// <summary>
        /// Gets the Value body type from an AMQP <see cref="ServiceBusReceivedMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns>If the message contains an AMQP body, returns the Value body. Otherwise, null.</returns>
        public static object GetAmqpValueBody(this ServiceBusReceivedMessage message) =>
            message.SentMessage.GetAmqpValueBody();
    }
}
