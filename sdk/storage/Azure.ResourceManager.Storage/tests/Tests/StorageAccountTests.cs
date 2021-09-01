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
using Azure.ResourceManager.Resources.Models;
using Sku = Azure.ResourceManager.Storage.Models.Sku;
namespace Azure.ResourceManager.Storage.Tests.Tests
{
<<<<<<< HEAD
    public class StorageAccountTests : StorageTestBase
    {
        private ResourceGroup _resourceGroup;
        public StorageAccountTests(bool isAsync) : base(isAsync)
=======
    public class StorageAccountTests : StorageTestsManagementClientBase
    {
        public StorageAccountTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
>>>>>>> upstream/main
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
            //create storage account and get keys
            string accountName = Recording.GenerateAssetName("storage");
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountContainer storageAccountContainer = _resourceGroup.GetStorageAccounts();
            StorageAccount account1 = (await storageAccountContainer.CreateOrUpdateAsync(accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(account1, true);
<<<<<<< HEAD
            StorageAccountListKeysResult keys = await account1.GetKeysAsync();
=======

            StorageAccount account2 = accountlists.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.Name, accountName2));
            VerifyAccountProperties(account2, true);
        }

        [RecordedTest]
        [Ignore("Records keys")]
        public async Task StorageAccountListKeysTest()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();

            // Create storage account
            string accountName = await CreateStorageAccount(AccountsClient, rgname, Recording);

            // List keys
            Response<StorageAccountListKeysResult> keys = await AccountsClient.ListKeysAsync(rgname, accountName);
            Assert.NotNull(keys);

            // Validate Key1
            StorageAccountKey key1 = keys.Value.Keys.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key1"));
            Assert.NotNull(key1);
            Assert.AreEqual(KeyPermission.Full, key1.Permissions);
            Assert.NotNull(key1.Value);

            // Validate Key2
            StorageAccountKey key2 = keys.Value.Keys.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
            Assert.NotNull(key2);
            Assert.AreEqual(KeyPermission.Full, key2.Permissions);
            Assert.NotNull(key2.Value);
        }

        [RecordedTest]
        public async Task StorageAccountRegenerateKeyTest()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();

            // Create storage account
            string accountName = await CreateStorageAccount(AccountsClient, rgname, Recording);

            // List keys
            Response<StorageAccountListKeysResult> keys = await AccountsClient.ListKeysAsync(rgname, accountName);
>>>>>>> upstream/main
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
<<<<<<< HEAD
            StorageAccount account = (await storageAccountContainer.CreateOrUpdateAsync(accountName, parameters)).Value;
=======
            parameters.EnableHttpsTrafficOnly = true;
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
            VerifyAccountProperties(account, false);
            Assert.True(account.EnableHttpsTrafficOnly);

