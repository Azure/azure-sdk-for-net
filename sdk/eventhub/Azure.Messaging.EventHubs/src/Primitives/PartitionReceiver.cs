// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Allows reading events from a specific partition of an Event Hub, and in the context
    ///   of a specific consumer group, to be read with a greater level of control over
    ///   communication with the Event Hubs service than is offered by other event consumers.
    /// </summary>
    ///
    /// <remarks>
    ///   It is recommended that the <c>EventProcessorClient</c> or <see cref="EventHubConsumerClient" />
    ///   be used for reading and processing events for the majority of scenarios.  The partition receiver is
    ///   intended to enable scenarios with special needs which require more direct control.
    /// </remarks>
    ///
    /// <seealso cref="EventHubConsumerClient.ReadEventsFromPartitionAsync(string, EventPosition, CancellationToken)"/>
    /// <seealso cref="EventHubConsumerClient.ReadEventsFromPartitionAsync(string, EventPosition, ReadEventOptions, CancellationToken)"/>
    ///
    internal class PartitionReceiver
    {
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
    }
}
