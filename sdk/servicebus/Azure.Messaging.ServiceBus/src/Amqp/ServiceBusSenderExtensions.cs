// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    /// These extensions allow additional functionality for the <see cref="ServiceBusClient"/>.
    /// </summary>
    public static class ServiceBusSenderExtensions
    {
        // Returns via the out parameter the flattened collection of bytes.
        // A majority of the time, data will only contain 1 element.
        // The method is optimized for this situation to return nothing and only give back the pre-existing array via the flattened parameter.
        private static IEnumerable<ReadOnlyMemory<byte>> ConvertAndFlattenData(IEnumerable<byte[]> data, out byte[] flattened)
        {
            flattened = null;
            List<byte> flattenedList = null;
            List<ReadOnlyMemory<byte>> dataList = null;
            var dataCount = 0;
            foreach (byte[] byteArray in data)
            {
                // Only the first array is needed if it is the only valid array.
                // This should be the case 99% of the time.
                if (dataCount == 0)
                {
                    flattened = byteArray;
                }
                else
                {
                    // We defer creating these lists since this case will rarely happen.
                    flattenedList ??= new List<byte>(flattened!);
                    flattenedList.AddRange(byteArray);
                    dataList ??= new List<ReadOnlyMemory<byte>> { flattened! };
                    dataList.Add(byteArray);
                }

                dataCount++;
            }

            if (dataCount > 1)
            {
                flattened = flattenedList!.ToArray();
            }

            return dataList;
        }

        internal static ServiceBusMessage CreateAmqpDataMessage(IEnumerable<byte[]> data)
        {
            IEnumerable<ReadOnlyMemory<byte>> dataBody = ConvertAndFlattenData(data, out byte[] flattened);
            var transportBody = new AmqpTransportBody
            {
                Body = BinaryData.FromMemory(flattened ?? ReadOnlyMemory<byte>.Empty),
                Data = dataBody,
                BodyType = AmqpBodyType.Data
            };

            return new ServiceBusMessage(transportBody);
        }

        /// <summary>
        /// Creates a <see cref="ServiceBusMessage"/> with the AMQP Data body type.
        /// </summary>
        /// <param name="sender">The sender for the message. This is unused to create the message.</param>
        /// <param name="data">The message body to provide to the AQMP Data body.</param>
        /// <returns>A new <see cref="ServiceBusMessage"/>.</returns>
        public static ServiceBusMessage CreateAmqpDataMessage(this ServiceBusSender sender, IEnumerable<ReadOnlyMemory<byte>> data) =>
            CreateAmqpDataMessage((data ?? Enumerable.Empty<ReadOnlyMemory<byte>>()).Select(rom => rom.ToArray()));

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
