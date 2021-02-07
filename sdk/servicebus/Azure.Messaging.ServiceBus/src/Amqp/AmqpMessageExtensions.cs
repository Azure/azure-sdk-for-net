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
            if (message.AmqpMessage.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> dataBody))
            {
                return AmqpMessage.Create(dataBody.AsAmqpData());
            }
            throw new NotSupportedException($"{message.AmqpMessage.Body.GetType()} is not a supported message body type.");
        }

        private static IEnumerable<Data> AsAmqpData(this IEnumerable<ReadOnlyMemory<byte>> binaryData)
        {
            foreach (ReadOnlyMemory<byte> data in binaryData)
            {
                yield return new Data
                {
                    Value = new ArraySegment<byte>(data.IsEmpty ? Array.Empty<byte>() : data.ToArray())
                };
            }
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

        public static IList<ReadOnlyMemory<byte>> GetDataViaDataBody(this AmqpMessage message)
        {
            IList<ReadOnlyMemory<byte>> dataList = new List<ReadOnlyMemory<byte>>();
            foreach (Data data in (message.DataBody ?? Enumerable.Empty<Data>()))
            {
                dataList.Add(BinaryData.FromBytes(data.GetByteArray()));
            }
            return dataList;
        }

        // Returns via the out parameter the flattened collection of bytes.
        // A majority of the time, data will only contain 1 element.
        // The method is optimized for this situation to return the pre-existing array.
        public static BinaryData ConvertAndFlattenData(this IEnumerable<ReadOnlyMemory<byte>> dataList)
        {
            var writer = new ArrayBufferWriter<byte>();
            Memory<byte> memory;
            foreach (ReadOnlyMemory<byte> data in dataList)
            {
                memory = writer.GetMemory(data.Length);
                data.CopyTo(memory);
                writer.Advance(data.Length);
            }
            if (writer.WrittenCount == 0)
            {
                return new BinaryData(Array.Empty<byte>());
            }
            return BinaryData.FromBytes(writer.WrittenMemory);
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

        public static BinaryData GetBody(this AmqpAnnotatedMessage message)
        {
            if (message.Body.TryGetData(out IEnumerable<ReadOnlyMemory<byte>> dataBody))
            {
                return dataBody.ConvertAndFlattenData();
            }
            throw new NotSupportedException($"{message.Body.BodyType} is not a supported message body type.");
        }
    }
}
