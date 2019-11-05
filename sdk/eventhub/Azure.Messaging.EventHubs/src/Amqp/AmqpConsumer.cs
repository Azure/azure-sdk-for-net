// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Errors;
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
        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed = false;

        /// <summary>
        ///   Indicates whether or not this consumer has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the consumer is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool Closed => _closed;

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
        ///   The set of options which govern the behavior of this consumer instance.
        /// </summary>
        ///
        private EventHubConsumerClientOptions Options { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private EventHubRetryPolicy RetryPolicy { get; }

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
        /// <param name="consumerOptions">The set of active options for the consumer that will make use of the link.</param>
        /// <param name="eventPosition">The position of the event in the partition where the consumer should begin reading.</param>
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
                            EventPosition eventPosition,
                            EventHubConsumerClientOptions consumerOptions,
                            AmqpConnectionScope connectionScope,
                            AmqpMessageConverter messageConverter,
                            EventHubRetryPolicy retryPolicy)
        {
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNullOrEmpty(consumerGroup, nameof(consumerGroup));
            Argument.AssertNotNullOrEmpty(partitionId, nameof(partitionId));
            Argument.AssertNotNull(eventPosition, nameof(EventPosition));
            Argument.AssertNotNull(consumerOptions, nameof(EventHubConsumerClientOptions));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(messageConverter, nameof(messageConverter));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            EventHubName = eventHubName;
            ConsumerGroup = consumerGroup;
            PartitionId = partitionId;
            Options = consumerOptions;
            ConnectionScope = connectionScope;
            RetryPolicy = retryPolicy;
            MessageConverter = messageConverter;
            ReceiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(timeout => ConnectionScope.OpenConsumerLinkAsync(consumerGroup, partitionId, eventPosition, consumerOptions, timeout, CancellationToken.None), link => link.SafeClose());
        }

        /// <summary>
        ///   Receives a batch of <see cref="EventData" /> from the Event Hub partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to build up the requested message count for the batch; if not specified, the default wait time specified when the consumer was created will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="EventData" /> from the Event Hub partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public override async Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                        TimeSpan? maximumWaitTime,
                                                                        CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpConsumer));
            Argument.AssertAtLeast(maximumMessageCount, 1, nameof(maximumMessageCount));

            var receivedEventCount = 0;
            var failedAttemptCount = 0;
            var tryTimeout = RetryPolicy.CalculateTryTimeout(0);
            var waitTime = (maximumWaitTime ?? tryTimeout);
            var link = default(ReceivingAmqpLink);
            var retryDelay = default(TimeSpan?);
            var amqpMessages = default(IEnumerable<AmqpMessage>);
            var receivedEvents = default(List<EventData>);

            var stopWatch = Stopwatch.StartNew();

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        EventHubsEventSource.Log.EventReceiveStart(EventHubName, ConsumerGroup, PartitionId);

                        link = await ReceiveLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, tryTimeout)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        var messagesReceived = await Task.Factory.FromAsync
                        (
                            (callback, state) => link.BeginReceiveMessages(maximumMessageCount, waitTime, callback, state),
                            (asyncResult) => link.EndReceiveMessages(asyncResult, out amqpMessages),
                            TaskCreationOptions.RunContinuationsAsynchronously
                        ).ConfigureAwait(false);

                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // If event messages were received, then package them for consumption and
                        // return them.

                        if ((messagesReceived) && (amqpMessages != null))
                        {
                            receivedEvents ??= new List<EventData>();

                            foreach (AmqpMessage message in amqpMessages)
                            {
                                link.DisposeDelivery(message, true, AmqpConstants.AcceptedOutcome);
                                receivedEvents.Add(MessageConverter.CreateEventFromMessage(message));
                                message.Dispose();
                            }

                            receivedEventCount = receivedEvents.Count;

                            if ((Options.TrackLastEnqueuedEventInformation) && (receivedEventCount > 0))
                            {
                                LastReceivedEvent = receivedEvents[receivedEventCount - 1];
                            }

                            return receivedEvents;
                        }

                        // No events were available.

                        return Enumerable.Empty<EventData>();
                    }
                    catch (EventHubsTimeoutException)
                    {
                        // Because the timeout specified with the request is intended to be the maximum
                        // amount of time to wait for events, a timeout isn't considered an error condition,
                        // rather a sign that no events were available in the requested period.

                        return Enumerable.Empty<EventData>();
                    }
                    catch (AmqpException amqpException)
                    {
                        throw AmqpError.CreateExceptionForError(amqpException.Error, EventHubName);
                    }
                    catch (Exception ex)
                    {
                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, bubble the exception.

                        ++failedAttemptCount;
                        retryDelay = RetryPolicy.CalculateRetryDelay(ex, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed) && (!cancellationToken.IsCancellationRequested))
                        {
                            EventHubsEventSource.Log.EventReceiveError(EventHubName, ConsumerGroup, PartitionId, ex.Message);
                            await Task.Delay(UseMinimum(retryDelay.Value, waitTime.CalculateRemaining(stopWatch.Elapsed)), cancellationToken).ConfigureAwait(false);

                            tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
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
            catch (Exception ex)
            {
                EventHubsEventSource.Log.EventReceiveError(EventHubName, ConsumerGroup, PartitionId, ex.Message);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                EventHubsEventSource.Log.EventReceiveComplete(EventHubName, ConsumerGroup, PartitionId, receivedEventCount);
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

            _closed = true;

            var clientId = GetHashCode().ToString();
            var clientType = GetType();

            try
            {
                EventHubsEventSource.Log.ClientCloseStart(clientType, EventHubName, clientId);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (ReceiveLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await ReceiveLink.CloseAsync().ConfigureAwait(false);
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
        ///   Uses the minimum value of the two specified <see cref="TimeSpan" /> instances.
        /// </summary>
        ///
        /// <param name="firstOption">The first option to consider.</param>
        /// <param name="secondOption">The second option to consider.</param>
        ///
        /// <returns>The smaller of the two specified intervals.</returns>
        ///
        private static TimeSpan UseMinimum(TimeSpan firstOption,
                                           TimeSpan secondOption) => (firstOption < secondOption) ? firstOption : secondOption;
    }
}
