// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Microsoft.Azure.Amqp;

namespace TrackOne.Amqp
{
    internal sealed class ActiveClientLinkManager
    {
        private static readonly TimeSpan SendTokenTimeout = TimeSpan.FromMinutes(1);
        private static readonly TimeSpan TokenRefreshBuffer = TimeSpan.FromSeconds(10);
        private readonly Timer validityTimer;
        private readonly AmqpEventHubClient eventHubClient;
        private readonly object syncRoot;
        private ActiveClientLinkObject activeClientLink;

        public ActiveClientLinkManager(AmqpEventHubClient eventHubClient)
        {
            this.eventHubClient = eventHubClient;
            validityTimer = new Timer(OnLinkExpiration, this, Timeout.Infinite, Timeout.Infinite);
            syncRoot = new object();
        }

        public void SetActiveLink(ActiveClientLinkObject activeClientLink)
        {
            lock (syncRoot)
            {
                this.activeClientLink = activeClientLink;
                this.activeClientLink.LinkObject.Closed += OnLinkClosed;
                if (this.activeClientLink.LinkObject.State == AmqpObjectState.Opened &&
                    this.activeClientLink.IsClientToken)
                {
                    ScheduleValidityTimer();
                }
            }
        }

        public void Close()
        {
            CancelValidityTimer();
        }

        private static async void OnLinkExpiration(object state)
        {
            ActiveClientLinkManager thisPtr = (ActiveClientLinkManager)state;
            Fx.Assert(thisPtr.activeClientLink != null, "activeClientLink cant be null");
            Fx.Assert(thisPtr.activeClientLink.IsClientToken, "timer can't fire if the link auth is not based on a client token");

            try
            {
                //DNX_TODO: MessagingClientEtwProvider.Provider.EventWriteAmqpManageLink("Before SendToken", thisPtr.activeClientLink.LinkObject, string.Empty);

                AmqpCbsLink cbsLink = thisPtr.activeClientLink.Connection.Extensions.Find<AmqpCbsLink>();
                if (cbsLink == null)
                {
                    cbsLink = new AmqpCbsLink(thisPtr.activeClientLink.Connection);
                }

                DateTime validTo = await cbsLink.SendTokenAsync(
                    thisPtr.eventHubClient.CbsTokenProvider,
                    thisPtr.eventHubClient.ConnectionStringBuilder.Endpoint,
                    thisPtr.activeClientLink.Audience, thisPtr.activeClientLink.EndpointUri,
                    thisPtr.activeClientLink.RequiredClaims,
                    ActiveClientLinkManager.SendTokenTimeout).ConfigureAwait(false);

                //DNX_TODO: MessagingClientEtwProvider.Provider.EventWriteAmqpManageLink("After SendToken", thisPtr.activeClientLink.LinkObject, validTo.ToString(CultureInfo.InvariantCulture));
                lock (thisPtr.syncRoot)
                {
                    thisPtr.activeClientLink.AuthorizationValidToUtc = validTo;
                    thisPtr.ScheduleValidityTimer();
                }
            }
            catch
            {
                //DNX_TODO:
                //if (Fx.IsFatal(exception))
                //{
                //    throw;
                //}

                //DNX_TODO: MessagingClientEtwProvider.Provider.EventWriteAmqpLogError(thisPtr.activeClientLink.LinkObject, "BeginSendToken", exception.Message);

                // failed to refresh token, no need to do anything since the server will shut the link itself
                thisPtr.CancelValidityTimer();
            }
        }

        private void ScheduleValidityTimer()
        {
            if (activeClientLink.AuthorizationValidToUtc < DateTime.UtcNow)
            {
                return;
            }

            TimeSpan interval = activeClientLink.AuthorizationValidToUtc.Subtract(DateTime.UtcNow);
            interval += TokenRefreshBuffer;   // Avoid getting a token that expires right away
            interval = interval < AmqpClientConstants.ClientMinimumTokenRefreshInterval ? AmqpClientConstants.ClientMinimumTokenRefreshInterval : interval;

            validityTimer.Change(interval, Timeout.InfiniteTimeSpan);

            //DNX_TODO: MessagingClientEtwProvider.Provider.EventWriteAmqpManageLink("SetTimer", this.activeClientLink.LinkObject, interval.ToString("c", CultureInfo.InvariantCulture));
        }

        private void OnLinkClosed(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelValidityTimer()
        {
            validityTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
}
