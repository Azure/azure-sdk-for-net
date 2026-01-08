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

            Assert.Multiple(() =>
            {
                Assert.That(userAssignedIdentity2.Data.Id, Is.EqualTo(userAssignedIdentity.Data.Id));
                Assert.That(userAssignedIdentity2.Data.Name, Is.EqualTo(userAssignedIdentity.Data.Name));
                Assert.That(userAssignedIdentity2.Data.ResourceType, Is.EqualTo(userAssignedIdentity.Data.ResourceType));
                Assert.That(userAssignedIdentity2.Data.TenantId, Is.EqualTo(userAssignedIdentity.Data.TenantId));
                Assert.That(userAssignedIdentity2.Data.ClientId, Is.EqualTo(userAssignedIdentity.Data.ClientId));
                Assert.That(userAssignedIdentity2.Data.PrincipalId, Is.EqualTo(userAssignedIdentity.Data.PrincipalId));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(userAssignedIdentity.Data.Tags.ContainsKey(key), Is.True);
                Assert.That(userAssignedIdentity.Data.Tags[key], Is.EqualTo(value));
            });
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

            Assert.That(userAssignedIdentity.Data.Tags, Is.EquivalentTo(tags));
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

            Assert.Multiple(() =>
            {
                Assert.That(userAssignedIdentity.Data.Tags.ContainsKey("key1"), Is.False);
                Assert.That(userAssignedIdentity.Data.Tags.ContainsKey("key2"), Is.True);
            });
        }
    }
}
