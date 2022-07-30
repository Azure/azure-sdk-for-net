// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement;
using Azure.Storage.Blobs;
using Azure.Core.Pipeline;
using Azure.Core;

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// Blob Directory Download Transfer Job
    /// </summary>
    internal class BlobFolderDownloadTransferJob : BlobTransferJobInternal
    {
        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration SourceBlobConfiguration;

        /// <summary>
        /// The source blob where it's contents will be downloaded when the job is performed.
        /// </summary>
        internal BlobFolderClient SourceBlobDirectoryClient;

        /// <summary>
        /// Local Path to store the downloaded contents from the source blob
        /// </summary>
        private string _destinationLocalPath;

        /// <summary>
        /// Gets the local Path to store the downloaded contents from the source blob
        /// </summary>
        public string DestinationLocalPath => _destinationLocalPath;

        /// <summary>
        /// The <see cref="StorageTransferOptions"/>.
        /// </summary>
        private BlobFolderDownloadOptions _options;

        /// <summary>
        /// The <see cref="BlobFolderDownloadOptions"/>.
        /// </summary>
        protected internal BlobFolderDownloadOptions Options => _options;

        private ClientDiagnostics _diagnostics;

        /// <summary>
        /// Client Diagnostics
        /// </summary>
        public ClientDiagnostics Diagnostics => _diagnostics;

        /// <summary>
        /// Creates Download Transfer Job
        /// </summary>
        /// <param name="transferId"></param>
        /// <param name="sourceClient"></param>
        /// <param name="destinationPath"></param>
        /// <param name="options"></param>
        /// <param name="errorOption"></param>
        public BlobFolderDownloadTransferJob(
            string transferId,
            BlobFolderClient sourceClient,
            string destinationPath,
            BlobFolderDownloadOptions options,
            ErrorHandlingOptions errorOption)
            : base(transferId: transferId,
                  errorHandling: errorOption)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _destinationLocalPath = destinationPath;
            SourceBlobDirectoryClient = sourceClient;
            SourceBlobConfiguration = new BlobBaseConfiguration()
            {
                BlobContainerName = sourceClient.BlobContainerName,
                AccountName = sourceClient.AccountName,
                Name = sourceClient.DirectoryPrefix
            };
            _options = options;
            _diagnostics = new ClientDiagnostics(BlobFolderClientInternals.GetClientOptions(sourceClient));
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <param name="blobName">Name of the blob in the directory that will be downloaded</param>
        /// <returns>The Task to perform the Upload operation.</returns>
        public async Task<Response> GetSingleDownloadTaskAsync(string blobName)
        {
            BlobBaseClient blockBlobClient = SourceBlobDirectoryClient.GetBlobBaseClient(blobName);
            string downloadPath = Path.Combine(DestinationLocalPath, blobName);

            Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));
            Response response;
            try
            {
                if (!((Options.OverwriteOptions == DownloadOverwriteMethod.Skip) && (File.Exists(downloadPath))))
                {
                    using (Stream destination = File.Create(downloadPath))
                    {
                        response = await blockBlobClient.DownloadToAsync(
                            downloadPath,
                            default,
                            Options.TransferOptions)
                            .ConfigureAwait(false);
                    }
                    Options.GetDownloadCompleted()?.Invoke(new BlobDownloadCompletedEventArgs(
                                    TransferId,
                                    blockBlobClient,
                                    downloadPath,
                                    response,
                                    false,
                                    CancellationTokenSource.Token));
                    return response;
                }
                else
                {
                    // Skipped
                }
            }
            catch (RequestFailedException ex)
            {
                Options.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                                TransferId,
                                blockBlobClient,
                                downloadPath,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                if (!ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnServiceFailure))
                {
                    PauseTransferJob();
                }
            }
            catch (IOException ex)
            {
                Options.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                                TransferId,
                                blockBlobClient,
                                downloadPath,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                if (!ErrorHandling.HasFlag(ErrorHandlingOptions.ContinueOnLocalFilesystemFailure))
                {
                    PauseTransferJob();
                }
            }
            catch (OperationCanceledException)
            {
                // Job was cancelled
            }
            catch (Exception ex)
            {
                // Unexpected exception
                Options.GetDownloadFailed()?.Invoke(new BlobDownloadFailedEventArgs(
                                TransferId,
                                blockBlobClient,
                                downloadPath,
                                ex,
                                false,
                                CancellationTokenSource.Token));
                PauseTransferJob();
            }
            return default;
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
                        message: $"Begin enumerating files within source directory: {transferJob.SourceBlobDirectoryClient.DirectoryPath}",
                        false).EnsureCompleted();
                    */
                OnTransferStatusChanged(StorageTransferStatus.InProgress, false).EnsureCompleted();
                Pageable<BlobItem> blobs = SourceBlobDirectoryClient.GetBlobs();
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Completed enumerating files within source directory: {transferJob.SourceBlobDirectoryClient.DirectoryPath}\n",
                    false).EnsureCompleted();
                */
                List<Task> fileUploadTasks = new List<Task>();
                foreach (BlobItem blob in blobs)
                {
                    //ProcessSingleDownloadTransfer(blob.Name);
                    //fileUploadTasks.Add(singleDownloadTask);
                }
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Created all upload tasks for the source directory: {transferJob.SourceBlobDirectoryClient.DirectoryPath} to upload to the destination directory: {transferJob.DestinationLocalPath}",
                    false).EnsureCompleted();
                */
                // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
                Task.WhenAll(fileUploadTasks).Wait();
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Completed all upload tasks for the source directory: {transferJob.SourceBlobDirectoryClient.DirectoryPath} and uploaded to the destination directory: {transferJob.DestinationLocalPath}",
                    false).EnsureCompleted();
                */
                OnTransferStatusChanged(StorageTransferStatus.Completed, false).EnsureCompleted();
            };
        }

        /// <summary>
        /// Process Single Download Transfer
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="async"></param>
        /// <returns></returns>
