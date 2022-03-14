// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Azure.Core.Pipeline;
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Storage.Blobs;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobDownloadTransferJob : BlobTransferJobInternal
    {
        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobClientConfiguration SourceBlobConfiguration;

        /// <summary>
        /// The source blob client. This client contains the information and methods required to perform
        /// the download from the source blob.
        /// </summary>
        internal BlobBaseClient SourceBlobClient;

        /// <summary>
        /// The local path which will store the contents of the blob to be downloaded.
        /// </summary>
        internal string _destinationLocalPath;

        /// <summary>
        /// Gets the local path which will store the contents of the blob to be downloaded.
        /// </summary>
        public string DestinationLocalPath => _destinationLocalPath;

        /// <summary>
        /// The <see cref="BlobDownloadOptions"/>.
        /// </summary>
        internal BlobDownloadToOptions _options;

        /// <summary>
        /// Gets the <see cref="BlobDownloadOptions"/>.
        /// </summary>
        public BlobDownloadToOptions Options => _options;

        /// <summary>
        /// Constructor. Creates Single Blob Download Job.
        ///
        /// TODO: better description, also for parameters.
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceClient">
        /// Source Blob to download.
        /// </param>
        /// <param name="destinationPath">
        /// Local Path to download the blob to.
        /// </param>
        /// <param name="options">
        /// Transfer Options for the specific download job.
        /// See <see cref="StorageTransferOptions"/>.
        /// </param>
        public BlobDownloadTransferJob(
            string jobId,
            BlobBaseClient sourceClient,
            string destinationPath,
            BlobDownloadToOptions options)
            : base(jobId)
        {
            SourceBlobConfiguration = new BlobClientConfiguration()
            {
                Uri = sourceClient.Uri,
                AccountName = sourceClient.AccountName,
            };
            SourceBlobClient = sourceClient;
            _destinationLocalPath = destinationPath;
            _options = options;
        }

        /// <summary>
        /// Creates Download TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Download operation</returns>
        public Task StartTransferTaskAsync()
        {
            // Do only blockblob upload for now for now
            return SourceBlobClient.DownloadToAsync(
                _destinationLocalPath,
                transferOptions:_options.TransferOptions);
        }

#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessDownloadTransfer(bool async = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                /* TODO: replace with Azure.Core.Diagnotiscs logger
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Upload Transfer source: {SourceBlobClient.Uri.AbsoluteUri}; destination: {DestinationLocalPath}", async).EnsureCompleted();
                */
                // Do only blockblob upload for now for now
                try
                {
                    Response response = SourceBlobClient.DownloadTo(DestinationLocalPath, transferOptions: _options.TransferOptions);
                    if (response != null)
                    {
                        /* TODO: replace with Azure.Core.Diagnotiscs logger
                        Logger.LogAsync(DataMovementLogLevel.Information, $"Transfer succeeded on from source:{SourceBlobClient} to destination:{DestinationLocalPath}", async).EnsureCompleted();
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
            if (credential?.SourceTransferCredential != default)
            {
                if (!string.IsNullOrEmpty(credential.SourceTransferCredential.ConnectionString))
                {
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(credential.SourceTransferCredential.ConnectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceBlobClient.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        SourceBlobClient = new BlobBaseClient(
                            credential.SourceTransferCredential.ConnectionString,
                            SourceBlobConfiguration.BlobContainerName,
                            SourceBlobConfiguration.Name,
                            BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                    }
                    else
                    {
                        // Mismatch in storage account host in the URL
                        throw Errors.InvalidConnectionString();
                    }
                }
                else if (credential.SourceTransferCredential.SasCredential != default)
                {
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        credential.SourceTransferCredential.SasCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else if (credential.SourceTransferCredential.SharedKeyCredential != default)
                {
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        credential.SourceTransferCredential.SharedKeyCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else if (credential.SourceTransferCredential.TokenCredential != default)
                {
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        credential.SourceTransferCredential.TokenCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(credential.SourceTransferCredential));
                }
            }
            // Read in Job Plan File
            // JobPlanReader.Read(file)
            return ProcessDownloadTransfer();
        }
    }
}
