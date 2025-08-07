// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.DataMovement.Blobs.Tests;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class CopyBlobDirectoryScenarioBase : BlobScenarioBase
    {
        private int _blobCount;
        private readonly BlobServiceClient _sourceServiceClient;

        public CopyBlobDirectoryScenarioBase(
            Uri sourceBlobUri,
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            TransferOptions transferOptions,
            TokenCredential sourceTokenCredential,
            TokenCredential destinationTokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, blobSize, transferManagerOptions, transferOptions, destinationTokenCredential, metrics, testRunId)
        {
            _sourceServiceClient = new BlobServiceClient(sourceBlobUri, sourceTokenCredential);
            _blobCount = blobCount ?? DataMovementBlobStressConstants.DefaultObjectCount;
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
                    string pathPrefix = TestSetupHelper.Randomize("dir");
                    BlobContainerClient sourceContainerClient = sourceDisposingContainer.Container;
                    BlobContainerClient destinationContainerClient = destinationDisposingContainer.Container;
                    await sourceContainerClient.CreateIfNotExistsAsync();
                    await BlobTestSetupHelper.CreateBlobsInDirectoryAsync(
                        sourceContainerClient,
                        blobType,
                        pathPrefix,
                        _blobCount,
                        _blobSize,
                        cancellationToken);

                    await destinationContainerClient.CreateIfNotExistsAsync();

                    // Create Source Blob Container Storage Resource
                    StorageResource sourceResource = BlobsStorageResourceProvider.FromClient(sourceContainerClient, new() { BlobPrefix = pathPrefix });

                    // Create Destination Blob Container Storage Resource
                    StorageResource destinationResource = BlobsStorageResourceProvider.FromClient(
                        destinationContainerClient,
                        new()
                        {
                            BlobPrefix = pathPrefix,
                            BlobType = blobType
                        });

                    // Start Transfer
                    await new TransferValidator()
                    {
                        TransferManager = new(_transferManagerOptions)
                    }.TransferAndVerifyAsync(
                        sourceResource,
                        destinationResource,
                        TransferValidator.GetBlobLister(sourceContainerClient, pathPrefix),
                        TransferValidator.GetBlobLister(destinationContainerClient, pathPrefix),
                        _blobCount,
                        _transferOptions,
                        cancellationToken);
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
