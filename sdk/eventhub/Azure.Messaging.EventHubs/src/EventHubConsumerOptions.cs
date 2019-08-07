// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Globalization;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The baseline set of options that can be specified when creating a <see cref="EventHubConsumer" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventHubConsumerOptions
    {
        /// <summary>The minimum value allowed for the prefetch count of the consumer.</summary>
        internal const int MinimumPrefetchCount = 10;

        /// <summary>The maximum length, in characters, for the identifier assigned to a consumer.</summary>
        internal const int MaximumIdentifierLength = 64;

        /// <summary>The amount of time to wait for messages when receiving.</summary>
        private TimeSpan? _maximumReceiveWaitTime = TimeSpan.FromMinutes(1);

        /// <summary>The prefetch count to use for the consumer.</summary>
        private int _prefetchCount = 300;

        /// <summary>The identifier to use for the consumer.</summary>
        private string _identifier = null;

        /// <summary>
        ///   When populated, the owner level indicates that a consumer is intended to be the only reader of events for the
        ///   requested partition and an associated consumer group.  To do so, this consumer will attempt to assert ownership
        ///   over the partition; in the case where more than one exclusive consumer attempts to assert ownership for the same
        ///   partition/consumer group pair, the one having a larger <see cref="OwnerLevel"/> value will "win."
        ///
        ///   When an exclusive consumer is used, other consumers which are non-exclusive or which have a lower owner level will either
        ///   not be allowed to be created, if they already exist, will encounter an exception during the next attempted operation.
        /// </summary>
        ///
        /// <value>The relative priority to associate with an exclusive consumer; for a non-exclusive consumer, this value should be <c>null</c>.</value>
        ///
        public long? OwnerLevel { get; set; }

        /// <summary>
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.  If not specified, the retry policy from
        ///   the associated <see cref="EventHubClient" /> will be used.
        /// </summary>
        ///
        public RetryOptions RetryOptions { get; set; }

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
        ///     An optional text-based identifier label to assign to a consumer.
        /// </summary>
        ///
        /// <value>The identifier is used for informational purposes only.  If not specified, the receiver will have no assigned identifier label.</value>
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
        ///   The count used by the consumer to control the number of events this consumer will actively receive
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
        ///   Creates a new copy of the current <see cref="EventHubConsumerOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventHubConsumerOptions" />.</returns>
        ///
        internal EventHubConsumerOptions Clone() =>
            new EventHubConsumerOptions
            {
                OwnerLevel = this.OwnerLevel,
                RetryOptions = this.RetryOptions?.Clone(),
                _identifier = this._identifier,
                _prefetchCount = this._prefetchCount,
                _maximumReceiveWaitTime = this._maximumReceiveWaitTime
            };

        /// <summary>
        ///   Validates that the identifier requested for the consumer can be used, throwing an <see cref="ArgumentException" /> if
        ///   it is not valid.
        /// </summary>
        ///
        /// <param name="identifier">The identifier to validae.</param>
        ///
        private void ValidateIdentifier(string identifier)
        {
            if ((!String.IsNullOrEmpty(identifier)) && (identifier.Length > MaximumIdentifierLength))
            {
                throw new ArgumentException(nameof(identifier), String.Format(CultureInfo.CurrentCulture, Resources.ConsumerIdentifierOverMaxValue, MaximumIdentifierLength));
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
