// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Blob Directory Upload Job
    /// </summary>
    internal class BlobUploadDirectoryTransferJob : BlobTransferJobInternal
    {
        private string _sourceLocalPath;

        /// <summary>
        /// Gets the local path of the source file.
        /// </summary>
        public string SourceLocalPath => _sourceLocalPath;

        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobClientConfiguration DestinationBlobConfiguration;

        /// <summary>
        /// The destination blob client.
        /// </summary>
        internal BlobVirtualDirectoryClient DestinationBlobDirectoryClient;

        internal BlobDirectoryUploadOptions _uploadOptions;

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads. Is it worth it to make a whole other class
        // for each operation type.
        public BlobDirectoryUploadOptions UploadOptions => _uploadOptions;

        /*
        /// <summary>
        /// Number of Blobs that succeeded in transfer
        /// </summary>
        internal int CurrentBlobsSuccesfullyTransferred;
        /// <summary>
        /// Number of blobs that were skipped in transfer due to overwrite being set to not overwrite files, but the files exists already
        /// </summary>
        internal int CurrentBlobsSkippedTransferring;
        /// <summary>
        /// Number of blobs that failed transferred.
        /// </summary>
        internal int CurrentBlobsFailedTransferred;
        /// <summary>
        /// Number of bytes transferred succesfully.
        /// </summary>
        internal long CurrentTotalBytesTransferred;
        /// <summary>
        /// Transfer Status
        /// </summary>
        internal StorageJobTransferStatus TransferStatus;
        */

        private bool _overwrite;

        /// <summary>
        /// Defines whether to overwrite the blobs within the Blob Virtual Directory if they already exist.
        ///
        /// If the blob already exist and the Overwrite value is set to false
        /// then we will follow error handling based on what the user has set.
        ///
        /// If this value is not defined it is defaulted false.
        /// </summary>
        public bool Overwrite => _overwrite;

        /// <summary>
        /// Creates Upload Transfer Job.
        ///
        /// TODO: better decription and parameters descriptions
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceLocalPath"></param>
        /// <param name="destinationClient"></param>
        /// <param name="overwrite"></param>
        /// <param name="uploadOptions"></param>
        public BlobUploadDirectoryTransferJob(
            string jobId,
            string sourceLocalPath,
            bool overwrite,
            BlobVirtualDirectoryClient destinationClient,
            BlobDirectoryUploadOptions uploadOptions)
            : base(jobId)
        {
            _sourceLocalPath = sourceLocalPath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            DestinationBlobDirectoryClient = destinationClient;
            DestinationBlobConfiguration = new BlobClientConfiguration()
            {
                BlobContainerName = destinationClient.BlobContainerName,
                AccountName = destinationClient.AccountName,
                Name = destinationClient.DirectoryPath
            };
            _uploadOptions = uploadOptions;
            _overwrite = overwrite;
        }

        /// <summary>
        /// Gets the Task for calling upload on a single blob
        /// </summary>
        /// <param name="fullPathName"></param>
        /// <returns></returns>
        internal async Task<Response<BlobContentInfo>> GetSingleUploadTaskAsync(string fullPathName)
        {
            // Replace backward slashes meant to be directory name separators
            string blobName = fullPathName.Substring(SourceLocalPath.Length + 1);
            blobName = blobName.Replace(@"\", "/");

            BlockBlobClient blockBlobClient = DestinationBlobDirectoryClient.GetBlockBlobClient(blobName);

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
            {
                AccessTier = UploadOptions.AccessTier,
                TransferOptions = UploadOptions.TransferOptions,
                ImmutabilityPolicy = UploadOptions.ImmutabilityPolicy,
                LegalHold = UploadOptions.LegalHold,
                TransactionalHashingOptions = UploadOptions.TransactionalHashingOptions,
            };

            Response<BlobContentInfo> response;

            // This would not support PIPE or FIFO files, that require to be open from both ends
            using (FileStream uploadStream = new FileStream(fullPathName, FileMode.Open, FileAccess.Read))
            {
                response = await blockBlobClient.UploadAsync(
                    uploadStream,
                    blobUploadOptions ).ConfigureAwait(false);
            }
            return response;
        }

#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessDirectoryTransfer(
            TaskFactory taskFactory,
            BlobJobTransferScheduler scheduler,
            bool async = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Begin enumerating files within source directory: {transferJob.SourceLocalPath}",
                    false).EnsureCompleted();
                */
                PathScannerFactory scannerFactory = new PathScannerFactory(SourceLocalPath);
                PathScanner scanner = scannerFactory.BuildPathScanner();
                IEnumerable<FileSystemInfo> pathList = scanner.Scan();
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Completed enumerating files within source directory: {transferJob.SourceLocalPath}\n",
                    false).EnsureCompleted();
                */

                List<Task> fileUploadTasks = new List<Task>();
                foreach (FileSystemInfo path in pathList)
                {
                    if (path.GetType() == typeof(FileInfo))
                    {
                        Task singleUploadTask = taskFactory.StartNew(
                            ProcessSingleUploadTransfer(path.FullName),
                            cancellationToken: CancellationTokenSource.Token,
                            creationOptions: TaskCreationOptions.LongRunning,
                            scheduler: scheduler);
                        fileUploadTasks.Add(singleUploadTask);
                    }
                }
                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                    logLevel: DataMovementLogLevel.Information,
                    message: $"Created all upload tasks for the source directory: {transferJob.SourceLocalPath} to upload to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
                    false).EnsureCompleted();
                */

                // Wait for all the remaining blobs to finish upload before logging that the transfer has finished.
                Task.WhenAll(fileUploadTasks).Wait();

                /* TODO: move this to Core.Diagnostics Logger
                transferJob.Logger.LogAsync(
                logLevel: DataMovementLogLevel.Information,
                message: $"Completed all upload tasks for the source directory: {transferJob.SourceLocalPath} and uploaded to the destination directory: {transferJob.DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
                false).EnsureCompleted();
                */
            };
        }

