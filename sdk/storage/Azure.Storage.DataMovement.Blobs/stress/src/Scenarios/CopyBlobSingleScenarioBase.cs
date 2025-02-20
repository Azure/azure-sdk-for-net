// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Blobs.Tests;
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
            TransferOptions transferOptions,
            TokenCredential sourceTokenCredential,
            TokenCredential destinationTokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, blobSize, transferManagerOptions, transferOptions, destinationTokenCredential, metrics, testRunId)
        {
            _sourceServiceClient = new BlobServiceClient(sourceBlobUri, sourceTokenCredential);
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string sourceContainerName = TestSetupHelper.Randomize("container");
                DisposingBlobContainer sourceDisposingContainer = new(_sourceServiceClient.GetBlobContainerClient(sourceContainerName));
                string destinationContainerName = TestSetupHelper.Randomize("container");
                DisposingBlobContainer destinationDisposingContainer = new(_blobServiceClient.GetBlobContainerClient(destinationContainerName));
                try
                {
                    BlobContainerClient sourceContainerClient = sourceDisposingContainer.Container;
                    BlobContainerClient destinationContainerClient = destinationDisposingContainer.Container;

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
                        sourceResource = BlobsStorageResourceProvider.FromClient(sourceBlob);

                        AppendBlobClient destinationBlob = destinationContainerClient.GetAppendBlobClient(blobName);
                        destinationBaseBlob = destinationBlob;
                        destinationResource = BlobsStorageResourceProvider.FromClient(destinationBlob);
                    }
                    else if (blobType == BlobType.Page)
                    {
                        PageBlobClient sourceBlob = sourceContainerClient.GetPageBlobClient(blobName);
                        await BlobTestSetupHelper.CreatePageBlobAsync(
                            sourceContainerClient.GetPageBlobClient(blobName),
                            _blobSize,
                            cancellationToken);
                        sourceBaseBlob = sourceBlob;
                        sourceResource = BlobsStorageResourceProvider.FromClient(sourceBlob);

                        PageBlobClient destinationBlob = destinationContainerClient.GetPageBlobClient(blobName);
                        destinationBaseBlob = destinationBlob;
                        destinationResource = BlobsStorageResourceProvider.FromClient(destinationBlob);
                    }
                    else
                    {
                        BlockBlobClient sourceBlob = sourceContainerClient.GetBlockBlobClient(blobName);
                        await BlobTestSetupHelper.CreateBlockBlobAsync(
                            sourceContainerClient.GetBlockBlobClient(blobName),
                            _blobSize,
                            cancellationToken);
                        sourceBaseBlob = sourceBlob;
                        sourceResource = BlobsStorageResourceProvider.FromClient(sourceBlob);

                        BlockBlobClient destinationBlob = destinationContainerClient.GetBlockBlobClient(blobName);
                        destinationBaseBlob = destinationBlob;
                        destinationResource = BlobsStorageResourceProvider.FromClient(destinationBlob);
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
                        options: _transferOptions,
                        cancellationToken: cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    // No action needed
                }
                catch (Exception ex) when
                    (ex is OutOfMemoryException
                    || ex is StackOverflowException
                    || ex is ThreadAbortException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    _metrics.Client.GetMetric(Metrics.TransferRestarted).TrackValue(1);
                    _metrics.Client.TrackException(ex);
                }
                finally
                {
                    // In case the container is the issue, delete the container.

                    using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(25));

                    try
                    {
                        if (sourceDisposingContainer != null)
                        {
                            _metrics.Client.TrackEvent("Stopping processing events");
                            await sourceDisposingContainer.DisposeAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        _metrics.Client.GetMetric(Metrics.TransferRestarted).TrackValue(1);
                        _metrics.Client.TrackException(ex);
                    }
                }
            }
        }
    }
}
