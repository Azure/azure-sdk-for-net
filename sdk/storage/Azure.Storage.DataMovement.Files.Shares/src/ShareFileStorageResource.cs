// Copyright (c) Microsoft Corporation. All rights reserved.
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

        protected override long? Length => ResourceProperties?.ResourceLength;

        internal string _destinationPermissionKey;

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
            string filePermission = _options?.GetFilePermission(properties?.RawProperties);
            FileSmbProperties smbProperties = _options?.GetFileSmbProperties(properties, _destinationPermissionKey);
            await ShareFileClient.CreateAsync(
                    maxSize: maxSize,
                    httpHeaders: httpHeaders,
                    metadata: metadata,
                    smbProperties: smbProperties,
                    filePermission: filePermission,
                    conditions: _options?.DestinationConditions,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override Task CompleteTransferAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            return Task.CompletedTask;
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
                if (_options?.FilePermissions ?? false)
                {
                    ShareFileStorageResource sourceShareFile = (ShareFileStorageResource)sourceResource;
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
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal partial class Errors
#pragma warning restore SA1402 // File may only contain a single type
    {
        public static InvalidOperationException ShareFileAlreadyExists(string pathName)
            => new InvalidOperationException($"Share File `{pathName}` already exists. Cannot overwrite file.");
    }
}
