// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class PathClientTests : PathTestBase
    {
        public PathClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
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

        [RecordedTest]
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

        [RecordedTest]
        public async Task Ctor_TokenCredential()
        {
            string fileSystemName = GetNewFileSystemName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);

            // Arrange
            string directoryName = GetNewDirectoryName();
            await test.FileSystem.CreateDirectoryAsync(directoryName);

            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}/{directoryName}").ToHttps();
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(uri, tokenCredential, GetOptions()));

            // Act
            await pathClient.GetPropertiesAsync();

            // Assert
            Assert.AreEqual(fileSystemName, pathClient.FileSystemName);
            Assert.AreEqual(uri, pathClient.Uri);
        }

        [RecordedTest]
        public async Task Ctor_ConnectionString_RoundTrip()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(path));
            await directoryClient.CreateAsync();

            // Act
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint};TableEndpoint={TestConfigHierarchicalNamespace.TableServiceEndpoint}";
            DataLakePathClient connStringDirectory = InstrumentClient(new DataLakePathClient(connectionString, fileSystemName, path, GetOptions()));

            // Assert
            await connStringDirectory.GetPropertiesAsync();
            await connStringDirectory.GetAccessControlAsync();
        }

        [RecordedTest]
        public async Task Ctor_ConnectionString_GenerateSas()
        {
            // Arrange
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(fileSystemName: fileSystemName);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(path));
            await directoryClient.CreateAsync();

            // Act
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint};TableEndpoint={TestConfigHierarchicalNamespace.TableServiceEndpoint}";
            DataLakePathClient connStringDirectory = InstrumentClient(new DataLakePathClient(connectionString, fileSystemName, path, GetOptions()));
            Uri sasUri = connStringDirectory.GenerateSasUri(DataLakeSasPermissions.All, Recording.UtcNow.AddDays(1));
            DataLakePathClient sasPathClient = InstrumentClient(new DataLakePathClient(sasUri, GetOptions()));

            // Assert
            await sasPathClient.GetPropertiesAsync();
            await sasPathClient.GetAccessControlAsync();
        }

        [Test]
        public void Ctor_ConnectionString_CustomUri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://customdomain/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://customdomain/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));

            var filesystemName = "filesystemName";
            var pathName = "pathName";

            DataLakePathClient pathClient = new DataLakePathClient(connectionString.ToString(true), filesystemName, pathName);

            Assert.AreEqual(filesystemName, pathClient.FileSystemName);
            Assert.AreEqual(pathName, pathClient.Name);
            Assert.AreEqual(accountName, pathClient.AccountName);
        }

        [RecordedTest]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakePathClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakePathClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [RecordedTest]
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

        [RecordedTest]
        public void Ctor_CPK_Http()
        {
            // Arrange
            Models.DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeClientOptions dataLakeClientOptions = new DataLakeClientOptions
            {
                CustomerProvidedKey = customerProvidedKey
            };
            Uri httpUri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakePathClient(httpUri, dataLakeClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        #region GenerateSasTests
        [RecordedTest]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = TestConstants.Create(this);
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

        [RecordedTest]
        public void CanGenerateSas_Mockable()
        {
            // Act
            var pathClient = new Mock<DataLakePathClient>();
            pathClient.Setup(x => x.CanGenerateSasUri).Returns(false);

            // Assert
            Assert.IsFalse(pathClient.Object.CanGenerateSasUri);

            // Act
            pathClient.Setup(x => x.CanGenerateSasUri).Returns(true);

            // Assert
            Assert.IsTrue(pathClient.Object.CanGenerateSasUri);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            string stringToSign = null;

            // Act
            Uri sasUri = pathClient.GenerateSasUri(permissions, expiresOn, out stringToSign);

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
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateSas_Builder()
        {
            var constants = TestConstants.Create(this);
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

            string stringToSign = null;

            // Act
            Uri sasUri = pathClient.GenerateSasUri(sasBuilder, out stringToSign);

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
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongFileSystemName()
        {
            // Arrange
            var constants = TestConstants.Create(this);
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

        [RecordedTest]
        public void GenerateSas_BuilderWrongPath()
        {
            // Arrange
            var constants = TestConstants.Create(this);
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

        [RecordedTest]
        public void GenerateSas_BuilderIsDirectoryError()
        {
            var constants = TestConstants.Create(this);
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

        #region GenerateUserDelegationSasTests
        [RecordedTest]
        public async Task GenerateUserDelegationSas_RequiredParameters()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                GetOptions()));

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = pathClient.GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out stringToSign);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint)
            {
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, pathClient.AccountName)
            };
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_Builder()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = pathClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint);
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, pathClient.AccountName);
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNull()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                GetOptions()));

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => pathClient.GenerateUserDelegationSasUri(null, userDelegationKey, out stringToSign),
                 new ArgumentNullException("builder"));
        }

        [RecordedTest]
        public void GenerateUserDelegationSas_UserDelegationKeyNull()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };

            string stringToSign = null;

            // Act
            TestHelper.AssertExpectedException(
                () => pathClient.GenerateUserDelegationSasUri(sasBuilder, null, out stringToSign),
                 new ArgumentNullException("userDelegationKey"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullFileSystemName()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = null,
                Path = path,
                StartsOn = startsOn
            };

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = pathClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint);
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, pathClient.AccountName);
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongFileSystemName()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewFileSystemName() + "/" + path;
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobUriBuilder.Uri,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesystem name
                Path = path,
            };

            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => pathClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.FileSystemName does not match FileSystemName in the Client. DataLakeSasBuilder.FileSystemName must either be left empty or match the FileSystemName in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullPath()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = null,
                StartsOn = startsOn
            };

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = pathClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint);
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, pathClient.AccountName);
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongPath()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string fileSystemName = GetNewFileSystemName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + fileSystemName + "/" + GetNewFileName();
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobUriBuilder.Uri,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewFileName(), // different path
            };

            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => pathClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.Path does not match Path in the Client. DataLakeSasBuilder.Path must either be left empty or match the Path in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullIsDirectory()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            string path = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "/" + fileSystemName + "/" + path);
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobEndpoint,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn,
                IsDirectory = null
            };

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = pathClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(blobEndpoint);
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = path,
                StartsOn = startsOn,
                IsDirectory = false
            };
            expectedUri.Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, pathClient.AccountName);
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderIsDirectoryError()
        {
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            string fileSystemName = GetNewFileSystemName();
            string fileName = GetNewFileName();
            DataLakeSasPermissions permissions = DataLakeSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            blobUriBuilder.Path += constants.Sas.Account + "/" + fileSystemName + "/" + fileName;
            DataLakePathClient pathClient = InstrumentClient(new DataLakePathClient(
                blobUriBuilder.Uri,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = fileName,
                IsDirectory = true,
            };

            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => pathClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. Expected builder.IsDirectory to be set to false to generate the respective SAS for the client, GetType"));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<DataLakePathClient>(TestConfigDefault.ConnectionString, "name", "name", new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakePathClient>(TestConfigDefault.ConnectionString, "name", "name").Object;
            mock = new Mock<DataLakePathClient>(new Uri("https://test/test"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakePathClient>(new Uri("https://test/test"), Tenants.GetNewHnsSharedKeyCredentials(), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakePathClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakePathClient>(new Uri("https://test/test"), TestEnvironment.Credential, new DataLakeClientOptions()).Object;
        }

        [RecordedTest]
        public async Task RenameAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient sourceFile = await test.FileSystem.CreateFileAsync(GetNewFileName());
            DataLakePathClient pathClient = test.FileSystem.GetPathClient(sourceFile.Name);
            string destFileName = GetNewDirectoryName();

            // Act
            DataLakePathClient destFile = await pathClient.RenameAsync(destinationPath: destFileName);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_FileSystem()
        {
            await using DisposingFileSystem sourceTest = await GetNewFileSystem();
            await using DisposingFileSystem destTest = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient sourceFile = await sourceTest.FileSystem.CreateFileAsync(GetNewFileName());
            DataLakePathClient pathClient = sourceTest.FileSystem.GetPathClient(sourceFile.Name);
            string destFileName = GetNewDirectoryName();

            // Act
            DataLakePathClient destFile = await pathClient.RenameAsync(
                destinationPath: destFileName,
                destinationFileSystem: destTest.FileSystem.Name);

            // Assert
            Response<PathProperties> response = await destFile.GetPropertiesAsync();
        }

        [RecordedTest]
        public async Task RenameAsync_Error()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeFileClient sourceFile = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            DataLakePathClient pathClient = test.FileSystem.GetPathClient(sourceFile.Name);
            string destPath = GetNewFileName();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                pathClient.RenameAsync(destinationPath: destPath),
                e => Assert.AreEqual("SourcePathNotFound", e.ErrorCode));
        }
    }
}
