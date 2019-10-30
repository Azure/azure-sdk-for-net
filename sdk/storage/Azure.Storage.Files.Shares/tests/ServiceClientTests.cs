// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
{
    public class ServiceClientTests : FileTestBase
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
            var fileEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            ShareServiceClient service = InstrumentClient(new ShareServiceClient(connectionString.ToString(true), GetOptions()));

            var builder = new ShareUriBuilder(service.Uri);

            Assert.AreEqual("", builder.ShareName);
            Assert.AreEqual("", builder.DirectoryOrFilePath);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();

            // Act
            Response<ShareServiceProperties> properties = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
            var accountName = new ShareUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            ShareServiceClient service = InstrumentClient(
                new ShareServiceClient(
                    s_invalidUri,
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetPropertiesAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        [NonParallelizable]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();
            Response<ShareServiceProperties> properties = await service.GetPropertiesAsync();
            _ = properties.Value.Cors.ToArray();
            properties.Value.Cors.Clear();
            properties.Value.Cors.Add(
                new ShareCorsRule
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
            ShareServiceClient service = GetServiceClient_SharedKey();
            Response<ShareServiceProperties> properties = await service.GetPropertiesAsync();
            ShareServiceClient fakeService = InstrumentClient(
                new ShareServiceClient(
                    new Uri("https://error.file.core.windows.net"),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fakeService.SetPropertiesAsync(properties),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task ListSharesSegmentAsync()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();

            // Ensure at least one share
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            var shares = new List<ShareItem>();
            await foreach (Page<ShareItem> page in service.GetSharesAsync().AsPages())
            {
                shares.AddRange(page.Values);
            }

            // Assert
            Assert.AreNotEqual(0, shares.Count);
            Assert.AreEqual(shares.Count, shares.Select(c => c.Name).Distinct().Count());
            Assert.IsTrue(shares.Any(c => share.Uri == service.GetShareClient(c.Name).Uri));
            Assert.IsTrue(shares.All(c => c.Properties.Metadata == null));
        }

        [Test]
        public async Task ListSharesSegmentAsync_Metadata()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();
            IDictionary<string, string> metadata = BuildMetadata();

            // Ensure at least one share
            await using DisposingShare test = await GetTestShareAsync(service, metadata: metadata);
            ShareClient share = test.Share;

            var shares = new List<ShareItem>();
            await foreach (Page<ShareItem> page in service.GetSharesAsync(ShareTraits.Metadata).AsPages())
            {
                shares.AddRange(page.Values);
            }

            // Assert
            Assert.AreNotEqual(0, shares.Count);
            Assert.AreEqual(shares.Count, shares.Select(c => c.Name).Distinct().Count());
            Assert.IsTrue(shares.Any(c => share.Uri == service.GetShareClient(c.Name).Uri));
            AssertMetadataEquality(
                metadata,
                shares.Where(s => s.Name == test.Share.Name).FirstOrDefault().Properties.Metadata);
        }

        [Test]
        public async Task ListShareSegmentAsync_Error()
        {
            // Arrange
            ShareServiceClient service = InstrumentClient(
                new ShareServiceClient(
                    new Uri("https://error.file.core.windows.net"),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetSharesAsync().ToListAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode.Split('\n')[0]));
        }

        [Test]
        public async Task CreateShareAsync()
        {
            var name = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            try
            {
                ShareClient share = InstrumentClient((await service.CreateShareAsync(name)).Value);
                Response<ShareProperties> properties = await share.GetPropertiesAsync();
                Assert.AreNotEqual(0, properties.Value.QuotaInGB);
            }
            finally
            {
                await service.DeleteShareAsync(name, false);
            }
        }

        [Test]
        public async Task DeleteShareAsync()
        {
            var name = GetNewShareName();
            ShareServiceClient service = GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient((await service.CreateShareAsync(name)).Value);

            await service.DeleteShareAsync(name, false);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await share.GetPropertiesAsync());
        }


    }
}
