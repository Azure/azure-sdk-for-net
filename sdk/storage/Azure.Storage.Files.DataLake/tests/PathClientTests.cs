// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathClientTests : PathTestBase
    {
        public PathClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
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
        public async Task Ctor_ConnectionString_RoundTrip()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(path));
            await directoryClient.CreateAsync();

            // Act
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};EndpointSuffix=core.windows.net";
            DataLakePathClient connStringDirectory = InstrumentClient(new DataLakePathClient(connectionString, fileSystemName, path, GetOptions()));

            // Assert
            await connStringDirectory.GetPropertiesAsync();
            await connStringDirectory.GetAccessControlAsync();
        }

        [Test]
        public async Task Ctor_ConnectionString_GenerateSas()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(path));
            await directoryClient.CreateAsync();

            // Act
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};EndpointSuffix=core.windows.net";
            DataLakePathClient connStringDirectory = InstrumentClient(new DataLakePathClient(connectionString, fileSystemName, path, GetOptions()));
            Uri sasUri = connStringDirectory.GenerateSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddDays(1));
            DataLakePathClient sasPathClient = InstrumentClient(new DataLakePathClient(sasUri, GetOptions()));

            // Assert
            await sasPathClient.GetPropertiesAsync();
            await sasPathClient.GetAccessControlAsync();
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
        public async Task Ctor_FileSystemAndPath()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient fileClient = await test.FileSystem.CreateFileAsync(GetNewFileName());

            // Act
            DataLakePathClient pathClient = new DataLakePathClient(test.FileSystem, fileClient.Path);

            // Assert
            await pathClient.GetPropertiesAsync();
            await pathClient.GetAccessControlAsync();
        }

        #region GenerateSasTests
        [Test]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - DataLakePathClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakePathClient blob3 = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(blob3.CanGenerateSasUri);

            // Act - DataLakePathClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakePathClient blob4 = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(blob4.CanGenerateSasUri);

            // Act - DataLakePathClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakePathClient blob5 = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.IsFalse(blob5.CanGenerateSasUri);
        }

        [Test]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            // Act
            Uri sasUri = pathClient.GenerateSasUri(permissions, expiresOn);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint)
            {
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_Builder()
        {
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = pathClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint);
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential);
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_BuilderWrongFileSystemName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewFileSystemName() + "/" + path;
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesystem name
                Path = path,
            };

            // Act
            try
            {
                pathClient.GenerateSasUri(sasBuilder);

                Assert.Fail("DataLakePathClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }

        [Test]
        public void GenerateSas_BuilderWrongPath()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string fileSystemName = GetNewFileSystemName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + fileSystemName + "/" + GetNewFileName();
            DataLakePathClient containerClient = InstrumentClient(new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewFileName(), // different path
            };

            // Act
            try
            {
                containerClient.GenerateSasUri(sasBuilder);

                Assert.Fail("DataLakePathClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }

        [Test]
        public void GenerateSas_BuilderIsDirectoryError()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + fileSystemName + "/" + fileName;
            DataLakePathClient containerClient = InstrumentClient(new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = fileName,
                IsDirectory = true,
            };

            // Act
            try
            {
                containerClient.GenerateSasUri(sasBuilder);

                Assert.Fail("DataLakeFileClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }
        #endregion
    }
}
