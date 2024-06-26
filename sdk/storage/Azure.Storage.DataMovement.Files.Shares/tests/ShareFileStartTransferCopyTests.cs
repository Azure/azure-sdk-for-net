// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Tests;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [ShareClientTestFixture]
    public class ShareFileStartTransferCopyTests : StartTransferCopyTestBase
        <ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        private const string _defaultContentType = "text/plain";
        private const string _defaultContentLanguage = "en-US";
        private const string _defaultContentDisposition = "inline";
        private const string _defaultCacheControl = "no-cache";
        private readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        private readonly DateTimeOffset _defaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset _defaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset _defaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);
        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        public ShareFileStartTransferCopyTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<bool> SourceExistsAsync(ShareFileClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<bool> DestinationExistsAsync(ShareFileClient objectClient)
            => await objectClient.ExistsAsync();

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await SourceClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        private async Task<ShareFileClient> CreateFileClientAsync(
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
            return InstrumentClient(new ShareFileClient(sourceUri, GetOptions()));
        }

        protected override Task<ShareFileClient> GetSourceObjectClientAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesTestType = default)
            => CreateFileClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        protected override StorageResourceItem GetSourceStorageResourceItem(ShareFileClient objectClient)
            => new ShareFileStorageResource(objectClient);

        protected override Task<Stream> SourceOpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();

        protected override Task<ShareFileClient> GetDestinationObjectClientAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null)
            => CreateFileClientAsync(
                container,
                objectLength,
                createResource,
                objectName,
                options,
                contents);

        protected override StorageResourceItem GetDestinationStorageResourceItem(
            ShareFileClient objectClient,
            TransferPropertiesTestType type = TransferPropertiesTestType.Default)
            => new ShareFileStorageResource(objectClient);

        protected override Task<Stream> DestinationOpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();

        public ShareClientOptions GetOptions()
        {
            var options = new ShareClientOptions(_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Constants.MaxReliabilityRetries,
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

        protected override async Task VerifyPropertiesCopyAsync(
            DataTransfer transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            ShareFileClient sourceClient,
            ShareFileClient destinationClient)
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
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.IsEmpty(destinationProperties.Metadata);
                Assert.IsNull(destinationProperties.ContentDisposition);
                Assert.IsNull(destinationProperties.ContentLanguage);
                Assert.IsNull(destinationProperties.CacheControl);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(_defaultContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
                Assert.AreEqual(_defaultFileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(_defaultFileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                Assert.AreEqual(_defaultFileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
            }
            else //(transferPropertiesTestType == TransferPropertiesTestType.Default ||
                 //transferPropertiesTestType == TransferPropertiesTestType.Preserve)
            {
                ShareFileProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(sourceProperties.ContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(sourceProperties.ContentLanguage, destinationProperties.ContentLanguage);
                Assert.AreEqual(sourceProperties.CacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
                Assert.AreEqual(sourceProperties.SmbProperties.FileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(sourceProperties.SmbProperties.FileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                Assert.AreEqual(sourceProperties.SmbProperties.FileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
            }
        }
    }
}
