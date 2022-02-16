// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Specialized;
using Azure.Storage.Test;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    internal class ClientNavigationTests : FileTestBase
    {
        public ClientNavigationTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task PathClient_CanGetParentContainerClient()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareFileClient fileClient = InstrumentClient(test.Container.GetRootDirectoryClient().GetFileClient(SharesClientBuilder.GetNewFileName()));

            // Act
            ShareClient filesystemClient = fileClient.GetParentShareClient();
            // make sure that client is functional
            var containerProperties = await filesystemClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileClient.ShareName, filesystemClient.Name);
            Assert.AreEqual(fileClient.AccountName, filesystemClient.AccountName);
            Assert.IsNotNull(containerProperties);
        }

        [RecordedTest]
        public async Task PathClient_CanGetParentContainerClient_WithContainerSAS()
        {
            // Arrange
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            var fileName = SharesClientBuilder.GetNewFileName();
            ShareFileClient fileClient = InstrumentClient(
                GetServiceClient_FileServiceSasShare(test.Container.Name)
                .GetShareClient(test.Share.Name)
                .GetRootDirectoryClient()
                .GetFileClient(fileName));

            // Act
            var fileSystemClient = fileClient.GetParentShareClient();
            // make sure that client is functional
            var pathItems = await fileSystemClient.GetRootDirectoryClient().GetFilesAndDirectoriesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(fileClient.ShareName, fileSystemClient.Name);
            Assert.AreEqual(fileClient.AccountName, fileSystemClient.AccountName);
            Assert.IsNotNull(pathItems);
        }

        [RecordedTest]
        public void PathClient_CanMockParentContainerClientRetrieval()
        {
            // Arrange
            Mock<ShareFileClient> fileClientMock = new Mock<ShareFileClient>();
            Mock<ShareClient> fileSystemClientMock = new Mock<ShareClient>();
            fileClientMock.Protected().Setup<ShareClient>("GetParentShareClientCore").Returns(fileSystemClientMock.Object);

            // Act
            var fileSystemClient = fileClientMock.Object.GetParentShareClientCore();

            // Assert
            Assert.IsNotNull(fileSystemClient);
            Assert.AreSame(fileSystemClientMock.Object, fileSystemClient);
        }

        [RecordedTest]
        public async Task PathClient_CanGetParentDirectoryClient()
        {
            // Arrange
            var parentDirName = SharesClientBuilder.GetNewDirectoryName();
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            ShareDirectoryClient parentDirClient = InstrumentClient(test.Container
                .GetRootDirectoryClient()
                .GetSubdirectoryClient(parentDirName));
            await parentDirClient.CreateAsync();
            ShareFileClient fileClient = InstrumentClient(parentDirClient
                .GetFileClient(SharesClientBuilder.GetNewFileName()));
            await fileClient.CreateAsync(Constants.KB);

            // Act
            parentDirClient = fileClient.GetParentShareDirectoryClient();
            // make sure that client is functional
            var dirProperties = await parentDirClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileClient.Path.GetParentPath(), parentDirClient.Path);
            Assert.AreEqual(fileClient.AccountName, parentDirClient.AccountName);
            Assert.IsNotNull(dirProperties);
        }

        [RecordedTest]
        public async Task PathClient_CanGetParentDirectoryClient_WithContainerSAS()
        {
            // Arrange
            var parentDirName = SharesClientBuilder.GetNewDirectoryName();
            await using DisposingShare test = await SharesClientBuilder.GetTestShareAsync();
            var fileName = SharesClientBuilder.GetNewFileName();
            ShareDirectoryClient parentDirClient = InstrumentClient(
                GetServiceClient_FileServiceSasShare(test.Container.Name)
                .GetShareClient(test.Share.Name)
                .GetRootDirectoryClient()
                .GetSubdirectoryClient(parentDirName));
            await parentDirClient.CreateAsync();
            ShareFileClient fileClient = InstrumentClient(parentDirClient
                .GetFileClient(SharesClientBuilder.GetNewFileName()));
            await fileClient.CreateAsync(Constants.KB);

            // Act
            parentDirClient = fileClient.GetParentShareDirectoryClient();
            // make sure that client is functional
            var pathItems = await parentDirClient.GetFilesAndDirectoriesAsync().ToListAsync();

            // Assert
            Assert.AreEqual(fileClient.Path.GetParentPath(), parentDirClient.Path);
            Assert.AreEqual(fileClient.AccountName, parentDirClient.AccountName);
            Assert.IsNotNull(pathItems);
        }

        [RecordedTest]
        public void PathClient_CanMockParentDirectoryClientRetrieval()
        {
            // Arrange
            Mock<ShareFileClient> fileClientMock = new Mock<ShareFileClient>();
            Mock<ShareClient> fileSystemClientMock = new Mock<ShareClient>();
            fileClientMock.Protected().Setup<ShareClient>("GetParentShareClientCore").Returns(fileSystemClientMock.Object);

            // Act
            var fileSystemClient = fileClientMock.Object.GetParentShareClientCore();

            // Assert
            Assert.IsNotNull(fileSystemClient);
            Assert.AreSame(fileSystemClientMock.Object, fileSystemClient);
        }

        [RecordedTest]
        public void PathClient_CanGenerateSas_GetParentShareClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var endpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var secondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (endpoint, secondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - BlobBaseClient(string connectionString, string blobContainerName, string blobName)
            ShareFileClient file = InstrumentClient(new ShareFileClient(
                connectionString,
                GetNewShareName(),
                $"{GetNewDirectoryName()}/{GetNewFileName()}"));
            ShareClient fileSystem = file.GetParentShareClient();
            Assert.IsTrue(fileSystem.CanGenerateSasUri);

            // Act - BlobBaseClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            ShareFileClient file2 = InstrumentClient(new ShareFileClient(
                connectionString,
                GetNewShareName(),
                $"{GetNewDirectoryName()}/{GetNewFileName()}",
                GetOptions()));
            ShareClient fileSystem2 = file2.GetParentShareClient();
            Assert.IsTrue(fileSystem2.CanGenerateSasUri);

            // Act - BlobBaseClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareFileClient file3 = InstrumentClient(new ShareFileClient(
                endpoint,
                GetOptions()));
            ShareClient container3 = file3.GetParentShareClient();
            Assert.IsFalse(container3.CanGenerateSasUri);

            // Act - BlobBaseClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareFileClient file4 = InstrumentClient(new ShareFileClient(
                endpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            ShareClient container4 = file4.GetParentShareClient();
            Assert.IsTrue(container4.CanGenerateSasUri);
        }
    }
}
