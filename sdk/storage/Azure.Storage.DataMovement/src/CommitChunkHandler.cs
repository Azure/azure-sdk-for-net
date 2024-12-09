// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Threading;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    internal class CommitChunkHandler : IDisposable
    {
        #region Delegate Definitions
        public delegate Task QueuePutBlockTaskInternal(long offset, long blockSize, long expectedLength, StorageResourceItemProperties properties);
        public delegate Task QueueCommitBlockTaskInternal(StorageResourceItemProperties sourceProperties);
        public delegate void ReportProgressInBytes(long bytesWritten);
        public delegate Task InvokeFailedEventHandlerInternal(Exception ex);
        #endregion Delegate Definitions

        private readonly QueuePutBlockTaskInternal _queuePutBlockTask;
        private readonly QueueCommitBlockTaskInternal _queueCommitBlockTask;
        private readonly ReportProgressInBytes _reportProgressInBytes;
        private readonly InvokeFailedEventHandlerInternal _invokeFailedEventHandler;

        public struct Behaviors
        {
            public QueuePutBlockTaskInternal QueuePutBlockTask { get; set; }
            public QueueCommitBlockTaskInternal QueueCommitBlockTask { get; set; }
            public ReportProgressInBytes ReportProgressInBytes { get; set; }
            public InvokeFailedEventHandlerInternal InvokeFailedHandler { get; set; }
        }

        /// <summary>
        /// Create channel of <see cref="QueueStageChunkArgs"/> to keep track of that are
        /// waiting to update the bytesTransferred and other required operations.
        /// </summary>
        private readonly IProcessor<QueueStageChunkArgs> _stageChunkProcessor;
        private readonly CancellationToken _cancellationToken;

        private long _bytesTransferred;
        private readonly long _expectedLength;
        private readonly long _blockSize;
        private readonly DataTransferOrder _transferOrder;
        private readonly StorageResourceItemProperties _sourceProperties;

        public CommitChunkHandler(
            long expectedLength,
            long blockSize,
            Behaviors behaviors,
            DataTransferOrder transferOrder,
            StorageResourceItemProperties sourceProperties,
            CancellationToken cancellationToken)
        {
            if (expectedLength <= 0)
            {
                throw Errors.InvalidExpectedLength(expectedLength);
            }
            Argument.AssertNotNull(behaviors, nameof(behaviors));

            _cancellationToken = cancellationToken;
            // Set bytes transferred to block size because we transferred the initial block
            _bytesTransferred = blockSize;
            _expectedLength = expectedLength;
            _blockSize = blockSize;
            _transferOrder = transferOrder;
            _sourceProperties = sourceProperties;

            _queuePutBlockTask = behaviors.QueuePutBlockTask
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueuePutBlockTask));
            _queueCommitBlockTask = behaviors.QueueCommitBlockTask
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueueCommitBlockTask));
            _reportProgressInBytes = behaviors.ReportProgressInBytes
                ?? throw Errors.ArgumentNull(nameof(behaviors.ReportProgressInBytes));
            _invokeFailedEventHandler = behaviors.InvokeFailedHandler
                ?? throw Errors.ArgumentNull(nameof(behaviors.InvokeFailedHandler));

            _stageChunkProcessor = ChannelProcessing.NewProcessor<QueueStageChunkArgs>(
                readers: 1,
                capacity: DataMovementConstants.Channels.StageChunkCapacity);
            _stageChunkProcessor.Process = ProcessCommitRange;
        }

        public void Dispose()
        {
            _stageChunkProcessor.TryComplete();
        }

        public async ValueTask QueueChunkAsync(QueueStageChunkArgs args)
        {
            await _stageChunkProcessor.QueueAsync(args).ConfigureAwait(false);
        }

        private async Task ProcessCommitRange(QueueStageChunkArgs args, CancellationToken cancellationToken = default)
        {
            try
            {
                _bytesTransferred += args.BytesTransferred;
                _reportProgressInBytes(args.BytesTransferred);

                if (_bytesTransferred == _expectedLength)
                {
                    // Add CommitBlockList task to the channel
                    await _queueCommitBlockTask(_sourceProperties).ConfigureAwait(false);
                }
                else if (_bytesTransferred < _expectedLength)
                {
                    // If this is a sequential transfer, we need to queue the next chunk
                    if (_transferOrder == DataTransferOrder.Sequential)
                    {
                        long newOffset = args.Offset + _blockSize;
                        long blockLength = (newOffset + _blockSize < _expectedLength) ?
                                            _blockSize :
                                            _expectedLength - newOffset;
                        await _queuePutBlockTask(
                            newOffset,
                            blockLength,
                            _expectedLength,
                            _sourceProperties).ConfigureAwait(false);
                    }
                }
                else  // _bytesTransferred > _expectedLength
                {
                    throw Errors.MismatchLengthTransferred(
                        expectedLength: _expectedLength,
                        actualLength: _bytesTransferred);
                }
            }
            catch (Exception ex)
            {
                await _invokeFailedEventHandler(ex).ConfigureAwait(false);
            }
        }
    }
}
