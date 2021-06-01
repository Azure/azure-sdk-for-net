// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Azure.Core.Amqp;
using Azure.Messaging.ServiceBus.Primitives;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;
using IList = System.Collections.IList;

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
            if (message.AmqpMessage.Body.TryGetValue(out object value))
            {
                if (AmqpMessageConverter.TryGetAmqpObjectFromNetObject(value, MappingType.MessageBody, out object amqpObject))
                {
                    return AmqpMessage.Create(new AmqpValue { Value = amqpObject });
                }
                else
                {
                    throw new NotSupportedException(Resources.InvalidAmqpMessageValueBody.FormatForUser(amqpObject?.GetType()));
                }
            }
            if (message.AmqpMessage.Body.TryGetSequence(out IEnumerable<IList<object>> sequence))
            {
                return AmqpMessage.Create(sequence.Select(s => new AmqpSequence((IList)s)).ToList());
            }

            throw new NotSupportedException($"{message.AmqpMessage.Body.GetType()} is not a supported message body type.");
        }

        private static IEnumerable<Data> AsAmqpData(this IEnumerable<ReadOnlyMemory<byte>> binaryData)
        {
            foreach (ReadOnlyMemory<byte> data in binaryData)
            {
                if (!MemoryMarshal.TryGetArray(data, out ArraySegment<byte> segment))
                {
                    segment = new ArraySegment<byte>(data.ToArray());
                }

                yield return new Data
                {
                    Value = segment
                };
            }
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
                return BinaryData.FromBytes(MessageBody.FromReadOnlyMemorySegments(dataBody));
            }
            throw new NotSupportedException($"{message.Body.BodyType} cannot be retrieved using the {nameof(ServiceBusMessage.Body)} property." +
                $"Use {nameof(ServiceBusMessage.GetRawAmqpMessage)} to access the underlying Amqp Message object.");
        }
    }
}
