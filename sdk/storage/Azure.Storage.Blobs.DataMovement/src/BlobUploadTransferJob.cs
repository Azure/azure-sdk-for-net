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
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration DestinationBlobConfiguration;

        /// <summary>
        /// Gets the destination blob client
        /// </summary>
        internal BlockBlobClient DestinationBlobClient;

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

        internal CommitBlockEventHandler commitBlockHandler;

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
            string sourceLocalPath,
            BlockBlobClient destinationClient,
            BlobSingleUploadOptions uploadOptions,
            ErrorHandlingOptions errorOption,
            QueueChunkTaskInternal queueChunkTask,
            ArrayPool<byte> arrayPool = default)
            : base(transferId: transferId,
                  errorHandling: errorOption,
                  queueChunkTask: queueChunkTask)
        {
            _sourceLocalPath = sourceLocalPath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            DestinationBlobClient = destinationClient;
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
            // TODO: make logging messages similar to the errors class where we only take in params
            // so we dont have magic strings hanging out here
            /* TODO: replace with Azure.Core.Diagnotiscs logger
            Logger.LogAsync(DataMovementLogLevel.Information,
                $"Processing Upload Transfer source: {SourceLocalPath}; destination: {DestinationBlobClient.Uri}", async).EnsureCompleted();
            */
            // Do only blockblob upload for now for now
            //BlockBlobClientInternals internalClient = new BlockBlobClientInternals(DestinationBlobClient);

            PartitionedProgressIncrementer progressIncrementer;
            if (UploadOptions?.ProgressHandler != default)
            {
                progressIncrementer = new PartitionedProgressIncrementer(UploadOptions.ProgressHandler);
            }
            else
            {
                // Create new progress tracker in the case that
                progressIncrementer = new PartitionedProgressIncrementer(new Progress<long>());
            }

            var uploader = GetPartitionedUploader(
                job: this,
                transferOptions: UploadOptions?.TransferOptions ?? default,
                // TODO #27253
                //options?.TransactionalHashingOptions,
                operationName: $"{nameof(BlobTransferManager.ScheduleUploadAsync)}");

            CancellationToken cancellationToken = CancellationTokenSource.Token;
            if (!uploader.IsPutBlockRequest)
            {
                commitBlockHandler = GetBlockListCommitHandler(
                    expectedLength: uploader.FileLength,
                    commitBlockTask: uploader.CommitBlockList,
                    job: this);
            }

            // This will internally use the queueChunkTask to add all the tasks to channel.
            await uploader.UploadInternal(
                UploadOptions,
                progressIncrementer,
                cancellationToken).ConfigureAwait(false);
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
                        DestinationBlobClient = new BlockBlobClient(
                            connectionString,
                            DestinationBlobConfiguration.BlobContainerName,
                            DestinationBlobConfiguration.Name,
                            BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
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
                    DestinationBlobClient = new BlockBlobClient(
                        DestinationBlobConfiguration.Uri,
                        sasCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else if (destinationCredential.GetType() == typeof(StorageSharedKeyCredential))
                {
                    StorageSharedKeyCredential sharedKeyCredential = (StorageSharedKeyCredential)destinationCredential;
                    DestinationBlobClient = new BlockBlobClient(
                        DestinationBlobConfiguration.Uri,
                        sharedKeyCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else if (destinationCredential.GetType() == typeof(TokenCredential))
                {
                    TokenCredential tokenCredential = (TokenCredential)destinationCredential;
                    DestinationBlobClient = new BlockBlobClient(
                        DestinationBlobConfiguration.Uri,
                        tokenCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
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

        public void TriggerJobCancellation()
        {
            if (!CancellationTokenSource.IsCancellationRequested)
            {
                CancellationTokenSource.Cancel();
            }
        }

        #region PartitionedUploader
        internal static async Task SingleUploadInternal(
            BlobUploadTransferJob job,
            BlobSingleUploadOptions options,
            string operationName,
            CancellationToken cancellationToken)
        {
            try
            {
                using (FileStream stream = new FileStream(job.SourceLocalPath, FileMode.Open, FileAccess.Read))
                {
                    await job.OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);
                    Response<BlobContentInfo> response = await BlockBlobClientInternals.PutBlobCallAsync(
                        job.DestinationBlobClient,
                        stream,
                        options,
                        operationName,
                        cancellationToken).ConfigureAwait(false);
                    await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                    // progressHandler is updated by passing the options bag to the putblob call
                }
            }
            catch (RequestFailedException ex)
            {
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnServiceFailure))
                {
                    job.PauseTransferJob();
                    status = StorageTransferStatus.Paused;
                }
                await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
            }
            catch (IOException ex)
            {
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                {
                    job.PauseTransferJob();
                    status = StorageTransferStatus.Paused;
                }
                await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Unexpected exception
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                job.PauseTransferJob();
                await job.OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
            }
        }

        internal static async Task StageBlockInternal(
            BlobUploadTransferJob job,
            long offset,
            int blockLength,
            BlobSingleUploadOptions options,
            IProgress<long> progressHandler,
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
                using (FileStream stream = new FileStream(job.SourceLocalPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    await job.OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);
                    Stream slicedStream = await GetOffsetPartitionInternal(
                        stream,
                        (int) offset,
                        blockLength,
                        job.UploadArrayPool,
                        cancellationToken).ConfigureAwait(false);

                    await job.DestinationBlobClient.StageBlockAsync(
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
                            progressHandler,
                            cancellationToken).ConfigureAwait(false);
                    await job.commitBlockHandler.InvokeEvent(
                        new BlobStageBlockEventArgs(
                            job.TransferId,
                            true,
                            offset,
                            blockLength,
                            true,
                            cancellationToken)).ConfigureAwait(false);
                };
            }
            // If we fail to stage a block, we need to make sure the rest of the stage blocks are cancelled
            // (Core already performs the retry policy on the one stage block request which means the rest are not worth to continue)
            catch (RequestFailedException ex)
            {
                options?.GetUploadFailed()?.Invoke(
                    new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnServiceFailure))
                {
                    job.PauseTransferJob();
                    status = StorageTransferStatus.Paused;
                }
                await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
                await job.commitBlockHandler.InvokeEvent(
                    new BlobStageBlockEventArgs(
                        job.TransferId,
                        false,
                        offset,
                        0,
                        true,
                        cancellationToken)).ConfigureAwait(false);
            }
            catch (IOException ex)
            {
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                {
                    job.PauseTransferJob();
                    status = StorageTransferStatus.Paused;
                }
                await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
                await job.commitBlockHandler.InvokeEvent(
                    new BlobStageBlockEventArgs(
                        job.TransferId,
                        false,
                        offset,
                        0,
                        false,
                        cancellationToken)).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Unexpected exception
                options?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                job.PauseTransferJob();
                await job.OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
            }
        }

        internal static async Task CommitBlockListInternal(
            BlobUploadTransferJob job,
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
                Response<BlobContentInfo> response = await job.DestinationBlobClient.CommitBlockListAsync(
                        partitions.Select(partition => Shared.StorageExtensions.GenerateBlockId(partition.Offset)),
                        options,
                        cancellationToken).ConfigureAwait(false);

                await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (RequestFailedException ex)
            {
                uploadOptions?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnServiceFailure))
                {
                    job.PauseTransferJob();
                    status = StorageTransferStatus.Paused;
                }
                await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
            }
            catch (IOException ex)
            {
                uploadOptions?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                StorageTransferStatus status = StorageTransferStatus.Completed;
                if (!job.ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                {
                    job.PauseTransferJob();
                    status = StorageTransferStatus.Paused;
                }
                await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
                await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Unexpected exception
                uploadOptions?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                job.TransferId,
                                job.SourceLocalPath,
                                job.DestinationBlobClient,
                                ex,
                                false,
                                job.CancellationTokenSource.Token));
                job.PauseTransferJob();
                await job.OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
            }
        }

        internal static ParallelPartitionedUploader<BlobSingleUploadOptions, BlobContentInfo> GetPartitionedUploader(
            BlobUploadTransferJob job,
            StorageTransferOptions transferOptions,
            // TODO #27253
            //UploadTransactionalHashingOptions validationOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
        => new ParallelPartitionedUploader<BlobSingleUploadOptions, BlobContentInfo>(
            job.SourceLocalPath,
            GetPartitionedUploaderBehaviors(job),
            transferOptions,
            //validationOptions,
            arrayPool,
            operationName);

        internal static ParallelPartitionedUploader<BlobSingleUploadOptions, BlobContentInfo>.Behaviors GetPartitionedUploaderBehaviors(BlobUploadTransferJob job)
        {
            return new ParallelPartitionedUploader<BlobSingleUploadOptions, BlobContentInfo>.Behaviors
            {
                // TODO #27253
                SingleUpload = (filePath, args, /*hashingOptions,*/ operationName, cancellationToken)
                    => job.QueueChunkTask(
                        async () =>
                        await SingleUploadInternal(
                            job,
                            args,
                            operationName,
                            cancellationToken).ConfigureAwait(false)),
                // TODO #27253
                UploadPartition = (offset, blockLength, args, progressHandler, /*validationOptions,*/ cancellationToken)
                    => job.QueueChunkTask(
                        async () =>
                        await StageBlockInternal(
                            job,
                            offset,
                            blockLength,
                            args,
                            progressHandler,
                            /*validationOptions,*/
                            cancellationToken).ConfigureAwait(false)),
                CommitPartitionedUpload = (partitions, args, cancellationToken)
                    => job.QueueChunkTask(
                        async () =>
                        await CommitBlockListInternal(
                            job,
                            partitions,
                            args,
                            cancellationToken).ConfigureAwait(false)),
                Scope = operationname =>
                {
                    StorageClientDiagnostics diagnostics = new StorageClientDiagnostics(BlobBaseClientInternals.GetClientOptions(job.DestinationBlobClient));
                    return diagnostics.CreateScope(operationname);
                }
            };
        }
        #endregion

        #region CommitBlockHandler
        internal static CommitBlockEventHandler GetBlockListCommitHandler(
            long expectedLength,
            CommitBlockTaskInternal commitBlockTask,
            BlobUploadTransferJob job)
        => new CommitBlockEventHandler(
            expectedLength,
            new Uri(job.SourceLocalPath), // Change source local path ot a uri
            job.DestinationBlobClient,
            GetBlockListCommitHandlerBehaviors(commitBlockTask, job),
            job.UploadOptions,
            job.CancellationTokenSource.Token);

        internal static CommitBlockEventHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            CommitBlockTaskInternal commitBlockTask,
            BlobUploadTransferJob job)
        {
            return new CommitBlockEventHandler.Behaviors
            {
                // TODO #27253
                QueueCommitBlockTask = async () =>
                        await commitBlockTask(
                            job.UploadOptions,
                            job.CancellationTokenSource.Token).ConfigureAwait(false),
                TriggerCancellationTask = () => job.TriggerJobCancellation(),
                UpdateTransferStatus = async (StorageTransferStatus status)
                    => await job.OnTransferStatusChanged(status, true).ConfigureAwait(false)
            };
        }
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
            StageBlockStream slicedStream = new StageBlockStream(arrayPool, offset, length);
            await slicedStream.SetStreamPartitionInternal(
                stream,
                length,
                length,
                cancellationToken).ConfigureAwait(false);
            return slicedStream;
        }
    }
}
