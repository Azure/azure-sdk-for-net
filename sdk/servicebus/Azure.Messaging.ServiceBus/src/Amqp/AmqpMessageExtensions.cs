// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Core.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal static class AmqpMessageExtensions
    {
        public static AmqpMessage ToAmqpMessage(this ServiceBusMessage message)
        {
            BinaryData body = ((AmqpDataBody)message.AmqpMessage.Body).Data.ConvertAndFlattenData();
            return AmqpMessage.Create(
                new Data
                {
                    Value = new ArraySegment<byte>(body.ToBytes().IsEmpty ? Array.Empty<byte>() : body.ToBytes().ToArray())
                });
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

        public static IEnumerable<BinaryData> GetDataViaDataBody(this AmqpMessage message)
        {
            foreach (Data data in (message.DataBody ?? Enumerable.Empty<Data>()))
            {
                byte[] bytes = data.GetByteArray();
                if (bytes != null)
                {
                    yield return BinaryData.FromBytes(bytes);
                }
            }
        }

        // Returns via the out parameter the flattened collection of bytes.
        // A majority of the time, data will only contain 1 element.
        // The method is optimized for this situation to return the pre-existing array.
        public static BinaryData ConvertAndFlattenData(this IEnumerable<BinaryData> dataList)
        {
            ReadOnlyMemory<byte> flattened = null;
            List<byte> flattenedList = null;
            var dataCount = 0;
            foreach (BinaryData data in dataList)
            {
                // Only the first array is needed if it is the only valid array.
                // This should be the case 99% of the time.
                if (dataCount == 0)
                {
                    flattened = data;
                }
                else
                {
                    // We defer creating this list since this case will rarely happen.
                    flattenedList ??= new List<byte>(flattened.ToArray()!);
                    flattenedList.AddRange(data.ToBytes().ToArray());
                }

                dataCount++;
            }

            if (dataCount > 1)
            {
                flattened = flattenedList!.ToArray();
            }

            return BinaryData.FromBytes(flattened);
        }

        public static string GetPartitionKey(this AmqpAnnotatedMessage message)
        {
            if (message.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.PartitionKeyName,
                    out object val))
            {
                return (string)val;
            }
            return default;
        }

        public static string GetViaPartitionKey(this AmqpAnnotatedMessage message)
        {
            if (message.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.ViaPartitionKeyName,
                    out object val))
            {
                return (string)val;
            }
            return default;
        }

        public static TimeSpan GetTimeToLive(this AmqpAnnotatedMessage message)
        {
            TimeSpan? ttl = message.Header.TimeToLive;
            if (ttl == default)
            {
                return TimeSpan.MaxValue;
            }
            return ttl.Value;
        }

        public static DateTimeOffset GetScheduledEnqueueTime(this AmqpAnnotatedMessage message)
        {
            if (message.MessageAnnotations.TryGetValue(
                    AmqpMessageConstants.ScheduledEnqueueTimeUtcName,
                    out object val))
            {
                return (DateTime)val;
            }
            return default;
        }
    }
}