            // Create storage account with cool
            parameters.EnableHttpsTrafficOnly = false;
            account = await _CreateStorageAccountAsync(rgname, accountName1, parameters);
            VerifyAccountProperties(account, false);
            Assert.False(account.EnableHttpsTrafficOnly);
        }

        [RecordedTest]
        [Ignore("Track2: Need KeyVaultManagementClient")]
        public void StorageAccountCMKTest()
        {
            //var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            //using (MockContext context = MockContext.Start(this.GetType()))
            //{
            //    var resourcesClient = GetResourceManagementClient(context, handler);
            //    var storageMgmtClient = GetStorageManagementClient(context, handler);
            //    var keyVaultMgmtClient = GetKeyVaultManagementClient(context, handler);
            //    var keyVaultClient = CreateKeyVaultClient();

            //    string accountName = TestUtilities.GenerateName("sto");
            //    var rgname = CreateResourceGroup(resourcesClient);
            //    string vaultName = TestUtilities.GenerateName("keyvault");
            //    string keyName = TestUtilities.GenerateName("keyvaultkey");

            //    var parameters = GetDefaultStorageAccountParameters();
            //    parameters.Location = "centraluseuap";
            //    parameters.Identity = new Identity { };
            //    var account = storageMgmtClient.StorageAccounts.Create(rgname, accountName, parameters);

            //    VerifyAccountProperties(account, false);
            //    Assert.NotNull(account.Identity);

            //    var accessPolicies = new List<Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry>();
            //    accessPolicies.Add(new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry
            //    {
            //        TenantId = System.Guid.Parse(account.Identity.TenantId),
            //        ObjectId = account.Identity.PrincipalId,
            //        Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions(new List<string> { "wrapkey", "unwrapkey" })
            //    });

            //    string servicePrincipalObjectId = GetServicePrincipalObjectId();
            //    accessPolicies.Add(new Microsoft.Azure.Management.KeyVault.Models.AccessPolicyEntry
            //    {
            //        TenantId = System.Guid.Parse(account.Identity.TenantId),
            //        ObjectId = servicePrincipalObjectId,
            //        Permissions = new Microsoft.Azure.Management.KeyVault.Models.Permissions(new List<string> { "all" })
            //    });

            //    var keyVault = keyVaultMgmtClient.Vaults.CreateOrUpdate(rgname, vaultName, new Microsoft.Azure.Management.KeyVault.Models.VaultCreateOrUpdateParameters
            //    {
            //        Location = account.Location,
            //        Properties = new Microsoft.Azure.Management.KeyVault.Models.VaultProperties
            //        {
            //            TenantId = System.Guid.Parse(account.Identity.TenantId),
            //            AccessPolicies = accessPolicies,
            //            Sku = new Microsoft.Azure.Management.KeyVault.Models.Sku(Microsoft.Azure.Management.KeyVault.Models.SkuName.Standard),
            //            EnabledForDiskEncryption = false,
            //            EnabledForDeployment = false,
            //            EnabledForTemplateDeployment = false
            //        }
            //    });

            //    var keyVaultKey = keyVaultClient.CreateKeyAsync(keyVault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa, 2048,
            //        JsonWebKeyOperation.AllOperations, new Microsoft.Azure.KeyVault.Models.KeyAttributes()).GetAwaiter().GetResult();

            //    // Enable encryption.
            //    var updateParameters = new StorageAccountUpdateParameters
            //    {
            //        Encryption = new Encryption
            //        {
            //            Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
            //            KeySource = "Microsoft.Keyvault",
            //            KeyVaultProperties =
            //                new KeyVaultProperties
            //                {
            //                    KeyName = keyVaultKey.KeyIdentifier.Name,
            //                    KeyVaultUri = keyVault.Properties.VaultUri,
            //                    KeyVersion = keyVaultKey.KeyIdentifier.Version
            //                }
            //        }
            //    };

            //    account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
            //    VerifyAccountProperties(account, false);
            //    Assert.NotNull(account.Encryption);
            //    Assert.True(account.Encryption.Services.Blob.Enabled);
            //    Assert.True(account.Encryption.Services.File.Enabled);
            //    Assert.Equal("Microsoft.Keyvault", account.Encryption.KeySource);

            //    // Disable Encryption.
            //    updateParameters = new StorageAccountUpdateParameters
            //    {
            //        Encryption = new Encryption
            //        {
            //            Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
            //            KeySource = "Microsoft.Storage"
            //        }
            //    };
            //    account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
            //    VerifyAccountProperties(account, false);
            //    Assert.NotNull(account.Encryption);
            //    Assert.True(account.Encryption.Services.Blob.Enabled);
            //    Assert.True(account.Encryption.Services.File.Enabled);
            //    Assert.Equal("Microsoft.Storage", account.Encryption.KeySource);

            //    updateParameters = new StorageAccountUpdateParameters
            //    {
            //        Encryption = new Encryption
            //        {
            //            Services = new EncryptionServices { Blob = new EncryptionService { Enabled = false }, File = new EncryptionService { Enabled = false } },
            //            KeySource = KeySource.MicrosoftStorage
            //        }
            //    };
            //    account = storageMgmtClient.StorageAccounts.Update(rgname, accountName, updateParameters);
            //    VerifyAccountProperties(account, false);
            //    Assert.Null(account.Encryption);
            //}
        }

        [RecordedTest]
        [Ignore("Track2: The constructor of OperationDisplay is internal")]
        public void StorageAccountOperationsTest()
        {
            //var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            //using (MockContext context = MockContext.Start(this.GetType()))
            //{
            //    var resourcesClient = GetResourceManagementClient(context, handler);
            //    var storageMgmtClient = GetStorageManagementClient(context, handler);
            //    var keyVaultMgmtClient = GetKeyVaultManagementClient(context, handler);

            //    // Create storage account with hot
            //    string accountName = TestUtilities.GenerateName("sto");
            //    var rgname = CreateResourceGroup(resourcesClient);

            //    var ops = storageMgmtClient.Operations.List();
            //    var op1 = new Operation
            //    {
            //        Name = "Microsoft.Storage/storageAccounts/write",
            //        Display = new OperationDisplay
            //        {
            //            Provider = "Microsoft Storage",
            //            Resource = "Storage Accounts",
            //            Operation = "Create/Update Storage Account"
            //        }
            //    };
            //    var op2 = new Operation
            //    {
            //        Name = "Microsoft.Storage/storageAccounts/delete",
            //        Display = new OperationDisplay
            //        {
            //            Provider = "Microsoft Storage",
            //            Resource = "Storage Accounts",
            //            Operation = "Delete Storage Account"
            //        }
            //    };
            //    bool exists1 = false;
            //    bool exists2 = false;
            //    Assert.NotNull(ops);
            //    Assert.NotNull(ops.GetEnumerator());
            //    var operation = ops.GetEnumerator();

            //    while (operation.MoveNext())
            //    {
            //        if (operation.Current.ToString().Equals(op1.ToString()))
            //        {
            //            exists1 = true;
            //        }
            //        if (operation.Current.ToString().Equals(op2.ToString()))
            //        {
            //            exists2 = true;
            //        }
            //    }
            //    Assert.True(exists1);
            //    Assert.True(exists2);
            //}
        }

        [RecordedTest]
        public async Task StorageAccountVnetACLTest()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account with Vnet
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();
            parameters.NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
            {
                Bypass = @"Logging,AzureServices",
                IpRules = { new IPRule(iPAddressOrRange: "23.45.67.90") }
            };
            await _CreateStorageAccountAsync(rgname, accountName, parameters);

            StorageAccount account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);

            // Verify the vnet rule properties.
            Assert.NotNull(account.NetworkRuleSet);
            Assert.AreEqual(@"Logging, AzureServices", account.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Deny, account.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(account.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(account.NetworkRuleSet.IpRules);
            Assert.IsNotEmpty(account.NetworkRuleSet.IpRules);
            Assert.AreEqual("23.45.67.90", account.NetworkRuleSet.IpRules[0].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), account.NetworkRuleSet.IpRules[0].Action);

            // Update Vnet
            StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters
            {
                NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
                {
                    Bypass = @"Logging, Metrics",
                    IpRules ={
                            new IPRule(iPAddressOrRange:"23.45.67.91") { Action = DefaultAction.Allow.ToString() },
                            new IPRule(iPAddressOrRange:"23.45.67.92")
                        },
                }
            };
            await UpdateStorageAccountAsync(rgname, accountName, updateParameters);
            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);

            Assert.NotNull(account.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", account.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Deny, account.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(account.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(account.NetworkRuleSet.IpRules);
            Assert.IsNotEmpty(account.NetworkRuleSet.IpRules);
            Assert.AreEqual("23.45.67.91", account.NetworkRuleSet.IpRules[0].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), account.NetworkRuleSet.IpRules[0].Action);
            Assert.AreEqual("23.45.67.92", account.NetworkRuleSet.IpRules[1].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), account.NetworkRuleSet.IpRules[1].Action);

            // Delete vnet.
            updateParameters = new StorageAccountUpdateParameters
            {
                NetworkRuleSet = new NetworkRuleSet(DefaultAction.Allow)
            };
            await UpdateStorageAccountAsync(rgname, accountName, updateParameters);
            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);

            Assert.NotNull(account.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", account.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Allow, account.NetworkRuleSet.DefaultAction);
        }

        [RecordedTest]
        [Ignore("Remove after storage refresh")]
        public void StorageSKUListTest()
        {
            AsyncPageable<SkuInformation> skulist = SkusClient.ListAsync();
            Assert.NotNull(skulist);
            Task<List<SkuInformation>> skuListTask = skulist.ToEnumerableAsync();
            Assert.AreEqual(@"storageAccounts", skuListTask.Result.ElementAt(0).ResourceType);
            Assert.NotNull(skuListTask.Result.ElementAt(0).Name);
            Assert.True(skuListTask.Result.ElementAt(0).Name.GetType() == SkuName.PremiumLRS.GetType());
            Assert.True(skuListTask.Result.ElementAt(0).Name.Equals(SkuName.PremiumLRS)
                || skuListTask.Result.ElementAt(0).Name.Equals(SkuName.StandardGRS)
                || skuListTask.Result.ElementAt(0).Name.Equals(SkuName.StandardLRS)
                || skuListTask.Result.ElementAt(0).Name.Equals(SkuName.StandardRagrs)
                || skuListTask.Result.ElementAt(0).Name.Equals(SkuName.StandardZRS));
            Assert.NotNull(skuListTask.Result.ElementAt(0).Kind);
            Assert.True(skuListTask.Result.ElementAt(0).Kind.Equals(Kind.BlobStorage) || skuListTask.Result.ElementAt(0).Kind.Equals(Kind.Storage) || skuListTask.Result.ElementAt(0).Kind.Equals(Kind.StorageV2));
        }

        [RecordedTest]
        public async Task StorageAccountCreateWithStorageV2()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account with StorageV2
            Sku sku = new Sku(SkuName.StandardGRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: DefaultLocation);
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
            VerifyAccountProperties(account, false);
            Assert.NotNull(account.PrimaryEndpoints.Web);
            Assert.AreEqual(Kind.StorageV2, account.Kind);
        }

        [RecordedTest]
        public async Task StorageAccountUpdateKindStorageV2()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();

            // Create storage account
            string accountName = await CreateStorageAccount(AccountsClient, rgname, Recording);

            // Update storage account type
            StorageAccountUpdateParameters parameters = new StorageAccountUpdateParameters
            {
                Kind = Kind.StorageV2,
                EnableHttpsTrafficOnly = true
            };
            StorageAccount account = await UpdateStorageAccountAsync(rgname, accountName, parameters);
            Assert.AreEqual(Kind.StorageV2, account.Kind);
            Assert.True(account.EnableHttpsTrafficOnly);
            Assert.NotNull(account.PrimaryEndpoints.Web);

            // Validate
            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);
            Assert.AreEqual(Kind.StorageV2, account.Kind);
            Assert.True(account.EnableHttpsTrafficOnly);
            Assert.NotNull(account.PrimaryEndpoints.Web);
        }

        [RecordedTest]
        public async Task StorageAccountSetGetDeleteManagementPolicy()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardGRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "westus");
            await _CreateStorageAccountAsync(rgname, accountName, parameters);

            List<ManagementPolicyRule> rules = new List<ManagementPolicyRule>();
            ManagementPolicyAction Actions = new ManagementPolicyAction()
            {
                BaseBlob = new ManagementPolicyBaseBlob()
                {
                    Delete = new DateAfterModification(300),
                    TierToArchive = new DateAfterModification(90),
                    TierToCool = new DateAfterModification(1000),
                },
                Snapshot = new ManagementPolicySnapShot()
                {
                    Delete = new DateAfterCreation(100)
                }
            };
            ManagementPolicyDefinition Definition = new ManagementPolicyDefinition(Actions)
            {
                Filters = new ManagementPolicyFilter(new List<string>() { "blockBlob" })
                {
                    PrefixMatch = { "olcmtestcontainer", "testblob" }
                }
            };
            ManagementPolicyRule rule1 = new ManagementPolicyRule("olcmtest", RuleType.Lifecycle, Definition)
            {
                Enabled = true
            };
            rules.Add(rule1);

            ManagementPolicyAction Actions2 = new ManagementPolicyAction()
            {
                BaseBlob = new ManagementPolicyBaseBlob()
                {
                    Delete = new DateAfterModification(1000),
                },
            };
            ManagementPolicyDefinition Definition2 = new ManagementPolicyDefinition(Actions2)
            {
                Filters = new ManagementPolicyFilter(new List<string>() { "blockBlob" })
            };
            ManagementPolicyRule rule2 = new ManagementPolicyRule("olcmtest2", RuleType.Lifecycle, Definition2)
            {
                Enabled = false
            };
            rules.Add(rule2);

            ManagementPolicyAction Actions3 = new ManagementPolicyAction()
            {
                Snapshot = new ManagementPolicySnapShot()
                {
                    Delete = new DateAfterCreation(200)
                }
            };
            ManagementPolicyDefinition Definition3 = new ManagementPolicyDefinition(Actions3)
            {
                Filters = new ManagementPolicyFilter(new List<string>() { "blockBlob" })
            };
            ManagementPolicyRule rule3 = new ManagementPolicyRule("olcmtest3", RuleType.Lifecycle, Definition3);
            rules.Add(rule3);

            //Set Management Policies
            ManagementPolicySchema policyToSet = new ManagementPolicySchema(rules);
            ManagementPolicy managementPolicy = new ManagementPolicy()
            {
                Policy = policyToSet
            };
            Response<ManagementPolicy> policy = await ManagementPoliciesClient.CreateOrUpdateAsync(rgname, accountName, ManagementPolicyName.Default, managementPolicy);
            CompareStorageAccountManagementPolicyProperty(policyToSet, policy.Value.Policy);

            //Get Management Policies
            policy = await ManagementPoliciesClient.GetAsync(rgname, accountName, ManagementPolicyName.Default);
            CompareStorageAccountManagementPolicyProperty(policyToSet, policy.Value.Policy);

            //Delete Management Policies, and check policy not exist
            await ManagementPoliciesClient.DeleteAsync(rgname, accountName, ManagementPolicyName.Default);
            bool dataPolicyExist = true;
            try
            {
                policy = await ManagementPoliciesClient.GetAsync(rgname, accountName, ManagementPolicyName.Default);
            }
            catch (RequestFailedException cloudException)
            {
                Assert.AreEqual((int)HttpStatusCode.NotFound, cloudException.Status);
                dataPolicyExist = false;
            }
            Assert.False(dataPolicyExist);

            //Delete not exist Management Policies will not fail
            await ManagementPoliciesClient.DeleteAsync(rgname, accountName, ManagementPolicyName.Default);
        }

        private static void CompareStorageAccountManagementPolicyProperty(ManagementPolicySchema policy1, ManagementPolicySchema policy2)
        {
            Assert.AreEqual(policy1.Rules.Count, policy2.Rules.Count);
            foreach (ManagementPolicyRule rule1 in policy1.Rules)
            {
                bool ruleFound = false;
                foreach (ManagementPolicyRule rule2 in policy2.Rules)
                {
                    if (rule1.Name == rule2.Name)
                    {
                        ruleFound = true;
                        Assert.AreEqual(rule1.Enabled is null ? true : rule1.Enabled, rule2.Enabled);
                        if (rule1.Definition.Filters != null || rule2.Definition.Filters != null)
                        {
                            Assert.AreEqual(rule1.Definition.Filters.BlobTypes, rule2.Definition.Filters.BlobTypes);
                            Assert.AreEqual(rule1.Definition.Filters.PrefixMatch, rule2.Definition.Filters.PrefixMatch);
                        }
                        if (rule1.Definition.Actions.BaseBlob != null || rule2.Definition.Actions.BaseBlob != null)
                        {
                            CompareDateAfterModification(rule1.Definition.Actions.BaseBlob.TierToCool, rule2.Definition.Actions.BaseBlob.TierToCool);
                            CompareDateAfterModification(rule1.Definition.Actions.BaseBlob.TierToArchive, rule2.Definition.Actions.BaseBlob.TierToArchive);
                            CompareDateAfterModification(rule1.Definition.Actions.BaseBlob.Delete, rule2.Definition.Actions.BaseBlob.Delete);
                        }

                        if (rule1.Definition.Actions.Snapshot != null || rule2.Definition.Actions.Snapshot != null)
                        {
                            CompareDateAfterCreation(rule1.Definition.Actions.Snapshot.Delete, rule1.Definition.Actions.Snapshot.Delete);
                        }
                        break;
                    }
                }
                Assert.True(ruleFound, string.Format("The set rule {0} should be found in the output.", rule1.Name));
            }
        }

        private static void CompareDateAfterModification(DateAfterModification date1, DateAfterModification date2)
        {
            if ((date1 is null) && (date2 is null))
            {
                return;
            }
            Assert.AreEqual(date1.DaysAfterModificationGreaterThan, date2.DaysAfterModificationGreaterThan);
        }
