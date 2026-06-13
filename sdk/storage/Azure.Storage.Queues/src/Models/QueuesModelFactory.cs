// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
    [CodeGenType("StorageQueuesModelFactory")]
    public static partial class QueuesModelFactory
    {
        /// <summary>
        /// Creates a new QueueMessage instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static QueueMessage QueueMessage(
            string messageId,
            string popReceipt,
            string messageText,
            long dequeueCount,
            System.DateTimeOffset? nextVisibleOn = default,
            System.DateTimeOffset? insertedOn = default,
            System.DateTimeOffset? expiresOn = default)
        {
            return new QueueMessage()
            {
                MessageId = messageId,
                PopReceipt = popReceipt,
                Body = new BinaryData(messageText),
                DequeueCount = dequeueCount,
                NextVisibleOn = nextVisibleOn,
                InsertedOn = insertedOn,
                ExpiresOn = expiresOn,
            };
        }

        /// <summary>
        /// Creates a new QueueMessage instance for mocking.
        /// </summary>
        public static QueueMessage QueueMessage(
            string messageId,
            string popReceipt,
            BinaryData body,
            long dequeueCount,
            System.DateTimeOffset? nextVisibleOn = default,
            System.DateTimeOffset? insertedOn = default,
            System.DateTimeOffset? expiresOn = default)
        {
            return new QueueMessage()
            {
                MessageId = messageId,
                PopReceipt = popReceipt,
                Body = body,
                DequeueCount = dequeueCount,
                NextVisibleOn = nextVisibleOn,
                InsertedOn = insertedOn,
                ExpiresOn = expiresOn,
            };
        }

        /// <summary>
        /// Creates a new PeekedMessage instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PeekedMessage PeekedMessage(
            string messageId,
            string messageText,
            long dequeueCount,
            System.DateTimeOffset? insertedOn = default,
            System.DateTimeOffset? expiresOn = default)
        {
            return new PeekedMessage()
            {
                MessageId = messageId,
                Body = new BinaryData(messageText),
                DequeueCount = dequeueCount,
                InsertedOn = insertedOn,
                ExpiresOn = expiresOn,
            };
        }

        /// <summary>
        /// Creates a new PeekedMessage instance for mocking.
        /// </summary>
        public static PeekedMessage PeekedMessage(
            string messageId,
            BinaryData message,
            long dequeueCount,
            System.DateTimeOffset? insertedOn = default,
            System.DateTimeOffset? expiresOn = default)
        {
            return new PeekedMessage()
            {
                MessageId = messageId,
                Body = message,
                DequeueCount = dequeueCount,
                InsertedOn = insertedOn,
                ExpiresOn = expiresOn,
            };
        }

        /// <summary>
        /// Creates a new QueueItem instance for mocking.
        /// </summary>
        public static QueueItem QueueItem(
            string name,
            IDictionary<string, string> metadata = default)
        {
            return new QueueItem()
            {
                Name = name,
                Metadata = metadata,
            };
        }

        /// <summary>
        /// Creates a new QueueProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static QueueProperties QueueProperties(
            IDictionary<string, string> metadata,
            int approximateMessagesCount)
        {
            return new QueueProperties()
            {
                Metadata = metadata,
                ApproximateMessagesCount = approximateMessagesCount,
            };
        }

        /// <summary>
        /// Creates a new QueueProperties instance for mocking.
        /// </summary>
        public static QueueProperties QueueProperties(
            IDictionary<string, string> metadata,
            long approximateMessagesCount)
        {
            return new QueueProperties()
            {
                Metadata = metadata,
                ApproximateMessagesCountLong = approximateMessagesCount,
            };
        }

        /// <summary>
        /// Creates a new QueueServiceStatistics instance for mocking.
        /// </summary>
        public static QueueServiceStatistics QueueServiceStatistics(
            QueueGeoReplication geoReplication = default)
        {
            return new QueueServiceStatistics()
            {
                GeoReplication = geoReplication,
            };
        }

        /// <summary>
        /// Creates a new UpdateReceipt instance for mocking.
        /// </summary>
        public static UpdateReceipt UpdateReceipt(
            string popReceipt,
            DateTimeOffset nextVisibleOn)
        {
            return new UpdateReceipt()
            {
                PopReceipt = popReceipt,
                NextVisibleOn = nextVisibleOn,
            };
        }

        /// <summary>
        /// Creates a new SendReceipt instance for mocking.
        /// </summary>
        public static SendReceipt SendReceipt(
            string messageId,
            DateTimeOffset insertionTime,
            DateTimeOffset expirationTime,
            string popReceipt,
            DateTimeOffset timeNextVisible)
        {
            return new SendReceipt()
            {
                MessageId = messageId,
                InsertionTime = insertionTime,
                ExpirationTime = expirationTime,
                PopReceipt = popReceipt,
                TimeNextVisible = timeNextVisible,
            };
        }

        /// <summary>
        /// Creates a new QueueGeoReplication instance for mocking.
        /// </summary>
        public static QueueGeoReplication QueueGeoReplication(
            QueueGeoReplicationStatus status,
            DateTimeOffset? lastSyncedOn = default)
        {
            return new QueueGeoReplication()
            {
                Status = status,
                LastSyncedOn = lastSyncedOn,
            };
        }

        /// <summary>
        /// Creates a new UserDelegationKey instance for mocking.
        /// </summary>
        public static UserDelegationKey UserDelegationKey(
            string signedObjectId = default,
            string signedTenantId = default,
            DateTimeOffset signedStartsOn = default,
            DateTimeOffset signedExpiresOn = default,
            string signedService = default,
            string signedVersion = default,
            string signedDelegatedUserTenantId = default,
            string value = default)
        {
            return new UserDelegationKey()
            {
                SignedObjectId = signedObjectId,
                SignedTenantId = signedTenantId,
                SignedStartsOn = signedStartsOn,
                SignedExpiresOn = signedExpiresOn,
                SignedService = signedService,
                SignedVersion = signedVersion,
                SignedDelegatedUserTenantId = signedDelegatedUserTenantId,
                Value = value
            };
        }

        /// <summary>
        /// Creates a new UserDelegationKey instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static UserDelegationKey UserDelegationKey(
            string signedObjectId,
            string signedTenantId,
            DateTimeOffset signedStartsOn,
            DateTimeOffset signedExpiresOn,
            string signedService,
            string signedVersion,
            string value)
        {
            return new UserDelegationKey()
            {
                SignedObjectId = signedObjectId,
                SignedTenantId = signedTenantId,
                SignedStartsOn = signedStartsOn,
                SignedExpiresOn = signedExpiresOn,
                SignedService = signedService,
                SignedVersion = signedVersion,
                Value = value
            };
        }
    }
}
