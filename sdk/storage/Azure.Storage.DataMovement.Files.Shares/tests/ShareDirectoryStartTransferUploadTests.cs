// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;
extern alias DMShare;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture(true)]
    [DataMovementShareClientTestFixture(false)]
    internal class ShareDirectoryStartTransferUploadTests : StartTransferUploadDirectoryTestBase<
        ShareServiceClient,
        ShareDirectoryClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        /// <summary>
        /// A <see cref="Storage.Files.Shares.Tests.DisposingShare"/> but exposes a directory client within that share.
        /// Still cleans up the whole share. Helpful for parameterizing tests to use a root
        /// directory vs a subdir.
        /// </summary>
        private class DisposingShareDirectory : IDisposingContainer<ShareDirectoryClient>
        {
            private readonly DisposingShare _disposingShare;
            public ShareDirectoryClient Container { get; }

            public DisposingShareDirectory(DisposingShare disposingShare, ShareDirectoryClient dirClient)
            {
                _disposingShare = disposingShare;
                Container = dirClient;
            }

            public async ValueTask DisposeAsync()
            {
                if (_disposingShare != default)
                {
                    await _disposingShare.DisposeAsync();
                }
            }
        }

        public bool UseNonRootDirectory { get; }
        // When the file is created, the last modified time is set to the current time.
        // We need to set the last modified time to a fixed value to make the test recordable/predictable.
        private readonly DateTimeOffset? _defaultFileLastWrittenOn = new DateTimeOffset(2024, 11, 24, 11, 23, 45, TimeSpan.FromHours(10));
        private readonly Dictionary<string,string> _defaultMetadata = DataProvider.BuildMetadata();

        public ShareDirectoryStartTransferUploadTests(bool async, ShareClientOptions.ServiceVersion serviceVersion, bool useNonRootDirectory)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
            UseNonRootDirectory = useNonRootDirectory;
        }

        protected override async Task<IDisposingContainer<ShareDirectoryClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
        {
            DisposingShare disposingShare = await ClientBuilder.GetTestShareAsync(service, containerName);
            ShareDirectoryClient directoryClient = disposingShare.Container.GetRootDirectoryClient();
            if (UseNonRootDirectory)
            {
                foreach (var _ in Enumerable.Range(0, 2))
                {
                    directoryClient = directoryClient.GetSubdirectoryClient(GetNewObjectName());
                    await directoryClient.CreateAsync();
                }
            }
            return new DisposingShareDirectory(disposingShare, directoryClient);
        }

        protected override StorageResourceContainer GetStorageResourceContainer(ShareDirectoryClient containerClient)
        {
            ShareFileStorageResourceOptions options = new();
            if (Mode == Core.TestFramework.RecordedTestMode.Record ||
                Mode == Core.TestFramework.RecordedTestMode.Playback)
            {
                options.FileLastWrittenOn = _defaultFileLastWrittenOn;
            }
            return new ShareDirectoryStorageResourceContainer(containerClient, options);
        }

        protected override TransferValidator.ListFilesAsync GetStorageResourceLister(ShareDirectoryClient containerClient)
        {
            return TransferValidator.GetShareFileLister(containerClient);
        }

        protected override async Task InitializeDestinationDataAsync(ShareDirectoryClient containerClient, List<(string FilePath, long Size)> fileSizes, CancellationToken cancellationToken)
        {
            foreach ((string filePath, long size) in fileSizes)
            {
                ShareDirectoryClient directory = containerClient;

                string[] pathSegments = filePath.Split('/');
                foreach (string pathSegment in pathSegments.Take(pathSegments.Length - 1))
                {
                    directory = directory.GetSubdirectoryClient(pathSegment);
                    await directory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
                }
                ShareFileClient file = directory.GetFileClient(pathSegments.Last());
                await file.CreateAsync(size, cancellationToken: cancellationToken);
                await file.UploadAsync(await CreateLimitedMemoryStream(size), cancellationToken: cancellationToken);
            }
        }

        private async Task CreateDirectoryAsync(
            ShareDirectoryClient rootDirectory,
            string directoryPath,
            ShareDirectoryCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = rootDirectory.GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(options: options, cancellationToken: cancellationToken);
        }

        protected async Task VerifyFileContentsAsync(
            string sourceFilePath,
            ShareFileClient destinationFileClient,
            CancellationToken cancellationToken)
        {
            // Assert file and file contents
            using Stream sourceStream = File.OpenRead(sourceFilePath);
            using Stream destinationStream = await destinationFileClient.OpenReadAsync(cancellationToken: cancellationToken);
            Assert.That(sourceStream, Is.EqualTo(destinationStream));
        }

        [RecordedTest]
        public async Task LocalDirectoryToShareDirectory_SkipIfExists_ExistingDirectories()
        {
            // Arrange
            using DisposingLocalDirectory source = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<ShareDirectoryClient> destination = await GetDisposingContainerAsync();

            int size = DataMovementTestConstants.KB;
            string sourcePath = source.DirectoryPath;
            string destPrefix = "destFolder";

            // Setup SOURCE: Create local directory structure WITH files
            Directory.CreateDirectory(sourcePath);
            string itemName1 = Path.Combine(sourcePath, "item1");
            File.WriteAllBytes(itemName1, new byte[size]);
            string itemName2 = Path.Combine(sourcePath, "item2");
            File.WriteAllBytes(itemName2, new byte[size]);

            string sourceSubDir1 = Path.Combine(sourcePath, "bar");
            Directory.CreateDirectory(sourceSubDir1);
            string itemName3 = Path.Combine(sourceSubDir1, "item3");
            File.WriteAllBytes(itemName3, new byte[size]);

            string sourceSubDir2 = Path.Combine(sourcePath, "pik");
            Directory.CreateDirectory(sourceSubDir2);
            string itemName4 = Path.Combine(sourceSubDir2, "item4");
            File.WriteAllBytes(itemName4, new byte[size]);
            // This creates:
            // source/
            // ├── item1 (file)
            // ├── item2 (file)
            // ├── bar/
            // │   └── item3 (file)
            // └── pik/
            //     └── item4 (file)

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

            // Setup DESTINATION: Create EMPTY directory structure with DIFFERENT properties
            await CreateDirectoryAsync(destination.Container, destPrefix, destDirOptions);
            string destSubDir1 = string.Join("/", destPrefix, "bar");
            await CreateDirectoryAsync(destination.Container, destSubDir1, destDirOptions);
            string destSubDir2 = string.Join("/", destPrefix, "pik");
            await CreateDirectoryAsync(destination.Container, destSubDir2, destDirOptions);
            // Destination has the directories but NO files

            // Store original destination directory properties to verify they weren't changed
            ShareDirectoryClient destBarDir = destination.Container.GetSubdirectoryClient(destSubDir1);
            ShareDirectoryProperties originalBarProps = await destBarDir.GetPropertiesAsync();

            // Create storage resource containers
            StorageResourceContainer sourceResource = new LocalDirectoryStorageResourceContainer(sourcePath);

            ShareDirectoryClient destinationDirectory = destination.Container.GetSubdirectoryClient(destPrefix);
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
            ShareDirectoryClient destDirectory = destination.Container.GetSubdirectoryClient(destPrefix);

            // Check root level files
            ShareFileClient destFile1 = destDirectory.GetFileClient("item1");
            Assert.IsTrue(await destFile1.ExistsAsync(), "item1 should exist");
            await VerifyFileContentsAsync(
                itemName1,
                destFile1,
                CancellationToken.None);

            ShareFileClient destFile2 = destDirectory.GetFileClient("item2");
            Assert.IsTrue(await destFile2.ExistsAsync(), "item2 should exist");
            await VerifyFileContentsAsync(
                itemName2,
                destFile2,
                CancellationToken.None);

            // Check files in subdirectories
            ShareDirectoryClient destBarDirClient = destDirectory.GetSubdirectoryClient("bar");
            ShareFileClient destFile3 = destBarDirClient.GetFileClient("item3");
            Assert.IsTrue(await destFile3.ExistsAsync(), "bar/item3 should exist");
            await VerifyFileContentsAsync(
                itemName3,
                destFile3,
                CancellationToken.None);

            ShareDirectoryClient destPikDirClient = destDirectory.GetSubdirectoryClient("pik");
            ShareFileClient destFile4 = destPikDirClient.GetFileClient("item4");
            Assert.IsTrue(await destFile4.ExistsAsync(), "pik/item4 should exist");
            await VerifyFileContentsAsync(
                itemName4,
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
