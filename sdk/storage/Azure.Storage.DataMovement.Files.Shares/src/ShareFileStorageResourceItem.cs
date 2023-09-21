// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class ShareFileStorageResourceItem : StorageResourceItem
    {
        internal readonly ShareFileStorageResourceOptions _options;

        internal ShareFileClient ShareFileClient { get; }

        public override Uri Uri => ShareFileClient.Uri;

        protected override string ResourceId => throw new NotImplementedException();

        protected override DataTransferOrder TransferType => throw new NotImplementedException();

        protected override long MaxChunkSize => throw new NotImplementedException();

        protected override long? Length => throw new NotImplementedException();

        public ShareFileStorageResourceItem(
            ShareFileClient fileClient,
            ShareFileStorageResourceOptions options = default)
        {
            ShareFileClient = fileClient;
            _options = options;
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
