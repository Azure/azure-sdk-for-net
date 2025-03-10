// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Stress;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Tests;
using BaseBlobs::Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Blobs.Tests;

namespace Azure.Storage.DataMovement.Blobs.Stress
{
    public abstract class UploadBlobSingleScenarioBase : BlobScenarioBase
    {
        protected UploadBlobSingleScenarioBase(
            Uri blobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            TransferOptions transferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId) : base(blobUri, blobSize, transferManagerOptions, transferOptions, tokenCredential, metrics, testRunId)
        {
        }

        internal async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string destinationContainerName = TestSetupHelper.Randomize("container");
                DisposingBlobContainer dipsosingContainer = new(_blobServiceClient.GetBlobContainerClient(destinationContainerName));
                try
                {
                    DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
                    BlobContainerClient destinationContainerClient = dipsosingContainer.Container;
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
                        destinationResource = BlobsStorageResourceProvider.FromClient(destinationBlob);
                    }
                    else if (blobType == BlobType.Page)
                    {
                        PageBlobClient destinationBlob = destinationContainerClient.GetPageBlobClient(blobName);
                        destinationBaseBlob = destinationBlob;
                        destinationResource = BlobsStorageResourceProvider.FromClient(destinationBlob);
                    }
                    else
                    {
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
                        cToken => Task.FromResult(File.OpenRead(sourceResource.Uri.AbsolutePath) as Stream),
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
