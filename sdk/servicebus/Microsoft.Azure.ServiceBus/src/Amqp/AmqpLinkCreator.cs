// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;
    using Primitives;

    internal abstract class AmqpLinkCreator
    {
	    private readonly string entityPath;
	    private readonly ServiceBusConnection serviceBusConnection;
	    private readonly Uri endpointAddress;
	    private readonly string[] audience;
	    private readonly string[] requiredClaims;
	    private readonly ICbsTokenProvider cbsTokenProvider;
	    private readonly AmqpLinkSettings amqpLinkSettings;

        protected AmqpLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, Uri endpointAddress, string[] audience, string[] requiredClaims, ICbsTokenProvider cbsTokenProvider, AmqpLinkSettings amqpLinkSettings, string clientId)
        {
            this.entityPath = entityPath;
            this.serviceBusConnection = serviceBusConnection;
            this.endpointAddress = endpointAddress;
            this.audience = audience;
            this.requiredClaims = requiredClaims;
            this.cbsTokenProvider = cbsTokenProvider;
            this.amqpLinkSettings = amqpLinkSettings;
            ClientId = clientId;
        }

        protected string ClientId { get; }

        public async Task<Tuple<AmqpObject, DateTime>> CreateAndOpenAmqpLinkAsync()
        {
            var timeoutHelper = new TimeoutHelper(serviceBusConnection.OperationTimeout, true);

            MessagingEventSource.Log.AmqpGetOrCreateConnectionStart();
            var amqpConnection = await serviceBusConnection.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            MessagingEventSource.Log.AmqpGetOrCreateConnectionStop(entityPath, amqpConnection.ToString(), amqpConnection.State.ToString());

            // Authenticate over CBS
            var cbsLink = amqpConnection.Extensions.Find<AmqpCbsLink>();
            DateTime cbsTokenExpiresAtUtc = DateTime.MaxValue;

            foreach (var resource in audience)
            {
                MessagingEventSource.Log.AmqpSendAuthenticationTokenStart(endpointAddress, resource, resource, requiredClaims);
                cbsTokenExpiresAtUtc = TimeoutHelper.Min(
                    cbsTokenExpiresAtUtc, 
                    await cbsLink.SendTokenAsync(cbsTokenProvider, endpointAddress, resource, resource, requiredClaims, timeoutHelper.RemainingTime()).ConfigureAwait(false));
                MessagingEventSource.Log.AmqpSendAuthenticationTokenStop(); 
            }

            AmqpSession session = null;
            try
            {
                // Create Session
                var amqpSessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = amqpConnection.CreateSession(amqpSessionSettings);
                await session.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpSessionCreationException(entityPath, amqpConnection, exception);
                session?.Abort();
                throw AmqpExceptionHelper.GetClientException(exception, null, session.GetInnerException(), amqpConnection.IsClosing());
            }

            AmqpObject link = null;
            try
            {
                // Create Link
                link = OnCreateAmqpLink(amqpConnection, amqpLinkSettings, session);
                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                return new Tuple<AmqpObject, DateTime>(link, cbsTokenExpiresAtUtc);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpLinkCreationException(
                    entityPath,
                    session,
                    amqpConnection,
                    exception);

                session.SafeClose(exception);
                throw AmqpExceptionHelper.GetClientException(exception, null, link?.GetInnerException(), amqpConnection.IsClosing());
            }
        }

        protected abstract AmqpObject OnCreateAmqpLink(AmqpConnection connection, AmqpLinkSettings linkSettings, AmqpSession amqpSession);
    }
}