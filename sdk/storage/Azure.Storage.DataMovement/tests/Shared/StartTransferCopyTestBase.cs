// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.Storage.Test.Shared;
using System.Threading.Tasks;
using System.IO;
using NUnit.Framework;
using System.Threading;

namespace Azure.Storage.DataMovement.Tests
{
    public abstract class StartTransferCopyTestBase
        <TSourceServiceClient,
        TSourceContainerClient,
        TSourceObjectClient,
        TSourceClientOptions,
        TDestinationServiceClient,
        TDestinationContainerClient,
        TDestinationObjectClient,
        TDestinationClientOptions,
        TEnvironment> : StorageTestBase<TEnvironment>
        where TSourceServiceClient : class
        where TSourceContainerClient : class
        where TSourceObjectClient : class
        where TSourceClientOptions : ClientOptions
        where TDestinationServiceClient : class
        where TDestinationContainerClient : class
        where TDestinationObjectClient : class
        where TDestinationClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        private readonly string _generatedResourceNamePrefix;
        private readonly string _expectedOverwriteExceptionMessage;

        public ClientBuilder<TSourceServiceClient, TSourceClientOptions> SourceClientBuilder { get; protected set; }
        public ClientBuilder<TDestinationServiceClient, TDestinationClientOptions> DestinationClientBuilder { get; protected set; }

        public enum TransferPropertiesTestType
        {
            Default = 0,
            Preserve = 1,
            NoPreserve = 2,
            NewProperties = 3,
        }

