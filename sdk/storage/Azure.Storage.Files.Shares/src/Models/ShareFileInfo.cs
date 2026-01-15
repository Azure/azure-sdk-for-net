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
    /// Subset of the file's properties.
    /// </summary>
    public class ShareFileInfo
    {
        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the file was last modified.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the contents of the request are successfully encrypted using the specified algorithm, and false otherwise.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The file's SMB properties.
        /// Only applicable to files in a SMB share.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// The file's NFS properties.
        /// Only applicable to files in a NFS share.
        /// </summary>
        public FilePosixProperties PosixProperties { get; internal set; }

//        /// <summary>
//        /// Content Hash of the file.  This value will only be populated if the file was created with data.
//        /// </summary>
//#pragma warning disable CA1819 // Properties should not return arrays
//        public byte[] ContentHash { get; internal set; }
//#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareFileInfo() { }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        ///// <summary>
        ///// Creates a new StorageFileInfo instance for mocking.
        ///// </summary>
        //public static ShareFileInfo StorageFileInfo(
        //    ETag eTag = default,
        //    DateTimeOffset lastModified = default,
        //    bool isServerEncrypted = default,
        //    string filePermissionKey = default,
        //    string fileAttributes = default,
        //    DateTimeOffset fileCreationTime = default,
        //    DateTimeOffset fileLastWriteTime = default,
        //    DateTimeOffset fileChangeTime = default,
        //    string fileId = default,
        //    string fileParentId = default,
        //    NfsFileMode nfsFileMode = default,
        //    string owner = default,
        //    string group = default,
        //    NfsFileType nfsFileType = default,
        //    byte[] contentHash = default)
        //    => new ShareFileInfo
        //    {
        //        ETag = eTag,
        //        LastModified = lastModified,
        //        IsServerEncrypted = isServerEncrypted,
        //        SmbProperties = new FileSmbProperties
        //        {
        //            FileAttributes = ShareModelExtensions.ToFileAttributes(fileAttributes),
        //            FilePermissionKey = filePermissionKey,
        //            FileCreatedOn = fileCreationTime,
        //            FileLastWrittenOn = fileLastWriteTime,
        //            FileChangedOn = fileChangeTime,
        //            FileId = fileId,
        //            ParentId = fileParentId
        //        },
        //        PosixProperties = new FilePosixProperties
        //        {
        //            FileMode = nfsFileMode,
        //            Owner = owner,
        //            Group = group,
        //            FileType = nfsFileType,
        //        },
        //        ContentHash = contentHash
        //    };

        /// <summary>
        /// Creates a new StorageFileInfo instance for mocking.
        /// </summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
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
            string fileParentId,
            NfsFileMode nfsFileMode,
            string owner,
            string group,
            NfsFileType nfsFileType)
            => new ShareFileInfo
            {
                ETag = eTag,
                LastModified = lastModified,
                IsServerEncrypted = isServerEncrypted,
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = ShareModelExtensions.ToFileAttributes(fileAttributes),
                    FilePermissionKey = filePermissionKey,
                    FileCreatedOn = fileCreationTime,
                    FileLastWrittenOn = fileLastWriteTime,
                    FileChangedOn = fileChangeTime,
                    FileId = fileId,
                    ParentId = fileParentId
                },
                PosixProperties = new FilePosixProperties
                {
                    FileMode = nfsFileMode,
                    Owner =  owner,
                    Group = group,
                    FileType = nfsFileType,
                }
            };

        /// <summary>
        /// Creates a new StorageFileInfo instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            => new ShareFileInfo
            {
                ETag = eTag,
                LastModified = lastModified,
                IsServerEncrypted = isServerEncrypted,
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
