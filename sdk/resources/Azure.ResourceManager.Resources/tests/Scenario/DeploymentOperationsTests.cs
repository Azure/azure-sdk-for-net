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
            string deploymentName = Recording.GenerateAssetName("deployEx-D-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deploymentName, deploymentData)).Value;
            await deployment.DeleteAsync();
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deployment.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task WhatIfAtRg()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deploymentName = Recording.GenerateAssetName("deploy-WhatIf-");
            DeploymentInput deploymentData = new DeploymentInput(new DeploymentProperties(DeploymentMode.Incremental)
            {
                TemplateLink = new TemplateLink
                {
                    Uri = "https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/what-if/what-if-before.json"
                }
            });
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deploymentName, deploymentData)).Value;
            DeploymentWhatIfProperties deploymentWhatIfProperties = new DeploymentWhatIfProperties(DeploymentMode.Incremental)
            {
                TemplateLink = new TemplateLink
                {
                    Uri = "https://raw.githubusercontent.com/Azure/azure-docs-json-samples/master/azure-resource-manager/what-if/what-if-after.json"
                }
            };
            DeploymentWhatIfOperation deploymentWhatIfOperation = await deployment.WhatIfAsync(deploymentWhatIfProperties);
            Assert.NotNull(deploymentWhatIfOperation.Value);
            Assert.AreEqual(deploymentWhatIfOperation.Value.Status, "Succeeded");
        }
    }
}
