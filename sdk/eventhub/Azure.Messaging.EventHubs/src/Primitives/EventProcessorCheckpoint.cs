// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Primitives
{
    /// <summary>
    ///   Contains the information to reflect the state of event processing for a given Event Hub partition.
    /// </summary>
    ///
    /// <seealso cref="EventProcessor{TPartition}" />
    ///
    public class EventProcessorCheckpoint
    {
        /// <summary>
        ///   The fully qualified Event Hubs namespace this checkpoint is associated with.  This
        ///   is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace { get; set; }

        /// <summary>
        ///   The name of the specific Event Hub this checkpoint is associated with, relative
        ///   to the Event Hubs namespace that contains it.
        /// </summary>
        ///
        public string EventHubName { get; set; }

        /// <summary>
        ///   The unique identifier of the client that authored this checkpoint.
        /// </summary>
        ///
        public string ClientIdentifier { get; set; }

        /// <summary>
        ///   The name of the consumer group this checkpoint is associated with.
        /// </summary>
        ///
        public string ConsumerGroup { get; set; }

        /// <summary>
        ///   The identifier of the Event Hub partition this checkpoint is associated with.
        /// </summary>
        ///
        public string PartitionId { get; set; }

        /// <summary>
        /// The date and time the checkpoint was last modified.
        /// </summary>
        ///
        public DateTimeOffset? LastModified { get; set; }

        /// <summary>
        ///   The starting position within the partition's event stream that this checkpoint is associated with.
        /// </summary>
        ///
        public EventPosition StartingPosition { get; set; }
    }
}
