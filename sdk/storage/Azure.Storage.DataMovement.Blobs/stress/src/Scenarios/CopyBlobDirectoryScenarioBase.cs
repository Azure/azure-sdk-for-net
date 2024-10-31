// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.DataMovement.Tests;
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
            DataTransferOptions dataTransferOptions,
            TokenCredential sourceTokenCredential,
            TokenCredential destinationTokenCredential,
            Metrics metrics,
            string testRunId)
            : base(destinationBlobUri, blobSize, transferManagerOptions, dataTransferOptions, destinationTokenCredential, metrics, testRunId)
        {
            _sourceServiceClient = new BlobServiceClient(sourceBlobUri, sourceTokenCredential);
            _blobCount = blobCount ?? DataMovementBlobStressConstants.DefaultObjectCount;
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string sourceContainerName = TestSetupHelper.Randomize("container");
                DisposingContainer sourceDisposingContainer = new(_sourceServiceClient.GetBlobContainerClient(sourceContainerName));
                string destinationContainerName = TestSetupHelper.Randomize("container");
                DisposingContainer destinationDisposingContainer = new(_blobServiceClient.GetBlobContainerClient(destinationContainerName));
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
                    StorageResource sourceResource = _blobsStorageResourceProvider.FromClient(sourceContainerClient, new() { BlobDirectoryPrefix = pathPrefix });

                    // Create Destination Blob Container Storage Resource
                    StorageResource destinationResource = _blobsStorageResourceProvider.FromClient(
                        destinationContainerClient,
                        new()
                        {
                            BlobDirectoryPrefix = pathPrefix,
                            BlobType = new(blobType)
                        });

                    // Start Transfer
                    await new TransferValidator()
                    {
                        TransferManager = new(_transferManagerOptions)
                    }.TransferAndVerifyAsync(
                        sourceResource,
                        destinationResource,
                        TransferValidator.Get(sourceContainerClient, pathPrefix),
                        TransferValidator.GetBlobLister(destinationContainerClient, pathPrefix),
                        _blobCount,
                        _dataTransferOptions,
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
