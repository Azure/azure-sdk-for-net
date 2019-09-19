﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class ServiceClientTests : BlobTestBase
    {
        public ServiceClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (blobEndpoint, blobSecondaryEndpoint), (default, default), (default, default), (default, default));

            var service = new BlobServiceClient(connectionString.ToString(true));

            var builder = new BlobUriBuilder(service.Uri);

            Assert.AreEqual("", builder.ContainerName);
            Assert.AreEqual("", builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task ListContainersSegmentAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewContainer(out _, service: service))
            {
                // Act
                IList<Response<ContainerItem>> containers = await service.GetContainersAsync().ToListAsync();

                // Assert
                Assert.IsTrue(containers.Count() >= 1);
            }
        }

        [Test]
        public async Task ListContainersSegmentAsync_Marker()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewContainer(out BlobContainerClient container, service: service))
            {
                var marker = default(string);
                var containers = new List<ContainerItem>();

                await foreach (Page<ContainerItem> page in service.GetContainersAsync().ByPage(marker))
                {
                    containers.AddRange(page.Values);
                }

                Assert.AreNotEqual(0, containers.Count);
                Assert.AreEqual(containers.Count, containers.Select(c => c.Name).Distinct().Count());
                Assert.IsTrue(containers.Any(c => container.Uri == InstrumentClient(service.GetBlobContainerClient(c.Name)).Uri));
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ListContainersSegmentAsync_MaxResults()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewContainer(out _, service: service))
            using (GetNewContainer(out BlobContainerClient container, service: service))
            {
                // Act
                Page<ContainerItem> page = await
                    service.GetContainersAsync()
                    .ByPage(pageSizeHint: 1)
                    .FirstAsync();

                // Assert
                Assert.AreEqual(1, page.Values.Count());
            }
        }

        [Test]
        public async Task ListContainersSegmentAsync_Prefix()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            var prefix = "aaa";
            var containerName = prefix + GetNewContainerName();
            // Ensure at least one container
            using (GetNewContainer(out BlobContainerClient container, service: service, containerName: containerName))
            {
                // Act
                AsyncCollection<ContainerItem> containers = service.GetContainersAsync(new GetContainersOptions { Prefix = prefix });
                IList<Response<ContainerItem>> items = await containers.ToListAsync();
                // Assert
                Assert.AreNotEqual(0, items.Count());
                Assert.IsTrue(items.All(c => c.Value.Name.StartsWith(prefix)));
                Assert.IsNotNull(items.Single(c => c.Value.Name == containerName));
            }
        }

        [Test]
        public async Task ListContainersSegmentAsync_Metadata()
        {
            BlobServiceClient service = GetServiceClient_SharedKey();
            // Ensure at least one container
            using (GetNewContainer(out BlobContainerClient container, service: service))
            {
                // Arrange
                IDictionary<string, string> metadata = BuildMetadata();
                await container.SetMetadataAsync(metadata);

                // Act
                Response<ContainerItem> first = await service.GetContainersAsync(new GetContainersOptions { IncludeMetadata = true }).FirstAsync();

                // Assert
                Assert.IsNotNull(first.Value.Metadata);
            }
        }

        [Test]
        [AsyncOnly]
        public async Task ListContainersSegmentAsync_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetContainersAsync().ByPage(continuationToken: "garbage").FirstAsync(),
                e => Assert.AreEqual("OutOfRangeInput", e.ErrorCode));
        }

        [Test]
        public async Task GetAccountInfoAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<AccountInfo> response = await service.GetAccountInfoAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task GetAccountInfoAsync_Error()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetAccountInfoAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<BlobServiceProperties> response = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.Value.DeleteRetentionPolicy);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetPropertiesAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobServiceProperties properties = (await service.GetPropertiesAsync()).Value;
            CorsRule[] originalCors = properties.Cors.ToArray();
            properties.Cors =
                new[]
                {
                    new CorsRule
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
            properties = (await service.GetPropertiesAsync()).Value;
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
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobServiceProperties properties = (await service.GetPropertiesAsync()).Value;
            BlobServiceClient invalidService = InstrumentClient(
                new BlobServiceClient(
                    GetServiceClient_SharedKey().Uri,
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                invalidService.SetPropertiesAsync(properties),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        // Note: read-access geo-redundant replication must be enabled for test account, or this test will fail.
        [Test]
        public async Task GetStatisticsAsync()
        {
            // Arrange
            // "-secondary" is required by the server
            BlobServiceClient service = InstrumentClient(
                new BlobServiceClient(
                    new Uri(TestConfigDefault.BlobServiceSecondaryEndpoint),
                    GetNewSharedKeyCredentials(),
                    GetOptions()));

            // Act
            Response<BlobServiceStatistics> response = await service.GetStatisticsAsync();

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OauthAccount();

            // Act
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(start: null, expiry: Recording.UtcNow.AddHours(1));

            // Assert
            Assert.IsNotNull(response.Value);
        }

        [Test]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetUserDelegationKeyAsync(start: null, expiry: Recording.UtcNow.AddHours(1)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task GetUserDelegationKey_ArgumentException()
        {
            // Arrange
            BlobServiceClient service = GetServiceClient_OauthAccount();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                service.GetUserDelegationKeyAsync(start: null, expiry: Recording.Now.AddHours(1)),
                e => Assert.AreEqual("expiry must be UTC", e.Message));
        }

        [Test]
        public async Task CreateBlobContainerAsync()
        {
            var name = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_SharedKey();
            try
            {
                BlobContainerClient container = InstrumentClient((await service.CreateBlobContainerAsync(name)).Value);
                Response<ContainerItem> properties = await container.GetPropertiesAsync();
                Assert.IsNotNull(properties.Value);
            }
            finally
            {
                await service.DeleteBlobContainerAsync(name);
            }
        }

        [Test]
        public async Task DeleteBlobContainerAsync()
        {
            var name = GetNewContainerName();
            BlobServiceClient service = GetServiceClient_SharedKey();
            BlobContainerClient container = InstrumentClient((await service.CreateBlobContainerAsync(name)).Value);

            await service.DeleteBlobContainerAsync(name);
            Assert.ThrowsAsync<StorageRequestFailedException>(
                async () => await container.GetPropertiesAsync());
        }
    }
}
