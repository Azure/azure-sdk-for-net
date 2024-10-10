// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System.Collections.Generic;
using System;

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
        public uint? Owner { get; set; }

        /// <summary>
        /// Optional. The owner group identifier (GID) to be set on the file or directory. The default value is 0 (root group).
        /// </summary>
        public uint? Group { get; set; }

        /// <summary>
        /// Optional, only applicable to files. The type of the file. The default value is <see cref="NfsFileType.Regular"/>.
        /// </summary>
        public NfsFileType? FileType { get; internal set; }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageFileDownloadProperties instance for mocking.
        /// </summary>
        public static FileNfsProperties FileNfsProperties(
            NfsFileMode fileMode,
            uint? owner,
            uint? group,
            NfsFileType fileType)
        {
            return new FileNfsProperties
            {
                FileMode = fileMode,
                Owner = owner,
                Group = group,
                FileType = fileType
            };
        }
    }
}
