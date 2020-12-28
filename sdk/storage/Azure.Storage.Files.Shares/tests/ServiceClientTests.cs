// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
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
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.All, permissions: AccountSasPermissions.All).ToString();
            Uri uri = GetServiceClient_SharedKey().Uri;

            // Act
            var sasClient = InstrumentClient(new ShareServiceClient(uri, new AzureSasCredential(sas), GetOptions()));
            ShareServiceProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [Test]
        public void Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.All, permissions: AccountSasPermissions.All).ToString();
            Uri uri = GetServiceClient_SharedKey().Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new ShareClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
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
        [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/15505")]
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
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/15505")]
        [NonParallelizable]
        public async Task GetSetServicePropertiesAsync_SmbMultiChannel()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_PremiumFile();

            // Act
            Response<ShareServiceProperties> propertiesResponse = await service.GetPropertiesAsync();
            ShareServiceProperties properties = propertiesResponse.Value;

            // Assert
            Assert.IsFalse(properties.Protocol.Smb.Multichannel.Enabled);

            // Act
            properties.Protocol.Smb.Multichannel.Enabled = true;
            await service.SetPropertiesAsync(properties);
            propertiesResponse = await service.GetPropertiesAsync();
            properties = propertiesResponse.Value;

            // Assert
            Assert.IsTrue(properties.Protocol.Smb.Multichannel.Enabled);

            // Cleanup
            properties.Protocol.Smb.Multichannel.Enabled = false;
            await service.SetPropertiesAsync(properties);
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
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListSharesSegmentAsync_AccessTier()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_SharedKey();

            // Ensure at least one share
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            ShareSetPropertiesOptions options = new ShareSetPropertiesOptions
            {
                AccessTier = ShareAccessTier.Hot
            };

            await test.Share.SetPropertiesAsync(options);

            var shares = new List<ShareItem>();
            await foreach (ShareItem shareItem in service.GetSharesAsync())
            {
                shares.Add(shareItem);
            }

            ShareItem shareItemForShare = shares.FirstOrDefault(r => r.Name == test.Share.Name);

            // Assert
            Assert.AreEqual(ShareAccessTier.Hot.ToString(), shareItemForShare.Properties.AccessTier);
            Assert.IsNotNull(shareItemForShare.Properties.AccessTierChangeTime);
            Assert.AreEqual("pending-from-transactionOptimized", shareItemForShare.Properties.AccessTierTransitionState);
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
        [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/17262")]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_04_08)]
        public async Task ListSharesSegmentAsync_EnabledProtocolsAndRootSquash()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = GetServiceClient_PremiumFile();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareCreateOptions options = new ShareCreateOptions
            {
                Protocols = ShareProtocols.Nfs,
                RootSquash = ShareRootSquash.AllSquash,
            };

            await share.CreateAsync(options);

            // Act
            IList<ShareItem> shares = await service.GetSharesAsync().ToListAsync();

            // Assert
            ShareItem shareItem = shares.Where(s => s.Name == share.Name).FirstOrDefault();
            Assert.AreEqual(ShareProtocols.Nfs, shareItem.Properties.Protocols);
            Assert.AreEqual(ShareRootSquash.AllSquash, shareItem.Properties.RootSquash);
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

        #region GenerateSasTests
        [Test]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - ShareServiceClient(string connectionString)
            ShareServiceClient share = InstrumentClient(new ShareServiceClient(
                connectionString));
            Assert.IsTrue(share.CanGenerateAccountSasUri);

            // Act - ShareServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            ShareServiceClient share2 = InstrumentClient(new ShareServiceClient(
                connectionString,
                GetOptions()));
            Assert.IsTrue(share2.CanGenerateAccountSasUri);

            // Act - ShareServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareServiceClient share3 = InstrumentClient(new ShareServiceClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(share3.CanGenerateAccountSasUri);

            // Act - ShareServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareServiceClient share4 = InstrumentClient(new ShareServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(share4.CanGenerateAccountSasUri);
        }

        [Test]
        public void CanGenerateSas_GetShareClient()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - ShareServiceClient(string connectionString)
            ShareServiceClient service = InstrumentClient(new ShareServiceClient(
                connectionString));
            ShareClient share = service.GetShareClient(GetNewShareName());
            Assert.IsTrue(share.CanGenerateSasUri);

            // Act - ShareServiceClient(string connectionString, string blobContainerName, BlobClientOptions options)
            ShareServiceClient service2 = InstrumentClient(new ShareServiceClient(
                connectionString,
                GetOptions()));
            ShareClient share2 = service2.GetShareClient(GetNewShareName());
            Assert.IsTrue(share2.CanGenerateSasUri);

            // Act - ShareServiceClient(Uri blobContainerUri, BlobClientOptions options = default)
            ShareServiceClient service3 = InstrumentClient(new ShareServiceClient(
                blobEndpoint,
                GetOptions()));
            ShareClient share3 = service3.GetShareClient(GetNewShareName());
            Assert.IsFalse(share3.CanGenerateSasUri);

            // Act - ShareServiceClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            ShareServiceClient service4 = InstrumentClient(new ShareServiceClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            ShareClient share4 = service4.GetShareClient(GetNewShareName());
            Assert.IsTrue(share4.CanGenerateSasUri);
        }

        [Test]
        public void GenerateAccountSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            var fileEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (fileEndpoint, fileSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            ShareServiceClient serviceClient = InstrumentClient(new ShareServiceClient(connectionString, GetOptions()));

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(
                permissions: permissions,
                expiresOn: expiresOn,
                resourceTypes: resourceTypes);

            // Assert
            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, AccountSasServices.Files, resourceTypes);
            UriBuilder expectedUri = new UriBuilder(fileEndpoint)
            {
                Query = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString()
            };
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateAccountSas_Builder()
        {
            var constants = new TestConstants(this);
            var fileEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (fileEndpoint, fileSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            AccountSasServices services = AccountSasServices.Files;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            ShareServiceClient serviceClient = InstrumentClient(new ShareServiceClient(connectionString, GetOptions()));

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
            UriBuilder expectedUri = new UriBuilder(fileEndpoint);
            expectedUri.Query += sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential).ToString();
            Assert.AreEqual(expectedUri.Uri.ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateAccountSas_WrongService_Service()
        {
            var constants = new TestConstants(this);
            var fileEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var fileSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, fileStorageUri: (fileEndpoint, fileSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Blobs; // Wrong Service
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            ShareServiceClient serviceClient = InstrumentClient(new ShareServiceClient(connectionString, GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            // Act
            try
            {
                Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder);

                Assert.Fail("FileServiceClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                // the correct exception came back
            }
        }
        #endregion
    }
}
