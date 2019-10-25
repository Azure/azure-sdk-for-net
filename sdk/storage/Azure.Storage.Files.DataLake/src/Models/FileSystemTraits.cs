// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Specifies options for listing blob containers with the
    /// <see cref="DataLakeServiceClient.GetFileSystemsAsync"/> operation.
    /// </summary>
    [Flags]
    public enum FileSystemTraits
    {
        /// <summary>
        /// Default flag specifying that no flags are set in <see cref="FileSystemTraits"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that the container's metadata should
        /// be included.
        /// </summary>
        Metadata = 1,
    }
}
