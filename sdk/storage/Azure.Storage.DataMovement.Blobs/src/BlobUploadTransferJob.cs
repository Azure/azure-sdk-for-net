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
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Uploading BLobTransfer Job
    /// </summary>
    internal class BlobUploadTransferJob : TransferJobInternal
    {
        /// <summary>
        /// The path to the local file where the contents to be upload to the blob is stored.
        /// </summary>
        internal string _sourceLocalPath;

        /// <summary>
        /// Gets the path to the local file where the contents to be upload to the blob is stored.
        /// </summary>
        public string SourceLocalPath => _sourceLocalPath;

        // Might have to change BlobBaseClient to other client, when we do page blob and append blob
        internal BlobClient _destinationBlobClient;

        /// <summary>
        /// Gets the destination blob client
        /// </summary>
        public BlobClient DestinationBlobClient => _destinationBlobClient;

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
            _destinationBlobClient = destinationClient;
            _uploadOptions = uploadOptions;
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <returns>The Task to perform the Upload operation.</returns>
        public Task StartTransferTaskAsync()
        {
            // Do only blockblob upload for now
            return DestinationBlobClient.UploadAsync(_sourceLocalPath, _uploadOptions);
        }

        /// <summary>
        /// Create next TransferItem/Task to be processed.
        /// </summary>
        /// <param name="async">Defines whether the oepration should be async</param>
        /// <returns>The Task to perform the Upload operation.</returns>
        public Action ProcessUploadTransfer(bool async = true)
        {
            return () =>
            {
                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Upload Transfer source: {SourceLocalPath}; destination: {DestinationBlobClient.Uri}", async).EnsureCompleted();
                // Do only blockblob upload for now for now
                try
                {
                    Response<BlobContentInfo> response = DestinationBlobClient.Upload(_sourceLocalPath, _uploadOptions);
                    if (response != null && response.Value != null)
                    {
                        Logger.LogAsync(DataMovementLogLevel.Information, $"Transfer succeeded on from source:{SourceLocalPath} to destination:{DestinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
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
    }
}
