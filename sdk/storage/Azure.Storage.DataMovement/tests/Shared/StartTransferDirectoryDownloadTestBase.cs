// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests.Shared
{
    public abstract class StartTransferDirectoryDownloadTestBase<
        TServiceClient,
        TContainerClient,
        TObjectClient,
        TClientOptions,
        TEnvironment> : StorageTestBase<TEnvironment>
        where TServiceClient : class
        where TContainerClient : class
        where TObjectClient : class
        where TClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        private readonly string _generatedResourceNamePrefix;
        private readonly string _expectedOverwriteExceptionMessage;

        public ClientBuilder<TServiceClient, TClientOptions> ClientBuilder { get; protected set; }

        /// <summary>
        /// Constructor for TransferManager.StartTransferAsync tests
        ///
        /// The async is defaulted to true, since we do not have sync StartTransfer methods.
        /// </summary>
        /// <param name="expectedOverwriteExceptionMessage">
        /// To confirm the correct overwrite exception was thrown, we check against
        /// this exception message to verify.
        /// </param>
        /// <param name="generatedResourcenamePrefix"></param>
        /// <param name="mode"></param>
        public StartTransferDirectoryDownloadTestBase(
            bool async,
            string expectedOverwriteExceptionMessage,
            string generatedResourceNamePrefix = default,
            RecordedTestMode? mode = null) : base(async, mode)
        {
            Argument.CheckNotNullOrEmpty(expectedOverwriteExceptionMessage, nameof(expectedOverwriteExceptionMessage));
            _generatedResourceNamePrefix = generatedResourceNamePrefix ?? "test-resource-";
            _expectedOverwriteExceptionMessage = expectedOverwriteExceptionMessage;
        }

        #region Service-Specific Methods
        /// <summary>
        /// Gets a service-specific disposing container for use with tests in this class.
        /// </summary>
        /// <param name="service">Optionally specified service client to get container from.</param>
        /// <param name="containerName">Optional container name specification.</param>
        protected abstract Task<IDisposingContainer<TContainerClient>> GetDisposingContainerAsync(
            TServiceClient service = default,
            string containerName = default);

        /// <summary>
        /// Gets a new service-specific child object client from a given container, e.g. a BlobClient from a
        /// TContainerClient or a TObjectClient from a ShareClient.
        /// </summary>
        /// <param name="container">Container to get resource from.</param>
        /// <param name="objectLength">Sets the resource size in bytes, for resources that require this upfront.</param>
        /// <param name="createResource">Whether to call CreateAsync on the resource, if necessary.</param>
        /// <param name="objectName">Optional name for the resource.</param>
        /// <param name="options">ClientOptions for the resource client.</param>
        /// <param name="contents">If specified, the contents will be uploaded to the object client.</param>
        protected abstract Task<TObjectClient> GetObjectClientAsync(
            TContainerClient container,
            long? objectLength,
            string objectName,
            bool createResource = false,
            TClientOptions options = default,
            Stream contents = default);

        /// <summary>
        /// Gets the specific storage resource from the given TObjectClient
        /// e.g. TObjectClient to a ShareFileStorageResource, TObjectClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="objectClient">The object client to create the storage resource object.</param>
        /// <returns></returns>
        protected abstract StorageResourceItem GetStorageResourceItem(TObjectClient objectClient);

        /// <summary>
        /// Calls the OpenRead method on the TObjectClient.
        ///
        /// This is mainly used to verify the contents of the Object Client.
        /// </summary>
        /// <param name="objectClient">The object client to get the Open Read Stream from.</param>
        /// <returns></returns>
        protected abstract Task<Stream> OpenReadAsync(TObjectClient objectClient);
        #endregion

        protected string GetNewObjectName()
            => _generatedResourceNamePrefix + ClientBuilder.Recording.Random.NewGuid();

        #region DirectoryDownloadTests
        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="sourceContainer">The source container which will contains the source blobs</param>
        /// <param name="sourceBlobPrefix">The source blob prefix/folder</param>
        /// <param name="localDirectoryPath">The local source file prefix to join together with the source prefixes below.</param>
        /// <param name="sourceFiles">The source file paths relative to the sourceFilePrefix</param>
        /// <param name="destinationLocalPath">The destination local path to download the blobs to</param>
        /// <param name="waitTimeInSec">
        /// How long we should wait until we cancel the operation. If this timeout is reached the test will fail.
        /// </param>
        /// <param name="transferManagerOptions">Options for the transfer manager</param>
        /// <param name="options">Options for the transfer Options</param>
        /// <returns></returns>
        private async Task DownloadBlobDirectoryAndVerify(
            TContainerClient sourceContainer,
            string sourcePrefix,
            List<(string BlobName, int Size)> blobSizes,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            foreach ((string blobName, int size) in blobSizes)
            {
                await sourceContainer.GetBlobClient(blobName).UploadAsync(new BinaryData(GetRandomBuffer(size)), cancellationToken);
            }

            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Set transfer options
            options ??= new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            BlobStorageResourceContainer sourceResource = GetStorageResourceItem(sourceContainer, new()
            {
                BlobDirectoryPrefix = sourcePrefix,
            });
            LocalDirectoryStorageResourceContainer destinationResource = new(disposingLocalDirectory.DirectoryPath);

            await new TransferValidator().TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                TransferValidator.GetBlobLister(sourceContainer, sourcePrefix),
                TransferValidator.GetLocalFileLister(disposingLocalDirectory.DirectoryPath),
                blobSizes.Count,
                options,
                cancellationToken);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        public async Task DownloadDirectoryAsync_Small(int size, int waitInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            string sourceBlobDirectoryName = "foo";

            List<string> blobNames = new()
            {
                Path.Combine(sourceBlobDirectoryName, GetNewObjectName()),
                Path.Combine(sourceBlobDirectoryName, GetNewObjectName()),
                Path.Combine(sourceBlobDirectoryName, "bar", GetNewObjectName()),
                Path.Combine(sourceBlobDirectoryName, "bar", "pik", GetNewObjectName()),
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(waitInSec);
            await DownloadBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                blobNames.Select(name => (name, size)).ToList(),
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(400 * Constants.MB, 200)]
        [TestCase(Constants.GB, 500)]
        public async Task DownloadDirectoryAsync_Large(int size, int waitInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            string sourceBlobDirectoryName = "foo";

            List<string> blobNames = new()
            {
                Path.Combine(sourceBlobDirectoryName, GetNewObjectName()),
                Path.Combine(sourceBlobDirectoryName, GetNewObjectName()),
                Path.Combine(sourceBlobDirectoryName, "bar", GetNewObjectName()),
                Path.Combine(sourceBlobDirectoryName, "bar", "pik", GetNewObjectName()),
            };

            CancellationTokenSource cts = new();
            cts.CancelAfter(waitInSec);
            await DownloadBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                blobNames.Select(name => (name, size)).ToList(),
                cancellationToken: cts.Token).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_Empty()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceBlobDirectoryName = "foo";
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Initialize transferManager
            TransferManager transferManager = new TransferManager();
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = sourceBlobDirectoryName });
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destinationFolder);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);

            List<string> localItemsAfterDownload = Directory.GetFiles(destinationFolder, "*", SearchOption.AllDirectories).ToList();

            // Assert
            Assert.IsEmpty(localItemsAfterDownload);
            testEventRaised.AssertUnexpectedFailureCheck();
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_SingleFile()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            string sourceBlobDirectoryName = GetNewBlobDirectoryName();
            await DownloadBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                new List<(string, int)> { ($"{sourceBlobDirectoryName}/{GetNewObjectName()}", Constants.KB) })
                .ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_ManySubDirectories()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string tempFolder = CreateRandomDirectory(testDirectory.DirectoryPath);
            string blobDirectoryName = "foo";
            string fullSourceFolderPath = CreateRandomDirectory(tempFolder, blobDirectoryName);
            List<string> blobNames = new()
            {
                Path.Combine(fullSourceFolderPath, "bar", GetNewObjectName()),
                Path.Combine(fullSourceFolderPath, "rul", GetNewObjectName()),
                Path.Combine(fullSourceFolderPath, "pik", GetNewObjectName()),
            };

            await DownloadBlobDirectoryAndVerify(
                sourceContainer: test.Container,
                sourcePrefix: blobDirectoryName,
                blobNames.Select(name => (name, Constants.KB)).ToList()).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DownloadDirectoryAsync_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            string sourcePrefix = "foo";

            List<string> blobNames = new List<string>();

            string prefix = sourcePrefix;
            for (int i = 0; i < level; i++)
            {
                prefix = Path.Combine(prefix, $"folder{i}");
                blobNames.Add(Path.Combine(prefix, GetNewObjectName()));
            }

            string destinationFolder = CreateRandomDirectory(Path.GetTempPath());

            await DownloadBlobDirectoryAndVerify(
                test.Container,
                sourcePrefix,
                blobNames.Select(name => (name, Constants.KB)).ToList()).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_SmallChunks_ManyFiles()
        {
            // Arrange
            int blobSize = 2 * Constants.KB;
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string tempFolder = CreateRandomDirectory(testDirectory.DirectoryPath);
            string blobDirectoryName = "foo";

            List<string> blobNames = new List<string>();

            foreach (var _ in Enumerable.Range(0, 5))
            {
                blobNames.Add(Path.Combine(blobDirectoryName, GetNewObjectName()));
            }
            foreach (var _ in Enumerable.Range(0, 3))
            {
                blobNames.Add(Path.Combine(blobDirectoryName, "bar", GetNewObjectName()));
            }
            foreach (var _ in Enumerable.Range(0, 2))
            {
                blobNames.Add(Path.Combine(blobDirectoryName, "rul", GetNewObjectName()));
            }

            TransferManagerOptions transferManagerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.StopOnAnyFailure,
                MaximumConcurrency = 3
            };
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };

            // Act / Assert
            await DownloadBlobDirectoryAndVerify(
                sourceContainer: test.Container,
                sourcePrefix: blobDirectoryName,
                blobNames.Select(name => (name, blobSize)).ToList(),
                transferManagerOptions: transferManagerOptions,
                options: options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DownloadDirectoryAsync_Root()
        {
            // Arrange
            string[] files = { "file1", "dir1/file1", "dir1/file2", "dir1/file3", "dir2/file1" };
            BinaryData data = BinaryData.FromString("Hello World");

            await using DisposingContainer source = await GetTestContainerAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            foreach (string file in files)
            {
                await source.Container.UploadBlobAsync(file, data);
            }

            TransferManager transferManager = new TransferManager();

            StorageResourceContainer sourceResource =
                new BlobStorageResourceContainer(source.Container);
            StorageResourceContainer destinationResource =
                new LocalDirectoryStorageResourceContainer(destination.DirectoryPath);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            IEnumerable<string> destinationFiles = FileUtil.ListFileNamesRecursive(destination.DirectoryPath)
                .Select(f => f.Substring(destination.DirectoryPath.Length + 1).Replace("\\", "/"));

            Assert.IsTrue(destinationFiles.OrderBy(f => f).SequenceEqual(files.OrderBy(f => f)));
        }
        #endregion DirectoryDownloadTests

        #region Single Concurrency
        private async Task CreateBlobDirectoryTree(
            TContainerClient client,
            string sourceFolderPath,
            string sourceBlobDirectoryName,
            int size)
        {
            string blobName1 = Path.Combine(sourceBlobDirectoryName, "blob1");
            string blobName2 = Path.Combine(sourceBlobDirectoryName, "blob2");
            await CreateBlockBlob(client, Path.GetTempFileName(), blobName1, size);
            await CreateBlockBlob(client, Path.GetTempFileName(), blobName2, size);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, "blob3");
            await CreateBlockBlob(client, Path.GetTempFileName(), blobName3, size);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, "blob4");
            await CreateBlockBlob(client, Path.GetTempFileName(), blobName4, size);
        }

        private async Task<DataTransfer> CreateStartTransfer(
            TContainerClient containerClient,
            string destinationFolder,
            int concurrency,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            string sourceBlobPrefix = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(Path.GetTempPath(), sourceBlobPrefix);
            await CreateBlobDirectoryTree(containerClient, sourceFolderPath, sourceBlobPrefix, size);

            // Create storage resources
            StorageResourceContainer sourceResource = new(containerClient, new() { BlobDirectoryPrefix = sourceBlobPrefix });
            StorageResourceContainer destinationResource = new LocalDirectoryStorageResourceContainer(destinationFolder);

            // Create Transfer Manager with single threaded operation
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = concurrency,
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // Start transfer and await for completion.
            return await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Create transfer to do a AwaitCompletion
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            await testEventsRaised.AssertContainerCompletedCheck(4);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Close();

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Dispose();

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Create transfer to do a EnsureCompleted
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            DataTransfer transfer = await CreateStartTransfer(
                    test.Container,
                    destinationFolder,
                    1,
                    options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            await testEventsRaised.AssertContainerCompletedCheck(4);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Close();

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Close();

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(1);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed_SmallChunks()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create at least one of the dest files to make it fail
            File.Create(Path.Combine(destinationFolder, "blob1")).Close();

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                destinationFolder,
                1,
                options: options,
                size: Constants.KB * 4);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("Cannot overwrite file."));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }
        #endregion
    }
}
