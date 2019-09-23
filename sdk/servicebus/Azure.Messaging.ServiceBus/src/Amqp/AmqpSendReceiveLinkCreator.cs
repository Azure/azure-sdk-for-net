// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Amqp
{
    using System;
    using Microsoft.Azure.Amqp;
    using Azure.Messaging.ServiceBus.Primitives;

    internal class AmqpSendReceiveLinkCreator : AmqpLinkCreator
    {
        public AmqpSendReceiveLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, Uri endpointAddress, string[] audience, string[] requiredClaims, AmqpLinkSettings linkSettings, string clientId)
            : base(entityPath, serviceBusConnection, endpointAddress, audience, requiredClaims, linkSettings, clientId)
        {
        }

        protected override AmqpObject OnCreateAmqpLink(AmqpConnection connection, AmqpLinkSettings linkSettings, AmqpSession amqpSession)
        {
            AmqpLink amqpLink;
            if (linkSettings.IsReceiver())
            {
                amqpLink = new ReceivingAmqpLink(linkSettings);
            }
            else
            {
                amqpLink = new SendingAmqpLink(linkSettings);
            }
            linkSettings.LinkName = $"{connection.Settings.ContainerId};{connection.Identifier}:{amqpSession.Identifier}:{amqpLink.Identifier}:{linkSettings.Source.ToString()}:{this.ClientId}";
            amqpLink.AttachTo(amqpSession);
            return amqpLink;
        }
    }
}