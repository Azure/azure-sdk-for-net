// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// NFS properties.
    /// Note that these properties only apply to files or directories in
    /// premium NFS file accounts.
    /// </summary>
    public class FileNfsProperties
    {
        /// <summary>
        /// Optional. Version TBD and newer. The mode permissions to be set on the file or directory.
        /// </summary>
        public NfsFileMode FileMode { get; set; }

        /// <summary>
        /// Optional. The owner user identifier (UID) to be set on the file or directory. The default value is 0 (root).
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Optional. The owner group identifier (GID) to be set on the file or directory. The default value is 0 (root group).
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Optional, only applicable to files. The type of the file. The default value is <see cref="NfsFileType.Regular"/>.
        /// </summary>
        public NfsFileType? FileType { get; set; }
    }
}
