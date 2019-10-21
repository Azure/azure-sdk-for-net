// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Get
    /// Messages on a Queue.
    /// </summary>
    public partial class QueueMessage
    {
        /// <summary>
        /// Cached message text as bytes.
        /// </summary>
        private byte[] _bytes = null;

        /// <summary>
        /// Gets the Base 64 encoded <see cref="MessageText"/> as bytes.
        /// </summary>
        /// <returns>
        /// The Base 64 encoded <see cref="MessageText"/> as bytes.
        /// </returns>
        public byte[] GetMessageBytes()
        {
            if (_bytes == null)
            {
                _bytes = Convert.FromBase64String(MessageText);
            }
            return _bytes;
        }

        /// <summary>
        /// Update a <see cref="QueueMessage"/> after calling
        /// <see cref="QueueClient.UpdateMessageAsync(string, string, string, TimeSpan, System.Threading.CancellationToken)"/>
        /// with the resulting <see cref="UpdateReceipt"/>.
        /// </summary>
        /// <param name="updated">The message details.</param>
        /// <returns>The updated <see cref="QueueMessage"/>.</returns>
        public QueueMessage Update(UpdateReceipt updated) =>
            QueuesModelFactory.QueueMessage(
                MessageId,
                InsertionTime,
                ExpirationTime,
                updated.PopReceipt,
                updated.TimeNextVisible,
                DequeueCount,
                MessageText);

        /// <summary>
        /// Update a <see cref="QueueMessage"/> after calling
        /// <see cref="QueueClient.UpdateMessageAsync(string, string, string, TimeSpan, System.Threading.CancellationToken)"/>
        /// with the resulting <see cref="UpdateReceipt"/>.
        /// </summary>
        /// <param name="updated">The message details.</param>
        /// <param name="updatedMessageText">The updated message text.</param>
        /// <returns>The updated <see cref="QueueMessage"/>.</returns>
        public QueueMessage Update(UpdateReceipt updated, string updatedMessageText) =>
            QueuesModelFactory.QueueMessage(
                MessageId,
                InsertionTime,
                ExpirationTime,
                updated.PopReceipt,
                updated.TimeNextVisible,
                DequeueCount,
                updatedMessageText);

        /// <summary>
        /// Update a <see cref="QueueMessage"/> after calling
        /// <see cref="QueueClient.UpdateMessageAsync(string, string, byte[], TimeSpan, System.Threading.CancellationToken)"/>
        /// with the resulting <see cref="UpdateReceipt"/>.
        /// </summary>
        /// <param name="updated">The message details.</param>
        /// <param name="updatedMessageBytes">The updated message bytes.</param>
        /// <returns>The updated <see cref="QueueMessage"/>.</returns>
        public QueueMessage Update(UpdateReceipt updated, byte[] updatedMessageBytes) =>
            QueuesModelFactory.QueueMessage(
                MessageId,
                InsertionTime,
                ExpirationTime,
                updated.PopReceipt,
                updated.TimeNextVisible,
                DequeueCount,
                Convert.ToBase64String(updatedMessageBytes));
    }
}
