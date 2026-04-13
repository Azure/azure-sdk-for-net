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
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.Tests;
using Azure.Storage.Test.Shared;
using BaseShares::Azure.Storage.Files.Shares;
using BaseShares::Azure.Storage.Files.Shares.Models;
using BaseShares::Azure.Storage.Sas;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using System.Diagnostics.Tracing;
using NUnit.Framework;
using Metadata = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture]
    public class ShareFilePauseResumeTransferTests : PauseResumeTransferTestBase
        <ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        protected readonly ShareClientOptions.ServiceVersion _serviceVersion;

        public ShareFilePauseResumeTransferTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
            _serviceVersion = serviceVersion;
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(
            string containerName = default,
            ShareServiceClient service = default)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override StorageResourceProvider GetStorageResourceProvider()
            => new ShareFilesStorageResourceProvider(TestEnvironment.Credential);

        protected override StorageResourceProvider GetContainerSasStorageResourceProvider(ShareClient sourceContainer, ShareClient destinationContainer)
        {
            // Create Source Container SAS
            Uri sourceSasUri = sourceContainer.GenerateSasUri(
                ShareSasPermissions.All,
                DateTimeOffset.UtcNow.AddHours(1));
            string sourceSas = new ShareUriBuilder(sourceSasUri).Sas.ToString();

            // Create Destination Container SAS
            Uri destinationSasUri = destinationContainer.GenerateSasUri(
                ShareSasPermissions.All,
                DateTimeOffset.UtcNow.AddHours(1));
            string destinationSas = new ShareUriBuilder(destinationSasUri).Sas.ToString();

            // Create the provider with a delegate that returns the right SAS per URI
            Func<Uri, CancellationToken, ValueTask<AzureSasCredential>> getSasCredential = (uri, ct) =>
            {
                var builder = new ShareUriBuilder(uri);
                if (builder.ShareName == sourceContainer.Name)
                    return new ValueTask<AzureSasCredential>(new AzureSasCredential(sourceSas));
                if (builder.ShareName == destinationContainer.Name)
                    return new ValueTask<AzureSasCredential>(new AzureSasCredential(destinationSas));
                throw new InvalidOperationException($"Unknown container: {builder.ShareName}");
            };
            return new ShareFilesStorageResourceProvider(getSasCredential);
        }

        protected override async Task<StorageResource> CreateSourceStorageResourceItemAsync(
            long size,
            string fileName,
            ShareClient container)
        {
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            await fileClient.CreateAsync(size);
            // create a new file and copy contents of stream into it, and then close the FileStream
            using (Stream originalStream = await CreateLimitedMemoryStream(size))
            {
                originalStream.Position = 0;
                await fileClient.UploadAsync(originalStream);
            }
            return ShareFilesStorageResourceProvider.FromClient(fileClient);
        }

        protected override StorageResource CreateDestinationStorageResourceItem(
            string fileName,
            ShareClient container,
            Metadata metadata = default,
            string contentLanguage = default)
        {
            ShareFileStorageResourceOptions testOptions = new()
            {
                FileMetadata = metadata,
                ContentLanguage = contentLanguage is null ? null : new[] { contentLanguage }
            };
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            return ShareFilesStorageResourceProvider.FromClient(fileClient, testOptions);
        }

        protected override async Task AssertDestinationProperties(
            string fileName,
            Metadata expectedMetadata,
            string expectedContentLanguage,
            ShareClient container)
        {
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            ShareFileProperties props = (await fileClient.GetPropertiesAsync()).Value;
            Assert.That(props.Metadata, Is.EqualTo(expectedMetadata));
            Assert.That(props.ContentLanguage.First, Is.EqualTo(expectedContentLanguage));
        }

        protected override async Task<Stream> GetStreamFromContainerAsync(Uri uri, ShareClient container)
        {
            var uriBuilder = new ShareUriBuilder(uri);
            string fileName = uriBuilder.DirectoryOrFilePath;
            ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(fileName);
            if (!await fileClient.ExistsAsync())
            {
                throw new FileNotFoundException($"File not found: {uri}");
            }

            // Download the file to a MemoryStream
            ShareFileDownloadInfo downloadInfo = await fileClient.DownloadAsync();
            MemoryStream memoryStream = new MemoryStream();
            await downloadInfo.Content.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }

        protected override async Task<StorageResource> CreateSourceStorageResourceContainerAsync(
            long size,
            int count,
            string directoryPath,
            ShareClient container)
        {
            for (int i = 0; i < count; i++)
            {
                ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(GetNewItemName());
                await fileClient.CreateAsync(size);
                // create a new file and copy contents of stream into it, and then close the FileStream
                using (Stream originalStream = await CreateLimitedMemoryStream(size))
                {
                    originalStream.Position = 0;
                    await fileClient.UploadAsync(originalStream);
                }
            }
            return ShareFilesStorageResourceProvider.FromClient(container.GetRootDirectoryClient());
        }

        protected override StorageResource CreateDestinationStorageResourceContainer(
            ShareClient container)
        {
            return ShareFilesStorageResourceProvider.FromClient(container.GetRootDirectoryClient());
        }

        protected override ShareServiceClient GetAzureSasCredentialServiceClient()
            => ClientBuilder.GetServiceClientFromAzureSasCredentialConfig(Tenants.TestConfigDefault, default);

        /// <summary>
        /// Stress test for pause/resume with multiple subdirectories and files.
        /// Creates a configurable directory tree in a source share, starts a copy
        /// transfer, pauses and resumes multiple times, then verifies every file
        /// was transferred.
        /// </summary>
        //[Ignore("Stress test – run manually to repro missing-file bugs after pause/resume.")]
        [Test, Pairwise]
        [LiveOnly]
        public async Task MultiplePauseResume_DirectoryTree_Copy(
            [Values(3)] int subdirectoryCount,
            [Values(5)] int filesPerDirectory,
            [Values(3)] int pauseCount,
            [Values(0, 500)] int delayBeforePauseMs)
        {
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (args, message) =>
                {
                    if (args.EventSource.Name == "Azure-Storage-DataMovement")
                    {
                        TestContext.Out.WriteLine(message);
                    }
                },
                EventLevel.Verbose);
            // ── Arrange ──────────────────────────────────────────────────
            string MakeSubdirName(int index) => $"subdir-{index}";
            string MakeTestFileName(int index) => $"file-{index}.bin";
            int totalFileCount = subdirectoryCount * filesPerDirectory;
            long fileSize = DataMovementTestConstants.KB * 4;

            using DisposingLocalDirectory checkpointerDirectory = DisposingLocalDirectory.GetTestDirectory();
            await using IDisposingContainer<ShareClient> sourceContainer = await GetDisposingContainerAsync();
            await using IDisposingContainer<ShareClient> destinationContainer = await GetDisposingContainerAsync();

            StorageResourceProvider provider = GetStorageResourceProvider();
            TransferManagerOptions managerOptions = new TransferManagerOptions()
            {
                CheckpointStoreOptions = TransferCheckpointStoreOptions.CreateLocalStore(checkpointerDirectory.DirectoryPath),
                ErrorMode = TransferErrorMode.ContinueOnFailure,
                ProvidersForResuming = new List<StorageResourceProvider>() { provider },
            };
            TransferManager transferManager = new TransferManager(managerOptions);

            // ── Build source directory tree ──────────────────────────────
            // Structure: rootDir / subdir-N / file-M
            ShareDirectoryClient rootDir = sourceContainer.Container.GetRootDirectoryClient();
            List<string> expectedRelativePaths = new();

            for (int d = 0; d < subdirectoryCount; d++)
            {
                string subdirName = MakeSubdirName(d);
                ShareDirectoryClient subDir = rootDir.GetSubdirectoryClient(subdirName);
                await subDir.CreateIfNotExistsAsync();

                for (int f = 0; f < filesPerDirectory; f++)
                {
                    ShareFileClient file = subDir.GetFileClient(MakeTestFileName(f));
                    await file.CreateAsync(fileSize);

                    using Stream data = await CreateLimitedMemoryStream(fileSize);
                    data.Position = 0;
                    await file.UploadAsync(data);

                    expectedRelativePaths.Add($"{subdirName}/{MakeTestFileName(f)}");
                }
            }

            // ── Create source / destination storage resources ────────────
            StorageResource sourceResource = ShareFilesStorageResourceProvider.FromClient(rootDir);
            StorageResource destinationResource = ShareFilesStorageResourceProvider.FromClient(
                destinationContainer.Container.GetRootDirectoryClient());

            // ── Start transfer and pause/resume loop ─────────────────────
            TransferOptions transferOptions = new TransferOptions()
            {
                InitialTransferSize = DataMovementTestConstants.KB,
                MaximumTransferChunkSize = DataMovementTestConstants.KB,
                CreationMode = StorageResourceCreationMode.OverwriteIfExists,
            };
            TestEventsRaised testEventsRaised = new TestEventsRaised(transferOptions);

            TransferOperation transfer = await transferManager.StartTransferAsync(
                sourceResource,
                destinationResource,
                transferOptions);

            string transferId = transfer.Id;

            for (int pause = 0; pause < pauseCount; pause++)
            {
                // Allow some progress before pausing
                if (delayBeforePauseMs > 0)
                {
                    await Task.Delay(delayBeforePauseMs);
                }

                // If the transfer already completed, no need to keep pausing
                if (transfer.HasCompleted)
                {
                    break;
                }

                // Pause
                using CancellationTokenSource pauseCts = new CancellationTokenSource(TimeSpan.FromSeconds(60));
                try
                {
                    Console.WriteLine("[TestConsole] Pausing transfer...");
                    await transferManager.PauseTransferAsync(transferId, pauseCts.Token);
                }
                catch (ArgumentException)
                {
                    // Transfer may have already completed or been paused; continue
                    if (transfer.HasCompleted)
                    {
                        break;
                    }
                    continue;
                }

                Assert.AreEqual(
                    TransferState.Paused,
                    transfer.Status.State,
                    $"Expected Paused after pause #{pause + 1}, but got {transfer.Status.State}");

                // Resume
                TransferOptions resumeOptions = new TransferOptions()
                {
                    CreationMode = StorageResourceCreationMode.OverwriteIfExists,
                };
                Console.WriteLine("[TestConsole] Resuming transfer...");
                transfer = await transferManager.ResumeTransferAsync(
                    transferId: transferId,
                    transferOptions: resumeOptions);
            }

            // ── Wait for final completion ────────────────────────────────
            using CancellationTokenSource completionCts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
            await transfer.WaitForCompletionAsync(completionCts.Token);

            testEventsRaised.AssertUnexpectedFailureCheck();

            // ── Verify every source file exists in the destination ────────
            ShareDirectoryClient destRoot = destinationContainer.Container.GetRootDirectoryClient();
            List<string> actualRelativePaths = new();

            for (int d = 0; d < subdirectoryCount; d++)
            {
                string subdirName = $"subdir-{d}";
                ShareDirectoryClient destSubDir = destRoot.GetSubdirectoryClient(subdirName);

                await foreach (ShareFileItem item in destSubDir.GetFilesAndDirectoriesAsync())
                {
                    if (!item.IsDirectory)
                    {
                        actualRelativePaths.Add($"{subdirName}/{item.Name}");
                    }
                }
            }

            Assert.AreEqual(totalFileCount, actualRelativePaths.Count,
                $"Expected {totalFileCount} files in destination but found {actualRelativePaths.Count}.\n" +
                $"Missing: {string.Join(", ", expectedRelativePaths.Except(actualRelativePaths))}\n" +
                $"Extra:   {string.Join(", ", actualRelativePaths.Except(expectedRelativePaths))}");
            Assert.That(actualRelativePaths, Is.EquivalentTo(expectedRelativePaths));

            // ── Verify content of each file matches ──────────────────────
            for (int d = 0; d < subdirectoryCount; d++)
            {
                string subdirName = MakeSubdirName(d);
                ShareDirectoryClient srcSubDir = rootDir.GetSubdirectoryClient(subdirName);
                ShareDirectoryClient destSubDir = destRoot.GetSubdirectoryClient(subdirName);

                for (int f = 0; f < filesPerDirectory; f++)
                {
                    string fileName = $"file-{f}.bin";
                    ShareFileClient srcFile = srcSubDir.GetFileClient(fileName);
                    ShareFileClient destFile = destSubDir.GetFileClient(fileName);

                    Assert.IsTrue(
                        await destFile.ExistsAsync(),
                        $"Destination file missing: {subdirName}/{fileName}");

                    ShareFileDownloadInfo srcDownload = await srcFile.DownloadAsync();
                    ShareFileDownloadInfo destDownload = await destFile.DownloadAsync();

                    using MemoryStream srcStream = new MemoryStream();
                    using MemoryStream destStream = new MemoryStream();
                    await srcDownload.Content.CopyToAsync(srcStream);
                    await destDownload.Content.CopyToAsync(destStream);

                    Assert.AreEqual(srcStream.Length, destStream.Length,
                        $"Content length mismatch for {subdirName}/{fileName}");
                    Assert.IsTrue(
                        srcStream.ToArray().SequenceEqual(destStream.ToArray()),
                        $"Content mismatch for {subdirName}/{fileName}");
                }
            }
        }
    }
}
