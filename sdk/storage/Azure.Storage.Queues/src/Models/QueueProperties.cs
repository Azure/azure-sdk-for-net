// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueProperties.
    /// </summary>
    public class QueueProperties
    {
        /// <summary>
        /// Metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The approximate number of messages in the queue. This number is not lower than the actual number of messages in the queue, but could be higher.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ApproximateMessagesCount
        {
            get => (int)ApproximateMessagesCountLong;
            internal set => ApproximateMessagesCountLong = value;
        }

        /// <summary>
        /// The approximate number of messages in the queue. This number is not lower than the actual number of messages in the queue, but could be higher.
        /// </summary>
        public long ApproximateMessagesCountLong { get; internal set; }

        /// <summary>
        /// Creates a new QueueProperties instance
        /// </summary>
        public QueueProperties()
        {
            Metadata = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
        }
    }
}
