// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// UpdateReceipt
    /// </summary>
    public class UpdateReceipt
    {
        /// <summary>
        /// A UTC date/time value that represents when the message will be visible on the queue.
        /// </summary>
        public DateTimeOffset NextVisibleOn { get; internal set; }

        /// <summary>
        /// The pop receipt of the queue message.
        /// </summary>
        public string PopReceipt { get; internal set; }

        internal UpdateReceipt() { }
    }
}
