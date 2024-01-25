// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   A transport client abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="EventHubConsumerClient" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.EventHubs.Core.TransportConsumer" />
    ///
    internal class AmqpConsumer : TransportConsumer
    {
        /// <summary>The default prefetch count to use for the consumer.</summary>
        private const uint DefaultPrefetchCount = 300;

        /// <summary>An empty set of events which can be dispatched when no events are available.</summary>
        private static readonly IReadOnlyList<EventData> EmptyEventSet = Array.Empty<EventData>();

        /// <summary>The interval that an attempt to receive events should wait for additional events when less than the requested count was available.</summary>
        private static readonly TimeSpan ReceiveBuildBatchInterval = TimeSpan.FromMilliseconds(20);

        /// <summary>A captured exception that indicates the partition was stolen by another consumer; this should be surfaced when an attempt is made to open a consumer link.</summary>
        private volatile Exception _activePartitionStolenException;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

        /// <summary>
        ///   Indicates whether or not this consumer has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the consumer is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool IsClosed => _closed;

        /// <summary>
        ///   The name of the Event Hub to which the client is bound.
        /// </summary>
        ///
        private string EventHubName { get; }

        /// <summary>
        ///   The name of the consumer group that this consumer is associated with.  Events will be read
        ///   only in the context of this group.
        /// </summary>
        ///
        private string ConsumerGroup { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition that this consumer is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        private string PartitionId { get; }

        /// <summary>
        ///   A unique name used to identify this consumer.
        /// </summary>
        ///
        public string Identifier { get; }

        /// <summary>
        ///   The current position for the consumer, updated as events are received from the
        ///   partition.
        /// </summary>
        ///
        /// <remarks>
        ///   When creating or recovering the associated AMQP link, this value is used
        ///   to set the position.  It is intended to primarily support recreating links
        ///   transparently to callers, allowing progress in the stream to be remembered.
        /// </remarks>
        ///
        private EventPosition CurrentEventPosition { get; set; }

        /// <summary>
        ///   Indicates whether or not the consumer should request information on the last enqueued event on the partition
        ///   associated with a given event, and track that information as events are received.
        /// </summary>
        ///
        /// <value><c>true</c> if information about a partition's last event should be requested and tracked; otherwise, <c>false</c>.</value>
        ///
        private bool TrackLastEnqueuedEventProperties { get; }

        /// <summary>
        ///   Indicates whether or not the consumer should consider itself invalid when a partition is stolen.  If set,
        ///   an observed exception indicating that the partition was stolen will be captured and surfaced when any
        ///   operation is requested.
        /// </summary>
        ///
        /// <value><c>true</c> if the consumer is considered invalid after a partition is stolen; otherwise, <c>false</c>.</value>
        ///
        private bool InvalidateConsumerWhenPartitionStolen { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The converter to use for translating between AMQP messages and client library
        ///   types.
        /// </summary>
        ///
        private AmqpMessageConverter MessageConverter { get; }

        /// <summary>
        ///   The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private AmqpConnectionScope ConnectionScope { get; }

        /// <summary>
        ///   The AMQP link intended for use with receiving operations.
        /// </summary>
        ///
        private FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLink { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpConsumer"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub from which events will be consumed.</param>
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="consumerIdentifier">The identifier to associate with the consumer; if <c>null</c> or <see cref="string.Empty" />, a random identifier will be generated.</param>
        /// <param name="eventPosition">The position of the event in the partition where the consumer should begin reading.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="prefetchSizeInBytes">The cache size of the prefetch queue. When set, the link makes a best effort to ensure prefetched messages fit into the specified size.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether information on the last enqueued event on the partition is sent as events are received.</param>
        /// <param name="invalidateConsumerWhenPartitionStolen">Indicates whether or not the consumer should consider itself invalid when a partition is stolen.</param>
        /// <param name="connectionScope">The AMQP connection context for operations .</param>
        /// <param name="messageConverter">The converter to use for translating between AMQP messages and client types.</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        public AmqpConsumer(string eventHubName,
                            string consumerGroup,
                            string partitionId,
                            string consumerIdentifier,
                            EventPosition eventPosition,
                            bool trackLastEnqueuedEventProperties,
                            bool invalidateConsumerWhenPartitionStolen,
                            long? ownerLevel,
                            uint? prefetchCount,
                            long? prefetchSizeInBytes,
                            AmqpConnectionScope connectionScope,
                            AmqpMessageConverter messageConverter,
                            EventHubsRetryPolicy retryPolicy)
        {
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(messageConverter, nameof(messageConverter));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            if (string.IsNullOrEmpty(consumerIdentifier))
            {
                consumerIdentifier = Guid.NewGuid().ToString();
            }

            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
            Identifier = consumerIdentifier;
            CurrentEventPosition = eventPosition;
            TrackLastEnqueuedEventProperties = trackLastEnqueuedEventProperties;
            InvalidateConsumerWhenPartitionStolen = invalidateConsumerWhenPartitionStolen;
            ConnectionScope = connectionScope;
            RetryPolicy = retryPolicy;
            MessageConverter = messageConverter;

            ReceiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(
                timeout =>
                   CreateConsumerLinkAsync(
                        consumerGroup,
                        partitionId,
                        consumerIdentifier,
                        CurrentEventPosition,
                        prefetchCount ?? DefaultPrefetchCount,
                        prefetchSizeInBytes,
                        ownerLevel,
                        trackLastEnqueuedEventProperties,
                        timeout,
                        CancellationToken.None),
                CloseConsumerLink);
        }

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition.
        /// </summary>
        ///
        /// <param name="maximumEventCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait for events to become available, if no events can be read from the prefetch queue.  If not specified, the per-try timeout specified by the retry policy will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this consumer is associated with.  If no events are present, an empty set is returned.</returns>
        ///
        /// <remarks>
        ///   When events are available in the prefetch queue, they will be used to form the batch as quickly as possible without waiting for additional events from the
        ///   Event Hubs service to try and meet the requested <paramref name="maximumEventCount" />.  When no events are available in prefetch, the receiver will wait up
        ///   to the <paramref name="maximumWaitTime"/> for events to be read from the service.  Once any events are available, they will be used to form the batch immediately.
        /// </remarks>
        ///
        public override async Task<IReadOnlyList<EventData>> ReceiveAsync(int maximumEventCount,
                                                                          TimeSpan? maximumWaitTime,
                                                                          CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpConsumer));
            Argument.AssertNotClosed(ConnectionScope.IsDisposed, nameof(EventHubConnection));
            Argument.AssertAtLeast(maximumEventCount, 1, nameof(maximumEventCount));

            var receivedEventCount = 0;
            var failedAttemptCount = 0;
            var tryTimeout = RetryPolicy.CalculateTryTimeout(0);
            var waitTime = (maximumWaitTime ?? tryTimeout);
            var operationId = Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture);
            var link = default(ReceivingAmqpLink);
            var retryDelay = default(TimeSpan?);
            var receivedEvents = default(List<EventData>);
            var firstReceivedEvent = default(EventData);
            var lastReceivedEvent = default(EventData);

            var stopWatch = ValueStopwatch.StartNew();

            try
            {
                while ((!cancellationToken.IsCancellationRequested) && (!_closed))
                {
                    try
                    {
                        // Creation of the link happens without explicit knowledge of the cancellation token
                        // used for this operation; validate the token state before attempting link creation and
                        // again after the operation completes to provide best efforts in respecting it.

                        EventHubsEventSource.Log.EventReceiveStart(EventHubName, ConsumerGroup, PartitionId, operationId);

                        if (!ReceiveLink.TryGetOpenedObject(out link))
                        {
                            link = await ReceiveLink.GetOrCreateAsync(tryTimeout, cancellationToken).ConfigureAwait(false);
                        }

                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                        var messagesReceived = await link.ReceiveMessagesAsync(maximumEventCount, ReceiveBuildBatchInterval, waitTime, cancellationToken).ConfigureAwait(false);

                        // If no messages were received, then just return the empty set.

                        if (messagesReceived == null)
                        {
                            return EmptyEventSet;
                        }

                        // If event messages were received, then package them for consumption and
                        // return them.

                        foreach (AmqpMessage message in messagesReceived)
                        {
                            receivedEvents ??= new List<EventData>();

                            link.DisposeDelivery(message, true, AmqpConstants.AcceptedOutcome);
                            receivedEvents.Add(MessageConverter.CreateEventFromMessage(message));
                            message.Dispose();

                            receivedEventCount = receivedEvents.Count;
                        }

                        if (receivedEventCount > 0)
                        {
                            firstReceivedEvent = receivedEvents[0];
                            lastReceivedEvent = receivedEvents[receivedEventCount - 1];

                            if (lastReceivedEvent.Offset > long.MinValue)
                            {
                                CurrentEventPosition = EventPosition.FromOffset(lastReceivedEvent.Offset, false);
                            }

                            if (TrackLastEnqueuedEventProperties)
                            {
                                LastReceivedEvent = lastReceivedEvent;
                            }
                        }

                        return receivedEvents ?? EmptyEventSet;
                    }
                    catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ServiceTimeout)
                    {
                        // Because the timeout specified with the request is intended to be the maximum
                        // amount of time to wait for events, a timeout isn't considered an error condition,
                        // rather a sign that no events were available in the requested period.

                        return EmptyEventSet;
                    }
                    catch (Exception ex)
                    {
                        Exception activeEx = ex.TranslateServiceException(EventHubName);

                        // If the partition was stolen determine the correct action to take for
                        // capturing it with respect to whether the consumer should be invalidated.
                        //
                        // In either case, it is a terminal exception and will not trigger a retry;
                        // allow the normal error handling flow to surface the exception.

                        if (ex.IsConsumerPartitionStolenException())
                        {
                             // If the consumer should be invalidated, capture the exception
                             // and force-close the link.  This will ensure that the next operation
                             // will surface it.

                            if (InvalidateConsumerWhenPartitionStolen)
                            {
                                _activePartitionStolenException = ex;
                                CloseConsumerLink(link);
                            }
                            else
                            {
                                // If the consumer should not be invalidated, clear any previously captured exception to avoid
                                // surfacing the failure multiple times.  If the link is stolen after this operation, it will
                                // be intercepted and handled as needed.

                                _activePartitionStolenException = null;
                            }
                        }

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, bubble the exception.

                        ++failedAttemptCount;
                        retryDelay = RetryPolicy.CalculateRetryDelay(activeEx, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed) && (!_closed) && (!cancellationToken.IsCancellationRequested))
                        {
                            EventHubsEventSource.Log.EventReceiveError(EventHubName, ConsumerGroup, PartitionId, operationId, activeEx.Message);
                            await Task.Delay(waitTime.CalculateRemaining(stopWatch.GetElapsedTime()), cancellationToken).ConfigureAwait(false);

                            tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
                        }
                        else if (ex is AmqpException)
                        {
                            ExceptionDispatchInfo.Capture(activeEx).Throw();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                // If no value has been returned nor exception thrown by this point,
                // then cancellation has been requested.

                throw new TaskCanceledException();
            }
            catch (TaskCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.EventReceiveError(EventHubName, ConsumerGroup, PartitionId, operationId, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.EventReceiveComplete(
                    EventHubName,
                    ConsumerGroup,
                    PartitionId,
                    operationId,
                    failedAttemptCount,
                    receivedEventCount,
                    stopWatch.GetElapsedTime().TotalSeconds,
                    firstReceivedEvent?.SequenceNumber.ToString(),
                    LastReceivedEvent?.SequenceNumber.ToString(),
                    maximumEventCount,
                    waitTime.TotalSeconds);
            }
        }

        /// <summary>
        ///   Closes the connection to the transport consumer instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override async Task CloseAsync(CancellationToken cancellationToken)
        {
            if (_closed)
            {
                return;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            _closed = true;

            var clientId = GetHashCode().ToString(CultureInfo.InvariantCulture);
            var clientType = GetType().Name;

            try
            {
                EventHubsEventSource.Log.ClientCloseStart(clientType, EventHubName, clientId);

                if (ReceiveLink?.TryGetOpenedObject(out var _) == true)
                {
                    await ReceiveLink.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }

                ReceiveLink?.Dispose();
            }
            catch (Exception ex)
            {
                _closed = false;
                EventHubsEventSource.Log.ClientCloseError(clientType, EventHubName, clientId, ex.Message);

                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(clientType, EventHubName, clientId);
            }
        }

        /// <summary>
        ///   Creates the AMQP link to be used for consumer-related operations.
        /// </summary>
        ///
        /// <param name="consumerGroup">The consumer group of the Event Hub to which the link is bound.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition to which the link is bound.</param>
        /// <param name="consumerIdentifier">The identifier associated with the consumer.</param>
        /// <param name="eventStartingPosition">The place within the partition's event stream to begin consuming events.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.</param>
        /// <param name="prefetchSizeInBytes">The cache size of the prefetch queue. When set, the link makes a best effort to ensure prefetched messages fit into the specified size.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="trackLastEnqueuedEventProperties">Indicates whether information on the last enqueued event on the partition is sent as events are received.</param>
        /// <param name="timeout">The timeout to apply for creating the link.</param>
        /// <param name="cancellationToken">The cancellation token to consider when creating the link.</param>
        ///
        /// <returns>The AMQP link to use for consumer-related operations.</returns>
        ///
        protected async Task<ReceivingAmqpLink> CreateConsumerLinkAsync(string consumerGroup,
                                                                        string partitionId,
                                                                        string consumerIdentifier,
                                                                        EventPosition eventStartingPosition,
                                                                        uint prefetchCount,
                                                                        long? prefetchSizeInBytes,
                                                                        long? ownerLevel,
                                                                        bool trackLastEnqueuedEventProperties,
                                                                        TimeSpan timeout,
                                                                        CancellationToken cancellationToken)
        {
            // Determine if there is an active is an active exception that needs to be surfaced,
            // do so now.
            //
            // Note that this is a benign race; it is possible that multiple threads
            // will observe the active exception and surface it, even if the consumer is not
            // considered invalid.  This is reasonable behavior for this scenario as the underlying
            // condition is itself a race condition between multiple consumers.

            var activeException = _activePartitionStolenException;

            if (activeException != null)
            {
                // If the consumer should not be considered invalid, clear the active exception if
                // it hasn't already been reset.

                if (!InvalidateConsumerWhenPartitionStolen)
                {
                    Interlocked.CompareExchange(ref _activePartitionStolenException, null, activeException);
                }

                EventHubsEventSource.Log.AmqpConsumerLinkCreateCapturedErrorThrow(EventHubName, consumerGroup, partitionId, ownerLevel?.ToString(CultureInfo.InvariantCulture), eventStartingPosition.ToString(), activeException.Message);
                ExceptionDispatchInfo.Capture(activeException).Throw();
            }

            // Create and open the consumer link.

            var link = default(ReceivingAmqpLink);
            var tryTimeout = RetryPolicy.CalculateTryTimeout(0);

            try
            {
                link = await ConnectionScope.OpenConsumerLinkAsync(
                    consumerGroup,
                    partitionId,
                    eventStartingPosition,
                    tryTimeout,
                    timeout,
                    prefetchCount,
                    prefetchSizeInBytes,
                    ownerLevel,
                    trackLastEnqueuedEventProperties,
                    consumerIdentifier,
                    cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex.TranslateConnectionCloseDuringLinkCreationException(EventHubName)).Throw();
            }

            return link;
        }

        /// <summary>
        ///   Closes the AMQP link used by the consumer, capturing the passive terminal exception that triggered
        ///   closing if it should be surfaced during the next requested operation.
        /// </summary>
        ///
        protected void CloseConsumerLink(ReceivingAmqpLink link)
        {
            // If there is no link, then no action needs to be
            // taken.

            if (link == null)
            {
                return;
            }

            // If the consumer is being closed, the sentinel variable will already be set, and
            // the terminal exception need not be considered.

            if (!_closed)
            {
                var linkException = GetTerminalException(link);

                // If the terminal exception indicates that the partition was stolen from the consumer,
                // capture it so that it can be surfaced when the next operation is requested.

                if (linkException.IsConsumerPartitionStolenException())
                {
                    EventHubsEventSource.Log.AmqpConsumerLinkFaultCapture(EventHubName, ConsumerGroup, PartitionId, linkException.Message);
                    _activePartitionStolenException = linkException;
                }
            }

            // Close the link and it's associated session.

            link.Session?.SafeClose();
            link.SafeClose();

            EventHubsEventSource.Log.FaultTolerantAmqpObjectClose(nameof(ReceivingAmqpLink), "", EventHubName, ConsumerGroup, PartitionId, link.TerminalException?.Message);
        }

        /// <summary>
        ///   Gets the terminal exception that caused link closure.
        /// </summary>
        ///
        /// <param name="link">The link to inspect for a terminal exception.</param>
        ///
        /// <returns>The terminal exception, if one was captured; otherwise, <c>null</c>.</returns>
        ///
        protected virtual Exception GetTerminalException(ReceivingAmqpLink link) =>
            link switch
            {
                null => null,
                _ => link.TerminalException
            };
    }
}
