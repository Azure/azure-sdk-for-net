// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.DataMovement.Models;
using Azure.Storage.DataMovement;
using Azure.Storage.Blobs;
using Azure.Core;
using System.Collections.Generic;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class BlobDownloadTransferJob : BlobTransferJobInternal
    {
        /// <summary>
        /// Holds Source Blob Configurations
        /// </summary>
        public BlobBaseConfiguration SourceBlobConfiguration;

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
        /// The <see cref="BlobDownloadToOptions"/>.
        /// </summary>
        internal BlobSingleDownloadOptions _options;

        /// <summary>
        /// Gets the <see cref="BlobDownloadToOptions"/>.
        /// </summary>
        public BlobSingleDownloadOptions Options => _options;

        private ClientDiagnostics _diagnostics;

        /// <summary>
        /// Client Diagnostics
        /// </summary>
        public ClientDiagnostics Diagnostics => _diagnostics;

        /// <summary>
        /// Constructor. Creates Single Blob Download Job.
        ///
        /// TODO: better description, also for parameters.
        /// </summary>
        /// <param name="transferId"></param>
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
        /// <param name="errorOption">
        /// Error Options
        /// </param>
        public BlobDownloadTransferJob(
            string transferId,
            BlobBaseClient sourceClient,
            string destinationPath,
            BlobSingleDownloadOptions options,
            ErrorHandlingOptions errorOption)
            : base(transferId: transferId,
                  errorHandling: errorOption)
        {
            SourceBlobConfiguration = new BlobBaseConfiguration()
            {
                Uri = sourceClient.Uri,
                AccountName = sourceClient.AccountName,
            };
            SourceBlobClient = sourceClient;
            _destinationLocalPath = destinationPath;
            _options = options;
            _diagnostics = new ClientDiagnostics(BlobBaseClientInternals.GetClientOptions(sourceClient));
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
                    TransferStatus = StorageTransferStatus.InProgress;
                    Response response = SourceBlobClient.DownloadTo(DestinationLocalPath, transferOptions: Options?.TransferOptions ?? default);
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
        /// <param name="sourceCredential"></param>
        /// <param name="destinationCredential"></param>
        public override void ProcessResumeTransfer(
            object sourceCredential = default,
            object destinationCredential = default)
        {
            if (sourceCredential != default)
            {
                // Connection String
                if (sourceCredential.GetType() == typeof(string))
                {
                    string connectionString = (string)sourceCredential;
                    // Check if an endpoint was passed in the connection string and if that matches the original source uri
                    StorageConnectionString parsedConnectionString = StorageConnectionString.Parse(connectionString);
                    BlobUriBuilder sourceUriBuilder = new BlobUriBuilder(SourceBlobClient.Uri);

                    if (parsedConnectionString.BlobEndpoint.Host == sourceUriBuilder.Host)
                    {
                        SourceBlobClient = new BlobBaseClient(
                            connectionString,
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
                else if (sourceCredential.GetType() == typeof(AzureSasCredential))
                {
                    AzureSasCredential sasCredential = (AzureSasCredential)sourceCredential;
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        sasCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else if (sourceCredential.GetType() == typeof(StorageSharedKeyCredential))
                {
                    StorageSharedKeyCredential storageSharedKeyCredential = (StorageSharedKeyCredential)sourceCredential;
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        storageSharedKeyCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else if (sourceCredential.GetType() == typeof(TokenCredential))
                {
                    TokenCredential tokenCredential = (TokenCredential)sourceCredential;
                    SourceBlobClient = new BlobBaseClient(
                        SourceBlobConfiguration.Uri,
                        tokenCredential,
                        BlobBaseClientInternals.GetClientOptions(SourceBlobClient));
                }
                else
                {
                    throw Errors.InvalidArgument(nameof(sourceCredential));
                }
                TransferStatus = StorageTransferStatus.Queued;
            }
            // Read in Job Plan File
            // JobPlanReader.Read(file)
            TransferStatus = StorageTransferStatus.Queued;
            //return ProcessDownloadTransfer();
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
                    if ((Options != null) &&
                        (Options?.GetTransferStatus() != null))
                    {
                        await Options.GetTransferStatus().RaiseAsync(
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
                    if ((Options != null) &&
                        (Options?.GetTransferStatus() != null))
                    {
                        Options.GetTransferStatus()?.Invoke(new StorageTransferStatusEventArgs(
                                    TransferId,
                                    transferStatus,
                                    true,
                                    CancellationTokenSource.Token));
                    }
                }
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async IAsyncEnumerable<BlobJobPartInternal> ProcessJobToJobPartAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            yield return new BlobDownloadPartInternal(this);
        }

        public override IAsyncEnumerable<Func<Task>> ProcessPartToChunkAsync()
        {
            throw new NotImplementedException();
        }
    }
}