        /// <summary>
        /// Constructor for TransferManager.StartTransferAsync tests
        ///
        /// The async is defaulted to true, since we do not have sync StartTransfer methods.
        /// </summary>
        /// <param name="generatedResourcenamePrefix"></param>
        /// <param name="mode"></param>
        public StartTransferCopyTestBase(
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
        protected abstract Task<IDisposingContainer<TSourceContainerClient>> GetSourceDisposingContainerAsync(
            TSourceServiceClient service = default,
            string containerName = default);

        /// <summary>
        /// Gets a new service-specific child object client from a given container, e.g. a BlobClient from a
        /// TSourceContainerClient or a TSourceObjectClient from a ShareClient.
        /// </summary>
        /// <param name="container">Container to get resource from.</param>
        /// <param name="objectLength">Sets the resource size in bytes, for resources that require this upfront.</param>
        /// <param name="createResource">Whether to call CreateAsync on the resource, if necessary.</param>
        /// <param name="objectName">Optional name for the resource.</param>
        /// <param name="options">ClientOptions for the resource client.</param>
        /// <param name="contents">If specified, the contents will be uploaded to the object client.</param>
        protected abstract Task<TSourceObjectClient> GetSourceObjectClientAsync(
            TSourceContainerClient container,
            long? objectLength = default,
            bool createResource = false,
            string objectName = default,
            TSourceClientOptions options = default,
            Stream contents = default,
            TransferPropertiesTestType propertiesTestType = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the specific storage resource from the given TSourceObjectClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, TSourceObjectClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="objectClient">The object client to create the storage resource object.</param>
        /// <returns></returns>
        protected abstract StorageResourceItem GetSourceStorageResourceItem(TSourceObjectClient objectClient);

        /// <summary>
        /// Calls the OpenRead method on the TSourceObjectClient.
        ///
        /// This is mainly used to verify the contents of the Object Client.
        /// </summary>
        /// <param name="objectClient">The object client to get the Open Read Stream from.</param>
        /// <returns></returns>
        protected abstract Task<Stream> SourceOpenReadAsync(TSourceObjectClient objectClient);

        /// <summary>
        /// Checks if the Object Client exists.
        /// </summary>
        /// <param name="objectClient">Object Client to call exists on.</param>
        /// <returns></returns>
        protected abstract Task<bool> SourceExistsAsync(TSourceObjectClient objectClient);

        /// <summary>
        /// Gets a service-specific disposing container for use with tests in this class.
        /// </summary>
        /// <param name="service">Optionally specified service client to get container from.</param>
        /// <param name="containerName">Optional container name specification.</param>
        protected abstract Task<IDisposingContainer<TDestinationContainerClient>> GetDestinationDisposingContainerAsync(
            TDestinationServiceClient service = default,
            string containerName = default);

        /// <summary>
        /// Gets a new service-specific child object client from a given container, e.g. a BlobClient from a
        /// TSourceContainerClient or a TDestinationObjectClient from a ShareClient.
        /// </summary>
        /// <param name="container">Container to get resource from.</param>
        /// <param name="objectLength">Sets the resource size in bytes, for resources that require this upfront.</param>
        /// <param name="createResource">Whether to call CreateAsync on the resource, if necessary.</param>
        /// <param name="objectName">Optional name for the resource.</param>
        /// <param name="options">ClientOptions for the resource client.</param>
        /// <param name="contents">If specified, the contents will be uploaded to the object client.</param>
        protected abstract Task<TDestinationObjectClient> GetDestinationObjectClientAsync(
            TDestinationContainerClient container,
            long? objectLength = default,
            bool createResource = false,
            string objectName = default,
            TDestinationClientOptions options = default,
            Stream contents = default,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the specific storage resource from the given TDestinationObjectClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, TSourceObjectClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="objectClient">The object client to create the storage resource object.</param>
        /// <param name="propertiesTestType">This defines what properties to preserve or set.</param>
        /// <returns></returns>
        protected abstract StorageResourceItem GetDestinationStorageResourceItem(
            TDestinationObjectClient objectClient,
            TransferPropertiesTestType propertiesTestType = TransferPropertiesTestType.Default);

        /// <summary>
        /// Calls the OpenRead method on the TDestinationObjectClient.
        ///
        /// This is mainly used to verify the contents of the Object Client.
        /// </summary>
        /// <param name="objectClient">The object client to get the Open Read Stream from.</param>
        /// <returns></returns>
        protected abstract Task<Stream> DestinationOpenReadAsync(TDestinationObjectClient objectClient);

        /// <summary>
        /// Checks if the Object Client exists.
        /// </summary>
        /// <param name="objectClient">Object Client to call exists on.</param>
        /// <returns></returns>
        protected abstract Task<bool> DestinationExistsAsync(TDestinationObjectClient objectClient);

        /// <summary>
        /// Verifies resource transfer properties.
        /// </summary>
        /// <param name="transfer">The transfer.</param>
        /// <param name="testEventsRaised">Event Arguements to check.</param>
        /// <param name="sourceClient">The source resource to check the contents and properties.</param>
        /// <param name="destinationClient">The destination resource to check the contents and properties.</param>
        /// <returns></returns>
        protected abstract Task VerifyPropertiesCopyAsync(
            TransferOperation transfer,
            TransferPropertiesTestType transferPropertiesTestType,
            TestEventsRaised testEventsRaised,
            TSourceObjectClient sourceClient,
            TDestinationObjectClient destinationClient,
            CancellationToken cancellationToken = default);
        #endregion

        protected string GetNewObjectName()
            => _generatedResourceNamePrefix + SourceClientBuilder.Recording.Random.NewGuid();

        internal class VerifyObjectCopyFromUriInfo
        {
            public readonly string SourceLocalPath;
            public readonly StorageResourceItem SourceResource;
            public readonly TSourceObjectClient SourceClient;
            public readonly StorageResourceItem DestinationResource;
            public readonly TDestinationObjectClient DestinationClient;
            public TestEventsRaised testEventsRaised;
            public TransferOperation TransferOperation;
            public bool CompletedStatus;

            public VerifyObjectCopyFromUriInfo(
                string sourceLocalPath,
                StorageResourceItem sourceResource,
                TSourceObjectClient sourceClient,
                StorageResourceItem destinationResource,
                TDestinationObjectClient destinationClient,
                TestEventsRaised eventsRaised,
                bool completed)
            {
                SourceLocalPath = sourceLocalPath;
                SourceResource = sourceResource;
                SourceClient = sourceClient;
                DestinationResource = destinationResource;
                DestinationClient = destinationClient;
                testEventsRaised = eventsRaised;
                CompletedStatus = completed;
                TransferOperation = default;
            }
        };
        #region Copy RemoteObject
        /// <summary>
        /// Upload the source remote object, then copy the contents to another remote object.
        /// Then copy the remote object and verify the contents.
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="waitTimeInSec"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        private async Task CopyRemoteObjectsAndVerify(
            TSourceContainerClient sourceContainer,
            TDestinationContainerClient destinationContainer,
            long size = DataMovementTestConstants.KB,
            int waitTimeInSec = 30,
            int objectCount = 1,
            TransferManagerOptions transferManagerOptions = default,
            List<string> sourceObjectNames = default,
            List<string> destinationObjectNames = default,
            List<TransferOptions> options = default)
        {
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            // Populate objectCount list for number of objects to be created
            if (sourceObjectNames == default || sourceObjectNames?.Count == 0)
            {
                sourceObjectNames ??= new List<string>();
                for (int i = 0; i < objectCount; i++)
                {
                    sourceObjectNames.Add(GetNewObjectName());
                }
            }
            else
            {
                // If objectNames is populated make sure these number of objects match
                Assert.AreEqual(objectCount, sourceObjectNames.Count);
            }

            // Populate objectNames list for number of objects to be created
            if (destinationObjectNames == default || destinationObjectNames?.Count == 0)
            {
                destinationObjectNames ??= new List<string>();
                for (int i = 0; i < objectCount; i++)
                {
                    destinationObjectNames.Add(GetNewObjectName());
                }
            }
            else
            {
                // If objectNames is populated make sure these number of objects match
                Assert.AreEqual(objectCount, destinationObjectNames.Count);
            }

            // Populate Options and TestRaisedOptions
            List<TestEventsRaised> eventsRaisedList = TestEventsRaised.PopulateTestOptions(objectCount, ref options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorMode = TransferErrorMode.ContinueOnFailure
            };

            List<VerifyObjectCopyFromUriInfo> copyObjectInfo = new List<VerifyObjectCopyFromUriInfo>(objectCount);
            // Initialize transfer manager
            await using TransferManager transferManager = new TransferManager(transferManagerOptions);

            // Upload set of VerifyCopyFromUriInfo Remote Objects to Copy
            for (int i = 0; i < objectCount; i++)
            {
                bool completed = false;
                // Set up object to be Copied
                var data = GetRandomBuffer(size);
                using Stream originalStream = await CreateLimitedMemoryStream(size);
                string localSourceFile = Path.Combine(testDirectory.DirectoryPath, sourceObjectNames[i]);
                TSourceObjectClient sourceClient = await GetSourceObjectClientAsync(
                    container: sourceContainer,
                    objectLength: size,
                    createResource: true,
                    objectName: sourceObjectNames[i]);

                StorageResourceItem sourceResource = GetSourceStorageResourceItem(sourceClient);
                // Set up destination client
                TDestinationObjectClient destClient = await GetDestinationObjectClientAsync(
                    container: destinationContainer,
                    createResource: false,
                    objectName: string.Concat(destinationObjectNames[i]));
                StorageResourceItem destinationResource = GetDestinationStorageResourceItem(destClient);
                copyObjectInfo.Add(new VerifyObjectCopyFromUriInfo(
                    localSourceFile,
                    sourceResource,
                    sourceClient,
                    destinationResource,
                    destClient,
                    eventsRaisedList[i],
                    completed));
            }

            // Schedule all Copy Remote Objects consecutively
            for (int i = 0; i < copyObjectInfo.Count; i++)
            {
                // Act
                TransferOperation transfer = await transferManager.StartTransferAsync(
                    copyObjectInfo[i].SourceResource,
                    copyObjectInfo[i].DestinationResource,
                    options[i]).ConfigureAwait(false);
                copyObjectInfo[i].TransferOperation = transfer;
            }

            for (int i = 0; i < copyObjectInfo.Count; i++)
            {
                // Assert
                Assert.NotNull(copyObjectInfo[i].TransferOperation);
                using CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(waitTimeInSec));
                await TestTransferWithTimeout.WaitForCompletionAsync(
                    copyObjectInfo[i].TransferOperation,
                    copyObjectInfo[i].testEventsRaised,
                    tokenSource.Token);
                Assert.IsTrue(copyObjectInfo[i].TransferOperation.HasCompleted);
                Assert.AreEqual(TransferState.Completed, copyObjectInfo[i].TransferOperation.Status.State);

                // Verify Copy - using original source File and Copying the destination
                await copyObjectInfo[i].testEventsRaised.AssertSingleCompletedCheck();
                using Stream sourceStream = await SourceOpenReadAsync(copyObjectInfo[i].SourceClient);
                using Stream destinationStream = await DestinationOpenReadAsync(copyObjectInfo[i].DestinationClient);
                Assert.AreEqual(sourceStream, destinationStream);
            }
        }

        [RecordedTest]
        public async Task SourceObjectToDestinationObject()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            // No Option Copy bag or manager options bag, plain Copy
            await CopyRemoteObjectsAndVerify(source.Container, destination.Container).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task SourceObjectToDestinationObject_SmallChunk()
        {
            long size = DataMovementTestConstants.KB;
            int waitTimeInSec = 25;

            TransferOptions options = new TransferOptions()
            {
                InitialTransferSize = DataMovementTestConstants.KB / 2,
                MaximumTransferChunkSize = DataMovementTestConstants.KB / 2,
            };

            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
            await CopyRemoteObjectsAndVerify(
                source.Container,
                destination.Container,
                waitTimeInSec: waitTimeInSec,
                size: size,
                options: optionsList).ConfigureAwait(false);
        }

        [RecordedTest]
        [TestCase(0, 10)]
        [TestCase(DataMovementTestConstants.KB/2, 10)]
        [TestCase(DataMovementTestConstants.KB, 10)]
        [TestCase(2 * DataMovementTestConstants.KB, 10)]
        public async Task SourceObjectToDestinationObject_SmallSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjectsAndVerify(
                source.Container,
                destination.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(4 * DataMovementTestConstants.MB, 20)]
        [TestCase(5 * DataMovementTestConstants.MB, 20)]
        [TestCase(257 * DataMovementTestConstants.MB, 400)]
        [TestCase(DataMovementTestConstants.GB, 1000)]
        public async Task SourceObjectToDestinationObject_LargeSize(long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjectsAndVerify(
                source.Container,
                destination.Container,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/33003")]
        [Test]
        [LiveOnly]
        [TestCase(2, 0, 30)]
        [TestCase(6, 0, 30)]
        [TestCase(2, DataMovementTestConstants.KB/2, 30)]
        [TestCase(6, DataMovementTestConstants.KB/2, 30)]
        [TestCase(2, DataMovementTestConstants.KB, 300)]
        [TestCase(6, DataMovementTestConstants.KB, 300)]
        public async Task SourceObjectToDestinationObject_SmallMultiple(int count, long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjectsAndVerify(
                source.Container,
                destination.Container,
                objectCount: count,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [Ignore("These tests currently take 40+ mins for little additional coverage")]
        [Test]
        [LiveOnly]
        [TestCase(2, 4 * DataMovementTestConstants.MB, 300)]
        [TestCase(6, 4 * DataMovementTestConstants.MB, 300)]
        [TestCase(2, 257 * DataMovementTestConstants.MB, 400)]
        [TestCase(6, 257 * DataMovementTestConstants.MB, 600)]
        [TestCase(2, DataMovementTestConstants.GB, 2000)]
        public async Task SourceObjectToDestinationObject_LargeMultiple(int count, long size, int waitTimeInSec)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjectsAndVerify(
                source.Container,
                destination.Container,
                objectCount: count,
                size: size,
                waitTimeInSec: waitTimeInSec).ConfigureAwait(false);
        }

        [RecordedTest]
        public async Task SourceObjectToDestinationObject_Overwrite_Exists()
        {
            // Arrange
            // Create source local file for checking, and source object
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string name = GetNewObjectName();
            string localSourceFile = Path.Combine(testDirectory.DirectoryPath, name);
            int size = DataMovementTestConstants.KB;
            // Create destination, so when we attempt to transfer, we have something to overwrite.
            TDestinationObjectClient destClient = await GetDestinationObjectClientAsync(
                container: destination.Container,
                objectName: name,
                objectLength: size,
                createResource: true);

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.OverwriteIfExists,
            };
            List<TransferOptions> optionsList = new List<TransferOptions>() { options };
            List<string> objectNames = new List<string>() { name };

            // Start transfer and await for completion.
            await CopyRemoteObjectsAndVerify(
                source.Container,
                destination.Container,
                destinationObjectNames: objectNames,
                options: optionsList);
        }

        [RecordedTest]
        public async Task SourceObjectToDestinationObject_Overwrite_NotExists()
        {
            // Arrange
            // Create source local file for checking, and source object
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

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
            await CopyRemoteObjectsAndVerify(
                source.Container,
                destination.Container,
                size: size,
                waitTimeInSec: waitTimeInSec,
                options: optionsList);
        }

        [RecordedTest]
        public async Task SourceObjectToDestinationObject_Skip_Exists()
        {
            // Arrange
            // Create source local file for checking, and source object
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string objectName = GetNewObjectName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, objectName);
            int size = DataMovementTestConstants.KB;
            var data = GetRandomBuffer(size);
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            TDestinationObjectClient destinationClient = await GetDestinationObjectClientAsync(
                container: destination.Container,
                objectLength: size,
                createResource: true,
                objectName: objectName,
                contents: originalStream);

            // Act
            // Create options bag to overwrite any existing destination.
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.SkipIfExists,
            };

            // Create new source block object.
            string newSourceFile = Path.Combine(testDirectory.DirectoryPath, GetNewObjectName());
            TSourceObjectClient sourceClient = await GetSourceObjectClientAsync(
                source.Container,
                objectName: GetNewObjectName(),
                objectLength: size,
                createResource: true);
            StorageResourceItem sourceResource = GetSourceStorageResourceItem(sourceClient);
            StorageResourceItem destinationResource = GetDestinationStorageResourceItem(destinationClient);
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            await using TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            Assert.AreEqual(true, transfer.Status.HasSkippedItems);
            await testEventsRaised.AssertSingleSkippedCheck();
            Assert.IsTrue(await DestinationExistsAsync(destinationClient));
            // Verify Upload - That we skipped over and didn't reupload something new.
            using Stream destinationStream = await DestinationOpenReadAsync(destinationClient);
            Assert.AreEqual(originalStream, destinationStream);
        }

        [RecordedTest]
        public async Task SourceObjectToDestinationObject_Failure_Exists()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            using DisposingLocalDirectory testDirectory = DisposingLocalDirectory.GetTestDirectory();
            string name = GetNewObjectName();
            string originalSourceFile = Path.Combine(testDirectory.DirectoryPath, name);
            int size = DataMovementTestConstants.KB;
            var data = GetRandomBuffer(size);
            using Stream originalStream = await CreateLimitedMemoryStream(size);
            TDestinationObjectClient destinationClient = await GetDestinationObjectClientAsync(
                container: destination.Container,
                objectLength: size,
                createResource: true,
                objectName: name,
                contents: originalStream);

            // Act
            // Create options bag to fail and keep track of the failure.
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.FailIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            // Create new source object.
            string newSourceFile = Path.Combine(testDirectory.DirectoryPath, GetNewObjectName());
            TSourceObjectClient sourceClient = await GetSourceObjectClientAsync(
                container: source.Container,
                objectName: GetNewObjectName(),
                createResource: true,
                objectLength: size);
            StorageResourceItem sourceResource = GetSourceStorageResourceItem(sourceClient);
            StorageResourceItem destinationResource = GetDestinationStorageResourceItem(destinationClient);
            await using TransferManager transferManager = new TransferManager();

            // Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            Assert.AreEqual(true, transfer.Status.HasFailedItems);
            Assert.IsTrue(await DestinationExistsAsync(destinationClient));
            await testEventsRaised.AssertSingleFailedCheck(1);
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
            // Verify Copy - That we skipped over and didn't reupload something new.
            using Stream destinationStream = await DestinationOpenReadAsync(destinationClient);
            Assert.AreEqual(originalStream, destinationStream);
        }
        #endregion

        /// <summary>
        /// For usage, please dispose of the TransferManager after use.
        /// </summary>
        /// <param name="concurrency">Concurrency to set in TransferManagerOptions.</param>
        /// <returns>Valid TransferManager that needs to be disposed after use.</returns>
        private TransferManager CreateTransferManager(int concurrency = default)
        {
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = concurrency,
            };
            return new TransferManager(managerOptions);
        }

