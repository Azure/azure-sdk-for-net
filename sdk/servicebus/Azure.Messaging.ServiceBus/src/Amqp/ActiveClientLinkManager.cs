// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Azure.Messaging.ServiceBus.Amqp
{
    using Microsoft.Azure.Amqp;
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
            this.clientId = client.ClientId;
            this.retryPolicy = client.RetryPolicy ?? RetryPolicy.Default;
            this.cbsTokenProvider = tokenProvider;
            this.sendReceiveLinkCbsTokenRenewalTimer = new Timer(OnRenewSendReceiveCbsToken, this, Timeout.Infinite, Timeout.Infinite);
            this.requestResponseLinkCbsTokenRenewalTimer = new Timer(OnRenewRequestResponseCbsToken, this, Timeout.Infinite, Timeout.Infinite);
        }

        public void Close()
        {
            this.sendReceiveLinkCbsTokenRenewalTimer.Dispose();
            this.sendReceiveLinkCbsTokenRenewalTimer = null;
            this.requestResponseLinkCbsTokenRenewalTimer.Dispose();
            this.requestResponseLinkCbsTokenRenewalTimer = null;
        }

        public void SetActiveSendReceiveLink(ActiveSendReceiveClientLink sendReceiveClientLink)
        {
            this.activeSendReceiveClientLink = sendReceiveClientLink;
            this.activeSendReceiveClientLink.Link.Closed += this.OnSendReceiveLinkClosed;
            if (this.activeSendReceiveClientLink.Link.State == AmqpObjectState.Opened)
            {
                this.SetRenewCbsTokenTimer(sendReceiveClientLink);
            }
        }

        private void OnSendReceiveLinkClosed(object sender, EventArgs e)
        {
            this.ChangeRenewTimer(this.activeSendReceiveClientLink, Timeout.InfiniteTimeSpan);
        }

        public void SetActiveRequestResponseLink(ActiveRequestResponseLink requestResponseLink)
        {
            this.activeRequestResponseClientLink = requestResponseLink;
            this.activeRequestResponseClientLink.Link.Closed += this.OnRequestResponseLinkClosed;
            if (this.activeRequestResponseClientLink.Link.State == AmqpObjectState.Opened)
            {
                this.SetRenewCbsTokenTimer(requestResponseLink);
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

                    await this.retryPolicy.RunOperation(
                        async () =>
                        {
                            cbsTokenExpiresAtUtc = TimeoutHelper.Min(
                                cbsTokenExpiresAtUtc,
                                await cbsLink.SendTokenAsync(
                                    this.cbsTokenProvider,
                                    activeClientLinkObject.EndpointUri,
                                    resource,
                                    resource,
                                    activeClientLinkObject.RequiredClaims,
                                    ActiveClientLinkManager.SendTokenTimeout).ConfigureAwait(false));
                        }, ActiveClientLinkManager.SendTokenTimeout).ConfigureAwait(false);

                    MessagingEventSource.Log.AmqpSendAuthenticationTokenStop();
                }

                activeClientLinkObject.AuthorizationValidUntilUtc = cbsTokenExpiresAtUtc;
                this.SetRenewCbsTokenTimer(activeClientLinkObject);
            }
            catch (Exception e)
            {
                // failed to refresh token, no need to do anything since the server will shut the link itself
                MessagingEventSource.Log.AmqpSendAuthenticationTokenException(this.clientId, e);

                this.ChangeRenewTimer(activeClientLinkObject, Timeout.InfiniteTimeSpan);
            }
        }

        private void OnRequestResponseLinkClosed(object sender, EventArgs e)
        {
            this.ChangeRenewTimer(this.activeRequestResponseClientLink, Timeout.InfiniteTimeSpan);
        }

        private void SetRenewCbsTokenTimer(ActiveClientLinkObject activeClientLinkObject)
        {
            if (activeClientLinkObject.AuthorizationValidUntilUtc < DateTime.UtcNow)
            {
                return;
            }

            var interval = activeClientLinkObject.AuthorizationValidUntilUtc.Subtract(DateTime.UtcNow) - ActiveClientLinkManager.TokenRefreshBuffer;
            interval = TimeoutHelper.Min(interval, ActiveClientLinkManager.MaxTokenRefreshTime);

            this.ChangeRenewTimer(activeClientLinkObject, interval);
        }

        private void ChangeRenewTimer(ActiveClientLinkObject activeClientLinkObject, TimeSpan dueTime)
        {
            if (activeClientLinkObject is ActiveSendReceiveClientLink)
            {
                this.sendReceiveLinkCbsTokenRenewalTimer?.Change(dueTime, Timeout.InfiniteTimeSpan);
            }
            else
            {
                this.requestResponseLinkCbsTokenRenewalTimer?.Change(dueTime, Timeout.InfiniteTimeSpan);
            }
        }
    }
}
