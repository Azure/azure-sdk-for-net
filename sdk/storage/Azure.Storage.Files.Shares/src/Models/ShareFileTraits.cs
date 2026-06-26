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
        /// Supported for SMB in version 2020-04-08 and above.
        /// Supported for NFS in version 2026-12-06 and above.
        /// </summary>
        Timestamps = 1,

        /// <summary>
        /// Indicates that ETag should be included.
        /// Supported for SMB in version 2020-04-08 and above.
        /// Supported for NFS in version 2026-12-06 and above.
        /// </summary>
        ETag = 2,

        /// <summary>
        /// Indicates that attributes should be included.
        /// Supported for SMB in version 2020-04-08 and above. Not applicable to NFS shares.
        /// </summary>
        Attributes = 4,

        /// <summary>
        /// Indicates that permission key should be included.
        /// Supported for SMB in version 2020-04-08 and above. Not applicable to NFS shares.
        /// </summary>
        PermissionKey = 8,

        /// <summary>
        /// Indicates that permission information should be included
        /// Only applicable to NFS shares.
        /// Supported in version 2026-12-06 and above.
        /// </summary>
        Permissions = 16,

        /// <summary>
        /// Indicates that the count of hard links should be included.
        /// Only applicable to NFS shares.
        /// Supported in version 2026-12-06 and above.
        /// </summary>
        LinkCount = 32,

        /// <summary>
        /// Indicates that NFS-style attributes should be included.
        /// Only applicable to NFS shares.
        /// Supported in version 2026-12-06 and above.
        /// </summary>
        NfsAttributes = 64,

        /// <summary>
        /// Flag specifying that all traits should be included.
        /// </summary>
        All = ~None
    }
}
