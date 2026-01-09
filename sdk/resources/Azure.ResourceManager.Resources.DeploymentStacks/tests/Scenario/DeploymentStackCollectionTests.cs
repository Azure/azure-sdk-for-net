// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.DeploymentStacks.Tests
{
    public class DeploymentStackCollectionTests : DeploymentStacksManagementTestBase
    {
        public DeploymentStackCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record
        {
        }

        /* RG Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(DeploymentStacksManagementTestConstants.DefaultLocation);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-CreateOrUpdate-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            var deploymentStack =  (await rg.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData)).Value;

            Assert.That(deploymentStack.Data.Name, Is.EqualTo(deploymentStackName));

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(DeploymentStacksManagementTestConstants.DefaultLocation);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-Get-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            var deploymentStack = (await rg.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStackGet = (await rg.GetDeploymentStackAsync(deploymentStackName)).Value;

            AssertValidDeploymentStack(deploymentStack, deploymentStackGet);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(DeploymentStacksManagementTestConstants.DefaultLocation);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-List-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            var getStack = (await rg.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = rg.GetDeploymentStacks();
            int count = 0;
            await foreach (var deploymentStack in deploymentStacks)
            {
                count++;
            }

            Assert.That(count, Is.EqualTo(1));
            await getStack.DeleteAsync(WaitUntil.Completed);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        /* Sub Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackSub-CreateOrUpdate-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            DeploymentStackResource deploymentStack = (await subscription.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            Assert.That(deploymentStack.Data.Name, Is.EqualTo(deploymentStackName));

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackSub-Get-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            var deploymentStack = (await subscription.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStackGet = (await subscription.GetDeploymentStackAsync(deploymentStackName)).Value;

            AssertValidDeploymentStack(deploymentStack, deploymentStackGet);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackSub-List-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            var getStack = (await subscription.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = subscription.GetDeploymentStacks();
            int count = 0;
            await foreach (var deploymentStack in deploymentStacks)
            {
                count++;
            }

            await getStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);

            // There are more stacks in the sub than just the one created for the test:
            Assert.That(count, Is.GreaterThanOrEqualTo(1));
        }

        /* MG Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackExMG-CreateOrUpdate-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            DeploymentStackResource deploymentStack = (await managementGroup.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            Assert.That(deploymentStack.Data.Name, Is.EqualTo(deploymentStackName));

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackMG-Get-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            var deploymentStack = (await managementGroup.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStackGet = (await managementGroup.GetDeploymentStackAsync(deploymentStackName)).Value;

            AssertValidDeploymentStack(deploymentStack, deploymentStackGet);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Detach, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Detach, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Detach);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackExMG-List-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(DeploymentStacksManagementTestConstants.DefaultLocation);
            var getStack = (await managementGroup.GetDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = managementGroup.GetDeploymentStacks();
            int count = 0;
            await foreach (var deploymentStack in deploymentStacks)
            {
                count++;
            }

            Assert.That(count, Is.GreaterThanOrEqualTo(1));
            await getStack.DeleteAsync(WaitUntil.Completed);
        }

        private static void AssertValidDeploymentStack(DeploymentStackResource model, DeploymentStackResource getResult)
        {
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
                Assert.That(getResult.Data.Location, Is.EqualTo(model.Data.Location));
                Assert.That(getResult.Data.Tags, Is.EqualTo(model.Data.Tags));

                Assert.That(getResult.Data.ActionOnUnmanage.Resources, Is.EqualTo(model.Data.ActionOnUnmanage.Resources));
                Assert.That(getResult.Data.ActionOnUnmanage.ResourceGroups, Is.EqualTo(model.Data.ActionOnUnmanage.ResourceGroups));
                Assert.That(getResult.Data.ActionOnUnmanage.ManagementGroups, Is.EqualTo(model.Data.ActionOnUnmanage.ManagementGroups));
                Assert.That(getResult.Data.DenySettings.Mode, Is.EqualTo(model.Data.DenySettings.Mode));
                Assert.That(getResult.Data.DenySettings.ApplyToChildScopes, Is.EqualTo(model.Data.DenySettings.ApplyToChildScopes));
                Assert.That(getResult.Data.DenySettings.ExcludedPrincipals, Is.EqualTo(model.Data.DenySettings.ExcludedPrincipals));
                Assert.That(getResult.Data.DenySettings.ExcludedActions, Is.EqualTo(model.Data.DenySettings.ExcludedActions));
                Assert.That(getResult.Data.BypassStackOutOfSyncError, Is.EqualTo(model.Data.BypassStackOutOfSyncError));
            });
        }
    }
}
