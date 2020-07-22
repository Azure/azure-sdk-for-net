// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Test
{
    public class ServiceClientTests : FileTestBase
    {
        public ServiceClientTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
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
                e => Assert.AreEqual(ShareErrorCode.AuthenticationFailed.ToString(), e.ErrorCode));
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
                e => Assert.AreEqual(ShareErrorCode.AuthenticationFailed.ToString(), e.ErrorCode));

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
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_07_07)]
        [Ignore("#10044: Re-enable failing Storage tests")]
        public async Task ListSharesSegmentAsync_Premium()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_Premium();
            string shareName = GetNewShareName();

            // Ensure at least one premium share
            await using DisposingShare test = await GetTestShareAsync(
                service: service,
                shareName: shareName);
            ShareClient share = test.Share;

            var shares = new List<ShareItem>();
            await foreach (Page<ShareItem> page in service.GetSharesAsync().AsPages())
            {
                shares.AddRange(page.Values);
            }

            // Assert
            ShareItem premiumShareItem = shares.Where(r => r.Name == shareName).First();
            Assert.IsNotNull(premiumShareItem.Properties.ETag);
            Assert.IsNotNull(premiumShareItem.Properties.LastModified);
            Assert.IsNotNull(premiumShareItem.Properties.NextAllowedQuotaDowngradeTime);
            Assert.IsNotNull(premiumShareItem.Properties.ProvisionedEgressMBps);
            Assert.IsNotNull(premiumShareItem.Properties.ProvisionedIngressMBps);
            Assert.IsNotNull(premiumShareItem.Properties.ProvisionedIops);
            Assert.IsNotNull(premiumShareItem.Properties.QuotaInGB);
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
            AssertDictionaryEquality(
                metadata,
                shares.Where(s => s.Name == test.Share.Name).FirstOrDefault().Properties.Metadata);
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListSharesSegmentAsync_Deleted()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SoftDelete();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            await share.CreateAsync();
            await share.DeleteAsync();

            // Act
            IList<ShareItem> shares = await service.GetSharesAsync(states: ShareStates.Deleted).ToListAsync();

            // Assert
            ShareItem shareItem = shares.Where(s => s.Name == share.Name).FirstOrDefault();
            Assert.IsTrue(shareItem.IsDeleted);
            Assert.IsNotNull(shareItem.VersionId);
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
                e => Assert.AreEqual(ShareErrorCode.AuthenticationFailed.ToString(), e.ErrorCode));
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

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UndeleteShareAsync()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SoftDelete();
            string shareName = GetNewShareName();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            await share.CreateAsync();
            await share.DeleteAsync();
            IList<ShareItem> shares = await service.GetSharesAsync(states: ShareStates.Deleted).ToListAsync();
            ShareItem shareItem = shares.Where(s => s.Name == shareName).FirstOrDefault();

            // It takes some time for the Share to be deleted.
            await Delay(30000);

            // Act
            Response<ShareClient> response = await service.UndeleteShareAsync(
                shareItem.Name,
                shareItem.VersionId);

            // Assert
            await response.Value.GetPropertiesAsync();

            // Cleanup
            await share.DeleteAsync();
        }

        [Test]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UndeleteShareAsync_Error()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SoftDelete();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            string fakeVersion = "01D60F8BB59A4652";

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.UndeleteShareAsync(GetNewShareName(), fakeVersion),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }
    }
}
