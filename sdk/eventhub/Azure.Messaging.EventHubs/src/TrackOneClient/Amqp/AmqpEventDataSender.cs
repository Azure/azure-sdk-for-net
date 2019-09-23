// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace TrackOne.Amqp
{
    internal class AmqpEventDataSender : EventDataSender
    {
        private int _deliveryCount;
        private bool _linkCreated;
        private readonly ActiveClientLinkManager _clientLinkManager;

        internal AmqpEventDataSender(AmqpEventHubClient eventHubClient, string partitionId)
            : base(eventHubClient, partitionId)
        {
            Path = !string.IsNullOrEmpty(partitionId)
                ? $"{eventHubClient.EventHubName}/Partitions/{partitionId}"
                : eventHubClient.EventHubName;

            SendLinkManager = new FaultTolerantAmqpObject<SendingAmqpLink>(CreateLinkAsync, CloseSession);
            _clientLinkManager = new ActiveClientLinkManager((AmqpEventHubClient)EventHubClient);
            MaxMessageSize = 256 * 1024;   // Default. Updated when link is opened
        }

        private string Path { get; }

        private FaultTolerantAmqpObject<SendingAmqpLink> SendLinkManager { get; }

        public override Task CloseAsync()
        {
            _clientLinkManager.Close();
            return SendLinkManager.CloseAsync();
        }

        protected override async Task OnSendAsync(IEnumerable<EventData> eventDatas, string partitionKey)
        {
            bool shouldRetry;
            int retryCount = 0;

            var timeoutHelper = new TimeoutHelper(EventHubClient.ConnectionStringBuilder.OperationTimeout, startTimeout: true);

            do
            {
                using (AmqpMessage amqpMessage = AmqpMessageConverter.EventDatasToAmqpMessage(eventDatas, partitionKey))
                {
                    shouldRetry = false;

                    try
                    {
                        try
                        {
                            // Always use default timeout for AMQP sesssion.
                            SendingAmqpLink amqpLink = await SendLinkManager.GetOrCreateAsync(
                                TimeSpan.FromSeconds(AmqpClientConstants.AmqpSessionTimeoutInSeconds)).ConfigureAwait(false);
                            if (amqpLink.Settings.MaxMessageSize.HasValue)
                            {
                                ulong size = (ulong)amqpMessage.SerializedMessageSize;
                                if (size > amqpLink.Settings.MaxMessageSize.Value)
                                {
                                    throw new MessageSizeExceededException(amqpMessage.DeliveryId.Value, size, amqpLink.Settings.MaxMessageSize.Value);
                                }
                            }

                            Outcome outcome = await amqpLink.SendMessageAsync(
                                amqpMessage,
                                GetNextDeliveryTag(),
                                AmqpConstants.NullBinary,
                                timeoutHelper.RemainingTime()).ConfigureAwait(false);
                            if (outcome.DescriptorCode != Accepted.Code)
                            {
                                Rejected rejected = (Rejected)outcome;
                                throw new AmqpException(rejected.Error);
                            }
                        }
                        catch (AmqpException amqpException)
                        {
                            throw AmqpExceptionHelper.ToMessagingContract(amqpException.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Evaluate retry condition?
                        TimeSpan? retryInterval = RetryPolicy.GetNextRetryInterval(ex, timeoutHelper.RemainingTime(), ++retryCount);
                        if (retryInterval != null && !EventHubClient.CloseCalled)
                        {
                            await Task.Delay(retryInterval.Value).ConfigureAwait(false);
                            shouldRetry = true;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            } while (shouldRetry);
        }

        internal override async ValueTask EnsureLinkAsync()
        {
            if (_linkCreated)
            {
                return;
            }

            await SendLinkManager.GetOrCreateAsync(TimeSpan.FromSeconds(AmqpClientConstants.AmqpSessionTimeoutInSeconds)).ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromMilliseconds(15)).ConfigureAwait(false);

        }

        private ArraySegment<byte> GetNextDeliveryTag()
        {
            int deliveryId = Interlocked.Increment(ref _deliveryCount);
            return new ArraySegment<byte>(BitConverter.GetBytes(deliveryId));
        }

        private async Task<SendingAmqpLink> CreateLinkAsync(TimeSpan timeout)
        {
            var amqpEventHubClient = ((AmqpEventHubClient)EventHubClient);

            var timeoutHelper = new TimeoutHelper(timeout);
            AmqpConnection connection = await amqpEventHubClient.ConnectionManager.GetOrCreateAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

            // Authenticate over CBS
            AmqpCbsLink cbsLink = connection.Extensions.Find<AmqpCbsLink>();

            ICbsTokenProvider cbsTokenProvider = amqpEventHubClient.CbsTokenProvider;
            Uri address = new Uri(amqpEventHubClient.ConnectionStringBuilder.Endpoint, Path);
            string audience = address.AbsoluteUri;
            string resource = address.AbsoluteUri;
            DateTime expiresAt = await cbsLink.SendTokenAsync(
                cbsTokenProvider,
                address,
                audience,
                resource,
                new[] { ClaimConstants.Send },
                timeoutHelper.RemainingTime()).ConfigureAwait(false);

            AmqpSession session = null;
            try
            {
                // Create our Session
                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);
                await session.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                // Create our Link
                var linkSettings = new AmqpLinkSettings();
                linkSettings.AddProperty(AmqpClientConstants.TimeoutName, (uint)timeoutHelper.RemainingTime().TotalMilliseconds);
                linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)MessagingEntityType.EventHub);
                linkSettings.Role = false;
                linkSettings.InitialDeliveryCount = 0;
                linkSettings.Target = new Target { Address = address.AbsolutePath };
                linkSettings.Source = new Source { Address = ClientId };

                var link = new SendingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{amqpEventHubClient.ContainerId};{connection.Identifier}:{session.Identifier}:{link.Identifier}";
                link.AttachTo(session);

                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                var activeClientLink = new ActiveClientLink(
                    link,
                    audience, // audience
                    EventHubClient.ConnectionStringBuilder.Endpoint.AbsoluteUri, // endpointUri
                    new[] { ClaimConstants.Send },
                    true,
                    expiresAt);

                MaxMessageSize = (long)activeClientLink.Link.Settings.MaxMessageSize();
                _clientLinkManager.SetActiveLink(activeClientLink);
                _linkCreated = true;
                return link;
            }
            catch
            {
                // Cleanup any session (and thus link) in case of exception.
                session?.Abort();
                throw;
            }
        }

        private void CloseSession(SendingAmqpLink link)
        {
            // Note we close the session (which includes the link).
            link.Session.SafeClose();
        }
    }
}
