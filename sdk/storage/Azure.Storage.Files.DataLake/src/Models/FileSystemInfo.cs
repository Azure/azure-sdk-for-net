// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// FileSystemInfo
    /// </summary>
    public class FileSystemInfo : BlobContainerInfo
    {
        /// <summary>
        /// Prevent direct instantiation of FileSystemInfo instances.
        /// You can use DataLakeModelFactory.FileSystemInfo instead.
        /// </summary>
        internal FileSystemInfo() { }
    }
}
