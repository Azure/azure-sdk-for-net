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
        /// <summary>The owner level (a.k.a. epoch) to associate with a link.</summary>
        public static readonly AmqpSymbol OwnerLevel = AmqpConstants.Vendor + ":epoch";

        /// <summary>The type of Event Hubs entity to associate with a link.</summary>
        public static readonly AmqpSymbol EntityType = AmqpConstants.Vendor + ":entity-type";

        /// <summary>The timeout to associate with a link.</summary>
        public static readonly AmqpSymbol Timeout = AmqpConstants.Vendor + ":timeout";

        /// <summary>The identifier of the consumer to associate with a link.</summary>
        public static readonly AmqpSymbol ReceiverIdentifier = AmqpConstants.Vendor + ":receiver-name";

        /// <summary>A type annotation for representing a <see cref="System.TimeSpan" /> in a message.</summary>
        public static readonly AmqpSymbol TimeSpan = AmqpConstants.Vendor + ":timespan";

        /// <summary>A type annotation for representing a <see cref="System.Uri" /> in a message.</summary>
        public static readonly AmqpSymbol Uri = AmqpConstants.Vendor + ":uri";

        /// <summary>A type annotation for representing a <see cref="System.DateTimeOffset" /> in a message.</summary>
        public static readonly AmqpSymbol DateTimeOffset = AmqpConstants.Vendor + ":datetime-offset";

        /// <summary>
        ///   Represents the type mapping for AMQP properties between the client library and
        ///   the Event Hubs service.
        /// </summary>
        ///
        /// <remarks>
        ///   WARNING:
        ///     These values are synchonized between the Event Hubs service and the client
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
