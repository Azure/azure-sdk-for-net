// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Models;
using Azure.Core.Pipeline;
using Azure.Storage.DataMovement.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    internal class BlobDownloadTransferJob : BlobTransferJobInternal
    {
        // Might have to change BlobBaseClient to other client, when we do page blob and append blob
        internal BlobBaseClient _sourceBlobClient;

        /// <summary>
        /// The source blob client. This client contains the information and methods required to perform
        /// the download from the source blob.
        /// </summary>
        public BlobBaseClient SourceBlobClient => _sourceBlobClient;

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
            _sourceBlobClient = sourceClient;
            _destinationLocalPath = destinationPath;
            _options = options;
            //ProgressTracker = progressTracker;
        }

        /// <summary>
        /// Creates Download TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Download operation</returns>
        public Task StartTransferTaskAsync()
        {
            // Do only blockblob upload for now for now
            return _sourceBlobClient.DownloadToAsync(
                _destinationLocalPath,
                transferOptions:_options.TransferOptions);
        }

        public Action ProcessDownloadTransfer(bool async = true)
        {
            return () =>
            {
                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Upload Transfer source: {SourceBlobClient.Uri.AbsoluteUri}; destination: {DestinationLocalPath}", async).EnsureCompleted();
                // Do only blockblob upload for now for now
                try
                {
                    Response response = SourceBlobClient.DownloadTo(DestinationLocalPath, transferOptions: _options.TransferOptions);
                    if (response != null)
                    {
                        Logger.LogAsync(DataMovementLogLevel.Information, $"Transfer succeeded on from source:{SourceBlobClient} to destination:{DestinationLocalPath}", async).EnsureCompleted();
                    }
                    else
                    {
                        Logger.LogAsync(DataMovementLogLevel.Error, $"Upload Transfer Failed due to unknown reasons. Upload Transfer returned null results", async).EnsureCompleted();
                    }
                }
                //TODO: catch other type of exceptions and handle gracefully
                catch (RequestFailedException ex)
                {
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Upload Transfer Failed due to the following: {ex.ErrorCode}: {ex.Message}", async).EnsureCompleted();
                    // Progress Handling is already done by the upload call
                }
                catch (Exception ex)
                {
                    Logger.LogAsync(DataMovementLogLevel.Error, $"Upload Transfer Failed due to the following: {ex.Message}", async).EnsureCompleted();
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
