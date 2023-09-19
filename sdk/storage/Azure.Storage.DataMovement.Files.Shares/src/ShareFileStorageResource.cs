// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileStorageResource : StorageResourceItem
    {
        internal long? _length;
        internal readonly ShareFileStorageResourceOptions _options;
        internal ETag? _etagDownloadLock = default;

        internal ShareFileClient ShareFileClient { get; }

        public override Uri Uri => ShareFileClient.Uri;

        protected override string ResourceId => "ShareFile";

        protected override DataTransferOrder TransferType => DataTransferOrder.Sequential;

        protected override long MaxChunkSize => DataMovementConstants.Share.MaxRange;

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

        protected override Task CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Task CopyBlockFromUriAsync(StorageResourceItem sourceResource, HttpRange range, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Task CopyFromStreamAsync(Stream stream, long streamLength, bool overwrite, long completeLength, StorageResourceWriteToOffsetOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Task CopyFromUriAsync(StorageResourceItem sourceResource, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        protected override Task<StorageResourceReadStreamResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
