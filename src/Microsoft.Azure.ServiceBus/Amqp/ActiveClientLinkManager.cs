// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Amqp
{
    using Microsoft.Azure.Amqp;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    sealed class ActiveClientLinkManager
    {
        static readonly TimeSpan SendTokenTimeout = TimeSpan.FromMinutes(1);
        static readonly TimeSpan TokenRefreshBuffer = TimeSpan.FromSeconds(10);

        readonly string clientId;
        readonly ICbsTokenProvider cbsTokenProvider;
        readonly Timer sendReceiveLinkCBSTokenRenewalTimer;
        readonly Timer requestResponseLinkCBSTokenRenewalTimer;

        ActiveSendReceiveClientLink activeSendReceiveClientLink;
        ActiveRequestResponseLink activeRequestResponseClientLink;

        public ActiveClientLinkManager(string clientId, ICbsTokenProvider tokenProvider)
        {
            this.clientId = clientId;
            this.cbsTokenProvider = tokenProvider;
            this.sendReceiveLinkCBSTokenRenewalTimer = new Timer(OnRenewSendReceiveCBSToken, this, Timeout.Infinite, Timeout.Infinite);
            this.requestResponseLinkCBSTokenRenewalTimer = new Timer(OnRenewRequestResponseCBSToken, this, Timeout.Infinite, Timeout.Infinite);
        }

        public void Close()
        {
            this.ChangeRenewTimer(this.activeSendReceiveClientLink, Timeout.InfiniteTimeSpan);
            this.ChangeRenewTimer(this.activeRequestResponseClientLink, Timeout.InfiniteTimeSpan);
        }

        public void SetActiveSendReceiveLink(ActiveSendReceiveClientLink sendReceiveClientLink)
        {
            this.activeSendReceiveClientLink = sendReceiveClientLink;
            this.activeSendReceiveClientLink.Link.Closed += this.OnSendReceiveLinkClosed;
            if (this.activeSendReceiveClientLink.Link.State == AmqpObjectState.Opened)
            {
                this.SetRenewCBSTokenTimer(sendReceiveClientLink);
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
                this.SetRenewCBSTokenTimer(requestResponseLink);
            }
        }

        void OnRequestResponseLinkClosed(object sender, EventArgs e)
        {
            this.ChangeRenewTimer(this.activeRequestResponseClientLink, Timeout.InfiniteTimeSpan);
        }

        static async void OnRenewSendReceiveCBSToken(object state)
        {
            ActiveClientLinkManager thisPtr = (ActiveClientLinkManager)state;
            await thisPtr.RenewCBSTokenAsync(thisPtr.activeSendReceiveClientLink).ConfigureAwait(false);
        }

        static async void OnRenewRequestResponseCBSToken(object state)
        {
            ActiveClientLinkManager thisPtr = (ActiveClientLinkManager)state;
            await thisPtr.RenewCBSTokenAsync(thisPtr.activeRequestResponseClientLink).ConfigureAwait(false);
        }

        void SetRenewCBSTokenTimer(ActiveClientLinkObject activeClientLinkObject)
        {
            if (activeClientLinkObject.AuthorizationValidUntilUtc < DateTime.UtcNow)
            {
                return;
            }

            TimeSpan interval = activeClientLinkObject.AuthorizationValidUntilUtc.Subtract(DateTime.UtcNow) - ActiveClientLinkManager.TokenRefreshBuffer;
            this.ChangeRenewTimer(activeClientLinkObject, interval);
        }

        void ChangeRenewTimer(ActiveClientLinkObject activeClientLinkObject, TimeSpan dueTime)
        {
            if (activeClientLinkObject is ActiveSendReceiveClientLink)
            {
                this.sendReceiveLinkCBSTokenRenewalTimer.Change(dueTime, Timeout.InfiniteTimeSpan);
            }
            else
            {
                this.requestResponseLinkCBSTokenRenewalTimer.Change(dueTime, Timeout.InfiniteTimeSpan);
            }
        }

        async Task RenewCBSTokenAsync(ActiveClientLinkObject activeClientLinkObject)
        {
            try
            {
                AmqpCbsLink cbsLink = activeClientLinkObject.Connection.Extensions.Find<AmqpCbsLink>() ?? new AmqpCbsLink(activeClientLinkObject.Connection);

                MessagingEventSource.Log.AmqpSendAuthenticanTokenStart(activeClientLinkObject.EndpointUri, activeClientLinkObject.Audience, activeClientLinkObject.Audience, activeClientLinkObject.RequiredClaims);

                activeClientLinkObject.AuthorizationValidUntilUtc = await cbsLink.SendTokenAsync(
                    this.cbsTokenProvider,
                    activeClientLinkObject.EndpointUri,
                    activeClientLinkObject.Audience,
                    activeClientLinkObject.Audience,
                    activeClientLinkObject.RequiredClaims,
                    ActiveClientLinkManager.SendTokenTimeout).ConfigureAwait(false);

                this.SetRenewCBSTokenTimer(activeClientLinkObject);

                MessagingEventSource.Log.AmqpSendAuthenticanTokenStop();
            }
            catch (Exception e)
            {
                // failed to refresh token, no need to do anything since the server will shut the link itself
                MessagingEventSource.Log.AmqpSendAuthenticanTokenException(this.clientId, e);

                this.ChangeRenewTimer(activeClientLinkObject, Timeout.InfiniteTimeSpan);
            }
        }
    }
}
