// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    /// <summary>
    /// Options to define partiton key and maximum message size while creating an <see cref="EventDataBatch"/>. 
    /// </summary>
    public class BatchOptions
    {
        /// <summary>
        /// Partition key associated with the batch.
        /// </summary>
        public string PartitionKey { get; set; }

        /// <summary>
        /// The maximum size allowed for the batch.
        /// </summary>
        public long MaxMessageSize { get; set; }
    }
}
