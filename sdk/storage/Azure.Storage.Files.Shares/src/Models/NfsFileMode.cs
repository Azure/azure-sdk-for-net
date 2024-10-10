// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Only applicable to NFS files and directories.
    /// The mode permissions of the file or directory.
    /// </summary>
    public class NfsFileMode
    {
        /// <summary>
        /// Permissions the owner has over the file or directory.
        /// </summary>
        public RolePermissions Owner { get; set; }

        /// <summary>
        /// Permissions the group has over the file or directory.
        /// </summary>
        public RolePermissions Group { get; set; }

        /// <summary>
        /// Permissions others have over the file or directory.
        /// </summary>
        public RolePermissions Others { get; set; }

        /// <summary>
        /// Set effective user ID (setuid) on the file or directory.
        /// </summary>
        public bool EffectiveUserIdentity { get; set; }

        /// <summary>
        /// Set effective group ID (setgid) on the file or directory.
        /// </summary>
        public bool EffectiveGroupIdentity { get; set; }

        /// <summary>
        /// The sticky bit may be set on directories.  The files in that
        /// directory may only be renamed or deleted by the file's owner, the directory's owner, or the root user.
        /// </summary>
        public bool StickyBit { get; set; }
    }
}
