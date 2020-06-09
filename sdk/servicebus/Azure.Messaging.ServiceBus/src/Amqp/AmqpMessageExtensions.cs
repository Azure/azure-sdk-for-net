// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.ServiceBus.Transports.Amqp;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal static class AmqpMessageExtensions
    {
        private static AmqpMessage CreateAmqpDataMessage(ServiceBusMessage message)
        {
            ReadOnlyMemory<byte> bodyBytes = message.GetAmqpDataBody();
            var body = new ArraySegment<byte>(bodyBytes.IsEmpty ? Array.Empty<byte>() : bodyBytes.ToArray());
            return AmqpMessage.Create(new Data { Value = body });
        }

        private static AmqpMessage CreateAmqpSequenceMessage(ServiceBusMessage message) =>
            AmqpMessage.Create(message.GetAmqpSequenceBody().Select(s => new AmqpSequence(s)));

        private static AmqpMessage CreateAmqpValueMessage(ServiceBusMessage message) =>
            AmqpMessage.Create(new AmqpValue { Value = message.GetAmqpValueBody() });

        public static AmqpMessage CreateAmqpMessage(this ServiceBusMessage message) =>
            message.GetAmqpBodyType() switch
            {
                AmqpBodyType.Sequence => CreateAmqpSequenceMessage(message),
                AmqpBodyType.Value => CreateAmqpValueMessage(message),
                // Both Data and Unspecified
                _ => CreateAmqpDataMessage(message)
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

        private static ServiceBusReceivedMessage CreateServiceBusDataMessage(AmqpMessage message)
        {
            var dataSegments = new List<byte>();
            foreach (var data in message.DataBody)
            {
                if (data.Value is byte[] byteArrayValue)
                {
                    dataSegments.AddRange(byteArrayValue);
                }
                else if (data.Value is ArraySegment<byte> arraySegmentValue)
                {
                    byte[] byteArray;
                    if (arraySegmentValue.Count == arraySegmentValue.Array?.Length)
                    {
                        byteArray = arraySegmentValue.Array;
                    }
                    else
                    {
                        byteArray = new byte[arraySegmentValue.Count];
                        Array.ConstrainedCopy(arraySegmentValue.Array, arraySegmentValue.Offset, byteArray, 0, arraySegmentValue.Count);
                    }
                    dataSegments.AddRange(byteArray);
                }
            }
            return new ServiceBusReceivedMessage { SentMessage = ServiceBusSenderExtensions.CreateAmqpDataMessage(dataSegments.ToArray()) };
        }

        private static ServiceBusReceivedMessage CreateServiceBusSequenceMessage(AmqpMessage message) =>
            new ServiceBusReceivedMessage { SentMessage = ServiceBusSenderExtensions.CreateAmqpSequenceMessage(message.SequenceBody.Select(s => s.List)) };

        private static ServiceBusReceivedMessage CreateServiceBusValueMessage(AmqpMessage message)
        {
            object value =
                AmqpMessageConverter.TryGetNetObjectFromAmqpObject(message.ValueBody.Value, MappingType.MessageBody, out var dotNetObject)
                ? dotNetObject
                : message.ValueBody.Value;
            return new ServiceBusReceivedMessage { SentMessage = ServiceBusSenderExtensions.CreateAmqpValueMessage(value) };
        }

        public static ServiceBusReceivedMessage CreateServiceBusReceivedMessage(this AmqpMessage message) =>
            message.GetBodyType() switch
            {
                AmqpBodyType.Data => CreateServiceBusDataMessage(message),
                AmqpBodyType.Sequence => CreateServiceBusSequenceMessage(message),
                AmqpBodyType.Value => CreateServiceBusValueMessage(message),
                // Unspecified
                _ => new ServiceBusReceivedMessage()
            };
    }
}
