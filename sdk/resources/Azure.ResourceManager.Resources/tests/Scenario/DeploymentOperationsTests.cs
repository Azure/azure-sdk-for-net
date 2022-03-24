// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
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
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-D-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            await deployment.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deployment.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task WhatIfAtResourceGroup()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-5-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroup rg = lro.Value;
            ResourceIdentifier deploymentResourceIdentifier = Deployment.CreateResourceIdentifier(rg.Id, "testDeploymentWhatIf");
            Deployment deployment = Client.GetDeployment(deploymentResourceIdentifier);
            DeploymentWhatIf deploymentWhatIf = new DeploymentWhatIf(new DeploymentWhatIfProperties(DeploymentMode.Incremental)
            {
                Template = CreateDeploymentPropertiesUsingString().Template,
                Parameters = CreateDeploymentPropertiesUsingJsonElement().Parameters
            });
            WhatIfOperationResult whatIfOperationResult = (await deployment.WhatIfAsync(WaitUntil.Completed, deploymentWhatIf)).Value;
            Assert.AreEqual(whatIfOperationResult.Status, "Succeeded");
            Assert.AreEqual(whatIfOperationResult.Changes.Count, 1);
            Assert.AreEqual(whatIfOperationResult.Changes[0].ChangeType, ChangeType.Create);
        }
    }
}
