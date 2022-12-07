// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// Deep copies the Blob Request Conditions along with changing the IfNoneMatch to
        /// the wildcard value if overwrite is enabled.
        /// </summary>
        internal static BlobRequestConditions CreateRequestConditions(BlobRequestConditions conditions, bool overwrite = true)
        {
            return new BlobRequestConditions()
            {
                IfMatch = conditions?.IfMatch,
                IfNoneMatch = overwrite ? conditions?.IfNoneMatch : new ETag(Constants.Wildcard),
                IfUnmodifiedSince = conditions?.IfUnmodifiedSince,
                IfModifiedSince = conditions?.IfModifiedSince,
                TagConditions = conditions?.TagConditions,
                LeaseId = conditions?.LeaseId,
            };
        }

        internal static BlobDownloadOptions ToBlobDownloadOptions(this BlockBlobStorageResourceOptions options, HttpRange range)
        {
            return new BlobDownloadOptions()
            {
                Range = range,
                Conditions = CreateRequestConditions(options?.DownloadOptions?.Conditions),
                TransferValidation = options?.DownloadOptions?.TransferValidationOptions,
            };
        }

        internal static BlobUploadOptions ToBlobUploadOptions(this BlockBlobStorageResourceOptions options, bool overwrite)
        {
            return new BlobUploadOptions()
            {
                HttpHeaders = options?.UploadOptions?.HttpHeaders,
                Metadata = options?.UploadOptions?.Metadata,
                Tags = options?.UploadOptions?.Tags,
                AccessTier = options?.UploadOptions?.AccessTier,
                ImmutabilityPolicy = options?.UploadOptions?.ImmutabilityPolicy,
                LegalHold = options?.UploadOptions?.LegalHold,
                Conditions = CreateRequestConditions(options?.UploadOptions?.Conditions, overwrite),
                TransferValidation = options?.UploadOptions?.TransferValidationOptions,
            };
        }

        internal static BlockBlobStageBlockOptions ToBlobStageBlockOptions(this BlockBlobStorageResourceOptions options)
        {
            // There's a lot of conditions that cannot be applied to a StageBlock Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/put-block#request-headers
            // to see what headers are accepted.
            return new BlockBlobStageBlockOptions()
            {
                Conditions = new BlobRequestConditions()
                {
                    LeaseId = options?.UploadOptions?.Conditions?.LeaseId,
                    TagConditions = options?.UploadOptions?.Conditions?.TagConditions,
                },
                TransferValidation = options?.UploadOptions?.TransferValidationOptions,
            };
        }

        internal static BlobCopyFromUriOptions ToBlobCopyFromUriOptions(
            this BlockBlobStorageResourceOptions options,
            bool overwrite,
            HttpAuthorization sourceAuthorization)
        {
            // There's a lot of conditions that cannot be applied to a Copy Blob (async) Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/copy-blob#request-headers
            // to see what headers are accepted.
            return new BlobCopyFromUriOptions()
            {
                Metadata = options?.CopyOptions?.Metadata,
                Tags = options?.CopyOptions?.Tags,
                AccessTier = options?.CopyOptions?.AccessTier,
                SourceConditions = new BlobRequestConditions()
                {
                    IfMatch = options?.CopyOptions?.SourceConditions.IfMatch,
                    IfUnmodifiedSince = options?.CopyOptions?.SourceConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.CopyOptions?.SourceConditions?.IfModifiedSince,
                    TagConditions = options?.CopyOptions?.SourceConditions?.TagConditions,
                },
                DestinationConditions = CreateRequestConditions(options?.CopyOptions?.DestinationConditions, overwrite),
                RehydratePriority = options?.CopyOptions?.RehydratePriority,
                DestinationImmutabilityPolicy = options?.CopyOptions?.DestinationImmutabilityPolicy,
                LegalHold = options?.CopyOptions?.LegalHold,
                SourceAuthentication = sourceAuthorization,
                CopySourceTagsMode = options?.CopyOptions?.CopySourceTagsMode,
            };
        }

        internal static BlobSyncUploadFromUriOptions ToSyncUploadFromUriOptions(
            this BlockBlobStorageResourceOptions options,
            bool overwrite,
            HttpAuthorization sourceAuthorization)
        {
            // There's a lot of conditions that cannot be applied to a Copy Blob (async) Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url#request-headers
            // to see what headers are accepted.
            return new BlobSyncUploadFromUriOptions()
            {
                CopySourceBlobProperties = options?.CopyOptions?.CopySourceBlobProperties,
                HttpHeaders = options?.CopyOptions?.HttpHeaders,
                Tags = options?.CopyOptions?.Tags,
                AccessTier = options?.CopyOptions?.AccessTier,
                SourceConditions = new BlobRequestConditions()
                {
                    IfMatch = options?.CopyOptions?.SourceConditions.IfMatch,
                    IfUnmodifiedSince = options?.CopyOptions?.SourceConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.CopyOptions?.SourceConditions?.IfModifiedSince,
                    TagConditions = options?.CopyOptions?.SourceConditions?.TagConditions,
                },
                DestinationConditions = CreateRequestConditions(options?.CopyOptions?.DestinationConditions, overwrite),
                SourceAuthentication = sourceAuthorization,
                CopySourceTagsMode = options?.CopyOptions?.CopySourceTagsMode,
            };
        }

        internal static StageBlockFromUriOptions ToBlobStageBlockFromUriOptions(
            this BlockBlobStorageResourceOptions options,
            HttpRange sourceRange,
            HttpAuthorization sourceAuthorization)
        {
            // There's a lot of conditions that cannot be applied to a StageBlock Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/put-block-from-url#request-headers
            // to see what headers are accepted.
            return new StageBlockFromUriOptions()
            {
                SourceRange = sourceRange,
                SourceConditions = CreateRequestConditions(options?.CopyOptions?.SourceConditions, true),
                DestinationConditions = new BlobRequestConditions()
                {
                    LeaseId = options?.CopyOptions?.DestinationConditions?.LeaseId,
                },
                SourceAuthentication = sourceAuthorization,
            };
        }

        internal static CommitBlockListOptions ToCommitBlockOptions(this BlockBlobStorageResourceOptions options)
        {
            // There's a lot of conditions that cannot be applied to a StageBlock Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/put-block-list#request-headers
            // to see what headers are accepted.
            return new CommitBlockListOptions()
            {
                HttpHeaders = options?.UploadOptions?.HttpHeaders,
                Metadata = options?.UploadOptions?.Metadata,
                Tags = options?.UploadOptions?.Tags,
                AccessTier = options?.UploadOptions?.AccessTier,
                ImmutabilityPolicy = options?.UploadOptions?.ImmutabilityPolicy,
                LegalHold = options?.UploadOptions?.LegalHold,
                Conditions = CreateRequestConditions(options?.UploadOptions?.Conditions, true)
            };
        }
    }
}
