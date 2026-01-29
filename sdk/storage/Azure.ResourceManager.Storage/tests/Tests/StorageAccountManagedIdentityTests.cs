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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task CreateAccountWithUserAssignedIdentity()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task CreateAccountWithSystemAndUserAssignedIdentity()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromNoneToSystem()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs));
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity, Is.Null);

            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account2.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account2.Data.Identity.TenantId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromNoneToUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs));
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity, Is.Null);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account2.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromNoneToSystemAndUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs));
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity, Is.Null);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account2.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemToNone()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Not.Null);

            var noneIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = noneIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
            Assert.That(account2.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account2.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account2.Data.Identity.TenantId, Is.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemToUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Not.Null);

            var userManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            userManagedIdentity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = userManagedIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account2.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemToSystemUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Not.Null);

            var systemUserIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            systemUserIdentity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = systemUserIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account2.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromUserToNone()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            var noneIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = noneIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
            Assert.That(account2.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account2.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account2.Data.Identity.TenantId, Is.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromUserToSystem()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            var systemIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = systemIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account2.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account2.Data.Identity.TenantId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromUserToSystemUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            var systemUserIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = systemUserIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account2.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        [Ignore("Too many user-assigned identities specified on the resource.")]
        public async Task UpdateAccountIdentityFromUserToTwoUsers()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            // With JSON Merge Patch, we only need to put the identity to add in the dictionary for update operation.
            var identity2 = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity2 = await CreateUserAssignedIdentityAsync();
            identity2.UserAssignedIdentities.Add(userAssignedIdentity2.Id, new UserAssignedIdentity());
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = identity2
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(2));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id].PrincipalId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(2));
            Assert.That(account2.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
            Assert.That(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        [Ignore("Service throws exception validating that None type cannot have user assigned identity even its value is null which means to delete an existing one. Use the operations in UpdateAccountIdentityFromUserToNone to achieve the same result.")]
        public async Task UpdateAccountIdentityToRemoveUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.GreaterThan(0));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id] = null;
            account1.Data.Identity.ManagedServiceIdentityType = ManagedServiceIdentityType.None;
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = account1.Data.Identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(0));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
            Assert.That(account2.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(0));
            Assert.That(account2.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account2.Data.Identity.TenantId, Is.Null);
        }

        [Test]
        [RecordedTest]
        [Ignore("Storage account only supports one user assigned identity")]
        public async Task UpdateAccountIdentityFromTwoUsersToOneUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity1 = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity1.Id, new UserAssignedIdentity());
            var userAssignedIdentity2 = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity2.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(2));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id].PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id].PrincipalId, Is.Not.Null);

            account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id] = null;
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = account1.Data.Identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id], Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id].PrincipalId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities.ContainsKey(userAssignedIdentity1.Id), Is.False);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id].PrincipalId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemUserToNone()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            var noneIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = noneIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
            Assert.That(account2.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account2.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account2.Data.Identity.TenantId, Is.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemUserToSystem()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.TenantId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities, Is.Empty);
            Assert.That(account2.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account2.Data.Identity.TenantId, Is.Not.Null);
        }

        [Test]
        [RecordedTest]
        public async Task UpdateAccountIdentityFromSystemUserToUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id, new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new StorageSku(StorageSkuName.StandardLrs), identity: identity);
            StorageAccountResource account1 = (await storageAccountCollection.CreateOrUpdateAsync(WaitUntil.Completed, accountName, param)).Value;
            Assert.That(account1.Id.Name, Is.EqualTo(accountName));
            VerifyAccountProperties(account1, false);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssignedUserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Not.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            StorageAccountPatch parameters = new StorageAccountPatch()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned)
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.That(account1.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account1.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account1.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);

            // validate
            StorageAccountResource account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.That(account2.Data.Identity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.UserAssigned));
            Assert.That(account2.Data.Identity.UserAssignedIdentities.Count, Is.EqualTo(1));
            Assert.That(account2.Data.Identity.PrincipalId, Is.Null);
            Assert.That(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id].PrincipalId, Is.Not.Null);
        }
    }
}
