// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Files.Shares.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal static partial class DataMovementSharesExtensions
    {
        public static ShareFileHttpHeaders GetShareFileHttpHeaders(
            this ShareFileStorageResourceOptions options,
            Dictionary<string, object> properties)
            => new()
            {
                ContentType = (options?.ContentType?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentType, out object contentType) == true
                        ? (string)contentType
                        : default
                    : options?.ContentType?.Value,
                ContentEncoding = (options?.ContentEncoding?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentEncoding, out object contentEncoding) == true
                        ? (string[])contentEncoding
                        : default
                    : options?.ContentEncoding?.Value,
                ContentLanguage = (options?.ContentLanguage?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentLanguage, out object contentLanguage) == true
                        ? (string[])contentLanguage
                        : default
                    : options?.ContentLanguage?.Value,
                ContentDisposition = (options?.ContentDisposition?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentDisposition, out object contentDisposition) == true
                        ? (string)contentDisposition
                        : default
                    : options?.ContentDisposition?.Value,
                CacheControl = (options?.CacheControl?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.CacheControl, out object cacheControl) == true
                        ? (string)cacheControl
                        : default
                    : options?.CacheControl?.Value,
            };

        public static Metadata GetFileMetadata(
            this ShareFileStorageResourceOptions options,
            Dictionary<string, object> properties)
            => (options?.FileMetadata?.Preserve ?? true)
                    ? properties?.TryGetValue(DataMovementConstants.ResourceProperties.Metadata, out object metadata) == true
                        ? (Metadata) metadata
                        : default
                    : options?.FileMetadata?.Value;

        public static FileSmbProperties GetFileSmbProperties(
            this ShareFileStorageResourceOptions options,
            StorageResourceItemProperties properties)
            => new()
            {
                FileAttributes = (options?.FileAttributes?.Preserve ?? true)
                    ? properties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.FileAttributes, out object fileAttributes) == true
                        ? (NtfsFileAttributes?) fileAttributes
                        : default
                    : options?.FileAttributes?.Value,
                FilePermissionKey = options?.FilePermissionKey,
                FileCreatedOn = (options?.FileCreatedOn?.Preserve ?? true)
                    ? properties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.CreationTime, out object fileCreatedOn) == true
                        ? (DateTimeOffset?) fileCreatedOn
                        : default
                    : options?.FileCreatedOn?.Value,
                FileLastWrittenOn = (options?.FileLastWrittenOn?.Preserve ?? true)
                    ? properties?.LastModifiedTime
                    : options?.FileLastWrittenOn?.Value,
                FileChangedOn = (options?.FileChangedOn?.Preserve ?? true)
                    ? properties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.ChangedOnTime, out object fileChangedOn) == true
                        ? (DateTimeOffset?) fileChangedOn
                        : default
                    : options?.FileChangedOn?.Value,
            };

        internal static ShareFileUploadOptions ToShareFileUploadOptions(
            this ShareFileStorageResourceOptions options)
            => new()
            {
                Conditions = options?.DestinationConditions,
            };

        internal static ShareFileUploadRangeOptions ToShareFileUploadRangeOptions(
            this ShareFileStorageResourceOptions options)
            => new()
            {
                Conditions = options?.DestinationConditions,
                FileLastWrittenMode = (options?.FileLastWrittenOn?.Value != default) || (options?.FileLastWrittenOn?.Preserve ?? false)
                    ? FileLastWrittenMode.Preserve
                    : default
            };

        internal static ShareFileUploadRangeFromUriOptions ToShareFileUploadRangeFromUriOptions(
            this ShareFileStorageResourceOptions options,
            HttpAuthorization sourceAuthorization)
            => new()
            {
                Conditions = options?.DestinationConditions,
                FileLastWrittenMode = (options?.FileLastWrittenOn?.Value != default) || (options?.FileLastWrittenOn?.Preserve ?? true)
                    ? FileLastWrittenMode.Preserve
                    : default,
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
            if (fileProperties.SmbProperties.FileChangedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ChangedOnTime, fileProperties.SmbProperties.FileChangedOn);
            }
            if (fileProperties.SmbProperties.FileAttributes != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.FileAttributes, fileProperties.SmbProperties.FileAttributes);
            }
            if (fileProperties.SmbProperties.FilePermissionKey != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.FilePermissionKey, fileProperties.SmbProperties.FilePermissionKey);
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
            if (info.Details.SmbProperties.FileChangedOn != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ChangedOnTime, info.Details.SmbProperties.FileChangedOn);
            }
            if (info.ContentType != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentType, info.ContentType);
            }
            if (info.ContentHash != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.ContentHash, info.ContentHash);
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

#pragma warning disable SA1402 // File may only contain a single type
    internal partial class Errors
#pragma warning restore SA1402 // File may only contain a single type
    {
        public static ArgumentException InvalidNtfsFileAttributesString(string attributesString)
            => new ArgumentException($"Invalid NtfsFileAttributes string: {attributesString}.");
    }
}
