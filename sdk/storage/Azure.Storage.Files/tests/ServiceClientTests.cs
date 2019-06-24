// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Common;
using Azure.Storage.Files.Models;
using Azure.Storage.Files.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Test
{
    [TestFixture]
    public class ServiceClientTests : FileTestBase
    {
        public ServiceClientTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            var service = this.InstrumentClient(new FileServiceClient(connectionString.ToString(true), this.GetOptions()));

            var builder = new FileUriBuilder(service.Uri);

            Assert.AreEqual("", builder.ShareName);
            Assert.AreEqual("", builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();

            // Act
            var properties = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var service = this.InstrumentClient(
                new FileServiceClient(
                    InvalidUri,
                    new SharedKeyCredentials(
                        TestConfigurations.DefaultTargetTenant.AccountName,
                        TestConfigurations.DefaultTargetTenant.AccountKey),
                    this.GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.GetPropertiesAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var properties = await service.GetPropertiesAsync();
            _ = properties.Value.Cors.ToArray();
            properties.Value.Cors.Clear();
            properties.Value.Cors.Add(
                new CorsRule
                {
                    MaxAgeInSeconds = 1000,
                    AllowedHeaders = "x-ms-meta-data*,x-ms-meta-target*,x-ms-meta-abc",
                    AllowedMethods = "PUT,GET",
                    AllowedOrigins = "*",
                    ExposedHeaders = "x-ms-meta-*"
                });

            // Act
            await service.SetPropertiesAsync(properties: properties);

            // Assert
            properties = await service.GetPropertiesAsync();
            Assert.AreEqual(1, properties.Value.Cors.Count());
            Assert.IsTrue(properties.Value.Cors[0].MaxAgeInSeconds == 1000);
        }

        [Test]
        public async Task SetPropertiesAsync_Error()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();
            var properties = await service.GetPropertiesAsync();
            var fakeService = this.InstrumentClient(
                new FileServiceClient(
                    new Uri("https://error.file.core.windows.net"),
                    new SharedKeyCredentials(
                        TestConfigurations.DefaultTargetTenant.AccountName,
                        TestConfigurations.DefaultTargetTenant.AccountKey),
                    this.GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                fakeService.SetPropertiesAsync(properties),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ListSharesSegmentAsync()
        {
            // Arrange
            var service = this.GetServiceClient_SharedKey();

            // Ensure at least one share
            using (this.GetNewShare(out var share, service: service)) 
            {
                var marker = default(string);
                SharesSegment sharesSegment;

                var shares = new List<ShareItem>();

                do
                {
                    // Act
                    sharesSegment = await service.ListSharesSegmentAsync(marker: marker);
                    shares.AddRange(sharesSegment.ShareItems);
                    marker = sharesSegment.NextMarker;
                }
                while (!String.IsNullOrWhiteSpace(marker));

                // Assert
                Assert.AreNotEqual(0, shares.Count);
                Assert.AreEqual(shares.Count, shares.Select(c => c.Name).Distinct().Count());
                Assert.IsTrue(shares.Any(c => share.Uri == service.GetShareClient(c.Name).Uri));
            }
        }

        [Test]
        public async Task ListShareSegmentAsync_Error()
        {
            // Arrange
            var service = this.InstrumentClient(
                new FileServiceClient(
                    new Uri("https://error.file.core.windows.net"),
                    new SharedKeyCredentials(
                        TestConfigurations.DefaultTargetTenant.AccountName,
                        TestConfigurations.DefaultTargetTenant.AccountKey),
                    this.GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                service.ListSharesSegmentAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }
    }
}
