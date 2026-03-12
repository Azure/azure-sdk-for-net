// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageAccountManagedIdentityTests : StorageManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private const string namePrefix = "teststoragemgmt";
        public StorageAccountManagedIdentityTests(bool isAsync) : base(isAsync)
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

        private async Task<GenericResource> CreateUserAssignedIdentityAsync()
        {
            string userAssignedIdentityName = Recording.GenerateAssetName("testMsi-");
            ResourceIdentifier userIdentityId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{userAssignedIdentityName}");
            var input = new GenericResourceData(DefaultLocation);
            var response = await Client.GetGenericResources().CreateOrUpdateAsync(WaitUntil.Completed, userIdentityId, input);
            return response.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateAccountWithSystemAssignedIdentity()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task CreateAccountWithUserAssignedIdentity()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task CreateAccountWithSystemAndUserAssignedIdentity()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromNoneToSystem()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS));
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.Null(account1.Data.Identity);

            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = new StorageIdentity(StorageIdentityType.SystemAssigned)
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account2.Data.Identity.Type);
            Assert.IsEmpty(account2.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromNoneToUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS));
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.Null(account1.Data.Identity);

            var identity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromNoneToSystemAndUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS));
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.Null(account1.Data.Identity);

            var identity = new StorageIdentity(StorageIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemToNone()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            var noneIdentity = new StorageIdentity(StorageIdentityType.None);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = noneIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.None, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.TenantId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.None, account2.Data.Identity.Type);
            Assert.IsEmpty(account2.Data.Identity.UserAssignedIdentities);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.Null(account2.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemToUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            var userManagedIdentity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            userManagedIdentity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = userManagedIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemToSystemUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            var systemUserIdentity = new StorageIdentity(StorageIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            systemUserIdentity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = systemUserIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromUserToNone()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            var noneIdentity = new StorageIdentity(StorageIdentityType.None);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = noneIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.None, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.TenantId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.None, account2.Data.Identity.Type);
            Assert.IsEmpty(account2.Data.Identity.UserAssignedIdentities);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.Null(account2.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromUserToSystem()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            var systemIdentity = new StorageIdentity(StorageIdentityType.SystemAssigned);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = systemIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account2.Data.Identity.Type);
            Assert.IsEmpty(account2.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromUserToSystemUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            var systemUserIdentity = new StorageIdentity(StorageIdentityType.SystemAssignedUserAssigned);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = systemUserIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        [Ignore("Too many user-assigned identities specified on the resource.")]
        public async Task UpdateAccountIdentityFromUserToTwoUsers()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // With JSON Merge Patch, we only need to put the identity to add in the dictionary for update operation.
            var identity2 = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity2 = await CreateUserAssignedIdentityAsync();
            identity2.UserAssignedIdentities.Add(userAssignedIdentity2.Id.ToString(), new StorageUserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = identity2
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 2);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 2);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        [Ignore("Service throws exception validating that None type cannot have user assigned identity even its value is null which means to delete an existing one. Use the operations in UpdateAccountIdentityFromUserToNone to achieve the same result.")]
        public async Task UpdateAccountIdentityToRemoveUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()] = null;
            account1.Data.Identity.Type = StorageIdentityType.None;
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = account1.Data.Identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.None, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.TenantId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.None, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.Null(account2.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        [Ignore("Storage account only supports one user assigned identity")]
        public async Task UpdateAccountIdentityFromTwoUsersToOneUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.UserAssigned);
            var userAssignedIdentity1 = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity1.Id, new StorageUserAssignedIdentity());
            var userAssignedIdentity2 = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity2.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 2);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id].PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);

            account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id] = null;
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = account1.Data.Identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id]);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.IsFalse(account1.Data.Identity.UserAssignedIdentities.ContainsKey(userAssignedIdentity1.Id));
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemUserToNone()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            var noneIdentity = new StorageIdentity(StorageIdentityType.None);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = noneIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.None, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.TenantId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.None, account2.Data.Identity.Type);
            Assert.IsEmpty(account2.Data.Identity.UserAssignedIdentities);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.Null(account2.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemUserToSystem()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = new StorageIdentity(StorageIdentityType.SystemAssigned)
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.IsEmpty(account1.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.SystemAssigned, account2.Data.Identity.Type);
            Assert.IsEmpty(account2.Data.Identity.UserAssignedIdentities);
            Assert.NotNull(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.TenantId);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemUserToUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new StorageIdentity(StorageIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new StorageUserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLRS), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(StorageIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = new StorageIdentity(StorageIdentityType.UserAssigned)
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(StorageIdentityType.UserAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
        }
    }
}