        private async Task<TransferOperation> CreateStartTransfer(
            TSourceContainerClient sourceContainer,
            TDestinationContainerClient destinationContainer,
            TransferManager transferManager,
            bool createFailedCondition = false,
            TransferOptions options = default,
            int size = DataMovementTestConstants.KB)
        {
            // Arrange
            // Create source local file for checking, and source object
            string sourceName = GetNewObjectName();
            string destinationName = GetNewObjectName();
            TDestinationObjectClient destinationClient = await GetDestinationObjectClientAsync(
                container: destinationContainer,
                createResource: createFailedCondition,
                objectName: destinationName,
                objectLength: size);

            // Create new source object.
            TSourceObjectClient sourceClient = await GetSourceObjectClientAsync(
                container: sourceContainer,
                objectName: sourceName,
                createResource: true,
                objectLength: size);
            StorageResourceItem sourceResource = GetSourceStorageResourceItem(sourceClient);
            StorageResourceItem destinationResource = GetDestinationStorageResourceItem(destinationClient);

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
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            await using TransferManager transferManager = CreateTransferManager(concurrency: 1);

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            TransferOperation transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                transferManager,
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
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            await using TransferManager transferManager = CreateTransferManager(concurrency: 1);

            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            TransferOperation transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                transferManager,
                createFailedCondition: true,
                options: options);