#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessSingleUploadTransfer(string fullPathName, bool async = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                // Replace backward slashes meant to be directory name separators
                string blobName = fullPathName.Substring(SourceLocalPath.Length + 1);
                blobName = blobName.Replace(@"\", "/");

                BlobClient destinationBlobClient = DestinationBlobDirectoryClient.GetBlobClient(blobName);

                BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
                {
                    AccessTier = UploadOptions.AccessTier,
                    TransferOptions = UploadOptions.TransferOptions,
                    ImmutabilityPolicy = UploadOptions.ImmutabilityPolicy,
                    LegalHold = UploadOptions.LegalHold,
                    TransactionalHashingOptions = UploadOptions.TransactionalHashingOptions,
                };

                /* TODO: move this to Core.Diagnostics Logger
                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Upload Directory Transfer source: {SourceLocalPath}; destination: {DestinationBlobDirectoryClient.Uri}",
                    async).EnsureCompleted();
                */
                // Do only blockblob upload for now for now
                try
                {
                    Response<BlobContentInfo> response = destinationBlobClient.Upload(
                        _sourceLocalPath,
                        blobUploadOptions,
                        CancellationTokenSource.Token);
                    if (response != null && response.Value != null)
                    {
                        /* TODO: move this to Core.Diagnostics Logger
                        Logger.LogAsync(DataMovementLogLevel.Information,
                            $"Transfer succeeded on from source:{SourceLocalPath} to destination:{DestinationBlobDirectoryClient.Uri.AbsoluteUri}",
                            async).EnsureCompleted();
                        */
                    }
                    else
                    {
                        /* TODO: move this to Core.Diagnostics Logger
                        Logger.LogAsync(DataMovementLogLevel.Error,
                            $"Upload Transfer Failed due to unknown reasons. Upload Transfer returned null results",
                            async).EnsureCompleted();
                        */
                    }
                }
                //TODO: catch other type of exceptions and handle gracefully
#pragma warning disable CS0168 // Variable is declared but never used
                catch (RequestFailedException ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    /* TODO: move this to Core.Diagnostics Logger
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Upload Transfer Failed due to the following: {ex.ErrorCode}: {ex.Message}", async).EnsureCompleted();
                    */
                    // Progress Handling is already done by the upload call
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    /* TODO: move this to Core.Diagnostics Logger
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
            if (credential?.DestinationTransferCredential != default)
            {
                if (!string.IsNullOrEmpty(credential.SourceTransferCredential.ConnectionString))
                {
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(credential.SourceTransferCredential.ConnectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(DestinationBlobConfiguration.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        DestinationBlobDirectoryClient = new BlobVirtualDirectoryClient(
                            credential.DestinationTransferCredential.ConnectionString,
                            DestinationBlobConfiguration.BlobContainerName,
                            DestinationBlobConfiguration.Name,
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
