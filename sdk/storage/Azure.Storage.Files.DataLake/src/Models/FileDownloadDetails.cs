// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Properties returned when downloading a File.
    /// </summary>
    public class FileDownloadDetails
    {
        /// <summary>
        /// Returns the <see cref="DateTimeOffset"/> the file was last modified. Any operation that modifies the file,
        /// including an update of the file's metadata or properties, changes the last-modified time of the file.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// The file's metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Indicates the range of bytes returned in the event that the client requested a subset of the file
        /// setting the 'Range' request header.
        ///
        /// The format of the Content-Range is expected to comeback in the following format.
        /// [unit] [start]-[end]/[FileSize]
        /// (e.g. bytes 1024-3071/10240)
        ///
        /// The [end] value will be the inclusive last byte (e.g. header "bytes 0-7/8" is the entire 8-byte file).
        /// </summary>
        public string ContentRange { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally on the file.
        /// If the request service version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header.
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// This header is returned if it was previously specified for the file.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header.
        /// The Content-Disposition response header field conveys additional information about how to process the response payload,
        /// and also can be used to attach additional metadata. For example, if set to attachment, it indicates that the user-agent
        /// should not display the response, but instead show a Save As dialog with a filename other than the file name specified.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this file was the destination file.
        /// This value can specify the time of a completed, aborted, or failed copy attempt. This header does not
        /// appear if a copy is pending, if this blob has never been the destination in a Copy Blob operation, or
        /// if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties,
        /// Put Blob, or Put Block List.
        /// </summary>
        public DateTimeOffset CopyCompletedOn { get; internal set; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes the cause of the last fatal or
        /// non-fatal copy operation failure. This header does not appear if this blob has never been the destination
        /// in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using
        /// Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get Properties to check the status of this copy
        /// operation, or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob operation
        /// where this blob was the destination blob. Can show between 0 and Content-Length bytes copied. This header does not
        /// appear if this blob has never been the destination in a Copy Blob operation, or if this blob has been modified after
        /// a concluded Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2 KB in length that specifies the source blob or file used in the last attempted Copy Blob
        /// operation where this blob was the destination blob. This header does not appear if this blob has never
        /// been the destination in a Copy Blob operation, or if this blob has been modified after a concluded Copy
        /// Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        public Uri CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public CopyStatus CopyStatus { get; internal set; }

        /// <summary>
        /// When a file is leased, specifies whether the lease is of infinite or fixed duration.
        /// </summary>
        public DataLakeLeaseDuration LeaseDuration { get; internal set; }

        /// <summary>
        /// Lease state of the file.
        /// </summary>
        public DataLakeLeaseState LeaseState { get; internal set; }

        /// <summary>
        /// The current lease status of the file.
        /// </summary>
        public DataLakeLeaseStatus LeaseStatus { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the file data and application metadata are completely
        /// encrypted using the specified algorithm. Otherwise, the value is set to false (when the file is
        /// unencrypted, or if only parts of the file/application metadata are encrypted).
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the file. This header is only returned when
        /// the file was encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 { get; internal set; }

        /// <summary>
        /// If the file has a MD5 hash, and if request contains range header (Range or x-ms-range), this response
        /// header is returned with the value of the whole file's MD5 value. This value may or may not be equal
        /// to the value returned in Content-MD5 header, with the latter calculated from the requested range
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Returns the date and time the blob was created on.
        /// </summary>
        public DateTimeOffset CreatedOn { get; internal set; }

        /// <summary>
        /// Encryption context of the file.  Encryption context is metadata that is not encrypted when stored on the file.
        /// The primary application of this field is to store non-encrypted data that can be used to derive the customer-provided key
        /// for a file.
        /// </summary>
        public string EncryptionContext { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of FileDownloadDetails instances.
        /// You can use DataLakeModelFactory.FileDownloadDetails instead.
        /// </summary>
        internal FileDownloadDetails() { }
    }
}
