// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventSender" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class SenderOptions
    {
        /// <summary>The timeout that will be used by default for sending events.</summary>
        private TimeSpan? _timeout = TimeSpan.FromMinutes(1);

        /// <summary>
        ///   The identifier of the Event Hub partition that the <see cref="EventSender" /> will be bound to,
        ///   limiting it to sending events to only that partition.
        ///
        ///   If the identifier is not spedified, the Event Hubs service will be responsible for routing events that
        ///   are sent to an available partition.
        /// </summary>
        ///
        /// <value>If the sender wishes the events to be automatically to partitions, <c>null</c>; otherwise, the identifier of the desired partition.</value>
        ///
        /// <remarks>
        ///   Allowing automatic routing of partitions is recommended when:
        ///   <para>- The sending of events needs to be highly available.</para>
        ///   <para>- The event data should be evenly distributed among all available partitions.</para>
        ///
        ///   If no partition is specified, the following rules are used for automatically selecting one:
        ///   <para>1) Distribute the events equally amongst all available partitions using a round-robin approach.</para>
        ///   <para>2) If a partition becomes unavailable, the Event Hubs service will automatically detect it and forward the message to another available partition.</para>
        /// </remarks>
        ///
        public string PartitionId { get; set; }

        /// <summary>
        ///   The <see cref="EventHubs.Retry" /> used to govern retry attempts when an issue
        ///   is encountered while sending.
        /// </summary>
        ///
        /// <value>If not specified, the retry policy configured on the associated <see cref="EventHubClient" /> will be used.</value>
        ///
        public Retry Retry { get; set; }

        /// <summary>
        ///   The default timeout to apply when sending events.  If the timeout is reached, before the Event Hub
        ///   acknowledges receipt of the event data being sent, the attempt will be conisdered failed and considered
        ///   to be retried.
        /// </summary>
        ///
        /// <value>If not specified, the operation timeout requested for the associated <see cref="EventHubClient" /> will be used.</value>
        ///
        public TimeSpan? Timeout
        {
            get => _timeout;

            set
            {
                ValidateTimeout(value);
                _timeout = value;
            }
        }

        /// <summary>
        ///   Normalizes the specified timeout value, returning the timeout period or the
        ///   a <c>null</c> value if no timeout was specified.
        /// </summary>
        ///
        internal TimeSpan? TimeoutOrDefault => (_timeout == TimeSpan.Zero) ? null : _timeout;

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
        ///   Creates a new copy of the current <see cref="SenderOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="SenderOptions" />.</returns>
        ///
        internal SenderOptions Clone() =>
            new SenderOptions
            {
                PartitionId = this.PartitionId,
                Retry = this.Retry?.Clone(),
                Timeout = this.Timeout
            };

        /// <summary>
        ///   Validates the time period specified as the timeout to use when sending vents, throwing an <see cref="ArgumentException" /> if
        ///   it is not valid.
        /// </summary>
        ///
        /// <param name="timeout">The time period to validate.</param>
        ///
        protected virtual void ValidateTimeout(TimeSpan? timeout)
        {
            if (timeout < TimeSpan.Zero)
            {
                throw new ArgumentException(Resources.TimeoutMustBePositive, nameof(Timeout));
            }
        }
    }
}
