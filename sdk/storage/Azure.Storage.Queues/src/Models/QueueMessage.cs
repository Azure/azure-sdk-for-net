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
    public partial class QueueMessage
    {
        /// <summary>
        /// Update a <see cref="UpdateReceipt"/> after calling
        /// <see cref="QueueClient.UpdateMessageAsync"/> with the resulting
        /// <see cref="UpdateReceipt"/>.
        /// </summary>
        /// <param name="updated">The message details.</param>
        /// <returns>The updated <see cref="QueueMessage"/>.</returns>
        public QueueMessage Update(UpdateReceipt updated) =>
            QueuesModelFactory.QueueMessage(
                MessageId,
                updated.PopReceipt,
                MessageText,
                DequeueCount,
                updated.NextVisibleOn,
                InsertedOn,
                ExpiresOn);
    }
}
