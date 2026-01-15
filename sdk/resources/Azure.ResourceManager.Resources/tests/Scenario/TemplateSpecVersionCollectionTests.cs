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
    public class TemplateSpecVersionCollectionTests : ResourcesTestBase
    {
        public TemplateSpecVersionCollectionTests(bool isAsync)
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
            const string version = "v1";
            TemplateSpecVersionData templateSpecVersionData = CreateTemplateSpecVersionData();
            TemplateSpecVersionResource templateSpecVersion = (await templateSpec.GetTemplateSpecVersions().CreateOrUpdateAsync(WaitUntil.Completed, version, templateSpecVersionData)).Value;
            Assert.That(templateSpecVersion.Data.Name, Is.EqualTo(version));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, null, templateSpecData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-L-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            const string version = "v1";
            TemplateSpecVersionData templateSpecVersionData = CreateTemplateSpecVersionData();
            _ = (await templateSpec.GetTemplateSpecVersions().CreateOrUpdateAsync(WaitUntil.Completed, version, templateSpecVersionData)).Value;
            int count = 0;
            await foreach (var tempTemplateSpecVersion in templateSpec.GetTemplateSpecVersions().GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(1));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-G-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            const string version = "v1";
            TemplateSpecVersionData templateSpecVersionData = CreateTemplateSpecVersionData();
            TemplateSpecVersionResource templateSpecVersion = (await templateSpec.GetTemplateSpecVersions().CreateOrUpdateAsync(WaitUntil.Completed, version, templateSpecVersionData)).Value;
            TemplateSpecVersionResource getTemplateSpecVersion = await templateSpec.GetTemplateSpecVersions().GetAsync(version);
            AssertValidTemplateSpecVersion(templateSpecVersion, getTemplateSpecVersion);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await templateSpec.GetTemplateSpecVersions().GetAsync(null));
        }

        private static void AssertValidTemplateSpecVersion(TemplateSpecVersionResource model, TemplateSpecVersionResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.Location, Is.EqualTo(model.Data.Location));
            Assert.That(getResult.Data.Tags, Is.EqualTo(model.Data.Tags));
            Assert.That(getResult.Data.Description, Is.EqualTo(model.Data.Description));
            Assert.That(getResult.Data.LinkedTemplates.Count, Is.EqualTo(model.Data.LinkedTemplates.Count));
            for (int i = 0; i < model.Data.LinkedTemplates.Count; ++i)
            {
                Assert.That(getResult.Data.LinkedTemplates[i].Path, Is.EqualTo(model.Data.LinkedTemplates[i].Path));
                Assert.That(getResult.Data.LinkedTemplates[i].Template, Is.EqualTo(model.Data.LinkedTemplates[i].Template));
            }
            Assert.That(getResult.Data.Metadata, Is.EqualTo(model.Data.Metadata));
            Assert.That(getResult.Data.MainTemplate.ToArray(), Is.EqualTo(model.Data.MainTemplate.ToArray()));
            Assert.That(getResult.Data.UiFormDefinition, Is.EqualTo(model.Data.UiFormDefinition));
        }
    }
}
