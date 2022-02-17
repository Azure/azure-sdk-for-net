// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.Storage.Tests.Helpers;
using Azure.ResourceManager.Resources.Models;
using Sku = Azure.ResourceManager.Storage.Models.Sku;
using Azure.ResourceManager.Network.Models;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Tests
{
    public class StorageAccountManagedIdentityTests : StorageTestBase
    {
        private ResourceGroup _resourceGroup;
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
                List<StorageAccount> storageAccountList = await storageAccountCollection.GetAllAsync().ToEnumerableAsync();
                foreach (StorageAccount account in storageAccountList)
                {
                    await account.DeleteAsync(true);
                }
                _resourceGroup = null;
            }
        }

        private async Task<GenericResource> CreateUserAssignedIdentityAsync()
        {
            string userAssignedIdentityName = Recording.GenerateAssetName("testMsi-");
            ResourceIdentifier userIdentityId = new ResourceIdentifier($"{_resourceGroup.Id}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{userAssignedIdentityName}");
            var input = new GenericResourceData(DefaultLocation);
            var response = await Client.GetGenericResources().CreateOrUpdateAsync(true, userIdentityId, input);
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
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS));
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.Null(account1.Data.Identity);

            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS));
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.Null(account1.Data.Identity);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account2.Data.Identity.Type);
            Assert.Greater(account2.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS));
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.Null(account1.Data.Identity);

            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, account2.Data.Identity.Type);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            var noneIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = noneIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.None, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.TenantId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.None, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            var userManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            userManagedIdentity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = userManagedIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account2.Data.Identity.Type);
            Assert.Greater(account2.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            var systemUserIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            systemUserIdentity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = systemUserIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, account2.Data.Identity.Type);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            var noneIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = noneIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.None, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.TenantId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.None, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            var systemIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = systemIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.TenantId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 0);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            var systemUserIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssignedUserAssigned);
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = systemUserIdentity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.NotNull(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssignedUserAssigned, account2.Data.Identity.Type);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            var userAssignedIdentity2 = await CreateUserAssignedIdentityAsync();
            account1.Data.Identity.UserAssignedIdentities.Add(userAssignedIdentity2.Id.ToString(), new UserAssignedIdentity());
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = account1.Data.Identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 2);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account2.Data.Identity.Type);
            Assert.AreEqual(account2.Data.Identity.UserAssignedIdentities.Count, 2);
            Assert.Null(account2.Data.Identity.PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);
            Assert.NotNull(account2.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);
        }

        [Test]
        [RecordedTest]
        [Ignore("Storage account does not support JSON Merge Patch")]
        public async Task UpdateAccountIdentityToRemoveUser()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            StorageAccountCollection storageAccountCollection = _resourceGroup.GetStorageAccounts();

            string accountName = await CreateValidAccountNameAsync(namePrefix);
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity.Id.ToString(), new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.Greater(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()].PrincipalId);

            account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity.Id.ToString()] = null;
            account1.Data.Identity.Type = ManagedServiceIdentityType.None;
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = account1.Data.Identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.None, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 0);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.TenantId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.None, account2.Data.Identity.Type);
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
            var identity = new ManagedServiceIdentity(ManagedServiceIdentityType.UserAssigned);
            var userAssignedIdentity1 = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity1.Id.ToString(), new UserAssignedIdentity());
            var userAssignedIdentity2 = await CreateUserAssignedIdentityAsync();
            identity.UserAssignedIdentities.Add(userAssignedIdentity2.Id.ToString(), new UserAssignedIdentity());
            var param = GetDefaultStorageAccountParameters(sku: new Sku(SkuName.StandardLRS), identity: identity);
            StorageAccount account1 = (await storageAccountCollection.CreateOrUpdateAsync(true, accountName, param)).Value;
            Assert.AreEqual(accountName, account1.Id.Name);
            VerifyAccountProperties(account1, false);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 2);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id.ToString()].PrincipalId);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);

            account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id.ToString()] = null;
            StorageAccountUpdateOptions parameters = new StorageAccountUpdateOptions()
            {
                Identity = account1.Data.Identity
            };
            account1 = await account1.UpdateAsync(parameters);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id.ToString()]);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);

            // validate
            StorageAccount account2 = await storageAccountCollection.GetAsync(accountName);
            Assert.AreEqual(ManagedServiceIdentityType.UserAssigned, account1.Data.Identity.Type);
            Assert.AreEqual(account1.Data.Identity.UserAssignedIdentities.Count, 1);
            Assert.Null(account1.Data.Identity.PrincipalId);
            Assert.Null(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity1.Id.ToString()]);
            Assert.NotNull(account1.Data.Identity.UserAssignedIdentities[userAssignedIdentity2.Id.ToString()].PrincipalId);
        }
    }
}
