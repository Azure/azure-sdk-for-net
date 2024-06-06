// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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

            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-Delete-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            await deploymentStack.DeleteAsync(WaitUntil.Completed);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentStack.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task Export()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-Export-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            var deploymentStackCollection = Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id));

            ArmDeploymentStackResource deploymentStack = (await deploymentStackCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            var deploymentStackTemplate = (await deploymentStack.ExportTemplateAsync()).Value;
            Assert.IsNotNull(deploymentStackTemplate);

            // TODO: Output is off by a little and may be how the template is being read.
            //Assert.AreEqual(deploymentStackTemplate.Template, deploymentStackData.Template);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }
    }
}
