// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of filters associated with an AMQP messages and
    ///   entities.
    /// </summary>
    ///
    internal static class AmqpFilter
    {
        /// <summary>Indicates filtering based on the sequence number of a message.</summary>
        public const string SeqNumberName = "amqp.annotation.x-opt-sequence-number";

        /// <summary>Indicates filtering based on the offset of a message.</summary>
        public const string OffsetPartName = "amqp.annotation.x-opt-offset";

        /// <summary>Indicates filtering based on time that a message was enqueued.</summary>
        public const string ReceivedAtName = "amqp.annotation.x-opt-enqueued-time";
    }
}
