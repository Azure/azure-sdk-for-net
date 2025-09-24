// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Xml.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageAccountTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private const string namePrefix = "teststoragemgmt";
        public StorageAccountTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TearDown]
        public async Task ClearStorageAccounts()
        {
            //remove all storage accounts under current resource group
            if (_resourceGroup != null)
            {
                await foreach (StorageAccountResource account in _resourceGroup.GetStorageAccounts())
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
            Assert.True(skulist.ElementAt(0).Name.Equals(StorageSkuName.PremiumLrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardGrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardLrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardRagrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardZrs));
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

            // Make sure a second create returns immediately
            var createRequest = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            VerifyAccountProperties(createRequest, true);

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

            // Delete an account which was just deleted
            await account1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.IsFalse(await storageAccountCollection.ExistsAsync(accountName));
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await storageAccountCollection.GetAsync(accountName); });
            Assert.AreEqual(404, exception.Status);

            // Delete an account which does not exist
            var falseId = account1.Id.ToString().Replace(accountName, "missingaccount");
            var missingStorage = new StorageAccountResource(Client, new ResourceIdentifier(falseId));
            await missingStorage.DeleteAsync(WaitUntil.Completed);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStandardAccount()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            //create a Lrs storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs)))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.Null(account1.Data.Identity);

            //create a Grs storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardGrs)))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, true);

            //create a RAGrs storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardRagrs)))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);

            //create a ZRS storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardZrs)))).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
        }

        [Test]
        [RecordedTest]
        public async Task CreateBlobAccount()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            //create a blob Lrs storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage, sku: new StorageSku(StorageSkuName.StandardLrs));
            parameters.AccessTier = StorageAccountAccessTier.Hot;
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);

            //create a blob Grs storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage, sku: new StorageSku(StorageSkuName.StandardGrs));
            parameters.AccessTier = StorageAccountAccessTier.Hot;
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);

            //create a blob RAGrs storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage, sku: new StorageSku(StorageSkuName.StandardRagrs));
            parameters.AccessTier = StorageAccountAccessTier.Hot;
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

            //create a premium Lrs storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.PremiumLrs));
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
                Sku = new StorageSku(StorageSkuName.StandardLrs),
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(account1.Data.Sku.Name, StorageSkuName.StandardLrs);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(account2.Data.Sku.Name, StorageSkuName.StandardLrs);

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
            parameters.Encryption = new StorageAccountEncryption()
            {
                KeySource = StorageAccountKeySource.Storage,
                Services = new StorageAccountEncryptionServices
                {
                    Blob = new StorageEncryptionService { IsEnabled = true },
                    File = new StorageEncryptionService { IsEnabled = true }
                }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            //validate
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.NotNull(account2.Data.Encryption);
            Assert.NotNull(account2.Data.Encryption.Services.Blob);
            Assert.True(account2.Data.Encryption.Services.Blob.IsEnabled);
            Assert.NotNull(account2.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account2.Data.Encryption.Services.File);
            Assert.True(account2.Data.Encryption.Services.File.IsEnabled);
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
                CustomDomain = new StorageCustomDomain("foo.example.com")
                {
                    IsUseSubDomainNameEnabled = true
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
            Assert.NotNull(account1.Data.PrimaryEndpoints.WebUri);
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
            VerifyAccountProperties(account1, false);
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
            VerifyAccountProperties(account1, false);
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
                Sku = new StorageSku(StorageSkuName.StandardLrs)
            };
            parameters.Tags.Add("key3", "value3");
            parameters.Tags.Add("key4", "value4");
            parameters.Tags.Add("key5", "value5");

            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageSkuName.StandardLrs, account1.Data.Sku.Name);
            Assert.AreEqual(parameters.Tags.Count, account1.Data.Tags.Count);

            account1 = await account1.GetAsync();
            Assert.AreEqual(StorageSkuName.StandardLrs, account1.Data.Sku.Name);
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
                Encryption = new StorageAccountEncryption()
                {
                    KeySource = StorageAccountKeySource.Storage,
                    Services = new StorageAccountEncryptionServices
                    {
                        Blob = new StorageEncryptionService { IsEnabled = true },
                        File = new StorageEncryptionService { IsEnabled = true }
                    }
                }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            // Validate
            account1 = await account1.GetAsync();
            Assert.NotNull(account1.Data.Encryption);
            Assert.NotNull(account1.Data.Encryption.Services.Blob);
            Assert.True(account1.Data.Encryption.Services.Blob.IsEnabled);
            Assert.NotNull(account1.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account1.Data.Encryption.Services.File);
            Assert.True(account1.Data.Encryption.Services.File.IsEnabled);
            Assert.NotNull(account1.Data.Encryption.Services.File.LastEnabledOn);

            // 2. Restore storage encryption
            parameters = new StorageAccountPatch
            {
                Encryption = new StorageAccountEncryption()
                {
                    KeySource = StorageAccountKeySource.Storage,
                    Services = new StorageAccountEncryptionServices
                    {
                        Blob = new StorageEncryptionService { IsEnabled = true },
                        File = new StorageEncryptionService { IsEnabled = true }
                    }
                }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            // Validate
            account1 = await account1.GetAsync();
            Assert.NotNull(account1.Data.Encryption);
            Assert.NotNull(account1.Data.Encryption.Services.Blob);
            Assert.True(account1.Data.Encryption.Services.Blob.IsEnabled);
            Assert.NotNull(account1.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account1.Data.Encryption.Services.File);
            Assert.True(account1.Data.Encryption.Services.File.IsEnabled);
            Assert.NotNull(account1.Data.Encryption.Services.File.LastEnabledOn);

            // 3. Remove file encryption service field.
            parameters = new StorageAccountPatch
            {
                Encryption = new StorageAccountEncryption()
                {
                    KeySource = StorageAccountKeySource.Storage,
                    Services = new StorageAccountEncryptionServices { Blob = new StorageEncryptionService { IsEnabled = true } }
                }
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.NotNull(account1.Data.Encryption);

            // Validate
            account1 = await account1.GetAsync();
            Assert.NotNull(account1.Data.Encryption);
            Assert.NotNull(account1.Data.Encryption.Services.Blob);
            Assert.True(account1.Data.Encryption.Services.Blob.IsEnabled);
            Assert.NotNull(account1.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account1.Data.Encryption.Services.File);
            Assert.True(account1.Data.Encryption.Services.File.IsEnabled);
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
            parameters.Encryption = new StorageAccountEncryption()
            {
                KeySource = StorageAccountKeySource.Storage,
                Services = new StorageAccountEncryptionServices
                {
                    Blob = new StorageEncryptionService { IsEnabled = true },
                    File = new StorageEncryptionService { IsEnabled = true }
                },
            };
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account1, true);

            List<StorageAccountResource> accounts = await storageAccountCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(1, accounts.Count);
            StorageAccountResource account = accounts[0];
            Assert.NotNull(account.Data.Encryption);
            Assert.NotNull(account.Data.Encryption.Services.Blob);
            Assert.IsTrue(account.Data.Encryption.Services.Blob.IsEnabled);
            Assert.NotNull(account.Data.Encryption.Services.Blob.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.File);
            Assert.IsTrue(account.Data.Encryption.Services.File.IsEnabled);
            Assert.NotNull(account.Data.Encryption.Services.File.LastEnabledOn);

            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.IsEnabled.HasValue)
                {
                    Assert.IsFalse(account.Data.Encryption.Services.Table.LastEnabledOn.HasValue);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.IsEnabled.HasValue)
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
            StorageSku sku = new StorageSku(StorageSkuName.StandardLrs);
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

            // List keys
            var keys = await account1.GetKeysAsync().ToEnumerableAsync();
            Assert.NotNull(keys);

            // Validate Key1
            StorageAccountKey key1 = keys.First(
                t => t.KeyName.Equals("key1", StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(key1);
            Assert.AreEqual(StorageAccountKeyPermission.Full, key1.Permissions);
            Assert.NotNull(key1.Value);

            // Validate Key2
            StorageAccountKey key2 = keys.First(
                t => t.KeyName.Equals("key2", StringComparison.OrdinalIgnoreCase));
            Assert.NotNull(key2);
            Assert.AreEqual(StorageAccountKeyPermission.Full, key2.Permissions);
            Assert.NotNull(key2.Value);

            //regenerate key and verify the key's change
            StorageAccountRegenerateKeyContent keyParameters = new StorageAccountRegenerateKeyContent("key2");
            var regenKeys = await account1.RegenerateKeyAsync(keyParameters).ToEnumerableAsync();
            StorageAccountKey regenKey2 = regenKeys.First(
                t => t.KeyName.Equals("key2", StringComparison.OrdinalIgnoreCase));
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
            parameters.NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Deny)
            {
                Bypass = @"Logging, AzureServices",
                IPRules = { new StorageAccountIPRule("23.45.67.89") }
            };
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account1, false);

            //verify network rule
            StorageAccountData accountData = account1.Data;
            Assert.NotNull(accountData.NetworkRuleSet);
            Assert.AreEqual(@"Logging, AzureServices", accountData.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(StorageNetworkDefaultAction.Deny, accountData.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(accountData.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(accountData.NetworkRuleSet.IPRules);
            Assert.IsNotEmpty(accountData.NetworkRuleSet.IPRules);
            Assert.AreEqual("23.45.67.89", accountData.NetworkRuleSet.IPRules[0].IPAddressOrRange);
            Assert.AreEqual(StorageAccountNetworkRuleAction.Allow, accountData.NetworkRuleSet.IPRules[0].Action);

            //update network rule
            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Deny)
                {
                    Bypass = @"Logging, Metrics",
                    IPRules =
                    {
                        new StorageAccountIPRule("23.45.67.90"),
                        new StorageAccountIPRule("23.45.67.91")
                    }
                }
            };
            StorageAccountResource account2 = await account1.UpdateAsync(updateParameters);

            //verify updated network rule
            accountData = account2.Data;
            Assert.NotNull(accountData.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", accountData.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(StorageNetworkDefaultAction.Deny, accountData.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(accountData.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(accountData.NetworkRuleSet.IPRules);
            Assert.IsNotEmpty(accountData.NetworkRuleSet.IPRules);
            Assert.AreEqual("23.45.67.90", accountData.NetworkRuleSet.IPRules[0].IPAddressOrRange);
            Assert.AreEqual(StorageAccountNetworkRuleAction.Allow, accountData.NetworkRuleSet.IPRules[0].Action);
            Assert.AreEqual("23.45.67.91", accountData.NetworkRuleSet.IPRules[1].IPAddressOrRange);
            Assert.AreEqual(StorageAccountNetworkRuleAction.Allow, accountData.NetworkRuleSet.IPRules[1].Action);

            //update network rule to allow
            updateParameters = new StorageAccountPatch()
            {
                NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Allow)
            };
            StorageAccountResource account3 = await account2.UpdateAsync(updateParameters);

            //verify updated network rule
            accountData = account3.Data;
            Assert.NotNull(accountData.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", accountData.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(StorageNetworkDefaultAction.Allow, accountData.NetworkRuleSet.DefaultAction);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithBlockBlobStorage()
        {
            //create storage account with block blob storage
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageSku sku = new StorageSku(StorageSkuName.PremiumLrs);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: sku, kind: StorageKind.BlockBlobStorage);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageKind.BlockBlobStorage, account1.Data.Kind);
            Assert.AreEqual(StorageSkuName.PremiumLrs, account1.Data.Sku.Name);
            //this storage account should only have endpoints on blob and dfs
            Assert.NotNull(account1.Data.PrimaryEndpoints.BlobUri);
            Assert.NotNull(account1.Data.PrimaryEndpoints.DfsUri);
            Assert.IsNull(account1.Data.PrimaryEndpoints.FileUri);
            Assert.IsNull(account1.Data.PrimaryEndpoints.TableUri);
            Assert.IsNull(account1.Data.PrimaryEndpoints.QueueUri);
        }

        [Test]
        [RecordedTest]
        public async Task CreateStorageAccountWithLargeFileSharesState()
        {
            //create storage account with storage v2
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), kind: StorageKind.StorageV2);
            parameters.LargeFileSharesState = LargeFileSharesState.Enabled;
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account1 = await account1.GetAsync();
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(LargeFileSharesState.Enabled, account1.Data.LargeFileSharesState);
            Assert.AreEqual(StorageSkuName.StandardLrs, account1.Data.Sku.Name);
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
            Assert.NotNull(account1.Data.PrimaryEndpoints.DfsUri);
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
            StorageSku sku = new StorageSku(StorageSkuName.PremiumLrs);
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: sku, kind: StorageKind.FileStorage);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageKind.FileStorage, account1.Data.Kind);
            Assert.AreEqual(StorageSkuName.PremiumLrs, account1.Data.Sku.Name);
            //this storage account should only have endpoints on file
            Assert.IsNull(account1.Data.PrimaryEndpoints.BlobUri);
            Assert.IsNull(account1.Data.PrimaryEndpoints.DfsUri);
            Assert.NotNull(account1.Data.PrimaryEndpoints.FileUri);
            Assert.IsNull(account1.Data.PrimaryEndpoints.TableUri);
            Assert.IsNull(account1.Data.PrimaryEndpoints.QueueUri);
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
            parameters.Encryption = new StorageAccountEncryption()
            {
                KeySource = StorageAccountKeySource.Storage,
                Services = new StorageAccountEncryptionServices
                {
                    Blob = new StorageEncryptionService { IsEnabled = true },
                    File = new StorageEncryptionService { IsEnabled = true }
                }
            };
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account, true);

            //verify encryption settings
            Assert.NotNull(account.Data.Encryption);
            Assert.NotNull(account.Data.Encryption.Services.Blob);
            Assert.True(account.Data.Encryption.Services.Blob.IsEnabled);
            Assert.NotNull(account.Data.Encryption.Services.Blob.LastEnabledOn);
            Assert.NotNull(account.Data.Encryption.Services.File);
            Assert.NotNull(account.Data.Encryption.Services.File.IsEnabled);
            Assert.NotNull(account.Data.Encryption.Services.File.LastEnabledOn);
            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.IsEnabled.HasValue)
                {
                    Assert.False(account.Data.Encryption.Services.Table.LastEnabledOn.HasValue);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.IsEnabled.HasValue)
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
            parameters.Encryption = new StorageAccountEncryption()
            {
                KeySource = StorageAccountKeySource.Storage,
                Services = new StorageAccountEncryptionServices()
                {
                    Queue = new StorageEncryptionService { KeyType = StorageEncryptionKeyType.Account },
                    Table = new StorageEncryptionService { KeyType = StorageEncryptionKeyType.Account },
                }
            };
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account, false);

            //verify encryption settings
            Assert.NotNull(account.Data.Encryption);
            Assert.NotNull(account.Data.Encryption.Services.Blob);
            Assert.IsTrue(account.Data.Encryption.Services.Blob.IsEnabled);
            Assert.AreEqual(StorageEncryptionKeyType.Account, account.Data.Encryption.Services.Blob.KeyType);
            Assert.NotNull(account.Data.Encryption.Services.Blob.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.File);
            Assert.IsTrue(account.Data.Encryption.Services.File.IsEnabled);
            Assert.AreEqual(StorageEncryptionKeyType.Account, account.Data.Encryption.Services.Blob.KeyType);
            Assert.NotNull(account.Data.Encryption.Services.File.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.Queue);
            Assert.AreEqual(StorageEncryptionKeyType.Account, account.Data.Encryption.Services.Queue.KeyType);
            Assert.IsTrue(account.Data.Encryption.Services.Queue.IsEnabled);
            Assert.NotNull(account.Data.Encryption.Services.Queue.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.Table);
            Assert.AreEqual(StorageEncryptionKeyType.Account, account.Data.Encryption.Services.Table.KeyType);
            Assert.IsTrue(account.Data.Encryption.Services.Table.IsEnabled);
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
        public async Task CreateUpdateStorageAccountWithAccessTier()
        {
            //create storage account with accesstier hot, update to cool
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage);
            parameters.AccessTier = StorageAccountAccessTier.Hot;
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;

            VerifyAccountProperties(account, false);
            Assert.AreEqual(StorageAccountAccessTier.Hot, account.Data.AccessTier);
            Assert.AreEqual(StorageKind.BlobStorage, account.Data.Kind);

            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                AccessTier = StorageAccountAccessTier.Cool
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.AreEqual(StorageAccountAccessTier.Cool, account.Data.AccessTier);

            //create storage account with accesstier cool, update to cool
            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            parameters.AccessTier = StorageAccountAccessTier.Cool;
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, parameters)).Value;

            VerifyAccountProperties(account, false);
            Assert.AreEqual(StorageAccountAccessTier.Cool, account.Data.AccessTier);
            Assert.AreEqual(StorageKind.BlobStorage, account.Data.Kind);
        }

        [Test]
        [RecordedTest]
        public async Task CreateUpdateStorageAccountWithAccessTierCold()
        {
            //create storage account with accesstier cool, update to cold
            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage);
            parameters.AccessTier = StorageAccountAccessTier.Cool;
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, parameters)).Value;

            VerifyAccountProperties(account, false);
            Assert.AreEqual(StorageAccountAccessTier.Cool, account.Data.AccessTier);
            Assert.AreEqual(StorageKind.BlobStorage, account.Data.Kind);

            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                AccessTier = StorageAccountAccessTier.Cold
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.AreEqual(StorageAccountAccessTier.Cold, account.Data.AccessTier);

            //create storage account with accesstier cold, update to hot
            string accountName3 = await CreateValidAccountNameAsync(namePrefix);
            parameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                "eastus2euap"
                );
            parameters.AccessTier = StorageAccountAccessTier.Cold;
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName3, parameters)).Value;

            VerifyAccountProperties(account, false);
            Assert.AreEqual(StorageAccountAccessTier.Cold, account.Data.AccessTier);
            Assert.AreEqual(StorageKind.StorageV2, account.Data.Kind);

            updateParameters = new StorageAccountPatch()
            {
                AccessTier = StorageAccountAccessTier.Hot
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.AreEqual(StorageAccountAccessTier.Hot, account.Data.AccessTier);
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
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.PremiumLrs), kind: StorageKind.StorageV2, location: AzureLocation.EastUS2);
            parameters.ExtendedLocation = new ExtendedLocation
            {
                ExtendedLocationType = ExtendedLocationType.EdgeZone,
                Name = "microsoftrrdclab1"
            };
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account = await account.GetAsync();
            VerifyAccountProperties(account, false);
            Assert.NotNull(account.Data.PrimaryEndpoints.WebUri);
            Assert.AreEqual(StorageKind.StorageV2, account.Data.Kind);
            Assert.AreEqual(ExtendedLocationType.EdgeZone, account.Data.ExtendedLocation.ExtendedLocationType);
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
            parameters.MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_3;
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account = await account.GetAsync();
            VerifyAccountProperties(account, false);
            Assert.AreEqual(StorageMinimumTlsVersion.Tls1_3, account.Data.MinimumTlsVersion);

            //update account
            StorageAccountPatch udpateParameters = new StorageAccountPatch();
            udpateParameters.MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_2;
            udpateParameters.AllowBlobPublicAccess = true;
            udpateParameters.EnableHttpsTrafficOnly = true;
            account = await account.UpdateAsync(udpateParameters);

            //validate
            account = await account.GetAsync();
            Assert.AreEqual(StorageMinimumTlsVersion.Tls1_2, account.Data.MinimumTlsVersion);

            //update account
            udpateParameters = new StorageAccountPatch();
            udpateParameters.MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_1;
            udpateParameters.AllowBlobPublicAccess = true;
            udpateParameters.EnableHttpsTrafficOnly = true;
            account = await account.UpdateAsync(udpateParameters);

            //validate
            account = await account.GetAsync();
            Assert.AreEqual(StorageMinimumTlsVersion.Tls1_1, account.Data.MinimumTlsVersion);

            //update account
            udpateParameters = new StorageAccountPatch();
            udpateParameters.MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_3;
            udpateParameters.AllowBlobPublicAccess = true;
            udpateParameters.EnableHttpsTrafficOnly = true;
            account = await account.UpdateAsync(udpateParameters);

            //validate
            account = await account.GetAsync();
            Assert.AreEqual(StorageMinimumTlsVersion.Tls1_3, account.Data.MinimumTlsVersion);
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
            AccountSasContent accountSasParameters = new AccountSasContent(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpireOn: Recording.UtcNow.AddHours(1));
            GetAccountSasResult result = await account.GetAccountSasAsync(accountSasParameters);
            AccountSasContent resultCredentials = ParseAccountSASToken(result.AccountSasToken);

            Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
            Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
            Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
            Assert.NotNull(accountSasParameters.SharedAccessExpireOn);
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
            AccountSasContent accountSasParameters = new AccountSasContent(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpireOn: Recording.UtcNow.AddHours(1));
            GetAccountSasResult result = await account.GetAccountSasAsync(accountSasParameters);
            AccountSasContent resultCredentials = ParseAccountSASToken(result.AccountSasToken);

            Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
            Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
            Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
            Assert.NotNull(accountSasParameters.SharedAccessExpireOn);
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

            AccountSasContent accountSasParameters = new AccountSasContent(services: "b", resourceTypes: "sco", permissions: "rl", sharedAccessExpireOn: Recording.UtcNow.AddHours(1))
            {
                Protocols = StorageAccountHttpProtocol.HttpsHttp,
                SharedAccessStartOn = Recording.UtcNow,
                KeyToSign = "key1"
            };
            GetAccountSasResult result = await account.GetAccountSasAsync(accountSasParameters);
            AccountSasContent resultCredentials = ParseAccountSASToken(result.AccountSasToken);

            Assert.AreEqual(accountSasParameters.Services, resultCredentials.Services);
            Assert.AreEqual(accountSasParameters.ResourceTypes, resultCredentials.ResourceTypes);
            Assert.AreEqual(accountSasParameters.Permissions, resultCredentials.Permissions);
            Assert.AreEqual(accountSasParameters.Protocols, resultCredentials.Protocols);
            Assert.NotNull(accountSasParameters.SharedAccessStartOn);
            Assert.NotNull(accountSasParameters.SharedAccessExpireOn);
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
            GetServiceSasResult result = await account.GetServiceSasAsync(serviceSasParameters);
            ServiceSasContent resultCredentials = ParseServiceSASToken(result.ServiceSasToken, canonicalizedResourceParameter);
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
                Response<GetServiceSasResult> result = await account.GetServiceSasAsync(serviceSasParameters);
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
                Protocols = StorageAccountHttpProtocol.HttpsHttp,
                SharedAccessStartOn = Recording.UtcNow,
                SharedAccessExpiryOn = Recording.UtcNow.AddHours(1),
                KeyToSign = "key1"
            };

            GetServiceSasResult result = await account.GetServiceSasAsync(serviceSasParameters);
            ServiceSasContent resultCredentials = ParseServiceSASToken(result.ServiceSasToken, canonicalizedResourceParameter);
            Assert.AreEqual(serviceSasParameters.Resource, resultCredentials.Resource);
            Assert.AreEqual(serviceSasParameters.Permissions, resultCredentials.Permissions);
            Assert.AreEqual(serviceSasParameters.Protocols, resultCredentials.Protocols);
            Assert.NotNull(serviceSasParameters.SharedAccessStartOn);
            Assert.NotNull(serviceSasParameters.SharedAccessExpiryOn);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
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
            parameters.IsNfsV3Enabled = false;
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            VerifyAccountProperties(account, false);
            Assert.NotNull(account.Data.PrimaryEndpoints.WebUri);
            Assert.AreEqual(StorageKind.StorageV2, account.Data.Kind);
            Assert.False(account.Data.IsNfsV3Enabled);
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

            List<string> blobSchemaFields1 = new(BlobSchemaField);
            List<string> blobSchemaFields2 = new();
            blobSchemaFields2.Add("Name");
            List<string> containerSchemaFields1 = new(ContainerSchemaField);
            List<string> containerSchemaFields2 = new();
            containerSchemaFields2.Add("Name");

            // prepare policy objects,the type of policy rule should always be Inventory
            var ruleList = new List<BlobInventoryPolicyRule>();
            BlobInventoryPolicyRule rule1 = new BlobInventoryPolicyRule(true, "rule1", containerName,
                new BlobInventoryPolicyDefinition(BlobInventoryPolicyFormat.Csv, BlobInventoryPolicySchedule.Weekly, BlobInventoryPolicyObjectType.Blob, blobSchemaFields1)
                {
                    Filters = new BlobInventoryPolicyFilter()
                    {
                        BlobTypes = { "blockBlob" },
                        IncludePrefix = { "prefix1", "prefix2" },
                        IncludeBlobVersions = true,
                        IncludeSnapshots = true,
                    }
                });

            BlobInventoryPolicyRule rule2 = new BlobInventoryPolicyRule(true, "rule2", containerName,
                new BlobInventoryPolicyDefinition(
                    format: BlobInventoryPolicyFormat.Csv,
                    schedule: BlobInventoryPolicySchedule.Daily,
                    objectType: BlobInventoryPolicyObjectType.Container,
                    schemaFields: containerSchemaFields1));

            BlobInventoryPolicyRule rule3 = new BlobInventoryPolicyRule(true, "rule3", containerName,
                new BlobInventoryPolicyDefinition(
                    format: BlobInventoryPolicyFormat.Parquet,
                    schedule: BlobInventoryPolicySchedule.Weekly,
                    objectType: BlobInventoryPolicyObjectType.Container,
                    schemaFields: containerSchemaFields2));
            ruleList.Add(rule1);
            ruleList.Add(rule2);
            BlobInventoryPolicySchema policy = new BlobInventoryPolicySchema(true, "Inventory", ruleList);
            BlobInventoryPolicyData parameter = new BlobInventoryPolicyData()
            {
                PolicySchema = policy
            };

            //create and get policy, the name of blob inventory policy should always be default
            BlobInventoryPolicyResource blobInventoryPolicy = account.GetBlobInventoryPolicy();
            blobInventoryPolicy = (await blobInventoryPolicy.CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;
            blobInventoryPolicy = await blobInventoryPolicy.GetAsync();
            Assert.AreEqual(blobInventoryPolicy.Data.PolicySchema.Rules.Count, 2);

            //update policy
            ruleList.Add(rule3);
            BlobInventoryPolicySchema policy2 = new BlobInventoryPolicySchema(true, "Inventory", ruleList);
            BlobInventoryPolicyData parameter2 = new BlobInventoryPolicyData()
            {
                PolicySchema = policy2
            };
            blobInventoryPolicy = (await blobInventoryPolicy.CreateOrUpdateAsync(WaitUntil.Completed, parameter2)).Value;
            Assert.AreEqual(blobInventoryPolicy.Data.PolicySchema.Rules.Count, 3);

            //delete policy
            await blobInventoryPolicy.DeleteAsync(WaitUntil.Completed);
            try
            {
                var outputPolicy = await blobInventoryPolicy.GetAsync();
                throw new Exception("BlobInventoryPolicy should already beene deleted, so get BlobInventoryPolicy should fail with 404. But not fail.");
            }
            catch (RequestFailedException e) when (e.ErrorCode.Equals("BlobInventoryPolicyNotFound"))
            {
                // get not exist blob inventory policy should report 404(NotFound)
            }
        }

        [Test]
        [RecordedTest]
        public async Task SetGetDeleteManagementPolicy()
        {
            //create resource group and storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2, location: "eastus2euap", sku: new StorageSku(StorageSkuName.StandardLrs));
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
                    Delete = new DateAfterModification()
                    {
                        DaysAfterModificationGreaterThan = 1000,
                    }
                }
            };
            ManagementPolicyAction action2 = new ManagementPolicyAction()
            {
                BaseBlob = new ManagementPolicyBaseBlob()
                {
                    Delete = new DateAfterModification()
                    {
                        DaysAfterModificationGreaterThan = 1000,
                    },
                    TierToCold = new DateAfterModification()
                    {
                        DaysAfterCreationGreaterThan = 100,
                    },
                    TierToCool = new DateAfterModification()
                    {
                        DaysAfterCreationGreaterThan = 500,
                    }
                },
                Snapshot = new ManagementPolicySnapShot()
                {
                    TierToCool = new DateAfterCreation(100),
                    TierToCold = new DateAfterCreation(500),
                },
                Version = new ManagementPolicyVersion()
                {
                    TierToArchive = new DateAfterCreation(200),
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

            ManagementPolicyDefinition definition3 = new ManagementPolicyDefinition(action2)
            {
                Filters = new ManagementPolicyFilter(blobTypes: new List<string>() { "blockBlob" }),
            };
            ManagementPolicyRule rule3 = new ManagementPolicyRule("rule3", "Lifecycle", definition3);
            rules.Add(rule3);

            StorageAccountManagementPolicyData parameter = new StorageAccountManagementPolicyData()
            {
                Policy = new ManagementPolicySchema(rules)
            };

            //set management policy, the policy name should always be default
            StorageAccountManagementPolicyResource managementPolicy = (await account.GetStorageAccountManagementPolicy().CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;
            Assert.NotNull(managementPolicy);
            Assert.AreEqual(managementPolicy.Data.Policy.Rules.Count, 3);
            Assert.AreEqual(managementPolicy.Data.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan, 1000);
            Assert.AreEqual(managementPolicy.Data.Rules[1].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan, 1000);
            Assert.AreEqual(managementPolicy.Data.Rules[0].Definition.Filters.BlobTypes.Count, 2);
            Assert.AreEqual(managementPolicy.Data.Rules[1].Definition.Filters.BlobTypes.Count, 1);
            Assert.AreEqual(managementPolicy.Data.Rules[2].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan, 1000);
            Assert.AreEqual(managementPolicy.Data.Rules[2].Definition.Actions.BaseBlob.TierToCold.DaysAfterCreationGreaterThan ,100);
            Assert.AreEqual(managementPolicy.Data.Rules[2].Definition.Actions.BaseBlob.TierToCool.DaysAfterCreationGreaterThan, 500);
            Assert.AreEqual(managementPolicy.Data.Rules[2].Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan, 100);
            Assert.AreEqual(managementPolicy.Data.Rules[2].Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan, 500);
            Assert.AreEqual(managementPolicy.Data.Rules[2].Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan, 200);

            // Create block blob storage premium Storage account for TierToHot test
            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup2 = await CreateResourceGroupAsync();
            storageAccountCollection = resourceGroup2.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent createAccountParams2 = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.PremiumLrs), StorageKind.BlockBlobStorage, "eastus2");
            StorageAccountResource account2 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, createAccountParams2)).Value;
            ManagementPolicyAction action3 = new ManagementPolicyAction()
            {
                BaseBlob = new ManagementPolicyBaseBlob()
                {
                    TierToCool = new DateAfterModification()
                    {
                        DaysAfterCreationGreaterThan = 100,
                    },
                    TierToHot = new DateAfterModification()
                    {
                        DaysAfterCreationGreaterThan = 50,
                    }
                }
            };
            ManagementPolicyDefinition definition4 = new ManagementPolicyDefinition(action3)
            {
                Filters = new ManagementPolicyFilter(blobTypes: new List<string>() { "blockBlob" }),
            };
            ManagementPolicyRule rule4 = new ManagementPolicyRule("rule4", "Lifecycle", definition4);
            List<ManagementPolicyRule> rules2 = new List<ManagementPolicyRule>();
            rules2.Add(rule4);
            parameter = new StorageAccountManagementPolicyData()
            {
                Policy = new ManagementPolicySchema(rules2)
            };
            StorageAccountManagementPolicyResource managementPolicy2 = (await account2.GetStorageAccountManagementPolicy().CreateOrUpdateAsync(WaitUntil.Completed, parameter)).Value;
            Assert.AreEqual(50, managementPolicy2.Data.Rules[0].Definition.Actions.BaseBlob.TierToHot.DaysAfterCreationGreaterThan);
            Assert.AreEqual(100, managementPolicy2.Data.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterCreationGreaterThan);
            Assert.AreEqual(1, managementPolicy2.Data.Rules[0].Definition.Filters.BlobTypes.Count);

            //delete namagement policy
            await managementPolicy.DeleteAsync(WaitUntil.Completed);
            bool dataPolicyExist = true;
            try
            {
                var policy = await account.GetStorageAccountManagementPolicy().GetAsync();
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual("ManagementPolicyNotFound", ex.ErrorCode);
                dataPolicyExist = false;
            }
            Assert.IsFalse(dataPolicyExist);

            //Delete not exist Management Policies will not fail
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
                Source = EncryptionScopeSource.Storage,
                State = EncryptionScopeState.Enabled,
                RequireInfrastructureEncryption = false
            };
            EncryptionScopeResource encryptionScope = (await encryptionScopeCollection.CreateOrUpdateAsync(WaitUntil.Completed, "scope", parameter)).Value;
            Assert.AreEqual("scope", encryptionScope.Id.Name);
            Assert.AreEqual(EncryptionScopeState.Enabled, encryptionScope.Data.State);
            Assert.AreEqual(EncryptionScopeSource.Storage, encryptionScope.Data.Source);

            //patch encryption scope
            encryptionScope.Data.State = EncryptionScopeState.Disabled;
            encryptionScope = await encryptionScope.UpdateAsync(encryptionScope.Data);
            Assert.AreEqual(encryptionScope.Data.State, EncryptionScopeState.Disabled);

            EncryptionScopeResource encryptionScope2 = (await encryptionScopeCollection.CreateOrUpdateAsync(WaitUntil.Completed, "scope2", parameter)).Value;
            EncryptionScopeResource encryptionScope3 = (await encryptionScopeCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testscope3", parameter)).Value;

            //get all encryption scopes
            List<EncryptionScopeResource> encryptionScopes = await encryptionScopeCollection.GetAllAsync().ToEnumerableAsync();
            encryptionScope = encryptionScopes.First();
            Assert.AreEqual(3, encryptionScopes.Count);
            Assert.AreEqual("scope", encryptionScope.Id.Name);
            Assert.AreEqual(EncryptionScopeState.Disabled, encryptionScope.Data.State);
            Assert.AreEqual(EncryptionScopeSource.Storage, encryptionScope.Data.Source);
            Assert.AreEqual("scope2", encryptionScopes[1].Data.Name);
            Assert.AreEqual(EncryptionScopeState.Enabled, encryptionScopes[1].Data.State);
            Assert.AreEqual(EncryptionScopeSource.Storage, encryptionScopes[1].Data.Source);
            Assert.AreEqual("testscope3", encryptionScopes[2].Data.Name);
            Assert.AreEqual(EncryptionScopeState.Enabled, encryptionScopes[2].Data.State);
            Assert.AreEqual(EncryptionScopeSource.Storage, encryptionScopes[2].Data.Source);

            encryptionScopes = await encryptionScopeCollection.GetAllAsync(maxpagesize: 5, include: EncryptionScopesIncludeType.Enabled, filter: "startswith(name, test)").ToEnumerableAsync();
            Assert.AreEqual(1, encryptionScopes.Count);
            Assert.AreEqual("testscope3", encryptionScopes[0].Data.Name);
            Assert.AreEqual(EncryptionScopeState.Enabled, encryptionScopes[0].Data.State);
            Assert.AreEqual(EncryptionScopeSource.Storage, encryptionScopes[0].Data.Source);

            encryptionScopes = await encryptionScopeCollection.GetAllAsync(maxpagesize: 10, include: EncryptionScopesIncludeType.Disabled, filter: "startswith(name, scope)").ToEnumerableAsync();
            Assert.AreEqual(1, encryptionScopes.Count);
            Assert.AreEqual("scope", encryptionScopes[0].Data.Name);
            Assert.AreEqual(EncryptionScopeState.Disabled, encryptionScopes[0].Data.State);
            Assert.AreEqual(EncryptionScopeSource.Storage, encryptionScopes[0].Data.Source);
        }

        [Test]
        [RecordedTest]
        public async Task GetAllPrivateEndPointConnections()
        {
            //create resource group and storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), kind: StorageKind.StorageV2);
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
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), kind: StorageKind.StorageV2);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //get all private link resources
            await foreach (var _ in account.GetPrivateLinkResourcesAsync())
            {
                return;
            }

            Assert.Fail($"{nameof(StorageAccountResource)}.{nameof(StorageAccountResource.GetPrivateLinkResourcesAsync)} has returned an empty collection of {nameof(StoragePrivateLinkResourceData)}.");
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
        [LiveOnly(Reason = "TenantId cannot be stored in recording as it is considered PII.")]
        public async Task StorageAccountVnetACL()
        {
            //create an account with network rule set
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup1 = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = resourceGroup1.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2, sku: new StorageSku(StorageSkuName.StandardLrs));
            parameters.NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Deny) { Bypass = @"Logging,AzureServices" };
            parameters.NetworkRuleSet.IPRules.Add(new StorageAccountIPRule("23.45.67.90") { Action = StorageAccountNetworkRuleAction.Allow });
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;

            //validate
            account = await account.GetAsync();
            Assert.NotNull(account.Data.NetworkRuleSet);
            Assert.AreEqual(@"Logging, AzureServices", account.Data.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(StorageNetworkDefaultAction.Deny, account.Data.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(account.Data.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(account.Data.NetworkRuleSet.IPRules);
            Assert.IsNotEmpty(account.Data.NetworkRuleSet.IPRules);
            Assert.AreEqual("23.45.67.90", account.Data.NetworkRuleSet.IPRules[0].IPAddressOrRange);
            Assert.AreEqual(StorageAccountNetworkRuleAction.Allow, account.Data.NetworkRuleSet.IPRules[0].Action);

            //update vnet
            StorageAccountPatch updateParameters = new StorageAccountPatch
            {
                NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Deny)
                {
                    Bypass = @"Logging, Metrics",
                    IPRules =
                    {
                        new StorageAccountIPRule("23.45.67.91") { Action = StorageAccountNetworkRuleAction.Allow },
                        new StorageAccountIPRule("23.45.67.92") { Action = StorageAccountNetworkRuleAction.Allow }
                    },
                    ResourceAccessRules =
                    {
                        new StorageAccountResourceAccessRule()
                        {
                            TenantId = Guid.Parse("72f988bf-86f1-41af-91ab-2d7cd011db47"),
                            ResourceId = new ResourceIdentifier("/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount1")
                        },
                        new StorageAccountResourceAccessRule()
                        {
                            TenantId = Guid.Parse("72f988bf-86f1-41af-91ab-2d7cd011db47"),
                            ResourceId = new ResourceIdentifier("/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount2")
                        },
                    }
                }
            };
            account = await account.UpdateAsync(updateParameters);

            //validate
            account = await account.GetAsync();
            Assert.NotNull(account.Data.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", account.Data.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(StorageNetworkDefaultAction.Deny, account.Data.NetworkRuleSet.DefaultAction);
            Assert.IsEmpty(account.Data.NetworkRuleSet.VirtualNetworkRules);
            Assert.NotNull(account.Data.NetworkRuleSet.IPRules);
            Assert.IsNotEmpty(account.Data.NetworkRuleSet.IPRules);
            Assert.AreEqual("23.45.67.91", account.Data.NetworkRuleSet.IPRules[0].IPAddressOrRange);
            Assert.AreEqual(StorageAccountNetworkRuleAction.Allow, account.Data.NetworkRuleSet.IPRules[0].Action);
            Assert.AreEqual("23.45.67.92", account.Data.NetworkRuleSet.IPRules[1].IPAddressOrRange);
            Assert.AreEqual(StorageAccountNetworkRuleAction.Allow, account.Data.NetworkRuleSet.IPRules[1].Action);
            Assert.NotNull(account.Data.NetworkRuleSet.ResourceAccessRules);
            Assert.IsNotEmpty(account.Data.NetworkRuleSet.ResourceAccessRules);
            Assert.AreEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", account.Data.NetworkRuleSet.ResourceAccessRules[0].TenantId.ToString());
            Assert.AreEqual("/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount1", account.Data.NetworkRuleSet.ResourceAccessRules[0].ResourceId.ToString());
            Assert.AreEqual("72f988bf-86f1-41af-91ab-2d7cd011db47", account.Data.NetworkRuleSet.ResourceAccessRules[1].TenantId.ToString());
            Assert.AreEqual("/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount2", account.Data.NetworkRuleSet.ResourceAccessRules[1].ResourceId.ToString());

            //delete vnet
            updateParameters = new StorageAccountPatch
            {
                NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Allow) { }
            };
            account = await account.UpdateAsync(updateParameters);

            //validate
            account = await account.GetAsync();
            Assert.NotNull(account.Data.NetworkRuleSet);
            Assert.AreEqual(@"Logging, Metrics", account.Data.NetworkRuleSet.Bypass.ToString());
            Assert.AreEqual(StorageNetworkDefaultAction.Allow, account.Data.NetworkRuleSet.DefaultAction);
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
            parameters.KeyPolicy = new StorageAccountKeyPolicy(2);
            parameters.SasPolicy = new StorageAccountSasPolicy("2.02:03:59", ExpirationAction.Log);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;
            Assert.AreEqual(2, account.Data.KeyPolicy.KeyExpirationPeriodInDays);
            Assert.AreEqual("2.02:03:59", account.Data.SasPolicy.SasExpirationPeriod);

            //update storage account type
            var updateParameters = new StorageAccountPatch()
            {
                Kind = StorageKind.StorageV2,
                EnableHttpsTrafficOnly = true,
                KeyPolicy = new StorageAccountKeyPolicy(9),
                SasPolicy = new StorageAccountSasPolicy("0.02:03:59", ExpirationAction.Block),
            };
            account = await account.UpdateAsync(updateParameters);

            //validate
            Assert.AreEqual(9, account.Data.KeyPolicy.KeyExpirationPeriodInDays);
            Assert.AreEqual("0.02:03:59", account.Data.SasPolicy.SasExpirationPeriod);
            Assert.AreEqual(ExpirationAction.Block, account.Data.SasPolicy.ExpirationAction);
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
            string location;
            do
            {
                account = await account.GetAsync(expand: StorageAccountExpand.GeoReplicationStats);
                Assert.AreEqual(StorageSkuName.StandardRagrs, account.Data.Sku.Name);
                Assert.Null(account.Data.IsFailoverInProgress);
                location = account.Data.SecondaryLocation;

                //Don't need sleep when playback, or Unit test will be very slow. Need sleep when record.
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
            } while ((account.Data.GeoReplicationStats.CanFailover != true) && (i-- > 0));

            await account.FailoverAsync(WaitUntil.Completed);

            account = await account.GetAsync();

            Assert.AreEqual(StorageSkuName.StandardLrs, account.Data.Sku.Name);
            Assert.AreEqual(location, account.Data.PrimaryLocation?.ToString());
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountSoftFailOver()
        {
            //create an account with network rule set
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            ResourceGroupResource resourceGroup1 = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = resourceGroup1.GetStorageAccounts();
            StorageAccountCreateOrUpdateContent parameters = GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2, sku: new StorageSku(StorageSkuName.StandardRagrs), location: "eastus2euap");
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;
            int i = 100;
            string location;
            do
            {
                account = await account.GetAsync(expand: StorageAccountExpand.GeoReplicationStats);
                Assert.AreEqual(StorageSkuName.StandardRagrs, account.Data.Sku.Name);
                Assert.Null(account.Data.IsFailoverInProgress);
                location = account.Data.SecondaryLocation;

                //Don't need sleep when playback, or Unit test will be very slow. Need sleep when record.
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
            } while ((account.Data.GeoReplicationStats.CanFailover != true) && (i-- > 0));

            await account.FailoverAsync(WaitUntil.Completed, StorageAccountFailoverType.Planned);

            account = await account.GetAsync();

            Assert.AreEqual(StorageSkuName.StandardRagrs, account.Data.Sku.Name);
            Assert.AreEqual(location, account.Data.PrimaryLocation?.ToString());
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
            parameters.AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.Aadds);
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters)).Value;

            //validate
            account = await account.GetAsync();
            Assert.AreEqual(DirectoryServiceOption.Aadds, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            //Update storage account
            var updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.None),
                EnableHttpsTrafficOnly = true
            };
            account = await account.UpdateAsync(updateParameters);
            Assert.AreEqual(DirectoryServiceOption.None, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            // Validate
            account = await account.GetAsync();
            Assert.AreEqual(DirectoryServiceOption.None, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountUpdateWithCreateTest()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            Assert.AreEqual(accountName, account.Id.Name);

            // Update storage account type
            var data = GetDefaultStorageAccountParameters(new StorageSku(StorageSkuName.StandardLrs));
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data)).Value;
            Assert.AreEqual(StorageSkuName.StandardLrs, account.Data.Sku.Name);

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.AreEqual(StorageSkuName.StandardLrs, account.Data.Sku.Name);

            // Update storage tags
            data = new StorageAccountCreateOrUpdateContent(DefaultSkuNameStandardGRS, DefaultKindStorage, DefaultLocationString)
            {
                Tags = {
                        {"key3","value3"},
                        {"key4","value4"},
                        {"key5","value6"}
                    }
            };
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data)).Value;
            Assert.AreEqual(account.Data.Tags.Count, 3);

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.AreEqual(account.Data.Tags.Count, 3);

            // Update storage encryption
            data = new StorageAccountCreateOrUpdateContent(DefaultSkuNameStandardGRS, DefaultKindStorage, DefaultLocationString)
            {
                Encryption = new StorageAccountEncryption()
                {
                    Services = new StorageAccountEncryptionServices()
                    {
                        Blob = new StorageEncryptionService() { IsEnabled = true },
                        File = new StorageEncryptionService() { IsEnabled = true }
                    },
                    KeySource = StorageAccountKeySource.Storage
                }
            };

            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data)).Value;
            Assert.NotNull(account.Data.Encryption);

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.NotNull(account.Data.Encryption);
            Assert.NotNull(account.Data.Encryption.Services.Blob);
            Assert.IsTrue(account.Data.Encryption.Services.Blob.IsEnabled);
            Assert.NotNull(account.Data.Encryption.Services.Blob.LastEnabledOn);

            Assert.NotNull(account.Data.Encryption.Services.File);
            Assert.IsTrue(account.Data.Encryption.Services.File.IsEnabled);
            Assert.NotNull(account.Data.Encryption.Services.File.LastEnabledOn);

            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.IsEnabled.HasValue)
                {
                    Assert.IsFalse(account.Data.Encryption.Services.Table.LastEnabledOn.HasValue);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.IsEnabled.HasValue)
                {
                    Assert.IsFalse(account.Data.Encryption.Services.Queue.LastEnabledOn.HasValue);
                }
            }

            // Update storage custom domains
            data = new StorageAccountCreateOrUpdateContent(DefaultSkuNameStandardGRS, DefaultKindStorage, DefaultLocationString)
            {
                CustomDomain = new StorageCustomDomain("foo.example.com")
                {
                    IsUseSubDomainNameEnabled = true
                }
            };

            try
            {
                //should fail
                await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data);
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
        public async Task StorageAccountLocationUsageTest()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters())).Value;
            Assert.AreEqual(accountName, account.Id.Name);

            var usages = await DefaultSubscription.GetUsagesByLocationAsync(DefaultLocation).ToEnumerableAsync();
            Assert.AreEqual(1, usages.Count());
            Assert.AreEqual(StorageUsageUnit.Count, usages.First().Unit);
            Assert.NotNull(usages.First().CurrentValue);
            Assert.AreEqual(250, usages.First().Limit);
            Assert.NotNull(usages.First().Name);
            Assert.AreEqual("StorageAccounts", usages.First().Name.Value);
            Assert.AreEqual("Storage Accounts", usages.First().Name.LocalizedValue);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountHNFSMigration()
        {
            //create storage account
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(kind: StorageKind.StorageV2))).Value;
            Assert.AreEqual(accountName, account.Id.Name);

            await account.EnableHierarchicalNamespaceAsync(WaitUntil.Completed, "HnsOnValidationRequest");
            await account.EnableHierarchicalNamespaceAsync(WaitUntil.Completed, "HnsOnHydrationRequest");

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.IsTrue(account.Data.IsHnsEnabled);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountLevelVLW_publicnetworkaccess_defaultToOAuthAuthentication()
        {
            //create storage account 1
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            var parameters1 = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                DefaultLocation
                )
            {
                PublicNetworkAccess = StoragePublicNetworkAccess.SecuredByPerimeter,
                IsDefaultToOAuthAuthentication = true,
                ImmutableStorageWithVersioning = new ImmutableStorageAccount() { IsEnabled = false }
            };
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters1)).Value;
            Assert.AreEqual(accountName1, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.IsFalse(account1.Data.ImmutableStorageWithVersioning.IsEnabled);
            Assert.IsNull(account1.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy);
            Assert.IsTrue(account1.Data.IsDefaultToOAuthAuthentication);
            Assert.AreEqual(StoragePublicNetworkAccess.SecuredByPerimeter, account1.Data.PublicNetworkAccess);

            // Create storage account 2
            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            var parameters2 = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                DefaultLocation
                )
            {
                PublicNetworkAccess = StoragePublicNetworkAccess.Enabled,
                IsDefaultToOAuthAuthentication = true,
                ImmutableStorageWithVersioning = new ImmutableStorageAccount()
                {
                    IsEnabled = true,
                    ImmutabilityPolicy = new AccountImmutabilityPolicy()
                    {
                        ImmutabilityPeriodSinceCreationInDays = 1,
                        State = AccountImmutabilityPolicyState.Unlocked,
                        AllowProtectedAppendWrites = true
                    }
                }
            };
            StorageAccountResource account2 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, parameters2)).Value;
            Assert.AreEqual(accountName2, account2.Id.Name);
            VerifyAccountProperties(account2, false);
            Assert.IsTrue(account2.Data.ImmutableStorageWithVersioning.IsEnabled);
            Assert.AreEqual(1, account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(AccountImmutabilityPolicyState.Unlocked, account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.State);
            Assert.IsTrue(account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites);
            Assert.IsTrue(account2.Data.IsDefaultToOAuthAuthentication);
            Assert.AreEqual(StoragePublicNetworkAccess.Enabled, account2.Data.PublicNetworkAccess);

            //Update account 2
            var parameter = new StorageAccountPatch()
            {
                ImmutableStorageWithVersioning = new ImmutableStorageAccount() { IsEnabled = true }
            };
            account2 = (await account2.UpdateAsync(parameter)).Value;
            VerifyAccountProperties(account2, false);
            Assert.IsTrue(account2.Data.ImmutableStorageWithVersioning.IsEnabled);
            Assert.IsTrue(account2.Data.IsDefaultToOAuthAuthentication);
            Assert.AreEqual(StoragePublicNetworkAccess.Enabled, account2.Data.PublicNetworkAccess);

            parameter = new StorageAccountPatch()
            {
                PublicNetworkAccess = StoragePublicNetworkAccess.Disabled,
                IsDefaultToOAuthAuthentication = false,
                ImmutableStorageWithVersioning = new ImmutableStorageAccount()
                {
                    IsEnabled = true,
                    ImmutabilityPolicy = new AccountImmutabilityPolicy()
                    {
                        ImmutabilityPeriodSinceCreationInDays = 2,
                        State = AccountImmutabilityPolicyState.Unlocked,
                        AllowProtectedAppendWrites = false
                    }
                }
            };
            account2 = (await account2.UpdateAsync(parameter)).Value;
            VerifyAccountProperties(account2, false);
            Assert.IsTrue(account2.Data.ImmutableStorageWithVersioning.IsEnabled);
            Assert.AreEqual(2, account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays);
            Assert.AreEqual(AccountImmutabilityPolicyState.Unlocked, account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.State);
            Assert.IsFalse(account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites);
            Assert.IsFalse(account2.Data.IsDefaultToOAuthAuthentication);
            Assert.AreEqual(StoragePublicNetworkAccess.Disabled, account2.Data.PublicNetworkAccess);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountAllowedCopyScope()
        {
            //create storage account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var parameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                DefaultLocation
                )
            {
                AllowedCopyScope = AllowedCopyScope.Aad
            };
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            VerifyAccountProperties(account, false);
            Assert.AreEqual(AllowedCopyScope.Aad, account.Data.AllowedCopyScope);

            //Update account
            var patch = new StorageAccountPatch()
            {
                AllowedCopyScope = AllowedCopyScope.PrivateLink
            };
            account = await account.UpdateAsync(patch);
            VerifyAccountProperties(account, false);
            Assert.AreEqual(AllowedCopyScope.PrivateLink, account.Data.AllowedCopyScope);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountSFTP_LocalUser()
        {
            // Create resource group
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            // Create storage account
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            var parameters1 = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                "eastus2euap"
                )
            {
                IsSftpEnabled = true,
                IsLocalUserEnabled = true,
                IsHnsEnabled = true,
                // IsExtendedGroupEnabled = true,
            };
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters1)).Value;
            Assert.AreEqual(accountName1, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.IsTrue(account1.Data.IsSftpEnabled);
            Assert.IsTrue(account1.Data.IsLocalUserEnabled);
            //Assert.IsTrue(account1.Data.IsExtendedGroupEnabled);

            //Update account
            var parameter = new StorageAccountPatch()
            {
                IsSftpEnabled = false,
                IsLocalUserEnabled = false,
                // IsExtendedGroupEnabled = false,
            };
            account1 = (await account1.UpdateAsync(parameter)).Value;
            VerifyAccountProperties(account1, false);
            Assert.IsFalse(account1.Data.IsSftpEnabled);
            Assert.IsFalse(account1.Data.IsLocalUserEnabled);
            //Assert.IsFalse(account1.Data.IsExtendedGroupEnabled);

            parameter = new StorageAccountPatch()
            {
                IsLocalUserEnabled = true,
                //IsExtendedGroupEnabled = true,
            };
            account1 = (await account1.UpdateAsync(parameter)).Value;
            VerifyAccountProperties(account1, false);
            Assert.IsFalse(account1.Data.IsSftpEnabled);
            Assert.IsTrue(account1.Data.IsLocalUserEnabled);
            //Assert.IsTrue(account1.Data.IsExtendedGroupEnabled);

            parameter = new StorageAccountPatch()
            {
                IsSftpEnabled = true
            };
            account1 = (await account1.UpdateAsync(parameter)).Value;
            VerifyAccountProperties(account1, false);
            Assert.IsTrue(account1.Data.IsSftpEnabled);
            Assert.IsTrue(account1.Data.IsLocalUserEnabled);

            // Create Local user 1
            var userCollection = account1.GetStorageAccountLocalUsers();
            string userName1 = Recording.GenerateAssetName("user1");
            var data = new StorageAccountLocalUserData()
            {
                HomeDirectory = "/"
            };
            var user1 = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName1, data)).Value;
            Assert.AreEqual(userName1, user1.Data.Name);
            Assert.AreEqual("/", user1.Data.HomeDirectory);
            Assert.IsNull(user1.Data.HasSharedKey);
            Assert.IsNull(user1.Data.HasSshKey);
            Assert.IsNull(user1.Data.HasSshPassword);

            // Create Local user 2
            string userName2 = Recording.GenerateAssetName("user2");
            data = new StorageAccountLocalUserData()
            {
                PermissionScopes = { new StoragePermissionScope("rw", "blob", "container1"), new StoragePermissionScope("rwd", "file", "share1") },
                HomeDirectory = "/dir1/",
                SshAuthorizedKeys = {
                    new StorageSshPublicKey() { Description = "key1 description", Key = "ssh-rsa keykeykeykeykey=" },
                    new StorageSshPublicKey() { Description = "key2 description", Key = "ssh-rsa keykeykeykeykey=" }
                },
                HasSharedKey = true,
                HasSshKey = true,
                HasSshPassword = true
            };
            var user2 = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName2, data)).Value;
            Assert.AreEqual(userName2, user2.Data.Name);
            Assert.AreEqual("/dir1/", user2.Data.HomeDirectory);
            Assert.AreEqual(2, user2.Data.PermissionScopes.Count);
            Assert.AreEqual(2, user2.Data.SshAuthorizedKeys.Count);
            Assert.IsTrue(user2.Data.HasSharedKey);
            Assert.IsTrue(user2.Data.HasSshKey);
            Assert.IsTrue(user2.Data.HasSshPassword);

            // Create Local user 3
            string userName3 = Recording.GenerateAssetName("user3");
            data = new StorageAccountLocalUserData()
            {
                HomeDirectory = "/",
                GroupId = 2000,
                IsAclAuthorizationAllowed = true,
            };
            var user3 = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName3, data)).Value;
            Assert.AreEqual(userName3, user3.Data.Name);
            Assert.AreEqual("/", user3.Data.HomeDirectory);
            Assert.IsNull(user3.Data.HasSharedKey);
            Assert.IsNull(user3.Data.HasSshKey);
            Assert.IsNull(user3.Data.HasSshPassword);
            Assert.AreEqual(data.GroupId, user3.Data.GroupId);
            Assert.AreEqual(data.IsAclAuthorizationAllowed, user3.Data.IsAclAuthorizationAllowed);
            Assert.NotNull(user3.Data.UserId);

            // Create Local user 4
            string userName4 = Recording.GenerateAssetName("user4");
            data = new StorageAccountLocalUserData()
            {
                HomeDirectory = "/",
                //ExtendedGroups = { 1001, 1005 },
                //IsNfsV3Enabled = true,
            };
            var user4 = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName4, data)).Value;
            Assert.AreEqual(userName4, user4.Data.Name);
            Assert.AreEqual("/", user4.Data.HomeDirectory);
            Assert.IsNull(user4.Data.HasSharedKey);
            Assert.IsNull(user4.Data.HasSshKey);
            Assert.IsNull(user4.Data.HasSshPassword);
            Assert.AreEqual(data.ExtendedGroups, user3.Data.ExtendedGroups);
            Assert.AreEqual(data.IsNfsV3Enabled, user3.Data.IsNfsV3Enabled);

            // List all local user
            var users = await userCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(4, users.Count);

            // List with filter
            users = await userCollection.GetAllAsync(filter: "startswith(name, user3)").ToEnumerableAsync();
            Assert.AreEqual(1, users.Count);
            Assert.AreEqual(userName3, users.First().Data.Name);

            // List with include
            //users = await userCollection.GetAllAsync(include: ListLocalUserIncludeParam.Nfsv3).ToEnumerableAsync();
            //Assert.AreEqual(1, users.Count);
            //Assert.AreEqual(userName4, users.First().Data.Name);

            // List with maxpagesize & nextlink
            users = await userCollection.GetAllAsync(maxpagesize: 3).ToEnumerableAsync();
            Assert.AreEqual(4, users.Count);

            // Get Single local user
            user1 = (await userCollection.GetAsync(userName1)).Value;
            Assert.AreEqual(userName1, user1.Data.Name);
            Assert.AreEqual("/", user1.Data.HomeDirectory);
            Assert.IsFalse(user1.Data.HasSharedKey);
            Assert.IsFalse(user1.Data.HasSshKey);
            Assert.IsFalse(user1.Data.HasSshPassword);
            user2 = (await userCollection.GetAsync(userName2)).Value;
            Assert.AreEqual(userName2, user2.Data.Name);
            Assert.AreEqual("/dir1/", user2.Data.HomeDirectory);
            Assert.AreEqual(2, user2.Data.PermissionScopes.Count);
            Assert.IsEmpty(user2.Data.SshAuthorizedKeys);
            Assert.IsTrue(user2.Data.HasSharedKey);
            Assert.IsTrue(user2.Data.HasSshKey);
            Assert.IsFalse(user2.Data.HasSshPassword);

            // Get Key on local user
            var keys = (await user2.GetKeysAsync()).Value;
            Assert.NotNull(keys.SharedKey);
            Assert.AreEqual(2, keys.SshAuthorizedKeys.Count);

            // re-generate sshPassword on local user
            LocalUserRegeneratePasswordResult regeneratePasswordResult = (await user2.RegeneratePasswordAsync()).Value;
            Assert.NotNull(regeneratePasswordResult.SshPassword);

            //Remove Localuser
            await user1.DeleteAsync(WaitUntil.Completed);
            users = await userCollection.GetAllAsync().ToEnumerableAsync();
            Assert.AreEqual(3, users.Count);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountPremiumAccesstier()
        {
            //create storage account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var parameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                DefaultLocation
                )
            {
                AccessTier = StorageAccountAccessTier.Hot
            };
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(StorageAccountAccessTier.Hot, account.Data.AccessTier);

            //Update account
            var patch = new StorageAccountPatch()
            {
                AccessTier = StorageAccountAccessTier.Premium
            };
            account = await account.UpdateAsync(patch);
            Assert.AreEqual(StorageAccountAccessTier.Premium, account.Data.AccessTier);
        }

        [Test]
        [RecordedTest]
        [Ignore("Feature not available on public cloud")]
        public async Task StorageAccountDnsEndpointType()
        {
            //create storage account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var parameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                DefaultLocation
                )
            {
                DnsEndpointType = StorageDnsEndpointType.AzureDnsZone
            };
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(StorageDnsEndpointType.AzureDnsZone, account.Data.DnsEndpointType);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountCreateSetGetFileAAdKERB()
        {
            //create storage account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            string domainName = "testaadkerb.com";
            var domainId = new Guid("aebfc118-1111-1111-1111-d98e41a77cd5");
            var data = new FilesIdentityBasedAuthentication(DirectoryServiceOption.Aadkerb)
            {
                ActiveDirectoryProperties = new StorageActiveDirectoryProperties(domainName, domainId)
            };
            var parameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                DefaultLocation
                )
            {
                AzureFilesIdentityBasedAuthentication = data
            };
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(DirectoryServiceOption.Aadkerb, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);
            Assert.AreEqual(domainName, account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainName);
            Assert.AreEqual(domainId, account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainGuid);

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.AreEqual(DirectoryServiceOption.Aadkerb, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);
            Assert.AreEqual(domainName, account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainName);
            Assert.AreEqual(domainId, account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainGuid);

            // Update storage account to None
            var updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.None)
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.AreEqual(DirectoryServiceOption.None, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            // Update storage account to AADKERB
            updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.Aadkerb)
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.AreEqual(DirectoryServiceOption.Aadkerb, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.AreEqual(DirectoryServiceOption.Aadkerb, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);

            // Update storage account to AADKERB + properties
            updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = data
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.AreEqual(DirectoryServiceOption.Aadkerb, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);
            Assert.AreEqual(domainName, account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainName);
            Assert.AreEqual(domainId, account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainGuid);

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.AreEqual(DirectoryServiceOption.Aadkerb, account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions);
            Assert.AreEqual(domainName, account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainName);
            Assert.AreEqual(domainId, account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainGuid);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountCreateSetGetFileSmbOauth()
        {
            //create storage account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var data = new FilesIdentityBasedAuthentication(DirectoryServiceOption.None)
            {
                IsSmbOAuthEnabled = true,
            };
            var parameters = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardLrs),
                StorageKind.StorageV2,
                "centraluseuap"
                )
            {
                AzureFilesIdentityBasedAuthentication = data
            };
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.AreEqual(account.Data.AzureFilesIdentityBasedAuthentication.IsSmbOAuthEnabled, true);

            // Update storage account to None
            var updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.None)
                {
                    IsSmbOAuthEnabled = false,
                }
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.AreEqual(account.Data.AzureFilesIdentityBasedAuthentication.IsSmbOAuthEnabled, false);
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountCreateGetSetZonePlacementPolicy()
        {
            //create storage account
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            var parameters1 = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.PremiumLrs),
                StorageKind.FileStorage,
                "centraluseuap"
                )
            {
                Zones = { "1" },
            };
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters1)).Value;
            Assert.AreEqual(account1.Data.Zones[0], "1");

            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            var parameters2 = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.PremiumLrs),
                StorageKind.FileStorage,
                "centraluseuap"
                )
            {
                ZonePlacementPolicy = StorageAccountZonePlacementPolicy.Any,
            };
            StorageAccountResource account2 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, parameters2)).Value;
            Assert.AreEqual(account2.Data.ZonePlacementPolicy, StorageAccountZonePlacementPolicy.Any);

            // Update storage account to None
            var updateParameters1 = new StorageAccountPatch
            {
                ZonePlacementPolicy = StorageAccountZonePlacementPolicy.None,
            };

            account2 = (await account2.UpdateAsync(updateParameters1)).Value;
            Assert.AreEqual(account2.Data.ZonePlacementPolicy, StorageAccountZonePlacementPolicy.None);

            string accountName3 = await CreateValidAccountNameAsync(namePrefix);
            var parameters3 = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.PremiumLrs),
                StorageKind.FileStorage,
                "centraluseuap"
                );
            var account3 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName3, parameters3)).Value;
            Assert.AreEqual(account3.Data.Zones.Count, 0);

            var updateParameters2 = new StorageAccountPatch
            {
                Zones = {"1"}
            };
            account3 = (await account3.UpdateAsync(updateParameters2)).Value;
            Assert.AreEqual(account3.Data.Zones[0], "1");
        }
    }
}
