// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Messaging.ServiceBus.Transports.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal static class AmqpMessageExtensions
    {
        private static AmqpMessage ToAmqpDataMessage(this ServiceBusMessage message, bool viaBody)
        {
            IEnumerable<ReadOnlyMemory<byte>> bodyBytes = viaBody ? new ReadOnlyMemory<byte>[]{ message.Body } : message.GetAmqpDataBody();
            IEnumerable<Data> body = bodyBytes.Select(d =>
                new Data { Value = new ArraySegment<byte>(d.IsEmpty ? Array.Empty<byte>() : d.ToArray()) });
            return AmqpMessage.Create(body);
        }

        private static AmqpMessage ToAmqpSequenceMessage(this ServiceBusMessage message) =>
            AmqpMessage.Create(message.GetAmqpSequenceBody().Select(s => new AmqpSequence(s)));

        private static AmqpMessage ToAmqpValueMessage(this ServiceBusMessage message) =>
            AmqpMessage.Create(new AmqpValue { Value = message.GetAmqpValueBody() });

        public static AmqpMessage ToAmqpMessage(this ServiceBusMessage message) =>
            message.GetAmqpBodyType() switch
            {
                AmqpBodyType.Data => message.ToAmqpDataMessage(viaBody: false),
                AmqpBodyType.Sequence => message.ToAmqpSequenceMessage(),
                AmqpBodyType.Value => message.ToAmqpValueMessage(),
                // Unspecified
                _ => message.ToAmqpDataMessage(viaBody: true)
            };

        public static AmqpBodyType GetBodyType(this AmqpMessage message)
        {
            if ((message.BodyType & SectionFlag.Data) != 0 && message.DataBody != null)
            {
                return AmqpBodyType.Data;
            }

            if ((message.BodyType & SectionFlag.AmqpSequence) != 0 && message.SequenceBody != null)
            {
                return AmqpBodyType.Sequence;
            }

            if ((message.BodyType & SectionFlag.AmqpValue) != 0 && message.ValueBody.Value != null)
            {
                return AmqpBodyType.Value;
            }

            return AmqpBodyType.Unspecified;
        }

        private static byte[] GetByteArray(this Data data)
        {
            switch (data.Value)
            {
                case byte[] byteArray:
                    return byteArray;
                case ArraySegment<byte> arraySegment when arraySegment.Count == arraySegment.Array?.Length:
                    return arraySegment.Array;
                case ArraySegment<byte> arraySegment:
                {
                    var byteArray = new byte[arraySegment.Count];
                    Array.ConstrainedCopy(
                        sourceArray: arraySegment.Array,
                        sourceIndex: arraySegment.Offset,
                        destinationArray: byteArray,
                        destinationIndex: 0,
                        length: arraySegment.Count);
                    return byteArray;
                }
                default:
                    return null;
            }
        }

        // Converts the Data elements into ReadOnlyMemory<byte>, removing the Data elements that do not contain byte arrays.
        // Also returns via the out parameter the flattened collection of bytes.
        // A majority of the time, dataBody will only contain 1 element.
        // The method is optimized for this situation to return nothing and only give back the pre-existing array via the flattened parameter.
        private static IEnumerable<ReadOnlyMemory<byte>> ConvertAndFlatten(this IEnumerable<Data> dataBody, out byte[] flattened)
        {
            flattened = null;
            List<byte> flattenedList = null;
            List<ReadOnlyMemory<byte>> dataList = null;
            var dataCount = 0;
            foreach (byte[] byteArray in dataBody.Select(db => db.GetByteArray()).Where(ba => ba != null))
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

        private static ServiceBusReceivedMessage ToServiceBusDataMessage(this AmqpMessage message)
        {
            IEnumerable<ReadOnlyMemory<byte>> dataBody = message.DataBody.ConvertAndFlatten(out byte[] flattened);
            var transportBody = new AmqpTransportBody
            {
                Body = new BinaryData(flattened ?? ReadOnlyMemory<byte>.Empty),
                Data = dataBody,
                BodyType = dataBody != null ? AmqpBodyType.Data : AmqpBodyType.Unspecified
            };

            return new ServiceBusReceivedMessage { SentMessage = new ServiceBusMessage(transportBody) };
        }

        private static ServiceBusReceivedMessage ToServiceBusSequenceMessage(this AmqpMessage message) =>
            new ServiceBusReceivedMessage { SentMessage = ServiceBusSenderExtensions.CreateAmqpSequenceMessage(message.SequenceBody.Select(s => s.List)) };

        private static ServiceBusReceivedMessage ToServiceBusValueMessage(this AmqpMessage message)
        {
            object value =
                AmqpMessageConverter.TryGetNetObjectFromAmqpObject(message.ValueBody.Value, MappingType.MessageBody, out var dotNetObject)
                ? dotNetObject
                : message.ValueBody.Value;
            return new ServiceBusReceivedMessage { SentMessage = ServiceBusSenderExtensions.CreateAmqpValueMessage(value) };
        }

        public static ServiceBusReceivedMessage ToServiceBusReceivedMessage(this AmqpMessage message) =>
            message.GetBodyType() switch
            {
                AmqpBodyType.Data => message.ToServiceBusDataMessage(),
                AmqpBodyType.Sequence => message.ToServiceBusSequenceMessage(),
                AmqpBodyType.Value => message.ToServiceBusValueMessage(),
                // Unspecified
                _ => new ServiceBusReceivedMessage()
            };
    }
}
