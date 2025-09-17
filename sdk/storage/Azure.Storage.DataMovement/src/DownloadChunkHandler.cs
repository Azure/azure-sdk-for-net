// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    internal class DownloadChunkHandler
    {
        #region Delegate Definitions
        public delegate Task CopyToDestinationFileInternal(long offset, long length, Stream stream, long expectedLength, bool initial);
        public delegate ValueTask ReportProgressInBytes(long bytesWritten);
        public delegate Task QueueCompleteFileDownloadInternal();
        public delegate Task InvokeFailedEventHandlerInternal(Exception ex);
        #endregion Delegate Definitions

        private readonly CopyToDestinationFileInternal _copyToDestinationFile;
        private readonly ReportProgressInBytes _reportProgressInBytes;
        private readonly InvokeFailedEventHandlerInternal _invokeFailedEventHandler;
        private readonly QueueCompleteFileDownloadInternal _queueCompleteFileDownload;

        public struct Behaviors
        {
            public CopyToDestinationFileInternal CopyToDestinationFile { get; set; }
            public ReportProgressInBytes ReportProgressInBytes { get; set; }
            public InvokeFailedEventHandlerInternal InvokeFailedHandler { get; set; }
            public QueueCompleteFileDownloadInternal QueueCompleteFileDownload { get; set; }
        }

        /// <summary>
        /// Create channel of <see cref="QueueDownloadChunkArgs"/> to handle writing
        /// downloaded chunks to the destination as well as tracking overall progress.
        /// </summary>
        private readonly IProcessor<QueueDownloadChunkArgs> _downloadRangeProcessor;
        private readonly CancellationToken _cancellationToken;

        private long _bytesTransferred;
        private readonly long _expectedLength;

        internal bool _isChunkHandlerRunning;

        /// <summary>
        /// The controller for downloading the chunks to each file.
        /// </summary>
        /// <param name="currentTransferred">
        /// The amount of data that has already been transferred in bytes.
        /// </param>
        /// <param name="expectedLength">
        /// The expected length of the content to be downloaded in bytes.
        /// </param>
        /// <param name="behaviors">
        /// Contains all the supported function calls.
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation token of the job part or job to cancel any ongoing waiting in the
        /// download chunk handler to prevent infinite waiting.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        public DownloadChunkHandler(
            long currentTransferred,
            long expectedLength,
            Behaviors behaviors,
            CancellationToken cancellationToken)
        {
            if (expectedLength <= 0)
            {
                throw Errors.InvalidExpectedLength(expectedLength);
            }
            Argument.AssertNotNull(behaviors, nameof(behaviors));

            _cancellationToken = cancellationToken;
            // Set bytes transferred to the length of bytes we got back from the initial
            // download request
            _bytesTransferred = currentTransferred;
            _expectedLength = expectedLength;

            _copyToDestinationFile = behaviors.CopyToDestinationFile
                ?? throw Errors.ArgumentNull(nameof(behaviors.CopyToDestinationFile));
            _reportProgressInBytes = behaviors.ReportProgressInBytes
                ?? throw Errors.ArgumentNull(nameof(behaviors.ReportProgressInBytes));
            _invokeFailedEventHandler = behaviors.InvokeFailedHandler
                ?? throw Errors.ArgumentNull(nameof(behaviors.InvokeFailedHandler));
            _queueCompleteFileDownload = behaviors.QueueCompleteFileDownload
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueueCompleteFileDownload));

            _downloadRangeProcessor = ChannelProcessing.NewProcessor<QueueDownloadChunkArgs>(
                readers: 1,
                capacity: DataMovementConstants.Channels.DownloadChunkCapacity);
            _downloadRangeProcessor.Process = ProcessDownloadRange;
            _isChunkHandlerRunning = true;
        }

        public async ValueTask TryCompleteAsync()
        {
            _isChunkHandlerRunning = false;
            await _downloadRangeProcessor.TryCompleteAsync().ConfigureAwait(false);
        }

        public async ValueTask QueueChunkAsync(QueueDownloadChunkArgs args, CancellationToken cancellationToken = default)
        {
            await _downloadRangeProcessor.QueueAsync(args, cancellationToken).ConfigureAwait(false);
        }

        private async Task ProcessDownloadRange(QueueDownloadChunkArgs args)
        {
            try
            {
                // Copy the current chunk to the destination
                using (Stream content = args.Content)
                {
                    await _copyToDestinationFile(
                        args.Offset,
                        args.Length,
                        content,
                        _expectedLength,
                        initial: _bytesTransferred == 0).ConfigureAwait(false);
                }
                _bytesTransferred += args.Length;
                await _reportProgressInBytes(args.Length).ConfigureAwait(false);

                // Check if we finished downloading the blob
                if (_bytesTransferred == _expectedLength)
                {
                    await _queueCompleteFileDownload().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                // If we are disposing, we don't want to invoke the failed event handler
                // because the error is likely due to the job part being disposed and was
                // invoked by another InvokeFailedEventHandler call.
                if (_isChunkHandlerRunning)
                {
                    // This will trigger the job part to call Dispose on this object
                    _ = Task.Run(() => _invokeFailedEventHandler(ex));
                }
            }
        }
    }
}
