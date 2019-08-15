// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;

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

        /// <summary>The message property that identifies the beginning sequence number in a partition.</summary>
        public const string PartitionBeginSequenceNumber = "begin_sequence_number";

        /// <summary>The message property that identifies the last sequence number enqueued for a partition.</summary>
        public const string PartitionLastEnqueuedSequenceNumber = "last_enqueued_sequence_number";

        /// <summary>The message property that identifies the last offset enqueued for a partition.</summary>
        public const string PartitionLastEnqueuedOffset = "last_enqueued_offset";

        /// <summary>The message property that identifies the last time enqueued for a partition.</summary>
        public const string PartitionLastEnqueuedTimeUtc = "last_enqueued_time_utc";

        /// <summary>The message property that identifies the date and time, in UTC, that partition information was sent from the Event Hubs service.</summary>
        public const string PartitionRuntimeInfoRetrievalTimeUtc = "runtime_info_retrieval_time_utc";

        /// <summary>The message property that identifies whether or not a partition is considered empty.</summary>
        public const string PartitionRuntimeInfoPartitionIsEmpty = "is_partition_empty";
    }
}
