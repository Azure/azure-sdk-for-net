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
        public Memory<byte> Buffer { get; set; } = Memory<byte>.Empty;

        public override Uri Uri { get; }

        public override string ProviderId => "mock";

        protected internal override string ResourceId => "MemoryBuffer";

        protected internal override DataTransferOrder TransferType => DataTransferOrder.Unordered;

        protected internal override long MaxSupportedChunkSize => long.MaxValue;

        protected internal override long? Length => Buffer.Length;

        public MemoryStorageResourceItem(Uri uri = default)
        {
            Uri = uri ?? new Uri($"memory://localhost/mycontainer/mypath-{Guid.NewGuid()}/resource-item-{Guid.NewGuid()}");
        }

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
            if (!overwrite && !Buffer.IsEmpty)
            {
                return;
            }
            byte[] buf = new byte[streamLength];
            MemoryStream dest = new(buf);
            await stream.CopyToAsync(dest);
            Buffer = new Memory<byte>(buf);
        }

        protected internal override Task CopyFromUriAsync(StorageResourceItem sourceResource, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected internal override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            bool result = !Buffer.IsEmpty;
            Buffer = Memory<byte>.Empty;
            return Task.FromResult(result);
        }

        protected internal override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected internal override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken token = default)
        {
            return Task.FromResult(new StorageResourceProperties(default, default, Buffer.Length, default));
        }

        protected internal override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            throw new NotImplementedException();
        }

        protected internal override StorageResourceCheckpointData GetSourceCheckpointData()
        {
            throw new NotImplementedException();
        }

        protected internal override Task<StorageResourceReadStreamResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        {
            var slice = length.HasValue ? Buffer.Slice((int)position, (int)length.Value) : Buffer.Slice((int)position);
            return Task.FromResult(new StorageResourceReadStreamResult(new MemoryStream(slice.ToArray())));
        }
    }
}
