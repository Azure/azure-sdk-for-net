// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of well-known properties associated with an AMQP messages and
    ///   entities.
    /// </summary>
    ///
    internal static class AmqpProperty
    {
        /// <summary>
        ///   The owner level (a.k.a. epoch) to associate with a receiver link.
        /// </summary>
        ///
        public static AmqpSymbol ConsumerOwnerLevel { get; } = AmqpConstants.Vendor + ":epoch";

        /// <summary>
        ///   The consumer identifier to associate with a receiver link.
        /// </summary>
        ///
        public static AmqpSymbol ConsumerIdentifier { get; } = AmqpConstants.Vendor + ":receiver-name";

        /// <summary>
        ///   The owner level (a.k.a. epoch) to associate with a sending link.
        /// </summary>
        ///
        public static AmqpSymbol ProducerOwnerLevel { get; } = AmqpConstants.Vendor + ":producer-epoch";

        /// <summary>
        ///   The type of Event Hubs entity to associate with a link.
        /// </summary>
        ///
        public static AmqpSymbol EntityType { get; } = AmqpConstants.Vendor + ":entity-type";

        /// <summary>
        ///   The capability for tracking the last event enqueued in a partition, to associate with a link.
        /// </summary>
        ///
        public static AmqpSymbol TrackLastEnqueuedEventProperties { get; } = AmqpConstants.Vendor + ":enable-receiver-runtime-metric";

        /// <summary>
        ///   The capability for geo replication in a namespace, to associate with a link.
        /// </summary>
        ///
        public static AmqpSymbol GeoReplication { get; } = AmqpConstants.Vendor + ":georeplication";

        /// <summary>
        ///   The capability for opting-into idempotent publishing.
        /// </summary>
        ///
        public static AmqpSymbol EnableIdempotentPublishing { get; } = AmqpConstants.Vendor + ":idempotent-producer";

        /// <summary>
        ///   The identifier of the producer group to associate with a producer.
        /// </summary>
        ///
        public static AmqpSymbol ProducerGroupId { get; } = AmqpConstants.Vendor + ":producer-id";

        /// <summary>
        ///   The sequence number assigned by a producer to an event when it was published.
        /// </summary>
        ///
        public static AmqpSymbol ProducerSequenceNumber { get; } = AmqpConstants.Vendor + ":producer-sequence-number";

        /// <summary>
        ///   The timeout to associate with a link.
        /// </summary>
        ///
        public static AmqpSymbol Timeout { get; } = AmqpConstants.Vendor + ":timeout";

        /// <summary>
        ///   The date and time, in UTC, that a message was enqueued.
        /// </summary>
        ///
        public static AmqpSymbol EnqueuedTime { get; } = "x-opt-enqueued-time";

        /// <summary>
        ///   The sequence number assigned to a message.
        /// </summary>
        ///
        public static AmqpSymbol SequenceNumber { get; } = "x-opt-sequence-number";

        /// <summary>
        ///   The offset of a message within a given partition.
        /// </summary>
        ///
        public static AmqpSymbol Offset { get; } = "x-opt-offset";

        /// <summary>
        ///   The partition hashing key used for grouping a batch of events together with the intent of routing to a single partition.
        /// </summary>
        ///
        public static AmqpSymbol PartitionKey { get; } = "x-opt-partition-key";

        /// <summary>
        ///   The message property that identifies the last sequence number enqueued for a partition.
        /// </summary>
        ///
        public static AmqpSymbol PartitionLastEnqueuedSequenceNumber { get; } = "last_enqueued_sequence_number";

        /// <summary>
        ///   The message property that identifies the last offset enqueued for a partition.
        /// </summary>
        ///
        public static AmqpSymbol PartitionLastEnqueuedOffset { get; } = "last_enqueued_offset";

        /// <summary>
        ///   The message property that identifies the last time enqueued for a partition.
        /// </summary>
        ///
        public static AmqpSymbol PartitionLastEnqueuedTimeUtc { get; } = "last_enqueued_time_utc";

        /// <summary>
        ///   The message property that identifies the time that the last enqueued event information was
        ///   received from the service.
        /// </summary>
        ///
        public static AmqpSymbol LastPartitionPropertiesRetrievalTimeUtc { get; } = "runtime_info_retrieval_time_utc";

        /// <summary>
        ///   The set of descriptors for well-known <see cref="DescribedType" />
        ///   property types.
        /// </summary>
        ///
        public static class Descriptor
        {
            /// <summary>
            ///   A type annotation for representing a <see cref="System.TimeSpan" /> in a message.
            /// </summary>
            ///
            public static AmqpSymbol TimeSpan { get; } = AmqpConstants.Vendor + ":timespan";

            /// <summary>
            ///   A type annotation for representing a <see cref="System.Uri" /> in a message.
            /// </summary>
            ///
            public static AmqpSymbol Uri { get; } = AmqpConstants.Vendor + ":uri";

            /// <summary>
            ///   A type annotation for representing a <see cref="System.DateTimeOffset" /> in a message.
            /// </summary>
            ///
            public static AmqpSymbol DateTimeOffset { get; } = AmqpConstants.Vendor + ":datetime-offset";
        }

        /// <summary>
        ///   Represents the entity mapping for AMQP properties between the client library and
        ///   the Event Hubs service.
        /// </summary>
        ///
        /// <remarks>
        ///   WARNING:
        ///     These values are synchronized between the Event Hubs service and the client
        ///     library.  You must consult with the Event Hubs service team before making
        ///     changes, including adding a new member.
        ///
        ///     When adding a new member, remember to always do so before the Unknown
        ///     member.
        /// </remarks>
        ///
        public enum Entity
        {
            Namespace = 4,
            EventHub = 7,
            ConsumerGroup = 8,
            Partition = 9,
            Checkpoint = 10,
            Unknown = 0x7FFFFFFE
        }

        /// <summary>
        ///   Represents the type mapping for AMQP properties between the client library and
        ///   the Event Hubs service.
        /// </summary>
        ///
        /// <remarks>
        ///   WARNING:
        ///     These values are synchronized between the Event Hubs service and the client
        ///     library.  You must consult with the Event Hubs service team before making
        ///     changes, including adding a new member.
        ///
        ///     When adding a new member, remember to always do so before the Unknown
        ///     member.
        /// </remarks>
        ///
        public enum Type
        {
            Null,
            Byte,
            SByte,
            Char,
            Int16,
            UInt16,
            Int32,
            UInt32,
            Int64,
            UInt64,
            Single,
            Double,
            Decimal,
            Boolean,
            Guid,
            String,
            Uri,
            DateTime,
            DateTimeOffset,
            TimeSpan,
            Stream,
            Unknown
        }
    }
}
