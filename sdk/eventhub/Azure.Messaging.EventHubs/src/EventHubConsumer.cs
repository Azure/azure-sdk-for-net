// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   A consumer responsible for reading <see cref="EventData" /> from a specific Event Hub
    ///   partition and as a member of a specific consumer group.
    ///
    ///   A consumer may be exclusive, which asserts ownership over the partition for the consumer
    ///   group to ensure that only one consumer from that group is reading the from the partition.
    ///   These exclusive consumers are sometimes referred to as "Epoch Consumers."
    ///
    ///   A consumer may also be non-exclusive, allowing multiple consumers from the same consumer
    ///   group to be actively reading events from the partition.  These non-exclusive consumers are
    ///   sometimes referred to as "Non-Epoch Consumers."
    /// </summary>
    ///
    public class EventHubConsumer : IAsyncDisposable
    {
        /// <summary>The name of the default consumer group in the Event Hubs service.</summary>
        public const string DefaultConsumerGroupName = "$Default";

        /// <summary>The size of event batch requested by the background publishing operation used for subscriptions.</summary>
        private const int BackgroundPublishReceiveBatchSize = 50;

        /// <summary>The maximum wait time for receiving an event batch for the background publishing operation used for subscriptions.</summary>
        private readonly TimeSpan BackgroundPublishingWaitTime = TimeSpan.FromMilliseconds(250);

        /// <summary>The set of channels for publishing events to local subscribers.</summary>
        private readonly ConcurrentDictionary<Guid, Channel<EventData>> ActiveChannels = new ConcurrentDictionary<Guid, Channel<EventData>>();

        /// <summary>The primitive for synchronizing access during subscribe and unsubscribe operations.</summary>
        private readonly SemaphoreSlim ChannelSyncRoot = new SemaphoreSlim(1, 1);

        /// <summary>Indicates whether events are actively being published to subscribed channels.</summary>
        private bool _isPublishingActive = false;

        /// <summary>The cancellation token to use for requesting to cancel publishing events to the subscribed channels.</summary>
        private CancellationTokenSource _channelPublishingTokenSource;

        /// <summary>The <see cref="Task"/> associated with publishing events to subscribed channels.</summary>
        private Task _channelPublishingTask;

        /// <summary>The policy to use for determining retry behavior for when an operation fails.</summary>
        private EventHubRetryPolicy _retryPolicy;

        /// <summary>
        ///   The path of the specific Event Hub that the consumer is connected to, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubPath { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition that this consumer is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        public string PartitionId { get; }

        /// <summary>
        ///   The name of the consumer group that this consumer is associated with.  Events will be read
        ///   only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; }

        /// <summary>
        ///   When populated, the priority indicates that a consumer is intended to be the only reader of events for the
        ///   requested partition and an associated consumer group.  To do so, this consumer will attempt to assert ownership
        ///   over the partition; in the case where more than one exclusive consumer attempts to assert ownership for the same
        ///   partition/consumer group pair, the one having a larger ownership level value will "win."
        ///
        ///   When an exclusive consumer is used, those consumers which are not exclusive or which have a lower owner level will either
        ///   not be allowed to be created, if they already exist, will encounter an exception during the next attempted operation.
        /// </summary>
        ///
        /// <value>The priority to associated with an exclusive consumer; for a non-exclusive consumer, this value will be <c>null</c>.</value>
        ///
        public long? OwnerLevel { get; }

        /// <summary>
        ///   The position of the event in the partition where the consumer should begin reading.
        /// </summary>
        ///
        public EventPosition StartingPosition { get; }

        /// <summary>
        ///   The text-based identifier label that has optionally been assigned to the consumer.
        /// </summary>
        ///
        public string Identifier => Options?.Identifier;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        public EventHubRetryPolicy RetryPolicy
        {
            get => _retryPolicy;

            set
            {
                Guard.ArgumentNotNull(nameof(RetryPolicy), value);
                _retryPolicy = value;

                // Applying a custom retry policy invalidates the retry options specified.
                // Clear them to ensure the custom policy is propagated as the default.

                Options.RetryOptions = null;
                InnerConsumer.UpdateRetryPolicy(value);
            }
        }

        /// <summary>
        ///   The set of consumer options used for creation of this consumer.
        /// </summary>
        ///
        private EventHubConsumerOptions Options { get; }

        /// <summary>
        ///   An abstracted Event Hub consumer specific to the active protocol and transport intended to perform delegated operations.
        /// </summary>
        ///
        private TransportEventHubConsumer InnerConsumer { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumer"/> class.
        /// </summary>
        ///
        /// <param name="transportConsumer">An abstracted Event Consumer specific to the active protocol and transport intended to perform delegated operations.</param>
        /// <param name="eventHubPath">The path of the Event Hub from which events will be received.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition from which events will be received.</param>
        /// <param name="consumerGroup">The name of the consumer group this consumer is associated with.  Events are read in the context of this group.</param>
        /// <param name="eventPosition">The position within the partition where the consumer should begin reading events.</param>
        /// <param name="consumerOptions">The set of options to use for this consumer.</param>
        /// <param name="retryPolicy">The policy to apply when making retry decisions for failed operations.</param>
        ///
        /// <remarks>
        ///   If the starting event position is not specified in the <paramref name="consumerOptions"/>, the consumer will
        ///   default to ignoring events in the partition that were queued prior to the consumer being created and read only
        ///   events which appear after that point.
        ///
        ///   Because this is a non-public constructor, it is assumed that the <paramref name="consumerOptions" /> passed are
        ///   owned by this instance and are safe from changes made by consumers.  It is considered the responsibility of the
        ///   caller to ensure that any needed cloning of options is performed.
        /// </remarks>
        ///
        internal EventHubConsumer(TransportEventHubConsumer transportConsumer,
                                   string eventHubPath,
                                   string consumerGroup,
                                   string partitionId,
                                   EventPosition eventPosition,
                                   EventHubConsumerOptions consumerOptions,
                                   EventHubRetryPolicy retryPolicy)
        {
            Guard.ArgumentNotNull(nameof(transportConsumer), transportConsumer);
            Guard.ArgumentNotNullOrEmpty(nameof(eventHubPath), eventHubPath);
            Guard.ArgumentNotNullOrEmpty(nameof(consumerGroup), consumerGroup);
            Guard.ArgumentNotNullOrEmpty(nameof(partitionId), partitionId);
            Guard.ArgumentNotNull(nameof(eventPosition), eventPosition);
            Guard.ArgumentNotNull(nameof(consumerOptions), consumerOptions);
            Guard.ArgumentNotNull(nameof(retryPolicy), retryPolicy);

            EventHubPath = eventHubPath;
            PartitionId = partitionId;
            StartingPosition = eventPosition;
            OwnerLevel = consumerOptions.OwnerLevel;
            ConsumerGroup = consumerGroup;
            Options = consumerOptions;
            InnerConsumer = transportConsumer;

            _retryPolicy = retryPolicy;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubConsumer"/> class.
        /// </summary>
        ///
        protected EventHubConsumer()
        {
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
        public virtual Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                 TimeSpan? maximumWaitTime = default,
                                                                 CancellationToken cancellationToken = default)
        {
            maximumWaitTime = maximumWaitTime ?? Options.DefaultMaximumReceiveWaitTime;

            Guard.ArgumentInRange(nameof(maximumMessageCount), maximumMessageCount, 1, Int32.MaxValue);
            Guard.ArgumentNotNegative(nameof(maximumWaitTime), maximumWaitTime.Value);

            return InnerConsumer.ReceiveAsync(maximumMessageCount, maximumWaitTime.Value, cancellationToken);
        }

        /// <summary>
        ///   Subscribes to events for the associated partition in the form of an asynchronous enumerable that sends events as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   This version of the enumerator may block for an indeterminate amount of time for an <c>await</c> if events are not available
        ///   on the partition, requiring cancellation via the <paramref name="cancellationToken"/> to be requested in order to return control.
        ///   It is recommended to call the overload which accepts a maximum wait time for scenarios where a more deterministic wait period is
        ///   desired.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   Unlike calls to <see cref="ReceiveAsync"/>, each subscriber to events is presented with an independent iterator; if there are multiple
        ///   subscribers, they will each receive their own copy of an event to process, rather than competing for them.
        ///
        ///   Subscriptions will still compete with <see cref="ReceiveAsync" /> calls, however.  It is recommended that consumers either subscribe to
        ///   events or explicitly receive batches, but do not use both approaches concurrently.
        /// </remarks>
        ///
        /// <seealso cref="SubscribeToEvents(TimeSpan?, CancellationToken)"/>
        ///
        public virtual IAsyncEnumerable<EventData> SubscribeToEvents(CancellationToken cancellationToken = default) => SubscribeToEvents(null, cancellationToken);

        /// <summary>
        ///   Subscribes to events for the associated partition in the form of an asynchronous enumerable that sends events as they
        ///   become available on the partition, waiting as necessary should there be no events available.
        ///
        ///   If the <paramref name="maximumWaitTime" /> is passed, if no events were available before the wait time elapsed, an empty
        ///   item will be sent in the enumerable in order to return control and ensure that <c>await</c> calls do not block for an
        ///   indeterminate length of time.
        /// </summary>
        ///
        /// <param name="maximumWaitTime">The maximum amount of time to wait to for an event to be available before emitting an empty item; if <c>null</c>, empty items will not be published.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="IAsyncEnumerable{T}"/> to be used for iterating over events in the partition.</returns>
        ///
        /// <remarks>
        ///   Unlike calls to <see cref="ReceiveAsync"/>, each subscriber to events is presented with an independent iterator; if there are multiple
        ///   subscribers, they will each receive their own copy of an event to process, rather than competing for them.
        ///
        ///   Subscriptions will still compete with <see cref="ReceiveAsync" /> calls, however.  It is recommended that consumers either subscribe to
        ///   events or explicitly receive batches, but do not use both approaches concurrently.
        /// </remarks>
        ///
        /// <seealso cref="SubscribeToEvents(CancellationToken)"/>
        ///
        public virtual IAsyncEnumerable<EventData> SubscribeToEvents(TimeSpan? maximumWaitTime,
                                                                     CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return CreateEmptyAsyncEnumerable<EventData>();
            }

            try
            {
                var maximumQueuedEvents = Math.Min((Options.PrefetchCount / 4), (BackgroundPublishReceiveBatchSize * 2));
                var subscription = SubscribeToChannel(EventHubPath, PartitionId, ConsumerGroup, maximumQueuedEvents, cancellationToken);

                return new ChannelEnumerableSubscription<EventData>(subscription.ChannelReader, maximumWaitTime, () => UnsubscribeFromChannelAsync(subscription.Identifier), cancellationToken);
            }
            catch (Exception ex) when
                (ex is TaskCanceledException
                || ex is OperationCanceledException)
            {

                // This is unlikely, but possible if cancellation is triggered after the conditional, and
                // indicates that the synchronization primitive for subscriptions referenced the canceled token.

                return CreateEmptyAsyncEnumerable<EventData>();
            }
        }

        /// <summary>
        ///   Closes the consumer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual Task CloseAsync(CancellationToken cancellationToken = default) => InnerConsumer.CloseAsync(cancellationToken);

        /// <summary>
        ///   Closes the consumer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public virtual void Close(CancellationToken cancellationToken = default) => CloseAsync(cancellationToken).GetAwaiter().GetResult();

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="EventHubClient" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   Creates a subscription to events being published to the partition associated with
        ///   the consumer.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the event hub with the subscription; used for informational purposes only.</param>
        /// <param name="partitionId">The identifier for the partition to associate with the subscription; used for informational purposes only.</param>
        /// <param name="consumerGroup">The name of the consumer group to associate with the subscription; used for informational purposes only.</param>
        /// <param name="maximumQueuedEvents">The maximum number of events to queue while waiting for them to be read.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal the request to cancel the event enumeration.</param>
        ///
        /// <returns>The elements of a channel subscription, including its identifier and a reader for the subscribed channel.</returns>
        ///
        private (Guid Identifier, ChannelReader<EventData> ChannelReader) SubscribeToChannel(string eventHubName,
                                                                                             string partitionId,
                                                                                             string consumerGroup,
                                                                                             int maximumQueuedEvents,
                                                                                             CancellationToken cancellationToken)
        {
            var channel = CreateEventChannel(maximumQueuedEvents);
            var identifier = Guid.NewGuid();

            if (!ActiveChannels.TryAdd(identifier, channel))
            {
                throw new EventHubsException(true, eventHubName, String.Format(CultureInfo.CurrentCulture, Resources.FailedToCreateEventSubscription, eventHubName, partitionId, consumerGroup));
            }

            // Ensure that publishing is taking place.  To avoid race conditions, always acquire the semaphore and then perform the check.

            ChannelSyncRoot.Wait(cancellationToken);

            try
            {
                if (!_isPublishingActive)
                {
                    _channelPublishingTokenSource?.Cancel();
                    _channelPublishingTask?.GetAwaiter().GetResult();
                    _channelPublishingTokenSource?.Dispose();

                    _channelPublishingTokenSource = new CancellationTokenSource();
                    _channelPublishingTask = StartBackgroundChannelPublishingAsync(_channelPublishingTokenSource.Token);
                    _isPublishingActive = true;
                }
            }
            finally
            {
                ChannelSyncRoot.Release();
            }

            return (identifier, channel.Reader);
        }

        /// <summary>
        ///   Unsubscribe from a channel subscription.
        /// </summary>
        ///
        /// <param name="identifier">The identifier of the subscription to unsubscribe.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task UnsubscribeFromChannelAsync(Guid identifier)
        {
            if ((ActiveChannels.TryRemove(identifier, out var unsubscribeChannel)) && (ActiveChannels.Count == 0))
            {
                await ChannelSyncRoot.WaitAsync().ConfigureAwait(false);

                try
                {
                    // If the channel was the last active channel and publishing is still marked as active, take
                    // the necessary steps to stop publishing.

                    if ((_isPublishingActive) && (ActiveChannels.Count == 0))
                    {
                        _channelPublishingTokenSource?.Cancel();

                        if (_channelPublishingTask != null)
                        {
                            try
                            {
                                await _channelPublishingTask.ConfigureAwait(false);
                            }
                            catch (TaskCanceledException)
                            {
                               // This is an expected scenario; no action is needed.
                            }
                        }

                        _channelPublishingTokenSource?.Dispose();
                        _isPublishingActive = false;
                    }
                }
                finally
                {
                    ChannelSyncRoot.Release();
                }
            }

            // Attempt to finalize the channel, signaling that no more writes should be
            // expected to occur.

            unsubscribeChannel?.Writer.TryComplete();
        }

        /// <summary>
        ///   Begins the background process responsible for receiving from the partition
        ///   and publishing to all subscribed channels.
        /// </summary>
        ///
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to signal the request to cancel the background publishing.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private Task StartBackgroundChannelPublishingAsync(CancellationToken cancellationToken) =>
            Task.Run(async () =>
            {
                var failedAttemptCount = 0;
                var publishTasks = new List<Task>();
                var publishChannels = default(ICollection<Channel<EventData>>);
                var receivedItems = default(IEnumerable<EventData>);
                var retryDelay = default(TimeSpan?);
                var activeException = default(Exception);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        // Receive items in batches and then write them to the subscribed channels.  The channels will naturally
                        // block if they reach their maximum queue size, so there is no need to throttle publishing.

                        receivedItems = await InnerConsumer.ReceiveAsync(BackgroundPublishReceiveBatchSize, BackgroundPublishingWaitTime, cancellationToken).ConfigureAwait(false);
                        publishChannels = ActiveChannels.Values;

                        foreach (var item in receivedItems)
                        {
                            foreach (var channel in publishChannels)
                            {
                                publishTasks.Add(channel.Writer.WriteAsync(item, cancellationToken).AsTask());
                            }
                        }

                        await Task.WhenAll(publishTasks).ConfigureAwait(false);

                        publishTasks.Clear();
                        failedAttemptCount = 0;
                    }
                    catch (TaskCanceledException ex)
                    {
                        // In the case that a task was canceled, if cancellation was requested, then publishing should
                        // is already terminating.  Otherwise, something unexpected canceled the operation and it should
                        // be treated as an exception to ensure that the channels are marked final and consumers are made
                        // aware.

                        activeException = (cancellationToken.IsCancellationRequested) ? null : ex;
                        break;
                    }
                    catch (ConsumerDisconnectedException ex)
                    {
                        // If the consumer was disconnected, it is known to be unrecoverable; do not offer the chance to retry.

                        activeException = ex;
                        break;
                    }
                    catch (Exception ex) when
                        (ex is OutOfMemoryException
                        || ex is StackOverflowException
                        || ex is ThreadAbortException)
                    {
                        // These exceptions are known to be unrecoverable and there should be no attempts at further processing.
                        // The environment is in a bad state and is likely to fail.
                        //
                        // Attempt to clean up, which may or may not fail due to resource constraints,
                        // then let the exception bubble.

                        _isPublishingActive = false;

                        foreach (var channel in ActiveChannels.Values)
                        {
                            channel.Writer.TryComplete(ex);
                        }

                        throw;
                    }
                    catch (Exception ex)
                    {
                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, mark the exception as active and break out of the loop.

                        ++failedAttemptCount;
                        retryDelay = _retryPolicy.CalculateRetryDelay(ex, failedAttemptCount);

                        if (retryDelay.HasValue)
                        {
                            await Task.Delay(retryDelay.Value).ConfigureAwait(false);
                            activeException = null;
                        }
                        else
                        {
                            activeException = ex;
                            break;
                        }
                    }
                }

                // Publishing has terminated; if there was an active exception, then take the necessary steps to mark publishing as aborted rather
                // than completed normally.

                if (activeException != null)
                {
                    await AbortBackgroundChannelPublishingAsync(activeException).ConfigureAwait(false);
                }

            }, cancellationToken);

        /// <summary>
        ///   Creates a channel for publishing events to local subscribers.
        /// </summary>
        ///
        /// <param name="capacity">The maximum amount of events that can be queued in the channel.</param>
        ///
        /// <returns>A bounded channel, configured for 1:1 read/write usage.</returns>
        ///
        private Channel<EventData> CreateEventChannel(int capacity) =>
            Channel.CreateBounded<EventData>(new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait,
                SingleWriter = true,
                SingleReader = true
            });

        /// <summary>
        ///   Aborts the background channel publishing in the case of an exception that it was
        ///   unable to recover from.
        /// </summary>
        ///
        /// <param name="exception">The exception that triggered publishing to terminate.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        private async Task AbortBackgroundChannelPublishingAsync(Exception exception)
        {
            // Though state is normally managed through subscribe and unsubscribe, in the case of aborting,
            // forcefully clear the subscription and reset publishing state.

            await ChannelSyncRoot.WaitAsync().ConfigureAwait(false);

            try
            {
                foreach (var channel in ActiveChannels.Values)
                {
                    channel.Writer.TryComplete(exception);
                }

                ActiveChannels.Clear();
                _channelPublishingTokenSource.Dispose();
                _isPublishingActive = false;
            }
            finally
            {
                ChannelSyncRoot.Release();
            }
        }

        /// <summary>
        ///   Creates an empty <see cref="IAsyncEnumerable{T}" />.
        /// </summary>
        ///
        /// <typeparam name="T">The type of data represented by the empty enumerable.</typeparam>
        ///
        /// <returns>An empty asynchronous enumerable.</returns>
        ///
        private async IAsyncEnumerable<T> CreateEmptyAsyncEnumerable<T>()
        {
            await Task.Delay(0).ConfigureAwait(false);
            yield break;
        }
    }
}
