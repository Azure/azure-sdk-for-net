// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MockStorageResource : StorageResourceItem
    {
        private readonly Uri _uri;
        private readonly int _failAfter;
        private int _operationCount = 0;

        public override Uri Uri => _uri;

        public override string ProviderId => "mock";

        protected internal override string ResourceId => "Mock";

        protected internal override DataTransferOrder TransferType { get; }

        protected internal override long MaxSupportedChunkSize => Constants.GB;

        protected internal override long? Length { get; }

        private MockStorageResource(long? length, Uri uri, int failAfter, DataTransferOrder transferOrder = DataTransferOrder.Sequential)
        {
            Length = length;
            _uri = uri ?? new Uri("https://example.com");
            _failAfter = failAfter;
            TransferType = transferOrder;
        }

        public static MockStorageResource MakeSourceResource(long length, Uri uri = default, int failAfter = int.MaxValue)
        {
            return new MockStorageResource(length, uri, failAfter);
        }

        public static MockStorageResource MakeDestinationResource(Uri uri = default, DataTransferOrder transferOrder = DataTransferOrder.Sequential, int failAfter = int.MaxValue)
        {
            return new MockStorageResource(default, uri, failAfter, transferOrder);
        }

        protected internal override Task CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        protected internal override Task CopyBlockFromUriAsync(StorageResourceItem sourceResource, HttpRange range, bool overwrite, long completeLength = 0, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            if (_operationCount > _failAfter)
            {
                throw new Exception($"Intentionally failing copy after {_operationCount} blocks.");
            }
            Interlocked.Increment(ref _operationCount);

            return Task.CompletedTask;
        }

        protected internal override Task CopyFromUriAsync(StorageResourceItem sourceResource, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        protected internal override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        protected internal override Task<StorageResourceItemProperties> GetPropertiesAsync(CancellationToken token = default)
        {
            return Task.FromResult(new StorageResourceItemProperties(
                resourceLength: Length ?? 0,
                eTag: new ETag("etag"),
                lastModifiedTime: DateTimeOffset.UtcNow,
                properties: default));
        }

        protected internal override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<HttpAuthorization>(default);
        }

        protected internal override Task<StorageResourceReadStreamResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        {
            if (_operationCount > _failAfter)
            {
                throw new Exception($"Intentionally failing read after {_operationCount} reads.");
            }
            Interlocked.Increment(ref _operationCount);

            // This mirrors the way the real resources work. Local resources give back a stream of the full length
            // of the file whereas remote resources will give back stream of exactly the requested length.
            Stream result = new EmptyStream(_uri.IsFile ? Length.Value : length.Value);
            return Task.FromResult(new StorageResourceReadStreamResult(result));
        }

        protected internal override StorageResourceCheckpointData GetSourceCheckpointData()
        {
            return new MockResourceCheckpointData();
        }

        protected internal override StorageResourceCheckpointData GetDestinationCheckpointData()
        {
            return new MockResourceCheckpointData();
        }

        protected internal override Task CopyFromStreamAsync(Stream stream, long streamLength, bool overwrite, long completeLength, StorageResourceWriteToOffsetOptions options = null, CancellationToken cancellationToken = default)
        {
            if (_operationCount > _failAfter)
            {
                throw new Exception($"Intentionally failing write after {_operationCount} writes.");
            }
            Interlocked.Increment(ref _operationCount);

            stream.Position += streamLength;
            return Task.CompletedTask;
        }
    }
}
