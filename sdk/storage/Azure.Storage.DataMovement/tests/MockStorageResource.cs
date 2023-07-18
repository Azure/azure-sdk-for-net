// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MockStorageResource : StorageResourceSingle
    {
        private readonly Stream _readStream;

        protected internal override string ResourceId => "Mock";

        protected internal override TransferType TransferType => TransferType.Sequential;

        private readonly long _maxChunkSize;
        protected internal override long MaxChunkSize => _maxChunkSize;

        private readonly bool _canProduceUri;
        protected internal override bool CanProduceUri => _canProduceUri;

        public override Uri Uri => new Uri("https://example.com");

        public override string Path => "random";

        protected internal override long? Length { get; }

        private MockStorageResource(long? length, bool conProduceUri, long maxChunkSize)
        {
            Length = length;
            if (length.HasValue)
            {
                _readStream = new RepeatingStream((int)(1234567 % length.Value), length.Value, revealsLength: true);
            }
            _canProduceUri = conProduceUri;
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

        protected internal override Task CopyBlockFromUriAsync(StorageResourceSingle sourceResource, HttpRange range, bool overwrite, long completeLength = 0, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        protected internal override Task CopyFromUriAsync(StorageResourceSingle sourceResource, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
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
                lastAccessed: default,
                resourceType: StorageResourceType.LocalFile));
        }

        protected internal override Task<HttpAuthorization> GetCopyAuthorizationHeaderAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<HttpAuthorization>(default);
        }

        protected internal override Task<ReadStreamStorageResourceResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        {
            _readStream.Position = 0;
            return Task.FromResult(new ReadStreamStorageResourceResult(_readStream));
        }

        protected internal override async Task WriteFromStreamAsync(Stream stream, long streamLength, bool overwrite, long position = 0, long completeLength = 0, StorageResourceWriteToOffsetOptions options = null, CancellationToken cancellationToken = default)
        {
            await stream.CopyToAsync(Stream.Null);
        }
    }
}
