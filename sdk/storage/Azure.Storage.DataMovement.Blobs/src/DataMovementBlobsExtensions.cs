// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs
{
    internal static partial class DataMovementBlobsExtensions
    {
        internal static StorageResourceItemProperties ToStorageResourceProperties(this BlobProperties blobProperties)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            if (blobProperties.Metadata != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.Metadata, blobProperties.Metadata);
            }
            if (blobProperties.CreatedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CreationTime, blobProperties.CreatedOn);
            }
            if (blobProperties.BlobType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.BlobType, blobProperties.BlobType);
            }
            if (blobProperties.ContentType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentType, blobProperties.ContentType);
            }
            if (blobProperties.ContentEncoding != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentEncoding, blobProperties.ContentEncoding);
            }
            if (blobProperties.ContentLanguage != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentLanguage, blobProperties.ContentLanguage);
            }
            if (blobProperties.ContentDisposition != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentDisposition, blobProperties.ContentDisposition);
            }
            if (blobProperties.CacheControl != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CacheControl, blobProperties.CacheControl);
            }
            if (blobProperties.AccessTier != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.AccessTier, new AccessTier(blobProperties.AccessTier));
            }

            return new StorageResourceItemProperties(
                resourceLength: blobProperties.ContentLength,
                eTag: blobProperties.ETag,
                lastModifiedTime: blobProperties.LastModified,
                properties: properties);
        }

        internal static StorageResourceItemProperties ToStorageResourceItemProperties(this BlobDownloadStreamingResult result)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            if (result.Details.Metadata != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.Metadata, result.Details.Metadata);
            }
            if (result.Details.CreatedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CreationTime, result.Details.CreatedOn);
            }
            if (result.Details.BlobType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.BlobType, result.Details.BlobType);
            }
            if (result.Details.ContentType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentType, result.Details.ContentType);
            }
            if (result.Details.ContentEncoding != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentEncoding, result.Details.ContentEncoding);
            }
            if (result.Details.ContentLanguage != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentLanguage, result.Details.ContentLanguage);
            }
            if (result.Details.ContentDisposition != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentDisposition, result.Details.ContentDisposition);
            }
            if (result.Details.CacheControl != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CacheControl, result.Details.CacheControl);
            }

            long? size = default;
            ContentRange contentRange = !string.IsNullOrWhiteSpace(result?.Details?.ContentRange) ? ContentRange.Parse(result.Details.ContentRange) : default;
            if (contentRange != default)
            {
                size = contentRange.Size;
            }

            return new StorageResourceItemProperties(
                resourceLength: size,
                eTag : result?.Details.ETag,
                lastModifiedTime: result?.Details.LastModified,
                properties: properties);
        }

        internal static StorageResourceReadStreamResult ToReadStreamStorageResourceInfo(this BlobDownloadStreamingResult result)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            if (result.Details.Metadata != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.Metadata, result.Details.Metadata);
            }
            if (result.Details.CreatedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CreationTime, result.Details.CreatedOn);
            }
            if (result.Details.BlobType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.BlobType, result.Details.BlobType);
            }
            if (result.Details.ContentType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentType, result.Details.ContentType);
            }
            if (result.Details.ContentEncoding != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentEncoding, result.Details.ContentEncoding);
            }
            if (result.Details.ContentLanguage != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentLanguage, result.Details.ContentLanguage);
            }
            if (result.Details.ContentDisposition != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentDisposition, result.Details.ContentDisposition);
            }
            if (result.Details.CacheControl != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CacheControl, result.Details.CacheControl);
            }

            HttpRange range = default;
            long? size = default;
            ContentRange contentRange = !string.IsNullOrWhiteSpace(result?.Details?.ContentRange) ? ContentRange.Parse(result.Details.ContentRange) : default;
            if (contentRange != default)
            {
                range = ContentRange.ToHttpRange(contentRange);
                size = contentRange.Size;
            }
            else if (result.Details.ContentLength > 0)
            {
                range = new HttpRange(0, result.Details.ContentLength);
                size = result.Details.ContentLength;
            }

            return new StorageResourceReadStreamResult(
                content: result.Content,
                range: range,
                properties: new StorageResourceItemProperties(
                    resourceLength: size.HasValue ? size : result.Details.ContentLength,
                    eTag: result.Details.ETag,
                    lastModifiedTime: result?.Details.LastModified,
                    properties: properties));
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
            };

            result.Conditions.IfMatch ??= etag;
            return result;
        }

        internal static AppendBlobCreateOptions GetCreateOptions(
            AppendBlobStorageResourceOptions options,
            bool overwrite,
            StorageResourceItemProperties sourceProperties)
        {
            return new AppendBlobCreateOptions()
            {
                HttpHeaders = GetHttpHeaders(options, sourceProperties?.RawProperties),
                Metadata = GetMetadata(options, sourceProperties?.RawProperties),
                Conditions = new AppendBlobRequestConditions()
                {
                    IfMatch = options?.DestinationConditions?.IfMatch,
                    IfNoneMatch = overwrite ? options?.DestinationConditions?.IfNoneMatch : new ETag(Constants.Wildcard),
                    IfUnmodifiedSince = options?.DestinationConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.DestinationConditions?.IfModifiedSince,
                    TagConditions = options?.DestinationConditions?.TagConditions,
                    LeaseId = options?.DestinationConditions?.LeaseId,
                },
            };
        }

        internal static AppendBlobAppendBlockOptions ToAppendBlockOptions(
            this AppendBlobStorageResourceOptions options,
            bool overwrite)
        {
            return new AppendBlobAppendBlockOptions()
            {
                Conditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
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
            };
            result.Conditions.IfMatch ??= etag;
            return result;
        }

        internal static BlobUploadOptions GetBlobUploadOptions(
            BlockBlobStorageResourceOptions options,
            bool overwrite,
            long initialSize,
            StorageResourceItemProperties sourceProperties)
        {
            return new BlobUploadOptions()
            {
                HttpHeaders = GetHttpHeaders(options, sourceProperties?.RawProperties),
                Metadata = GetMetadata(options, sourceProperties?.RawProperties),
                AccessTier = GetAccessTier(options, sourceProperties?.RawProperties),
                TransferOptions = new StorageTransferOptions()
                {
                    InitialTransferSize = initialSize,
                },
                Conditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
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
            };
        }

        internal static BlobSyncUploadFromUriOptions GetSyncUploadFromUriOptions(
            BlockBlobStorageResourceOptions options,
            bool overwrite,
            HttpAuthorization sourceAuthorization,
            StorageResourceItemProperties sourceProperties)
        {
            // There's a lot of conditions that cannot be applied to a Copy Blob (async) Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/copy-blob-from-url#request-headers
            // to see what headers are accepted.
            return new BlobSyncUploadFromUriOptions()
            {
                HttpHeaders = GetHttpHeaders(options, sourceProperties?.RawProperties),
                Metadata = GetMetadata(options, sourceProperties?.RawProperties),
                AccessTier = GetAccessTier(options, sourceProperties?.RawProperties),
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

        internal static CommitBlockListOptions GetCommitBlockOptions(
            BlockBlobStorageResourceOptions options,
            bool overwrite,
            StorageResourceItemProperties sourceProperties)
        {
            // There's a lot of conditions that cannot be applied to a StageBlock Request.
            // We need to omit them, but still apply them to other requests that do accept them.
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/put-block-list#request-headers
            // to see what headers are accepted.
            return new CommitBlockListOptions()
            {
                HttpHeaders = GetHttpHeaders(options, sourceProperties?.RawProperties),
                Metadata = GetMetadata(options, sourceProperties?.RawProperties),
                AccessTier = GetAccessTier(options, sourceProperties?.RawProperties),
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
            };
            result.Conditions.IfMatch ??= etag;
            return result;
        }

        internal static PageBlobCreateOptions GetCreateOptions(
            PageBlobStorageResourceOptions options,
            bool overwrite,
            StorageResourceItemProperties sourceProperties)
        {
            return new PageBlobCreateOptions()
            {
                SequenceNumber = options?.SequenceNumber,
                HttpHeaders = GetHttpHeaders(options, sourceProperties?.RawProperties),
                Metadata = GetMetadata(options, sourceProperties?.RawProperties),
                Conditions = new PageBlobRequestConditions()
                {
                    IfMatch = options?.DestinationConditions?.IfMatch,
                    IfNoneMatch = overwrite ? options?.DestinationConditions?.IfNoneMatch : new ETag(Constants.Wildcard),
                    IfUnmodifiedSince = options?.DestinationConditions?.IfUnmodifiedSince,
                    IfModifiedSince = options?.DestinationConditions?.IfModifiedSince,
                    TagConditions = options?.DestinationConditions?.TagConditions,
                    LeaseId = options?.DestinationConditions?.LeaseId,
                },
            };
        }

        internal static PageBlobUploadPagesOptions ToUploadPagesOptions(
            this PageBlobStorageResourceOptions options,
            bool overwrite)
        {
            return new PageBlobUploadPagesOptions()
            {
                Conditions = CreateRequestConditions(options?.DestinationConditions, overwrite),
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
                CacheControl = checkpointData.CacheControl,
                ContentDisposition = checkpointData.ContentDisposition,
                ContentEncoding = checkpointData.ContentEncoding,
                ContentLanguage = checkpointData.ContentLanguage,
                ContentType = checkpointData.ContentType,
                AccessTier = checkpointData.AccessTier,
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
                    CacheControl = options?.BlobOptions?.CacheControl,
                    ContentEncoding = options?.BlobOptions?.ContentEncoding,
                    ContentDisposition = options?.BlobOptions?.ContentDisposition,
                    ContentLanguage = options?.BlobOptions?.ContentLanguage,
                    ContentType = options?.BlobOptions?.ContentType,
                    AccessTier = options?.BlobOptions?.AccessTier,
                }
            };

        internal static StorageResourceItemProperties ToResourceProperties(this BlobItem blobItem)
        {
            Dictionary<string, object> properties = new();
            if (blobItem.Metadata != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.Metadata, blobItem.Metadata);
            }
            if (blobItem.Properties.AccessTier.HasValue)
            {
                properties.Add(DataMovementConstants.ResourceProperties.AccessTier, blobItem.Properties.AccessTier.Value);
            }
            if (blobItem.Properties.CreatedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CreationTime, blobItem.Properties.CreatedOn);
            }
            if (blobItem.Properties.BlobType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.BlobType, blobItem.Properties.BlobType);
            }
            if (blobItem.Properties.ContentType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentType, blobItem.Properties.ContentType);
            }
            if (blobItem.Properties.ContentEncoding != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentEncoding, blobItem.Properties.ContentEncoding);
            }
            if (blobItem.Properties.ContentLanguage != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentLanguage, blobItem.Properties.ContentLanguage);
            }
            if (blobItem.Properties.ContentDisposition != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentDisposition, blobItem.Properties.ContentDisposition);
            }
            if (blobItem.Properties.CacheControl != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CacheControl, blobItem.Properties.CacheControl);
            }

            return new StorageResourceItemProperties(
                resourceLength: blobItem.Properties.ContentLength,
                eTag: blobItem.Properties.ETag,
                lastModifiedTime: blobItem.Properties.LastModified,
                properties: properties);
        }

        internal static async Task ClearMetadataIfSet(
            BlobStorageResourceOptions options,
            Dictionary<string, object> sourceProperties,
            BlobBaseClient destinationBlobClient)
        {
            // If the metdata does NOT want to be preserved,
            // and does not contain a value. Clear the metdata.
            if (!(options?.Metadata?.Preserve ?? true) &&
                options?.Metadata?.Value == default)
            {
                // Only clear the metadata if there's metadata to clear.
                if (sourceProperties?.TryGetValue(DataMovementConstants.ResourceProperties.Metadata, out object metadataObject) == true)
                {
                    await destinationBlobClient.SetMetadataAsync(default).ConfigureAwait(false);
                }
            }
            BlobHttpHeaders headers = GetHttpHeaders(options, sourceProperties);
            bool callSetHttpHeaders = false;
            // If the HttpHeaders should NOT be preserved
            // and does not contain a value to set it to. Clear the respective value.
            if (!(options?.CacheControl?.Preserve ?? true) &&
                options?.CacheControl?.Value == default)
            {
                // Only clear the cache control if there's cache control to clear.
                if (sourceProperties?.TryGetValue(DataMovementConstants.ResourceProperties.CacheControl, out object cacheControlObject) == true)
                {
                    headers.CacheControl = default;
                    callSetHttpHeaders = true;
                }
            }
            if (!(options?.ContentDisposition?.Preserve ?? true) &&
                options?.ContentDisposition?.Value == default)
            {
                // Only clear the content disposition if there's cache control to clear.
                if (sourceProperties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentDisposition, out object outObject) == true)
                {
                    headers.ContentDisposition = default;
                    callSetHttpHeaders = true;
                }
            }
            if (!(options?.ContentEncoding?.Preserve ?? true) &&
                options?.ContentEncoding?.Value == default)
            {
                // Only clear the cache control if there's cache control to clear.
                if (sourceProperties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentEncoding, out object outObject) == true)
                {
                    headers.ContentEncoding = default;
                    callSetHttpHeaders = true;
                }
            }
            if (!(options?.ContentLanguage?.Preserve ?? true) &&
                options?.ContentLanguage?.Value == default)
            {
                // Only clear the cache control if there's cache control to clear.
                if (sourceProperties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentLanguage, out object outObject) == true)
                {
                    headers.ContentLanguage = default;
                    callSetHttpHeaders = true;
                }
            }
            if (!(options?.CacheControl?.Preserve ?? true) &&
                options?.CacheControl?.Value == default)
            {
                // Only clear the cache control if there's cache control to clear.
                if (sourceProperties?.TryGetValue(DataMovementConstants.ResourceProperties.CacheControl, out object outObject) == true)
                {
                    headers.CacheControl = default;
                    callSetHttpHeaders = true;
                }
            }
            if (callSetHttpHeaders)
            {
                await destinationBlobClient.SetHttpHeadersAsync(headers).ConfigureAwait(false);
            }

            // If the Access Tier does NOT want to be preserved,
            // and does not contain a value. Clear the access tier.
            if (!(options?.AccessTier?.Preserve ?? true) &&
                options?.AccessTier?.Value == default)
            {
                // Only clear the metadata if there's metadata to clear.
                if (sourceProperties?.TryGetValue(DataMovementConstants.ResourceProperties.AccessTier, out object accessTierObject) == true)
                {
                    if ((AccessTier) accessTierObject != AccessTier.Hot)
                    {
                        await destinationBlobClient.SetAccessTierAsync(AccessTier.Hot).ConfigureAwait(false);
                    }
                }
            }
        }

        private static BlobHttpHeaders GetHttpHeaders(
            BlobStorageResourceOptions options,
            Dictionary<string, object> properties)
            => new()
            {
                ContentType = (options?.ContentType?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentType, out object contentType) == true
                        ? (string) contentType
                        : default
                    : options?.ContentType?.Value,
                ContentEncoding = (options?.ContentEncoding?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentEncoding, out object contentEncoding) == true
                        ? (string) contentEncoding
                        : default
                    : options?.ContentEncoding?.Value,
                ContentLanguage = (options?.ContentLanguage?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentLanguage, out object contentLanguage) == true
                        ? (string) contentLanguage
                        : default
                    : options?.ContentLanguage?.Value,
                ContentDisposition = (options?.ContentDisposition?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentDisposition, out object contentDisposition) == true
                        ? (string) contentDisposition
                        : default
                : options?.ContentDisposition?.Value,
                CacheControl = (options?.CacheControl?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.CacheControl, out object cacheControl) == true
                        ? (string) cacheControl
                        : default
                    : options?.CacheControl?.Value,
            };

        // By default we preserve the access tier
        private static AccessTier? GetAccessTier(
            BlobStorageResourceOptions options,
            Dictionary<string, object> properties)
            => (options?.AccessTier?.Preserve ?? true)
               ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.AccessTier, out object accessTierObject) == true
                    ? (AccessTier?)accessTierObject
                    : default
               : options?.AccessTier?.Value;

        // By default we preserve the metadata
        private static Metadata GetMetadata(
            BlobStorageResourceOptions options,
            Dictionary<string, object> properties)
            => (options?.Metadata?.Preserve ?? true)
                ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.Metadata, out object metadataObject) == true
                    ? (Metadata) metadataObject
                    : default
               : options?.Metadata?.Value;
    }
}
