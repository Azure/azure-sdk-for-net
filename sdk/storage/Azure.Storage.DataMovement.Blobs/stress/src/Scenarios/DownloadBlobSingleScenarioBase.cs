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
    public abstract class DownloadBlobSingleScenarioBase : BlobScenarioBase
    {
        public DownloadBlobSingleScenarioBase(
            Uri sourceBlobUri,
            int? blobSize,
            TransferManagerOptions transferManagerOptions,
            TransferOptions transferOptions,
            TokenCredential tokenCredential,
            Metrics metrics,
            string testRunId)
            : base(sourceBlobUri, blobSize, transferManagerOptions, transferOptions, tokenCredential, metrics, testRunId)
        {
        }

        public async Task RunTestInternalAsync(BlobType blobType, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string sourceContainerName = TestSetupHelper.Randomize("container");
                DisposingBlobContainer dipsosingContainer = new(_blobServiceClient.GetBlobContainerClient(sourceContainerName));
                try
                {
                    BlobContainerClient sourceContainerClient = dipsosingContainer.Container;
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
                        sourceResource = BlobsStorageResourceProvider.FromClient(sourceBlob);
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
                    }

                    // Create Local Destination Storage Resource
                    StorageResource destinationResource = LocalFilesStorageResourceProvider.FromFile(Path.Combine(disposingLocalDirectory.DirectoryPath, blobName));

                    // Start Transfer
                    await new TransferValidator()
                    {
                        TransferManager = new(_transferManagerOptions)
                    }.TransferAndVerifyAsync(
                        sourceResource as StorageResourceItem,
                        destinationResource as StorageResourceItem,
                        async cToken => await sourceBaseBlob.OpenReadAsync(default, cToken),
                        cToken => Task.FromResult(File.OpenRead(sourceResource.Uri.AbsolutePath) as Stream),
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
