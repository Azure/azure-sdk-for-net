// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure.ResourceManager.Resources.Tests
{
    public class TemplateSpecVersionOperationsTests : ResourcesTestBase
    {
        private string _tagKey;
        private string TagKey => _tagKey ??= Recording.GenerateAssetName("TagKey-");
        private string _tagValue;
        private string TagValue => _tagValue ??= Recording.GenerateAssetName("TagValue-");

        public TemplateSpecVersionOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        public async Task Delete()
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
            await templateSpecVersion.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await templateSpecVersion.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        public async Task AddTag()
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
            var templateSpecVersion2 = await templateSpecVersion.AddTagAsync(TagKey, TagValue);
            Assert.IsTrue(templateSpecVersion2.Value.Data.Tags.ContainsKey(TagKey));
            Assert.AreEqual(templateSpecVersion2.Value.Data.Tags[TagKey], TagValue);
        }

        [TestCase]
        public async Task RemoveTag()
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
            var templateSpecVersion2 = await templateSpecVersion.AddTagAsync(TagKey, TagValue);
            templateSpecVersion2 = await templateSpecVersion.RemoveTagAsync(TagKey);
            Assert.IsFalse(templateSpecVersion2.Value.Data.Tags.ContainsKey(TagKey));
        }

        [TestCase]
        public async Task SetTags()
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
            var key = Recording.GenerateAssetName("TagKey-");
            var value = Recording.GenerateAssetName("TagValue-");
            var tags = new Dictionary<string, string>()
            {
                {key, value}
            };
            var templateSpecVersion2 = await templateSpecVersion.SetTagsAsync(tags);
            //Assert.IsFalse(templateSpecVersion2.Value.Data.Tags.ContainsKey(key));
            Assert.IsTrue(templateSpecVersion2.Value.Data.Tags.ContainsKey(key));
            Assert.AreEqual(templateSpecVersion2.Value.Data.Tags[key], value);
        }
    }
}
