// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement;
using Azure.Core;
using System.Collections.Generic;
using Azure.Core.Pipeline;
using System.Linq;
using System.Xml.Linq;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlockBlobServiceCopyTransferJob : BlobTransferJobInternal
    {
        /// <summary>
        /// The source Uri
        /// </summary>
        public Uri SourceUri { get; internal set; }

        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration DestinationBlobConfiguration;

        /// <summary>
        /// The destination blob client for the copy job
        /// </summary>
        internal BlockBlobClient DestinationBlobClient;

        /// <summary>
        /// Type of Copy to occur
        /// </summary>
        public readonly BlobCopyMethod CopyMethod;

        internal BlobSingleCopyOptions _copyFromUriOptions;

        /// <summary>
        /// Gets the <see cref="BlobCopyFromUriOptions"/>.
        /// </summary>
        public BlobSingleCopyOptions CopyFromUriOptions => _copyFromUriOptions;

        //internal CommitChunkHandler commitBlockController;

        /// <summary>
        /// Creates Single Copy Transfer Job
        ///
        /// TODO: better description and param descriptions.
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceUri"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod"></param>
        /// <param name="copyFromUriOptions"></param>
        /// <param name="errorOption"></param>
        /// <param name="queueChunkTask"></param>
        public BlockBlobServiceCopyTransferJob(
            string transferId,
            Uri sourceUri,
            BlockBlobClient destinationClient,
            BlobCopyMethod copyMethod,
            BlobSingleCopyOptions copyFromUriOptions,
            ErrorHandlingOptions errorOption,
            QueueChunkTaskInternal queueChunkTask)
            : base(transferId: transferId,
                  errorHandling: errorOption,
                  queueChunkTask: queueChunkTask)
        {
            SourceUri = sourceUri;
            DestinationBlobClient = destinationClient;
            DestinationBlobConfiguration = new BlobBaseConfiguration()
            {
                BlobContainerName = destinationClient.BlobContainerName,
                AccountName = destinationClient.AccountName,
                Name = destinationClient.Name,
            };
            CopyMethod = copyMethod;
            _copyFromUriOptions = copyFromUriOptions;
        }

        public override async Task ProcessPartToChunkAsync()
        {
            // TODO: make logging messages similar to the errors class where we only take in params
            // so we dont have magic strings hanging out here
            /* TODO: replace with Azure.Core.Diagnotiscs logger
            Logger.LogAsync(DataMovementLogLevel.Information,$"Processing Copy Transfer source: {SourceUri.AbsoluteUri}; destination: {DestinationBlobClient.Uri}", async).EnsureCompleted();
            */
            // Do only blockblob upload for now for now
            try
            {
                long? contentLength = await GetSourceLength().ConfigureAwait(false);

                if (contentLength.HasValue)
                {
                    if (CopyMethod == BlobCopyMethod.Copy)
                    {
                        await SingleAsyncCopyInternal(contentLength.Value).ConfigureAwait(false);
                    }
                    else if (CopyMethod == BlobCopyMethod.SyncCopy)
                    {
                        long singleCopyThreshold = Constants.Blob.Block.Pre_2019_12_12_MaxUploadBytes;
                        if (CopyFromUriOptions.TransferOptions.InitialTransferSize.HasValue
                            && CopyFromUriOptions.TransferOptions.InitialTransferSize.Value > 0)
                        {
                            singleCopyThreshold = Math.Min(CopyFromUriOptions.TransferOptions.InitialTransferSize.Value, Constants.Blob.Block.MaxUploadBytes);
                        }

                        if (singleCopyThreshold < contentLength.Value)
                        {
                            // If the caller provided an explicit block size, we'll use it.
                            // Otherwise we'll adjust dynamically based on the size of the
                            // content.
                            long blockSize;
                            if (CopyFromUriOptions.TransferOptions.MaximumTransferSize.HasValue
                            && CopyFromUriOptions.TransferOptions.MaximumTransferSize > 0)
                            {
                                blockSize = Math.Min(
                                    Constants.Blob.Block.MaxStageBytes,
                                    CopyFromUriOptions.TransferOptions.MaximumTransferSize.Value);
                            }
                            else
                            {
                                blockSize = contentLength < Constants.LargeUploadThreshold ?
                                        Constants.DefaultBufferSize :
                                        Constants.LargeBufferSize;
                            }

                            List<(long Offset, long Length)> commitBlockList = await QueueStageBlockRequests(
                                blockSize,
                                contentLength.Value,
                                CopyFromUriOptions,
                                CancellationTokenSource.Token).ConfigureAwait(false);
                            /*
                            commitBlockController = GetCommitController(
                                contentLength.Value,
                                commitBlockList,
                                this);
                            */
                        }
                        else
                        {
                            // Intiate polling to check the status of the copy.
                            await SingleSyncCopyInternal().ConfigureAwait(false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await InvokeCopyFailed(ex).ConfigureAwait(false);
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
            // Recreate source uri if a new sas is present
            if (sourceCredential != default)
            {
                // Current single copy only supports SAS on the URL of the source
                if (sourceCredential.GetType() == typeof(string))
                {
                    string connectionString = (string)sourceCredential;
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(connectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceUri);

                    if (parsedConnectionString.BlobEndpoint.Host != sourceUriBuilder.Host ||
                        parsedConnectionString.BlobEndpoint.AbsolutePath != sourceUriBuilder.BlobName)
                    {
                        // Mismatch in storage account host in the URL
                        throw Errors.InvalidConnectionString();
                    }
                    SourceUri = parsedConnectionString.BlobEndpoint;
                }
                else
                {
                    // TODO: throw an argument that says invalid credentials for this operation?
                    throw Errors.InvalidArgument(nameof(destinationCredential));
                }
            }
            // Recreate destination client if new credentials are present
            if (destinationCredential != default)
            {
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
            // TODO: do we throw an error if they specify the destination?
            // Read in Job Plan File
            // JobPlanReader.Read(file)
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<BlobJobPartInternal> ProcessJobToJobPartAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            yield return new BlockBlobServiceCopyPartInternal(this);
        }

        /// <summary>
        /// Get length of the blob beforehand to determine if chunking the blob is the best path
        /// </summary>
        /// <returns>The length of the source blob</returns>
        private async Task<long?> GetSourceLength()
        {
            BlobBaseClient sourceBlobCLient = new BlobBaseClient(SourceUri);

            try
            {
                BlobProperties sourceProperties = await sourceBlobCLient.GetPropertiesAsync().ConfigureAwait(false);
                return sourceProperties.ContentLength;
            }
            catch (Exception ex)
            {
                await InvokeCopyFailed(ex).ConfigureAwait(false);
                return default;
            }
        }

        #region PartitionedChunker
        internal async Task SingleAsyncCopyInternal(long expectedBytes)
        {
            try
            {
                await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);

                CopyFromUriOperation copyOperation = await DestinationBlobClient.StartCopyFromUriAsync(SourceUri, CopyFromUriOptions).ConfigureAwait(false);
                // TODO: Might want to figure out an appropriate delay to poll the wait for completion
                // TODO: Also might want to cancel this if it takes too long to prevent any threads to be hung up on this operation.
                await copyOperation.WaitForCompletionAsync(CancellationTokenSource.Token).ConfigureAwait(false);

                if (copyOperation.HasCompleted && copyOperation.HasValue)
                {
                    if (copyOperation.Value == expectedBytes)
                    {
                        await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
                    }
                    else
                    {
                        await InvokeCopyFailed(
                        new Exception("Service Copy has not completed with the correct amount of bytes")).ConfigureAwait(false);
                    }
                }
                else
                {
                    await InvokeCopyFailed(
                        new Exception("Copy Has not finished within the amount of polling time.")).ConfigureAwait(false);
                }

                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeCopyFailed(ex).ConfigureAwait(false);
            }
        }

        internal async Task SingleSyncCopyInternal()
        {
            try
            {
                await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);

                Response<BlobCopyInfo> response = await DestinationBlobClient.SyncCopyFromUriAsync(
                    SourceUri,
                    CopyFromUriOptions,
                    CancellationTokenSource.Token).ConfigureAwait(false);

                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeCopyFailed(ex).ConfigureAwait(false);
            }
        }

        internal async Task StageBlockInternal(
            long offset,
            long blockLength,
            BlobSingleCopyOptions options,
            CancellationToken cancellationToken)
        {
            // Stage Block only accepts LeaseId.
            StageBlockFromUriOptions copyOptions = new StageBlockFromUriOptions()
            {
                SourceRange = new HttpRange(offset, blockLength),
                SourceConditions = options.SourceConditions,
                DestinationConditions = options.DestinationConditions,
                SourceAuthentication = options.SourceAuthentication,
            };
            try
            {
                await OnTransferStatusChanged(StorageTransferStatus.InProgress, true).ConfigureAwait(false);
                await DestinationBlobClient.StageBlockFromUriAsync(
                    SourceUri,
                    Shared.StorageExtensions.GenerateBlockId(offset),
                    copyOptions,
                    cancellationToken).ConfigureAwait(false);
                /*
                await commitBlockController.InvokeEvent(
                    new BlobStageChunkEventArgs(
                        TransferId,
                        true,
                        offset,
                        blockLength,
                        true,
                        cancellationToken)).ConfigureAwait(false);
                */
            }
            catch (Exception ex)
            {
                // Unexpected exception
                await InvokeCopyFailed(ex).ConfigureAwait(false);
            }
        }

        internal async Task CommitBlockListInternal(
            List<(long Offset, long Size)> partitions,
            BlobSingleCopyOptions copyOptions,
            CancellationToken cancellationToken)
        {
            CommitBlockListOptions options = new CommitBlockListOptions()
            {
                Metadata = copyOptions.Metadata,
                Tags = copyOptions.Tags,
                AccessTier = copyOptions.AccessTier,
                LegalHold = copyOptions.LegalHold,
            };
            try
            {
                Response<BlobContentInfo> response = await DestinationBlobClient.CommitBlockListAsync(
                        partitions.Select(partition => Shared.StorageExtensions.GenerateBlockId(partition.Offset)),
                        options,
                        cancellationToken).ConfigureAwait(false);

                await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await InvokeCopyFailed(ex).ConfigureAwait(false);
            }
        }

        private async Task<List<(long Offset, long Size)>> QueueStageBlockRequests(
            long blockSize,
            long fileLength,
            BlobSingleCopyOptions args,
            CancellationToken cancellationToken)
        {
            // Wrap the staging and commit calls in an Upload span for
            // distributed tracing
            StorageClientDiagnostics diagnostics = new StorageClientDiagnostics(BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));

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
            List<(long Offset, long Length)> commitBlockList,
            BlockBlobServiceCopyTransferJob job)
        => new CommitChunkHandler(
            expectedLength,
            GetBlockListCommitHandlerBehaviors(commitBlockList, job));

        internal static CommitChunkHandler.Behaviors GetBlockListCommitHandlerBehaviors(
            List<(long Offset, long Length)> commitBlockList,
            BlockBlobServiceCopyTransferJob job)
        {
            return new CommitChunkHandler.Behaviors
            {
                QueueCommitBlockTask = async () =>
                        await job.CommitBlockListInternal(
                            commitBlockList,
                            job.CopyFromUriOptions,
                            job.CancellationTokenSource.Token).ConfigureAwait(false),
                ReportProgressInBytes = (long bytesWritten) =>
                    job.CopyFromUriOptions?.ProgressHandler?.Report(bytesWritten),
                InvokeFailedHandler = async (ex) => await job.InvokeCopyFailed(ex).ConfigureAwait(false),
                UpdateTransferStatus = async (StorageTransferStatus status)
                    => await job.OnTransferStatusChanged(status, true).ConfigureAwait(false)
            };
        }
        */
        #endregion

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
                    if ((CopyFromUriOptions != null) &&
                        (CopyFromUriOptions?.GetTransferStatus() != null))
                    {
                        await CopyFromUriOptions.GetTransferStatus().Invoke(
                                new StorageTransferStatusEventArgs(
                                    TransferId,
                                    transferStatus,
                                    true,
                                    CancellationTokenSource.Token)).ConfigureAwait(false);
                    }
                }
                else
                {
                    if ((CopyFromUriOptions != null) &&
                        (CopyFromUriOptions?.GetTransferStatus() != null))
                    {
                        CopyFromUriOptions.GetTransferStatus()?.Invoke(new StorageTransferStatusEventArgs(
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

        private async Task InvokeCopyFailed(Exception ex)
        {
            CopyFromUriOptions?.GetCopyFailed()?.Invoke(
                    new BlobSingleCopyFailedEventArgs(
                    TransferId,
                    SourceUri,
                    DestinationBlobClient,
                    ex,
                    false,
                    CancellationTokenSource.Token));
            // Trigger job cancellation if the failed handler is enabled
            TriggerJobCancellation();
            await OnTransferStatusChanged(StorageTransferStatus.Completed, true).ConfigureAwait(false);
        }
    }
}
