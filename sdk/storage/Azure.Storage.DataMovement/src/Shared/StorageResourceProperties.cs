// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Storage.DataMovement.Models
{
    /// <summary>
    /// Properties of a Blob.
    /// </summary>
    public partial class StorageResourceProperties
    {
        /// <summary>
        /// Returns the date and time the blob was last modified. Any operation that modifies the blob,
        /// including an update of the blob's metadata or properties, changes the last-modified time of the blob.
        /// </summary>
        internal DateTimeOffset LastModified { get; }

        /// <summary>
        /// Returns the date and time the blob was created.
        /// </summary>
        internal DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// Metadata.
        /// </summary>
        internal IDictionary<string, string> Metadata { get; }

        /// <summary>
        /// Storage Resource Type
        /// </summary>
        public StorageResourceType ResourceType { get; }

        /// <summary>
        /// Conclusion time of the last attempted Copy Blob operation where this blob was the destination blob.
        /// This value can specify the time of a completed, aborted, or failed copy attempt. This header does
        /// not appear if a copy is pending, if this blob has never been the destination in a Copy Blob operation,
        /// or if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties,
        /// Put Blob, or Put Block List.
        /// </summary>
        internal DateTimeOffset CopyCompletedOn { get; }

        /// <summary>
        /// Only appears when x-ms-copy-status is failed or pending. Describes the cause of the last fatal or
        /// non-fatal copy operation failure. This header does not appear if this blob has never been the destination
        /// in a Copy Blob operation, or if this blob has been modified after a concluded Copy Blob operation using
        /// Set Blob Properties, Put Blob, or Put Block List
        /// </summary>
        internal string CopyStatusDescription { get; }

        /// <summary>
        /// String identifier for this copy operation. Use with Get Blob Properties to check the status of this copy
        /// operation, or pass to Abort Copy Blob to abort a pending copy.
        /// </summary>
        internal string CopyId { get; }

        /// <summary>
        /// Contains the number of bytes copied and the total bytes in the source in the last attempted Copy Blob
        /// operation where this blob was the destination blob. Can show between 0 and Content-Length bytes copied.
        /// This header does not appear if this blob has never been the destination in a Copy Blob operation, or
        /// if this blob has been modified after a concluded Copy Blob operation using Set Blob Properties, Put
        /// Blob, or Put Block List.
        /// </summary>
        internal string CopyProgress { get; }

        /// <summary>
        /// URL up to 2 KB in length that specifies the source blob or file used in the last attempted Copy Blob
        /// operation where this blob was the destination blob. This header does not appear if this blob has never
        /// been the destination in a Copy Blob operation, or if this blob has been modified after a concluded
        /// Copy Blob operation using Set Blob Properties, Put Blob, or Put Block List.
        /// </summary>
        internal Uri CopySource { get; }

        /// <summary>
        /// State of the most recent copy operation identified by x-ms-copy-id, if any.
        ///
        /// TODO: this might be needed in a different callback, but double check if
        /// copy blob status and file blob status is the same. All we need is
        /// pending, failed, and completed
        /// </summary>
        internal ServiceCopyStatus? CopyStatus { get; }

        /// <summary>
        /// The number of bytes present in the response body.
        /// </summary>
        internal long ContentLength { get; }

        /// <summary>
        /// The content type specified for the blob. The default content type is 'application/octet-stream'.
        /// </summary>
        internal string ContentType { get; }

        /// <summary>
        /// The ETag contains a value that you can use to perform operations conditionally.
        /// If the request version is 2011-08-18 or newer, the ETag value will be in quotes.
        /// </summary>
        internal ETag ETag { get; }

        /// <summary>
        /// If the blob has an MD5 hash and this operation is to read the full blob, this response header is
        /// returned so that the client can check for message content integrity.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        internal byte[] ContentHash { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// The current sequence number for a page blob. This header is returned only for page blobs.
        /// </summary>
        internal long BlobSequenceNumber { get; }

        /// <summary>
        /// The number of committed blocks present in the blob. This header is returned only for append blobs.
        /// </summary>
        internal int BlobCommittedBlockCount { get; }

        /// <summary>
        /// The value of this header is set to true if the blob data and application metadata are completely encrypted
        /// using the specified algorithm. Otherwise, the value is set to false (when the blob is unencrypted, or if
        /// only parts of the blob/application metadata are encrypted).
        /// </summary>
        internal bool IsServerEncrypted { get; }

        /// <summary>
        /// The SHA-256 hash of the encryption key used to encrypt the metadata. This header is only returned when the
        /// metadata was encrypted with a customer-provided key.
        /// </summary>
        internal string EncryptionKeySha256 { get; }

        /// <summary>
        /// Returns the name of the encryption scope used to encrypt the blob contents and application metadata.
        /// Note that the absence of this header implies use of the default account encryption scope.
        /// </summary>
        internal string EncryptionScope { get; }

        /// <summary>
        /// A DateTime value returned by the service that uniquely identifies the blob. The value of this header
        /// indicates the blob version, and may be used in subsequent requests to access this version of the blob.
        /// </summary>
        internal string VersionId { get; }

        /// <summary>
        /// The value of this header indicates whether version of this blob is a current version, see also x-ms-version-id header.
        /// </summary>
        internal bool IsLatestVersion { get; }

        /// <summary>
        /// The time this blob will expire.
        /// </summary>
        internal DateTimeOffset ExpiresOn { get; }

        /// <summary>
        /// Returns the date and time the blob was read or written to.
        /// </summary>
        internal DateTimeOffset LastAccessed { get; }

        /// <summary>
        /// Mock Constructor.
        /// </summary>
        protected StorageResourceProperties()
        {
            Metadata = new Dictionary<string, string>(System.StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public StorageResourceProperties(
            DateTimeOffset lastModified,
            DateTimeOffset createdOn,
            IDictionary<string, string> metadata,
            DateTimeOffset copyCompletedOn,
            string copyStatusDescription,
            string copyId,
            string copyProgress,
            Uri copySource,
            ServiceCopyStatus? copyStatus,
            long contentLength,
            string contentType,
            ETag eTag,
            byte[] contentHash,
            long blobSequenceNumber,
            int blobCommittedBlockCount,
            bool isServerEncrypted,
            string encryptionKeySha256,
            string encryptionScope,
            string versionId,
            bool isLatestVersion,
            DateTimeOffset expiresOn,
            DateTimeOffset lastAccessed,
            StorageResourceType resourceType)
        {
            LastModified = lastModified;
            ContentLength = contentLength;
            ContentType = contentType;
            ETag = eTag;
            BlobSequenceNumber = blobSequenceNumber;
            BlobCommittedBlockCount = blobCommittedBlockCount;
            IsServerEncrypted = isServerEncrypted;
            CopyStatus = copyStatus;
            EncryptionKeySha256 = encryptionKeySha256;
            CopySource = copySource;
            EncryptionScope = encryptionScope;
            CopyProgress = copyProgress;
            CopyId = copyId;
            CopyStatusDescription = copyStatusDescription;
            CopyCompletedOn = copyCompletedOn;
            VersionId = versionId;
            IsLatestVersion = isLatestVersion;
            Metadata = metadata;
            ExpiresOn = expiresOn;
            CreatedOn = createdOn;
            ContentHash = contentHash;
            LastAccessed = lastAccessed;
            ResourceType = resourceType;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public StorageResourceProperties(
            DateTimeOffset lastModified,
            DateTimeOffset createdOn,
            long contentLength,
            DateTimeOffset lastAccessed,
            StorageResourceType resourceType)
        {
            LastModified = lastModified;
            ContentLength = contentLength;
            CreatedOn = createdOn;
            LastAccessed = lastAccessed;
            ResourceType = resourceType;
        }
    }
}
