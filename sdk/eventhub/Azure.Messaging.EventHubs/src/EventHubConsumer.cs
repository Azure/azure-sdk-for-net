// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;

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

        /// <summary>The policy to use for determining retry behavior for when an operation fails.</summary>
        private EventHubRetryPolicy _retryPolicy;

        /// <summary>
        ///   The identifier of the Event Hub partition that this consumer is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        public string PartitionId { get; protected set; }

        /// <summary>
        ///   The name of the consumer group that this consumer is associated with.  Events will be read
        ///   only in the context of this group.
        /// </summary>
        ///
        public string ConsumerGroup { get; protected set; }

        /// <summary>
        ///   When populated, the priority indicates that a consumer is intended to be the only reader of events for the
        ///   requested partition and an associated consumer group.  To do so, this consumer will attempt to assert ownership
        ///   over the partition; in the case where more than one exclusive consumer attempts to assert ownership for the same
        ///   partition/consumer group pair, the one having a larger onwership level value will "win."
        ///
        ///   When an exclusive consumer is used, those consumers which are not exclusive or which have a lower owner level will either
        ///   not be allowed to be created, if they already exist, will encounter an exception during the next attempted operation.
        /// </summary>
        ///
        /// <value>The priority to associated with an exclusive consumer; for a non-exclusive consumer, this value will be <c>null</c>.</value>
        ///
        public long? OwnerLevel { get; protected set; }

        /// <summary>
        ///   The position of the event in the partition where the consumer should begin reading.
        /// </summary>
        ///
        public EventPosition StartingPosition { get; protected set; }

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
        ///   Receives a bach of <see cref="EventData" /> from the Event Hub partition.
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
    }
}
