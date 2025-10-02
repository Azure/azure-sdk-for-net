// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.DeploymentStacks.Tests
{
    public class DeploymentStackOperationsTests : DeploymentStacksManagementTestBase
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
            ResourceGroupData rgData = new ResourceGroupData(DeploymentStacksManagementTestConstants.DefaultLocation);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-Delete-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            DeploymentStackResource deploymentStack = (await rg.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
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
            ResourceGroupData rgData = new ResourceGroupData(DeploymentStacksManagementTestConstants.DefaultLocation);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-Export-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            DeploymentStackResource deploymentStack = (await rg.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            var deploymentStackTemplate = (await deploymentStack.ExportTemplateAsync()).Value;

            Assert.IsNotNull(deploymentStackTemplate);

            // TODO: Output is off by a little and may be how the template is being read.
            //Assert.AreEqual(deploymentStackTemplate.Template, deploymentStackData.Template);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(DeploymentStacksManagementTestConstants.DefaultLocation);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-Validate-");
            var deploymentStackId = new ResourceIdentifier(rg.Id + "/providers/Microsoft.Resources/deploymentStacks/" + deploymentStackName);
            var deploymentStack = Client.GetDeploymentStackResource(deploymentStackId);

            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            DeploymentStackValidateResult deploymentStackValidateResult = (await deploymentStack.ValidateStackAsync(WaitUntil.Completed, deploymentStackData)).Value;

            Assert.IsNotNull(deploymentStackValidateResult);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        /* Sub Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task DeleteSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackSub-Delete-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            DeploymentStackResource deploymentStack = (await subscription.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            await deploymentStack.DeleteAsync(WaitUntil.Completed);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () => await deploymentStack.GetAsync());
            Assert.AreEqual(404, ex.Status);
        }

        [TestCase]
        [RecordedTest]
        public async Task ExportSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackSub-Export-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            DeploymentStackResource deploymentStack = (await subscription.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            var deploymentStackTemplate = (await deploymentStack.ExportTemplateAsync()).Value;
            Assert.IsNotNull(deploymentStackTemplate);

            // TODO: Output is off by a little and may be how the template is being read.
            //Assert.AreEqual(deploymentStackTemplate.Template, deploymentStackData.Template);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackSub-Validate-");
            var deploymentStackId = new ResourceIdentifier(subscription.Id + "/providers/Microsoft.Resources/deploymentStacks/" + deploymentStackName);
            var deploymentStack = Client.GetDeploymentStackResource(deploymentStackId);

            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            DeploymentStackValidateResult deploymentStackValidateResult = (await deploymentStack.ValidateStackAsync(WaitUntil.Completed, deploymentStackData)).Value;
            Assert.NotNull(deploymentStackValidateResult);
        }

        /* MG Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task DeleteMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackMG-Delete-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            DeploymentStackResource deploymentStack = (await managementGroup.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
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
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            DeploymentStackResource deploymentStack = (await managementGroup.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;
            var deploymentStackTemplate = (await deploymentStack.ExportTemplateAsync()).Value;
            Assert.IsNotNull(deploymentStackTemplate);

            // TODO: Output is off by a little and may be how the template is being read.
            //Assert.AreEqual(deploymentStackTemplate.Template, deploymentStackData.Template);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackMG-Validate-");
            var deploymentStackId = new ResourceIdentifier(managementGroup.Id + "/providers/Microsoft.Resources/deploymentStacks/" + deploymentStackName);
            var deploymentStack = Client.GetDeploymentStackResource(deploymentStackId);

            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            DeploymentStackValidateResult deploymentStackValidateResult = (await deploymentStack.ValidateStackAsync(WaitUntil.Completed, deploymentStackData)).Value;
            Assert.IsNotNull(deploymentStackValidateResult);
        }
    }
}
