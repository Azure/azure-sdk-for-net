﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        private async Task<DataTransfer> CreateStartTransfer(
            TContainerClient containerClient,
            string localDirectoryPath,
            int concurrency,
            bool createFailedCondition = false,
            DataTransferOptions options = default,
            int size = Constants.KB)
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
            LocalFilesStorageResourceProvider files = new();
            StorageResource sourceResource = files.FromFile(localSourceFile);

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

            DataTransferOptions options = new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                1,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleCompletedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Failed()
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleFailedCheck(1);
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(testEventsRaised.FailedEvents.First().Exception.Message.Contains(_expectedOverwriteExceptionMessage));
        }

        [RecordedTest]
        public async Task StartTransfer_AwaitCompletion_Skipped()
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            // Create transfer options with Skipping available
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            DataTransfer transfer = await CreateStartTransfer(
                containerClient: test.Container,
                localDirectoryPath: disposingLocalDirectory.DirectoryPath,
                concurrency: 1,
                createFailedCondition: true,
                options: options);

            // Act
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token).ConfigureAwait(false);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
        }

        #region Single Upload Verified
        internal class VerifyUploadObjectContentInfo
        {
            public readonly string LocalPath;
            public TObjectClient DestinationClient;
            public TestEventsRaised EventsRaised;
            public DataTransfer DataTransfer;

            public VerifyUploadObjectContentInfo(
                string sourceFile,
                TObjectClient destinationClient,
                TestEventsRaised eventsRaised,
                DataTransfer dataTransfer)
            {
                LocalPath = sourceFile;
                DestinationClient = destinationClient;
                EventsRaised = eventsRaised;
                DataTransfer = dataTransfer;
            }
        };

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
        private async Task UploadResourceAndVerify(
            TContainerClient container,
            long size = Constants.KB,
            int waitTimeInSec = 30,
            TransferManagerOptions transferManagerOptions = default,
            int objectCount = 1,
            List<string> objectNames = default,
            List<DataTransferOptions> options = default)
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
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
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
                LocalFilesStorageResourceProvider files = new();
                StorageResource sourceResource = files.FromFile(localSourceFile);
                DataTransfer transfer = await transferManager.StartTransferAsync(sourceResource, destinationResource, options[i]);

                uploadedObjectInfo.Add(new VerifyUploadObjectContentInfo(
                    sourceFile: localSourceFile,
                    destinationClient: destClient,
                    eventsRaised: eventRaisedList[i],
                    dataTransfer: transfer));
            }

            for (int i = 0; i < objectCount; i++)
            {
                // Assert
                Assert.NotNull(uploadedObjectInfo[i].DataTransfer);
                CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await uploadedObjectInfo[i].DataTransfer.WaitForCompletionAsync(tokenSource.Token);
                Assert.IsTrue(uploadedObjectInfo[i].DataTransfer.HasCompleted);

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
            DataTransferOptions options = new DataTransferOptions();
            options.TransferStatusChanged += (TransferStatusEventArgs args) =>
            {
                // Assert
                if (args.TransferStatus.State == DataTransferState.InProgress)
                {
                    progressSeen = true;
                }
                return Task.CompletedTask;
            };

            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
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
            long size = Constants.KB;
            int waitTimeInSec = 25;
            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 100,
                MaximumTransferChunkSize = 200,
            };

            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };

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
            int size = Constants.KB;
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
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };
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
            int size = Constants.KB;
            int waitTimeInSec = 10;

            // Act
            // Create options bag to overwrite any existing destination.
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions>() { options };

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
            int size = Constants.KB;

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
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists,
            };
            LocalFilesStorageResourceProvider files = new();
            StorageResource sourceResource = files.FromFile(newSourceFile);
            StorageResourceItem destinationResource = GetStorageResourceItem(objectClient);
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasSkippedItems);
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
            int size = Constants.KB;

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
            DataTransferOptions options = new DataTransferOptions()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists,
            };
            TestEventsRaised testEventRaised = new TestEventsRaised(options);
            LocalFilesStorageResourceProvider files = new();
            StorageResource sourceResource = files.FromFile(newSourceFile);
            StorageResourceItem destinationResource = GetStorageResourceItem(objectClient);
            TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            DataTransfer transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await transfer.WaitForCompletionAsync(cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(DataTransferState.Completed, transfer.TransferStatus.State);
            Assert.AreEqual(true, transfer.TransferStatus.HasFailedItems);
            Assert.IsTrue(await ExistsAsync(objectClient));
            await testEventRaised.AssertSingleFailedCheck(1);
            Assert.NotNull(testEventRaised.FailedEvents.First().Exception, "Excepted failure: Overwrite failure was supposed to be raised during the test");
            Assert.IsTrue(testEventRaised.FailedEvents.First().Exception.Message.Contains(_expectedOverwriteExceptionMessage));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using Stream stream = await OpenReadAsync(objectClient);
            Assert.AreEqual(originalStream, stream);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(1000, 10)]
        [TestCase(Constants.KB, 20)]
        [TestCase(4 * Constants.KB, 20)]
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
        [TestCase(257 * Constants.MB, 600)]
        [TestCase(500 * Constants.MB, 200)]
        [TestCase(700 * Constants.MB, 200)]
        [TestCase(Constants.GB, 1500)]
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
        [TestCase(1, Constants.KB, 10)]
        [TestCase(2, Constants.KB, 10)]
        [TestCase(1, 4 * Constants.KB, 60)]
        [TestCase(2, 4 * Constants.KB, 60)]
        [TestCase(4, 16 * Constants.KB, 60)]
        public async Task LocalToRemoteObject_SmallConcurrency(int concurrency, long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
                MaximumConcurrency = concurrency,
            };

            DataTransferOptions options = new DataTransferOptions()
            {
                InitialTransferSize = 512,
                MaximumTransferChunkSize = 512,
            };
            List<DataTransferOptions> optionsList = new List<DataTransferOptions> { options };

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
        [TestCase(1, 257 * Constants.MB, 200)]
        [TestCase(4, 257 * Constants.MB, 200)]
        [TestCase(16, 257 * Constants.MB, 200)]
        [TestCase(16, Constants.GB, 200)]
        [TestCase(32, Constants.GB, 200)]
        public async Task LocalToRemoteObject_LargeConcurrency(int concurrency, int size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure,
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
        [TestCase(2, Constants.KB, 30)]
        [TestCase(6, Constants.KB, 30)]
        [TestCase(32, Constants.KB, 30)]
        [TestCase(2, 2 * Constants.KB, 30)]
        [TestCase(6, 2 * Constants.KB, 30)]
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
        [TestCase(2, 257 * Constants.MB, 400)]
        [TestCase(6, 257 * Constants.MB, 400)]
        [TestCase(2, Constants.GB, 1000)]
        [TestCase(3, Constants.GB, 2000)]
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