#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessSingleDownloadTransfer(string blobName, bool async = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                BlobBaseClient blobClient = SourceBlobDirectoryClient.GetBlobBaseClient(blobName);
                string downloadPath = Path.Combine(DestinationLocalPath, blobName);

                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here

                /* TODO: replace with Azure.Core.Diagnotiscs logger
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Download Directory Transfer source: {SourceBlobDirectoryClient.Uri.AbsoluteUri}; destination: {DestinationLocalPath}",
                    async).EnsureCompleted();
                */
                // Do only blockblob upload for now for now

                BlobDownloadToOptions blobDownloadOptions = new BlobDownloadToOptions()
                {
                    TransferOptions = Options.TransferOptions,
                    //TransactionalHashingOptions = Options.TransactionalHashingOptions,
                };

                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));
                    Response response = blobClient.DownloadTo(
                        path: downloadPath,
                        options: blobDownloadOptions,
                        CancellationTokenSource.Token);
                    if (response != null)
                    {
                        /* TODO: replace with Azure.Core.Diagnotiscs logger
                        Logger.LogAsync(DataMovementLogLevel.Information,
                            $"Transfer succeeded on from source:{SourceBlobDirectoryClient.Uri.AbsoluteUri} to destination:{DestinationLocalPath}",
                            async).EnsureCompleted();
                        */
                    }
                    else
                    {
                        /* TODO: replace with Azure.Core.Diagnotiscs logger
                        Logger.LogAsync(DataMovementLogLevel.Error,
                            $"Download Directory Transfer Failed due to unknown reasons. Download Directory Transfer returned null results",
                            async).EnsureCompleted();
                        */
                    }
                }
                //TODO: catch other type of exceptions and handle gracefully
#pragma warning disable CS0168 // Variable is declared but never used
                catch (RequestFailedException ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    /* TODO: replace with Azure.Core.Diagnotiscs logger
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Download Directory Transfer Failed due to the following: {ex.ErrorCode}: {ex.Message}", async).EnsureCompleted();
                    */
                    Options.GetDownloadFailed()?.Invoke(
                        new BlobDownloadFailedEventArgs(
                            TransferId,
                            blobClient,
                            downloadPath,
                            ex,
                            true,
                            CancellationTokenSource.Token));
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    /* TODO: replace with Azure.Core.Diagnotiscs logger
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Download Directory Transfer Failed due to the following: {ex.Message}", async).EnsureCompleted();
                    */
                    // Progress Handling is already done by the upload call
                    Options.GetDownloadFailed()?.Invoke(
                        new BlobDownloadFailedEventArgs(
                            TransferId,
                            blobClient,
                            downloadPath,
                            ex,
                            true,
                            CancellationTokenSource.Token));
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
            // Checking Destination Credentials are not necessary here
            if (sourceCredential != default)
            {
                // Connection String
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
                    StorageSharedKeyCredential sharedKeyCredential = (StorageSharedKeyCredential)sourceCredential;
                    SourceBlobDirectoryClient = new BlobFolderClient(
                        SourceBlobConfiguration.Uri,
                        sharedKeyCredential,
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
                    throw Errors.InvalidArgument(nameof(sourceCredential));
                }
            }
            // else
            // If no credentials are passed or default is passed then we will just use the
            // credentials that are currently cached (or if none, then we assume it's public access)

            // TODO: do we throw an error if they specify the destination?
            // Read in Job Plan File
            // JobPlanReader.Read(file)
            OnTransferStatusChanged(StorageTransferStatus.Queued, false).EnsureCompleted();
            //ProcessDirectoryTransfer(taskFactory, scheduler);
        }

        /// <summary>
        /// To change all transfer statues at the same time
        /// </summary>
        /// <param name="transferStatus"></param>
        /// <param name="async"></param>
        /// <returns></returns>
        public async Task OnTransferStatusChanged(StorageTransferStatus transferStatus, bool async = true)
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
                            nameof(BlobFolderDownloadOptions),
                            nameof(BlobFolderDownloadOptions.TransferStatusEventHandler),
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
                                false,
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
