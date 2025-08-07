// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

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
        public const string SequenceNumberName = "amqp.annotation.x-opt-sequence-number";

        /// <summary>Indicates filtering based on the offset of a message.</summary>
        public const string OffsetName = "amqp.annotation.x-opt-offset";

        /// <summary>Indicates filtering based on time that a message was enqueued.</summary>
        public const string EnqueuedTimeName = "amqp.annotation.x-opt-enqueued-time";

        /// <summary>Identifies the filter type name.</summary>
        public const string ConsumerFilterName = AmqpConstants.Apache + ":selector-filter:string";

        /// <summary>Identifies the filter type code.</summary>
        public const ulong ConsumerFilterCode = 0x00000137000000A;

        /// <summary>
        ///   Creates an event consumer filter based on the specified expression.
        /// </summary>
        ///
        /// <param name="filterExpression">The SQL-like expression to use for filtering events in the partition.</param>
        ///
        /// <returns>An <see cref="AmqpDescribed"/> type to use in the filter map for a consumer AMQP link.</returns>
        ///
        public static AmqpDescribed CreateConsumerFilter(string filterExpression)
        {
            Argument.AssertNotNullOrEmpty(filterExpression, nameof(filterExpression));
            return new AmqpDescribed(ConsumerFilterName, ConsumerFilterCode) { Value = filterExpression };
        }

        /// <summary>
        ///   Builds an AMQP filter expression for the specified event position.
        /// </summary>
        ///
        /// <param name="eventPosition">The event position to use as the source for filtering.</param>
        ///
        /// <returns>The AMQP filter expression that corresponds to the <paramref name="eventPosition"/>.</returns>
        ///
        public static string BuildFilterExpression(EventPosition eventPosition)
        {
            // Build the filter expression, in the order of significance.

            if (!string.IsNullOrEmpty(eventPosition.OffsetString))
            {
                return $"{ OffsetName } { (eventPosition.IsInclusive ? ">=" : ">") } { eventPosition.OffsetString }";
            }

            if (!string.IsNullOrEmpty(eventPosition.SequenceNumber))
            {
                return $"{ SequenceNumberName } { (eventPosition.IsInclusive ? ">=" : ">") } { eventPosition.SequenceNumber }";
            }

            if (eventPosition.EnqueuedTime.HasValue)
            {
                return $"{ EnqueuedTimeName } > { eventPosition.EnqueuedTime.Value.ToUnixTimeMilliseconds() }";
            }

            // If no filter was built, then the event position is not valid for filtering.

            throw new ArgumentException(Resources.InvalidEventPositionForFilter, nameof(eventPosition));
        }
    }
}
