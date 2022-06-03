// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   The set of information for describing the status of the partition ownership between <see cref="EventProcessor{TPartition}" />
    ///   instances cooperating for distribution of processing for a given Event Hub.
    /// </summary>
    ///
    /// <seealso cref="EventProcessor{TPartition}" />
    ///
    public class EventProcessorPartitionOwnership
    {
        /// <summary>
        ///   The fully qualified Event Hubs namespace this ownership is associated with.  This
        ///   is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; set; }

        /// <summary>
        ///   The name of the specific Event Hub this ownership is associated with, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; set; }

        /// <summary>
        ///   The name of the consumer group this ownership is associated with.
        /// </summary>
        ///
        public string ConsumerGroup { get; set; }

        /// <summary>
        ///   The identifier of the associated <see cref="EventProcessor{TPartition}" /> instance.
        /// </summary>
        ///
        public string OwnerIdentifier { get; set; }

        /// <summary>
        ///   The identifier of the Event Hub partition this ownership is associated with.
        /// </summary>
        ///
        public string PartitionId { get; set; }

        /// <summary>
        ///   The date and time, in UTC, that the last update was made to this ownership.
        /// </summary>
        ///
        public DateTimeOffset LastModifiedTime { get; set; }

        /// <summary>
        ///   The version metadata needed to update this ownership.
        /// </summary>
        ///
        public string Version { get; set; }
    }
}
