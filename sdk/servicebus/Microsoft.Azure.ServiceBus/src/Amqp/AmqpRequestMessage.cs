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
	    private readonly AmqpMessage _requestMessage;

	    private AmqpRequestMessage(string operation, TimeSpan timeout, string trackingId)
        {
            Map = new AmqpMap();
            _requestMessage = AmqpMessage.Create(new AmqpValue { Value = Map });
            _requestMessage.ApplicationProperties.Map[ManagementConstants.Request.Operation] = operation;
            _requestMessage.ApplicationProperties.Map[ManagementConstants.Properties.ServerTimeout] = (uint)timeout.TotalMilliseconds;
            _requestMessage.ApplicationProperties.Map[ManagementConstants.Properties.TrackingId] = trackingId ?? Guid.NewGuid().ToString();
        }

        public AmqpMessage AmqpMessage => _requestMessage;

        public AmqpMap Map { get; }

        public static AmqpRequestMessage CreateRequest(string operation, TimeSpan timeout, string trackingId)
        {
            return new AmqpRequestMessage(operation, timeout, trackingId);
        }
    }
}