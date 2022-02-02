// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// TODO; descriptions and comments for this entire class
    /// TODO: Add possible options bag for copy transfer
    /// </summary>
    internal class BlobServiceCopyTransferJob : TransferJobInternal
    {
        private Uri _sourceUri;

        /// <summary>
        /// The source Uri
        /// </summary>
        public Uri SourceUri => _sourceUri;

        internal BlobBaseClient _destinationBlobClient;

        /// <summary>
        /// The destination blob client for the copy job
        /// </summary>
        public BlobBaseClient DestinationBlobClient => _destinationBlobClient;

        /// <summary>
        /// Type of Copy to occur
        /// </summary>
        public readonly BlobServiceCopyMethod CopyMethod;

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
            BlobServiceCopyMethod copyMethod,
            BlobCopyFromUriOptions copyFromUriOptions)
            : base(jobId)
        {
            _sourceUri = sourceUri;
            _destinationBlobClient = destinationClient;
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
        public Action ProcessCopyTransfer(bool async = true)
        {
            return () =>
            {
                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Copy Transfer source: {SourceUri.AbsoluteUri}; destination: {DestinationBlobClient.Uri}", async).EnsureCompleted();
                // Do only blockblob upload for now for now
                try
                {
                    if (CopyMethod == BlobServiceCopyMethod.ServiceSideAsyncCopy)
                    {
                        CopyFromUriOperation copyOperation = DestinationBlobClient.StartCopyFromUri(SourceUri, CopyFromUriOptions);
                        // TODO: Might want to figure out an appropriate delay to poll the wait for completion
                        // TODO: Also might want to cancel this if it takes too long to prevent any threads to be hung up on this operation.
                        copyOperation.WaitForCompletion(CancellationTokenSource.Token);

                        if (copyOperation.HasCompleted && copyOperation.HasValue)
                        {
                            Logger.LogAsync(DataMovementLogLevel.Information, $"Copy Transfer succeeded on from source:{SourceUri.AbsoluteUri} to destination:{DestinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
                        }
                        else
                        {
                            Logger.LogAsync(DataMovementLogLevel.Error, $"Copy Transfer Failed due to unknown reasons. Upload Transfer returned null results", async).EnsureCompleted();
                        }
                    }
                    else //if(CopyMethod == BlobServiceCopyMethod.ServiceSideSyncCopy)
                    {
                        Response<BlobCopyInfo> response = DestinationBlobClient.SyncCopyFromUri(SourceUri, CopyFromUriOptions);
                        if (response != null && response.Value != null)
                        {
                            Logger.LogAsync(DataMovementLogLevel.Information, $"Copy Transfer succeeded on from source:{SourceUri.AbsoluteUri} to destination:{DestinationBlobClient.Uri.AbsoluteUri}", async).EnsureCompleted();
                        }
                        else
                        {
                            Logger.LogAsync(DataMovementLogLevel.Error, $"Copy Transfer Failed due to unknown reasons. Upload Transfer returned null results", async).EnsureCompleted();
                        }
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
