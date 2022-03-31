// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class TemplateSpecCollectionTests : ResourcesTestBase
    {
        public TemplateSpecCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-C-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            Assert.AreEqual(templateSpecName, templateSpec.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, null, templateSpecData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-L-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            _ = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            int count = 0;
            await foreach (var tempTemplateSpec in rg.GetTemplateSpecs().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-L-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            int count = 0;
            await foreach (var tempTemplateSpec in subscription.GetTemplateSpecsAsync())
            {
                if (tempTemplateSpec.Data.Id == templateSpec.Data.Id)
                {
                    count++;
                }
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-G-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            TemplateSpecResource getTemplateSpec = await rg.GetTemplateSpecs().GetAsync(templateSpecName);
            AssertValidTemplateSpec(templateSpec, getTemplateSpec);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetTemplateSpecs().GetAsync(null));
        }

        private static void AssertValidTemplateSpec(TemplateSpecResource model, TemplateSpecResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.Location, getResult.Data.Location);
            Assert.AreEqual(model.Data.Tags, getResult.Data.Tags);
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
            Assert.AreEqual(model.Data.Metadata, getResult.Data.Metadata);
            Assert.AreEqual(model.Data.Versions.Count, getResult.Data.Versions.Count);
            foreach (var kv in model.Data.Versions)
            {
                var getTemplateSpecVersionInfo = getResult.Data.Versions[kv.Key];
                Assert.NotNull(getTemplateSpecVersionInfo);
                Assert.AreEqual(model.Data.Versions[kv.Key].Description, getResult.Data.Versions[kv.Key].Description);
                Assert.AreEqual(model.Data.Versions[kv.Key].TimeCreated, getResult.Data.Versions[kv.Key].TimeCreated);
                Assert.AreEqual(model.Data.Versions[kv.Key].TimeModified, getResult.Data.Versions[kv.Key].TimeModified);
            }
        }
    }
}
