// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployScriptName = Recording.GenerateAssetName("deployScript-D-");
            DeploymentScriptData deploymentScriptData = await GetDeploymentScriptDataAsync();
            DeploymentScript deploymentScript = (await rg.GetDeploymentScripts().CreateOrUpdateAsync(deployScriptName, deploymentScriptData)).Value;
            await deploymentScript.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentScript.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
