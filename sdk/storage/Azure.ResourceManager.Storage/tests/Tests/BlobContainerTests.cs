// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class BlobContainerTests: StorageTestBase
    {
        private ResourceGroup _resourceGroup;
        private StorageAccount _storageAccount;
        private BlobServiceContainer _blobServiceContainer;
        private BlobService _blobService;
        private BlobContainerContainer _blobContainerContainer;
        public BlobContainerTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task createStorageAccountAndGetBlobContainerContainer()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("storage");
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            _storageAccount = (await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            _blobServiceContainer = _storageAccount.GetBlobServices();
            _blobService = await _blobServiceContainer.GetAsync("default");
            _blobContainerContainer = _blobService.GetBlobContainers();
        }
        [TearDown]
        public async Task ClearStorageAccount()
        {
            if (_resourceGroup != null)
            {
                StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
                {
                    await account.DeleteAsync();
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
            BlobContainer container1 = (await _blobContainerContainer.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;
            Assert.IsNotNull(container1);
            Assert.AreEqual(container1.Id.Name, containerName);

            //validate if created successfully
            BlobContainer container2 = await _blobContainerContainer.GetAsync(containerName);
            AssertBlobContainerEqual(container1, container2);
            Assert.IsTrue(await _blobContainerContainer.CheckIfExistsAsync(containerName));
            Assert.IsFalse(await _blobContainerContainer.CheckIfExistsAsync(containerName + "1"));
            BlobContainerData containerData = container1.Data;
            Assert.IsEmpty(containerData.Metadata);
            Assert.IsFalse(containerData.HasLegalHold);
            Assert.IsNull(containerData.PublicAccess);
            Assert.False(containerData.HasImmutabilityPolicy);

            //delete blob container
            BlobContainerDeleteOperation blobContainerDeleteOperation = await container1.DeleteAsync();
            await blobContainerDeleteOperation.WaitForCompletionResponseAsync();

            //validate if deleted successfully
            BlobContainer blobContainer3 = await _blobContainerContainer.GetIfExistsAsync(containerName);
            Assert.IsNull(blobContainer3);
            Assert.IsFalse(await _blobContainerContainer.CheckIfExistsAsync(containerName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllBlobContainers()
        {
            //create two blob containers
            string containerName1 = Recording.GenerateAssetName("testblob1");
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainer container1 = (await _blobContainerContainer.CreateOrUpdateAsync(containerName1, new BlobContainerData())).Value;
            BlobContainer container2 = (await _blobContainerContainer.CreateOrUpdateAsync(containerName2, new BlobContainerData())).Value;

            //validate if there are two containers
            BlobContainer container3 = null;
            BlobContainer container4 = null;
            int count = 0;
            await foreach (BlobContainer container in _blobContainerContainer.GetAllAsync())
            {
                count++;
                if (container.Id.Name == containerName1)
                    container3 = container;
                if (container.Id.Name == containerName2)
                    container4 = container;
            }
            Assert.AreEqual(count, 2);
            Assert.IsNotNull(container3);
            Assert.IsNotNull(container4);
        }
        [Test]
        [RecordedTest]
        public async Task UpdateBlobContainer()
        {
            //create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerContainer.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;

            //update metadata, public access
            BlobContainerData containerData = container.Data;
            containerData.Metadata.Add("key1", "value1");
            containerData.PublicAccess = PublicAccess.Container;
            BlobContainer container1=await container.UpdateAsync(containerData);

            //validate
            Assert.NotNull(container1);
            Assert.NotNull(container1.Data.Metadata);
            Assert.AreEqual(container1.Data.Metadata["key1"],"value1");
            Assert.AreEqual(PublicAccess.Container, container.Data.PublicAccess);
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
            BlobContainer container = (await _blobContainerContainer.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;

            //create immutability policy
            ImmutabilityPolicy immutabilityPolicyModel = new ImmutabilityPolicy() { ImmutabilityPeriodSinceCreationInDays = 3 };
            ImmutabilityPolicy immutabilityPolicy = await container.CreateOrUpdateImmutabilityPolicyAsync(parameters: immutabilityPolicyModel);

            //validate
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Type);
            Assert.NotNull(immutabilityPolicy.Name);
            Assert.AreEqual(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);

            //delete immutability policy
            immutabilityPolicy = await container.DeleteImmutabilityPolicyAsync(immutabilityPolicy.Etag);

            //validate
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Type);
            Assert.NotNull(immutabilityPolicy.Name);
            Assert.AreEqual(0, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
        }

        [Test]
        [RecordedTest]
        public async Task SetClearLegalHold()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerContainer.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;

            //set legal hold
            LegalHold legalHoldModel = new LegalHold(new List<string> { "tag1", "tag2", "tag3" });
            LegalHold legalHold =await container.SetLegalHoldAsync(legalHoldModel);

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
            //validate current file service properties
            Assert.False(_blobService.Data.DeleteRetentionPolicy.Enabled);
            Assert.Null(_blobService.Data.DeleteRetentionPolicy.Days);

            //update delete retention policy
            BlobServiceData serviceData = _blobService.Data;
            serviceData.DeleteRetentionPolicy = new DeleteRetentionPolicy
            {
                Enabled = true,
                Days = 100
            };
            BlobService service = await _blobService.SetServicePropertiesAsync(serviceData);

            //validate update
            Assert.True(service.Data.DeleteRetentionPolicy.Enabled);
            Assert.AreEqual(service.Data.DeleteRetentionPolicy.Days, 100);
        }
        [Test]
        [RecordedTest]
        public async Task ImmutabilityPolicy_AllowProtectedAppendWrites()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = (await _blobContainerContainer.CreateOrUpdateAsync(containerName, new BlobContainerData())).Value;
            ImmutabilityPolicy immutabilityPolicy = new ImmutabilityPolicy()
            {
                ImmutabilityPeriodSinceCreationInDays=4,
                AllowProtectedAppendWrites = true
            };
            immutabilityPolicy =await container.CreateOrUpdateImmutabilityPolicyAsync(ifMatch: "",immutabilityPolicy);
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Type);
            Assert.NotNull(immutabilityPolicy.Name);
            Assert.AreEqual(4, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);
            Assert.True(immutabilityPolicy.AllowProtectedAppendWrites.Value);

            immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays = 5;
            immutabilityPolicy.AllowProtectedAppendWrites = false;
            immutabilityPolicy = await container.CreateOrUpdateImmutabilityPolicyAsync(ifMatch: immutabilityPolicy.Etag, immutabilityPolicy);
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Type);
            Assert.NotNull(immutabilityPolicy.Name);
            Assert.AreEqual(5, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);
            Assert.False(immutabilityPolicy.AllowProtectedAppendWrites.Value);

            immutabilityPolicy = await container.GetImmutabilityPolicyAsync(immutabilityPolicy.Etag);
            Assert.NotNull(immutabilityPolicy.Id);
            Assert.NotNull(immutabilityPolicy.Type);
            Assert.NotNull(immutabilityPolicy.Name);
            Assert.AreEqual(5, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);
            Assert.False(immutabilityPolicy.AllowProtectedAppendWrites.Value);
        }
    }
}
