// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Traits to be included when listing shares with the
    /// <see cref="ShareDirectoryClient.GetFilesAndDirectoriesAsync(string, System.Threading.CancellationToken)"/> operations.
    /// </summary>
    [Flags]
    public enum ShareFileTraits
    {
        /// <summary>
        /// Default value specifying that no flags are set in <see cref="ShareFileTraits"/>.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that timestamps should be included.
        /// </summary>
        Timestamps = 1,

        /// <summary>
        /// Indicates that ETag should be included.
        /// </summary>
        ETag = 2,

        /// <summary>
        /// Indicates that attributes should be included.
        /// </summary>
        Attributes = 4,

        /// <summary>
        /// Indicates that permission key should be included.
        /// </summary>
        PermissionKey = 8,

        /// <summary>
        /// Flag specifying that all traits should be included.
        /// </summary>
        All = ~None
    }
}
