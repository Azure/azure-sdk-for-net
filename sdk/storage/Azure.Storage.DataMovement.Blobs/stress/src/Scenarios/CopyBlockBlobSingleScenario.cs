// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public class CopyBlockBlobSingleScenario : BlobScenarioBase
    {
        private readonly Uri _sourceBlobUri;
        private int _blobSize;
        public CopyBlockBlobSingleScenario(
            Uri sourceBlobUri,
            Uri destinationBlobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
            _sourceBlobUri = sourceBlobUri;
            _blobSize = blobSize.HasValue ? blobSize.Value : DataMovementBlobStressConstants.DefaultObjectSize;
        }

        public override string Name => DataMovementBlobStressConstants.TestScenarioNameStr.CopySingleBlockBlob;

        public override async Task RunTestAsync(CancellationToken cancellationToken)
        {
            string destinationContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient destinationContainerClient = _destinationServiceClient.GetBlobContainerClient(destinationContainerName);
            await destinationContainerClient.CreateIfNotExistsAsync();
            string blobName = TestSetupHelper.Randomize("blob");

            // Create Source Blob Storage Resource
            BlockBlobClient sourceBlob = destinationContainerClient.GetBlockBlobClient(blobName);
            StorageResource sourceResource = _blobsStorageResourceProvider.FromClient(sourceBlob);

            // Create Destination Blob Storage Resource
            BlockBlobClient destinationBlob = destinationContainerClient.GetBlockBlobClient(blobName);
            StorageResource destinationResource = _blobsStorageResourceProvider.FromClient(destinationBlob);

            // Start Transfer
            await new TransferValidator()
            {
                TransferManager = new()//new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                async cToken => await sourceBlob.OpenReadAsync(default, cToken),
                async cToken => await destinationBlob.OpenReadAsync(default, cToken),
                options: new(),//_dataTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
