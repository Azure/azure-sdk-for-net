// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies options for listing blob containers with the
    /// <see cref="BlobServiceClient.GetBlobContainersAsync(BlobContainerTraits, BlobContainerStates, string, System.Threading.CancellationToken)"/>
    /// operation.
    /// </summary>
    [Flags]
    public enum BlobContainerStates
    {
        /// <summary>
        /// Default flag specifying that no flags are set in <see cref="BlobContainerTraits"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that deleted containers should be included.
        /// </summary>
        Deleted = 1,
    }
}
