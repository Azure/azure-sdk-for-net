// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.ServiceBus.Amqp;
using Microsoft.Azure.Amqp;
using AmqpLib = Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Primitives
{
    /// <summary>
    /// Extensions for converting to and from AMQP.
    /// </summary>
    public static class ServiceBusAmqpExtensions
    {
        /// <summary>
        /// Converts the <see cref="ServiceBusReceivedMessage"/> to its serialized AMQP form.
        /// </summary>
        /// <returns></returns>
        public static BinaryData ToAmqpBytes(this ServiceBusReceivedMessage message)
        {
            var stream = AmqpMessageConverter.Default.AmqpAnnotatedMessageToAmqpMessage(message.GetRawAmqpMessage()).ToStream();
            return BinaryData.FromStream(stream);
        }

        /// <summary>
        /// Constructs a <see cref="ServiceBusReceivedMessage"/> from its serialized AMQP form.
        /// </summary>
        /// <param name="messageBytes">The AMQP message bytes.</param>
        /// <param name="lockTokenBytes">The lock token bytes.</param>
        /// <returns></returns>
        public static ServiceBusReceivedMessage FromAmqpBytes(BinaryData messageBytes, BinaryData lockTokenBytes)
        {
            var bufferStream = BufferListStream.Create(messageBytes.ToStream(), 4096);
            var amqpMessage = AmqpLib.AmqpMessage.CreateInputMessage(bufferStream);

            var message = AmqpMessageConverter.Default.AmqpMessageToSBReceivedMessage(amqpMessage);
            message.LockTokenGuid = GuidUtilities.ParseGuidBytes(lockTokenBytes);
            return message;
        }
    }
}