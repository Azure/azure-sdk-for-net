// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class UploadBlobSingleScenarioBase : BlobScenarioBase
    {
        protected UploadBlobSingleScenarioBase(
            Uri blobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId) : base(blobUri, blobSize, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
        }

        internal async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken = default)
        {
            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient destinationContainerClient = _blobServiceClient.GetBlobContainerClient(destinationContainerName);
            await destinationContainerClient.CreateIfNotExistsAsync();
            string blobName = TestSetupHelper.Randomize("blob");

            // Create Local Source Storage Resource
            StorageResource sourceResource = await TestSetupHelper.GetTemporaryFileStorageResourceAsync(
                disposingLocalDirectory.DirectoryPath,
                fileName: blobName,
                fileSize: _blobSize,
                cancellationToken: cancellationToken);

            // Create Destination Storage Resource
            BlobBaseClient destinationBaseBlob;
            StorageResource destinationResource;
            if (blobType == BlobType.Append)
            {
                AppendBlobClient destinationBlob = destinationContainerClient.GetAppendBlobClient(blobName);
                destinationBaseBlob = destinationBlob;
                destinationResource = _blobsStorageResourceProvider.FromClient(destinationBlob);
            }
            else if (blobType == BlobType.Page)
            {
                PageBlobClient destinationBlob = destinationContainerClient.GetPageBlobClient(blobName);
                destinationBaseBlob = destinationBlob;
                destinationResource = _blobsStorageResourceProvider.FromClient(destinationBlob);
            }
            else
            {
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
                cToken => Task.FromResult(File.OpenRead(sourceResource.Uri.AbsolutePath) as Stream),
                async cToken => await destinationBaseBlob.OpenReadAsync(default, cToken),
                options: _dataTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
