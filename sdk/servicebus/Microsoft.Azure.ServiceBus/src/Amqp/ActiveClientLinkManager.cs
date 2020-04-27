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

	    private readonly string clientId;
	    private readonly RetryPolicy retryPolicy;
	    private readonly ICbsTokenProvider cbsTokenProvider;
	    private Timer sendReceiveLinkCbsTokenRenewalTimer;
	    private Timer requestResponseLinkCbsTokenRenewalTimer;

	    private ActiveSendReceiveClientLink activeSendReceiveClientLink;
	    private ActiveRequestResponseLink activeRequestResponseClientLink;

        public ActiveClientLinkManager(ClientEntity client, ICbsTokenProvider tokenProvider)
        {
            clientId = client.ClientId;
            retryPolicy = client.RetryPolicy ?? RetryPolicy.Default;
            cbsTokenProvider = tokenProvider;
            sendReceiveLinkCbsTokenRenewalTimer = new Timer(OnRenewSendReceiveCbsToken, this, Timeout.Infinite, Timeout.Infinite);
            requestResponseLinkCbsTokenRenewalTimer = new Timer(OnRenewRequestResponseCbsToken, this, Timeout.Infinite, Timeout.Infinite);
        }

        public void Close()
        {
            sendReceiveLinkCbsTokenRenewalTimer.Dispose();
            sendReceiveLinkCbsTokenRenewalTimer = null;
            requestResponseLinkCbsTokenRenewalTimer.Dispose();
            requestResponseLinkCbsTokenRenewalTimer = null;
        }

        public void SetActiveSendReceiveLink(ActiveSendReceiveClientLink sendReceiveClientLink)
        {
            activeSendReceiveClientLink = sendReceiveClientLink;
            activeSendReceiveClientLink.Link.Closed += OnSendReceiveLinkClosed;
            if (activeSendReceiveClientLink.Link.State == AmqpObjectState.Opened)
            {
                SetRenewCbsTokenTimer(sendReceiveClientLink);
            }
        }

        private void OnSendReceiveLinkClosed(object sender, EventArgs e)
        {
            ChangeRenewTimer(activeSendReceiveClientLink, Timeout.InfiniteTimeSpan);
        }

        public void SetActiveRequestResponseLink(ActiveRequestResponseLink requestResponseLink)
        {
            activeRequestResponseClientLink = requestResponseLink;
            activeRequestResponseClientLink.Link.Closed += OnRequestResponseLinkClosed;
            if (activeRequestResponseClientLink.Link.State == AmqpObjectState.Opened)
            {
                SetRenewCbsTokenTimer(requestResponseLink);
            }
        }

        private static async void OnRenewSendReceiveCbsToken(object state)
        {
            var activeClientLinkManager = (ActiveClientLinkManager)state;
            await activeClientLinkManager.RenewCbsTokenAsync(activeClientLinkManager.activeSendReceiveClientLink).ConfigureAwait(false);
        }

        private static async void OnRenewRequestResponseCbsToken(object state)
        {
            var activeClientLinkManager = (ActiveClientLinkManager)state;
            await activeClientLinkManager.RenewCbsTokenAsync(activeClientLinkManager.activeRequestResponseClientLink).ConfigureAwait(false);
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

                    await retryPolicy.RunOperation(
                        async () =>
                        {
                            cbsTokenExpiresAtUtc = TimeoutHelper.Min(
                                cbsTokenExpiresAtUtc, 
                                await cbsLink.SendTokenAsync(
                                    cbsTokenProvider,
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
                MessagingEventSource.Log.AmqpSendAuthenticationTokenException(clientId, e);

                ChangeRenewTimer(activeClientLinkObject, Timeout.InfiniteTimeSpan);
            }
        }

        private void OnRequestResponseLinkClosed(object sender, EventArgs e)
        {
            ChangeRenewTimer(activeRequestResponseClientLink, Timeout.InfiniteTimeSpan);
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
                sendReceiveLinkCbsTokenRenewalTimer?.Change(dueTime, Timeout.InfiniteTimeSpan);
            }
            else
            {
                requestResponseLinkCbsTokenRenewalTimer?.Change(dueTime, Timeout.InfiniteTimeSpan);
            }
        }
    }
}
