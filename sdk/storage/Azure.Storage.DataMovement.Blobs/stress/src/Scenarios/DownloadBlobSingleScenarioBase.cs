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
    public abstract class DownloadBlobSingleScenarioBase : BlobScenarioBase
    {
        public DownloadBlobSingleScenarioBase(
            Uri sourceBlobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            DataTransferOptions dataTransferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(sourceBlobUri, blobSize, transferManagerOptions, dataTransferOptions, tokenCredential, metrics, testRunId)
        {
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            string sourceContainerName = TestSetupHelper.Randomize("container");
            BlobContainerClient sourceContainerClient = _blobServiceClient.GetBlobContainerClient(sourceContainerName);
            await sourceContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();

            string blobName = TestSetupHelper.Randomize("blob");

            // Create Source Storage Resource
            BlobBaseClient sourceBaseBlob;
            StorageResource sourceResource;
            if (blobType == BlobType.Append)
            {
                AppendBlobClient sourceBlob = sourceContainerClient.GetAppendBlobClient(blobName);
                await BlobTestSetupHelper.CreateAppendBlobAsync(
                    sourceContainerClient.GetAppendBlobClient(blobName),
                    _blobSize,
                    cancellationToken);
                sourceBaseBlob = sourceBlob;
                sourceResource = _blobsStorageResourceProvider.FromClient(sourceBlob);
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
            }

            // Create Local Destination Storage Resource
            StorageResource destinationResource = _localFilesStorageResourceProvider.FromFile(Path.Combine(disposingLocalDirectory.DirectoryPath, blobName));

            // Start Transfer
            await new TransferValidator()
            {
                TransferManager = new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource as StorageResourceItem,
                destinationResource as StorageResourceItem,
                async cToken => await sourceBaseBlob.OpenReadAsync(default, cToken),
                cToken => Task.FromResult(File.OpenRead(sourceResource.Uri.AbsolutePath) as Stream),
                options: _dataTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
