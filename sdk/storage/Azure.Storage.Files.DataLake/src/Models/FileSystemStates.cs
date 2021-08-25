// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Specifies options for listing blob containers with the
    /// <see cref="DataLakeServiceClient.GetFileSystems(FileSystemTraits, FileSystemStates, string, System.Threading.CancellationToken)"></see>
    /// operation.
    /// </summary>
    [Flags]
    public enum FileSystemStates
    {
        /// <summary>
        /// Default flag specifying that no flags are set in <see cref="FileSystemStates"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Flag specifying that deleted containers should be included.
        /// </summary>
        Deleted = 1,
    }
}
