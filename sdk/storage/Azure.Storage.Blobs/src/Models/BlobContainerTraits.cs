// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies options for listing blob containers with the
    /// <see cref="BlobServiceClient.GetBlobContainersAsync"/> operation.
    /// </summary>
    [Flags]
    public enum BlobContainerTraits
    {
        /// <summary>
        /// Default flag specifying that no flags are set in <see cref="BlobContainerTraits"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that the container's metadata should
        /// be included.
        /// </summary>
        Metadata = 1,
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// BlobContainerTraits enum extensions
    /// </summary>
    internal static partial class BlobExtensions
    {
        /// <summary>
        /// Convert the details into a ListBlobContainersIncludeType value.
        /// </summary>
        /// <returns>A ListBlobContainersIncludeType value.</returns>
        internal static ListBlobContainersIncludeType? AsIncludeType(this BlobContainerTraits traits)
            => (traits & BlobContainerTraits.Metadata) == BlobContainerTraits.Metadata ?
                ListBlobContainersIncludeType.Metadata :
                (ListBlobContainersIncludeType?)null;
    }
}
