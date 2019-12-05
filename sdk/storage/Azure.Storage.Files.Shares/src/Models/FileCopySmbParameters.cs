// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// SMB parameters for file copy operations.
    /// </summary>
    public class FileCopySmbParameters
    {
        /// <summary>
        /// The file system attributes for this file.
        /// </summary>
        public NtfsFileAttributes? FileAttributes { get; set; }

        /// <summary>
        /// The key of the file permission.  FilePermissionKey and
        /// FilePermission cannot both be set.
        /// </summary>
        public string FilePermissionKey { get; set; }

        /// <summary>
        /// The file permission.  FilePermission and FilePermissionKey
        /// cannot both be set.
        /// </summary>
        public string FilePermission { get; set; }

        /// <summary>
        /// Specifies the option to copy file security descriptor from source file or
        /// to set it using the value which is defined by the header value of FilePermission
        /// or FilePermissionKey.
        /// </summary>
        public PermissionCopyModeType? FilePermissionCopyMode { get; set; }

        /// <summary>
        /// The creation time of the file.
        /// </summary>
        public DateTimeOffset? FileCreatedOn { get; set; }

        /// <summary>
        /// The last write time of the file.
        /// </summary>
        public DateTimeOffset? FileLastWrittenOn { get; set; }
    }
}
