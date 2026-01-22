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
            Assert.That(apiList.Count() > 1, Is.True);
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
            Assert.That(exist1, Is.True);
            Assert.That(exist2, Is.True);
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
            Assert.That(skulist, Is.Not.Null);
            Assert.That(skulist.ElementAt(0).ResourceType, Is.EqualTo(@"storageAccounts"));
            Assert.That(skulist.ElementAt(0).Name, Is.Not.Null);
            Assert.That(skulist.ElementAt(0).Name.Equals(StorageSkuName.PremiumLrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardGrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardLrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardRagrs)
                || skulist.ElementAt(0).Name.Equals(StorageSkuName.StandardZrs), Is.True);
            Assert.That(skulist.ElementAt(0).Kind, Is.Not.Null);
            Assert.That(skulist.ElementAt(0).Kind.Equals(StorageKind.BlobStorage) || skulist.ElementAt(0).Kind.Equals(StorageKind.Storage) || skulist.ElementAt(0).Kind.Equals(StorageKind.StorageV2) || skulist.ElementAt(0).Kind.Equals(StorageKind.BlockBlobStorage), Is.True);
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
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
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
            Assert.That(exception.Status, Is.EqualTo(404));
            Assert.That((bool)await storageAccountCollection.ExistsAsync(accountName), Is.True);
            Assert.That((bool)await storageAccountCollection.ExistsAsync(accountName + "1"), Is.False);

            //delete storage account
            await account1.DeleteAsync(WaitUntil.Completed);

            // Delete an account which was just deleted
            await account1.DeleteAsync(WaitUntil.Completed);

            //validate if deleted successfully
            Assert.That((bool)await storageAccountCollection.ExistsAsync(accountName), Is.False);
            exception = Assert.ThrowsAsync<RequestFailedException>(async () => { await storageAccountCollection.GetAsync(accountName); });
            Assert.That(exception.Status, Is.EqualTo(404));

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
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity, Is.Null);

            //create a Grs storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardGrs)))).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, true);

            //create a RAGrs storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardRagrs)))).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);

            //create a ZRS storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardZrs)))).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
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
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);

            //create a blob Grs storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage, sku: new StorageSku(StorageSkuName.StandardGrs));
            parameters.AccessTier = StorageAccountAccessTier.Hot;
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);

            //create a blob RAGrs storage account
            accountName = await CreateValidAccountNameAsync(namePrefix);
            parameters = GetDefaultStorageAccountParameters(kind: StorageKind.BlobStorage, sku: new StorageSku(StorageSkuName.StandardRagrs));
            parameters.AccessTier = StorageAccountAccessTier.Hot;
            account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
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
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
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
            Assert.That(count, Is.EqualTo(2));
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
            Assert.That(StorageSkuName.StandardLrs, Is.EqualTo(account1.Data.Sku.Name));

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(StorageSkuName.StandardLrs, Is.EqualTo(account2.Data.Sku.Name));

            //update tags
            parameters.Tags.Clear();
            parameters.Tags.Add("key3", "value3");
            parameters.Tags.Add("key4", "value4");
            parameters.Tags.Add("key5", "value5");
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(parameters.Tags.Count, Is.EqualTo(account1.Data.Tags.Count));

            //validate
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(parameters.Tags.Count, Is.EqualTo(account2.Data.Tags.Count));

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
            Assert.That(account1.Data.Encryption, Is.Not.Null);

            //validate
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Encryption, Is.Not.Null);
            Assert.That(account2.Data.Encryption.Services.Blob, Is.Not.Null);
            Assert.That(account2.Data.Encryption.Services.Blob.IsEnabled, Is.True);
            Assert.That(account2.Data.Encryption.Services.Blob.LastEnabledOn, Is.Not.Null);
            Assert.That(account2.Data.Encryption.Services.File, Is.Not.Null);
            Assert.That(account2.Data.Encryption.Services.File.IsEnabled, Is.True);
            Assert.That(account2.Data.Encryption.Services.File.LastEnabledOn, Is.Not.Null);

            //update http traffic only and validate
            parameters = new StorageAccountPatch()
            {
                EnableHttpsTrafficOnly = false
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.EnableHttpsTrafficOnly, Is.EqualTo(false));
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.EnableHttpsTrafficOnly, Is.EqualTo(false));
            parameters = new StorageAccountPatch()
            {
                EnableHttpsTrafficOnly = true
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.EnableHttpsTrafficOnly, Is.EqualTo(true));
            account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.EnableHttpsTrafficOnly, Is.EqualTo(true));
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
                Assert.That(ex.Status, Is.EqualTo(409));
                Assert.That(ex.ErrorCode, Is.EqualTo("StorageDomainNameCouldNotVerify"));
                Assert.That(ex.Message != null && ex.Message.StartsWith("The custom domain " +
                        "name could not be verified. CNAME mapping from foo.example.com to "), Is.True);
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
            Assert.That(account1.Data.Kind, Is.EqualTo(StorageKind.StorageV2));
            Assert.That(account1.Data.EnableHttpsTrafficOnly, Is.True);
            Assert.That(account1.Data.PrimaryEndpoints.WebUri, Is.Not.Null);
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
            Assert.That(account1.Data.AllowSharedKeyAccess, Is.False);

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
            Assert.That(account1.Data.AllowSharedKeyAccess, Is.True);

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
            Assert.That(account1.Data.AllowSharedKeyAccess, Is.False);
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
            Assert.That(account1.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardLrs));
            Assert.That(account1.Data.Tags.Count, Is.EqualTo(parameters.Tags.Count));

            account1 = await account1.GetAsync();
            Assert.That(account1.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardLrs));
            Assert.That(account1.Data.Tags.Count, Is.EqualTo(parameters.Tags.Count));
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
            Assert.That(account1.Data.Encryption, Is.Not.Null);

            // Validate
            account1 = await account1.GetAsync();
            Assert.That(account1.Data.Encryption, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.Blob, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.Blob.IsEnabled, Is.True);
            Assert.That(account1.Data.Encryption.Services.Blob.LastEnabledOn, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.File, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.File.IsEnabled, Is.True);
            Assert.That(account1.Data.Encryption.Services.File.LastEnabledOn, Is.Not.Null);

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
            Assert.That(account1.Data.Encryption, Is.Not.Null);

            // Validate
            account1 = await account1.GetAsync();
            Assert.That(account1.Data.Encryption, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.Blob, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.Blob.IsEnabled, Is.True);
            Assert.That(account1.Data.Encryption.Services.Blob.LastEnabledOn, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.File, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.File.IsEnabled, Is.True);
            Assert.That(account1.Data.Encryption.Services.File.LastEnabledOn, Is.Not.Null);

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
            Assert.That(account1.Data.Encryption, Is.Not.Null);

            // Validate
            account1 = await account1.GetAsync();
            Assert.That(account1.Data.Encryption, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.Blob, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.Blob.IsEnabled, Is.True);
            Assert.That(account1.Data.Encryption.Services.Blob.LastEnabledOn, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.File, Is.Not.Null);
            Assert.That(account1.Data.Encryption.Services.File.IsEnabled, Is.True);
            Assert.That(account1.Data.Encryption.Services.File.LastEnabledOn, Is.Not.Null);
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
            Assert.That(accounts.Count, Is.EqualTo(1));
            StorageAccountResource account = accounts[0];
            Assert.That(account.Data.Encryption, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Blob, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Blob.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.Blob.LastEnabledOn, Is.Not.Null);

            Assert.That(account.Data.Encryption.Services.File, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.File.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.File.LastEnabledOn, Is.Not.Null);

            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.IsEnabled.HasValue)
                {
                    Assert.That(account.Data.Encryption.Services.Table.LastEnabledOn.HasValue, Is.False);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.IsEnabled.HasValue)
                {
                    Assert.That(account.Data.Encryption.Services.Queue.LastEnabledOn.HasValue, Is.False);
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
            Assert.That(shareData.ShareQuota, Is.EqualTo(share.Data.ShareQuota));
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
            Assert.That(keys, Is.Not.Null);

            // Validate Key1
            StorageAccountKey key1 = keys.First(
                t => t.KeyName.Equals("key1", StringComparison.OrdinalIgnoreCase));
            Assert.That(key1, Is.Not.Null);
            Assert.That(key1.Permissions, Is.EqualTo(StorageAccountKeyPermission.Full));
            Assert.That(key1.Value, Is.Not.Null);

            // Validate Key2
            StorageAccountKey key2 = keys.First(
                t => t.KeyName.Equals("key2", StringComparison.OrdinalIgnoreCase));
            Assert.That(key2, Is.Not.Null);
            Assert.That(key2.Permissions, Is.EqualTo(StorageAccountKeyPermission.Full));
            Assert.That(key2.Value, Is.Not.Null);

            //regenerate key and verify the key's change
            StorageAccountRegenerateKeyContent keyParameters = new StorageAccountRegenerateKeyContent("key2");
            var regenKeys = await account1.RegenerateKeyAsync(keyParameters).ToEnumerableAsync();
            StorageAccountKey regenKey2 = regenKeys.First(
                t => t.KeyName.Equals("key2", StringComparison.OrdinalIgnoreCase));
            Assert.That(regenKey2, Is.Not.Null);

            //validate the key is different from origin one
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.That(regenKey2.Value, Is.Not.EqualTo(key2.Value));
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
            Assert.That(accountData.NetworkRuleSet, Is.Not.Null);
            Assert.That(accountData.NetworkRuleSet.Bypass.ToString(), Is.EqualTo(@"Logging, AzureServices"));
            Assert.That(accountData.NetworkRuleSet.DefaultAction, Is.EqualTo(StorageNetworkDefaultAction.Deny));
            Assert.That(accountData.NetworkRuleSet.VirtualNetworkRules, Is.Empty);
            Assert.That(accountData.NetworkRuleSet.IPRules, Is.Not.Null);
            Assert.That(accountData.NetworkRuleSet.IPRules, Is.Not.Empty);
            Assert.That(accountData.NetworkRuleSet.IPRules[0].IPAddressOrRange, Is.EqualTo("23.45.67.89"));
            Assert.That(accountData.NetworkRuleSet.IPRules[0].Action, Is.EqualTo(StorageAccountNetworkRuleAction.Allow));

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
            Assert.That(accountData.NetworkRuleSet, Is.Not.Null);
            Assert.That(accountData.NetworkRuleSet.Bypass.ToString(), Is.EqualTo(@"Logging, Metrics"));
            Assert.That(accountData.NetworkRuleSet.DefaultAction, Is.EqualTo(StorageNetworkDefaultAction.Deny));
            Assert.That(accountData.NetworkRuleSet.VirtualNetworkRules, Is.Empty);
            Assert.That(accountData.NetworkRuleSet.IPRules, Is.Not.Null);
            Assert.That(accountData.NetworkRuleSet.IPRules, Is.Not.Empty);
            Assert.That(accountData.NetworkRuleSet.IPRules[0].IPAddressOrRange, Is.EqualTo("23.45.67.90"));
            Assert.That(accountData.NetworkRuleSet.IPRules[0].Action, Is.EqualTo(StorageAccountNetworkRuleAction.Allow));
            Assert.That(accountData.NetworkRuleSet.IPRules[1].IPAddressOrRange, Is.EqualTo("23.45.67.91"));
            Assert.That(accountData.NetworkRuleSet.IPRules[1].Action, Is.EqualTo(StorageAccountNetworkRuleAction.Allow));

            //update network rule to allow
            updateParameters = new StorageAccountPatch()
            {
                NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Allow)
            };
            StorageAccountResource account3 = await account2.UpdateAsync(updateParameters);

            //verify updated network rule
            accountData = account3.Data;
            Assert.That(accountData.NetworkRuleSet, Is.Not.Null);
            Assert.That(accountData.NetworkRuleSet.Bypass.ToString(), Is.EqualTo(@"Logging, Metrics"));
            Assert.That(accountData.NetworkRuleSet.DefaultAction, Is.EqualTo(StorageNetworkDefaultAction.Allow));
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
            Assert.That(account1.Data.Kind, Is.EqualTo(StorageKind.BlockBlobStorage));
            Assert.That(account1.Data.Sku.Name, Is.EqualTo(StorageSkuName.PremiumLrs));
            //this storage account should only have endpoints on blob and dfs
            Assert.That(account1.Data.PrimaryEndpoints.BlobUri, Is.Not.Null);
            Assert.That(account1.Data.PrimaryEndpoints.DfsUri, Is.Not.Null);
            Assert.That(account1.Data.PrimaryEndpoints.FileUri, Is.Null);
            Assert.That(account1.Data.PrimaryEndpoints.TableUri, Is.Null);
            Assert.That(account1.Data.PrimaryEndpoints.QueueUri, Is.Null);
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
            Assert.That(account1.Data.LargeFileSharesState, Is.EqualTo(LargeFileSharesState.Enabled));
            Assert.That(account1.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardLrs));
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
            Assert.That(account1.Data.PrimaryEndpoints.DfsUri, Is.Not.Null);
            Assert.That(account1.Data.IsHnsEnabled, Is.True);
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
            Assert.That(account1.Data.Kind, Is.EqualTo(StorageKind.FileStorage));
            Assert.That(account1.Data.Sku.Name, Is.EqualTo(StorageSkuName.PremiumLrs));
            //this storage account should only have endpoints on file
            Assert.That(account1.Data.PrimaryEndpoints.BlobUri, Is.Null);
            Assert.That(account1.Data.PrimaryEndpoints.DfsUri, Is.Null);
            Assert.That(account1.Data.PrimaryEndpoints.FileUri, Is.Not.Null);
            Assert.That(account1.Data.PrimaryEndpoints.TableUri, Is.Null);
            Assert.That(account1.Data.PrimaryEndpoints.QueueUri, Is.Null);
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
            Assert.That(account.Data.Encryption, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Blob, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Blob.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.Blob.LastEnabledOn, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.File, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.File.IsEnabled, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.File.LastEnabledOn, Is.Not.Null);
            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.IsEnabled.HasValue)
                {
                    Assert.That(account.Data.Encryption.Services.Table.LastEnabledOn.HasValue, Is.False);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.IsEnabled.HasValue)
                {
                    Assert.That(account.Data.Encryption.Services.Queue.LastEnabledOn.HasValue, Is.False);
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
            Assert.That(account.Data.Encryption, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Blob, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Blob.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.Blob.KeyType, Is.EqualTo(StorageEncryptionKeyType.Account));
            Assert.That(account.Data.Encryption.Services.Blob.LastEnabledOn, Is.Not.Null);

            Assert.That(account.Data.Encryption.Services.File, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.File.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.Blob.KeyType, Is.EqualTo(StorageEncryptionKeyType.Account));
            Assert.That(account.Data.Encryption.Services.File.LastEnabledOn, Is.Not.Null);

            Assert.That(account.Data.Encryption.Services.Queue, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Queue.KeyType, Is.EqualTo(StorageEncryptionKeyType.Account));
            Assert.That(account.Data.Encryption.Services.Queue.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.Queue.LastEnabledOn, Is.Not.Null);

            Assert.That(account.Data.Encryption.Services.Table, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Table.KeyType, Is.EqualTo(StorageEncryptionKeyType.Account));
            Assert.That(account.Data.Encryption.Services.Table.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.Table.LastEnabledOn, Is.Not.Null);
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
            Assert.That(account.Data.Kind, Is.EqualTo(StorageKind.StorageV2));
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
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Hot));
            Assert.That(account.Data.Kind, Is.EqualTo(StorageKind.BlobStorage));

            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                AccessTier = StorageAccountAccessTier.Cool
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Cool));

            //create storage account with accesstier cool, update to cool
            string accountName2 = await CreateValidAccountNameAsync(namePrefix);
            parameters.AccessTier = StorageAccountAccessTier.Cool;
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName2, parameters)).Value;

            VerifyAccountProperties(account, false);
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Cool));
            Assert.That(account.Data.Kind, Is.EqualTo(StorageKind.BlobStorage));
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
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Cool));
            Assert.That(account.Data.Kind, Is.EqualTo(StorageKind.BlobStorage));

            StorageAccountPatch updateParameters = new StorageAccountPatch()
            {
                AccessTier = StorageAccountAccessTier.Cold
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Cold));

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
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Cold));
            Assert.That(account.Data.Kind, Is.EqualTo(StorageKind.StorageV2));

            updateParameters = new StorageAccountPatch()
            {
                AccessTier = StorageAccountAccessTier.Hot
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Hot));
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
            Assert.That(account.Data.EnableHttpsTrafficOnly, Is.True);

            //create storage account with enable https only false
            accountName = await CreateValidAccountNameAsync(namePrefix);
            _resourceGroup = await CreateResourceGroupAsync();
            storageAccountCollection = _resourceGroup.GetStorageAccounts();
            parameters.EnableHttpsTrafficOnly = false;
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, parameters)).Value;

            //validate
            account = await account.GetAsync();
            VerifyAccountProperties(account, false);
            Assert.That(account.Data.EnableHttpsTrafficOnly, Is.False);
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
            Assert.That(account.Data.PrimaryEndpoints.WebUri, Is.Not.Null);
            Assert.That(account.Data.Kind, Is.EqualTo(StorageKind.StorageV2));
            Assert.That(account.Data.ExtendedLocation.ExtendedLocationType, Is.EqualTo(ExtendedLocationType.EdgeZone));
            Assert.That(account.Data.ExtendedLocation.Name, Is.EqualTo("microsoftrrdclab1"));
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
            Assert.That(account.Data.MinimumTlsVersion, Is.EqualTo(StorageMinimumTlsVersion.Tls1_3));

            //update account
            StorageAccountPatch udpateParameters = new StorageAccountPatch();
            udpateParameters.MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_2;
            udpateParameters.AllowBlobPublicAccess = true;
            udpateParameters.EnableHttpsTrafficOnly = true;
            account = await account.UpdateAsync(udpateParameters);

            //validate
            account = await account.GetAsync();
            Assert.That(account.Data.MinimumTlsVersion, Is.EqualTo(StorageMinimumTlsVersion.Tls1_2));

            //update account
            udpateParameters = new StorageAccountPatch();
            udpateParameters.MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_1;
            udpateParameters.AllowBlobPublicAccess = true;
            udpateParameters.EnableHttpsTrafficOnly = true;
            account = await account.UpdateAsync(udpateParameters);

            //validate
            account = await account.GetAsync();
            Assert.That(account.Data.MinimumTlsVersion, Is.EqualTo(StorageMinimumTlsVersion.Tls1_1));

            //update account
            udpateParameters = new StorageAccountPatch();
            udpateParameters.MinimumTlsVersion = StorageMinimumTlsVersion.Tls1_3;
            udpateParameters.AllowBlobPublicAccess = true;
            udpateParameters.EnableHttpsTrafficOnly = true;
            account = await account.UpdateAsync(udpateParameters);

            //validate
            account = await account.GetAsync();
            Assert.That(account.Data.MinimumTlsVersion, Is.EqualTo(StorageMinimumTlsVersion.Tls1_3));
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
            Assert.That(account.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardRagrs));
            Assert.That(account.Data.GeoReplicationStats, Is.Null);

            //expand
            account = await account.GetAsync(StorageAccountExpand.GeoReplicationStats);
            Assert.That(account.Data.GeoReplicationStats, Is.Not.Null);
            Assert.That(account.Data.GeoReplicationStats.Status, Is.Not.Null);
            Assert.That(account.Data.GeoReplicationStats.LastSyncOn, Is.Not.Null);
            Assert.That(account.Data.GeoReplicationStats.CanFailover, Is.Not.Null);
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
            Assert.That(locationList, Is.Not.Null);
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

            Assert.That(resultCredentials.Services, Is.EqualTo(accountSasParameters.Services));
            Assert.That(resultCredentials.ResourceTypes, Is.EqualTo(accountSasParameters.ResourceTypes));
            Assert.That(resultCredentials.Permissions, Is.EqualTo(accountSasParameters.Permissions));
            Assert.That(accountSasParameters.SharedAccessExpireOn, Is.Not.Null);
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

            Assert.That(resultCredentials.Services, Is.EqualTo(accountSasParameters.Services));
            Assert.That(resultCredentials.ResourceTypes, Is.EqualTo(accountSasParameters.ResourceTypes));
            Assert.That(resultCredentials.Permissions, Is.EqualTo(accountSasParameters.Permissions));
            Assert.That(accountSasParameters.SharedAccessExpireOn, Is.Not.Null);
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

            Assert.That(resultCredentials.Services, Is.EqualTo(accountSasParameters.Services));
            Assert.That(resultCredentials.ResourceTypes, Is.EqualTo(accountSasParameters.ResourceTypes));
            Assert.That(resultCredentials.Permissions, Is.EqualTo(accountSasParameters.Permissions));
            Assert.That(resultCredentials.Protocols, Is.EqualTo(accountSasParameters.Protocols));
            Assert.That(accountSasParameters.SharedAccessStartOn, Is.Not.Null);
            Assert.That(accountSasParameters.SharedAccessExpireOn, Is.Not.Null);
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
            Assert.That(resultCredentials.Resource, Is.EqualTo(serviceSasParameters.Resource));
            Assert.That(resultCredentials.Permissions, Is.EqualTo(serviceSasParameters.Permissions));
            Assert.That(serviceSasParameters.SharedAccessExpiryOn, Is.Not.Null);
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
                Assert.That(ex.Message.StartsWith("Values for request parameters are invalid: signedExpiry."), Is.True);
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
            Assert.That(resultCredentials.Resource, Is.EqualTo(serviceSasParameters.Resource));
            Assert.That(resultCredentials.Permissions, Is.EqualTo(serviceSasParameters.Permissions));
            Assert.That(resultCredentials.Protocols, Is.EqualTo(serviceSasParameters.Protocols));
            Assert.That(serviceSasParameters.SharedAccessStartOn, Is.Not.Null);
            Assert.That(serviceSasParameters.SharedAccessExpiryOn, Is.Not.Null);
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
            Assert.That(DefaultTags.Count + 1, Is.EqualTo(account.Data.Tags.Count));

            //remove tag
            account = await account.RemoveTagAsync("key");

            //verify the tag is removed successfully
            Assert.That(DefaultTags.Count, Is.EqualTo(account.Data.Tags.Count));
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
            Assert.That(account.Data.PrimaryEndpoints.WebUri, Is.Not.Null);
            Assert.That(account.Data.Kind, Is.EqualTo(StorageKind.StorageV2));
            Assert.That(account.Data.IsNfsV3Enabled, Is.False);
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
            Assert.That(blobInventoryPolicy.Data.PolicySchema.Rules.Count, Is.EqualTo(2));

            //update policy
            ruleList.Add(rule3);
            BlobInventoryPolicySchema policy2 = new BlobInventoryPolicySchema(true, "Inventory", ruleList);
            BlobInventoryPolicyData parameter2 = new BlobInventoryPolicyData()
            {
                PolicySchema = policy2
            };
            blobInventoryPolicy = (await blobInventoryPolicy.CreateOrUpdateAsync(WaitUntil.Completed, parameter2)).Value;
            Assert.That(blobInventoryPolicy.Data.PolicySchema.Rules.Count, Is.EqualTo(3));

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
            Assert.That(managementPolicy, Is.Not.Null);
            Assert.That(managementPolicy.Data.Policy.Rules.Count, Is.EqualTo(3));
            Assert.That(managementPolicy.Data.Rules[0].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan, Is.EqualTo(1000));
            Assert.That(managementPolicy.Data.Rules[1].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan, Is.EqualTo(1000));
            Assert.That(managementPolicy.Data.Rules[0].Definition.Filters.BlobTypes.Count, Is.EqualTo(2));
            Assert.That(managementPolicy.Data.Rules[1].Definition.Filters.BlobTypes.Count, Is.EqualTo(1));
            Assert.That(managementPolicy.Data.Rules[2].Definition.Actions.BaseBlob.Delete.DaysAfterModificationGreaterThan, Is.EqualTo(1000));
            Assert.That(managementPolicy.Data.Rules[2].Definition.Actions.BaseBlob.TierToCold.DaysAfterCreationGreaterThan, Is.EqualTo(100));
            Assert.That(managementPolicy.Data.Rules[2].Definition.Actions.BaseBlob.TierToCool.DaysAfterCreationGreaterThan, Is.EqualTo(500));
            Assert.That(managementPolicy.Data.Rules[2].Definition.Actions.Snapshot.TierToCool.DaysAfterCreationGreaterThan, Is.EqualTo(100));
            Assert.That(managementPolicy.Data.Rules[2].Definition.Actions.Snapshot.TierToCold.DaysAfterCreationGreaterThan, Is.EqualTo(500));
            Assert.That(managementPolicy.Data.Rules[2].Definition.Actions.Version.TierToArchive.DaysAfterCreationGreaterThan, Is.EqualTo(200));

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
            Assert.That(managementPolicy2.Data.Rules[0].Definition.Actions.BaseBlob.TierToHot.DaysAfterCreationGreaterThan, Is.EqualTo(50));
            Assert.That(managementPolicy2.Data.Rules[0].Definition.Actions.BaseBlob.TierToCool.DaysAfterCreationGreaterThan, Is.EqualTo(100));
            Assert.That(managementPolicy2.Data.Rules[0].Definition.Filters.BlobTypes.Count, Is.EqualTo(1));

            //delete namagement policy
            await managementPolicy.DeleteAsync(WaitUntil.Completed);
            bool dataPolicyExist = true;
            try
            {
                var policy = await account.GetStorageAccountManagementPolicy().GetAsync();
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.ErrorCode, Is.EqualTo("ManagementPolicyNotFound"));
                dataPolicyExist = false;
            }
            Assert.That(dataPolicyExist, Is.False);

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
            Assert.That(encryptionScope.Id.Name, Is.EqualTo("scope"));
            Assert.That(encryptionScope.Data.State, Is.EqualTo(EncryptionScopeState.Enabled));
            Assert.That(encryptionScope.Data.Source, Is.EqualTo(EncryptionScopeSource.Storage));

            //patch encryption scope
            encryptionScope.Data.State = EncryptionScopeState.Disabled;
            encryptionScope = await encryptionScope.UpdateAsync(encryptionScope.Data);
            Assert.That(EncryptionScopeState.Disabled, Is.EqualTo(encryptionScope.Data.State));

            EncryptionScopeResource encryptionScope2 = (await encryptionScopeCollection.CreateOrUpdateAsync(WaitUntil.Completed, "scope2", parameter)).Value;
            EncryptionScopeResource encryptionScope3 = (await encryptionScopeCollection.CreateOrUpdateAsync(WaitUntil.Completed, "testscope3", parameter)).Value;

            //get all encryption scopes
            List<EncryptionScopeResource> encryptionScopes = await encryptionScopeCollection.GetAllAsync().ToEnumerableAsync();
            encryptionScope = encryptionScopes.First();
            Assert.That(encryptionScopes.Count, Is.EqualTo(3));
            Assert.That(encryptionScope.Id.Name, Is.EqualTo("scope"));
            Assert.That(encryptionScope.Data.State, Is.EqualTo(EncryptionScopeState.Disabled));
            Assert.That(encryptionScope.Data.Source, Is.EqualTo(EncryptionScopeSource.Storage));
            Assert.That(encryptionScopes[1].Data.Name, Is.EqualTo("scope2"));
            Assert.That(encryptionScopes[1].Data.State, Is.EqualTo(EncryptionScopeState.Enabled));
            Assert.That(encryptionScopes[1].Data.Source, Is.EqualTo(EncryptionScopeSource.Storage));
            Assert.That(encryptionScopes[2].Data.Name, Is.EqualTo("testscope3"));
            Assert.That(encryptionScopes[2].Data.State, Is.EqualTo(EncryptionScopeState.Enabled));
            Assert.That(encryptionScopes[2].Data.Source, Is.EqualTo(EncryptionScopeSource.Storage));

            encryptionScopes = await encryptionScopeCollection.GetAllAsync(maxpagesize: 5, include: EncryptionScopesIncludeType.Enabled, filter: "startswith(name, test)").ToEnumerableAsync();
            Assert.That(encryptionScopes.Count, Is.EqualTo(1));
            Assert.That(encryptionScopes[0].Data.Name, Is.EqualTo("testscope3"));
            Assert.That(encryptionScopes[0].Data.State, Is.EqualTo(EncryptionScopeState.Enabled));
            Assert.That(encryptionScopes[0].Data.Source, Is.EqualTo(EncryptionScopeSource.Storage));

            encryptionScopes = await encryptionScopeCollection.GetAllAsync(maxpagesize: 10, include: EncryptionScopesIncludeType.Disabled, filter: "startswith(name, scope)").ToEnumerableAsync();
            Assert.That(encryptionScopes.Count, Is.EqualTo(1));
            Assert.That(encryptionScopes[0].Data.Name, Is.EqualTo("scope"));
            Assert.That(encryptionScopes[0].Data.State, Is.EqualTo(EncryptionScopeState.Disabled));
            Assert.That(encryptionScopes[0].Data.Source, Is.EqualTo(EncryptionScopeSource.Storage));
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
            Assert.That(privateEndpointConnections, Is.Not.Null);
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
            Assert.That(resourceGroup1.Id.Name, Is.EqualTo(account1.Id.ResourceGroupName));
            Assert.That(resourceGroup2.Id.Name, Is.EqualTo(account2.Id.ResourceGroupName));

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
            Assert.That(account.Data.NetworkRuleSet, Is.Not.Null);
            Assert.That(account.Data.NetworkRuleSet.Bypass.ToString(), Is.EqualTo(@"Logging, AzureServices"));
            Assert.That(account.Data.NetworkRuleSet.DefaultAction, Is.EqualTo(StorageNetworkDefaultAction.Deny));
            Assert.That(account.Data.NetworkRuleSet.VirtualNetworkRules, Is.Empty);
            Assert.That(account.Data.NetworkRuleSet.IPRules, Is.Not.Null);
            Assert.That(account.Data.NetworkRuleSet.IPRules, Is.Not.Empty);
            Assert.That(account.Data.NetworkRuleSet.IPRules[0].IPAddressOrRange, Is.EqualTo("23.45.67.90"));
            Assert.That(account.Data.NetworkRuleSet.IPRules[0].Action, Is.EqualTo(StorageAccountNetworkRuleAction.Allow));

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
            Assert.That(account.Data.NetworkRuleSet, Is.Not.Null);
            Assert.That(account.Data.NetworkRuleSet.Bypass.ToString(), Is.EqualTo(@"Logging, Metrics"));
            Assert.That(account.Data.NetworkRuleSet.DefaultAction, Is.EqualTo(StorageNetworkDefaultAction.Deny));
            Assert.That(account.Data.NetworkRuleSet.VirtualNetworkRules, Is.Empty);
            Assert.That(account.Data.NetworkRuleSet.IPRules, Is.Not.Null);
            Assert.That(account.Data.NetworkRuleSet.IPRules, Is.Not.Empty);
            Assert.That(account.Data.NetworkRuleSet.IPRules[0].IPAddressOrRange, Is.EqualTo("23.45.67.91"));
            Assert.That(account.Data.NetworkRuleSet.IPRules[0].Action, Is.EqualTo(StorageAccountNetworkRuleAction.Allow));
            Assert.That(account.Data.NetworkRuleSet.IPRules[1].IPAddressOrRange, Is.EqualTo("23.45.67.92"));
            Assert.That(account.Data.NetworkRuleSet.IPRules[1].Action, Is.EqualTo(StorageAccountNetworkRuleAction.Allow));
            Assert.That(account.Data.NetworkRuleSet.ResourceAccessRules, Is.Not.Null);
            Assert.That(account.Data.NetworkRuleSet.ResourceAccessRules, Is.Not.Empty);
            Assert.That(account.Data.NetworkRuleSet.ResourceAccessRules[0].TenantId.ToString(), Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
            Assert.That(account.Data.NetworkRuleSet.ResourceAccessRules[0].ResourceId.ToString(), Is.EqualTo("/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount1"));
            Assert.That(account.Data.NetworkRuleSet.ResourceAccessRules[1].TenantId.ToString(), Is.EqualTo("72f988bf-86f1-41af-91ab-2d7cd011db47"));
            Assert.That(account.Data.NetworkRuleSet.ResourceAccessRules[1].ResourceId.ToString(), Is.EqualTo("/subscriptions/subID/resourceGroups/RGName/providers/Microsoft.Storage/storageAccounts/testaccount2"));

            //delete vnet
            updateParameters = new StorageAccountPatch
            {
                NetworkRuleSet = new StorageAccountNetworkRuleSet(StorageNetworkDefaultAction.Allow) { }
            };
            account = await account.UpdateAsync(updateParameters);

            //validate
            account = await account.GetAsync();
            Assert.That(account.Data.NetworkRuleSet, Is.Not.Null);
            Assert.That(account.Data.NetworkRuleSet.Bypass.ToString(), Is.EqualTo(@"Logging, Metrics"));
            Assert.That(account.Data.NetworkRuleSet.DefaultAction, Is.EqualTo(StorageNetworkDefaultAction.Allow));
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
            Assert.That(account.Data.KeyPolicy.KeyExpirationPeriodInDays, Is.EqualTo(2));
            Assert.That(account.Data.SasPolicy.SasExpirationPeriod, Is.EqualTo("2.02:03:59"));

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
            Assert.That(account.Data.KeyPolicy.KeyExpirationPeriodInDays, Is.EqualTo(9));
            Assert.That(account.Data.SasPolicy.SasExpirationPeriod, Is.EqualTo("0.02:03:59"));
            Assert.That(account.Data.SasPolicy.ExpirationAction, Is.EqualTo(ExpirationAction.Block));
            Assert.That(account.Data.KeyCreationTime.Key1, Is.Not.Null);
            Assert.That(account.Data.KeyCreationTime.Key2, Is.Not.Null);
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
                Assert.That(account.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardRagrs));
                Assert.That(account.Data.IsFailoverInProgress, Is.Null);
                location = account.Data.SecondaryLocation;

                //Don't need sleep when playback, or Unit test will be very slow. Need sleep when record.
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
            } while ((account.Data.GeoReplicationStats.CanFailover != true) && (i-- > 0));

            await account.FailoverAsync(WaitUntil.Completed);

            account = await account.GetAsync();

            Assert.That(account.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardLrs));
            Assert.That(account.Data.PrimaryLocation?.ToString(), Is.EqualTo(location));
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
                Assert.That(account.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardRagrs));
                Assert.That(account.Data.IsFailoverInProgress, Is.Null);
                location = account.Data.SecondaryLocation;

                //Don't need sleep when playback, or Unit test will be very slow. Need sleep when record.
                if (Mode != RecordedTestMode.Playback)
                {
                    await Task.Delay(10000);
                }
            } while ((account.Data.GeoReplicationStats.CanFailover != true) && (i-- > 0));

            await account.FailoverAsync(WaitUntil.Completed, StorageAccountFailoverType.Planned);

            account = await account.GetAsync();

            Assert.That(account.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardRagrs));
            Assert.That(account.Data.PrimaryLocation?.ToString(), Is.EqualTo(location));
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
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.Aadds));

            //Update storage account
            var updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.None),
                EnableHttpsTrafficOnly = true
            };
            account = await account.UpdateAsync(updateParameters);
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.None));

            // Validate
            account = await account.GetAsync();
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.None));
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
            Assert.That(account.Id.Name, Is.EqualTo(accountName));

            // Update storage account type
            var data = GetDefaultStorageAccountParameters(new StorageSku(StorageSkuName.StandardLrs));
            account = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, data)).Value;
            Assert.That(account.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardLrs));

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.That(account.Data.Sku.Name, Is.EqualTo(StorageSkuName.StandardLrs));

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
            Assert.That(account.Data.Tags.Count, Is.EqualTo(3));

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.That(account.Data.Tags.Count, Is.EqualTo(3));

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
            Assert.That(account.Data.Encryption, Is.Not.Null);

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.That(account.Data.Encryption, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Blob, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.Blob.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.Blob.LastEnabledOn, Is.Not.Null);

            Assert.That(account.Data.Encryption.Services.File, Is.Not.Null);
            Assert.That(account.Data.Encryption.Services.File.IsEnabled, Is.True);
            Assert.That(account.Data.Encryption.Services.File.LastEnabledOn, Is.Not.Null);

            if (null != account.Data.Encryption.Services.Table)
            {
                if (account.Data.Encryption.Services.Table.IsEnabled.HasValue)
                {
                    Assert.That(account.Data.Encryption.Services.Table.LastEnabledOn.HasValue, Is.False);
                }
            }

            if (null != account.Data.Encryption.Services.Queue)
            {
                if (account.Data.Encryption.Services.Queue.IsEnabled.HasValue)
                {
                    Assert.That(account.Data.Encryption.Services.Queue.LastEnabledOn.HasValue, Is.False);
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
                Assert.That(ex.Status, Is.EqualTo(409));
                Assert.That(ex.ErrorCode, Is.EqualTo("StorageDomainNameCouldNotVerify"));
                Assert.That(ex.Message != null && ex.Message.StartsWith("The custom domain " +
                        "name could not be verified. CNAME mapping from foo.example.com to "), Is.True);
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
            Assert.That(account.Id.Name, Is.EqualTo(accountName));

            var usages = await DefaultSubscription.GetUsagesByLocationAsync(DefaultLocation).ToEnumerableAsync();
            Assert.That(usages.Count(), Is.EqualTo(1));
            Assert.That(usages.First().Unit, Is.EqualTo(StorageUsageUnit.Count));
            Assert.That(usages.First().CurrentValue, Is.Not.Null);
            Assert.That(usages.First().Limit, Is.EqualTo(250));
            Assert.That(usages.First().Name, Is.Not.Null);
            Assert.That(usages.First().Name.Value, Is.EqualTo("StorageAccounts"));
            Assert.That(usages.First().Name.LocalizedValue, Is.EqualTo("Storage Accounts"));
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
            Assert.That(account.Id.Name, Is.EqualTo(accountName));

            await account.EnableHierarchicalNamespaceAsync(WaitUntil.Completed, "HnsOnValidationRequest");
            await account.EnableHierarchicalNamespaceAsync(WaitUntil.Completed, "HnsOnHydrationRequest");

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.That(account.Data.IsHnsEnabled, Is.True);
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
            Assert.That(account1.Id.Name, Is.EqualTo(accountName1));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.ImmutableStorageWithVersioning.IsEnabled, Is.False);
            Assert.That(account1.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy, Is.Null);
            Assert.That(account1.Data.IsDefaultToOAuthAuthentication, Is.True);
            Assert.That(account1.Data.PublicNetworkAccess, Is.EqualTo(StoragePublicNetworkAccess.SecuredByPerimeter));

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
            Assert.That(account2.Id.Name, Is.EqualTo(accountName2));
            VerifyAccountProperties(account2, false);
            Assert.That(account2.Data.ImmutableStorageWithVersioning.IsEnabled, Is.True);
            Assert.That(account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(1));
            Assert.That(account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.State, Is.EqualTo(AccountImmutabilityPolicyState.Unlocked));
            Assert.That(account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites, Is.True);
            Assert.That(account2.Data.IsDefaultToOAuthAuthentication, Is.True);
            Assert.That(account2.Data.PublicNetworkAccess, Is.EqualTo(StoragePublicNetworkAccess.Enabled));

            //Update account 2
            var parameter = new StorageAccountPatch()
            {
                ImmutableStorageWithVersioning = new ImmutableStorageAccount() { IsEnabled = true }
            };
            account2 = (await account2.UpdateAsync(parameter)).Value;
            VerifyAccountProperties(account2, false);
            Assert.That(account2.Data.ImmutableStorageWithVersioning.IsEnabled, Is.True);
            Assert.That(account2.Data.IsDefaultToOAuthAuthentication, Is.True);
            Assert.That(account2.Data.PublicNetworkAccess, Is.EqualTo(StoragePublicNetworkAccess.Enabled));

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
            Assert.That(account2.Data.ImmutableStorageWithVersioning.IsEnabled, Is.True);
            Assert.That(account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.ImmutabilityPeriodSinceCreationInDays, Is.EqualTo(2));
            Assert.That(account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.State, Is.EqualTo(AccountImmutabilityPolicyState.Unlocked));
            Assert.That(account2.Data.ImmutableStorageWithVersioning.ImmutabilityPolicy.AllowProtectedAppendWrites, Is.False);
            Assert.That(account2.Data.IsDefaultToOAuthAuthentication, Is.False);
            Assert.That(account2.Data.PublicNetworkAccess, Is.EqualTo(StoragePublicNetworkAccess.Disabled));
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
            Assert.That(account.Data.AllowedCopyScope, Is.EqualTo(AllowedCopyScope.Aad));

            //Update account
            var patch = new StorageAccountPatch()
            {
                AllowedCopyScope = AllowedCopyScope.PrivateLink
            };
            account = await account.UpdateAsync(patch);
            VerifyAccountProperties(account, false);
            Assert.That(account.Data.AllowedCopyScope, Is.EqualTo(AllowedCopyScope.PrivateLink));
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
            Assert.That(account1.Id.Name, Is.EqualTo(accountName1));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.IsSftpEnabled, Is.True);
            Assert.That(account1.Data.IsLocalUserEnabled, Is.True);
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
            Assert.That(account1.Data.IsSftpEnabled, Is.False);
            Assert.That(account1.Data.IsLocalUserEnabled, Is.False);
            //Assert.IsFalse(account1.Data.IsExtendedGroupEnabled);

            parameter = new StorageAccountPatch()
            {
                IsLocalUserEnabled = true,
                //IsExtendedGroupEnabled = true,
            };
            account1 = (await account1.UpdateAsync(parameter)).Value;
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.IsSftpEnabled, Is.False);
            Assert.That(account1.Data.IsLocalUserEnabled, Is.True);
            //Assert.IsTrue(account1.Data.IsExtendedGroupEnabled);

            parameter = new StorageAccountPatch()
            {
                IsSftpEnabled = true
            };
            account1 = (await account1.UpdateAsync(parameter)).Value;
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.IsSftpEnabled, Is.True);
            Assert.That(account1.Data.IsLocalUserEnabled, Is.True);

            // Create Local user 1
            var userCollection = account1.GetStorageAccountLocalUsers();
            string userName1 = Recording.GenerateAssetName("user1");
            var data = new StorageAccountLocalUserData()
            {
                HomeDirectory = "/"
            };
            var user1 = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName1, data)).Value;
            Assert.That(user1.Data.Name, Is.EqualTo(userName1));
            Assert.That(user1.Data.HomeDirectory, Is.EqualTo("/"));
            Assert.That(user1.Data.HasSharedKey, Is.Null);
            Assert.That(user1.Data.HasSshKey, Is.Null);
            Assert.That(user1.Data.HasSshPassword, Is.Null);

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
            Assert.That(user2.Data.Name, Is.EqualTo(userName2));
            Assert.That(user2.Data.HomeDirectory, Is.EqualTo("/dir1/"));
            Assert.That(user2.Data.PermissionScopes.Count, Is.EqualTo(2));
            Assert.That(user2.Data.SshAuthorizedKeys.Count, Is.EqualTo(2));
            Assert.That(user2.Data.HasSharedKey, Is.True);
            Assert.That(user2.Data.HasSshKey, Is.True);
            Assert.That(user2.Data.HasSshPassword, Is.True);

            // Create Local user 3
            string userName3 = Recording.GenerateAssetName("user3");
            data = new StorageAccountLocalUserData()
            {
                HomeDirectory = "/",
                GroupId = 2000,
                IsAclAuthorizationAllowed = true,
            };
            var user3 = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName3, data)).Value;
            Assert.That(user3.Data.Name, Is.EqualTo(userName3));
            Assert.That(user3.Data.HomeDirectory, Is.EqualTo("/"));
            Assert.That(user3.Data.HasSharedKey, Is.Null);
            Assert.That(user3.Data.HasSshKey, Is.Null);
            Assert.That(user3.Data.HasSshPassword, Is.Null);
            Assert.That(user3.Data.GroupId, Is.EqualTo(data.GroupId));
            Assert.That(user3.Data.IsAclAuthorizationAllowed, Is.EqualTo(data.IsAclAuthorizationAllowed));
            Assert.That(user3.Data.UserId, Is.Not.Null);

            // Create Local user 4
            string userName4 = Recording.GenerateAssetName("user4");
            data = new StorageAccountLocalUserData()
            {
                HomeDirectory = "/",
                //ExtendedGroups = { 1001, 1005 },
                //IsNfsV3Enabled = true,
            };
            var user4 = (await userCollection.CreateOrUpdateAsync(WaitUntil.Completed, userName4, data)).Value;
            Assert.That(user4.Data.Name, Is.EqualTo(userName4));
            Assert.That(user4.Data.HomeDirectory, Is.EqualTo("/"));
            Assert.That(user4.Data.HasSharedKey, Is.Null);
            Assert.That(user4.Data.HasSshKey, Is.Null);
            Assert.That(user4.Data.HasSshPassword, Is.Null);
            Assert.That(user3.Data.ExtendedGroups, Is.EqualTo(data.ExtendedGroups));
            Assert.That(user3.Data.IsNfsV3Enabled, Is.EqualTo(data.IsNfsV3Enabled));

            // List all local user
            var users = await userCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(users.Count, Is.EqualTo(4));

            // List with filter
            users = await userCollection.GetAllAsync(filter: "startswith(name, user3)").ToEnumerableAsync();
            Assert.That(users.Count, Is.EqualTo(1));
            Assert.That(users.First().Data.Name, Is.EqualTo(userName3));

            // List with include
            //users = await userCollection.GetAllAsync(include: ListLocalUserIncludeParam.Nfsv3).ToEnumerableAsync();
            //Assert.AreEqual(1, users.Count);
            //Assert.AreEqual(userName4, users.First().Data.Name);

            // List with maxpagesize & nextlink
            users = await userCollection.GetAllAsync(maxpagesize: 3).ToEnumerableAsync();
            Assert.That(users.Count, Is.EqualTo(4));

            // Get Single local user
            user1 = (await userCollection.GetAsync(userName1)).Value;
            Assert.That(user1.Data.Name, Is.EqualTo(userName1));
            Assert.That(user1.Data.HomeDirectory, Is.EqualTo("/"));
            Assert.That(user1.Data.HasSharedKey, Is.False);
            Assert.That(user1.Data.HasSshKey, Is.False);
            Assert.That(user1.Data.HasSshPassword, Is.False);
            user2 = (await userCollection.GetAsync(userName2)).Value;
            Assert.That(user2.Data.Name, Is.EqualTo(userName2));
            Assert.That(user2.Data.HomeDirectory, Is.EqualTo("/dir1/"));
            Assert.That(user2.Data.PermissionScopes.Count, Is.EqualTo(2));
            Assert.That(user2.Data.SshAuthorizedKeys, Is.Empty);
            Assert.That(user2.Data.HasSharedKey, Is.True);
            Assert.That(user2.Data.HasSshKey, Is.True);
            Assert.That(user2.Data.HasSshPassword, Is.False);

            // Get Key on local user
            var keys = (await user2.GetKeysAsync()).Value;
            Assert.That(keys.SharedKey, Is.Not.Null);
            Assert.That(keys.SshAuthorizedKeys.Count, Is.EqualTo(2));

            // re-generate sshPassword on local user
            LocalUserRegeneratePasswordResult regeneratePasswordResult = (await user2.RegeneratePasswordAsync()).Value;
            Assert.That(regeneratePasswordResult.SshPassword, Is.Not.Null);

            //Remove Localuser
            await user1.DeleteAsync(WaitUntil.Completed);
            users = await userCollection.GetAllAsync().ToEnumerableAsync();
            Assert.That(users.Count, Is.EqualTo(3));
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
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Hot));

            //Update account
            var patch = new StorageAccountPatch()
            {
                AccessTier = StorageAccountAccessTier.Premium
            };
            account = await account.UpdateAsync(patch);
            Assert.That(account.Data.AccessTier, Is.EqualTo(StorageAccountAccessTier.Premium));
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
            Assert.That(account.Data.DnsEndpointType, Is.EqualTo(StorageDnsEndpointType.AzureDnsZone));
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
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.Aadkerb));
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainName, Is.EqualTo(domainName));
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainGuid, Is.EqualTo(domainId));

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.Aadkerb));
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainName, Is.EqualTo(domainName));
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainGuid, Is.EqualTo(domainId));

            // Update storage account to None
            var updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.None)
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.None));

            // Update storage account to AADKERB
            updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.Aadkerb)
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.Aadkerb));

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.Aadkerb));

            // Update storage account to AADKERB + properties
            updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = data
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.Aadkerb));
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainName, Is.EqualTo(domainName));
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainGuid, Is.EqualTo(domainId));

            // Validate
            account = (await storageAccountCollection.GetAsync(accountName)).Value;
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.DirectoryServiceOptions, Is.EqualTo(DirectoryServiceOption.Aadkerb));
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainName, Is.EqualTo(domainName));
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.ActiveDirectoryProperties.DomainGuid, Is.EqualTo(domainId));
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
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.IsSmbOAuthEnabled, Is.EqualTo(true));

            // Update storage account to None
            var updateParameters = new StorageAccountPatch
            {
                AzureFilesIdentityBasedAuthentication = new FilesIdentityBasedAuthentication(DirectoryServiceOption.None)
                {
                    IsSmbOAuthEnabled = false,
                }
            };
            account = (await account.UpdateAsync(updateParameters)).Value;
            Assert.That(account.Data.AzureFilesIdentityBasedAuthentication.IsSmbOAuthEnabled, Is.EqualTo(false));
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
            Assert.That(account1.Data.Zones[0], Is.EqualTo("1"));

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
            Assert.That(StorageAccountZonePlacementPolicy.Any, Is.EqualTo(account2.Data.ZonePlacementPolicy));

            // Update storage account to None
            var updateParameters1 = new StorageAccountPatch
            {
                ZonePlacementPolicy = StorageAccountZonePlacementPolicy.None,
            };

            account2 = (await account2.UpdateAsync(updateParameters1)).Value;
            Assert.That(StorageAccountZonePlacementPolicy.None, Is.EqualTo(account2.Data.ZonePlacementPolicy));

            string accountName3 = await CreateValidAccountNameAsync(namePrefix);
            var parameters3 = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.PremiumLrs),
                StorageKind.FileStorage,
                "centraluseuap"
                );
            var account3 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName3, parameters3)).Value;
            Assert.That(account3.Data.Zones.Count, Is.EqualTo(0));

            var updateParameters2 = new StorageAccountPatch
            {
                Zones = { "1" }
            };
            account3 = (await account3.UpdateAsync(updateParameters2)).Value;
            Assert.That(account3.Data.Zones[0], Is.EqualTo("1"));
        }

        [Test]
        [RecordedTest]
        public async Task StorageAccountCreateUpdateGeoSLA()
        {
            //create storage account with GeoPriorityReplicationStatus.IsBlobEnabled = true
            _resourceGroup = await CreateResourceGroupAsync();
            string accountName1 = await CreateValidAccountNameAsync(namePrefix);
            var parameters1 = new StorageAccountCreateOrUpdateContent(
                new StorageSku(StorageSkuName.StandardGrs),
                StorageKind.StorageV2,
                "centraluseuap"
                )
            {
                GeoPriorityReplicationStatus = new GeoPriorityReplicationStatus() { IsBlobEnabled = true }
            };
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName1, parameters1)).Value;
            Assert.That(account1.Data.GeoPriorityReplicationStatus.IsBlobEnabled, Is.EqualTo(true));

            // Update storage account to GeoPriorityReplicationStatus.IsBlobEnabled = false
            var updateParameters1 = new StorageAccountPatch
            {
                GeoPriorityReplicationStatus = new GeoPriorityReplicationStatus() { IsBlobEnabled = false }
            };

            account1 = (await account1.UpdateAsync(updateParameters1)).Value;
            Assert.That(account1.Data.GeoPriorityReplicationStatus.IsBlobEnabled, Is.EqualTo(false));

            await account1.DeleteAsync(waitUntil: WaitUntil.Started);
        }
    }
}
