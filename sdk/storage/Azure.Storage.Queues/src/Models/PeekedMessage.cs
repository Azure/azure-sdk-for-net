// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// The object returned in the QueueMessageList array when calling Peek Messages on a Queue
    /// </summary>
    public partial class PeekedMessage
    {
        /// <summary>
        /// The Id of the Message.
        /// </summary>
        public string MessageId { get; internal set; }

        /// <summary>
        /// The content of the Message.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string MessageText
        {
            get => Body.ToString();
            internal set => Body = new BinaryData(value);
        }

        /// <summary>
        /// The content of the Message.
        /// </summary>
        public BinaryData Body { get; internal set; }

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
        /// Prevent direct instantiation of PeekedMessage instances.
        /// You can use QueuesModelFactory.PeekedMessage instead.
        /// </summary>
        internal PeekedMessage() { }

        internal static PeekedMessage ToPeekedMessage(PeekedMessageItem peekedMessageItem, QueueMessageEncoding messageEncoding)
        {
            return new PeekedMessage()
            {
                MessageId = peekedMessageItem.MessageId,
                DequeueCount = peekedMessageItem.DequeueCount,
                Body = QueueMessageCodec.DecodeMessageBody(peekedMessageItem.MessageText, messageEncoding),
                ExpiresOn = peekedMessageItem.ExpirationTime,
                InsertedOn = peekedMessageItem.InsertionTime,
            };
        }
    }
}
