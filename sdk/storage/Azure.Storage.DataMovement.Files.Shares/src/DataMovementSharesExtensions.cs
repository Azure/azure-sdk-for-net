// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        internal static StorageResourceItemProperties ToStorageResourceItemProperties(
            this ShareFileProperties fileProperties)
        {
            Dictionary<string, object> properties = new();
            if (fileProperties.Metadata != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.Metadata, fileProperties.Metadata);
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
                resourceLength: fileProperties.ContentLength,
                eTag: fileProperties.ETag,
                lastModifiedTime: fileProperties.SmbProperties.FileLastWrittenOn,
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
            Dictionary<string, object> properties = new();
            if (info.Details.Metadata != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.Metadata, info.Details.Metadata);
            }
            if (info.Details.SmbProperties.FileCreatedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.CreationTime, info.Details.SmbProperties.FileCreatedOn);
            }
            if (info.ContentType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentType, info.ContentType);
            }
            if (info.ContentHash != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentHash, info.ContentHash);
            }

            long? size = default;
            ContentRange contentRange = !string.IsNullOrWhiteSpace(info?.Details?.ContentRange) ? ContentRange.Parse(info.Details.ContentRange) : default;
            if (contentRange != default)
            {
                size = contentRange.Size;
            }

            return new StorageResourceReadStreamResult(
                content: info?.Content,
                range: ContentRange.ToHttpRange(contentRange),
                properties: new StorageResourceItemProperties(
                    resourceLength: contentRange.Size,
                    eTag: info.Details.ETag,
                    lastModifiedTime: info.Details.LastModified,
                    properties: properties));
        }
    }
}
