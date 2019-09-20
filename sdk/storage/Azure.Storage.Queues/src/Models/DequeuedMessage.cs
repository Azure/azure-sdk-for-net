// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

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
    public partial class DequeuedMessage
    {
        /// <summary>
        /// Update a <see cref="DequeuedMessage"/> after calling
        /// <see cref="QueueClient.UpdateMessageAsync"/> with the resulting
        /// <see cref="UpdatedMessage"/>.
        /// </summary>
        /// <param name="updated">The message details.</param>
        /// <returns>The updated <see cref="DequeuedMessage"/>.</returns>
        public DequeuedMessage Update(UpdatedMessage updated) =>
            QueuesModelFactory.DequeuedMessage(
                MessageId,
                InsertionTime,
                ExpirationTime,
                updated.PopReceipt,
                updated.TimeNextVisible,
                DequeueCount,
                MessageText);
    }
}
