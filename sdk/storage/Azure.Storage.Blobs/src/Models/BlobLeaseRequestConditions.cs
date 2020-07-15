// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies access conditions for leasing operations on a container or blob.
    /// </summary>
    public class BlobLeaseRequestConditions : RequestConditions
    {
        /// <summary>
        /// Optional SQL statement to apply to the Tags of the Blob.
        /// </summary>
        public string TagConditions { get; set; }
    }
}
