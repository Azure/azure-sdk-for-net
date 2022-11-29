// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    internal static partial class DataMovementBlobsExtensions
    {
        internal static StorageResourceProperties ToStorageResourceProperties(this BlobProperties blobProperties)
        {
            return new StorageResourceProperties(
                lastModified: blobProperties.LastModified,
                createdOn: blobProperties.CreatedOn,
                metadata: blobProperties.Metadata,
                copyCompletedOn: blobProperties.CopyCompletedOn,
                copyStatusDescription: blobProperties.CopyStatusDescription,
                copyId: blobProperties.CopyId,
                copyProgress: blobProperties.CopyProgress,
                copySource: blobProperties.CopySource,
                copyStatus: blobProperties.CopyStatus.ToCopyStatus(),
                contentLength: blobProperties.ContentLength,
                contentType: blobProperties.ContentType,
                eTag: blobProperties.ETag,
                contentHash: blobProperties.ContentHash,
                blobSequenceNumber: blobProperties.BlobSequenceNumber,
                blobCommittedBlockCount: blobProperties.BlobCommittedBlockCount,
                isServerEncrypted: blobProperties.IsServerEncrypted,
                encryptionKeySha256: blobProperties.EncryptionKeySha256,
                encryptionScope: blobProperties.EncryptionScope,
                versionId: blobProperties.VersionId,
                isLatestVersion: blobProperties.IsLatestVersion,
                expiresOn: blobProperties.ExpiresOn,
                lastAccessed: blobProperties.LastAccessed,
                resourceType: blobProperties.BlobType.ToStorageResourceType());
        }

        internal static StorageResourceProperties ToStorageResourceProperties(this BlobDownloadDetails blobProperties)
        {
            return new StorageResourceProperties(
                lastModified: blobProperties.LastModified,
                createdOn: default,
                metadata: blobProperties.Metadata,
                copyCompletedOn: blobProperties.CopyCompletedOn,
                copyStatusDescription: blobProperties.CopyStatusDescription,
                copyId: blobProperties.CopyId,
                copyProgress: blobProperties.CopyProgress,
                copySource: blobProperties.CopySource,
                copyStatus: blobProperties.CopyStatus.ToCopyStatus(),
                contentLength: blobProperties.ContentLength,
                contentType: blobProperties.ContentType,
                eTag: blobProperties.ETag,
                contentHash: blobProperties.ContentHash,
                blobSequenceNumber: blobProperties.BlobSequenceNumber,
                blobCommittedBlockCount: blobProperties.BlobCommittedBlockCount,
                isServerEncrypted: blobProperties.IsServerEncrypted,
                encryptionKeySha256: blobProperties.EncryptionKeySha256,
                encryptionScope: blobProperties.EncryptionScope,
                versionId: blobProperties.VersionId,
                isLatestVersion: default,
                expiresOn: default,
                lastAccessed: blobProperties.LastAccessed,
                resourceType: blobProperties.BlobType.ToStorageResourceType());
        }

        internal static ReadStreamStorageResourceResult ToReadStreamStorageResourceInfo(this BlobDownloadStreamingResult result)
        {
            return new ReadStreamStorageResourceResult(
                content: result.Content,
                contentRange: result.Details.ContentRange,
                acceptRanges: result.Details.AcceptRanges,
                rangeContentHash: result.Details.BlobContentHash,
                properties: result.Details.ToStorageResourceProperties());
        }

        private static ServiceCopyStatus? ToCopyStatus(this CopyStatus copyStatus)
        {
            if (CopyStatus.Pending == copyStatus)
            {
                return ServiceCopyStatus.Pending;
            }
            else if (CopyStatus.Success == copyStatus)
            {
                return ServiceCopyStatus.Success;
            }
            else if (CopyStatus.Aborted == copyStatus)
            {
                return ServiceCopyStatus.Aborted;
            }
            else if (CopyStatus.Failed == copyStatus)
            {
                return ServiceCopyStatus.Failed;
            }
            return default;
        }

        private static StorageResourceType ToStorageResourceType(this BlobType blobType)
        {
            if (BlobType.Block == blobType)
            {
                return StorageResourceType.BlockBlob;
            }
            else if (BlobType.Page == blobType)
            {
                return StorageResourceType.PageBlob;
            }
            else if (BlobType.Append == blobType)
            {
                return StorageResourceType.AppendBlob;
            }
            return default;
        }
    }
}
