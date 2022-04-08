// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.ResourceManager.Resources;
namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentScriptOperationsTests : ResourcesTestBase
    {
        private string _tagKey;
        private string TagKey => _tagKey ??= Recording.GenerateAssetName("TagKey-");
        private string _tagValue;
        private string TagValue => _tagValue ??= Recording.GenerateAssetName("TagValue-");
        public DeploymentScriptOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-D-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            var deploymentScript = (await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData)).Value;
            await deploymentScript.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentScript.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        public async Task AddTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-D-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            var deploymentScript = (await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData)).Value;
            var deploymentScript2 = await deploymentScript.AddTagAsync(TagKey, TagValue);
            Assert.IsTrue(deploymentScript2.Value.Data.Tags.ContainsKey(TagKey));
            Assert.AreEqual(deploymentScript2.Value.Data.Tags[TagKey], TagValue);
        }

        [TestCase]
        public async Task RemoveTag()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-D-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            var deploymentScript = (await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData)).Value;
            var tagKey = Recording.GenerateAssetName("TagKey-");
            var tagValue = Recording.GenerateAssetName("TagValue-");
            var deploymentScript2 = (await deploymentScript.AddTagAsync(tagKey, tagValue)).Value;
            var deploymentScript3 = await deploymentScript2.RemoveTagAsync(tagKey);
            Assert.IsFalse(deploymentScript3.Value.Data.Tags.ContainsKey(tagKey));
        }

        [TestCase]
        public async Task SetTags()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-D-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            var deploymentScript = (await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData)).Value;
            var key = Recording.GenerateAssetName("TagKey-");
            var value = Recording.GenerateAssetName("TagValue-");
            var tags = new Dictionary<string, string>()
            {
                {key, value}
            };
            var deploymentScript2 = await deploymentScript.SetTagsAsync(tags);
            //Assert.IsFalse(deploymentScript2.Value.Data.Tags.ContainsKey(key));
            Assert.IsTrue(deploymentScript2.Value.Data.Tags.ContainsKey(key));
            Assert.AreEqual(deploymentScript2.Value.Data.Tags[key], value);
        }
    }
}
