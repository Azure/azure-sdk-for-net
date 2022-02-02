// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Models;
using Azure.Storage.DataMovement.Blobs.Models;
using Azure.Storage.Blobs;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement.Blobs
{
    /// <summary>
    /// Blob Directory Upload Job
    /// </summary>
    internal class BlobUploadDirectoryTransferJob : TransferJobInternal
    {
        private string _sourceLocalPath;

        /// <summary>
        /// Gets the local path of the source file.
        /// </summary>
        public string SourceLocalPath => _sourceLocalPath;

        internal BlobVirtualDirectoryClient _destinationBlobClient;

        /// <summary>
        /// The destination blob client.
        /// </summary>
        public BlobVirtualDirectoryClient DestinationDirectoryBlobClient => _destinationBlobClient;

        internal BlobDirectoryUploadOptions _uploadOptions;

        // Should only be used for upload options. Felt redudant
        // to create a whole other class that inherited this just
        // for uploads. Is it worth it to make a whole other class
        // for each operation type.
        public BlobDirectoryUploadOptions UploadOptions => _uploadOptions;

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
            _destinationBlobClient = destinationClient;
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

            BlockBlobClient blockBlobClient = DestinationDirectoryBlobClient.GetBlockBlobClient(blobName);

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

        public Action ProcessSingleUploadTransfer(string fullPathName, bool async = true)
        {
            return () =>
            {
                // Replace backward slashes meant to be directory name separators
                string blobName = fullPathName.Substring(SourceLocalPath.Length + 1);
                blobName = blobName.Replace(@"\", "/");

                BlobClient destinationBlobClient = DestinationDirectoryBlobClient.GetBlobClient(blobName);

                BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
                {
                    AccessTier = UploadOptions.AccessTier,
                    TransferOptions = UploadOptions.TransferOptions,
                    ImmutabilityPolicy = UploadOptions.ImmutabilityPolicy,
                    LegalHold = UploadOptions.LegalHold,
                    TransactionalHashingOptions = UploadOptions.TransactionalHashingOptions,
                };

                // TODO: make logging messages similar to the errors class where we only take in params
                // so we dont have magic strings hanging out here
                Logger.LogAsync(DataMovementLogLevel.Information,
                    $"Processing Upload Directory Transfer source: {SourceLocalPath}; destination: {DestinationDirectoryBlobClient.Uri}",
                    async).EnsureCompleted();
                // Do only blockblob upload for now for now
                try
                {
                    Response<BlobContentInfo> response = destinationBlobClient.Upload(
                        _sourceLocalPath,
                        blobUploadOptions,
                        CancellationTokenSource.Token);
                    if (response != null && response.Value != null)
                    {
                        Logger.LogAsync(DataMovementLogLevel.Information,
                            $"Transfer succeeded on from source:{SourceLocalPath} to destination:{DestinationDirectoryBlobClient.Uri.AbsoluteUri}",
                            async).EnsureCompleted();
                    }
                    else
                    {
                        Logger.LogAsync(DataMovementLogLevel.Error,
                            $"Upload Transfer Failed due to unknown reasons. Upload Transfer returned null results",
                            async).EnsureCompleted();
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
