// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal static class AmqpMessageExtensions
    {
        public static AmqpMessage ToAmqpMessage(this ServiceBusMessage message) =>
            AmqpMessage.Create(new Data { Value = new ArraySegment<byte>(message.Body.Bytes.IsEmpty ? Array.Empty<byte>() : message.Body.Bytes.ToArray()) });

        private static byte[] GetByteArray(this Data data)
        {
            switch (data.Value)
            {
                case byte[] byteArray:
                    return byteArray;
                case ArraySegment<byte> arraySegment when arraySegment.Count == arraySegment.Array?.Length:
                    return arraySegment.Array;
                case ArraySegment<byte> arraySegment:
                    var bytes = new byte[arraySegment.Count];
                    Array.ConstrainedCopy(
                        sourceArray: arraySegment.Array,
                        sourceIndex: arraySegment.Offset,
                        destinationArray: bytes,
                        destinationIndex: 0,
                        length: arraySegment.Count);
                    return bytes;
                default:
                    return null;
            }
        }

        private static IEnumerable<byte[]> GetDataViaDataBody(AmqpMessage message)
        {
            foreach (Data data in (message.DataBody ?? Enumerable.Empty<Data>()))
            {
                byte[] bytes = data.GetByteArray();
                if (bytes != null)
                {
                    yield return bytes;
                }
            }
        }

        // Returns via the out parameter the flattened collection of bytes.
        // A majority of the time, data will only contain 1 element.
        // The method is optimized for this situation to return the pre-existing array.
        private static byte[] ConvertAndFlattenData(IEnumerable<byte[]> data)
        {
            byte[] flattened = null;
            List<byte> flattenedList = null;
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
                    // We defer creating this list since this case will rarely happen.
                    flattenedList ??= new List<byte>(flattened!);
                    flattenedList.AddRange(byteArray);
                }

                dataCount++;
            }

            if (dataCount > 1)
            {
                flattened = flattenedList!.ToArray();
            }

            return flattened;
        }

        private static ServiceBusMessage CreateAmqpDataMessage(IEnumerable<byte[]> data) =>
            new ServiceBusMessage(BinaryData.FromMemory(ConvertAndFlattenData(data) ?? ReadOnlyMemory<byte>.Empty));

        public static ServiceBusReceivedMessage ToServiceBusReceivedMessage(this AmqpMessage message)
        {
            if ((message.BodyType & SectionFlag.Data) != 0 && message.DataBody != null)
            {
                return new ServiceBusReceivedMessage { SentMessage = CreateAmqpDataMessage(GetDataViaDataBody(message)) };
            }

            return new ServiceBusReceivedMessage();
        }
    }
}
