﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Azure.ResourceManager.Resources.Models;
using Sku = Azure.ResourceManager.Storage.Models.Sku;
namespace Azure.ResourceManager.Storage.Tests.Tests
{
    public class StorageAccountTests : StorageTestBase
    {
        private ResourceGroup _resourceGroup;
        public StorageAccountTests(bool isAsync) : base(isAsync)
        {
        }
        [TearDown]
        public async Task ClearStorageAccounts()
        {
            //remove all storage accounts under current resource group
            if (_resourceGroup != null)
            {
                StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
                List<StorageAccount> storageAccountList = await storageAccountContainer.GetAllAsync().ToEnumerableAsync();
                foreach (StorageAccount account in storageAccountList)
                {
                    await account.DeleteAsync();
                }
                _resourceGroup = null;
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateDeleteStorageAccount()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
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
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName1, GetDefaultStorageAccountParameters())).Value;
            StorageAccount account2 = (await storageAccountContainer.CreateOrUpdateAsync(accountName2, GetDefaultStorageAccountParameters())).Value;

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
            VerifyAccountProperties(account3, true);
            VerifyAccountProperties(account4, true);
        }
        [Test]
        [RecordedTest]
        public async Task UpdateStorageAccount()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(account1, true);

            //update sku
            StorageAccountUpdateParameters parameters = new StorageAccountUpdateParameters()
            {
                Sku = new Sku(SkuName.StandardLRS),
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.Sku.Name, SkuName.StandardLRS);

            // validate
            StorageAccount account2 = await storageAccountContainer.GetAsync(accountName);
            Assert.AreEqual(account2.Data.Sku.Name, SkuName.StandardLRS);

