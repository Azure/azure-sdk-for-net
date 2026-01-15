// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Tests
{
    public class FileShareTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private FileServiceResource _fileService;
        private FileShareCollection _fileShareCollection;

        public FileShareTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task CreateStorageAccountAndGetFileShareCollection()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            _fileService = _storageAccount.GetFileService();
            _fileService = await _fileService.GetAsync();
            _fileShareCollection = _fileService.GetFileShares();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                var storageAccountCollection = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccountResource account in storageAccountCollection.GetAllAsync())
                {
                    await account.DeleteAsync(WaitUntil.Completed);
                }
                _resourceGroup = null;
                _storageAccount = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteFileShare()
        {
            //create file share
            string accountName = Recording.GenerateAssetName("account");
            var content = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardGrs), StorageKind.StorageV2, AzureLocation.EastUS2);
            var account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, content)).Value;

            _fileShareCollection = (await account.GetFileService().GetAsync()).Value.GetFileShares();
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShareResource share1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, new FileShareData())).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //validate if created successfully
            FileShareData shareData = share1.Data;
            Assert.IsEmpty(shareData.Metadata);
            FileShareResource share2 = await _fileShareCollection.GetAsync(fileShareName);
            AssertFileShareEqual(share1, share2);
            Assert.IsTrue(await _fileShareCollection.ExistsAsync(fileShareName));
            Assert.IsFalse(await _fileShareCollection.ExistsAsync(fileShareName + "1"));

            string shareName2 = Recording.GenerateAssetName("share");
            var data = new FileShareData()
            {
                Metadata = { { "metadata1", "true" }, { "metadata2", "value2" } },
                ShareQuota = 500,
                AccessTier = FileShareAccessTier.Hot
            };
            share2 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, shareName2, data)).Value;
            Assert.AreEqual(2, share2.Data.Metadata.Count);
            Assert.AreEqual("metadata1", share2.Data.Metadata.FirstOrDefault().Key);
            Assert.AreEqual(500, share2.Data.ShareQuota);
            Assert.AreEqual(FileShareAccessTier.Hot, share2.Data.AccessTier);

            share2 = (await _fileShareCollection.GetAsync(shareName2)).Value;
            Assert.AreEqual(2, share2.Data.Metadata.Count);
            Assert.AreEqual("metadata1", share2.Data.Metadata.FirstOrDefault().Key);
            Assert.AreEqual(500, share2.Data.ShareQuota);
            Assert.AreEqual(FileShareAccessTier.Hot, share2.Data.AccessTier);

            //delete file share
            await share1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _fileShareCollection.GetAsync(fileShareName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _fileShareCollection.ExistsAsync(fileShareName));
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteListFileShareSnapshot()
        {
            //update storage account to v2
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2
            };
            await _storageAccount.UpdateAsync(updateParameters);

            // Enable share soft delete in service properties
            _fileService = await _fileService.GetAsync();
            FileServiceData properties = new FileServiceData()
            {
                ShareDeleteRetentionPolicy = new DeleteRetentionPolicy()
                {
                    IsEnabled = true,
                    Days = 5
                }
            };
            _fileService = (await _fileService.CreateOrUpdateAsync(WaitUntil.Completed, properties)).Value;

            //create 2 file share and delete 1
            string fileShareName1 = Recording.GenerateAssetName("testfileshare1");
            string fileShareName2 = Recording.GenerateAssetName("testfileshare2");
            FileShareResource share1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName1, new FileShareData())).Value;
            FileShareResource share2 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName2, new FileShareData())).Value;
            await share2.DeleteAsync(WaitUntil.Completed);

            //create 2 share snapshots
            FileShareResource shareSnapshot1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName1, new FileShareData(), expand: "snapshots")).Value;
            FileShareResource shareSnapshot2 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName1, new FileShareData(), expand: "snapshots")).Value;

            //get single share snapshot
            FileShareResource shareSnapshot = await _fileShareCollection.GetAsync(fileShareName1, "stats", shareSnapshot1.Data.SnapshotOn.Value.UtcDateTime.ToString("o"));
            Assert.AreEqual(shareSnapshot.Data.SnapshotOn, shareSnapshot1.Data.SnapshotOn);

            //list share with snapshot
            List<FileShareResource> fileShares = await _fileShareCollection.GetAllAsync(expand: "snapshots").ToEnumerableAsync();
            Assert.AreEqual(3, fileShares.Count);

            //delete share snapshot
            await shareSnapshot.DeleteAsync(WaitUntil.Completed);

            // List share with deleted
            fileShares = await _fileShareCollection.GetAllAsync(expand: "deleted").ToEnumerableAsync();
            Assert.AreEqual(2, fileShares.Count);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllFileShares()
        {
            //create two file shares
            string fileShareName1 = Recording.GenerateAssetName("testfileshare1");
            string fileShareName2 = Recording.GenerateAssetName("testfileshare2");
            FileShareResource share1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName1, new FileShareData())).Value;
            FileShareResource share2 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName2, new FileShareData())).Value;

            //validate if there are two file shares
            FileShareResource share3 = null;
            FileShareResource share4 = null;
            int count = 0;
            await foreach (FileShareResource share in _fileShareCollection.GetAllAsync())
            {
                count++;
                if (share.Id.Name == fileShareName1)
                    share3 = share;
                if (share.Id.Name == fileShareName2)
                    share4 = share;
            }
            Assert.AreEqual(count, 2);
            Assert.IsNotNull(share3);
            Assert.IsNotNull(share4);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateFileShare()
        {
            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShareResource share1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, new FileShareData())).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //update metadata and share quota
            FileShareData shareData = share1.Data;
            shareData.Metadata.Add("key1", "value1");
            shareData.Metadata.Add("key2", "value2");
            shareData.ShareQuota = 5000;
            FileShareResource share2 = await share1.UpdateAsync(shareData);

            //validate
            Assert.NotNull(share2.Data.Metadata);
            Assert.AreEqual(share2.Data.ShareQuota, shareData.ShareQuota);
            Assert.AreEqual(share2.Data.Metadata, shareData.Metadata);
            FileShareResource share3 = await _fileShareCollection.GetAsync(fileShareName);
            Assert.NotNull(share3.Data.Metadata);
            Assert.AreEqual(share3.Data.ShareQuota, shareData.ShareQuota);
            Assert.AreEqual(share3.Data.Metadata, shareData.Metadata);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateFileService()
        {
            //create file share
            string accountName = Recording.GenerateAssetName("account");
            var content = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.PremiumLrs), StorageKind.FileStorage, AzureLocation.EastUS2);
            var account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, content)).Value;
            _fileService = account.GetFileService();

            //update service property
            FileServiceData parameter = new FileServiceData()
            {
                ShareDeleteRetentionPolicy = new DeleteRetentionPolicy()
                {
                    IsEnabled = true,
                    Days = 5
                }
            };
            _fileService = (await _fileService.CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;

            //validate
            Assert.IsTrue(_fileService.Data.ShareDeleteRetentionPolicy.IsEnabled);
            Assert.AreEqual(_fileService.Data.ShareDeleteRetentionPolicy.Days, 5);

            // Get after account create
            var service = (await _fileService.GetAsync()).Value;
            Assert.AreEqual(0, service.Data.Cors.CorsRules.Count);

            //Set and validated
            var data = new FileServiceData()
            {
                ProtocolSettings = new FileServiceProtocolSettings()
                {
                    SmbSetting = new SmbSetting()
                    {
                        Multichannel = new Multichannel()
                        {
                            IsMultiChannelEnabled = true
                        },
                        Versions = "SMB2.1;SMB3.0;SMB3.1.1",
                        AuthenticationMethods = "NTLMv2;Kerberos",
                        KerberosTicketEncryption = "RC4-HMAC;AES-256",
                        ChannelEncryption = "AES-128-CCM;AES-128-GCM;AES-256-GCM"
                    }
                }
            };
            service = (await _fileService.CreateOrUpdateAsync(WaitUntil.Completed, data)).Value;
            Assert.IsTrue(service.Data.ProtocolSettings.SmbSetting.Multichannel.IsMultiChannelEnabled);
            Assert.AreEqual("SMB2.1;SMB3.0;SMB3.1.1", service.Data.ProtocolSettings.SmbSetting.Versions);
            Assert.AreEqual("NTLMv2;Kerberos", service.Data.ProtocolSettings.SmbSetting.AuthenticationMethods);
            Assert.AreEqual("RC4-HMAC;AES-256", service.Data.ProtocolSettings.SmbSetting.KerberosTicketEncryption);
            Assert.AreEqual("AES-128-CCM;AES-128-GCM;AES-256-GCM", service.Data.ProtocolSettings.SmbSetting.ChannelEncryption);

            // Get and validate
            service = (await _fileService.GetAsync()).Value;
            Assert.IsTrue(service.Data.ProtocolSettings.SmbSetting.Multichannel.IsMultiChannelEnabled);
            Assert.AreEqual("SMB2.1;SMB3.0;SMB3.1.1", service.Data.ProtocolSettings.SmbSetting.Versions);
            Assert.AreEqual("NTLMv2;Kerberos", service.Data.ProtocolSettings.SmbSetting.AuthenticationMethods);
            Assert.AreEqual("RC4-HMAC;AES-256", service.Data.ProtocolSettings.SmbSetting.KerberosTicketEncryption);
            Assert.AreEqual("AES-128-CCM;AES-128-GCM;AES-256-GCM", service.Data.ProtocolSettings.SmbSetting.ChannelEncryption);
        }

        [Test]
        [RecordedTest]
        public async Task RestoreFileShare()
        {
            //enable soft delete in service property
            FileServiceData parameter = new FileServiceData()
            {
                ShareDeleteRetentionPolicy = new DeleteRetentionPolicy()
                {
                    IsEnabled = true,
                    Days = 5
                }
            };
            _fileService = (await _fileService.CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;

            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShareResource share1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, new FileShareData())).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);

            //delete this share
            await share1.DeleteAsync(WaitUntil.Completed);

            //get the deleted share version
            string deletedShareVersion = null;
            List<FileShareResource> fileShares = await _fileShareCollection.GetAllAsync(expand: "deleted").ToEnumerableAsync();
            deletedShareVersion = fileShares[0].Data.Version;

            //restore file share
            //Don't need sleep when playback, or test will be very slow. Need sleep when live and record.
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(30000);
            }
            DeletedShare deletedShare = new DeletedShare(fileShareName, deletedShareVersion);
            await share1.RestoreAsync(deletedShare);

            //validate
            fileShares = await _fileShareCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(fileShares.Count, 1);
        }

        [Test]
        [RecordedTest]
        public async Task FileShareAccessPolicy()
        {
            //update storage account to v2
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2
            };
            await _storageAccount.UpdateAsync(updateParameters);

            //create share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShareResource share = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, new FileShareData())).Value;

            // Prepare signedIdentifiers to set
            var sigs = new List<StorageSignedIdentifier>();
            DateTimeOffset datenow = Recording.Now;
            DateTimeOffset start1 = datenow.ToUniversalTime();
            DateTimeOffset end1 = datenow.AddHours(2).ToUniversalTime();
            DateTimeOffset start2 = datenow.AddMinutes(1).ToUniversalTime();
            DateTimeOffset end2 = datenow.AddMinutes(40).ToUniversalTime();
            var updateParameters2 = new FileShareData();
            var sig1 = new StorageSignedIdentifier("testSig1",
                new StorageServiceAccessPolicy(startOn: start1,
                    expireOn: end1,
                    permission: "rw", null), null);
            var sig2 = new StorageSignedIdentifier("testSig2",
                new StorageServiceAccessPolicy(startOn: start2,
                    expireOn: end2,
                    permission: "rwdl", null), null);
            updateParameters2.SignedIdentifiers.Add(sig1);
            updateParameters2.SignedIdentifiers.Add(sig2);

            // Update share
            share = await share.UpdateAsync(updateParameters2);
            Assert.AreEqual(2, share.Data.SignedIdentifiers.Count);
            Assert.AreEqual("testSig1", share.Data.SignedIdentifiers[0].Id);
            Assert.AreEqual("rw", share.Data.SignedIdentifiers[0].AccessPolicy.Permission);
        }

        [Test]
        [RecordedTest]
        public async Task FileShareLease()
        {
            //update storage account to v2
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2
            };
            await _storageAccount.UpdateAsync(updateParameters);

            //create base share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileShareResource share = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, new FileShareData())).Value;

            //create share snapshots
            FileShareResource shareSnapshot = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, new FileShareData(), "snapshots")).Value;

            // Acquire lease share
            string proposedLeaseID1 = "ca761232-ed42-11ce-bacd-00aa0057b223";
            string proposedLeaseID2 = "dd761232-ed42-11ce-bacd-00aa0057b444";
            LeaseShareResponse leaseResponse;
            leaseResponse = await share.LeaseAsync(content: new LeaseShareContent(LeaseShareAction.Acquire) { LeaseDuration = 60, ProposedLeaseId = proposedLeaseID1 });
            Assert.AreEqual(proposedLeaseID1, leaseResponse.LeaseId);

            share = await share.GetAsync();
            Assert.AreEqual(StorageLeaseDurationType.Fixed, share.Data.LeaseDuration);
            Assert.AreEqual(StorageLeaseState.Leased, share.Data.LeaseState);
            Assert.AreEqual(StorageLeaseStatus.Locked, share.Data.LeaseStatus);

            //renew lease share
            leaseResponse = await share.LeaseAsync(content: new LeaseShareContent(LeaseShareAction.Renew) { LeaseId = proposedLeaseID1 });
            Assert.AreEqual(proposedLeaseID1, leaseResponse.LeaseId);

            // change lease share
            leaseResponse = await share.LeaseAsync(content: new LeaseShareContent(LeaseShareAction.Change) { LeaseId = proposedLeaseID1, ProposedLeaseId = proposedLeaseID2 });
            Assert.AreEqual(proposedLeaseID2, leaseResponse.LeaseId);

            //break lease share
            leaseResponse = await share.LeaseAsync(content: new LeaseShareContent(LeaseShareAction.Break) { BreakPeriod = 20 });
            Assert.AreEqual("20", leaseResponse.LeaseTimeSeconds);

            //release lease share
            leaseResponse = await share.LeaseAsync(content: new LeaseShareContent(LeaseShareAction.Release) { LeaseId = proposedLeaseID2 });
            Assert.IsNull(leaseResponse.LeaseId);

            //lease share snapshot
            leaseResponse = await share.LeaseAsync(xMsSnapshot: shareSnapshot.Data.SnapshotOn.Value.UtcDateTime.ToString("o"),
                content: new LeaseShareContent(LeaseShareAction.Acquire) { LeaseDuration = 60, ProposedLeaseId = proposedLeaseID1 });
            Assert.AreEqual(proposedLeaseID1, leaseResponse.LeaseId);

            shareSnapshot = await shareSnapshot.GetAsync(xMsSnapshot: shareSnapshot.Data.SnapshotOn.Value.UtcDateTime.ToString("o"));
            Assert.AreEqual(StorageLeaseDurationType.Fixed, share.Data.LeaseDuration);
            Assert.AreEqual(StorageLeaseState.Leased, share.Data.LeaseState);
            Assert.AreEqual(StorageLeaseStatus.Locked, share.Data.LeaseStatus);

            bool DeleteFail = false;
            // try delete with include = none
            try
            {
                await share.DeleteAsync(WaitUntil.Completed, include: "none");
            }
            catch (RequestFailedException e) when (e.Status == 409)
            {
                DeleteFail = true;
            }
            Assert.IsTrue(DeleteFail, "Delete should fail with include = none");

            DeleteFail = false;
            // try delete with include = snapshots
            try
            {
                await share.DeleteAsync(WaitUntil.Completed, include: "snapshots");
            }
            catch (RequestFailedException e) when (e.Status == 409)
            {
                DeleteFail = true;
            }
            Assert.IsTrue(DeleteFail, "Delete should fail with include = snapshots");

            //delete with include = leased-snapshots
            await share.DeleteAsync(WaitUntil.Completed, include: "leased-snapshots");
        }

        [Test]
        [RecordedTest]
        public async Task FileServiceCors()
        {
            FileServiceData properties1 = _fileService.Data;
            FileServiceData properties2 = new FileServiceData();
            properties2.Cors = new StorageCorsRules()
            {
                CorsRules =
                {
                    new StorageCorsRule(new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                        new[] { CorsRuleAllowedMethod.Get, CorsRuleAllowedMethod.Put },
                        100,
                        new string[] { "x-ms-meta-*" },
                        new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" })
                }
            };

            _fileService = (await _fileService.CreateOrUpdateAsync(WaitUntil.Completed, properties2)).Value;
            FileServiceData properties3 = _fileService.Data;

            //validate CORS rules
            Assert.AreEqual(properties2.Cors.CorsRules.Count, properties3.Cors.CorsRules.Count);
            for (int i = 0; i < properties2.Cors.CorsRules.Count; i++)
            {
                var putRule = properties2.Cors.CorsRules[i];
                var getRule = properties3.Cors.CorsRules[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }

            _fileService = await _fileService.GetAsync();

            FileServiceData properties4 = _fileService.Data;

            //validate CORS rules
            Assert.AreEqual(properties2.Cors.CorsRules.Count, properties4.Cors.CorsRules.Count);
            for (int i = 0; i < properties2.Cors.CorsRules.Count; i++)
            {
                var putRule = properties2.Cors.CorsRules[i];
                var getRule = properties4.Cors.CorsRules[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }
        }

        [Test]
        [RecordedTest]
        public async Task ProvisionV2FileStorageAccount()
        {
            // Create PV2 account
            string accountName = await CreateValidAccountNameAsync("teststoragemgmtpv2");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed,
                accountName,
                GetDefaultStorageAccountParameters(
                    sku: new StorageSku(StorageSkuName.StandardV2Lrs),
                    StorageKind.FileStorage,
                    AzureLocation.WestUS2)))
                    //"eastus2euap")))
                .Value;
            _fileService = _storageAccount.GetFileService();
            _fileService = await _fileService.GetAsync();
            _fileShareCollection = _fileService.GetFileShares();

            // Get share usage
            var usage = (_fileService.GetFileServiceUsage()).GetAsync().Result.Value.Data;
            Assert.IsNotNull(usage.Properties.FileShareLimits);
            Assert.IsTrue(usage.Properties.FileShareLimits.MaxProvisionedBandwidthMiBPerSec.Value > 0);
            Assert.IsTrue(usage.Properties.FileShareLimits.MaxProvisionedIops.Value > 0);
            Assert.IsTrue(usage.Properties.FileShareLimits.MaxProvisionedStorageGiB.Value > 0);
            Assert.IsTrue(usage.Properties.FileShareLimits.MinProvisionedBandwidthMiBPerSec.Value > 0);
            Assert.IsTrue(usage.Properties.FileShareLimits.MinProvisionedIops.Value > 0);
            Assert.IsTrue(usage.Properties.FileShareLimits.MinProvisionedStorageGiB.Value > 0);
            Assert.IsNotNull(usage.Properties.BurstingConstants);
            Assert.IsTrue(usage.Properties.FileShareRecommendations.BandwidthScalar.Value > 0);
            Assert.IsTrue(usage.Properties.FileShareRecommendations.BaseBandwidthMiBPerSec.Value > 0);
            Assert.IsTrue(usage.Properties.FileShareRecommendations.BaseIops.Value > 0);
            Assert.IsTrue(usage.Properties.FileShareRecommendations.IoScalar.Value > 0);
            Assert.IsTrue(usage.Properties.StorageAccountLimits.MaxFileShares.Value > 0);
            Assert.IsTrue(usage.Properties.StorageAccountLimits.MaxProvisionedBandwidthMiBPerSec.Value > 0);
            Assert.IsTrue(usage.Properties.StorageAccountLimits.MaxProvisionedIops.Value > 0);
            Assert.IsTrue(usage.Properties.StorageAccountLimits.MaxProvisionedStorageGiB.Value > 0);
            Assert.IsNotNull(usage.Properties.StorageAccountUsage);

            //create file share
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            var data = new FileShareData()
            {
                ProvisionedBandwidthMibps = usage.Properties.FileShareLimits.MaxProvisionedBandwidthMiBPerSec.Value - 1,
                ProvisionedIops = usage.Properties.FileShareLimits.MaxProvisionedIops.Value - 1,
                ShareQuota = usage.Properties.FileShareLimits.MaxProvisionedStorageGiB.Value - 1
            };
            FileShareResource share1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, data)).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);
            Assert.AreEqual(data.ProvisionedBandwidthMibps, share1.Data.ProvisionedBandwidthMibps);
            Assert.AreEqual(data.ProvisionedIops, share1.Data.ProvisionedIops);
            Assert.AreEqual(data.ShareQuota, share1.Data.ShareQuota);

            //validate if created successfully
            FileShareResource share2 = await _fileShareCollection.GetAsync(fileShareName);
            Assert.AreEqual(share1.Data.ProvisionedBandwidthMibps, share2.Data.ProvisionedBandwidthMibps);
            Assert.AreEqual(share1.Data.ProvisionedIops, share2.Data.ProvisionedIops);
            Assert.AreEqual(share1.Data.ShareQuota, share2.Data.ShareQuota);

            // Update File share
            data.ProvisionedBandwidthMibps = usage.Properties.FileShareLimits.MinProvisionedBandwidthMiBPerSec.Value + 1;
            data.ProvisionedIops = usage.Properties.FileShareLimits.MinProvisionedIops.Value + 1;
            data.ShareQuota = usage.Properties.FileShareLimits.MinProvisionedStorageGiB.Value + 1;

            share1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, data)).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);
            Assert.AreEqual(data.ProvisionedBandwidthMibps, share1.Data.ProvisionedBandwidthMibps);
            Assert.AreEqual(data.ProvisionedIops, share1.Data.ProvisionedIops);
            Assert.AreEqual(data.ShareQuota, share1.Data.ShareQuota);

            share2 = (await _fileShareCollection.GetAsync(fileShareName)).Value;
            Assert.AreEqual(share1.Data.ProvisionedBandwidthMibps, share2.Data.ProvisionedBandwidthMibps);
            Assert.AreEqual(share1.Data.ProvisionedIops, share2.Data.ProvisionedIops);
            Assert.AreEqual(share1.Data.ShareQuota, share2.Data.ShareQuota);

            //delete file share
            await share1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _fileShareCollection.GetAsync(fileShareName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _fileShareCollection.ExistsAsync(fileShareName));
        }

        [Test]
        [RecordedTest]
        public async Task PaidBursting()
        {
            // Create account
            string accountName = Recording.GenerateAssetName("account");
            var content = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.PremiumLrs), StorageKind.FileStorage, "eastus2euap");
            var account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, content)).Value;

            //create file share
            _fileShareCollection = (await account.GetFileService().GetAsync()).Value.GetFileShares();
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            var data = new FileShareData();
            data.FileSharePaidBursting = new FileSharePropertiesFileSharePaidBursting()
            {
                PaidBurstingEnabled = true,
                PaidBurstingMaxBandwidthMibps = 129,
                PaidBurstingMaxIops = 3230
            };
            FileShareResource share1 = (await _fileShareCollection.CreateOrUpdateAsync(WaitUntil.Completed, fileShareName, data)).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingEnabled, share1.Data.FileSharePaidBursting.PaidBurstingEnabled);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingMaxBandwidthMibps, share1.Data.FileSharePaidBursting.PaidBurstingMaxBandwidthMibps);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingMaxIops, share1.Data.FileSharePaidBursting.PaidBurstingMaxIops);

            //validate if created successfully
            FileShareResource share2 = await _fileShareCollection.GetAsync(fileShareName);
            AssertFileShareEqual(share1, share2);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingEnabled, share2.Data.FileSharePaidBursting.PaidBurstingEnabled);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingMaxBandwidthMibps, share2.Data.FileSharePaidBursting.PaidBurstingMaxBandwidthMibps);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingMaxIops, share2.Data.FileSharePaidBursting.PaidBurstingMaxIops);

            // update file share - disable PaidBursting
            data = new FileShareData();
            data.FileSharePaidBursting = new FileSharePropertiesFileSharePaidBursting()
            {
                PaidBurstingEnabled = false
            };
            share1 = (await share1.UpdateAsync(data)).Value;
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingEnabled, share1.Data.FileSharePaidBursting.PaidBurstingEnabled);

            share2 = (await _fileShareCollection.GetAsync(fileShareName)).Value;
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingEnabled, share2.Data.FileSharePaidBursting.PaidBurstingEnabled);

            // update file share - enable PaidBursting
            data.FileSharePaidBursting = new FileSharePropertiesFileSharePaidBursting()
            {
                PaidBurstingEnabled = true,
                PaidBurstingMaxBandwidthMibps = 128,
                PaidBurstingMaxIops = 3229
            };
            share1 = (await share1.UpdateAsync(data)).Value;
            Assert.AreEqual(share1.Id.Name, fileShareName);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingEnabled, share1.Data.FileSharePaidBursting.PaidBurstingEnabled);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingMaxBandwidthMibps, share1.Data.FileSharePaidBursting.PaidBurstingMaxBandwidthMibps);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingMaxIops, share1.Data.FileSharePaidBursting.PaidBurstingMaxIops);

            share2 = await _fileShareCollection.GetAsync(fileShareName);
            AssertFileShareEqual(share1, share2);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingEnabled, share2.Data.FileSharePaidBursting.PaidBurstingEnabled);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingMaxBandwidthMibps, share2.Data.FileSharePaidBursting.PaidBurstingMaxBandwidthMibps);
            Assert.AreEqual(data.FileSharePaidBursting.PaidBurstingMaxIops, share2.Data.FileSharePaidBursting.PaidBurstingMaxIops);

            //delete file share
            await share1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _fileShareCollection.GetAsync(fileShareName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _fileShareCollection.ExistsAsync(fileShareName));
        }
    }
}
