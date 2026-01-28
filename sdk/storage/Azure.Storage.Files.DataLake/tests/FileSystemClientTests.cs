// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Tests.Shared;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class FileSystemClientTests : DataLakeTestBase
    {
        public FileSystemClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task Ctor_Uri()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSystemName = GetNewFileSystemName();
            await service.CreateFileSystemAsync(fileSystemName);

            try
            {
                SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}?{sasQueryParameters}");
                DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(uri, GetOptions()));

                // Act
                await fileSystemClient.GetPropertiesAsync();

                // Assert
                Assert.That(fileSystemClient.Name, Is.EqualTo(fileSystemName));
                Assert.That(fileSystemClient.Uri, Is.EqualTo(uri));
            }
            finally
            {
                await service.DeleteFileSystemAsync(fileSystemName);
            }
        }

        [RecordedTest]
        public async Task Ctor_SharedKey()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSystemName = GetNewFileSystemName();
            await service.CreateFileSystemAsync(fileSystemName);

            try
            {
                StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                    TestConfigHierarchicalNamespace.AccountName,
                    TestConfigHierarchicalNamespace.AccountKey);
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}");
                DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(uri, sharedKey, GetOptions()));

                // Act
                await fileSystemClient.GetPropertiesAsync();

                // Assert
                Assert.That(fileSystemClient.Name, Is.EqualTo(fileSystemName));
                Assert.That(fileSystemClient.Uri, Is.EqualTo(uri));
                Assert.That(fileSystemClient.ClientConfiguration.SharedKeyCredential, Is.Not.Null);
            }
            finally
            {
                await service.DeleteFileSystemAsync(fileSystemName);
            }
        }

        [RecordedTest]
        public async Task Ctor_TokenCredential()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSystemName = GetNewFileSystemName();
            await service.CreateFileSystemAsync(fileSystemName);

            try
            {
                TokenCredential tokenCredential = TestEnvironment.Credential;
                Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{fileSystemName}").ToHttps();
                DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(uri, tokenCredential, GetOptions()));

                // Act
                await fileSystemClient.GetPropertiesAsync();
                Assert.That(fileSystemClient.ClientConfiguration.TokenCredential, Is.Not.Null);
            }
            finally
            {
                await service.DeleteFileSystemAsync(fileSystemName);
            }
        }

        [RecordedTest]
        public async Task Ctor_ConnectionString_RoundTrip()
        {
            // Arrage
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint};TableEndpoint={TestConfigHierarchicalNamespace.TableServiceEndpoint}";
            DataLakeFileSystemClient fileSystem = InstrumentClient(new DataLakeFileSystemClient(connectionString, GetNewFileSystemName(), GetOptions()));

            // Act
            try
            {
                await fileSystem.CreateAsync();
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(GetNewDirectoryName()));
                await directory.CreateAsync();

                IList<PathItem> paths = await fileSystem.GetPathsAsync().ToListAsync();

                // Assert
                Assert.That(paths.Count, Is.EqualTo(1));
                Assert.That(fileSystem.ClientConfiguration.SharedKeyCredential, Is.Not.Null);
            }

            // Cleanup
            finally
            {
                await fileSystem.DeleteAsync();
            }
        }

        [RecordedTest]
        public async Task Ctor_ConnectionString_GenerateSas()
        {
            // Arrage
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint};TableEndpoint={TestConfigHierarchicalNamespace.TableServiceEndpoint}";
            DataLakeFileSystemClient fileSystem = InstrumentClient(new DataLakeFileSystemClient(connectionString, GetNewFileSystemName(), GetOptions()));

            // Act
            try
            {
                await fileSystem.CreateAsync();
                Uri sasUri = fileSystem.GenerateSasUri(
                    DataLakeFileSystemSasPermissions.All,
                    Recording.UtcNow.AddDays(1));

                DataLakeFileSystemClient sasFileSystem = InstrumentClient(new DataLakeFileSystemClient(sasUri, GetOptions()));

                DataLakeDirectoryClient directory = InstrumentClient(sasFileSystem.GetDirectoryClient(GetNewDirectoryName()));
                await directory.CreateAsync();

                IList<PathItem> paths = await sasFileSystem.GetPathsAsync().ToListAsync();

                // Assert
                Assert.That(paths.Count, Is.EqualTo(1));
            }

            // Cleanup
            finally
            {
                await fileSystem.DeleteAsync();
            }
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

            DataLakeFileSystemClient container = new DataLakeFileSystemClient(connectionString.ToString(true), filesystemName);

            Assert.That(container.Name, Is.EqualTo(filesystemName));
            Assert.That(container.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeFileSystemClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakeFileSystemClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var fileSystemName = "fileSystemName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri($"https://customdomain/{fileSystemName}");

            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(blobEndpoint, credentials);

            Assert.That(fileSystemClient.AccountName, Is.EqualTo(accountName));
            Assert.That(fileSystemClient.Name, Is.EqualTo(fileSystemName));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            Uri uri = test.FileSystem.Uri;

            // Act
            var sasClient = InstrumentClient(new DataLakeFileSystemClient(uri, new AzureSasCredential(sas), GetOptions()));
            FileSystemProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.That(properties, Is.Not.Null);
            Assert.That(sasClient.ClientConfiguration.SasCredential, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingFileSystem test = await GetNewFileSystem();
            Uri uri = test.FileSystem.Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new DataLakeFileSystemClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public void Ctor_CPK_Http()
        {
            // Arrange
            DataLakeCustomerProvidedKey customerProvidedKey = GetCustomerProvidedKey();
            DataLakeClientOptions dataLakeClientOptions = new DataLakeClientOptions
            {
                CustomerProvidedKey = customerProvidedKey
            };
            Uri httpUri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeFileSystemClient(httpUri, dataLakeClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(DataLakeAudience.DefaultAudience);
            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = test.FileSystem.Name,
            };

            DataLakeFileSystemClient aadFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                uriBuilder.ToUri(),
                GetOAuthHnsCredential(),
                options));

            // Assert
            bool exists = await aadFileSystemClient.ExistsAsync();
            Assert.That(exists, Is.True);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(new DataLakeAudience($"https://{test.FileSystem.AccountName}.blob.core.windows.net/"));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = test.FileSystem.Name,
            };

            DataLakeFileSystemClient aadFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                uriBuilder.ToUri(),
                GetOAuthHnsCredential(),
                options));

            // Assert
            bool exists = await aadFileSystemClient.ExistsAsync();
            Assert.That(exists, Is.True);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(DataLakeAudience.CreateDataLakeServiceAccountAudience(test.FileSystem.AccountName));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = test.FileSystem.Name,
            };

            DataLakeFileSystemClient aadFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                uriBuilder.ToUri(),
                GetOAuthHnsCredential(),
                options));

            // Assert
            bool exists = await aadFileSystemClient.ExistsAsync();
            Assert.That(exists, Is.True);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(new DataLakeAudience("https://badaudience.blob.core.windows.net"));

            DataLakeUriBuilder uriBuilder = new DataLakeUriBuilder(new Uri(Tenants.TestConfigHierarchicalNamespace.BlobServiceEndpoint))
            {
                FileSystemName = test.FileSystem.Name,
            };

            DataLakeFileSystemClient aadFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                uriBuilder.ToUri(),
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadFileSystemClient.ExistsAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("InvalidAuthenticationInfo")));
        }

        [RecordedTest]
        public async Task GetFileClient()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient fileClient = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await fileClient.CreateAsync();
            DataLakeFileClient newFileClient = InstrumentClient(test.FileSystem.GetFileClient(fileClient.Name));

            // Act
            Response<PathProperties> response = await newFileClient.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetDirectoryClient()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            await directoryClient.CreateAsync();
            DataLakeDirectoryClient newDirectoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryClient.Name));

            // Act
            Response<PathProperties> response = await newDirectoryClient.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetPathClient()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient fileClient = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await fileClient.CreateAsync();
            DataLakePathClient newPathClient = InstrumentClient(test.FileSystem.GetPathClient(fileClient.Name));

            // Act
            Response<PathProperties> response = await newPathClient.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CreateAsync()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            var fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystem.CreateAsync();

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

                var accountName = new DataLakeUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => fileSystem.AccountName);
                TestHelper.AssertCacheableProperty(fileSystemName, () => fileSystem.Name);
            }
            finally
            {
                await fileSystem.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task CreateAsync_EncryptionScopeOptions()
        {
            // Arrange
            DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions = new DataLakeFileSystemEncryptionScopeOptions
            {
                DefaultEncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope,
                PreventEncryptionScopeOverride = true
            };
            await using DisposingFileSystem test = await GetNewFileSystem(encryptionScopeOptions: encryptionScopeOptions);

            // Assert - We are also testing GetPropertiesAsync() in this test.
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();
            Assert.That(response.Value.DefaultEncryptionScope, Is.EqualTo(TestConfigHierarchicalNamespace.EncryptionScope));
            Assert.That(response.Value.PreventEncryptionScopeOverride, Is.True);
        }

        [RecordedTest]
        public async Task CreateAsync_WithAccountSas()
        {
            // Arrange
            var fileSystemName = GetNewFileSystemName();
            DataLakeServiceClient service = GetServiceClient_AccountSas();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystem.CreateAsync();

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
            finally
            {
                await fileSystem.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task CreateAsync_WithDataLakeServiceSas()
        {
            // Arrange
            var fileSystemName = GetNewFileSystemName();
            DataLakeServiceClient service = GetServiceClient_DataLakeServiceSas_FileSystem(fileSystemName);
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));
            var pass = false;

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystem.CreateAsync();

                Assert.Fail("CreateAsync unexpected success: blob service SAS should not be usable to create container");
            }
            catch (RequestFailedException se) when (se.ErrorCode == "AuthorizationFailure") // TODO verify if this is a missing error code
            {
                pass = true;
            }
            finally
            {
                if (!pass)
                {
                    await fileSystem.DeleteIfExistsAsync();
                }
            }
        }

        [RecordedTest]
        public async Task CreateAsync_Oauth()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_OAuth();
            var fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystem.CreateAsync();

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

                var accountName = new DataLakeUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => fileSystem.AccountName);
                TestHelper.AssertCacheableProperty(fileSystemName, () => fileSystem.Name);
            }
            finally
            {
                await fileSystem.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task CreateAsync_Metadata()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            IDictionary<string, string> metadata = BuildMetadata();

            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions()
            {
                Metadata = metadata
            };

            // Act
            await fileSystem.CreateAsync(options);

            // Assert
            Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);

            // Cleanup
            await fileSystem.DeleteIfExistsAsync();
        }

        [RecordedTest]
        [PlaybackOnly("Public access disabled on live test accounts.")]
        public async Task CreateAsync_PublicAccess()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                PublicAccessType = PublicAccessType.Path
            };

            // Act
            await fileSystem.CreateAsync(options);

            // Assert
            Response<FileSystemProperties> response = await fileSystem.GetPropertiesAsync();
            Assert.That(response.Value.PublicAccess, Is.EqualTo(Models.PublicAccessType.Path));

            // Cleanup
            await fileSystem.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task CreateAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            // ContainerUri is intentually created twice
            await fileSystemClient.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystemClient.CreateAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerAlreadyExists")));

            // Cleanup
            await fileSystemClient.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task CreateIfNotExistAsync_NotExists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            try
            {
                // Act
                Response<FileSystemInfo> response = await fileSystemClient.CreateIfNotExistsAsync();

                // Assert
                Assert.That(response.Value.ETag, Is.Not.Null);
            }
            finally
            {
                // Cleanup
                await fileSystemClient.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task CreateIfNotExistAsync_Exists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            try
            {
                await fileSystemClient.CreateIfNotExistsAsync();

                // Act
                Response<FileSystemInfo> response = await fileSystemClient.CreateIfNotExistsAsync();

                // Assert
                Assert.That(response, Is.Null);
            }
            finally
            {
                // Cleanup
                await fileSystemClient.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task CreateIfNotExists_EncryptionScopeOptions()
        {
            // Arrange
            DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions = new DataLakeFileSystemEncryptionScopeOptions
            {
                DefaultEncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope
            };
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                EncryptionScopeOptions = encryptionScopeOptions
            };

            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            try
            {
                // Act
                await fileSystemClient.CreateIfNotExistsAsync(options: options);

                // Assert - We are also testing GetPropertiesAsync() in this test.
                Response<FileSystemProperties> response = await fileSystemClient.GetPropertiesAsync();
                Assert.That(response.Value.DefaultEncryptionScope, Is.EqualTo(TestConfigHierarchicalNamespace.EncryptionScope));
            }
            finally
            {
                // Cleanup
                await fileSystemClient.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeFileSystemClient unauthorizedFileSystem = InstrumentClient(new DataLakeFileSystemClient(fileSystemClient.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFileSystem.CreateIfNotExistsAsync(),
                e => Assert.That(
                    e.ErrorCode,
                    Is.EqualTo(_serviceVersion >= DataLakeClientOptions.ServiceVersion.V2019_12_12 ?
                        "NoAuthenticationInformation" :
                        "ResourceNotFound")));
        }

        [RecordedTest]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            Response<bool> response = await test.FileSystem.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.True);
        }

        [RecordedTest]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            Response<bool> response = await fileSystemClient.ExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem(publicAccessType: PublicAccessType.None);
            DataLakeFileSystemClient unauthorizedFileSystemClient = InstrumentClient(new DataLakeFileSystemClient(test.FileSystem.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFileSystemClient.ExistsAsync(),
                e => Assert.That(
                    e.ErrorCode,
                    Is.EqualTo(_serviceVersion >= DataLakeClientOptions.ServiceVersion.V2019_12_12 ?
                        "NoAuthenticationInformation" :
                        "ResourceNotFound")));
        }

        [RecordedTest]
        public async Task DeleteAsync()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateIfNotExistsAsync();

            // Act
            Response response = await fileSystem.DeleteAsync();

            // Assert
            Assert.That(response.Headers.RequestId, Is.Not.Null);
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeRequestConditions.IfMatch))]
        [TestCase(nameof(DataLakeRequestConditions.IfNoneMatch))]
        public async Task DeleteAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());

            DataLakeRequestConditions conditions = new DataLakeRequestConditions();

            switch (invalidCondition)
            {
                case nameof(DataLakeRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(DataLakeRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                fileSystemClient.DeleteAsync(
                    conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"Delete does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.DeleteAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task DeleteAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                parameters.LeaseId = await SetupFileSystemLeaseCondition(fileSystem, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                Response response = await fileSystem.DeleteAsync(conditions: conditions);

                // Assert
                Assert.That(response.Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task DeleteAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                parameters.LeaseId = await SetupFileSystemLeaseCondition(test.FileSystem, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.FileSystem.DeleteAsync(conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync_Exists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystemClient.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await fileSystemClient.DeleteIfExistsAsync();

            // Assert
            Assert.That(response.Value, Is.True);

            // Act
            response = await fileSystemClient.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync_NotExists()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            Response<bool> response = await fileSystemClient.DeleteIfExistsAsync();

            // Assert
            Assert.That(response.Value, Is.False);
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeRequestConditions.IfMatch))]
        [TestCase(nameof(DataLakeRequestConditions.IfNoneMatch))]
        public async Task DeleteIfExistsAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());

            DataLakeRequestConditions conditions = new DataLakeRequestConditions();

            switch (invalidCondition)
            {
                case nameof(DataLakeRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(DataLakeRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                fileSystemClient.DeleteIfExistsAsync(
                    conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"Delete does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task DeleteIfExistsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            DataLakeFileSystemClient unauthorizedFileSystem = InstrumentClient(new DataLakeFileSystemClient(fileSystemClient.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedFileSystem.DeleteIfExistsAsync(),
                e => Assert.That(
                    e.ErrorCode,
                    Is.EqualTo(_serviceVersion >= DataLakeClientOptions.ServiceVersion.V2019_12_12 ?
                        "NoAuthenticationInformation" :
                        "ResourceNotFound")));
        }

        [RecordedTest]
        public async Task GetPathsAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(3));
            Assert.That(paths[0].Name, Is.EqualTo("bar"));
            Assert.That(paths[1].Name, Is.EqualTo("baz"));
            Assert.That(paths[2].Name, Is.EqualTo("foo"));
            Assert.That(paths[0].ETag, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetPathsAsync_EncryptionScopeOptions()
        {
            // Arrange
            DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions = new DataLakeFileSystemEncryptionScopeOptions
            {
                DefaultEncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope
            };
            string directoryName = GetNewDirectoryName();
            await using DisposingFileSystem test = await GetNewFileSystem(encryptionScopeOptions: encryptionScopeOptions);
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directoryClient.CreateAsync();

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();
            PathItem pathItem = paths.Single(r => r.Name == directoryName);

            // Assert
            Assert.That(pathItem.EncryptionScope, Is.EqualTo(TestConfigHierarchicalNamespace.EncryptionScope));
        }

        [RecordedTest]
        public async Task GetPathsAsync_Recursive()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true
            };

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync(options);
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(PathNames.Length));
            Assert.That(paths[0].Name, Is.EqualTo("bar"));
            Assert.That(paths[1].Name, Is.EqualTo("baz"));
            Assert.That(paths[2].Name, Is.EqualTo("baz/bar"));
            Assert.That(paths[3].Name, Is.EqualTo("baz/bar/foo"));
            Assert.That(paths[4].Name, Is.EqualTo("baz/foo"));
            Assert.That(paths[5].Name, Is.EqualTo("baz/foo/bar"));
            Assert.That(paths[6].Name, Is.EqualTo("foo"));
            Assert.That(paths[7].Name, Is.EqualTo("foo/bar"));
            Assert.That(paths[8].Name, Is.EqualTo("foo/foo"));
        }

        [RecordedTest]
        public async Task GetPathsAsync_Upn()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                UserPrincipalName = true
            };

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync(options);
            ;
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(3));
            Assert.That(paths[0].Group, Is.Not.Null);
            Assert.That(paths[0].Owner, Is.Not.Null);

            Assert.That(paths[0].Name, Is.EqualTo("bar"));
            Assert.That(paths[1].Name, Is.EqualTo("baz"));
            Assert.That(paths[2].Name, Is.EqualTo("foo"));
        }

        [RecordedTest]
        public async Task GetPathsAsync_Path()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Path = "foo"
            };

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync(options);
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(2));
            Assert.That(paths[0].Name, Is.EqualTo("foo/bar"));
            Assert.That(paths[1].Name, Is.EqualTo("foo/foo"));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetPathsAsync_MaxResults()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            // Act
            Page<PathItem> page = await test.FileSystem.GetPathsAsync().AsPages(pageSizeHint: 2).FirstAsync();

            // Assert
            Assert.That(page.Values.Count, Is.EqualTo(2));
            Assert.That(page.Values[0].Name, Is.EqualTo("bar"));
            Assert.That(page.Values[1].Name, Is.EqualTo("baz"));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetPathsAsync_CreationTimeExpiryTime()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient fileClient = InstrumentClient(test.Container.GetFileClient(GetNewFileName()));
            await fileClient.CreateAsync();
            DataLakeFileScheduleDeletionOptions options = new DataLakeFileScheduleDeletionOptions(expiresOn: Recording.UtcNow.AddDays(1));
            await fileClient.ScheduleDeletionAsync(options);

            // Act
            IList<PathItem> paths = await test.Container.GetPathsAsync().ToListAsync();

            // Assert
            Response<PathProperties> pathPropertiesResponse = await fileClient.GetPropertiesAsync();
            Assert.That(paths.Count, Is.EqualTo(1));
            Assert.That(paths[0].Name, Is.EqualTo(fileClient.Name));

            // the CreatedOn value returned by GetPaths() is more precise than GetProperties().
            DateTimeOffset getPathsCreatedOnRounded = new DateTimeOffset(
                paths[0].CreatedOn.Value.Year,
                paths[0].CreatedOn.Value.Month,
                paths[0].CreatedOn.Value.Day,
                paths[0].CreatedOn.Value.Hour,
                paths[0].CreatedOn.Value.Minute,
                paths[0].CreatedOn.Value.Second,
                TimeSpan.Zero);
            Assert.That(getPathsCreatedOnRounded, Is.EqualTo(pathPropertiesResponse.Value.CreatedOn));

            Assert.That(paths[0].ExpiresOn, Is.EqualTo(pathPropertiesResponse.Value.ExpiresOn));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetPathsAsync_NoExpiryTime()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient fileClient = InstrumentClient(test.Container.GetFileClient(GetNewFileName()));
            await fileClient.CreateAsync();

            // Act
            IList<PathItem> paths = await test.Container.GetPathsAsync().ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(1));
            Assert.That(paths[0].Name, Is.EqualTo(fileClient.Name));
            Assert.That(paths[0].ExpiresOn, Is.Null);
        }

        [RecordedTest]
        public async Task GetPathsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.GetPathsAsync().ToListAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("FilesystemNotFound")));
        }

        [RecordedTest]
        [RetryOnException(5, typeof(RequestFailedException))]
        public async Task GetPathsAsync_NonHns()
        {
            await using DisposingFileSystem test = await GetNewFileSystem(hnsEnabled: false);

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync();
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(3));
            Assert.That(paths[0].Name, Is.EqualTo("bar"));
            Assert.That(paths[1].Name, Is.EqualTo("baz"));
            Assert.That(paths[2].Name, Is.EqualTo("foo"));
            Assert.That(paths[0].CreatedOn, Is.Not.Null);
            Assert.That(paths[1].CreatedOn, Is.Not.Null);
            Assert.That(paths[2].CreatedOn, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetPathsAsync_BeginFrom()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            await SetUpFileSystemForListing(test.FileSystem);

            DataLakeGetPathsOptions options = new DataLakeGetPathsOptions
            {
                Recursive = true,
                StartFrom = "foo"
            };

            // Act
            AsyncPageable<PathItem> response = test.FileSystem.GetPathsAsync(options);
            IList<PathItem> paths = await response.ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(3));
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.PublicAccess, Is.EqualTo(PublicAccessType.None));
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeRequestConditions.IfMatch))]
        [TestCase(nameof(DataLakeRequestConditions.IfNoneMatch))]
        [TestCase(nameof(DataLakeRequestConditions.IfModifiedSince))]
        [TestCase(nameof(DataLakeRequestConditions.IfUnmodifiedSince))]
        public async Task GetPropertiesAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());

            DataLakeRequestConditions conditions = new DataLakeRequestConditions();

            switch (invalidCondition)
            {
                case nameof(DataLakeRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(DataLakeRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
                case nameof(DataLakeRequestConditions.IfModifiedSince):
                    conditions.IfModifiedSince = new DateTimeOffset();
                    break;
                case nameof(DataLakeRequestConditions.IfUnmodifiedSince):
                    conditions.IfUnmodifiedSince = new DateTimeOffset();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                fileSystemClient.GetPropertiesAsync(
                    conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"GetProperties does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileService = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileService.GetPropertiesAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task SetMetadataAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await test.FileSystem.SetMetadataAsync(metadata);

            // Assert
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();
            AssertDictionaryEquality(metadata, response.Value.Metadata);
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeRequestConditions.IfUnmodifiedSince))]
        [TestCase(nameof(DataLakeRequestConditions.IfMatch))]
        [TestCase(nameof(DataLakeRequestConditions.IfNoneMatch))]
        public async Task SetMetadataAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());

            IDictionary<string, string> metadata = BuildMetadata();
            DataLakeRequestConditions conditions = new DataLakeRequestConditions();

            switch (invalidCondition)
            {
                case nameof(DataLakeRequestConditions.IfUnmodifiedSince):
                    conditions.IfUnmodifiedSince = new DateTimeOffset();
                    break;
                case nameof(DataLakeRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(DataLakeRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                fileSystemClient.SetMetadataAsync(
                    metadata: metadata,
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"SetMetadata does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient container = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                container.SetMetadataAsync(metadata),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task SetMetadataAsync_Conditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                parameters.LeaseId = await SetupFileSystemLeaseCondition(fileSystem, parameters.LeaseId, garbageLeaseId);
                IDictionary<string, string> metadata = BuildMetadata();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                Response<FileSystemInfo> response = await fileSystem.SetMetadataAsync(
                    metadata: metadata,
                    conditions: conditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

                // Cleanup
                await fileSystem.DeleteIfExistsAsync(new DataLakeRequestConditions
                {
                    LeaseId = parameters.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task SetMetadataAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            AccessConditionParameters[] data = new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { LeaseId = garbageLeaseId }
            };
            foreach (AccessConditionParameters parameters in data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: false,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.FileSystem.SetMetadataAsync(
                        metadata: metadata,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task CreateFileAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            string fileName = GetNewFileName();
            Response<DataLakeFileClient> response = await test.FileSystem.CreateFileAsync(fileName);

            // Assert
            Assert.That(response.Value.Name, Is.EqualTo(fileName));
        }

        [RecordedTest]
        public async Task CreateFileAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            PathHttpHeaders headers = new PathHttpHeaders
            {
                ContentType = ContentType,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl
            };

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                HttpHeaders = headers,
            };

            // Act
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName(), options: options);

            // Assert
            Response<PathProperties> response = await file.GetPropertiesAsync();
            Assert.That(response.Value.ContentType, Is.EqualTo(ContentType));
            Assert.That(response.Value.ContentEncoding, Is.EqualTo(ContentEncoding));
            Assert.That(response.Value.ContentLanguage, Is.EqualTo(ContentLanguage));
            Assert.That(response.Value.ContentDisposition, Is.EqualTo(ContentDisposition));
            Assert.That(response.Value.CacheControl, Is.EqualTo(CacheControl));
        }

        [RecordedTest]
        public async Task CreateFileAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                Metadata = metadata
            };

            // Act
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(GetNewFileName(), options: options);

            // Assert
            Response<PathProperties> getPropertiesResponse = await file.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: false);
        }

        [RecordedTest]
        public async Task CreateFileAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string permissions = "0777";
            string umask = "0057";

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    Permissions = permissions,
                    Umask = umask
                }
            };

            // Act
            DataLakeFileClient file = await test.FileSystem.CreateFileAsync(
                GetNewFileName(),
                options: options);

            // Assert
            Response<PathAccessControl> response = await file.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [RecordedTest]
        public async Task CreateFileAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.CreateFileAsync(GetNewFileName()),
                e => Assert.That(e.ErrorCode, Is.EqualTo("FilesystemNotFound")));
        }

        [RecordedTest]
        public async Task DeleteFileAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string fileName = GetNewFileName();
            await test.FileSystem.CreateFileAsync(fileName);

            // Act
            await test.FileSystem.DeleteFileAsync(fileName);
        }

        [RecordedTest]
        public async Task DeleteFileAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.DeleteFileAsync(GetNewFileName()),
                e => Assert.That(e.ErrorCode, Is.EqualTo("FilesystemNotFound")));
        }

        [RecordedTest]
        public async Task CreateDirectoryAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            string directoryName = GetNewDirectoryName();
            Response<DataLakeDirectoryClient> response = await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Assert
            Assert.That(response.Value.Name, Is.EqualTo(directoryName));
        }

        [RecordedTest]
        public async Task CreateDirectoryAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.CreateDirectoryAsync(GetNewDirectoryName()),
                e => Assert.That(e.ErrorCode, Is.EqualTo("FilesystemNotFound")));
        }

        [RecordedTest]
        public async Task CreateDirectoryAsync_HttpHeaders()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            PathHttpHeaders headers = new PathHttpHeaders
            {
                ContentType = ContentType,
                ContentEncoding = ContentEncoding,
                ContentLanguage = ContentLanguage,
                ContentDisposition = ContentDisposition,
                CacheControl = CacheControl
            };

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                HttpHeaders = headers
            };

            // Act
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName(), options: options);

            // Assert
            Response<PathProperties> response = await directory.GetPropertiesAsync();
            Assert.That(response.Value.ContentType, Is.EqualTo(ContentType));
            Assert.That(response.Value.ContentEncoding, Is.EqualTo(ContentEncoding));
            Assert.That(response.Value.ContentLanguage, Is.EqualTo(ContentLanguage));
            Assert.That(response.Value.ContentDisposition, Is.EqualTo(ContentDisposition));
            Assert.That(response.Value.CacheControl, Is.EqualTo(CacheControl));
        }

        [RecordedTest]
        public async Task CreateDirectoryAsync_Metadata()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                Metadata = metadata
            };

            // Act
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(GetNewDirectoryName(), options: options);

            // Assert
            Response<PathProperties> getPropertiesResponse = await directory.GetPropertiesAsync();
            AssertMetadataEquality(metadata, getPropertiesResponse.Value.Metadata, isDirectory: true);
        }

        [RecordedTest]
        public async Task CreateDirectoryAsync_PermissionAndUmask()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string permissions = "0777";
            string umask = "0057";

            DataLakePathCreateOptions options = new DataLakePathCreateOptions
            {
                AccessOptions = new DataLakeAccessOptions
                {
                    Permissions = permissions,
                    Umask = umask
                }
            };

            // Act
            DataLakeDirectoryClient directory = await test.FileSystem.CreateDirectoryAsync(
                GetNewDirectoryName(),
                options: options);

            // Assert
            Response<PathAccessControl> response = await directory.GetAccessControlAsync();
            AssertPathPermissionsEquality(PathPermissions.ParseSymbolicPermissions("rwx-w----"), response.Value.Permissions);
        }

        [RecordedTest]
        public async Task DeleteDirectoryAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string directoryName = GetNewDirectoryName();
            await test.FileSystem.CreateDirectoryAsync(directoryName);

            // Act
            await test.FileSystem.DeleteDirectoryAsync(directoryName);
        }

        [RecordedTest]
        public async Task DeleteDirectoryAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.DeleteDirectoryAsync(GetNewDirectoryName()),
                e => Assert.That(e.ErrorCode, Is.EqualTo("FilesystemNotFound")));
        }

        [RecordedTest]
        public async Task AquireLeaseAsync()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateIfNotExistsAsync();
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

            // Assert
            Assert.That(response.Value.LeaseId, Is.EqualTo(id));

            // Cleanup
            await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
            {
                LeaseId = response.Value.LeaseId
            });
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task AcquireLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            TimeSpan duration = TimeSpan.FromSeconds(15);
            DataLakeLeaseClient leaseClient = InstrumentClient(fileSystemClient.GetDataLakeLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.AcquireAsync(
                    duration,
                    conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"Acquire does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(
                    duration: duration,
                    conditions: conditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = response.Value.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task AcquireLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(
                        duration: duration,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task RenewLeaseAsync()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateIfNotExistsAsync();

            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);

            Response<Models.DataLakeLease> leaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(
                duration: duration);

            // Act
            Response<Models.DataLakeLease> renewResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(leaseResponse.Value.LeaseId)).RenewAsync();

            // Assert
            Assert.That(renewResponse.GetRawResponse().Headers.RequestId, Is.Not.Null);

            // Cleanup
            await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
            {
                LeaseId = renewResponse.Value.LeaseId
            });
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task RenewLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            DataLakeLeaseClient leaseClient = InstrumentClient(fileSystemClient.GetDataLakeLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.RenewAsync(
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"Release does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).ReleaseAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);
                DataLakeLeaseClient lease = InstrumentClient(fileSystem.GetDataLakeLeaseClient(id));
                _ = await lease.AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await lease.RenewAsync(conditions: conditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = response.Value.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task RenewLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(fileSystem.GetDataLakeLeaseClient(id));
                Response<DataLakeLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.RenewAsync(conditions: conditions),
                    e => { });

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<DataLakeLease> leaseResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);

            // Act
            Response<ReleasedObjectInfo> releaseResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(leaseResponse.Value.LeaseId)).ReleaseAsync();

            // Assert
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();

            Assert.That(response.Value.LeaseStatus, Is.EqualTo(DataLakeLeaseStatus.Unlocked));
            Assert.That(response.Value.LeaseState, Is.EqualTo(DataLakeLeaseState.Available));
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task ReleaseLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            DataLakeLeaseClient leaseClient = InstrumentClient(fileSystemClient.GetDataLakeLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.ReleaseAsync(
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"Release does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).ReleaseAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                await using DisposingFileSystem test = await GetNewFileSystem();

                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id));
                Response<DataLakeLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                Response<ReleasedObjectInfo> response = await lease.ReleaseAsync(conditions: conditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task ReleaseLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                DataLakeLeaseClient lease = InstrumentClient(fileSystem.GetDataLakeLeaseClient(id));
                Response<DataLakeLease> aquireLeaseResponse = await lease.AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    lease.ReleaseAsync(conditions: conditions),
                    e => { });

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            Response<DataLakeLease> leaseResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);
            var newId = Recording.Random.NewGuid().ToString();

            // Act
            Response<DataLakeLease> changeResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).ChangeAsync(newId);

            // Assert
            Assert.That(changeResponse.Value.LeaseId, Is.EqualTo(newId));

            // Cleanup
            await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(changeResponse.Value.LeaseId)).ReleaseAsync();
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task ChangeLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            DataLakeLeaseClient leaseClient = InstrumentClient(fileSystemClient.GetDataLakeLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.ChangeAsync(
                    id,
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"Change does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).ChangeAsync(id),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();

                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<DataLakeLease> aquireLeaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                    proposedId: newId,
                    conditions: conditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

                // Cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = response.Value.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task ChangeLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var newId = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<DataLakeLease> aquireLeaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(fileSystem.GetDataLakeLeaseClient(aquireLeaseResponse.Value.LeaseId)).ChangeAsync(
                        proposedId: newId,
                        conditions: conditions),
                    e => { });

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task BreakLeaseAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            var id = Recording.Random.NewGuid().ToString();
            var duration = TimeSpan.FromSeconds(15);
            await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration);
            TimeSpan breakPeriod = TimeSpan.FromSeconds(0);

            // Act
            Response<DataLakeLease> breakResponse = await InstrumentClient(test.FileSystem.GetDataLakeLeaseClient()).BreakAsync(breakPeriod);

            // Assert
            Response<FileSystemProperties> response = await test.FileSystem.GetPropertiesAsync();
            Assert.That(response.Value.LeaseStatus, Is.EqualTo(DataLakeLeaseStatus.Unlocked));
            Assert.That(response.Value.LeaseState, Is.EqualTo(DataLakeLeaseState.Broken));
        }

        [RecordedTest]
        [TestCase(nameof(RequestConditions.IfMatch))]
        [TestCase(nameof(RequestConditions.IfNoneMatch))]
        public async Task BreakLeaseAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient containerClient = new DataLakeFileSystemClient(uri, GetOptions());
            string id = Recording.Random.NewGuid().ToString();
            DataLakeLeaseClient leaseClient = InstrumentClient(containerClient.GetDataLakeLeaseClient(id));

            RequestConditions conditions = new RequestConditions();

            switch (invalidCondition)
            {
                case nameof(RequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(RequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                leaseClient.BreakAsync(
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"Break does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            var id = Recording.Random.NewGuid().ToString();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                InstrumentClient(fileSystem.GetDataLakeLeaseClient()).BreakAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();

                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<DataLakeLease> aquireLeaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                Response<DataLakeLease> response = await InstrumentClient(fileSystem.GetDataLakeLeaseClient()).BreakAsync(
                    conditions: conditions);

                // Assert
                Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

                // Cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task BreakLeaseAsync_ConditionsFail()
        {
            foreach (AccessConditionParameters parameters in NoLease_ConditionsFail_Data)
            {
                // Arrange
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                var id = Recording.Random.NewGuid().ToString();
                var duration = TimeSpan.FromSeconds(15);

                Response<DataLakeLease> aquireLeaseResponse = await InstrumentClient(fileSystem.GetDataLakeLeaseClient(id)).AcquireAsync(duration: duration);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    InstrumentClient(fileSystem.GetDataLakeLeaseClient()).BreakAsync(
                        conditions: conditions),
                    e => { });

                // cleanup
                await fileSystem.DeleteIfExistsAsync(conditions: new DataLakeRequestConditions
                {
                    LeaseId = aquireLeaseResponse.Value.LeaseId
                });
            }
        }

        [RecordedTest]
        public async Task GetAccesPolicyAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Act
            Response<FileSystemAccessPolicy> response = await test.FileSystem.GetAccessPolicyAsync();

            // Assert
            Assert.That(response.Value.SignedIdentifiers.Count(), Is.EqualTo(0));
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeRequestConditions.IfMatch))]
        [TestCase(nameof(DataLakeRequestConditions.IfNoneMatch))]
        [TestCase(nameof(DataLakeRequestConditions.IfModifiedSince))]
        [TestCase(nameof(DataLakeRequestConditions.IfUnmodifiedSince))]
        public async Task GetAccessPolicyAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());

            DataLakeRequestConditions conditions = new DataLakeRequestConditions();

            switch (invalidCondition)
            {
                case nameof(DataLakeRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(DataLakeRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
                case nameof(DataLakeRequestConditions.IfModifiedSince):
                    conditions.IfModifiedSince = new DateTimeOffset();
                    break;
                case nameof(DataLakeRequestConditions.IfUnmodifiedSince):
                    conditions.IfUnmodifiedSince = new DateTimeOffset();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                fileSystemClient.GetAccessPolicyAsync(
                    conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"GetAccessPolicy does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.GetAccessPolicyAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task GetAccessPolicy_Lease()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
            await fileSystem.CreateIfNotExistsAsync();
            string garbageLeaseId = GetGarbageLeaseId();
            string leaseId = await SetupFileSystemLeaseCondition(fileSystem, ReceivedLeaseId, garbageLeaseId);
            DataLakeRequestConditions leaseAccessConditions = new DataLakeRequestConditions
            {
                LeaseId = leaseId
            };

            // Act
            Response<FileSystemAccessPolicy> response = await fileSystem.GetAccessPolicyAsync(
                conditions: leaseAccessConditions);

            // Assert
            Assert.That(response.Value.SignedIdentifiers.Count(), Is.EqualTo(0));

            // Cleanup
            await fileSystem.DeleteIfExistsAsync(conditions: leaseAccessConditions);
        }

        [RecordedTest]
        public async Task GetAccessPolicy_LeaseFailed()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            string garbageLeaseId = GetGarbageLeaseId();
            DataLakeRequestConditions leaseAccessConditions = new DataLakeRequestConditions
            {
                LeaseId = garbageLeaseId
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.FileSystem.GetAccessPolicyAsync(conditions: leaseAccessConditions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("LeaseNotPresentWithContainerOperation")));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2025_07_05)]
        public async Task GetSetAccesPolicy_OAuth()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_OAuth();
            await using DisposingFileSystem test = await GetNewFileSystem(service);

            // Act
            Response<FileSystemAccessPolicy> response = await test.FileSystem.GetAccessPolicyAsync();
            await test.FileSystem.SetAccessPolicyAsync(permissions: response.Value.SignedIdentifiers);
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await test.FileSystem.SetAccessPolicyAsync(
                permissions: signedIdentifiers
            );

            // Assert
            Response<FileSystemAccessPolicy> response = await test.FileSystem.GetAccessPolicyAsync();
            Assert.That(response.Value.SignedIdentifiers.Count(), Is.EqualTo(1));

            DataLakeSignedIdentifier acl = response.Value.SignedIdentifiers.First();
            Assert.That(acl.Id, Is.EqualTo(signedIdentifiers[0].Id));
            Assert.That(acl.AccessPolicy.PolicyStartsOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyStartsOn));
            Assert.That(acl.AccessPolicy.PolicyExpiresOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn));
            Assert.That(acl.AccessPolicy.Permissions, Is.EqualTo(signedIdentifiers[0].AccessPolicy.Permissions));
        }

        [RecordedTest]
        [TestCase(nameof(DataLakeRequestConditions.IfMatch))]
        [TestCase(nameof(DataLakeRequestConditions.IfNoneMatch))]
        public async Task SetAccessPolicyAsync_InvalidRequestConditions(string invalidCondition)
        {
            // Arrange
            Uri uri = new Uri("https://www.doesntmatter.com");
            DataLakeFileSystemClient fileSystemClient = new DataLakeFileSystemClient(uri, GetOptions());

            DataLakeRequestConditions conditions = new DataLakeRequestConditions();

            switch (invalidCondition)
            {
                case nameof(DataLakeRequestConditions.IfMatch):
                    conditions.IfMatch = new ETag();
                    break;
                case nameof(DataLakeRequestConditions.IfNoneMatch):
                    conditions.IfNoneMatch = new ETag();
                    break;
            }

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                fileSystemClient.SetAccessPolicyAsync(
                    conditions: conditions),
                e =>
                {
                    Assert.That(e.Message.Contains($"SetAccessPolicy does not support the {invalidCondition} condition(s)."), Is.True);
                    Assert.That(e.Message.Contains("conditions"), Is.True);
                });
        }

        [RecordedTest]
        [PlaybackOnly("Public access disabled on live test accounts.")]
        public async Task SetAccessPolicy_PublicAccessPolicy()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            PublicAccessType publicAccessType = PublicAccessType.FileSystem;

            // Act
            await test.FileSystem.SetAccessPolicyAsync(accessType: publicAccessType);

            // Assert
            DataLakeFileSystemClient publicAccessFileSystemClient
                = InstrumentClient(new DataLakeFileSystemClient(new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{test.FileSystem.Name}"), GetOptions()));
            Response<FileSystemProperties> propertiesResponse = await publicAccessFileSystemClient.GetPropertiesAsync();

            Assert.That(propertiesResponse.Value.ETag, Is.Not.Null);
        }

        [RecordedTest]
        public async Task SetAccessPolicy_SignedIdentifiers()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await test.FileSystem.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder()
            {
                FileSystemName = test.FileSystem.Name,
                Identifier = signedIdentifiers[0].Id
            };
            DataLakeSasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(Tenants.GetNewHnsSharedKeyCredentials());

            DataLakeFileSystemClient sasFileSystem
                = InstrumentClient(new DataLakeFileSystemClient(
                    new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{test.FileSystem.Name}?{sasQueryParameters}"), GetOptions()));
            await sasFileSystem.CreateDirectoryAsync(GetNewDirectoryName());
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_OldProperties()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange and Act
            DataLakeSignedIdentifier[] signedIdentifiers = new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    // Create an AccessPolicy with only StartsOn (old property)
                    AccessPolicy = new DataLakeAccessPolicy
                    {
                        StartsOn = Recording.UtcNow.AddHours(-1),
                        ExpiresOn = Recording.UtcNow.AddHours(+1)
                    }
                }
            };

            // Assert
            Assert.That(signedIdentifiers[0].AccessPolicy.StartsOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyStartsOn));
            Assert.That(signedIdentifiers[0].AccessPolicy.ExpiresOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn));

            // Act
            Response<FileSystemInfo> response = await test.FileSystem.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Response<FileSystemAccessPolicy> responseAfter = await test.FileSystem.GetAccessPolicyAsync();
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            DataLakeSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.That(responseAfter.Value.SignedIdentifiers.Count(), Is.EqualTo(1));
            Assert.That(signedIdentifierResponse.Id, Is.EqualTo(signedIdentifiers[0].Id));
            Assert.That(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyStartsOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, Is.EqualTo(signedIdentifierResponse.AccessPolicy.StartsOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn, Is.EqualTo(signedIdentifierResponse.AccessPolicy.ExpiresOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.Permissions, Is.Null);
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_StartsPermissionsProperties()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new DataLakeAccessPolicy
                    {
                        // Create an AccessPolicy without PolicyExpiresOn
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        Permissions = "rw"
                    }
                }
            };
            // Assert
            Assert.That(signedIdentifiers[0].AccessPolicy.StartsOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyStartsOn));
            Assert.That(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn, Is.Null);

            // Act
            Response<FileSystemInfo> response = await test.FileSystem.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

            Response<FileSystemAccessPolicy> responseAfter = await test.FileSystem.GetAccessPolicyAsync();
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            DataLakeSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.That(responseAfter.Value.SignedIdentifiers.Count(), Is.EqualTo(1));
            Assert.That(signedIdentifierResponse.Id, Is.EqualTo(signedIdentifiers[0].Id));
            Assert.That(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyStartsOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.StartsOn, Is.EqualTo(signedIdentifierResponse.AccessPolicy.PolicyStartsOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn, Is.Null);
            Assert.That(signedIdentifiers[0].AccessPolicy.Permissions, Is.EqualTo(signedIdentifierResponse.AccessPolicy.Permissions));
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_StartsExpiresProperties()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new DataLakeAccessPolicy
                    {
                        // Create an AccessPolicy without PolicyExpiresOn
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        PolicyExpiresOn = Recording.UtcNow.AddHours(+1)
                    }
                }
            };
            // Assert
            Assert.That(signedIdentifiers[0].AccessPolicy.StartsOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyStartsOn));
            Assert.That(signedIdentifiers[0].AccessPolicy.ExpiresOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn));

            // Act
            Response<FileSystemInfo> response = await test.FileSystem.SetAccessPolicyAsync(permissions: signedIdentifiers);

            // Assert
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);

            Response<FileSystemAccessPolicy> responseAfter = await test.FileSystem.GetAccessPolicyAsync();
            Assert.That(response.GetRawResponse().Headers.RequestId, Is.Not.Null);
            DataLakeSignedIdentifier signedIdentifierResponse = responseAfter.Value.SignedIdentifiers.First();
            Assert.That(responseAfter.Value.SignedIdentifiers.Count(), Is.EqualTo(1));
            Assert.That(signedIdentifierResponse.Id, Is.EqualTo(signedIdentifiers[0].Id));
            Assert.That(signedIdentifierResponse.AccessPolicy.PolicyStartsOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyStartsOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.StartsOn, Is.EqualTo(signedIdentifierResponse.AccessPolicy.PolicyStartsOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.ExpiresOn, Is.EqualTo(signedIdentifierResponse.AccessPolicy.PolicyExpiresOn));
            Assert.That(signedIdentifierResponse.AccessPolicy.Permissions, Is.Null);
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.SetAccessPolicyAsync(
                    permissions: signedIdentifiers),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_Conditions()
        {
            foreach (AccessConditionParameters parameters in NoLease_Conditions_Data)
            {
                // Arrange
                DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
                DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));
                await fileSystem.CreateIfNotExistsAsync();

                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: false);

                // Act
                Response<FileSystemInfo> response = await fileSystem.SetAccessPolicyAsync(
                    permissions: signedIdentifiers,
                    conditions: conditions);

                // Assert
                Assert.That(response.Value.ETag, Is.Not.Null);
            }
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_ConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in ConditionsFail_Data)
            {
                await using DisposingFileSystem test = await GetNewFileSystem();

                // Arrange
                PublicAccessType publicAccessType = PublicAccessType.FileSystem;
                DataLakeSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                parameters.LeaseId = await SetupFileSystemLeaseCondition(test.FileSystem, parameters.LeaseId, garbageLeaseId);
                DataLakeRequestConditions conditions = BuildFileSystemConditions(
                    parameters: parameters,
                    ifUnmodifiedSince: true,
                    lease: true);

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    test.FileSystem.SetAccessPolicyAsync(
                        accessType: publicAccessType,
                        permissions: signedIdentifiers,
                        conditions: conditions),
                    e => { });
            }
        }

        [RecordedTest]
        public async Task SetAccessPolicyAsync_InvalidPermissionOrder()
        {
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Arrange
            DataLakeSignedIdentifier[] signedIdentifiers = new[]
            {
                new DataLakeSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy = new DataLakeAccessPolicy()
                    {
                        PolicyStartsOn = Recording.UtcNow.AddHours(-1),
                        PolicyExpiresOn = Recording.UtcNow.AddHours(1),
                        Permissions = "wrld"
                    }
                }
            };

            // Act
            await test.FileSystem.SetAccessPolicyAsync(
                permissions: signedIdentifiers
            );

            // Assert
            Response<FileSystemAccessPolicy> response = await test.FileSystem.GetAccessPolicyAsync();
            Assert.That(response.Value.SignedIdentifiers.Count(), Is.EqualTo(1));

            DataLakeSignedIdentifier acl = response.Value.SignedIdentifiers.First();
            Assert.That(acl.Id, Is.EqualTo(signedIdentifiers[0].Id));
            Assert.That(acl.AccessPolicy.PolicyStartsOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyStartsOn));
            Assert.That(acl.AccessPolicy.PolicyExpiresOn, Is.EqualTo(signedIdentifiers[0].AccessPolicy.PolicyExpiresOn));
            Assert.That(acl.AccessPolicy.Permissions, Is.EqualTo("rwdl"));
        }

        [RecordedTest]
        public void DataLakeAccessPolicyNullStartsOnExpiresOnTest()
        {
            DataLakeAccessPolicy accessPolicy = new DataLakeAccessPolicy()
            {
                Permissions = "rw"
            };

            Assert.That(accessPolicy.StartsOn, Is.EqualTo(new DateTimeOffset()));
            Assert.That(accessPolicy.ExpiresOn, Is.EqualTo(new DateTimeOffset()));
        }

        [RecordedTest]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("my cool directory")]
        [TestCase("directory")]
        public async Task GetDirectoryClient_SpecialCharacters(string directoryName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directory = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            Uri blobUri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}");
            Uri dfsUri = new Uri($"{BlobEndpointToDfsEndpoint(TestConfigHierarchicalNamespace.BlobServiceEndpoint)}/{test.FileSystem.Name}/{Uri.EscapeDataString(directoryName)}");

            // Act
            Response<PathInfo> createResponse = await directory.CreateAsync();

            List<PathItem> pathItems = new List<PathItem>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync())
            {
                pathItems.Add(pathItem);
            }

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(directory.Uri);

            // Assert
            Assert.That(pathItems[0].Name, Is.EqualTo(directoryName));
            Assert.That(directory.Name, Is.EqualTo(directoryName));
            Assert.That(directory.Path, Is.EqualTo(directoryName));

            Assert.That(directory.Uri, Is.EqualTo(blobUri));
            Assert.That(directory.BlobUri, Is.EqualTo(blobUri));
            Assert.That(directory.DfsUri, Is.EqualTo(dfsUri));

            Assert.That(dataLakeUriBuilder.LastDirectoryOrFileName, Is.EqualTo(directoryName));
            Assert.That(dataLakeUriBuilder.DirectoryOrFilePath, Is.EqualTo(directoryName));
            Assert.That(dataLakeUriBuilder.ToUri(), Is.EqualTo(blobUri));
        }

        [RecordedTest]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase("my cool file")]
        [TestCase("file")]
        public async Task GetFileClient_SpecialCharacters(string fileName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeFileClient file = InstrumentClient(test.FileSystem.GetFileClient(fileName));
            Uri blobUri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}/{test.FileSystem.Name}/{Uri.EscapeDataString(fileName)}");
            Uri dfsUri = new Uri($"{BlobEndpointToDfsEndpoint(TestConfigHierarchicalNamespace.BlobServiceEndpoint)}/{test.FileSystem.Name}/{Uri.EscapeDataString(fileName)}");

            // Act
            Response<PathInfo> createResponse = await file.CreateAsync();

            List<PathItem> pathItems = new List<PathItem>();
            await foreach (PathItem pathItem in test.FileSystem.GetPathsAsync())
            {
                pathItems.Add(pathItem);
            }

            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(file.Uri);

            // Assert
            Assert.That(pathItems[0].Name, Is.EqualTo(fileName));
            Assert.That(file.Name, Is.EqualTo(fileName));
            Assert.That(file.Path, Is.EqualTo(fileName));

            Assert.That(file.Uri, Is.EqualTo(blobUri));
            Assert.That(file.BlobUri, Is.EqualTo(blobUri));
            Assert.That(file.DfsUri, Is.EqualTo(dfsUri));

            Assert.That(dataLakeUriBuilder.LastDirectoryOrFileName, Is.EqualTo(fileName));
            Assert.That(dataLakeUriBuilder.DirectoryOrFilePath, Is.EqualTo(fileName));
            Assert.That(dataLakeUriBuilder.ToUri(), Is.EqualTo(blobUri));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        public async Task GetDeletedPathsAsync()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();

            // Create 2 files and 2 directories.  Delete one of each.
            DataLakeFileClient deletedFile = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            DataLakeFileClient nonDeletedFile = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            DataLakeDirectoryClient deletedDirectory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));
            DataLakeDirectoryClient nonDeletedDirectory = InstrumentClient(test.FileSystem.GetDirectoryClient(GetNewDirectoryName()));

            await deletedFile.CreateAsync();
            await deletedFile.DeleteAsync();

            await nonDeletedFile.CreateAsync();

            await deletedDirectory.CreateAsync();
            await deletedDirectory.DeleteAsync();

            await nonDeletedDirectory.CreateAsync();

            // Act
            AsyncPageable<PathDeletedItem> response = test.FileSystem.GetDeletedPathsAsync();
            IList<PathDeletedItem> paths = await response.ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(2));

            Assert.That(paths[0].Path, Is.EqualTo(deletedDirectory.Name));
            Assert.That(paths[0].DeletedOn, Is.Not.Null);
            Assert.That(paths[0].DeletionId, Is.Not.Null);
            Assert.That(paths[0].RemainingRetentionDays, Is.Not.Null);

            Assert.That(paths[1].Path, Is.EqualTo(deletedFile.Name));
            Assert.That(paths[1].DeletedOn, Is.Not.Null);
            Assert.That(paths[1].DeletionId, Is.Not.Null);
            Assert.That(paths[1].RemainingRetentionDays, Is.Not.Null);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        public async Task GetDeletedPathsAsync_Path()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directoryClient.CreateAsync();
            string fileName = GetNewFileName();
            DataLakeFileClient fileClient1 = InstrumentClient(directoryClient.GetFileClient(fileName));
            await fileClient1.CreateAsync();
            await fileClient1.DeleteAsync();

            DataLakeFileClient fileClient2 = InstrumentClient(test.FileSystem.GetFileClient(GetNewFileName()));
            await fileClient2.CreateAsync();
            await fileClient2.DeleteAsync();

            // Act
            AsyncPageable<PathDeletedItem> response = test.FileSystem.GetDeletedPathsAsync(
                pathPrefix: directoryName);
            IList<PathDeletedItem> paths = await response.ToListAsync();

            // Assert
            Assert.That(paths.Count, Is.EqualTo(1));
            Assert.That(paths[0].Path, Is.EqualTo($"{directoryName}/{fileName}"));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        public async Task GetDeletedPathsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.GetDeletedPathsAsync().ToListAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        public async Task UndeletePathAsync()
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            string directoryName = GetNewDirectoryName();
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directoryClient.CreateAsync();
            await directoryClient.DeleteAsync();

            AsyncPageable<PathDeletedItem> response = test.FileSystem.GetDeletedPathsAsync();
            IList<PathDeletedItem> paths = await response.ToListAsync();
            string deletionId = paths[0].DeletionId;

            // Act
            DataLakePathClient restoredPathClient = await test.FileSystem.UndeletePathAsync(
                deletedPath: directoryName,
                deletionId: deletionId);

            // Assert
            Assert.That(restoredPathClient.GetType(), Is.EqualTo(typeof(DataLakeDirectoryClient)));
            await restoredPathClient.GetPropertiesAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        public async Task UndeletePathAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = service.GetFileSystemClient(GetNewFileSystemName());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fileSystem.UndeletePathAsync(
                    deletedPath: GetNewDirectoryName(),
                    deletionId: "132502020374991873"),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [RecordedTest]
        [TestCase("!'();[]@&%=+$,#äÄöÖüÜß;")]
        [TestCase("%21%27%28%29%3B%5B%5D%40%26%25%3D%2B%24%2C%23äÄöÖüÜß%3B")]
        [TestCase(" my cool directory ")]
        [TestCase("directory")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        public async Task UndeletePathAsync_SpecialCharacters(string directoryName)
        {
            // Arrange
            await using DisposingFileSystem test = await GetNewFileSystem();
            DataLakeDirectoryClient directoryClient = InstrumentClient(test.FileSystem.GetDirectoryClient(directoryName));
            await directoryClient.CreateAsync();
            await directoryClient.DeleteAsync();

            AsyncPageable<PathDeletedItem> response = test.FileSystem.GetDeletedPathsAsync();
            IList<PathDeletedItem> paths = await response.ToListAsync();
            string deletionId = paths[0].DeletionId;

            // Act
            DataLakePathClient restoredPathClient = await test.FileSystem.UndeletePathAsync(
                deletedPath: directoryName,
                deletionId: deletionId);

            // Assert
            await restoredPathClient.GetPropertiesAsync();
        }

        //[Test]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task Rename()
        //{
        //    // Arrange
        //    DataLakeServiceClient service = Clients.GetServiceClient_Hns();
        //    string oldFileSystemName = GetNewFileName();
        //    string newFileSystemName = GetNewFileName();
        //    DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(oldFileSystemName));
        //    await fileSystem.CreateAsync();

        //    // Act
        //    DataLakeFileSystemClient newFileSystem = await fileSystem.RenameAsync(
        //        destinationFileSystemName: newFileSystemName);

        //    // Assert
        //    await newFileSystem.GetPropertiesAsync();

        //    // Cleanup
        //    await newFileSystem.DeleteAsync();
        //}

        //[Test]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameAsync_AccountSas()
        //{
        //    // Arrange
        //    DataLakeServiceClient service = Clients.GetServiceClient_Hns();
        //    string oldFileSystemName = GetNewFileName();
        //    string newFileSystemName = GetNewFileName();
        //    DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(oldFileSystemName));
        //    await fileSystem.CreateAsync();
        //    SasQueryParameters sasQueryParameters = GetNewAccountSas();
        //    service = InstrumentClient(new DataLakeServiceClient(new Uri($"{service.Uri}?{sasQueryParameters}"), GetOptions()));
        //    DataLakeFileSystemClient sasFileSystemClient = InstrumentClient(service.GetFileSystemClient(oldFileSystemName));

        //    // Act
        //    DataLakeFileSystemClient newFileSystem = await sasFileSystemClient.RenameAsync(
        //        destinationFileSystemName: newFileSystemName);

        //    // Assert
        //    await newFileSystem.GetPropertiesAsync();

        //    // Cleanup
        //    await newFileSystem.DeleteAsync();
        //}

        //[Test]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameAsync_Error()
        //{
        //    // Arrange
        //    DataLakeServiceClient service = Clients.GetServiceClient_Hns();
        //    DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(GetNewFileSystemName()));

        //    // Act
        //    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
        //        fileSystemClient.RenameAsync(GetNewFileSystemName()),
        //        e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        //}

        //[Test]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameAsync_SourceLease()
        //{
        //    // Arrange
        //    DataLakeServiceClient service = Clients.GetServiceClient_Hns();
        //    string oldFileSystemName = GetNewFileSystemName();
        //    string newFileSystemName = GetNewFileSystemName();
        //    DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(oldFileSystemName));
        //    await fileSystem.CreateAsync();
        //    string leaseId = Recording.Random.NewGuid().ToString();

        //    DataLakeLeaseClient leaseClient = InstrumentClient(fileSystem.GetDataLakeLeaseClient(leaseId));
        //    await leaseClient.AcquireAsync(duration: TimeSpan.FromSeconds(30));

        //    DataLakeRequestConditions sourceConditions = new DataLakeRequestConditions
        //    {
        //        LeaseId = leaseId
        //    };

        //    // Act
        //    DataLakeFileSystemClient newFileSystem = await fileSystem.RenameAsync(
        //        destinationFileSystemName: newFileSystemName,
        //        sourceConditions: sourceConditions);

        //    // Assert
        //    await newFileSystem.GetPropertiesAsync();

        //    // Cleanup
        //    await newFileSystem.DeleteAsync();
        //}

        //[Test]
        //[Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameAsync_SourceLeaseFailed()
        //{
        //    // Arrange
        //    DataLakeServiceClient service = Clients.GetServiceClient_Hns();
        //    string oldFileSystemName = GetNewFileSystemName();
        //    string newFileSystemName = GetNewFileSystemName();
        //    DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(oldFileSystemName));
        //    await fileSystem.CreateAsync();
        //    string leaseId = Recording.Random.NewGuid().ToString();

        //    DataLakeRequestConditions sourceConditions = new DataLakeRequestConditions
        //    {
        //        LeaseId = leaseId
        //    };

        //    // Act
        //    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
        //        fileSystem.RenameAsync(
        //            destinationFileSystemName: newFileSystemName,
        //            sourceConditions: sourceConditions),
        //        e => Assert.AreEqual("LeaseNotPresentWithContainerOperation", e.ErrorCode));

        //    // Cleanup
        //    await fileSystem.DeleteAsync();
        //}

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

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                GetOptions()));
            Assert.That(filesystem.CanGenerateSasUri, Is.False);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem2 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.That(filesystem2.CanGenerateSasUri, Is.True);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeFileSystemClient filesystem3 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.That(filesystem3.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_GetFileClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                GetOptions()));
            DataLakeFileClient file = filesystem.GetFileClient(GetNewFileName());
            Assert.That(file.CanGenerateSasUri, Is.False);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem2 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeFileClient file2 = filesystem2.GetFileClient(GetNewFileName());
            Assert.That(file2.CanGenerateSasUri, Is.True);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeFileSystemClient filesystem3 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeFileClient file3 = filesystem3.GetFileClient(GetNewFileName());
            Assert.That(file3.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_GetDirectoryClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                GetOptions()));
            DataLakeDirectoryClient directory = filesystem.GetDirectoryClient(GetNewDirectoryName());
            Assert.That(directory.CanGenerateSasUri, Is.False);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeFileSystemClient filesystem2 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeDirectoryClient directory2 = filesystem2.GetDirectoryClient(GetNewDirectoryName());
            Assert.That(directory2.CanGenerateSasUri, Is.True);

            // Act - DataLakeFileSystemClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeFileSystemClient filesystem3 = InstrumentClient(new DataLakeFileSystemClient(
                blobEndpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeDirectoryClient directory3 = filesystem3.GetDirectoryClient(GetNewDirectoryName());
            Assert.That(directory3.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_Mockable()
        {
            // Act
            var filesystem = new Mock<DataLakeFileSystemClient>();
            filesystem.Setup(x => x.CanGenerateSasUri).Returns(false);

            // Assert
            Assert.That(filesystem.Object.CanGenerateSasUri, Is.False);

            // Act
            filesystem.Setup(x => x.CanGenerateSasUri).Returns(true);

            // Assert
            Assert.That(filesystem.Object.CanGenerateSasUri, Is.True);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            string stringToSign = null;

            // Act
            Uri sasUri = fileSystemClient.GenerateSasUri(permissions, expiresOn, out stringToSign);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateSas_Builder()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemClient.Name
            };

            string stringToSign = null;

            // Act
            Uri sasUri = fileSystemClient.GenerateSasUri(sasBuilder, out stringToSign);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };

            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateSas_BuilderNullName()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = null
            };

            // Act
            Uri sasUri = fileSystemClient.GenerateSasUri(sasBuilder);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };

            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
        }

        [RecordedTest]
        public void GenerateSas_BuilderWrongName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesytem name
            };

            // Act
            TestHelper.AssertExpectedException(
                () => fileSystemClient.GenerateSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.FileSystemName does not match Name in the Client. DataLakeSasBuilder.FileSystemName must either be left empty or match the Name in the Client"));
        }
        #endregion

        #region GenerateUserDelegationSasTests
        [RecordedTest]
        public async Task GenerateUserDelegationSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = fileSystemClient.GenerateUserDelegationSasUri(permissions, expiresOn, userDelegationKey, out stringToSign);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, fileSystemClient.AccountName)
            };
            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_Builder()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemClient.Name
            };

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = fileSystemClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey, out stringToSign);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, fileSystemClient.AccountName)
            };

            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNull()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            string stringToSign = null;
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => fileSystemClient.GenerateUserDelegationSasUri(null, userDelegationKey, out stringToSign),
                 new ArgumentNullException("builder"));
        }

        [RecordedTest]
        public void GenerateUserDelegationSas_UserDelegationKeyNull()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemClient.Name
            };

            string stringToSign = null;

            // Act
            TestHelper.AssertExpectedException(
                () => fileSystemClient.GenerateUserDelegationSasUri(sasBuilder, null, out stringToSign),
                 new ArgumentNullException("userDelegationKey"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderNullName()
        {
            var constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = null
            };

            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            Uri sasUri = fileSystemClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey);

            // Assert
            DataLakeSasBuilder sasBuilder2 = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName
            };
            DataLakeUriBuilder expectedUri = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName,
                Sas = sasBuilder2.ToSasQueryParameters(userDelegationKey, fileSystemClient.AccountName)
            };

            Assert.That(sasUri, Is.EqualTo(expectedUri.ToUri()));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderWrongName()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = GetNewFileSystemName(), // different filesytem name
            };

            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => fileSystemClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. DataLakeSasBuilder.FileSystemName does not match Name in the Client. DataLakeSasBuilder.FileSystemName must either be left empty or match the Name in the Client"));
        }

        [RecordedTest]
        public async Task GenerateUserDelegationSas_BuilderIncorrectlySetPath()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            string fileSystemName = GetNewFileSystemName();

            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            DataLakeUriBuilder dataLakeUriBuilder = new DataLakeUriBuilder(serviceUri)
            {
                FileSystemName = fileSystemName
            };

            DataLakeFileSystemSasPermissions permissions = DataLakeFileSystemSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(new DataLakeFileSystemClient(
                dataLakeUriBuilder.ToUri(),
                GetOptions()));

            DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder(permissions, expiresOn)
            {
                FileSystemName = fileSystemName,
                Path = GetNewFileName()
            };

            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> userDelegationKeyResponse = await GetServiceClient_OAuth().GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);
            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            // Act
            TestHelper.AssertExpectedException(
                () => fileSystemClient.GenerateUserDelegationSasUri(sasBuilder, userDelegationKey),
                new InvalidOperationException("SAS Uri cannot be generated. builder.Path cannot be set to create a FileSystemName SAS."));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<DataLakeFileSystemClient>(TestConfigDefault.ConnectionString, "name", new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeFileSystemClient>(TestConfigDefault.ConnectionString, "name").Object;
            mock = new Mock<DataLakeFileSystemClient>(new Uri("https://test/test"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeFileSystemClient>(new Uri("https://test/test"), Tenants.GetNewHnsSharedKeyCredentials(), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeFileSystemClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeFileSystemClient>(new Uri("https://test/test"), TestEnvironment.Credential, new DataLakeClientOptions()).Object;
        }

        private IEnumerable<AccessConditionParameters> Conditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };

        private IEnumerable<AccessConditionParameters> ConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { LeaseId = GarbageETag },
             };

        private IEnumerable<AccessConditionParameters> NoLease_Conditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate }
            };

        private IEnumerable<AccessConditionParameters> NoLease_ConditionsFail_Data
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate }
            };

        private DataLakeRequestConditions BuildFileSystemConditions(
            AccessConditionParameters parameters,
            bool ifUnmodifiedSince,
            bool lease)
        {
            DataLakeRequestConditions conditions = new DataLakeRequestConditions()
            {
                IfModifiedSince = parameters.IfModifiedSince
            };

            if (ifUnmodifiedSince)
            {
                conditions.IfUnmodifiedSince = parameters.IfUnmodifiedSince;
            }

            if (lease)
            {
                conditions.LeaseId = parameters.LeaseId;
            }

            return conditions;
        }

        private class AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string LeaseId { get; set; }
        }

        private async Task SetUpFileSystemForListing(DataLakeFileSystemClient fileSystem)
        {
            string[] pathNames = PathNames;
            DataLakeDirectoryClient[] directories = new DataLakeDirectoryClient[pathNames.Length];

            // Upload directories
            for (var i = 0; i < pathNames.Length; i++)
            {
                DataLakeDirectoryClient directory = InstrumentClient(fileSystem.GetDirectoryClient(pathNames[i]));
                directories[i] = directory;
                await directory.CreateIfNotExistsAsync();
            }
        }
    }
}