            //update tags
            parameters.Tags.Clear();
            parameters.Tags.Add("key3", "value3");
            parameters.Tags.Add("key4", "value4");
            parameters.Tags.Add("key5", "value5");
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.Tags.Count, parameters.Tags.Count);

            //validate
            account2 = await storageAccountContainer.GetAsync(accountName);
            Assert.AreEqual(account2.Data.Tags.Count, parameters.Tags.Count);

            //update encryption
            parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
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

            //update http traffic only and validate
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
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            Sku sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(sku: sku, kind: Kind.StorageV2);
            parameters.LargeFileSharesState = LargeFileSharesState.Enabled;
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;
            VerifyAccountProperties(account1, false);

            //create file share with share quota 5200, which is allowed in large file shares
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileService fileService = await account1.GetFileServices().GetAsync("default");
            FileShareContainer shareContainer = fileService.GetFileShares();
            FileShareData shareData = new FileShareData();
            shareData.ShareQuota = 5200;
            FileShareCreateOperation fileShareCreateOperation = await shareContainer.CreateOrUpdateAsync(fileShareName, shareData);
            FileShare share = await fileShareCreateOperation.WaitForCompletionAsync();
            Assert.AreEqual(share.Data.ShareQuota, shareData.ShareQuota);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountRegenerateKey()
        {
            Sanitizer.AddJsonPathSanitizer("$.keys.[*].value");
            //create storage account and get keys
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
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
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.AreNotEqual(key2.Value, regenKey2.Value);
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateUpdataNetworkRule()
        {
            //create storage account with network rule
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            parameters.NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
            {
                Bypass = @"Logging, AzureServices",
                IpRules = { new IPRule(iPAddressOrRange: "23.45.67.89") }
            };
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;
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
        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithBlockBlobStorage()
        {
            //create storage account with block blob storage
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            Sku sku = new Sku(SkuName.PremiumLRS);
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(sku: sku, kind: Kind.BlockBlobStorage);
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(Kind.BlockBlobStorage, account1.Data.Kind);
            Assert.AreEqual(SkuName.PremiumLRS, account1.Data.Sku.Name);
            //this storage account should only have endpoints on blob and dfs
            Assert.NotNull(account1.Data.PrimaryEndpoints.Blob);
            Assert.NotNull(account1.Data.PrimaryEndpoints.Dfs);
            Assert.IsNull(account1.Data.PrimaryEndpoints.File);
            Assert.IsNull(account1.Data.PrimaryEndpoints.Table);
            Assert.IsNull(account1.Data.PrimaryEndpoints.Queue);
        }
        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithFileStorage()
        {
            //create storage account with file storage
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            Sku sku = new Sku(SkuName.PremiumLRS);
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(sku: sku, kind: Kind.FileStorage);
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(Kind.FileStorage, account1.Data.Kind);
            Assert.AreEqual(SkuName.PremiumLRS, account1.Data.Sku.Name);
            //this storage account should only have endpoints on file
            Assert.IsNull(account1.Data.PrimaryEndpoints.Blob);
            Assert.IsNull(account1.Data.PrimaryEndpoints.Dfs);
            Assert.NotNull(account1.Data.PrimaryEndpoints.File);
            Assert.IsNull(account1.Data.PrimaryEndpoints.Table);
            Assert.IsNull(account1.Data.PrimaryEndpoints.Queue);
        }
        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithEncrpytion()
        {
            //create storage account with encryption settings
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
            {
                Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
            };
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;
            VerifyAccountProperties(account, true);

            //verify encryption settings
            Assert.NotNull(account.Data.Encryption);
            Assert.NotNull(account.Data.Encryption.Services.Blob);
            Assert.True(account.Data.Encryption.Services.Blob.Enabled);
            Assert.NotNull(account.Data.Encryption.Services.Blob.LastEnabledTime);
            Assert.NotNull(account.Data.Encryption.Services.File);
            Assert.NotNull(account.Data.Encryption.Services.File.Enabled);
            Assert.NotNull(account.Data.Encryption.Services.File.LastEnabledTime);
            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.Enabled.HasValue)
                {
                    Assert.False(account.Data.Encryption.Services.Table.LastEnabledTime.HasValue);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.Enabled.HasValue)
                {
                    Assert.False(account.Data.Encryption.Services.Queue.LastEnabledTime.HasValue);
                }
            }
        }
        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithAccessTier()
        {
            //create storage account with accesstier hot
            string accountName1 = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind: Kind.BlobStorage);
            parameters.AccessTier = AccessTier.Hot;
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName1, parameters)).Value;

            //validate
            VerifyAccountProperties(account, false);
            Assert.AreEqual(AccessTier.Hot, account.Data.AccessTier);
            Assert.AreEqual(Kind.BlobStorage, account.Data.Kind);

            //create storage account with accesstier cool
            string accountName2 = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            parameters.AccessTier = AccessTier.Cool;
            account = (await storageAccountContainer.CreateOrUpdateAsync(accountName2, parameters)).Value;

            //validate
            VerifyAccountProperties(account, false);
            Assert.AreEqual(AccessTier.Cool, account.Data.AccessTier);
            Assert.AreEqual(Kind.BlobStorage, account.Data.Kind);
        }
        [Test]
        [RecordedTest]
        public async Task GetStorageAccountLastSyncTime()
        {
            //create storage account
            string accountName1 = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            Sku sku = new Sku(SkuName.StandardRagrs);
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(sku: sku, kind: Kind.StorageV2);
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName1, parameters)).Value;
            Assert.AreEqual(SkuName.StandardRagrs, account.Data.Sku.Name);
            Assert.Null(account.Data.GeoReplicationStats);

            //expand
            account = await account.GetAsync(StorageAccountExpand.GeoReplicationStats);
            Assert.NotNull(account.Data.GeoReplicationStats);
            Assert.NotNull(account.Data.GeoReplicationStats.Status);
            Assert.NotNull(account.Data.GeoReplicationStats.LastSyncTime);
            Assert.NotNull(account.Data.GeoReplicationStats.CanFailover);
        }
        [Test]
        [RecordedTest]
        public async Task StorageAccountRevokeUserDelegationKeys()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            //revoke user delegation keys
            await account.RevokeUserDelegationKeysAsync();
        }
        [Test]
        [RecordedTest]
        public async Task ListStorageAccountAvailableLocations()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            //get available locations
            IEnumerable<Location> locationList =await account.GetAvailableLocationsAsync();
            Assert.NotNull(locationList);
        }
        [Test]
        [RecordedTest]
        public async Task ListStorageAccountSASWithDefaultProperties()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            // Test for default values of sas credentials.
            AccountSasParameters accountSasParameters = new AccountSasParameters(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpiryTime: Recording.UtcNow.AddHours(1));
            Response<ListAccountSasResponse> result =await account.GetAccountSASAsync(accountSasParameters);
            AccountSasParameters resultCredentials = ParseAccountSASToken(result.Value.AccountSasToken);

            Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
            Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
            Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
            Assert.NotNull(accountSasParameters.SharedAccessExpiryTime);
        }
        [Test]
        [RecordedTest]
        public async Task ListStorageAccountSAS()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            AccountSasParameters accountSasParameters = new AccountSasParameters(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpiryTime: Recording.UtcNow.AddHours(1))
            {
                Protocols = HttpProtocol.HttpsHttp,
                SharedAccessStartTime = Recording.UtcNow,
                KeyToSign = "key1"
            };
            Response<ListAccountSasResponse> result = await account.GetAccountSASAsync(accountSasParameters);
            AccountSasParameters resultCredentials = ParseAccountSASToken(result.Value.AccountSasToken);

            Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
            Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
            Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
            Assert.AreEqual(accountSasParameters.Protocols, resultCredentials.Protocols);
            Assert.NotNull(accountSasParameters.SharedAccessStartTime);
            Assert.NotNull(accountSasParameters.SharedAccessExpiryTime);
        }
        [Test]
        [RecordedTest]
        public async Task ListServiceSASWithDefaultProperties()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            string canonicalizedResourceParameter = "/blob/" + accountName + "/music";
            ServiceSasParameters serviceSasParameters = new ServiceSasParameters(canonicalizedResource: canonicalizedResourceParameter)
            {
                Resource = "c",
                Permissions = "rl",
                SharedAccessExpiryTime = Recording.UtcNow.AddHours(1),
            };
            Response<ListServiceSasResponse> result = await account.GetServiceSASAsync(serviceSasParameters);
            ServiceSasParameters resultCredentials = ParseServiceSASToken(result.Value.ServiceSasToken, canonicalizedResourceParameter);
            Assert.AreEqual(serviceSasParameters.Resource, resultCredentials.Resource);
            Assert.AreEqual(serviceSasParameters.Permissions, resultCredentials.Permissions);
            Assert.NotNull(serviceSasParameters.SharedAccessExpiryTime);
        }
        [Test]
        [RecordedTest]
        public async Task ListServiceSAS()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            string canonicalizedResourceParameter = "/blob/" + accountName + "/music";
            ServiceSasParameters serviceSasParameters = new ServiceSasParameters(canonicalizedResource: canonicalizedResourceParameter)
            {
                Resource = "c",
                Permissions = "rdwlacup",
                Protocols = HttpProtocol.HttpsHttp,
                SharedAccessStartTime = Recording.UtcNow,
                SharedAccessExpiryTime = Recording.UtcNow.AddHours(1),
                KeyToSign = "key1"
            };

            Response<ListServiceSasResponse> result = await account.GetServiceSASAsync(serviceSasParameters);
            ServiceSasParameters resultCredentials = ParseServiceSASToken(result.Value.ServiceSasToken, canonicalizedResourceParameter);
            Assert.AreEqual(serviceSasParameters.Resource, resultCredentials.Resource);
            Assert.AreEqual(serviceSasParameters.Permissions, resultCredentials.Permissions);
            Assert.AreEqual(serviceSasParameters.Protocols, resultCredentials.Protocols);
            Assert.NotNull(serviceSasParameters.SharedAccessStartTime);
            Assert.NotNull(serviceSasParameters.SharedAccessExpiryTime);
        }
        [Test]
        [RecordedTest]
        public async Task AddTag()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            //add tag to this storage account
            account=await account.AddTagAsync("key", "value");

            //verify the tag is added successfully
            Assert.AreEqual(account.Data.Tags.Count, 1);
        }
        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithEnableNfsV3()
        {
            //create storage account
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters(kind:Kind.StorageV2);
            parameters.EnableNfsV3 = false;
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account, false);
            Assert.NotNull(account.Data.PrimaryEndpoints.Web);
            Assert.AreEqual(Kind.StorageV2, account.Data.Kind);
            Assert.False(account.Data.EnableNfsV3);
        }
        [Test]
        [RecordedTest]
        public async Task GetDeletedAccounts()
        {
            //get all deleted accounts
            List<DeletedAccount> deletedAccounts =await DefaultSubscription.GetDeletedAccountsAsync().ToEnumerableAsync();
            Assert.NotNull(deletedAccounts);
        }
    }
}
