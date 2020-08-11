// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Subset of the file's properties.
    /// </summary>
    public class ShareFileInfo
    {
        /// <summary>
        /// The internal RawStorageFileInfo.
        /// </summary>
        internal RawStorageFileInfo _rawStorageFileInfo;

        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public ETag ETag => _rawStorageFileInfo.ETag;

        /// <summary>
        /// Returns the date and time the file was last modified.
        /// </summary>
        public DateTimeOffset LastModified => _rawStorageFileInfo.LastModified;

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted => _rawStorageFileInfo.IsServerEncrypted;

        /// <summary>
        /// The file's SMB properties.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        internal ShareFileInfo(RawStorageFileInfo rawStorageFileInfo)
        {
            _rawStorageFileInfo = rawStorageFileInfo;
            SmbProperties = new FileSmbProperties(rawStorageFileInfo);
        }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageFileInfo instance for mocking.
        /// </summary>
        public static ShareFileInfo StorageFileInfo(
            ETag eTag,
            DateTimeOffset lastModified,
            bool isServerEncrypted,
            string filePermissionKey,
            string fileAttributes,
            DateTimeOffset fileCreationTime,
            DateTimeOffset fileLastWriteTime,
            DateTimeOffset fileChangeTime,
            string fileId,
            string fileParentId
            )
            => new ShareFileInfo(new RawStorageFileInfo()
            {
                ETag = eTag,
                LastModified = lastModified,
                IsServerEncrypted = isServerEncrypted,
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
