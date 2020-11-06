// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueuesModelFactory provides utilities for mocking.
    /// </summary>
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
    }
}
