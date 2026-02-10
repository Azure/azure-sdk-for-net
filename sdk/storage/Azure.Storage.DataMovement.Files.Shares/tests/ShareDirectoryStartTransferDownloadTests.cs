// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;
extern alias DMShare;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using Azure.Storage.Test.Shared;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using NUnit.Framework;
using Azure.Core.TestFramework;
using BaseShares::Azure.Storage.Files.Shares.Models;
using System.Linq;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture]
    public class ShareDirectoryStartTransferDownloadTests
        : StartTransferDirectoryDownloadTestBase<
        ShareServiceClient,
        ShareClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _dirResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";
        private readonly DateTimeOffset _defaultFileCreatedOn = new DateTimeOffset(2024, 4, 1, 9, 5, 55, default);
        private readonly DateTimeOffset _defaultFileLastWrittenOn = new DateTimeOffset(2024, 4, 1, 12, 16, 6, default);
        private readonly DateTimeOffset _defaultFileChangedOn = new DateTimeOffset(2024, 4, 1, 13, 30, 3, default);

        public ShareDirectoryStartTransferDownloadTests(
            bool async,
            ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, _dirResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task CreateObjectClientAsync(
            ShareClient container,
            long? objectLength,
            string objectName,
            bool createResource = false,
            ShareClientOptions options = null,
            Stream contents = null,
            CancellationToken cancellationToken = default)
        {
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
            await fileClient.CreateAsync(objectLength.Value, cancellationToken: cancellationToken);

            if (contents != default)
            {
                await fileClient.UploadAsync(contents, cancellationToken: cancellationToken);
            }
        }

        private async Task CreateDirectoryAsync(ShareClient container,
            string directoryPath,
            ShareDirectoryCreateOptions options = default,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            ShareDirectoryClient directory = container.GetRootDirectoryClient().GetSubdirectoryClient(directoryPath);
            await directory.CreateIfNotExistsAsync(options: options, cancellationToken: cancellationToken);
        }

        private async Task CreateShareFileNfsAndHardLinkAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);

            await fileClient.CreateAsync(
                maxSize: objectLength.Value,
                cancellationToken: cancellationToken);

            ShareFileClient hardlinkClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient($"{objectName}-hardlink"));

            // Create Hardlink
            await hardlinkClient.CreateHardLinkAsync(
                targetFile: $"{container.GetRootDirectoryClient().Name}/{objectName}");

            // Assert hardlink was successfully created
            ShareFileProperties properties = await hardlinkClient.GetPropertiesAsync();
            Assert.AreEqual(2, properties.PosixProperties.LinkCount);
            Assert.AreEqual(NfsFileType.Regular, properties.PosixProperties.FileType);
        }

        private async Task CreateShareFileNfsAndSymLinkAsync(
            ShareClient container,
            long? objectLength = null,
            string objectName = null,
            CancellationToken cancellationToken = default)
        {
            CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
            objectName ??= GetNewObjectName();
            if (!objectLength.HasValue)
            {
                throw new InvalidOperationException($"Cannot create share file without size specified. Specify {nameof(objectLength)}.");
            }
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);

            await fileClient.CreateAsync(
                maxSize: objectLength.Value,
                cancellationToken: cancellationToken);

            ShareFileClient symlinkClient = InstrumentClient(container.GetRootDirectoryClient().GetFileClient($"{objectName}-symlink"));

            // Create Symlink
            await symlinkClient.CreateSymbolicLinkAsync(linkText: fileClient.Uri.AbsolutePath);

            // Assert symlink was successfully created
            ShareFileProperties properties = await symlinkClient.GetPropertiesAsync();
            Assert.AreEqual(1, properties.PosixProperties.LinkCount);
            Assert.AreEqual(NfsFileType.SymLink, properties.PosixProperties.FileType);
        }

        protected override TransferValidator.ListFilesAsync GetSourceLister(ShareClient container, string prefix)
            => TransferValidator.GetShareFileLister(container.GetDirectoryClient(prefix));

        protected override StorageResourceContainer GetStorageResourceContainer(ShareClient container, string directoryPath)
        {
            ShareDirectoryClient directory = string.IsNullOrEmpty(directoryPath) ?
                    container.GetRootDirectoryClient() :
                    container.GetDirectoryClient(directoryPath);
            return new ShareDirectoryStorageResourceContainer(directory, new ShareFileStorageResourceOptions());
        }

        protected override async Task SetupSourceDirectoryAsync(
            ShareClient container,
            string directoryPath,
            List<(string PathName, int Size)> fileSizes,
            CancellationToken cancellationToken)
        {
            ShareDirectoryClient parentDirectory = string.IsNullOrEmpty(directoryPath) ?
                    container.GetRootDirectoryClient() :
                    container.GetDirectoryClient(directoryPath);
            if (!string.IsNullOrEmpty(directoryPath))
            {
                await parentDirectory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
            }
            HashSet<string> subDirectoryNames = new() { directoryPath };
            foreach ((string filePath, long size) in fileSizes)
            {
                CancellationHelper.ThrowIfCancellationRequested(cancellationToken);

                // Check if the parent subdirectory is already created,
                // if not create it before making the files
                int fileNameIndex = filePath.LastIndexOf('/');
                string subDirectoryName = fileNameIndex > 0 ? filePath.Substring(0, fileNameIndex) : "";
                string fileName = fileNameIndex > 0 ? filePath.Substring(fileNameIndex + 1) : filePath;

                // Create parent subdirectory if it does not currently exist.
                ShareDirectoryClient subdirectory = string.IsNullOrEmpty(subDirectoryName) ?
                    container.GetRootDirectoryClient() :
                    container.GetDirectoryClient(subDirectoryName);

                if (!string.IsNullOrEmpty(subDirectoryName) &&
                    !subDirectoryNames.Contains(subDirectoryName))
                {
                    await subdirectory.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
                    subDirectoryNames.Add(subDirectoryName);
                }

                using (Stream data = await CreateLimitedMemoryStream(size))
                {
                    ShareFileClient fileClient = subdirectory.GetFileClient(fileName);
                    await fileClient.CreateAsync(size, cancellationToken: cancellationToken);
                    if (size > 0)
                    {
                        await fileClient.UploadAsync(data, cancellationToken: cancellationToken);
                    }
                }
            }
        }

        private async Task CreateDirectoryTreeSmbAsync(
            ShareClient client,
            string sourcePrefix,
            ShareDirectoryCreateOptions options,
            int size)
        {
            string itemName1 = string.Join("/", sourcePrefix, "item1");
            string itemName2 = string.Join("/", sourcePrefix, "item2");
            await CreateObjectClientAsync(client, size, itemName1);
            await CreateObjectClientAsync(client, size, itemName2);

            string subDirPath = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryAsync(client, subDirPath, options);
            string itemName3 = string.Join("/", subDirPath, "item3");
            await CreateObjectClientAsync(client, size, itemName3);

            string subDirPath2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryAsync(client, subDirPath2, options);
            string itemName4 = string.Join("/", subDirPath2, "item4");
            await CreateObjectClientAsync(client, size, itemName4);
        }

        protected async Task VerifyFileContentsAsync(
            ShareFileClient sourceFileClient,
            string destinationFilePath,
            CancellationToken cancellationToken)
        {
            // Assert file and file contents
            using Stream sourceStream = await sourceFileClient.OpenReadAsync(cancellationToken: cancellationToken);
            using Stream destinationStream = File.OpenRead(destinationFilePath);
            Assert.That(sourceStream, Is.EqualTo(destinationStream));
        }

        [RecordedTest]
        public async Task ShareDirectoryToLocalDirectory_NfsHardLink()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await ClientBuilder.GetTestShareSasNfsAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";

            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix);
            string itemName1 = string.Join("/", sourcePrefix, "item1");
            await CreateShareFileNfsAndHardLinkAsync(source.Container, DataMovementTestConstants.KB, itemName1);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            StorageResource destinationResource = LocalFilesStorageResourceProvider.FromDirectory(destination.DirectoryPath);

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

            // Act
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            await testEventsRaised.AssertContainerCompletedCheck(2);

            // Get source files
            List<string> sourceFileNames = new List<string>();
            ShareDirectoryClient sourceDirectory = source.Container.GetDirectoryClient(sourcePrefix);
            await foreach (Page<ShareFileItem> page in sourceDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                sourceFileNames.AddRange(page.Values.Where((ShareFileItem item) => !item.IsDirectory).Select((ShareFileItem item) => item.Name));
            }
            // Get dest files
            List<string> destFileNames = Directory
                .EnumerateFiles(destination.DirectoryPath, "*", SearchOption.TopDirectoryOnly)
                .Select(Path.GetFileName)
                .ToList();

            // Assert all files (including hardlink) were copied over to dest
            Assert.AreEqual(sourceFileNames.Count, destFileNames.Count);
            Assert.That(sourceFileNames, Is.EquivalentTo(destFileNames));
        }

        [RecordedTest]
        public async Task ShareDirectoryToLocalDirectory_NfsSymbolicLink()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await ClientBuilder.GetTestShareSasNfsAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            string sourcePrefix = "sourceFolder";

            // setup source
            await CreateDirectoryAsync(source.Container, sourcePrefix);
            string itemName1 = string.Join("/", sourcePrefix, "item1");
            await CreateShareFileNfsAndSymLinkAsync(source.Container, DataMovementTestConstants.KB, itemName1);

            // Create storage resource containers
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                source.Container.GetDirectoryClient(sourcePrefix),
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            StorageResource destinationResource = LocalFilesStorageResourceProvider.FromDirectory(destination.DirectoryPath);

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);

            // Act
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            await testEventsRaised.AssertContainerCompletedCheck(2);

            // Get source files
            List<string> sourceFileNames = new List<string>();
            ShareDirectoryClient sourceDirectory = source.Container.GetDirectoryClient(sourcePrefix);
            await foreach (Page<ShareFileItem> page in sourceDirectory.GetFilesAndDirectoriesAsync().AsPages())
            {
                sourceFileNames.AddRange(page.Values.Where((ShareFileItem item) => !item.IsDirectory).Select((ShareFileItem item) => item.Name));
            }
            // Get dest files
            List<string> destFileNames = Directory
                .EnumerateFiles(destination.DirectoryPath, "*", SearchOption.TopDirectoryOnly)
                .Select(Path.GetFileName)
                .ToList();

            // Ensure the Symlink file was skipped and not copied
            Assert.AreEqual(2, sourceFileNames.Count);
            Assert.AreEqual(1, destFileNames.Count);
            Assert.Contains("item1-symlink", sourceFileNames);
            Assert.False(destFileNames.Contains("item1-symlink"));
            Assert.AreEqual("item1", destFileNames[0]);
        }

        [RecordedTest]
        public async Task ShareDirectoryToLocalDirectory_SkipIfExists_ExistingDirectories()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await GetDisposingContainerAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            int size = DataMovementTestConstants.KB;
            string sourcePrefix = "sourceFolder";
            string destPath = destination.DirectoryPath;

            // Source directory metadata and properties
            ShareDirectoryCreateOptions sourceDirOptions = new ShareDirectoryCreateOptions()
            {
                SmbProperties = new FileSmbProperties()
                {
                    FileAttributes = NtfsFileAttributes.Directory,
                    FileCreatedOn = _defaultFileCreatedOn,
                    FileChangedOn = _defaultFileChangedOn,
                    FileLastWrittenOn = _defaultFileLastWrittenOn,
                },
            };

            // Setup SOURCE: Create directory structure WITH files
            await CreateDirectoryAsync(source.Container, sourcePrefix, sourceDirOptions);
            await CreateDirectoryTreeSmbAsync(source.Container, sourcePrefix, sourceDirOptions, size);
            // This creates:
            // sourceFolder/
            // ├── item1 (file)
            // ├── item2 (file)
            // ├── bar/
            // │   └── item3 (file)
            // └── pik/
            //     └── item4 (file)

            // Setup DESTINATION: Create EMPTY local directory structure
            Directory.CreateDirectory(destPath);
            string destSubDir1 = Path.Combine(destPath, "bar");
            Directory.CreateDirectory(destSubDir1);
            string destSubDir2 = Path.Combine(destPath, "pik");
            Directory.CreateDirectory(destSubDir2);
            // Destination has the directories but NO files

            // Store original destination directory creation time to verify it wasn't changed
            DirectoryInfo destBarDirInfo = new DirectoryInfo(destSubDir1);
            DateTime originalCreationTime = destBarDirInfo.CreationTime;
            FileAttributes originalAttributes = destBarDirInfo.Attributes;

            // Create storage resource containers
            ShareDirectoryClient sourceDirectory = source.Container.GetDirectoryClient(sourcePrefix);
            StorageResourceContainer sourceResource = new ShareDirectoryStorageResourceContainer(
                sourceDirectory,
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Smb });

            StorageResourceContainer destinationResource = new LocalDirectoryStorageResourceContainer(destPath);

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
            // Check root level files
            string destFile1 = Path.Combine(destPath, "item1");
            Assert.IsTrue(File.Exists(destFile1), "item1 should exist");
            await VerifyFileContentsAsync(
                sourceDirectory.GetFileClient("item1"),
                destFile1,
                cancellationTokenSource.Token);

            string destFile2 = Path.Combine(destPath, "item2");
            Assert.IsTrue(File.Exists(destFile2), "item2 should exist");
            await VerifyFileContentsAsync(
                sourceDirectory.GetFileClient("item2"),
                destFile2,
                cancellationTokenSource.Token);

            // Check files in subdirectories
            string destFile3 = Path.Combine(destSubDir1, "item3");
            Assert.IsTrue(File.Exists(destFile3), "bar/item3 should exist");
            await VerifyFileContentsAsync(
                sourceDirectory.GetFileClient("bar/item3"),
                destFile3,
                cancellationTokenSource.Token);

            string destFile4 = Path.Combine(destSubDir2, "item4");
            Assert.IsTrue(File.Exists(destFile4), "pik/item4 should exist");
            await VerifyFileContentsAsync(
                sourceDirectory.GetFileClient("pik/item4"),
                destFile4,
                cancellationTokenSource.Token);

            // Assert: Verify directory properties were NOT changed (directory was skipped)
            DirectoryInfo currentDirInfo = new DirectoryInfo(destSubDir1);

            // Directory should retain its ORIGINAL properties (creation time shouldn't change significantly)
            // Allow small time difference due to file system precision
            TimeSpan timeDifference = (currentDirInfo.CreationTime - originalCreationTime).Duration();
            Assert.IsTrue(timeDifference < TimeSpan.FromSeconds(1),
                $"Directory creation time should not change when skipped. Original: {originalCreationTime}, Current: {currentDirInfo.CreationTime}");
        }
    }
}
