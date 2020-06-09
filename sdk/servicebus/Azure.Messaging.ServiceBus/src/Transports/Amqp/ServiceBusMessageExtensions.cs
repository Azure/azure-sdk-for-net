// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Addons
{
    /// <summary>
    /// Extension methods for <see cref="ServiceBusMessage"/>.
    /// </summary>
    public static class ServiceBusMessageExtensions
    {
        /// <summary>
        /// Gets the Data body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns></returns>
        public static ReadOnlyMemory<byte> GetAmqpDataBody(this ServiceBusMessage message) =>
            message.AmqpData;

        /// <summary>
        /// Gets the Sequence body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns></returns>
        public static IEnumerable<IList> GetAmqpSequenceBody(this ServiceBusMessage message) =>
            message.AmqpSequence;

        /// <summary>
        /// Gets the Value body type from an AMQP <see cref="ServiceBusMessage"/>.
        /// </summary>
        /// <param name="message">The message to use.</param>
        /// <returns></returns>
        public static object GetAmqpValueBody(this ServiceBusMessage message) =>
            message.AmqpValue;
    }
}
