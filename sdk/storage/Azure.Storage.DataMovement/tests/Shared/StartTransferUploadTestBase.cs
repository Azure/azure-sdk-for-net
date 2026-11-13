// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Common;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public abstract class StartTransferUploadTestBase
            <TServiceClient,
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
        public StartTransferUploadTestBase(
            bool async,
            string expectedOverwriteExceptionMessage,
            string generatedResourceNamePrefix = default,
            RecordedTestMode? mode = null) : base(async, mode)
        {
            if (expectedOverwriteExceptionMessage is null)
            {
                throw new ArgumentNullException(expectedOverwriteExceptionMessage);
            }
            if (expectedOverwriteExceptionMessage.Length == 0)
            {
                throw new ArgumentException("Value cannot be an empty string.", expectedOverwriteExceptionMessage);
            }
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
        /// BlobContainerClient or a TObjectClient from a ShareClient.
        /// </summary>
        /// <param name="container">Container to get resource from.</param>
        /// <param name="objectLength">Sets the resource size in bytes, for resources that require this upfront.</param>
        /// <param name="createResource">Whether to call CreateAsync on the resource, if necessary.</param>
        /// <param name="objectName">Optional name for the resource.</param>
        /// <param name="options">ClientOptions for the resource client.</param>
        /// <param name="contents">If specified, the contents will be uploaded to the object client.</param>
        protected abstract Task<TObjectClient> GetObjectClientAsync(
            TContainerClient container,
            long? objectLength = default,
            bool createResource = false,
            string objectName = default,
            TClientOptions options = default,
            Stream contents = default);

        /// <summary>
        /// Gets the specific storage resource from the given TObjectClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
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

        /// <summary>
        /// Checks if the Object Client exists.
        /// </summary>
        /// <param name="objectClient">Object Client to call exists on.</param>
        /// <returns></returns>
        protected abstract Task<bool> ExistsAsync(TObjectClient objectClient);
        #endregion

        protected string GetNewObjectName()
            => _generatedResourceNamePrefix + ClientBuilder.Recording.Random.NewGuid();

        private async Task<TransferOperation> CreateStartTransfer(
            TContainerClient containerClient,
            string localDirectoryPath,
            int concurrency,
            bool createFailedCondition = false,
            TransferOptions options = default,
            int size = DataMovementTestConstants.KB)
        {
            // Arrange
            string destinationName = GetNewObjectName();

            // To create a transfer intended to end in failure,
            // create the failed object so we can run into an overwrite error.
            TObjectClient destinationClient = await GetObjectClientAsync(
                containerClient,
                objectLength: size,
                createResource: createFailedCondition);
            StorageResourceItem destinationResource = GetStorageResourceItem(destinationClient);

            // Create new source file
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            string localSourceFile = Path.Combine(localDirectoryPath, destinationName);
            // create a new file and copy contents of stream into it, and then close the FileStream
            // so the StagedUploadAsync call is not prevented from reading using its FileStream.
            using (FileStream fileStream = File.Create(localSourceFile))
            {
                await originalStream.CopyToAsync(fileStream);
            }
            StorageResource sourceResource = LocalFilesStorageResourceProvider.FromFile(localSourceFile);

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
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            TransferOperation transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                1,
                options: options);

            // Act
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleCompletedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            TransferOperation transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            Assert.AreEqual(true, transfer.Status.HasFailedItems);
            var testException = testEventsRaised.FailedEvents.First().Exception;
            Assert.NotNull(testException, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            if (testException is RequestFailedException rfe)
            {
                Assert.That(rfe.ErrorCode, Does.Contain(_expectedOverwriteExceptionMessage));
            }
            else
            {
                Assert.IsTrue(testException.Message.Contains(_expectedOverwriteExceptionMessage));
            }
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            TransferOperation transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            Assert.AreEqual(true, transfer.Status.HasSkippedItems);
        }

        #region Single Upload Verified
        internal class VerifyUploadObjectContentInfo
        {
            public readonly string LocalPath;
            public TObjectClient DestinationClient;
            public TestEventsRaised EventsRaised;
            public TransferOperation TransferOperation;

            public VerifyUploadObjectContentInfo(
                string sourceFile,
                TObjectClient destinationClient,
                TestEventsRaised eventsRaised,
                TransferOperation transferOperation)
            {
                LocalPath = sourceFile;
                DestinationClient = destinationClient;
                EventsRaised = eventsRaised;
                TransferOperation = transferOperation;
            }
        };

        /// <summary>
        /// Upload and verify the contents of the object
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="waitTimeInSec"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task UploadResourceAndVerify(
            TContainerClient container,
            long size = DataMovementTestConstants.KB,
            int waitTimeInSec = 30,
            TransferManagerOptions transferManagerOptions = default,
            int objectCount = 1,
            List<string> objectNames = default,
            List<TransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();

            // Populate objectNames list for number of files to be created
            if (objectNames == default || objectNames?.Count == 0)
            {
                objectNames ??= new List<string>();
                for (int i = 0; i < objectCount; i++)
                {
                    objectNames.Add(GetNewObjectName());
                }
            }
            else
            {
                // If objectNames is popluated make sure these number of files match
                Assert.AreEqual(objectCount, objectNames.Count);
            }

            // Populate Options and TestRaisedOptions
            List<TestEventsRaised> eventRaisedList = TestEventsRaised.PopulateTestOptions(objectCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorMode = TransferErrorMode.ContinueOnFailure
            };

            List<VerifyUploadObjectContentInfo> uploadedObjectInfo = new List<VerifyUploadObjectContentInfo>(objectCount);

            // Initialize TransferManager
            TransferManager transferManager = new TransferManager(transferManagerOptions);

            // Set up file to upload
            for (int i = 0; i < objectCount; i++)
            {
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, GetNewObjectName());
                // create a new file and copy contents of stream into it, and then close the FileStream
                // so the StagedUploadAsync call is not prevented from reading using its FileStream.
                using (FileStream fileStream = File.OpenWrite(localSourceFile))
                {
                    await originalStream.CopyToAsync(fileStream);
                }

                // Set up destination client
                TObjectClient destClient = await GetObjectClientAsync(
                    container: container,
                    objectLength: size,
                    objectName: objectNames[i]);
                StorageResourceItem destinationResource = GetStorageResourceItem(destClient);

                // Act
                StorageResource sourceResource = LocalFilesStorageResourceProvider.FromFile(localSourceFile);
                TransferOperation transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options[i]);

                uploadedObjectInfo.Add(new VerifyUploadObjectContentInfo(
                    sourceFile: localSourceFile,
                    destinationClient: destClient,
                    eventsRaised: eventRaisedList[i],
                    transferOperation: transfer));
            }

            for (int i = 0; i < objectCount; i++)
            {
                // Assert
                Assert.NotNull(uploadedObjectInfo[i].TransferOperation);
                using CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await TestTransferWithTimeout.WaitForCompletionAsync(
                    uploadedObjectInfo[i].TransferOperation,
                    uploadedObjectInfo[i].EventsRaised,
                    tokenSource.Token);
                Assert.IsTrue(uploadedObjectInfo[i].TransferOperation.HasCompleted);

                // Verify Upload
                await uploadedObjectInfo[i].EventsRaised.AssertSingleCompletedCheck();
                using FileStream fileStream = File.OpenRead(uploadedObjectInfo[i].LocalPath);
                using Stream stream = await OpenReadAsync(uploadedObjectInfo[i].DestinationClient);
                Assert.AreEqual(fileStream, stream);
            }
        }

        [RecordedTest]
        public async Task LocalToRemoteObject()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            await UploadResourceAndVerify(test.Container);
        }

        [RecordedTest]
        public async Task LocalToRemoteObject_EventHandler()
        {
            AutoResetEvent InProgressWait = new AutoResetEvent(false);

            bool progressSeen = false;
            TransferOptions options = new TransferOptions();
            options.TransferStatusChanged += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.TransferStatus.State == TransferState.InProgress)
                {
                    progressSeen = true;
                }
                return Task.CompletedTask;
            };

            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
            await UploadResourceAndVerify(
                container: test.Container,
                objectCount: optionsList.Count,
                options: optionsList);

            // Assert
            Assert.IsTrue(progressSeen);
        }

        [RecordedTest]
        public async Task LocalToRemoteObjectSize_SmallChunk()
        {
            long size = DataMovementTestConstants.KB * 2;
            int waitTimeInSec = 25;
            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };

            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

            await UploadResourceAndVerify(
                size: size,
                waitTimeInSec: waitTimeInSec,
                container: test.Container,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToRemoteObject_Overwrite_Exists()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            string objectName = GetNewObjectName();
            int size = DataMovementTestConstants.KB;
            int waitTimeInSec = 10;

            // Create destination client with uploaded content.
            // This will cause a overwrite to occur since we have OverwriteIfExists enabled,
            // since the destination will pre-exist.
            TObjectClient objectClient;
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                objectClient = await GetObjectClientAsync(
                    container: test.Container,
                    objectLength: size,
                    createResource: true,
                    objectName: objectName,
                    contents: originalStream);
            }

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
            List<string> objectNames = new List<string>() { objectName };

            // Start transfer and await for completion.
            await UploadResourceAndVerify(
                container: test.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                objectNames: objectNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToRemoteObject_Overwrite_NotExists()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            int size = DataMovementTestConstants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };

            // Start transfer and await for completion.
            await UploadResourceAndVerify(
                container: test.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
        }

        [RecordedTest]
        public async Task LocalToRemoteObject_Skip_Exists()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string objectName = GetNewObjectName();
            int size = DataMovementTestConstants.KB;

            // Create destination client with uploaded content.
            // This will cause a skip to occur since we have SkipIfExists enabled,
            // since the destination will pre-exist.
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            TObjectClient objectClient = await GetObjectClientAsync(
                    container: test.Container,
                    objectLength: size,
                    createResource: true,
                    objectName: objectName,
                    contents: originalStream);

            // Act
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(testDirectory.DirectoryPath, size: size);
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.SkipIfExists,
            };
            StorageResource sourceResource = LocalFilesStorageResourceProvider.FromFile(newSourceFile);
            StorageResourceItem destinationResource = GetStorageResourceItem(objectClient);
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            Assert.AreEqual(true, transfer.Status.HasSkippedItems);
            Assert.IsTrue(await ExistsAsync(objectClient));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using Stream stream = await OpenReadAsync(objectClient);
            Assert.AreEqual(originalStream, stream);
        }

        [RecordedTest]
        public async Task LocalToRemoteObject_Failure_Exists()
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            string objectName = GetNewObjectName();
            int size = DataMovementTestConstants.KB;

            // Create destination client with uploaded content.
            // This will cause a failure to occur since we have FailIfExists enabled,
            // since the destination will pre-exist.
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            TObjectClient objectClient = await GetObjectClientAsync(
                    container: test.Container,
                    objectLength: size,
                    createResource: true,
                    objectName: objectName,
                    contents: originalStream);

            // Make destination file name but do not create the file beforehand.
            // Create new source file
            string newSourceFile = await CreateRandomFileAsync(Path.GetTempPath(), size: size);

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.FailIfExists,
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);
            StorageResource sourceResource = LocalFilesStorageResourceProvider.FromFile(newSourceFile);
            StorageResourceItem destinationResource = GetStorageResourceItem(objectClient);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            Assert.AreEqual(true, transfer.Status.HasFailedItems);
            Assert.IsTrue(await ExistsAsync(objectClient));
            await testEventRaised.AssertSingleFailedCheck(1);
            var testException = testEventRaised.FailedEvents.First().Exception;
            Assert.NotNull(testException, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            if (testException is RequestFailedException rfe)
            {
                Assert.That(rfe.ErrorCode, Does.Contain(_expectedOverwriteExceptionMessage));
            }
            else
            {
                Assert.IsTrue(testException.Message.Contains(_expectedOverwriteExceptionMessage));
            }
            // Verify Upload - That we skipped over and didn't reupload something new.
            using Stream stream = await OpenReadAsync(objectClient);
            Assert.AreEqual(originalStream, stream);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(512, 10)]
        [TestCase(DataMovementTestConstants.KB, 20)]
        [TestCase(4 * DataMovementTestConstants.KB, 20)]
        public async Task LocalToRemoteObject_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            await UploadResourceAndVerify(
                container: test.Container,
                size: size,
                waitTimeInSec: waitTimeInSec);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(257 * DataMovementTestConstants.MB, 600)]
        [TestCase(500 * DataMovementTestConstants.MB, 200)]
        [TestCase(700 * DataMovementTestConstants.MB, 200)]
        [TestCase(DataMovementTestConstants.GB, 1500)]
        public async Task LocalToRemoteObject_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            await UploadResourceAndVerify(
                container: test.Container,
                size: size,
                waitTimeInSec: waitTimeInSec);
        }

        [RecordedTest]
        [TestCase(1, DataMovementTestConstants.KB, 10)]
        [TestCase(2, DataMovementTestConstants.KB, 10)]
        [TestCase(1, 4 * DataMovementTestConstants.KB, 60)]
        [TestCase(2, 4 * DataMovementTestConstants.KB, 60)]
        [TestCase(4, 16 * DataMovementTestConstants.KB, 60)]
        public async Task LocalToRemoteObject_SmallConcurrency(int concurrency, long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<TransferOptions> optionsList = new List<TransferOptions> { options };

            await UploadResourceAndVerify(
                container: test.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions,
                options: optionsList);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(1, 257 * DataMovementTestConstants.MB, 200)]
        [TestCase(4, 257 * DataMovementTestConstants.MB, 200)]
        [TestCase(16, 257 * DataMovementTestConstants.MB, 200)]
        [TestCase(16, DataMovementTestConstants.GB, 200)]
        [TestCase(32, DataMovementTestConstants.GB, 200)]
        public async Task LocalToRemoteObject_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            await UploadResourceAndVerify(
                container: test.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                transferManagerOptions: managerOptions);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, 0, 30)]
        [TestCase(2, DataMovementTestConstants.KB, 30)]
        [TestCase(6, DataMovementTestConstants.KB, 30)]
        [TestCase(32, DataMovementTestConstants.KB, 30)]
        [TestCase(2, 2 * DataMovementTestConstants.KB, 30)]
        [TestCase(6, 2 * DataMovementTestConstants.KB, 30)]
        public async Task LocalToRemoteObject_SmallMultiple(int objectCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            await UploadResourceAndVerify(
                container: test.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                objectCount: objectCount);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 257 * DataMovementTestConstants.MB, 400)]
        [TestCase(6, 257 * DataMovementTestConstants.MB, 400)]
        [TestCase(2, DataMovementTestConstants.GB, 1000)]
        [TestCase(3, DataMovementTestConstants.GB, 2000)]
        public async Task LocalToRemoteObject_LargeMultiple(int objectCount, long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            await UploadResourceAndVerify(
                container: test.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                objectCount: objectCount);
        }
        #endregion
    }
}
