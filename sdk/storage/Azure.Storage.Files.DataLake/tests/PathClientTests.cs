// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathClientTests : PathTestBase
    {
        public PathClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public async Task Ctor_Uri()
        {
            string fileSystemName = GetNewFileSystemName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            string directoryName = GetNewDirectoryName();
            await test.FileSystem.CreateDirectoryAsync(directoryName);

            SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}?{sasQueryParameters}");
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(uri, GetOptions()));

            // Act
            await pathClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileSystemName, pathClient.FileSystemName);
            Assert.AreEqual(uri, pathClient.Uri);
        }

        [Test]
        public async Task Ctor_SharedKey()
        {
            string fileSystemName = GetNewFileSystemName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            string directoryName = GetNewDirectoryName();
            await test.FileSystem.CreateDirectoryAsync(directoryName);

            StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                TestConfigHierarchicalNamespace.AccountName,
                TestConfigHierarchicalNamespace.AccountKey);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}");
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(uri, sharedKey, GetOptions()));

            // Act
            await pathClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileSystemName, pathClient.FileSystemName);
            Assert.AreEqual(uri, pathClient.Uri);
        }

        [Test]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            string directoryName = GetNewDirectoryName();
            await test.FileSystem.CreateDirectoryAsync(directoryName);

            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}").ToHttps();
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(uri, tokenCredential, GetOptions()));

            // Act
            await pathClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileSystemName, pathClient.FileSystemName);
            Assert.AreEqual(uri, pathClient.Uri);
        }

        [Test]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakePathClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakePathClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
        public async Task ExistsAsync_FileExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string pathName = GetNewFileName();
            DataLakeFileClient fileClient = await test.FileSystem.CreateFileAsync(pathName);
            DataLakePathClient pathClient = new DataLakePathClient(fileClient.Uri, fileClient.Pipeline);

            // Act
            Response<bool> response = await pathClient.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task ExistsAsync_DirectoryExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string pathName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = await test.FileSystem.CreateDirectoryAsync(pathName);
            DataLakePathClient pathClient = new DataLakePathClient(directoryClient.Uri, directoryClient.Pipeline);

            // Act
            Response<bool> response = await pathClient.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string pathName = GetNewFileName();
            DataLakeFileClient fileClient = test.FileSystem.GetFileClient(pathName);
            DataLakePathClient pathClient = new DataLakePathClient(fileClient.Uri, fileClient.Pipeline);

            // Act
            Response<bool> response = await pathClient.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName());
            DataLakeFileClient file = InstrumentClient(directory.GetFileClient(GetNewFileName()));
            DataLakePathClient unauthorizedPath = InstrumentClient(new DataLakePathClient(file.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedPath.ExistsAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }
    }
}
