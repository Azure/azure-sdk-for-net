// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Tests.Helpers;
using Azure.ResourceManager.Storage.Models;
using System.Collections.Generic;

namespace Azure.ResourceManager.Storage.Tests
{
    public class FileShareTests : StorageTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private FileServiceResource _fileService;
        private FileShareCollection _fileShareCollection;

        public FileShareTests(bool async) : base(async)
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
                    Enabled = true,
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
            //update service property
            FileServiceData parameter = new FileServiceData()
            {
                ShareDeleteRetentionPolicy = new DeleteRetentionPolicy()
                {
                    Enabled = true,
                    Days = 5
                }
            };
            _fileService = (await _fileService.CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;

            //validate
            Assert.IsTrue(_fileService.Data.ShareDeleteRetentionPolicy.Enabled);
            Assert.AreEqual(_fileService.Data.ShareDeleteRetentionPolicy.Days, 5);
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
                    Enabled = true,
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
            List<SignedIdentifier> sigs = new List<SignedIdentifier>();
            DateTimeOffset datenow = Recording.Now;
            DateTimeOffset start1 = datenow.ToUniversalTime();
            DateTimeOffset end1 = datenow.AddHours(2).ToUniversalTime();
            DateTimeOffset start2 = datenow.AddMinutes(1).ToUniversalTime();
            DateTimeOffset end2 = datenow.AddMinutes(40).ToUniversalTime();
            var updateParameters2 = new FileShareData();
            SignedIdentifier sig1 = new SignedIdentifier("testSig1",
                new AccessPolicy(startOn: start1,
                    expiryOn: end1,
                    permission: "rw"));
            SignedIdentifier sig2 = new SignedIdentifier("testSig2",
                new AccessPolicy(startOn: start2,
                    expiryOn: end2,
                    permission: "rwdl"));
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
            Assert.AreEqual(LeaseDuration.Fixed, share.Data.LeaseDuration);
            Assert.AreEqual(LeaseState.Leased, share.Data.LeaseState);
            Assert.AreEqual(LeaseStatus.Locked, share.Data.LeaseStatus);

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
            Assert.AreEqual(LeaseDuration.Fixed, share.Data.LeaseDuration);
            Assert.AreEqual(LeaseState.Leased, share.Data.LeaseState);
            Assert.AreEqual(LeaseStatus.Locked, share.Data.LeaseStatus);

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
            properties2.Cors = new CorsRules();
            properties2.Cors.CorsRulesValue.Add(new CorsRule(new string[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                new CorsRuleAllowedMethodsItem[] { CorsRuleAllowedMethodsItem.GET, CorsRuleAllowedMethodsItem.PUT },
                100, new string[] { "x-ms-meta-*" },
                new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" }
                ));
            properties2.Cors.CorsRulesValue.Add(new CorsRule(new string[] { "*" },
                new CorsRuleAllowedMethodsItem[] { CorsRuleAllowedMethodsItem.GET },
                2, new string[] { "*" },
                new string[] { "*" }
                ));
            properties2.Cors.CorsRulesValue.Add(new CorsRule(new string[] { "http://www.abc23.com", "https://www.fabrikam.com/*" },
                new CorsRuleAllowedMethodsItem[] { CorsRuleAllowedMethodsItem.GET, CorsRuleAllowedMethodsItem.PUT, CorsRuleAllowedMethodsItem.Post },
                2000, new string[] { "x-ms-meta-12345675754564*" },
                new string[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" }
                ));

            _fileService = (await _fileService.CreateOrUpdateAsync(WaitUntil.Completed, properties2)).Value;
            FileServiceData properties3 = _fileService.Data;

            //validate CORS rules
            Assert.AreEqual(properties2.Cors.CorsRulesValue.Count, properties3.Cors.CorsRulesValue.Count);
            for (int i = 0; i < properties2.Cors.CorsRulesValue.Count; i++)
            {
                CorsRule putRule = properties2.Cors.CorsRulesValue[i];
                CorsRule getRule = properties3.Cors.CorsRulesValue[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }

            _fileService = await _fileService.GetAsync();

            FileServiceData properties4 = _fileService.Data;

            //validate CORS rules
            Assert.AreEqual(properties2.Cors.CorsRulesValue.Count, properties4.Cors.CorsRulesValue.Count);
            for (int i = 0; i < properties2.Cors.CorsRulesValue.Count; i++)
            {
                CorsRule putRule = properties2.Cors.CorsRulesValue[i];
                CorsRule getRule = properties4.Cors.CorsRulesValue[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }
        }
    }
}