            // Act
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            Assert.AreEqual(true, transfer.Status.HasFailedItems);
            await testEventsRaised.AssertSingleFailedCheck(1);
            var testException = testEventsRaised.FailedEvents.First().Exception;
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
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();
            await using TransferManager transferManager = CreateTransferManager(concurrency: 1);

            // Create transfer options with Skipping available
            TransferOptions options = new TransferOptions()
            {
                CreationMode = StorageResourceCreationMode.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            // Create transfer to do a AwaitCompletion
            TransferOperation transfer = await CreateStartTransfer(
                source.Container,
                destination.Container,
                transferManager,
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

        private async Task CopyRemoteObjects_VerifyProperties(
            TSourceContainerClient sourceContainer,
            TDestinationContainerClient destinationContainer,
            TransferPropertiesTestType propertiesType,
            long size = Constants.KB,
            long? chunkSize = default)
        {
            // Create blob with properties
            TSourceObjectClient sourceClient = await GetSourceObjectClientAsync(
                container: sourceContainer,
                objectLength: size,
                createResource: true);
            // Set preserve properties
            StorageResourceItem sourceResource = GetSourceStorageResourceItem(sourceClient);

            // Destination client - Set Properties
            TDestinationObjectClient destinationClient = await GetDestinationObjectClientAsync(
                container: destinationContainer,
                createResource: false);
            StorageResourceItem destinationResource = GetDestinationStorageResourceItem(
                destinationClient,
                propertiesTestType: propertiesType);

            TransferOptions options = new()
            {
                MaximumTransferChunkSize = chunkSize,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            await using TransferManager transferManager = new TransferManager();

            // Act - Start transfer and await for completion.
            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                options);
            using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationTokenSource.Token);

            // Assert
            await VerifyPropertiesCopyAsync(
                transfer,
                propertiesType,
                testEventsRaised,
                sourceClient,
                destinationClient);
        }

        [RecordedTest]
        public virtual async Task SourceObjectToDestinationObject_DefaultProperties()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjects_VerifyProperties(
                source.Container,
                destination.Container,
                TransferPropertiesTestType.Default);
        }

