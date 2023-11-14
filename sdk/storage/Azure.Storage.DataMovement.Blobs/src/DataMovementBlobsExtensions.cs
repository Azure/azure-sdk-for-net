// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Threading;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.JobPlan;
using System.IO;

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
                lastAccessed: blobProperties.LastAccessed);
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
                lastAccessed: blobProperties.LastAccessed);
        }

        internal static StorageResourceReadStreamResult ToReadStreamStorageResourceInfo(this BlobDownloadStreamingResult result)
        {
            return new StorageResourceReadStreamResult(
                content: result.Content,
                contentRange: result.Details.ContentRange,
                acceptRanges: result.Details.AcceptRanges,
                rangeContentHash: result.Details.BlobContentHash,
                properties: result.Details.ToStorageResourceProperties());
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
            return new AppendBlobStorageResourceOptions(options?.BlobOptions);
        }

        internal static BlobDownloadOptions ToBlobDownloadOptions(
            this AppendBlobStorageResourceOptions options,
            HttpRange range,
            ETag? etag)
        {
            var result = new BlobDownloadOptions()
            {
                Range = range,
                Conditions = CreateRequestConditions(options?.SourceConditions, true),
                TransferValidation = options?.DownloadTransferValidationOptions,
            };

            result.Conditions.IfMatch ??= etag;
            return result;
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
            return new BlockBlobStorageResourceOptions(options?.BlobOptions);
        }

        internal static BlobDownloadOptions ToBlobDownloadOptions(
            this BlockBlobStorageResourceOptions options,
            HttpRange range,
            ETag? etag)
        {
            var result = new BlobDownloadOptions()
            {
                Range = range,
                Conditions = CreateRequestConditions(options?.SourceConditions),
                TransferValidation = options?.DownloadTransferValidationOptions,
            };
            result.Conditions.IfMatch ??= etag;
            return result;
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
                HttpHeaders = options?.HttpHeaders,
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
                SourceAuthentication = sourceAuthorization,
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

        internal static CommitBlockListOptions ToCommitBlockOptions(this BlockBlobStorageResourceOptions options, bool overwrite)
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
                Conditions = CreateRequestConditions(options?.DestinationConditions, overwrite)
            };
        }

        internal static PageBlobStorageResourceOptions ToPageBlobStorageResourceOptions(
            this BlobStorageResourceContainerOptions options)
        {
            return new PageBlobStorageResourceOptions(options?.BlobOptions);
        }

        internal static BlobDownloadOptions ToBlobDownloadOptions(
            this PageBlobStorageResourceOptions options,
            HttpRange range,
            ETag? etag)
        {
            var result = new BlobDownloadOptions()
            {
                Range = range,
                Conditions = CreateRequestConditions(options?.SourceConditions, true),
                TransferValidation = options?.DownloadTransferValidationOptions,
            };
            result.Conditions.IfMatch ??= etag;
            return result;
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

        internal static BlobCheckpointData GetCheckpointData(this DataTransferProperties properties, bool isSource)
        {
            if (isSource)
            {
                using (MemoryStream stream = new(properties.SourceCheckpointData))
                {
                    return BlobSourceCheckpointData.Deserialize(stream);
                }
            }
            else
            {
                using (MemoryStream stream = new(properties.DestinationCheckpointData))
                {
                    return BlobDestinationCheckpointData.Deserialize(stream);
                }
            }
        }

        internal static BlobStorageResourceOptions GetBlobResourceOptions(
            this BlobDestinationCheckpointData checkpointData)
        {
            return new()
            {
                Metadata = checkpointData.Metadata,
                Tags = checkpointData.Tags,
                HttpHeaders = checkpointData.ContentHeaders,
                AccessTier = checkpointData.AccessTier,
                // LegalHold = checkpointData.LegalHold
            };
        }

        internal static BlockBlobStorageResourceOptions GetBlockBlobResourceOptions(
            this BlobDestinationCheckpointData checkpointData)
        {
            BlobStorageResourceOptions baseOptions = checkpointData.GetBlobResourceOptions();
            return new BlockBlobStorageResourceOptions(baseOptions);
        }

        internal static PageBlobStorageResourceOptions GetPageBlobResourceOptions(
            this BlobDestinationCheckpointData checkpointData)
        {
            BlobStorageResourceOptions baseOptions = checkpointData.GetBlobResourceOptions();
            return new PageBlobStorageResourceOptions(baseOptions);
        }

        internal static AppendBlobStorageResourceOptions GetAppendBlobResourceOptions(
            this BlobDestinationCheckpointData checkpointData)
        {
            BlobStorageResourceOptions baseOptions = checkpointData.GetBlobResourceOptions();
            return new AppendBlobStorageResourceOptions(baseOptions);
        }

        internal static BlobStorageResourceContainerOptions GetBlobContainerOptions(
            this BlobDestinationCheckpointData checkpointData,
            string directoryPrefix)
        {
            BlobStorageResourceOptions baseOptions = checkpointData.GetBlobResourceOptions();
            return new BlobStorageResourceContainerOptions()
            {
                BlobType = checkpointData.BlobType,
                BlobDirectoryPrefix = directoryPrefix,
                BlobOptions = baseOptions,
            };
        }

        internal static BlobStorageResourceContainerOptions DeepCopy(this BlobStorageResourceContainerOptions options)
            => new BlobStorageResourceContainerOptions()
            {
                BlobType = options?.BlobType ?? BlobType.Block,
                BlobDirectoryPrefix = options?.BlobDirectoryPrefix,
                BlobOptions = new BlobStorageResourceOptions()
                {
                    Metadata = options?.BlobOptions?.Metadata,
                    Tags = options?.BlobOptions?.Tags,
                    HttpHeaders = options?.BlobOptions?.HttpHeaders,
                    AccessTier = options?.BlobOptions?.AccessTier,
                    DestinationImmutabilityPolicy = options?.BlobOptions?.DestinationImmutabilityPolicy,
                    LegalHold = options?.BlobOptions?.LegalHold,
                    UploadTransferValidationOptions = options?.BlobOptions?.UploadTransferValidationOptions,
                    DownloadTransferValidationOptions = options?.BlobOptions?.DownloadTransferValidationOptions,
                }
            };
    }
}
