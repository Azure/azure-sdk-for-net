// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MockStorageResourceItem : StorageResourceItem
    {
        private readonly Uri _uri;
        private readonly int _failAfter;
        private int _operationCount = 0;

        public override Uri Uri => _uri;

        public override string ProviderId => "mock";

        protected internal override string ResourceId => "Mock";

        protected internal override TransferOrder TransferType { get; }

        protected internal override long MaxSupportedSingleTransferSize => Constants.GB;

        protected internal override long MaxSupportedChunkSize => _maxSupportedChunkSize;
        private long _maxSupportedChunkSize;

        protected internal override int MaxSupportedChunkCount => _maxSupportedChunkCount;
        private int _maxSupportedChunkCount;

        protected internal override long? Length { get; }

        private MockStorageResourceItem(
            long? length,
            Uri uri,
            int failAfter,
            TransferOrder transferOrder = TransferOrder.Sequential,
            long maxSupportedChunkSize = Constants.GB,
            int maxSupportedChunkCount = int.MaxValue)
        {
            Length = length;
            _uri = uri ?? new Uri("https://example.com");
            _failAfter = failAfter;
            TransferType = transferOrder;
            _maxSupportedChunkSize = maxSupportedChunkSize;
            _maxSupportedChunkCount = maxSupportedChunkCount;
        }

        public static MockStorageResourceItem MakeSourceResource(long length, Uri uri = default, int failAfter = int.MaxValue)
        {
            return new MockStorageResourceItem(length, uri, failAfter);
        }

        public static MockStorageResourceItem MakeDestinationResource(
            Uri uri = default,
            TransferOrder transferOrder = TransferOrder.Sequential,
            int failAfter = int.MaxValue,
            long maxSupportedChunkSize = Constants.GB,
            int maxSupportChunkCount = int.MaxValue)
        {
            return new MockStorageResourceItem(default, uri, failAfter, transferOrder, maxSupportedChunkSize, maxSupportChunkCount);
        }

        protected internal override Task CompleteTransferAsync(
            bool overwrite,
            StorageResourceCompleteTransferOptions completeTransferOptions = default,
            CancellationToken cancellationToken = default)
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
            return Task.FromResult(new StorageResourceItemProperties()
            {
                ResourceLength = Length ?? 0,
                ETag = new ETag("etag"),
                LastModifiedTime = DateTimeOffset.UtcNow
            });
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

        protected internal override StorageResourceCheckpointDetails GetSourceCheckpointDetails()
        {
            return new MockResourceCheckpointDetails();
        }

        protected internal override StorageResourceCheckpointDetails GetDestinationCheckpointDetails()
        {
            return new MockResourceCheckpointDetails();
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

        // no-op for get permissions
        protected internal override Task<string> GetPermissionsAsync(
            StorageResourceItemProperties properties = default,
            CancellationToken cancellationToken = default)
            => Task.FromResult((string)default);

        // no-op for set permissions
        protected internal override Task SetPermissionsAsync(
            StorageResourceItem sourceResource,
            StorageResourceItemProperties sourceProperties,
            CancellationToken cancellationToken = default)
            => Task.CompletedTask;

        public static (StorageResourceItem Source, StorageResourceItem Destination) GetMockTransferResources(
            TransferDirection transferDirection,
            TransferOrder transferOrder = TransferOrder.Unordered,
            long fileSize = 4L * Constants.KB,
            int sourceFailAfter = int.MaxValue,
            int destinationFailAfter = int.MaxValue)
        {
            Uri localUri = new(@"C:\Sample\test.txt");
            Uri remoteUri = new("https://example.com");

            StorageResourceItem sourceResource;
            StorageResourceItem destinationResource;
            if (transferDirection == TransferDirection.Copy)
            {
                sourceResource = MakeSourceResource(fileSize, uri: remoteUri, failAfter: sourceFailAfter);
                destinationResource = MakeDestinationResource(uri: remoteUri, transferOrder: transferOrder, failAfter: destinationFailAfter);
            }
            else if (transferDirection == TransferDirection.Upload)
            {
                sourceResource = MakeSourceResource(fileSize, uri: localUri, failAfter: sourceFailAfter);
                destinationResource = MakeDestinationResource(uri: remoteUri, transferOrder: transferOrder, failAfter: destinationFailAfter);
            }
            else // transferType == TransferDirection.Download
            {
                sourceResource = MakeSourceResource(fileSize, uri: remoteUri, failAfter: sourceFailAfter);
                destinationResource = MakeDestinationResource(uri: localUri, transferOrder: transferOrder, failAfter: destinationFailAfter);
            }

            return (sourceResource, destinationResource);
        }
    }
}
