// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of annotations for management-related operations associated with an AMQP messages and
    ///   entities.
    /// </summary>
    ///
    internal static class AmqpManagement
    {
        /// <summary>The location to specify for management operations.</summary>
        public const string Address = "$management";

        /// <summary>The type to specify for an AMQP link used for management operations.</summary>
        public const string LinkType = "svc";

        /// <summary>The key to use for specifying an Event Hubs resource name.</summary>
        public const string ResourceNameKey = "name";

        /// <summary>The key to use for specifying a partition. </summary>
        public const string PartitionNameKey = "partition";

        /// <summary>The key to use for specifying an operation.</summary>
        public const string OperationKey = "operation";

        /// <summary>The key to use for specifying the type of Event Hubs resource.</summary>
        public const string ResourceTypeKey = "type";

        /// <summary>The key to use for specifying a security token.</summary>
        public const string SecurityTokenKey = "security_token";

        /// <summary>The value to specify when requesting a read-based operation.</summary>
        public const string ReadOperationValue = "READ";

        /// <summary>The value to specify when identifying an Event Hub resource.</summary>
        public const string EventHubResourceTypeValue = AmqpConstants.Vendor + ":eventhub";

        /// <summary>The value to specify when identifying a partition resource.</summary>
        public const string PartitionResourceTypeValue = AmqpConstants.Vendor + ":partition";

        /// <summary>
        ///   The set of property mappings to use for reading management-related
        ///   responses from the Event Hubs service.
        /// </summary>
        ///
        public static class ResponseMap
        {
            /// <summary>The message property that identifies the name of a resource.</summary>
            public static readonly MapKey Name = new MapKey("name");

            /// <summary>The message property that identifies the date/time that a resource was created.</summary>
            public static readonly MapKey CreatedAt = new MapKey("created_at");

            /// <summary>The message property that identifies the unique identifier associated with a partition.</summary>
            public static readonly MapKey PartitionIdentifier = new MapKey("partition");

            /// <summary>The message property that identifies the set of unique identifiers for each partition of an Event Hub.</summary>
            public static readonly MapKey PartitionIdentifiers = new MapKey("partition_ids");

            /// <summary>The message property that identifies the beginning sequence number in a partition.</summary>
            public static readonly MapKey PartitionBeginSequenceNumber = new MapKey("begin_sequence_number");

            /// <summary>The message property that identifies the last sequence number enqueued for a partition.</summary>
            public static readonly MapKey PartitionLastEnqueuedSequenceNumber = new MapKey("last_enqueued_sequence_number");

            /// <summary>The message property that identifies the last offset enqueued for a partition.</summary>
            public static readonly MapKey PartitionLastEnqueuedOffset = new MapKey("last_enqueued_offset");

            /// <summary>The message property that identifies the last time enqueued for a partition.</summary>
            public static readonly MapKey PartitionLastEnqueuedTimeUtc = new MapKey("last_enqueued_time_utc");

            /// <summary>The message property that identifies the date and time, in UTC, that partition information was sent from the Event Hubs service.</summary>
            public static readonly MapKey PartitionRuntimeInfoRetrievalTimeUtc = new MapKey("runtime_info_retrieval_time_utc");

            /// <summary>The message property that identifies whether or not a partition is considered empty.</summary>
            public static readonly MapKey PartitionRuntimeInfoPartitionIsEmpty = new MapKey("is_partition_empty");
        }
    }
}
