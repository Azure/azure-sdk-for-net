// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   The set of well-known annotations associated with an AMQP messages and
    ///   entities.
    /// </summary>
    ///
    internal static class AmqpAnnotation
    {
        /// <summary>The date and time, in UTC, that a message was enqueued.</summary>
        public const string EnqueuedTime = "x-opt-enqueued-time";

        /// <summary>The sequence number assigned to a message.</summary>
        public const string SequenceNumber = "x-opt-sequence-number";

        /// <summary>The offset of a message within a given partition.</summary>
        public const string Offset = "x-opt-offset";

        /// <summary>The name of the entity that published a message.</summary>
        public const string Publisher = "x-opt-publisher";

        /// <summary>The partition hashing key used for grouping a batch of events together with the intent of routing to a single partition.</summary>
        public const string PartitionKey = "x-opt-partition-key";
    }
}
