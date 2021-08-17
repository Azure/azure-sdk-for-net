// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class BlobContainerTests: StorageTestBase
    {
        private ResourceGroup curResourceGroup;
        private StorageAccount curStorageAccount;
        private BlobServiceContainer blobServiceContainer;
        private BlobService blobService;
        private BlobContainerContainer blobContainerContainer;
        public BlobContainerTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task createStorageAccountAndGetBlobContainersAsync()
        {
            curResourceGroup = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("storage");
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            curStorageAccount = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            blobServiceContainer = curStorageAccount.GetBlobServices();
            blobService = await blobServiceContainer.GetAsync("default");
            blobContainerContainer = blobService.GetBlobContainers();
        }
        [TearDown]
        public async Task clearStorageAccountAsync()
        {
            if (curResourceGroup != null)
            {
                StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
                await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
                {
                    await account.DeleteAsync();
                }
                curResourceGroup = null;
                curStorageAccount = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteBlobContainer()
        {
            //create blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainer container1 = await blobContainerContainer.CreateOrUpdateAsync(containerName, new BlobContainerData());
            Assert.IsNotNull(container1);
            Assert.AreEqual(container1.Id.Name, containerName);

            //validate
            BlobContainer container2 = await blobContainerContainer.GetAsync(containerName);
            BlobHelper.AssertBlobContainer(container1, container2);
            Assert.IsTrue(await blobContainerContainer.CheckIfExistsAsync(containerName));
            Assert.IsFalse(await blobContainerContainer.CheckIfExistsAsync(containerName + "1"));
            BlobContainerData containerData = container1.Data;
            Assert.IsEmpty(containerData.Metadata);
            Assert.IsFalse(containerData.HasLegalHold);
            Assert.IsNull(containerData.PublicAccess);
            Assert.False(containerData.HasImmutabilityPolicy);

            //delete blob container
            await container1.DeleteAsync();

            //validate if deleted successfully
            BlobContainer blobContainer3 = await blobContainerContainer.GetIfExistsAsync(containerName);
            Assert.IsNull(blobContainer3);
            Assert.IsFalse(await blobContainerContainer.CheckIfExistsAsync(containerName));
        }

        [Test]
        [RecordedTest]
        public async Task StartCreateDeleteBlobContainer()
        {
            //start create blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerCreateOperation containerCreateOp=await blobContainerContainer.StartCreateOrUpdateAsync(containerName, new BlobContainerData());
            BlobContainer container1 = await containerCreateOp.WaitForCompletionAsync();
            Assert.IsNotNull(container1);
            Assert.AreEqual(container1.Id.Name, containerName);

            //validate
            BlobContainer container2 = await blobContainerContainer.GetAsync(containerName);
            BlobHelper.AssertBlobContainer(container1, container2);
            Assert.IsTrue(await blobContainerContainer.CheckIfExistsAsync(containerName));
            Assert.IsFalse(await blobContainerContainer.CheckIfExistsAsync(containerName + "1"));
            BlobContainerData containerData = container1.Data;
            Assert.IsEmpty(containerData.Metadata);
            Assert.IsFalse(containerData.HasLegalHold);
            Assert.IsNull(containerData.PublicAccess);
            Assert.False(containerData.HasImmutabilityPolicy);
            Assert.False(containerData.HasLegalHold);

            //delete blob container
            BlobContainerDeleteOperation containerDeleteOp = await container1.StartDeleteAsync();
            await containerDeleteOp.WaitForCompletionResponseAsync();

            //validate if deleted successfully
            BlobContainer blobContainer3 = await blobContainerContainer.GetIfExistsAsync(containerName);
            Assert.IsNull(blobContainer3);
            Assert.IsFalse(await blobContainerContainer.CheckIfExistsAsync(containerName));
        }

        [Test]
        [RecordedTest]
        public async Task GetAllBlobContainers()
        {
            //create two blob containers
            string containerName1 = Recording.GenerateAssetName("testblob1");
            string containerName2 = Recording.GenerateAssetName("testblob2");
            BlobContainer container1 = await blobContainerContainer.CreateOrUpdateAsync(containerName1, new BlobContainerData());
            BlobContainer container2 = await blobContainerContainer.CreateOrUpdateAsync(containerName2, new BlobContainerData());

            //validate if there are two containers
            BlobContainer container3 = null;
            BlobContainer container4 = null;
            int count = 0;
            await foreach (BlobContainer container in blobContainerContainer.GetAllAsync())
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
        public async Task UpdataBlobContainer()
        {
            //create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container =await blobContainerContainer.CreateOrUpdateAsync(containerName, data);

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

        //[Test]
        //[RecordedTest]
        //public async Task CreateUpdateImmutabilityPolicy()
        //{
        //    // create a blob container
        //    string containerName = Recording.GenerateAssetName("testblob");
        //    BlobContainerData data = new BlobContainerData();
        //    BlobContainer container = await blobContainerContainer.CreateOrUpdateAsync(containerName, data);

        //    //create immutability policy
        //    ImmutabilityPolicy immutabilityPolicyModel = new ImmutabilityPolicy() { ImmutabilityPeriodSinceCreationInDays = 3 };
        //    ImmutabilityPolicy immutabilityPolicy = await container.CreateOrUpdateImmutabilityPolicyAsync(parameters: immutabilityPolicyModel);

        //    //validate
        //    Assert.NotNull(immutabilityPolicy.Id);
        //    Assert.NotNull(immutabilityPolicy.Type);
        //    Assert.NotNull(immutabilityPolicy.Name);
        //    Assert.AreEqual(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
        //    Assert.AreEqual(ImmutabilityPolicyState.Unlocked, immutabilityPolicy.State);

        //    //lock immutability policy
        //    immutabilityPolicy = await container.LockImmutabilityPolicyAsync(ifMatch: immutabilityPolicy.Etag);

        //    //validate
        //    Assert.NotNull(immutabilityPolicy.Id);
        //    Assert.NotNull(immutabilityPolicy.Type);
        //    Assert.NotNull(immutabilityPolicy.Name);
        //    Assert.AreEqual(3, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
        //    Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.State);

        //    //extend immutability policy
        //    immutabilityPolicyModel.ImmutabilityPeriodSinceCreationInDays = 10;
        //    immutabilityPolicy = await container.ExtendImmutabilityPolicyAsync(immutabilityPolicy.Etag, parameters: immutabilityPolicyModel);

        //    //validate
        //    Assert.NotNull(immutabilityPolicy.Id);
        //    Assert.NotNull(immutabilityPolicy.Type);
        //    Assert.NotNull(immutabilityPolicy.Name);
        //    Assert.AreEqual(10, immutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
        //    Assert.AreEqual(ImmutabilityPolicyState.Locked, immutabilityPolicy.State);
        //    BlobContainer container1 =await blobContainerContainer.GetAsync(containerName);
        //    Assert.AreEqual(container1.Data.ImmutabilityPolicy.UpdateHistory.Count,3);
        //    Assert.AreEqual(ImmutabilityPolicyUpdateType.Put, container1.Data.ImmutabilityPolicy.UpdateHistory[0].Update);
        //    Assert.AreEqual(ImmutabilityPolicyUpdateType.Lock, container1.Data.ImmutabilityPolicy.UpdateHistory[1].Update);
        //    Assert.AreEqual(ImmutabilityPolicyUpdateType.Extend, container1.Data.ImmutabilityPolicy.UpdateHistory[2].Update);
        //}
        [Test]
        [RecordedTest]
        public async Task CreateDeleteImmutabilityPolicy()
        {
            // create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobContainer container = await blobContainerContainer.CreateOrUpdateAsync(containerName, data);

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
            BlobContainer container = await blobContainerContainer.CreateOrUpdateAsync(containerName, data);

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
    }
}
