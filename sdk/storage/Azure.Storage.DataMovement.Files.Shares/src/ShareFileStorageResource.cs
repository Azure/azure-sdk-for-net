// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileStorageResource : StorageResourceItemInternal
    {
        internal long? _length;
        internal readonly ShareFileStorageResourceOptions _options;
        internal ETag? _etagDownloadLock = default;

        internal ShareFileClient ShareFileClient { get; }

        public override Uri Uri => ShareFileClient.Uri;

        protected override string ResourceId => "ShareFile";

        protected override DataTransferOrder TransferType => DataTransferOrder.Sequential;

        protected override long MaxChunkSize => DataMovementShareConstants.MaxRange;

        protected override long? Length => _length;

        public ShareFileStorageResource(
            ShareFileClient fileClient,
            ShareFileStorageResourceOptions options = default)
        {
            ShareFileClient = fileClient;
            _options = options;
        }

        /// <summary>
        /// Internal Constructor for constructing the resource retrieved by a GetStorageResources.
        /// </summary>
        /// <param name="fileClient">The blob client which will service the storage resource operations.</param>
        /// <param name="length">The content length of the blob.</param>
        /// <param name="etagLock">Preset etag to lock on for reads.</param>
        /// <param name="options">Options for the storage resource. See <see cref="ShareFileStorageResourceOptions"/>.</param>
        internal ShareFileStorageResource(
            ShareFileClient fileClient,
            long? length,
            ETag? etagLock,
            ShareFileStorageResourceOptions options = default)
            : this(fileClient, options)
        {
            _length = length;
            _etagDownloadLock = etagLock;
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
            await ShareFileClient.UploadRangeFromUriAsync(
                sourceUri: sourceResource.Uri,
                range: range,
                sourceRange: range,
                options: _options.ToShareFileUploadRangeFromUriOptions(),
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
            if ((streamLength == completeLength) && position == 0)
            {
                // Default to Upload
                await ShareFileClient.UploadAsync(
                    stream,
                    _options.ToShareFileUploadOptions(),
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                return;
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
            await ShareFileClient.UploadRangeFromUriAsync(
                sourceUri: sourceResource.Uri,
                range: new HttpRange(0, completeLength),
                sourceRange: new HttpRange(0, completeLength),
                options: _options.ToShareFileUploadRangeFromUriOptions(),
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override async Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            return await ShareFileClient.DeleteIfExistsAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        protected override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // TODO: This needs an update to ShareFileClient to allow getting the Copy Authorization Token
            throw new NotImplementedException();
        }

        protected override async Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            Response<ShareFileProperties> response = await ShareFileClient.GetPropertiesAsync(
                conditions: _options?.SourceConditions,
                cancellationToken: cancellationToken).ConfigureAwait(false);
            // TODO: should we be grabbing the ETag here even though we can't apply it to the download.
            //GrabEtag(response.GetRawResponse());
            return response.Value.ToStorageResourceProperties();
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
            throw new NotImplementedException();
        }

        protected override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            throw new NotImplementedException();
        }
    }
}
