// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Subset of the directory's properties.
    /// </summary>
    public class ShareDirectoryInfo
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the directory, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the directory was last modified. Any operation that modifies the directory or
        /// its properties updates the last modified time. Operations on files do not affect the last modified time of the directory.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The directory's SMB properties.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// The directory's NFS properties.
        /// Only applicable to files in a NFS share.
        /// </summary>
        public FilePosixProperties PosixProperties { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareDirectoryInfo() { }
}

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageDirectoryInfo instance for mocking.
        /// </summary>
        public static ShareDirectoryInfo StorageDirectoryInfo(
            ETag eTag = default,
            DateTimeOffset lastModified = default,
            FileSmbProperties smbProperties = default,
            FilePosixProperties posixProperties = default)
            => new ShareDirectoryInfo
            {
                ETag = eTag,
                LastModified = lastModified,
                SmbProperties = smbProperties,
                PosixProperties = posixProperties,
            };
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class SharesModelFactory
    {
        /// <summary>
        /// Creates a new StorageDirectoryInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareDirectoryInfo StorageDirectoryInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            string filePermissionKey,
            string fileAttributes,
            DateTimeOffset fileCreationTime,
            DateTimeOffset fileLastWriteTime,
            DateTimeOffset fileChangeTime,
            string fileId,
            string fileParentId)
            => new ShareDirectoryInfo
            {
                ETag = eTag,
                LastModified = lastModified,
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = ShareModelExtensions.ToFileAttributes(fileAttributes),
                    FilePermissionKey = filePermissionKey,
                    FileCreatedOn = fileCreationTime,
                    FileLastWrittenOn = fileLastWriteTime,
                    FileChangedOn = fileChangeTime,
                    FileId = fileId,
                    ParentId = fileParentId
                }
            };
    }
}
