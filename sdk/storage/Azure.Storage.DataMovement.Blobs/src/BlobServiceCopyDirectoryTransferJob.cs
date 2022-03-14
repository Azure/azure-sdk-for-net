// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Storage.Blobs;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlobServiceCopyDirectoryTransferJob : BlobTransferJobInternal
    {
        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobClientConfiguration SourceBlobConfiguration;

        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobClientConfiguration DestinationBlobConfiguration;

        /// <summary>
        /// Directory clients to perform the copy directory job
        /// </summary>
        internal BlobVirtualDirectoryClient SourceBlobDirectoryClient;
        internal BlobVirtualDirectoryClient DestinationBlobDirectoryClient;

        /// <summary>
        /// Copy method to choose between StartCopyFromUri or SyncCopyFromUri
        /// </summary>
        internal readonly BlobCopyMethod CopyMethod;

        /// <summary>
        /// The <see cref="BlobDirectoryCopyFromUriOptions"/>.
        /// </summary>
        internal BlobDirectoryCopyFromUriOptions _copyFromUriOptions;

        /// <summary>
        /// Gets the <see cref="BlobDirectoryCopyFromUriOptions"/>.
        /// </summary>
        public BlobDirectoryCopyFromUriOptions CopyFromUriOptions => _copyFromUriOptions;

        /// <summary>
        /// Creates Service Copy Directory Transfer Job
        ///
        /// TODO; better descriptions and update parameter descriptions
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceClient"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod"></param>
        /// <param name="copyFromUriOptions"></param>
        public BlobServiceCopyDirectoryTransferJob(
            string jobId,
            BlobVirtualDirectoryClient sourceClient,
            BlobVirtualDirectoryClient destinationClient,
            BlobCopyMethod copyMethod,
            BlobDirectoryCopyFromUriOptions copyFromUriOptions)
            : base(jobId)
        {
            SourceBlobDirectoryClient = sourceClient;
            SourceBlobConfiguration = new BlobClientConfiguration()
            {
                BlobContainerName = sourceClient.BlobContainerName,
                AccountName = sourceClient.AccountName,
                Name = sourceClient.DirectoryPath
            };
            DestinationBlobDirectoryClient = destinationClient;
            DestinationBlobConfiguration = new BlobClientConfiguration()
            {
                BlobContainerName = destinationClient.BlobContainerName,
                AccountName = destinationClient.AccountName,
                Name = destinationClient.DirectoryPath
            };
            CopyMethod = copyMethod;
            _copyFromUriOptions = copyFromUriOptions;
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

            BlockBlobClient blockBlobClient = DestinationBlobDirectoryClient.GetBlockBlobClient(blobName);

            BlobCopyFromUriOptions blobCopyFromUriOptions = new BlobCopyFromUriOptions()
            {
                AccessTier = CopyFromUriOptions.AccessTier,
                RehydratePriority = CopyFromUriOptions.RehydratePriority,
                DestinationImmutabilityPolicy = CopyFromUriOptions.DestinationImmutabilityPolicy,
                LegalHold = CopyFromUriOptions.LegalHold,
                SourceAuthentication = CopyFromUriOptions.SourceAuthentication,
            };

            return await blockBlobClient.StartCopyFromUriAsync(sourceUriBuilder.ToUri(), blobCopyFromUriOptions).ConfigureAwait(false);
        }

#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessDirectoryTransfer(TaskFactory taskFactory, BlobJobTransferScheduler scheduler, bool async = true)
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
                    Task singleDownloadTask = taskFactory.StartNew(
                        ProcessSingleCopyTransfer(blob.Name),
                        cancellationToken: CancellationTokenSource.Token,
                        creationOptions: TaskCreationOptions.LongRunning,
                        scheduler: scheduler);
                    fileUploadTasks.Add(singleDownloadTask);
                }
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Created all upload tasks for the source directory: {transferJob.SourceDirectoryUri.AbsoluteUri} to upload to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
                    false).EnsureCompleted();
                */

                // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
                Task.WhenAll(fileUploadTasks).Wait();

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

            BlockBlobClient blockBlobClient = DestinationBlobDirectoryClient.GetBlockBlobClient(blobName);

            BlobCopyFromUriOptions blobCopyFromUriOptions = new BlobCopyFromUriOptions()
            {
                AccessTier = CopyFromUriOptions.AccessTier,
                RehydratePriority = CopyFromUriOptions.RehydratePriority,
                DestinationImmutabilityPolicy = CopyFromUriOptions.DestinationImmutabilityPolicy,
                LegalHold = CopyFromUriOptions.LegalHold,
                SourceAuthentication = CopyFromUriOptions.SourceAuthentication,
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

                BlobClient destinationBlobClient = DestinationBlobDirectoryClient.GetBlobClient(blobName);

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
                        AccessTier = CopyFromUriOptions.AccessTier,
                        RehydratePriority = CopyFromUriOptions.RehydratePriority,
                        DestinationImmutabilityPolicy = CopyFromUriOptions.DestinationImmutabilityPolicy,
                        LegalHold = CopyFromUriOptions.LegalHold,
                        SourceAuthentication = CopyFromUriOptions.SourceAuthentication,
                    };

                    if (CopyMethod == BlobCopyMethod.ServiceSideAsyncCopy)
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
        /// <param name="taskFactory"></param>
        /// <param name="scheduler"></param>
        /// <param name="credential"></param>
        /// <returns></returns>
        public override Action ProcessResumeTransfer(
            TaskFactory taskFactory,
            BlobJobTransferScheduler scheduler,
            ResumeTransferCredentials credential = default)
        {
            // Recreate source client if new credentials are present
            if (credential?.SourceTransferCredential != default)
            {
                if (!string.IsNullOrEmpty(credential.SourceTransferCredential.ConnectionString))
                {
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(credential.SourceTransferCredential.ConnectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceBlobDirectoryClient.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        SourceBlobDirectoryClient = new BlobVirtualDirectoryClient(
                            credential.SourceTransferCredential.ConnectionString,
                            SourceBlobConfiguration.BlobContainerName,
                            SourceBlobConfiguration.Name,
                            BlobVirtualDirectoryClientInternals.GetClientOptions(SourceBlobDirectoryClient));
                    }
                    else
                    {
                        // Mismatch in storage account host in the URL
                        throw Errors.InvalidConnectionString();
                    }
                }
                else if (credential.SourceTransferCredential.SasCredential != default)
                {
                    SourceBlobDirectoryClient = new BlobVirtualDirectoryClient(
                        SourceBlobConfiguration.Uri,
                        credential.SourceTransferCredential.SasCredential,
                        BlobVirtualDirectoryClientInternals.GetClientOptions(SourceBlobDirectoryClient));
                }
                else if (credential.SourceTransferCredential.SharedKeyCredential != default)
                {
                    SourceBlobDirectoryClient = new BlobVirtualDirectoryClient(
                        SourceBlobConfiguration.Uri,
                        credential.SourceTransferCredential.SharedKeyCredential,
                        BlobVirtualDirectoryClientInternals.GetClientOptions(SourceBlobDirectoryClient));
                }
                else if (credential.SourceTransferCredential.TokenCredential != default)
                {
                    SourceBlobDirectoryClient = new BlobVirtualDirectoryClient(
                        SourceBlobConfiguration.Uri,
                        credential.SourceTransferCredential.TokenCredential,
                        BlobVirtualDirectoryClientInternals.GetClientOptions(SourceBlobDirectoryClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(credential));
                }
            }
            // Recreate destination client if new credentials are present
            if (credential?.DestinationTransferCredential != default)
            {
                if (!string.IsNullOrEmpty(credential.DestinationTransferCredential.ConnectionString))
                {
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(credential.DestinationTransferCredential.ConnectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(DestinationBlobDirectoryClient.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        DestinationBlobDirectoryClient = new BlobVirtualDirectoryClient(
                            credential.DestinationTransferCredential.ConnectionString,
                            SourceBlobConfiguration.BlobContainerName,
                            SourceBlobConfiguration.Name,
                            BlobVirtualDirectoryClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                    }
                    else
                    {
                        // Mismatch in storage account host in the URL
                        throw Errors.InvalidConnectionString();
                    }
                }
                else if (credential.SourceTransferCredential.SasCredential != default)
                {
                    DestinationBlobDirectoryClient = new BlobVirtualDirectoryClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.SasCredential,
                        BlobVirtualDirectoryClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else if (credential.SourceTransferCredential.SharedKeyCredential != default)
                {
                    DestinationBlobDirectoryClient = new BlobVirtualDirectoryClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.SharedKeyCredential,
                        BlobVirtualDirectoryClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else if (credential.SourceTransferCredential.TokenCredential != default)
                {
                    DestinationBlobDirectoryClient = new BlobVirtualDirectoryClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.TokenCredential,
                        BlobVirtualDirectoryClientInternals.GetClientOptions(DestinationBlobDirectoryClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(credential));
                }
            }
            // TODO: do we throw an error if they specify the destination?
            // Read in Job Plan File
            // JobPlanReader.Read(file)
            return ProcessDirectoryTransfer(taskFactory, scheduler);
        }
    }
}
