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
        private int _rangesCount;
        /// <summary>
        /// Holds which range we are currently waiting on to download.
        /// </summary>
        private int _currentRangeIndex;

        /// <summary>
        /// If any download chunks come in early before the chunk before it
        /// to copy to the file, let's hold it in order here before we copy it over.
        /// </summary>
        private ConcurrentDictionary<long, string> _rangesCompleted;

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

            // Set bytes transferred to the length of bytes we got back from the initial
            // download request
            _bytesTransferred = currentTransferred;
            _currentRangeIndex = 0;
            _rangesCount = ranges.Count;
            // Set size of the list of null streams
            _rangesCompleted = new ConcurrentDictionary<long, string>();

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
                        // One of the chunks finished downloading before the chunk(s)
                        // before it (early bird, or the last chunk)
                        // Save the chunk to a temporary file to append later
                        string chunkFilePath = Path.GetTempFileName();
                        using (Stream chunkContent = args.Result)
                        {
                            await _copyToChunkFile(chunkFilePath, chunkContent).ConfigureAwait(false);
                        }
                        if (!_rangesCompleted.TryAdd(args.Offset, chunkFilePath))
                        {
                            // Throw an error here that we were unable to idenity the
                            // the range that has come back to us. We should never see this error
                            // since we were the ones who calculated the range.
                            throw Errors.InvalidDownloadOffset(args.Offset, args.BytesTransferred);
                        }
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
                                args.BytesTransferred,
                                content,
                                _expectedLength).ConfigureAwait(false);
                        }
                        UpdateBytesAndRange(args.BytesTransferred);

                        await AppendEarlyChunksToFile().ConfigureAwait(false);

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
                        throw Errors.InvalidDownloadOffset(args.Offset, args.BytesTransferred);
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

        private async Task AppendEarlyChunksToFile()
        {
            // If there are any other chunks that have already been downloaded that
            // can be appended to the file, let's do it now.
            while ((_bytesTransferred < _expectedLength) &&
                    (_currentRangeIndex < _rangesCount) &&
                    _rangesCompleted.ContainsKey(_ranges[_currentRangeIndex].Offset))
            {
                HttpRange currentRange = _ranges[_currentRangeIndex];
                if (_rangesCompleted.TryRemove(currentRange.Offset, out string chunkFilePath))
                {
                    if (File.Exists(chunkFilePath))
                    {
                        using (Stream content = File.OpenRead(chunkFilePath))
                        {
                            await _copyToDestinationFile(
                                currentRange.Offset,
                                currentRange.Length.Value,
                                content,
                                _expectedLength).ConfigureAwait(false);
                        }
                        // Delete the temporary chunk file that's no longer needed
                        File.Delete(chunkFilePath);
                    }
                    else
                    {
                        throw Errors.TempChunkFileNotFound(
                            offset: currentRange.Offset,
                            length: currentRange.Length.Value,
                            filePath: chunkFilePath);
                    }
                }
                else
                {
                    throw Errors.InvalidDownloadOffset(currentRange.Offset, currentRange.Length.Value);
                }

                // Increment the current range we are expect, if it's null then
                // that's the next one we have to wait on.
                UpdateBytesAndRange((long)_ranges[_currentRangeIndex].Length);
            }
        }

        private async Task InvokeFailedEvent(Exception ex)
        {
            foreach (HttpRange range in _ranges)
            {
                if (_rangesCompleted.TryRemove(range.Offset, out string tempChunkFile))
                {
                    if (File.Exists(tempChunkFile))
                    {
                        try
                        {
                            File.Delete(tempChunkFile);
                        }
                        catch (Exception deleteException)
                        {
                            await _invokeFailedEventHandler(deleteException).ConfigureAwait(false);
                        }
                    }
                }
            }
            await _invokeFailedEventHandler(ex).ConfigureAwait(false);
        }

        /// <summary>
        /// Update the progress handler and the current range we are waiting on.
        /// </summary>
        /// <param name="bytesDownloaded"></param>
        private void UpdateBytesAndRange(long bytesDownloaded)
        {
            Interlocked.Add(ref _bytesTransferred, bytesDownloaded);
            Interlocked.Increment(ref _currentRangeIndex);
            _reportProgressInBytes(bytesDownloaded);
        }
    }
}
