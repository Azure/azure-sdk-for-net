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
    public class ApplicationOperationsTests : ResourcesTestBase
    {
        private string _tagKey;
        private string TagKey => _tagKey ??= Recording.GenerateAssetName("TagKey-");
        private string _tagValue;
        private string TagValue => _tagValue ??= Recording.GenerateAssetName("TagValue-");
        public ApplicationOperationsTests(bool isAsync)
            : base(isAsync, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-D-");
            ArmApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ArmApplicationDefinitionResource appDef = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-D-");
            ArmApplicationData applicationData = CreateApplicationData(appDef.Id, new ResourceIdentifier(subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-5-")), Recording.GenerateAssetName("s5"));
            ArmApplicationResource application = (await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, applicationData)).Value;
            await application.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await application.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [RecordedTest]
        public async Task AddTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-D-");
            ArmApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ArmApplicationDefinitionResource appDef = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-D-");
            ArmApplicationData applicationData = CreateApplicationData(appDef.Id, new ResourceIdentifier(subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-5-")), Recording.GenerateAssetName("s5"));
            ArmApplicationResource application = (await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, applicationData)).Value;
            var application2 = await application.AddTagAsync(TagKey, TagValue);
            Assert.IsTrue(application2.Value.Data.Tags.ContainsKey(TagKey));
            Assert.AreEqual(application2.Value.Data.Tags[TagKey], TagValue);
        }

        [RecordedTest]
        public async Task RemoveTag()
        {
            await AddTag();
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-D-");
            ArmApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ArmApplicationDefinitionResource appDef = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-D-");
            ArmApplicationData applicationData = CreateApplicationData(appDef.Id, new ResourceIdentifier(subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-5-")), Recording.GenerateAssetName("s5"));
            ArmApplicationResource application = (await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, applicationData)).Value;
            var application2 = await application.RemoveTagAsync(TagKey);
            Assert.IsFalse(application2.Value.Data.Tags.ContainsKey(TagKey));
        }

        [RecordedTest]
        public async Task SetTags()
        {
            await AddTag();
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-D-");
            ArmApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ArmApplicationDefinitionResource appDef = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-D-");
            ArmApplicationData applicationData = CreateApplicationData(appDef.Id, new ResourceIdentifier(subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-5-")), Recording.GenerateAssetName("s5"));
            ArmApplicationResource application = (await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, applicationData)).Value;
            var key = Recording.GenerateAssetName("TagKey-");
            var value = Recording.GenerateAssetName("TagValue-");
            var tags = new Dictionary<string, string>();
            var application2 = await application.SetTagsAsync(tags);
            Assert.IsFalse(application2.Value.Data.Tags.ContainsKey(TagKey));
            Assert.IsTrue(application2.Value.Data.Tags.ContainsKey(key));
            Assert.AreEqual(application2.Value.Data.Tags[key], value);
        }
    }
}
