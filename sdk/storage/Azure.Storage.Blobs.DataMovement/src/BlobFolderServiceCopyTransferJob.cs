// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlobFolderServiceCopyTransferJob : BlobTransferJobInternal
    {
        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration SourceBlobConfiguration;

        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration DestinationBlobConfiguration;

        /// <summary>
        /// Directory clients to perform the copy directory job
        /// </summary>
        internal BlobFolderClient SourceBlobDirectoryClient;
        internal BlobFolderClient DestinationBlobDirectoryClient;

        /// <summary>
        /// Copy method to choose between StartCopyFromUri or SyncCopyFromUri
        /// </summary>
        public readonly BlobCopyMethod CopyMethod;

        /// <summary>
        /// The <see cref="BlobFolderCopyFromUriOptions"/>.
        /// </summary>
        internal BlobFolderCopyFromUriOptions _copyFromUriOptions;

        /// <summary>
        /// Gets the <see cref="BlobFolderCopyFromUriOptions"/>.
        /// </summary>
        public BlobFolderCopyFromUriOptions CopyFromUriOptions => _copyFromUriOptions;

        private ClientDiagnostics _diagnostics;

        /// <summary>
        /// Client Diagnostics
        /// </summary>
        public ClientDiagnostics Diagnostics => _diagnostics;

        /// <summary>
        /// Creates Service Copy Directory Transfer Job
        ///
        /// TODO; better descriptions and update parameter descriptions
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceClient"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod"></param>
        /// <param name="copyFromUriOptions"></param>
        /// <param name="errorOption"></param>
        public BlobFolderServiceCopyTransferJob(
            string transferId,
            BlobFolderClient sourceClient,
            BlobFolderClient destinationClient,
            BlobCopyMethod copyMethod,
            BlobFolderCopyFromUriOptions copyFromUriOptions,
            ErrorHandlingOptions errorOption)
            : base(transferId: transferId,
                  errorHandling: errorOption)
        {
            SourceBlobDirectoryClient = sourceClient;
            SourceBlobConfiguration = new BlobBaseConfiguration()
            {
                BlobContainerName = sourceClient.BlobContainerName,
                AccountName = sourceClient.AccountName,
                Name = sourceClient.DirectoryPrefix
            };
            DestinationBlobDirectoryClient = destinationClient;
            DestinationBlobConfiguration = new BlobBaseConfiguration()
            {
                BlobContainerName = destinationClient.BlobContainerName,
                AccountName = destinationClient.AccountName,
                Name = destinationClient.DirectoryPrefix
            };
            CopyMethod = copyMethod;
            _copyFromUriOptions = copyFromUriOptions;
            _diagnostics = new ClientDiagnostics(BlobFolderClientInternals.GetClientOptions(sourceClient));
        }

        /// <summary>
        /// Gets sing copy job for the job scheduler
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        internal async Task<CopyFromUriOperation> GetSingleAsyncCopyTaskAsync(string blobName)
        {
            //TODO: check if the listing operation gives the full blob path name or just everything but the prefix
            BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceBlobDirectoryClient.Uri);
            sourceUriBuilder.BlobName += $"/{blobName}";

            BlobBaseClient blobClient = DestinationBlobDirectoryClient.GetBlobBaseClient(blobName);
            BlockBlobClient blockBlobClient = (BlockBlobClient) blobClient;

            BlobCopyFromUriOptions blobCopyFromUriOptions = new BlobCopyFromUriOptions()
            {
                AccessTier = CopyFromUriOptions?.AccessTier,
                RehydratePriority = CopyFromUriOptions?.RehydratePriority,
                DestinationImmutabilityPolicy = CopyFromUriOptions?.DestinationImmutabilityPolicy,
                LegalHold = CopyFromUriOptions?.LegalHold,
                SourceAuthentication = CopyFromUriOptions?.SourceAuthentication,
            };

            return await blockBlobClient.StartCopyFromUriAsync(sourceUriBuilder.ToUri(), blobCopyFromUriOptions).ConfigureAwait(false);
        }

