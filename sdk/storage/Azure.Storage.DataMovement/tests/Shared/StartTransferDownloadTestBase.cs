﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public abstract class StartTransferDownloadTestBase<
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
        public StartTransferDownloadTestBase(
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

        private async Task<DataTransfer> CreateStartTransfer(
            TContainerClient containerClient,
            string localDirectoryPath,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
        {
            // Arrange
            // Create source local file for checking, and source object
            string sourceObjectName = GetNewObjectName();
            string destFile;
            if (createFailedCondition)
            {
                destFile = await CreateRandomFileAsync(localDirectoryPath);
            }
            else
            {
                destFile = Path.Combine(localDirectoryPath, GetNewObjectName());
            }

            // Create new source object.
            TObjectClient TObjectClient = await GetObjectClientAsync(
                containerClient,
                objectName: sourceObjectName,
                objectLength: size,
                createResource: true);
            StorageResourceItem sourceResource = GetStorageResourceItem(TObjectClient);
            LocalFilesStorageResourceProvider files = new();
            StorageResource destinationResource = files.FromFile(destFile);

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

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer to do a AwaitCompletion
            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised failureTransferHolder = new TestEventsRaised(options);
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            failureTransferHolder.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventRaised.AssertSingleFailedCheck(1);
            Assert.AreEqual(1, testEventRaised.FailedEvents.Count);
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains(_expectedOverwriteExceptionMessage));
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
            await testEventRaised.AssertSingleSkippedCheck();
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer to do a EnsureCompleted
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            testEventRaised.AssertUnexpectedFailureCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Failed()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertSingleFailedCheck(1);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains(_expectedOverwriteExceptionMessage));
        }

        [RecordedTest]
        public async Task StartTransfer_EnsureCompleted_Skipped()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a EnsureCompleted
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: testDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            transfer.WaitForCompletion(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
        }

        internal class VerifyDownloadObjectContentInfo
        {
            public readonly TObjectClient SourceObjectClient;
            public readonly string DestinationLocalPath;
            public TestEventsRaised EventsRaised;
            public DataTransfer DataTransfer;
            public bool CompletedStatus;

            public VerifyDownloadObjectContentInfo(
                TObjectClient sourceClient,
                string destinationFile,
                TestEventsRaised eventsRaised,
                bool completed)
            {
                SourceObjectClient = sourceClient;
                DestinationLocalPath = destinationFile;
                EventsRaised = eventsRaised;
                CompletedStatus = completed;
                DataTransfer = default;
            }
        };

        #region SingleDownload Block Object
        /// <summary>
        /// Upload and verify the contents of the object
        ///
        /// By default in this function an event arguement will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="waitTimeInSec"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task DownloadObjectsAndVerify(
            TContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 30,
            int objectCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> objectNames = default,
            List<DataTransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Populate objectNames list for number of objects to be created
            if (objectNames == default || objectNames?.Count < 0)
            {
                objectNames ??= new List<string>();
                for (int i = 0; i < objectCount; i++)
                {
                    objectNames.Add(GetNewObjectName());
                }
            }
            else
            {
                // If objectNames is popluated make sure these number of objects match
                Assert.AreEqual(objectCount, objectNames.Count);
            }

            // Populate Options and TestRaisedOptions
            List<TestEventsRaised> eventRaisedList = TestEventsRaised.PopulateTestOptions(objectCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            List<VerifyDownloadObjectContentInfo> downloadedObjectInfo = new List<VerifyDownloadObjectContentInfo>(objectCount);

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);
            // Upload set of VerifyDownloadObjectContentInfo objects to download
            for (int i = 0; i < objectCount; i++)
            {
                // Set up object to be downloaded
                bool completed = false;
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                TObjectClient sourceClient = await GetObjectClientAsync(
                    container: container,
                    objectLength: size,
                    objectName: objectNames[i],
                    createResource: true,
                    contents: originalStream);

                string destFile = Path.Combine(testDirectory.DirectoryPath, objectNames[i]);

                downloadedObjectInfo.Add(new VerifyDownloadObjectContentInfo(
                    sourceClient,
                    destFile,
                    eventRaisedList[i],
                    completed));
            }

            // Schedule all download objects consecutively
            for (int i = 0; i < downloadedObjectInfo.Count; i++)
            {
                // Create a special object client for downloading that will
                // assign client request IDs based on the range so that out
                // of order operations still get predictable IDs and the
                // recordings work correctly
                StorageResourceItem sourceResource = GetStorageResourceItem(downloadedObjectInfo[i].SourceObjectClient);
                LocalFilesStorageResourceProvider files = new();
                StorageResource destinationResource = files.FromFile(downloadedObjectInfo[i].DestinationLocalPath);

                // Act
                DataTransfer transfer = await transferManager.StartTransferAsync(
                    sourceResource,
                    destinationResource,
                    options[i]).ConfigureAwait(false);

                downloadedObjectInfo[i].DataTransfer = transfer;
            }

            for (int i = 0; i < downloadedObjectInfo.Count; i++)
            {
                // Assert
                Assert.NotNull(downloadedObjectInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await downloadedObjectInfo[i].DataTransfer.WaitForCompletionAsync(tokenSource.Token);
                Assert.IsTrue(downloadedObjectInfo[i].DataTransfer.HasCompleted);

                // Verify Download
                await downloadedObjectInfo[i].EventsRaised.AssertSingleCompletedCheck();
                Assert.AreEqual(DataTransferState.Completed, downloadedObjectInfo[i].DataTransfer.TransferStatus.State);
                using Stream stream = await OpenReadAsync(downloadedObjectInfo[i].SourceObjectClient);
                using FileStream fileStream = File.OpenRead(downloadedObjectInfo[i].DestinationLocalPath);
                Assert.AreEqual(stream, fileStream);
            };
        }

        [RecordedTest]
        public async Task RemoteObjectToLocal()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            // No Option Download bag or manager options bag, plain download
            await DownloadObjectsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                objectCount: 1).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task RemoteObjectToLocal_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source object
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();
            string objectName = GetNewObjectName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            TObjectClient sourceClient = await GetObjectClientAsync(
                container: testContainer.Container,
                objectLength: size,
                objectName: objectName,
                createResource: true);

            // Create destination to overwrite
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions> { options };
            await DownloadObjectsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                objectCount: 1,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task RemoteObjectToLocal_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source object
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions> { options };
            await DownloadObjectsAndVerify(
                testContainer.Container,
                waitTimeInSec: 10,
                size: Constants.KB,
                objectCount: 1,
                options: optionsList).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33086")]
        [Test]
        [LiveOnly]
        public async Task RemoteObjectToLocal_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source object
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();
            string objectName = GetNewObjectName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            bool skippedSeen = false;
            TObjectClient sourceClient = await GetObjectClientAsync(
                container: testContainer.Container,
                objectLength: size,
                objectName: objectName,
                createResource: true);

            // Create destination file. So it can get skipped over.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            options.ItemTransferSkipped += (TransferItemSkippedEventArgs args) =>
            {
                if (args.SourceResource != null &&
                    args.DestinationResource != null &&
                    args.TransferId != null)
                {
                    skippedSeen = true;
                }
                return Task.CompletedTask;
            };
            TransferManager transferManager = new TransferManager();

            LocalFilesStorageResourceProvider files = new();
            StorageResource destinationResource = files.FromFile(destFile);

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                GetStorageResourceItem(sourceClient),
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(skippedSeen);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
        }

        [RecordedTest]
        public async Task RemoteObjectToLocal_Failure_Exists()
        {
            // Arrange
            // Create source local file for checking, and source file
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();
            string objectName = GetNewObjectName();
            string localSourceFile = Path.GetTempFileName();
            int size = Constants.KB;
            TObjectClient sourceClient = await GetObjectClientAsync(
                container: testContainer.Container,
                objectLength: size,
                objectName: objectName,
                createResource: true);

            // Make destination file name but do not create the file beforehand.
            string destFile = Path.GetTempFileName();

            // Act
            // Create options bag to fail and keep track of the failure.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            StorageResourceItem sourceResource = GetStorageResourceItem(sourceClient);
            LocalFilesStorageResourceProvider files = new();
            StorageResource destinationResource = files.FromFile(destFile);

            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                GetStorageResourceItem(sourceClient),
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            await testEventsRaised.AssertSingleFailedCheck(1);
            FileInfo destFileInfo = new FileInfo(destFile);
            Assert.IsTrue(destFileInfo.Length == 0);
            Assert.NotNull(testEventsRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.AreEqual(testEventsRaised.FailedEvents.First().Exception.Message, $"File path `{destFile}` already exists. Cannot overwrite file.");
        }

        [RecordedTest]
        public async Task RemoteObjectToLocal_SmallChunk()
        {
            long size = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
            await DownloadObjectsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(100, 10)]
        [TestCase(Constants.KB, 10)]
        [TestCase(4 * Constants.KB, 10)]
        public async Task RemoteObjectToLocal_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            await DownloadObjectsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(Constants.MB, 20)]
        [TestCase(257 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
        public async Task RemoteObjectToLocal_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            await DownloadObjectsAndVerify(
                testContainer.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, Constants.KB, 60)]
        [TestCase(6, Constants.KB, 60)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(6, 4 * Constants.KB, 60)]
        public async Task RemoteObjectToLocal_SmallMultiple(int count, long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            await DownloadObjectsAndVerify(
                testContainer.Container,
                objectCount: count,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 600)]
        [TestCase(2, Constants.GB, 2000)]
        public async Task RemoteObjectToLocal_LargeMultiple(int count, long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            await DownloadObjectsAndVerify(
                testContainer.Container,
                objectCount: count,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(2, 0, 30)]
        [TestCase(2, Constants.KB, 60)]
        [TestCase(6, Constants.KB, 60)]
        [TestCase(6, 4 * Constants.KB, 60)]
        public async Task RemoteObjectToLocal_SmallConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };

            await DownloadObjectsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions,
                options: optionsList).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, Constants.MB, 300)]
        [TestCase(6, Constants.MB, 300)]
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        public async Task RemoteObjectToLocal_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            // Arrange
            await using IDisposingContainer<TContainerClient> testContainer = await GetDisposingContainerAsync();

            await DownloadObjectsAndVerify(
                testContainer.Container,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions).ConfigureAwait(false);
        }
        #endregion SingleDownload Object
    }
}
