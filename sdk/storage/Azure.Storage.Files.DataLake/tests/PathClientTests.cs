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
            DataLakePathClient blob3 = new DataLakePathClient(
                blobEndpoint,
                GetOptions());
            Assert.IsFalse(blob3.CanGenerateSasUri);

            // Act - DataLakePathClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakePathClient blob4 = new DataLakePathClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions());
            Assert.IsTrue(blob4.CanGenerateSasUri);

            // Act - DataLakePathClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakePathClient blob5 = new DataLakePathClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions());
            Assert.IsFalse(blob5.CanGenerateSasUri);
        }

        [Test]
        public void GetSasBuilder()
        {
            //Arrange
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            string Path = GetNewFileName();
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + Path);
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read | DataLakeSasPermissions.Write;
            DataLakePathClient pathClient = new DataLakePathClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            // Act
            DataLakeSasBuilder sasBuilder = pathClient.GetSasBuilder(
                permissions: permissions,
                expiresOn: expiresOn);

            // Assert
            Assert.AreEqual(sasBuilder.FileSystemName, fileSystemName);
            Assert.AreEqual(sasBuilder.Path, Path);
            Assert.AreEqual(sasBuilder.Permissions, permissions.ToPermissionsString());
            Assert.AreEqual(sasBuilder.ExpiresOn, expiresOn);
            Assert.AreEqual("b", sasBuilder.Resource);
        }

        [Test]
        public void GenerateSas_GeneratedBuilder_Path()
        {
            // Arrange
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            string Path = GetNewFileName();
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + Path);
            DataLakePathClient pathClient = new DataLakePathClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            DataLakeSasBuilder sasBuilder =
                pathClient.GetSasBuilder(DataLakeSasPermissions.Read, Recording.UtcNow.AddHours(+1));
            // Add more properties on the builder
            sasBuilder.StartsOn = Recording.UtcNow.AddHours(-1);
            sasBuilder.Identifier = GetNewString();

            // Act
            Uri sasUri = pathClient.GenerateSasUri(sasBuilder);

            // Assert
            UriBuilder expectedUri = new UriBuilder(blobEndpoint);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_CustomerProvidedBuilder()
        {
            var constants = new TestConstants(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = new DataLakePathClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder()
            {
                FileSystemName = fileSystemName,
                Path = path,
                Resource = "b",
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None)
            };
            // Add more properties on the builder
            sasBuilder.StartsOn = Recording.UtcNow.AddHours(-1);
            sasBuilder.Identifier = GetNewString();

            // Act
            Uri sasUri = pathClient.GenerateSasUri(sasBuilder);

            // Assert
            UriBuilder expectedUri = new UriBuilder(blobEndpoint);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_BuilderWrongFileSystemName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewFileSystemName() + "/" + GetNewFileName();
            DataLakePathClient pathClient = new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            DataLakeSasBuilder sasBuilder =
                pathClient.GetSasBuilder(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(+1));
            sasBuilder.FileSystemName = GetNewFileSystemName();

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
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewFileSystemName() + "/" + GetNewFileName();
            DataLakePathClient containerClient = new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            DataLakeSasBuilder sasBuilder =
                containerClient.GetSasBuilder(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(+1));
            sasBuilder.Path = GetNewFileName();

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
            blobUriBuilder.Path += constants.Sas.Account + "/" + fileSystemName + "/" + fileName;
            DataLakePathClient containerClient = new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder()
            {
                FileSystemName = fileSystemName,
                Path = fileName,
                IsDirectory = true,
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                ExpiresOn = Recording.UtcNow.AddHours(+1)

            };
            sasBuilder.SetPermissions(DataLakeSasPermissions.All);
            sasBuilder.Path = GetNewFileName();

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

        [Test]
        public void GenerateUserDelegationSas_GeneratedBuilder()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            blobUriBuilder.Path += "/" + GetNewFileSystemName() + "/" + GetNewFileName();
            DataLakePathClient blobClient =
                new DataLakePathClient(blobUriBuilder.Uri, GetOptions());
            UserDelegationKey userDelegationKey = new UserDelegationKey
            {
                SignedObjectId = constants.Sas.KeyObjectId,
                SignedTenantId = constants.Sas.KeyTenantId,
                SignedStartsOn = constants.Sas.KeyStart,
                SignedExpiresOn = constants.Sas.KeyExpiry,
                SignedService = constants.Sas.KeyService,
                SignedVersion = constants.Sas.KeyVersion,
                Value = constants.Sas.KeyValue
            };

            DataLakeSasBuilder sasBuilder =
                blobClient.GetSasBuilder(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(+1));
            // Add more properties on the builder
            sasBuilder.StartsOn = Recording.UtcNow.AddHours(-1);
            sasBuilder.Identifier = GetNewString();

            // Act
            Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            blobUriBuilder.Query += sasBuilder.ToSasQueryParameters(userDelegationKey, constants.Sas.Account).ToString();
            Assert.AreEqual(blobUriBuilder.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateUserDelegationSas_CustomerProvidedBuilder()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            string containerName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            DataLakePathClient blobClient =
                new DataLakePathClient(new Uri(blobEndpoint + "/" + containerName + "/" + fileName));

            UserDelegationKey userDelegationKey = new UserDelegationKey
            {
                SignedObjectId = constants.Sas.KeyObjectId,
                SignedTenantId = constants.Sas.KeyTenantId,
                SignedStartsOn = constants.Sas.KeyStart,
                SignedExpiresOn = constants.Sas.KeyExpiry,
                SignedService = constants.Sas.KeyService,
                SignedVersion = constants.Sas.KeyVersion,
                Value = constants.Sas.KeyValue
            };
            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder()
            {
                FileSystemName = containerName,
                Path = fileName,
                Resource = "b",
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None)

            };
            // Add more properties on the builder
            sasBuilder.StartsOn = Recording.UtcNow.AddHours(-1);
            sasBuilder.Identifier = GetNewString();

            // Act
            Uri sasUri = blobClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            UriBuilder expectedUri = new UriBuilder(blobEndpoint);
            expectedUri.Path += "/" + containerName + "/" + fileName;
            expectedUri.Query += sasBuilder.ToSasQueryParameters(userDelegationKey, constants.Sas.Account).ToString();
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateUserDelegationSas_BuilderWrongFileSystemName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewFileSystemName() + "/" + GetNewFileName();
            UserDelegationKey userDelegationKey = new UserDelegationKey
            {
                SignedObjectId = constants.Sas.KeyObjectId,
                SignedTenantId = constants.Sas.KeyTenantId,
                SignedStartsOn = constants.Sas.KeyStart,
                SignedExpiresOn = constants.Sas.KeyExpiry,
                SignedService = constants.Sas.KeyService,
                SignedVersion = constants.Sas.KeyVersion,
                Value = constants.Sas.KeyValue
            };
            DataLakePathClient containerClient = new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            DataLakeSasBuilder sasBuilder =
                containerClient.GetSasBuilder(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(+1));
            sasBuilder.FileSystemName = GetNewFileSystemName();

            // Act
            try
            {
                containerClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

                Assert.Fail("DataLakePathClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }

        [Test]
        public void GenerateUserDelegationSas_BuilderWrongPath()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewFileSystemName() + "/" + GetNewFileName();
            UserDelegationKey userDelegationKey = new UserDelegationKey
            {
                SignedObjectId = constants.Sas.KeyObjectId,
                SignedTenantId = constants.Sas.KeyTenantId,
                SignedStartsOn = constants.Sas.KeyStart,
                SignedExpiresOn = constants.Sas.KeyExpiry,
                SignedService = constants.Sas.KeyService,
                SignedVersion = constants.Sas.KeyVersion,
                Value = constants.Sas.KeyValue
            };
            DataLakePathClient containerClient = new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            DataLakeSasBuilder sasBuilder =
                containerClient.GetSasBuilder(DataLakeSasPermissions.All, Recording.UtcNow.AddHours(+1));
            sasBuilder.Path = GetNewFileName();
            ;

            // Act
            try
            {
                containerClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

                Assert.Fail("DataLakePathClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }

        [Test]
        public void GenerateUserDelegationSas_BuilderIsDirectoryError()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            blobUriBuilder.Path += constants.Sas.Account + "/" + fileSystemName + "/" + fileName;
            UserDelegationKey userDelegationKey = new UserDelegationKey
            {
                SignedObjectId = constants.Sas.KeyObjectId,
                SignedTenantId = constants.Sas.KeyTenantId,
                SignedStartsOn = constants.Sas.KeyStart,
                SignedExpiresOn = constants.Sas.KeyExpiry,
                SignedService = constants.Sas.KeyService,
                SignedVersion = constants.Sas.KeyVersion,
                Value = constants.Sas.KeyValue
            };
            DataLakePathClient containerClient = new DataLakePathClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions());

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder()
            {
                FileSystemName = fileSystemName,
                Path = fileName,
                IsDirectory = true,
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                ExpiresOn = Recording.UtcNow.AddHours(+1)

            };
            sasBuilder.SetPermissions(DataLakeSasPermissions.All);
            sasBuilder.Path = GetNewFileName();

            // Act
            try
            {
                containerClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

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
