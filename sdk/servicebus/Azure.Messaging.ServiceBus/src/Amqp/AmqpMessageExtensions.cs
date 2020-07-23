// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal static class AmqpMessageExtensions
    {
        private static AmqpMessage ToAmqpDataMessage(this ServiceBusMessage message)
        {
            IEnumerable<Data> body = message.GetAmqpDataBody().Select(d =>
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
                AmqpBodyType.Value => message.ToAmqpValueMessage(),
                AmqpBodyType.Sequence => message.ToAmqpSequenceMessage(),
                // Data
                _ => message.ToAmqpDataMessage()
            };

        public static AmqpBodyType GetBodyType(this AmqpMessage message)
        {
            if ((message.BodyType & SectionFlag.AmqpValue) != 0 && message.ValueBody.Value != null)
            {
                return AmqpBodyType.Value;
            }

            if ((message.BodyType & SectionFlag.AmqpSequence) != 0 && message.SequenceBody != null)
            {
                return AmqpBodyType.Sequence;
            }

            return AmqpBodyType.Data;
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

        // TODO: [WIP] This gets the data bytes via the BodyStream, and this method is current unused.
        // This ignores the already parsed DataBody information, which is potentially faster and uses less memory.
        // However, I'm not confident that doing it this way won't cause unknown issues.
        // This is a drop-in replacement for GetDataViaDataBody.
        private static IEnumerable<byte[]> GetDataViaBodyStream(AmqpMessage message)
        {
            using var streamData = message.BodyStream;
            var data = new byte[streamData.Length];
            streamData.Read(data, 0, (int)streamData.Length);
            return new[] { data };
        }

        private static IEnumerable<byte[]> GetDataViaDataBody(AmqpMessage message) =>
            (message.DataBody ?? Enumerable.Empty<Data>()).Select(db => db.GetByteArray()).Where(ba => ba != null);

        private static ServiceBusReceivedMessage ToServiceBusDataMessage(this AmqpMessage message)
        {
            IEnumerable<byte[]> data = GetDataViaDataBody(message);
            return new ServiceBusReceivedMessage { SentMessage = ServiceBusSenderExtensions.CreateAmqpDataMessage(data) };
        }

        private static ServiceBusReceivedMessage ToServiceBusSequenceMessage(this AmqpMessage message)
        {
            IEnumerable<IList> sequence = message.SequenceBody.Select(s => s.List);
            return new ServiceBusReceivedMessage { SentMessage = ServiceBusSenderExtensions.CreateAmqpSequenceMessage(sequence) };
        }

        private static ServiceBusReceivedMessage ToServiceBusValueMessage(this AmqpMessage message)
        {
            object value = AmqpMessageConverter.TryGetNetObjectFromAmqpObject(message.ValueBody.Value, MappingType.MessageBody, out var dotNetObject)
                ? dotNetObject
                : message.ValueBody.Value;
            return new ServiceBusReceivedMessage { SentMessage = ServiceBusSenderExtensions.CreateAmqpValueMessage(value) };
        }

        public static ServiceBusReceivedMessage ToServiceBusReceivedMessage(this AmqpMessage message) =>
            message.GetBodyType() switch
            {
                AmqpBodyType.Value => message.ToServiceBusValueMessage(),
                AmqpBodyType.Sequence => message.ToServiceBusSequenceMessage(),
                // Data
                _ => message.ToServiceBusDataMessage()
            };
    }
}
