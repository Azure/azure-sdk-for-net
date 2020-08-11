// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.ServiceBus.Primitives;

    internal class AmqpSendReceiveLinkCreator : AmqpLinkCreator
    {
        public AmqpSendReceiveLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, Uri endpointAddress, string[] audience, string[] requiredClaims, ICbsTokenProvider cbsTokenProvider, AmqpLinkSettings linkSettings, string clientId)
            : base(entityPath, serviceBusConnection, endpointAddress, audience, requiredClaims, cbsTokenProvider, linkSettings, clientId)
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