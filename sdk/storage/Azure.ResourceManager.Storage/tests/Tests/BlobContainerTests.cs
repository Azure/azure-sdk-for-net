// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

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
            Assert.That(container1, Is.Not.Null);
            Assert.That(containerName, Is.EqualTo(container1.Id.Name));
            Assert.That(container1.Data.Metadata, Is.Empty);
            Assert.That(container1.Data.PublicAccess, Is.Null);

            //validate if created successfully
            BlobContainerResource container2 = await _blobContainerCollection.GetAsync(containerName);
            AssertBlobContainerEqual(container1, container2);
            Assert.That((bool)await _blobContainerCollection.ExistsAsync(containerName), Is.True);
            Assert.That((bool)await _blobContainerCollection.ExistsAsync(containerName + "1"), Is.False);
            BlobContainerData containerData = container1.Data;
            Assert.That(containerData.Metadata, Is.Empty);
            Assert.That(containerData.HasLegalHold, Is.False);
            Assert.That(containerData.PublicAccess, Is.Null);
            Assert.That(containerData.HasImmutabilityPolicy, Is.False);

            //delete blob container
            ArmOperation blobContainerDeleteOperation = await container1.DeleteAsync(WaitUntil.Completed);
            await blobContainerDeleteOperation.WaitForCompletionResponseAsync();

            //validate if deleted successfully
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await _blobContainerCollection.GetAsync(containerName); });
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await _blobContainerCollection.ExistsAsync(containerName), Is.False);
        }

        [Test]
        [RecordedTest]
        public async Task GetBlobContainer()
        {
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerResource container = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData())).Value;

            Assert.That(container.Data.Metadata, Is.Empty);
            Assert.That(container.Data.PublicAccess, Is.Null);

            LegalHold legalHoldModel = new LegalHold(new List<string> { "tag1", "tag2", "tag3" });
            LegalHold legalHold = await container.SetLegalHoldAsync(legalHoldModel);
            Assert.That(legalHold.HasLegalHold, Is.True);
            Assert.That(legalHold.Tags, Is.EqualTo(new List<string> { "tag1", "tag2", "tag3" }));

            ImmutabilityPolicyData immutabilityPolicyModel = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicyResource immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicyModel)).Value;
            Assert.That(immutabilityPolicy.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(3));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));

            immutabilityPolicy = await container.GetImmutabilityPolicy().LockImmutabilityPolicyAsync(immutabilityPolicy.Data.ETag.Value);
            Assert.That(immutabilityPolicy.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(3));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Locked));

            immutabilityPolicyModel = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 100 };
            immutabilityPolicy = await container.GetImmutabilityPolicy().ExtendImmutabilityPolicyAsync(immutabilityPolicy.Data.ETag.Value, data: immutabilityPolicyModel);
            Assert.That(immutabilityPolicy.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(100));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Locked));

            container = await container.GetAsync();
            Assert.That(container.Data.Metadata, Is.Empty);
            Assert.That(container.Data.PublicAccess, Is.EqualTo(StoragePublicAccessType.None));
            Assert.That(container.Data.ImmutabilityPolicy.UpdateHistory.Count, Is.EqualTo(3));
            Assert.That(container.Data.ImmutabilityPolicy.UpdateHistory[0].UpdateType, Is.EqualTo(ImmutabilityPolicyUpdateType.Put));
            Assert.That(container.Data.ImmutabilityPolicy.UpdateHistory[1].UpdateType, Is.EqualTo(ImmutabilityPolicyUpdateType.Lock));
            Assert.That(container.Data.ImmutabilityPolicy.UpdateHistory[2].UpdateType, Is.EqualTo(ImmutabilityPolicyUpdateType.Extend));
            Assert.That(container.Data.LegalHold.HasLegalHold, Is.True);
            Assert.That(container.Data.LegalHold.Tags.Count, Is.EqualTo(3));
            Assert.That(container.Data.LegalHold.Tags[0].Tag, Is.EqualTo("tag1"));
            Assert.That(container.Data.LegalHold.Tags[1].Tag, Is.EqualTo("tag2"));
            Assert.That(container.Data.LegalHold.Tags[2].Tag, Is.EqualTo("tag3"));

            legalHold = await container.ClearLegalHoldAsync(legalHold);
            Assert.That(legalHold.HasLegalHold, Is.False);

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
            Assert.That(containerList.Count, Is.EqualTo(2));
            foreach (var item in containerList)
            {
                Assert.That(item.Data.Name, Is.Not.Null);
                Assert.That(item.Data.PublicAccess, Is.Not.Null);
                Assert.That(item.Data.HasImmutabilityPolicy, Is.False);
                Assert.That(item.Data.HasLegalHold, Is.False);
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
            Assert.That(container1.Data.PublicAccess, Is.EqualTo(container.Data.PublicAccess));
            Assert.That(container1, Is.Not.Null);
            Assert.That(container1.Data.Metadata, Is.Not.Null);
            Assert.That(container1.Data.Metadata["key1"], Is.EqualTo("value1"));
            Assert.That(container.Data.PublicAccess, Is.EqualTo(StoragePublicAccessType.Container));
            Assert.That(container1.Data.HasLegalHold, Is.False);
            Assert.That(container1.Data.HasImmutabilityPolicy, Is.False);

            container1 = (await _blobContainerCollection.GetAsync(containerName)).Value;
            //validate
            Assert.That(container1.Data.PublicAccess, Is.EqualTo(container.Data.PublicAccess));
            Assert.That(container1, Is.Not.Null);
            Assert.That(container1.Data.Metadata, Is.Not.Null);
            Assert.That(container1.Data.Metadata["key1"], Is.EqualTo("value1"));
            Assert.That(container.Data.PublicAccess, Is.EqualTo(StoragePublicAccessType.Container));
            Assert.That(container1.Data.HasLegalHold, Is.False);
            Assert.That(container1.Data.HasImmutabilityPolicy, Is.False);
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
            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(3));
            Assert.That(immutabilityPolicy.Data.AllowProtectedAppendWritesAll, Is.True);
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));

            //delete immutability policy
            immutabilityPolicyData = (await immutabilityPolicy.DeleteAsync(WaitUntil.Completed, immutabilityPolicy.Data.ETag.Value)).Value.Data;

            //validate
            Assert.That(immutabilityPolicyData.Id, Is.Not.Null);
            Assert.That(immutabilityPolicyData.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicyData.Name, Is.Not.Null);
            Assert.That(immutabilityPolicyData.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(0));
            Assert.That(immutabilityPolicyData.State.ToString(), Is.EqualTo("Deleted"));
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
            Assert.That(immutabilityPolicy.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(3));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));

            //update immutability policy
            immutabilityPolicyData = new ImmutabilityPolicyData()
            {
                ImmutabilityPeriodSinceCreationInDays = 5,
                AllowProtectedAppendWrites = true
            };
            immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicyData, immutabilityPolicy.Data.ETag)).Value;
            Assert.That(immutabilityPolicy.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(5));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));
            Assert.That(immutabilityPolicy.Data.AllowProtectedAppendWrites, Is.True);

            immutabilityPolicy = await container.GetImmutabilityPolicy().GetAsync(immutabilityPolicy.Data.ETag);
            Assert.That(immutabilityPolicy.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(5));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));
            Assert.That(immutabilityPolicy.Data.AllowProtectedAppendWrites, Is.True);
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
            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(3));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));

            //lock immutability policy
            immutabilityPolicy = await container.GetImmutabilityPolicy().LockImmutabilityPolicyAsync(immutabilityPolicy.Data.ETag.Value);

            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(3));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Locked));

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
            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(3));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));

            //lock immutability policy
            immutabilityPolicy = await container.GetImmutabilityPolicy().LockImmutabilityPolicyAsync(immutabilityPolicy.Data.ETag.Value);

            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(3));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Locked));

            //extend immutability policy
            immutabilityPolicyData = new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 100 };
            immutabilityPolicy = await container.GetImmutabilityPolicy().ExtendImmutabilityPolicyAsync(ifMatch: immutabilityPolicy.Data.ETag.Value, data: immutabilityPolicyData);

            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(100));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Locked));
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
            Assert.That(legalHold.HasLegalHold, Is.True);
            Assert.That(legalHold.Tags, Is.EqualTo(new List<string> { "tag1", "tag2", "tag3" }));

            //clear legal hold
            legalHold = await container.ClearLegalHoldAsync(legalHoldModel);

            //validate
            Assert.That(legalHold.HasLegalHold, Is.False);
            Assert.That(legalHold.Tags.Count, Is.EqualTo(0));
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
            Assert.That(_blobService.Data.DeleteRetentionPolicy.IsEnabled, Is.False);
            Assert.That(_blobService.Data.DeleteRetentionPolicy.Days, Is.Null);
            Assert.That(_blobService.Data.DefaultServiceVersion, Is.Null);
            Assert.That(_blobService.Data.Cors.CorsRules.Count, Is.EqualTo(0));
            Assert.That(StorageSkuName.StandardGrs, Is.EqualTo(_blobService.Data.Sku.Name));

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
            Assert.That(service.Data.DeleteRetentionPolicy.IsEnabled, Is.True);
            Assert.That(service.Data.DeleteRetentionPolicy.Days, Is.EqualTo(100));
            Assert.That(service.Data.DeleteRetentionPolicy.AllowPermanentDelete, Is.True);
            Assert.That(service.Data.DefaultServiceVersion, Is.EqualTo("2017-04-17"));
            Assert.That(service.Data.LastAccessTimeTrackingPolicy.IsEnabled, Is.True);
            Assert.That(service.Data.IsVersioningEnabled, Is.True);
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
            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(4));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));
            Assert.That(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value, Is.True);

            immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays = 5;
            immutabilityPolicy.Data.AllowProtectedAppendWrites = false;
            immutabilityPolicy = (await container.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, immutabilityPolicy.Data, ifMatch: immutabilityPolicy.Data.ETag)).Value;
            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(5));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));
            Assert.That(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value, Is.False);

            immutabilityPolicy = await container.GetImmutabilityPolicy().GetAsync(immutabilityPolicy.Data.ETag);
            Assert.That(immutabilityPolicy.Data.Id, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ResourceType, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.Name, Is.Not.Null);
            Assert.That(immutabilityPolicy.Data.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(5));
            Assert.That(immutabilityPolicy.Data.State, Is.EqualTo(ImmutabilityPolicyState.Unlocked));
            Assert.That(immutabilityPolicy.Data.AllowProtectedAppendWrites.Value, Is.False);
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
            Assert.That(objectReplicationPolicy, Is.Not.Null);
            Assert.That(destAccount.Id.Name, Is.EqualTo(objectReplicationPolicy.Data.DestinationAccount));
            Assert.That(sourceAccount.Id.Name, Is.EqualTo(objectReplicationPolicy.Data.SourceAccount));
            Assert.That(objectReplicationPolicy.Data.IsMetricsEnabled, Is.EqualTo(true));
            Assert.That(objectReplicationPolicy.Data.PriorityReplication.IsPriorityReplicationEnabled, Is.EqualTo(true));

            //get policy
            List<ObjectReplicationPolicyResource> policies = await objectReplicationPolicyCollection.GetAllAsync().ToEnumerableAsync();
            objectReplicationPolicy = policies[0];
            Assert.That(objectReplicationPolicy, Is.Not.Null);
            Assert.That(destAccount.Id.Name, Is.EqualTo(objectReplicationPolicy.Data.DestinationAccount));
            Assert.That(sourceAccount.Id.Name, Is.EqualTo(objectReplicationPolicy.Data.SourceAccount));
            Assert.That(objectReplicationPolicy.Data.IsMetricsEnabled, Is.EqualTo(true));
            Assert.That(objectReplicationPolicy.Data.PriorityReplication.IsPriorityReplicationEnabled, Is.EqualTo(true));

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

            Assert.That(_blobService.Data.DeleteRetentionPolicy.IsEnabled, Is.EqualTo(blobServiceData.DeleteRetentionPolicy.IsEnabled));
            Assert.That(_blobService.Data.DeleteRetentionPolicy.Days, Is.EqualTo(blobServiceData.DeleteRetentionPolicy.Days));
            Assert.That(_blobService.Data.DefaultServiceVersion, Is.EqualTo(blobServiceData.DefaultServiceVersion));

            //validate CORS rules
            Assert.That(_blobService.Data.Cors.CorsRules.Count, Is.EqualTo(blobServiceData.Cors.CorsRules.Count));
            for (int i = 0; i < blobServiceData.Cors.CorsRules.Count; i++)
            {
                var putRule = blobServiceData.Cors.CorsRules[i];
                var getRule = _blobService.Data.Cors.CorsRules[i];

                Assert.That(getRule.AllowedHeaders, Is.EqualTo(putRule.AllowedHeaders));
                Assert.That(getRule.AllowedMethods, Is.EqualTo(putRule.AllowedMethods));
                Assert.That(getRule.AllowedOrigins, Is.EqualTo(putRule.AllowedOrigins));
                Assert.That(getRule.ExposedHeaders, Is.EqualTo(putRule.ExposedHeaders));
                Assert.That(getRule.MaxAgeInSeconds, Is.EqualTo(putRule.MaxAgeInSeconds));
            }

            _blobService = await _blobService.GetAsync();

            Assert.That(_blobService.Data.DeleteRetentionPolicy.IsEnabled, Is.EqualTo(blobServiceData.DeleteRetentionPolicy.IsEnabled));
            Assert.That(_blobService.Data.DeleteRetentionPolicy.Days, Is.EqualTo(blobServiceData.DeleteRetentionPolicy.Days));
            Assert.That(_blobService.Data.DefaultServiceVersion, Is.EqualTo(blobServiceData.DefaultServiceVersion));

            //validate CORS rules
            Assert.That(_blobService.Data.Cors.CorsRules.Count, Is.EqualTo(blobServiceData.Cors.CorsRules.Count));
            for (int i = 0; i < blobServiceData.Cors.CorsRules.Count; i++)
            {
                var putRule = blobServiceData.Cors.CorsRules[i];
                var getRule = _blobService.Data.Cors.CorsRules[i];

                Assert.That(getRule.AllowedHeaders, Is.EqualTo(putRule.AllowedHeaders));
                Assert.That(getRule.AllowedMethods, Is.EqualTo(putRule.AllowedMethods));
                Assert.That(getRule.AllowedOrigins, Is.EqualTo(putRule.AllowedOrigins));
                Assert.That(getRule.ExposedHeaders, Is.EqualTo(putRule.ExposedHeaders));
                Assert.That(getRule.MaxAgeInSeconds, Is.EqualTo(putRule.MaxAgeInSeconds));
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
            Assert.That(blobContainers.Count, Is.EqualTo(2));
            foreach (BlobContainerResource con in blobContainers)
            {
                if (con.Data.Name == containerName1)
                {
                    Assert.That(con.Data.IsDeleted, Is.False);
                }
                else
                {
                    Assert.That(con.Data.IsDeleted, Is.True);
                    Assert.That(con.Data.RemainingRetentionDays, Is.Not.Null);
                }
            }
            //list without delete included
            blobContainers = await _blobContainerCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(blobContainers.Count, Is.EqualTo(1));

            //disable container softdelete
            properties = _blobService.Data;
            properties.ContainerDeleteRetentionPolicy = new DeleteRetentionPolicy();
            properties.DeleteRetentionPolicy.IsEnabled = false;
            _blobService = (await _blobService.CreateOrUpdateAsync(WaitUntil.Completed, properties)).Value;
            properties = _blobService.Data;
            Assert.That(properties.ContainerDeleteRetentionPolicy.IsEnabled, Is.False);
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
            Assert.That(interimRestoreStatus.Status, Is.EqualTo(BlobRestoreProgressStatus.InProgress));
            //wait for restore completion
            BlobRestoreStatus restoreStatus = await restoreOperation.WaitForCompletionAsync();

            Assert.That(restoreStatus.Status == BlobRestoreProgressStatus.Complete || restoreStatus.Status == BlobRestoreProgressStatus.InProgress, Is.True);
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
            Assert.That(properties.IsVersioningEnabled, Is.True);

            //create container with VLW
            string containerName1 = Recording.GenerateAssetName("testblob1");
            BlobContainerData parameters1 = new BlobContainerData() { ImmutableStorageWithVersioning = new ImmutableStorageWithVersioning() { IsEnabled = true } };
            BlobContainerResource container1 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName1, parameters1)).Value;
            Assert.That(container1.Data.ImmutableStorageWithVersioning.IsEnabled, Is.True);
            Assert.That(container1.Data.ImmutableStorageWithVersioning.MigrationState, Is.Null);

            //update container to enabled  Immutability Policy
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainerData parameters2 = new BlobContainerData();
            BlobContainerResource container2 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName2, parameters2)).Value;
            await container2.GetImmutabilityPolicy().CreateOrUpdateAsync(WaitUntil.Completed, data: new ImmutabilityPolicyData() { ImmutabilityPeriodSinceCreationInDays = 1 });

            await container2.EnableVersionLevelImmutabilityAsync(WaitUntil.Completed);
            container2 = await container2.GetAsync();
            Assert.That(container2.Data.ImmutableStorageWithVersioning.IsEnabled, Is.True);
            Assert.That(container2.Data.ImmutableStorageWithVersioning.MigrationState, Is.EqualTo("Completed"));
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
            Assert.That(blobContainer.Data.DefaultEncryptionScope, Is.EqualTo(scopeName1));
            Assert.That(blobContainer.Data.PreventEncryptionScopeOverride.Value, Is.False);

            //Update container not support Encryption scope
            BlobContainerResource blobContainer2 = (await _blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData() { DefaultEncryptionScope = scopeName2, PreventEncryptionScopeOverride = true })).Value;
            Assert.That(blobContainer2.Data.DefaultEncryptionScope, Is.EqualTo(scopeName2));
            Assert.That(blobContainer2.Data.PreventEncryptionScopeOverride.Value, Is.True);
        }
    }
}
