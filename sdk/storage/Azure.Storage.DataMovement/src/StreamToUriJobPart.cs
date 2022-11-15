﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Storage.DataMovement.Models;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Azure.Storage.Blobs.DataMovement.Models;
using System.Buffers;
using Azure.Storage.Shared;

namespace Azure.Storage.DataMovement
{
    internal class StreamToUriJobPart : JobPartInternal
    {
        public delegate Task CommitBlockTaskInternal(CancellationToken cancellationToken);
        public CommitBlockTaskInternal CommitBlockTask { get; internal set; }

        /// <summary>
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private CommitChunkHandler _commitBlockHandler;

        /// <summary>
        /// Creating job part based on a single transfer job
        /// </summary>
        /// <param name="job"></param>
        /// <param name="partNumber"></param>
        public StreamToUriJobPart(StreamToUriTransferJob job, int partNumber)
            : base(job._dataTransfer,
                  partNumber,
                  job._sourceResource,
                  job._destinationResource,
                  job._maximumTransferChunkSize,
                  job._initialTransferSize,
                  job._errorHandling,
                  job._createMode,
                  job._checkpointer,
                  job.UploadArrayPool,
                  job.TransferStatusEventHandler,
                  job.TransferFailedEventHandler,
                  job._cancellationTokenSource)
        { }

        /// <summary>
        /// Creating transfer job based on a storage resource created from listing.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="partNumber"></param>
        public StreamToUriJobPart(
            StreamToUriTransferJob job,
            int partNumber,
            StorageResource sourceResource,
            StorageResource destinationResource)
            : base(job._dataTransfer,
                  partNumber,
                  sourceResource,
                  destinationResource,
                  job._maximumTransferChunkSize,
                  job._initialTransferSize,
                  job._errorHandling,
                  job._createMode,
                  job._checkpointer,
                  job.UploadArrayPool,
                  job.TransferStatusEventHandler,
                  job.TransferFailedEventHandler,
                  job._cancellationTokenSource)
        { }

        /// <summary>
        /// Processes the job to job parts
        /// </summary>
        /// <returns>The task that's queueing up the chunks</returns>
        public override async Task ProcessPartToChunkAsync()
        {
            // Attempt to get the length, it's possible the file could
            // not be accesible (or does not exist).
            long? fileLength = default;
            try
            {
                StorageResourceProperties properties = await _sourceResource.GetPropertiesAsync(_cancellationTokenSource.Token).ConfigureAwait(false);
                fileLength = properties.ContentLength;
            }
            catch
            {
                // TODO: logging when given the event handler
                await TriggerCancellation().ConfigureAwait(false);
                return;
            }

            string operationName = $"{nameof(TransferManager.StartTransferAsync)}";
            await OnTransferStatusChanged(StorageTransferStatus.InProgress).ConfigureAwait(false);
            if (fileLength.HasValue)
            {
                // Determine whether the upload will be a single put blob or not
                if (_initialTransferSize < fileLength.Value)
                {
                    // If the caller provided an explicit block size, we'll use it.
                    // Otherwise we'll adjust dynamically based on the size of the
                    // content.
                    long blockSize;
                    if (_maximumTransferChunkSize.HasValue
                    && _maximumTransferChunkSize > 0)
                    {
                        blockSize = Math.Min(
                        Constants.Blob.Block.MaxStageBytes,
                            _maximumTransferChunkSize.Value);
                    }
                    else
                    {
                        blockSize = fileLength < Constants.LargeUploadThreshold ?
                                Constants.DefaultBufferSize :
                                Constants.LargeBufferSize;
                    }

                    // If we cannot upload in one shot, initiate the parallel block uploader
                    List<(long Offset, long Length)> commitBlockList = GetCommitBlockList(blockSize, fileLength.Value);

                    await QueueStageBlockRequests(commitBlockList).ConfigureAwait(false);

                    _commitBlockHandler = GetCommitController(expectedLength: fileLength.Value, this);
                }
                else
                {
                    // Single Put Blob Request
                    await QueueChunk( async () => await SingleUploadCall(fileLength.Value).ConfigureAwait(false)).ConfigureAwait(false);
                }
            }
            else
            {
                // TODO: logging when given the event handler
                await TriggerCancellation().ConfigureAwait(false);
            }
        }

        #region CommitChunkController
        internal static CommitChunkHandler GetCommitController(
            long expectedLength,
            StreamToUriJobPart jobPart)
        => new CommitChunkHandler(
            expectedLength,
            GetBlockListCommitHandlerBehaviors(jobPart));

        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            StreamToUriJobPart jobPart)
        {
            return new CommitChunkHandler.Behaviors
            {
                // TODO #27253
                QueueCommitBlockTask = async () => await jobPart.CompleteTransferAsync().ConfigureAwait(false),
                ReportProgressInBytes = (long bytesWritten) =>
                    jobPart.ReportBytesWritten(bytesWritten),
                InvokeFailedHandler = async (ex) => await jobPart.InvokeFailedArg(ex).ConfigureAwait(false),
                UpdateTransferStatus = async (status)
                    => await jobPart.OnTransferStatusChanged(status).ConfigureAwait(false)
            };
        }
        #endregion

