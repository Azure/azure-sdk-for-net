// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public abstract class StartTransferUploadDirectoryTestBase<
        TServiceClient,
        TContainerClient,
        TObjectClient,
        TClientOptions,
        TEnvironment>
        : StorageTestBase<TEnvironment>
        where TServiceClient : class
        where TContainerClient : class
        where TObjectClient : class
        where TClientOptions : ClientOptions
        where TEnvironment : StorageTestEnvironment, new()
    {
        private const long DefaultObjectSize = Constants.KB;

        //private readonly string _generatedResourceNamePrefix;
        //private readonly string _expectedOverwriteExceptionMessage;

        public ClientBuilder<TServiceClient, TClientOptions> ClientBuilder { get; protected set; }

        public LocalFilesStorageResourceProvider LocalResourceProvider { get; } = new();

        public StartTransferUploadDirectoryTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode)
        { }

        protected string GetNewObjectName(int? maxChars = 8)
        {
            string result = ClientBuilder.Recording.Random.NewGuid().ToString();
            return maxChars < result.Length ? result.Substring(0, maxChars.Value) : result;
        }

        #region Service-Specific Implementations
        /// <summary>
        /// Gets a service-specific disposing container for use with tests in this class.
        /// </summary>
        /// <param name="service">Optionally specified service client to get container from.</param>
        /// <param name="containerName">Optional container name specification.</param>
        protected abstract Task<IDisposingContainer<TContainerClient>> GetDisposingContainerAsync(
            TServiceClient service = default,
            string containerName = default);

        /// <summary>
        /// Initializes data at the destination container.
        /// </summary>
        /// <returns></returns>
        protected abstract Task InitializeDestinationDataAsync(
            TContainerClient containerClient,
            List<(string FilePath, long Size)> fileSizes,
            CancellationToken cancellationToken);

        /// <summary>
        /// Gets the specific storage resource from the given TObjectClient
        /// e.g. ShareFileClient to a ShareFileStorageResource, BlockBlobClient to a BlockBlobStorageResource.
        /// </summary>
        /// <param name="objectClient">The object client to create the storage resource object.</param>
        /// <returns></returns>
        protected abstract StorageResourceContainer GetStorageResourceContainer(TContainerClient containerClient);

        /// <summary>
        /// Gets the appropriate delegate for listing through and validating the state of the destination container.
        /// </summary>
        /// <param name="containerClient"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        protected abstract TransferValidator.ListFilesAsync GetStorageResourceLister(TContainerClient containerClient);
        #endregion

        #region Test Helpers
        private async Task SetupDirectoryAsync(
            string directoryPath,
            List<(string FilePath, long Size)> fileSizes,
            CancellationToken cancellationToken)
        {
            foreach ((string filePath, long size) in fileSizes)
            {
                string currRelPath = "";
                string[] pathSegments = filePath.Split('/', '\\');
                if (pathSegments.Length < 1)
                {
                    continue;
                }
                foreach (string directoryName in pathSegments.Take(pathSegments.Length - 1))
                {
                    currRelPath = string.Join(Path.DirectorySeparatorChar.ToString(), currRelPath, directoryName).Trim(Path.DirectorySeparatorChar);
                    string currAbsPath = Path.Combine(directoryPath, currRelPath);
                    if (!Directory.Exists(currAbsPath))
                    {
                        Directory.CreateDirectory(currAbsPath);
                    }
                }

                currRelPath = string.Join(Path.DirectorySeparatorChar.ToString(), currRelPath, pathSegments.Last()).Trim(Path.DirectorySeparatorChar);
                if (size < 0)
                {
                    Directory.CreateDirectory(Path.Combine(directoryPath, currRelPath));
                }
                else
                {
                    using FileStream fs = File.OpenWrite(Path.Combine(directoryPath, currRelPath));
                    using Stream data = await CreateLimitedMemoryStream(size);
                    await data.CopyToAsync(fs, bufferSize: 4 * Constants.KB, cancellationToken);
                }
            }
        }

        /// <summary>
        /// Upload and verify the contents of the directory
        ///
        /// By default in this function an event argument will be added to the options event handler
        /// to detect when the upload has finished.
        /// </summary>
        private async Task UploadDirectoryAndVerifyAsync(
            string sourceLocalDirectoryPath,
            TContainerClient destinationContainer,
            int expectedTransfers,
            TransferManagerOptions transferManagerOptions = default,
            DataTransferOptions options = default,
            CancellationToken cancellationToken = default)
        {
            // Set transfer options
            options ??= new DataTransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);

            transferManagerOptions ??= new TransferManagerOptions()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            StorageResourceContainer sourceResource = LocalResourceProvider.FromDirectory(sourceLocalDirectoryPath);
            StorageResourceContainer destinationResource = GetStorageResourceContainer(destinationContainer);

            await new TransferValidator()
            {
                TransferManager = new(transferManagerOptions)
            }.TransferAndVerifyAsync(
                sourceResource,
                destinationResource,
                TransferValidator.GetLocalFileLister(sourceLocalDirectoryPath),
                GetStorageResourceLister(destinationContainer),
                expectedTransfers,
                options,
                cancellationToken);
        }
        #endregion

        [RecordedTest]
        [TestCase(Constants.KB, 10)]
        [TestCase(12345, 10)]
        public async Task Upload(long objectSize, int waitTimeInSec)
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<string> files = new()
            {
                GetNewObjectName(),
                GetNewObjectName(),
            };

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await SetupDirectoryAsync(
                disposingLocalDirectory.DirectoryPath,
                files.Select(path => (path, objectSize)).ToList(),
                cancellationToken);
            await UploadDirectoryAndVerifyAsync(
                disposingLocalDirectory.DirectoryPath,
                test.Container,
                expectedTransfers: files.Count,
                cancellationToken: cancellationToken);
        }

        [RecordedTest]
        [TestCase(DataTransferErrorMode.ContinueOnFailure)]
        [TestCase(DataTransferErrorMode.StopOnAnyFailure)]
        public async Task UploadFailIfExists(DataTransferErrorMode errorMode)
        {
            const int waitTimeInSec = 15;
            const int preexistingFileCount = 2;
            const int skipCount = 1;
            const int totalFileCount = skipCount + preexistingFileCount + 1;
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<string> files = new();
            foreach (var _ in Enumerable.Range(0, totalFileCount))
            {
                files.Add(GetNewObjectName());
            }

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await InitializeDestinationDataAsync(
                test.Container,
                files.Skip(skipCount).Take(preexistingFileCount).Select(path => (path, DefaultObjectSize)).ToList(),
                cancellationToken);
            await SetupDirectoryAsync(
                disposingLocalDirectory.DirectoryPath,
                files.Select(path => (path, DefaultObjectSize)).ToList(),
            cancellationToken);

            DataTransferOptions options = new()
            {
                CreationPreference = StorageResourceCreationPreference.FailIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManagerOptions transferManagerOptions = new()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            StorageResourceContainer sourceResource = LocalResourceProvider.FromDirectory(disposingLocalDirectory.DirectoryPath);
            StorageResourceContainer destinationResource = GetStorageResourceContainer(test.Container);
            DataTransfer transfer = await new TransferManager(transferManagerOptions)
                .StartTransferAsync(sourceResource, destinationResource, options, cancellationToken);
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationToken);

            // check if expected files exist, but not necessarily for contents
            if (errorMode == DataTransferErrorMode.ContinueOnFailure)
            {
                await testEventsRaised.AssertContainerCompletedWithFailedCheckContinue(preexistingFileCount);

                // Verify all files exist, meaning files without conflict were transferred.
                List<string> localFiles = (await TransferValidator.GetLocalFileLister(disposingLocalDirectory.DirectoryPath)
                    .Invoke(cancellationToken))
                    .Select(item => item.RelativePath)
                    .ToList();
                List<string> destinationObjects = (await GetStorageResourceLister(test.Container)
                    .Invoke(cancellationToken))
                    .Select(item => item.RelativePath)
                    .ToList();
                Assert.That(localFiles, Is.EquivalentTo(destinationObjects));
            }
            else if (errorMode == DataTransferErrorMode.StopOnAnyFailure)
            {
                Assert.That(transfer.TransferStatus.HasFailedItems, Is.True);
            }
        }

        [RecordedTest]
        [Test]
        public async Task UploadSkipIfExists()
        {
            const int waitTimeInSec = 15;
            const int preexistingFileCount = 2;
            const int skipCount = 1;
            const int totalFileCount = skipCount + preexistingFileCount + 1;
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<string> files = new();
            foreach (var _ in Enumerable.Range(0, totalFileCount))
            {
                files.Add(GetNewObjectName());
            }

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await InitializeDestinationDataAsync(
                test.Container,
                files.Skip(skipCount).Take(preexistingFileCount).Select(path => (path, DefaultObjectSize)).ToList(),
                cancellationToken);
            await SetupDirectoryAsync(
                disposingLocalDirectory.DirectoryPath,
                files.Select(path => (path, DefaultObjectSize)).ToList(),
            cancellationToken);

            DataTransferOptions options = new()
            {
                CreationPreference = StorageResourceCreationPreference.SkipIfExists
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManagerOptions transferManagerOptions = new()
            {
                ErrorHandling = DataTransferErrorMode.ContinueOnFailure
            };

            StorageResourceContainer sourceResource = LocalResourceProvider.FromDirectory(disposingLocalDirectory.DirectoryPath);
            StorageResourceContainer destinationResource = GetStorageResourceContainer(test.Container);
            DataTransfer transfer = await new TransferManager(transferManagerOptions)
                .StartTransferAsync(sourceResource, destinationResource, options, cancellationToken);
            await TestTransferWithTimeout.WaitForCompletionAsync(
                transfer,
                testEventsRaised,
                cancellationToken);

            // check if expected files exist, but not necessarily for contents
            await testEventsRaised.AssertContainerCompletedWithSkippedCheck(preexistingFileCount);

            // Verify all files exist, meaning files without conflict were transferred.
            List<string> localFiles = (await TransferValidator.GetLocalFileLister(disposingLocalDirectory.DirectoryPath)
                .Invoke(cancellationToken))
                .Select(item => item.RelativePath)
                .ToList();
            List<string> destinationObjects = (await GetStorageResourceLister(test.Container)
                .Invoke(cancellationToken))
                .Select(item => item.RelativePath)
                .ToList();
            Assert.That(localFiles, Is.EquivalentTo(destinationObjects));
        }

        [RecordedTest]
        [Test]
        public async Task UploadOverwriteIfExists()
        {
            const int waitTimeInSec = 15;
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<string> files = new()
            {
                GetNewObjectName(),
                GetNewObjectName(),
            };

            DataTransferOptions options = new()
            {
                CreationPreference = StorageResourceCreationPreference.OverwriteIfExists
            };
            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await InitializeDestinationDataAsync(
                test.Container,
                files.Take(1).Select(path => (path, DefaultObjectSize)).ToList(),
                cancellationToken);
            await SetupDirectoryAsync(
                disposingLocalDirectory.DirectoryPath,
                files.Select(path => (path, DefaultObjectSize)).ToList(),
                cancellationToken);
            await UploadDirectoryAndVerifyAsync(
                disposingLocalDirectory.DirectoryPath,
                test.Container,
                expectedTransfers: files.Count,
                options: options,
                cancellationToken: cancellationToken);
        }

        [RecordedTest]
        [TestCase(Constants.KB, Constants.KB/4, 10)]
        [TestCase(10 * Constants.KB, 4 * Constants.KB, 15)]
        [TestCase(Constants.KB, 97, 10)]
        public async Task UploadSmallChunks(long objectSize, long chunkSize, int waitTimeInSec)
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<string> files = new()
            {
                GetNewObjectName(),
                GetNewObjectName(),
            };

            DataTransferOptions options = new()
            {
                InitialTransferSize = chunkSize,
                MaximumTransferChunkSize = chunkSize,
            };

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await SetupDirectoryAsync(
                disposingLocalDirectory.DirectoryPath,
                files.Select(path => (path, objectSize)).ToList(),
                cancellationToken);
            await UploadDirectoryAndVerifyAsync(
                disposingLocalDirectory.DirectoryPath,
                test.Container,
                expectedTransfers: files.Count,
                cancellationToken: cancellationToken);
        }

        [RecordedTest]
        [TestCase(1, 10)]
        [TestCase(5, 30)]
        public async Task UploadEmpty(int folderDepth, int waitTimeInSec)
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            void BuildFolders(string path, int depth)
            {
                if (depth < 1)
                {
                    return;
                }
                for (int i = 0; i < 2; i++)
                {
                    string subDirPath = Path.Combine(path, GetNewObjectName());
                    Directory.CreateDirectory(subDirPath);
                    BuildFolders(subDirPath, depth - 1);
                }
            }
            BuildFolders(disposingLocalDirectory.DirectoryPath, folderDepth);

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await UploadDirectoryAndVerifyAsync(
                disposingLocalDirectory.DirectoryPath,
                test.Container,
                expectedTransfers: 0,
                cancellationToken: cancellationToken);
        }

        [Ignore("Times out on linux/mac, currently unsure why.")]
        [RecordedTest]
        [TestCase(1, 5)]
        [TestCase(3, 10)]
        public async Task UploadManySubdirectories(int folderDepth, int waitTimeInSec)
        {
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<string> files = new();
            void BuildFilePaths(string path, int depth)
            {
                if (depth < 1)
                {
                    files.Add(Path.Combine(path, GetNewObjectName()));
                    return;
                }
                for (int i = 0; i < 2; i++)
                {
                    BuildFilePaths(Path.Combine(path, GetNewObjectName()), depth - 1);
                }
            }
            BuildFilePaths(disposingLocalDirectory.DirectoryPath, folderDepth);

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await SetupDirectoryAsync(
                disposingLocalDirectory.DirectoryPath,
                files.Select(path => (path, DefaultObjectSize)).ToList(),
                cancellationToken);
            await UploadDirectoryAndVerifyAsync(
                disposingLocalDirectory.DirectoryPath,
                test.Container,
                expectedTransfers: 1 << folderDepth,
                cancellationToken: cancellationToken);
        }

        [RecordedTest]
        [TestCase(1)]
        [TestCase(5)]
        public async Task UploadSingleFile(int folderDepth)
        {
            const int waitTimeInSec = 5;
            // Arrange
            using DisposingLocalDirectory disposingLocalDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<TContainerClient> test = await GetDisposingContainerAsync();

            List<string> files = new()
            {
                string.Join(Path.DirectorySeparatorChar.ToString(), Enumerable.Range(0, folderDepth).Select(_ => GetNewObjectName()).ToList())
            };

            CancellationToken cancellationToken = TestHelper.GetTimeoutToken(waitTimeInSec);
            await SetupDirectoryAsync(
                disposingLocalDirectory.DirectoryPath,
                files.Select(path => (path, DefaultObjectSize)).ToList(),
                cancellationToken);
            await UploadDirectoryAndVerifyAsync(
                disposingLocalDirectory.DirectoryPath,
                test.Container,
                expectedTransfers: 1,
                cancellationToken: cancellationToken);
        }
    }
}
