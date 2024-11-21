// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Get
    /// Messages on a Queue.
    /// </summary>
    public partial class QueueMessage
    {
        internal QueueMessage() { }

        internal QueueMessage(string messageText)
        {
            MessageText = messageText;
        }

        /// <summary>
        /// The Id of the Message.
        /// </summary>
        public string MessageId { get; internal set; }

        /// <summary>
        /// This value is required to delete the Message. If deletion fails using this popreceipt then the message has been dequeued by another client.
        /// </summary>
        public string PopReceipt { get; internal set; }

        /// <summary>
        /// The content of the Message.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MessageText
        {
            get
            {
                try
                {
                    return Body?.ToString();
                }
                catch (ArgumentNullException) // workaround for: https://github.com/dotnet/runtime/issues/68262 which was fixed in 8.0.0, can remove this after upgrade
                {
                    return string.Empty;
                }
            }
            internal set => Body = value == null ? null : new BinaryData(value);
        }

        /// <summary>
        /// The content of the Message.
        /// </summary>
        public BinaryData Body { get; internal set; }

        /// <summary>
        /// The time that the message will again become visible in the Queue.
        /// </summary>
        public System.DateTimeOffset? NextVisibleOn { get; internal set; }

        /// <summary>
        /// The time the Message was inserted into the Queue.
        /// </summary>
        public System.DateTimeOffset? InsertedOn { get; internal set; }

        /// <summary>
        /// The time that the Message will expire and be automatically deleted.
        /// </summary>
        public System.DateTimeOffset? ExpiresOn { get; internal set; }

        /// <summary>
        /// The number of times the message has been dequeued.
        /// </summary>
        public long DequeueCount { get; internal set; }

        /// <summary>
        /// Update a <see cref="UpdateReceipt"/> after calling
        /// <see cref="QueueClient.UpdateMessageAsync(string, string, BinaryData?, System.TimeSpan, System.Threading.CancellationToken)"/> with the resulting
        /// <see cref="UpdateReceipt"/>.
        /// </summary>
        /// <param name="updated">The message details.</param>
        /// <returns>The updated <see cref="QueueMessage"/>.</returns>
        public QueueMessage Update(UpdateReceipt updated) =>
            QueuesModelFactory.QueueMessage(
                MessageId,
                updated.PopReceipt,
                Body,
                DequeueCount,
                updated.NextVisibleOn,
                InsertedOn,
                ExpiresOn);

        internal static QueueMessage ToQueueMessage(DequeuedMessageItem dequeuedMessageItem, QueueMessageEncoding messageEncoding)
        {
            if (dequeuedMessageItem == null)
            {
                return null;
            }

            return new QueueMessage()
            {
                MessageId = dequeuedMessageItem.MessageId,
                PopReceipt = dequeuedMessageItem.PopReceipt,
                Body = QueueMessageCodec.DecodeMessageBody(dequeuedMessageItem.MessageText, messageEncoding),
                DequeueCount = dequeuedMessageItem.DequeueCount,
                NextVisibleOn = dequeuedMessageItem.TimeNextVisible,
                InsertedOn = dequeuedMessageItem.InsertionTime,
                ExpiresOn = dequeuedMessageItem.ExpirationTime,
            };
        }
    }
}
