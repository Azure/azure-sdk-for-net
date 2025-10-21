// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias DMBlob;
extern alias DMShare;
extern alias BaseShares;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    [BlobShareClientTestFixture]
    public abstract class StartTransferCopyFromShareDirectoryTestBase : StartTransferDirectoryCopyTestBase
        <ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        BlobServiceClient,
        BlobContainerClient,
        BlobClientOptions,
        StorageTestEnvironment>
    {
        public const int MaxReliabilityRetries = 5;
        internal readonly AccessTier _defaultAccessTier = AccessTier.Cold;
        internal const string _defaultContentType = "text/plain";
        internal const string _defaultContentLanguageBlob = "en-US";
        internal readonly string[] _defaultContentLanguageShare = new[] { "en-US", "en-CA" };
        internal const string _defaultContentDisposition = "inline";
        internal const string _defaultCacheControl = "no-cache";
        internal const NtfsFileAttributes _defaultFileAttributes = NtfsFileAttributes.None;
        internal readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        private readonly DateTimeOffset _defaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset _defaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset _defaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "BlobAlreadyExists";
        protected readonly object _serviceVersion;

        public StartTransferCopyFromShareDirectoryTestBase(
            bool async,
            object serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, (ShareClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
        }

        protected override Task CreateDirectoryInDestinationAsync(BlobContainerClient destinationContainer, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // No-op since blobs are virtual directories
            return Task.CompletedTask;
        }

        protected override async Task CreateDirectoryInSourceAsync(ShareClient sourceContainer, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = sourceContainer.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
        }

        protected override async Task CreateObjectInSourceAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = null,
            TransferPropertiesTestType propertiesType = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            await fileClient.CreateAsync(objectLength.Value);

            if (contents != default)
            {
                await fileClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            BlobServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential);
            return await DestinationClientBuilder.GetTestContainerAsync(oauthService, containerName);
        }

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetDestinationDisposingContainerAsync(BlobServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
            => await DestinationClientBuilder.GetTestContainerAsync(service, containerName);

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            ShareClientOptions options = SourceClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential, options);
            return await SourceClientBuilder.GetTestShareAsync(oauthService, containerName);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetSourceDisposingContainerAsync(
            ShareServiceClient service = null,
            string containerName = null,
            CancellationToken cancellationToken = default)
            => await SourceClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceContainer GetSourceStorageResourceContainer(ShareClient containerClient, string directoryPath)
        {
            // Authorize with SAS when performing operations
            if (containerClient.CanGenerateSasUri)
            {
                Uri sourceUri = containerClient.GenerateSasUri(BaseShares::Azure.Storage.Sas.ShareSasPermissions.All, Recording.UtcNow.AddDays(1));
                ShareClient sasClient = InstrumentClient(new ShareClient(sourceUri, GetShareOptions()));
                return new ShareDirectoryStorageResourceContainer(sasClient.GetDirectoryClient(directoryPath), default);
            }
            return new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(directoryPath), default);
        }

        protected override async Task VerifyEmptyDestinationContainerAsync(BlobContainerClient destinationContainer, string destinationPrefix, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            GetBlobsOptions options = new GetBlobsOptions()
            {
                Prefix = destinationPrefix,
            };
            IList<BlobItem> items = await destinationContainer.GetBlobsAsync(options, cancellationToken: cancellationToken).ToListAsync();
            Assert.IsEmpty(items);
        }

        protected override async Task VerifyResultsAsync(
            ShareClient sourceContainer,
            string sourcePrefix,
            BlobContainerClient destinationContainer,
            string destinationPrefix,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // List all files in source blob folder path
            List<string> sourceFileNames = new List<string>();

            // Get source directory client and list the paths
            ShareDirectoryClient sourceDirectory = string.IsNullOrEmpty(sourcePrefix) ?
                sourceContainer.GetRootDirectoryClient() :
                sourceContainer.GetDirectoryClient(sourcePrefix);
            await foreach ((ShareDirectoryClient dir, ShareFileClient file) in ScanShareDirectoryAsync(
                sourceDirectory, cancellationToken).ConfigureAwait(false))
            {
                if (file != default)
                {
                    sourceFileNames.Add(file.Path.Substring(sourcePrefix.Length + 1));
                }
            }

            // List all files in the destination blob folder path
            List<string> destinationFileNames = new List<string>();
            GetBlobsOptions options = new GetBlobsOptions
            {
                Prefix = destinationPrefix,
            };
            await foreach (Page<BlobItem> page in destinationContainer.GetBlobsAsync(options, cancellationToken: cancellationToken).AsPages())
            {
                destinationFileNames.AddRange(page.Values.Select((BlobItem item) => item.Name.Substring(destinationPrefix.Length + 1)));
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
                string destinationFullName = string.Join("/", destinationPrefix, destinationFileNames[i]);
                using Stream sourceStream = await sourceDirectory.GetFileClient(sourceFileNames[i]).OpenReadAsync(cancellationToken: cancellationToken);
                using Stream destinationStream = await destinationContainer.GetBlobClient(destinationFullName).OpenReadAsync(cancellationToken: cancellationToken);
                Assert.AreEqual(sourceStream, destinationStream);
            }
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

        private async IAsyncEnumerable<(ShareDirectoryClient Dir, ShareFileClient File)> ScanShareDirectoryAsync(
            ShareDirectoryClient directory,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(directory, nameof(directory));

            Queue<ShareDirectoryClient> toScan = new();
            toScan.Enqueue(directory);

            while (toScan.Count > 0)
            {
                ShareDirectoryClient current = toScan.Dequeue();
                await foreach (ShareFileItem item in current.GetFilesAndDirectoriesAsync(
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (item.IsDirectory)
                    {
                        ShareDirectoryClient subdir = current.GetSubdirectoryClient(item.Name);
                        toScan.Enqueue(subdir);
                        yield return (Dir: subdir, File: null);
                    }
                    else
                    {
                        yield return (Dir: null, File: current.GetFileClient(item.Name));
                    }
                }
            }
        }

        internal BlobStorageResourceOptions GetSetValuesResourceOptions()
            => new BlobStorageResourceOptions
            {
                AccessTier = _defaultAccessTier,
                ContentDisposition = _defaultContentDisposition,
                ContentLanguage = _defaultContentLanguageBlob,
                CacheControl = _defaultCacheControl,
                ContentType = _defaultContentType,
                Metadata = _defaultMetadata,
            };

        [Test]
        public override Task DirectoryToDirectory_OAuth()
        {
            // NoOp this test since File To Blob
            return Task.CompletedTask;
        }
    }
}
