// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.Amqp;
    using Microsoft.Azure.Amqp.Framing;
    using Microsoft.Azure.ServiceBus.Primitives;
    using Newtonsoft.Json.Schema;

    internal abstract class AmqpLinkCreator
    {
        readonly string entityPath;
        readonly ServiceBusConnection serviceBusConnection;
        readonly Uri endpointAddress;
        readonly string[] audience;
        readonly string[] requiredClaims;
        readonly ICbsTokenProvider cbsTokenProvider;
        readonly AmqpLinkSettings amqpLinkSettings;

        protected AmqpLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, Uri endpointAddress, string[] audience, string[] requiredClaims, ICbsTokenProvider cbsTokenProvider, AmqpLinkSettings amqpLinkSettings, string clientId)
        {
            this.entityPath = entityPath;
            this.serviceBusConnection = serviceBusConnection;
            this.endpointAddress = endpointAddress;
            this.audience = audience;
            this.requiredClaims = requiredClaims;
            this.cbsTokenProvider = cbsTokenProvider;
            this.amqpLinkSettings = amqpLinkSettings;
            this.ClientId = clientId;
        }

        protected string ClientId { get; }

        public async Task<Tuple<AmqpObject, DateTime>> CreateAndOpenAmqpLinkAsync()
        {
            var timeoutHelper = new TimeoutHelper(this.serviceBusConnection.OperationTimeout, true);

            MessagingEventSource.Log.AmqpGetOrCreateConnectionStart();
            var amqpConnection = await this.serviceBusConnection.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            MessagingEventSource.Log.AmqpGetOrCreateConnectionStop(this.entityPath, amqpConnection.ToString(), amqpConnection.State.ToString());

            // Authenticate over CBS
            var cbsLink = amqpConnection.Extensions.Find<AmqpCbsLink>();
            DateTime cbsTokenExpiresAtUtc = DateTime.MaxValue;

            foreach (var resource in this.audience)
            {
                MessagingEventSource.Log.AmqpSendAuthenticationTokenStart(this.endpointAddress, resource, resource, this.requiredClaims);
                cbsTokenExpiresAtUtc = TimeoutHelper.Min(
                    cbsTokenExpiresAtUtc, 
                    await cbsLink.SendTokenAsync(this.cbsTokenProvider, this.endpointAddress, resource, resource, this.requiredClaims, timeoutHelper.RemainingTime()).ConfigureAwait(false));
                MessagingEventSource.Log.AmqpSendAuthenticationTokenStop(); 
            }

            AmqpSession session = null;
            try
            {
                // Create Session
                var amqpSessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                if (this.amqpLinkSettings.IsReceiver())
                {
                    // This is the maximum number of unsettled transfers across all receive links on this session.
                    // This will allow the session to accept unlimited number of transfers, even if the recevier(s)
                    // are not settling any of the deliveries.
                    amqpSessionSettings.IncomingWindow = uint.MaxValue;
                }

                session = amqpConnection.CreateSession(amqpSessionSettings);
                await session.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpSessionCreationException(this.entityPath, amqpConnection, exception);
                session?.Abort();
                throw AmqpExceptionHelper.GetClientException(exception, null, session.GetInnerException(), amqpConnection.IsClosing());
            }

            AmqpObject link = null;
            try
            {
                // Create Link
                link = this.OnCreateAmqpLink(amqpConnection, this.amqpLinkSettings, session);
                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                return new Tuple<AmqpObject, DateTime>(link, cbsTokenExpiresAtUtc);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpLinkCreationException(
                    this.entityPath,
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