// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.Tests.Shared;

namespace Azure.Storage.DataMovement.Tests
{
    internal class MockStorageResource : StorageResource
    {
        private readonly Stream _readStream;

        public override TransferCopyMethod ServiceCopyMethod => TransferCopyMethod.None;

        public override TransferType TransferType => TransferType.Sequential;

        private readonly long _maxChunkSize;
        public override long MaxChunkSize => _maxChunkSize;

        private readonly ProduceUriType _produceUriType;
        public override ProduceUriType CanProduceUri => _produceUriType;

        public override Uri Uri => new Uri("https://example.com");

        public override string Path => "random";

        public override long? Length { get; }

        private MockStorageResource(long? length, ProduceUriType uriType, long maxChunkSize)
        {
            Length = length;
            if (length.HasValue)
            {
                _readStream = new RepeatingStream((int)(1234567 % length.Value), length.Value, revealsLength: true);
            }
            _produceUriType = uriType;
            _maxChunkSize = maxChunkSize;
        }

        public static MockStorageResource MakeSourceResource(long length, ProduceUriType uriType, long? maxChunkSize = default)
        {
            return new MockStorageResource(length, uriType, maxChunkSize ?? 1024);
        }

        public static MockStorageResource MakeDestinationResource(ProduceUriType uriType, long? maxChunkSize = default)
        {
            return new MockStorageResource(default, uriType, maxChunkSize ?? 1024);
        }

        public override Task CompleteTransferAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override Task CopyBlockFromUriAsync(StorageResource sourceResource, HttpRange range, bool overwrite, long completeLength = 0, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override Task CopyFromUriAsync(StorageResource sourceResource, bool overwrite, long completeLength, StorageResourceCopyFromUriOptions options = null, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override Task<bool> DeleteIfExistsAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public override Task<StorageResourceProperties> GetPropertiesAsync(CancellationToken token = default)
        {
            return Task.FromResult(new StorageResourceProperties(
                lastModified: default,
                createdOn: default,
                contentLength: Length ?? 0,
                lastAccessed: default,
                resourceType: StorageResourceType.LocalFile));
        }

        public override Task<ReadStreamStorageResourceResult> ReadStreamAsync(long position = 0, long? length = null, CancellationToken cancellationToken = default)
        {
            _readStream.Position = 0;
            return Task.FromResult(new ReadStreamStorageResourceResult(_readStream));
        }

        public override async Task WriteFromStreamAsync(Stream stream, long streamLength, bool overwrite, long position = 0, long completeLength = 0, StorageResourceWriteToOffsetOptions options = null, CancellationToken cancellationToken = default)
        {
            await stream.CopyToAsync(Stream.Null);
        }
    }
}
