// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Files.Shares;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Files.Shares;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using Azure.Storage.Files.Shares.Tests;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareFileToBlockBlobTests : StartTransferCopyTestBase
        <ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        public const int MaxReliabilityRetries = 5;
        private const string _blobResourcePrefix = "test-blob-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        protected readonly object _serviceVersion;

        public ShareFileToBlockBlobTests(
            bool async,
            object serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, (ShareClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
        }

        protected override async Task<bool> DestinationExistsAsync(BlockBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override Task<Stream> DestinationOpenReadAsync(BlockBlobClient objectClient)
            => objectClient.OpenReadAsync();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<BlockBlobClient> GetDestinationObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);

            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }

                if (contents != default)
                {
                    await blobClient.UploadAsync(contents);
                }
                else
                {
                    var data = GetRandomBuffer(objectLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(objectLength.Value);
                    await blobClient.UploadAsync(originalStream);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new BlockBlobClient(sourceUri, GetBlobOptions()));
        }

        protected override StorageResourceItem GetDestinationStorageResourceItem(
            BlockBlobClient objectClient,
            TransferPropertiesTestType type = TransferPropertiesTestType.Default)
        {
            BlockBlobStorageResourceOptions options = default;
            if (type == TransferPropertiesTestType.NewProperties)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    AccessTier = AccessTier.Cool,
                    ContentDisposition = new("attachment"),
                    ContentLanguage = new("en-US"),
                    CacheControl = new("no-cache")
                };
            }
            else if (type == TransferPropertiesTestType.NoPreserve)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    ContentDisposition = new(false),
                    ContentLanguage = new(false),
                    CacheControl = new(false)
                };
            }
            else if (type == TransferPropertiesTestType.Preserve)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    ContentDisposition = new(true),
                    ContentLanguage = new(true),
                    CacheControl = new(true)
                };
            }
            return new BlockBlobStorageResource(objectClient, options);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await SourceClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<ShareFileClient> GetSourceObjectClientAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null)
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

        protected override StorageResourceItem GetSourceStorageResourceItem(ShareFileClient objectClient)
            => new ShareFileStorageResource(objectClient);

        protected override async Task<bool> SourceExistsAsync(ShareFileClient objectClient)
            => await objectClient.ExistsAsync();

        protected override Task<Stream> SourceOpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();

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

        protected override Task VerifyPropertiesCopyAsync(
            DataTransfer transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            ShareFileClient sourceClient,
            BlockBlobClient destinationClient)
        {
            throw new NotImplementedException();
        }

        [Test]
        [Ignore("Not implemented yet")]
        public override Task SourceObjectToDestinationObject_DefaultProperties()
        {
            Assert.Fail("Feature not implemented yet for this source and destination resource.");
            return Task.CompletedTask;
        }

        [Test]
        [Ignore("Not implemented yet")]
        public override Task SourceObjectToDestinationObject_PreserveProperties()
        {
            Assert.Fail("Feature not implemented yet for this source and destination resource.");
            return Task.CompletedTask;
        }

        [Test]
        [Ignore("Not implemented yet")]
        public override Task SourceObjectToDestinationObject_NoPreserveProperties()
        {
            Assert.Fail("Feature not implemented yet for this source and destination resource.");
            return Task.CompletedTask;
        }

        [Test]
        [Ignore("Not implemented yet")]
        public override Task SourceObjectToDestinationObject_NewProperties()
        {
            Assert.Fail("Feature not implemented yet for this source and destination resource.");
            return Task.CompletedTask;
        }
    }
}
