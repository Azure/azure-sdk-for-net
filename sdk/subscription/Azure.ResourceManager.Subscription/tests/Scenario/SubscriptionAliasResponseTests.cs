// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Subscription.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Subscription.Tests
{
    internal class SubscriptionAliasResponseTests : SubscriptionManagementTestBase
    {
        private SubscriptionAliasCollection _aliasCollection => GetAliasCollection().Result;

        public SubscriptionAliasResponseTests(bool isAsync) : base(isAsync)
        {
        }

        [TearDown]
        public async Task TestTearDown()
        {
            var list = await _aliasCollection.GetAllAsync().ToEnumerableAsync();
            foreach (var item in list)
            {
                await item.DeleteAsync(WaitUntil.Completed);
            }
        }

        private async Task<SubscriptionAliasCollection> GetAliasCollection()
        {
            var tenants = await Client.GetTenants().GetAllAsync().ToEnumerableAsync();
            return tenants.FirstOrDefault().GetSubscriptionAliases();
        }

        private async Task<SubscriptionAliasResource> CreateAliasResponse(string aliasName)
        {
            var data = new SubscriptionAliasCreateOrUpdateContent()
            {
                 Workload = "Production",
                SubscriptionId = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID")
            };
            data.AdditionalProperties = new SubscriptionAliasAdditionalProperties();
            data.AdditionalProperties.Tags.Add(new KeyValuePair<string, string>("tag1", "test1"));
            data.AdditionalProperties.Tags.Add(new KeyValuePair<string, string>("tag2", "test2"));
            var alias = await _aliasCollection.CreateOrUpdateAsync(WaitUntil.Completed, aliasName, data);
            return alias.Value;
        }

        [RecordedTest]
        [Ignore("pipeline playback error")]
        public async Task CreateOrUpdate()
        {
            string aliasName = Recording.GenerateAssetName("test-alias-");
            var alias = await CreateAliasResponse(aliasName);
            ValidateAliasResponse(alias);
            Assert.AreEqual(aliasName, alias.Data.Name);
        }

        [RecordedTest]
        [Ignore("pipeline playback error")]
        public async Task Exist()
        {
            string aliasName = Recording.GenerateAssetName("test-alias-");
            var alias = await CreateAliasResponse(aliasName);
            bool flag = await _aliasCollection.ExistsAsync(aliasName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        [Ignore("pipeline playback error")]
        public async Task Get()
        {
            string aliasName = Recording.GenerateAssetName("test-alias-");
            await CreateAliasResponse(aliasName);
            var alias = await _aliasCollection.GetAsync(aliasName);
            ValidateAliasResponse(alias);
            Assert.AreEqual(aliasName, alias.Value.Data.Name);
        }

        [RecordedTest]
        [Ignore("pipeline playback error")]
        public async Task GetAll()
        {
            string aliasName = Recording.GenerateAssetName("test-alias-");
            await CreateAliasResponse(aliasName);
            var list = await _aliasCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateAliasResponse(list.FirstOrDefault());
        }

        [RecordedTest]
        [Ignore("pipeline playback error")]
        public async Task Delete()
        {
            string aliasName = Recording.GenerateAssetName("test-alias-");
            var alias = await CreateAliasResponse(aliasName);
            bool flag = await _aliasCollection.ExistsAsync(aliasName);
            Assert.IsTrue(flag);

            await alias.DeleteAsync(WaitUntil.Completed);
            flag = await _aliasCollection.ExistsAsync(aliasName);
            Assert.IsFalse(flag);
        }

        private void ValidateAliasResponse(SubscriptionAliasResource alias)
        {
            Assert.IsNotNull(alias);
            Assert.AreEqual("Microsoft.Subscription", alias.Data.ResourceType.Namespace);
        }
    }
}
