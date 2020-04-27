// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using Azure.Amqp;
    using Azure.Amqp.Encoding;
    using Azure.Amqp.Framing;

    internal sealed class AmqpRequestMessage
    {
        readonly AmqpMessage requestMessage;

        AmqpRequestMessage(string operation, TimeSpan timeout, string trackingId)
        {
            Map = new AmqpMap();
            requestMessage = AmqpMessage.Create(new AmqpValue { Value = Map });
            requestMessage.ApplicationProperties.Map[ManagementConstants.Request.Operation] = operation;
            requestMessage.ApplicationProperties.Map[ManagementConstants.Properties.ServerTimeout] = (uint)timeout.TotalMilliseconds;
            requestMessage.ApplicationProperties.Map[ManagementConstants.Properties.TrackingId] = trackingId ?? Guid.NewGuid().ToString();
        }

        public AmqpMessage AmqpMessage => requestMessage;

        public AmqpMap Map { get; }

        public static AmqpRequestMessage CreateRequest(string operation, TimeSpan timeout, string trackingId)
        {
            return new AmqpRequestMessage(operation, timeout, trackingId);
        }
    }
}