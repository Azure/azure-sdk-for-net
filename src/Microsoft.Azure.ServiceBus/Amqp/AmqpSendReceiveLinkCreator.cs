// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using Microsoft.Azure.Amqp;

    public class AmqpSendReceiveLinkCreator : AmqpLinkCreator
    {
        public AmqpSendReceiveLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, string[] requiredClaims, ICbsTokenProvider cbsTokenProvider, AmqpLinkSettings linkSettings)
            : base(entityPath, serviceBusConnection, requiredClaims, cbsTokenProvider, linkSettings)
        {
        }

        protected override AmqpObject OnCreateAmqpLink(AmqpConnection connection, AmqpLinkSettings linkSettings, AmqpSession amqpSession)
        {
            AmqpObject link = (linkSettings.IsReceiver()) ? (AmqpObject)new ReceivingAmqpLink(linkSettings) : (AmqpObject)new SendingAmqpLink(linkSettings);
            linkSettings.LinkName = $"{connection.Settings.ContainerId};{connection.Identifier}:{amqpSession.Identifier}:{link.Identifier}";
            ((AmqpLink)link).AttachTo(amqpSession);
            return link;
        }
    }
}