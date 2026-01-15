// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedServiceIdentities.Tests
{
    public class UserAssignedIdentityCollectionTests : ManagedServiceIdentitiesManagementTestBase
    {
        public UserAssignedIdentityCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            return await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "uai-rg", DefaultLocation);
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var name = Recording.GenerateAssetName("uai");
            var data = new UserAssignedIdentityData(DefaultLocation);
            var collection = resourceGroup.GetUserAssignedIdentities();
            var userAssignedIdentity = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;

            Assert.NotNull(userAssignedIdentity.Data.TenantId);
            Assert.NotNull(userAssignedIdentity.Data.ClientId);
            Assert.NotNull(userAssignedIdentity.Data.PrincipalId);
        }

        [RecordedTest]
        public async Task Get()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var name = Recording.GenerateAssetName("uai");
            var data = new UserAssignedIdentityData(DefaultLocation);
            var collection = resourceGroup.GetUserAssignedIdentities();
            var userAssignedIdentity = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;

            UserAssignedIdentityResource userAssignedIdentity2 = await collection.GetAsync(name);

            Assert.That(userAssignedIdentity2.Data.Id, Is.EqualTo(userAssignedIdentity.Data.Id));
            Assert.That(userAssignedIdentity2.Data.Name, Is.EqualTo(userAssignedIdentity.Data.Name));
            Assert.That(userAssignedIdentity2.Data.ResourceType, Is.EqualTo(userAssignedIdentity.Data.ResourceType));
            Assert.That(userAssignedIdentity2.Data.TenantId, Is.EqualTo(userAssignedIdentity.Data.TenantId));
            Assert.That(userAssignedIdentity2.Data.ClientId, Is.EqualTo(userAssignedIdentity.Data.ClientId));
            Assert.That(userAssignedIdentity2.Data.PrincipalId, Is.EqualTo(userAssignedIdentity.Data.PrincipalId));
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var resourceGroup = await CreateResourceGroupAsync();
            var name1 = Recording.GenerateAssetName("uai");
            var name2 = Recording.GenerateAssetName("uai");
            var collection = resourceGroup.GetUserAssignedIdentities();
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name1, new UserAssignedIdentityData(DefaultLocation));
            _ = await collection.CreateOrUpdateAsync(WaitUntil.Completed, name2, new UserAssignedIdentityData(DefaultLocation));

            var count = 0;
            await foreach (var _ in collection.GetAllAsync())
            {
                count++;
            }

            Assert.GreaterOrEqual(count, 2);
        }
    }
}
