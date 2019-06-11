// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The baseline set of options that can be specified when creating a <see cref="EventReceiver" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class ReceiverOptions
    {
        /// <summary>The name of the default consumer group in the Event Hubs service.</summary>
        public const string DefaultConsumerGroup = "$Default";

        /// <summary>The minimum value allowed for the prefetch count of the receiver.</summary>
        internal const int MinimumPrefetchCount = 10;

        /// <summary>The maximum length, in characters, for the identifier assigned to a receiver.</summary>
        internal const int MaximumIdentifierLength = 64;

        /// <summary>The amount of time to wait for messages when receiving.</summary>
        private TimeSpan? _maximumReceiveWaitTime = TimeSpan.FromMinutes(1);

        /// <summary>The prefetch count to use for the receiver.</summary>
        private int _prefetchCount = 300;

        /// <summary>The identifier to use for the receiver.</summary>
        private string _identifier = null;

        /// <summary>
        ///   The name of the consumer group that an event receiver should be associated with.  Events read
        ///   by the receiver will be performed in the context of this group.
        /// </summary>
        ///
        /// <value>If not specified, the default consumer group will be assumed.</value>
        ///
        public string ConsumerGroup { get; set; } = DefaultConsumerGroup;

        /// <summary>
        ///   The position within the partition where the receiver should begin reading events.
        /// </summary>
        ///
        /// <value>
        ///   If not specified, the receiver will begin receiving all events that are
        ///   contained in the partition, starting with the first event that was enqueued and
        ///   will continue receiving until there are no more events observed.
        /// </value>
        ///
        public EventPosition BeginReceivingAt { get; set; } = EventPosition.FirstAvailableEvent;

        /// <summary>
        ///   When populated, the priority indicates that a receiver is intended to be the only reader of events for the
        ///   requested partition and an associated consumer group.  To do so, this receiver will attempt to assert ownership
        ///   over the partition; in the case where more than one exclusive receiver attempts to assert ownership for the same
        ///   partition/consumer group pair, the one having a larger <see cref="ExclusiveReceiverPriority"/> value will "win."
        ///
        ///   When an exclusive receiver is used, those receivers which are not exclusive or which have a lower priority will either
        ///   not be allowed to be created, if they already exist, will encounter an exception during the next attempted operation.
        /// </summary>
        ///
        /// <value>The priority to associated with an exclusive receiver; for a non-exclusive receiver, this value should be <c>null</c>.</value>
        ///
        public long? ExclusiveReceiverPriority { get; set; }

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
        internal TimeSpan? DefaultMaximumReceiveWaitTime
        {
            get => _maximumReceiveWaitTime;

            set
            {
                ValidateMaximumReceiveWaitTime(value);
                _maximumReceiveWaitTime = value;
            }
        }

        /// <summary>
        ///   Normalizes the specified wait time value, returning the timeout period or the
        ///   a <c>null</c> value if no wait time was specified.
        /// </summary>
        ///
        internal TimeSpan? MaximumReceiveWaitTimeOrDefault => (_maximumReceiveWaitTime == TimeSpan.Zero) ? null : _maximumReceiveWaitTime;

        /// <summary>
        ///     An optional text-based identifier label to assign to an event receiver.
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
        ///   Creates a new copy of the current <see cref="ReceiverOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="ReceiverOptions" />.</returns>
        ///
        internal ReceiverOptions Clone() =>
            new ReceiverOptions
            {
                ConsumerGroup = this.ConsumerGroup,
                BeginReceivingAt = this.BeginReceivingAt,
                ExclusiveReceiverPriority = this.ExclusiveReceiverPriority,
                Retry = this.Retry?.Clone(),

                _identifier = this._identifier,
                _prefetchCount = this._prefetchCount,
                _maximumReceiveWaitTime = this._maximumReceiveWaitTime
            };

        /// <summary>
        ///   Validates that the identifier requested for the receiver can be used, throwing an <see cref="ArgumentException" /> if
        ///   it is not valid.
        /// </summary>
        ///
        /// <param name="identifier">The identifier to validae.</param>
        ///
        private void ValidateIdentifier(string identifier)
        {
            if ((!String.IsNullOrEmpty(identifier)) && (identifier.Length > MaximumIdentifierLength))
            {
                throw new ArgumentException(nameof(identifier), String.Format(CultureInfo.CurrentCulture, Resources.ReceiverIdentifierOverMaxValue, MaximumIdentifierLength));
            }
        }

        /// <summary>
        ///   Validates the time period specified as the maximum time to wait when receiving, throwing an <see cref="ArgumentException" /> if
        ///   it is not valid.
        /// </summary>
        ///
        /// <param name="maximumWaitTime">The time period to validae.</param>
        ///
        private void ValidateMaximumReceiveWaitTime(TimeSpan? maximumWaitTime)
        {
            if (maximumWaitTime < TimeSpan.Zero)
            {
                throw new ArgumentException(Resources.TimeoutMustBePositive, nameof(DefaultMaximumReceiveWaitTime));
            }
        }
    }
}
