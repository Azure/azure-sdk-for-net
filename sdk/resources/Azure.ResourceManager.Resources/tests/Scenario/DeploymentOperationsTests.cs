// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentOperationsTests : ResourcesTestBase
    {
        public DeploymentOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-D-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deployName, deploymentData)).Value;
            await deployment.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deployment.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
