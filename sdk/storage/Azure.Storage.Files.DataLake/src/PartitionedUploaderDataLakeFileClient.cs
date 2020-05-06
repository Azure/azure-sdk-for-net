// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal class PartitionedUploaderDataLakeFileClient : PartitionedUploader<DataLakeFileUploadOptions, PathInfo>.IClient
    {
        private readonly DataLakeFileClient _client;

        public PartitionedUploaderDataLakeFileClient(DataLakeFileClient client)
        {
            _client = client;
        }

        public async Task<Response<PathInfo>> CommitPartitionedUploadInternal(
            List<(long Offset, long Size)> partitions,
            DataLakeFileUploadOptions args,
            bool async,
            CancellationToken cancellationToken)
        {
            var lastPartition = partitions.LastOrDefault();
            return await _client.FlushInternal(
                lastPartition.Offset + lastPartition.Size,
                retainUncommittedData: default,
                close: default,
                httpHeaders: args.HttpHeaders,
                conditions: args.Conditions,
                async,
                cancellationToken).ConfigureAwait(false);
        }

        public DiagnosticScope CreateScope(string operationName)
            => _client.ClientDiagnostics.CreateScope(operationName ??
                $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Files)}.{nameof(DataLake)}.{nameof(DataLakeFileClient)}.{nameof(DataLakeFileClient.Upload)}");

        public async Task<Response<PathInfo>> FullUploadInternal(
            Stream contentStream,
            DataLakeFileUploadOptions args,
            IProgress<long> progressHandler,
            string operationName,
            bool async,
            CancellationToken cancellationToken)
        {
            // Append data
            await _client.AppendInternal(
                contentStream,
                offset: 0,
                contentHash: default,
                args.Conditions?.LeaseId,
                progressHandler,
                async,
                cancellationToken).ConfigureAwait(false);

            // Flush data
            return await _client.FlushInternal(
                position: contentStream.Length,
                retainUncommittedData: default,
                close: default,
                args.HttpHeaders,
                args.Conditions,
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task InitializeDestinationInternal(DataLakeFileUploadOptions args, bool async, CancellationToken cancellationToken)
        {
            await _client.CreateInternal(
                PathResourceType.File,
                args.HttpHeaders,
                args.Metadata,
                args.Permissions,
                args.Umask,
                args.Conditions,
                async,
                cancellationToken).ConfigureAwait(false);

            // After the File is Create, Lease ID is the only valid request parameter.
            args.Conditions = new DataLakeRequestConditions { LeaseId = args.Conditions?.LeaseId };
        }

        public async Task StageUploadPartitionInternal(
            Stream contentStream,
            long offset,
            DataLakeFileUploadOptions args,
            IProgress<long> progressHandler,
            bool async,
            CancellationToken cancellationToken)
            => await _client.AppendInternal(
                contentStream,
                offset,
                contentHash: default,
                args.Conditions.LeaseId,
                progressHandler,
                async,
                cancellationToken).ConfigureAwait(false);
    }
}
