// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using System.IO;
using Azure.Core.TestFramework;
using Azure.Core;
using System.Threading;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class BlockBlobStartTransferUploadTests : StartTransferUploadTestBase<
        BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private const string _blobResourcePrefix = "test-blob-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        private const int MaxReliabilityRetries = 5;
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public BlockBlobStartTransferUploadTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> ExistsAsync(BlockBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<BlockBlobClient> GetObjectClientAsync(
            BlobContainerClient container,
            long? resourceLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = default)
        {
            objectName ??= GetNewObjectName();
            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);

            if (createResource)
            {
                if (!resourceLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createResource)} to false or specify a {nameof(resourceLength)}.");
                }

                if (contents != default)
                {
                    await blobClient.UploadAsync(contents);
                }
                else
                {
                    var data = GetRandomBuffer(resourceLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(resourceLength.Value);
                    await blobClient.UploadAsync(originalStream);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new BlockBlobClient(sourceUri, GetOptions()));
        }

        protected override StorageResourceItem GetStorageResourceItem(BlockBlobClient objectClient)
            => new BlockBlobStorageResource(objectClient);

        protected override Task<Stream> OpenReadAsync(BlockBlobClient objectClient)
            => objectClient.OpenReadAsync();

        public BlobClientOptions GetOptions()
        {
            var options = new BlobClientOptions((BlobClientOptions.ServiceVersion)_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        public async Task<StorageResource> GetTemporaryFileStorageResourceAsync(
                string prefixPath,
                string fileName = default,
                int bufferSize = Constants.MB,
                int? fileSize = 4 * Constants.MB,
                CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(prefixPath))
            {
                throw new ArgumentException("prefixPath cannot be null or empty", nameof(prefixPath));
            }
            fileName ??= GetNewObjectName();

            // Create new source file
            using Stream originalStream = await CreateLimitedMemoryStream(fileSize.Value);
            string localSourceFile = Path.Combine(prefixPath, fileName);
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            Console.Out.Write($"Creating File: {localSourceFile}..");
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                Console.Out.WriteLine("Copying Stream to File..");
                await originalStream.CopyToAsync(
                    fileStream,
                    bufferSize,
                    cancellationToken: cancellationToken);
                fileStream.Close();
            }
            LocalFilesStorageResourceProvider files = new();
            return files.FromFile(localSourceFile);
        }

        [Test]
        public async Task TempTestAsync()
        {
            int _blobSize = Constants.KB;
            TransferManagerOptions _transferManagerOptions = new();
            DataTransferOptions _dataTransferOptions = new();
            CancellationToken cancellationToken = CancellationToken.None;
            BlobsStorageResourceProvider _blobsStorageResourceProvider = new();

            DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            IDisposingContainer<BlobContainerClient> disposingBlobContainer = await GetDisposingContainerAsync();
            BlobContainerClient destinationContainerClient = disposingBlobContainer.Container;
            await destinationContainerClient.CreateIfNotExistsAsync();
            string blobName = GetNewObjectName();

            // Create Local Source Storage Resource
            StorageResource sourceResource = await GetTemporaryFileStorageResourceAsync(
                disposingLocalDirectory.DirectoryPath,
                fileName: blobName,
                fileSize: _blobSize,
                cancellationToken: cancellationToken);

            // Create Destination Storage Resource
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(destinationContainerClient.Uri)
            {
                BlobContainerName = destinationContainerClient.Name,
                BlobName = blobName
            };
            BlockBlobClient destinationBlob = destinationContainerClient.GetBlockBlobClient(blobName);
            StorageResource destinationResource = _blobsStorageResourceProvider.FromClient(destinationBlob);

            // Start Transfer
            await new TransferValidator()
            {
                TransferManager = new(_transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                cToken => Task.FromResult(File.OpenRead(sourceResource.Uri.AbsolutePath) as Stream),
                async cToken => await destinationBlob.OpenReadAsync(default, cToken),
                options: _dataTransferOptions,
                cancellationToken: cancellationToken);
        }
    }
}
