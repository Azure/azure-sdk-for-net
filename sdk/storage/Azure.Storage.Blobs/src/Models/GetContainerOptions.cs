// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Specifies options for listing containers with the
    /// <see cref="BlobServiceClient.GetBlobContainersAsync"/> operation.
    /// </summary>
    [Flags]
    public enum GetContainerOptions
    {
        /// <summary>
        /// Default flag specifying that no flags are set in <see cref="GetContainerOptions"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Gets or sets a flag specifing that the container's metadata should
        /// be included.
        /// </summary>
        Metadata = 1,
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// GetContainerOptions enum extensions
    /// </summary>
    internal static partial class BlobExtensions
    {
        /// <summary>
        /// Convert the details into ListBlobsIncludeItem values.
        /// </summary>
        /// <returns>ListBlobsIncludeItem values</returns>
        /// <summary>
        /// Convert the details into a ListContainersIncludeType value.
        /// </summary>
        /// <returns>A ListContainersIncludeType value.</returns>
        internal static ListBlobContainersIncludeType? AsIncludeType(this GetContainerOptions options)
                => options.HasFlag(GetContainerOptions.Metadata) ?
                    ListBlobContainersIncludeType.Metadata :
                    (ListBlobContainersIncludeType?)null;
    }
}
