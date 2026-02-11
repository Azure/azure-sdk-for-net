// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias BaseShares;
extern alias DMBlob;
extern alias DMShare;

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
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Common;
using DMBlob::Azure.Storage.DataMovement.Blobs;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Blobs.Files.Shares.Tests
{
    public abstract class StartTransferCopyToShareDirectoryTestBase
        : StartTransferDirectoryCopyTestBase<BlobServiceClient,
        BlobContainerClient,
        BlobClientOptions,
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        internal readonly AccessTier _defaultAccessTier = AccessTier.Cold;
        internal const string _defaultContentType = "image/jpeg";
        internal const string _defaultContentLanguageBlob = "en-US";
        internal readonly string[] _defaultContentLanguageShare = new[] { "en-US", "en-CA" };
        internal const string _defaultContentDisposition = "inline";
        internal const string _defaultCacheControl = "no-cache";
        internal const NtfsFileAttributes _defaultFileAttributes = NtfsFileAttributes.None;
        internal readonly Metadata _defaultMetadata = DataProvider.BuildMetadata();
        public const int MaxReliabilityRetries = 5;
        private readonly DateTimeOffset _defaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset _defaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset _defaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        protected readonly object _serviceVersion;

        public StartTransferCopyToShareDirectoryTestBase(
            bool async,
            object serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            SourceClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, (BlobClientOptions.ServiceVersion)serviceVersion);
            DestinationClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, (ShareClientOptions.ServiceVersion)serviceVersion);
        }

        protected override async Task CreateDirectoryInDestinationAsync(ShareClient destinationContainer, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = destinationContainer.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
        }

        protected async Task CreateDirectoryWithOptionsInDestinationAsync(
            ShareClient destinationContainer,
            string directoryPath,
            ShareDirectoryCreateOptions options,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = destinationContainer.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(options: options, cancellationToken: cancellationToken);
        }

        protected override Task CreateDirectoryInSourceAsync(BlobContainerClient sourceContainer, string directoryPath, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            // No-op since blobs are virtual directories
            return Task.CompletedTask;
        }

        protected override async Task CreateObjectInDestinationAsync(ShareClient container, long? objectLength = null, string objectName = null, Stream contents = null, CancellationToken cancellationToken = default)
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

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            ShareClientOptions options = DestinationClientBuilder.GetOptions();
            options.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient oauthService = DestinationClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential, options);
            return await DestinationClientBuilder.GetTestShareAsync(oauthService, containerName);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDestinationDisposingContainerAsync(ShareServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
            => await DestinationClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceContainer GetDestinationStorageResourceContainer(
            ShareClient containerClient,
            string directoryPath,
            TransferPropertiesTestType propertiesTestType = default)
        {
            ShareFileStorageResourceOptions options = new()
            {
                SkipProtocolValidation = true,
            };
            if (propertiesTestType == TransferPropertiesTestType.NewProperties)
            {
                options = new ShareFileStorageResourceOptions
                {
                    ContentDisposition = _defaultContentDisposition,
                    ContentLanguage = _defaultContentLanguageShare,
                    CacheControl = _defaultCacheControl,
                    ContentType = _defaultContentType,
                    FileMetadata = _defaultMetadata,
                    FileAttributes = _defaultFileAttributes,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                    SkipProtocolValidation = true
                };
            }
            else if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
            {
                options = new ShareFileStorageResourceOptions
                {
                    ContentDisposition = default,
                    ContentLanguage = default,
                    CacheControl = default,
                    ContentType = default,
                    FileMetadata = default,
                    FileAttributes = default,
                    FileCreatedOn = default,
                    FileLastWrittenOn = default,
                    SkipProtocolValidation = true
                };
            }
            else if (propertiesTestType == TransferPropertiesTestType.Preserve)
            {
                options = new ShareFileStorageResourceOptions
                {
                    FilePermissions = true,
                    SkipProtocolValidation = true
                };
            }
            // Authorize with SAS when performing operations
            if (containerClient.CanGenerateSasUri)
            {
                Uri uri = containerClient.GenerateSasUri(BaseShares::Azure.Storage.Sas.ShareSasPermissions.All, Recording.UtcNow.AddDays(1));
                ShareClient sasClient = InstrumentClient(new ShareClient(uri, GetShareOptions()));
                return new ShareDirectoryStorageResourceContainer(sasClient.GetDirectoryClient(directoryPath), options);
            }
            return new ShareDirectoryStorageResourceContainer(containerClient.GetDirectoryClient(directoryPath), options);
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

        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerOauthAsync(
            string containerName = default,
            CancellationToken cancellationToken = default)
        {
            BlobServiceClient oauthService = SourceClientBuilder.GetServiceClientFromOauthConfig(Tenants.TestConfigOAuth, TestEnvironment.Credential);
            return await SourceClientBuilder.GetTestContainerAsync(oauthService, containerName);
        }

        // Blob to File always needs OAuth source container
        protected override async Task<IDisposingContainer<BlobContainerClient>> GetSourceDisposingContainerAsync(BlobServiceClient service = null, string containerName = null, CancellationToken cancellationToken = default)
            => await SourceClientBuilder.GetOAuthTestContainerAsync(containerName, TestEnvironment.Credential);

        protected override async Task VerifyEmptyDestinationContainerAsync(ShareClient destinationContainer, string destinationPrefix, CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            IList<ShareFileItem> items = await destinationDirectory.GetFilesAndDirectoriesAsync(cancellationToken: cancellationToken).ToListAsync();
            Assert.IsEmpty(items);
        }

        protected override async Task VerifyResultsAsync(
            BlobContainerClient sourceContainer,
            string sourcePrefix,
            ShareClient destinationContainer,
            string destinationPrefix,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

            // List all files in source blob folder path
            List<string> sourceFileNames = new List<string>();

            // Get source directory client and list the paths
            GetBlobsOptions options = new GetBlobsOptions
            {
                Prefix = sourcePrefix
            };
            await foreach (Page<BlobItem> page in sourceContainer.GetBlobsAsync(options, cancellationToken: cancellationToken).AsPages())
            {
                sourceFileNames.AddRange(page.Values.Select((BlobItem item) => item.Name.Substring(sourcePrefix.Length + 1)));
            }

            // List all files in the destination blob folder path
            List<string> destinationFileNames = new List<string>();
            ShareDirectoryClient destinationDirectory = string.IsNullOrEmpty(destinationPrefix) ?
                destinationContainer.GetRootDirectoryClient() :
                destinationContainer.GetDirectoryClient(destinationPrefix);
            await foreach ((ShareDirectoryClient dir, ShareFileClient file) in ScanShareDirectoryAsync(
                destinationDirectory, cancellationToken).ConfigureAwait(false))
            {
                if (file != default)
                {
                    destinationFileNames.Add(file.Path.Substring(destinationPrefix.Length + 1));
                }
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
                string sourceFullName = string.Join("/", sourcePrefix, sourceFileNames[i]);
                BlobBaseClient sourceClient = sourceContainer.GetBlobClient(sourceFullName);
                ShareFileClient destinationClient = destinationDirectory.GetFileClient(destinationFileNames[i]);
                using Stream sourceStream = await sourceClient.OpenReadAsync(cancellationToken: cancellationToken);
                using Stream destinationStream = await destinationClient.OpenReadAsync(cancellationToken: cancellationToken);
                Assert.AreEqual(sourceStream, destinationStream);

                if (propertiesTestType == TransferPropertiesTestType.NoPreserve)
                {
                    ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                    Assert.IsEmpty(destinationProperties.Metadata);
                    Assert.IsNull(destinationProperties.ContentDisposition);
                    Assert.IsNull(destinationProperties.ContentLanguage);
                    Assert.IsNull(destinationProperties.CacheControl);
                }
                else if (propertiesTestType == TransferPropertiesTestType.NewProperties)
                {
                    BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync(cancellationToken: cancellationToken);
                    ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                    Assert.That(_defaultMetadata, Is.EqualTo(destinationProperties.Metadata));
                    Assert.AreEqual(_defaultContentDisposition, destinationProperties.ContentDisposition);
                    Assert.AreEqual(_defaultContentLanguageShare, destinationProperties.ContentLanguage);
                    Assert.AreEqual(_defaultCacheControl, destinationProperties.CacheControl);
                    Assert.AreEqual(_defaultContentType, destinationProperties.ContentType);
                    Assert.AreEqual(_defaultFileCreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                    Assert.AreEqual(_defaultFileLastWrittenOn, destinationProperties.SmbProperties.FileLastWrittenOn);
                    Assert.AreEqual(_defaultFileChangedOn, destinationProperties.SmbProperties.FileChangedOn);
                }
                else //(propertiesTestType == TransferPropertiesTestType.Default ||
                     //propertiesTestType == TransferPropertiesTestType.Preserve)
                {
                    BlobProperties sourceProperties = await sourceClient.GetPropertiesAsync(cancellationToken: cancellationToken);
                    ShareFileProperties destinationProperties = await destinationClient.GetPropertiesAsync(cancellationToken: cancellationToken);

                    Assert.That(sourceProperties.Metadata, Is.EqualTo(destinationProperties.Metadata));
                    Assert.AreEqual(sourceProperties.ContentDisposition, destinationProperties.ContentDisposition);
                    Assert.AreEqual(sourceProperties.ContentLanguage, destinationProperties.ContentLanguage.First());
                    Assert.AreEqual(sourceProperties.CacheControl, destinationProperties.CacheControl);
                    Assert.AreEqual(sourceProperties.ContentType, destinationProperties.ContentType);
                    Assert.AreEqual(sourceProperties.CreatedOn, destinationProperties.SmbProperties.FileCreatedOn);
                }
            }
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

        protected async Task VerifyFileContentsAsync(
            string sourceBlobName,
            BlobContainerClient sourceBlobContainerClient,
            ShareFileClient destinationFileClient,
            CancellationToken cancellationToken)
        {
            // Assert file and file contents
            BlobBaseClient sourceBlobClient = sourceBlobContainerClient.GetBlobClient(sourceBlobName);
            using Stream sourceStream = await sourceBlobClient.OpenReadAsync(cancellationToken: cancellationToken);
            using Stream destinationStream = await destinationFileClient.OpenReadAsync(cancellationToken: cancellationToken);
            Assert.That(sourceStream, Is.EqualTo(destinationStream));
        }

        [Test]
        public override Task DirectoryToDirectory_OAuth()
        {
            // NoOp this test since Blob To File
            return Task.CompletedTask;
        }

        [RecordedTest]
        public async Task BlobDirectoryToShareDirectory_SkipIfExists_ExistingDirectoriesTransferFiles()
        {
            // Arrange
            await using IDisposingContainer<BlobContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destination = await GetDestinationDisposingContainerAsync();

            int size = DataMovementTestConstants.KB;
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";

            // Setup SOURCE: Create blob directory structure WITH files (blobs don't have real directories)
            string sourceItemName1 = $"{sourcePrefix}/item1";
            await CreateObjectInSourceAsync(source.Container, size, sourceItemName1);
            string sourceItemName2 = $"{sourcePrefix}/item2";
            await CreateObjectInSourceAsync(source.Container, size, sourceItemName2);
            string sourceItemName3 = $"{sourcePrefix}/bar/item3";
            await CreateObjectInSourceAsync(source.Container, size, sourceItemName3);
            string sourceItemName4 = $"{sourcePrefix}/pik/item4";
            await CreateObjectInSourceAsync(source.Container, size, sourceItemName4);
            // This creates:
            // sourceFolder/
            // ├── item1 (blob)
            // ├── item2 (blob)
            // ├── bar/
            // │   └── item3 (blob)
            // └── pik/
            //     └── item4 (blob)

            // Destination directory metadata and properties (DIFFERENT from source)
            ShareDirectoryCreateOptions destDirOptions = new ShareDirectoryCreateOptions()
            {
                Metadata = _defaultMetadata,
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = NtfsFileAttributes.Directory | NtfsFileAttributes.System,
                    FileCreatedOn = new DateTimeOffset(2021, 8, 1, 9, 5, 55, default),
                    FileChangedOn = new DateTimeOffset(2021, 9, 1, 9, 5, 55, default),
                    FileLastWrittenOn = new DateTimeOffset(2021, 10, 1, 9, 5, 55, default),
                },
            };

            // Setup DESTINATION: Create EMPTY directory structure with specific properties
            await CreateDirectoryWithOptionsInDestinationAsync(destination.Container, destPrefix, destDirOptions);
            string destSubDir1 = string.Join("/", destPrefix, "bar");
            await CreateDirectoryWithOptionsInDestinationAsync(destination.Container, destSubDir1, destDirOptions);
            string destSubDir2 = string.Join("/", destPrefix, "pik");
            await CreateDirectoryWithOptionsInDestinationAsync(destination.Container, destSubDir2, destDirOptions);
            // Destination has the directories but NO files

            // Store original destination directory properties to verify they weren't changed
            ShareDirectoryClient destBarDir = destination.Container.GetDirectoryClient(destSubDir1);
            ShareDirectoryProperties originalBarProps = await destBarDir.GetPropertiesAsync();

            // Create storage resource containers
            BlobContainerClient sourceContainer = source.Container;
            StorageResourceContainer sourceResource = new BlobStorageResourceContainer(
                sourceContainer,
                new BlobStorageResourceContainerOptions()
                {
                    BlobPrefix = sourcePrefix
                });

            ShareDirectoryClient destinationDirectory = destination.Container.GetDirectoryClient(destPrefix);
            StorageResourceContainer destinationResource = new ShareDirectoryStorageResourceContainer(
                destinationDirectory,
                new ShareFileStorageResourceOptions());

            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            TransferManager transferManager = new TransferManager();

            // Act
            TransferOperation transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert: Transfer should complete successfully
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);

            // Verify FILES were transferred
            ShareDirectoryClient destDirectory = destination.Container.GetDirectoryClient(destPrefix);

            // Check root level files
            ShareFileClient destFile1 = destDirectory.GetFileClient("item1");
            Assert.IsTrue(await destFile1.ExistsAsync());
            await VerifyFileContentsAsync(
                sourceItemName1,
                sourceContainer,
                destFile1,
                CancellationToken.None);

            ShareFileClient destFile2 = destDirectory.GetFileClient("item2");
            Assert.IsTrue(await destFile2.ExistsAsync());
            await VerifyFileContentsAsync(
                sourceItemName2,
                sourceContainer,
                destFile2,
                CancellationToken.None);

            // Check files in subdirectories
            ShareDirectoryClient destBarDirClient = destDirectory.GetSubdirectoryClient("bar");
            ShareFileClient destFile3 = destBarDirClient.GetFileClient("item3");
            Assert.IsTrue(await destFile3.ExistsAsync());
            await VerifyFileContentsAsync(
                sourceItemName3,
                sourceContainer,
                destFile3,
                CancellationToken.None);

            ShareDirectoryClient destPikDirClient = destDirectory.GetSubdirectoryClient("pik");
            ShareFileClient destFile4 = destPikDirClient.GetFileClient("item4");
            Assert.IsTrue(await destFile4.ExistsAsync());
            await VerifyFileContentsAsync(
                sourceItemName4,
                sourceContainer,
                destFile4,
                CancellationToken.None);

            // Assert: Verify directory properties were NOT changed (directory was skipped)
            ShareDirectoryProperties currentBarProps = await destBarDir.GetPropertiesAsync();

            // Directory should retain its ORIGINAL properties (not source properties)
            Assert.That(originalBarProps.Metadata, Is.EqualTo(currentBarProps.Metadata),
                "Directory metadata should not change when skipped");
            Assert.AreEqual(originalBarProps.SmbProperties.FileAttributes, currentBarProps.SmbProperties.FileAttributes,
                "Directory attributes should not change when skipped");
            Assert.AreEqual(originalBarProps.SmbProperties.FileCreatedOn, currentBarProps.SmbProperties.FileCreatedOn,
                "Directory FileCreatedOn should not change when skipped");
        }
    }
}
