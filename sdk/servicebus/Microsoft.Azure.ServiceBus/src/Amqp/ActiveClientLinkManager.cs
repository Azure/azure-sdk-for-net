// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using Azure.Amqp;
    using Primitives;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class ActiveClientLinkManager
    {
	    private static readonly TimeSpan SendTokenTimeout = TimeSpan.FromMinutes(1);
	    private static readonly TimeSpan TokenRefreshBuffer = TimeSpan.FromSeconds(10);
	    private static readonly TimeSpan MaxTokenRefreshTime = TimeSpan.FromDays(30);

	    private readonly string _clientId;
	    private readonly RetryPolicy _retryPolicy;
	    private readonly ICbsTokenProvider _cbsTokenProvider;
	    private Timer _sendReceiveLinkCbsTokenRenewalTimer;
	    private Timer _requestResponseLinkCbsTokenRenewalTimer;

	    private ActiveSendReceiveClientLink _activeSendReceiveClientLink;
	    private ActiveRequestResponseLink _activeRequestResponseClientLink;

        public ActiveClientLinkManager(ClientEntity client, ICbsTokenProvider tokenProvider)
        {
            _clientId = client.ClientId;
            _retryPolicy = client.RetryPolicy ?? RetryPolicy.Default;
            _cbsTokenProvider = tokenProvider;
            _sendReceiveLinkCbsTokenRenewalTimer = new Timer(OnRenewSendReceiveCbsToken, this, Timeout.Infinite, Timeout.Infinite);
            _requestResponseLinkCbsTokenRenewalTimer = new Timer(OnRenewRequestResponseCbsToken, this, Timeout.Infinite, Timeout.Infinite);
        }

        public void Close()
        {
            _sendReceiveLinkCbsTokenRenewalTimer.Dispose();
            _sendReceiveLinkCbsTokenRenewalTimer = null;
            _requestResponseLinkCbsTokenRenewalTimer.Dispose();
            _requestResponseLinkCbsTokenRenewalTimer = null;
        }

        public void SetActiveSendReceiveLink(ActiveSendReceiveClientLink sendReceiveClientLink)
        {
            _activeSendReceiveClientLink = sendReceiveClientLink;
            _activeSendReceiveClientLink.Link.Closed += OnSendReceiveLinkClosed;
            if (_activeSendReceiveClientLink.Link.State == AmqpObjectState.Opened)
            {
                SetRenewCbsTokenTimer(sendReceiveClientLink);
            }
        }

        private void OnSendReceiveLinkClosed(object sender, EventArgs e)
        {
            ChangeRenewTimer(_activeSendReceiveClientLink, Timeout.InfiniteTimeSpan);
        }

        public void SetActiveRequestResponseLink(ActiveRequestResponseLink requestResponseLink)
        {
            _activeRequestResponseClientLink = requestResponseLink;
            _activeRequestResponseClientLink.Link.Closed += OnRequestResponseLinkClosed;
            if (_activeRequestResponseClientLink.Link.State == AmqpObjectState.Opened)
            {
                SetRenewCbsTokenTimer(requestResponseLink);
            }
        }

        private static async void OnRenewSendReceiveCbsToken(object state)
        {
            var activeClientLinkManager = (ActiveClientLinkManager)state;
            await activeClientLinkManager.RenewCbsTokenAsync(activeClientLinkManager._activeSendReceiveClientLink).ConfigureAwait(false);
        }

        private static async void OnRenewRequestResponseCbsToken(object state)
        {
            var activeClientLinkManager = (ActiveClientLinkManager)state;
            await activeClientLinkManager.RenewCbsTokenAsync(activeClientLinkManager._activeRequestResponseClientLink).ConfigureAwait(false);
        }

        private async Task RenewCbsTokenAsync(ActiveClientLinkObject activeClientLinkObject)
        {
            try
            {
                var cbsLink = activeClientLinkObject.Connection.Extensions.Find<AmqpCbsLink>() ?? new AmqpCbsLink(activeClientLinkObject.Connection);
                DateTime cbsTokenExpiresAtUtc = DateTime.MaxValue;

                foreach (var resource in activeClientLinkObject.Audience)
                {
                    MessagingEventSource.Log.AmqpSendAuthenticationTokenStart(activeClientLinkObject.EndpointUri, resource, resource, activeClientLinkObject.RequiredClaims);

                    await _retryPolicy.RunOperation(
                        async () =>
                        {
                            cbsTokenExpiresAtUtc = TimeoutHelper.Min(
                                cbsTokenExpiresAtUtc, 
                                await cbsLink.SendTokenAsync(
                                    _cbsTokenProvider,
                                    activeClientLinkObject.EndpointUri,
                                    resource,
                                    resource,
                                    activeClientLinkObject.RequiredClaims,
                                    SendTokenTimeout).ConfigureAwait(false));
                        }, SendTokenTimeout).ConfigureAwait(false);

                    MessagingEventSource.Log.AmqpSendAuthenticationTokenStop();
                }

                activeClientLinkObject.AuthorizationValidUntilUtc = cbsTokenExpiresAtUtc;
                SetRenewCbsTokenTimer(activeClientLinkObject);
            }
            catch (Exception e)
            {
                // failed to refresh token, no need to do anything since the server will shut the link itself
                MessagingEventSource.Log.AmqpSendAuthenticationTokenException(_clientId, e);

                ChangeRenewTimer(activeClientLinkObject, Timeout.InfiniteTimeSpan);
            }
        }

        private void OnRequestResponseLinkClosed(object sender, EventArgs e)
        {
            ChangeRenewTimer(_activeRequestResponseClientLink, Timeout.InfiniteTimeSpan);
        }

        private void SetRenewCbsTokenTimer(ActiveClientLinkObject activeClientLinkObject)
        {
            var utcNow = DateTime.UtcNow;
            if (activeClientLinkObject.AuthorizationValidUntilUtc < utcNow)
            {
                return;
            }

            var interval = activeClientLinkObject.AuthorizationValidUntilUtc.Subtract(utcNow) - TokenRefreshBuffer;
            
            if (interval < TokenRefreshBuffer)
            {
	            interval = TimeSpan.Zero;
            }

            interval = TimeoutHelper.Min(interval, MaxTokenRefreshTime);

            ChangeRenewTimer(activeClientLinkObject, interval);
        }

        private void ChangeRenewTimer(ActiveClientLinkObject activeClientLinkObject, TimeSpan dueTime)
        {
            if (activeClientLinkObject is ActiveSendReceiveClientLink)
            {
                _sendReceiveLinkCbsTokenRenewalTimer?.Change(dueTime, Timeout.InfiniteTimeSpan);
            }
            else
            {
                _requestResponseLinkCbsTokenRenewalTimer?.Change(dueTime, Timeout.InfiniteTimeSpan);
            }
        }
    }
}
