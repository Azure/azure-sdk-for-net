// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class SharesModelFactory
    {
        /// <summary>
        /// Creates a new StorageDirectoryInfo instance for mocking.
        /// </summary>
        public static ShareDirectoryInfo StorageDirectoryInfo(
            ETag eTag,
            DateTimeOffset lastModified,
#pragma warning disable CA1801 // Review unused parameters
            string filePermissionKey,
            string fileAttributes,
            DateTimeOffset fileCreationTime,
            DateTimeOffset fileLastWriteTime,
            DateTimeOffset fileChangeTime,
            string fileId,
            string fileParentId
#pragma warning restore CA1801 // Review unused parameters
            )
            => new ShareDirectoryInfo
            {
                ETag = eTag,
                LastModified = lastModified,
                // TODO fix this
                //FilePermissionKey = filePermissionKey,
                //FileAttributes = fileAttributes,
                //FileCreationTime = fileCreationTime,
                //FileLastWriteTime = fileLastWriteTime,
                //FileChangeTime = fileChangeTime,
                //FileId = fileId,
                //FileParentId = fileParentId
            };
    }
}
