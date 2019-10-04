// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace TrackOne
{
    /// <summary>
    /// Options to define partition key and maximum message size while creating an <see cref="EventDataBatch"/>.
    /// </summary>
    internal class BatchOptions
    {
        /// <summary>
        /// Partition key associate with the batch.
        /// </summary>
        public string PartitionKey { get; set; }

        /// <summary>
        /// The maximum size allowed for the batch.
        /// </summary>
        public long MaxMessageSize { get; set; }
    }
}