#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessDirectoryTransfer()
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Begin enumerating files within source directory: {transferJob.SourceDirectoryUri.AbsoluteUri}",
                    false).EnsureCompleted();
                */
                OnTransferStatusChanged(StorageTransferStatus.InProgress, false).EnsureCompleted();
                Pageable<BlobItem> blobs = SourceBlobDirectoryClient.GetBlobs();
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                logLevel: DataMovementLogLevel.Information,
                message: $"Completed enumerating files within source directory: {transferJob.SourceDirectoryUri.AbsoluteUri}\n",
                false).EnsureCompleted();
                */

                List<Task> fileUploadTasks = new List<Task>();
                foreach (BlobItem blob in blobs)
                {
                    //ProcessSingleCopyTransfer(blob.Name)
                    //fileUploadTasks.Add(singleDownloadTask);
                }
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Created all upload tasks for the source directory: {transferJob.SourceDirectoryUri.AbsoluteUri} to upload to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
                    false).EnsureCompleted();
                */

                // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
                Task.WhenAll(fileUploadTasks).Wait();
                OnTransferStatusChanged(StorageTransferStatus.Completed, false).EnsureCompleted();
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Completed all upload tasks for the source directory: {transferJob.SourceDirectoryUri.AbsoluteUri} and uploaded to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
                    false).EnsureCompleted();
                */
            };
        }

        /// <summary>
        /// Gets sing copy job for the job scheduler
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        internal async Task<Response<BlobCopyInfo>> GetSingleSyncCopyTaskAsync(string blobName)
        {
            //TODO: check if the listing operation gives the full blob path name or just everything but the prefix
            BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceBlobDirectoryClient.Uri);
            sourceUriBuilder.BlobName += $"/{blobName}";

            BlobBaseClient blobClient = DestinationBlobDirectoryClient.GetBlobBaseClient(blobName);
            BlockBlobClient blockBlobClient = (BlockBlobClient)blobClient;

            BlobCopyFromUriOptions blobCopyFromUriOptions = new BlobCopyFromUriOptions()
            {
                AccessTier = CopyFromUriOptions?.AccessTier,
                RehydratePriority = CopyFromUriOptions?.RehydratePriority,
                DestinationImmutabilityPolicy = CopyFromUriOptions?.DestinationImmutabilityPolicy,
                LegalHold = CopyFromUriOptions?.LegalHold,
                SourceAuthentication = CopyFromUriOptions?.SourceAuthentication,
            };

            return await blockBlobClient.SyncCopyFromUriAsync(sourceUriBuilder.ToUri(), blobCopyFromUriOptions).ConfigureAwait(false);
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <param name="blobName">Blob Name in the Source that is to be copied</param>
        /// <param name="async">Defines whether the oepration should be async</param>
        /// <returns>The Task to perform the Upload operation.</returns>
