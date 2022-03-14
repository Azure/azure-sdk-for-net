// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Uploading BLobTransfer Job
    /// </summary>
    internal class BlobUploadTransferJob : BlobTransferJobInternal
    {
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
        public BlobClientConfiguration DestinationBlobConfiguration;

        /// <summary>
        /// Gets the destination blob client
        /// </summary>
        internal BlobClient DestinationBlobClient;

        internal BlobUploadOptions _uploadOptions;

        /// <summary>
        /// Upload options for the upload task
        /// </summary>
        public BlobUploadOptions UploadOptions => _uploadOptions;

        /// <summary>
        /// Constructor. Creates Single Upload Transfer Job.
        ///
        /// TODO: better description; better param descriptions.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceLocalPath">
        /// Local File Path that contains the contents to upload.
        /// </param>
        /// <param name="destinationClient">
        /// Destination Blob where the contents will be uploaded to.
        /// </param>
        /// <param name="uploadOptions">
        /// Upload Transfer Options for the specific job.
        /// </param>
        public BlobUploadTransferJob(
            string jobId,
            string sourceLocalPath,
            BlobClient destinationClient,
            BlobUploadOptions uploadOptions)
            : base(jobId)
        {
            _sourceLocalPath = sourceLocalPath;
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            DestinationBlobClient = destinationClient;
            DestinationBlobConfiguration = new BlobClientConfiguration()
            {
                BlobContainerName = destinationClient.BlobContainerName,
                AccountName = destinationClient.AccountName,
                Name = destinationClient.Name
            };
            _uploadOptions = uploadOptions;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <param name="async">Defines whether the oepration should be async</param>
        /// <returns>The Task to perform the Upload operation.</returns>
#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessUploadTransfer(bool async = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here
                /* TODO: replace with Azure.Core.Diagnotiscs logger
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Upload Transfer source: {SourceLocalPath}; destination: {DestinationBlobClient.Uri}", async).EnsureCompleted();
                */
                // Do only blockblob upload for now for now
                try
                {
                    Response<BlobContentInfo> response = DestinationBlobClient.Upload(_sourceLocalPath, _uploadOptions);
                    if (response != null && response.Value != null)
                    {
                /* TODO: replace with Azure.Core.Diagnotiscs logger
                        Logger.LogAsync(DataMovementLogLevel.Information, $"Transfer succeeded on from source:{SourceLocalPath} to destination:{DestinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
                */
                    }
                    else
                    {
                /* TODO: replace with Azure.Core.Diagnotiscs logger
                        Logger.LogAsync(DataMovementLogLevel.Error, $"Upload Transfer Failed due to unknown reasons. Upload Transfer returned null results", async).EnsureCompleted();
                */
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
            TaskFactory taskFactory = default,
            BlobJobTransferScheduler scheduler = default,
            ResumeTransferCredentials credential = default)
        {
            if (credential?.DestinationTransferCredential != default)
            {
                if (!string.IsNullOrEmpty(credential.DestinationTransferCredential.ConnectionString))
                {
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(credential.SourceTransferCredential.ConnectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(DestinationBlobConfiguration.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        DestinationBlobClient = new BlobClient(
                            credential.SourceTransferCredential.ConnectionString,
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
                    DestinationBlobClient = new BlobClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.SasCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else if (credential.SourceTransferCredential.SharedKeyCredential != default)
                {
                    DestinationBlobClient = new BlobClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.SharedKeyCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else if (credential.SourceTransferCredential.TokenCredential != default)
                {
                    DestinationBlobClient = new BlobClient(
                        DestinationBlobConfiguration.Uri,
                        credential.DestinationTransferCredential.TokenCredential,
                        BlobBaseClientInternals.GetClientOptions(DestinationBlobClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(credential.SourceTransferCredential));
                }
            }
            // Read in Job Plan File
            // JobPlanReader.Read(file)
            return ProcessUploadTransfer();
        }
    }
}
