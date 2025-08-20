// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Deployments.Tests
{
    public class DeploymentOperationsTests : DeploymentsTestBase
    {
        public DeploymentOperationsTests(bool isAsync)
            : base(isAsync)
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
            string deployName = Recording.GenerateAssetName("deployEx-D-");
            var deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            var deployment = (await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            await deployment.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deployment.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task WhatIfAtResourceGroup()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            ResourceIdentifier deploymentResourceIdentifier = ArmDeploymentResource.CreateResourceIdentifier(rg.Id, "testDeploymentWhatIf");
            ArmDeploymentResource deployment = Client.GetArmDeploymentResource(deploymentResourceIdentifier);
            var deploymentWhatIf = new ArmDeploymentWhatIfContent(new ArmDeploymentWhatIfProperties(ArmDeploymentMode.Incremental)
            {
                Template = CreateDeploymentPropertiesUsingString().Template,
                Parameters = CreateDeploymentPropertiesUsingJsonElement().Parameters
            });
            WhatIfOperationResult whatIfOperationResult = (await deployment.WhatIfAsync(WaitUntil.Completed, deploymentWhatIf)).Value;
            Assert.AreEqual(whatIfOperationResult.Status, "Succeeded");
            Assert.AreEqual(whatIfOperationResult.Changes.Count, 1);
            Assert.AreEqual(whatIfOperationResult.Changes[0].ChangeType, WhatIfChangeType.Create);
        }
    }
}
