// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test.Shared;
using DMBlobs::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public abstract class BlobDirectoryStartTransferDownloadTestBase
        : StartTransferDirectoryDownloadTestBase<
        BlobServiceClient,
        BlobContainerClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _dirResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";

        public BlobDirectoryStartTransferDownloadTestBase(
            bool async,
            BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, _dirResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected abstract Task CreateBlobClientAsync(BlobContainerClient container, string blobName, Stream contents, CancellationToken cancellationToken = default);

        protected abstract BlobType GetBlobType();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

        protected override StorageResourceContainer GetStorageResourceContainer(BlobContainerClient container, string directoryPath)
            => new BlobStorageResourceContainer(container, new() { BlobType = GetBlobType(), BlobPrefix = directoryPath });

        protected override TransferValidator.ListFilesAsync GetSourceLister(BlobContainerClient container, string prefix)
            => TransferValidator.GetBlobLister(container, prefix);

        protected override async Task CreateObjectClientAsync(
            BlobContainerClient container,
            long? objectLength,
            string blobName,
            bool createResource = false,
            BlobClientOptions options = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            blobName ??= GetNewObjectName();
            await CreateBlobClientAsync(container, blobName, contents, cancellationToken);
        }

        protected override async Task SetupSourceDirectoryAsync(
            BlobContainerClient container,
            string directoryPath,
            List<(string PathName, int Size)> fileSizes,
            CancellationToken cancellationToken)
        {
            foreach ((string blobName, int size) in fileSizes)
            {
                await CreateBlobClientAsync(container, blobName, new MemoryStream(GetRandomBuffer(size)), cancellationToken);
            }
        }
    }
}
