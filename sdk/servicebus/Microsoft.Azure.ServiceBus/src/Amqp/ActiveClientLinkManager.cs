// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using Azure.Amqp;
    using Primitives;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    sealed class ActiveClientLinkManager
    {
        static readonly TimeSpan SendTokenTimeout = TimeSpan.FromMinutes(1);
        static readonly TimeSpan TokenRefreshBuffer = TimeSpan.FromSeconds(10);
        static readonly TimeSpan MaxTokenRefreshTime = TimeSpan.FromDays(30);

        readonly string clientId;
        readonly RetryPolicy retryPolicy;
        readonly ICbsTokenProvider cbsTokenProvider;
        Timer sendReceiveLinkCbsTokenRenewalTimer;
        Timer requestResponseLinkCbsTokenRenewalTimer;

        ActiveSendReceiveClientLink activeSendReceiveClientLink;
        ActiveRequestResponseLink activeRequestResponseClientLink;

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

        void OnSendReceiveLinkClosed(object sender, EventArgs e)
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

        static async void OnRenewSendReceiveCbsToken(object state)
        {
            var activeClientLinkManager = (ActiveClientLinkManager)state;
            await activeClientLinkManager.RenewCbsTokenAsync(activeClientLinkManager.activeSendReceiveClientLink).ConfigureAwait(false);
        }

        static async void OnRenewRequestResponseCbsToken(object state)
        {
            var activeClientLinkManager = (ActiveClientLinkManager)state;
            await activeClientLinkManager.RenewCbsTokenAsync(activeClientLinkManager.activeRequestResponseClientLink).ConfigureAwait(false);
        }

        async Task RenewCbsTokenAsync(ActiveClientLinkObject activeClientLinkObject)
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

        void OnRequestResponseLinkClosed(object sender, EventArgs e)
        {
            this.ChangeRenewTimer(this.activeRequestResponseClientLink, Timeout.InfiniteTimeSpan);
        }

        void SetRenewCbsTokenTimer(ActiveClientLinkObject activeClientLinkObject)
        {
            var utcNow = DateTime.UtcNow;
            if (activeClientLinkObject.AuthorizationValidUntilUtc < utcNow)
            {
                return;
            }

            var interval = activeClientLinkObject.AuthorizationValidUntilUtc.Subtract(utcNow) - ActiveClientLinkManager.TokenRefreshBuffer;
            if (interval < ActiveClientLinkManager.TokenRefreshBuffer)
                interval = TimeSpan.Zero;

            interval = TimeoutHelper.Min(interval, ActiveClientLinkManager.MaxTokenRefreshTime);

            this.ChangeRenewTimer(activeClientLinkObject, interval);
        }

        void ChangeRenewTimer(ActiveClientLinkObject activeClientLinkObject, TimeSpan dueTime)
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
