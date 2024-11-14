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
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// Content
        /// </summary>
        public Stream Content { get; internal set; }

        /// <summary>
        /// The content type specified for the file. The default content type is 'application/octet-stream'
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// If the file has an MD5 hash and this operation is to read the full content, this response header is returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// When requested using <see cref="DownloadTransferValidationOptions"/>, this value contains the CRC for the download blob range.
        /// This value may only become populated once the network stream is fully consumed.
        /// </summary>
        public byte[] ContentCrc { get; internal set; }

        /// <summary>
        /// Details returned when downloading a file
        /// </summary>
        public ShareFileDownloadDetails Details { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareFileDownloadInfo() { }

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
            DateTimeOffset lastModified = default,
            IEnumerable<string> contentLanguage = default,
            string acceptRanges = default,
            DateTimeOffset copyCompletionTime = default,
            string copyStatusDescription = default,
            string contentDisposition = default,
            string copyProgress = default,
            Uri copySource = default,
            CopyStatus copyStatus = default,
            byte[] fileContentHash = default,
            bool isServerEncrypted = default,
            string cacheControl = default,
            string fileAttributes = default,
            IEnumerable<string> contentEncoding = default,
            DateTimeOffset fileCreationTime = default,
            byte[] contentHash = default,
            DateTimeOffset fileLastWriteTime = default,
            ETag eTag = default,
            DateTimeOffset fileChangeTime = default,
            string contentRange = default,
            string filePermissionKey = default,
            string contentType = default,
            string fileId = default,
            long contentLength = default,
            string fileParentId = default,
            IDictionary<string, string> metadata = default,
            Stream content = default,
            string copyId = default)
        {
            return new ShareFileDownloadInfo
            {
                ContentLength = contentLength,
                Content = content,
                ContentType = contentType,
                ContentHash = contentHash,
                Details = new ShareFileDownloadDetails
                {
                    LastModified = lastModified,
                    Metadata = metadata,
                    ContentRange = contentRange,
                    ETag = eTag,
                    ContentEncoding = contentEncoding,
                    CacheControl = cacheControl,
                    ContentDisposition = contentDisposition,
                    ContentLanguage = contentLanguage,
                    AcceptRanges = acceptRanges,
                    CopyCompletedOn = copyCompletionTime,
                    CopyStatusDescription = copyStatusDescription,
                    CopyId = copyId,
                    CopyProgress = copyProgress,
                    CopySource = copySource,
                    CopyStatus = copyStatus,
                    FileContentHash = fileContentHash,
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
                }
            };
        }
    }
}
