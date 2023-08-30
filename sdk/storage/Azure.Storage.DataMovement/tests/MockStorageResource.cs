// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MockStorageResource : StorageResourceItem
    {
        private readonly Stream _readStream;
        private readonly Uri _uri = new Uri("https://example.com");

        protected internal override string ResourceId => "Mock";

        protected internal override DataTransferOrder TransferType => DataTransferOrder.Sequential;

        private readonly long _maxChunkSize;
        protected internal override long MaxChunkSize => _maxChunkSize;

        public override Uri Uri => _uri;

        protected internal override long? Length { get; }

        private MockStorageResource(long? length, bool conProduceUri, long maxChunkSize)
        {
            Length = length;
            if (length.HasValue)
            {
                _readStream = new RepeatingStream((int)(1234567 % length.Value), length.Value, revealsLength: true);
            }
            _maxChunkSize = maxChunkSize;
        }

        public static MockStorageResource MakeSourceResource(long length, bool canProduceUri, long? maxChunkSize = default)
        {
            return new MockStorageResource(length, canProduceUri, maxChunkSize ?? 1024);
        }

        public static MockStorageResource MakeDestinationResource(bool canProduceUri, long? maxChunkSize = default)
        {
            return new MockStorageResource(default, canProduceUri, maxChunkSize ?? 1024);
        }

        protected internal override Task CompleteTransferAsync(bool overwrite, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        protected internal override Task CopyBlockFromUriAsync(StorageResourceItem sourceResource, HttpRange range, bool overwrite, long completeLength = 0, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
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

        protected internal override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken token = default)
        {
            return Task.FromResult(new StorageResourceProperties(
                lastModified: default,
                createdOn: default,
                contentLength: Length ?? 0,
                lastAccessed: default));
        }

        protected internal override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<HttpAuthorization>(default);
        }

        protected internal override Task<StorageResourceReadStreamResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        {
            _readStream.Position = 0;
            return Task.FromResult(new StorageResourceReadStreamResult(_readStream));
        }

        protected internal override async Task CopyFromStreamAsync(Stream stream, long streamLength, bool overwrite, long completeLength, StorageResourceWriteToOffsetOptions options = null, CancellationToken cancellationToken = default)
        {
            await stream.CopyToAsync(Stream.Null);
        }
    }
}
