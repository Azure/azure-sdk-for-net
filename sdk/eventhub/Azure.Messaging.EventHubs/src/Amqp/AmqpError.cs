// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of well-known error codes associated with an AMQP messages and
    ///   entities.
    /// </summary>
    ///
    internal static class AmqpError
    {
        /// <summary>Indicates that a timeout occurred on the link.</summary>
        public static readonly AmqpSymbol TimeoutError = AmqpConstants.Vendor + ":timeout";

        /// <summary>Indicates that a message is no longer available.</summary>
        public static readonly AmqpSymbol MessageLockLostError = AmqpConstants.Vendor + ":message-lock-lost";

        /// <summary>Indicates that a session is no longer available.</summary>
        public static readonly AmqpSymbol SessionLockLostError = AmqpConstants.Vendor + ":session-lock-lost";

        /// <summary>Indicates that a store is no longer available.</summary>
        public static readonly AmqpSymbol StoreLockLostError = AmqpConstants.Vendor + ":store-lock-lost";

        /// <summary>Indicates that a session is no longer available.</summary>
        public static readonly AmqpSymbol SessionCannotBeLockedError = AmqpConstants.Vendor + ":session-cannot-be-locked";

        /// <summary>Indicates that a referenced subscription is no longer available.</summary>
        public static readonly AmqpSymbol NoMatchingSubscriptionError = AmqpConstants.Vendor + ":no-matching-subscription";

        /// <summary>Indicates that the server was busy and could not allow the requested operation.</summary>
        public static readonly AmqpSymbol ServerBusyError = AmqpConstants.Vendor + ":server-busy";

        /// <summary>Indicates that an argument provided to the Event Hubs service was incorrect.</summary>
        public static readonly AmqpSymbol ArgumentError = AmqpConstants.Vendor + ":argument-error";

        /// <summary>Indicates that an argument provided to the Event Hubs service was incorrect.</summary>
        public static readonly AmqpSymbol ArgumentOutOfRangeError = AmqpConstants.Vendor + ":argument-out-of-range";

        /// <summary>Indicates that the consumer requesting an operation does not own the associated partition.</summary>
        public static readonly AmqpSymbol PartitionNotOwnedError = AmqpConstants.Vendor + ":partition-not-owned";

        /// <summary>Indicates that the requested Event Hubs resource is disabled.</summary>
        public static readonly AmqpSymbol ResourceDisabledError = AmqpConstants.Vendor + ":entity-disabled";

        /// <summary>Indicates that the producer requesting an operation is not allowed to publish events to the requested resource.</summary>
        public static readonly AmqpSymbol PublisherRevokedError = AmqpConstants.Vendor + ":publisher-revoked";

        /// <summary>Indicates that an operation was canceled by the Event Hubs service.</summary>
        public static readonly AmqpSymbol OperationCancelledError = AmqpConstants.Vendor + ":operation-cancelled";

        /// <summary>Indicates that the requested resource cannot be created because it already exists.</summary>
        public static readonly AmqpSymbol ResourceAlreadyExistsError = AmqpConstants.Vendor + ":entity-already-exists";
    }
}
