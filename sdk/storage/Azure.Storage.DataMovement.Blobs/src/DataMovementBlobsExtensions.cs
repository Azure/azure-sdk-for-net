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

        /// <summary>
        /// Deep copies the Blob Request Conditions along with changing the IfNoneMatch to
        /// the wildcard value if overwrite is enabled.
        /// </summary>
        internal static AppendBlobRequestConditions CreateRequestConditions(AppendBlobRequestConditions conditions, bool overwrite = true)
        {
            return new AppendBlobRequestConditions()
            {
                IfAppendPositionEqual = conditions?.IfAppendPositionEqual,
                IfMaxSizeLessThanOrEqual = conditions?.IfMaxSizeLessThanOrEqual,
                IfMatch = conditions?.IfMatch,
                IfNoneMatch = overwrite ? conditions?.IfNoneMatch : new ETag(Constants.Wildcard),
                IfUnmodifiedSince = conditions?.IfUnmodifiedSince,
                IfModifiedSince = conditions?.IfModifiedSince,
                TagConditions = conditions?.TagConditions,
                LeaseId = conditions?.LeaseId,
            };
        }

        /// <summary>
        /// Deep copies the Blob Request Conditions along with changing the IfNoneMatch to
        /// the wildcard value if overwrite is enabled.
        /// </summary>
        internal static PageBlobRequestConditions CreateRequestConditions(PageBlobRequestConditions conditions, bool overwrite = true)
        {
            return new PageBlobRequestConditions()
            {
                IfSequenceNumberEqual = conditions?.IfSequenceNumberEqual,
                IfSequenceNumberLessThanOrEqual = conditions?.IfSequenceNumberLessThanOrEqual,
                IfSequenceNumberLessThan = conditions?.IfSequenceNumberLessThan,
                IfMatch = conditions?.IfMatch,
                IfNoneMatch = overwrite ? conditions?.IfNoneMatch : new ETag(Constants.Wildcard),
                IfUnmodifiedSince = conditions?.IfUnmodifiedSince,
                IfModifiedSince = conditions?.IfModifiedSince,
                TagConditions = conditions?.TagConditions,
                LeaseId = conditions?.LeaseId,
            };
        }

        internal static AppendBlobStorageResourceOptions ToAppendBlobStorageResourceOptions(
            this BlobStorageResourceContainerOptions options)
        {
            return new AppendBlobStorageResourceOptions()
            {
                CopyMethod = (TransferCopyMethod)(options?.CopyMethod),
            };
        }

        internal static BlobDownloadOptions ToBlobDownloadOptions(
            this AppendBlobStorageResourceOptions options,
            HttpRange range)
        {
            return new BlobDownloadOptions()
            {
                Range = range,
                Conditions = CreateRequestConditions(options?.SourceConditions, true),
                TransferValidation = options?.DownloadTransferValidationOptions,
            };
        }

        internal static AppendBlobCreateOptions ToCreateOptions(
            this AppendBlobStorageResourceOptions options,
            bool overwrite)
        {
            return new AppendBlobCreateOptions()
            {
                HttpHeaders = options?.HttpHeaders,
                Metadata = options?.Metadata,
                Tags = options?.Tags,
                Conditions = new AppendBlobRequestConditions()
                {
                    IfMatch = options?.DestinationConditions?.IfMatch,
                    IfNoneMatch = overwrite ? options?.DestinationConditions?.IfNoneMatch : new ETag(Constants.Wildcard),
                    IfUnmodifiedSince = options?.DestinationConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.DestinationConditions?.IfModifiedSince,
                    TagConditions = options?.DestinationConditions?.TagConditions,
                    LeaseId = options?.DestinationConditions?.LeaseId,
                },
                ImmutabilityPolicy = options?.DestinationImmutabilityPolicy,
                HasLegalHold = options?.LegalHold,
            };
        }

        internal static AppendBlobAppendBlockOptions ToAppendBlockOptions(
            this AppendBlobStorageResourceOptions options,
            bool overwrite)
        {
            return new AppendBlobAppendBlockOptions()
            {
                Conditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                TransferValidation = options?.UploadTransferValidationOptions,
            };
        }

        internal static BlobCopyFromUriOptions ToBlobCopyFromUriOptions(
            this AppendBlobStorageResourceOptions options,
            bool overwrite,
            HttpAuthorization sourceAuthorization)
        {
            // There's a lot of conditions that cannot be applied to a Copy Blob (async) Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/copy-blob#request-headers
            // to see what headers are accepted.
            return new BlobCopyFromUriOptions()
            {
                Metadata = options?.Metadata,
                Tags = options?.Tags,
                AccessTier = options?.AccessTier,
                SourceConditions = new BlobRequestConditions()
                {
                    IfMatch = options?.SourceConditions?.IfMatch,
                    IfUnmodifiedSince = options?.SourceConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.SourceConditions?.IfModifiedSince,
                    TagConditions = options?.SourceConditions?.TagConditions,
                },
                DestinationConditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                ShouldSealDestination = options?.ShouldSealDestination,
                RehydratePriority = options?.RehydratePriority,
                DestinationImmutabilityPolicy = options?.DestinationImmutabilityPolicy,
                LegalHold = options?.LegalHold,
                SourceAuthentication = sourceAuthorization,
                CopySourceTagsMode = options?.CopySourceTagsMode,
            };
        }

        internal static AppendBlobAppendBlockFromUriOptions ToAppendBlockFromUriOptions(
            this AppendBlobStorageResourceOptions options,
            bool overwrite,
            HttpRange range,
            HttpAuthorization sourceAuthorization)
        {
            return new AppendBlobAppendBlockFromUriOptions()
            {
                SourceRange = range,
                SourceConditions = new AppendBlobRequestConditions()
                {
                    IfAppendPositionEqual = options?.SourceConditions?.IfAppendPositionEqual,
                    IfMaxSizeLessThanOrEqual = options?.SourceConditions?.IfMaxSizeLessThanOrEqual,
                    IfMatch = options?.SourceConditions?.IfMatch,
                    IfUnmodifiedSince = options?.SourceConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.SourceConditions?.IfModifiedSince,
                    TagConditions = options?.SourceConditions?.TagConditions,
                    LeaseId = options?.SourceConditions?.LeaseId,
                },
                DestinationConditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                SourceAuthentication = sourceAuthorization,
            };
        }

        internal static BlockBlobStorageResourceOptions ToBlockBlobStorageResourceOptions(
            this BlobStorageResourceContainerOptions options)
        {
            return new BlockBlobStorageResourceOptions()
            {
                CopyMethod = options != default ? options.CopyMethod : TransferCopyMethod.None,
            };
        }

        internal static BlobDownloadOptions ToBlobDownloadOptions(this BlockBlobStorageResourceOptions options, HttpRange range)
        {
            return new BlobDownloadOptions()
            {
                Range = range,
                Conditions = CreateRequestConditions(options?.SourceConditions),
                TransferValidation = options?.DownloadTransferValidationOptions,
            };
        }

        internal static BlobUploadOptions ToBlobUploadOptions(this BlockBlobStorageResourceOptions options, bool overwrite, long initialSize)
        {
            return new BlobUploadOptions()
            {
                HttpHeaders = options?.HttpHeaders,
                Metadata = options?.Metadata,
                Tags = options?.Tags,
                AccessTier = options?.AccessTier,
                ImmutabilityPolicy = options?.DestinationImmutabilityPolicy,
                LegalHold = options?.LegalHold,
                TransferOptions = new StorageTransferOptions()
                {
                    InitialTransferSize = initialSize,
                },
                Conditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                TransferValidation = options?.UploadTransferValidationOptions,
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
                    LeaseId = options?.DestinationConditions?.LeaseId,
                    TagConditions = options?.DestinationConditions?.TagConditions,
                },
                TransferValidation = options?.UploadTransferValidationOptions,
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
                Metadata = options?.Metadata,
                Tags = options?.Tags,
                AccessTier = options?.AccessTier,
                SourceConditions = new BlobRequestConditions()
                {
                    IfMatch = options?.SourceConditions?.IfMatch,
                    IfUnmodifiedSince = options?.SourceConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.SourceConditions?.IfModifiedSince,
                    TagConditions = options?.SourceConditions?.TagConditions,
                },
                DestinationConditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                RehydratePriority = options?.RehydratePriority,
                DestinationImmutabilityPolicy = options?.DestinationImmutabilityPolicy,
                LegalHold = options?.LegalHold,
                SourceAuthentication = sourceAuthorization,
                CopySourceTagsMode = options?.CopySourceTagsMode,
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
                CopySourceBlobProperties = options?.CopySourceBlobProperties,
                HttpHeaders = options?.HttpHeaders,
                Tags = options?.Tags,
                AccessTier = options?.AccessTier,
                SourceConditions = new BlobRequestConditions()
                {
                    IfMatch = options?.SourceConditions?.IfMatch,
                    IfUnmodifiedSince = options?.SourceConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.SourceConditions?.IfModifiedSince,
                    TagConditions = options?.SourceConditions?.TagConditions,
                },
                DestinationConditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                SourceAuthentication = sourceAuthorization,
                CopySourceTagsMode = options?.CopySourceTagsMode,
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
                SourceConditions = CreateRequestConditions(options?.SourceConditions, true),
                DestinationConditions = new BlobRequestConditions()
                {
                    LeaseId = options?.DestinationConditions?.LeaseId,
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
                HttpHeaders = options?.HttpHeaders,
                Metadata = options?.Metadata,
                Tags = options?.Tags,
                AccessTier = options?.AccessTier,
                ImmutabilityPolicy = options?.DestinationImmutabilityPolicy,
                LegalHold = options?.LegalHold,
                Conditions = CreateRequestConditions(options?.DestinationConditions, true)
            };
        }

        internal static PageBlobStorageResourceOptions ToPageBlobStorageResourceOptions(
            this BlobStorageResourceContainerOptions options)
        {
            return new PageBlobStorageResourceOptions()
            {
                CopyMethod = (TransferCopyMethod)(options?.CopyMethod),
            };
        }

        internal static BlobDownloadOptions ToBlobDownloadOptions(
            this PageBlobStorageResourceOptions options,
            HttpRange range)
        {
            return new BlobDownloadOptions()
            {
                Range = range,
                Conditions = CreateRequestConditions(options?.SourceConditions, true),
                TransferValidation = options?.DownloadTransferValidationOptions,
            };
        }

        internal static PageBlobCreateOptions ToCreateOptions(
            this PageBlobStorageResourceOptions options,
            bool overwrite)
        {
            return new PageBlobCreateOptions()
            {
                SequenceNumber = options?.SequenceNumber,
                HttpHeaders = options?.HttpHeaders,
                Metadata = options?.Metadata,
                Tags = options?.Tags,
                Conditions = new PageBlobRequestConditions()
                {
                    IfMatch = options?.DestinationConditions?.IfMatch,
                    IfNoneMatch = overwrite ? options?.DestinationConditions?.IfNoneMatch : new ETag(Constants.Wildcard),
                    IfUnmodifiedSince = options?.DestinationConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.DestinationConditions?.IfModifiedSince,
                    TagConditions = options?.DestinationConditions?.TagConditions,
                    LeaseId = options?.DestinationConditions?.LeaseId,
                },
                ImmutabilityPolicy = options?.DestinationImmutabilityPolicy,
                LegalHold = options?.LegalHold,
            };
        }

        internal static PageBlobUploadPagesOptions ToUploadPagesOptions(
            this PageBlobStorageResourceOptions options,
            bool overwrite)
        {
            return new PageBlobUploadPagesOptions()
            {
                Conditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                TransferValidation = options?.UploadTransferValidationOptions,
            };
        }

        internal static BlobCopyFromUriOptions ToBlobCopyFromUriOptions(
            this PageBlobStorageResourceOptions options,
            bool overwrite,
            HttpAuthorization sourceAuthorization)
        {
            // There's a lot of conditions that cannot be applied to a Copy Blob (async) Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/copy-blob#request-headers
            // to see what headers are accepted.
            return new BlobCopyFromUriOptions()
            {
                Metadata = options?.Metadata,
                Tags = options?.Tags,
                AccessTier = options?.AccessTier,
                SourceConditions = new BlobRequestConditions()
                {
                    IfMatch = options?.SourceConditions?.IfMatch,
                    IfUnmodifiedSince = options?.SourceConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.SourceConditions?.IfModifiedSince,
                    TagConditions = options?.SourceConditions?.TagConditions,
                },
                DestinationConditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                RehydratePriority = options?.RehydratePriority,
                DestinationImmutabilityPolicy = options?.DestinationImmutabilityPolicy,
                LegalHold = options?.LegalHold,
                SourceAuthentication = sourceAuthorization,
                CopySourceTagsMode = options?.CopySourceTagsMode,
            };
        }

        internal static PageBlobUploadPagesFromUriOptions ToUploadPagesFromUriOptions(
            this PageBlobStorageResourceOptions options,
            bool overwrite,
            HttpAuthorization sourceAuthorization)
        {
            return new PageBlobUploadPagesFromUriOptions()
            {
                SourceConditions = new PageBlobRequestConditions()
                {
                    IfMatch = options?.SourceConditions?.IfMatch,
                    IfUnmodifiedSince = options?.SourceConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.SourceConditions?.IfModifiedSince,
                    LeaseId = options?.SourceConditions?.LeaseId,
                },
                DestinationConditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
                SourceAuthentication = sourceAuthorization,
            };
        }
    }
}