#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessSingleCopyTransfer(string blobName, bool async = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceBlobDirectoryClient.Uri);
                sourceUriBuilder.BlobName += $"/{blobName}";
                Uri sourceBlobUri = sourceUriBuilder.ToUri();

                BlobClient destinationBlobClient = DestinationBlobDirectoryClient.GetBlobClientCore(blobName);

                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here
                /* TODO: replace with Azure.Core.Diagnotiscs logger
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Single Copy Transfer source: {sourceBlobUri.AbsoluteUri}; destination: {destinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
                */
                // Do only blockblob upload for now for now
                try
                {
                    BlobCopyFromUriOptions blobCopyFromUriOptions = new BlobCopyFromUriOptions()
                    {
                        AccessTier = CopyFromUriOptions?.AccessTier,
                        RehydratePriority = CopyFromUriOptions?.RehydratePriority,
                        DestinationImmutabilityPolicy = CopyFromUriOptions?.DestinationImmutabilityPolicy,
                        LegalHold = CopyFromUriOptions?.LegalHold,
                        SourceAuthentication = CopyFromUriOptions?.SourceAuthentication,
                    };

                    if (CopyMethod == BlobCopyMethod.Copy)
                    {
                        CopyFromUriOperation copyOperation = destinationBlobClient.StartCopyFromUri(sourceBlobUri, blobCopyFromUriOptions);
                        // TODO: Might want to figure out an appropriate delay to poll the wait for completion
                        // TODO: Also might want to cancel this if it takes too long to prevent any threads to be hung up on this operation.
                        copyOperation.WaitForCompletion(CancellationTokenSource.Token);

                        if (copyOperation.HasCompleted && copyOperation.HasValue)
                        {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                            Logger.LogAsync(DataMovementLogLevel.Information, $"Copy Transfer succeeded on from source:{sourceBlobUri.AbsoluteUri} to destination:{destinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
                            */
                        }
                        else
                        {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                            Logger.LogAsync(DataMovementLogLevel.Error, $"Copy Transfer Failed due to unknown reasons. Upload Transfer returned null results", async).EnsureCompleted();
                            */
                        }
                    }
                    else //if(CopyMethod == BlobServiceCopyMethod.ServiceSideSyncCopy)
                    {
                        Response<BlobCopyInfo> response = destinationBlobClient.SyncCopyFromUri(sourceBlobUri, blobCopyFromUriOptions);
                        if (response != null && response.Value != null)
                        {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                            Logger.LogAsync(DataMovementLogLevel.Information, $"Copy Transfer succeeded on from source:{sourceBlobUri.AbsoluteUri} to destination:{destinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
                            */
                        }
                        else
                        {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                            Logger.LogAsync(DataMovementLogLevel.Error, $"Copy Transfer Failed due to unknown reasons. Upload Transfer returned null results", async).EnsureCompleted();
                            */
                        }
                    }
                }
                //TODO: catch other type of exceptions and handle gracefully
#pragma warning disable CS0168 // Variable is declared but never used
                catch (RequestFailedException ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Upload Transfer Failed due to the following: {ex.ErrorCode}: {ex.Message}", async).EnsureCompleted();
                            */
                    // Progress Handling is already done by the upload call
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Upload Transfer Failed due to the following: {ex.Message}", async).EnsureCompleted();
                            */
                    // Progress Handling is already done by the upload call
                }
            };
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
            // Recreate source client if new credentials are present
            if (sourceCredential != default)
            {
                if (sourceCredential.GetType() == typeof(string))
                {
                    string connectionString = (string)sourceCredential;
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(connectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceBlobDirectoryClient.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        SourceBlobDirectoryClient = new BlobFolderClient(
                            connectionString,
                            SourceBlobConfiguration.BlobContainerName,
                            SourceBlobConfiguration.Name,
                            BlobFolderClientInternals.GetClientOptions(SourceBlobDirectoryClient));
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
                    SourceBlobDirectoryClient = new BlobFolderClient(
                        SourceBlobConfiguration.Uri,
                        sasCredential,
                        BlobFolderClientInternals.GetClientOptions(SourceBlobDirectoryClient));
                }
                else if (sourceCredential.GetType() == typeof(StorageSharedKeyCredential))
                {
                    StorageSharedKeyCredential storageSharedKeyCredential = (StorageSharedKeyCredential)sourceCredential;
                    SourceBlobDirectoryClient = new BlobFolderClient(
                        SourceBlobConfiguration.Uri,
                        storageSharedKeyCredential,
                        BlobFolderClientInternals.GetClientOptions(SourceBlobDirectoryClient));
                }
                else if (sourceCredential.GetType() == typeof(TokenCredential))
                {
                    TokenCredential tokenCredential = (TokenCredential)sourceCredential;
                    SourceBlobDirectoryClient = new BlobFolderClient(
                        SourceBlobConfiguration.Uri,
                        tokenCredential,
                        BlobFolderClientInternals.GetClientOptions(SourceBlobDirectoryClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(destinationCredential));
                }
            }
            // Recreate destination client if new credentials are present
            if (destinationCredential != default)
            {
                if (destinationCredential.GetType() == typeof(string))
                {
                    string connectionString = (string) destinationCredential;
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(connectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(DestinationBlobDirectoryClient.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        DestinationBlobDirectoryClient = new BlobFolderClient(
                            connectionString,
                            SourceBlobConfiguration.BlobContainerName,
                            SourceBlobConfiguration.Name,
                            BlobFolderClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
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
                    DestinationBlobDirectoryClient = new BlobFolderClient(
                        DestinationBlobConfiguration.Uri,
                        sasCredential,
                        BlobFolderClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else if (destinationCredential.GetType() == typeof(StorageSharedKeyCredential))
                {
                    StorageSharedKeyCredential sharedKeyCredential = (StorageSharedKeyCredential)destinationCredential;
                    DestinationBlobDirectoryClient = new BlobFolderClient(
                        DestinationBlobConfiguration.Uri,
                        sharedKeyCredential,
                        BlobFolderClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else if (destinationCredential.GetType() == typeof(TokenCredential))
                {
                    TokenCredential tokenCredential = (TokenCredential)destinationCredential;
                    DestinationBlobDirectoryClient = new BlobFolderClient(
                        DestinationBlobConfiguration.Uri,
                        tokenCredential,
                        BlobFolderClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(destinationCredential));
                }
            }
            // TODO: do we throw an error if they specify the destination?
            // Read in Job Plan File
            // JobPlanReader.Read(file)
            TransferStatus = StorageTransferStatus.Queued;
            //ProcessDirectoryTransfer(taskFactory, scheduler);
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
                    if ((CopyFromUriOptions != null) &&
                        (CopyFromUriOptions?.GetTransferStatus() != null))
                    {
                        await CopyFromUriOptions.GetTransferStatus().RaiseAsync(
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
            }
        }

        public override IAsyncEnumerable<BlobJobPartInternal> ProcessJobToJobPartAsync()
        {
            throw new NotImplementedException();
        }

        public override IAsyncEnumerable<Func<Task>> ProcessPartToChunkAsync()
        {
            throw new NotImplementedException();
        }
    }
}
