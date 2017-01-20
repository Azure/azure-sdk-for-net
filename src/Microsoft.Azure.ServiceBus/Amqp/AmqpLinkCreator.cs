// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;

    public abstract class AmqpLinkCreator
    {
        readonly string entityPath;
        readonly ServiceBusConnection serviceBusConnection;
        readonly string[] requiredClaims;
        readonly ICbsTokenProvider cbsTokenProvider;
        readonly AmqpLinkSettings amqpLinkSettings;

        protected AmqpLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, string[] requiredClaims, ICbsTokenProvider cbsTokenProvider, AmqpLinkSettings amqpLinkSettings)
        {
            this.entityPath = entityPath;
            this.serviceBusConnection = serviceBusConnection;
            this.requiredClaims = requiredClaims;
            this.cbsTokenProvider = cbsTokenProvider;
            this.amqpLinkSettings = amqpLinkSettings;
        }

        public async Task<AmqpObject> CreateAndOpenAmqpLinkAsync()
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(this.serviceBusConnection.OperationTimeout);

            MessagingEventSource.Log.AmqpGetOrCreateConnectionStart();
            AmqpConnection connection = await this.serviceBusConnection.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            MessagingEventSource.Log.AmqpGetOrCreateConnectionStop();

            // Authenticate over CBS
            AmqpCbsLink cbsLink = connection.Extensions.Find<AmqpCbsLink>();
            Uri address = new Uri(this.serviceBusConnection.Endpoint, this.entityPath);
            string audience = address.AbsoluteUri;
            string resource = address.AbsoluteUri;

            MessagingEventSource.Log.AmqpSendAuthenticanTokenStart(address, audience, resource, this.requiredClaims);
            await cbsLink.SendTokenAsync(this.cbsTokenProvider, address, audience, resource, this.requiredClaims, timeoutHelper.RemainingTime()).ConfigureAwait(false);
            MessagingEventSource.Log.AmqpSendAuthenticanTokenStop();

            AmqpSession session = null;
            try
            {
                // Create our Session
                AmqpSessionSettings sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);
                await session.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                // Create our Link
                AmqpObject link = this.OnCreateAmqpLink(connection, this.amqpLinkSettings, session);
                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                return link;
            }
            catch (Exception)
            {
                session?.Abort();
                throw;
            }
        }

        protected abstract AmqpObject OnCreateAmqpLink(AmqpConnection connection, AmqpLinkSettings linkSettings, AmqpSession amqpSession);
    }
}