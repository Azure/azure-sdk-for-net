﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.Threading.Tasks;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public class PageBlobToBlockBlobTests : StartTransferCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        PageBlobClient,
        BlobClientOptions,
        BlobServiceClient,
        BlobContainerClient,
        BlockBlobClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        private readonly AccessTier _defaultAccessTier = AccessTier.Cold;
        private const string _defaultContentType = "text/plain";
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

        public PageBlobToBlockBlobTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _blobResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> SourceExistsAsync(PageBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<bool> DestinationExistsAsync(BlockBlobClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await SourceClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerAsync(BlobServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<PageBlobClient> GetSourceObjectClientAsync(
            BlobContainerClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            BlobClientOptions options = null,
            Stream contents = null)
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
                    await UploadPagesAsync(blobClient, contents);
                }
                else
                {
                    var data = GetRandomBuffer(objectLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(objectLength.Value);
                    await UploadPagesAsync(blobClient, originalStream);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new PageBlobClient(sourceUri, GetOptions()));
        }

        private async Task UploadPagesAsync(PageBlobClient blobClient, Stream contents)
        {
            long size = contents.Length;
            Assert.IsTrue(size % (KB / 2) == 0, "Cannot create page blob that's not a multiple of 512");
            await blobClient.CreateIfNotExistsAsync(size, new PageBlobCreateOptions()
            {
                Metadata = _defaultMetadata,
                HttpHeaders = new BlobHttpHeaders()
                {
                    ContentType = _defaultContentType,
                    ContentLanguage = _defaultContentLanguage,
                    ContentDisposition = _defaultContentDisposition,
                    CacheControl = _defaultCacheControl,
                }
            });
            long offset = 0;
            long blockSize = Math.Min(DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.UploadPagesAsync(partStream, offset);
                offset += blockSize;
            }
        }

        protected override StorageResourceItem GetSourceStorageResourceItem(PageBlobClient objectClient)
            => new PageBlobStorageResource(objectClient);

        protected override Task<Stream> SourceOpenReadAsync(PageBlobClient objectClient)
            => objectClient.OpenReadAsync();

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
            Uri sourceUri = blobClient.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new BlockBlobClient(sourceUri, GetOptions()));
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
                    AccessTier = _defaultAccessTier,
                    ContentDisposition = new(_defaultContentDisposition),
                    ContentLanguage = new(_defaultContentLanguage),
                    CacheControl = new(_defaultCacheControl),
                    ContentType = new(_defaultContentType),
                    Metadata = new(_defaultMetadata)
                };
            }
            else if (type == TransferPropertiesTestType.NoPreserve)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    ContentDisposition = new(false),
                    ContentLanguage = new(false),
                    CacheControl = new(false),
                    ContentType = new(false),
                    Metadata = new(false)
                };
            }
            else if (type == TransferPropertiesTestType.Preserve)
            {
                options = new BlockBlobStorageResourceOptions
                {
                    ContentDisposition = new(true),
                    ContentLanguage = new(true),
                    CacheControl = new(true),
                    ContentType = new(true),
                    Metadata = new(true)
                };
            }
            return new BlockBlobStorageResource(objectClient, options);
        }

        protected override Task<Stream> DestinationOpenReadAsync(BlockBlobClient objectClient)
            => objectClient.OpenReadAsync();

        protected override async Task VerifyPropertiesCopyAsync(
            DataTransfer transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            PageBlobClient sourceClient,
            BlockBlobClient destinationClient)
        {
            // Verify completion
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            // Verify Copy - using original source File and Copying the destination
            await testEventsRaised.AssertSingleCompletedCheck();
            using Stream sourceStream = await sourceClient.OpenReadAsync();
            using Stream destinationStream = await destinationClient.OpenReadAsync();
            Assert.AreEqual(sourceStream, destinationStream);

            if (transferPropertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.IsEmpty(destinationProperties.Metadata);
                Assert.IsNull(destinationProperties.ContentDisposition);
                Assert.IsNull(destinationProperties.ContentLanguage);
                Assert.IsNull(destinationProperties.CacheControl);

                GetBlobTagResult destinationTags = await destinationClient.GetTagsAsync();
                Assert.IsEmpty(destinationTags.Tags);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(_defaultAccessTier.ToString(), destinationProperties.AccessTier);
                Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(_defaultContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
            }
            else //(transferPropertiesTestType == TransferPropertiesTestType.Default ||
                 //transferPropertiesTestType == TransferPropertiesTestType.Preserve)
            {
                BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(sourceProperties.ContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(sourceProperties.ContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(sourceProperties.CacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
            }
        }

        public BlobClientOptions GetOptions()
        {
            var options = new BlobClientOptions(_serviceVersion)
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
