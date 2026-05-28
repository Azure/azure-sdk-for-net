// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Tests
{
    public class BlobContainerTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private StorageAccountResource _storageAccount;
        private BlobServiceResource _blobService;
        private BlobContainerCollection _blobContainerCollection;
        public BlobContainerTests(bool async) : base(async)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task CreateStorageAccountAndGetBlobContainerContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            _blobService = _storageAccount.GetBlobService();
            _blobService = await _blobService.GetAsync();
            _blobContainerCollection = _blobService.GetBlobContainers();
        }

        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
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
        public async Task CreateDeleteBlobContainer()
        {
            //create blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerResource container1 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData())).Value;
            Assert.IsNotNull(container1);
            Assert.AreEqual(container1.Id.Name, containerName);
            Assert.IsEmpty(container1.Data.Metadata);
            Assert.IsNull(container1.Data.PublicAccess);

            //validate if created successfully
            BlobContainerResource container2 = await _blobContainerCollection.GetAsync(containerName);
            AssertBlobContainerEqual(container1, container2);
            Assert.IsTrue(await _blobContainerCollection.ExistsAsync(containerName));
            Assert.IsFalse(await _blobContainerCollection.ExistsAsync(containerName + "1"));
            BlobContainerData containerData = container1.Data;
            Assert.IsEmpty(containerData.Metadata);
            Assert.IsFalse(containerData.HasLegalHold);
            Assert.IsNull(containerData.PublicAccess);
            Assert.False(containerData.HasImmutabilityPolicy);

            //delete blob container
            ArmOperation blobContainerDeleteOperation = await container1.DeleteAsync(WaitUntil.Completed);
            await blobContainerDeleteOperation.WaitForCompletionResponseAsync();

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _blobContainerCollection.GetAsync(containerName); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsFalse(await _blobContainerCollection.ExistsAsync(containerName));
        }

        [Test]
        [RecordedTest]
        public async Task GetBlobContainer()
        {
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData())).Value;

            Assert.IsEmpty(container.Data.Metadata);
            Assert.Null(container.Data.PublicAccess);

            LegalHold legalHoldModel = new LegalHold(new List<string> { "tag1", "tag2", "tag3" });
            LegalHold legalHold = await container.SetLegalHoldAsync(legalHoldModel);
            Assert.IsTrue(legalHold.HasLegalHold);
            Assert.AreEqual(new List<string> { "tag1", "tag2", "tag3" }, legalHold.Tags);

            ImmutabilityPolicyData immutabilityPolicyModel = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicyResource immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicyModel)).Value;
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);

            immutabilityPolicy = await container.GetImmutabilityPolicy().LockImmutabilityPolicyAsync(immutabilityPolicy.Data.ETag.Value);
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Data.State);

            immutabilityPolicyModel = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 100 };
            immutabilityPolicy = await container.GetImmutabilityPolicy().ExtendImmutabilityPolicyAsync(immutabilityPolicy.Data.ETag.Value, data: immutabilityPolicyModel);
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(100, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Data.State);

            container = await container.GetAsync();
            Assert.IsEmpty(container.Data.Metadata);
            Assert.AreEqual(StoragePublicAccessType.None, container.Data.PublicAccess);
            Assert.AreEqual(3, container.Data.ImmutabilityPolicy.UpdateHistory.Count);
            Assert.AreEqual(ImmutabilityPolicyUpdateType.Put, container.Data.ImmutabilityPolicy.UpdateHistory[0].UpdateType);
            Assert.AreEqual(ImmutabilityPolicyUpdateType.Lock, container.Data.ImmutabilityPolicy.UpdateHistory[1].UpdateType);
            Assert.AreEqual(ImmutabilityPolicyUpdateType.Extend, container.Data.ImmutabilityPolicy.UpdateHistory[2].UpdateType);
            Assert.IsTrue(container.Data.LegalHold.HasLegalHold);
            Assert.AreEqual(3, container.Data.LegalHold.Tags.Count);
            Assert.AreEqual("tag1", container.Data.LegalHold.Tags[0].Tag);
            Assert.AreEqual("tag2", container.Data.LegalHold.Tags[1].Tag);
            Assert.AreEqual("tag3", container.Data.LegalHold.Tags[2].Tag);

            legalHold = await container.ClearLegalHoldAsync(legalHold);
            Assert.IsFalse(legalHold.HasLegalHold);

            await container.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllBlobContainers()
        {
            //create two blob containers
            string containerName1 = Recording.GenerateAssetName("testblob1");
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainerResource container1 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName1, new BlobContainerData())).Value;
            BlobContainerResource container2 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName2, new BlobContainerData())).Value;

            var containerList = await _blobContainerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(containerList.Count, 2);
            foreach (var item in containerList)
            {
                Assert.NotNull(item.Data.Name);
                Assert.NotNull(item.Data.PublicAccess);
                Assert.IsFalse(item.Data.HasImmutabilityPolicy);
                Assert.IsFalse(item.Data.HasLegalHold);
            }
        }

        [Test]
        [RecordedTest]
        public async Task UpdateBlobContainer()
        {
            //create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, data)).Value;

            //update metadata, public access
            BlobContainerData update = container.Data;
            update.Metadata.Add("key1", "value1");
            update.PublicAccess = StoragePublicAccessType.Container;
            BlobContainerResource container1 = await container.UpdateAsync(update);

            //validate
            Assert.AreEqual(container.Data.PublicAccess, container1.Data.PublicAccess);
            Assert.NotNull(container1);
            Assert.NotNull(container1.Data.Metadata);
            Assert.AreEqual(container1.Data.Metadata["key1"], "value1");
            Assert.AreEqual(StoragePublicAccessType.Container, container.Data.PublicAccess);
            Assert.False(container1.Data.HasLegalHold);
            Assert.False(container1.Data.HasImmutabilityPolicy);

            container1 = (await _blobContainerCollection.GetAsync(containerName)).Value;
            //validate
            Assert.AreEqual(container.Data.PublicAccess, container1.Data.PublicAccess);
            Assert.NotNull(container1);
            Assert.NotNull(container1.Data.Metadata);
            Assert.AreEqual(container1.Data.Metadata["key1"], "value1");
            Assert.AreEqual(StoragePublicAccessType.Container, container.Data.PublicAccess);
            Assert.False(container1.Data.HasLegalHold);
            Assert.False(container1.Data.HasImmutabilityPolicy);
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteImmutabilityPolicy()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, data)).Value;

            //create immutability policy
            ImmutabilityPolicyData immutabilityPolicyData = new ImmutabilityPolicyData()
            {
                ImmutabilityPeriodSinceCreationInDays = 3,
                AllowProtectedAppendWritesAll = true
            };
            ImmutabilityPolicyResource immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, data: immutabilityPolicyData)).Value;

            //validate
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.IsTrue(immutabilityPolicy.Data.AllowProtectedAppendWritesAll);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);

            //delete immutability policy
            immutabilityPolicyData = (await immutabilityPolicy.DeleteAsync(WaitUntil.Completed, immutabilityPolicy.Data.ETag.Value)).Value.Data;

            //validate
            Assert.NotNull(immutabilityPolicyData.Id);
            Assert.NotNull(immutabilityPolicyData.ResourceType);
            Assert.NotNull(immutabilityPolicyData.Name);
            Assert.AreEqual(0, immutabilityPolicyData.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual("Deleted", immutabilityPolicyData.State.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task UpdateImmutabilityPolicy()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, data)).Value;

            //create immutability policy
            ImmutabilityPolicyData immutabilityPolicyData = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicyResource immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicyData)).Value;

            //validate
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);

            //update immutability policy
            immutabilityPolicyData = new ImmutabilityPolicyData()
            {
                ImmutabilityPeriodSinceCreationInDays = 5,
                AllowProtectedAppendWrites = true
            };
            immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicyData, immutabilityPolicy.Data.ETag)).Value;
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(5, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);
            Assert.IsTrue(immutabilityPolicy.Data.AllowProtectedAppendWrites);

            immutabilityPolicy = await container.GetImmutabilityPolicy().GetAsync(immutabilityPolicy.Data.ETag);
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(5, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);
            Assert.IsTrue(immutabilityPolicy.Data.AllowProtectedAppendWrites);
        }

        [Test]
        [RecordedTest]
        public async Task LockImmutabilityPolicy()
        {
            //update storage account to v2
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2
            };
            _storageAccount = await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, data)).Value;

            //create immutability policy
            ImmutabilityPolicyData immutabilityPolicyData = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicyResource immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicyData)).Value;

            //validate
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);

            //lock immutability policy
            immutabilityPolicy = await container.GetImmutabilityPolicy().LockImmutabilityPolicyAsync(immutabilityPolicy.Data.ETag.Value);

            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Data.State);

            await container.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task ExtendImmutabilityPolicy()
        {
            //update storage account to v2
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2
            };
            _storageAccount = await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, data)).Value;

            //create immutability policy
            ImmutabilityPolicyData immutabilityPolicyData = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicyResource immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, data: immutabilityPolicyData)).Value;

            //validate
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);

            //lock immutability policy
            immutabilityPolicy = await container.GetImmutabilityPolicy().LockImmutabilityPolicyAsync(immutabilityPolicy.Data.ETag.Value);

            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(3, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Data.State);

            //extend immutability policy
            immutabilityPolicyData = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 100 };
            immutabilityPolicy = await container.GetImmutabilityPolicy().ExtendImmutabilityPolicyAsync(ifMatch: immutabilityPolicy.Data.ETag.Value, data: immutabilityPolicyData);

            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(100, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.Data.State);
            await container.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task SetClearLegalHold()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, data)).Value;

            //set legal hold
            LegalHold legalHoldModel = new LegalHold(new List<string> { "tag1", "tag2", "tag3" });
            LegalHold legalHold = await container.SetLegalHoldAsync(legalHoldModel);

            //validate
            Assert.True(legalHold.HasLegalHold);
            Assert.AreEqual(new List<string> { "tag1", "tag2", "tag3" }, legalHold.Tags);

            //clear legal hold
            legalHold = await container.ClearLegalHoldAsync(legalHoldModel);

            //validate
            Assert.False(legalHold.HasLegalHold);
            Assert.AreEqual(0, legalHold.Tags.Count);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateBlobService()
        {
            string accountName = Recording.GenerateAssetName("account");
            var content = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardGrs), StorageKind.StorageV2, AzureLocation.EastUS2);
            var account = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName, content)).Value;
            _blobService = await account.GetBlobService().GetAsync();
            //validate current file service properties
            Assert.IsFalse(_blobService.Data.DeleteRetentionPolicy.IsEnabled);
            Assert.IsNull(_blobService.Data.DeleteRetentionPolicy.Days);
            Assert.IsNull(_blobService.Data.DefaultServiceVersion);
            Assert.AreEqual(0, _blobService.Data.Cors.CorsRules.Count);
            Assert.AreEqual(_blobService.Data.Sku.Name, StorageSkuName.StandardGrs);

            //update delete retention policy
            BlobServiceData serviceData = _blobService.Data;
            serviceData.DeleteRetentionPolicy = new DeleteRetentionPolicy
            {
                IsEnabled = true,
                Days = 100,
                AllowPermanentDelete = true,
            };
            serviceData.DefaultServiceVersion = "2017-04-17";
            serviceData.LastAccessTimeTrackingPolicy = new LastAccessTimeTrackingPolicy(true);
            serviceData.IsVersioningEnabled = true;
            BlobServiceResource service = (await _blobService.CreateOrUpdateAsync(WaitUntil.Completed, serviceData)).Value;
            service = (await _blobService.GetAsync()).Value;
            //validate update
            Assert.IsTrue(service.Data.DeleteRetentionPolicy.IsEnabled);
            Assert.AreEqual(100, service.Data.DeleteRetentionPolicy.Days);
            Assert.IsTrue(service.Data.DeleteRetentionPolicy.AllowPermanentDelete);
            Assert.AreEqual("2017-04-17", service.Data.DefaultServiceVersion);
            Assert.IsTrue(service.Data.LastAccessTimeTrackingPolicy.IsEnabled);
            Assert.IsTrue(service.Data.IsVersioningEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task ImmutabilityPolicy_AllowProtectedAppendWrites()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, data)).Value;
            ImmutabilityPolicyData immutabilityPolicyData = new ImmutabilityPolicyData()
            {
                ImmutabilityPeriodSinceCreationInDays = 4,
                AllowProtectedAppendWrites = true
            };
            ImmutabilityPolicyResource immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicyData)).Value;
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(4, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);
            Assert.True(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value);

            immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays = 5;
            immutabilityPolicy.Data.AllowProtectedAppendWrites = false;
            immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicy.Data, ifMatch: immutabilityPolicy.Data.ETag)).Value;
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(5, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);
            Assert.False(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value);

            immutabilityPolicy = await container.GetImmutabilityPolicy().GetAsync(immutabilityPolicy.Data.ETag);
            Assert.NotNull(immutabilityPolicy.Data.Id);
            Assert.NotNull(immutabilityPolicy.Data.ResourceType);
            Assert.NotNull(immutabilityPolicy.Data.Name);
            Assert.AreEqual(5, immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.Data.State);
            Assert.False(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value);
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetDeleteObjectReplicationPolicy()
        {
            //create 2 storage accounts
            string accountName1 = await CreateValidAccountNameAsync("teststoragemgmt");
            string accountName2 = await CreateValidAccountNameAsync("teststoragemgmt");
            StorageAccountCreateOrUpdateContent createContent = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.StorageV2, "centralusEUAP");
            StorageAccountResource sourceAccount = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName1, createContent)).Value;
            StorageAccountResource destAccount = (await _resourceGroup.GetStorageAccounts().CreateOrUpdateAsync(WaitUntil.Completed, accountName2, createContent)).Value;

            //update 2 accounts properties
            var updateparameter = new StorageAccountPatch
            {
                AllowCrossTenantReplication = true,
                EnableHttpsTrafficOnly = true
            };
            destAccount = await destAccount.UpdateAsync(updateparameter);
            sourceAccount = await sourceAccount.UpdateAsync(updateparameter);

            BlobServiceResource blobService1 = await destAccount.GetBlobService().GetAsync();
            BlobContainerCollection blobContainerCollection1 = blobService1.GetBlobContainers();
            BlobServiceResource blobService2 = await destAccount.GetBlobService().GetAsync();
            BlobContainerCollection blobContainerCollection2 = blobService2.GetBlobContainers();

            //enable changefeed and versoning
            blobService1.Data.IsVersioningEnabled = true;
            await blobService1.CreateOrUpdateAsync(WaitUntil.Completed, blobService1.Data);

            //create 2 pairs of source and dest blob containers
            string containerName1 = Recording.GenerateAssetName("testblob1");
            string containerName2 = Recording.GenerateAssetName("testblob2");
            string containerName3 = Recording.GenerateAssetName("testblob3");
            string containerName4 = Recording.GenerateAssetName("testblob4");
            BlobContainerResource container1 = (await blobContainerCollection1.CreateOrUpdateAsync(WaitUntil.Completed, containerName1, new BlobContainerData())).Value;
            BlobContainerResource container2 = (await blobContainerCollection2.CreateOrUpdateAsync(WaitUntil.Completed, containerName2, new BlobContainerData())).Value;
            BlobContainerResource container3 = (await blobContainerCollection1.CreateOrUpdateAsync(WaitUntil.Completed, containerName3, new BlobContainerData())).Value;
            BlobContainerResource container4 = (await blobContainerCollection2.CreateOrUpdateAsync(WaitUntil.Completed, containerName4, new BlobContainerData())).Value;

            //prepare rules and policy
            List<string> prefix = new List<string>();
            prefix.Add("aa");
            prefix.Add("bc d");
            prefix.Add("123");
            string minCreationTime = "2021-03-19T16:06:00Z";
            ObjectReplicationPolicyData parameter = new ObjectReplicationPolicyData()
            {
                SourceAccount = sourceAccount.Id.Name,
                DestinationAccount = destAccount.Id.Name,
                IsMetricsEnabled = true,
                PriorityReplication = new ObjectReplicationPolicyPropertiesPriorityReplication()
                {
                    IsPriorityReplicationEnabled = true,
                },
                Rules =
                {
                    new ObjectReplicationPolicyRule(containerName1, containerName2)
                    {
                        Filters = new ObjectReplicationPolicyFilter(prefix, minCreationTime, null),
                    },
                    new ObjectReplicationPolicyRule(containerName3, containerName4),
                }
            };

            //create policy
            ObjectReplicationPolicyCollection objectReplicationPolicyCollection = destAccount.GetObjectReplicationPolicies();
            ObjectReplicationPolicyResource objectReplicationPolicy = (await objectReplicationPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, "default", parameter)).Value;
            Assert.NotNull(objectReplicationPolicy);
            Assert.AreEqual(objectReplicationPolicy.Data.DestinationAccount, destAccount.Id.Name);
            Assert.AreEqual(objectReplicationPolicy.Data.SourceAccount, sourceAccount.Id.Name);
            Assert.AreEqual(objectReplicationPolicy.Data.IsMetricsEnabled, true);
            Assert.AreEqual(objectReplicationPolicy.Data.PriorityReplication.IsPriorityReplicationEnabled, true);

            //get policy
            List<ObjectReplicationPolicyResource> policies = await objectReplicationPolicyCollection.GetAllAsync().ToEnumerableAsync();
            objectReplicationPolicy = policies[0];
            Assert.NotNull(objectReplicationPolicy);
            Assert.AreEqual(objectReplicationPolicy.Data.DestinationAccount, destAccount.Id.Name);
            Assert.AreEqual(objectReplicationPolicy.Data.SourceAccount, sourceAccount.Id.Name);
            Assert.AreEqual(objectReplicationPolicy.Data.IsMetricsEnabled, true);
            Assert.AreEqual(objectReplicationPolicy.Data.PriorityReplication.IsPriorityReplicationEnabled, true);

            //delete policy
            await objectReplicationPolicy.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task BlobServiceCors()
        {
            BlobServiceData blobServiceData = new BlobServiceData()
            {
                DeleteRetentionPolicy = new DeleteRetentionPolicy()
                {
                    IsEnabled = true,
                    Days = 300,
                },
                DefaultServiceVersion = "2017-04-17",
                Cors = new StorageCorsRules()
                {
                    CorsRules =
                    {
                        new StorageCorsRule(new[] { "http://www.contoso.com", "http://www.fabrikam.com" },
                            new[] { CorsRuleAllowedMethod.Get, CorsRuleAllowedMethod.Put },
                            100,
                            new[] { "x-ms-meta-*" },
                            new[] { "x-ms-meta-abc", "x-ms-meta-data*", "x-ms-meta-target*" })
                    }
                }
            };
            _blobService = (await _blobService.CreateOrUpdateAsync(WaitUntil.Completed, blobServiceData)).Value;

            Assert.AreEqual(blobServiceData.DeleteRetentionPolicy.IsEnabled, _blobService.Data.DeleteRetentionPolicy.IsEnabled);
            Assert.AreEqual(blobServiceData.DeleteRetentionPolicy.Days, _blobService.Data.DeleteRetentionPolicy.Days);
            Assert.AreEqual(blobServiceData.DefaultServiceVersion, _blobService.Data.DefaultServiceVersion);

            //validate CORS rules
            Assert.AreEqual(blobServiceData.Cors.CorsRules.Count, _blobService.Data.Cors.CorsRules.Count);
            for (int i = 0; i < blobServiceData.Cors.CorsRules.Count; i++)
            {
                var putRule = blobServiceData.Cors.CorsRules[i];
                var getRule = _blobService.Data.Cors.CorsRules[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }

            _blobService = await _blobService.GetAsync();

            Assert.AreEqual(blobServiceData.DeleteRetentionPolicy.IsEnabled, _blobService.Data.DeleteRetentionPolicy.IsEnabled);
            Assert.AreEqual(blobServiceData.DeleteRetentionPolicy.Days, _blobService.Data.DeleteRetentionPolicy.Days);
            Assert.AreEqual(blobServiceData.DefaultServiceVersion, _blobService.Data.DefaultServiceVersion);

            //validate CORS rules
            Assert.AreEqual(blobServiceData.Cors.CorsRules.Count, _blobService.Data.Cors.CorsRules.Count);
            for (int i = 0; i < blobServiceData.Cors.CorsRules.Count; i++)
            {
                var putRule = blobServiceData.Cors.CorsRules[i];
                var getRule = _blobService.Data.Cors.CorsRules[i];

                Assert.AreEqual(putRule.AllowedHeaders, getRule.AllowedHeaders);
                Assert.AreEqual(putRule.AllowedMethods, getRule.AllowedMethods);
                Assert.AreEqual(putRule.AllowedOrigins, getRule.AllowedOrigins);
                Assert.AreEqual(putRule.ExposedHeaders, getRule.ExposedHeaders);
                Assert.AreEqual(putRule.MaxAgeInSeconds, getRule.MaxAgeInSeconds);
            }
        }

        [Test]
        [RecordedTest]
        public async Task BlobContainerSoftDelete()
        {
            //update storage account to v2
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2
            };
            await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();
            BlobServiceData properties = _blobService.Data;

            //enable container softdelete
            properties.ContainerDeleteRetentionPolicy = new DeleteRetentionPolicy();
            properties.ContainerDeleteRetentionPolicy.IsEnabled = true;
            properties.ContainerDeleteRetentionPolicy.Days = 30;
            _blobService = (await _blobService.CreateOrUpdateAsync(WaitUntil.Completed, properties)).Value;

            //create two blob containers and delete 1
            string containerName1 = Recording.GenerateAssetName("testblob1");
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainerResource container1 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName1, new BlobContainerData())).Value;
            BlobContainerResource container2 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName2, new BlobContainerData())).Value;
            await container2.DeleteAsync(WaitUntil.Completed);

            //list delete included
            List<BlobContainerResource> blobContainers = await _blobContainerCollection.GetAllAsync(include: BlobContainerState.Deleted).ToEnumerableAsync();
            Assert.AreEqual(2, blobContainers.Count);
            foreach (BlobContainerResource con in blobContainers)
            {
                if (con.Data.Name == containerName1)
                {
                    Assert.IsFalse(con.Data.IsDeleted);
                }
                else
                {
                    Assert.IsTrue(con.Data.IsDeleted);
                    Assert.NotNull(con.Data.RemainingRetentionDays);
                }
            }
            //list without delete included
            blobContainers = await _blobContainerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, blobContainers.Count);

            //disable container softdelete
            properties = _blobService.Data;
            properties.ContainerDeleteRetentionPolicy = new DeleteRetentionPolicy();
            properties.DeleteRetentionPolicy.IsEnabled = false;
            _blobService = (await _blobService.CreateOrUpdateAsync(WaitUntil.Completed, properties)).Value;
            properties = _blobService.Data;
            Assert.IsFalse(properties.ContainerDeleteRetentionPolicy.IsEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task PITR()
        {
            //update storage account to v2
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2
            };
            _storageAccount = await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();

            BlobServiceData properties = _blobService.Data;
            properties.DeleteRetentionPolicy = new DeleteRetentionPolicy();
            properties.DeleteRetentionPolicy.IsEnabled = true;
            properties.DeleteRetentionPolicy.Days = 30;
            properties.ChangeFeed = new BlobServiceChangeFeed();
            properties.ChangeFeed.IsEnabled = true;
            properties.IsVersioningEnabled = true;
            properties.RestorePolicy = new RestorePolicy(true) { Days = 5 };

            _blobService = (await _blobService.CreateOrUpdateAsync(WaitUntil.Completed, properties)).Value;

            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(10000);
            }

            //create restore ranges
            //start restore
            BlobRestoreContent restoreContent = new BlobRestoreContent(
                Recording.Now.AddSeconds(-1).ToUniversalTime(),
                new List<BlobRestoreRange>()
                {
                    new BlobRestoreRange("", "container1/blob1"),
                    new BlobRestoreRange("container1/blob2", "container2/blob3"),
                    new BlobRestoreRange("container3/blob3", "")
                });
            var restoreOperation = await _storageAccount.RestoreBlobRangesAsync(WaitUntil.Started, restoreContent);

            BlobRestoreStatus interimRestoreStatus = await restoreOperation.GetCurrentStatusAsync();
            Assert.IsTrue(interimRestoreStatus.Status == BlobRestoreProgressStatus.InProgress);
            //wait for restore completion
            BlobRestoreStatus restoreStatus = await restoreOperation.WaitForCompletionAsync();

            Assert.IsTrue(restoreStatus.Status == BlobRestoreProgressStatus.Complete || restoreStatus.Status == BlobRestoreProgressStatus.InProgress);
        }

        [Test]
        [RecordedTest]
        [Ignore("account protected from deletion")]
        public async Task BlobContainersVLW()
        {
            //update storage account to v2
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2
            };
            _storageAccount = await _storageAccount.UpdateAsync(updateParameters);
            _blobService = await _blobService.GetAsync();

            //enable blob versioning
            BlobServiceData properties = _blobService.Data;
            properties.IsVersioningEnabled = true;
            _blobService = (await _blobService.CreateOrUpdateAsync(WaitUntil.Completed, properties)).Value;
            Assert.IsTrue(properties.IsVersioningEnabled);

            //create container with VLW
            string containerName1 = Recording.GenerateAssetName("testblob1");
            BlobContainerData parameters1 = new BlobContainerData() { ImmutableStorageWithVersioning = new ImmutableStorageWithVersioning() { IsEnabled = true } };
            BlobContainerResource container1 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName1, parameters1)).Value;
            Assert.IsTrue(container1.Data.ImmutableStorageWithVersioning.IsEnabled);
            Assert.IsNull(container1.Data.ImmutableStorageWithVersioning.MigrationState);

            //update container to enabled  Immutability Policy
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainerData parameters2 = new BlobContainerData();
            BlobContainerResource container2 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName2, parameters2)).Value;
            await container2.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, data: new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 1 });

            await container2.EnableVersionLevelImmutabilityAsync(WaitUntil.Completed);
            container2 = await container2.GetAsync();
            Assert.IsTrue(container2.Data.ImmutableStorageWithVersioning.IsEnabled);
            Assert.AreEqual("Completed", container2.Data.ImmutableStorageWithVersioning.MigrationState);
        }

        [Test]
        [RecordedTest]
        public async Task BlobContainerEncryptionScope()
        {
            //create encryption scope
            string scopeName1 = "testscope1";
            string scopeName2 = "testscope2";
            EncryptionScopeData data = new EncryptionScopeData()
            {
                Source = EncryptionScopeSource.Storage,
                State = EncryptionScopeState.Enabled
            };
            await _storageAccount.GetEncryptionScopes().CreateOrUpdateAsync(WaitUntil.Completed, scopeName1, data);
            await _storageAccount.GetEncryptionScopes().CreateOrUpdateAsync(WaitUntil.Completed, scopeName2, data);

            //create container
            string containerName = Recording.GenerateAssetName("container");
            BlobContainerResource blobContainer = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData() { DefaultEncryptionScope = scopeName1, PreventEncryptionScopeOverride = false })).Value;
            Assert.AreEqual(scopeName1, blobContainer.Data.DefaultEncryptionScope);
            Assert.False(blobContainer.Data.PreventEncryptionScopeOverride.Value);

            //Update container not support Encryption scope
            BlobContainerResource blobContainer2 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData() { DefaultEncryptionScope = scopeName2, PreventEncryptionScopeOverride = true })).Value;
            Assert.AreEqual(scopeName2, blobContainer2.Data.DefaultEncryptionScope);
            Assert.True(blobContainer2.Data.PreventEncryptionScopeOverride.Value);
        }
    }
}
