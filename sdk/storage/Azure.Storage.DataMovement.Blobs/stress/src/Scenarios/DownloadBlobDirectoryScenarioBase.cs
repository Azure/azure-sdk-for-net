// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Blobs.Tests;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class DownloadBlobDirectoryScenarioBase : BlobScenarioBase
    {
        private int _blobCount;
        public DownloadBlobDirectoryScenarioBase(
            Uri destinationBlobUri,
            int? blobSize,
            int? blobCount,
            TransferManagerOptions transferManagerOptions,
            TransferOptions transferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId) :
            base(destinationBlobUri, blobSize, transferManagerOptions, transferOptions, tokenCredential, metrics, testRunId)
        {
            _blobCount = blobCount ?? DataMovementBlobStressConstants.DefaultObjectCount;
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string sourceContainerName = TestSetupHelper.Randomize("container");
                DisposingBlobContainer dipsosingContainer = new(_blobServiceClient.GetBlobContainerClient(sourceContainerName));
                try
                {
                    // Create Source Blob Container
                    BlobContainerClient sourceContainerClient = dipsosingContainer.Container;
                    await sourceContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);

                    // Create Destination Test Local Directory
                    string pathPrefix = TestSetupHelper.Randomize("dir");
                    DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory(pathPrefix);

                    // Create Blobs in source container
                    await BlobTestSetupHelper.CreateBlobsInDirectoryAsync(
                        sourceContainerClient,
                        blobType,
                        pathPrefix,
                        _blobCount,
                        _blobSize,
                        cancellationToken);

                    // Create Destination Local Storage Resource
                    StorageResource sourceResource = await TestSetupHelper.GetTemporaryFileStorageResourceAsync(disposingLocalDirectory.DirectoryPath);

                    // Create Destination Storage Resource
                    StorageResource destinationResource = BlobsStorageResourceProvider.FromClient(sourceContainerClient, new() { BlobPrefix = pathPrefix });

                    // Start Transfer
                    await new TransferValidator()
                    {
                        TransferManager = new(_transferManagerOptions)
                    }.TransferAndVerifyAsync(
                        sourceResource,
                        destinationResource,
                        TransferValidator.GetBlobLister(sourceContainerClient, pathPrefix),
                        TransferValidator.GetLocalFileLister(disposingLocalDirectory.DirectoryPath),
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
                        if (dipsosingContainer != null)
                        {
                            _metrics.Client.TrackEvent("Stopping processing events");
                            await dipsosingContainer.DisposeAsync();
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
