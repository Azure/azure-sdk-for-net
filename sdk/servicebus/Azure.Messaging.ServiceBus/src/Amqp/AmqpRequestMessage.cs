// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal sealed class AmqpRequestMessage
    {
        public AmqpRequestMessage(string operation, TimeSpan timeout, string trackingId)
        {
            Map = new AmqpMap();
            AmqpMessage = AmqpMessage.Create(new AmqpValue { Value = Map });
            AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.Operation] = operation;
            AmqpMessage.ApplicationProperties.Map[ManagementConstants.Properties.ServerTimeout] = (uint)timeout.TotalMilliseconds;
            AmqpMessage.ApplicationProperties.Map[ManagementConstants.Properties.TrackingId] = trackingId ?? Guid.NewGuid().ToString();
        }

        public AmqpMessage AmqpMessage { get; }

        public AmqpMap Map { get; }

        public static AmqpRequestMessage CreateRequest(string operation, TimeSpan timeout, string trackingId)
        {
            return new AmqpRequestMessage(operation, timeout, trackingId);
        }
    }
}
