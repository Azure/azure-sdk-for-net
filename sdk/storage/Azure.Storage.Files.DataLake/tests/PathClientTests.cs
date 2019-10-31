// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Sas;
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
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();
                await fileSystem.CreateDirectoryAsync(directoryName);

                SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}?{sasQueryParameters}");
                DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(uri, GetOptions()));

                // Act
                await pathClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(fileSystemName, pathClient.FileSystemName);
                Assert.AreEqual(uri, pathClient.Uri);
            }
        }

        [Test]
        public async Task Ctor_SharedKey()
        {
            string fileSystemName = GetNewFileSystemName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();
                await fileSystem.CreateDirectoryAsync(directoryName);

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
        }

        [Test]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            using (GetNewFileSystem(out DataLakeFileSystemClient fileSystem, fileSystemName: fileSystemName))
            {
                // Arrange
                string directoryName = GetNewDirectoryName();
                await fileSystem.CreateDirectoryAsync(directoryName);

                TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}").ToHttps();
                DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(uri, tokenCredential, GetOptions()));

                // Act
                await pathClient.GetPropertiesAsync();

                // Assert
                Assert.AreEqual(fileSystemName, pathClient.FileSystemName);
                Assert.AreEqual(uri, pathClient.Uri);
            }
        }
    }
}
