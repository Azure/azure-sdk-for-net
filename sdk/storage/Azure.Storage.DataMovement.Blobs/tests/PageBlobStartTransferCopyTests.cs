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
using Azure.Storage.Shared;
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
    public class PageBlobStartTransferCopyTests : StartTransferCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        PageBlobClient,
        BlobClientOptions,
        BlobServiceClient,
        BlobContainerClient,
        PageBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private readonly AccessTier _defaultAccessTier = AccessTier.P30;
        private readonly PremiumPageBlobAccessTier _defaultPremiumAccessTier = PremiumPageBlobAccessTier.P30;
        private const string _defaultContentType = "image/jpeg";
        private const string _defaultContentLanguage = "en-US";
        private const string _defaultContentDisposition = "inline";
        private const string _defaultCacheControl = "no-cache";
        private readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        private const int KB = 1024;
        private const int DefaultBufferSize = 4 * 1024 * 1024; // 4MB
        private const int MaxReliabilityRetries = 5;
        private const string _blobResourcePrefix = "test-blob-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public PageBlobStartTransferCopyTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> SourceExistsAsync(PageBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<bool> DestinationExistsAsync(PageBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await SourceClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestContainerAsync(service, containerName);

        private async Task<PageBlobClient> GetPageBlobClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null,
            bool premium = false)
        {
            objectName ??= GetNewObjectName();
            PageBlobClient blobClient = container.GetPageBlobClient(objectName);

            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create a blob without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }

                if (contents != default)
                {
                    await UploadPagesAsync(blobClient, contents, premium: premium);
                }
                else
                {
                    var data = GetRandomBuffer(objectLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(objectLength.Value);
                    await UploadPagesAsync(blobClient, originalStream, premium: premium);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new PageBlobClient(sourceUri, GetOptions()));
        }

        private async Task UploadPagesAsync(
            PageBlobClient blobClient,
            Stream contents,
            bool premium = false)
        {
            long size = contents.Length;
            Assert.That(size % (KB / 2), Is.EqualTo(0), "Cannot create page blob that's not a multiple of 512");
            PageBlobCreateOptions options = new()
            {
                Metadata = _defaultMetadata,
                HttpHeaders = new BlobHttpHeaders()
                {
                    ContentType = _defaultContentType,
                    ContentLanguage = _defaultContentLanguage,
                    ContentDisposition = _defaultContentDisposition,
                    CacheControl = _defaultCacheControl,
                },
            };
            if (premium)
            {
                options.PremiumPageBlobAccessTier = _defaultPremiumAccessTier;
            }
            await blobClient.CreateIfNotExistsAsync(size, options);
            long offset = 0;
            long blockSize = Math.Min(DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.UploadPagesAsync(partStream, offset);
                offset += blockSize;
            }
        }

        protected override Task<PageBlobClient> GetSourceObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = default,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default)
            => GetPageBlobClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        protected override StorageResourceItem GetSourceStorageResourceItem(PageBlobClient objectClient)
            => new PageBlobStorageResource(objectClient);

        protected override Task<Stream> SourceOpenReadAsync(PageBlobClient objectClient)
            => objectClient.OpenReadAsync();

        protected override Task<PageBlobClient> GetDestinationObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
            => GetPageBlobClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        private StorageResourceItem GetDestinationStorageResourceItemInternal(
            PageBlobClient objectClient,
            TransferPropertiesTestType type = TransferPropertiesTestType.Default,
            bool premium = false)
        {
            PageBlobStorageResourceOptions options = default;
            if (type == TransferPropertiesTestType.NewProperties)
            {
                options = new PageBlobStorageResourceOptions
                {
                    ContentDisposition = _defaultContentDisposition,
                    ContentLanguage = _defaultContentLanguage,
                    CacheControl = _defaultCacheControl,
                    ContentType = _defaultContentType,
                    Metadata = _defaultMetadata
                };
                if (premium)
                {
                    options.AccessTier = _defaultAccessTier;
                }
            }
            else if (type == TransferPropertiesTestType.NoPreserve)
            {
                options = new PageBlobStorageResourceOptions
                {
                    ContentDisposition = default,
                    ContentLanguage = default,
                    CacheControl = default,
                    ContentType = default,
                    Metadata = default,
                    AccessTier = default
                };
            }
            return new PageBlobStorageResource(objectClient, options);
        }

        protected override StorageResourceItem GetDestinationStorageResourceItem(
            PageBlobClient objectClient,
            TransferPropertiesTestType type = TransferPropertiesTestType.Default)
            => GetDestinationStorageResourceItemInternal(objectClient, type);

        protected override Task<Stream> DestinationOpenReadAsync(PageBlobClient objectClient)
            => objectClient.OpenReadAsync();

        private async Task VerifyPropertiesCopyAsyncInternal(
            TransferOperation transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            PageBlobClient sourceClient,
            PageBlobClient destinationClient,
            bool premium,
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
                Assert.That(destinationProperties.ContentType, Is.Not.EqualTo(_defaultContentType));
                if (premium)
                {
                    Assert.That(destinationProperties.AccessTier.ToString(), Is.Not.EqualTo(_defaultAccessTier.ToString()));
                }
                else
                {
                    // Premium accounts do not support tags
                    GetBlobTagResult destinationTags = await destinationClient.GetTagsAsync();
                    Assert.That(destinationTags.Tags, Is.Empty);
                }
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(destinationProperties.ContentDisposition, Is.EqualTo(_defaultContentDisposition));
                Assert.That(destinationProperties.ContentLanguage, Is.EqualTo(_defaultContentLanguage));
                Assert.That(destinationProperties.CacheControl, Is.EqualTo(_defaultCacheControl));
                Assert.That(destinationProperties.ContentType, Is.EqualTo(_defaultContentType));
                if (premium)
                {
                    Assert.That(destinationProperties.AccessTier.ToString(), Is.EqualTo(_defaultAccessTier.ToString()));
                }
            }
            else //(transferPropertiesTestType == TransferPropertiesTestType.Default ||
                 //transferPropertiesTestType == TransferPropertiesTestType.Preserve)
            {
                BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.That(destinationProperties.ContentDisposition, Is.EqualTo(sourceProperties.ContentDisposition));
                Assert.That(destinationProperties.ContentLanguage, Is.EqualTo(sourceProperties.ContentLanguage));
                Assert.That(destinationProperties.CacheControl, Is.EqualTo(sourceProperties.CacheControl));
                Assert.That(destinationProperties.ContentType, Is.EqualTo(sourceProperties.ContentType));
                if (premium)
                {
                    Assert.That(destinationProperties.AccessTier, Is.EqualTo(sourceProperties.AccessTier));
                }
            }
        }

        protected override async Task VerifyPropertiesCopyAsync(
            TransferOperation transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            PageBlobClient sourceClient,
            PageBlobClient destinationClient,
            CancellationToken cancellationToken)
            => await VerifyPropertiesCopyAsyncInternal(
                transfer,
                transferPropertiesTestType,
                testEventsRaised,
                sourceClient,
                destinationClient,
                false,
                cancellationToken);

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

        [RecordedTest]
        [TestCase(TransferPropertiesTestType.NoPreserve)]
        [TestCase(TransferPropertiesTestType.NewProperties)]
        [TestCase(TransferPropertiesTestType.Preserve)]
        public async Task CopyPremiumPageBlob_AccessTier(TransferPropertiesTestType propertiesType)
        {
            // Arrange
            await using IDisposingContainer<BlobContainerClient> source = await SourceClientBuilder.GetTestContainerAsync(premium: true);
            await using IDisposingContainer<BlobContainerClient> destination = await DestinationClientBuilder.GetTestContainerAsync(premium: true);

            // Create Source Blob with Premium Tier
            PageBlobClient sourceClient = await GetPageBlobClientAsync(
                container: source.Container,
                createResource: true,
                objectLength: Constants.KB,
                premium: true);
            StorageResourceItem sourceResource = GetSourceStorageResourceItem(sourceClient);

            // Create Destination Client with option (properties to preserve)
            PageBlobClient destinationClient = await GetDestinationObjectClientAsync(
                container: destination.Container,
                createResource: false);
            StorageResourceItem destinationResource = GetDestinationStorageResourceItemInternal(
                destinationClient,
                type: propertiesType,
                premium: true);

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManager transferManager = new TransferManager();

            // Act - Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await VerifyPropertiesCopyAsyncInternal(
                transfer,
                propertiesType,
                testEventsRaised,
                sourceClient,
                destinationClient,
                true,
                cancellationTokenSource.Token);
        }
    }
}
