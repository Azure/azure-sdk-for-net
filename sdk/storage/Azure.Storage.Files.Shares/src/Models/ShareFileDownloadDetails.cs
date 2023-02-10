// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Details returned when downloading a File
    /// </summary>
    public partial class ShareFileDownloadDetails
    {
        /// <summary>
        /// Returns the date and time the file was last modified. Any operation that modifies the file or its properties updates the last modified time.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// A set of name-value pairs associated with this file as user-defined metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Indicates the range of bytes returned if the client requested a subset of the file by setting the Range request header.
        ///
        /// The format of the Content-Range is expected to comeback in the following format.
        /// [unit] [start]-[end]/[fileSize]
        /// (e.g. bytes 1024-3071/10240)
        ///
        /// The [end] value will be the inclusive last byte (e.g. header "bytes 0-7/8" is the entire 8-byte file).
        /// </summary>
        public string ContentRange { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// CreatedOn.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; internal set; }

        /// <summary>
        /// Returns the value that was specified for the Content-Encoding request header.
        /// </summary>
        public IEnumerable<string> ContentEncoding { get; internal set; }

        /// <summary>
        /// Returned if it was previously specified for the file.
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
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

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
        public Uri CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by 'x-ms-copy-id'.
        /// </summary>
        public CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// If the file has a MD5 hash, and if request contains range header (Range or x-ms-range), this response header is returned with the value of the whole file's MD5 value. This value may or may not be equal to the value returned in Content-MD5 header, with the latter calculated from the requested range.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] FileContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The value of this header is set to true if the file data and application metadata are completely encrypted using the specified algorithm. Otherwise, the value is set to false (when the file is unencrypted, or if only parts of the file/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

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
        /// The SMB properties for the file
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareFileDownloadDetails() { }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new StorageFileDownloadProperties instance for mocking.
        /// </summary>
        public static ShareFileDownloadDetails StorageFileDownloadProperties(
            DateTimeOffset lastModified,
            IDictionary<string, string> metadata,
#pragma warning disable CA1801 // Review unused parameters
            string contentType,
#pragma warning restore CA1801 // Review unused parameters
            string contentRange,
            ETag eTag,
            IEnumerable<string> contentEncoding,
            string cacheControl,
            string contentDisposition,
            IEnumerable<string> contentLanguage,
            string acceptRanges,
            DateTimeOffset copyCompletedOn,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            CopyStatus copyStatus,
            byte[] fileContentHash,
            bool isServiceEncrypted)
        {
            return new ShareFileDownloadDetails
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
                CopyCompletedOn = copyCompletedOn,
                CopyStatusDescription = copyStatusDescription,
                CopyId = copyId,
                CopyProgress = copyProgress,
                CopySource = copySource,
                CopyStatus = copyStatus,
                FileContentHash = fileContentHash,
                IsServerEncrypted = isServiceEncrypted
            };
        }
    }
}
