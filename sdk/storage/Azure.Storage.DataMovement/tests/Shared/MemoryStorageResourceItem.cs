// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MemoryStorageResourceItem : StorageResourceItem
    {
        private Memory<byte> _buffer = Memory<byte>.Empty;

        private readonly Uri _uri;
        public override Uri Uri => _uri;

        protected internal override string ResourceId => "MemoryBuffer";

        protected internal override DataTransferOrder TransferType => DataTransferOrder.Unordered;

        protected internal override long MaxChunkSize => long.MaxValue;

        protected internal override long? Length => _buffer.Length;

        protected internal override Task CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        protected internal override Task CopyBlockFromUriAsync(StorageResourceItem sourceResource, HttpRange range, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected internal override async Task CopyFromStreamAsync(Stream stream, long streamLength, bool overwrite, long completeLength, StorageResourceWriteToOffsetOptions options = null, CancellationToken cancellationToken = default)
        {
            if (!overwrite && !_buffer.IsEmpty)
            {
                return;
            }
            MemoryStream dest = new();
            await stream.CopyToAsync(dest);
            _buffer = new Memory<byte>(dest.ToArray());
        }

        protected internal override Task CopyFromUriAsync(StorageResourceItem sourceResource, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected internal override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            bool result = _buffer.IsEmpty;
            _buffer = Memory<byte>.Empty;
            return Task.FromResult(result);
        }

        protected internal override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected internal override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            throw new NotImplementedException();
        }

        protected internal override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken token = default)
        {
            return Task.FromResult(new StorageResourceProperties(default, default, _buffer.Length, default));
        }

        protected internal override StorageResourceCheckpointData GetSourceCheckpointData()
        {
            throw new NotImplementedException();
        }

        protected internal override Task<StorageResourceReadStreamResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        {
            var slice = length.HasValue ? _buffer.Slice((int)position, (int)length.Value) : _buffer.Slice((int)position);
            return Task.FromResult(new StorageResourceReadStreamResult(new MemoryStream(slice.ToArray())));
        }
    }
}
