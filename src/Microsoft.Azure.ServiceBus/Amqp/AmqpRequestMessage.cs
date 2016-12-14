// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using Azure.Amqp;
    using Azure.Amqp.Encoding;
    using Azure.Amqp.Framing;
    using Microsoft.Azure.Messaging.Amqp;

    public sealed class AmqpRequestMessage
    {
        readonly AmqpMessage requestMessage;

        AmqpRequestMessage(string operation, TimeSpan timeout, string trackingId)
        {
            this.Map = new AmqpMap();
            this.requestMessage = AmqpMessage.Create(new AmqpValue() { Value = this.Map });
            this.requestMessage.ApplicationProperties.Map[ManagementConstants.Request.Operation] = operation;
            this.requestMessage.ApplicationProperties.Map[ManagementConstants.Properties.ServerTimeout] = (uint)timeout.TotalMilliseconds;
            this.requestMessage.ApplicationProperties.Map[ManagementConstants.Properties.TrackingId] = trackingId ?? Guid.NewGuid().ToString();
        }

        public AmqpMessage AmqpMessage
        {
            get { return this.requestMessage; }
        }

        public AmqpMap Map { get; }

        public static AmqpRequestMessage CreateRequest(string operation, TimeSpan timeout, string trackingId)
        {
            return new AmqpRequestMessage(operation, timeout, trackingId);
        }
    }
}