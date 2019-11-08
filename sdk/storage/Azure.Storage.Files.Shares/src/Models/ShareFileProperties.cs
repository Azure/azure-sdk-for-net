// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Properties for a file.
    /// </summary>
    public class ShareFileProperties
    {
        /// <summary>
        /// The internal RawStorageFileProperties
        /// </summary>
        internal RawStorageFileProperties _rawStorageFileProperties;

        /// <summary>
        /// The DateTimeOffset when the file was last modified.
        /// </summary>
        public DateTimeOffset LastModified => _rawStorageFileProperties.LastModified;

        /// <summary>
        /// A set of name-value pairs associated with this file as user-defined metadata.
        /// </summary>
        public IDictionary<string, string> Metadata => _rawStorageFileProperties.Metadata;

        /// <summary>
        /// The size of the file in bytes.
        /// </summary>
        public long ContentLength => _rawStorageFileProperties.ContentLength;

        /// <summary>
        /// The content type specified for the file. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType => _rawStorageFileProperties.ContentType;

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public ETag ETag => _rawStorageFileProperties.ETag;

        /// <summary>
        /// If the Content-MD5 header has been set for the file, the Content-MD5 response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash => _rawStorageFileProperties.ContentHash;
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// If the Content-Encoding request header has previously been set for the file, the Content-Encoding value is returned in this header.
        /// </summary>
        public IEnumerable<string> ContentEncoding => _rawStorageFileProperties.ContentEncoding;

        /// <summary>
        /// If the Cache-Control request header has previously been set for the file, the Cache-Control value is returned in this header.
        /// </summary>
        public string CacheControl => _rawStorageFileProperties.CacheControl;

        /// <summary>
        /// Returns the value that was specified for the 'x-ms-content-disposition' header and specifies how to process the response.
        /// </summary>
        public string ContentDisposition => _rawStorageFileProperties.ContentDisposition;

        /// <summary>
        /// Returns the value that was specified for the Content-Language request header.
        /// </summary>
        public IEnumerable<string> ContentLanguage => _rawStorageFileProperties.ContentLanguage;

        /// <summary>
        /// Conclusion time of the last attempted Copy File operation where this file was the destination file. This value can specify the time of a completed, aborted, or failed copy attempt.
        /// </summary>
        public DateTimeOffset CopyCompletedOn => _rawStorageFileProperties.CopyCompletionTime;

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes cause of fatal or non-fatal copy operation failure.
        /// </summary>
        public string CopyStatusDescription => _rawStorageFileProperties.CopyStatusDescription;

        /// <summary>
        /// String identifier for the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public string CopyId => _rawStorageFileProperties.CopyId;

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy File operation where this file was the destination file. Can show between 0 and Content-Length bytes copied.
        /// </summary>
        public string CopyProgress => _rawStorageFileProperties.CopyProgress;

        /// <summary>
        /// URL up to 2KB in length that specifies the source file used in the last attempted Copy File operation where this file was the destination file.
        /// </summary>
        public string CopySource => _rawStorageFileProperties.CopySource;

        /// <summary>
        /// State of the copy operation identified by 'x-ms-copy-id'.
        /// </summary>
        public CopyStatus CopyStatus => _rawStorageFileProperties.CopyStatus;

        /// <summary>
        /// The value of this header is set to true if the file data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the file is unencrypted, or if only parts of the file/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted => _rawStorageFileProperties.IsServerEncrypted;

        /// <summary>
        /// The SMB properties for the file
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        internal ShareFileProperties(RawStorageFileProperties rawStorageFileProperties)
        {
            _rawStorageFileProperties = rawStorageFileProperties;
            SmbProperties = new FileSmbProperties(rawStorageFileProperties);
        }
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
            string fileAttributes,
            DateTimeOffset fileCreationTime,
            DateTimeOffset fileLastWriteTime,
            DateTimeOffset fileChangeTime,
            string filePermissionKey,
            string fileId,
            string fileParentId
            ) => new ShareFileProperties(new RawStorageFileProperties()
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
                CopyCompletionTime = copyCompletedOn,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                IsServerEncrypted = isServerEncrypted,
                FileAttributes = fileAttributes,
                FilePermissionKey = filePermissionKey,
                FileCreationTime = fileCreationTime,
                FileLastWriteTime = fileLastWriteTime,
                FileChangeTime = fileChangeTime,
                FileId = fileId,
                FileParentId = fileParentId
            });
    }
}
