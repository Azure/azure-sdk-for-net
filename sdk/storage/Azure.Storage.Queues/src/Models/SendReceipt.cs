// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// SendReceipt.
    /// </summary>
    [CodeGenModel("EnqueuedMessage")]
    public partial class SendReceipt
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        internal SendReceipt() { }

        /// <summary> The Id of the Message. </summary>
        [CodeGenMember("MessageId")]
        public string MessageId { get; internal set; }

        /// <summary> The time the Message was inserted into the Queue. </summary>
        [CodeGenMember("InsertionTime")]
        public DateTimeOffset InsertionTime { get; internal set; }

        /// <summary> The time that the Message will expire and be automatically deleted. </summary>
        [CodeGenMember("ExpirationTime")]
        public DateTimeOffset ExpirationTime { get; internal set; }

        /// <summary> This value is required to delete the Message. If deletion fails using this popreceipt then the message has been dequeued by another client. </summary>

        [CodeGenMember("PopReceipt")]
        public string PopReceipt { get; internal set; }
        /// <summary> The time that the message will again become visible in the Queue. </summary>

        [CodeGenMember("TimeNextVisible")]
        public DateTimeOffset TimeNextVisible { get; internal set; }
    }
}
