// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    /// Service Bus specific constants that are used to identify keys for various
    /// MessageAnnotations in an AMQP message.
    /// </summary>
    internal class AmqpMessageConstants
    {
        internal const string EnqueuedTimeUtcName = "x-opt-enqueued-time";
        internal const string ScheduledEnqueueTimeUtcName = "x-opt-scheduled-enqueue-time";
        internal const string SequenceNumberName = "x-opt-sequence-number";
        internal const string EnqueueSequenceNumberName = "x-opt-enqueue-sequence-number";
        internal const string LockedUntilName = "x-opt-locked-until";
        internal const string PartitionKeyName = "x-opt-partition-key";
        internal const string PartitionIdName = "x-opt-partition-id";
        internal const string ViaPartitionKeyName = "x-opt-via-partition-key";
        internal const string DeadLetterSourceName = "x-opt-deadletter-source";
        internal const string MessageStateName = "x-opt-message-state";
        internal const string TimeSpanName = AmqpConstants.Vendor + ":timespan";
        internal const string UriName = AmqpConstants.Vendor + ":uri";
        internal const string DateTimeOffsetName = AmqpConstants.Vendor + ":datetime-offset";
        /// <summary>
        ///  Property key representing dead-letter reason, when a message is received from a dead-letter subqueue of an entity.
        ///  This key and the associated values are stored in the <see cref="ServiceBusReceivedMessage.ApplicationProperties"/> dictionary
        ///  for dead lettered messages.
        /// </summary>
        internal const string DeadLetterReasonHeader = "DeadLetterReason";

        /// <summary>
        ///  Property key representing detailed error description, when a message is received from a dead-letter subqueue of an entity.
        ///  This key and the associated values are stored in the <see cref="ServiceBusReceivedMessage.ApplicationProperties"/> dictionary
        ///  for dead lettered messages.
        /// </summary>
        internal const string DeadLetterErrorDescriptionHeader = "DeadLetterErrorDescription";
    }
}
