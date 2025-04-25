﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Storage.Files.Shares.Models;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal static partial class DataMovementSharesExtensions
    {
        public static ShareFileHttpHeaders GetShareFileHttpHeaders(
            this ShareFileStorageResourceOptions options,
            IDictionary<string, object> properties)
            => new()
            {
                ContentType = (options?._isContentTypeSet ?? false)
                    ? options?.ContentType
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentType, out object contentType) == true
                        ? (string)contentType
                        : default,
                ContentEncoding = (options?._isContentEncodingSet ?? true)
                    ? options?.ContentEncoding
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentEncoding, out object contentEncoding) == true
                        ? ConvertContentPropertyObjectToStringArray(DataMovementConstants.ResourceProperties.ContentEncoding, contentEncoding)
                        : default,
                ContentLanguage = (options?._isContentLanguageSet ?? false)
                    ? options?.ContentLanguage
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.ContentLanguage, out object contentLanguage) == true
                        ? ConvertContentPropertyObjectToStringArray(DataMovementConstants.ResourceProperties.ContentLanguage, contentLanguage)
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
                        : default,
            };

        public static Metadata GetFileMetadata(
            this ShareFileStorageResourceOptions options,
            IDictionary<string, object> properties)
            => (options?._isFileMetadataSet ?? false)
                    ? options?.FileMetadata
                    : properties?.TryGetValue(DataMovementConstants.ResourceProperties.Metadata, out object metadata) == true
                        ? (Metadata)metadata
                        : default;

        public static string GetFilePermission(
            this ShareFileStorageResourceOptions options,
            StorageResourceItemProperties sourceProperties)
        {
            // Only set permissions if Copy transfer and FilePermissions is on.
            bool setPermissions = (!sourceProperties?.Uri?.IsFile ?? false) && (options?.FilePermissions ?? false);

            if ((!options?.IsNfs ?? true) && setPermissions)
            {
                return sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.FilePermissions, out object permission) == true
                    ? (string)permission
                    : default;
            }
            return default;
        }

        public static string GetFilePermission(
            this ShareFileStorageResourceOptions options,
            StorageResourceContainerProperties sourceProperties)
        {
            // Only set permissions if Copy transfer and FilePermissions is on.
            bool setPermissions = (!sourceProperties?.Uri?.IsFile ?? false) && (options?.FilePermissions ?? false);

            if ((!options?.IsNfs ?? true) && setPermissions)
            {
                return sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.FilePermissions, out object permission) == true
                        ? (string)permission
                        : default;
            }
            return default;
        }

        public static string GetSourcePermissionKey(
            this IDictionary<string, object> properties)
            => properties?.TryGetValue(DataMovementConstants.ResourceProperties.SourceFilePermissionKey, out object permissionKey) == true
                ? (string)permissionKey
                : default;

        public static string GetDestinationPermissionKey(
            this IDictionary<string, object> properties)
            => properties?.TryGetValue(DataMovementConstants.ResourceProperties.DestinationFilePermissionKey, out object permissionKey) == true
                ? (string)permissionKey
                : default;

        public static string GetPermission(
            this IDictionary<string, object> properties)
            => properties?.TryGetValue(DataMovementConstants.ResourceProperties.FilePermissions, out object permission) == true
                ? (string) permission
                : default;

        public static FileSmbProperties GetFileSmbProperties(
            this ShareFileStorageResourceOptions options,
            StorageResourceItemProperties properties,
            string destinationPermissionKey)
        {
            string permissionKeyValue = destinationPermissionKey;
            if (string.IsNullOrEmpty(permissionKeyValue))
            {
                // Only set permissions if Copy transfer and FilePermissions is on.
                bool setPermissions = (!properties?.Uri?.IsFile ?? false) && (options?.FilePermissions ?? false);

                permissionKeyValue = setPermissions
                    ? properties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.DestinationFilePermissionKey, out object permissionKeyObject) == true
                        ? (string) permissionKeyObject
                        : default
                    : default;
            }
            return new()
            {
                FileAttributes = (options?.IsNfs ?? false)
                    ? default
                    : GetPropertyValue<NtfsFileAttributes>(
                        options?._isFileAttributesSet ?? false,
                        options?.FileAttributes,
                        properties?.RawProperties,
                        DataMovementConstants.ResourceProperties.FileAttributes),
                FilePermissionKey = (options?.IsNfs ?? false)
                    ? default
                    : permissionKeyValue,
                FileCreatedOn = GetPropertyValue<DateTimeOffset>(
                    options?._isFileCreatedOnSet ?? false,
                    options?.FileCreatedOn,
                    properties?.RawProperties,
                    DataMovementConstants.ResourceProperties.CreationTime),
                FileLastWrittenOn = GetPropertyValue<DateTimeOffset>(
                    options?._isFileLastWrittenOnSet ?? false,
                    options?.FileLastWrittenOn,
                    properties?.RawProperties,
                    DataMovementConstants.ResourceProperties.LastWrittenOn),
                FileChangedOn = (options?.IsNfs ?? false)
                    ? default
                    : GetPropertyValue<DateTimeOffset>(
                        options?._isFileChangedOnSet ?? false,
                        options?.FileChangedOn,
                        properties?.RawProperties,
                        DataMovementConstants.ResourceProperties.ChangedOnTime)
            };
        }

        public static FileSmbProperties GetFileSmbProperties(
            this ShareFileStorageResourceOptions options,
            StorageResourceContainerProperties properties)
        {
            // Only set permissions if Copy transfer and FilePermissions is on.
            bool setPermissions = (!properties?.Uri?.IsFile ?? false) && (options?.FilePermissions ?? false);

            string permissionKeyValue = setPermissions
                ? properties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.DestinationFilePermissionKey, out object permissionKeyObject) == true
                    ? (string)permissionKeyObject
                    : default
                : default;
            return new()
            {
                FileAttributes = (options?.IsNfs ?? false)
                    ? default
                    : GetPropertyValue<NtfsFileAttributes>(
                        options?._isFileAttributesSet ?? false,
                        options?.FileAttributes,
                        properties?.RawProperties,
                        DataMovementConstants.ResourceProperties.FileAttributes),
                FilePermissionKey = (options?.IsNfs ?? false)
                    ? default
                    : permissionKeyValue,
                FileCreatedOn = GetPropertyValue<DateTimeOffset>(
                    options?._isFileCreatedOnSet ?? false,
                    options?.FileCreatedOn,
                    properties?.RawProperties,
                    DataMovementConstants.ResourceProperties.CreationTime),
                FileLastWrittenOn = GetPropertyValue<DateTimeOffset>(
                    options?._isFileLastWrittenOnSet ?? false,
                    options?.FileLastWrittenOn,
                    properties?.RawProperties,
                    DataMovementConstants.ResourceProperties.LastWrittenOn),
                FileChangedOn = (options?.IsNfs ?? false)
                    ? default
                    : GetPropertyValue<DateTimeOffset>(
                        options?._isFileChangedOnSet ?? false,
                        options?.FileChangedOn,
                        properties?.RawProperties,
                        DataMovementConstants.ResourceProperties.ChangedOnTime)
            };
        }

        private static T? GetPropertyValue<T>(
            bool isOptionSet,
            T? optionValue,
            IDictionary<string, object> rawProperties,
            string propertyKey) where T : struct
        {
            if (isOptionSet)
            {
                return optionValue;
            }

            return rawProperties?.TryGetValue(propertyKey, out object value) == true
                   ? (T?) value
                   : default;
        }

        public static FilePosixProperties GetFilePosixProperties(
            this ShareFileStorageResourceOptions options,
            StorageResourceItemProperties sourceProperties)
        {
            // Only set NFS permissions if Copy transfer and FilePermissions is on.
            bool setPermissions = (!sourceProperties?.Uri?.IsFile ?? false) && (options?.FilePermissions ?? false);

            if (options?.IsNfs ?? false)
            {
                NfsFileMode FileMode = default;
                string Owner = default;
                string Group = default;
                NfsFileType FileType = NfsFileType.Regular;

                if (setPermissions)
                {
                    FileMode = sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.FileMode, out object fileMode) == true
                            ? (NfsFileMode)fileMode
                            : default;
                    Owner = sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.Owner, out object owner) == true
                            ? (string)owner
                            : default;
                    Group = sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.Group, out object group) == true
                            ? (string)group
                            : default;
                }

                return FilesModelFactory.FilePosixProperties(
                    fileMode: FileMode,
                    owner: Owner,
                    group: Group,
                    fileType: FileType,
                    linkCount: default);
            }
            return new();
        }

        public static FilePosixProperties GetFilePosixProperties(
            this ShareFileStorageResourceOptions options,
            StorageResourceContainerProperties sourceProperties)
        {
            NfsFileMode FileMode = default;
            string Owner = default;
            string Group = default;

            // Only set NFS permissions if Copy transfer and FilePermissions is on.
            bool setPermissions = (!sourceProperties?.Uri?.IsFile ?? false) && (options?.FilePermissions ?? false);

            if ((options?.IsNfs ?? false) && setPermissions)
            {
                FileMode = sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.FileMode, out object fileMode) == true
                        ? (NfsFileMode)fileMode
                        : default;
                Owner = sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.Owner, out object owner) == true
                        ? (string)owner
                        : default;
                Group = sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.Group, out object group) == true
                        ? (string)group
                        : default;
            }
            return FilesModelFactory.FilePosixProperties(
                fileMode: FileMode,
                owner: Owner,
                group: Group,
                fileType: default,
                linkCount: default);
        }

        internal static ShareFileUploadRangeOptions ToShareFileUploadRangeOptions(
            this ShareFileStorageResourceOptions options)
            => new()
            {
                Conditions = options?.DestinationConditions,
                FileLastWrittenMode = options?._isFileLastWrittenOnSet == false || options?.FileLastWrittenOn != default
                    ? FileLastWrittenMode.Preserve
                    : default
            };

        internal static ShareFileUploadRangeFromUriOptions ToShareFileUploadRangeFromUriOptions(
            this ShareFileStorageResourceOptions options,
            HttpAuthorization sourceAuthorization)
            => new()
            {
                Conditions = options?.DestinationConditions,
                FileLastWrittenMode = options == default || options?._isFileLastWrittenOnSet == false || options?.FileLastWrittenOn != default
                    ? FileLastWrittenMode.Preserve
                    : default,
                SourceAuthentication = sourceAuthorization
            };

        private static void WriteKeyValue(
            this IDictionary<string, object> properties,
            string key,
            object value)
        {
            if (value != default &&
                properties.ContainsKey(key))
            {
                properties[key] = value;
            }
            else
            {
                properties.Add(key, value);
            }
        }

        internal static StorageResourceItemProperties ToStorageResourceItemProperties(
            this ShareFileProperties fileProperties)
        {
            Dictionary<string, object> rawProperties = new();
            if (fileProperties.Metadata != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Metadata, fileProperties.Metadata);
            }
            if (fileProperties.SmbProperties.FileCreatedOn != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.CreationTime, fileProperties.SmbProperties.FileCreatedOn);
            }
            if (fileProperties.SmbProperties.FileLastWrittenOn != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.LastWrittenOn, fileProperties.SmbProperties.FileLastWrittenOn);
            }
            if (fileProperties.SmbProperties.FileChangedOn != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ChangedOnTime, fileProperties.SmbProperties.FileChangedOn);
            }
            if (fileProperties.SmbProperties.FileAttributes != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.FileAttributes, fileProperties.SmbProperties.FileAttributes);
            }
            if (fileProperties.SmbProperties.FilePermissionKey != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.SourceFilePermissionKey, fileProperties.SmbProperties.FilePermissionKey);
            }
            if (fileProperties.ContentType != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentType, fileProperties.ContentType);
            }
            if (fileProperties.ContentHash != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentHash, fileProperties.ContentHash);
            }
            if (fileProperties.ContentEncoding != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentEncoding, fileProperties.ContentEncoding);
            }
            if (fileProperties.ContentLanguage != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentLanguage, fileProperties.ContentLanguage);
            }
            if (fileProperties.ContentDisposition != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentDisposition, fileProperties.ContentDisposition);
            }
            if (fileProperties.CacheControl != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.CacheControl, fileProperties.CacheControl);
            }
            if (fileProperties.PosixProperties.Owner != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Owner, fileProperties.PosixProperties.Owner);
            }
            if (fileProperties.PosixProperties.Group != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Group, fileProperties.PosixProperties.Group);
            }
            if (fileProperties.PosixProperties.FileMode != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.FileMode, fileProperties.PosixProperties.FileMode);
            }
            return new StorageResourceItemProperties()
            {
                ResourceLength = fileProperties.ContentLength,
                ETag = fileProperties.ETag,
                LastModifiedTime = fileProperties.LastModified,
                RawProperties = rawProperties
            };
        }

        internal static void AddToStorageResourceItemProperties(
            this StorageResourceItemProperties existingProperties,
            ShareFileProperties fileProperties)
        {
            if (fileProperties.Metadata != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Metadata, fileProperties.Metadata);
            }
            if (fileProperties.SmbProperties.FileCreatedOn != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.CreationTime, fileProperties.SmbProperties.FileCreatedOn);
            }
            if (fileProperties.SmbProperties.FileChangedOn != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ChangedOnTime, fileProperties.SmbProperties.FileChangedOn);
            }
            if (fileProperties.SmbProperties.FileLastWrittenOn != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.LastWrittenOn, fileProperties.SmbProperties.FileLastWrittenOn);
            }
            if (fileProperties.SmbProperties.FileAttributes != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.FileAttributes, fileProperties.SmbProperties.FileAttributes);
            }
            if (fileProperties.SmbProperties.FilePermissionKey != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.SourceFilePermissionKey, fileProperties.SmbProperties.FilePermissionKey);
            }
            if (fileProperties.ContentType != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentType, fileProperties.ContentType);
            }
            if (fileProperties.ContentHash != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentHash, fileProperties.ContentHash);
            }
            if (fileProperties.ContentEncoding != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentEncoding, fileProperties.ContentEncoding);
            }
            if (fileProperties.ContentLanguage != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentLanguage, fileProperties.ContentLanguage);
            }
            if (fileProperties.ContentDisposition != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ContentDisposition, fileProperties.ContentDisposition);
            }
            if (fileProperties.CacheControl != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.CacheControl, fileProperties.CacheControl);
            }
            if (existingProperties.LastModifiedTime == default)
            {
                existingProperties.LastModifiedTime = fileProperties.LastModified;
            }
            if (existingProperties.ETag == default)
            {
                existingProperties.ETag = fileProperties.ETag;
            }
            if (existingProperties.ResourceLength == default)
            {
                existingProperties.ResourceLength = fileProperties.ContentLength;
            }
            if (fileProperties.PosixProperties.Owner != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Owner, fileProperties.PosixProperties.Owner);
            }
            if (fileProperties.PosixProperties.Group != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Group, fileProperties.PosixProperties.Group);
            }
            if (fileProperties.PosixProperties.FileMode != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.FileMode, fileProperties.PosixProperties.FileMode);
            }
        }

        internal static StorageResourceContainerProperties ToStorageResourceContainerProperties(
            this ShareDirectoryProperties directoryProperties)
        {
            Dictionary<string, object> rawProperties = new();
            if (directoryProperties.Metadata != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Metadata, directoryProperties.Metadata);
            }
            if (directoryProperties.SmbProperties.FileCreatedOn != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.CreationTime, directoryProperties.SmbProperties.FileCreatedOn);
            }
            if (directoryProperties.SmbProperties.FileLastWrittenOn != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.LastWrittenOn, directoryProperties.SmbProperties.FileLastWrittenOn);
            }
            if (directoryProperties.SmbProperties.FileChangedOn != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ChangedOnTime, directoryProperties.SmbProperties.FileChangedOn);
            }
            if (directoryProperties.SmbProperties.FileAttributes != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.FileAttributes, directoryProperties.SmbProperties.FileAttributes);
            }
            if (directoryProperties.SmbProperties.FilePermissionKey != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.SourceFilePermissionKey, directoryProperties.SmbProperties.FilePermissionKey);
            }
            if (directoryProperties.PosixProperties.Owner != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Owner, directoryProperties.PosixProperties.Owner);
            }
            if (directoryProperties.PosixProperties.Group != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Group, directoryProperties.PosixProperties.Group);
            }
            if (directoryProperties.PosixProperties.FileMode != default)
            {
                rawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.FileMode, directoryProperties.PosixProperties.FileMode);
            }
            return new StorageResourceContainerProperties()
            {
                RawProperties = rawProperties
            };
        }

        internal static void AddToStorageResourceContainerProperties(
            this StorageResourceContainerProperties existingProperties,
            ShareDirectoryProperties directoryProperties)
        {
            if (directoryProperties.Metadata != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Metadata, directoryProperties.Metadata);
            }
            if (directoryProperties.SmbProperties.FileCreatedOn != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.CreationTime, directoryProperties.SmbProperties.FileCreatedOn);
            }
            if (directoryProperties.SmbProperties.FileChangedOn != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.ChangedOnTime, directoryProperties.SmbProperties.FileChangedOn);
            }
            if (directoryProperties.SmbProperties.FileLastWrittenOn != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.LastWrittenOn, directoryProperties.SmbProperties.FileLastWrittenOn);
            }
            if (directoryProperties.SmbProperties.FileAttributes != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.FileAttributes, directoryProperties.SmbProperties.FileAttributes);
            }
            if (directoryProperties.SmbProperties.FilePermissionKey != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.SourceFilePermissionKey, directoryProperties.SmbProperties.FilePermissionKey);
            }
            if (directoryProperties.PosixProperties.Owner != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Owner, directoryProperties.PosixProperties.Owner);
            }
            if (directoryProperties.PosixProperties.Group != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.Group, directoryProperties.PosixProperties.Group);
            }
            if (directoryProperties.PosixProperties.FileMode != default)
            {
                existingProperties.RawProperties.WriteKeyValue(DataMovementConstants.ResourceProperties.FileMode, directoryProperties.PosixProperties.FileMode);
            }
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
                new StorageResourceItemProperties()
                {
                    ResourceLength = contentRange.Size,
                    ETag = info.Details.ETag,
                    LastModifiedTime = info.Details.LastModified,
                    RawProperties = properties
                });
        }

        internal static StorageResourceItemProperties ToResourceProperties(
            this ShareFileItem shareItem,
            string destinationPermissionKey)
        {
            Dictionary<string, object> properties = new();
            if (shareItem?.PermissionKey != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.SourceFilePermissionKey, shareItem.PermissionKey);
            }
            if (destinationPermissionKey != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.DestinationFilePermissionKey, destinationPermissionKey);
            }
            return new StorageResourceItemProperties()
            {
                ResourceLength = shareItem?.FileSize,
                ETag = shareItem?.Properties?.ETag,
                LastModifiedTime = shareItem?.Properties?.LastModified,
                RawProperties = properties
            };
        }

        internal static StorageResourceContainerProperties ToResourceContainerProperties(
            this ShareFileItem shareItem,
            string destinationPermissionKey)
        {
            Dictionary<string, object> properties = new();
            if (shareItem?.PermissionKey != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.SourceFilePermissionKey, shareItem.PermissionKey);
            }
            if (destinationPermissionKey != default)
            {
                properties.Add(DataMovementConstants.ResourceProperties.DestinationFilePermissionKey, destinationPermissionKey);
            }
            return new StorageResourceContainerProperties()
            {
                RawProperties = properties
            };
        }

        private static string[] ConvertContentPropertyObjectToStringArray(string contentPropertyName, object contentPropertyValue)
        {
            if (contentPropertyValue is string)
            {
                return new string[] { contentPropertyValue as string, };
            }
            else if (contentPropertyValue is string[])
            {
                return contentPropertyValue as string[];
            }
            else
            {
                throw Storage.Errors.UnexpectedPropertyType(contentPropertyName, DataMovementConstants.StringTypeStr, DataMovementConstants.StringArrayTypeStr);
            }
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
