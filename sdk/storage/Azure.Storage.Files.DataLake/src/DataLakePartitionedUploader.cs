// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakePartitionedUploader
    {
        /// <summary>
        /// The client we use to do the actual uploading.
        /// </summary>
        private readonly DataLakeFileClient _client;

        /// <summary>
        /// The maximum number of simultaneous workers.
        /// </summary>
        private readonly int _maxWorkerCount;

        /// <summary>
        /// A pool of memory we use to partition the stream into blocks.
        /// </summary>
        private readonly ArrayPool<byte> _arrayPool;

        /// <summary>
        /// The size we use to determine whether to upload as a single PUT BLOB
        /// request or stage as multiple blocks.
        /// </summary>
        private readonly long _singleUploadThreshold;

        /// <summary>
        /// The size of each staged block.  If null, we'll change between 4MB
        /// and 8MB depending on the size of the content.
        /// </summary>
        private readonly int? _blockSize;

        /// <summary>
        /// The name of the calling operaiton.
        /// </summary>
        private readonly string _operationName;

        public DataLakePartitionedUploader(
            DataLakeFileClient client,
            StorageTransferOptions transferOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
        {
            _client = client;
            _arrayPool = arrayPool ?? ArrayPool<byte>.Shared;

            // Set _maxWorkerCount
            if (transferOptions.MaximumConcurrency.HasValue)
            {
                if (transferOptions.MaximumConcurrency < 1)
                {
                    _maxWorkerCount = Constants.DataLake.DefaultConcurrentTransfersCount;
                }
                else
                {
                    _maxWorkerCount = transferOptions.MaximumConcurrency.Value;
                }
            }
            else
            {
                _maxWorkerCount = Constants.DataLake.DefaultConcurrentTransfersCount;
            }

            // Set _singleUploadThreshold
            if (transferOptions.InitialTransferLength.HasValue)
            {
                if (transferOptions.InitialTransferLength.Value < 1)
                {
                    _singleUploadThreshold = Constants.DataLake.MaxAppendBytes;
                }
                else
                {
                    _singleUploadThreshold = Math.Min(transferOptions.InitialTransferLength.Value, Constants.DataLake.MaxAppendBytes);
                }
            }
            else
            {
                _singleUploadThreshold = Constants.DataLake.MaxAppendBytes;
            }

            // Set _blockSize
            if (transferOptions.MaximumTransferLength.HasValue)
            {
                if (transferOptions.MaximumTransferLength < 1)
                {
                    _blockSize = Constants.DataLake.MaxAppendBytes;
                }
                else
                {
                    _blockSize = Math.Min(
                        Constants.DataLake.MaxAppendBytes,
                        transferOptions.MaximumTransferLength.Value);
                }
            }
            else
            {
                _blockSize = Constants.DataLake.MaxAppendBytes;
            }

            _operationName = operationName;
        }

        public async Task<Response<PathInfo>> UploadAsync(
            Stream content,
            PathHttpHeaders httpHeaders,
            DataLakeRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            await _client.CreateAsync(
                httpHeaders: httpHeaders,
                conditions: conditions,
                cancellationToken: cancellationToken).ConfigureAwait(false);

            // After the File is Create, Lease ID is the only valid request parameter.
            conditions = new DataLakeRequestConditions { LeaseId = conditions?.LeaseId };

            // If we can compute the size and it's small enough
            if (PartitionedUploadExtensions.TryGetLength(content, out long contentLength)
                && contentLength < _singleUploadThreshold)
            {
                // Append data
                await _client.AppendAsync(
                    content,
                    offset: 0,
                    leaseId: conditions?.LeaseId,
                    progressHandler: progressHandler,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                // Flush data
                return await _client.FlushAsync(
                    position: contentLength,
                    httpHeaders: httpHeaders,
                    conditions: conditions)
                    .ConfigureAwait(false);
            }

            // If the caller provided an explicit block size, we'll use it.
            // Otherwise we'll adjust dynamically based on the size of the
            // content.
            int blockSize =
                _blockSize != null ? _blockSize.Value :
                contentLength < Constants.LargeUploadThreshold ?
                    Constants.DefaultBufferSize :
                    Constants.LargeBufferSize;

            // Otherwise stage individual blocks in parallel
            return await UploadInParallelAsync(
                content,
                blockSize,
                httpHeaders,
                conditions,
                progressHandler,
                cancellationToken).ConfigureAwait(false);
        }

        public Response<PathInfo> Upload(
            Stream content,
            PathHttpHeaders httpHeaders,
            DataLakeRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            _client.Create(
                httpHeaders: httpHeaders,
                conditions: conditions,
                cancellationToken: cancellationToken);

            // After the File is Create, Lease ID is the only valid request parameter.
            conditions = new DataLakeRequestConditions { LeaseId = conditions?.LeaseId };

            // If we can compute the size and it's small enough
            if (PartitionedUploadExtensions.TryGetLength(content, out long contentLength)
                && contentLength < _singleUploadThreshold)
            {
                // Upload it in a single request
                _client.Append(
                    content,
                    offset: 0,
                    leaseId: conditions?.LeaseId,
                    progressHandler: progressHandler,
                    cancellationToken: cancellationToken);

                // Calculate flush position
                long flushPosition = contentLength;

                return _client.Flush(
                    position: flushPosition,
                    httpHeaders: httpHeaders,
                    conditions: conditions,
                    cancellationToken: cancellationToken);
            }

            // If the caller provided an explicit block size, we'll use it.
            // Otherwise we'll adjust dynamically based on the size of the
            // content.
            int blockSize =
                _blockSize != null ? _blockSize.Value :
                contentLength < Constants.LargeUploadThreshold ?
                    Constants.DefaultBufferSize :
                    Constants.LargeBufferSize;

            // Otherwise stage individual blocks one at a time.  It's not as
            // fast as a parallel upload, but you get the benefit of the retry
            // policy working on a single block instead of the entire stream.
            return UploadInSequence(
                content,
                blockSize,
                httpHeaders,
                conditions,
                progressHandler,
                cancellationToken);
        }

        private Response<PathInfo> UploadInSequence(
            Stream content,
            int blockSize,
            PathHttpHeaders httpHeaders,
            DataLakeRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            // Wrap the append and flush calls in an Upload span for
            // distributed tracing
            DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(
                _operationName ?? $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Files)}.{nameof(DataLake)}.{nameof(DataLakeFileClient)}.{nameof(DataLakeFileClient.Upload)}");

            try
            {
                scope.Start();

                // Wrap progressHandler in a AggregatingProgressIncrementer to prevent
                // progress from being reset with each append file operation.
                if (progressHandler != null)
                {
                    progressHandler = new AggregatingProgressIncrementer(progressHandler);
                }

                // Partition the stream into individual blocks and stage them
                IAsyncEnumerator<ChunkedStream> enumerator =
                    PartitionedUploadExtensions.GetBlocksAsync(
                        content, blockSize, async: false, _arrayPool, cancellationToken)
                    .GetAsyncEnumerator(cancellationToken);

                // We need to keep track of how much data we have appended to
                // calculate offsets for the next appends, and the final
                // position to flush
                long appendedBytes = 0;
#pragma warning disable AZC0107
                while (enumerator.MoveNextAsync().EnsureCompleted())
#pragma warning restore AZC0107
                {
                    // Dispose the block after the loop iterates and return its
                    // memory to our ArrayPool
                    using ChunkedStream block = enumerator.Current;

                    // Append the next block
                    _client.Append(
                        new MemoryStream(block.Bytes, 0, block.Length, writable: false),
                        offset: appendedBytes,
                        leaseId: conditions?.LeaseId,
                        progressHandler: progressHandler,
                        cancellationToken: cancellationToken);

                    appendedBytes += block.Length;
                }

                // Commit the block list after everything has been staged to
                // complete the upload
                return _client.Flush(
                    position: appendedBytes,
                    httpHeaders: httpHeaders,
                    conditions: conditions,
                    cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        private async Task<Response<PathInfo>> UploadInParallelAsync(
            Stream content,
            int blockSize,
            PathHttpHeaders httpHeaders,
            DataLakeRequestConditions conditions,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)

        {
            // Wrap the staging and commit calls in an Upload span for
            // distributed tracing
            DiagnosticScope scope = _client.ClientDiagnostics.CreateScope(
                _operationName ?? $"{nameof(Azure)}.{nameof(Storage)}.{nameof(Files)}.{nameof(DataLake)}.{nameof(DataLakeFileClient)}.{nameof(DataLakeFileClient.Upload)}");

            try
            {
                scope.Start();

                // Wrap progressHandler in a AggregatingProgressIncrementer to prevent
                // progress from being reset with each stage blob operation.
                if (progressHandler != null)
                {
                    progressHandler = new AggregatingProgressIncrementer(progressHandler);
                }

                // A list of tasks that are currently executing which will
                // always be smaller than _maxWorkerCount
                List<Task> runningTasks = new List<Task>();

                // We need to keep track of how much data we have appended to
                // calculate offsets for the next appends, and the final
                // position to flush
                long appendedBytes = 0;

                // Partition the stream into individual blocks
                await foreach (ChunkedStream block in PartitionedUploadExtensions.GetBlocksAsync(
                    content, blockSize, async: true, _arrayPool, cancellationToken).ConfigureAwait(false))
                {
                    // Start appending the next block (but don't await the Task!)
                    Task task = AppendBlockAsync(
                        block,
                        appendedBytes,
                        conditions?.LeaseId,
                        progressHandler,
                        cancellationToken);

                    // Add the block to our task and commit lists
                    runningTasks.Add(task);

                    appendedBytes += block.Length;

                    // If we run out of workers
                    if (runningTasks.Count >= _maxWorkerCount)
                    {
                        // Wait for at least one of them to finish
                        await Task.WhenAny(runningTasks).ConfigureAwait(false);

                        // Clear any completed blocks from the task list
                        for (int i = 0; i < runningTasks.Count; i++)
                        {
                            Task runningTask = runningTasks[i];
                            if (!runningTask.IsCompleted)
                            {
                                continue;
                            }

                            await runningTask.ConfigureAwait(false);
                            runningTasks.RemoveAt(i);
                            i--;
                        }
                    }
                }

                // Wait for all the remaining blocks to finish staging and then
                // commit the block list to complete the upload
                await Task.WhenAll(runningTasks).ConfigureAwait(false);
                return await _client.FlushAsync(
                    position: appendedBytes,
                    httpHeaders: httpHeaders,
                    conditions: conditions,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
            finally
            {
                scope.Dispose();
            }
        }

        private async Task AppendBlockAsync(
            ChunkedStream block,
            long offset,
            string leaseId,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            try
            {
                await _client.AppendAsync(
                    new MemoryStream(block.Bytes, 0, block.Length, writable: false),
                    offset: offset,
                    leaseId: leaseId,
                    progressHandler: progressHandler,
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            finally
            {
                // Return the memory used by the block to our ArrayPool as soon
                // as we've staged it
                block.Dispose();
            }
        }
    }
}
