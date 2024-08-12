// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventProcessor{TPartition}" />
    ///   to configure its behavior.
    /// </summary>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples">Event Hubs event processor samples and discussion</seealso>
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

        /// <summary>The prefetch size limit to use for the partition receiver.</summary>
        private long? _prefetchSizeInBytes;

        /// <summary>The desired amount of time to allow between load balancing verification attempts.</summary>
        private TimeSpan _loadBalancingUpdateInterval = TimeSpan.FromSeconds(30);

        /// <summary>The desired amount of time to consider a partition owned by a specific event processor.</summary>
        private TimeSpan _partitionOwnershipExpirationInterval = TimeSpan.FromMinutes(2);

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
        ///   The maximum amount of time to wait for events to become available from a given partition before emitting
        ///   an empty batch of events.
        /// </summary>
        ///
        /// <value>
        ///   If <c>null</c>, the processor will wait indefinitely for a batch of events to become available and will not
        ///   dispatch them to be processed while waiting; otherwise, a batch will always be emitted within this interval, whether or not
        ///   it is empty.
        ///
        ///   The default wait time is <c>null</c>.
        /// </value>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested wait time is negative.</exception>
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
        ///   whether a read operation is currently active, intended to help maximize throughput by allowing events to be read from
        ///   from a local cache rather than waiting on a service request.
        /// </summary>
        ///
        /// <value>
        ///   The <see cref="PrefetchCount" /> is a control that developers can use to help tune performance for the specific
        ///   needs of an application, given its expected size of events, throughput needs, and expected scenarios for using
        ///   Event Hubs.
        ///
        ///   The default prefetch count is 300.
        /// </value>
        ///
        /// <remarks>
        ///   The size of the prefetch count has an influence on the efficiency of reading events from the Event Hubs service.  The
        ///   larger the size of the cache, the more efficiently service operations can be buffered in the background to
        ///   improve throughput.  This comes at the cost of additional memory use and potentially increases network I/O.
        ///
        ///   For scenarios where the size of events is small and many events are flowing through the system, requesting more
        ///   events in a batch and using a higher <see cref="PrefetchCount" /> may help improve throughput.  For scenarios where
        ///   the size of events is larger or when processing of events is expected to be a heavier and slower operation, requesting
        ///   fewer events in a batch and using a smaller <see cref="PrefetchCount"/> may help manage resource use without
        ///   incurring a non-trivial cost to throughput.
        ///
        ///   Regardless of the values, it is generally recommended that the <see cref="PrefetchCount" /> be at least 2-3
        ///   times as large as the number of events in a batch to allow for efficient buffering of service operations.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested count is negative.</exception>
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
        ///   The desired number of bytes to attempt to eagerly request from the Event Hubs service and queued locally without regard to
        ///   whether a read operation is currently active, intended to help maximize throughput by allowing events to be read from
        ///   from a local cache rather than waiting on a service request.
        /// </summary>
        ///
        /// <value>
        ///   <para>When set to <c>null</c>, the option is considered disabled; otherwise, it will be considered enabled and take
        ///   precedence over any value specified for the <see cref="PrefetchCount" />The <see cref="PrefetchSizeInBytes" /> is an
        ///   advanced control that developers can use to help tune performance in some scenarios; it is recommended to prefer using
        ///   the <see cref="PrefetchCount" /> over this option where possible for more accurate control and more predictable throughput.</para>
        ///
        ///   <para>This size should be considered a statement of intent rather than a guaranteed limit; the local cache may be larger or
        ///   smaller than the number of bytes specified, and will always contain at least one event when the <see cref="PrefetchSizeInBytes" />
        ///   is specified.  A heuristic is used to predict the average event size to use for size calculations, which should be expected to fluctuate
        ///   as traffic passes through the system.  Consequently, the resulting resource use will fluctuate as well.</para>
        ///
        ///   <para>This option is disabled by default with the value set to <c>null</c>.</para>
        /// </value>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested size is negative.</exception>
        ///
        public long? PrefetchSizeInBytes
        {
            get => _prefetchSizeInBytes;

            set
            {
                if (value.HasValue)
                {
                    Argument.AssertAtLeast(value.Value, 0, nameof(PrefetchSizeInBytes));
                }
                _prefetchSizeInBytes = value;
            }
        }

        /// <summary>
        ///   The desired amount of time to allow between load balancing verification attempts.
        /// </summary>
        ///
        /// <value>The default load balancing interval is 30 seconds.</value>
        ///
        /// <remarks>
        ///   Because load balancing holds less priority than processing events, this interval
        ///   should be considered the minimum time that will elapse between verification attempts; operations
        ///   with higher priority may cause a delay longer than this interval for load balancing.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested interval is negative.</exception>
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
        ///   instance before the ownership is considered stale and the partition becomes eligible to be
        ///   requested by another event processor that wishes to assume responsibility for processing it.
        /// </summary>
        ///
        /// <value>The default ownership interval is 2 minutes.</value>
        ///
        /// <remarks>
        ///   As a general guideline, it is advised that this value be greater than the configured
        ///   <see cref="LoadBalancingUpdateInterval" /> by at least a factor of two. It is recommended that
        ///   this be a factor of three or more, unless there are application scenarios that require more
        ///   aggressive ownership expiration.
        /// </remarks>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested interval is negative.</exception>
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
        /// <value>If not specified, a random unique identifier will be generated.</value>
        ///
        /// <remarks>
        ///   It is recommended that you set a stable unique identifier for processor instances, as this allows
        ///   the processor to recover partition ownership when an application or host instance is restarted.  It
        ///   also aids readability in Azure SDK logs and allows for more easily correlating logs to a specific
        ///   processor instance.
        /// </remarks>
        ///
        public string Identifier { get; set; }

        /// <summary>
        ///   Indicates whether or not the processor should request information on the last enqueued event on the partition
        ///   associated with a given event, and track that information as events are received.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if information about a partition's last event should be requested and tracked; otherwise, <c>false</c>.  The
        ///   default value is <c>true</c>.
        /// </value>
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
        ///
        ///   The default starting position is <see cref="EventPosition.Earliest" />.
        /// </remarks>
        ///
        /// <seealso cref="EventProcessor{TPartition}.ListCheckpointsAsync"/>
        ///
        public EventPosition DefaultStartingPosition { get; set; } = EventPosition.Earliest;

        /// <summary>
        ///   The strategy that an event processor will use to make decisions about
        ///   partition ownership when performing load balancing to share work with
        ///   other event processors.
        /// </summary>
        ///
        /// <value>The default strategy is <see cref="LoadBalancingStrategy.Greedy" />.</value>
        ///
        /// <seealso cref="Processor.LoadBalancingStrategy" />
        ///
        public LoadBalancingStrategy LoadBalancingStrategy { get; set; } = LoadBalancingStrategy.Greedy;

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
                _prefetchSizeInBytes = PrefetchSizeInBytes,
                _maximumWaitTime = MaximumWaitTime,
                _loadBalancingUpdateInterval = LoadBalancingUpdateInterval,
                _partitionOwnershipExpirationInterval = PartitionOwnershipExpirationInterval,
                Identifier = Identifier,
                TrackLastEnqueuedEventProperties = TrackLastEnqueuedEventProperties,
                DefaultStartingPosition = DefaultStartingPosition,
                LoadBalancingStrategy = LoadBalancingStrategy
            };
    }
}
