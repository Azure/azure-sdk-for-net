// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.Shared;
using static Azure.Storage.DataMovement.TransferJobInternal;

namespace Azure.Storage.DataMovement
{
    internal class ServiceToServiceJobPart : JobPartInternal
    {
        public delegate Task CommitBlockTaskInternal(CancellationToken cancellationToken);
        public CommitBlockTaskInternal CommitBlockTask { get; internal set; }

        /// <summary>
        ///  Will handle the calling the commit block list API once
        ///  all commit blocks have been uploaded.
        /// </summary>
        private CommitChunkHandler _commitBlockHandler;

        /// <summary>
        /// Constructs the StreamToUriJobPart
        /// </summary>
        /// <param name="dataTransfer"></param>
        /// <param name="sourceResource"></param>
        /// <param name="destinationResource"></param>
        /// <param name="maximumTransferChunkSize"></param>
        /// <param name="initialTransferSize"></param>
        /// <param name="errorHandling"></param>
        /// <param name="checkpointer"></param>
        /// <param name="uploadPool"></param>
        /// <param name="events"></param>
        /// <param name="cancellationTokenSource"></param>
        public ServiceToServiceJobPart(
            DataTransfer dataTransfer,
            StorageResource sourceResource,
            StorageResource destinationResource,
            long? maximumTransferChunkSize,
            long initialTransferSize,
            ErrorHandlingOptions errorHandling,
            TransferCheckpointer checkpointer,
            ArrayPool<byte> uploadPool,
            TransferEventsInternal events,
            CancellationTokenSource cancellationTokenSource)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  maximumTransferChunkSize,
                  initialTransferSize,
                  errorHandling,
                  checkpointer,
                  uploadPool,
                  events,
                  cancellationTokenSource)
        { }

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

                    if (RequiresCompleteTransferType.RequiresCompleteCall == _sourceResource.RequiresCompleteTransfer)
                    {
                        _commitBlockHandler = GetCommitController(
                            expectedLength: fileLength.Value,
                            commitBlockTask: async (cancellationToken) =>
                                await _sourceResource.CompleteTransferAsync(cancellationToken).ConfigureAwait(false),
                            this);
                    }
                }
                else
                {
                    // Single Put Blob Request
                    await QueueChunk(async () => await SingleSyncCopyInternal(fileLength.Value).ConfigureAwait(false)).ConfigureAwait(false);
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
            CommitBlockTaskInternal commitBlockTask,
            ServiceToServiceJobPart jobPart)
        => new CommitChunkHandler(
            expectedLength,
            GetBlockListCommitHandlerBehaviors(commitBlockTask, jobPart));

        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            CommitBlockTaskInternal commitBlockTask,
            ServiceToServiceJobPart jobPart)
        {
            return new CommitChunkHandler.Behaviors
            {
                // TODO #27253
                QueueCommitBlockTask = async () =>
                        await commitBlockTask(
                            jobPart._cancellationTokenSource.Token).ConfigureAwait(false),
                ReportProgressInBytes = (long bytesWritten) =>
                    jobPart.ReportBytesWritten(bytesWritten),
                InvokeFailedHandler = async (ex) => await jobPart.InvokeFailedArg(ex).ConfigureAwait(false),
                UpdateTransferStatus = async (status)
                    => await jobPart.OnTransferStatusChanged(status).ConfigureAwait(false)
            };
        }
        #endregion

        internal async Task SingleSyncCopyInternal(long length)
        {
            try
            {
                await OnTransferStatusChanged(StorageTransferStatus.InProgress).ConfigureAwait(false);

                await _destinationResource.CopyFromUriAsync(
                    _sourceResource.Uri,
                    default, // TODO: change to respective options if necessary
                    _cancellationTokenSource.Token).ConfigureAwait(false);

                ReportBytesWritten(length);
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
                    await PutBlockFromUri(
                        block.Offset,
                        block.Length).ConfigureAwait(false)).ConfigureAwait(false);
            }
        }

        internal async Task PutBlockFromUri(
            long offset,
            long blockLength)
        {
            try
            {
                await _destinationResource.CopyBlockFromUriAsync(
                    sourceUri: _sourceResource.Uri,
                    range: new HttpRange(offset, blockLength),
                    cancellationToken: _cancellationTokenSource.Token).ConfigureAwait(false);
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
            long blockLength = acceptableBlockSize;

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
    }
}
