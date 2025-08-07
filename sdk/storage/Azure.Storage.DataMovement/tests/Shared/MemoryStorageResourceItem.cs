// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        protected internal override TransferOrder TransferType => TransferOrder.Unordered;

        protected internal override long MaxSupportedSingleTransferSize => long.MaxValue;

        protected internal override long MaxSupportedChunkSize => long.MaxValue;

        protected internal override int MaxSupportedChunkCount => int.MaxValue;

        protected internal override long? Length => Buffer.Length;

        public MemoryStorageResourceItem(Uri uri = default)
        {
            Uri = uri ?? new Uri($"memory://localhost/mycontainer/mypath-{Guid.NewGuid()}/resource-item-{Guid.NewGuid()}");
        }

        protected internal override Task CompleteTransferAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions,
            CancellationToken cancellationToken = default)
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

        protected internal override Task<StorageResourceItemProperties> GetPropertiesAsync(CancellationToken token = default)
        {
            return Task.FromResult(new StorageResourceItemProperties()
            {
                ResourceLength = Buffer.Length,
                ETag = new ETag("etag"),
                LastModifiedTime = DateTimeOffset.UtcNow
            });
        }

        protected internal override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            throw new NotImplementedException();
        }

        protected internal override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            throw new NotImplementedException();
        }

        protected internal override Task<StorageResourceReadStreamResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        {
            var slice = length.HasValue ? Buffer.Slice((int)position, (int)length.Value) : Buffer.Slice((int)position);
            return Task.FromResult(new StorageResourceReadStreamResult(new MemoryStream(slice.ToArray())));
        }

        protected internal override Task<string> GetPermissionsAsync(
            StorageResourceItemProperties properties = default,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected internal override Task SetPermissionsAsync(
            StorageResourceItem sourceResource,
            StorageResourceItemProperties sourceProperties,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
