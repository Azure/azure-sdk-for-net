// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Core;
using System.Buffers;
using System.IO;
using Azure.Core.Pipeline;
using System.Linq;
using Azure.Storage.Blobs.Specialized;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Azure.Storage.Shared;
using System.Security.Cryptography;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Uploading BLobTransfer Job
    /// </summary>
    internal class BlobUploadTransferJob : BlobTransferJobInternal
    {
        public delegate Task CommitBlockTaskInternal(BlobSingleUploadOptions options, CancellationToken cancellationToken);
        public CommitBlockTaskInternal CommitBlockTask { get; internal set; }
        /// <summary>
        /// The path to the local file where the contents to be upload to the blob is stored.
        /// </summary>
        internal string _sourceLocalPath;

        /// <summary>
        /// Gets the path to the local file where the contents to be upload to the blob is stored.
        /// </summary>
        public string SourceLocalPath => _sourceLocalPath;

        /// <summary>
        /// Source Resource
        /// </summary>
        public StorageResource SourceResource => _sourceResource;
        internal StorageResource _sourceResource;

        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration DestinationBlobConfiguration;

        /// <summary>
        /// Gets the destination blob client
        /// </summary>
        internal BlockBlobClient _destinationBlobClient;

        internal BlobSingleUploadOptions _uploadOptions;

        /// <summary>
        /// Upload options for the upload task
        /// </summary>
        public BlobSingleUploadOptions UploadOptions => _uploadOptions;

        private ClientDiagnostics _diagnostics;

        /// <summary>
        /// Client Diagnostics
        /// </summary>
        public ClientDiagnostics Diagnostics => _diagnostics;

        //internal CommitChunkHandler commitBlockHandler;

        /// <summary>
        /// Array pool designated for upload file
        /// </summary>
        public ArrayPool<byte> UploadArrayPool => _arrayPool;
        internal ArrayPool<byte> _arrayPool;

        /// <summary>
        /// Constructor. Creates Single Upload Transfer Job.
        ///
        /// TODO: better description; better param descriptions.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceLocalPath">
        /// Local File Path that contains the contents to upload.
        /// </param>
        /// <param name="destinationClient">
        /// Destination Blob where the contents will be uploaded to.
        /// </param>
        /// <param name="uploadOptions">
        /// Upload Transfer Options for the specific job.
        /// </param>
        /// <param name="errorOption">
        /// Error Handling Options.
        /// </param>
        /// <param name="queueChunkTask">
        /// </param>
        /// <param name="arrayPool">
        /// // TODO array pool
        /// </param>
        public BlobUploadTransferJob(
            string transferId,
            StorageResource sourceLocalPath,
            BlockBlobClient destinationClient,
            BlobSingleUploadOptions uploadOptions,
            ErrorHandlingOptions errorOption,
            QueueChunkTaskInternal queueChunkTask,
            ArrayPool<byte> arrayPool = default)
            : base(transferId: transferId,
                  errorHandling: errorOption,
                  queueChunkTask: queueChunkTask)
        {
            _sourceResource = sourceLocalPath;
            _sourceLocalPath = string.Join("/", sourceLocalPath.GetPath().ToArray());
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _destinationBlobClient = destinationClient;
            DestinationBlobConfiguration = new BlobBaseConfiguration()
            {
                BlobContainerName = destinationClient.BlobContainerName,
                AccountName = destinationClient.AccountName,
                Name = destinationClient.Name
            };
            _uploadOptions = uploadOptions;
            _diagnostics = new ClientDiagnostics(BlobBaseClientInternals.GetClientOptions(destinationClient));
            QueueChunkTask = queueChunkTask;
            _arrayPool = arrayPool ?? ArrayPool<byte>.Shared;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        ///
        /// TODO: for speed up, figure out how to finish processing this chunking the job part to chunks once we know what the commit block list is.
        /// we could be waiting for a while to queue up the commit block request waiting on the blocks to upload.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public override async Task ProcessPartToChunkAsync()
        {
            // Set _singleUploadThreshold
            long singleUploadThreshold = Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes;
            if (UploadOptions.TransferOptions.InitialTransferSize.HasValue
                && UploadOptions.TransferOptions.InitialTransferSize.Value > 0)
            {
                singleUploadThreshold = Math.Min(UploadOptions.TransferOptions.InitialTransferSize.Value, Constants.Blob.Block.MaxUploadBytes);
            }

            FileInfo fileInfo = new FileInfo(SourceLocalPath);
            long fileLength = fileInfo.Length;
            string operationName = $"{nameof(BlobTransferManager.ScheduleUploadAsync)}";

            CancellationToken cancellationToken = CancellationTokenSource.Token;
            if (singleUploadThreshold < fileLength)
            {
                // If the caller provided an explicit block size, we'll use it.
                // Otherwise we'll adjust dynamically based on the size of the
                // content.
                long blockSize;
                if (UploadOptions.TransferOptions.MaximumTransferSize.HasValue
                && UploadOptions.TransferOptions.MaximumTransferSize > 0)
                {
                    blockSize = Math.Min(
                        Constants.Blob.Block.MaxStageBytes,
                        UploadOptions.TransferOptions.MaximumTransferSize.Value);
                }
                else
                {
                    blockSize = fileLength < Constants.LargeUploadThreshold ?
                            Constants.DefaultBufferSize :
                            Constants.LargeBufferSize;
                }

                // If we cannot upload in one shot, initiate the parallel block uploader
                List<(long Offset, long Length)> commitBlockList = await QueueStageBlockRequests(
                    blockSize,
                    fileLength,
                    operationName,
                    UploadOptions,
                    cancellationToken).ConfigureAwait(false);
                /*
                commitBlockHandler = GetCommitController(
                    expectedLength: fileLength,
                    commitBlockTask: async (options, cancellationToken) =>
                    await CommitBlockListInternal(
                        commitBlockList,
                        options,
                        cancellationToken).ConfigureAwait(false),
                    job: this);
                */
            }
            else
            {
                // Single Put Blob Request
                await QueueChunkTask(async () => await SingleUploadInternal(
                    UploadOptions,
                    $"{nameof(BlobTransferManager.ScheduleUploadAsync)}",
                    cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);
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
            // Checking source credentials is unnecesary here
            if (destinationCredential != default)
            {
                // Connection String
                if (destinationCredential.GetType() == typeof(string))
                {
                    string connectionString = (string)destinationCredential;
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(connectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(DestinationBlobConfiguration.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        _destinationBlobClient = new BlockBlobClient(
                            connectionString,
                            DestinationBlobConfiguration.BlobContainerName,
                            DestinationBlobConfiguration.Name,
                            BlobBaseClientInternals.GetClientOptions(_destinationBlobClient));
                    }
                    else
                    {
                        // Mismatch in storage account host in the URL
                        throw Errors.InvalidConnectionString();
                    }
                }
                else if (destinationCredential.GetType() == typeof(AzureSasCredential))
                {
                    AzureSasCredential sasCredential = (AzureSasCredential)destinationCredential;
                    _destinationBlobClient = new BlockBlobClient(
                        DestinationBlobConfiguration.Uri,
                        sasCredential,
                        BlobBaseClientInternals.GetClientOptions(_destinationBlobClient));
                }
                else if (destinationCredential.GetType() == typeof(StorageSharedKeyCredential))
                {
                    StorageSharedKeyCredential sharedKeyCredential = (StorageSharedKeyCredential)destinationCredential;
                    _destinationBlobClient = new BlockBlobClient(
                        DestinationBlobConfiguration.Uri,
                        sharedKeyCredential,
                        BlobBaseClientInternals.GetClientOptions(_destinationBlobClient));
                }
                else if (destinationCredential.GetType() == typeof(TokenCredential))
                {
                    TokenCredential tokenCredential = (TokenCredential)destinationCredential;
                    _destinationBlobClient = new BlockBlobClient(
                        DestinationBlobConfiguration.Uri,
                        tokenCredential,
                        BlobBaseClientInternals.GetClientOptions(_destinationBlobClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(destinationCredential));
                }
            }
            // else
            // If no credentials are passed or default is passed then we will just use the
            // credentials that are currently cached (or if none, then we assume it's public access)

            // Read in Job Plan File
            // JobPlanReader.Read(file)
            OnTransferStatusChanged(StorageTransferStatus.Queued, false).EnsureCompleted();
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
                    if ((UploadOptions != null) &&
                        (UploadOptions?.GetTransferStatus() != null))
                    {
                        await UploadOptions.GetTransferStatus().Invoke(
                                new StorageTransferStatusEventArgs(
                                    TransferId,
                                    transferStatus,
                                    true,
                                    CancellationTokenSource.Token)).ConfigureAwait(false);
                    }
                }
                else
                {
                    if ((UploadOptions != null) &&
                        (UploadOptions?.GetTransferStatus() != null))
                    {
                        UploadOptions.GetTransferStatus()?.Invoke(new StorageTransferStatusEventArgs(
                                    TransferId,
                                    transferStatus,
                                    true,
                                    CancellationTokenSource.Token));
                    }
                }

                if (transferStatus == StorageTransferStatus.Completed ||
                    transferStatus == StorageTransferStatus.Paused)
                {
                    PlanJobWriter.CloseWriter();
                }
            }
        }

        #region PartitionedUploader
        internal async Task SingleUploadInternal(
            BlobSingleUploadOptions options,
            string operationName,
            CancellationToken cancellationToken)
        {
            try
            {
                using (FileStream stream = new FileStream(SourceLocalPath, FileMode.Open, FileAccess.Read))
                {
                    await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);
                    Response<BlobContentInfo> response = await BlockBlobClientInternals.PutBlobCallAsync(
                        _destinationBlobClient,
                        stream,
                        options,
                        operationName,
                        cancellationToken).ConfigureAwait(false);
                    await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                    // progressHandler is updated by passing the options bag to the putblob call
                }
            }
            catch (RequestFailedException ex)
            {
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                    TransferId,
                    SourceResource,
                    _destinationBlobClient,
                    ex,
                    false,
                    CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                await OnTransferStatusChanged(status, true).ConfigureAwait(false);
            }
            catch (IOException ex)
            {
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                    TransferId,
                    SourceResource,
                    _destinationBlobClient,
                    ex,
                    false,
                    CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
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
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                SourceResource,
                                _destinationBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                PauseTransferJob();
                await OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
            }
        }

        internal async Task StageBlockInternal(
            long offset,
            long blockLength,
            BlobSingleUploadOptions options,
            CancellationToken cancellationToken)
        {
            // Stage Block only accepts LeaseId.
            BlobRequestConditions conditions = null;
            if (options?.Conditions != null)
            {
                conditions = new BlobRequestConditions
                {
                    LeaseId = options.Conditions.LeaseId
                };
            }
            try
            {
                // Make sure it's opened only in Shared Read Only Mode

                Stream slicedStream = Stream.Null;
                using (FileStream stream = new FileStream(SourceLocalPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);
                    slicedStream = await GetOffsetPartitionInternal(
                        stream,
                        (int)offset,
                        (int)blockLength,
                        UploadArrayPool,
                        cancellationToken).ConfigureAwait(false);
                }
                await _destinationBlobClient.StageBlockAsync(
                        Shared.StorageExtensions.GenerateBlockId(offset),
                        slicedStream,
                        // TODO #27253
                        //new BlockBlobStageBlockOptions()
                        //{
                        //    TransactionalHashingOptions = hashingOptions,
                        //    Conditions = conditions,
                        //    ProgressHandler = progressHandler
                        //},
                        transactionalContentHash: default,
                        conditions,
                        default,
                        cancellationToken).ConfigureAwait(false);
                /*
                await commitBlockHandler.InvokeEvent(
                    new BlobStageChunkEventArgs(
                        TransferId,
                        true,
                        offset,
                        blockLength,
                        true,
                        cancellationToken)).ConfigureAwait(false);
                */
            }
            // If we fail to stage a block, we need to make sure the rest of the stage blocks are cancelled
            // (Core already performs the retry policy on the one stage block request which means the rest are not worth to continue)
            catch (RequestFailedException ex)
            {
                options?.GetUploadFailed()?.Invoke(
                    new BlobUploadFailedEventArgs(
                                TransferId,
                                SourceResource,
                                _destinationBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                await OnTransferStatusChanged(status, true).ConfigureAwait(false);
                /*
                await commitBlockHandler.InvokeEvent(
                    new BlobStageChunkEventArgs(
                        TransferId,
                        false,
                        offset,
                        0,
                        true,
                        cancellationToken)).ConfigureAwait(false);
                */
            }
            catch (IOException ex)
            {
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                SourceResource,
                                _destinationBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                await OnTransferStatusChanged(status, true).ConfigureAwait(false);
                /*
                await commitBlockHandler.InvokeEvent(
                    new BlobStageChunkEventArgs(
                        TransferId,
                        false,
                        offset,
                        0,
                        false,
                        cancellationToken)).ConfigureAwait(false);
                */
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Unexpected exception
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                SourceResource,
                                _destinationBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                PauseTransferJob();
                await OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
            }
        }

        internal async Task CommitBlockListInternal(
            List<(long Offset, long Size)> partitions,
            BlobSingleUploadOptions uploadOptions,
            CancellationToken cancellationToken)
        {
            CommitBlockListOptions options = new CommitBlockListOptions()
            {
                HttpHeaders = uploadOptions.HttpHeaders,
                Metadata = uploadOptions.Metadata,
                Tags = uploadOptions.Tags,
                Conditions = uploadOptions.Conditions,
                AccessTier = uploadOptions.AccessTier,
                ImmutabilityPolicy = uploadOptions.ImmutabilityPolicy,
                LegalHold = uploadOptions.LegalHold,
            };
            try
            {
                Response<BlobContentInfo> response = await _destinationBlobClient.CommitBlockListAsync(
                        partitions.Select(partition => Shared.StorageExtensions.GenerateBlockId(partition.Offset)),
                        options,
                        cancellationToken).ConfigureAwait(false);

                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                uploadOptions?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                SourceResource,
                                _destinationBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                await OnTransferStatusChanged(status, true).ConfigureAwait(false);
            }
            catch (IOException ex)
            {
                uploadOptions?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                SourceResource,
                                _destinationBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
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
                uploadOptions?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                TransferId,
                                SourceResource,
                                _destinationBlobClient,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                PauseTransferJob();
                await OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
            }
        }

        private async Task<List<(long Offset, long Size)>> QueueStageBlockRequests(
            long blockSize,
            long fileLength,
            string operationName,
            BlobSingleUploadOptions args,
            CancellationToken cancellationToken)
        {
            // Wrap the staging and commit calls in an Upload span for
            // distributed tracing
            StorageClientDiagnostics diagnostics = new StorageClientDiagnostics(BlobBaseClientInternals.GetClientOptions(_destinationBlobClient));
            DiagnosticScope scope = diagnostics.CreateScope(operationName);
            scope.Start();

            // The list tracking blocks IDs we're going to commit
            List<(long Offset, long Size)> partitions = new List<(long, long)>();

            // Partition the stream into individual blocks
            foreach ((long Offset, long Length) block in GetPartitionIndexes(fileLength, blockSize))
            {
                /* We need to do this first! Length is calculated on the fly based on stream buffer
                    * contents; We need to record the partition data first before consuming the stream
                    * asynchronously. */
                partitions.Add(block);

                // Queue paritioned block task
                await QueueChunkTask(async () =>
                    await StageBlockInternal(
                        block.Offset,
                        block.Length,
                        args,
                        /*validationOptions,*/
                        cancellationToken).ConfigureAwait(false)).ConfigureAwait(false);
            }
            return partitions;
        }
        #endregion

        #region CommitChunkController
        /*
        internal static CommitChunkHandler GetCommitController(
            long expectedLength,
            CommitBlockTaskInternal commitBlockTask,
            BlobUploadTransferJob job)
        => new CommitChunkHandler(
            expectedLength,
            GetBlockListCommitHandlerBehaviors(commitBlockTask, job));

        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            CommitBlockTaskInternal commitBlockTask,
            BlobUploadTransferJob job)
        {
            return new CommitChunkHandler.Behaviors
            {
                // TODO #27253
                QueueCommitBlockTask = async () =>
                        await commitBlockTask(
                            job.UploadOptions,
                            job.CancellationTokenSource.Token).ConfigureAwait(false),
                ReportProgressInBytes = (long bytesWritten) =>
                    job.UploadOptions?.ProgressHandler?.Report(bytesWritten),
                InvokeFailedHandler = async (ex) => await job.InvokeUploadFailed(ex, StorageTransferStatus.Completed).ConfigureAwait(false),
                UpdateTransferStatus = async (StorageTransferStatus status)
                    => await job.OnTransferStatusChanged(status, true).ConfigureAwait(false)
            };
        }
        */
        #endregion

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<BlobJobPartInternal> ProcessJobToJobPartAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            yield return new BlobUploadPartInternal(this);
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

        private async Task InvokeUploadFailed(Exception ex, StorageTransferStatus status)
        {
            UploadOptions?.GetUploadFailed()?.Invoke(
                new BlobUploadFailedEventArgs(
                TransferId,
                SourceResource,
                _destinationBlobClient,
                ex,
                false,
                CancellationTokenSource.Token));
            // Trigger job cancellation if the failed handler is enabled
            TriggerJobCancellation();
            await OnTransferStatusChanged(status, true).ConfigureAwait(false);
        }
    }
}
