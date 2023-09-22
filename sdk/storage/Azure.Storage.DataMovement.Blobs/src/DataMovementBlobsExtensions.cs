// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Threading;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.JobPlan;

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

        internal static async Task<BlockBlobStorageResourceOptions> GetBlockBlobResourceOptionsAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            CancellationToken cancellationToken)
        {
            BlobStorageResourceOptions baseOptions = await checkpointer.GetBlobResourceOptionsAsync(
                transferId,
                isSource,
                cancellationToken).ConfigureAwait(false);
            BlockBlobStorageResourceOptions options = new(baseOptions);

            // Get AccessTier
            if (!isSource)
            {
                int startIndex = DataMovementConstants.JobPartPlanFile.DstBlobBlockBlobTierIndex;
                JobPartPlanBlockBlobTier accessTier = (JobPartPlanBlockBlobTier)await checkpointer.GetByteValue(
                    transferId,
                    startIndex,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                options.AccessTier = accessTier.ToAccessTier();
            }
            return options;
        }

        internal static async Task<PageBlobStorageResourceOptions> GetPageBlobResourceOptionsAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            CancellationToken cancellationToken)
        {
            BlobStorageResourceOptions baseOptions = await checkpointer.GetBlobResourceOptionsAsync(
                transferId,
                isSource,
                cancellationToken).ConfigureAwait(false);
            PageBlobStorageResourceOptions options = new(baseOptions);

            if (!isSource)
            {
                // Get AccessTier
                int startIndex = DataMovementConstants.JobPartPlanFile.DstBlobPageBlobTierIndex;
                JobPartPlanPageBlobTier accessTier = (JobPartPlanPageBlobTier)await checkpointer.GetByteValue(
                    transferId,
                    startIndex,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                options.AccessTier = accessTier.ToAccessTier();
            }
            return options;
        }

        internal static async Task<BlobStorageResourceOptions> GetBlobResourceOptionsAsync(
            this TransferCheckpointer checkpointer,
            string transferId,
            bool isSource,
            CancellationToken cancellationToken)
        {
            BlobStorageResourceOptions options = new BlobStorageResourceOptions();

            // TODO: parse out the rest of the parameters from the Job Part Plan File

            if (!isSource)
            {
                // Get Metadata
                int metadataIndex = DataMovementConstants.JobPartPlanFile.DstBlobMetadataLengthIndex;
                int metadataReadLength = DataMovementConstants.JobPartPlanFile.DstBlobTagsLengthIndex - metadataIndex;
                string metadata = await checkpointer.GetHeaderUShortValue(
                    transferId,
                    metadataIndex,
                    metadataReadLength,
                    DataMovementConstants.JobPartPlanFile.MetadataStrNumBytes,
                    cancellationToken).ConfigureAwait(false);
                options.Metadata = metadata.ToDictionary(nameof(metadata));

                // Get blob tags
                int tagsIndex = DataMovementConstants.JobPartPlanFile.DstBlobTagsLengthIndex;
                int tagsReadLength = DataMovementConstants.JobPartPlanFile.DstBlobIsSourceEncrypted - tagsIndex;
                string tags = await checkpointer.GetHeaderLongValue(
                    transferId,
                    tagsIndex,
                    tagsReadLength,
                    DataMovementConstants.JobPartPlanFile.BlobTagsStrNumBytes,
                    cancellationToken).ConfigureAwait(false);
                options.Tags = tags.ToDictionary(nameof(tags));
            }
            return options;
        }

        internal static async Task<BlobStorageResourceContainerOptions> GetBlobContainerOptionsAsync(
            this TransferCheckpointer checkpointer,
            string directoryPrefix,
            string transferId,
            bool isSource,
            CancellationToken cancellationToken)
        {
            BlobStorageResourceOptions baseOptions = await checkpointer.GetBlobResourceOptionsAsync(
                transferId,
                isSource,
                cancellationToken).ConfigureAwait(false);
            BlobStorageResourceContainerOptions options = new()
            {
                BlobDirectoryPrefix = directoryPrefix,
                BlobOptions = baseOptions,
            };

            return options;
        }

        private static AccessTier ToAccessTier(this JobPartPlanBlockBlobTier tier)
        {
            if (JobPartPlanBlockBlobTier.Archive == tier)
            {
                return AccessTier.Archive;
            }
            else if (JobPartPlanBlockBlobTier.Cool == tier)
            {
                return AccessTier.Cool;
            }
            else if (JobPartPlanBlockBlobTier.Cold == tier)
            {
                return AccessTier.Cold;
            }
            else // including JobPartPlanBlockBlobTier.Hot == tier
            {
                return AccessTier.Hot;
            }
        }

        private static AccessTier ToAccessTier(this JobPartPlanPageBlobTier tier)
        {
            if (JobPartPlanPageBlobTier.P4 == tier)
            {
                return AccessTier.P4;
            }
            else if (JobPartPlanPageBlobTier.P6 == tier)
            {
                return AccessTier.P6;
            }
            else if (JobPartPlanPageBlobTier.P10 == tier)
            {
                return AccessTier.P10;
            }
            else if (JobPartPlanPageBlobTier.P15 == tier)
            {
                return AccessTier.P15;
            }
            else if (JobPartPlanPageBlobTier.P20 == tier)
            {
                return AccessTier.P20;
            }
            else if (JobPartPlanPageBlobTier.P30 == tier)
            {
                return AccessTier.P30;
            }
            else if (JobPartPlanPageBlobTier.P40 == tier)
            {
                return AccessTier.P40;
            }
            else if (JobPartPlanPageBlobTier.P50 == tier)
            {
                return AccessTier.P50;
            }
            else if (JobPartPlanPageBlobTier.P60 == tier)
            {
                return AccessTier.P60;
            }
            else if (JobPartPlanPageBlobTier.P70 == tier)
            {
                return AccessTier.P70;
            }
            else // including JobPartPlanPageBlobTier.P80 == tier
            {
                return AccessTier.P80;
            }
        }
    }
}
