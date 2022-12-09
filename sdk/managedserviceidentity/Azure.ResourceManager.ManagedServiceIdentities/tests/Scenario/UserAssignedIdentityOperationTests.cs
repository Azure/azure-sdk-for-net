// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.ManagedServiceIdentities.Tests
{
    public class UserAssignedIdentityOperationTests : ManagedServiceIdentitiesManagementTestBase
    {
        public UserAssignedIdentityOperationTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<UserAssignedIdentityResource> CreateUserAssignedIdentityResource(string name)
        {
            var resourceGroup = await CreateResourceGroup(await Client.GetDefaultSubscriptionAsync(), "uai-rg", DefaultLocation);
            return (await resourceGroup.GetUserAssignedIdentities()
                .CreateOrUpdateAsync(WaitUntil.Completed, name, new UserAssignedIdentityData(DefaultLocation))).Value;
        }

        [RecordedTest]
        public async Task Get()
        {
            var name = Recording.GenerateAssetName("uai");
            var userAssignedIdentity = await CreateUserAssignedIdentityResource(name);

            UserAssignedIdentityResource userAssignedIdentity2 = await userAssignedIdentity.GetAsync();

            Assert.AreEqual(userAssignedIdentity.Data.Id, userAssignedIdentity2.Data.Id);
            Assert.AreEqual(userAssignedIdentity.Data.Name, userAssignedIdentity2.Data.Name);
            Assert.AreEqual(userAssignedIdentity.Data.ResourceType, userAssignedIdentity2.Data.ResourceType);
            Assert.AreEqual(userAssignedIdentity.Data.TenantId, userAssignedIdentity2.Data.TenantId);
            Assert.AreEqual(userAssignedIdentity.Data.ClientId, userAssignedIdentity2.Data.ClientId);
            Assert.AreEqual(userAssignedIdentity.Data.PrincipalId, userAssignedIdentity2.Data.PrincipalId);
        }

        [RecordedTest]
        public async Task Delete()
        {
            var name = Recording.GenerateAssetName("uai");
            var userAssignedIdentity = await CreateUserAssignedIdentityResource(name);

            await userAssignedIdentity.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("uai");
            var userAssignedIdentity = await CreateUserAssignedIdentityResource(name);

            var key = "key";
            var value = "value";
            userAssignedIdentity = await userAssignedIdentity.AddTagAsync(key, value);

            Assert.IsTrue(userAssignedIdentity.Data.Tags.ContainsKey(key));
            Assert.AreEqual(value, userAssignedIdentity.Data.Tags[key]);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task SetTags(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("uai");
            var userAssignedIdentity = await CreateUserAssignedIdentityResource(name);

            var tags = new Dictionary<string, string>()
            {
                ["key1"] = "value1",
                ["key2"] = "value2"
            };
            userAssignedIdentity = await userAssignedIdentity.SetTagsAsync(tags);

            CollectionAssert.AreEquivalent(tags, userAssignedIdentity.Data.Tags);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task RemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            var name = Recording.GenerateAssetName("uai");
            var userAssignedIdentity = await CreateUserAssignedIdentityResource(name);

            var tags = new Dictionary<string, string>()
            {
                ["key1"] = "value1",
                ["key2"] = "value2"
            };
            userAssignedIdentity = await userAssignedIdentity.SetTagsAsync(tags);

            userAssignedIdentity = await userAssignedIdentity.RemoveTagAsync("key1");

            Assert.IsFalse(userAssignedIdentity.Data.Tags.ContainsKey("key1"));
            Assert.IsTrue(userAssignedIdentity.Data.Tags.ContainsKey("key2"));
        }
    }
}
