// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Addons
{
    /// <summary>
    /// These extensions allow additional functionality for the <see cref="ServiceBusClient"/>.
    /// </summary>
    public static class ServiceBusClientExtensions
    {
        /// <summary>
        /// Creates a <see cref="ServiceBusMessage"/> with the AMQP Data body type.
        /// </summary>
        /// <param name="data">The data to </param>
        /// <returns></returns>
        public static ServiceBusMessage CreateAmqpDataMessage(ReadOnlyMemory<byte> data) =>
            new ServiceBusMessage{ AmqpBodyTypeHint = ServiceBusMessage.AmqpBodyType.Data, AmqpData = data };

        /// <summary>
        /// Creates a <see cref="ServiceBusMessage"/> with the AMQP Sequence body type.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static ServiceBusMessage CreateAmqpSequenceMessage(IEnumerable<IList> sequence) =>
            new ServiceBusMessage { AmqpBodyTypeHint = ServiceBusMessage.AmqpBodyType.Sequence, AmqpSequence = sequence };

        /// <summary>
        /// Creates a <see cref="ServiceBusMessage"/> with the AMQP Value body type.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ServiceBusMessage CreateAmqpValueMessage(object value) =>
            new ServiceBusMessage { AmqpBodyTypeHint = ServiceBusMessage.AmqpBodyType.Value, AmqpValue = value };
    }
}
