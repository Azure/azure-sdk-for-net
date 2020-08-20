// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

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
                Message = new BinaryData(messageText),
                DequeueCount = dequeueCount,
                NextVisibleOn = nextVisibleOn,
                InsertedOn = insertedOn,
                ExpiresOn = expiresOn,
            };
        }
    }
}
