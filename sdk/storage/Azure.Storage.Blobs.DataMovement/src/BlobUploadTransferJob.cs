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
using Azure.Storage.Blob.Experiemental;
using System.Linq;
using Azure.Storage.Blobs.Specialized;
using System.Threading;
using System.Collections.Generic;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Uploading BLobTransfer Job
    /// </summary>
    internal class BlobUploadTransferJob : BlobTransferJobInternal
    {
        public delegate Task QueueChunkTaskInternal(Func<Task> uploadTask);
        private readonly QueueChunkTaskInternal _queueChunkTask;
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

        internal SyncAsyncEventHandler<BlobStageBlockEventArgs> commitBlockHandler;

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
        public BlobUploadTransferJob(
            string transferId,
            string sourceLocalPath,
            BlockBlobClient destinationClient,
            BlobSingleUploadOptions uploadOptions,
            ErrorHandlingOptions errorOption,
            QueueChunkTaskInternal queueChunkTask)
            : base(transferId: transferId,
                  errorHandling: errorOption)
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
            _queueChunkTask = queueChunkTask;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        ///
        /// TODO: for speed up, figure out how to finish processing this chunking the job part to chunks once we know what the commit block list is.
        /// we could be waiting for a while to queue up the commit block request waiting on the blocks to upload.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
#pragma warning disable CA1801 // Review unused parameters
        public async Func<Task> ProcessUploadTransfer()
#pragma warning restore CA1801 // Review unused parameters
        {
            // TODO: make logging messages similar to the errors class where we only take in params
            // so we dont have magic strings hanging out here
            /* TODO: replace with Azure.Core.Diagnotiscs logger
            Logger.LogAsync(DataMovementLogLevel.Information,
                $"Processing Upload Transfer source: {SourceLocalPath}; destination: {DestinationBlobClient.Uri}", async).EnsureCompleted();
            */
            // Do only blockblob upload for now for now
            //BlockBlobClientInternals internalClient = new BlockBlobClientInternals(DestinationBlobClient);

            AggregatingProgressIncrementer progressIncrementer;
            if (UploadOptions?.ProgressHandler == default)
            {
                progressIncrementer = new AggregatingProgressIncrementer(UploadOptions.ProgressHandler);
            }
            else
            {
                // Create new progress tracker in the case that
                progressIncrementer = new AggregatingProgressIncrementer(new Progress<long>());
            }

            var uploader = GetPartitionedUploader(
                job: this,
                transferOptions: UploadOptions?.TransferOptions ?? default,
                // TODO #27253
                //options?.TransactionalHashingOptions,
                operationName: $"{nameof(BlobTransferManager.ScheduleUploadAsync)}");

            CancellationToken cancellationToken = CancellationTokenSource.Token;
            commitBlockHandler += async (BlobStageBlockEventArgs args) =>
            {
                if (args.Success && !uploader.IsPutBlockRequest)
                {
                    if(progressIncrementer.Current == uploader.)
                    {
                        await uploader.CommitBlockList(
                            UploadOptions,
                            cancellationToken).ConfigureAwait(false);
                    }
                }
                else
                {
                    // Set status to completed
                    await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                }
            };

            await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);
            await foreach (UploadBlobTask func in uploader.UploadInternal(
                SourceLocalPath,
                UploadOptions,
                progressIncrementer,
                cancellationToken).ConfigureAwait(false))
            {
                yield return func;
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
                        await UploadOptions.GetTransferStatus().RaiseAsync(
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
        internal static ParallelPartitionedUploader<BlobSingleUploadOptions, BlobContentInfo> GetPartitionedUploader(
            BlobUploadTransferJob job,
            StorageTransferOptions transferOptions,
            // TODO #27253
            //UploadTransactionalHashingOptions validationOptions,
            ArrayPool<byte> arrayPool = null,
            string operationName = null)
            => new ParallelPartitionedUploader<BlobSingleUploadOptions, BlobContentInfo>(
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
                SingleUpload = async (filePath, args, progressHandler, /*hashingOptions,*/ operationName, async, cancellationToken)
                    =>
                {
                    job._queueChunkTask(async () =>
                    {
                        try
                        {
                            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                            {
                                if (async)
                                {
                                    Response<BlobContentInfo> response = await BlockBlobClientInternals.PutBlobCallAsync(
                                       job.DestinationBlobClient,
                                       stream,
                                       args,
                                       operationName,
                                       cancellationToken).ConfigureAwait(false);
                                    await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                                    return response;
                                }
                                else
                                {
                                    Response<BlobContentInfo> response = BlockBlobClientInternals.PutBlobCall(
                                        job.DestinationBlobClient,
                                        stream,
                                        args,
                                        operationName,
                                        cancellationToken);
                                    job.OnTransferStatusChanged(StorageTransferStatus.Completed, false).EnsureCompleted();
                                    return response;
                                }
                            }
                        }
                        catch (RequestFailedException ex)
                        {
                            args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
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
                            if (async)
                            {
                                await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
                            }
                            else
                            {
                                job.OnTransferStatusChanged(status, false).EnsureCompleted();
                            }
                        }
                        catch (IOException ex)
                        {
                            args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
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
                            if (async)
                            {
                                await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
                            }
                            else
                            {
                                job.OnTransferStatusChanged(status, false).EnsureCompleted();
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            // Job was cancelled
                            if (async)
                            {
                                await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                            }
                            else
                            {
                                job.OnTransferStatusChanged(StorageTransferStatus.Completed, false).EnsureCompleted();
                            }
                        }
                        catch (Exception ex)
                        {
                            // Unexpected exception
                            args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                            job.TransferId,
                                            job.SourceLocalPath,
                                            job.DestinationBlobClient,
                                            ex,
                                            false,
                                            job.CancellationTokenSource.Token));
                            job.PauseTransferJob();
                            if (async)
                            {
                                await job.OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
                            }
                            else
                            {
                                job.OnTransferStatusChanged(StorageTransferStatus.Paused, false).EnsureCompleted();
                            }
                        }
                    }
                    return default;
                },
                // TODO #27253
                UploadPartition = async (stream, offset, args, progressHandler, /*validationOptions,*/ async, cancellationToken)
                    =>
                {
                    // Stage Block only accepts LeaseId.
                    BlobRequestConditions conditions = null;
                    if (args?.Conditions != null)
                    {
                        conditions = new BlobRequestConditions
                        {
                            LeaseId = args.Conditions.LeaseId
                        };
                    }
                    try
                    {
                        if (async)
                        {
                            await job.DestinationBlobClient.StageBlockAsync(
                                    Shared.StorageExtensions.GenerateBlockId(offset),
                                    stream,
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
                        }
                        else
                        {
                            job.DestinationBlobClient.StageBlock(
                                    Shared.StorageExtensions.GenerateBlockId(offset),
                                    stream,
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
                                    cancellationToken);
                        }
                        job.commitBlockHandler.(offset, stream.Length);
                    }
                    // If we fail to stage a block, we need to make sure the rest of the stage blocks are cancelled
                    // (Core already performs the retry policy on the one stage block request which means the rest are not worth to continue)
                    catch (RequestFailedException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(
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
                        if (async)
                        {
                            await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
                        }
                        else
                        {
                            job.OnTransferStatusChanged(status, false).EnsureCompleted();
                        }
                    }
                    catch (IOException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
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
                        if (async)
                        {
                            await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
                        }
                        else
                        {
                            job.OnTransferStatusChanged(status, false).EnsureCompleted();
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // Job was cancelled
                        if (async)
                        {
                            await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                        }
                        else
                        {
                            job.OnTransferStatusChanged(StorageTransferStatus.Completed, false).EnsureCompleted();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Unexpected exception
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        job.SourceLocalPath,
                                        job.DestinationBlobClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        job.PauseTransferJob();
                        if (async)
                        {
                            await job.OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
                        }
                        else
                        {
                            job.OnTransferStatusChanged(StorageTransferStatus.Paused, false).EnsureCompleted();
                        }
                    }
                },
                CommitPartitionedUpload = async (partitions, args, async, cancellationToken)
                    =>
                {
                    CommitBlockListOptions options = new CommitBlockListOptions()
                    {
                        HttpHeaders = args.HttpHeaders,
                        Metadata = args.Metadata,
                        Tags = args.Tags,
                        Conditions = args.Conditions,
                        AccessTier = args.AccessTier,
                        ImmutabilityPolicy = args.ImmutabilityPolicy,
                        LegalHold = args.LegalHold,
                    };
                    try
                    {
                        if (async)
                        {
                            Response<BlobContentInfo> response = await job.DestinationBlobClient.CommitBlockListAsync(
                                  partitions.Select(partition => Shared.StorageExtensions.GenerateBlockId(partition.Offset)),
                                  options,
                                  cancellationToken).ConfigureAwait(false);

                            await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                            return response;
                        }
                        else
                        {
                            Response<BlobContentInfo> response = job.DestinationBlobClient.CommitBlockList(
                                partitions.Select(partition => Shared.StorageExtensions.GenerateBlockId(partition.Offset)),
                                  options,
                                  cancellationToken);
                            job.OnTransferStatusChanged(StorageTransferStatus.Completed, false).EnsureCompleted();
                            return response;
                        }
                    }
                    catch (RequestFailedException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
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
                        if (async)
                        {
                            await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
                        }
                        else
                        {
                            job.OnTransferStatusChanged(status, false).EnsureCompleted();
                        }
                    }
                    catch (IOException ex)
                    {
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
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
                        if (async)
                        {
                            await job.OnTransferStatusChanged(status, true).ConfigureAwait(false);
                        }
                        else
                        {
                            job.OnTransferStatusChanged(status, false).EnsureCompleted();
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // Job was cancelled
                        if (async)
                        {
                            await job.OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                        }
                        else
                        {
                            job.OnTransferStatusChanged(StorageTransferStatus.Completed, false).EnsureCompleted();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Unexpected exception
                        args?.GetUploadFailed()?.Invoke(new BlobUploadFailedEventArgs(
                                        job.TransferId,
                                        job.SourceLocalPath,
                                        job.DestinationBlobClient,
                                        ex,
                                        false,
                                        job.CancellationTokenSource.Token));
                        job.PauseTransferJob();
                        if (async)
                        {
                            await job.OnTransferStatusChanged(StorageTransferStatus.Paused, true).ConfigureAwait(false);
                        }
                        else
                        {
                            job.OnTransferStatusChanged(StorageTransferStatus.Paused, false).EnsureCompleted();
                        }
                    }
                    return default;
                },
                Scope = operationname =>
                {
                    StorageClientDiagnostics diagnostics = new StorageClientDiagnostics(BlobBaseClientInternals.GetClientOptions(job.DestinationBlobClient));
                    return diagnostics.CreateScope(operationname);
                }
            };
        }
        #endregion

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<BlobJobPartInternal> ProcessJobToJobPartAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            yield return new BlobUploadPartInternal(this);
        }

        public override async IAsyncEnumerable<Func<Task>> ProcessPartToChunkAsync()
        {
            // Do only blockblob upload for now for now
            //BlockBlobClientInternals internalClient = new BlockBlobClientInternals(DestinationBlobClient);
            var uploader = GetPartitionedUploader(
                job: this,
                transferOptions: UploadOptions?.TransferOptions ?? default,
                // TODO #27253
                //options?.TransactionalHashingOptions,
                operationName: $"{nameof(BlobTransferManager.ScheduleUploadAsync)}");

            await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);
            CancellationToken cancellationToken = CancellationTokenSource.Token;
            await foreach (UploadBlobTask func in uploader.UploadInternal(
                SourceLocalPath,
                UploadOptions,
                UploadOptions?.ProgressHandler,
                cancellationToken).ConfigureAwait(false))
            {
                yield return func;
            }
        }
    }
}
