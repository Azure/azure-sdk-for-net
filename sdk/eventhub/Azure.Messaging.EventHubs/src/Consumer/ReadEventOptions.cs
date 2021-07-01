// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Consumer
{
    /// <summary>
    ///   The set of options that can be specified to configure behavior when reading events from an
    ///   <see cref="EventHubConsumerClient" />.
    /// </summary>
    ///
    public class ReadEventOptions
    {
        /// <summary>The maximum amount of time to wait to for an event to be available before emitting an empty item; if <c>null</c>, empty items will not be emitted.</summary>
        private TimeSpan? _maximumWaitTime;

        /// <summary>The event catch count to use when reading events.</summary>
        private int _cacheEventCount = 100;

        /// <summary>The prefetch count to use when reading events.</summary>
        private int _prefetchCount = 300;

        /// <summary>The prefetch size limit to use for the partition receiver.</summary>
        private long? _prefetchSizeInBytes;

        /// <summary>
        ///   When populated, the owner level indicates that a reading is intended to be performed exclusively for events in the
        ///   requested partition and for the associated consumer group.  To do so, reading will attempt to assert ownership
        ///   over the partition; in the case where more than one exclusive reader in the consumer group attempts to assert ownership
        ///   for the same partition, the one having a larger <see cref="OwnerLevel"/> value will "win".
        ///
        ///   <para>When an exclusive reader is used, other readers which are non-exclusive or which have a lower owner level will either
        ///   not be allowed to be created, if they already exist, will encounter an exception during the next attempted operation.</para>
        /// </summary>
        ///
        /// <value>The relative priority to associate with an exclusive reader; for a non-exclusive reader, this value should be <c>null</c>.</value>
        ///
        /// <remarks>
        ///   An <see cref="EventHubsException"/> will occur if an <see cref="EventHubConsumerClient"/> is unable to read events from the
        ///   requested Event Hub partition for the given consumer group.  In this case, the <see cref="EventHubsException.FailureReason"/>
        ///   will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </remarks>
        ///
        /// <seealso cref="EventHubsException"/>
        /// <seealso cref="EventHubsException.FailureReason.ConsumerDisconnected"/>
        ///
        public long? OwnerLevel { get; set; }

        /// <summary>
        ///   Indicates whether or not the reader should request information on the last enqueued event on the partition
        ///   associated with a given event, and track that information as events are read.
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
        ///   The maximum amount of time to wait to for an event to be available when reading before reading an empty
        ///   event.
        /// </summary>
        ///
        /// <value>
        ///   If specified, should there be no events available before this waiting period expires, an empty event will be returned,
        ///   allowing control to return to the reader that was waiting.
        ///
        ///   <para>If <c>null</c>, the reader will wait forever for items to be available unless reading is canceled. Empty items will
        ///   not be returned.</para>
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
        ///   The maximum number of events that will be read from the Event Hubs service and held in a local memory
        ///   cache when reading is active and events are being emitted to an enumerator for processing.
        /// </summary>
        ///
        /// <value>
        ///   The <see cref="CacheEventCount" /> is a control that developers can use to help tune performance for the specific
        ///   needs of an application, given its expected size of events, throughput needs, and expected scenarios for using
        ///   Event Hubs.
        /// </value>
        ///
        /// <remarks>
        ///   The size of this cache has an influence on the efficiency of reading events from the Event Hubs service.  The
        ///   larger the size of the cache, the more efficiently service operations can be buffered in the background to
        ///   improve throughput.  This comes at the cost of additional memory use and potentially increases network I/O.
        ///
        ///   For scenarios where the size of events is small and many events are flowing through the system, using a larger
        ///   <see cref="CacheEventCount"/> and <see cref="PrefetchCount" /> may help improve throughput.  For scenarios where
        ///   the size of events is larger or when processing of events is expected to be a heavier and slower operation, using
        ///   a smaller size <see cref="CacheEventCount"/> and <see cref="PrefetchCount"/> may help manage resource use without
        ///   incurring a non-trivial cost to throughput.
        ///
        ///   Regardless of the values, it is generally recommended that the <see cref="PrefetchCount" /> be at least 2-3
        ///   times as large as the <see cref="CacheEventCount" /> to allow for efficient buffering of service operations.
        /// </remarks>
        ///
        public int CacheEventCount
        {
            get => _cacheEventCount;

            set
            {
                Argument.AssertAtLeast(value, 1, nameof(CacheEventCount));
                _cacheEventCount = value;
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
        /// </value>
        ///
        /// <remarks>
        ///   The size of the prefetch count has an influence on the efficiency of reading events from the Event Hubs service.  The
        ///   larger the size of the cache, the more efficiently service operations can be buffered in the background to
        ///   improve throughput.  This comes at the cost of additional memory use and potentially increases network I/O.
        ///
        ///   For scenarios where the size of events is small and many events are flowing through the system, using a larger
        ///   <see cref="CacheEventCount"/> and <see cref="PrefetchCount" /> may help improve throughput.  For scenarios where
        ///   the size of events is larger or when processing of events is expected to be a heavier and slower operation, using
        ///   a smaller size <see cref="CacheEventCount"/> and <see cref="PrefetchCount"/> may help manage resource use without
        ///   incurring a non-trivial cost to throughput.
        ///
        ///   Regardless of the values, it is generally recommended that the <see cref="PrefetchCount" /> be at least 2-3
        ///   times as large as the <see cref="CacheEventCount" /> to allow for efficient buffering of service operations.
        /// </remarks>
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
        /// </value>
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
        ///   Creates a new copy of the current <see cref="ReadEventOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="ReadEventOptions" />.</returns>
        ///
        internal ReadEventOptions Clone() =>
            new ReadEventOptions
            {
                _maximumWaitTime = _maximumWaitTime,
                _cacheEventCount = _cacheEventCount,
                _prefetchCount = _prefetchCount,
                _prefetchSizeInBytes = _prefetchSizeInBytes,
                OwnerLevel = OwnerLevel,
                TrackLastEnqueuedEventProperties = TrackLastEnqueuedEventProperties
            };
    }
}
