// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// Encapsulates a block blob client in an interface that can be used by our <see cref="PartitionedUploader{ServiceSpecificArgs, CompleteUploadReturn}"/>
    /// that is used across multiple services.
    /// </summary>
    internal class PartitionedUploaderBlockBlobClient : PartitionedUploader<UploadBlobOptions, BlobContentInfo>.IClient
    {
        private readonly BlockBlobClient _client;

        public PartitionedUploaderBlockBlobClient(BlockBlobClient client)
        {
            _client = client;
        }

        public async Task<Response<BlobContentInfo>> CommitPartitionedUploadInternal(
            List<(long Offset, long Size)> partitions,
            UploadBlobOptions args,
            bool async,
            CancellationToken cancellationToken)
            => await _client.CommitBlockListInternal(
                partitions.Select(partition => GenerateBlockId(partition.Offset)),
                args.HttpHeaders,
                args.Metadata,
                args.Tags,
                args.Conditions,
                args.AccessTier,
                async,
                cancellationToken).ConfigureAwait(false);

        public DiagnosticScope CreateScope(string operationName)
            => _client.ClientDiagnostics.CreateScope(operationName ?? $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Blobs)}.{nameof(BlobClient)}.{nameof(BlobClient.Upload)}");

        public async Task<Response<BlobContentInfo>> FullUploadInternal(
            Stream contentStream,
            UploadBlobOptions args,
            IProgress<long> progressHandler,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
            => await _client.UploadInternal(
                contentStream,
                args.HttpHeaders,
                args.Metadata,
                args.Tags,
                args.Conditions,
                args.AccessTier,
                progressHandler,
                operationName,
                async,
                cancellationToken).ConfigureAwait(false);

        public Task InitializeDestinationInternal(UploadBlobOptions args, bool async, CancellationToken cancellationToken)
            => Task.CompletedTask; // block blobs don't need this initialization

        public async Task StageUploadPartitionInternal(
            Stream contentStream,
            long offset,
            UploadBlobOptions args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
            => await _client.StageBlockInternal(
                GenerateBlockId(offset),
                contentStream,
                transactionalContentHash: default,
                args.Conditions,
                progressHandler,
                async,
                cancellationToken).ConfigureAwait(false);

        // Block IDs must be 64 byte Base64 encoded strings
        private static string GenerateBlockId(long offset)
        {
            // TODO #8162 - Add in a random GUID so multiple simultaneous
            // uploads won't stomp on each other and the first to commit wins.
            // This will require some changes to our test framework's
            // RecordedClientRequestIdPolicy.
            byte[] id = new byte[48]; // 48 raw bytes => 64 byte string once Base64 encoded
            BitConverter.GetBytes(offset).CopyTo(id, 0);
            return Convert.ToBase64String(id);
        }
    }
}
