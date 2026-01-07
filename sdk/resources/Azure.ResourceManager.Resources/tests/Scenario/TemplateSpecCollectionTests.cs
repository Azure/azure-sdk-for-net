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
            Assert.That(templateSpec.Data.Name, Is.EqualTo(templateSpecName));
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
            Assert.That(count, Is.EqualTo(1));
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
            Assert.That(count, Is.EqualTo(1));
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
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.Location, Is.EqualTo(model.Data.Location));
            Assert.That(getResult.Data.Tags, Is.EqualTo(model.Data.Tags));
            Assert.That(getResult.Data.Description, Is.EqualTo(model.Data.Description));
            Assert.That(getResult.Data.DisplayName, Is.EqualTo(model.Data.DisplayName));
            Assert.That(getResult.Data.Metadata, Is.EqualTo(model.Data.Metadata));
            Assert.That(getResult.Data.Versions.Count, Is.EqualTo(model.Data.Versions.Count));
            foreach (var kv in model.Data.Versions)
            {
                var getTemplateSpecVersionInfo = getResult.Data.Versions[kv.Key];
                Assert.That(getTemplateSpecVersionInfo, Is.Not.Null);
                Assert.That(getResult.Data.Versions[kv.Key].Description, Is.EqualTo(model.Data.Versions[kv.Key].Description));
                Assert.That(getResult.Data.Versions[kv.Key].TimeCreated, Is.EqualTo(model.Data.Versions[kv.Key].TimeCreated));
                Assert.That(getResult.Data.Versions[kv.Key].TimeModified, Is.EqualTo(model.Data.Versions[kv.Key].TimeModified));
            }
        }
    }
}
