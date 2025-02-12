// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;
extern alias BaseShares;

using System;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Blobs;
using BaseShares::Azure.Storage.Files.Shares;
using Azure.Storage.Test.Shared;
using Azure.Storage.Blobs.Specialized;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Shared;
using Azure.Storage.DataMovement.Files.Shares;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using Azure.Storage.Blobs.Models;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using System.Threading;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [BlobShareClientTestFixture]
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
        private const string _defaultContentType = "text/plain";
        private readonly string[] _defaultContentLanguageFile = { "en-US" };
        private const string _defaultContentLanguageBlob = "en-US";
        private const string _defaultContentDisposition = "inline";
        private const string _defaultCacheControl = "no-cache";
        private readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        private readonly DateTimeOffset _defaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset _defaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset _defaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);

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
            Stream contents = default,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default)
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
                    await UploadAppendBlocksAsync(blobClient, contents, cancellationToken);
                }
                else
                {
                    var data = GetRandomBuffer(objectLength.Value);
                    using Stream originalStream = await CreateLimitedMemoryStream(objectLength.Value);
                    await UploadAppendBlocksAsync(blobClient, originalStream, cancellationToken);
                }
            }
            Uri sourceUri = blobClient.GenerateSasUri(Sas.BlobSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new AppendBlobClient(sourceUri, GetBlobOptions()));
        }

        private async Task UploadAppendBlocksAsync(
            AppendBlobClient blobClient,
            Stream contents,
            CancellationToken cancellationToken)
        {
            await blobClient.CreateIfNotExistsAsync(
                new AppendBlobCreateOptions()
                {
                    Metadata = _defaultMetadata,
                    HttpHeaders = new BlobHttpHeaders()
                    {
                        ContentType = _defaultContentType,
                        ContentLanguage = _defaultContentLanguageBlob,
                        ContentDisposition = _defaultContentDisposition,
                        CacheControl = _defaultCacheControl,
                    }
                },
                cancellationToken: cancellationToken);
            long offset = 0;
            long size = contents.Length;
            long blockSize = Math.Min(Constants.DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.AppendBlockAsync(partStream, cancellationToken: cancellationToken);
                offset += blockSize;
            }
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<ShareFileClient> GetDestinationObjectClientAsync(
            ShareClient container,
            long? objectLength = null,
            bool createResource = false,
            string objectName = null,
            ShareClientOptions options = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            objectName ??= GetNewObjectName();
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            if (createResource)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified. Either set {nameof(createResource)} to false or specify a {nameof(objectLength)}.");
                }
                await fileClient.CreateAsync(objectLength.Value, cancellationToken: cancellationToken);

                if (contents != default)
                {
                    await fileClient.UploadAsync(contents);
                }
            }
            Uri sourceUri = fileClient.GenerateSasUri(BaseShares::Azure.Storage.Sas.ShareFileSasPermissions.All, Recording.UtcNow.AddDays(1));
            return InstrumentClient(new ShareFileClient(sourceUri, GetShareOptions()));
        }

        protected override StorageResourceItem GetDestinationStorageResourceItem(
            ShareFileClient objectClient,
            TransferPropertiesTestType type = TransferPropertiesTestType.Default)
        {
            ShareFileStorageResourceOptions options = default;
            if (type == TransferPropertiesTestType.NewProperties)
            {
                options = new ShareFileStorageResourceOptions()
                {
                    ContentType = _defaultContentType,
                    ContentLanguage = _defaultContentLanguageFile,
                    ContentDisposition = _defaultContentDisposition,
                    CacheControl = _defaultCacheControl,
                    FileMetadata = _defaultMetadata,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                    FileChangedOn = _defaultFileChangedOn
                };
            }
            else if (type == TransferPropertiesTestType.Preserve)
            {
                options = new ShareFileStorageResourceOptions()
                {
                    FilePermissions = true,
                };
            }
            else if (type == TransferPropertiesTestType.NoPreserve)
            {
                options = new ShareFileStorageResourceOptions()
                {
                    ContentType = default,
                    ContentLanguage = default,
                    ContentDisposition = default,
                    CacheControl = default,
                    FileMetadata = default,
                    FileCreatedOn = default,
                    FileLastWrittenOn = default,
                    FileChangedOn = default
                };
            }
            return new ShareFileStorageResource(objectClient, options);
        }

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

        protected override async Task VerifyPropertiesCopyAsync(
            TransferOperation transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            AppendBlobClient sourceClient,
            ShareFileClient destinationClient,
            CancellationToken cancellationToken)
        {
            // Verify completion
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            // Verify Copy - using original source File and Copying the destination
            await testEventsRaised.AssertSingleCompletedCheck();
            using Stream sourceStream = await sourceClient.OpenReadAsync(cancellationToken: cancellationToken);
            using Stream destinationStream = await destinationClient.OpenReadAsync(cancellationToken: cancellationToken);
            Assert.AreEqual(sourceStream, destinationStream);

            if (transferPropertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                Assert.IsEmpty(destinationProperties.Metadata);
                Assert.IsNull(destinationProperties.ContentDisposition);
                Assert.IsNull(destinationProperties.ContentLanguage);
                Assert.IsNull(destinationProperties.CacheControl);
            }
            else if (transferPropertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(_defaultContentLanguageFile, destinationProperties.ContentLanguage);
                Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
                Assert.AreEqual(_defaultFileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                Assert.AreEqual(_defaultFileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                Assert.AreEqual(_defaultFileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
            }
            else //(transferPropertiesTestType == TransferPropertiesTestType.Default ||
                 //transferPropertiesTestType == TransferPropertiesTestType.Preserve)
            {
                BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync(cancellationToken: cancellationToken);
                ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                Assert.AreEqual(sourceProperties.ContentDisposition, destinationProperties.ContentDisposition);
                Assert.AreEqual(sourceProperties.CacheControl, destinationProperties.CacheControl);
                Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
                Assert.AreEqual(sourceProperties.CreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
            }
        }
    }
}
