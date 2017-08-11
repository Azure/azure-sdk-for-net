// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.ServiceBus.Primitives;

    internal abstract class AmqpLinkCreator
    {
        readonly string entityPath;
        readonly ServiceBusConnection serviceBusConnection;
        readonly Uri endpointAddress;
        readonly string[] requiredClaims;
        readonly ICbsTokenProvider cbsTokenProvider;
        readonly AmqpLinkSettings amqpLinkSettings;

        protected AmqpLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, Uri endpointAddress, string[] requiredClaims, ICbsTokenProvider cbsTokenProvider, AmqpLinkSettings amqpLinkSettings, string clientId)
        {
            this.entityPath = entityPath;
            this.serviceBusConnection = serviceBusConnection;
            this.endpointAddress = endpointAddress;
            this.requiredClaims = requiredClaims;
            this.cbsTokenProvider = cbsTokenProvider;
            this.amqpLinkSettings = amqpLinkSettings;
            this.ClientId = clientId;
        }

        protected string ClientId { get; }

        public async Task<Tuple<AmqpObject, DateTime>> CreateAndOpenAmqpLinkAsync()
        {
            TimeoutHelper timeoutHelper = new TimeoutHelper(this.serviceBusConnection.OperationTimeout);

            MessagingEventSource.Log.AmqpGetOrCreateConnectionStart();
            AmqpConnection connection = await this.serviceBusConnection.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            MessagingEventSource.Log.AmqpGetOrCreateConnectionStop(this.entityPath, connection.ToString(), connection.State.ToString());

            // Authenticate over CBS
            AmqpCbsLink cbsLink = connection.Extensions.Find<AmqpCbsLink>();
            
            string resource = this.endpointAddress.AbsoluteUri;
            MessagingEventSource.Log.AmqpSendAuthenticanTokenStart(this.endpointAddress, resource, resource, this.requiredClaims);
            DateTime cbsTokenExpiresAtUtc = await cbsLink.SendTokenAsync(this.cbsTokenProvider, this.endpointAddress, resource, resource, this.requiredClaims, timeoutHelper.RemainingTime()).ConfigureAwait(false);
            MessagingEventSource.Log.AmqpSendAuthenticanTokenStop();

            AmqpSession session = null;
            try
            {
                // Create Session
                AmqpSessionSettings sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);
                await session.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpSessionCreationException(this.entityPath, connection, exception);
                session?.Abort();
                throw AmqpExceptionHelper.GetClientException(exception, null, session.GetInnerException());
            }

            AmqpObject link = null;
            try
            {
                // Create Link
                link = this.OnCreateAmqpLink(connection, this.amqpLinkSettings, session);
                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                return new Tuple<AmqpObject, DateTime>(link, cbsTokenExpiresAtUtc);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpLinkCreationException(
                    this.entityPath,
                    session,
                    connection,
                    exception);

                throw AmqpExceptionHelper.GetClientException(exception, null, link?.GetInnerException(), session.IsClosing());
            }
        }

        protected abstract AmqpObject OnCreateAmqpLink(AmqpConnection connection, AmqpLinkSettings linkSettings, AmqpSession amqpSession);
    }
}