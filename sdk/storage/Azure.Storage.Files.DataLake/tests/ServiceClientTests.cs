// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class ServiceClientTests : DataLakeTestBase
    {
        public ServiceClientTests(bool async, DataLakeClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_OAuth();

            // Act
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(startsOn: null, expiresOn: Recording.UtcNow.AddHours(1));

            // Assert
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            DataLakeServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(startsOn: null, expiresOn: Recording.UtcNow.AddHours(1)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task DeleteFileSystemAsync()
        {
            var name = GetNewFileSystemName();
            DataLakeServiceClient service = GetServiceClient_SharedKey();
            DataLakeFileSystemClient fileSystem = InstrumentClient((await service.CreateFileSystemAsync(name)).Value);

            await service.DeleteFileSystemAsync(name);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await fileSystem.GetPropertiesAsync());
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
    }
}
