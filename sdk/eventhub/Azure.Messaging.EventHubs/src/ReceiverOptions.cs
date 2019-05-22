// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The baseline set of options that can be specified when creating a <see cref="PartitionReceiver" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class ReceiverOptions
    {
        /// <summary>The name of the default consumer group in the Event Hubs service.</summary>
        public const string DefaultConsumerGroupName = "$Default";

        /// <summary>The minimum value allowed for the prefetch count of the receiver.</summary>
        protected const int MinimumPrefetchCount = 10;

        /// <summary>The maximum length, in characters, for the identifier assigned to a receiver.</summary>
        protected const int MaximumIdentifierLength = 64;

        /// <summary>The prefetch count to use for the receiver.</summary>
        protected int _prefetchCount = 300;

        /// <summary>The identifier to use for the receiver.</summary>
        protected string _identifier = null;

        /// <summary>
        ///   The name of the consumer group that an event receiver should be associated with.  Events read
        ///   by the receiver will be performed in the context of this group.
        /// </summary>
        ///
        /// <value>If not specified, the default consumer group will be assumed.</value>
        ///
        public string ConsumerGroup { get; set; } = DefaultConsumerGroupName;

        /// <summary>
        ///   The position within the partition where the receiver should begin reading events.
        /// </summary>
        ///
        /// <value>
        ///   If not specified, the receiver will ignore events in the partition that were
        ///   queued prior to the receiver being created and read only events which appear
        ///   after that point.
        /// </value>
        ///
        public EventPosition BeginReceivingAt { get; set; } = EventPosition.NewEventsOnly;

        /// <summary>
        ///   Indicates that the receiver is intended to be the only reader of events for the requested partition and an
        ///   associated consumer group.  To do so, this receiver will attempt to assert ownership over the partition;
        ///   in the case where two exclusive receivers attempt to assert ownership for the same partition/consumer group
        ///   pair, the one having a larger <see cref="ExclusiveReceiverPriority"/> value will "win."
        /// </summary>
        ///
        /// <value><c>true</c> if the receiver should be exclusive; otherwise, <c>false</c>.</value>
        ///
        public bool IsExclusiveReceiver { get; set; }

        /// <summary>
        ///   For an exlclusive receiver, the relative priority within the associated consumer group, used to resolve
        ///   conflicting requests for partition ownership.
        /// </summary>
        ///
        /// <value>The priority to associated with an exclusive receiver; for a non-exclusive receiver, this value has no effect.</value>
        ///
        /// <seealso cref="IsExclusiveReceiver" />
        ///
        public long ExclusiveReceiverPriority { get; set; }

        /// <summary>
        ///   The <see cref="EventHubs.Retry" /> used to govern retry attempts when an issue
        ///   is encountered while receiving.
        /// </summary>
        ///
        /// <value>If not specified, the retry policy configured on the associated <see cref="EventHubClient" /> will be used.</value>
        ///
        public Retry Retry { get; set; }

        /// <summary>
        ///   The default amount of time to wait for the requested amount of messages when receiving; if this
        ///   period elapses before the requested amount of messages were available or received, then the set of
        ///   messages that were received will be returned.
        /// </summary>
        ///
        /// <value>If not specified, the operation timeout requested for the associated <see cref="EventHubClient" /> will be used.</value>
        ///
        public TimeSpan? DefaultReceiveWaitTime { get; set; }

        /// <summary>
        ///   Indicates whether or not properties about the current state of events received is kept up to date
        ///   as the receiver reads events.
        ///
        ///   Enabling updates allows consumers that wish to create checkpoints more easily and frequently, as the
        ///   necessary inormation needed to do so is readily available on the <see cref="PartitionReceiver" />.  If
        ///   updates are not enabled, consumers will need to request partition properties using
        ///   <see cref="EventHubClient.GetPartitionPropertiesAsync(string, System.Threading.CancellationToken)"/>.
        ///
        ///   Should a consumer wish to save checkpoint information frequently, to try and minimize the number of events
        ///   which would be repeated in the event of crash recovery, it is recommended that updates are enabled.  For consumers
        ///   that would prefer to minimize network transfers at the cost of potentially having more repeated events after a crash
        ///   resovery, it is recommended that updating be disabled.
        /// </summary>
        ///
        /// <value><c>true</c> if the information should be kept up-to-date as events are received; otherwise, <c>false</c>.</value>
        ///
        /// <remarks>
        ///   Enabling updates does result in use of a small amount of additional bandwidth when receiving messages, as the
        ///   properties for the state of the partition are sent with events.
        /// </remarks>
        ///
        public bool UpdatePropertiesOnReceive { get; set; } = true;

        /// <summary>
        ///     An optional text-based identifierlabel to assign to an event receiver.
        /// </summary>
        ///
        /// <value>The identifier is used for informational purposes only.  If not specified, the reaciever will have no assigned identifier label.</value>
        ///
        public string Identifier
        {
            get => _identifier;

            set
            {
                ValidateIdentifier(value);
                _identifier = value;
            }
        }

        /// <summary>
        ///   The prefetch count used by the receiver to control the number of events this receiver will actively receive
        ///   and queue locally without regard to whether a receive operation is currently active.
        /// </summary>
        ///
        public int PrefetchCount
        {
            get => _prefetchCount;

            set
            {
                Guard.ArgumentInRange(nameof(PrefetchCount), value, MinimumPrefetchCount, int.MaxValue);
                _prefetchCount = value;
            }
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
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
        ///   Validates that the identifier requested for the receiver can be used, throwing an <see cref="ArgumentException" /> if
        ///   it is not valid.
        /// </summary>
        ///
        /// <param name="identifier">The identifier to validae.</param>
        ///
        protected virtual void ValidateIdentifier(string identifier)
        {
            if ((!String.IsNullOrEmpty(identifier)) && (identifier.Length > MaximumIdentifierLength))
            {
                throw new ArgumentException(nameof(identifier), String.Format(CultureInfo.CurrentCulture, Resources.ReceiverIdentifierOverMaxValue, MaximumIdentifierLength));
            }
        }
    }
}
