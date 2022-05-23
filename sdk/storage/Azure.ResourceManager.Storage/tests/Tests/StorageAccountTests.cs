// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageAccountTests : StorageTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private const string namePrefix = "teststoragemgmt";
        public StorageAccountTests(bool isAsync) : base(isAsync)
        {
        }

        [TearDown]
        public async Task ClearStorageAccounts()
        {
            //remove all storage accounts under current resource group
            if (_resourceGroup != null)
            {
                StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
                List<StorageAccountResource> storageAccountList = await storageAccountCollection.GetAllAsync().ToEnumerableAsync();
                foreach (StorageAccountResource account in storageAccountList)
                {
                    await account.DeleteAsync(WaitUntil.Completed);
                }
                _resourceGroup = null;
            }
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountGetOperations()
        {
            ArmRestApiCollection operationCollection = DefaultSubscription.GetArmRestApis("Microsoft.Storage");
            List<ArmRestApi> apiList = await operationCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsTrue(apiList.Count() > 1);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountOperations()
        {
            ArmRestApiCollection operationCollection = DefaultSubscription.GetArmRestApis("Microsoft.Storage");
            List<ArmRestApi> apiList = await operationCollection.GetAllAsync().ToEnumerableAsync();
            bool exist1 = false;
            bool exist2 = false;
            foreach (ArmRestApi restApi in apiList)
            {
                if (CheckRestApi(restApi, "Microsoft.Storage/storageAccounts/write", "Microsoft Storage", "Storage Accounts", "Create/Update Storage Account"))
                {
                    exist1 = true;
                }
                if (CheckRestApi(restApi, "Microsoft.Storage/storageAccounts/delete", "Microsoft Storage", "Storage Accounts", "Delete Storage Account"))
                {
                    exist2 = true;
                }
            }
            Assert.IsTrue(exist1);
            Assert.IsTrue(exist2);
        }

        public bool CheckRestApi(ArmRestApi restApi, string name, string provider, string resource, string operation)
        {
            if (restApi.Name != name)
            {
                return false;
            }
            if (restApi.Operation != operation)
            {
                return false;
            }
            if (restApi.Provider != provider)
            {
                return false;
            }
            if (restApi.Resource != resource)
            {
                return false;
            }
            return true;
        }

        [Test]
        [RecordedTest]
        public async Task ListSku()
        {
            List<StorageSkuInformation> skulist = await DefaultSubscription.GetSkusAsync().ToEnumerableAsync();
            Assert.NotNull(skulist);
            Assert.AreEqual(@"storageAccounts", skulist.ElementAt(0).ResourceType);
            Assert.NotNull(skulist.ElementAt(0).Name);
            Assert.True(skulist.ElementAt(0).Name.Equals(StorageSkuName.PremiumLRS)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardGRS)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardLRS)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardRagrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardZRS));
            Assert.NotNull(skulist.ElementAt(0).Kind);
            Assert.True(skulist.ElementAt(0).Kind.Equals(StorageKind.BlobStorage) || skulist.ElementAt(0).Kind.Equals(StorageKind.Storage) || skulist.ElementAt(0).Kind.Equals(StorageKind.StorageV2) || skulist.ElementAt(0).Kind.Equals(StorageKind.BlockBlobStorage));
        }

        [Test]
        [RecordedTest]
        public async Task CreateDeleteStorageAccount()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, true);
            AssertStorageAccountEqual(account1, await account1.GetAsync());

            //validate if created successfully
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            VerifyAccountProperties(account2, true);
            AssertStorageAccountEqual(account1, account2);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await storageAccountCollection.GetAsync(accountName + "1"); });
            Assert.AreEqual(404, exception.Status);
            Assert.IsTrue(await storageAccountCollection.ExistsAsync(accountName));
            Assert.IsFalse(await storageAccountCollection.ExistsAsync(accountName + "1"));

            //delete storage account
            await account1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await storageAccountCollection.ExistsAsync(accountName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await storageAccountCollection.GetAsync(accountName); });
            Assert.AreEqual(404, exception.Status);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStandardAccount()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            //create a LRS storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS)))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.Null(account1.Data.Identity);

            //create a GRS storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardGRS)))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, true);

            //create a RAGRS storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardRagrs)))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);

            //create a ZRS storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardZRS)))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
        }

        [Test]
        [RecordedTest]
        public async Task CreateBlobAccount()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            //create a blob LRS storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage, sku: new StorageSku(StorageSkuName.StandardLRS));
            parameters.AccessTier = AccessTier.Hot;
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);

            //create a blob GRS storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage, sku: new StorageSku(StorageSkuName.StandardGRS));
            parameters.AccessTier = AccessTier.Hot;
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);

            //create a blob RAGRS storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage, sku: new StorageSku(StorageSkuName.StandardRagrs));
            parameters.AccessTier = AccessTier.Hot;
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
        }

        [Test]
        [RecordedTest]
        public async Task CreatePremiumAccount()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            //create a premium LRS storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.PremiumLRS));
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllStorageAccounts()
        {
            //create two storage accounts
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, GetDefaultStorageAccountParameters())).Value;
            StorageAccountResource account2 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, GetDefaultStorageAccountParameters())).Value;

            //validate two storage accounts
            int count = 0;
            StorageAccountResource account3 = null;
            StorageAccountResource account4 = null;
            await foreach (StorageAccountResource account in storageAccountCollection.GetAllAsync())
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
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(account1, true);

            //update sku
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Sku = new StorageSku(StorageSkuName.StandardLRS),
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.Sku.Name, StorageSkuName.StandardLRS);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(account2.Data.Sku.Name, StorageSkuName.StandardLRS);

            //update tags
            parameters.Tags.Clear();
            parameters.Tags.Add("key3", "value3");
            parameters.Tags.Add("key4", "value4");
            parameters.Tags.Add("key5", "value5");
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.Tags.Count, parameters.Tags.Count);

            //validate
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(account2.Data.Tags.Count, parameters.Tags.Count);

            //update encryption
            parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
            {
                Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            //validate
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.NotNull(account2.Data.Encryption);
            Assert.NotNull(account2.Data.Encryption.Services.Blob);
            Assert.True(account2.Data.Encryption.Services.Blob.Enabled);
            Assert.NotNull(account2.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account2.Data.Encryption.Services.File);
            Assert.True(account2.Data.Encryption.Services.File.Enabled);
            Assert.NotNull(account2.Data.Encryption.Services.File.LastEnabledOn);

            //update http traffic only and validate
            parameters = new StorageAccountPatch()
            {
                EnableHttpsTrafficOnly = false
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.EnableHttpsTrafficOnly, false);
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(account2.Data.EnableHttpsTrafficOnly, false);
            parameters = new StorageAccountPatch()
            {
                EnableHttpsTrafficOnly = true
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.EnableHttpsTrafficOnly, true);
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(account2.Data.EnableHttpsTrafficOnly, true);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateStorageAccountWithInvalidCustomDomin()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(account1, true);

            var parameters = new StorageAccountPatch()
            {
                CustomDomain = new CustomDomain("foo.example.com")
                {
                    UseSubDomainName = true
                }
            };
            try
            {
                //should fail
                account1 = await account1.UpdateAsync(parameters);
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(409, ex.Status);
                Assert.AreEqual("StorageDomainNameCouldNotVerify", ex.ErrorCode);
                Assert.True(ex.Message != null && ex.Message.StartsWith("The custom domain " +
                        "name could not be verified. CNAME mapping from foo.example.com to "));
            }
        }

        [Test]
        [RecordedTest]
        public async Task UpdateStorageAccountWithStorageV2()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(account1, true);

            var parameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2,
                EnableHttpsTrafficOnly = true
            };
            account1 = await account1.UpdateAsync(parameters);

            //validate
            account1 = await account1.GetAsync();
            Assert.AreEqual(StorageKind.StorageV2, account1.Data.Kind);
            Assert.IsTrue(account1.Data.EnableHttpsTrafficOnly);
            Assert.NotNull(account1.Data.PrimaryEndpoints.Web);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateStorageAccountWithAllowSharedKeyAccess()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            parameters.AllowSharedKeyAccess = false;
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account1, false);
            Assert.IsFalse(account1.Data.AllowSharedKeyAccess);

            //update
            var parameter = new StorageAccountPatch()
            {
                AllowSharedKeyAccess = true,
                EnableHttpsTrafficOnly = false
            };
            account1 = await account1.UpdateAsync(parameter);

            //validate
            account1 = await account1.GetAsync();
            Assert.IsTrue(account1.Data.AllowSharedKeyAccess);

            //update
            parameter = new StorageAccountPatch()
            {
                AllowSharedKeyAccess = false,
                EnableHttpsTrafficOnly = false
            };
            account1 = await account1.UpdateAsync(parameter);

            //validate
            account1 = await account1.GetAsync();
            Assert.IsFalse(account1.Data.AllowSharedKeyAccess);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateStorageAccountMultipleProperties()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(account1, true);

            //update account type and tags
            var parameters = new StorageAccountPatch()
            {
                Sku = new StorageSku(StorageSkuName.StandardLRS)
            };
            parameters.Tags.Add("key3", "value3");
            parameters.Tags.Add("key4", "value4");
            parameters.Tags.Add("key5", "value5");

            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageSkuName.StandardLRS, account1.Data.Sku.Name);
            Assert.AreEqual(parameters.Tags.Count, account1.Data.Tags.Count);

            account1 = await account1.GetAsync();
            Assert.AreEqual(StorageSkuName.StandardLRS, account1.Data.Sku.Name);
            Assert.AreEqual(parameters.Tags.Count, account1.Data.Tags.Count);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateStorageAccountEncryption()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(account1, true);

            //update encryption
            var parameters = new StorageAccountPatch
            {
                Encryption = new Encryption(KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
                }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            // Validate
            account1 = await account1.GetAsync();
            Assert.NotNull(account1.Data.Encryption);
            Assert.NotNull(account1.Data.Encryption.Services.Blob);
            Assert.True(account1.Data.Encryption.Services.Blob.Enabled);
            Assert.NotNull(account1.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account1.Data.Encryption.Services.File);
            Assert.True(account1.Data.Encryption.Services.File.Enabled);
            Assert.NotNull(account1.Data.Encryption.Services.File.LastEnabledOn);

            // 2. Restore storage encryption
            parameters = new StorageAccountPatch
            {
                Encryption = new Encryption(KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
                }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            // Validate
            account1 = await account1.GetAsync();
            Assert.NotNull(account1.Data.Encryption);
            Assert.NotNull(account1.Data.Encryption.Services.Blob);
            Assert.True(account1.Data.Encryption.Services.Blob.Enabled);
            Assert.NotNull(account1.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account1.Data.Encryption.Services.File);
            Assert.True(account1.Data.Encryption.Services.File.Enabled);
            Assert.NotNull(account1.Data.Encryption.Services.File.LastEnabledOn);

            // 3. Remove file encryption service field.
            parameters = new StorageAccountPatch
            {
                Encryption = new Encryption(KeySource.MicrosoftStorage)
                {
                    Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true } }
                }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            // Validate
            account1 = await account1.GetAsync();
            Assert.NotNull(account1.Data.Encryption);
            Assert.NotNull(account1.Data.Encryption.Services.Blob);
            Assert.True(account1.Data.Encryption.Services.Blob.Enabled);
            Assert.NotNull(account1.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account1.Data.Encryption.Services.File);
            Assert.True(account1.Data.Encryption.Services.File.Enabled);
            Assert.NotNull(account1.Data.Encryption.Services.File.LastEnabledOn);
        }

        [Test]
        [RecordedTest]
        public async Task ListWithEncryption()
        {
            //create storage account with encryption
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
            {
                Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
            };
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account1, true);

            List<StorageAccountResource> accounts = await storageAccountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, accounts.Count);
            StorageAccountResource account = accounts[0];
            Assert.NotNull(account.Data.Encryption);
            Assert.NotNull(account.Data.Encryption.Services.Blob);
            Assert.IsTrue(account.Data.Encryption.Services.Blob.Enabled);
            Assert.NotNull(account.Data.Encryption.Services.Blob.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.File);
            Assert.IsTrue(account.Data.Encryption.Services.File.Enabled);
            Assert.NotNull(account.Data.Encryption.Services.File.LastEnabledOn);

            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.Enabled.HasValue)
                {
                    Assert.IsFalse(account.Data.Encryption.Services.Table.LastEnabledOn.HasValue);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.Enabled.HasValue)
                {
                    Assert.IsFalse(account.Data.Encryption.Services.Queue.LastEnabledOn.HasValue);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateLargeFileShareOnStorageAccount()
        {
            //create storage account and enable large share
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageSku sku = new StorageSku(StorageSkuName.StandardLRS);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: sku, kind: StorageKind.StorageV2);
            parameters.LargeFileSharesState = LargeFileSharesState.Enabled;
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account1, false);

            //create file share with share quota 5200, which is allowed in large file shares
            string fileShareName = Recording.GenerateAssetName("testfileshare");
            FileServiceResource fileService = await account1.GetFileService().GetAsync();
            FileShareCollection shareCollection = fileService.GetFileShares();
            FileShareData shareData = new FileShareData();
            shareData.ShareQuota = 5200;
            ArmOperation<FileShareResource> fileShareCreateOperation = await shareCollection.CreateOrUpdateAsync(WaitUntil.Started, fileShareName, shareData);
            FileShareResource share = await fileShareCreateOperation.WaitForCompletionAsync();
            Assert.AreEqual(share.Data.ShareQuota, shareData.ShareQuota);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountRegenerateKey()
        {
            JsonPathSanitizers.Add("$.keys.[*].value");
            //create storage account and get keys
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(account1, true);
            StorageAccountListKeysResult keys = await account1.GetKeysAsync();
            Assert.NotNull(keys);
            StorageAccountKey key2 = keys.Keys.First(
                t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));
            Assert.NotNull(key2);

            //regenerate key and verify the key's change
            StorageAccountRegenerateKeyContent keyParameters = new StorageAccountRegenerateKeyContent("key2");
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
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            parameters.NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
            {
                Bypass = @"Logging, AzureServices",
                IPRules = { new IPRule("23.45.67.89") }
            };
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account1, false);

            //verify network rule
            StorageAccountData accountData = account1.Data;
            Assert.NotNull(accountData.NetworkRuleSet);
            Assert.AreEqual(@"Logging, AzureServices", accountData.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Deny, accountData.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(accountData.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(accountData.NetworkRuleSet.IPRules);
            Assert.IsNotEmpty(accountData.NetworkRuleSet.IPRules);
            Assert.AreEqual("23.45.67.89", accountData.NetworkRuleSet.IPRules[0].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), accountData.NetworkRuleSet.IPRules[0].Action);

            //update network rule
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Deny)
                {
                    Bypass = @"Logging, Metrics",
                    IPRules = { new IPRule("23.45.67.90"),
                        new IPRule("23.45.67.91")
                    }
                }
            };
            StorageAccountResource account2 = await account1.UpdateAsync(updateParameters);

            //verify updated network rule
            accountData = account2.Data;
            Assert.NotNull(accountData.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", accountData.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Deny, accountData.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(accountData.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(accountData.NetworkRuleSet.IPRules);
            Assert.IsNotEmpty(accountData.NetworkRuleSet.IPRules);
            Assert.AreEqual("23.45.67.90", accountData.NetworkRuleSet.IPRules[0].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), accountData.NetworkRuleSet.IPRules[0].Action);
            Assert.AreEqual("23.45.67.91", accountData.NetworkRuleSet.IPRules[1].IPAddressOrRange);
            Assert.AreEqual(DefaultAction.Allow.ToString(), accountData.NetworkRuleSet.IPRules[1].Action);

            //update network rule to allow
            updateParameters = new StorageAccountPatch()
            {
                NetworkRuleSet = new NetworkRuleSet(defaultAction: DefaultAction.Allow)
            };
            StorageAccountResource account3 = await account2.UpdateAsync(updateParameters);

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
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageSku sku = new StorageSku(StorageSkuName.PremiumLRS);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: sku, kind: StorageKind.BlockBlobStorage);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageKind.BlockBlobStorage, account1.Data.Kind);
            Assert.AreEqual(StorageSkuName.PremiumLRS, account1.Data.Sku.Name);
            //this storage account should only have endpoints on blob and dfs
            Assert.NotNull(account1.Data.PrimaryEndpoints.Blob);
            Assert.NotNull(account1.Data.PrimaryEndpoints.Dfs);
            Assert.IsNull(account1.Data.PrimaryEndpoints.File);
            Assert.IsNull(account1.Data.PrimaryEndpoints.Table);
            Assert.IsNull(account1.Data.PrimaryEndpoints.Queue);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithLargeFileSharesState()
        {
            //create storage account with storage v2
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), kind: StorageKind.StorageV2);
            parameters.LargeFileSharesState = LargeFileSharesState.Enabled;
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account1 = await account1.GetAsync();
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(LargeFileSharesState.Enabled, account1.Data.LargeFileSharesState);
            Assert.AreEqual(StorageSkuName.StandardLRS, account1.Data.Sku.Name);
        }

        [Test]
        [RecordedTest]
        public async Task CreateGetStorageAccountDfs()
        {
            //create storage account with storage v2
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            parameters.IsHnsEnabled = true;
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account1, false);
            Assert.NotNull(account1.Data.PrimaryEndpoints.Dfs);
            Assert.IsTrue(account1.Data.IsHnsEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithFileStorage()
        {
            //create storage account with file storage
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageSku sku = new StorageSku(StorageSkuName.PremiumLRS);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: sku, kind: StorageKind.FileStorage);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageKind.FileStorage, account1.Data.Kind);
            Assert.AreEqual(StorageSkuName.PremiumLRS, account1.Data.Sku.Name);
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
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
            {
                Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } }
            };
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account, true);

            //verify encryption settings
            Assert.NotNull(account.Data.Encryption);
            Assert.NotNull(account.Data.Encryption.Services.Blob);
            Assert.True(account.Data.Encryption.Services.Blob.Enabled);
            Assert.NotNull(account.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account.Data.Encryption.Services.File);
            Assert.NotNull(account.Data.Encryption.Services.File.Enabled);
            Assert.NotNull(account.Data.Encryption.Services.File.LastEnabledOn);
            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.Enabled.HasValue)
                {
                    Assert.False(account.Data.Encryption.Services.Table.LastEnabledOn.HasValue);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.Enabled.HasValue)
                {
                    Assert.False(account.Data.Encryption.Services.Queue.LastEnabledOn.HasValue);
                }
            }
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithTableQueueEncrpytion()
        {
            //create storage account with encryption settings
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            parameters.Encryption = new Encryption(KeySource.MicrosoftStorage)
            {
                Services = new EncryptionServices()
                {
                    Queue = new EncryptionService { KeyType = KeyType.Account },
                    Table = new EncryptionService { KeyType = KeyType.Account },
                }
            };
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account, false);

            //verify encryption settings
            Assert.NotNull(account.Data.Encryption);
            Assert.NotNull(account.Data.Encryption.Services.Blob);
            Assert.IsTrue(account.Data.Encryption.Services.Blob.Enabled);
            Assert.AreEqual(KeyType.Account, account.Data.Encryption.Services.Blob.KeyType);
            Assert.NotNull(account.Data.Encryption.Services.Blob.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.File);
            Assert.IsTrue(account.Data.Encryption.Services.File.Enabled);
            Assert.AreEqual(KeyType.Account, account.Data.Encryption.Services.Blob.KeyType);
            Assert.NotNull(account.Data.Encryption.Services.File.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.Queue);
            Assert.AreEqual(KeyType.Account, account.Data.Encryption.Services.Queue.KeyType);
            Assert.IsTrue(account.Data.Encryption.Services.Queue.Enabled);
            Assert.NotNull(account.Data.Encryption.Services.Queue.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.Table);
            Assert.AreEqual(KeyType.Account, account.Data.Encryption.Services.Table.KeyType);
            Assert.IsTrue(account.Data.Encryption.Services.Table.Enabled);
            Assert.NotNull(account.Data.Encryption.Services.Table.LastEnabledOn);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithStorageV2()
        {
            //create storage account with storage v2
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account, false);
            Assert.AreEqual(StorageKind.StorageV2, account.Data.Kind);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithAccessTier()
        {
            //create storage account with accesstier hot
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage);
            parameters.AccessTier = AccessTier.Hot;
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;

            //validate
            VerifyAccountProperties(account, false);
            Assert.AreEqual(AccessTier.Hot, account.Data.AccessTier);
            Assert.AreEqual(StorageKind.BlobStorage, account.Data.Kind);

            //create storage account with accesstier cool
            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            parameters.AccessTier = AccessTier.Cool;
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, parameters)).Value;

            //validate
            VerifyAccountProperties(account, false);
            Assert.AreEqual(AccessTier.Cool, account.Data.AccessTier);
            Assert.AreEqual(StorageKind.BlobStorage, account.Data.Kind);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithHttpsOnly()
        {
            //create storage account with enable https only true
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            parameters.EnableHttpsTrafficOnly = true;
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account = await account.GetAsync();
            VerifyAccountProperties(account, false);
            Assert.IsTrue(account.Data.EnableHttpsTrafficOnly);

            //create storage account with enable https only false
            accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            storageAccountCollection = _resourceGroup.GetStorageAccounts();
            parameters.EnableHttpsTrafficOnly = false;
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account = await account.GetAsync();
            VerifyAccountProperties(account, false);
            Assert.IsFalse(account.Data.EnableHttpsTrafficOnly);
        }

        [Test]
        [RecordedTest]
        [Ignore("Edge zone 'microsoftrrdclab1' not found")]
        public async Task CreateStorageAccountWithExtendedLocation()
        {
            //create storage account with enable https only true
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.PremiumLRS), kind: StorageKind.StorageV2, location: AzureLocation.EastUS2);
            parameters.ExtendedLocation = new Models.ExtendedLocation
            {
                ExtendedLocationType = Storage.Models.ExtendedLocationTypes.EdgeZone,
                Name = "microsoftrrdclab1"
            };
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account = await account.GetAsync();
            VerifyAccountProperties(account, false);
            Assert.NotNull(account.Data.PrimaryEndpoints.Web);
            Assert.AreEqual(StorageKind.StorageV2, account.Data.Kind);
            Assert.AreEqual(ExtendedLocationTypes.EdgeZone, account.Data.ExtendedLocation.ExtendedLocationType);
            Assert.AreEqual("microsoftrrdclab1", account.Data.ExtendedLocation.Name);
        }

        [Test]
        [RecordedTest]
        public async Task CreateUpdateStorageAccountWithMinTlsVersionBlobPublicAccess()
        {
            //create storage account with enable https only true
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            parameters.AllowBlobPublicAccess = false;
            parameters.MinimumTlsVersion = MinimumTlsVersion.TLS11;
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account = await account.GetAsync();
            VerifyAccountProperties(account, false);
            Assert.AreEqual(MinimumTlsVersion.TLS11, account.Data.MinimumTlsVersion);

            //update account
            StorageAccountPatch udpateParameters = new StorageAccountPatch();
            udpateParameters.MinimumTlsVersion = MinimumTlsVersion.TLS12;
            udpateParameters.AllowBlobPublicAccess = true;
            udpateParameters.EnableHttpsTrafficOnly = true;
            account = await account.UpdateAsync(udpateParameters);

            //validate
            account = await account.GetAsync();
            Assert.AreEqual(MinimumTlsVersion.TLS12, account.Data.MinimumTlsVersion);
        }

        [Test]
        [RecordedTest]
        public async Task GetStorageAccountLastSyncTime()
        {
            //create storage account
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageSku sku = new StorageSku(StorageSkuName.StandardRagrs);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: sku, kind: StorageKind.StorageV2);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;
            Assert.AreEqual(StorageSkuName.StandardRagrs, account.Data.Sku.Name);
            Assert.Null(account.Data.GeoReplicationStats);

            //expand
            account = await account.GetAsync(StorageAccountExpand.GeoReplicationStats);
            Assert.NotNull(account.Data.GeoReplicationStats);
            Assert.NotNull(account.Data.GeoReplicationStats.Status);
            Assert.NotNull(account.Data.GeoReplicationStats.LastSyncOn);
            Assert.NotNull(account.Data.GeoReplicationStats.CanFailover);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountRevokeUserDelegationKeys()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //revoke user delegation keys
            await account.RevokeUserDelegationKeysAsync();
        }

        [Test]
        [RecordedTest]
        public async Task ListStorageAccountAvailableLocations()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //get available locations
            IEnumerable<AzureLocation> locationList = (await account.GetAvailableLocationsAsync()).Value;
            Assert.NotNull(locationList);
        }

        [Test]
        [RecordedTest]
        public async Task ListStorageAccountSASWithDefaultProperties()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            // Test for default values of sas credentials.
            AccountSasContent accountSasParameters = new AccountSasContent(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpiryOn: Recording.UtcNow.AddHours(1));
            Response<ListAccountSasResponse> result = await account.GetAccountSasAsync(accountSasParameters);
            AccountSasContent resultCredentials = ParseAccountSASToken(result.Value.AccountSasToken);

            Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
            Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
            Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
            Assert.NotNull(accountSasParameters.SharedAccessExpiryOn);
        }

        [Test]
        [RecordedTest]
        public async Task ListStorageAccountSASWithMissingProperties()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            // Test for default values of sas credentials.
            AccountSasContent accountSasParameters = new AccountSasContent(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpiryOn: Recording.UtcNow.AddHours(1));
            Response<ListAccountSasResponse> result = await account.GetAccountSasAsync(accountSasParameters);
            AccountSasContent resultCredentials = ParseAccountSASToken(result.Value.AccountSasToken);

            Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
            Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
            Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
            Assert.NotNull(accountSasParameters.SharedAccessExpiryOn);
        }

        [Test]
        [RecordedTest]
        public async Task ListStorageAccountSAS()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            AccountSasContent accountSasParameters = new AccountSasContent(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpiryOn: Recording.UtcNow.AddHours(1))
            {
                Protocols = HttpProtocol.HttpsHttp,
                SharedAccessStartOn = Recording.UtcNow,
                KeyToSign = "key1"
            };
            Response<ListAccountSasResponse> result = await account.GetAccountSasAsync(accountSasParameters);
            AccountSasContent resultCredentials = ParseAccountSASToken(result.Value.AccountSasToken);

            Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
            Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
            Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
            Assert.AreEqual(accountSasParameters.Protocols, resultCredentials.Protocols);
            Assert.NotNull(accountSasParameters.SharedAccessStartOn);
            Assert.NotNull(accountSasParameters.SharedAccessExpiryOn);
        }

        [Test]
        [RecordedTest]
        public async Task ListServiceSASWithDefaultProperties()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            string canonicalizedResourceParameter = "/blob/" + accountName + "/music";
            ServiceSasContent serviceSasParameters = new ServiceSasContent(canonicalizedResource: canonicalizedResourceParameter)
            {
                Resource = "c",
                Permissions = "rl",
                SharedAccessExpiryOn = Recording.UtcNow.AddHours(1),
            };
            Response<ListServiceSasResponse> result = await account.GetServiceSasAsync(serviceSasParameters);
            ServiceSasContent resultCredentials = ParseServiceSASToken(result.Value.ServiceSasToken, canonicalizedResourceParameter);
            Assert.AreEqual(serviceSasParameters.Resource, resultCredentials.Resource);
            Assert.AreEqual(serviceSasParameters.Permissions, resultCredentials.Permissions);
            Assert.NotNull(serviceSasParameters.SharedAccessExpiryOn);
        }

        [Test]
        [RecordedTest]
        public async Task ListServiceSASWithMissingProperties()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            string canonicalizedResourceParameter = "/blob/" + accountName + "/music";
            ServiceSasContent serviceSasParameters = new ServiceSasContent(canonicalizedResource: canonicalizedResourceParameter)
            {
                Resource = "c",
                Permissions = "rl"
            };
            try
            {
                //should fail
                Response<ListServiceSasResponse> result = await account.GetServiceSasAsync(serviceSasParameters);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.StartsWith("Values for request parameters are invalid: signedExpiry."));
            }
        }

        [Test]
        [RecordedTest]
        public async Task ListServiceSAS()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            string canonicalizedResourceParameter = "/blob/" + accountName + "/music";
            ServiceSasContent serviceSasParameters = new ServiceSasContent(canonicalizedResource: canonicalizedResourceParameter)
            {
                Resource = "c",
                Permissions = "rdwlacup",
                Protocols = HttpProtocol.HttpsHttp,
                SharedAccessStartOn = Recording.UtcNow,
                SharedAccessExpiryOn = Recording.UtcNow.AddHours(1),
                KeyToSign = "key1"
            };

            Response<ListServiceSasResponse> result = await account.GetServiceSasAsync(serviceSasParameters);
            ServiceSasContent resultCredentials = ParseServiceSASToken(result.Value.ServiceSasToken, canonicalizedResourceParameter);
            Assert.AreEqual(serviceSasParameters.Resource, resultCredentials.Resource);
            Assert.AreEqual(serviceSasParameters.Permissions, resultCredentials.Permissions);
            Assert.AreEqual(serviceSasParameters.Protocols, resultCredentials.Protocols);
            Assert.NotNull(serviceSasParameters.SharedAccessStartOn);
            Assert.NotNull(serviceSasParameters.SharedAccessExpiryOn);
        }

        [Test]
        [RecordedTest]
        public async Task AddRemoveTag()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //add tag to this storage account
            account = await account.AddTagAsync("key", "value");

            //verify the tag is added successfully
            Assert.AreEqual(account.Data.Tags.Count, DefaultTags.Count + 1);

            //remove tag
            account = await account.RemoveTagAsync("key");

            //verify the tag is removed successfully
            Assert.AreEqual(account.Data.Tags.Count, DefaultTags.Count);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithEnableNfsV3()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            parameters.EnableNfsV3 = false;
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account, false);
            Assert.NotNull(account.Data.PrimaryEndpoints.Web);
            Assert.AreEqual(StorageKind.StorageV2, account.Data.Kind);
            Assert.False(account.Data.EnableNfsV3);
        }

        [Test]
        [RecordedTest]
        [Ignore("Looks like a regression, temporarily removed")]
        public async Task GetDeletedAccounts()
        {
            //get all deleted accounts
            await foreach (var _ in DefaultSubscription.GetDeletedAccountsAsync())
            {
                return;
            }
            Assert.Fail($"{nameof(StorageExtensions)}.{nameof(StorageExtensions.GetDeletedAccountsAsync)} has returned an empty collection of DeletedAccount.");
        }

        [Test]
        [RecordedTest]
        public async Task CreateUpdateGetDeleteBlobInventoryPolicy()
        {
            //create resource group and storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            BlobInventoryPolicyCollection blobInventoryPolicyCollection = account.GetBlobInventoryPolicies();

            //create a blob container
            string containerName = Recording.GenerateAssetName("testblob");
            BlobContainerData data = new BlobContainerData();
            BlobServiceResource blobService = await account.GetBlobService().GetAsync();
            BlobContainerCollection blobContainerCollection = blobService.GetBlobContainers();
            BlobContainerResource container = (await blobContainerCollection.CreateOrUpdateAsync(WaitUntil.Completed, containerName, new BlobContainerData())).Value;

            //prepare schema fields
            string[] BlobSchemaField = new string[] {"Name", "Creation-Time", "Last-Modified", "Content-Length", "Content-MD5", "BlobType", "AccessTier", "AccessTierChangeTime",
                     "Snapshot", "VersionId", "IsCurrentVersion", "Metadata", "LastAccessTime"};
            string[] ContainerSchemaField = new string[] { "Name", "Last-Modified", "Metadata", "LeaseStatus", "LeaseState", "LeaseDuration", "PublicAccess", "HasImmutabilityPolicy", "HasLegalHold" };

            List<string> blobSchemaFields1 = new List<string>(BlobSchemaField);
            List<string> blobSchemaFields2 = new List<string>();
            blobSchemaFields2.Add("Name");
            List<string> containerSchemaFields1 = new List<string>(ContainerSchemaField);
            List<string> containerSchemaFields2 = new List<string>();
            containerSchemaFields2.Add("Name");

            // prepare policy objects,the type of policy rule should always be Inventory
            List<BlobInventoryPolicyRule> ruleList = new List<BlobInventoryPolicyRule>();
            BlobInventoryPolicyRule rule1 = new BlobInventoryPolicyRule(true, "rule1", containerName,
                new BlobInventoryPolicyDefinition(
                    filters: new BlobInventoryPolicyFilter(
                        blobTypes: new List<string>(new string[] { "blockBlob" }),
                        prefixMatch: new List<string>(new string[] { "prefix1", "prefix2" }),
                        includeBlobVersions: true,
                        includeSnapshots: true),
                    format: Format.Csv,
                    schedule: Schedule.Weekly,
                    objectType: ObjectType.Blob,
                    schemaFields: blobSchemaFields1));

            BlobInventoryPolicyRule rule2 = new BlobInventoryPolicyRule(true, "rule2", containerName,
                new BlobInventoryPolicyDefinition(
                    format: Format.Csv,
                    schedule: Schedule.Daily,
                    objectType: ObjectType.Container,
                    schemaFields: containerSchemaFields1));

            BlobInventoryPolicyRule rule3 = new BlobInventoryPolicyRule(true, "rule3", containerName,
                new BlobInventoryPolicyDefinition(
                    format: Format.Parquet,
                    schedule: Schedule.Weekly,
                    objectType: ObjectType.Container,
                    schemaFields: containerSchemaFields2));
            ruleList.Add(rule1);
            ruleList.Add(rule2);
            BlobInventoryPolicySchema policy = new BlobInventoryPolicySchema(true, "Inventory", ruleList);
            BlobInventoryPolicyData parameter = new BlobInventoryPolicyData()
            {
                Policy = policy
            };

            //create and get policy, the name of blob inventory policy should always be default
            BlobInventoryPolicyResource blobInventoryPolicy = (await blobInventoryPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, "default", parameter)).Value;
            blobInventoryPolicy = await blobInventoryPolicyCollection.GetAsync("default");
            Assert.AreEqual(blobInventoryPolicy.Data.Policy.Rules.Count, 2);

            //update policy
            ruleList.Add(rule3);
            BlobInventoryPolicySchema policy2 = new BlobInventoryPolicySchema(true, "Inventory", ruleList);
            BlobInventoryPolicyData parameter2 = new BlobInventoryPolicyData()
            {
                Policy = policy2
            };
            blobInventoryPolicy = (await blobInventoryPolicyCollection.CreateOrUpdateAsync(WaitUntil.Completed, "default", parameter2)).Value;
            Assert.AreEqual(blobInventoryPolicy.Data.Policy.Rules.Count, 3);

            //delete policy
            await blobInventoryPolicy.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task SetGetDeleteManagementPolicy()
        {
            //create resource group and storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //Enable LAT
            BlobServiceResource blobService = await account.GetBlobService().GetAsync();
            blobService.Data.LastAccessTimeTrackingPolicy = new LastAccessTimeTrackingPolicy(true);
            _ = await blobService.CreateOrUpdateAsync(WaitUntil.Completed, blobService.Data);

            // create ManagementPolicy to set, the type of policy rule should always be Lifecycle
            List<ManagementPolicyRule> rules = new List<ManagementPolicyRule>();
            ManagementPolicyAction action = new ManagementPolicyAction()
            {
                BaseBlob = new ManagementPolicyBaseBlob()
                {
                    Delete = new DateAfterModification(1000, null)
                }
            };
            ManagementPolicyDefinition definition1 = new ManagementPolicyDefinition(action)
            {
                Filters = new ManagementPolicyFilter(blobTypes: new List<string>() { "blockBlob", "appendBlob" }),
            };
            ManagementPolicyRule rule1 = new ManagementPolicyRule("rule1", "Lifecycle", definition1);
            rules.Add(rule1);

            ManagementPolicyDefinition definition2 = new ManagementPolicyDefinition(action)
            {
                Filters = new ManagementPolicyFilter(blobTypes: new List<string>() { "appendBlob" }),
            };
            ManagementPolicyRule rule2 = new ManagementPolicyRule("rule2", "Lifecycle", definition2);
            rules.Add(rule2);

            ManagementPolicyDefinition definition3 = new ManagementPolicyDefinition(action)
            {
                Filters = new ManagementPolicyFilter(blobTypes: new List<string>() { "blockBlob" }),
            };
            ManagementPolicyRule rule3 = new ManagementPolicyRule("rule3", "Lifecycle", definition3);
            rules.Add(rule3);

            ManagementPolicyData parameter = new ManagementPolicyData()
            {
                Policy = new ManagementPolicySchema(rules)
            };

            //set management policy, the policy name should always be default
            ManagementPolicyResource managementPolicy = (await account.GetManagementPolicy().CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;
            Assert.NotNull(managementPolicy);
            Assert.AreEqual(managementPolicy.Data.Policy.Rules.Count, 3);

            //delete namagement policy
            await managementPolicy.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task CreateUpdateGetEncryptionScope()
        {
            //create resource group and storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            EncryptionScopeCollection encryptionScopeCollection = account.GetEncryptionScopes();

            //create encryption scope
            EncryptionScopeData parameter = new EncryptionScopeData()
            {
                Source = EncryptionScopeSource.MicrosoftStorage,
                State = EncryptionScopeState.Enabled,
                RequireInfrastructureEncryption = false
            };
            EncryptionScopeResource encryptionScope = (await encryptionScopeCollection.CreateOrUpdateAsync(WaitUntil.Completed, "scope", parameter)).Value;
            Assert.AreEqual("scope", encryptionScope.Id.Name);
            Assert.AreEqual(EncryptionScopeState.Enabled, encryptionScope.Data.State);
            Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, encryptionScope.Data.Source);

            //patch encryption scope
            encryptionScope.Data.State = EncryptionScopeState.Disabled;
            encryptionScope = await encryptionScope.UpdateAsync(encryptionScope.Data);
            Assert.AreEqual(encryptionScope.Data.State, EncryptionScopeState.Disabled);

            //get all encryption scopes
            List<EncryptionScopeResource> encryptionScopes = await encryptionScopeCollection.GetAllAsync().ToEnumerableAsync();
            encryptionScope = encryptionScopes.First();
            Assert.AreEqual("scope", encryptionScope.Id.Name);
            Assert.AreEqual(EncryptionScopeState.Disabled, encryptionScope.Data.State);
            Assert.AreEqual(EncryptionScopeSource.MicrosoftStorage, encryptionScope.Data.Source);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllPrivateEndPointConnections()
        {
            //create resource group and storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), kind: StorageKind.StorageV2);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            StoragePrivateEndpointConnectionCollection privateEndpointConnectionCollection = account.GetStoragePrivateEndpointConnections();

            //get all private endpoint connections
            List<StoragePrivateEndpointConnectionResource> privateEndpointConnections = await privateEndpointConnectionCollection.GetAllAsync().ToEnumerableAsync();
            Assert.NotNull(privateEndpointConnections);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllPrivateLinkResources()
        {
            //create resource group and storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), kind: StorageKind.StorageV2);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //get all private link resources
            await foreach (var _ in account.GetPrivateLinkResourcesAsync())
            {
                return;
            }

            Assert.Fail($"{nameof(StorageAccountResource)}.{nameof(StorageAccountResource.GetPrivateLinkResourcesAsync)} has returned an empty collection of {nameof(StoragePrivateLinkResource)}.");
        }

        [Test]
        [RecordedTest]
        public async Task ListStorageAccountsInSubscription()
        {
            //create 2 resource groups and 2 storage accounts
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup1 = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = resourceGroup1.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters);

            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup2 = await CreateResourceGroupAsync();
            storageAccountCollection = resourceGroup2.GetStorageAccounts();
            await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, parameters);

            //validate two storage accounts
            StorageAccountResource account1 = null;
            StorageAccountResource account2 = null;
            await foreach (StorageAccountResource account in DefaultSubscription.GetStorageAccountsAsync())
            {
                if (account.Id.Name == accountName1)
                    account1 = account;
                if (account.Id.Name == accountName2)
                    account2 = account;
            }
            VerifyAccountProperties(account1, true);
            VerifyAccountProperties(account2, true);
            Assert.AreEqual(account1.Id.ResourceGroupName, resourceGroup1.Id.Name);
            Assert.AreEqual(account2.Id.ResourceGroupName, resourceGroup2.Id.Name);

            await account1.DeleteAsync(WaitUntil.Completed);
            await account2.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountVnetACL()
        {
            //create an account with network rule set
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup1 = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = resourceGroup1.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2, sku: new StorageSku(StorageSkuName.StandardLRS));
            parameters.NetworkRuleSet = new NetworkRuleSet(DefaultAction.Deny) { Bypass = @"Logging,AzureServices" };
            parameters.NetworkRuleSet.IPRules.Add(new IPRule("23.45.67.90"));
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;

            //validate
            account = await account.GetAsync();
            Assert.NotNull(account.Data.NetworkRuleSet);
            Assert.AreEqual(@"Logging, AzureServices", account.Data.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Deny, account.Data.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(account.Data.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(account.Data.NetworkRuleSet.IPRules);
            Assert.IsNotEmpty(account.Data.NetworkRuleSet.IPRules);
            Assert.AreEqual("23.45.67.90", account.Data.NetworkRuleSet.IPRules[0].IPAddressOrRange);
            Assert.AreEqual("Allow", account.Data.NetworkRuleSet.IPRules[0].Action);

            //update vnet
            StorageAccountPatch updateParameters = new StorageAccountPatch
            {
                NetworkRuleSet = new NetworkRuleSet(DefaultAction.Deny)
                {
                    Bypass = @"Logging, Metrics"
                }
            };
            updateParameters.NetworkRuleSet.IPRules.Add(new IPRule("23.45.67.91") { Action = "Allow" });
            updateParameters.NetworkRuleSet.IPRules.Add(new IPRule("23.45.67.92"));
            updateParameters.NetworkRuleSet.ResourceAccessRules.Add(new ResourceAccessRule("72f988bf-86f1-41af-91ab-2d7cd011db47", "/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount1"));
            updateParameters.NetworkRuleSet.ResourceAccessRules.Add(new ResourceAccessRule("72f988bf-86f1-41af-91ab-2d7cd011db47", "/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount2"));
            account = await account.UpdateAsync(updateParameters);

            //validate
            account = await account.GetAsync();
            Assert.NotNull(account.Data.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", account.Data.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Deny, account.Data.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(account.Data.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(account.Data.NetworkRuleSet.IPRules);
            Assert.IsNotEmpty(account.Data.NetworkRuleSet.IPRules);
            Assert.AreEqual("23.45.67.91", account.Data.NetworkRuleSet.IPRules[0].IPAddressOrRange);
            Assert.AreEqual("Allow", account.Data.NetworkRuleSet.IPRules[0].Action);
            Assert.AreEqual("23.45.67.92", account.Data.NetworkRuleSet.IPRules[1].IPAddressOrRange);
            Assert.AreEqual("Allow", account.Data.NetworkRuleSet.IPRules[1].Action);
            Assert.NotNull(account.Data.NetworkRuleSet.ResourceAccessRules);
            Assert.IsNotEmpty(account.Data.NetworkRuleSet.ResourceAccessRules);
            Assert.AreEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", account.Data.NetworkRuleSet.ResourceAccessRules[0].TenantId);
            Assert.AreEqual("/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount1", account.Data.NetworkRuleSet.ResourceAccessRules[0].ResourceId);
            Assert.AreEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", account.Data.NetworkRuleSet.ResourceAccessRules[1].TenantId);
            Assert.AreEqual("/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount2", account.Data.NetworkRuleSet.ResourceAccessRules[1].ResourceId);

            //delete vnet
            updateParameters = new StorageAccountPatch
            {
                NetworkRuleSet = new NetworkRuleSet(DefaultAction.Allow) { }
            };
            account = await account.UpdateAsync(updateParameters);

            //validate
            account = await account.GetAsync();
            Assert.NotNull(account.Data.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", account.Data.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(DefaultAction.Allow, account.Data.NetworkRuleSet.DefaultAction);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountSASKeyPolicy()
        {
            //create an account and validate
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup1 = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = resourceGroup1.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters();
            parameters.KeyPolicy = new KeyPolicy(2);
            parameters.SasPolicy = new SasPolicy("2.02:03:59", ExpirationAction.Log);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;
            Assert.AreEqual(2, account.Data.KeyPolicy.KeyExpirationPeriodInDays);
            Assert.AreEqual("2.02:03:59", account.Data.SasPolicy.SasExpirationPeriod);

            //update storage account type
            var updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2,
                EnableHttpsTrafficOnly = true,
                SasPolicy = new SasPolicy("0.02:03:59", ExpirationAction.Log),
                KeyPolicy = new KeyPolicy(9)
            };
            account = await account.UpdateAsync(updateParameters);

            //validate
            Assert.AreEqual(9, account.Data.KeyPolicy.KeyExpirationPeriodInDays);
            Assert.AreEqual("0.02:03:59", account.Data.SasPolicy.SasExpirationPeriod);
            Assert.NotNull(account.Data.KeyCreationTime.Key1);
            Assert.NotNull(account.Data.KeyCreationTime.Key2);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountFailOver()
        {
            //create an account with network rule set
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup1 = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = resourceGroup1.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2, sku: new StorageSku(StorageSkuName.StandardRagrs));
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;
            int i = 100;
            string location = account.Data.Location;
            do
            {
                account = await account.GetAsync(expand: StorageAccountExpand.GeoReplicationStats);
                Assert.AreEqual(StorageSkuName.StandardRagrs, account.Data.Sku.Name);
                Assert.Null(account.Data.FailoverInProgress);
                location = account.Data.SecondaryLocation;

                //Don't need sleep when playback, or Unit test will be very slow. Need sleep when record.
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
            } while ((account.Data.GeoReplicationStats.CanFailover != true) && (i-- > 0));

            await account.FailoverAsync(WaitUntil.Completed);

            account = await account.GetAsync();

            Assert.AreEqual(StorageSkuName.StandardLRS, account.Data.Sku.Name);
            Assert.AreEqual(location, account.Data.PrimaryLocation);
        }

        [Test]
        [RecordedTest]
        [Ignore("need enviroment")]
        public async Task StorageAccountCreateSetGetFileAadIntegration()
        {
            //create an account
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup1 = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = resourceGroup1.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2);
            parameters.AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication(DirectoryServiceOptions.Aadds);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;

            //validate
            account = await account.GetAsync();
            Assert.AreEqual(DirectoryServiceOptions.Aadds, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            //Update storage account
            var updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new AzureFilesIdentityBasedAuthentication(DirectoryServiceOptions.None),
                EnableHttpsTrafficOnly = true
            };
            account = await account.UpdateAsync(updateParameters);
            Assert.AreEqual(DirectoryServiceOptions.None, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            // Validate
            account = await account.GetAsync();
            Assert.AreEqual(DirectoryServiceOptions.None, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);
        }
    }
}
