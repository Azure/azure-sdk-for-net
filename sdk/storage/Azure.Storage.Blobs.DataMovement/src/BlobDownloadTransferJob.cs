// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement;
using Azure.Storage.Blobs;
using Azure.Core;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class BlobDownloadTransferJob : BlobTransferJobInternal
    {
        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration SourceBlobConfiguration;

        /// <summary>
        /// The source blob client. This client contains the information and methods required to perform
        /// the download from the source blob.
        /// </summary>
        internal BlobBaseClient SourceBlobClient;

        /// <summary>
        /// The local path which will store the contents of the blob to be downloaded.
        /// </summary>
        internal string _destinationLocalPath;

        /// <summary>
        /// Gets the local path which will store the contents of the blob to be downloaded.
        /// </summary>
        public string DestinationLocalPath => _destinationLocalPath;

        /// <summary>
        /// The <see cref="BlobDownloadToOptions"/>.
        /// </summary>
        internal BlobSingleDownloadOptions _options;

        /// <summary>
        /// Gets the <see cref="BlobDownloadToOptions"/>.
        /// </summary>
        public BlobSingleDownloadOptions Options => _options;

        private ClientDiagnostics _diagnostics;

        /// <summary>
        /// Client Diagnostics
        /// </summary>
        public ClientDiagnostics Diagnostics => _diagnostics;

        /// <summary>
        /// Internal Download Chunk Controller that manages when the chunks
        /// have completed and writes to the file
        /// </summary>
        internal DownloadChunkController _downloadChunkController;

        /// <summary>
        /// Constructor. Creates Single Blob Download Job.
        ///
        /// TODO: better description, also for parameters.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceClient">
        /// Source Blob to download.
        /// </param>
        /// <param name="destinationPath">
        /// Local Path to download the blob to.
        /// </param>
        /// <param name="options">
        /// Transfer Options for the specific download job.
        /// See <see cref="StorageTransferOptions"/>.
        /// </param>
        /// <param name="errorOption">
        /// Error Options
        /// </param>
        /// <param name="queueChunkTask">
        /// </param>
        public BlobDownloadTransferJob(
            string transferId,
            BlobBaseClient sourceClient,
            string destinationPath,
            BlobSingleDownloadOptions options,
            ErrorHandlingOptions errorOption,
            QueueChunkTaskInternal queueChunkTask)
            : base(transferId: transferId,
                  errorHandling: errorOption,
                  queueChunkTask: queueChunkTask)
        {
            SourceBlobConfiguration = new BlobBaseConfiguration()
            {
                Uri = sourceClient.Uri,
                AccountName = sourceClient.AccountName,
            };
            SourceBlobClient = sourceClient;
            _destinationLocalPath = destinationPath;
            _options = options;
            _diagnostics = new ClientDiagnostics(BlobBaseClientInternals.GetClientOptions(sourceClient));
        }

        /// <summary>
        /// Creates the next Transfer Chunk to process
        /// </summary>
        /// <returns></returns>
        public override async Task ProcessPartToChunkAsync()
        {
            // Attempt temporary download path
            if (await CreateDownloadFilePath().ConfigureAwait(false))
            {
                await InitiateDownload().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Translates job details
        /// </summary>
        public override BlobTransferJobProperties GetJobDetails()
        {
            return this.ToBlobTransferJobDetails();
        }

        /// <summary>
        /// Resumes respective job
        /// </summary>
        /// <param name="sourceCredential"></param>
        /// <param name="destinationCredential"></param>
        public override void ProcessResumeTransfer(
            object sourceCredential = default,
            object destinationCredential = default)
        {
            if (sourceCredential != default)
            {
                // Connection String
                if (sourceCredential.GetType() == typeof(string))
                {
                    string connectionString = (string)sourceCredential;
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(connectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceBlobClient.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        SourceBlobClient = new BlobBaseClient(
                            connectionString,
                            SourceBlobConfiguration.BlobContainerName,
                            SourceBlobConfiguration.Name,
                            BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                    }
                    else
                    {
                        // Mismatch in storage account host in the URL
                        throw Errors.InvalidConnectionString();
                    }
                }
                else if (sourceCredential.GetType() == typeof(AzureSasCredential))
                {
                    AzureSasCredential sasCredential = (AzureSasCredential)sourceCredential;
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        sasCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else if (sourceCredential.GetType() == typeof(StorageSharedKeyCredential))
                {
                    StorageSharedKeyCredential storageSharedKeyCredential = (StorageSharedKeyCredential)sourceCredential;
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        storageSharedKeyCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else if (sourceCredential.GetType() == typeof(TokenCredential))
                {
                    TokenCredential tokenCredential = (TokenCredential)sourceCredential;
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        tokenCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(sourceCredential));
                }
                TransferStatus = StorageTransferStatus.Queued;
            }
            TransferStatus = StorageTransferStatus.Queued;
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="transferStatus"></param>
        /// <param name="async"></param>
        /// <returns></returns>
        public async Task OnTransferStatusChanged(StorageTransferStatus transferStatus, bool async)
        {
            if (transferStatus != TransferStatus)
            {
                TransferStatus = transferStatus;
                if (async)
                {
                    if ((Options != null) &&
                        (Options?.GetTransferStatus() != null))
                    {
                        await Options.GetTransferStatus().RaiseAsync(
                                new StorageTransferStatusEventArgs(
                                    TransferId,
                                    transferStatus,
                                    true,
                                    CancellationTokenSource.Token),
                                nameof(BlobFolderUploadOptions),
                                nameof(BlobFolderUploadOptions.TransferStatusEventHandler),
                                Diagnostics).ConfigureAwait(false);
                    }
                }
                else
                {
                    if ((Options != null) &&
                        (Options?.GetTransferStatus() != null))
                    {
                        Options.GetTransferStatus()?.Invoke(new StorageTransferStatusEventArgs(
                                    TransferId,
                                    transferStatus,
                                    true,
                                    CancellationTokenSource.Token));
                    }
                }
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<BlobJobPartInternal> ProcessJobToJobPartAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            yield return new BlobDownloadPartInternal(this);
        }

        #region PartitionedDownloader
        /// <summary>
        /// Initializes the temporary file path for the blob to be downloaded to.
        /// </summary>
        private async Task<bool> CreateDownloadFilePath()
        {
            try
            {
                if (!File.Exists(DestinationLocalPath))
                {
                    File.Create(DestinationLocalPath).Close();
                    FileAttributes attributes = File.GetAttributes(DestinationLocalPath);
                    File.SetAttributes(DestinationLocalPath, attributes | FileAttributes.Temporary);
                    return true;
                }
                else
                {
                    // TODO: if there's an error handling enum to overwrite the file we have to check
                    // for that instead of throwing an error
                    Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                        TransferId,
                        SourceBlobClient,
                        DestinationLocalPath,
                        new IOException($"File path `{DestinationLocalPath}` already exists. Cannot overwite file"),
                        false,
                        CancellationTokenSource.Token));
                    await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                        TransferId,
                        SourceBlobClient,
                        DestinationLocalPath,
                        ex,
                        false,
                        CancellationTokenSource.Token));
                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            return false;
        }

        /// <summary>
        /// Just start downloading using an initial range.  If it's a
        /// small blob, we'll get the whole thing in one shot.  If it's
        /// a large blob, we'll get its full size in Content-Range and
        /// can keep downloading it in segments.
        ///
        /// After this response comes back and there's more to download
        /// then we will trigger more to download since we now know the
        /// content length.
        /// </summary>
        internal async Task InitiateDownload()
        {
            await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);

            // Set initial range size

            long initialRangeSize = Constants.Blob.Block.DefaultInitalDownloadRangeSize;
            if (Options.TransferOptions.InitialTransferSize.HasValue
                && Options.TransferOptions.InitialTransferSize.Value > 0)
            {
                // Custom initial range size
                initialRangeSize = _options.TransferOptions.InitialTransferSize.Value;
            }

            try
            {
                Task<Response<BlobDownloadStreamingResult>> initialResponseTask =
                    SourceBlobClient.DownloadStreamingAsync(
                        new HttpRange(0, initialRangeSize),
                        conditions: default, // TODO: Not accepting specific conditions currently.
                        rangeGetContentHash: default, // TODO: contentrangehash issue
                        default,
                        CancellationTokenSource.Token);

                Response<BlobDownloadStreamingResult> initialResponse = null;
                try
                {
                    initialResponse = await initialResponseTask.ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.InvalidRange)
                {
                    // Range not accepted, we need to attempt to use a default range
                    initialResponse = await SourceBlobClient.DownloadStreamingAsync(
                        range: default,
                        conditions: default,
                        rangeGetContentHash: default,
                        default,
                        CancellationTokenSource.Token)
                        .ConfigureAwait(false);
                }

                // If the initial request returned no content (i.e., a 304),
                // we'll pass that back to the user immediately
                if (initialResponse.IsUnavailable())
                {
                    // Invoke event handler and progress handler
                    return;
                }

                // Check if that was the entire blob, if so finish now.
                // If the first segment was the entire blob, we'll copy that to
                // the output stream and finish now
                long initialLength = initialResponse.Value.Details.ContentLength;
                long totalLength = ParseRangeTotalLength(initialResponse.Value.Details.ContentRange);
                if (initialLength == totalLength)
                {
                    // Complete download since it was done in one go
                    await CopyToStreamInternal(initialResponse.Value.Content).ConfigureAwait(false);
                    Options?.ProgressHandler?.Report(initialLength);

                    await QueueChunkTask(
                        async () =>
                        await CompleteFileDownload().ConfigureAwait(false))
                        .ConfigureAwait(false);
                }
                else
                {
                    // Capture the etag from the first segment and construct
                    // conditions to ensure the blob doesn't change while we're
                    // downloading the remaining segments
                    ETag etag = initialResponse.Value.Details.ETag;
                    BlobRequestConditions conditionsWithEtag;

                    // TODO: allow user to sumbit custom ETag and BlobRequestConditions
                    /*
                    if (conditions != default)
                    {
                        conditionsWithEtag = new BlobRequestConditions()
                        {
                            TagConditions = conditions.TagConditions,
                            IfMatch = etag,
                            IfNoneMatch = conditions.IfNoneMatch,
                            IfModifiedSince = conditions.IfModifiedSince,
                            IfUnmodifiedSince = conditions.IfUnmodifiedSince,
                            LeaseId = conditions.LeaseId
                        };
                    }
                    */
                    conditionsWithEtag = new BlobRequestConditions { IfMatch = etag };

                    await CopyToStreamInternal(initialResponse.Value.Content).ConfigureAwait(false);
                    Options?.ProgressHandler?.Report(initialLength);

                    // Set rangeSize
                    int rangeSize = Constants.DefaultBufferSize;
                    if (Options.TransferOptions.MaximumTransferSize.HasValue
                        && Options.TransferOptions.MaximumTransferSize.Value > 0)
                    {
                        rangeSize = Math.Min((int) Options.TransferOptions.MaximumTransferSize.Value, Constants.Blob.Block.MaxDownloadBytes);
                    }

                    // Get list of ranges of the blob
                    IList<HttpRange> ranges = GetRangesList(initialLength, totalLength, rangeSize);
                    // Create Download Chunk event handler to manage when the ranges finish downloading
                    _downloadChunkController = GetDownloadChunkController(
                        currentTranferred: initialLength,
                        expectedLength: totalLength,
                        ranges: ranges,
                        job: this);

                    // Fill the queue with tasks to download each of the remaining
                    // ranges in the blob
                    foreach (HttpRange httpRange in ranges)
                    {
                        // Add the next Task (which will start the download but
                        // return before it's completed downloading)
                        await QueueChunkTask( async () =>
                            await DownloadStreamingInternal(
                                range: httpRange,
                                conditions: conditionsWithEtag,
                                rangeGetContentHash: false).ConfigureAwait(false)).ConfigureAwait(false);
                    }
                }
            }
            // Expand Exception Handling
            catch (Exception ex)
            {
                // The file either does not exist any more, got moved, or renamed.
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                    TransferId,
                    SourceBlobClient,
                    DestinationLocalPath,
                    ex,
                    false,
                    CancellationTokenSource.Token));
                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
        }

        internal async Task CompleteFileDownload()
        {
            CancellationHelper.ThrowIfCancellationRequested(CancellationTokenSource.Token);

            // If the file requires client side encrytion, flush the crypto stream before finishing the download.
            if (BlobBaseClientInternals.GetUsingClientSideEncryption(SourceBlobClient))
            {
                await FlushFinalCryptoStreamInternal().ConfigureAwait(false);
            }

            if (File.Exists(DestinationLocalPath))
            {
                // Make file visible
                FileAttributes attributes = File.GetAttributes(DestinationLocalPath);
                File.SetAttributes(DestinationLocalPath, attributes | FileAttributes.Normal);
            }
            else
            {
                // The file either does not exist any more, got moved, or renamed.
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                    TransferId,
                    SourceBlobClient,
                    DestinationLocalPath,
                    new IOException($"Could not complete download. Destination file `{DestinationLocalPath}` could not be found."),
                    false,
                    CancellationTokenSource.Token));
            }
            await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
        }

        internal async Task DownloadStreamingInternal(
            HttpRange range,
            BlobRequestConditions conditions,
            bool rangeGetContentHash)
        {
            try
            {
                using BlobDownloadStreamingResult result = await SourceBlobClient.DownloadStreamingAsync(
                    range,
                    conditions,
                    rangeGetContentHash,
                    default,
                    CancellationTokenSource.Token).ConfigureAwait(false);
                await _downloadChunkController.InvokeEvent(new BlobDownloadRangeEventArgs(
                    transferId: TransferId,
                    success: true,
                    offset: range.Offset,
                    bytesTransferred: (long) range.Length,
                    result: result,
                    false,
                    CancellationTokenSource.Token)).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                    TransferId,
                    SourceBlobClient,
                    DestinationLocalPath,
                    ex,
                    false,
                    CancellationTokenSource.Token));
                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (IOException ex)
            {
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                                TransferId,
                                SourceBlobClient,
                                DestinationLocalPath,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                if (!ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                {
                    PauseTransferJob();
                    status = StorageTransferStatus.Paused;
                }
                await OnTransferStatusChanged(status, true).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Unexpected exception
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                                TransferId,
                                SourceBlobClient,
                                DestinationLocalPath,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                PauseTransferJob();
                await OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
            }
        }

        public async Task CopyToStreamInternal(Stream source)
        {
            CancellationHelper.ThrowIfCancellationRequested(CancellationTokenSource.Token);

            try
            {
                using (FileStream fileStream = new FileStream(
                    DestinationLocalPath,
                    FileMode.Append,
                    FileAccess.Write))
                {
                    await source.CopyToAsync(
                        fileStream,
                        Constants.DefaultDownloadCopyBufferSize,
                        CancellationTokenSource.Token)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                    TransferId,
                    SourceBlobClient,
                    DestinationLocalPath,
                    new Exception($"Failed to Write to File: {DestinationLocalPath}", ex),
                    false,
                    CancellationTokenSource.Token));
                TriggerJobCancellation();
                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
        }

        public async Task WriteChunkToTempFile(string chunkFilePath, Stream source)
        {
            CancellationHelper.ThrowIfCancellationRequested(CancellationTokenSource.Token);

            try
            {
                using (FileStream fileStream = File.OpenWrite(chunkFilePath))
                {
                    await source.CopyToAsync(
                        fileStream,
                        Constants.DefaultDownloadCopyBufferSize,
                        CancellationTokenSource.Token)
                        .ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                    TransferId,
                    SourceBlobClient,
                    DestinationLocalPath,
                    new Exception($"Failed to Write to Chunk File: {DestinationLocalPath}", ex),
                    false,
                    CancellationTokenSource.Token));
                TriggerJobCancellation();
                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
        }
        // If Encryption is enabled this is required to flush
        private async Task FlushFinalCryptoStreamInternal()
        {
            CancellationHelper.ThrowIfCancellationRequested(CancellationTokenSource.Token);

            try
            {
                using (Stream fileStream = new FileStream(
                    DestinationLocalPath,
                    FileMode.Open,
                    FileAccess.Read))
                {
                    if (fileStream is System.Security.Cryptography.CryptoStream cryptoStream)
                    {
                        cryptoStream.FlushFinalBlock();
                    }
                    else if (fileStream is Cryptography.AuthenticatedRegionCryptoStream authRegionCryptoStream)
                    {
                        await authRegionCryptoStream.FlushFinalInternal(async: true, CancellationTokenSource.Token).ConfigureAwait(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Options?.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                                TransferId,
                                SourceBlobClient,
                                DestinationLocalPath,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
        }

        internal static DownloadChunkController GetDownloadChunkController(
            long currentTranferred,
            long expectedLength,
            IList<HttpRange> ranges,
            BlobDownloadTransferJob job)
            => new DownloadChunkController(
                currentTranferred,
                expectedLength,
                ranges,
                GetDownloadChunkControllerBehaviors(job),
                job.Options?.ProgressHandler,
                job.CancellationTokenSource.Token);

        internal static DownloadChunkController.Behaviors GetDownloadChunkControllerBehaviors(BlobDownloadTransferJob job)
        {
            return new DownloadChunkController.Behaviors()
            {
                CopyToDestinationFile = (result) => job.CopyToStreamInternal(result),
                CopyToChunkFile = (chunkFilePath, source) => job.WriteChunkToTempFile(chunkFilePath, source),
                InvokeFailedHandler = (ex) =>
                {
                    job.Options?.GetDownloadFailed()?.Invoke(
                    new BlobDownloadFailedEventArgs(
                    job.TransferId,
                    job.SourceBlobClient,
                    job.DestinationLocalPath,
                    ex,
                    false,
                    job.CancellationTokenSource.Token));
                    // Trigger job cancellation if the failed handler is enabled
                    job.TriggerJobCancellation();
                },
                UpdateTransferStatus = (status) => job.QueueChunkTask(
                    async () =>
                    await job.OnTransferStatusChanged(status, true).ConfigureAwait(false)),
                QueueCompleteFileDownload = () => job.QueueChunkTask(
                    async () =>
                    await job.CompleteFileDownload().ConfigureAwait(false))
            };
        }

        private static long ParseRangeTotalLength(string range)
        {
            if (range == null)
            {
                return 0;
            }
            int lengthSeparator = range.IndexOf("/", StringComparison.InvariantCultureIgnoreCase);
            if (lengthSeparator == -1)
            {
                throw BlobErrors.ParsingFullHttpRangeFailed(range);
            }
            return long.Parse(range.Substring(lengthSeparator + 1), CultureInfo.InvariantCulture);
        }

        private static IList<HttpRange> GetRangesList(long initialLength, long totalLength, int rangeSize)
        {
            IList<HttpRange> list = new List<HttpRange>();
            for (long offset = initialLength; offset < totalLength; offset += rangeSize)
            {
                list.Add(new HttpRange(offset, Math.Min(totalLength - offset, rangeSize)));
            }
            return list;
        }
        #endregion PartitionedDownloader
    }
}
