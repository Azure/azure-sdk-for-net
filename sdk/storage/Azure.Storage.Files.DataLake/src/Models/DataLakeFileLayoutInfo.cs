// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// The result of a GetLayout operation, containing the file's layout
    /// information along with properties from the response headers.
    ///
    /// The shape mirrors <see cref="Azure.Storage.Blobs.Models.BlobLayoutInfo"/>
    /// (with <c>Blob*</c> properties renamed to <c>File*</c>) and additionally
    /// exposes the layout endpoints and ranges that callers can use to route
    /// one-shot downloads to the optimal endpoint via the LayoutEndpoint option
    /// on <see cref="DataLakeFileReadOptions"/>.
    /// </summary>
    public class DataLakeFileLayoutInfo
    {
        /// <summary>
        /// The file layout ranges.
        /// </summary>
        public DataLakeFileLayoutRanges Ranges { get; internal set; }

        /// <summary>
        /// The file layout endpoints.
        /// </summary>
        public DataLakeFileLayoutEndpoints Endpoints { get; internal set; }

        /// <summary>
        /// Returns the date and time the file was last modified. Any operation that modifies the file,
        /// including an update of the file's metadata or properties, changes the last-modified time of the file.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Returns the date and time the file was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; internal set; }

        /// <summary>
        /// Metadata.
        /// </summary>
        public IDictionary<string, string> Metadata { get; internal set; }

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this file was the destination file.
        /// </summary>
        public DateTimeOffset CopyCompletedOn { get; internal set; }

        /// <summary>
        /// Describes the cause of the last fatal or non-fatal copy operation failure.
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// String identifier for this copy operation.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob operation.
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// URL up to 2 KB in length that specifies the source file used in the last attempted Copy Blob operation.
        /// </summary>
        public Uri CopySource { get; internal set; }

        /// <summary>
        /// State of the copy operation identified by x-ms-copy-id.
        /// </summary>
        public CopyStatus? CopyStatus { get; internal set; }

        /// <summary>
        /// Included if the file is incremental copy blob.
        /// </summary>
        public bool IsIncrementalCopy { get; internal set; }

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
        /// The number of bytes present in the response body.
        /// </summary>
        public long ContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the file. The default content type is 'application/octet-stream'.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// If the file has an MD5 hash and this operation is to read the full file, this response header is
        /// returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// This header returns the value that was specified for the Content-Encoding request header.
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the 'x-ms-blob-content-disposition' header.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// This header returns the value that was specified for the Content-Language request header.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// This header is returned if it was previously specified for the file.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// Indicates that the service supports requests for partial file content.
        /// </summary>
        public string AcceptRanges { get; internal set; }

        /// <summary>
        /// The value of this header is set to true if the file data and application metadata are completely encrypted
        /// using the specified algorithm. Otherwise, the value is set to false.
        /// </summary>
        public bool IsServerEncrypted { get; internal set; }

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the metadata. This header is only returned when the
        /// metadata was encrypted with a customer-provided key.
        /// </summary>
        public string EncryptionKeySha256 { get; internal set; }

        /// <summary>
        /// Returns the name of the encryption scope used to encrypt the file contents and application metadata.
        /// Note that the absence of this header implies use of the default account encryption scope.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// The tier of page blob on a premium storage account or tier of block blob on blob storage LRS accounts.
        /// </summary>
        public string AccessTier { get; internal set; }

        /// <summary>
        /// For page blobs on a premium storage account only. If the access tier is not explicitly set on the file,
        /// the tier is inferred based on its content length and this header will be returned with true value.
        /// </summary>
        public bool AccessTierInferred { get; internal set; }

        /// <summary>
        /// The underlying tier of a smart tier file. Only returned if the file is in Smart tier.
        /// </summary>
        public string SmartAccessTier { get; internal set; }

        /// <summary>
        /// For blob storage LRS accounts, valid values are rehydrate-pending-to-hot/rehydrate-pending-to-cool.
        /// If the file is being rehydrated and is not complete then this header is returned indicating that
        /// rehydrate is pending and also tells the destination tier.
        /// </summary>
        public string ArchiveStatus { get; internal set; }

        /// <summary>
        /// The time the tier was changed on the object. This is only returned if the tier on the block blob was ever set.
        /// </summary>
        public DateTimeOffset AccessTierChangedOn { get; internal set; }

        /// <summary>
        /// The time this file will expire.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; internal set; }

        /// <summary>
        /// The content length of the file.
        /// </summary>
        public long FileContentLength { get; internal set; }

        /// <summary>
        /// The content type specified for the file.
        /// </summary>
        public string FileContentType { get; internal set; }

        /// <summary>
        /// The content encoding specified for the file.
        /// </summary>
        public string FileContentEncoding { get; internal set; }

        /// <summary>
        /// The content MD5 of the file.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] FileContentMD5 { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The creation time of the file.
        /// </summary>
        public DateTimeOffset FileCreatedOn { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of <see cref="DataLakeFileLayoutInfo"/> instances.
        /// You can use <see cref="DataLakeModelFactory"/> instead.
        /// </summary>
        internal DataLakeFileLayoutInfo() { }
    }
}
