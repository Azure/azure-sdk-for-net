// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class BlobPropertiesExtensions
    {
        internal static PathProperties ToPathProperties(this BlobProperties blobProperties) =>
            new PathProperties()
            {
                LastModified = blobProperties.LastModified,
                CreatedOn = blobProperties.CreatedOn,
                Metadata = blobProperties.Metadata,
                CopyCompletedOn = blobProperties.CopyCompletedOn,
                CopyStatusDescription = blobProperties.CopyStatusDescription,
                CopyId = blobProperties.CopyId,
                CopyProgress = blobProperties.CopyProgress,
                CopySource = blobProperties.CopySource,
                IsIncrementalCopy = blobProperties.IsIncrementalCopy,
                LeaseDuration = (Models.LeaseDurationType)blobProperties.LeaseDuration,
                LeaseStatus = (Models.LeaseStatus)blobProperties.LeaseStatus,
                LeaseState = (Models.LeaseState)blobProperties.LeaseState,
                ContentLength = blobProperties.ContentLength,
                ContentType = blobProperties.ContentType,
                ETag = blobProperties.ETag,
                ContentHash = blobProperties.ContentHash,
                ContentEncoding = blobProperties.ContentEncoding,
                ContentDisposition = blobProperties.ContentDisposition,
                ContentLanguage = blobProperties.ContentLanguage,
                CacheControl = blobProperties.CacheControl,
                AcceptRanges = blobProperties.AcceptRanges,
                IsServerEncrypted = blobProperties.IsServerEncrypted,
                EncryptionKeySha256 = blobProperties.EncryptionKeySha256,
                AccessTier = blobProperties.AccessTier,
                ArchiveStatus = blobProperties.ArchiveStatus,
                AccessTierChangedOn = blobProperties.AccessTierChangedOn
            };
    }
}
