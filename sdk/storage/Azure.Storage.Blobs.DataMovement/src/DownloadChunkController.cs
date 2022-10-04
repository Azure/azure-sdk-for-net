// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class DownloadChunkController
    {
        #region Delegate Definitions
        public delegate Task CopyToDestinationFileInternal(Stream stream);
        public delegate Task CopyToChunkFileInternal(string chunkFilePath, Stream stream);
        public delegate Task QueueCompleteFileDownloadInternal();
        public delegate Task InvokeFailedEventHandlerInternal(Exception ex);
        #endregion Delegate Definitions

        private readonly CopyToDestinationFileInternal _copyToDestinationFile;
        private readonly CopyToChunkFileInternal _copyToChunkFile;
        private readonly InvokeFailedEventHandlerInternal _invokeFailedEventHandler;
        private readonly QueueCompleteFileDownloadInternal _queueCompleteFileDownload;

        public struct Behaviors
        {
            public CopyToDestinationFileInternal CopyToDestinationFile { get; set; }

            public CopyToChunkFileInternal CopyToChunkFile { get; set; }
            public InvokeFailedEventHandlerInternal InvokeFailedHandler { get; set; }

            public QueueCompleteFileDownloadInternal QueueCompleteFileDownload { get; set; }
        }

        private event SyncAsyncEventHandler<BlobDownloadRangeEventArgs> _downloadChunkEventHandler;
        internal SyncAsyncEventHandler<BlobDownloadRangeEventArgs> GetDownloadChunkHandler() => _downloadChunkEventHandler;

        /// <summary>
        /// Progress handle can be null if the user does not specify
        /// </summary>
        private readonly IProgress<long>  _progressHandler;

        private long _bytesTransferred;
        private long _expectedLength;

        /// <summary>
        /// Holds all ranges
        /// </summary>
        private readonly IList<HttpRange> _ranges;
        private int _rangesCount;
        /// <summary>
        /// To hold which Range we are currently waiting on to download
        /// </summary>
        private int _currentRangeIndex;

        /// <summary>
        /// If any download chunks come in early before the chunk before it
        /// to copy to the file, let's hold it in order here before we copy it over
        /// </summary>
        private ConcurrentDictionary<long, string> _rangesCompleted;
        private CancellationToken _cancellationToken;

        /// <summary>
        /// Constructing controller for downloading the chunks to each file
        /// </summary>
        /// <param name="currentTransferred">
        /// The initial amount of bytes that have already been transferred
        /// </param>
        /// <param name="expectedLength">
        /// Expected Bytes Length.
        /// </param>
        /// <param name="ranges">
        /// Expected ranges the chunk ranges will come back as
        /// </param>
        /// <param name="behaviors">
        /// Function calls
        /// </param>
        /// <param name="progressHandler">
        /// Progress Handler
        /// </param>
        /// <param name="cancellationToken">
        /// Cancellation Token
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        public DownloadChunkController(
            long currentTransferred,
            long expectedLength,
            IList<HttpRange> ranges,
            Behaviors behaviors,
            IProgress<long> progressHandler,
            CancellationToken cancellationToken)
        {
            if (expectedLength <= 0)
                throw new ArgumentException("Cannot initiate Commit Block List function with File that has a negative or zero length");
            Argument.AssertNotNullOrEmpty(ranges, nameof(ranges));
            Argument.AssertNotNull(behaviors, nameof(behaviors));

            // Set values
            _copyToDestinationFile = behaviors.CopyToDestinationFile
                ?? throw Errors.ArgumentNull(nameof(behaviors.CopyToDestinationFile));
            _copyToChunkFile = behaviors.CopyToChunkFile
                ?? throw Errors.ArgumentNull(nameof(behaviors.CopyToChunkFile));
            _invokeFailedEventHandler = behaviors.InvokeFailedHandler
                ?? throw Errors.ArgumentNull(nameof(behaviors.InvokeFailedHandler));
            _queueCompleteFileDownload = behaviors.QueueCompleteFileDownload
                ?? throw Errors.ArgumentNull(nameof(behaviors.QueueCompleteFileDownload));
            _progressHandler = progressHandler;
            _cancellationToken = cancellationToken;
            _expectedLength = expectedLength;
            _ranges = ranges;

            // Set bytes transferred to the length of bytes we got back from the initial
            // download request
            _bytesTransferred = currentTransferred;
            _currentRangeIndex = 0;
            _rangesCount = ranges.Count;
            // Set size of the list of null streams
            _rangesCompleted = new ConcurrentDictionary<long, string>();

            AddDownloadChunkEvent();
        }

        public void AddDownloadChunkEvent()
        {
            _downloadChunkEventHandler += async (BlobDownloadRangeEventArgs args) =>
            {
                if (args.Success && !_cancellationToken.IsCancellationRequested)
                {
                    long currentRangeOffset = _ranges[_currentRangeIndex].Offset;
                    if (currentRangeOffset < args.Offset)
                    {
                        // One of the chunks finished downloading before the chunk(s)
                        // before it (early bird, or the last chunk)
                        // Save the chunk to a temporary file to append later
                        string chunkFilePath = Path.GetTempFileName();
                        using (Stream chunkContent = args.Result.Content)
                        {
                            await _copyToChunkFile(chunkFilePath, chunkContent).ConfigureAwait(false);
                        }
                        if (!_rangesCompleted.TryAdd(args.Offset, chunkFilePath))
                        {
                            // Throw an error here that we were unable to idenity the
                            // the range that has come back to us. We should never see this error
                            // since we were the ones who calculated the range.
                            await InvokeFailedEvent(
                                new ArgumentOutOfRangeException(
                                    nameof(args.Offset),
                                    args.Offset,
                                    $"Cannot find offset returned by Successful Download Range" +
                                    $"in the expected Ranges: \"{args.Offset}\""))
                            .ConfigureAwait(false);
                        }
                    }
                    else if (currentRangeOffset == args.Offset)
                    {
                        // Start Copying the response to the file stream and any other chunks after
                        // Most of the time we will always get the next chunk first so the loop
                        // on averages runs once.
                        using (Stream content = args.Result.Content)
                        {
                            await _copyToDestinationFile(content).ConfigureAwait(false);
                        }
                        UpdateBytesAndRange(args.BytesTransferred);

                        await AppendEarlyChunksToFile().ConfigureAwait(false);

                        // Check if we finished downloading the blob
                        if (_bytesTransferred == _expectedLength)
                        {
                            // TODO: update progress handler, flush file
                            await _queueCompleteFileDownload().ConfigureAwait(false);
                        }
                    }
                    else
                    {
                        // We should never reach this point because that means
                        // the range that came back was less than the next range that is supposed
                        // to be copied to the file
                        await InvokeFailedEvent(
                            new ArgumentOutOfRangeException(
                                nameof(args.Offset),
                                args.Offset,
                                $"Offset returned by Successful Download Range" +
                                $"was not in the expected Ranges: \"{args.Offset}\""))
                        .ConfigureAwait(false);
                    }
                }
            };
        }

        public void AddEvent(SyncAsyncEventHandler<BlobDownloadRangeEventArgs> stageBlockEvent)
        {
            _downloadChunkEventHandler += stageBlockEvent;
        }

        public async Task InvokeEvent(BlobDownloadRangeEventArgs args)
        {
            await _downloadChunkEventHandler.Invoke(args).ConfigureAwait(false);
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
                    try
                    {
                        if (File.Exists(chunkFilePath))
                        {
                            using (Stream content = File.OpenRead(chunkFilePath))
                            {
                                await _copyToDestinationFile(content).ConfigureAwait(false);
                            }
                            // Delete the temporary chunk file that's no longer needed
                            File.Delete(chunkFilePath);
                        }
                        else
                        {
                            await InvokeFailedEvent(new FileNotFoundException(
                                $"Could not append chunk to destination file at Offset: " +
                                $"\"{currentRange.Offset}\" and Length: \"{currentRange.Length}\"," +
                                $"due to the chunk file missing: \"{chunkFilePath}\"")).ConfigureAwait(false);
                        }
                    }
                    catch
                    {
                        await InvokeFailedEvent(new Exception(
                            $"Could not append chunk to destination file at Offset: " +
                            $"\"{currentRange.Offset}\" and Length: \"{currentRange.Length}\""))
                            .ConfigureAwait(false);
                    }
                }
                else
                {
                    await InvokeFailedEvent(new ArgumentOutOfRangeException(
                        "Offset",
                        currentRange,
                        $"Cannot find offset returned by Successful Download Range at Offset: " +
                        $"\"{currentRange.Offset}\" and Length: \"{currentRange.Length}\""))
                        .ConfigureAwait(false);
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
                        File.Delete(tempChunkFile);
                    }
                }
            }
            await _invokeFailedEventHandler(ex).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates Progress handler and the current Range we are waiting on
        /// </summary>
        /// <param name="bytesDownloaded"></param>
        private void UpdateBytesAndRange(long bytesDownloaded)
        {
            Interlocked.Add(ref _bytesTransferred, bytesDownloaded);
            _progressHandler?.Report(_bytesTransferred);
            Interlocked.Increment(ref _currentRangeIndex);
        }
    }
}
