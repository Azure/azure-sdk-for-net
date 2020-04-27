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
	    private readonly string _entityPath;
	    private readonly ServiceBusConnection _serviceBusConnection;
	    private readonly Uri _endpointAddress;
	    private readonly string[] _audience;
	    private readonly string[] _requiredClaims;
	    private readonly ICbsTokenProvider _cbsTokenProvider;
	    private readonly AmqpLinkSettings _amqpLinkSettings;

        protected AmqpLinkCreator(string entityPath, ServiceBusConnection serviceBusConnection, Uri endpointAddress, string[] audience, string[] requiredClaims, ICbsTokenProvider cbsTokenProvider, AmqpLinkSettings amqpLinkSettings, string clientId)
        {
            this._entityPath = entityPath;
            this._serviceBusConnection = serviceBusConnection;
            this._endpointAddress = endpointAddress;
            this._audience = audience;
            this._requiredClaims = requiredClaims;
            this._cbsTokenProvider = cbsTokenProvider;
            this._amqpLinkSettings = amqpLinkSettings;
            ClientId = clientId;
        }

        protected string ClientId { get; }

        public async Task<Tuple<AmqpObject, DateTime>> CreateAndOpenAmqpLinkAsync()
        {
            var timeoutHelper = new TimeoutHelper(_serviceBusConnection.OperationTimeout, true);

            MessagingEventSource.Log.AmqpGetOrCreateConnectionStart();
            var amqpConnection = await _serviceBusConnection.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
            MessagingEventSource.Log.AmqpGetOrCreateConnectionStop(_entityPath, amqpConnection.ToString(), amqpConnection.State.ToString());

            // Authenticate over CBS
            var cbsLink = amqpConnection.Extensions.Find<AmqpCbsLink>();
            DateTime cbsTokenExpiresAtUtc = DateTime.MaxValue;

            foreach (var resource in _audience)
            {
                MessagingEventSource.Log.AmqpSendAuthenticationTokenStart(_endpointAddress, resource, resource, _requiredClaims);
                cbsTokenExpiresAtUtc = TimeoutHelper.Min(
                    cbsTokenExpiresAtUtc, 
                    await cbsLink.SendTokenAsync(_cbsTokenProvider, _endpointAddress, resource, resource, _requiredClaims, timeoutHelper.RemainingTime()).ConfigureAwait(false));
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
                MessagingEventSource.Log.AmqpSessionCreationException(_entityPath, amqpConnection, exception);
                session?.Abort();
                throw AmqpExceptionHelper.GetClientException(exception, null, session.GetInnerException(), amqpConnection.IsClosing());
            }

            AmqpObject link = null;
            try
            {
                // Create Link
                link = OnCreateAmqpLink(amqpConnection, _amqpLinkSettings, session);
                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                return new Tuple<AmqpObject, DateTime>(link, cbsTokenExpiresAtUtc);
            }
            catch (Exception exception)
            {
                MessagingEventSource.Log.AmqpLinkCreationException(
                    _entityPath,
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