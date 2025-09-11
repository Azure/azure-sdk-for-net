// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlobContainerClient.GetBlobsAsync(GetBlobsOptions, System.Threading.CancellationToken)"/>
    /// and <see cref="BlobContainerClient.GetBlobsAsync(GetBlobsOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class GetBlobsOptions
    {
        /// <summary>
        /// Optional.  Specifies trait options for shaping the blobs.
        /// </summary>
        public BlobTraits Traits { get; set; }

        /// <summary>
        /// Optional.  Specifies state options for filtering the blobs.
        /// </summary>
        public BlobStates States { get; set; }

        /// <summary>
        /// Optional.  Specifies a string that filters the results to return only blobs
        /// whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Optional.  Specifies a fully qualified path within the container, similar to how the prefix parameter
        /// is used to list paths starting from a defined location within prefix’s specified range.
        /// For non-recursive list, only one entity level is supported.
        /// </summary>
        public string StartFrom { get; set; }
    }
}
