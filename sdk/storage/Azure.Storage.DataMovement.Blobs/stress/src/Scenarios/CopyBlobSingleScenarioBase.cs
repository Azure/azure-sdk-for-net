// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class CopyBlobSingleScenarioBase : BlobScenarioBase
    {
        private readonly BlobServiceClient _sourceServiceClient;

        public CopyBlobSingleScenarioBase(
            Uri sourceBlobUri,
            Uri destinationBlobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential sourceTokenCredential,
            TokenCredential destinationTokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, blobSize, transferManagerOptions, dataTransferOptions, destinationTokenCredential, metrics, testRunId)
        {
            _sourceServiceClient = new BlobServiceClient(sourceBlobUri, sourceTokenCredential);
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            string sourceContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient sourceContainerClient = _sourceServiceClient.GetBlobContainerClient(sourceContainerName);
            await sourceContainerClient.CreateIfNotExistsAsync();

            string destinationContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient destinationContainerClient = _blobServiceClient.GetBlobContainerClient(destinationContainerName);
            await destinationContainerClient.CreateIfNotExistsAsync();
            string blobName = TestSetupHelper.Randomize("blob");

            // Create Source and Destination Storage Resource
            BlobBaseClient sourceBaseBlob;
            StorageResource sourceResource;
            BlobBaseClient destinationBaseBlob;
            StorageResource destinationResource;
            if (blobType == BlobType.Append)
            {
                AppendBlobClient sourceBlob = sourceContainerClient.GetAppendBlobClient(blobName);
                await BlobTestSetupHelper.CreateAppendBlobAsync(
                    sourceContainerClient.GetAppendBlobClient(blobName),
                    _blobSize,
                    cancellationToken);
                sourceBaseBlob = sourceBlob;
                sourceResource = _blobsStorageResourceProvider.FromClient(sourceBlob);

                AppendBlobClient destinationBlob = destinationContainerClient.GetAppendBlobClient(blobName);
                destinationBaseBlob = destinationBlob;
                destinationResource = _blobsStorageResourceProvider.FromClient(destinationBlob);
            }
            else if (blobType == BlobType.Page)
            {
                PageBlobClient sourceBlob = sourceContainerClient.GetPageBlobClient(blobName);
                await BlobTestSetupHelper.CreatePageBlobAsync(
                    sourceContainerClient.GetPageBlobClient(blobName),
                    _blobSize,
                    cancellationToken);
                sourceBaseBlob = sourceBlob;
                sourceResource = _blobsStorageResourceProvider.FromClient(sourceBlob);

                PageBlobClient destinationBlob = destinationContainerClient.GetPageBlobClient(blobName);
                destinationBaseBlob = destinationBlob;
                destinationResource = _blobsStorageResourceProvider.FromClient(destinationBlob);
            }
            else
            {
                BlockBlobClient sourceBlob = sourceContainerClient.GetBlockBlobClient(blobName);
                await BlobTestSetupHelper.CreateBlockBlobAsync(
                    sourceContainerClient.GetBlockBlobClient(blobName),
                    _blobSize,
                    cancellationToken);
                sourceBaseBlob = sourceBlob;
                sourceResource = _blobsStorageResourceProvider.FromClient(sourceBlob);

                BlockBlobClient destinationBlob = destinationContainerClient.GetBlockBlobClient(blobName);
                destinationBaseBlob = destinationBlob;
                destinationResource = _blobsStorageResourceProvider.FromClient(destinationBlob);
            }

            // Start Transfer
            await new TransferValidator()
            {
                TransferManager = new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                async cToken => await sourceBaseBlob.OpenReadAsync(default, cToken),
                async cToken => await destinationBaseBlob.OpenReadAsync(default, cToken),
                options: _dataTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
