// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

            return new StorageResourceItemProperties()
            {
                ResourceLength = blobProperties.ContentLength,
                ETag = blobProperties.ETag,
                LastModifiedTime = blobProperties.LastModified,
                RawProperties = properties
            };
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

            return new StorageResourceItemProperties()
            {
                ResourceLength = size,
                ETag = result?.Details.ETag,
                LastModifiedTime = result?.Details.LastModified,
                RawProperties = properties
            };
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
                properties: new StorageResourceItemProperties()
                {
                    ResourceLength = size.HasValue ? size : result.Details.ContentLength,
                    ETag = result.Details.ETag,
                    LastModifiedTime = result?.Details.LastModified,
                    RawProperties = properties
                });
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
            // See https://learn.microsoft.com/en-us/rest/api/storageservices/put-blob-from-url?tabs=microsoft-entra-id#request-headers
            // to see what headers are accepted.
            BlobSyncUploadFromUriOptions uploadFromUriOptions = new BlobSyncUploadFromUriOptions()
            {
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
            if (options == default ||
                ((options?._isContentEncodingSet == false) &&
                (options?._isContentDispositionSet == false) &&
                (options?._isContentLanguageSet == false) &&
                (options?._isContentTypeSet == false) &&
                (options?._isCacheControlSet == false) &&
                (options?._isMetadataSet == false)))
            {
                return uploadFromUriOptions;
            }
            // If all the properties are not being preserved, we need to clear them and manually
            // set them from the source. We can't do it the other way around because the service
            // does not clear the properties if you send an empty value.
            uploadFromUriOptions.CopySourceBlobProperties = false;
            uploadFromUriOptions.HttpHeaders = GetHttpHeaders(options, sourceProperties?.RawProperties);
            uploadFromUriOptions.Metadata = GetMetadata(options, sourceProperties?.RawProperties);
            return uploadFromUriOptions;
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

        internal static StorageResourceCheckpointDetails GetCheckpointDetails(this TransferProperties properties, bool isSource)
        {
            if (isSource)
            {
                using (MemoryStream stream = new(properties.SourceCheckpointDetails))
                {
                    return BlobSourceCheckpointDetails.Deserialize(stream);
                }
            }
            else
            {
                using (MemoryStream stream = new(properties.DestinationCheckpointDetails))
                {
                    return BlobDestinationCheckpointDetails.Deserialize(stream);
                }
            }
        }

        internal static BlockBlobStorageResourceOptions GetBlockBlobResourceOptions(
            this BlobDestinationCheckpointDetails checkpointDetails)
            => new BlockBlobStorageResourceOptions(checkpointDetails);

        internal static PageBlobStorageResourceOptions GetPageBlobResourceOptions(
            this BlobDestinationCheckpointDetails checkpointDetails)
            => new PageBlobStorageResourceOptions(checkpointDetails);

        internal static AppendBlobStorageResourceOptions GetAppendBlobResourceOptions(
            this BlobDestinationCheckpointDetails checkpointDetails)
            => new AppendBlobStorageResourceOptions(checkpointDetails);

        internal static BlobStorageResourceContainerOptions GetBlobContainerOptions(
            this BlobDestinationCheckpointDetails checkpointDetails,
            string directoryPrefix)
        {
            return new BlobStorageResourceContainerOptions()
            {
                BlobType = default,
                _isBlobTypeSet = false,
                BlobDirectoryPrefix = directoryPrefix,
                BlobOptions = new(checkpointDetails),
            };
        }

        internal static BlobStorageResourceContainerOptions DeepCopy(this BlobStorageResourceContainerOptions options)
            => new BlobStorageResourceContainerOptions()
            {
                BlobType = options?.BlobType,
                _isBlobTypeSet = options?._isBlobTypeSet ?? false,
                BlobDirectoryPrefix = options?.BlobDirectoryPrefix,
                BlobOptions = new BlobStorageResourceOptions(options?.BlobOptions)
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

            return new StorageResourceItemProperties()
            {
                ResourceLength = blobItem.Properties.ContentLength,
                ETag = blobItem.Properties.ETag,
                LastModifiedTime = blobItem.Properties.LastModified,
                RawProperties = properties
            };
        }

        private static string ConvertContentPropertyObjectToString(string contentPropertyName, object contentPropertyValue)
        {
            if (contentPropertyValue is string)
            {
                return contentPropertyValue as string;
            }
            else if (contentPropertyValue is string[])
            {
                return string.Join(",", (string[])contentPropertyValue);
            }
            else
            {
                throw Errors.UnexpectedPropertyType(contentPropertyName, DataMovementConstants.StringTypeStr, DataMovementConstants.StringArrayTypeStr);
            }
        }

        private static BlobHttpHeaders GetHttpHeaders(
            BlobStorageResourceOptions options,
            IDictionary<string, object> properties)
            => new()
            {
                ContentType = (options?._isContentTypeSet ?? false)
                    ? options?.ContentType
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentType, out object contentType) == true
                        ? (string) contentType
                        : default,
                ContentEncoding = (options?._isContentEncodingSet ?? false)
                    ? options?.ContentEncoding
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentEncoding, out object contentEncoding) == true
                        ? ConvertContentPropertyObjectToString(DataMovementConstants.ResourceProperties.ContentEncoding, contentEncoding)
                        : default,
                ContentLanguage = (options?._isContentLanguageSet ?? false)
                    ? options?.ContentLanguage
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentLanguage, out object contentLanguage) == true
                        ? ConvertContentPropertyObjectToString(DataMovementConstants.ResourceProperties.ContentLanguage, contentLanguage)
                        : default,
                ContentDisposition = (options?._isContentDispositionSet ?? false)
                    ? options?.ContentDisposition
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentDisposition, out object contentDisposition) == true
                        ? (string)contentDisposition
                        : default,
                CacheControl = (options?._isCacheControlSet ?? false)
                    ? options?.CacheControl
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.CacheControl, out object cacheControl) == true
                        ? (string)cacheControl
                        : default
            };

        // Get the access tier property
        private static AccessTier? GetAccessTier(
            BlobStorageResourceOptions options,
            IDictionary<string, object> properties)
            => options?.AccessTier != default
                ? options?.AccessTier
                : properties?.TryGetValue(DataMovementConstants.ResourceProperties.AccessTier, out object accessTierObject) == true
                    ? (AccessTier?)accessTierObject
                    : default;

        // By default we preserve the metadata
        private static Metadata GetMetadata(
            BlobStorageResourceOptions options,
            IDictionary<string, object> properties)
            => (options?._isMetadataSet ?? false)
                ? options?.Metadata
                : properties?.TryGetValue(DataMovementConstants.ResourceProperties.Metadata, out object metadataObject) == true
                    ? (Metadata)metadataObject
                    : default;
    }
}
