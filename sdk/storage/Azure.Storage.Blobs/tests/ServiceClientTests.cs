// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Storage.Blobs.Test
{
    [TestClass]
    public class ServiceClientTests
    {
        [TestMethod]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var blobEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (blobEndpoint, blobSecondaryEndpoint), (default, default), (default, default), (default, default));

            var service = new BlobServiceClient(connectionString.ToString(true), TestHelper.GetOptions<BlobConnectionOptions>());

            var builder = new BlobUriBuilder(service.Uri);

            Assert.AreEqual("", builder.ContainerName);
            Assert.AreEqual("", builder.BlobName);
            Assert.AreEqual("accountName", builder.AccountName);
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ListContainersSegmentAsync()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            // Ensure at least one container
            using (TestHelper.GetNewContainer(out _, service: service))
            {
                // Act
                var response = await service.ListContainersSegmentAsync();

                // Assert
                Assert.IsTrue(response.Value.ContainerItems.Count() >= 1);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ListContainersSegmentAsync_Marker()
        {
            var service = TestHelper.GetServiceClient_SharedKey();
            // Ensure at least one container
            using (TestHelper.GetNewContainer(out var container, service: service))
            {
                var marker = default(string);
                ContainersSegment containersSegment;

                var containers = new List<ContainerItem>();

                do
                {
                    containersSegment = await service.ListContainersSegmentAsync(marker: marker);

                    containers.AddRange(containersSegment.ContainerItems);

                    marker = containersSegment.NextMarker;
                }
                while (!String.IsNullOrWhiteSpace(marker));

                Assert.AreNotEqual(0, containers.Count);
                Assert.AreEqual(containers.Count, containers.Select(c => c.Name).Distinct().Count());
                Assert.IsTrue(containers.Any(c => container.Uri == service.GetBlobContainerClient(c.Name).Uri));
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ListContainersSegmentAsync_MaxResults()
        {
            var service = TestHelper.GetServiceClient_SharedKey();
            // Ensure at least one container
            using (TestHelper.GetNewContainer(out _, service: service))
            using (TestHelper.GetNewContainer(out var container, service: service))
            {
                // Act
                var response = await service.ListContainersSegmentAsync(options: new ContainersSegmentOptions
                {
                    MaxResults = 1
                });

                // Assert
                Assert.AreEqual(1, response.Value.ContainerItems.Count());
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ListContainersSegmentAsync_Prefix()
        {
            var service = TestHelper.GetServiceClient_SharedKey();
            var prefix = "aaa";
            var containerName = prefix + TestHelper.GetNewContainerName();
            // Ensure at least one container
            using (TestHelper.GetNewContainer(out var container, service: service, containerName: containerName))
            {
                // Act
                var response = await service.ListContainersSegmentAsync(options: new ContainersSegmentOptions
                {
                    Prefix = prefix
                });

                // Assert
                Assert.AreNotEqual(0, response.Value.ContainerItems.Count());
                Assert.IsTrue(response.Value.ContainerItems.All(c => c.Name.StartsWith(prefix)));
                Assert.IsNotNull(response.Value.ContainerItems.Single(c => c.Name == containerName));
            }
        }
        
        [TestMethod]
        [TestCategory("Live")]
        public async Task ListContainersSegmentAsync_Metadata()
        {
            var service = TestHelper.GetServiceClient_SharedKey();
            // Ensure at least one container
            using (TestHelper.GetNewContainer(out var container, service: service))
            {
                // Arrange
                var metadata = TestHelper.BuildMetadata();
                await container.SetMetadataAsync(metadata);

                // Act
                var response = await service.ListContainersSegmentAsync(options: new ContainersSegmentOptions
                {
                    Details = new ContainerListingDetails { Metadata = true }
                });

                // Assert
                Assert.IsNotNull(response.Value.ContainerItems.First().Metadata);
            }
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task ListContainersSegmentAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.ListContainersSegmentAsync(marker: "garbage"),
                e => Assert.AreEqual("OutOfRangeInput", e.ErrorCode));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetAccountInfoAsync()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();

            // Act
            var response = await service.GetAccountInfoAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetAccountInfoAsync_Error()
        {
            // Arrange
            var service = new BlobServiceClient(
                TestHelper.GetServiceClient_SharedKey().Uri,
                TestHelper.GetOptions<BlobConnectionOptions>());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetAccountInfoAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();

            // Act
            var response = await service.GetPropertiesAsync();

            // Assert
            Assert.IsFalse(String.IsNullOrWhiteSpace(response.Value.DefaultServiceVersion));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var service = new BlobServiceClient(
                TestHelper.GetServiceClient_SharedKey().Uri,
                TestHelper.GetOptions<BlobConnectionOptions>());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetPropertiesAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [TestMethod]
        [DoNotParallelize]
        [TestCategory("Live")]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var properties = (await service.GetPropertiesAsync()).Value;
            var originalCors = properties.Cors.ToArray();
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

        [TestMethod]
        [TestCategory("Live")]
        public async Task SetPropertiesAsync_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();
            var properties = (await service.GetPropertiesAsync()).Value;
            var invalidService = new BlobServiceClient(
                TestHelper.GetServiceClient_SharedKey().Uri,
                TestHelper.GetOptions<BlobConnectionOptions>());

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                invalidService.SetPropertiesAsync(properties),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        // Note: read-access geo-redundant replication must be enabled for test account, or this test will fail.
        [TestMethod]
        [TestCategory("Live")]
        public async Task GetStatisticsAsync()
        {
            // Arrange
            // "-secondary" is required by the server
            var service = new BlobServiceClient(
                new Uri(TestConfigurations.DefaultTargetTenant.BlobServiceSecondaryEndpoint),
                TestHelper.GetOptions<BlobConnectionOptions>(TestHelper.GetNewSharedKeyCredentials()));

            // Act
            var response = await service.GetStatisticsAsync();

            // Assert
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            var service = await TestHelper.GetServiceClient_OauthAccount();

            // Act
            var response = await service.GetUserDelegationKeyAsync(start: null, expiry: DateTimeOffset.UtcNow.AddHours(1));

            // Assert
            Assert.IsNotNull(response.Value);
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            var service = TestHelper.GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetUserDelegationKeyAsync(start: null, expiry: DateTimeOffset.UtcNow.AddHours(1)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [TestMethod]
        [TestCategory("Live")]
        public async Task GetUserDelegationKey_ArgumentException()
        {
            // Arrange
            var service = await TestHelper.GetServiceClient_OauthAccount();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                service.GetUserDelegationKeyAsync(start: null, expiry: DateTimeOffset.Now.AddHours(1)),
                e => Assert.AreEqual("expiry must be UTC", e.Message));
        }
    }
}
