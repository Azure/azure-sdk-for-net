// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class ServiceClientTests : DataLakeTestBase
    {
        public ServiceClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        public async Task Ctor_Uri()
        {
            // Arrange
            SasQueryParameters sasQueryParameters = GetNewAccountSasCredentials();
            Uri uri = new Uri($"{TestConfigHierarchicalNamespace.BlobServiceEndpoint}?{sasQueryParameters}");
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(uri, GetOptions()));

            // Act
            await serviceClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.That(serviceClient.Uri, Is.EqualTo(uri));
        }

        [RecordedTest]
        public async Task Ctor_SharedKey()
        {
            // Arrange
            StorageSharedKeyCredential sharedKey = new StorageSharedKeyCredential(
                TestConfigHierarchicalNamespace.AccountName,
                TestConfigHierarchicalNamespace.AccountKey);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint);
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(uri, sharedKey, GetOptions()));

            // Act
            await serviceClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.That(serviceClient.Uri, Is.EqualTo(uri));
            Assert.That(serviceClient.ClientConfiguration.SharedKeyCredential, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_TokenCredential()
        {
            // Arrange
            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttps();
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(uri, tokenCredential, GetOptions()));

            // Act
            await serviceClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.That(serviceClient.Uri, Is.EqualTo(uri));
            Assert.That(serviceClient.ClientConfiguration.TokenCredential, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_ConnectionString_RoundTrip()
        {
            // Arrage
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};BlobEndpoint={TestConfigHierarchicalNamespace.BlobServiceEndpoint};FileEndpoint={TestConfigHierarchicalNamespace.FileServiceEndpoint};QueueEndpoint={TestConfigHierarchicalNamespace.QueueServiceEndpoint};TableEndpoint={TestConfigHierarchicalNamespace.TableServiceEndpoint}";
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(connectionString, GetOptions()));
            DataLakeFileSystemClient fileSystem = InstrumentClient(serviceClient.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            try
            {
                await fileSystem.CreateAsync();
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
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(connectionString, GetOptions()));
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystem = InstrumentClient(serviceClient.GetFileSystemClient(fileSystemName));

            try
            {
                await fileSystem.CreateAsync();

                Uri accountSasUri = serviceClient.GenerateAccountSasUri(
                    AccountSasPermissions.All,
                    Recording.UtcNow.AddDays(1),
                    AccountSasResourceTypes.All);

                DataLakeServiceClient sasServiceClient = InstrumentClient(new DataLakeServiceClient(accountSasUri, GetOptions()));
                DataLakeFileSystemClient sasFileSystem = InstrumentClient(sasServiceClient.GetFileSystemClient(fileSystemName));

                // Act
                await sasFileSystem.GetPropertiesAsync();
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

            DataLakeServiceClient service = new DataLakeServiceClient(connectionString.ToString(true));

            Assert.That(service.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = TestEnvironment.Credential;
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeServiceClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakeServiceClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri($"https://customdomain/");

            DataLakeServiceClient service = new DataLakeServiceClient(blobEndpoint, credentials);

            Assert.That(service.AccountName, Is.EqualTo(accountName));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            Uri uri = DataLakeClientBuilder.GetServiceClient_Hns().Uri;

            // Act
            var sasClient = InstrumentClient(new DataLakeServiceClient(uri, new AzureSasCredential(sas), GetOptions()));
            var fileSystems = await sasClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.That(fileSystems, Is.Not.Null);
            Assert.That(sasClient.ClientConfiguration.SasCredential, Is.Not.Null);
        }

        [RecordedTest]
        public void Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            Uri uri = DataLakeClientBuilder.GetServiceClient_Hns().Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new DataLakeServiceClient(uri, new AzureSasCredential(sas)),
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
                () => new DataLakeServiceClient(httpUri, dataLakeClientOptions),
                new ArgumentException("Cannot use client-provided key without HTTPS."));
        }

        [RecordedTest]
        public async Task Ctor_DefaultAudience()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(DataLakeAudience.DefaultAudience);

            DataLakeServiceClient aadServiceClient = InstrumentClient(new DataLakeServiceClient(
                service.Uri,
                GetOAuthHnsCredential(),
                options));

            // Assert
            DataLakeServiceProperties properties = await aadServiceClient.GetPropertiesAsync();
            Assert.That(properties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_CustomAudience()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(new DataLakeAudience($"https://{service.AccountName}.blob.core.windows.net/"));

            DataLakeServiceClient aadServiceClient = InstrumentClient(new DataLakeServiceClient(
                service.Uri,
                GetOAuthHnsCredential(),
                options));

            // Assert
            DataLakeServiceProperties properties = await aadServiceClient.GetPropertiesAsync();
            Assert.That(properties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_StorageAccountAudience()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(DataLakeAudience.CreateDataLakeServiceAccountAudience(service.AccountName));

            DataLakeServiceClient aadServiceClient = InstrumentClient(new DataLakeServiceClient(
                service.Uri,
                GetOAuthHnsCredential(),
                options));

            // Assert
            DataLakeServiceProperties properties = await aadServiceClient.GetPropertiesAsync();
            Assert.That(properties, Is.Not.Null);
        }

        [RecordedTest]
        public async Task Ctor_AudienceError()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            // Act - Create new blob client with the OAuth Credential and Audience
            DataLakeClientOptions options = GetOptionsWithAudience(new DataLakeAudience("https://badaudience.blob.core.windows.net"));

            DataLakeServiceClient aadServiceClient = InstrumentClient(new DataLakeServiceClient(
                service.Uri,
                new MockCredential(),
                options));

            // Assert
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                aadServiceClient.GetPropertiesAsync(),
                e => Assert.That(e.ErrorCode, Is.EqualTo("InvalidAuthenticationInfo")));
        }

        [RecordedTest]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_OAuth();

            // Act
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(
                options: getUserDelegationKeyOptions);

            // Assert
            Assert.That(response.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            // Act
            DataLakeGetUserDelegationKeyOptions getUserDelegationKeyOptions = new DataLakeGetUserDelegationKeyOptions(expiresOn: Recording.UtcNow.AddHours(1));
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(options: getUserDelegationKeyOptions),
                e => Assert.That(e.ErrorCode, Is.EqualTo("AuthenticationFailed")));
        }

        [RecordedTest]
        public async Task GetFileSystemsAsync()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            // Ensure at least one container
            await using (await GetNewFileSystem(service: service))
            {
                // Act
                IList<FileSystemItem> fileSystems = await service.GetFileSystemsAsync().ToListAsync();

                // Assert
                Assert.That(fileSystems.Count >= 1, Is.True);
                var accountName = new DataLakeUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetFileSystemsAsync_EncryptionScope()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(fileSystemName));
            DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions = new DataLakeFileSystemEncryptionScopeOptions
            {
                DefaultEncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope
            };
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                EncryptionScopeOptions = encryptionScopeOptions
            };

            await fileSystemClient.CreateAsync(options: options);

            // Act
            IList<FileSystemItem> fileSystems = await service.GetFileSystemsAsync().ToListAsync();
            FileSystemItem fileSystemItem = fileSystems.Single(r => r.Name == fileSystemName);

            // Assert
            Assert.That(fileSystemItem.Properties.DefaultEncryptionScope, Is.EqualTo(TestConfigHierarchicalNamespace.EncryptionScope));

            // Cleanup
            await fileSystemClient.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task GetFileSystemsAsync_Marker()
        {
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            // Ensure at least one container
            await using DisposingFileSystem test = await GetNewFileSystem(service: service);

            var marker = default(string);
            var fileSystems = new List<FileSystemItem>();

            await foreach (Page<FileSystemItem> page in service.GetFileSystemsAsync().AsPages(marker))
            {
                fileSystems.AddRange(page.Values);
            }

            Assert.That(fileSystems.Count, Is.Not.EqualTo(0));
            Assert.That(fileSystems.Select(c => c.Name).Distinct().Count(), Is.EqualTo(fileSystems.Count));
            Assert.That(fileSystems.Any(c => test.FileSystem.Uri == InstrumentClient(service.GetFileSystemClient(c.Name)).Uri), Is.True);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetFileSystemsAsync_MaxResults()
        {
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            // Ensure at least one container
            await GetNewFileSystem(service: service);
            await using DisposingFileSystem test = await GetNewFileSystem(service: service);

            // Act
            Page<FileSystemItem> page = await
                service.GetFileSystemsAsync()
                .AsPages(pageSizeHint: 1)
                .FirstAsync();

            // Assert
            Assert.That(page.Values.Count(), Is.EqualTo(1));
        }

        [RecordedTest]
        public async Task GetFileSystemsAsync_Prefix()
        {
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            var prefix = "aaa";
            var fileSystemName = prefix + GetNewFileSystemName();
            // Ensure at least one container
            await using DisposingFileSystem test = await GetNewFileSystem(service: service, fileSystemName: fileSystemName);

            // Act
            AsyncPageable<FileSystemItem> fileSystems = service.GetFileSystemsAsync(prefix: prefix);
            IList<FileSystemItem> items = await fileSystems.ToListAsync();
            // Assert
            Assert.That(items.Count(), Is.Not.EqualTo(0));
            Assert.That(items.All(c => c.Name.StartsWith(prefix)), Is.True);
            Assert.That(items.Single(c => c.Name == fileSystemName), Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetFileSystemsAsync_Metadata()
        {
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            // Ensure at least one container
            await using DisposingFileSystem test = await GetNewFileSystem(service: service);

            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            await test.FileSystem.SetMetadataAsync(metadata);

            // Act
            IList<FileSystemItem> items = await service.GetFileSystemsAsync(FileSystemTraits.Metadata).ToListAsync();

            // Assert
            AssertDictionaryEquality(
                metadata,
                items.Where(i => i.Name == test.FileSystem.Name).FirstOrDefault().Properties.Metadata);
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task GetFileSystemsAsync_Deleted()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(fileSystemName));
            await fileSystemClient.CreateAsync();
            await fileSystemClient.DeleteAsync();

            // Act
            IList<FileSystemItem> fileSystems = await service.GetFileSystemsAsync(states: FileSystemStates.Deleted).ToListAsync();
            FileSystemItem fileSystemItem = fileSystems.Where(c => c.Name == fileSystemName).FirstOrDefault();

            // Assert
            Assert.That(fileSystemItem.IsDeleted, Is.True);
            Assert.That(fileSystemItem.VersionId, Is.Not.Null);
            Assert.That(fileSystemItem.Properties.DeletedOn, Is.Not.Null);
            Assert.That(fileSystemItem.Properties.RemainingRetentionDays, Is.Not.Null);
        }

        [RecordedTest]
        [PlaybackOnly("Enabling static website is not allowed on Network Security Perimeter enabled accounts.")]
        [NonParallelizable]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_10_02)]
        public async Task GetFileSystemsAsync_System()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            DataLakeServiceProperties properties = await service.GetPropertiesAsync();
            DataLakeStaticWebsite originalStaticWebsite = properties.StaticWebsite;
            string errorDocument404Path = "error/404.html";
            string defaultIndexDocumentPath = "index2.html";
            properties.StaticWebsite = new DataLakeStaticWebsite
            {
                Enabled = true,
                ErrorDocument404Path = errorDocument404Path,
                DefaultIndexDocumentPath = defaultIndexDocumentPath
            };

            // Act
            await service.SetPropertiesAsync(properties);

            // Act
            IList<FileSystemItem> fileSystems = await service.GetFileSystemsAsync(states: FileSystemStates.System).ToListAsync();
            FileSystemItem webFileSystemItem = fileSystems.Where(r => r.Name == "$web").FirstOrDefault();

            // Assert
            Assert.That(fileSystems.Count > 0, Is.True);
            Assert.That(webFileSystemItem, Is.Not.Null);

            // Cleanup
            properties = await service.GetPropertiesAsync();
            properties.StaticWebsite = originalStaticWebsite;
            await service.SetPropertiesAsync(properties);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetFileSystemsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetFileSystemsAsync().AsPages(continuationToken: "garbage").FirstAsync(),
                e =>
                {
                    Assert.That(e.ErrorCode, Is.EqualTo("OutOfRangeInput"));
                    Assert.That(e.Message.Split('\n')[0], Is.EqualTo("One of the request inputs is out of range."));
                });
        }

        [RecordedTest]
        public async Task CreateFileSystemAsync()
        {
            var name = GetNewFileSystemName();
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            try
            {
                DataLakeFileSystemClient fileSystem = InstrumentClient((await service.CreateFileSystemAsync(name)).Value);
                Response<FileSystemProperties> properties = await fileSystem.GetPropertiesAsync();
                Assert.That(properties.Value, Is.Not.Null);
            }
            finally
            {
                await service.DeleteFileSystemAsync(name);
            }
        }

        [RecordedTest]
        public async Task CreateFileSystemAsync_EncryptionScopeOptions()
        {
            var name = GetNewFileSystemName();
            DataLakeFileSystemEncryptionScopeOptions encryptionScopeOptions = new DataLakeFileSystemEncryptionScopeOptions
            {
                DefaultEncryptionScope = TestConfigHierarchicalNamespace.EncryptionScope
            };
            DataLakeFileSystemCreateOptions options = new DataLakeFileSystemCreateOptions
            {
                EncryptionScopeOptions = encryptionScopeOptions
            };
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            try
            {
                DataLakeFileSystemClient fileSystem = InstrumentClient((await service.CreateFileSystemAsync(name, options: options)).Value);
                Response<FileSystemProperties> properties = await fileSystem.GetPropertiesAsync();
                Assert.That(properties.Value.DefaultEncryptionScope, Is.EqualTo(TestConfigHierarchicalNamespace.EncryptionScope));
            }
            finally
            {
                await service.DeleteFileSystemAsync(name);
            }
        }

        [RecordedTest]
        public async Task DeleteFileSystemAsync()
        {
            var name = GetNewFileSystemName();
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeFileSystemClient fileSystem = InstrumentClient((await service.CreateFileSystemAsync(name)).Value);

            await service.DeleteFileSystemAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await fileSystem.GetPropertiesAsync());
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UndeleteFileSystemAsync()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSystemName));
            await fileSystem.CreateAsync();
            await fileSystem.DeleteAsync();
            IList<FileSystemItem> fileSystems = await service.GetFileSystemsAsync(states: FileSystemStates.Deleted).ToListAsync();
            FileSystemItem fileSystemItem = fileSystems.Where(c => c.Name == fileSystemName).FirstOrDefault();

            // It takes some time for the FileSystem to be deleted.
            await Delay(30000);

            // Act
            Response<DataLakeFileSystemClient> response = await service.UndeleteFileSystemAsync(
                fileSystemItem.Name,
                fileSystemItem.VersionId);

            // Assert
            await response.Value.GetPropertiesAsync();

            // Cleanup
            await response.Value.DeleteAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_02_10)]
        public async Task UndeleteFileSystemAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            string fileSytemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSytemName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.UndeleteFileSystemAsync(GetNewFileSystemName(), "01D60F8BB59A4652"),
                e => Assert.That(e.ErrorCode, Is.EqualTo("ContainerNotFound")));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();

            // Act
            Response<DataLakeServiceProperties> response = await service.GetPropertiesAsync();

            // Assert
            Assert.That(response.Value.DeleteRetentionPolicy, Is.Not.Null);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = InstrumentClient(
                new DataLakeServiceClient(
                    DataLakeClientBuilder.GetServiceClient_Hns().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetPropertiesAsync(),
                e => { });
        }

        [Test]
        [NonParallelizable]
        [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/20923")]
        public async Task SetPropertiesAsync_DeleteRetentionPolicy()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeServiceProperties properties = await service.GetPropertiesAsync();
            DataLakeRetentionPolicy originalRetentionPolicy = properties.DeleteRetentionPolicy;
            properties.DeleteRetentionPolicy = new DataLakeRetentionPolicy
            {
                Enabled = true,
                Days = 3
            };

            // Act
            await service.SetPropertiesAsync(properties);

            // Assert
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.DeleteRetentionPolicy.Enabled, Is.True);
            Assert.That(properties.DeleteRetentionPolicy.Days, Is.EqualTo(3));

            // Cleanup
            properties.DeleteRetentionPolicy = originalRetentionPolicy;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.DeleteRetentionPolicy.Enabled, Is.EqualTo(originalRetentionPolicy.Enabled));
            Assert.That(properties.DeleteRetentionPolicy.Days, Is.EqualTo(originalRetentionPolicy.Days));
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync_Logging()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeServiceProperties properties = await service.GetPropertiesAsync();
            DataLakeAnalyticsLogging originalLogging = properties.Logging;
            properties.Logging = new DataLakeAnalyticsLogging
            {
                Version = "1.0",
                Delete = true,
                Read = true,
                Write = true,
                RetentionPolicy = new DataLakeRetentionPolicy
                {
                    Enabled = true,
                    Days = 1
                }
            };

            // Act
            await service.SetPropertiesAsync(properties);

            // Assert
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.Logging.Version, Is.EqualTo("1.0"));
            Assert.That(properties.Logging.Delete, Is.True);
            Assert.That(properties.Logging.Read, Is.True);
            Assert.That(properties.Logging.Write, Is.True);
            Assert.That(properties.Logging.RetentionPolicy.Enabled, Is.True);
            Assert.That(properties.Logging.RetentionPolicy.Days, Is.EqualTo(1));

            // Cleanup
            properties.Logging = originalLogging;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.Logging.RetentionPolicy.Days, Is.EqualTo(originalLogging.RetentionPolicy.Days));
        }

        [Test]
        [NonParallelizable]
        public async Task SetProperties_HourAndMinuteMetrics()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeServiceProperties properties = await service.GetPropertiesAsync();
            DataLakeMetrics originalHourMetrics = properties.HourMetrics;
            DataLakeMetrics originalMinuteMetrics = properties.MinuteMetrics;

            properties.HourMetrics = new DataLakeMetrics
            {
                Version = "1.0",
                Enabled = true,
                RetentionPolicy = new DataLakeRetentionPolicy
                {
                    Enabled = true,
                    Days = 1
                },
                IncludeApis = false
            };

            properties.MinuteMetrics = new DataLakeMetrics
            {
                Version = "1.0",
                Enabled = true,
                RetentionPolicy = new DataLakeRetentionPolicy
                {
                    Enabled = true,
                    Days = 2
                },
                IncludeApis = false
            };

            // Act
            await service.SetPropertiesAsync(properties);

            // Assert
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.HourMetrics.Version, Is.EqualTo("1.0"));
            Assert.That(properties.HourMetrics.Enabled, Is.True);
            Assert.That(properties.HourMetrics.RetentionPolicy.Enabled, Is.True);
            Assert.That(properties.HourMetrics.RetentionPolicy.Days, Is.EqualTo(1));
            Assert.That(properties.HourMetrics.IncludeApis, Is.False);
            Assert.That(properties.MinuteMetrics.Version, Is.EqualTo("1.0"));
            Assert.That(properties.MinuteMetrics.Enabled, Is.True);
            Assert.That(properties.MinuteMetrics.RetentionPolicy.Enabled, Is.True);
            Assert.That(properties.MinuteMetrics.RetentionPolicy.Days, Is.EqualTo(2));
            Assert.That(properties.MinuteMetrics.IncludeApis, Is.False);

            // Cleanup
            properties.HourMetrics = originalHourMetrics;
            properties.MinuteMetrics = originalMinuteMetrics;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.HourMetrics.RetentionPolicy.Days, Is.EqualTo(originalHourMetrics.RetentionPolicy.Days));
            Assert.That(properties.MinuteMetrics.RetentionPolicy.Days, Is.EqualTo(originalMinuteMetrics.RetentionPolicy.Days));
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync_Cors()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeServiceProperties properties = await service.GetPropertiesAsync();
            DataLakeCorsRule[] originalCors = properties.Cors.ToArray();
            properties.Cors =
                new[]
                {
                    new DataLakeCorsRule
                    {
                        MaxAgeInSeconds = 1000,
                        AllowedHeaders = "x-ms-meta-data*,x-ms-meta-target*,x-ms-meta-abc",
                        AllowedMethods = "PUT,GET",
                        AllowedOrigins = "*",
                        ExposedHeaders = "x-ms-meta-*"
                    }
                };

            // Act
            await service.SetPropertiesAsync(properties);

            // Assert
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.Cors.Count(), Is.EqualTo(1));
            Assert.That(properties.Cors[0].MaxAgeInSeconds, Is.EqualTo(1000));

            // Cleanup
            properties.Cors = originalCors;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.Cors.Count(), Is.EqualTo(originalCors.Count()));
        }

        [Test]
        [PlaybackOnly("Enabling static website is not allowed on Network Security Perimeter enabled accounts.")]
        [ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2019_12_12)]
        [NonParallelizable]
        public async Task SetPropertiesAsync_StaticWebsite()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeServiceProperties properties = await service.GetPropertiesAsync();
            DataLakeStaticWebsite originalStaticWebsite = properties.StaticWebsite;
            string errorDocument404Path = "error/404.html";
            string defaultIndexDocumentPath = "index2.html";
            properties.StaticWebsite = new DataLakeStaticWebsite
            {
                Enabled = true,
                ErrorDocument404Path = errorDocument404Path,
                DefaultIndexDocumentPath = defaultIndexDocumentPath
            };

            // Act
            await service.SetPropertiesAsync(properties);

            // Assert
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.StaticWebsite.Enabled, Is.True);
            Assert.That(properties.StaticWebsite.ErrorDocument404Path, Is.EqualTo(errorDocument404Path));
            Assert.That(properties.StaticWebsite.DefaultIndexDocumentPath, Is.EqualTo(defaultIndexDocumentPath));

            // Cleanup
            properties.StaticWebsite = originalStaticWebsite;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.That(properties.StaticWebsite.Enabled, Is.EqualTo(originalStaticWebsite.Enabled));
            Assert.That(properties.StaticWebsite.IndexDocument, Is.EqualTo(originalStaticWebsite.IndexDocument));
            Assert.That(properties.StaticWebsite.ErrorDocument404Path, Is.EqualTo(originalStaticWebsite.ErrorDocument404Path));
            Assert.That(properties.StaticWebsite.DefaultIndexDocumentPath, Is.EqualTo(originalStaticWebsite.DefaultIndexDocumentPath));
        }

        [Test]
        public async Task SetPropertiesAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = DataLakeClientBuilder.GetServiceClient_Hns();
            DataLakeServiceProperties properties = (await service.GetPropertiesAsync()).Value;
            DataLakeServiceClient invalidService = InstrumentClient(
                new DataLakeServiceClient(
                    DataLakeClientBuilder.GetServiceClient_Hns().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                invalidService.SetPropertiesAsync(properties),
                e => { });
        }

        //[Test]
        //[PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameFileSystemAsync()
        //{
        //    // Arrange
        //    DataLakeServiceClient service = Clients.GetServiceClient_Hns();
        //    string oldFileSystemName = GetNewFileName();
        //    string newFileSystemName = GetNewFileName();
        //    DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(oldFileSystemName));
        //    await fileSystem.CreateAsync();

        //    // Act
        //    DataLakeFileSystemClient newFileSystem = await service.RenameFileSystemAsync(
        //        sourceFileSystemName: oldFileSystemName,
        //        destinationFileSystemName: newFileSystemName);

        //    // Assert
        //    await newFileSystem.GetPropertiesAsync();

        //    // Cleanup
        //    await newFileSystem.DeleteAsync();
        //}

        //[Test]
        //[PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameBlobContainerAsync_AccountSas()
        //{
        //    // Arrange
        //    DataLakeServiceClient service = Clients.GetServiceClient_Hns();
        //    string oldFileSystemName = GetNewFileName();
        //    string newFileSystemName = GetNewFileName();
        //    DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(oldFileSystemName));
        //    await fileSystem.CreateAsync();
        //    SasQueryParameters sasQueryParameters = GetNewAccountSas();
        //    service = InstrumentClient(new DataLakeServiceClient(new Uri($"{service.Uri}?{sasQueryParameters}"), GetOptions()));

        //    // Act
        //    DataLakeFileSystemClient newFileSystem = await service.RenameFileSystemAsync(
        //        destinationFileSystemName: newFileSystemName,
        //        sourceFileSystemName: oldFileSystemName);

        //    // Assert
        //    await newFileSystem.GetPropertiesAsync();

        //    // Cleanup
        //    await newFileSystem.DeleteAsync();
        //}

        //[Test]
        //[PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameFileSystemAsync_Error()
        //{
        //    // Arrange
        //    DataLakeServiceClient service = Clients.GetServiceClient_Hns();

        //    // Act
        //    await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
        //        service.RenameFileSystemAsync(GetNewFileSystemName(), GetNewFileSystemName()),
        //        e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        //}

        //[Test]
        //[PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/18257")]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameFileSystemAsync_SourceLease()
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
        //    DataLakeFileSystemClient newFileSystem = await service.RenameFileSystemAsync(
        //        sourceFileSystemName: oldFileSystemName,
        //        destinationFileSystemName: newFileSystemName,
        //        sourceConditions: sourceConditions);

        //    // Assert
        //    await newFileSystem.GetPropertiesAsync();

        //    // Cleanup
        //    await newFileSystem.DeleteAsync();
        //}

        //[Test]
        //[ServiceVersion(Min = DataLakeClientOptions.ServiceVersion.V2020_06_12)]
        //public async Task RenameFileSystemAsync_SourceLeaseFailed()
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
        //        service.RenameFileSystemAsync(
        //            sourceFileSystemName: oldFileSystemName,
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
            var uriEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (uriEndpoint, blobSecondaryEndpoint));

            // Act - DataLakeServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                GetOptions()));
            Assert.That(serviceClient.CanGenerateAccountSasUri, Is.False);

            // Act - DataLakeServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeServiceClient serviceClient2 = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.That(serviceClient2.CanGenerateAccountSasUri, Is.True);

            // Act - DataLakeServiceClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeServiceClient serviceClient3 = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.That(serviceClient3.CanGenerateAccountSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateSas_GetFileSystemClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var uriEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (uriEndpoint, blobSecondaryEndpoint));

            // Act - DataLakeServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                GetOptions()));
            DataLakeFileSystemClient fileSystemClient = serviceClient.GetFileSystemClient(GetNewFileSystemName());
            Assert.That(fileSystemClient.CanGenerateSasUri, Is.False);

            // Act - DataLakeServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeServiceClient serviceClient2 = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeFileSystemClient fileSystemClient2 = serviceClient2.GetFileSystemClient(GetNewFileSystemName());
            Assert.That(fileSystemClient2.CanGenerateSasUri, Is.True);

            // Act - DataLakeServiceClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeServiceClient serviceClient3 = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeFileSystemClient fileSystemClient3 = serviceClient3.GetFileSystemClient(GetNewFileSystemName());
            Assert.That(fileSystemClient3.CanGenerateSasUri, Is.False);
        }

        [RecordedTest]
        public void CanGenerateAccountSas_Mockable()
        {
            // Act
            var serviceClient = new Mock<DataLakeServiceClient>();
            serviceClient.Setup(x => x.CanGenerateAccountSasUri).Returns(false);

            // Assert
            Assert.That(serviceClient.Object.CanGenerateAccountSasUri, Is.False);

            // Act
            serviceClient.Setup(x => x.CanGenerateAccountSasUri).Returns(true);

            // Assert
            Assert.That(serviceClient.Object.CanGenerateAccountSasUri, Is.True);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = TestConstants.Create(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential, GetOptions()));

            string stringToSign = null;

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(
                permissions: permissions,
                expiresOn: expiresOn,
                resourceTypes: resourceTypes,
                out stringToSign);

            // Assert
            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, AccountSasServices.Blobs, resourceTypes);
            UriBuilder expectedUri = new UriBuilder(blobEndpoint)
            {
                Query = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString()
            };
            Assert.That(sasUri.ToString(), Is.EqualTo(expectedUri.Uri.ToString()));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateAccountSas_Builder()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            AccountSasServices services = AccountSasServices.Blobs;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                serviceUri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                StartsOn = startsOn
            };

            string stringToSign = null;

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder, out stringToSign);

            // Assert
            AccountSasBuilder sasBuilder2 = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                StartsOn = startsOn
            };
            UriBuilder expectedUri = new UriBuilder(serviceUri);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.That(sasUri, Is.EqualTo(expectedUri.Uri));
            Assert.That(stringToSign, Is.Not.Null);
        }

        [RecordedTest]
        public void GenerateAccountSas_WrongService_Service()
        {
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.dfs.core.windows.net");
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Files; // Wrong Service
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                serviceUri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes);

            // Add more properties on the builder
            sasBuilder.SetPermissions(permissions);

            // Act
            TestHelper.AssertExpectedException(
                () => serviceClient.GenerateAccountSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. builder.Services does specify Blobs. builder.Services must either specify Blobs or specify all Services are accessible in the value."));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<DataLakeServiceClient>(TestConfigDefault.ConnectionString, new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeServiceClient>(TestConfigDefault.ConnectionString).Object;
            mock = new Mock<DataLakeServiceClient>(new Uri("https://test/test"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeServiceClient>(new Uri("https://test/test"), Tenants.GetNewHnsSharedKeyCredentials(), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeServiceClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeServiceClient>(new Uri("https://test/test"), TestEnvironment.Credential, new DataLakeClientOptions()).Object;
        }
    }
}
