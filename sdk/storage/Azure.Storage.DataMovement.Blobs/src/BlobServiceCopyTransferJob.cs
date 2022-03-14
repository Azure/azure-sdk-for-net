// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;

namespace Azure.Storage.DataMovement.Blobs
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
        public BlobClientConfiguration DestinationBlobConfiguration;

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
        /// <param name="jobId"></param>
        /// <param name="sourceUri"></param>
        /// <param name="destinationClient"></param>
        /// <param name="copyMethod"></param>
        /// <param name="copyFromUriOptions"></param>
        public BlobServiceCopyTransferJob(
            string jobId,
            Uri sourceUri,
            BlobBaseClient destinationClient,
            BlobCopyMethod copyMethod,
            BlobCopyFromUriOptions copyFromUriOptions)
            : base(jobId)
        {
            SourceUri = sourceUri;
            DestinationBlobClient = destinationClient;
            DestinationBlobConfiguration = new BlobClientConfiguration()
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
                    if (CopyMethod == BlobCopyMethod.ServiceSideAsyncCopy)
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
                    else //if(CopyMethod == BlobServiceCopyMethod.ServiceSideSyncCopy)
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
                // Current single copy only supports SAS
                if (!string.IsNullOrEmpty(credential.SourceTransferCredential.ConnectionString))
                {
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(credential.SourceTransferCredential.ConnectionString);
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
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(DestinationBlobConfiguration.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        DestinationBlobClient = new BlobBaseClient(
                            credential.DestinationTransferCredential.ConnectionString,
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
                else if (credential.SourceTransferCredential.SasCredential != default)
                {
                    DestinationBlobClient = new BlobBaseClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.SasCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else if (credential.SourceTransferCredential.SharedKeyCredential != default)
                {
                    DestinationBlobClient = new BlobBaseClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.SharedKeyCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else if (credential.SourceTransferCredential.TokenCredential != default)
                {
                    DestinationBlobClient = new BlobBaseClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.TokenCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(credential));
                }
            }
            // TODO: do we throw an error if they specify the destination?
            // Read in Job Plan File
            // JobPlanReader.Read(file)
            return ProcessCopyTransfer();
        }
    }
}
