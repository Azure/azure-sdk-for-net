// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Tests.Helpers;
namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class StorageAccountTests:StorageTestBase
    {
        private ResourceGroup curResourceGroup;
        public StorageAccountTests(bool isAsync) : base(isAsync)
        {
        }
        [TearDown]
        public async Task ClearStorageAccountAsync()
        {
            //remove all storage accounts under current resource group
            if (curResourceGroup != null)
            {
                StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
                List<StorageAccount> storageAccountList = await storageAccountContainer.GetAllAsync().ToEnumerableAsync();
                foreach (StorageAccount account in storageAccountList)
                {
                    await account.DeleteAsync();
                }
                //storageAccountList = await storageAccountContainer.GetAllAsync().ToEnumerableAsync();
                //Console.WriteLine("current count is: " + storageAccountList.Count());
                //await curResourceGroup.DeleteAsync();
                curResourceGroup = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteStorageAccount()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            curResourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            StorageAccount account1 = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, true);
            AssertStorageAccountEqual(account1, await account1.GetAsync());

            //validate
            StorageAccount account2 = await storageAccountContainer.GetAsync(accountName);
            VerifyAccountProperties(account2, true);
            AssertStorageAccountEqual(account1, account2);
            StorageAccount account3 = await storageAccountContainer.GetIfExistsAsync(accountName + "1");
            Assert.IsNull(account3);
            Assert.IsTrue(await storageAccountContainer.CheckIfExistsAsync(accountName));
            Assert.IsFalse(await storageAccountContainer.CheckIfExistsAsync(accountName + "1"));

            //delete storage account
            await account1.DeleteAsync();
            Assert.IsFalse(await storageAccountContainer.CheckIfExistsAsync(accountName));

            //validate
            StorageAccount account4 = await storageAccountContainer.GetIfExistsAsync(accountName);
            Assert.IsNull(account4);
        }
        [Test]
        [RecordedTest]
        public async Task StartCreateDeleteStorageAccount()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            curResourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            StorageAccountCreateOperation accountCreateOp = await storageAccountContainer.StartCreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            StorageAccount account1 = await accountCreateOp.WaitForCompletionAsync();
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, true);
            AssertStorageAccountEqual(account1, await account1.GetAsync());

            //validate
            StorageAccount account2 = await storageAccountContainer.GetAsync(accountName);
            VerifyAccountProperties(account2, true);
            AssertStorageAccountEqual(account1, account2);
            StorageAccount account3 = await storageAccountContainer.GetIfExistsAsync(accountName + "1");
            Assert.IsNull(account3);
            Assert.IsTrue(await storageAccountContainer.CheckIfExistsAsync(accountName));
            Assert.IsFalse(await storageAccountContainer.CheckIfExistsAsync(accountName + "1"));

            //delete storage account
            StorageAccountDeleteOperation accountDeleteOp = await account1.StartDeleteAsync();
            await accountDeleteOp.WaitForCompletionResponseAsync();
            Assert.IsFalse(await storageAccountContainer.CheckIfExistsAsync(accountName));

            //validate
            StorageAccount account4 = await storageAccountContainer.GetIfExistsAsync(accountName);
            Assert.IsNull(account4);
        }
        [Test]
        [RecordedTest]
        public async Task GetAllStorageAccounts()
        {
            //create two storage accounts
            string accountName1 = Recording.GenerateAssetName("storage1");
            string accountName2 = Recording.GenerateAssetName("storage2");
            curResourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            StorageAccount account1 = await storageAccountContainer.CreateOrUpdateAsync(accountName1, GetDefaultStorageAccountParameters());
            StorageAccount account2 = await storageAccountContainer.CreateOrUpdateAsync(accountName2, GetDefaultStorageAccountParameters());

            //validate two storage accounts
            int count = 0;
            StorageAccount account3 = null;
            StorageAccount account4 = null;
            await foreach (StorageAccount account in storageAccountContainer.GetAllAsync())
            {
                count++;
                if (account.Id.Name == accountName1)
                    account3 = account;
                if (account.Id.Name == accountName2)
                    account4 = account;
            }
            Assert.AreEqual(count, 2);
            VerifyAccountProperties(account3,true);
            VerifyAccountProperties(account4, true);
        }
        [Test]
        [RecordedTest]
        public async Task UpdateStorageAccount()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            curResourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = curResourceGroup.GetStorageAccounts();
            StorageAccount account1 = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            VerifyAccountProperties(account1, true);

            //update sku
            StorageAccountUpdateParameters parameters = new StorageAccountUpdateParameters()
            {
                Sku = new Sku(SkuName.StandardLRS),
            };
            account1=await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.Sku.Name, SkuName.StandardLRS);

            // validate
            StorageAccount account2=await storageAccountContainer.GetAsync(accountName);
            Assert.AreEqual(account2.Data.Sku.Name, SkuName.StandardLRS);

            //update tags
            parameters.Tags.Clear();
            parameters.Tags.Add("key3", "value3");
            parameters.Tags.Add("key4", "value4");
            parameters.Tags.Add("key5", "value5");
            account1 =await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.Tags.Count, parameters.Tags.Count);

            //validate
            account2 = await storageAccountContainer.GetAsync(accountName);
            Assert.AreEqual(account2.Data.Tags.Count, parameters.Tags.Count);

            //update encryption
            parameters.Encryption= new Encryption(KeySource.MicrosoftStorage)
            {
                Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            //validate
            account2 = await storageAccountContainer.GetAsync(accountName);
            Assert.NotNull(account2.Data.Encryption);
            Assert.NotNull(account2.Data.Encryption.Services.Blob);
            Assert.True(account2.Data.Encryption.Services.Blob.Enabled);
            Assert.NotNull(account2.Data.Encryption.Services.Blob.LastEnabledTime);
            Assert.NotNull(account2.Data.Encryption.Services.File);
            Assert.True(account2.Data.Encryption.Services.File.Enabled);
            Assert.NotNull(account2.Data.Encryption.Services.File.LastEnabledTime);

            //update hhtptrafficonly and validate
            parameters = new StorageAccountUpdateParameters()
            {
                EnableHttpsTrafficOnly = false
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.EnableHttpsTrafficOnly, false);
            account2 = await storageAccountContainer.GetAsync(accountName);
            Assert.AreEqual(account2.Data.EnableHttpsTrafficOnly, false);
            parameters = new StorageAccountUpdateParameters()
            {
                EnableHttpsTrafficOnly = true
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.EnableHttpsTrafficOnly, true);
            account2 = await storageAccountContainer.GetAsync(accountName);
            Assert.AreEqual(account2.Data.EnableHttpsTrafficOnly, true);
        }
    }
}
