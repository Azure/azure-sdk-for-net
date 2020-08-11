// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Azure.Storage.Shared;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The properties and content returned from downloading a file
    /// </summary>
    public partial class ShareFileDownloadInfo : IDisposable, IDownloadedContent
    {
        /// <summary>
        /// Internal flattened property representation
        /// </summary>
        internal FlattenedStorageFileProperties _flattened;

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength => _flattened.ContentLength;

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content => _flattened.Content;

        /// <summary>
        /// The content type specified for the file. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType => _flattened.ContentType;

        /// <summary>
        /// If the file has an MD5 hash and this operation is to read the full content, this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash => _flattened.ContentHash;
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Details returned when downloading a file
        /// </summary>
        public ShareFileDownloadDetails Details { get; private set; }

        /// <summary>
        /// Creates a new StorageFileDownloadInfo backed by FlattenedStorageFileProperties
        /// </summary>
        /// <param name="flattened">The FlattenedStorageFileProperties returned with the request</param>
        internal ShareFileDownloadInfo(FlattenedStorageFileProperties flattened)
        {
            _flattened = flattened;
            Details = new ShareFileDownloadDetails(flattened);
        }

        /// <summary>
        /// Disposes the StorageFileDownloadInfo by calling Dispose on the underlying Content stream.
        /// </summary>
        public void Dispose()
        {
            Content?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageFileDownloadInfo instance for mocking.
        /// </summary>
        public static ShareFileDownloadInfo StorageFileDownloadInfo(
            System.DateTimeOffset lastModified = default,
            System.Collections.Generic.IEnumerable<string> contentLanguage = default,
            string acceptRanges = default,
            System.DateTimeOffset copyCompletionTime = default,
            string copyStatusDescription = default,
            string contentDisposition = default,
            string copyProgress = default,
            System.Uri copySource = default,
            Azure.Storage.Files.Shares.Models.CopyStatus copyStatus = default,
            byte[] fileContentHash = default,
            bool isServerEncrypted = default,
            string cacheControl = default,
            string fileAttributes = default,
            System.Collections.Generic.IEnumerable<string> contentEncoding = default,
            System.DateTimeOffset fileCreationTime = default,
            byte[] contentHash = default,
            System.DateTimeOffset fileLastWriteTime = default,
            ETag eTag = default,
            System.DateTimeOffset fileChangeTime = default,
            string contentRange = default,
            string filePermissionKey = default,
            string contentType = default,
            string fileId = default,
            long contentLength = default,
            string fileParentId = default,
            System.Collections.Generic.IDictionary<string, string> metadata = default,
            System.IO.Stream content = default,
            string copyId = default)
        {
            return new ShareFileDownloadInfo(
                new FlattenedStorageFileProperties()
                {
                    LastModified = lastModified,
                    ContentLanguage = contentLanguage,
                    AcceptRanges = acceptRanges,
                    CopyCompletionTime = copyCompletionTime,
                    CopyStatusDescription = copyStatusDescription,
                    ContentDisposition = contentDisposition,
                    CopyProgress = copyProgress,
                    CopySource = copySource,
                    CopyStatus = copyStatus,
                    FileContentHash = fileContentHash,
                    IsServerEncrypted = isServerEncrypted,
                    CacheControl = cacheControl,
                    FileAttributes = fileAttributes,
                    ContentEncoding = contentEncoding,
                    FileCreationTime = fileCreationTime,
                    ContentHash = contentHash,
                    FileLastWriteTime = fileLastWriteTime,
                    ETag = eTag,
                    FileChangeTime = fileChangeTime,
                    ContentRange = contentRange,
                    FilePermissionKey = filePermissionKey,
                    ContentType = contentType,
                    FileId = fileId,
                    ContentLength = contentLength,
                    FileParentId = fileParentId,
                    Metadata = metadata,
                    Content = content,
                    CopyId = copyId,
                }
            );
        }
    }
}
