// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when creating an <see cref="EventHubProducerClient" />
    ///   to configure its behavior.
    /// </summary>
    ///
    public class EventHubProducerClientOptions
    {
        /// <summary>The identifier of the partition that the producer will be bound to.</summary>
        private string _partitionId = null;

        /// <summary>The set of options to use for configuring the connection to the Event Hubs service.</summary>
        private EventHubConnectionOptions _connectionOptions = new EventHubConnectionOptions();

        /// <summary>The set of options to govern retry behavior and try timeouts.</summary>
        private RetryOptions _retryOptions = new RetryOptions();

        /// <summary>
        ///   The identifier of the Event Hub partition that the <see cref="EventHubProducerClient" /> will be bound to,
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
                Argument.AssertNotEmptyOrWhiteSpace(value, nameof(PartitionId));
                _partitionId = value;
            }
        }

        /// <summary>
        ///   Gets or sets the options used for configuring the connection to the Event Hubs service.
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
        ///   amount of time allowed for publishing events and other interactions with the Event Hubs service.
        /// </summary>
        ///
        public RetryOptions RetryOptions
        {
            get => _retryOptions;
            set
            {
                Argument.AssertNotNull(value, nameof(RetryOptions));
                _retryOptions = value;
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
        ///   Creates a new copy of the current <see cref="EventHubProducerClientOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="EventHubProducerClientOptions" />.</returns>
        ///
        internal EventHubProducerClientOptions Clone() =>
            new EventHubProducerClientOptions
            {
                _partitionId = PartitionId,
                _connectionOptions = ConnectionOptions.Clone(),
                _retryOptions = RetryOptions.Clone()
            };
    }
}