        internal async Task SingleUploadCall(long length)
        {
            try
            {
                ReadStreamStorageResourceInfo result =  await _sourceResource.ReadStreamAsync().ConfigureAwait(false);

                using Stream stream = result.Content;
                await _destinationResource.WriteFromStreamAsync(
                        stream,
                        _cancellationTokenSource.Token).ConfigureAwait(false);

                // Set completion status to completed
                ReportBytesWritten(length);
                await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task StageBlockInternal(
            long offset,
            long blockLength)
        {
            try
            {
                await OnTransferStatusChanged(StorageTransferStatus.InProgress).ConfigureAwait(false);
                Stream slicedStream = Stream.Null;
                ReadStreamStorageResourceInfo result = await _sourceResource.ReadPartialStreamAsync(
                    offset: offset,
                    length: blockLength,
                    cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
                using (Stream stream = result.Content)
                {
                    slicedStream = await GetOffsetPartitionInternal(
                        stream,
                        (int)offset,
                        (int)blockLength,
                        UploadArrayPool,
                        _cancellationTokenSource.Token).ConfigureAwait(false);
                    await _destinationResource.WriteStreamToOffsetAsync(
                        offset,
                        blockLength,
                        slicedStream,
                        default,
                        _cancellationTokenSource.Token).ConfigureAwait(false);
                }
                // Invoke event handler to keep track of all the stage blocks
                await _commitBlockHandler.InvokeEvent(
                    new StageChunkEventArgs(
                        _dataTransfer.Id,
                        true,
                        offset,
                        blockLength,
                        true,
                        _cancellationTokenSource.Token)).ConfigureAwait(false);
            }
            // If we fail to stage a block, we need to make sure the rest of the stage blocks are cancelled
            // (Core already performs the retry policy on the one stage block request
            // which means the rest are not worth to continue)
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await TriggerCancellation().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        internal async Task CompleteTransferAsync()
        {
            try
            {
                await _destinationResource.CompleteTransferAsync(_cancellationTokenSource.Token).ConfigureAwait(false);

                // Set completion status to completed
                await OnTransferStatusChanged(StorageTransferStatus.Completed).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeFailedArg(ex).ConfigureAwait(false);
            }
        }

        private static List<(long Offset, long Size)> GetCommitBlockList(long blockSize, long fileLength)
        {
            // The list tracking blocks IDs we're going to commit
            List<(long Offset, long Size)> partitions = new List<(long, long)>();

            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in GetPartitionIndexes(fileLength, blockSize))
            {
                /* We need to do this first! Length is calculated on the fly based on stream buffer
                    * contents; We need to record the partition data first before consuming the stream
                    * asynchronously. */
                partitions.Add(block);
            }
            return partitions;
        }

        private async Task QueueStageBlockRequests(List<(long Offset, long Size)> commitBlockList)
        {
            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in commitBlockList)
            {
                // Queue paritioned block task
                await QueueChunk(async () =>
                    await StageBlockInternal(
                        block.Offset,
                        block.Length).ConfigureAwait(false)).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Partition a stream into a series of blocks buffered as needed by an array pool.
        /// </summary>
        private static IEnumerable<(long Offset, long Length)> GetPartitionIndexes(
            long streamLength, // StreamLength needed to divide before hand
            long blockSize)
        {
            // The minimum amount of data we'll accept from a stream before
            // splitting another block. Code that sets `blockSize` will always
            // set it to a positive number. Min() only avoids edge case where
            // user sets their block size to 1.
            long acceptableBlockSize = Math.Max(1, blockSize / 2);

            // service has a max block count per blob
            // block size * block count limit = max data length to upload
            // if stream length is longer than specified max block size allows, can't upload
            long minRequiredBlockSize = (long)Math.Ceiling((double)streamLength / Constants.Blob.Block.MaxBlocks);
            if (blockSize < minRequiredBlockSize)
            {
                throw Errors.InsufficientStorageTransferOptions(streamLength, blockSize, minRequiredBlockSize);
            }
            // bring min up to our min required by the service
            acceptableBlockSize = Math.Max(acceptableBlockSize, minRequiredBlockSize);

            long absolutePosition = 0;
            long blockLength;

            // TODO: divide up paritions based on how much array pool is left
            while (absolutePosition < streamLength)
            {
                // Return based on the size of the stream divided up by the acceptable blocksize.
                blockLength = (absolutePosition + acceptableBlockSize < streamLength) ?
                    acceptableBlockSize :
                    streamLength - absolutePosition;
                yield return (absolutePosition, blockLength);
                absolutePosition += blockLength;
            }
        }

        /// <summary>
        /// Gets a partition from the current location of the given stream.
        ///
        /// This partition is buffered and it is safe to get many before using any of them.
        /// </summary>
        /// <param name="stream">
        /// Stream to buffer a partition from.
        /// </param>
        /// <param name="offset">
        /// Minimum amount of data to wait on before finalizing buffer.
        /// </param>
        /// <param name="length">
        /// Max amount of data to buffer before cutting off for the next.
        /// </param>
        /// <param name="arrayPool">
        /// </param>
        /// <param name="cancellationToken">
        /// </param>
        /// <returns>
        /// Task containing the buffered stream partition.
        /// </returns>
        private static async Task<SlicedStream> GetOffsetPartitionInternal(
            Stream stream,
            int offset,
            int length,
            ArrayPool<byte> arrayPool,
            CancellationToken cancellationToken)
        {
            return await PartitionedStream.BufferStreamPartitionInternal(
                stream: stream,
                minCount: length,
                maxCount: length,
                absolutePosition: offset,
                arrayPool: arrayPool,
                maxArrayPoolRentalSize: default,
                async: true,
                cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
