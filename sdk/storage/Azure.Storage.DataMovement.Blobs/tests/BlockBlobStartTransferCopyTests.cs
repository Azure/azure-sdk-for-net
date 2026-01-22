// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseBlobs;
extern alias DMBlobs;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class BlockBlobStartTransferCopyTests : StartTransferCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private readonly AccessTier _defaultAccessTier = AccessTier.Cold;
        private const string _defaultContentType = "image/jpeg";
        private const string _defaultContentLanguage = "en-US";
        private const string _defaultContentDisposition = "inline";
        private const string _defaultCacheControl = "no-cache";
        private readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        private const int MaxReliabilityRetries = 5;
        private const string _blobResourcePrefix = "test-blob-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public BlockBlobStartTransferCopyTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> SourceExistsAsync(BlockBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<bool> DestinationExistsAsync(BlockBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await SourceClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestContainerAsync(service, containerName);

        private async Task<BlockBlobClient> GetBlockBlobClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = default,
            TransferPropertiesTestType propertiesTestType = default)
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
                    await blobClient.UploadAsync(
                        originalStream,
                        new BlobUploadOptions()
                        {
                            AccessTier = _defaultAccessTier,
                            Metadata = _defaultMetadata,
                            HttpHeaders = new BlobHttpHeaders()
                            {
                                ContentType = _defaultContentType,
                                ContentLanguage = _defaultContentLanguage,
                                ContentDisposition = _defaultContentDisposition,
                                CacheControl = _defaultCacheControl,
                            }
                        });
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new BlockBlobClient(sourceUri, GetOptions()));
        }

        protected override Task<BlockBlobClient> GetSourceObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = default,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default)
            => GetBlockBlobClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        protected override StorageResourceItem GetSourceStorageResourceItem(BlockBlobClient objectClient)
            => new BlockBlobStorageResource(objectClient);

        protected override Task<Stream> SourceOpenReadAsync(BlockBlobClient objectClient)
            => objectClient.OpenReadAsync();

        protected override Task<BlockBlobClient> GetDestinationObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
            => GetBlockBlobClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        protected override StorageResourceItem GetDestinationStorageResourceItem(
            BlockBlobClient objectClient,
            TransferPropertiesTestType type = TransferPropertiesTestType.Default)
        {
            BlockBlobStorageResourceOptions options = default;
            if (type == TransferPropertiesTestType.NewProperties)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    AccessTier = _defaultAccessTier,
                    ContentDisposition = _defaultContentDisposition,
                    ContentLanguage = _defaultContentLanguage,
                    CacheControl = _defaultCacheControl,
                    ContentType = _defaultContentType,
                    Metadata = _defaultMetadata,
                };
            }
            else if (type == TransferPropertiesTestType.NoPreserve)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    AccessTier = default,
                    ContentDisposition = default,
                    ContentLanguage = default,
                    CacheControl = default,
                    ContentType = default,
                    Metadata = default
                };
            }
            return new BlockBlobStorageResource(objectClient, options);
        }

        protected override Task<Stream> DestinationOpenReadAsync(BlockBlobClient objectClient)
            => objectClient.OpenReadAsync();

        protected override async Task VerifyPropertiesCopyAsync(
            TransferOperation transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            BlockBlobClient sourceClient,
            BlockBlobClient destinationClient,
            CancellationToken cancellationToken)
        {
            // Verify completion
            Assert.That(transfer, Is.Not.Null);
            Assert.That(transfer.HasCompleted, Is.True);
            Assert.That(transfer.Status.State, Is.EqualTo(TransferState.Completed));
            // Verify Copy - using original source File and Copying the destination
            await testEventsRaised.AssertSingleCompletedCheck();
            using Stream sourceStream = await sourceClient.OpenReadAsync();
            using Stream destinationStream = await destinationClient.OpenReadAsync();
            Assert.That(destinationStream, Is.EqualTo(sourceStream));

            if (transferPropertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(destinationProperties.Metadata, Is.Empty);
                Assert.That(destinationProperties.ContentDisposition, Is.Null);
                Assert.That(destinationProperties.ContentLanguage, Is.Null);
                Assert.That(destinationProperties.CacheControl, Is.Null);
                // Because AccessTier is not preserved, the access tier value on the destination will
                // default to what the storage account sets (normally AccessTier.Hot)
                Assert.That(destinationProperties.AccessTier, Is.Not.EqualTo(_defaultAccessTier.ToString()));
                Assert.That(destinationProperties.ContentType, Is.Not.EqualTo(_defaultContentType));

                GetBlobTagResult destinationTags = await destinationClient.GetTagsAsync();
                Assert.That(destinationTags.Tags, Is.Empty);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(destinationProperties.AccessTier, Is.EqualTo(_defaultAccessTier.ToString()));
                Assert.That(destinationProperties.ContentDisposition, Is.EqualTo(_defaultContentDisposition));
                Assert.That(destinationProperties.ContentLanguage, Is.EqualTo(_defaultContentLanguage));
                Assert.That(destinationProperties.CacheControl, Is.EqualTo(_defaultCacheControl));
                Assert.That(destinationProperties.ContentType, Is.EqualTo(_defaultContentType));
            }
            else //(transferPropertiesTestType == TransferPropertiesTestType.Default ||
                 //transferPropertiesTestType == TransferPropertiesTestType.Preserve)
            {
                BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(destinationProperties.AccessTier, Is.EqualTo(sourceProperties.AccessTier));
                Assert.That(destinationProperties.ContentDisposition, Is.EqualTo(sourceProperties.ContentDisposition));
                Assert.That(destinationProperties.ContentLanguage, Is.EqualTo(sourceProperties.ContentLanguage));
                Assert.That(destinationProperties.CacheControl, Is.EqualTo(sourceProperties.CacheControl));
                Assert.That(destinationProperties.ContentType, Is.EqualTo(sourceProperties.ContentType));
            }
        }

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
    }
}
