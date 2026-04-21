// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources._Deployments;
using Azure.ResourceManager.Resources._Deployments.Models;
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
            var deployment = (await Client.GetDeployments(rg.Id).CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            await deployment.DeleteAsync(WaitUntil.Completed);
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deployment.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        [Ignore("WhatIf is not available on the generic at-scope DeploymentResource. The operation was only defined on per-scope interfaces (RG, subscription, tenant, management group) which are suppressed from C# in favor of the generic Extension.ScopeParameter interface.")]
        public async Task WhatIfAtResourceGroup()
        {
            // WhatIf operations are not exposed through the generic at-scope interface (DeploymentExtendeds).
            // They were only available on per-scope interfaces (DeploymentExtendedOperationGroup, Deployments,
            // DeploymentExtendedManagementGroup, DeploymentExtendedSubscriptionGroup) which are suppressed in
            // client.tsp to avoid duplicate ArmClient extension methods.
            // To use WhatIf, use the Azure.ResourceManager.Resources package's ArmDeploymentResource.WhatIfAsync().
            await Task.Yield();
        }
    }
}
