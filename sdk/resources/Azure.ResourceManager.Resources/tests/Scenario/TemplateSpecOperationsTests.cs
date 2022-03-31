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
    public class TemplateSpecOperationsTests : ResourcesTestBase
    {
        private string _tagKey;
        private string TagKey => _tagKey ??= Recording.GenerateAssetName("TagKey-");
        private string _tagValue;
        private string TagValue => _tagValue ??= Recording.GenerateAssetName("TagValue-");

        public TemplateSpecOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-G-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            await templateSpec.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await templateSpec.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task AddTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-G-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            var templateSpec2 = await templateSpec.AddTagAsync(TagKey, TagValue);
            Assert.IsTrue(templateSpec2.Value.Data.Tags.ContainsKey(TagKey));
            Assert.AreEqual(templateSpec2.Value.Data.Tags[TagKey], TagValue);
        }

        [RecordedTest]
        public async Task RemoveTag()
        {
            await AddTag();
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-G-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            var templateSpec2 = await templateSpec.AddTagAsync(TagKey, TagValue);
            templateSpec2 = await templateSpec.RemoveTagAsync(TagKey);
            Assert.IsFalse(templateSpec2.Value.Data.Tags.ContainsKey(TagKey));
        }

        [RecordedTest]
        public async Task SetTags()
        {
            await AddTag();
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string templateSpecName = Recording.GenerateAssetName("templateSpec-G-");
            TemplateSpecData templateSpecData = CreateTemplateSpecData(templateSpecName);
            TemplateSpecResource templateSpec = (await rg.GetTemplateSpecs().CreateOrUpdateAsync(WaitUntil.Completed, templateSpecName, templateSpecData)).Value;
            var key = Recording.GenerateAssetName("TagKey-");
            var value = Recording.GenerateAssetName("TagValue-");
            var tags = new Dictionary<string, string>()
            {
                {key, value}
            };
            var templateSpec2 = await templateSpec.SetTagsAsync(tags);
            //Assert.IsFalse(templateSpec2.Value.Data.Tags.ContainsKey(key));
            Assert.IsTrue(templateSpec2.Value.Data.Tags.ContainsKey(key));
            Assert.AreEqual(templateSpec2.Value.Data.Tags[key], value);
        }
    }
}
