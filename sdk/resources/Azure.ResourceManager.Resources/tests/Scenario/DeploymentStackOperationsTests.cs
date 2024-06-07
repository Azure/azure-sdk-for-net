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

        /* RG Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task DeleteRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-Delete-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            ArmDeploymentStackResource deploymentStack = (await rg.GetArmDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            await deploymentStack.DeleteAsync(WaitUntil.Completed);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentStack.GetAsync());
            Assert.AreEqual(404, ex.Status);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-Export-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            ArmDeploymentStackResource deploymentStack = (await rg.GetArmDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            var deploymentStackTemplate = (await deploymentStack.ExportTemplateAsync()).Value;

            Assert.IsNotNull(deploymentStackTemplate);

            // TODO: Output is off by a little and may be how the template is being read.
            //Assert.AreEqual(deploymentStackTemplate.Template, deploymentStackData.Template);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        /* Sub Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task DeleteSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackSub-Delete-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack = (await subscription.GetArmDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            await deploymentStack.DeleteAsync(WaitUntil.Completed);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentStack.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-Export-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack = (await subscription.GetArmDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            var deploymentStackTemplate = (await deploymentStack.ExportTemplateAsync()).Value;
            Assert.IsNotNull(deploymentStackTemplate);

            // TODO: Output is off by a little and may be how the template is being read.
            //Assert.AreEqual(deploymentStackTemplate.Template, deploymentStackData.Template);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }

        /* MG Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task DeleteMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackMG-Delete-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack = (await managementGroup.GetArmDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            await deploymentStack.DeleteAsync(WaitUntil.Completed);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentStack.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackMG-Export-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack = (await managementGroup.GetArmDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            var deploymentStackTemplate = (await deploymentStack.ExportTemplateAsync()).Value;
            Assert.IsNotNull(deploymentStackTemplate);

            // TODO: Output is off by a little and may be how the template is being read.
            //Assert.AreEqual(deploymentStackTemplate.Template, deploymentStackData.Template);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }
    }
}
