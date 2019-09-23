// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        private Timer timer;

        private ActiveClientLinkObject link;

        public ActiveClientLinkManager(ClientEntity client)
        {
            clientId = client.ClientId;
            retryPolicy = client.RetryPolicy ?? RetryPolicy.Default;
            cbsTokenProvider = client.ServiceBusConnection.CbsTokenProvider;
            timer = new Timer(sender => _ = OnRenewSendReceiveCbsToken(sender), this, Timeout.Infinite, Timeout.Infinite);
        }

        public void Close()
        {
            timer.Dispose();
            timer = null;
        }

        public void SetLink(ActiveClientLinkObject sendReceiveClientLink)
        {
            link = sendReceiveClientLink;
            link.Link.Closed += OnSendReceiveLinkClosed;
            if (link.Link.State == AmqpObjectState.Opened)
            {
                SetRenewCbsTokenTimer(sendReceiveClientLink);
            }
        }

        private void OnSendReceiveLinkClosed(object sender, EventArgs e)
        {
            ChangeRenewTimer(Timeout.InfiniteTimeSpan);
        }

        private static async Task OnRenewSendReceiveCbsToken(object state)
        {
            var activeClientLinkManager = (ActiveClientLinkManager)state;
            await activeClientLinkManager.RenewCbsTokenAsync(activeClientLinkManager.link).ConfigureAwait(false);
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

                ChangeRenewTimer(Timeout.InfiniteTimeSpan);
            }
        }

        private void SetRenewCbsTokenTimer(ActiveClientLinkObject activeClientLinkObject)
        {
            if (activeClientLinkObject.AuthorizationValidUntilUtc < DateTime.UtcNow)
            {
                return;
            }

            var interval = activeClientLinkObject.AuthorizationValidUntilUtc.Subtract(DateTime.UtcNow) - TokenRefreshBuffer;
            interval = TimeoutHelper.Min(interval, MaxTokenRefreshTime);

            ChangeRenewTimer(interval);
        }

        private void ChangeRenewTimer(TimeSpan dueTime)
        {
            timer?.Change(dueTime, Timeout.InfiniteTimeSpan);
        }
    }
}
