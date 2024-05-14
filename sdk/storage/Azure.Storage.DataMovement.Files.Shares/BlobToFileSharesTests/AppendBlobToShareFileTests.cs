// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
using Azure.Storage.DataMovement.Files.Shares;
using DMBlob::Azure.Storage.DataMovement.Blobs;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class AppendBlobToShareFileTests : StartTransferCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        AppendBlobClient,
        BlobClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        public const int MaxReliabilityRetries = 5;
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        protected readonly object _serviceVersion;

        public AppendBlobToShareFileTests(
            bool async,
            object serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, (ShareClientOptions.ServiceVersion)serviceVersion);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(
            BlobServiceClient service = default,
            string containerName = default)
            => await SourceClientBuilder.GetTestContainerAsync(service, containerName);

        /// <summary>
        /// Gets the specific storage resource from the given client
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="objectClient">The object client to create the storage resource object.</param>
        /// <returns></returns>
        protected override StorageResourceItem GetSourceStorageResourceItem(AppendBlobClient blob)
        {
            return new AppendBlobStorageResource(blob);
        }

        /// <summary>
        /// Calls the OpenRead method on the client.
        ///
        /// This is mainly used to verify the contents of the Object Client.
        /// </summary>
        /// <param name="objectClient">The object client to get the Open Read Stream from.</param>
        /// <returns></returns>
        protected override Task<Stream> SourceOpenReadAsync(AppendBlobClient objectClient)
            => objectClient.OpenReadAsync();

        /// <summary>
        /// Checks if the Object Client exists.
        /// </summary>
        /// <param name="objectClient">Object Client to call exists on.</param>
        /// <returns></returns>
        protected override async Task<bool> SourceExistsAsync(AppendBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<AppendBlobClient> GetSourceObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            AppendBlobClient blobClient = container.GetAppendBlobClient(objectName);

            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }

                if (contents != default)
                {
                    await UploadAppendBlocksAsync(blobClient, contents);
                }
                else
                {
                    var data = GetRandomBuffer(objectLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(objectLength.Value);
                    await UploadAppendBlocksAsync(blobClient, originalStream);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new AppendBlobClient(sourceUri, GetBlobOptions()));
        }

        private async Task UploadAppendBlocksAsync(AppendBlobClient blobClient, Stream contents)
        {
            await blobClient.CreateIfNotExistsAsync();
            long offset = 0;
            long size = contents.Length;
            long blockSize = Math.Min(Constants.DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.AppendBlockAsync(partStream);
                offset += blockSize;
            }
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<ShareFileClient> GetDestinationObjectClientAsync(ShareClient container, long? objectLength = null, bool createResource = false, string objectName = null, ShareClientOptions options = null, Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }
                await fileClient.CreateAsync(objectLength.Value);

                if (contents != default)
                {
                    await fileClient.UploadAsync(contents);
                }
            }
            Uri sourceUri = fileClient.GenerateSasUri(Sas.ShareFileSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new ShareFileClient(sourceUri, GetShareOptions()));
        }

        protected override StorageResourceItem GetDestinationStorageResourceItem(ShareFileClient objectClient)
            => new ShareFileStorageResource(objectClient);

        protected override Task<Stream> DestinationOpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();

        protected override async Task<bool> DestinationExistsAsync(ShareFileClient objectClient)
            => await objectClient.ExistsAsync();

        public BlobClientOptions GetBlobOptions()
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

        public ShareClientOptions GetShareOptions()
        {
            var options = new ShareClientOptions((ShareClientOptions.ServiceVersion)_serviceVersion)
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
    }
}
