// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal static partial class DataMovementSharesExtensions
    {
        internal static ShareFileUploadOptions ToShareFileUploadOptions(
            this ShareFileStorageResourceOptions options)
            => new()
            {
                Conditions = options?.DestinationConditions,
                TransferValidation = options?.UploadTransferValidationOptions,
            };

        internal static ShareFileUploadRangeOptions ToShareFileUploadRangeOptions(
            this ShareFileStorageResourceOptions options)
            => new()
            {
                Conditions = options?.DestinationConditions,
                TransferValidation = options?.UploadTransferValidationOptions,
            };

        internal static ShareFileUploadRangeFromUriOptions ToShareFileUploadRangeFromUriOptions(
            this ShareFileStorageResourceOptions options,
            HttpAuthorization sourceAuthorization)
            => new()
            {
                Conditions = options?.DestinationConditions,
                SourceAuthentication = sourceAuthorization
            };

        internal static StorageResourceItemProperties ToStorageResourceProperties(
            this ShareFileProperties fileProperties)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            if (fileProperties.Metadata != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.Metadata, fileProperties.Metadata);
            }
            if (fileProperties.ETag != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ETag, fileProperties.ETag);
            }
            if (fileProperties.LastModified != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.LastModified, fileProperties.LastModified);
            }
            if (fileProperties.SmbProperties.FileCreatedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CreationTime, fileProperties.SmbProperties.FileCreatedOn);
            }
            if (fileProperties.ContentType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentType, fileProperties.ContentType);
            }
            if (fileProperties.ContentHash != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentHash, fileProperties.ContentHash);
            }
            if (fileProperties.ContentEncoding != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentEncoding, fileProperties.ContentEncoding);
            }
            if (fileProperties.ContentLanguage != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentLanguage, fileProperties.ContentLanguage);
            }
            if (fileProperties.ContentDisposition != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentDisposition, fileProperties.ContentDisposition);
            }
            if (fileProperties.CacheControl != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CacheControl, fileProperties.CacheControl);
            }
            return new StorageResourceItemProperties(
                contentLength: fileProperties.ContentLength,
                properties: properties);
        }

        internal static ShareFileDownloadOptions ToShareFileDownloadOptions(
            this ShareFileStorageResourceOptions options,
            HttpRange range)
            => new()
            {
                Range = range,
                Conditions = options?.SourceConditions,
                TransferValidation = options?.DownloadTransferValidationOptions,
            };

        internal static StorageResourceReadStreamResult ToStorageResourceReadStreamResult(
            this ShareFileDownloadInfo info)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            if (info.Details.Metadata != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.Metadata, info.Details.Metadata);
            }
            if (info.Details.ETag != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ETag, info.Details.ETag);
            }
            if (info.Details.LastModified != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.LastModified, info.Details.LastModified);
            }
            if (info.Details.SmbProperties.FileCreatedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CreationTime, info.Details.SmbProperties.FileCreatedOn);
            }
            if (info.Details.ContentEncoding != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentEncoding, info.Details.ContentEncoding);
            }
            if (info.Details.ContentLanguage != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentLanguage, info.Details.ContentLanguage);
            }
            if (info.Details.ContentDisposition != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentDisposition, info.Details.ContentDisposition);
            }
            if (info.Details.CacheControl != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CacheControl, info.Details.CacheControl);
            }

            HttpRange range = default;
            long? size = default;
            ContentRange contentRange = ContentRange.Parse(info.Details.ContentRange);
            if (contentRange != default)
            {
                range = ContentRange.ToHttpRange(contentRange);
                size = contentRange.Size;
            }

            return new StorageResourceReadStreamResult(
                content: info.Content,
                range: range,
                properties: new StorageResourceItemProperties(
                    contentLength: size.HasValue ? size : info.ContentLength,
                    properties: properties));
        }
    }
}
