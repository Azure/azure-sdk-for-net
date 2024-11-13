// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Common;

namespace Azure.Storage.DataMovement
{
    internal class DownloadChunkHandler : IDisposable
    {
        // Indicates whether the current thread is processing stage chunks.
        private static Task _processDownloadRangeEvents;

        #region Delegate Definitions
        public delegate Task CopyToDestinationFileInternal(long offset, long length, Stream stream, long expectedLength);
        public delegate Task CopyToChunkFileInternal(string chunkFilePath, Stream stream);
        public delegate void ReportProgressInBytes(long bytesWritten);
        public delegate Task QueueCompleteFileDownloadInternal();
        public delegate Task InvokeFailedEventHandlerInternal(Exception ex);
        #endregion Delegate Definitions

        private readonly CopyToDestinationFileInternal _copyToDestinationFile;
        private readonly CopyToChunkFileInternal _copyToChunkFile;
        private readonly ReportProgressInBytes _reportProgressInBytes;
        private readonly InvokeFailedEventHandlerInternal _invokeFailedEventHandler;
        private readonly QueueCompleteFileDownloadInternal _queueCompleteFileDownload;

        public struct Behaviors
        {
            public CopyToDestinationFileInternal CopyToDestinationFile { get; set; }

            public CopyToChunkFileInternal CopyToChunkFile { get; set; }
            public ReportProgressInBytes ReportProgressInBytes { get; set; }

            public InvokeFailedEventHandlerInternal InvokeFailedHandler { get; set; }

            public QueueCompleteFileDownloadInternal QueueCompleteFileDownload { get; set; }
        }

        private event SyncAsyncEventHandler<DownloadRangeEventArgs> _downloadChunkEventHandler;
        internal SyncAsyncEventHandler<DownloadRangeEventArgs> GetDownloadChunkHandler() => _downloadChunkEventHandler;

        /// <summary>
        /// Create channel of <see cref="DownloadRangeEventArgs"/> to keep track of that are
        /// waiting to update the bytesTransferred and other required operations.
        /// </summary>
        private readonly Channel<DownloadRangeEventArgs> _downloadRangeChannel;
        private CancellationToken _cancellationToken;

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
        private Dictionary<long, Stream> _pendingChunks;

        internal ClientDiagnostics ClientDiagnostics { get; }

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
        /// <param name="clientDiagnostics">
        /// ClientDiagnostics for handler logging.
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
            ClientDiagnostics clientDiagnostics,
            CancellationToken cancellationToken)
        {
            // Set bytes transferred to the length of bytes we got back from the initial
            // download request
            _bytesTransferred = currentTransferred;
            _currentRangeIndex = 0;

            // Create channel of finished Stage Chunk Args to update the bytesTransferred
            // and for ending tasks like commit block.
            // The size of the channel should never exceed 50k (limit on blocks in a block blob).
            // and that's in the worst case that we never read from the channel and had a maximum chunk blob.
            _downloadRangeChannel = Channel.CreateUnbounded<DownloadRangeEventArgs>(
                new UnboundedChannelOptions()
                {
                    // Single reader is required as we can only read and write to bytesTransferred value
                    SingleReader = true,
                });
            _processDownloadRangeEvents = Task.Run(() => NotifyOfPendingChunkDownloadEvents());
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
            Argument.AssertNotNull(clientDiagnostics, nameof(clientDiagnostics));

            // Set values
            _copyToDestinationFile = behaviors.CopyToDestinationFile
                ?? throw Errors.ArgumentNull(nameof(behaviors.CopyToDestinationFile));
            _copyToChunkFile = behaviors.CopyToChunkFile
                ?? throw Errors.ArgumentNull(nameof(behaviors.CopyToChunkFile));
            _reportProgressInBytes = behaviors.ReportProgressInBytes
                ?? throw Errors.ArgumentNull(nameof(behaviors.ReportProgressInBytes));
            _invokeFailedEventHandler = behaviors.InvokeFailedHandler
                ?? throw Errors.ArgumentNull(nameof(behaviors.InvokeFailedHandler));
            _queueCompleteFileDownload = behaviors.QueueCompleteFileDownload
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueueCompleteFileDownload));

            _downloadChunkEventHandler += DownloadChunkEvent;
            ClientDiagnostics = clientDiagnostics;
        }

        public void Dispose()
        {
            _downloadRangeChannel.Writer.TryComplete();
            DisposeHandlers();
        }

        private void DisposeHandlers()
        {
            _downloadChunkEventHandler -= DownloadChunkEvent;
        }

        private async Task DownloadChunkEvent(DownloadRangeEventArgs args)
        {
            try
            {
                if (args.Success)
                {
                    _downloadRangeChannel.Writer.TryWrite(args);
                }
                else
                {
                    // Report back failed event.
                    throw args.Exception;
                }
            }
            catch (Exception ex)
            {
                await InvokeFailedEvent(ex).ConfigureAwait(false);
            }
        }

        private async Task NotifyOfPendingChunkDownloadEvents()
        {
            try
            {
                while (await _downloadRangeChannel.Reader.WaitToReadAsync(_cancellationToken).ConfigureAwait(false))
                {
                    // Read one event argument at a time.
                    DownloadRangeEventArgs args = await _downloadRangeChannel.Reader.ReadAsync(_cancellationToken).ConfigureAwait(false);
                    long currentRangeOffset = _ranges[_currentRangeIndex].Offset;
                    if (currentRangeOffset < args.Offset)
                    {
                        // Early chunk, add to pending
                        _pendingChunks.Add(args.Offset, args.Result);
                    }
                    else if (currentRangeOffset == args.Offset)
                    {
                        // Start Copying the response to the file stream and any other chunks after
                        // Most of the time we will always get the next chunk first so the loop
                        // on averages runs once.
                        using (Stream content = args.Result)
                        {
                            await _copyToDestinationFile(
                                args.Offset,
                                args.Length,
                                content,
                                _expectedLength).ConfigureAwait(false);
                        }
                        UpdateBytesAndRange(args.Length);

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
                await InvokeFailedEvent(ex).ConfigureAwait(false);
            }
        }

        public async Task InvokeEvent(DownloadRangeEventArgs args)
        {
            // There's a race condition where the event handler was disposed and an event
            // was already invoked, we should skip over this as the download chunk handler
            // was already disposed, and we should just ignore any more incoming events.
            if (_downloadChunkEventHandler != null)
            {
                await _downloadChunkEventHandler.RaiseAsync(
                    args,
                    nameof(DownloadChunkHandler),
                    nameof(_downloadChunkEventHandler),
                    ClientDiagnostics)
                    .ConfigureAwait(false);
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

        private async Task InvokeFailedEvent(Exception ex)
        {
            foreach (Stream chunkStream in _pendingChunks.Values)
            {
                chunkStream.Dispose();
            }
            _pendingChunks.Clear();
            await _invokeFailedEventHandler(ex).ConfigureAwait(false);
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
