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

namespace Azure.Storage.Blobs.DataMovement
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlobServiceCopyTransferJob : BlobTransferJobInternal
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
        internal BlobBaseClient DestinationBlobClient;

        /// <summary>
        /// Type of Copy to occur
        /// </summary>
        public readonly BlobCopyMethod CopyMethod;

        internal BlobCopyFromUriOptions _copyFromUriOptions;

        /// <summary>
        /// Gets the <see cref="BlobCopyFromUriOptions"/>.
        /// </summary>
        public BlobCopyFromUriOptions CopyFromUriOptions => _copyFromUriOptions;

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
        public BlobServiceCopyTransferJob(
            string transferId,
            Uri sourceUri,
            BlobBaseClient destinationClient,
            BlobCopyMethod copyMethod,
            BlobCopyFromUriOptions copyFromUriOptions,
            ErrorHandlingOptions errorOption)
            : base(transferId: transferId,
                  errorHandling: errorOption)
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

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public Task StartTransferTaskAsync()
        {
            // TODO: add other Copymethod Options
            // for now only do CopyMethod.ServiceSideAsyncCopy as a stub
            return DestinationBlobClient.StartCopyFromUriAsync(SourceUri);
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <param name="async">Defines whether the oepration should be async</param>
        /// <returns>The Task to perform the Upload operation.</returns>
#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessCopyTransfer(bool async = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here
                /* TODO: replace with Azure.Core.Diagnotiscs logger
                Logger.LogAsync(DataMovementLogLevel.Information,$"Processing Copy Transfer source: {SourceUri.AbsoluteUri}; destination: {DestinationBlobClient.Uri}", async).EnsureCompleted();
                */
                // Do only blockblob upload for now for now
                try
                {
                    if (CopyMethod == BlobCopyMethod.Copy)
                    {
                        CopyFromUriOperation copyOperation = DestinationBlobClient.StartCopyFromUri(SourceUri, CopyFromUriOptions);
                        // TODO: Might want to figure out an appropriate delay to poll the wait for completion
                        // TODO: Also might want to cancel this if it takes too long to prevent any threads to be hung up on this operation.
                        copyOperation.WaitForCompletion(CancellationTokenSource.Token);

                        if (copyOperation.HasCompleted && copyOperation.HasValue)
                        {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                            Logger.LogAsync(DataMovementLogLevel.Information, $"Copy Transfer succeeded on from source:{SourceUri.AbsoluteUri} to destination:{DestinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
                            */
                        }
                        else
                        {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                            Logger.LogAsync(DataMovementLogLevel.Error, $"Copy Transfer Failed due to unknown reasons. Upload Transfer returned null results", async).EnsureCompleted();
                            */
                        }
                    }
                    else if (CopyMethod == BlobCopyMethod.SyncCopy)
                    {
                        Response<BlobCopyInfo> response = DestinationBlobClient.SyncCopyFromUri(SourceUri, CopyFromUriOptions);
                        if (response != null && response.Value != null)
                        {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                            Logger.LogAsync(DataMovementLogLevel.Information, $"Copy Transfer succeeded on from source:{SourceUri.AbsoluteUri} to destination:{DestinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
                            */
                        }
                        else
                        {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                            Logger.LogAsync(DataMovementLogLevel.Error, $"Copy Transfer Failed due to unknown reasons. Upload Transfer returned null results", async).EnsureCompleted();
                            */
                        }
                    }
                    else if (CopyMethod == BlobCopyMethod.DownloadThenUploadCopy)
                    {
                        BlockBlobClient sourceClient = new BlockBlobClient(SourceUri);
                        string sourcePath = Path.GetTempPath() + SourceUri.GetPath();
                        Response response = sourceClient.DownloadTo(sourcePath, CancellationTokenSource.Token);
                        BlockBlobClient blockBlobDestinationClient = (BlockBlobClient)DestinationBlobClient;
                        using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                        {
                            Response<BlobContentInfo> uploadResponse = blockBlobDestinationClient.Upload(fileStream);
                        }
                    }
                }
                //TODO: catch other type of exceptions and handle gracefully
                catch (RequestFailedException)
                {
                            /* TODO: replace with Azure.Core.Diagnotiscs logger
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Upload Transfer Failed due to the following: {ex.ErrorCode}: {ex.Message}", async).EnsureCompleted();
                            */
                    // Progress Handling is already done by the upload call
                }
                catch (Exception)
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
                        DestinationBlobClient = new BlobBaseClient(
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
                    DestinationBlobClient = new BlobBaseClient(
                        DestinationBlobConfiguration.Uri,
                        sasCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else if (destinationCredential.GetType() == typeof(StorageSharedKeyCredential))
                {
                    StorageSharedKeyCredential sharedKeyCredential = (StorageSharedKeyCredential)destinationCredential;
                    DestinationBlobClient = new BlobBaseClient(
                        DestinationBlobConfiguration.Uri,
                        sharedKeyCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else if (destinationCredential.GetType() == typeof(TokenCredential))
                {
                    TokenCredential tokenCredential = (TokenCredential)destinationCredential;
                    DestinationBlobClient = new BlobBaseClient(
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
