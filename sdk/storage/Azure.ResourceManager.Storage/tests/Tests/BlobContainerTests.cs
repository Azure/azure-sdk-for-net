// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage.Tests.Tests
{
    [TestFixture(true)]
    public class BlobContainerTests: StorageTestBase
    {
        private ResourceGroup curResourceGroup;
        private StorageAccount curStorageAccount;
        public BlobContainerTests(bool async) : base(async)
        {
        }
        [SetUp]
        public async Task createStorageAccountAsync()
        {
            curResourceGroup = await CreateResourceGroupAsync();
            string accountName = "teststorage11114";
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            curStorageAccount = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
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
        public async Task CreateDeleteBlobContainer()
        {
            string blobContainerName = Recording.GenerateAssetName("testblob");
            BlobServiceContainer blobServiceContainer = curStorageAccount.GetBlobServices();
            await foreach (BlobService b in blobServiceContainer.GetAllAsync())
            {
                Console.WriteLine(b.Id.Name);
            }
            BlobService blobService = await blobServiceContainer.GetAsync("teststorage11114");

            BlobContainerContainer blobContainerContainer = blobService.GetBlobContainers();
            BlobContainer blobContainer1 = await blobContainerContainer.CreateOrUpdateAsync(blobContainerName, new BlobContainerData());
            //Assert.IsNotNull(blobContainer1);
            //Assert.AreEqual(blobContainer1.Id.Name, blobContainerName);

            //BlobContainer blobContainer2 = await blobContainerContainer.GetAsync(blobContainerName);
            //BlobHelper.AssertBlob(blobContainer1, blobContainer2);

            //Assert.IsNotNull(await blobContainerContainer.GetIfExistsAsync(blobContainerName));
            //Assert.IsTrue(await blobContainerContainer.CheckIfExistsAsync(blobContainerName));
            //Assert.IsNull(await blobContainerContainer.GetIfExistsAsync(blobContainerName + "1"));
            //Assert.IsFalse(await blobContainerContainer.CheckIfExistsAsync(blobContainerName + "1"));

            //BlobContainerData blobContainerData = blobContainer1.Data;
            //Assert.IsEmpty(blobContainerData.Metadata);
            //Assert.IsFalse(blobContainerData.HasLegalHold);

            //await blobContainer1.DeleteAsync();
            //BlobContainer blobContainer3 = await blobContainerContainer.GetAsync(blobContainerName);
            //Assert.IsNull(blobContainer3);
            //Assert.IsFalse(await blobContainerContainer.CheckIfExistsAsync(blobContainerName));
        }
    }
}
