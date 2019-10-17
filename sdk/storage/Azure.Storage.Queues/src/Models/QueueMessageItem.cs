// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Get
    /// Messages on a Queue.
    /// </summary>
    public partial class QueueMessageItem
    {
        /// <summary>
        /// Update a <see cref="UpdateMessageResult"/> after calling
        /// <see cref="QueueClient.UpdateMessageAsync"/> with the resulting
        /// <see cref="UpdateMessageResult"/>.
        /// </summary>
        /// <param name="updated">The message details.</param>
        /// <returns>The updated <see cref="QueueMessageItem"/>.</returns>
        public QueueMessageItem Update(UpdateMessageResult updated) =>
            QueuesModelFactory.QueueMessageItem(
                MessageId,
                InsertionTime,
                ExpirationTime,
                updated.PopReceipt,
                updated.TimeNextVisible,
                DequeueCount,
                MessageText);
    }
}
