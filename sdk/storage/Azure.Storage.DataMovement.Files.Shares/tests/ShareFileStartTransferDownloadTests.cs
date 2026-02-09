// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
extern alias BaseShares;
extern alias DMShare;

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Tests;
using BaseShares::Azure.Storage.Files.Shares;
using Azure.Storage.Test.Shared;
using DMShare::Azure.Storage.DataMovement.Files.Shares;
using NUnit.Framework;
using System.Threading;
using Azure.Core.TestFramework;
using BaseShares::Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares.Tests
{
    [DataMovementShareClientTestFixture]
    public class ShareFileStartTransferDownloadTests : StartTransferDownloadTestBase<
        ShareServiceClient,
        ShareClient,
        ShareFileClient,
        ShareClientOptions,
        StorageTestEnvironment>
    {
        private const string _fileResourcePrefix = "test-file-";
        private const string _expectedOverwriteExceptionMessage = "Cannot overwrite file.";

        public ShareFileStartTransferDownloadTests(
            bool async,
            ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, _expectedOverwriteExceptionMessage, _fileResourcePrefix, null /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewShareClientBuilder(Tenants, serviceVersion);
        }

        protected override async Task<IDisposingContainer<ShareClient>> GetDisposingContainerAsync(ShareServiceClient service = null, string containerName = null)
            => await ClientBuilder.GetTestShareAsync(service, containerName);

        protected override async Task<ShareFileClient> GetObjectClientAsync(
            ShareClient container,
            long? objectLength,
            string objectName,
            bool createObject = false,
            ShareClientOptions options = null,
            Stream contents = null)
        {
            objectName ??= GetNewObjectName();
            if (createObject)
            {
                if (!objectLength.HasValue)
                {
                    throw new InvalidOperationException($"Cannot create share file without size specified.");
                }
                ShareFileClient fileClient = container.GetRootDirectoryClient().GetFileClient(objectName);
                await fileClient.CreateAsync(objectLength.Value);

                if (contents != default && contents.Length > 0)
                {
                    await fileClient.UploadAsync(contents);
                }

                return fileClient;
            }
            return container.GetRootDirectoryClient().GetFileClient(objectName);
        }

        protected override StorageResourceItem GetStorageResourceItem(ShareFileClient objectClient)
            => new ShareFileStorageResource(objectClient);

        protected override Task<Stream> OpenReadAsync(ShareFileClient objectClient)
            => objectClient.OpenReadAsync();

        private bool StreamsAreEqual(Stream s1, Stream s2)
        {
            if (s1.Length != s2.Length)
                return false;

            s1.Position = 0;
            s2.Position = 0;

            int byte1, byte2;
            do
            {
                byte1 = s1.ReadByte();
                byte2 = s2.ReadByte();
                if (byte1 != byte2)
                    return false;
            } while (byte1 != -1);

            return true;
        }

        [RecordedTest]
        public async Task ShareFileToLocalFile_NfsHardLink()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await ClientBuilder.GetTestShareSasNfsAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            ShareDirectoryClient directory = source.Container.GetRootDirectoryClient();
            ShareFileClient originalClient = await GetObjectClientAsync(
                container: source.Container,
                objectLength: DataMovementTestConstants.KB,
                objectName: "original",
                createObject: true);
            ShareFileClient hardlinkClient = InstrumentClient(directory.GetFileClient("original-hardlink"));

            // Create Hardlink
            await hardlinkClient.CreateHardLinkAsync(
                targetFile: $"{directory.Name}/{originalClient.Name}");

            // Assert hardlink was successfully created
            ShareFileProperties sourceProperties = await hardlinkClient.GetPropertiesAsync();
            Assert.AreEqual(2, sourceProperties.PosixProperties.LinkCount);
            Assert.AreEqual(NfsFileType.Regular, sourceProperties.PosixProperties.FileType);

            // Use the hardlink to create the source file
            StorageResource sourceResource = new ShareFileStorageResource(hardlinkClient,
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            // Create destination local file
            string destFile = Path.Combine(destination.DirectoryPath, GetNewObjectName());
            StorageResource destinationResource = LocalFilesStorageResourceProvider.FromFile(destFile);

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManager transferManager = new TransferManager();

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
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            await testEventsRaised.AssertSingleCompletedCheck();

            // Assert dest was copied as regular file
            bool destExists = File.Exists(destinationResource.Uri.LocalPath);
            Assert.IsTrue(destExists);
            using Stream sourceStream = await hardlinkClient.OpenReadAsync();
            using Stream destinationStream = File.OpenRead(destinationResource.Uri.LocalPath);
            Assert.AreEqual(sourceStream.Length, destinationStream.Length);
            Assert.IsTrue(StreamsAreEqual(sourceStream, destinationStream));
        }

        [RecordedTest]
        public async Task ShareFileToLocalFile_NfsSymbolicLink()
        {
            // Arrange
            await using IDisposingContainer<ShareClient> source = await ClientBuilder.GetTestShareSasNfsAsync();
            using DisposingLocalDirectory destination = DisposingLocalDirectory.GetTestDirectory();

            ShareDirectoryClient directory = source.Container.GetRootDirectoryClient();
            ShareFileClient originalClient = await GetObjectClientAsync(
                container: source.Container,
                objectLength: DataMovementTestConstants.KB,
                objectName: "original",
                createObject: true);
            ShareFileClient symlinkClient = InstrumentClient(directory.GetFileClient("original-symlink"));

            // Create Symlink
            await symlinkClient.CreateSymbolicLinkAsync(linkText: originalClient.Uri.AbsolutePath);

            // Assert symlink was successfully created
            ShareFileProperties sourceProperties = await symlinkClient.GetPropertiesAsync();
            Assert.AreEqual(1, sourceProperties.PosixProperties.LinkCount);
            Assert.AreEqual(NfsFileType.SymLink, sourceProperties.PosixProperties.FileType);

            // Use the symlink to create the source file
            StorageResourceItem sourceResource = new ShareFileStorageResource(symlinkClient,
                new ShareFileStorageResourceOptions() { ShareProtocol = ShareProtocol.Nfs });

            // Create destination local file
            string destFile = Path.Combine(destination.DirectoryPath, GetNewObjectName());
            StorageResource destinationResource = LocalFilesStorageResourceProvider.FromFile(destFile);

            TransferOptions options = new TransferOptions();
            TestEventsRaised testEventsRaised = new TestEventsRaised(options);
            TransferManager transferManager = new TransferManager();

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
            Assert.NotNull(transfer);
            Assert.IsTrue(transfer.HasCompleted);
            Assert.AreEqual(TransferState.Completed, transfer.Status.State);
            await testEventsRaised.AssertSingleCompletedCheck();

            // Assert the Symlink was skipped and not copied
            bool destExists = File.Exists(destinationResource.Uri.LocalPath);
            Assert.IsFalse(destExists);
        }
    }
}
