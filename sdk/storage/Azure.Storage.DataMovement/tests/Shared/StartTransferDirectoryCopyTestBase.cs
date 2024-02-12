// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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
        private readonly string _firstItemName;

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
            _firstItemName = "item1";
        }

        #region Service-Specific Methods
        /// <summary>
        /// Gets the service client using OAuth to authenticate.
        /// </summary>
        protected abstract TSourceContainerClient GetOAuthSourceContainerClient(string containerName);

        /// <summary>
        /// Gets a service-specific disposing container for use with tests in this class.
        /// </summary>
        /// <param name="service">Optionally specified service client to get container from.</param>
        /// <param name="containerName">Optional container name specification.</param>
        protected abstract Task<IDisposingContainer<TSourceContainerClient>> GetSourceDisposingContainerAsync(
            TSourceServiceClient service = default,
            string containerName = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the specific storage resource from the given TDestinationObjectClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="containerClient">The object client to create the storage resource object.</param>
        /// <param name="directoryPath">The path of the directory.</param>
        /// <returns></returns>
        protected abstract StorageResourceContainer GetSourceStorageResourceContainer(TSourceContainerClient containerClient, string directoryPath);

        /// <summary>
        /// Creates the directory within the source container.
        /// </summary>
        /// <param name="sourceContainer">
        /// The respective source container to create the directory in.
        /// </param>
        /// <param name="directoryPath">
        /// The directory path.
        /// </param>
        protected abstract Task CreateDirectoryInSourceAsync(
            TSourceContainerClient sourceContainer,
            string directoryPath,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the object in the source storage resource container.
        /// </summary>
        /// <param name="objectLength">The length to create the object of.</param>
        /// <param name="objectName">The name of the object to create.</param>
        /// <param name="contents">The contents to set in the object.</param>
        /// <returns></returns>
        protected abstract Task CreateObjectInSourceAsync(
            TSourceContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a service-specific disposing container for use with tests in this class.
        /// </summary>
        /// <param name="service">Optionally specified service client to get container from.</param>
        /// <param name="containerName">Optional container name specification.</param>
        protected abstract Task<IDisposingContainer<TDestinationContainerClient>> GetDestinationDisposingContainerAsync(
            TDestinationServiceClient service = default,
            string containerName = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the service client using OAuth to authenticate.
        /// </summary>
        protected abstract TDestinationContainerClient GetOAuthDestinationContainerClient(string containerName);

        /// <summary>
        /// Gets the specific storage resource from the given TDestinationObjectClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="containerClient">The container client to get the respective storage resource.</param>
        /// <param name="directoryPath">The respective directory path of the storage resource container.</param>
        /// <returns></returns>
        protected abstract StorageResourceContainer GetDestinationStorageResourceContainer(TDestinationContainerClient containerClient, string directoryPath);

        /// <summary>
        /// Creates the directory within the source container. Will also create any parent directories if required and is a hierarchical structure.
        /// </summary>
        /// <param name="sourceContainer">
        /// The respective source container to create the directory in.
        /// </param>
        /// <param name="directoryPath">
        /// The directory path. If parent paths are required, will also create any parent directories if required and is a hierarchical structure.
        /// </param>
        protected abstract Task CreateDirectoryInDestinationAsync(
            TDestinationContainerClient destinationContainer,
            string directoryPath,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates the object in the source storage resource container.
        /// </summary>
        /// <param name="objectLength">The length to create the object of.</param>
        /// <param name="objectName">The name of the object to create.</param>
        /// <param name="contents">The contents to set in the object.</param>
        /// <returns></returns>
        protected abstract Task CreateObjectInDestinationAsync(
            TDestinationContainerClient container,
            long? objectLength = null,
            string objectName = null,
            Stream contents = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Verifies that the destination container is empty when we expect it to be.
        /// </summary>
        /// <param name="destinationContainer">
        /// The respective destination container to verify empty contents.
        /// </param>
        /// <returns></returns>
        protected abstract Task VerifyEmptyDestinationContainerAsync(
            TDestinationContainerClient destinationContainer,
            string destinationPrefix,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Verifies the results between the source and the destination container.
        /// </summary>
        /// <param name="sourceContainer">The source client to check the contents and compare against the destination.</param>
        /// <param name="destinationContainer">The destination client to check the contents and compare against the source.</param>
        /// <param name="sourcePrefix">Optional. The prefix to start listing at the source container.</param>
        /// <param name="destinationPrefix">Optional. The prefix to start listing at the destination container.</param>
        /// <returns></returns>
        protected abstract Task VerifyResultsAsync(
            TSourceContainerClient sourceContainer,
            string sourcePrefix,
            TDestinationContainerClient destinationContainer,
            string destinationPrefix,
            CancellationToken cancellationToken = default);
        #endregion

        protected string GetNewObjectName()
            => _generatedResourceNamePrefix + SourceClientBuilder.Recording.Random.NewGuid();

        /// <summary>
        /// Upload and verify the contents of the items
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="sourceContainer">The source container which will contains the source items</param>
        /// <param name="sourcePrefix">The source prefix/folder</param>
        /// <param name="destinationPrefix">The destination local path to download the items to</param>
        /// <param name="waitTimeInSec">
        /// How long we should wait until we cancel the operation. If this timeout is reached the test will fail.
        /// </param>
        /// <param name="transferManagerOptions">Options for the transfer manager</param>
        /// <param name="options">Options for the transfer Options</param>
        /// <returns></returns>
        private async Task CopyDirectoryAndVerifyAsync(
            TSourceContainerClient sourceContainer,
            TDestinationContainerClient destinationContainer,
            string sourcePrefix,
            string destinationPrefix,
            int itemTransferCount,
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
                GetSourceStorageResourceContainer(sourceContainer, sourcePrefix);
            StorageResourceContainer destinationResource =
                GetDestinationStorageResourceContainer(destinationContainer, destinationPrefix);

            DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options);

            // Assert
            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventFailed,
                tokenSource.Token);

            await testEventFailed.AssertContainerCompletedCheck(itemTransferCount);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);

            // List all files in source folder path
            await VerifyResultsAsync(
                sourceContainer: sourceContainer,
                sourcePrefix: sourcePrefix,
                destinationContainer: destinationContainer,
                destinationPrefix: destinationPrefix);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(0, 10)]
        [TestCase(Constants.KB / 2, 10)]
        [TestCase(Constants.KB, 10)]
        public async Task DirectoryToDirectory_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            string sourcePrefix = "sourceFolder";
            string destinationPrefix = "destinationFolder";

            await CreateDirectoryInSourceAsync(source.Container, sourcePrefix);
            string itemName1 = string.Join("/", sourcePrefix, GetNewObjectName());
            string itemName2 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName1);
            await CreateObjectInSourceAsync(source.Container, size, itemName2);

            string subDirName = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryInSourceAsync(source.Container, subDirName);
            string itemName3 = string.Join("/", subDirName, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName3);

            string subDirName2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryInSourceAsync(source.Container, subDirName2);
            string itemName4 = string.Join("/", subDirName2, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName4);

            await CreateDirectoryInDestinationAsync(destination.Container, destinationPrefix);

            await CopyDirectoryAndVerifyAsync(
                source.Container,
                destination.Container,
                sourcePrefix,
                destinationPrefix,
                4,
                waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * Constants.MB, 20)]
        [TestCase(4 * Constants.MB, 200)]
        [TestCase(257 * Constants.MB, 500)]
        [TestCase(Constants.GB, 500)]
        public async Task DirectoryToDirectory_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            string sourcePrefix = "sourceFolder";

            await CreateDirectoryInSourceAsync(source.Container, sourcePrefix);
            string itemName1 = string.Join("/", sourcePrefix, GetNewObjectName());
            string itemName2 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName1);
            await CreateObjectInSourceAsync(source.Container, size, itemName2);

            string subDirName = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryInSourceAsync(source.Container, subDirName);
            string itemName3 = string.Join("/", subDirName, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName3);

            string subDirName2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryInSourceAsync(source.Container, subDirName2);
            string itemName4 = string.Join("/", subDirName2, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName4);

            string destinationPrefix = "destFolder";
            await CreateDirectoryInDestinationAsync(destination.Container, destinationPrefix);

            await CopyDirectoryAndVerifyAsync(
                source.Container,
                destination.Container,
                sourcePrefix,
                destinationPrefix,
                waitTimeInSec).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryToDirectory_EmptyFolder()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            var sourcePath = GetNewObjectName();
            var destinationPath = GetNewObjectName();

            // Set up resources
            await CreateDirectoryInSourceAsync(source.Container, sourcePath);
            StorageResourceContainer sourceResource = GetSourceStorageResourceContainer(source.Container, sourcePath);
            await CreateDirectoryInDestinationAsync(destination.Container, destinationPath);
            StorageResourceContainer destinationResource = GetDestinationStorageResourceContainer(destination.Container, destinationPath);

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

            CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                tokenSource.Token);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);

            // Assert
            await VerifyEmptyDestinationContainerAsync(destination.Container, destinationPath);
            testEventsRaised.AssertUnexpectedFailureCheck();
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryToDirectory_SingleFile()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            string sourcePrefix = "sourceFolder";

            string itemName1 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateDirectoryInSourceAsync(source.Container, sourcePrefix);
            await CreateObjectInSourceAsync(source.Container, Constants.KB, itemName1);

            string destinationPrefix = "destFolder";

            await CreateDirectoryInDestinationAsync(destination.Container, destinationPrefix);
            await CopyDirectoryAndVerifyAsync(
                sourceContainer: source.Container,
                destinationContainer: destination.Container,
                sourcePrefix: sourcePrefix,
                destinationPrefix: destinationPrefix,
                itemTransferCount: 1).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryToDirectory_ManySubDirectories()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            string sourcePrefix = "sourceFolder";

            await CreateDirectoryInSourceAsync(source.Container, sourcePrefix);
            string subDir1 = string.Join("/", sourcePrefix, "foo");
            await CreateDirectoryInSourceAsync(source.Container, subDir1);
            string itemName1 = string.Join("/", subDir1, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, Constants.KB, itemName1);
            string subDir2 = string.Join("/", sourcePrefix, "rul");
            await CreateDirectoryInSourceAsync(source.Container, subDir2);
            string itemName2 = string.Join("/", subDir2, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, Constants.KB, itemName2);
            string subDir3 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryInSourceAsync(source.Container, subDir3);
            string itemName3 = string.Join("/", subDir3, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, Constants.KB, itemName3);

            string destinationPrefix = "destFolder";

            await CreateDirectoryInDestinationAsync(destination.Container, destinationPrefix);
            await CopyDirectoryAndVerifyAsync(
                sourceContainer: source.Container,
                destinationContainer: destination.Container,
                sourcePrefix: sourcePrefix,
                destinationPrefix: destinationPrefix,
                itemTransferCount: 3).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DirectoryToDirectory_SubDirectoriesLevels(int level)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            string sourcePrefix = "sourceFolder";

            await CreateDirectoryInSourceAsync(source.Container, sourcePrefix);

            string subDirPrefix = sourcePrefix;
            for (int i = 0; i < level; i++)
            {
                subDirPrefix = string.Join("/", subDirPrefix, $"folder{i}");
                await CreateDirectoryInSourceAsync(source.Container, subDirPrefix);
                string fullFilePath = string.Join("/", subDirPrefix, GetNewObjectName());
                await CreateObjectInSourceAsync(source.Container, Constants.KB, fullFilePath);
            }

            string destinationPrefix = "destFolder";
            await CreateDirectoryInDestinationAsync(destination.Container, destinationPrefix);

            await CopyDirectoryAndVerifyAsync(
                source.Container,
                destination.Container,
                sourcePrefix,
                destinationPrefix,
                itemTransferCount: level).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryToDirectory_OverwriteExists()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            long size = Constants.KB;
            string sourcePrefix = "sourceFolder";
            string destinationPrefix = "destPrefix";

            await CreateDirectoryInSourceAsync(source.Container, sourcePrefix);
            await CreateDirectoryInDestinationAsync(destination.Container, destinationPrefix);

            string itemName1 = string.Join("/", sourcePrefix, _firstItemName);
            await CreateObjectInSourceAsync(source.Container, size, itemName1);

            // Create same object in the destination, so when both files are seen overwrite will trigger.
            string destItemName1 = string.Join("/", destinationPrefix, _firstItemName);
            await CreateObjectInDestinationAsync(destination.Container, size, destItemName1);

            string itemName2 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName2);

            string subDirName = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryInSourceAsync(source.Container, subDirName);
            string itemName3 = string.Join("/", subDirName, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName3);

            string subDirName2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryInSourceAsync(source.Container, subDirName2);
            string itemName4 = string.Join("/", subDirName2, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName4);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };

            // Act
            await CopyDirectoryAndVerifyAsync(
                source.Container,
                destination.Container,
                sourcePrefix,
                destinationPrefix,
                itemTransferCount: 4,
                options: options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task DirectoryToDirectory_OverwriteNotExists()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            long size = Constants.KB;
            string sourcePrefix = "sourceFolder";
            string destinationPrefix = "destPrefix";

            await CreateDirectoryInSourceAsync(source.Container, sourcePrefix);
            await CreateDirectoryInDestinationAsync(destination.Container, destinationPrefix);

            string itemName1 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName1);

            string itemName2 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName2);

            string subDirName = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryInSourceAsync(source.Container, subDirName);
            string itemName3 = string.Join("/", subDirName, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName3);

            string subDirName2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryInSourceAsync(source.Container, subDirName2);
            string itemName4 = string.Join("/", subDirName2, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName4);

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };

            // Act
            await CopyDirectoryAndVerifyAsync(
                source.Container,
                destination.Container,
                sourcePrefix,
                destinationPrefix,
                itemTransferCount: 4,
                options: options).ConfigureAwait(false);
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public virtual async Task DirectoryToDirectory_OAuth()
        {
            // Arrange
            long size = Constants.KB;
            int waitTimeInSec = 20;
            string sourceContainerName = GetNewObjectName();
            string destContainerName = GetNewObjectName();
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync(containerName: sourceContainerName);
            TSourceContainerClient oauthSourceContainer = GetOAuthSourceContainerClient(containerName: sourceContainerName);

            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync(containerName: destContainerName);
            TDestinationContainerClient oauthDestinationContainer = GetOAuthDestinationContainerClient(containerName: destContainerName);

            string sourcePrefix = "sourceFolder";
            string destinationPrefix = "destFolder";

            await CreateDirectoryInSourceAsync(oauthSourceContainer, sourcePrefix);
            await CreateDirectoryInDestinationAsync(oauthDestinationContainer, destinationPrefix);

            string itemName1 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName1);

            string itemName2 = string.Join("/", sourcePrefix, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName2);

            string subDirName = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryInSourceAsync(source.Container, subDirName);
            string itemName3 = string.Join("/", subDirName, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName3);

            string subDirName2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryInSourceAsync(source.Container, subDirName2);
            string itemName4 = string.Join("/", subDirName2, GetNewObjectName());
            await CreateObjectInSourceAsync(source.Container, size, itemName4);

            await CopyDirectoryAndVerifyAsync(
                oauthSourceContainer,
                oauthDestinationContainer,
                sourcePrefix,
                destinationPrefix,
                4,
                waitTimeInSec).ConfigureAwait(false);
        }

        #region Single Concurrency
        private async Task CreateDirectoryTree(
            TSourceContainerClient client,
            string sourcePrefix,
            int size)
        {
            string itemName1 = string.Join("/", sourcePrefix, _firstItemName);
            string itemName2 = string.Join("/", sourcePrefix, "item2");
            await CreateObjectInSourceAsync(client, size, itemName1);
            await CreateObjectInSourceAsync(client, size, itemName2);

            string subDirPath = string.Join("/", sourcePrefix, "bar");
            await CreateDirectoryInSourceAsync(client, subDirPath);
            string itemName3 = string.Join("/", subDirPath, "item3");
            await CreateObjectInSourceAsync(client, size, itemName3);

            string subDirPath2 = string.Join("/", sourcePrefix, "pik");
            await CreateDirectoryInSourceAsync(client, subDirPath2);
            string itemName4 = string.Join("/", subDirPath2, "item4");
            await CreateObjectInSourceAsync(client, size, itemName4);
        }

        private async Task<DataTransfer> CreateStartTransfer(
            TSourceContainerClient sourceContainer,
            TDestinationContainerClient destinationContainer,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            string sourcePrefix = "sourceFolder";
            string destPrefix = "destFolder";
            await CreateDirectoryInSourceAsync(sourceContainer, sourcePrefix);
            await CreateDirectoryInDestinationAsync(destinationContainer, destPrefix);
            await CreateDirectoryTree(sourceContainer, sourcePrefix, size);

            // Create storage resource containers
            StorageResourceContainer sourceResource = GetSourceStorageResourceContainer(sourceContainer, sourcePrefix);
            StorageResourceContainer destinationResource = GetDestinationStorageResourceContainer(destinationContainer, destPrefix);

            if (createFailedCondition)
            {
                // To create an expected failure, create an item that is supposed to be transferred over.
                // If we don't enable overwrite, a failure should be thrown.
                string fullDestPath = string.Join("/", destPrefix, _firstItemName);
                await CreateObjectInDestinationAsync(destinationContainer, size, fullDestPath);
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
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            // Create transfer to do a AwaitCompletion
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

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
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains(_expectedOverwriteExceptionMessage));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

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
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            // Create transfer to do a EnsureCompleted
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            DataTransfer transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

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
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains(_expectedOverwriteExceptionMessage));
        }

        [Test]
        [LiveOnly] // https://github.com/Azure/azure-sdk-for-net/issues/33082
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

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

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                1,
                createFailedCondition: true,
                options: options,
                size: Constants.KB * 4);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            TestTransferWithTimeout.WaitForCompletion(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains(_expectedOverwriteExceptionMessage));
            await testEventsRaised.AssertContainerCompletedWithFailedCheck(1);
        }
        #endregion
    }
}