        [RecordedTest]
        public virtual async Task SourceObjectToDestinationObject_PreserveProperties()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjects_VerifyProperties(
                source.Container,
                destination.Container,
                TransferPropertiesTestType.Preserve);
        }

        [RecordedTest]
        public virtual async Task SourceObjectToDestinationObject_NoPreserveProperties()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjects_VerifyProperties(
                source.Container,
                destination.Container,
                TransferPropertiesTestType.NoPreserve);
        }

        [RecordedTest]
        public virtual async Task SourceObjectToDestinationObject_NewProperties()
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjects_VerifyProperties(
                source.Container,
                destination.Container,
                TransferPropertiesTestType.NewProperties);
        }

        [RecordedTest]
        [TestCase((int) TransferPropertiesTestType.Default)]
        [TestCase((int) TransferPropertiesTestType.Preserve)]
        [TestCase((int) TransferPropertiesTestType.NoPreserve)]
        [TestCase((int) TransferPropertiesTestType.NewProperties)]
        public virtual async Task SourceObjectToDestinationObject_VerifyProperties_Chunks(int propertiesType)
        {
            // Arrange
            await using IDisposingContainer<TSourceContainerClient> source = await GetSourceDisposingContainerAsync();
            await using IDisposingContainer<TDestinationContainerClient> destination = await GetDestinationDisposingContainerAsync();

            await CopyRemoteObjects_VerifyProperties(
                source.Container,
                destination.Container,
                (TransferPropertiesTestType) propertiesType,
                size: Constants.KB,
                chunkSize: Constants.KB / 2);
        }
    }
}
