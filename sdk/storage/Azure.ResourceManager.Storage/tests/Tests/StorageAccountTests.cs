// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;
namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class StorageAccountTests:StorageTestBase
    {
        private ResourceGroup resourceGroup;
        public StorageAccountTests(bool isAsync) : base(isAsync)
        {
        }
        [TearDown]
        public async Task ClearStorageAccounts()
        {
            //remove all storage accounts under current resource group
            if (resourceGroup != null)
            {
                StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
                List<StorageAccount> storageAccountList = await storageAccountContainer.GetAllAsync().ToEnumerableAsync();
                foreach (StorageAccount account in storageAccountList)
                {
                    await account.DeleteAsync();
                }
                resourceGroup = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteStorageAccount()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            StorageAccountCreateOperation accountOperation = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters(),false);
            StorageAccount account1=await accountOperation.WaitForCompletionAsync();
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, true);
            AssertStorageAccountEqual(account1, await account1.GetAsync());

            //validate if created successfully
            StorageAccount account2 = await storageAccountContainer.GetAsync(accountName);
            VerifyAccountProperties(account2, true);
            AssertStorageAccountEqual(account1, account2);
            StorageAccount account3 = await storageAccountContainer.GetIfExistsAsync(accountName + "1");
            Assert.IsNull(account3);
            Assert.IsTrue(await storageAccountContainer.CheckIfExistsAsync(accountName));
            Assert.IsFalse(await storageAccountContainer.CheckIfExistsAsync(accountName + "1"));

            //delete storage account
            await account1.DeleteAsync();

            //validate if deleted successfully
            Assert.IsFalse(await storageAccountContainer.CheckIfExistsAsync(accountName));
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
            resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            StorageAccountCreateOperation accountCreateOperation1 = await storageAccountContainer.CreateOrUpdateAsync(accountName1, GetDefaultStorageAccountParameters());
            StorageAccount account1 = await accountCreateOperation1.WaitForCompletionAsync();
            StorageAccountCreateOperation accountCreateOperation2 = await storageAccountContainer.CreateOrUpdateAsync(accountName2, GetDefaultStorageAccountParameters());
            StorageAccount account2 = await accountCreateOperation2.WaitForCompletionAsync();

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
            resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            StorageAccountCreateOperation accountCreateOperation = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            StorageAccount account1 = await accountCreateOperation.WaitForCompletionAsync();
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

        [Test]
        [RecordedTest]
        public async Task CreateLargeFileShareOnStorageAccount()
        {
            //create storage account and enable large share
            string accountName = Recording.GenerateAssetName("storage");
            resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            Sku sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(sku: sku,kind:Kind.StorageV2);
            parameters.LargeFileSharesState = LargeFileSharesState.Enabled;
            StorageAccountCreateOperation accountCreateOperation = await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters);
            StorageAccount account1 = await accountCreateOperation.WaitForCompletionAsync();
            VerifyAccountProperties(account1, false);

            //create file share with share quota 5200, which is allowed in large file shares
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileService fileService = await account1.GetFileServices().GetAsync("default");
            FileShareContainer shareContainer = fileService.GetFileShares();
            FileShareData shareData = new FileShareData();
            shareData.ShareQuota = 5200;
            FileShareCreateOperation fileShareCreateOperation= await shareContainer.CreateOrUpdateAsync(fileShareName, shareData);
            FileShare share = await fileShareCreateOperation.WaitForCompletionAsync();
            Assert.AreEqual(share.Data.ShareQuota, shareData.ShareQuota);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountRegenerateKey()
        {
            //create storage account and get keys
            string accountName = Recording.GenerateAssetName("storage");
            resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            StorageAccountCreateOperation accountCreateOperation = await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters());
            StorageAccount account1 = await accountCreateOperation.WaitForCompletionAsync();
            VerifyAccountProperties(account1, true);
            StorageAccountListKeysResult keys = await account1.GetKeysAsync();
            Assert.NotNull(keys);
            StorageAccountKey key2 = keys.Keys.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
            Assert.NotNull(key2);

            //regenerate key and verify the key's change
            StorageAccountRegenerateKeyParameters keyParameters = new StorageAccountRegenerateKeyParameters("key2");
            StorageAccountListKeysResult regenKeys = await account1.RegenerateKeyAsync(keyParameters);
            StorageAccountKey regenKey2 = regenKeys.Keys.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
            Assert.NotNull(regenKey2);

            //validate the key is different from origin one
            Assert.AreNotEqual(key2.Value, regenKey2.Value);
        }
        [Test]
        [RecordedTest]
        public async Task CreateUpdataNetworkRule()
        {
            //create storage account with network rule
            string accountName = Recording.GenerateAssetName("storage");
            resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            parameters.NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
            {
                Bypass = @"Logging, AzureServices",
                IpRules = { new IPRule(iPAddressOrRange: "23.45.67.89") }
            };
            StorageAccountCreateOperation accountCreateOperation = await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters);
            StorageAccount account1 = await accountCreateOperation.WaitForCompletionAsync();
            VerifyAccountProperties(account1, false);

            //verify network rule
            StorageAccountData accountData = account1.Data;
            Assert.NotNull(accountData.NetworkRuleSet);
            Assert.AreEqual(@"Logging, AzureServices", accountData.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Deny, accountData.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(accountData.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(accountData.NetworkRuleSet.IpRules);
            Assert.IsNotEmpty(accountData.NetworkRuleSet.IpRules);
            Assert.AreEqual("23.45.67.89", accountData.NetworkRuleSet.IpRules[0].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), accountData.NetworkRuleSet.IpRules[0].Action);

            //update network rule
            StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters()
            {
                NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
                {
                    Bypass = @"Logging, Metrics",
                    IpRules = { new IPRule(iPAddressOrRange: "23.45.67.90"),
                        new IPRule(iPAddressOrRange: "23.45.67.91")
                    }
                }
            };
            StorageAccount account2 = await account1.UpdateAsync(updateParameters);

            //verify updated network rule
            accountData = account2.Data;
            Assert.NotNull(accountData.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", accountData.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Deny, accountData.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(accountData.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(accountData.NetworkRuleSet.IpRules);
            Assert.IsNotEmpty(accountData.NetworkRuleSet.IpRules);
            Assert.AreEqual("23.45.67.90", accountData.NetworkRuleSet.IpRules[0].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), accountData.NetworkRuleSet.IpRules[0].Action);
            Assert.AreEqual("23.45.67.91", accountData.NetworkRuleSet.IpRules[1].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), accountData.NetworkRuleSet.IpRules[1].Action);

            //update network rule to allow
            updateParameters = new StorageAccountUpdateParameters()
            {
                NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Allow)
            };
            StorageAccount account3 = await account2.UpdateAsync(updateParameters);

            //verify updated network rule
            accountData = account3.Data;
            Assert.NotNull(accountData.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", accountData.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Allow, accountData.NetworkRuleSet.DefaultAction);
        }
    }
}
