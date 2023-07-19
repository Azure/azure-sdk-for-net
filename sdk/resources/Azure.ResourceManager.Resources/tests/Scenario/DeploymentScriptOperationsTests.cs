// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentScriptOperationsTests : ResourcesTestBase
    {
        public DeploymentScriptOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
            string deployScriptName = Recording.GenerateAssetName("deployScript-D-");
            var deploymentScriptData = await GetDeploymentScriptDataAsync();
            var deploymentScript = (await rg.GetArmDeploymentScripts().CreateOrUpdateAsync(WaitUntil.Completed, deployScriptName, deploymentScriptData)).Value;
            await deploymentScript.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentScript.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
