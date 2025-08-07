// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Properties for a file.
    /// </summary>
    public class ShareFileProperties
    {
        /// <summary>
        /// The DateTimeOffset when the file was last modified.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// A set of name-value pairs associated with this file as user-defined metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the file. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }
        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// If the Content-MD5 header has been set for the file, the Content-MD5 response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// If the Content-Encoding request header has previously been set for the file, the Content-Encoding value is returned in this header.
        /// </summary>
        public IEnumerable<string> ContentEncoding { get; internal set; }

        /// <summary>
        /// If the Cache-Control request header has previously been set for the file, the Cache-Control value is returned in this header.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// Returns the value that was specified for the 'x-ms-content-disposition' header and specifies how to process the response.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// Returns the value that was specified for the Content-Language request header.
        /// </summary>
        public IEnumerable<string> ContentLanguage { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy File operation where this file was the destination file. This value can specify the time of a completed, aborted, or failed copy attempt.
        /// </summary>
        public DateTimeOffset CopyCompletedOn { get; internal set; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes cause of fatal or non-fatal copy operation failure.
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy File operation where this file was the destination file. Can show between 0 and Content-Length bytes copied.
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2KB in length that specifies the source file used in the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public string CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by 'x-ms-copy-id'.
        /// </summary>
        public CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the file data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the file is unencrypted, or if only parts of the file/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The SMB properties for the file
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// When a file is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public ShareLeaseDuration LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the file.
        /// </summary>
        public ShareLeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the file.
        /// </summary>
        public ShareLeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// NFS properties.
        /// Note that this property is only applicable to files created in NFS shares.
        /// </summary>
        public FilePosixProperties PosixProperties { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareFileProperties() { }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageFileProperties instance for mocking.
        /// </summary>
        public static ShareFileProperties StorageFileProperties(
            DateTimeOffset lastModified = default,
            IDictionary<string, string> metadata = default,
            long contentLength = default,
            string contentType = default,
            ETag eTag = default,
            byte[] contentHash = default,
            IEnumerable<string> contentEncoding = default,
            string cacheControl = default,
            string contentDisposition = default,
            IEnumerable<string> contentLanguage = default,
            DateTimeOffset copyCompletedOn = default,
            string copyStatusDescription = default,
            string copyId = default,
            string copyProgress = default,
            string copySource = default,
            CopyStatus copyStatus = default,
            bool isServerEncrypted = default,
            FileSmbProperties smbProperties = default,
            FilePosixProperties posixProperties = default
            ) => new ShareFileProperties
            {
                LastModified = lastModified,
                Metadata = metadata,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                ContentHash = contentHash,
                ContentEncoding = contentEncoding,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CopyCompletedOn = copyCompletedOn,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                IsServerEncrypted = isServerEncrypted,
                SmbProperties = smbProperties,
                PosixProperties = posixProperties,
            };

        /// <summary>
        /// Creates a new StorageFileProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareFileProperties StorageFileProperties(
            DateTimeOffset lastModified,
            IDictionary<string, string> metadata,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            IEnumerable<string> contentEncoding,
            string cacheControl,
            string contentDisposition,
            IEnumerable<string> contentLanguage,
            DateTimeOffset copyCompletedOn,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            string copySource,
            CopyStatus copyStatus,
            bool isServerEncrypted,
#pragma warning disable CA1801 // Review unused parameters
            string fileAttributes,
            DateTimeOffset fileCreationTime,
            DateTimeOffset fileLastWriteTime,
            DateTimeOffset fileChangeTime,
            string filePermissionKey,
            string fileId,
            string fileParentId
#pragma warning restore CA1801 // Review unused parameters
            ) => new ShareFileProperties
            {
                LastModified = lastModified,
                Metadata = metadata,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                ContentHash = contentHash,
                ContentEncoding = contentEncoding,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CopyCompletedOn = copyCompletedOn,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
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

        /// <summary>
        /// Creates a new StorageFileProperties instance for mocking.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ShareFileProperties StorageFileProperties(
            DateTimeOffset lastModified,
            IDictionary<string, string> metadata,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            IEnumerable<string> contentEncoding,
            string cacheControl,
            string contentDisposition,
            IEnumerable<string> contentLanguage,
            DateTimeOffset copyCompletedOn,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            string copySource,
            CopyStatus copyStatus,
            bool isServerEncrypted,
#pragma warning disable CA1801 // Review unused parameters
            NtfsFileAttributes fileAttributes,
            DateTimeOffset fileCreationTime,
            DateTimeOffset fileLastWriteTime,
            DateTimeOffset fileChangeTime,
            string filePermissionKey,
            string fileId,
            string fileParentId
#pragma warning restore CA1801 // Review unused parameters
            ) => new ShareFileProperties
            {
                LastModified = lastModified,
                Metadata = metadata,
                ContentLength = contentLength,
                ContentType = contentType,
                ETag = eTag,
                ContentHash = contentHash,
                ContentEncoding = contentEncoding,
                CacheControl = cacheControl,
                ContentDisposition = contentDisposition,
                ContentLanguage = contentLanguage,
                CopyCompletedOn = copyCompletedOn,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                IsServerEncrypted = isServerEncrypted,
                SmbProperties = new FileSmbProperties
                {
                    FileAttributes = fileAttributes,
                    FilePermissionKey = filePermissionKey,
                    FileCreatedOn = fileCreationTime,
                    FileLastWrittenOn = fileLastWriteTime,
                    FileChangedOn = fileChangeTime,
                    FileId = fileId,
                    ParentId = fileParentId
                },
                PosixProperties = new FilePosixProperties()
            };
    }
}
