// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace TrackOne.Amqp
{
    internal class AmqpPartitionReceiver : PartitionReceiver
    {
        private readonly object receivePumpLock;
        private readonly ActiveClientLinkManager clientLinkManager;
        private IPartitionReceiveHandler receiveHandler;
        private CancellationTokenSource receivePumpCancellationSource;
        private Task receivePumpTask;

        public AmqpPartitionReceiver(
            AmqpEventHubClient eventHubClient,
            string consumerGroupName,
            string partitionId,
            EventPosition eventPosition,
            long? epoch,
            ReceiverOptions receiverOptions)
            : base(eventHubClient, consumerGroupName, partitionId, eventPosition, epoch, receiverOptions)
        {
            string entityPath = eventHubClient.ConnectionStringBuilder.EntityPath;
            Path = $"{entityPath}/ConsumerGroups/{consumerGroupName}/Partitions/{partitionId}";
            ReceiveLinkManager = new FaultTolerantAmqpObject<ReceivingAmqpLink>(CreateLinkAsync, CloseSession);
            receivePumpLock = new object();
            clientLinkManager = new ActiveClientLinkManager((AmqpEventHubClient)EventHubClient);
        }

        private string Path { get; }

        private FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLinkManager { get; }

        protected override async Task OnCloseAsync()
        {
            // Close any ReceiveHandler (this is safe if there is none) and the ReceiveLinkManager in parallel.
            await ReceiveHandlerClose().ConfigureAwait(false);
            clientLinkManager.Close();
            await ReceiveLinkManager.CloseAsync().ConfigureAwait(false);
        }

        protected override async Task<IList<EventData>> OnReceiveAsync(int maxMessageCount, TimeSpan waitTime)
        {
            bool shouldRetry;
            int retryCount = 0;

            var timeoutHelper = new TimeoutHelper(waitTime, true);

            do
            {
                shouldRetry = false;

                try
                {
                    try
                    {
                        // Always use default timeout for AMQP sesssion.
                        ReceivingAmqpLink receiveLink =
                            await ReceiveLinkManager.GetOrCreateAsync(
                                TimeSpan.FromSeconds(AmqpClientConstants.AmqpSessionTimeoutInSeconds)).ConfigureAwait(false);

                        IEnumerable<AmqpMessage> amqpMessages = null;
                        bool hasMessages = await Task.Factory.FromAsync(
                            (c, s) => receiveLink.BeginReceiveMessages(maxMessageCount, timeoutHelper.RemainingTime(), c, s),
                            a => receiveLink.EndReceiveMessages(a, out amqpMessages),
                            this).ConfigureAwait(false);

                        if (receiveLink.TerminalException != null)
                        {
                            throw receiveLink.TerminalException;
                        }

                        if (hasMessages && amqpMessages != null)
                        {
                            IList<EventData> eventDatas = null;
                            foreach (AmqpMessage amqpMessage in amqpMessages)
                            {
                                if (eventDatas == null)
                                {
                                    eventDatas = new List<EventData>();
                                }

                                receiveLink.DisposeDelivery(amqpMessage, true, AmqpConstants.AcceptedOutcome);
                                eventDatas.Add(AmqpMessageConverter.AmqpMessageToEventData(amqpMessage));
                            }

                            return eventDatas;
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
                        // Handle EventHubsTimeoutException explicitly.
                        // We don't really want to to throw EventHubsTimeoutException on this call.
                        if (ex is EventHubsTimeoutException)
                        {
                            break;
                        }

                        throw;
                    }
                }
            } while (shouldRetry);

            // No messages to deliver.
            return null;
        }

        protected override void OnSetReceiveHandler(IPartitionReceiveHandler newReceiveHandler, bool invokeWhenNoEvents)
        {
            lock (receivePumpLock)
            {
                if (newReceiveHandler != null)
                {
                    if (receiveHandler != null)
                    {
                        // Notify existing handler first (but don't wait).
                        Task.Run(() =>
                            receiveHandler.ProcessErrorAsync(new OperationCanceledException("New handler has registered for this receiver.")))
                            // We omit any failures from ProcessErrorAsync
                            .ContinueWith(t => t.Exception.Handle(ex => true), TaskContinuationOptions.OnlyOnFaulted);
                    }

                    receiveHandler = newReceiveHandler;

                    // We have a new receiveHandler, ensure pump is running.
                    if (receivePumpTask == null)
                    {
                        receivePumpCancellationSource = new CancellationTokenSource();
                        receivePumpTask = ReceivePumpAsync(receivePumpCancellationSource.Token, invokeWhenNoEvents);
                    }
                }
                else
                {
                    // newReceiveHandler == null, so this is an unregister call, ensure pump is shut down.
                    if (receivePumpTask != null)
                    {
                        // Do not wait as could block and would still match the previous behavior
                        ReceiveHandlerClose();
                    }

                    receiveHandler = null;
                }
            }
        }

        private async Task<ReceivingAmqpLink> CreateLinkAsync(TimeSpan timeout)
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
            DateTime expiresAt = await cbsLink.SendTokenAsync(cbsTokenProvider, address, audience, resource, new[] { ClaimConstants.Listen }, timeoutHelper.RemainingTime()).ConfigureAwait(false);

            AmqpSession session = null;
            try
            {
                // Create our Session
                var sessionSettings = new AmqpSessionSettings { Properties = new Fields() };
                session = connection.CreateSession(sessionSettings);
                await session.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);

                FilterSet filterMap = null;
                IList<AmqpDescribed> filters = CreateFilters();
                if (filters != null && filters.Count > 0)
                {
                    filterMap = new FilterSet();
                    foreach (AmqpDescribed filter in filters)
                    {
                        filterMap.Add(filter.DescriptorName, filter);
                    }
                }

                // Create our Link
                var linkSettings = new AmqpLinkSettings
                {
                    Role = true,
                    TotalLinkCredit = (uint)PrefetchCount,
                    AutoSendFlow = PrefetchCount > 0
                };
                linkSettings.AddProperty(AmqpClientConstants.EntityTypeName, (int)MessagingEntityType.ConsumerGroup);
                linkSettings.Source = new Source { Address = address.AbsolutePath, FilterSet = filterMap };
                linkSettings.Target = new Target { Address = ClientId };
                linkSettings.SettleType = SettleMode.SettleOnSend;

                // Receiver metrics enabled?
                if (ReceiverRuntimeMetricEnabled)
                {
                    linkSettings.DesiredCapabilities = new Multiple<AmqpSymbol>(new List<AmqpSymbol>
                    {
                        AmqpClientConstants.EnableReceiverRuntimeMetricName
                    });
                }

                if (Epoch.HasValue)
                {
                    linkSettings.AddProperty(AmqpClientConstants.AttachEpoch, Epoch.Value);
                }

                if (!string.IsNullOrWhiteSpace(Identifier))
                {
                    linkSettings.AddProperty(AmqpClientConstants.ReceiverIdentifierName, Identifier);
                }

                var link = new ReceivingAmqpLink(linkSettings);
                linkSettings.LinkName = $"{amqpEventHubClient.ContainerId};{connection.Identifier}:{session.Identifier}:{link.Identifier}";
                link.AttachTo(session);

                await link.OpenAsync(timeoutHelper.RemainingTime()).ConfigureAwait(false);
                var activeClientLink = new ActiveClientLink(
                    link,
                    audience, // audience
                    EventHubClient.ConnectionStringBuilder.Endpoint.AbsoluteUri, // endpointUri
                    new[] { ClaimConstants.Listen },
                    true,
                    expiresAt);

                clientLinkManager.SetActiveLink(activeClientLink);

                return link;
            }
            catch
            {
                // Cleanup any session (and thus link) in case of exception.
                session?.Abort();
                throw;
            }
        }

        private void CloseSession(ReceivingAmqpLink link)
        {
            link.Session.SafeClose();
        }

        private IList<AmqpDescribed> CreateFilters()
        {
            List<AmqpDescribed> filterMap = null;

            if (EventPosition != null)
            {
                filterMap = new List<AmqpDescribed> { new AmqpSelectorFilter(EventPosition.GetExpression()) };
            }

            return filterMap;
        }

        private async Task ReceivePumpAsync(CancellationToken cancellationToken, bool invokeWhenNoEvents)
        {
            try
            {
                // Loop until pump is shutdown or an error is hit.
                while (!cancellationToken.IsCancellationRequested)
                {
                    IEnumerable<EventData> receivedEvents;

                    try
                    {
                        int batchSize;

                        lock (receivePumpLock)
                        {
                            if (receiveHandler == null)
                            {
                                // Pump has been shutdown, nothing more to do.
                                return;
                            }

                            batchSize = receiveHandler.MaxBatchSize > 0 ? receiveHandler.MaxBatchSize : ClientConstants.ReceiveHandlerDefaultBatchSize;
                        }

                        receivedEvents = await ReceiveAsync(batchSize).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        // Omit any failures at exception handling. Pump should continue until cancellation is triggered.
                        try
                        {
                            EventHubsEventSource.Log.ReceiveHandlerExitingWithError(ClientId, PartitionId, e.Message);
                            await ReceiveHandlerProcessErrorAsync(e).ConfigureAwait(false);

                            // Avoid tight loop if Receieve call keeps faling.
                            await Task.Delay(100, cancellationToken).ConfigureAwait(false);
                        }
                        catch { }

                        // ReceiverDisconnectedException is a special case where we know we cannot recover the pump.
                        if (e is ReceiverDisconnectedException)
                        {
                            break;
                        }

                        continue;
                    }

                    if (invokeWhenNoEvents || receivedEvents != null)
                    {
                        try
                        {
                            await ReceiveHandlerProcessEventsAsync(receivedEvents).ConfigureAwait(false);
                        }
                        catch (Exception userCodeError)
                        {
                            EventHubsEventSource.Log.ReceiveHandlerExitingWithError(ClientId, PartitionId, userCodeError.Message);
                            await ReceiveHandlerProcessErrorAsync(userCodeError).ConfigureAwait(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // This should never throw
                EventHubsEventSource.Log.ReceiveHandlerExitingWithError(ClientId, PartitionId, ex.Message);
                Environment.FailFast(ex.ToString());
            }
        }

        // Encapsulates taking the receivePumpLock, checking this.receiveHandler for null,
        // calls this.receiveHandler.CloseAsync (starting this operation inside the receivePumpLock).
        private Task ReceiveHandlerClose()
        {
            Task task = null;

            lock (receivePumpLock)
            {
                if (receiveHandler != null)
                {
                    if (receivePumpTask != null)
                    {
                        task = receivePumpTask;
                        receivePumpCancellationSource.Cancel();
                        receivePumpCancellationSource.Dispose();
                        receivePumpCancellationSource = null;
                        receivePumpTask = null;
                    }

                    receiveHandler = null;
                }
            }

            return task ?? Task.CompletedTask;
        }

        // Encapsulates taking the receivePumpLock, checking this.receiveHandler for null,
        // calls this.receiveHandler.ProcessErrorAsync (starting this operation inside the receivePumpLock).
        private Task ReceiveHandlerProcessErrorAsync(Exception error)
        {
            Task processErrorTask = null;
            lock (receivePumpLock)
            {
                if (receiveHandler != null)
                {
                    processErrorTask = receiveHandler.ProcessErrorAsync(error);
                }
            }

            return processErrorTask ?? Task.FromResult(0);
        }

        // Encapsulates taking the receivePumpLock, checking this.receiveHandler for null,
        // calls this.receiveHandler.ProcessErrorAsync (starting this operation inside the receivePumpLock).
        private Task ReceiveHandlerProcessEventsAsync(IEnumerable<EventData> eventDatas)
        {
            Task processEventsTask = null;

            lock (receivePumpLock)
            {
                if (receiveHandler != null)
                {
                    processEventsTask = receiveHandler.ProcessEventsAsync(eventDatas);
                }
            }

            return processEventsTask ?? Task.FromResult(0);
        }
    }
}