>>>>>>> upstream/main

            //add tag to this storage account
            account=await account.AddTagAsync("key", "value");

<<<<<<< HEAD
            //verify the tag is added successfully
            Assert.AreEqual(account.Data.Tags.Count, 1);
=======
            // Create storage account with StorageV2
            Sku sku = new Sku(SkuName.PremiumLRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.FileStorage, location: "eastus");
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
            VerifyAccountProperties(account, false);
            Assert.AreEqual(Kind.FileStorage, account.Kind);
            Assert.AreEqual(SkuName.PremiumLRS, account.Sku.Name);
>>>>>>> upstream/main
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

<<<<<<< HEAD
            //validate
            VerifyAccountProperties(account, false);
            Assert.NotNull(account.Data.PrimaryEndpoints.Web);
            Assert.AreEqual(Kind.StorageV2, account.Data.Kind);
            Assert.False(account.Data.EnableNfsV3);
=======
            // Create storage account with StorageV2
            Sku sku = new Sku(SkuName.PremiumLRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.BlockBlobStorage, location: "eastus");
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
            VerifyAccountProperties(account, false);
            Assert.AreEqual(Kind.BlockBlobStorage, account.Kind);
            Assert.AreEqual(SkuName.PremiumLRS, account.Sku.Name);
        }

        [RecordedTest]
        [Ignore("Track2: Unable to locate active AAD DS for AAD tenant Id *************** associated with the storage account.")]
        public async Task StorageAccountCreateSetGetFileAadIntegration()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardGRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: DefaultLocation)
            {
                AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication(DirectoryServiceOptions.Aadds)
            };
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
            Assert.AreEqual(DirectoryServiceOptions.Aadds, account.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            // Validate
            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);
            Assert.AreEqual(DirectoryServiceOptions.Aadds, account.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            // Update storage account
            StorageAccountUpdateParameters updateParameters = new StorageAccountUpdateParameters
            {
                AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication(DirectoryServiceOptions.None),
                EnableHttpsTrafficOnly = true
            };
            account = await UpdateStorageAccountAsync(rgname, accountName, updateParameters);
            Assert.AreEqual(DirectoryServiceOptions.None, account.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            // Validate
            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);
            Assert.AreEqual(DirectoryServiceOptions.None, account.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);
        }

        [RecordedTest]
        [Ignore("Track2: Last sync time is unavailable for account sto218")]
        public async Task StorageAccountFailOver()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardRagrs);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: DefaultLocation);
            _ = await _CreateStorageAccountAsync(rgname, accountName, parameters);

            // Wait for account ready to failover and Validate
            StorageAccount account;
            string location;
            int i = 100;
            do
            {
                account = await AccountsClient.GetPropertiesAsync(rgname, accountName, expand: StorageAccountExpand.GeoReplicationStats);
                Assert.AreEqual(SkuName.StandardRagrs, account.Sku.Name);
                Assert.Null(account.FailoverInProgress);
                location = account.SecondaryLocation;

                //Don't need sleep when playback, or Unit test will be very slow. Need sleep when record.
                if (Mode == RecordedTestMode.Record)
                {
                    System.Threading.Thread.Sleep(10000);
                }
            } while ((account.GeoReplicationStats.CanFailover != true) && (i-- > 0));

            // Failover storage account
            Operation<Response> failoverWait = await AccountsClient.StartFailoverAsync(rgname, accountName);
            await WaitForCompletionAsync(failoverWait);
            // Validate
            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);
            Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);
            Assert.AreEqual(location, account.PrimaryLocation);
        }

        [RecordedTest]
        public async Task StorageAccountGetLastSyncTime()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardRagrs);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "eastus2");
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
            Assert.AreEqual(SkuName.StandardRagrs, account.Sku.Name);
            Assert.Null(account.GeoReplicationStats);
            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);
            Assert.Null(account.GeoReplicationStats);
            account = await AccountsClient.GetPropertiesAsync(rgname, accountName, StorageAccountExpand.GeoReplicationStats);
            Assert.NotNull(account.GeoReplicationStats);
            Assert.NotNull(account.GeoReplicationStats.Status);
            Assert.NotNull(account.GeoReplicationStats.LastSyncTime);
            Assert.NotNull(account.GeoReplicationStats.CanFailover);
        }

        [RecordedTest]
        public async Task StorageAccountLargeFileSharesStateTest()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "westeurope")
            {
                LargeFileSharesState = LargeFileSharesState.Enabled
            };
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
            Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);
            Assert.AreEqual(LargeFileSharesState.Enabled, account.LargeFileSharesState);

            // Validate
            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);
            Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);
            Assert.AreEqual(LargeFileSharesState.Enabled, account.LargeFileSharesState);
        }

        [RecordedTest]
        public async Task StorageAccountPrivateEndpointTest()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "westeurope")
            {
                LargeFileSharesState = LargeFileSharesState.Enabled
            };
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);
            Assert.AreEqual(SkuName.StandardLRS, account.Sku.Name);

            account = await WaitToGetAccountSuccessfullyAsync(rgname, accountName);
            IReadOnlyList<PrivateEndpointConnection> pes = account.PrivateEndpointConnections;
            foreach (PrivateEndpointConnection pe in pes)
            {
                //Get from account
                await PrivateEndpointConnectionsClient.GetAsync(rgname, accountName, pe.Name);

                // Prepare data for set
                PrivateEndpoint endpoint = new PrivateEndpoint();
                PrivateEndpointConnection connection = new PrivateEndpointConnection()
                {
                    PrivateEndpoint = endpoint,
                    PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionState()
                    {
                        ActionRequired = "None",
                        Description = "123",
                        Status = "Approved"
                    }
                };

                if (pe.PrivateLinkServiceConnectionState.Status != "Rejected")
                {
                    //Set approve
                    connection.PrivateLinkServiceConnectionState.Status = "Approved";
                    PrivateEndpointConnection pe3 = await PrivateEndpointConnectionsClient.PutAsync(rgname, accountName, pe.Name, pe);
                    Assert.AreEqual("Approved", pe3.PrivateLinkServiceConnectionState.Status);

                    //Validate approve by get
                    pe3 = await PrivateEndpointConnectionsClient.GetAsync(rgname, accountName, pe.Name);
                    Assert.AreEqual("Approved", pe3.PrivateLinkServiceConnectionState.Status);
                }

                if (pe.PrivateLinkServiceConnectionState.Status == "Rejected")
                {
                    //Set reject
                    connection.PrivateLinkServiceConnectionState.Status = "Rejected";
                    PrivateEndpointConnection pe4 = await PrivateEndpointConnectionsClient.PutAsync(rgname, accountName, pe.Name, pe);
                    Assert.AreEqual("Rejected", pe4.PrivateLinkServiceConnectionState.Status);

                    //Validate reject by get
                    pe4 = await PrivateEndpointConnectionsClient.GetAsync(rgname, accountName, pe.Name);
                    Assert.AreEqual("Rejected", pe4.PrivateLinkServiceConnectionState.Status);
                }
            }
        }

        [RecordedTest]
        public async Task StorageAccountPrivateLinkTest()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "westus")
            {
                LargeFileSharesState = LargeFileSharesState.Enabled
            };
            await _CreateStorageAccountAsync(rgname, accountName, parameters);

            // Get private link resource
            Response<PrivateLinkResourceListResult> result = await PrivateLinkResourcesClient.ListByStorageAccountAsync(rgname, accountName);

            // Validate
            Assert.True(result.Value.Value.Count > 0);
        }

        [RecordedTest]
        public async Task StorageAccountCreateWithTableQueueEcryptionKeyTypeTest()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "eastus")
            {
                Encryption = new Encryption(keySource: KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices
                    {
                        Queue = new EncryptionService { KeyType = KeyType.Account },
                        Table = new EncryptionService { KeyType = KeyType.Account },
                    }
                }
            };
            StorageAccount account = await _CreateStorageAccountAsync(rgname, accountName, parameters);

            // Verify encryption settings
            Assert.NotNull(account.Encryption);
            Assert.NotNull(account.Encryption.Services.Blob);
            Assert.True(account.Encryption.Services.Blob.Enabled);
            Assert.AreEqual(KeyType.Account, account.Encryption.Services.Blob.KeyType);
            Assert.NotNull(account.Encryption.Services.Blob.LastEnabledTime);

            Assert.NotNull(account.Encryption.Services.File);
            Assert.True(account.Encryption.Services.File.Enabled);
            Assert.AreEqual(KeyType.Account, account.Encryption.Services.Blob.KeyType);
            Assert.NotNull(account.Encryption.Services.File.LastEnabledTime);

            Assert.NotNull(account.Encryption.Services.Queue);
            Assert.AreEqual(KeyType.Account, account.Encryption.Services.Queue.KeyType);
            Assert.True(account.Encryption.Services.Queue.Enabled);
            Assert.NotNull(account.Encryption.Services.Queue.LastEnabledTime);

            Assert.NotNull(account.Encryption.Services.Table);
            Assert.AreEqual(KeyType.Account, account.Encryption.Services.Table.KeyType);
            Assert.True(account.Encryption.Services.Table.Enabled);
            Assert.NotNull(account.Encryption.Services.Table.LastEnabledTime);
        }

        [RecordedTest]
        [Ignore("Remove after storage refresh")]
        public async Task EcryptionScopeTest()
        {
            //Create resource group
            string rgname = await CreateResourceGroupAsync();
            string accountName = Recording.GenerateAssetName("sto");

            // Create storage account
            Sku sku = new Sku(SkuName.StandardLRS);
            StorageAccountCreateParameters parameters = new StorageAccountCreateParameters(sku: sku, kind: Kind.StorageV2, location: "eastus");
            await _CreateStorageAccountAsync(rgname, accountName, parameters);

            //Create EcryptionScope
            EncryptionScope EncryptionScope = new EncryptionScope()
            {
                Source = EncryptionScopeSource.MicrosoftStorage,
                State = EncryptionScopeState.Disabled
            };
            EncryptionScope es = await EncryptionScopesClient.PutAsync(rgname, accountName, "testscope", EncryptionScope);
            Assert.AreEqual("testscope", es.Name);
            Assert.AreEqual(EncryptionScopeState.Disabled, es.State);
            Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, es.Source);

            // Get EcryptionScope
            es = await EncryptionScopesClient.GetAsync(rgname, accountName, "testscope");
            Assert.AreEqual("testscope", es.Name);
            Assert.AreEqual(EncryptionScopeState.Disabled, es.State);
            Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, es.Source);

            // Patch EcryptionScope
            es.State = EncryptionScopeState.Enabled;
            es = await EncryptionScopesClient.PatchAsync(rgname, accountName, "testscope", es);
            Assert.AreEqual("testscope", es.Name);
            Assert.AreEqual(EncryptionScopeState.Enabled, es.State);
            Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, es.Source);

            //List EcryptionScope
            AsyncPageable<EncryptionScope> ess = EncryptionScopesClient.ListAsync(rgname, accountName);
            Task<List<EncryptionScope>> essList = ess.ToEnumerableAsync();
            es = essList.Result.First();
            Assert.AreEqual("testscope", es.Name);
            Assert.AreEqual(EncryptionScopeState.Enabled, es.State);
            Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, es.Source);
        }

        private async Task<string> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(GetResourceManagementClient(), Recording);
        }

        private async Task<StorageAccount> _CreateStorageAccountAsync(string resourceGroupName, string accountName, StorageAccountCreateParameters parameters = null)
        {
            StorageAccountCreateParameters saParameters = parameters ?? GetDefaultStorageAccountParameters();
            Operation<StorageAccount> accountsResponse = await AccountsClient.StartCreateAsync(resourceGroupName, accountName, saParameters);
            StorageAccount account = (await WaitForCompletionAsync(accountsResponse)).Value;
            return account;
        }

        private async Task<Response<StorageAccount>> WaitToGetAccountSuccessfullyAsync(string resourceGroupName, string accountName)
        {
            return await AccountsClient.GetPropertiesAsync(resourceGroupName, accountName);
        }

        private async Task<Response<StorageAccount>> UpdateStorageAccountAsync(string resourceGroupName, string accountName, StorageAccountUpdateParameters parameters)
        {
            return await AccountsClient.UpdateAsync(resourceGroupName, accountName, parameters);
        }

        private async Task<Response> DeleteStorageAccountAsync(string resourceGroupName, string accountName)
        {
            return await AccountsClient.DeleteAsync(resourceGroupName, accountName);
>>>>>>> upstream/main
        }
    }
}
