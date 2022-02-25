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
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Storage.Blobs;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Blob Directory Download Transfer Job
    /// </summary>
    internal class BlobDownloadDirectoryTransferJob : BlobTransferJobInternal
    {
        /// <summary>
        /// The source blob where it's contents will be downloaded when the job is performed.
        /// </summary>
        private BlobVirtualDirectoryClient _sourceBlobClient;

        /// <summary>
        /// The source blob where it's contents will be downloaded when the job is performed.
        /// </summary>
        public BlobVirtualDirectoryClient SourceBlobDirectoryClient => _sourceBlobClient;

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
        private BlobDirectoryDownloadOptions _options;

        /// <summary>
        /// The <see cref="BlobDirectoryDownloadOptions"/>.
        /// </summary>
        protected internal BlobDirectoryDownloadOptions Options => _options;

        /// <summary>
        /// Creates Download Transfer Job
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="sourceClient"></param>
        /// <param name="destinationPath"></param>
        /// <param name="options"></param>
        public BlobDownloadDirectoryTransferJob(
            string jobId,
            BlobVirtualDirectoryClient sourceClient,
            string destinationPath,
            BlobDirectoryDownloadOptions options)
            : base(jobId)
        {
            // Should we worry about concurrency issue and people using the client they pass elsewhere?
            _destinationLocalPath = destinationPath;
            _sourceBlobClient = sourceClient;
            _options = options;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <param name="blobName">Name of the blob in the directory that will be downloaded</param>
        /// <returns>The Task to perform the Upload operation.</returns>
        public async Task<Response> GetSingleDownloadTaskAsync(string blobName)
        {
            BlockBlobClient blockBlobClient = SourceBlobDirectoryClient.GetBlockBlobClient(blobName);
            string downloadPath = Path.Combine(DestinationLocalPath, blobName);

            Directory.CreateDirectory(Path.GetDirectoryName(downloadPath));
            Response response;
            using (Stream destination = File.Create(downloadPath))
            {
                response = await blockBlobClient.DownloadToAsync(
                    downloadPath,
                    default,
                    Options.TransferOptions)
                    .ConfigureAwait(false);
            }
            return response;
        }

#pragma warning disable CA1801 // Review unused parameters
        public Action ProcessSingleDownloadTransfer(string blobName, bool async = true)
#pragma warning restore CA1801 // Review unused parameters
        {
            return () =>
            {
                BlobClient blobClient = SourceBlobDirectoryClient.GetBlobClient(blobName);
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
                    TransactionalHashingOptions = Options.TransactionalHashingOptions,
                };

                try
                {
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
                    // Progress Handling is already done by the upload call
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
                {
                    /* TODO: replace with Azure.Core.Diagnotiscs logger
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Download Directory Transfer Failed due to the following: {ex.Message}", async).EnsureCompleted();
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
    }
}
