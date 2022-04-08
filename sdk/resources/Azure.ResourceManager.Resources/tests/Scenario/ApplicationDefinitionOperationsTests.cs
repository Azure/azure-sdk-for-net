// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Resources.Tests
{
    public class ApplicationDefinitionOperationsTests : ResourcesTestBase
    {
        private string _tagKey;
        private string TagKey => _tagKey ??= Recording.GenerateAssetName("TagKey-");
        private string _tagValue;
        private string TagValue => _tagValue ??= Recording.GenerateAssetName("TagValue-");

        public ApplicationDefinitionOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-C-");
            ArmApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            ArmApplicationDefinitionResource applicationDefinition = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, applicationDefinitionData)).Value;
            await applicationDefinition.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await applicationDefinition.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        public async Task AddTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-C-");
            ArmApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            ArmApplicationDefinitionResource applicationDefinition = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, applicationDefinitionData)).Value;
            ArmApplicationDefinitionResource applicationDefinition2 = await applicationDefinition.AddTagAsync(TagKey, TagValue);
            Assert.IsTrue(applicationDefinition2.Data.Tags.ContainsKey(TagKey));
            Assert.AreEqual(applicationDefinition2.Data.Tags[TagKey], TagValue);
        }

        [TestCase]
        public async Task RemoveTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-C-");
            ArmApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            ArmApplicationDefinitionResource applicationDefinition = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, applicationDefinitionData)).Value;
            var applicationDefinition2 = await applicationDefinition.RemoveTagAsync(TagKey);
            Assert.IsFalse(applicationDefinition2.Value.Data.Tags.ContainsKey(TagKey));
        }

        [TestCase]
        public async Task SetTags()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-C-");
            ArmApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            ArmApplicationDefinitionResource applicationDefinition = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, applicationDefinitionData)).Value;
            var key = Recording.GenerateAssetName("TagKey-");
            var value = Recording.GenerateAssetName("TagValue-");
            var tags = new Dictionary<string, string>()
            {
                {key, value}
            };
            var applicationDefinition2 = await applicationDefinition.SetTagsAsync(tags);
            Assert.IsTrue(applicationDefinition2.Value.Data.Tags.ContainsKey(key));
            Assert.AreEqual(applicationDefinition2.Value.Data.Tags[key], value);
        }
    }
}
