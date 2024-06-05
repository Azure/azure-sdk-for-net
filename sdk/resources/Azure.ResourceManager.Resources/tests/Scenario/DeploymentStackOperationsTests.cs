// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentStackOperationsTests : ResourcesTestBase
    {
        public DeploymentStackOperationsTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task Delete()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-C-");
            var stackId = "/subscription/" + subscription.Id +  "/Microsoft.Resources/deploymentStacks/" + deploymentStackName;
            var deploymentStackData = CreateDeploymentStackDataWithEmptyTemplate(stackId, "westus");
            DeploymentStackResource deploymentStack =  (await Client.GetDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData)).Value;
            await deploymentStack.DeleteAsync(WaitUntil.Completed);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentStack.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }
    }
}
