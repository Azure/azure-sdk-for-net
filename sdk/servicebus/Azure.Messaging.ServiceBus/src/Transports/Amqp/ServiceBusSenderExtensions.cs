// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Messaging.ServiceBus.Transports.Amqp
{
    /// <summary>
    /// These extensions allow additional functionality for the <see cref="ServiceBusClient"/>.
    /// </summary>
    public static class ServiceBusSenderExtensions
    {
        internal static ServiceBusMessage CreateAmqpDataMessage(IEnumerable<ReadOnlyMemory<byte>> data) =>
            new ServiceBusMessage(new AmqpTransportBody { BodyType = AmqpBodyType.Data, Data = data });

        /// <summary>
        /// Creates a <see cref="ServiceBusMessage"/> with the AMQP Data body type.
        /// </summary>
        /// <param name="sender">The sender for the message. This is unused to create the message.</param>
        /// <param name="data">The message body to provide to the AQMP Data body.</param>
        /// <returns>A new <see cref="ServiceBusMessage"/>.</returns>
        public static ServiceBusMessage CreateAmqpDataMessage(this ServiceBusSender sender, IEnumerable<ReadOnlyMemory<byte>> data) =>
            CreateAmqpDataMessage(data);

        internal static ServiceBusMessage CreateAmqpSequenceMessage(IEnumerable<IList> sequence) =>
            new ServiceBusMessage(new AmqpTransportBody { BodyType = AmqpBodyType.Sequence, Sequence = sequence });

        /// <summary>
        /// Creates a <see cref="ServiceBusMessage"/> with the AMQP Sequence body type.
        /// </summary>
        /// <param name="sender">The sender for the message. This is unused to create the message.</param>
        /// <param name="sequence">The message body to provide to the AQMP Sequence body.</param>
        /// <returns>A new <see cref="ServiceBusMessage"/>.</returns>
        public static ServiceBusMessage CreateAmqpSequenceMessage(this ServiceBusSender sender, IEnumerable<IList> sequence) =>
            CreateAmqpSequenceMessage(sequence);

        internal static ServiceBusMessage CreateAmqpValueMessage(object value) =>
            new ServiceBusMessage(new AmqpTransportBody { BodyType = AmqpBodyType.Value, Value = value });

        /// <summary>
        /// Creates a <see cref="ServiceBusMessage"/> with the AMQP Value body type.
        /// </summary>
        /// <param name="sender">The sender for the message. This is unused to create the message.</param>
        /// <param name="value">The message body to provide to the AQMP Value body.</param>
        /// <returns>A new <see cref="ServiceBusMessage"/>.</returns>
        public static ServiceBusMessage CreateAmqpValueMessage(this ServiceBusSender sender, object value) =>
            CreateAmqpValueMessage(value);
    }
}
