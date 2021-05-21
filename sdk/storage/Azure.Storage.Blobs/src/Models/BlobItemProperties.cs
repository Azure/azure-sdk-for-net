// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Properties of a blob.
    /// </summary>
    public class BlobItemProperties
    {
        /// <summary>
        /// Last-Modified.
        /// </summary>
        public DateTimeOffset? LastModified { get; internal set; }

        /// <summary>
        /// Size in bytes.
        /// </summary>
        public long? ContentLength { get; internal set; }

        /// <summary>
        /// Content-Type.
        /// </summary>
        public string ContentType { get; internal set; }

        /// <summary>
        /// Content-Encoding.
        /// </summary>
        public string ContentEncoding { get; internal set; }

        /// <summary>
        /// Content-Language.
        /// </summary>
        public string ContentLanguage { get; internal set; }

        /// <summary>
        /// Content-MD5.
        /// </summary>
#pragma warning disable CA1819 // Properties should not return arrays
        public byte[] ContentHash { get; internal set; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Content-Disposition.
        /// </summary>
        public string ContentDisposition { get; internal set; }

        /// <summary>
        /// Cache-Control.
        /// </summary>
        public string CacheControl { get; internal set; }

        /// <summary>
        /// BlobSequenceNumber.
        /// </summary>
        public long? BlobSequenceNumber { get; internal set; }

        /// <summary>
        /// BlobType.
        /// </summary>
        public BlobType? BlobType { get; internal set; }

        /// <summary>
        /// LeaseStatus,
        /// </summary>
        public LeaseStatus? LeaseStatus { get; internal set; }

        /// <summary>
        /// LeaseState
        /// </summary>
        public LeaseState? LeaseState { get; internal set; }

        /// <summary>
        /// LeaseDuration.
        /// </summary>
        public LeaseDurationType? LeaseDuration { get; internal set; }

        /// <summary>
        /// CopyId.
        /// </summary>
        public string CopyId { get; internal set; }

        /// <summary>
        /// CopyStatus.
        /// </summary>
        public CopyStatus? CopyStatus { get; internal set; }

        /// <summary>
        /// CopySource.
        /// </summary>
        public Uri CopySource { get; internal set; }

        /// <summary>
        /// CopyProgress.
        /// </summary>
        public string CopyProgress { get; internal set; }

        /// <summary>
        /// CopyStatusDescription.
        /// </summary>
        public string CopyStatusDescription { get; internal set; }

        /// <summary>
        /// ServerEncrypted.
        /// </summary>
        public bool? ServerEncrypted { get; internal set; }

        /// <summary>
        /// IncrementalCopy.
        /// </summary>
        public bool? IncrementalCopy { get; internal set; }

        /// <summary>
        /// DestinationSnapshot.
        /// </summary>
        public string DestinationSnapshot { get; internal set; }

        /// <summary>
        /// RemainingRetentionDays.
        /// </summary>
        public int? RemainingRetentionDays { get; internal set; }

        /// <summary>
        /// AccessTier.
        /// </summary>
        public AccessTier? AccessTier { get; internal set; }

        /// <summary>
        /// AccessTierInferred.
        /// </summary>
        public bool AccessTierInferred { get; internal set; }

        /// <summary>
        /// ArchiveStatus.
        /// </summary>
        public ArchiveStatus? ArchiveStatus { get; internal set; }

        /// <summary>
        /// CustomerProvidedKeySha256.
        /// </summary>
        public string CustomerProvidedKeySha256 { get; internal set; }

        /// <summary>
        /// The name of the encryption scope under which the blob is encrypted.
        /// </summary>
        public string EncryptionScope { get; internal set; }

        /// <summary>
        /// TagCount
        /// </summary>
        public long? TagCount { get; internal set; }

        /// <summary>
        /// Expiry-Time.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; internal set; }

        /// <summary>
        /// Sealed.
        /// </summary>
        public bool? IsSealed { get; internal set; }

        /// <summary>
        /// If an object is in rehydrate pending state then this header is returned with priority of rehydrate. Valid values are High and Standard.
        /// </summary>
        public RehydratePriority? RehydratePriority { get; internal set; }

        /// <summary>
        /// LastAccessTime.
        /// </summary>
        public DateTimeOffset? LastAccessedOn { get; internal set; }

        /// <summary>
        /// ETag.
        /// </summary>
        public ETag? ETag { get; internal set; }

        /// <summary>
        /// CreatedOn.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; internal set; }

        /// <summary>
        /// CopyCompletedOn.
        /// </summary>
        public DateTimeOffset? CopyCompletedOn { get; internal set; }

        /// <summary>
        /// DeletedOn;
        /// </summary>
        public DateTimeOffset? DeletedOn { get; internal set; }

        /// <summary>
        /// AccessTierChangedOn.
        /// </summary>
        public DateTimeOffset? AccessTierChangedOn { get; internal set; }

        /// <summary>
        /// Prevent direct instantiation of BlobItemProperties instances.
        /// You can use BlobsModelFactory.BlobItemProperties instead.
        /// </summary>
        internal BlobItemProperties() { }
    }
}
