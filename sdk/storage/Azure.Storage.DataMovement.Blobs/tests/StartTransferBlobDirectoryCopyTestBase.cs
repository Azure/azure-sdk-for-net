// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlobs;
extern alias BaseBlobs;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using BaseBlobs::Azure.Storage.Blobs;
using BaseBlobs::Azure.Storage.Blobs.Models;
using BaseBlobs::Azure.Storage.Blobs.Specialized;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using DMBlobs::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Azure.Storage.Shared;

namespace Azure.Storage.DataMovement.Blobs.Tests
{
    [DataMovementBlobsClientTestFixture]
    public abstract class StartTransferBlobDirectoryCopyTestBase<TSourceObjectClient, TDestinationObjectClient>
        : StartTransferDirectoryCopyTestBase
        <BlobServiceClient,
        BlobContainerClient,
        BlobClientOptions,
        BlobServiceClient,
        BlobContainerClient,
        BlobClientOptions,
        StorageTestEnvironment>
    where TSourceObjectClient : BlobBaseClient
    where TDestinationObjectClient : BlobBaseClient
    {
        private readonly AccessTier _defaultAccessTier = AccessTier.Cold;
        private const string _defaultContentType = "image/jpeg";
        private const string _defaultContentLanguage = "en-US";
        private const string _defaultContentDisposition = "inline";
        private const string _defaultCacheControl = "no-cache";
        private readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        public const int MaxReliabilityRetries = 5;
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        protected readonly object _serviceVersion;

        public StartTransferBlobDirectoryCopyTestBase(
            bool async,
            object serviceVersion)
        : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record*/)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
        }

        protected override Task CreateDirectoryInDestinationAsync(
            BlobContainerClient destinationContainer,
            string directoryPath,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // No-op since blobs are virtual directories
            return Task.CompletedTask;
        }

        protected override Task CreateDirectoryInSourceAsync(
            BlobContainerClient sourceContainer,
            string directoryPath,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // No-op since blobs are virtual directories
            return Task.CompletedTask;
        }

        internal async Task CreateBlockBlobAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();

            BlockBlobClient blobClient = container.GetBlockBlobClient(objectName);
            if (contents != default)
            {
                await blobClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
            else
            {
                byte[] data = GetRandomBuffer(objectLength ?? 0);
                using (var stream = new MemoryStream(data))
                {
                    await blobClient.UploadAsync(
                        content: stream,
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
                        },
                        cancellationToken: cancellationToken);
                }
            }
        }

        internal async Task UploadAppendBlocksAsync(
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
                        ContentLanguage = _defaultContentLanguage,
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

        internal async Task CreateAppendBlobAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();

            AppendBlobClient blobClient = container.GetAppendBlobClient(objectName);
            if (contents != default)
            {
                await UploadAppendBlocksAsync(blobClient, contents, cancellationToken);
            }
            else
            {
                byte[] data = GetRandomBuffer(objectLength ?? 0);
                using (var stream = new MemoryStream(data))
                {
                    await UploadAppendBlocksAsync(
                        blobClient,
                        stream,
                        cancellationToken);
                }
            }
        }

        internal async Task UploadPagesAsync(
            PageBlobClient blobClient,
            Stream contents,
            CancellationToken cancellationToken)
        {
            long size = contents.Length;
            Assert.IsTrue(size % (Constants.KB / 2) == 0, "Cannot create page blob that's not a multiple of 512");
            await blobClient.CreateIfNotExistsAsync(
                size,
                new PageBlobCreateOptions()
                {
                    Metadata = _defaultMetadata,
                    HttpHeaders = new BlobHttpHeaders()
                    {
                        ContentType = _defaultContentType,
                        ContentLanguage = _defaultContentLanguage,
                        ContentDisposition = _defaultContentDisposition,
                        CacheControl = _defaultCacheControl,
                    }
                },
                cancellationToken: cancellationToken).ConfigureAwait(false);
            long offset = 0;
            long blockSize = Math.Min(Constants.DefaultBufferSize, size);
            while (offset < size)
            {
                Stream partStream = WindowStream.GetWindow(contents, blockSize);
                await blobClient.UploadPagesAsync(partStream, offset, cancellationToken: cancellationToken);
                offset += blockSize;
            }
        }

        internal async Task CreatePageBlobAsync(
            BlobContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();

            PageBlobClient blobClient = container.GetPageBlobClient(objectName);
            if (contents != default)
            {
                await UploadPagesAsync(blobClient, contents, cancellationToken);
            }
            else
            {
                byte[] data = GetRandomBuffer(objectLength ?? 0);
                using (var stream = new MemoryStream(data))
                {
                    await UploadPagesAsync(
                        blobClient,
                        stream,
                        cancellationToken);
                }
            }
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            BlobServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential);
            return await DestinationClientBuilder.GetTestContainerAsync(oauthService, containerName);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerAsync(
            BlobServiceClient service = null,
            string containerName = null,
            CancellationToken cancellationToken = default)
            => await DestinationClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            BlobServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential);
            return await SourceClientBuilder.GetTestContainerAsync(oauthService, containerName);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(BlobServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
        {
            DisposingBlobContainer disposingContainer = await SourceClientBuilder.GetTestContainerAsync(service, containerName);
            Uri sourceUri = disposingContainer.Container.GenerateSasUri(BaseBlobs::Azure.Storage.Sas.BlobContainerSasPermissions.All, Recording.UtcNow.AddDays(1));
            return new DisposingBlobContainer(new BlobContainerClient(sourceUri, GetOptions()));
        }

        protected override async Task VerifyEmptyDestinationContainerAsync(BlobContainerClient destinationContainer, string destinationPrefix, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            GetBlobsOptions options = new GetBlobsOptions
            {
                Prefix = destinationPrefix
            };
            IList<BlobItem> items = await destinationContainer.GetBlobsAsync(options, cancellationToken: cancellationToken).ToListAsync();
            Assert.IsEmpty(items);
        }

        protected internal abstract TSourceObjectClient GetSourceBlob(BlobContainerClient containerClient, string blobName);
        protected internal abstract TDestinationObjectClient GetDestinationBlob(BlobContainerClient containerClient, string blobName);

        protected override async Task VerifyResultsAsync(
            BlobContainerClient sourceContainer,
            string sourcePrefix,
            BlobContainerClient destinationContainer,
            string destinationPrefix,
            TransferPropertiesTestType propertiesTestType = TransferPropertiesTestType.Default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // List all files in source blob folder path
            List<string> sourceFileNames = new List<string>();

            // Get source directory client and list the paths
            GetBlobsOptions options = new GetBlobsOptions
            {
                Prefix = !string.IsNullOrEmpty(sourcePrefix) ? sourcePrefix + '/' : sourcePrefix
            };
            await foreach (Page<BlobItem> page in sourceContainer.GetBlobsAsync(options, cancellationToken: cancellationToken).AsPages())
            {
                sourceFileNames.AddRange(page.Values.Select(
                    (BlobItem item) => !string.IsNullOrEmpty(sourcePrefix) ? item.Name.Substring(sourcePrefix.Length + 1) : item.Name));
            }

            // List all files in the destination blob folder path
            List<string> destinationFileNames = new List<string>();
            options = new GetBlobsOptions
            {
                Prefix = !string.IsNullOrEmpty(destinationPrefix) ? destinationPrefix + '/' : destinationPrefix
            };
            await foreach (Page<BlobItem> page in destinationContainer.GetBlobsAsync(options, cancellationToken: cancellationToken).AsPages())
            {
                destinationFileNames.AddRange(page.Values.Select(
                    (BlobItem item) => !string.IsNullOrEmpty(destinationPrefix) ? item.Name.Substring(destinationPrefix.Length + 1) : item.Name));
            }

            // Assert file and file contents
            Assert.AreEqual(sourceFileNames.Count, destinationFileNames.Count);
            sourceFileNames.Sort();
            destinationFileNames.Sort();
            for (int i = 0; i < sourceFileNames.Count; i++)
            {
                Assert.AreEqual(
                    sourceFileNames[i],
                    destinationFileNames[i]);

                // Verify contents
                string sourceFullName = !string.IsNullOrEmpty(sourcePrefix) ?
                    string.Join("/", sourcePrefix, sourceFileNames[i]) :
                    sourceFileNames[i];
                string destinationFullName = !string.IsNullOrEmpty(destinationPrefix) ?
                    string.Join("/", destinationPrefix, destinationFileNames[i]) :
                    destinationFileNames[i];
                TSourceObjectClient sourceClient = GetSourceBlob(sourceContainer, sourceFullName);
                TDestinationObjectClient destinationClient = GetDestinationBlob(destinationContainer, destinationFullName);
                using Stream sourceStream = await sourceClient.OpenReadAsync(cancellationToken: cancellationToken);
                using Stream destinationStream = await destinationClient.OpenReadAsync(cancellationToken: cancellationToken);
                Assert.AreEqual(sourceStream, destinationStream);

                if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
                {
                    BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                    Assert.IsEmpty(destinationProperties.Metadata);
                    Assert.IsNull(destinationProperties.ContentDisposition);
                    Assert.IsNull(destinationProperties.ContentLanguage);
                    Assert.IsNull(destinationProperties.CacheControl);

                    GetBlobTagResult destinationTags = await destinationClient.GetTagsAsync();
                    Assert.IsEmpty(destinationTags.Tags);
                }
                else if (propertiesTestType == TransferPropertiesTestType.NewProperties)
                {
                    BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                    Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                    Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                    Assert.AreEqual(_defaultContentLanguage, destinationProperties.ContentLanguage);
                    Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                    Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
                }
                else //(propertiesTestType == TransferPropertiesTestType.Default ||
                     //(propertiesTestType == TransferPropertiesTestType.Preserve)
                {
                    BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync();
                    BlobProperties destinationProperties = await destinationClient.GetPropertiesAsync();

                    Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                    Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
                }
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

        internal BlobStorageResourceOptions GetSetValuesResourceOptions()
            => new BlobStorageResourceOptions
            {
                AccessTier = _defaultAccessTier,
                ContentDisposition = _defaultContentDisposition,
                ContentLanguage = _defaultContentLanguage,
                CacheControl = _defaultCacheControl,
                ContentType = _defaultContentType,
                Metadata = _defaultMetadata,
            };
    }
}
