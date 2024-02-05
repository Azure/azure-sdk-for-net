// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileStorageResource : StorageResourceItemInternal
    {
        internal readonly ShareFileStorageResourceOptions _options;

        internal ShareFileClient ShareFileClient { get; }

        public override Uri Uri => ShareFileClient.Uri;

        public override string ProviderId => "share";

        protected override string ResourceId => "ShareFile";

        protected override DataTransferOrder TransferType => DataTransferOrder.Sequential;

        protected override long MaxSupportedChunkSize => DataMovementShareConstants.MaxRange;

        protected override long? Length => ResourceProperties?.ResourceLength;

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
            await ShareFileClient.CreateAsync(
                    maxSize: maxSize,
                    httpHeaders: _options.HttpHeaders,
                    metadata: _options.FileMetadata,
                    smbProperties: _options.SmbProperties,
                    filePermission: _options.FilePermissions,
                    conditions: _options.DestinationConditions,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override Task CompleteTransferAsync(
            bool overwrite,
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
                await CreateAsync(overwrite, completeLength, cancellationToken).ConfigureAwait(false);
                if (range.Length == 0)
                {
                    return;
                }
            }

            await ShareFileClient.UploadRangeFromUriAsync(
                sourceUri: sourceResource.Uri,
                range: range,
                sourceRange: range,
                options: _options.ToShareFileUploadRangeFromUriOptions(options?.SourceAuthentication),
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
                await CreateAsync(overwrite, completeLength, cancellationToken).ConfigureAwait(false);
                if (completeLength == 0)
                {
                    return;
                }
            }

            // Otherwise upload the Range
            await ShareFileClient.UploadRangeAsync(
                new HttpRange(position, streamLength),
                stream,
                _options.ToShareFileUploadRangeOptions(),
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
            await CreateAsync(overwrite, completeLength, cancellationToken).ConfigureAwait(false);
            if (completeLength > 0)
            {
                await ShareFileClient.UploadRangeFromUriAsync(
                    sourceUri: sourceResource.Uri,
                    range: new HttpRange(0, completeLength),
                    sourceRange: new HttpRange(0, completeLength),
                    options: _options.ToShareFileUploadRangeFromUriOptions(options?.SourceAuthentication),
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
                conditions: _options.SourceConditions,
                cancellationToken: cancellationToken).ConfigureAwait(false);
            if (ResourceProperties == default)
            {
                ResourceProperties = response.Value.ToStorageResourceItemProperties();
            }
            return ResourceProperties;
        }

        protected override async Task<StorageResourceReadStreamResult> ReadStreamAsync(
            long position = 0,
            long? length = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Response<ShareFileDownloadInfo> response = await ShareFileClient.DownloadAsync(
                _options.ToShareFileDownloadOptions(new HttpRange(position, length)),
                cancellationToken).ConfigureAwait(false);
            return response.Value.ToStorageResourceReadStreamResult();
        }

        protected override StorageResourceCheckpointData GetSourceCheckpointData()
        {
            return new ShareFileSourceCheckpointData();
        }

        protected override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            return new ShareFileDestinationCheckpointData(null, null, null, null);
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
