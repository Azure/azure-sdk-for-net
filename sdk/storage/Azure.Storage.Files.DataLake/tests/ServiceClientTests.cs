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
            Assert.AreEqual(uri, serviceClient.Uri);
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
            Assert.AreEqual(uri, serviceClient.Uri);
        }

        [RecordedTest]
        public async Task Ctor_TokenCredential()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttps();
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(uri, tokenCredential, GetOptions()));

            // Act
            await serviceClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.AreEqual(uri, serviceClient.Uri);
        }

        [RecordedTest]
        public async Task Ctor_ConnectionString_RoundTrip()
        {
            // Arrage
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};EndpointSuffix=core.windows.net";
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(connectionString, GetOptions()));
            DataLakeFileSystemClient fileSystem = InstrumentClient(serviceClient.GetFileSystemClient(GetNewFileSystemName()));

            // Act
            try
            {
                await fileSystem.CreateAsync();
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
            string connectionString = $"DefaultEndpointsProtocol=https;AccountName={TestConfigHierarchicalNamespace.AccountName};AccountKey={TestConfigHierarchicalNamespace.AccountKey};EndpointSuffix=core.windows.net";
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

        [RecordedTest]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigHierarchicalNamespace.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new DataLakeServiceClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));

            TestHelper.AssertExpectedException(
                () => new DataLakeServiceClient(uri, tokenCredential, new DataLakeClientOptions()),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            Uri uri = GetServiceClient_SharedKey().Uri;

            // Act
            var sasClient = InstrumentClient(new DataLakeServiceClient(uri, new AzureSasCredential(sas), GetOptions()));
            var fileSystems = await sasClient.GetFileSystemsAsync().ToListAsync();

            // Assert
            Assert.IsNotNull(fileSystems);
        }

        [RecordedTest]
        public void Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            Uri uri = GetServiceClient_SharedKey().Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new DataLakeServiceClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [RecordedTest]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_OAuth();

            // Act
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(startsOn: null, expiresOn: Recording.UtcNow.AddHours(1));

            // Assert
            Assert.IsNotNull(response.Value);
        }

        [RecordedTest]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(startsOn: null, expiresOn: Recording.UtcNow.AddHours(1)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [RecordedTest]
        public async Task GetFileSystemsAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewFileSystem(service: service))
            {
                // Act
                IList<FileSystemItem> fileSystems = await service.GetFileSystemsAsync().ToListAsync();

                // Assert
                Assert.IsTrue(fileSystems.Count >= 1);
                var accountName = new DataLakeUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
            }
        }

        [RecordedTest]
        public async Task GetFileSystemsAsync_Marker()
        {
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            await using DisposingFileSystem test = await GetNewFileSystem(service: service);

            var marker = default(string);
            var fileSystems = new List<FileSystemItem>();

            await foreach (Page<FileSystemItem> page in service.GetFileSystemsAsync().AsPages(marker))
            {
                fileSystems.AddRange(page.Values);
            }

            Assert.AreNotEqual(0, fileSystems.Count);
            Assert.AreEqual(fileSystems.Count, fileSystems.Select(c => c.Name).Distinct().Count());
            Assert.IsTrue(fileSystems.Any(c => test.FileSystem.Uri == InstrumentClient(service.GetFileSystemClient(c.Name)).Uri));
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetFileSystemsAsync_MaxResults()
        {
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            await GetNewFileSystem(service: service);
            await using DisposingFileSystem test = await GetNewFileSystem(service: service);

            // Act
            Page<FileSystemItem> page = await
                service.GetFileSystemsAsync()
                .AsPages(pageSizeHint: 1)
                .FirstAsync();

            // Assert
            Assert.AreEqual(1, page.Values.Count());
        }

        [RecordedTest]
        public async Task GetFileSystemsAsync_Prefix()
        {
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            var prefix = "aaa";
            var fileSystemName = prefix + GetNewFileSystemName();
            // Ensure at least one container
            await using DisposingFileSystem test = await GetNewFileSystem(service: service, fileSystemName: fileSystemName);

            // Act
            AsyncPageable<FileSystemItem> fileSystems = service.GetFileSystemsAsync(prefix: prefix);
            IList<FileSystemItem> items = await fileSystems.ToListAsync();
            // Assert
            Assert.AreNotEqual(0, items.Count());
            Assert.IsTrue(items.All(c => c.Name.StartsWith(prefix)));
            Assert.IsNotNull(items.Single(c => c.Name == fileSystemName));
        }

        [RecordedTest]
        public async Task GetFileSystemsAsync_Metadata()
        {
            DataLakeServiceClient service = GetServiceClient_SharedKey();
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
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            string fileSystemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystemClient = InstrumentClient(service.GetFileSystemClient(fileSystemName));
            await fileSystemClient.CreateAsync();
            await fileSystemClient.DeleteAsync();

            // Act
            IList<FileSystemItem> fileSystems = await service.GetFileSystemsAsync(states: FileSystemStates.Deleted).ToListAsync();
            FileSystemItem fileSystemItem = fileSystems.Where(c => c.Name == fileSystemName).FirstOrDefault();

            // Assert
            Assert.IsTrue(fileSystemItem.IsDeleted);
            Assert.IsNotNull(fileSystemItem.VersionId);
            Assert.IsNotNull(fileSystemItem.Properties.DeletedOn);
            Assert.IsNotNull(fileSystemItem.Properties.RemainingRetentionDays);
        }

        [RecordedTest]
        [AsyncOnly]
        public async Task GetFileSystemsAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetFileSystemsAsync().AsPages(continuationToken: "garbage").FirstAsync(),
                e =>
                {
                    Assert.AreEqual("OutOfRangeInput", e.ErrorCode);
                    Assert.AreEqual("One of the request inputs is out of range.", e.Message.Split('\n')[0]);
                });
        }

        [RecordedTest]
        public async Task CreateFileSystemAsync()
        {
            var name = GetNewFileSystemName();
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            try
            {
                DataLakeFileSystemClient fileSystem = InstrumentClient((await service.CreateFileSystemAsync(name)).Value);
                Response<FileSystemProperties> properties = await fileSystem.GetPropertiesAsync();
                Assert.IsNotNull(properties.Value);
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
            DataLakeServiceClient service = GetServiceClient_SharedKey();
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
            DataLakeServiceClient service = GetServiceClient_SharedKey();
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
                fileSystemItem.VersionId,
                GetNewFileSystemName());

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
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            string fileSytemName = GetNewFileSystemName();
            DataLakeFileSystemClient fileSystem = InstrumentClient(service.GetFileSystemClient(fileSytemName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.UndeleteFileSystemAsync(GetNewFileSystemName(), "01D60F8BB59A4652"),
                e => Assert.AreEqual("ContainerNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<DataLakeServiceProperties> response = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.DeleteRetentionPolicy);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = InstrumentClient(
                new DataLakeServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetPropertiesAsync(),
                e => { });
        }

        [Test]
        [NonParallelizable]
        [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/19575")]
        public async Task SetPropertiesAsync_DeleteRetentionPolicy()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
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
            Assert.IsTrue(properties.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(3, properties.DeleteRetentionPolicy.Days);

            // Cleanup
            properties.DeleteRetentionPolicy = originalRetentionPolicy;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.AreEqual(originalRetentionPolicy.Enabled, properties.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(originalRetentionPolicy.Days, properties.DeleteRetentionPolicy.Days);
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync_Logging()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
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
            Assert.AreEqual("1.0", properties.Logging.Version);
            Assert.IsTrue(properties.Logging.Delete);
            Assert.IsTrue(properties.Logging.Read);
            Assert.IsTrue(properties.Logging.Write);
            Assert.IsTrue(properties.Logging.RetentionPolicy.Enabled);
            Assert.AreEqual(1, properties.Logging.RetentionPolicy.Days);

            // Cleanup
            properties.Logging = originalLogging;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.AreEqual(originalLogging.RetentionPolicy.Days, properties.Logging.RetentionPolicy.Days);
        }

        [Test]
        [NonParallelizable]
        public async Task SetProperties_HourAndMinuteMetrics()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
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
            Assert.AreEqual("1.0", properties.HourMetrics.Version);
            Assert.IsTrue(properties.HourMetrics.Enabled);
            Assert.IsTrue(properties.HourMetrics.RetentionPolicy.Enabled);
            Assert.AreEqual(1, properties.HourMetrics.RetentionPolicy.Days);
            Assert.IsFalse(properties.HourMetrics.IncludeApis);
            Assert.AreEqual("1.0", properties.MinuteMetrics.Version);
            Assert.IsTrue(properties.MinuteMetrics.Enabled);
            Assert.IsTrue(properties.MinuteMetrics.RetentionPolicy.Enabled);
            Assert.AreEqual(2, properties.MinuteMetrics.RetentionPolicy.Days);
            Assert.IsFalse(properties.MinuteMetrics.IncludeApis);

            // Cleanup
            properties.HourMetrics = originalHourMetrics;
            properties.MinuteMetrics = originalMinuteMetrics;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.AreEqual(originalHourMetrics.RetentionPolicy.Days, properties.HourMetrics.RetentionPolicy.Days);
            Assert.AreEqual(originalMinuteMetrics.RetentionPolicy.Days, properties.MinuteMetrics.RetentionPolicy.Days);
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync_Cors()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
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
            Assert.AreEqual(1, properties.Cors.Count());
            Assert.IsTrue(properties.Cors[0].MaxAgeInSeconds == 1000);

            // Cleanup
            properties.Cors = originalCors;
            await service.SetPropertiesAsync(properties);
            properties = await service.GetPropertiesAsync();
            Assert.AreEqual(originalCors.Count(), properties.Cors.Count());
        }

        [Test]
        public async Task SetPropertiesAsync_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeServiceProperties properties = (await service.GetPropertiesAsync()).Value;
            DataLakeServiceClient invalidService = InstrumentClient(
                new DataLakeServiceClient(
                    GetServiceClient_SharedKey().Uri,
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
        //    DataLakeServiceClient service = GetServiceClient_SharedKey();
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
        //    DataLakeServiceClient service = GetServiceClient_SharedKey();
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
        //    DataLakeServiceClient service = GetServiceClient_SharedKey();

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
        //    DataLakeServiceClient service = GetServiceClient_SharedKey();
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
        //    DataLakeServiceClient service = GetServiceClient_SharedKey();
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
            var constants = new TestConstants(this);
            var uriEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (uriEndpoint, blobSecondaryEndpoint));

            // Act - DataLakeServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                GetOptions()));
            Assert.IsFalse(serviceClient.CanGenerateAccountSasUri);

            // Act - DataLakeServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeServiceClient serviceClient2 = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(serviceClient2.CanGenerateAccountSasUri);

            // Act - DataLakeServiceClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeServiceClient serviceClient3 = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                tokenCredentials,
                GetOptions()));
            Assert.IsFalse(serviceClient3.CanGenerateAccountSasUri);
        }

        [RecordedTest]
        public void CanGenerateSas_GetFileSystemClient()
        {
            // Arrange
            var constants = new TestConstants(this);
            var uriEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (uriEndpoint, blobSecondaryEndpoint));

            // Act - DataLakeServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                GetOptions()));
            DataLakeFileSystemClient fileSystemClient = serviceClient.GetFileSystemClient(GetNewFileSystemName());
            Assert.IsFalse(fileSystemClient.CanGenerateSasUri);

            // Act - DataLakeServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            DataLakeServiceClient serviceClient2 = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            DataLakeFileSystemClient fileSystemClient2 = serviceClient2.GetFileSystemClient(GetNewFileSystemName());
            Assert.IsTrue(fileSystemClient2.CanGenerateSasUri);

            // Act - DataLakeServiceClient(Uri blobContainerUri, TokenCredential credential, BlobClientOptions options = default)
            var tokenCredentials = new DefaultAzureCredential();
            DataLakeServiceClient serviceClient3 = InstrumentClient(new DataLakeServiceClient(
                uriEndpoint,
                tokenCredentials,
                GetOptions()));
            DataLakeFileSystemClient fileSystemClient3 = serviceClient3.GetFileSystemClient(GetNewFileSystemName());
            Assert.IsFalse(fileSystemClient3.CanGenerateSasUri);
        }

        [RecordedTest]
        public void CanGenerateAccountSas_Mockable()
        {
            // Act
            var serviceClient = new Mock<DataLakeServiceClient>();
            serviceClient.Setup(x => x.CanGenerateAccountSasUri).Returns(false);

            // Assert
            Assert.IsFalse(serviceClient.Object.CanGenerateAccountSasUri);

            // Act
            serviceClient.Setup(x => x.CanGenerateAccountSasUri).Returns(true);

            // Assert
            Assert.IsTrue(serviceClient.Object.CanGenerateAccountSasUri);
        }

        [RecordedTest]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
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

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(
                permissions: permissions,
                expiresOn: expiresOn,
                resourceTypes: resourceTypes);

            // Assert
            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, AccountSasServices.Blobs, resourceTypes);
            UriBuilder expectedUri = new UriBuilder(blobEndpoint)
            {
                Query = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString()
            };
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [RecordedTest]
        public void GenerateAccountSas_Builder()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            AccountSasServices services = AccountSasServices.Blobs;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential, GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder);

            // Assert
            AccountSasBuilder sasBuilder2 = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                StartsOn = startsOn
            };
            UriBuilder expectedUri = new UriBuilder(blobEndpoint);
            expectedUri.Query += sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [RecordedTest]
        public void GenerateAccountSas_WrongService_Service()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, blobStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Files; // Wrong Service
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            DataLakeServiceClient serviceClient = InstrumentClient(new DataLakeServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential, GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            // Add more properties on the builder
            sasBuilder.SetPermissions(permissions);

            // Act
            try
            {
                Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder);

                Assert.Fail("BlobContainerClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                // the correct exception came back
            }
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<DataLakeServiceClient>(TestConfigDefault.ConnectionString, new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeServiceClient>(TestConfigDefault.ConnectionString).Object;
            mock = new Mock<DataLakeServiceClient>(new Uri("https://test/test"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeServiceClient>(new Uri("https://test/test"), GetNewSharedKeyCredentials(), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeServiceClient>(new Uri("https://test/test"), new AzureSasCredential("foo"), new DataLakeClientOptions()).Object;
            mock = new Mock<DataLakeServiceClient>(new Uri("https://test/test"), GetOAuthCredential(TestConfigHierarchicalNamespace), new DataLakeClientOptions()).Object;
        }
    }
}
