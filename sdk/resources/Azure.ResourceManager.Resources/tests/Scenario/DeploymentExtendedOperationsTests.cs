// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/24578")]
    public class DeploymentExtendedOperationsTests : ResourcesTestBase
    {
        public DeploymentExtendedOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await Client.DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployExName = Recording.GenerateAssetName("deployEx-D-");
            Deployment deploymentExtendedData = CreateDeploymentExtendedData(CreateDeploymentProperties());
            DeploymentExtended deploymentExtended = (await rg.GetDeploymentExtendeds().CreateOrUpdateAsync(deployExName, deploymentExtendedData)).Value;
            await deploymentExtended.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentExtended.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
