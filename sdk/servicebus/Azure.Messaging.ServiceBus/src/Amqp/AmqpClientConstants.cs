﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

namespace Azure.Messaging.ServiceBus.Amqp
{
    internal class AmqpClientConstants
    {
        // AMQP Management Operation
        public const string ManagementAddress = "$management";
        public const string EntityTypeManagement = "entity-mgmt";
        public const string EntityNameKey = "name";
        public const string PartitionNameKey = "partition";
        public const string ManagementOperationKey = "operation";
        public const string ReadOperationValue = "READ";
        public const string ManagementEntityTypeKey = "type";
        public const string ManagementSecurityTokenKey = "security_token";

        // Filters
        public const string FilterOffsetPartName = "amqp.annotation.x-opt-offset";
        public const string FilterOffset = FilterOffsetPartName + " > ";
        public const string FilterInclusiveOffset = FilterOffsetPartName + " >= ";
        public const string FilterOffsetFormatString = FilterOffset + "'{0}'";
        public const string FilterInclusiveOffsetFormatString = FilterInclusiveOffset + "'{0}'";
        public const string FilterReceivedAtPartNameV1 = "amqp.annotation.x-opt-enqueuedtimeutc";
        public const string FilterReceivedAtPartNameV2 = "amqp.annotation.x-opt-enqueued-time";
        public const string FilterReceivedAt = FilterReceivedAtPartNameV2 + " > ";
        public const string FilterReceivedAtFormatString = FilterReceivedAt + "{0}";
        public static readonly AmqpSymbol SessionFilterName = AmqpConstants.Vendor + ":session-filter";
        public static readonly AmqpSymbol MessageReceiptsFilterName = AmqpConstants.Vendor + ":message-receipts-filter";
        public static readonly AmqpSymbol ClientSideCursorFilterName = AmqpConstants.Vendor + ":client-side-filter";
        public static readonly TimeSpan ClientMinimumTokenRefreshInterval = TimeSpan.FromMinutes(4);

        // Properties
        public static readonly AmqpSymbol AttachEpoch = AmqpConstants.Vendor + ":epoch";
        public static readonly AmqpSymbol BatchFlushIntervalName = AmqpConstants.Vendor + ":batch-flush-interval";
        public static readonly AmqpSymbol EntityTypeName = AmqpConstants.Vendor + ":entity-type";
        public static readonly AmqpSymbol TransferDestinationAddress = AmqpConstants.Vendor + ":transfer-destination-address";
        public static readonly AmqpSymbol TimeoutName = AmqpConstants.Vendor + ":timeout";
        public static readonly AmqpSymbol TrackingIdName = AmqpConstants.Vendor + ":tracking-id";

        // Error codes
        public static readonly AmqpSymbol DeadLetterName = AmqpConstants.Vendor + ":dead-letter";
        public static readonly AmqpSymbol TimeoutError = AmqpConstants.Vendor + ":timeout";
        public static readonly AmqpSymbol AddressAlreadyInUseError = AmqpConstants.Vendor + ":address-already-in-use";
        public static readonly AmqpSymbol AuthorizationFailedError = AmqpConstants.Vendor + ":auth-failed";
        public static readonly AmqpSymbol MessageLockLostError = AmqpConstants.Vendor + ":message-lock-lost";
        public static readonly AmqpSymbol SessionLockLostError = AmqpConstants.Vendor + ":session-lock-lost";
        public static readonly AmqpSymbol StoreLockLostError = AmqpConstants.Vendor + ":store-lock-lost";
        public static readonly AmqpSymbol SessionCannotBeLockedError = AmqpConstants.Vendor + ":session-cannot-be-locked";
        public static readonly AmqpSymbol NoMatchingSubscriptionError = AmqpConstants.Vendor + ":no-matching-subscription";
        public static readonly AmqpSymbol ServerBusyError = AmqpConstants.Vendor + ":server-busy";
        public static readonly AmqpSymbol ArgumentError = AmqpConstants.Vendor + ":argument-error";
        public static readonly AmqpSymbol ArgumentOutOfRangeError = AmqpConstants.Vendor + ":argument-out-of-range";
        public static readonly AmqpSymbol PartitionNotOwnedError = AmqpConstants.Vendor + ":partition-not-owned";
        public static readonly AmqpSymbol EntityDisabledError = AmqpConstants.Vendor + ":entity-disabled";
        public static readonly AmqpSymbol PublisherRevokedError = AmqpConstants.Vendor + ":publisher-revoked";
        public static readonly AmqpSymbol OperationCancelledError = AmqpConstants.Vendor + ":operation-cancelled";
        public static readonly AmqpSymbol EntityAlreadyExistsError = AmqpConstants.Vendor + ":entity-already-exists";
        public static readonly AmqpSymbol RelayNotFoundError = AmqpConstants.Vendor + ":relay-not-found";
        public static readonly AmqpSymbol MessageNotFoundError = AmqpConstants.Vendor + ":message-not-found";
        public static readonly AmqpSymbol LockedUntilUtc = AmqpConstants.Vendor + ":locked-until-utc";
    }
}
