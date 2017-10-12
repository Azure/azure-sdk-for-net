// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    internal class AmqpSendReceiveLinkCreator : AmqpLinkCreator
    {
        public AmqpSendReceiveLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, Uri endpointAddress, string[] requiredClaims, ICbsTokenProvider cbsTokenProvider, AmqpLinkSettings linkSettings, string clientId)
            : base(entityPath, serviceBusConnection, endpointAddress, requiredClaims, cbsTokenProvider, linkSettings, clientId)
        {
        }

        protected override AmqpObject OnCreateAmqpLink(AmqpConnection connection, AmqpLinkSettings linkSettings, AmqpSession amqpSession)
        {
            AmqpObject link = (linkSettings.IsReceiver()) ? (AmqpObject)new ReceivingAmqpLink(linkSettings) : (AmqpObject)new SendingAmqpLink(linkSettings);
            linkSettings.LinkName = $"{connection.Settings.ContainerId};{connection.Identifier}:{amqpSession.Identifier}:{link.Identifier}:{linkSettings.Source.ToString()}:{this.ClientId}";
            ((AmqpLink)link).AttachTo(amqpSession);
            return link;
        }
    }
}