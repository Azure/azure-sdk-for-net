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

namespace Azure.Storage.DataMovement.Tests
{
    public abstract class StartTransferDirectoryCopyTestBase
            <TSourceServiceClient,
            TSourceContainerClient,
            TSourceClientOptions,
            TDestinationServiceClient,
            TDestinationContainerClient,
            TDestinationClientOptions,
            TEnvironment> : StorageTestBase<TEnvironment>
        where TSourceServiceClient : class
        where TSourceContainerClient : class
        where TSourceClientOptions : ClientOptions
        where TDestinationServiceClient : class
        where TDestinationContainerClient : class
        where TDestinationClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        private readonly string _generatedResourceNamePrefix;
        private readonly string _expectedOverwriteExceptionMessage;

        public ClientBuilder<TSourceServiceClient, TSourceClientOptions> SourceClientBuilder { get; protected set; }
        public ClientBuilder<TDestinationServiceClient, TDestinationClientOptions> DestinationClientBuilder { get; protected set; }

        /// <summary>
        /// Constructor for TransferManager.StartTransferAsync tests
        ///
        /// The async is defaulted to true, since we do not have sync StartTransfer methods.
        /// </summary>
        /// <param name="generatedResourcenamePrefix"></param>
        /// <param name="mode"></param>
        public StartTransferDirectoryCopyTestBase(
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
        protected abstract Task<IDisposingContainer<TSourceContainerClient>> GetSourceDisposingContainerAsync(
            TSourceServiceClient service = default,
            string containerName = default);

        /// <summary>
        /// Gets the specific storage resource from the given TDestinationObjectClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="containerClient">The object client to create the storage resource object.</param>
        /// <param name="prefix">The prefix for a Storage Resource Container. If not specified, will default to root directory.</param>
        /// <returns></returns>
        protected abstract StorageResourceContainer GetSourceStorageResourceContainer(TSourceContainerClient containerClient, string prefix = default);

        /// <summary>
        /// Creates the object in the source storage resource container.
        /// </summary>
        /// <param name="containerClient">The container client to create the storage resource object.</param>
        /// <param name="objectName">The name of the object to create.</param>
        /// <param name="size">Optional. The size of the object.</param>
        /// <returns></returns>
        protected abstract Task CreateObjectInSource(TSourceContainerClient containerClient, string objectName = default, long? size = default);

        /// <summary>
        /// Creates the object in the source storage resource container.
        /// </summary>
        /// <param name="containerClient">The container client to create the storage resource object.</param>
        /// <param name="objectName">The name of the object to create.</param>
        /// <param name="content">Optional. The contents to set in the object resource.</param>
        /// <returns></returns>
        protected abstract Task CreateObjectInSource(TSourceContainerClient containerClient, string objectName = default, Stream content = default);

        /// <summary>
        /// Gets a service-specific disposing container for use with tests in this class.
        /// </summary>
        /// <param name="service">Optionally specified service client to get container from.</param>
        /// <param name="containerName">Optional container name specification.</param>
        protected abstract Task<IDisposingContainer<TDestinationContainerClient>> GetDestinationDisposingContainerAsync(
            TDestinationServiceClient service = default,
            string containerName = default);

        /// <summary>
        /// Gets the specific storage resource from the given TDestinationObjectClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="containerClient">The object client to create the storage resource object.</param>
        /// <param name="prefix">The prefix for a Storage Resource Container.</param>
        /// <returns></returns>
        protected abstract StorageResourceContainer GetDestinationStorageResourceContainer(TDestinationContainerClient containerClient, string prefix);

        /// <summary>
        /// Verifies the results between the source and the destination container.
        /// </summary>
        /// <param name="sourceClient">The source client to check the contents and compare against the destination.</param>
        /// <param name="destinationContainer">The destinatiojn client to check the contents and compare against the source.</param>
        /// <param name="sourcePrefix">Optional. The prefix to start listing at the source container.</param>
        /// <param name="destinationPrefix">Optional. The prefix to start listing at the destination container.</param>
        /// <returns></returns>
        protected abstract Task VerifyResults(
            TSourceContainerClient sourceClient,
            TDestinationContainerClient destinationContainer,
            string sourcePrefix = default,
            string destinationPrefix = default);
        #endregion

        protected string GetNewObjectName()
            => _generatedResourceNamePrefix + SourceClientBuilder.Recording.Random.NewGuid();

        /// <summary>
        /// Upload and verify the contents of the blob
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="sourceContainer">The source container which will contains the source blobs</param>
        /// <param name="sourceBlobPrefix">The source blob prefix/folder</param>
        /// <param name="destinationBlobPrefix">The destination local path to download the blobs to</param>
        /// <param name="waitTimeInSec">
        /// How long we should wait until we cancel the operation. If this timeout is reached the test will fail.
        /// </param>
        /// <param name="transferManagerOptions">Options for the transfer manager</param>
        /// <param name="options">Options for the transfer Options</param>
        /// <returns></returns>
        private async Task CopyBlobDirectoryAndVerify(
            TSourceContainerClient sourceContainer,
            TDestinationContainerClient destinationContainer,
            string sourceBlobPrefix,
            string destinationBlobPrefix,
            int waitTimeInSec = 30,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default)
        {
            // Set transfer options
            options ??= new DataTransferOptions();
            TestEventsRaised testEventFailed = new TestEventsRaised(options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            // Initialize transferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            StorageResourceContainer sourceResource =
                GetSourceStorageResourceContainer(sourceContainer, sourceBlobPrefix);
            StorageResourceContainer destinationResource =
                GetDestinationStorageResourceContainer(destinationContainer, destinationBlobPrefix);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
            await transfer.WaitForCompletionAsync(tokenSource.Token);

            await testEventFailed.AssertContainerCompletedCheck(sourceFiles.Count);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);

            // List all files in source blob folder path
            List<string> sourceblobNames = new List<string>();
            await foreach (Page<BlobItem> page in sourceContainer.GetBlobsAsync(prefix: sourceBlobPrefix).AsPages())
            {
                sourceblobNames.AddRange(page.Values.Select((BlobItem item) => item.Name));
            }

            // List all files in the destination blob folder path
            List<string> destblobNames = new List<string>();
            await foreach (Page<BlobItem> page in sourceContainer.GetBlobsAsync(prefix: destinationBlobPrefix).AsPages())
            {
                destblobNames.AddRange(page.Values.Select((BlobItem item) => item.Name));
            }
            Assert.AreEqual(sourceblobNames.Count, destblobNames.Count);
            sourceblobNames.Sort();
            destblobNames.Sort();
            for (int i = 0; i < sourceFiles.Count; i++)
            {
                // Verify file name to match the
                // (prefix folder path) + (the blob name without the blob folder prefix)
                string sourceNonPrefixed = sourceblobNames[i].Substring(sourceBlobPrefix.Length + 1);
                Assert.AreEqual(
                    sourceNonPrefixed,
                    destblobNames[i].Substring(destinationBlobPrefix.Length + 1));

                // Verify Download
                string sourceFileName = Path.Combine(sourceFilePrefix, sourceNonPrefixed);
                using (FileStream fileStream = File.OpenRead(sourceFileName))
                {
                    BlockBlobClient destinationBlob = sourceContainer.GetBlockBlobClient(destblobNames[i]);
                    Assert.IsTrue(await destinationBlob.ExistsAsync());
                    await DownloadAndAssertAsync(fileStream, destinationBlob);
                }
            }
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        public async Task BlockBlobDirectoryToDirectory_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            string sourceBlobDirectoryName = "sourceFolder";
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            await CreateObjectInSource(source.Container, blobName1, size);
            await CreateObjectInSource(source.Container, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewObjectName());
            await CreateObjectInSource(source.Container, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewObjectName());
            await CreateObjectInSource(source.Container, blobName4, size);
            blobNames.Add(blobName4);

            await CopyBlobDirectoryAndVerify(
                source.Container,
                destination.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(4 * Constants.MB, 200)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(Constants.GB, 500)]
        public async Task BlockBlobDirectoryToDirectory_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            string sourceBlobDirectoryName = "sourceFolder";

            List<string> blobNames = new List<string>();

            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            await CreateObjectInSource(source.Container, blobName1, size);
            await CreateObjectInSource(source.Container, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewObjectName());
            await CreateObjectInSource(source.Container, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewObjectName());
            await CreateObjectInSource(source.Container, blobName4, size);
            blobNames.Add(blobName4);

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                source.Container,
                destination.Container,
                sourceBlobDirectoryName,
                destinationFolder,
                waitTimeInSec).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_EmptyFolder()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Set up directory to upload
            var dirName = GetNewObjectName();
            var dirName2 = GetNewObjectName();
            string folder = CreateRandomDirectory(testDirectory.DirectoryPath);

            // Set up destination client
            StorageResourceContainer destinationResource = GetDestinationStorageResourceContainer(test.Container, new() { BlobDirectoryPrefix = dirName });
            StorageResourceContainer sourceResource = GetSourceStorageResourceContainer(test.Container,
                new BlobStorageResourceContainerOptions()
                {
                    BlobDirectoryPrefix = dirName2,
                });

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = 1,
            };
            TransferManager transferManager = new TransferManager(managerOptions);
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Act
            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(tokenSource.Token);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);

            // Assert
            List<string> blobs = ((List<BlobItem>)await test.Container.GetBlobsAsync().ToListAsync())
                .Select((BlobItem blob) => blob.Name).ToList();
            // Assert
            Assert.IsEmpty(blobs);
            testEventsRaised.AssertUnexpectedFailureCheck();
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_SingleFile()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            string sourceFolderName = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceFolderName);

            string blobName1 = Path.Combine(sourceFolderName, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, Constants.KB);
            List<string> blobNames = new List<string>() { blobName1 };

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                container: test.Container,
                sourceBlobPrefix: sourceFolderName,
                sourceFilePrefix: sourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_ManySubDirectories()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            string blobDirectoryName = "sourceFolder";
            string fullSourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, blobDirectoryName);

            List<string> blobNames = new List<string>();
            string subDir1 = CreateRandomDirectory(fullSourceFolderPath, "bar").Substring(fullSourceFolderPath.Length + 1);
            string blobName1 = Path.Combine(blobDirectoryName, subDir1, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, Constants.KB);
            blobNames.Add(blobName1);
            string subDir2 = CreateRandomDirectory(fullSourceFolderPath, "rul").Substring(fullSourceFolderPath.Length + 1);
            string blobName2 = Path.Combine(blobDirectoryName, subDir2, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName2, Constants.KB);
            blobNames.Add(blobName2);
            string subDir3 = CreateRandomDirectory(fullSourceFolderPath, "pik").Substring(fullSourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(blobDirectoryName, subDir3, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName3, Constants.KB);
            blobNames.Add(blobName3);

            string destinationFolder = "destFolder";

            string sourceBlobPrefix = fullSourceFolderPath.Substring(testDirectory.DirectoryPath.Length + 1);

            await CopyBlobDirectoryAndVerify(
                container: test.Container,
                sourceBlobPrefix: sourceBlobPrefix,
                sourceFilePrefix: fullSourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task BlockBlobDirectoryToDirectory_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            string sourceBlobDirectoryName = "sourceFolder";
            string fullSourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string subDir = default;
            for (int i = 0; i < level; i++)
            {
                subDir = CreateRandomDirectory(fullSourceFolderPath, $"folder{i}");
                string blobName = Path.Combine(sourceBlobDirectoryName, subDir.Substring(fullSourceFolderPath.Length + 1), GetNewObjectName());
                await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName, Constants.KB);
                blobNames.Add(blobName);
            }

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                fullSourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_OverwriteTrue()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            long size = Constants.KB;
            string sourceBlobDirectoryName = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();
            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, size);
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName4, size);
            blobNames.Add(blobName4);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };

            string destinationFolder = "destFolder";

            // Act
            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames,
                options: options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_OverwriteFalse()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            long size = Constants.KB;
            string sourceBlobDirectoryName = "sourceFolder";
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();
            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName1, size);
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(test.Container, testDirectory.DirectoryPath, blobName4, size);
            blobNames.Add(blobName4);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };

            string destinationFolder = "destFolder";

            // Act
            await CopyBlobDirectoryAndVerify(
                test.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                destinationBlobPrefix: destinationFolder,
                blobNames,
                options: options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task BlockBlobDirectoryToDirectory_OAuth()
        {
            // Arrange
            long size = Constants.KB;
            int waitTimeInSec = 10;
            TSourceServiceClient service = BlobsClientBuilder.GetServiceClient_OAuth();
            var containerName = GetNewContainerName();
            await using IDisposingContainer<TContainerClient> testContainer = await GetTestContainerAsync(
                service,
                containerName,
                publicAccessType: PublicAccessType.BlobContainer);
            string sourceBlobDirectoryName = "sourceFolder";
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobDirectoryName);

            List<string> blobNames = new List<string>();

            string blobName1 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            string blobName2 = Path.Combine(sourceBlobDirectoryName, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(testContainer.Container, testDirectory.DirectoryPath, blobName1, size);
            await CreateBlockBlobAndSourceFile(testContainer.Container, testDirectory.DirectoryPath, blobName2, size);
            blobNames.Add(blobName1);
            blobNames.Add(blobName2);

            string subDirName = "bar";
            CreateRandomDirectory(sourceFolderPath, subDirName).Substring(sourceFolderPath.Length + 1);
            string blobName3 = Path.Combine(sourceBlobDirectoryName, subDirName, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(testContainer.Container, testDirectory.DirectoryPath, blobName3, size);
            blobNames.Add(blobName3);

            string subDirName2 = "pik";
            CreateRandomDirectory(sourceFolderPath, subDirName2).Substring(sourceFolderPath.Length + 1);
            string blobName4 = Path.Combine(sourceBlobDirectoryName, subDirName2, GetNewObjectName());
            await CreateBlockBlobAndSourceFile(testContainer.Container, testDirectory.DirectoryPath, blobName4, size);
            blobNames.Add(blobName4);

            string destinationFolder = "destFolder";

            await CopyBlobDirectoryAndVerify(
                testContainer.Container,
                sourceBlobDirectoryName,
                sourceFolderPath,
                destinationFolder,
                blobNames,
                waitTimeInSec).ConfigureAwait(false);
        }

        #region Single Concurrency
        private async Task CreateBlobDirectoryTree(
            TSourceContainerClient client,
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
            TSourceContainerClient containerClient,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Arrange
            // Create source local file for checking, and source blob
            string sourceBlobPrefix = "sourceFolder";
            string destBlobPrefix = "destFolder";
            string sourceFolderPath = CreateRandomDirectory(testDirectory.DirectoryPath, sourceBlobPrefix);
            await CreateBlobDirectoryTree(containerClient, sourceFolderPath, sourceBlobPrefix, size);

            // Create new source block blob.
            StorageResourceContainer sourceResource = new BlobStorageResourceContainer(containerClient, new() { BlobDirectoryPrefix = sourceBlobPrefix });
            StorageResourceContainer destinationResource = new BlobStorageResourceContainer(containerClient,
                new BlobStorageResourceContainerOptions()
                {
                    BlobDirectoryPrefix = destBlobPrefix,
                });

            // If we want a failure condition to happen
            if (createFailedCondition)
            {
                string destBlobName = $"{destBlobPrefix}/blob1";
                await CreateBlockBlob(containerClient, Path.Combine(testDirectory.DirectoryPath, "blob1"), destBlobName, size);
            }

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
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer to do a AwaitCompletion
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
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
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer to do a EnsureCompleted
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            DataTransfer transfer = await CreateStartTransfer(test.Container, 1, options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetTestContainerAsync(publicAccessType: PublicAccessType.BlobContainer);

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            testEventsRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Failed_SmallChunks()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string destinationFolder = CreateRandomDirectory(testDirectory.DirectoryPath);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                test.Container,
                1,
                createFailedCondition: true,
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
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains("BlobAlreadyExists"));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }
        #endregion
    }
}
