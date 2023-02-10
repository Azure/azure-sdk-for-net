// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueItem.
    /// </summary>
    public partial class QueueItem
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        internal QueueItem() { }

        /// <summary>
        /// The name of the Queue.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Metadata
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }
    }
}
