// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.Tests
{
    public class ServiceClientTests : FileTestBase
    {
        public ServiceClientTests(bool async, ShareClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
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
            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public void Ctor_ConnectionString_CustomUri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var fileEndpoint = new Uri("http://customdomain/" + accountName);
            var fileSecondaryEndpoint = new Uri("http://customdomain/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (default, default), (default, default), (fileEndpoint, fileSecondaryEndpoint));

            ShareServiceClient service = new ShareServiceClient(connectionString.ToString(true));

            Assert.AreEqual(accountName, service.AccountName);
        }

        [Test]
        public void Ctor_SharedKey_AccountName()
        {
            // Arrange
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var shareEndpoint = new Uri($"https://customdomain/");

            ShareServiceClient service = new ShareServiceClient(shareEndpoint, credentials);

            Assert.AreEqual(accountName, service.AccountName);
        }

        [RecordedTest]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.All, permissions: AccountSasPermissions.All).ToString();
            Uri uri = SharesClientBuilder.GetServiceClient_SharedKey().Uri;

            // Act
            var sasClient = InstrumentClient(new ShareServiceClient(uri, new AzureSasCredential(sas), GetOptions()));
            ShareServiceProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [RecordedTest]
        public void Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials(resourceTypes: AccountSasResourceTypes.All, permissions: AccountSasPermissions.All).ToString();
            Uri uri = SharesClientBuilder.GetServiceClient_SharedKey().Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new ShareClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
        }

        [Test]
        public void Ctor_DevelopmentThrows()
        {
            var ex = Assert.Throws<ArgumentException>(() => new ShareServiceClient("UseDevelopmentStorage=true"));
            Assert.AreEqual("connectionString", ex.ParamName);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();

            // Act
            Response<ShareServiceProperties> properties = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
            var accountName = new ShareUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
        }

        [RecordedTest]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            ShareServiceClient service = InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigDefault.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConstants.InvalidAccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetPropertiesAsync(),
                e => Assert.AreEqual(ShareErrorCode.AuthenticationFailed.ToString(), e.ErrorCode));
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/25266")]
        [RecordedTest]
        [NonParallelizable]
        public async Task SetPropertiesAsync()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
            Response<ShareServiceProperties> properties = await service.GetPropertiesAsync();

            // Act
            await service.SetPropertiesAsync(properties: properties.Value);

            // Assert
           await service.GetPropertiesAsync();
        }

        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/25266")]
        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_08_04)]
        public async Task GetPropertiesAsync_OAuth()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();

            // Act
            Response<ShareServiceProperties> properties = await service.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
            var accountName = new ShareUriBuilder(service.Uri).AccountName;
            TestHelper.AssertCacheableProperty(accountName, () => service.AccountName);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        [NonParallelizable]
        [Category("NonVirtualized")]
        public async Task GetSetServicePropertiesAsync_SmbMultiChannel()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_PremiumFile();

            // Act
            Response<ShareServiceProperties> propertiesResponse = await service.GetPropertiesAsync();
            ShareServiceProperties properties = propertiesResponse.Value;

            if (properties.Protocol.Smb.Multichannel.Enabled == true)
            {
                // Act
                properties.Protocol.Smb.Multichannel.Enabled = false;
                await service.SetPropertiesAsync(properties);
                propertiesResponse = await service.GetPropertiesAsync();
                properties = propertiesResponse.Value;

                // Assert
                Assert.IsFalse(properties.Protocol.Smb.Multichannel.Enabled);

                // Cleanup
                properties.Protocol.Smb.Multichannel.Enabled = true;
                await service.SetPropertiesAsync(properties);
            }
            else
            {
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
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        [NonParallelizable]
        [Category("NonVirtualized")]
        public async Task GetSetServicePropertiesAsync_EncryptionInTransit_SMB()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();

            // Act
            Response<ShareServiceProperties> propertiesResponse = await service.GetPropertiesAsync();
            ShareServiceProperties properties = propertiesResponse.Value;

            if (properties.Protocol.Smb.EncryptionInTransit?.Required == true)
            {
                // Act
                properties.Protocol.Smb.Multichannel = null;
                properties.Protocol.Smb.EncryptionInTransit.Required = false;
                await service.SetPropertiesAsync(properties);
                propertiesResponse = await service.GetPropertiesAsync();
                properties = propertiesResponse.Value;

                // Assert
                Assert.IsFalse(properties.Protocol.Smb.EncryptionInTransit.Required);

                // Cleanup
                properties.Protocol.Smb.EncryptionInTransit.Required = false;
                properties.Protocol.Smb.Multichannel = null;

                await service.SetPropertiesAsync(properties);
            }
            else
            {
                // Act
                properties.Protocol.Smb.EncryptionInTransit = new ShareSmbSettingsEncryptionInTransit
                {
                    Required = true
                };
                properties.Protocol.Smb.Multichannel = null;
                await service.SetPropertiesAsync(properties);
                propertiesResponse = await service.GetPropertiesAsync();
                properties = propertiesResponse.Value;

                // Assert
                Assert.IsTrue(properties.Protocol.Smb.EncryptionInTransit.Required);

                // Cleanup
                properties.Protocol.Smb.Multichannel = null;
                properties.Protocol.Smb.EncryptionInTransit.Required = false;
                await service.SetPropertiesAsync(properties);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        [NonParallelizable]
        [Category("NonVirtualized")]
        public async Task GetSetServicePropertiesAsync_EncryptionInTransit_NFS()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_PremiumFile();

            // Act
            Response<ShareServiceProperties> propertiesResponse = await service.GetPropertiesAsync();
            ShareServiceProperties properties = propertiesResponse.Value;

            if (properties.Protocol.Nfs?.EncryptionInTransit?.Required == true)
            {
                // Act
                properties.Protocol.Nfs.EncryptionInTransit.Required = false;
                await service.SetPropertiesAsync(properties);
                propertiesResponse = await service.GetPropertiesAsync();
                properties = propertiesResponse.Value;

                // Assert
                Assert.IsFalse(properties.Protocol.Smb.EncryptionInTransit.Required);

                // Cleanup
                properties.Protocol.Smb.EncryptionInTransit.Required = true;
                await service.SetPropertiesAsync(properties);
            }
            else
            {
                // Act
                if (properties.Protocol.Nfs == null)
                {
                    properties.Protocol.Nfs = new ShareNfsSettings();
                }
                properties.Protocol.Nfs.EncryptionInTransit = new ShareNfsSettingsEncryptionInTransit
                {
                    Required = true
                };
                await service.SetPropertiesAsync(properties);
                propertiesResponse = await service.GetPropertiesAsync();
                properties = propertiesResponse.Value;

                // Assert
                Assert.IsTrue(properties.Protocol.Nfs.EncryptionInTransit.Required);

                // Cleanup
                properties.Protocol.Nfs.EncryptionInTransit.Required = false;
                await service.SetPropertiesAsync(properties);
            }
        }

        [RecordedTest]
        public async Task SetPropertiesAsync_Error()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
            Response<ShareServiceProperties> properties = await service.GetPropertiesAsync();
            ShareServiceClient fakeService = InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigDefault.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConstants.InvalidAccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                fakeService.SetPropertiesAsync(properties),
                e => Assert.AreEqual(ShareErrorCode.AuthenticationFailed.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [NonParallelizable]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_08_04)]
        public async Task SetPropertiesAsync_OAuth()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            Response<ShareServiceProperties> properties = await service.GetPropertiesAsync();
            properties.Value.Protocol = null;

            // Act
            await service.SetPropertiesAsync(properties: properties.Value);
        }

        [RecordedTest]
        public async Task ListSharesSegmentAsync()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();

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

        [RecordedTest]
        [Category("NonVirtualized")]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2021_02_12)]
        public async Task ListSharesSegmentAsync_Premium()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_PremiumFile();
            string shareName = GetNewShareName();

            // Ensure at least one premium share
            await using DisposingShare test = await GetTestShareAsync(
                service: service,
                shareName: shareName);
            ShareClient share = test.Share;

            IList<ShareItem> shares = await service.GetSharesAsync().ToListAsync();
            ShareItem premiumShareItem = shares.Where(r => r.Name == shareName).FirstOrDefault();

            // Assert
            Assert.IsNotNull(premiumShareItem.Properties.ETag);
            Assert.IsNotNull(premiumShareItem.Properties.LastModified);
            Assert.IsNotNull(premiumShareItem.Properties.NextAllowedQuotaDowngradeTime);
            Assert.IsNotNull(premiumShareItem.Properties.ProvisionedEgressMBps);
            Assert.IsNotNull(premiumShareItem.Properties.ProvisionedIngressMBps);
            Assert.IsNotNull(premiumShareItem.Properties.ProvisionedIops);
            Assert.IsNotNull(premiumShareItem.Properties.ProvisionedBandwidthMiBps);
            Assert.IsNotNull(premiumShareItem.Properties.QuotaInGB);
        }

        [RecordedTest]
        public async Task ListSharesSegmentAsync_Metadata()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListSharesSegmentAsync_Deleted()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SoftDelete();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        public async Task ListSharesSegmentAsync_AccessTier()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();

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

        [RecordedTest]
        public async Task ListShareSegmentAsync_Error()
        {
            // Arrange
            ShareServiceClient service = InstrumentClient(
                new ShareServiceClient(
                    new Uri(TestConfigDefault.FileServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConstants.InvalidAccountKey),
                    GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetSharesAsync().ToListAsync(),
                e => Assert.AreEqual(ShareErrorCode.AuthenticationFailed.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/17262")]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2020_04_08)]
        public async Task ListSharesSegmentAsync_EnabledProtocolsAndRootSquash()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_PremiumFile();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_02_04)]
        public async Task ListShares_EnableSnapshotVirtualDirectoryAccess()
        {
            // Arrange
            var shareName = GetNewShareName();
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_PremiumFile();
            ShareClient share = InstrumentClient(service.GetShareClient(shareName));
            ShareCreateOptions options = new ShareCreateOptions
            {
                Protocols = ShareProtocols.Nfs,
                EnableSnapshotVirtualDirectoryAccess = true,
            };

            try
            {
                await share.CreateAsync(options);

                // Act
                IList<ShareItem> shares = await service.GetSharesAsync().ToListAsync();

                // Assert
                ShareItem shareItem = shares.Where(s => s.Name == share.Name).FirstOrDefault();
                Assert.AreEqual(ShareProtocols.Nfs, shareItem.Properties.Protocols);
                Assert.IsTrue(shareItem.Properties.EnableSnapshotVirtualDirectoryAccess);
            }
            finally
            {
                await share.DeleteAsync(false);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2024_08_04)]
        public async Task ListSharesSegmentAsync_OAuth()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();

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

        [RecordedTest]
        [PlaybackOnly("https://github.com/Azure/azure-sdk-for-net/issues/45675")]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2025_01_05)]
        public async Task ListSharesSegmentAsync_ProvisionedBilling()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();

            // Ensure at least one share
            await using DisposingShare test = await GetTestShareAsync(service);
            ShareClient share = test.Share;

            List<ShareItem> shares = new List<ShareItem>();
            await foreach (ShareItem item in service.GetSharesAsync())
            {
                shares.Add(item);
            }

            ShareItem shareItem = shares.FirstOrDefault();

            // Assert
            Assert.IsNotNull(shareItem.Properties.IncludedBurstIops);
            Assert.IsNotNull(shareItem.Properties.MaxBurstCreditsForIops);
            Assert.IsNotNull(shareItem.Properties.NextAllowedProvisionedIopsDowngradeTime);
            Assert.IsNotNull(shareItem.Properties.NextAllowedProvisionedBandwidthDowngradeTime);
        }

        [RecordedTest]
        public async Task CreateShareAsync()
        {
            var name = GetNewShareName();
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
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

        [RecordedTest]
        public async Task DeleteShareAsync()
        {
            var name = GetNewShareName();
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();
            ShareClient share = InstrumentClient((await service.CreateShareAsync(name)).Value);

            await service.DeleteShareAsync(name, false);
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await share.GetPropertiesAsync());
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UndeleteShareAsync()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SoftDelete();
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

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2019_12_12)]
        public async Task UndeleteShareAsync_Error()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SoftDelete();
            ShareClient share = InstrumentClient(service.GetShareClient(GetNewShareName()));
            string fakeVersion = "01D60F8BB59A4652";

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.UndeleteShareAsync(GetNewShareName(), fakeVersion),
                e => Assert.AreEqual(ShareErrorCode.ShareNotFound.ToString(), e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegationKey()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();
            DateTimeOffset startTime = Recording.UtcNow.AddMinutes(-5);
            DateTimeOffset expiryTime = Recording.UtcNow.AddHours(1);

            // Act
            ShareGetUserDelegationKeyOptions options = new ShareGetUserDelegationKeyOptions
            {
                StartsOn = startTime,
            };
            Response<UserDelegationKey> response = await service.GetUserDelegationKeyAsync(expiryTime, options);

            // Assert
            Assert.IsNotNull(response.Value);
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegationKey_Error()
        {
            // Arrange
            ShareServiceClient service = SharesClientBuilder.GetServiceClient_SharedKey();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                service.GetUserDelegationKeyAsync(expiresOn: Recording.UtcNow.AddHours(1)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [RecordedTest]
        [ServiceVersion(Min = ShareClientOptions.ServiceVersion.V2026_02_06)]
        public async Task GetUserDelegationKey_ArgumentException()
        {
            // Arrange
            ShareServiceClient service = GetServiceClient_OAuth();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                service.GetUserDelegationKeyAsync(
                    // ensure the time used is not UTC, as DateTimeOffset.Now could actually be UTC based on OS settings
                    // Use a custom time zone so we aren't dependent on OS having specific standard time zone.
                    expiresOn: TimeZoneInfo.ConvertTime(
                        Recording.Now.AddHours(1),
                        TimeZoneInfo.CreateCustomTimeZone("Storage Test Custom Time Zone", TimeSpan.FromHours(-3), "CTZ", "CTZ"))),
                e => Assert.AreEqual("expiresOn must be UTC", e.Message));
            ;
        }

        #region GenerateSasTests
        [RecordedTest]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = TestConstants.Create(this);
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

        [RecordedTest]
        public void CanGenerateSas_GetShareClient()
        {
            // Arrange
            var constants = TestConstants.Create(this);
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

        [RecordedTest]
        public void CanGenerateAccountSas_Mockable()
        {
            // Act
            var directory = new Mock<ShareServiceClient>();
            directory.Setup(x => x.CanGenerateAccountSasUri).Returns(false);

            // Assert
            Assert.IsFalse(directory.Object.CanGenerateAccountSasUri);

            // Act
            directory.Setup(x => x.CanGenerateAccountSasUri).Returns(true);

            // Assert
            Assert.IsTrue(directory.Object.CanGenerateAccountSasUri);
        }

        [RecordedTest]
        public void GenerateAccountSas_RequiredParameters()
        {
            // Arrange
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            ShareServiceClient serviceClient = InstrumentClient(
                new ShareServiceClient(
                    serviceUri,
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            string clientStringToSign = null;
            string sasBuilderStringToSign = null;

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(
                permissions: permissions,
                expiresOn: expiresOn,
                resourceTypes: resourceTypes,
                out clientStringToSign);

            // Assert
            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, AccountSasServices.Files, resourceTypes);
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential, out sasBuilderStringToSign)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(clientStringToSign);
            Assert.IsNotNull(sasBuilderStringToSign);
        }

        [RecordedTest]
        public void GenerateAccountSas_Builder()
        {
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Files;
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            ShareServiceClient serviceClient = InstrumentClient(
                new ShareServiceClient(
                    serviceUri,
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes);

            string stringToSign = null;

            // Act
            Uri sasUri = serviceClient.GenerateAccountSasUri(sasBuilder, out stringToSign);

            // Assert
            AccountSasBuilder sasBuilder2 = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes);
            ShareUriBuilder expectedUri = new ShareUriBuilder(serviceUri)
            {
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri(), sasUri);
            Assert.IsNotNull(stringToSign);
        }

        [RecordedTest]
        public void GenerateAccountSas_WrongService_Service()
        {
            TestConstants constants = TestConstants.Create(this);
            Uri serviceUri = new Uri($"https://{constants.Sas.Account}.file.core.windows.net");
            AccountSasPermissions permissions = AccountSasPermissions.Read | AccountSasPermissions.Write;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            AccountSasServices services = AccountSasServices.Blobs; // Wrong Service
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.All;
            ShareServiceClient serviceClient = InstrumentClient(
                new ShareServiceClient(
                    serviceUri,
                    constants.Sas.SharedKeyCredential,
                    GetOptions()));

            AccountSasBuilder sasBuilder = new AccountSasBuilder(permissions, expiresOn, services, resourceTypes)
            {
                IPRange = new SasIPRange(System.Net.IPAddress.None, System.Net.IPAddress.None),
                StartsOn = Recording.UtcNow.AddHours(-1)
            };

            // Act
            TestHelper.AssertExpectedException(
                () => serviceClient.GenerateAccountSasUri(sasBuilder),
                new InvalidOperationException("SAS Uri cannot be generated. builder.Services does specify Files. builder.Services must either specify Files or specify all Services are accessible in the value."));
        }
        #endregion

        [RecordedTest]
        public void CanMockClientConstructors()
        {
            // One has to call .Object to trigger constructor. It's lazy.
            var mock = new Mock<ShareServiceClient>(TestConfigDefault.ConnectionString, new ShareClientOptions()).Object;
            mock = new Mock<ShareServiceClient>(TestConfigDefault.ConnectionString).Object;
            mock = new Mock<ShareServiceClient>(new Uri("https://test/test/test"), new ShareClientOptions()).Object;
            mock = new Mock<ShareServiceClient>(new Uri("https://test/test/test"), Tenants.GetNewSharedKeyCredentials(), new ShareClientOptions()).Object;
            mock = new Mock<ShareServiceClient>(new Uri("https://test/test/test"), new AzureSasCredential("foo"), new ShareClientOptions()).Object;
        }
    }
}
