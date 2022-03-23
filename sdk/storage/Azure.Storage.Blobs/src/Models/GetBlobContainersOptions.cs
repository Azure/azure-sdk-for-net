// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for GetBlobContainers.
    /// </summary>
    public class GetBlobContainersOptions
    {
        /// <summary>
        /// Specifies trait options for shaping the blob containers.
        /// </summary>
        public BlobContainerTraits Traits { get; set; }

        /// <summary>
        /// Specifies state options for shaping the blob containers.
        /// </summary>
        public BlobContainerStates States { get; set; }

        /// <summary>
        /// Specifies a string that filters the results to return only containers
        /// whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Geo-redundant (GRS) and Geo-zone-redundant (GZRS) storage accounts only.
        /// Allows client to override replication lock for read operations.
        /// </summary>
        public bool? IgnoreStrongConsistencyLock { get; set; }
    }
}
