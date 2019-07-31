// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubProducer" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventHubProducerOptions
    {
        /// <summary>The identifier of the partition that the producer will be bound to.</summary>
        private string _partitionId = null;

        /// <summary>
        ///   The identifier of the Event Hub partition that the <see cref="EventHubProducer" /> will be bound to,
        ///   limiting it to sending events to only that partition.
        ///
        ///   If the identifier is not specified, the Event Hubs service will be responsible for routing events that
        ///   are sent to an available partition.
        /// </summary>
        ///
        /// <value>If the producer wishes the events to be automatically to partitions, <c>null</c>; otherwise, the identifier of the desired partition.</value>
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
        public string PartitionId
        {
            get => _partitionId;
            set
            {
                Guard.ArgumentNotEmptyOrWhitespace(nameof(PartitionId), value);
                _partitionId = value;
            }
        }

        /// <summary>
        ///   The set of options to use for determining whether a failed operation should be retried and,
        ///   if so, the amount of time to wait between retry attempts.  If not specified, the retry policy from
        ///   the associcated <see cref="EventHubClient" /> will be used.
        /// </summary>
        ///
        public RetryOptions RetryOptions { get; set; }

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
        ///   Creates a new copy of the current <see cref="EventHubProducerOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventHubProducerOptions" />.</returns>
        ///
        internal EventHubProducerOptions Clone() =>
            new EventHubProducerOptions
            {
                RetryOptions = this.RetryOptions?.Clone(),
                _partitionId = this.PartitionId
            };
    }
}
