﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileStorageResource : StorageResourceItemInternal
    {
        internal readonly ShareFileStorageResourceOptions _options;

        internal ShareFileClient ShareFileClient { get; }

        public override Uri Uri => ShareFileClient.Uri;

        public override string ProviderId => "share";

        protected override string ResourceId => "ShareFile";

        protected override TransferOrder TransferType => TransferOrder.Unordered;

        protected override long MaxSupportedSingleTransferSize => DataMovementShareConstants.MaxRange;

        protected override long MaxSupportedChunkSize => DataMovementShareConstants.MaxRange;

        protected override int MaxSupportedChunkCount => int.MaxValue;

        protected override long? Length => ResourceProperties?.ResourceLength;

        internal string _destinationPermissionKey;

        internal bool _isResourcePropertiesFullySet = false;

        public ShareFileStorageResource(
            ShareFileClient fileClient,
            ShareFileStorageResourceOptions options = default)
        {
            ShareFileClient = fileClient;
            _options = options ?? new ShareFileStorageResourceOptions();
        }

        /// <summary>
        /// Internal Constructor for constructing the resource retrieved by a GetStorageResources.
        /// </summary>
        /// <param name="fileClient">The blob client which will service the storage resource operations.</param>
        /// <param name="properties">Properties specific to the resource.</param>
        /// <param name="options">Options for the storage resource. See <see cref="ShareFileStorageResourceOptions"/>.</param>
        internal ShareFileStorageResource(
            ShareFileClient fileClient,
            StorageResourceItemProperties properties,
            ShareFileStorageResourceOptions options = default)
            : this(fileClient, options)
        {
            ResourceProperties = properties;
        }

        internal async Task CreateAsync(
            bool overwrite,
            long maxSize,
            StorageResourceItemProperties properties,
            CancellationToken cancellationToken)
        {
            if (!overwrite)
            {
                // If overwrite is not enabled, we should check if the
                // file exists first before creating because Create call will
                // automatically overwrite the file if it already exists.
                Response<bool> exists = await ShareFileClient.ExistsAsync(cancellationToken).ConfigureAwait(false);
                if (exists.Value)
                {
                    throw Errors.ShareFileAlreadyExists(ShareFileClient.Path);
                }
            }
            ShareFileHttpHeaders httpHeaders = _options?.GetShareFileHttpHeaders(properties?.RawProperties);
            IDictionary<string, string> metadata = _options?.GetFileMetadata(properties?.RawProperties);
            string filePermission = _options?.GetFilePermission(properties);
            FileSmbProperties smbProperties = _options?.GetFileSmbProperties(properties, _destinationPermissionKey);
            FilePosixProperties posixProperties = _options?.GetFilePosixProperties(properties);

            // if transfer is not empty and File Attribute contains ReadOnly, we should not set it before creating the file.
            if ((properties == null || properties.ResourceLength > 0) && IsReadOnlySet(smbProperties.FileAttributes))
            {
                smbProperties.FileAttributes = default;
            }

            ShareFileCreateOptions options = new ShareFileCreateOptions()
            {
                HttpHeaders = httpHeaders,
                Metadata = metadata,
                FilePermission = new() { Permission = filePermission },
                SmbProperties = smbProperties,
                PosixProperties = posixProperties
            };

            await ShareFileClient.CreateAsync(
                    maxSize: maxSize,
                    options: options,
                    conditions: _options?.DestinationConditions,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        private bool IsReadOnlySet(NtfsFileAttributes? fileAttributes)
        {
            return fileAttributes?.HasFlag(NtfsFileAttributes.ReadOnly) ?? false;
        }

        protected override async Task CompleteTransferAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            StorageResourceItemProperties sourceProperties = completeTransferOptions?.SourceProperties;
            FileSmbProperties smbProperties = _options?.GetFileSmbProperties(sourceProperties, _destinationPermissionKey);
            // Call Set Properties
            // if transfer is not empty and original File Attribute contains ReadOnly
            // or if FileChangedOn is to be preserved or manually set
            if (((sourceProperties == null || sourceProperties.ResourceLength > 0) && IsReadOnlySet(smbProperties.FileAttributes))
                    || (_options?._isFileChangedOnSet == false || _options?.FileChangedOn != null))
            {
                ShareFileHttpHeaders httpHeaders = _options?.GetShareFileHttpHeaders(sourceProperties?.RawProperties);
                await ShareFileClient.SetHttpHeadersAsync(new()
                {
                    HttpHeaders = httpHeaders,
                    SmbProperties = smbProperties,
                },
                cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        protected override async Task CopyBlockFromUriAsync(
            StorageResourceItem sourceResource,
            HttpRange range,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (range.Offset == 0)
            {
                await CreateAsync(
                    overwrite,
                    completeLength,
                    options?.SourceProperties,
                    cancellationToken).ConfigureAwait(false);
                if (range.Length == 0)
                {
                    return;
                }
            }

            await ShareFileClient.UploadRangeFromUriAsync(
                sourceUri: sourceResource.Uri,
                range: range,
                sourceRange: range,
                options: _options?.ToShareFileUploadRangeFromUriOptions(options?.SourceAuthentication),
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override async Task CopyFromStreamAsync(
            Stream stream,
            long streamLength,
            bool overwrite,
            long completeLength,
            StorageResourceWriteToOffsetOptions options = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            long position = options?.Position != default ? options.Position.Value : 0;

            // Create the File beforehand if it hasn't been created
            if (position == 0)
            {
                await CreateAsync(
                    overwrite,
                    completeLength,
                    options?.SourceProperties,
                    cancellationToken).ConfigureAwait(false);
                if (completeLength == 0)
                {
                    return;
                }
            }

            // Otherwise upload the Range
            await ShareFileClient.UploadRangeAsync(
                new HttpRange(position, streamLength),
                stream,
                _options?.ToShareFileUploadRangeOptions(),
                cancellationToken).ConfigureAwait(false);
        }

        protected override async Task CopyFromUriAsync(
            StorageResourceItem sourceResource,
            bool overwrite,
            long completeLength,
            StorageResourceCopyFromUriOptions options = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            await CreateAsync(
                overwrite,
                completeLength,
                options?.SourceProperties,
                cancellationToken).ConfigureAwait(false);
            if (completeLength > 0)
            {
                await ShareFileClient.UploadRangeFromUriAsync(
                    sourceUri: sourceResource.Uri,
                    range: new HttpRange(0, completeLength),
                    sourceRange: new HttpRange(0, completeLength),
                    options: _options?.ToShareFileUploadRangeFromUriOptions(options?.SourceAuthentication),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
            }
        }

        protected override async Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            return await ShareFileClient.DeleteIfExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override async Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            return await ShareFileClientInternals.GetCopyAuthorizationTokenAsync(ShareFileClient, cancellationToken).ConfigureAwait(false);
        }

        protected override async Task<StorageResourceItemProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            if (_isResourcePropertiesFullySet)
            {
                return ResourceProperties;
            }
            Response<ShareFileProperties> response = await ShareFileClient.GetPropertiesAsync(
                conditions: _options?.SourceConditions,
                cancellationToken: cancellationToken).ConfigureAwait(false);
            if (ResourceProperties != default)
            {
                ResourceProperties.AddToStorageResourceItemProperties(response.Value);
            }
            else
            {
                ResourceProperties = response.Value.ToStorageResourceItemProperties();
            }
            _isResourcePropertiesFullySet = true;
            return ResourceProperties;
        }

        protected override async Task<string> GetPermissionsAsync(
            StorageResourceItemProperties properties = default,
            CancellationToken cancellationToken = default)
        {
            string permissionKey = properties?.RawProperties?.GetSourcePermissionKey();
            if (!string.IsNullOrEmpty(permissionKey))
            {
                ShareClient parentShare = ShareFileClient.GetParentShareClient();
                return await parentShare.GetPermissionAsync(permissionKey, cancellationToken).ConfigureAwait(false);
            }
            return default;
        }

        protected override async Task SetPermissionsAsync(
            StorageResourceItem sourceResource,
            StorageResourceItemProperties sourceProperties,
            CancellationToken cancellationToken = default)
        {
            if (sourceResource is ShareFileStorageResource)
            {
                ShareFileStorageResource sourceShareFile = (ShareFileStorageResource)sourceResource;
                // both source and destination must be SMB and destination FilePermission option must be set.
                if (((sourceShareFile._options?.ShareProtocol ?? ShareProtocols.Smb) == ShareProtocols.Smb)
                    && ((_options?.ShareProtocol ?? ShareProtocols.Smb) == ShareProtocols.Smb)
                    && (_options?.FilePermissions ?? false))
                {
                    string permissionsValue = sourceProperties?.RawProperties?.GetPermission();
                    string destinationPermissionKey = sourceProperties?.RawProperties?.GetDestinationPermissionKey();
                    // Get / Set the permission key if preserve is set to true,
                    // there are no short form file permissions (x-ms-file-permission) in the source properties
                    // and already set destination permission key (x-ms-file-permission-key).
                    if (destinationPermissionKey == default && permissionsValue == default)
                    {
                        string sourcePermissions = await sourceShareFile.GetPermissionsAsync(sourceProperties, cancellationToken).ConfigureAwait(false);

                        if (!string.IsNullOrEmpty(sourcePermissions))
                        {
                            ShareClient parentShare = ShareFileClient.GetParentShareClient();
                            PermissionInfo permissionsInfo = await parentShare.CreatePermissionAsync(sourcePermissions, cancellationToken).ConfigureAwait(false);
                            _destinationPermissionKey = permissionsInfo.FilePermissionKey;
                        }
                    }
                    else
                    {
                        _destinationPermissionKey = destinationPermissionKey;
                    }
                }
            }
        }

        protected override async Task<StorageResourceReadStreamResult> ReadStreamAsync(
            long position = 0,
            long? length = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Response<ShareFileDownloadInfo> response = await ShareFileClient.DownloadAsync(
                _options?.ToShareFileDownloadOptions(new HttpRange(position, length)),
                cancellationToken).ConfigureAwait(false);
            return response.Value.ToStorageResourceReadStreamResult();
        }

        protected override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new ShareFileSourceCheckpointDetails();
        }

        protected override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return new ShareFileDestinationCheckpointDetails(
                isContentTypeSet: _options?._isContentTypeSet ?? false,
                contentType: _options?.ContentType,
                isContentEncodingSet: _options?._isContentEncodingSet ?? false,
                contentEncoding: _options?.ContentEncoding,
                isContentLanguageSet: _options?._isContentLanguageSet ?? false,
                contentLanguage: _options?.ContentLanguage,
                isContentDispositionSet: _options?._isContentDispositionSet ?? false,
                contentDisposition: _options?.ContentDisposition,
                isCacheControlSet: _options?._isCacheControlSet ?? false,
                cacheControl: _options?.CacheControl,
                isFileAttributesSet: _options?._isFileAttributesSet ?? false,
                fileAttributes: _options?.FileAttributes,
                filePermissions: _options?.FilePermissions,
                isFileCreatedOnSet: _options?._isFileCreatedOnSet ?? false,
                fileCreatedOn: _options?.FileCreatedOn,
                isFileLastWrittenOnSet: _options?._isFileLastWrittenOnSet ?? false,
                fileLastWrittenOn: _options?.FileLastWrittenOn,
                isFileChangedOnSet: _options?._isFileChangedOnSet ?? false,
                fileChangedOn: _options?.FileChangedOn,
                isFileMetadataSet: _options?._isFileMetadataSet ?? false,
                fileMetadata: _options?.FileMetadata,
                isDirectoryMetadataSet: _options?._isDirectoryMetadataSet ?? false,
                directoryMetadata: _options?.DirectoryMetadata);
        }

        protected override async Task<bool> ShouldItemTransferAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            StorageResourceItemProperties sourceProperties = await GetPropertiesAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            NfsFileType FileType = sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.FileType, out object fileType) == true
                    ? (NfsFileType)fileType
                    : default;
            if (FileType == NfsFileType.SymLink)
            {
                DataMovementFileShareEventSource.Singleton.SymLinkDetected(Uri.AbsoluteUri);
                return false;
            }
            else if (FileType == NfsFileType.Regular)
            {
                long LinkCount = sourceProperties?.RawProperties?.TryGetValue(DataMovementConstants.ResourceProperties.LinkCount, out object linkCount) == true
                        ? (long)linkCount
                        : default;
                // Hardlink detected
                if (LinkCount > 1)
                {
                    DataMovementFileShareEventSource.Singleton.HardLinkDetected(Uri.AbsoluteUri);
                }
            }
            return true;
        }

        protected override async Task ValidateTransferAsync(
            string transferId,
            StorageResource sourceResource,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // ShareFile to ShareFile Copy transfer
            if (sourceResource is ShareFileStorageResource sourceShareFileResource)
            {
                // Ensure the transfer is supported (NFS -> NFS and SMB -> SMB)
                if ((_options?.ShareProtocol ?? ShareProtocols.Smb)
                    != (sourceShareFileResource._options?.ShareProtocol ?? ShareProtocols.Smb))
                {
                    throw Errors.ShareTransferNotSupported();
                }

                // Validate the source protocol
                await DataMovementSharesExtensions.ValidateProtocolAsync(
                    sourceShareFileResource.ShareFileClient.GetParentShareClient(),
                    sourceShareFileResource._options,
                    transferId,
                    "source",
                    sourceResource.Uri.AbsoluteUri,
                    cancellationToken).ConfigureAwait(false);

                // Validate the destination protocol
                await DataMovementSharesExtensions.ValidateProtocolAsync(
                    ShareFileClient.GetParentShareClient(),
                    _options,
                    transferId,
                    "destination",
                    Uri.AbsoluteUri,
                    cancellationToken).ConfigureAwait(false);
            }
        }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal partial class Errors
#pragma warning restore SA1402 // File may only contain a single type
    {
        public static InvalidOperationException ShareFileAlreadyExists(string pathName)
            => new InvalidOperationException($"Share File `{pathName}` already exists. Cannot overwrite file.");

        public static ArgumentException ProtocolSetMismatch(string endpoint, ShareProtocols setProtocol, ShareProtocols actualProtocol)
            => new ArgumentException($"The Protocol set on the {endpoint} '{setProtocol}' does not match the actual Protocol of the share '{actualProtocol}'.");

        public static UnauthorizedAccessException ProtocolValidationAuthorizationFailure(RequestFailedException ex, string endpoint)
            => new UnauthorizedAccessException($"Authorization failure on the {endpoint} when validating the Protocol. " +
                $"To skip this validation, please enable SkipProtocolValidation.", ex);

        public static NotSupportedException ShareTransferNotSupported()
            => new NotSupportedException("This Share transfer is not supported. " +
                "Currently only NFS -> NFS and SMB -> SMB Share transfers are supported");
    }
}
