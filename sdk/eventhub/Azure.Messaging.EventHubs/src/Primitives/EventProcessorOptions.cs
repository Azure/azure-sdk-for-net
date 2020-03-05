﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventProcessor{TPartition}" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventProcessorOptions
    {
        /// <summary>The set of options to use for configuring the connection to the Event Hubs service.</summary>
        private EventHubConnectionOptions _connectionOptions = new EventHubConnectionOptions();

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private EventHubsRetryOptions _retryOptions = new EventHubsRetryOptions();

        /// <summary>The maximum amount of time to wait for a batch of events to become available before emitting an empty batch.</summary>
        private TimeSpan? _maximumWaitTime = TimeSpan.FromSeconds(60);

        /// <summary>The prefetch count to use for the event processor.</summary>
        private int _prefetchCount = 300;

        /// <summary>The desired amount of time to allow between load balancing verification attempts.</summary>
        private TimeSpan _loadBalancingUpdateInterval = TimeSpan.FromSeconds(10);

        /// <summary>The desired amount of time to consider a partition owned by a specific event processor.</summary>
        private TimeSpan _partitionOwnershipExpirationInterval = TimeSpan.FromSeconds(30);

        /// <summary>
        ///   The options used for configuring the connection to the Event Hubs service.
        /// </summary>
        ///
        public EventHubConnectionOptions ConnectionOptions
        {
            get => _connectionOptions;

            set
            {
                Argument.AssertNotNull(value, nameof(ConnectionOptions));
                _connectionOptions = value;
            }
        }

        /// <summary>
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.  These options also control the
        ///   amount of time allowed for receiving event batches and other interactions with the Event Hubs service.
        /// </summary>
        ///
        public EventHubsRetryOptions RetryOptions
        {
            get => _retryOptions;

            set
            {
                Argument.AssertNotNull(value, nameof(RetryOptions));
                _retryOptions = value;
            }
        }

        /// <summary>
        ///   The maximum amount of time to wait for an event to become available for a given partition before emitting
        ///   an empty batch of events.
        /// </summary>
        ///
        /// <value>
        ///   If <c>null</c>, the processor will wait indefinitely for a batch of events to become available and will not
        ///   dispatch them to be processed while waiting; otherwise, a batch will always be emitted within this interval, whether or not
        ///   it is empty.
        /// </value>
        ///
        public TimeSpan? MaximumWaitTime
        {
            get => _maximumWaitTime;

            set
            {
                if (value.HasValue)
                {
                    Argument.AssertNotNegative(value.Value, nameof(MaximumWaitTime));
                }

                _maximumWaitTime = value;
            }
        }

        /// <summary>
        ///   The number of events that will be eagerly requested from the Event Hubs service and queued locally without regard to
        ///   whether a processing is currently active, intended to help maximize throughput by allowing the event processor to read
        ///   from a local cache rather than waiting on a service request.
        /// </summary>
        ///
        /// <value>
        ///   The <see cref="PrefetchCount" /> is a control that developers can use to help tune performance for the specific
        ///   needs of an application, given its expected size of events, throughput needs, and expected scenarios for using
        ///   Event Hubs.
        /// </value>
        ///
        public int PrefetchCount
        {
            get => _prefetchCount;

            set
            {
                Argument.AssertAtLeast(value, 0, nameof(PrefetchCount));
                _prefetchCount = value;
            }
        }

        /// <summary>
        ///   The desired amount of time to allow between load balancing verification attempts.
        /// </summary>
        ///
        /// <remarks>
        ///   Because load balancing holds less priority than processing events, this interval
        ///   should be considered the minimum time that will elapse between verification attempts; operations
        ///   with higher priority may cause a minor delay longer than this interval for load balancing.
        /// </remarks>
        ///
        public TimeSpan LoadBalancingUpdateInterval
        {
            get => _loadBalancingUpdateInterval;

            set
            {
                Argument.AssertNotNegative(value, nameof(LoadBalancingUpdateInterval));
                _loadBalancingUpdateInterval = value;
            }
        }

        /// <summary>
        ///   The desired amount of time to consider a partition owned by a specific event processor
        ///   instance before the ownership is considered stale and the partition eligible to be requested
        ///   by another event processor that wishes to assume responsibility for processing it.
        /// </summary>
        ///
        public TimeSpan PartitionOwnershipExpirationInterval
        {
            get => _partitionOwnershipExpirationInterval;

            set
            {
                Argument.AssertNotNegative(value, nameof(PartitionOwnershipExpirationInterval));
                _partitionOwnershipExpirationInterval = value;
            }
        }

        /// <summary>
        ///   A unique name used to identify the event processor.  If <c>null</c> or empty, a GUID will be used as the
        ///   identifier.
        /// </summary>
        ///
        public string Identifier { get; set; }

        /// <summary>
        ///   Indicates whether or not the processor should request information on the last enqueued event on the partition
        ///   associated with a given event, and track that information as events are received.
        /// </summary>
        ///
        /// <value><c>true</c> if information about a partition's last event should be requested and tracked; otherwise, <c>false</c>.</value>
        ///
        /// <remarks>
        ///   When information about a partition's last enqueued event is being tracked, each event received from the Event Hubs
        ///   service will carry metadata about the partition that it otherwise would not. This results in a small amount of
        ///   additional network bandwidth consumption that is generally a favorable trade-off when considered
        ///   against periodically making requests for partition properties using one of the Event Hub clients.
        /// </remarks>
        ///
        public bool TrackLastEnqueuedEventProperties { get; set; } = true;

        /// <summary>
        ///   The position within a partition where the event processor should
        ///   begin reading events when no checkpoint can be found.
        /// </summary>
        ///
        /// <remarks>
        ///   In the event that a custom starting point is desired for a single partition, or each partition should start at a unique place,
        ///   it is recommended that those values be returned by the <see cref="EventProcessor{TPartition}.ListCheckpointsAsync"/> method as
        ///   if they were previously saved checkpoints.
        /// </remarks>
        ///
        /// <seealso cref="EventProcessor{TPartition}.ListCheckpointsAsync"/>
        ///
        public EventPosition DefaultStartingPosition { get; set; } = EventPosition.Earliest;

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
        ///   Creates a new copy of the current <see cref="EventProcessorOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventProcessorOptions" />.</returns>
        ///
        internal EventProcessorOptions Clone() =>
            new EventProcessorOptions
            {
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone(),
                _prefetchCount = PrefetchCount,
                _maximumWaitTime = MaximumWaitTime,
                _loadBalancingUpdateInterval = LoadBalancingUpdateInterval,
                _partitionOwnershipExpirationInterval = PartitionOwnershipExpirationInterval,
                Identifier = Identifier,
                TrackLastEnqueuedEventProperties = TrackLastEnqueuedEventProperties,
                DefaultStartingPosition = DefaultStartingPosition
            };
    }
}
