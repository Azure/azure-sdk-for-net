// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.DataLake.Specialized;
using Azure.Storage.Test;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class ClientNavigationTests : DataLakeTestBase
    {
        public ClientNavigationTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task PathClient_CanGetParentContainerClient()
        {
            // Arrange
            await using DisposingFileSystem test = await DataLakeClientBuilder.GetNewFileSystem();
            DataLakeFileClient fileClient = InstrumentClient(test.Container.GetRootDirectoryClient().GetFileClient(DataLakeClientBuilder.GetNewFileName()));

            // Act
            DataLakeFileSystemClient filesystemClient = fileClient.GetParentFileSystemClient();
            // make sure that client is functional
            var containerProperties = await filesystemClient.GetPropertiesAsync();

            // Assert
            Assert.That(filesystemClient.Name, Is.EqualTo(fileClient.FileSystemName));
            Assert.That(filesystemClient.AccountName, Is.EqualTo(fileClient.AccountName));
            Assert.That(containerProperties, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task PathClient_CanGetParentContainerClient_WithAccountSAS()
        {
            // Arrange
            await using DisposingFileSystem test = await DataLakeClientBuilder.GetNewFileSystem();
            var fileName = DataLakeClientBuilder.GetNewFileName();
            DataLakeFileClient fileClient = InstrumentClient(
                GetServiceClient_AccountSas()
                .GetFileSystemClient(test.FileSystem.Name)
                .GetRootDirectoryClient()
                .GetFileClient(fileName));

            // Act
            var fileSystemClient = fileClient.GetParentFileSystemClient();
            // make sure that client is functional
            var fileSystemProperties = await fileSystemClient.GetPropertiesAsync();

            // Assert
            Assert.That(fileSystemClient.Name, Is.EqualTo(fileClient.FileSystemName));
            Assert.That(fileSystemClient.AccountName, Is.EqualTo(fileClient.AccountName));
            Assert.That(fileSystemProperties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task PathClient_CanGetParentContainerClient_WithContainerSAS()
        {
            // Arrange
            await using DisposingFileSystem test = await DataLakeClientBuilder.GetNewFileSystem();
            var fileName = DataLakeClientBuilder.GetNewFileName();
            DataLakeFileClient fileClient = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_FileSystem(test.Container.Name)
                .GetFileSystemClient(test.FileSystem.Name)
                .GetRootDirectoryClient()
                .GetFileClient(fileName));

            // Act
            var fileSystemClient = fileClient.GetParentFileSystemClient();
            // make sure that client is functional
            var pathItems = await fileSystemClient.GetPathsAsync().ToListAsync();

            // Assert
            Assert.That(fileSystemClient.Name, Is.EqualTo(fileClient.FileSystemName));
            Assert.That(fileSystemClient.AccountName, Is.EqualTo(fileClient.AccountName));
            Assert.That(pathItems, Is.Not.Null);
        }

        [RecordedTest]
        public void PathClient_CanMockParentContainerClientRetrieval()
        {
            // Arrange
            Mock<DataLakeFileClient> fileClientMock = new Mock<DataLakeFileClient>();
            Mock<DataLakeFileSystemClient> fileSystemClientMock = new Mock<DataLakeFileSystemClient>();
            fileClientMock.Protected().Setup<DataLakeFileSystemClient>("GetParentFileSystemClientCore").Returns(fileSystemClientMock.Object);

            // Act
            var fileSystemClient = fileClientMock.Object.GetParentFileSystemClientCore();

            // Assert
            Assert.That(fileSystemClient, Is.Not.Null);
            Assert.That(fileSystemClient, Is.SameAs(fileSystemClientMock.Object));
        }

        [RecordedTest]
        public async Task PathClient_CanGetParentDirectoryClient()
        {
            // Arrange
            var parentDirName = DataLakeClientBuilder.GetNewDirectoryName();
            await using DisposingFileSystem test = await DataLakeClientBuilder.GetNewFileSystem();
            DataLakeFileClient fileClient = InstrumentClient(test.Container
                .GetRootDirectoryClient()
                .GetSubDirectoryClient(parentDirName)
                .GetFileClient(DataLakeClientBuilder.GetNewFileName()));
            await fileClient.CreateAsync();

            // Act
            DataLakeDirectoryClient parentDirClient = fileClient.GetParentDirectoryClient();
            // make sure that client is functional
            var dirProperties = await parentDirClient.GetPropertiesAsync();

            // Assert
            Assert.That(parentDirClient.Path, Is.EqualTo(fileClient.Path.GetParentPath()));
            Assert.That(parentDirClient.AccountName, Is.EqualTo(fileClient.AccountName));
            Assert.That(dirProperties, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        public async Task PathClient_CanGetParentDirectoryClient_WithAccountSAS()
        {
            // Arrange
            var parentDirName = DataLakeClientBuilder.GetNewDirectoryName();
            await using DisposingFileSystem test = await DataLakeClientBuilder.GetNewFileSystem();
            var fileName = DataLakeClientBuilder.GetNewFileName();
            DataLakeFileClient fileClient = InstrumentClient(
                GetServiceClient_AccountSas()
                .GetFileSystemClient(test.FileSystem.Name)
                .GetRootDirectoryClient()
                .GetSubDirectoryClient(parentDirName)
                .GetFileClient(fileName));
            await fileClient.CreateAsync();

            // Act
            DataLakeDirectoryClient parentDirClient = fileClient.GetParentDirectoryClient();
            // make sure that client is functional
            var dirProperties = await parentDirClient.GetPropertiesAsync();

            // Assert
            Assert.That(parentDirClient.Path, Is.EqualTo(fileClient.Path.GetParentPath()));
            Assert.That(parentDirClient.AccountName, Is.EqualTo(fileClient.AccountName));
            Assert.That(dirProperties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task PathClient_CanGetParentDirectoryClient_WithContainerSAS()
        {
            // Arrange
            var parentDirName = DataLakeClientBuilder.GetNewDirectoryName();
            await using DisposingFileSystem test = await DataLakeClientBuilder.GetNewFileSystem();
            var fileName = DataLakeClientBuilder.GetNewFileName();
            DataLakeFileClient fileClient = InstrumentClient(
                GetServiceClient_DataLakeServiceSas_FileSystem(test.Container.Name)
                .GetFileSystemClient(test.FileSystem.Name)
                .GetRootDirectoryClient()
                .GetSubDirectoryClient(parentDirName)
                .GetFileClient(fileName));
            await fileClient.CreateAsync();

            // Act
            DataLakeDirectoryClient parentDirClient = fileClient.GetParentDirectoryClient();
            // make sure that client is functional
            var pathItems = await parentDirClient.GetPathsAsync().ToListAsync();

            // Assert
            Assert.That(parentDirClient.Path, Is.EqualTo(fileClient.Path.GetParentPath()));
            Assert.That(parentDirClient.AccountName, Is.EqualTo(fileClient.AccountName));
            Assert.That(pathItems, Is.Not.Null);
        }

        [RecordedTest]
        public void PathClient_CanMockParentDirectoryClientRetrieval()
        {
            // Arrange
            Mock<DataLakeFileClient> fileClientMock = new Mock<DataLakeFileClient>();
            Mock<DataLakeFileSystemClient> fileSystemClientMock = new Mock<DataLakeFileSystemClient>();
            fileClientMock.Protected().Setup<DataLakeFileSystemClient>("GetParentFileSystemClientCore").Returns(fileSystemClientMock.Object);

            // Act
            var fileSystemClient = fileClientMock.Object.GetParentFileSystemClientCore();

            // Assert
            Assert.That(fileSystemClient, Is.Not.Null);
            Assert.That(fileSystemClient, Is.SameAs(fileSystemClientMock.Object));
        }

        [RecordedTest]
        public void PathClient_CanGenerateSas_GetParentDataLakeFileSystemClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var endpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var secondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (endpoint, secondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - BlobBaseClient(string connectionString, string blobContainerName, string blobName)
            DataLakeFileClient file = InstrumentClient(new DataLakeFileClient(
                connectionString,
                GetNewFileSystemName(),
                $"{GetNewDirectoryName()}/{GetNewFileName()}"));
            DataLakeFileSystemClient fileSystem = file.GetParentFileSystemClient();
            Assert.That(fileSystem.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(string connectionString, string blobContainerName, string blobName, BlobClientOptions options)
            DataLakeFileClient file2 = InstrumentClient(new DataLakeFileClient(
                connectionString,
                GetNewFileSystemName(),
                $"{GetNewDirectoryName()}/{GetNewFileName()}",
                GetOptions()));
            DataLakeFileSystemClient fileSystem2 = file2.GetParentFileSystemClient();
            Assert.That(fileSystem2.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeFileClient file3 = InstrumentClient(new DataLakeFileClient(
                endpoint,
                GetOptions()));
            DataLakeFileSystemClient container3 = file3.GetParentFileSystemClient();
            Assert.That(container3.CanGenerateSasUri, Is.False);

            // Act - BlobBaseClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeFileClient file4 = InstrumentClient(new DataLakeFileClient(
                endpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeFileSystemClient container4 = file4.GetParentFileSystemClient();
            Assert.That(container4.CanGenerateSasUri, Is.True);

            // Act - BlobBaseClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeFileClient file5 = InstrumentClient(new DataLakeFileClient(
                endpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeFileSystemClient container5 = file5.GetParentFileSystemClient();
            Assert.That(container5.CanGenerateSasUri, Is.False);
        }
    }
}
