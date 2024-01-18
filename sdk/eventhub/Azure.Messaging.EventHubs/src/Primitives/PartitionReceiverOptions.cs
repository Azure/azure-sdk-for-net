// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   The set of options that can be specified when creating a <see cref="PartitionReceiver" />
    ///   to configure its behavior.
    /// </summary>
    ///
    /// <seealso href="https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/eventhub/Azure.Messaging.EventHubs/samples">Event Hubs samples and discussion</seealso>
    ///
    public class PartitionReceiverOptions
    {
        /// <summary>The set of options to use for configuring the connection to the Event Hubs service.</summary>
        private EventHubConnectionOptions _connectionOptions = new EventHubConnectionOptions();

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private EventHubsRetryOptions _retryOptions = new EventHubsRetryOptions();

        /// <summary>The amount of time to wait for messages when reading.</summary>
        private TimeSpan? _defaultMaximumReceiveWaitTime = TimeSpan.FromSeconds(60);

        /// <summary>The prefetch count to use for the partition receiver.</summary>
        private int _prefetchCount = 300;

        /// <summary>The prefetch size limit to use for the partition receiver.</summary>
        private long? _prefetchSizeInBytes;

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
        ///   amount of time allowed for reading events and other interactions with the Event Hubs service.
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
        ///   The default amount of time to wait for the requested amount of messages when reading; if this
        ///   period elapses before the requested amount of messages were available or read, then the set of
        ///   messages that were read will be returned.
        /// </summary>
        ///
        /// <value>The default wait time is 60 seconds.</value>
        ///
        /// <exception cref="ArgumentOutOfRangeException">Occurs when the requested wait time is negative.</exception>
        ///
        public TimeSpan? DefaultMaximumReceiveWaitTime
        {
            get => _defaultMaximumReceiveWaitTime;

            set
            {
                if (value.HasValue)
                {
                    Argument.AssertNotNegative(value.Value, nameof(DefaultMaximumReceiveWaitTime));
                }

                _defaultMaximumReceiveWaitTime = value;
            }
        }

        /// <summary>
        ///   A unique name used to identify the receiver.  If <c>null</c> or empty, a GUID will be used as the
        ///   identifier.
        /// </summary>
        ///
        /// <value>If not specified, a random unique identifier will be generated.</value>
        ///
        public string Identifier { get; set; }

        /// <summary>
        ///   When populated, the owner level indicates that a reading is intended to be performed exclusively for events in the
        ///   requested partition and for the associated consumer group.  To do so, reading will attempt to assert ownership
        ///   over the partition; in the case where more than one exclusive reader attempts to assert ownership for the same
        ///   partition/consumer group pair, the one having a larger <see cref="OwnerLevel"/> value will "win."
        ///
        ///   When an exclusive reader is used, other readers which are non-exclusive or which have a lower owner level will either
        ///   not be allowed to be created, if they already exist, will encounter an exception during the next attempted operation.
        /// </summary>
        ///
        /// <value>
        ///   The relative priority to associate with an exclusive reader; for a non-exclusive reader, this value should be <c>null</c>.  The
        ///   default owner level is <c>null</c>.
        /// </value>
        ///
        /// <exception cref="EventHubsException">
        ///   Occurs when the owner level is set and the <see cref="PartitionReceiver"/> is unable to read from the requested Event Hub partition due to being denied
        ///   ownership.  In this case, the <see cref="EventHubsException.FailureReason"/> will be set to <see cref="EventHubsException.FailureReason.ConsumerDisconnected"/>.
        /// </exception>
        ///
        /// <seealso cref="EventHubsException"/>
        /// <seealso cref="EventHubsException.FailureReason.ConsumerDisconnected"/>
        ///
        public long? OwnerLevel { get; set; }

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
        ///   Indicates whether or not the reader should request information on the last enqueued event on the partition
        ///   associated with a given event, and track that information as events are read.
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
        ///   Creates a new copy of the current <see cref="PartitionReceiverOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="PartitionReceiverOptions" />.</returns>
        ///
        internal PartitionReceiverOptions Clone() =>
            new PartitionReceiverOptions
            {
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone(),
                _defaultMaximumReceiveWaitTime = DefaultMaximumReceiveWaitTime,
                _prefetchCount = PrefetchCount,
                _prefetchSizeInBytes = PrefetchSizeInBytes,
                Identifier = Identifier,
                OwnerLevel = OwnerLevel,
                TrackLastEnqueuedEventProperties = TrackLastEnqueuedEventProperties
            };
    }
}
