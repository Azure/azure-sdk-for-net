// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Amqp
{
    using System;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Encoding;
    using Microsoft.Azure.Amqp.Framing;

    internal sealed class AmqpRequestMessage
    {
        public AmqpRequestMessage(string operation, TimeSpan timeout, string trackingId)
        {
            this.Map = new AmqpMap();
            this.AmqpMessage = AmqpMessage.Create(new AmqpValue { Value = this.Map });
            this.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.Operation] = operation;
            this.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Properties.ServerTimeout] = (uint)timeout.TotalMilliseconds;
            this.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Properties.TrackingId] = trackingId ?? Guid.NewGuid().ToString();

            //var request = AmqpMessage.Create();
            //request.ApplicationProperties = new ApplicationProperties();
            //request.ApplicationProperties.Map[AmqpManagement.ResourceNameKey] = eventHubName;
            //request.ApplicationProperties.Map[AmqpManagement.OperationKey] = AmqpManagement.ReadOperationValue;
            //request.ApplicationProperties.Map[AmqpManagement.ResourceTypeKey] = AmqpManagement.EventHubResourceTypeValue;
            //request.ApplicationProperties.Map[AmqpManagement.SecurityTokenKey] = managementAuthorizationToken;
        }

        public AmqpMessage AmqpMessage { get; }

        public AmqpMap Map { get; }

        public static AmqpRequestMessage CreateRequest(string operation, TimeSpan timeout, string trackingId)
        {
            return new AmqpRequestMessage(operation, timeout, trackingId);
        }
    }
}
