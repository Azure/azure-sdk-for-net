// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    internal class DownloadChunkHandler : IDisposable
    {
        #region Delegate Definitions
        public delegate Task CopyToDestinationFileInternal(long offset, long length, Stream stream, long expectedLength);
        public delegate void ReportProgressInBytes(long bytesWritten);
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
        /// Create channel of <see cref="QueueDownloadChunkArgs"/> to keep track to handle
        /// writing downloaded chunks to the destination as well as tracking overall progress.
        /// </summary>
        private readonly Channel<QueueDownloadChunkArgs> _downloadRangeChannel;
        private readonly Task _processDownloadRangeEvents;
        private readonly CancellationToken _cancellationToken;

        private long _bytesTransferred;
        private readonly long _expectedLength;

        /// <summary>
        /// List that holds all ranges of chunks to process.
        /// </summary>
        private readonly IList<HttpRange> _ranges;
        /// <summary>
        /// Holds which range we are currently waiting on to download.
        /// </summary>
        private int _currentRangeIndex;

        /// <summary>
        /// If any download chunks come in early before the chunk before it
        /// to copy to the file, let's hold it in order here before we copy it over.
        /// </summary>
        private readonly Dictionary<long, Stream> _pendingChunks;

        /// <summary>
        /// The controller for downloading the chunks to each file.
        /// </summary>
        /// <param name="currentTransferred">
        /// The amount of data that has already been transferred in bytes.
        /// </param>
        /// <param name="expectedLength">
        /// The expected length of the content to be downloaded in bytes.
        /// </param>
        /// <param name="ranges">
        /// List that holds the expected ranges the chunk ranges will come back as.
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
            IList<HttpRange> ranges,
            Behaviors behaviors,
            CancellationToken cancellationToken)
        {
            // Set bytes transferred to the length of bytes we got back from the initial
            // download request
            _bytesTransferred = currentTransferred;
            _currentRangeIndex = 0;

            // The size of the channel should never exceed 50k (limit on blocks in a block blob).
            // and that's in the worst case that we never read from the channel and had a maximum chunk blob.
            _downloadRangeChannel = Channel.CreateUnbounded<QueueDownloadChunkArgs>(
                new UnboundedChannelOptions()
                {
                    // Single reader is required as we can only have one writer to the destination.
                    SingleReader = true,
                });
            _processDownloadRangeEvents = Task.Run(NotifyOfPendingChunkDownloadEvents);
            _cancellationToken = cancellationToken;

            _expectedLength = expectedLength;
            _ranges = ranges;
            _pendingChunks = new();

            if (expectedLength <= 0)
            {
                throw Errors.InvalidExpectedLength(expectedLength);
            }
            Argument.AssertNotNullOrEmpty(ranges, nameof(ranges));
            Argument.AssertNotNull(behaviors, nameof(behaviors));

            // Set values
            _copyToDestinationFile = behaviors.CopyToDestinationFile
                ?? throw Errors.ArgumentNull(nameof(behaviors.CopyToDestinationFile));
            _reportProgressInBytes = behaviors.ReportProgressInBytes
                ?? throw Errors.ArgumentNull(nameof(behaviors.ReportProgressInBytes));
            _invokeFailedEventHandler = behaviors.InvokeFailedHandler
                ?? throw Errors.ArgumentNull(nameof(behaviors.InvokeFailedHandler));
            _queueCompleteFileDownload = behaviors.QueueCompleteFileDownload
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueueCompleteFileDownload));
        }

        public void Dispose()
        {
            foreach (Stream chunkStream in _pendingChunks.Values)
            {
                chunkStream.Dispose();
            }
            _pendingChunks.Clear();
            _downloadRangeChannel.Writer.TryComplete();
        }

        public void QueueChunk(QueueDownloadChunkArgs args)
        {
            _downloadRangeChannel.Writer.TryWrite(args);
        }

        private async Task NotifyOfPendingChunkDownloadEvents()
        {
            try
            {
                while (await _downloadRangeChannel.Reader.WaitToReadAsync(_cancellationToken).ConfigureAwait(false))
                {
                    // Read one event argument at a time.
                    QueueDownloadChunkArgs args = await _downloadRangeChannel.Reader.ReadAsync(_cancellationToken).ConfigureAwait(false);
                    long currentRangeOffset = _ranges[_currentRangeIndex].Offset;
                    if (currentRangeOffset < args.Offset)
                    {
                        // Early chunk, add to pending
                        _pendingChunks.Add(args.Offset, args.Result);
                    }
                    else if (currentRangeOffset == args.Offset)
                    {
                        // Copy the current chunk to the destination
                        using (Stream content = args.Result)
                        {
                            await _copyToDestinationFile(
                                args.Offset,
                                args.Length,
                                content,
                                _expectedLength).ConfigureAwait(false);
                        }
                        UpdateBytesAndRange(args.Length);

                        // Check if the next chunks are already downloaeded and copy those
                        await AppendPendingChunks().ConfigureAwait(false);

                        // Check if we finished downloading the blob
                        if (_bytesTransferred == _expectedLength)
                        {
                            await _queueCompleteFileDownload().ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        // We should never reach this point because that means
                        // the range that came back was less than the next range that is supposed
                        // to be copied to the file
                        throw Errors.InvalidDownloadOffset(args.Offset, args.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                // This will trigger the job part to call Dispose on this object
                await _invokeFailedEventHandler(ex).ConfigureAwait(false);
            }
        }

        private async Task AppendPendingChunks()
        {
            while (_currentRangeIndex < _ranges.Count &&
                _pendingChunks.ContainsKey(_ranges[_currentRangeIndex].Offset))
            {
                HttpRange currentRange = _ranges[_currentRangeIndex];
                using (Stream nextChunk = _pendingChunks[currentRange.Offset])
                {
                    await _copyToDestinationFile(
                        currentRange.Offset,
                        currentRange.Length.Value,
                        nextChunk,
                        _expectedLength).ConfigureAwait(false);
                }
                _pendingChunks.Remove(currentRange.Offset);
                UpdateBytesAndRange((long)currentRange.Length);
            }
        }

        /// <summary>
        /// Moves the downloader to the next range and updates/reports bytes transferred.
        /// </summary>
        /// <param name="bytesDownloaded"></param>
        private void UpdateBytesAndRange(long bytesDownloaded)
        {
            _currentRangeIndex++;
            _bytesTransferred += bytesDownloaded;
            _reportProgressInBytes(bytesDownloaded);
        }
    }
}
