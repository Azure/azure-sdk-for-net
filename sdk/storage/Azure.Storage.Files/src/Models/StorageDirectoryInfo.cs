// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Http;

namespace Azure.Storage.Files.Models
{
    /// <summary>
    /// Subset of the directory's properties.
    /// </summary>
    public class StorageDirectoryInfo
    {
        internal RawStorageDirectoryInfo _rawStorageDirectoryInfo;

        /// <summary>
        /// The ETag contains a value which represents the version of the directory, in quotes.
        /// </summary>
        public ETag ETag => _rawStorageDirectoryInfo.ETag;

        /// <summary>
        /// Returns the date and time the directory was last modified. Any operation that modifies the directory or 
        /// its properties updates the last modified time. Operations on files do not affect the last modified time of the directory.
        /// </summary>
        public DateTimeOffset LastModified => _rawStorageDirectoryInfo.LastModified;

        /// <summary>
        /// The directory's SMB properties.
        /// </summary>
        public FileSmbProperties? SmbProperties { get; set; }

        internal StorageDirectoryInfo(RawStorageDirectoryInfo rawStorageDirectoryInfo)
        {
            _rawStorageDirectoryInfo = rawStorageDirectoryInfo;
            SmbProperties = new FileSmbProperties(rawStorageDirectoryInfo);
        }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageDirectoryInfo instance for mocking.
        /// </summary>
        public static StorageDirectoryInfo StorageDirectoryInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            string filePermissionKey,
            string fileAttributes,
            DateTimeOffset fileCreationTime,
            DateTimeOffset fileLastWriteTime,
            DateTimeOffset fileChangeTime,
            string fileId,
            string fileParentId
            )
            => new StorageDirectoryInfo(new RawStorageDirectoryInfo
            {
                ETag = eTag,
                LastModified = lastModified,
                FilePermissionKey = filePermissionKey,
                FileAttributes = fileAttributes,
                FileCreationTime = fileCreationTime,
                FileLastWriteTime = fileLastWriteTime,
                FileChangeTime = fileChangeTime,
                FileId = fileId,
                FileParentId = fileParentId
            });
    }
}
