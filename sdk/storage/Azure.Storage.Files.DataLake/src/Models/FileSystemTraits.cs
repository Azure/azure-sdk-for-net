// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Specifies options for listing file systems with the
    /// <see cref="DataLakeServiceClient.GetFileSystems(FileSystemTraits, FileSystemStates, string, System.Threading.CancellationToken)"/> operation.
    /// </summary>
    [Flags]
    public enum FileSystemTraits
    {
        /// <summary>
        /// Default flag specifying that no flags are set in <see cref="FileSystemTraits"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that the file system's metadata should
        /// be included.
        /// </summary>
        Metadata = 1,
    }
}
