// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-C-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpec templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(templateSpecName, templateSpecData)).Value;
            const string version = "v1";
            TemplateSpecVersionData templateSpecVersionData = CreateTemplateSpecVersionData();
            TemplateSpecVersion templateSpecVersion = (await templateSpec.GetTemplateSpecVersions().CreateOrUpdateAsync(version, templateSpecVersionData)).Value;
            Assert.AreEqual(version, templateSpecVersion.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetTemplateSpecs().CreateOrUpdateAsync(null, templateSpecData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetTemplateSpecs().CreateOrUpdateAsync(templateSpecName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-L-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpec templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(templateSpecName, templateSpecData)).Value;
            const string version = "v1";
            TemplateSpecVersionData templateSpecVersionData = CreateTemplateSpecVersionData();
            _ = (await templateSpec.GetTemplateSpecVersions().CreateOrUpdateAsync(version, templateSpecVersionData)).Value;
            int count = 0;
            await foreach (var tempTemplateSpecVersion in templateSpec.GetTemplateSpecVersions().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-G-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpec templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(templateSpecName, templateSpecData)).Value;
            const string version = "v1";
            TemplateSpecVersionData templateSpecVersionData = CreateTemplateSpecVersionData();
            TemplateSpecVersion templateSpecVersion = (await templateSpec.GetTemplateSpecVersions().CreateOrUpdateAsync(version, templateSpecVersionData)).Value;
            TemplateSpecVersion getTemplateSpecVersion = await templateSpec.GetTemplateSpecVersions().GetAsync(version);
            AssertValidTemplateSpecVersion(templateSpecVersion, getTemplateSpecVersion);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await templateSpec.GetTemplateSpecVersions().GetAsync(null));
        }

        private static void AssertValidTemplateSpecVersion(TemplateSpecVersion model, TemplateSpecVersion getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Location, getResult.Data.Location);
            Assert.AreEqual(model.Data.Tags, getResult.Data.Tags);
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.LinkedTemplates.Count, getResult.Data.LinkedTemplates.Count);
            for (int i = 0; i < model.Data.LinkedTemplates.Count; ++i)
            {
                Assert.AreEqual(model.Data.LinkedTemplates[i].Path, getResult.Data.LinkedTemplates[i].Path);
                Assert.AreEqual(model.Data.LinkedTemplates[i].Template, getResult.Data.LinkedTemplates[i].Template);
            }
            Assert.AreEqual(model.Data.Metadata, getResult.Data.Metadata);
            Assert.AreEqual(model.Data.MainTemplate, getResult.Data.MainTemplate);
            Assert.AreEqual(model.Data.UiFormDefinition, getResult.Data.UiFormDefinition);
        }
    }
}
