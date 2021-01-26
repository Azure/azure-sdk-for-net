// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueRetentionPolicy.
    /// </summary>
    [CodeGenModel("RetentionPolicy")]
    public partial class QueueRetentionPolicy
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public QueueRetentionPolicy() { }

        internal QueueRetentionPolicy(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
