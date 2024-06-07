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
    public class DeploymentStackCollectionTests : ResourcesTestBase
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
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackExRG-CreateOrUpdate-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            ArmDeploymentStackResource deploymentStack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(rg.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            Assert.AreEqual(deploymentStackName, deploymentStack.Data.Name);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-Get-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            var deploymentStack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(rg.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStackGet = (await Client.GetArmDeploymentStackAsync(new ResourceIdentifier(rg.Id), deploymentStackName)).Value;

            AssertValidDeploymentStack(deploymentStack, deploymentStackGet);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS);
            ResourceGroupResource rg = (await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData)).Value;

            string deploymentStackName = Recording.GenerateAssetName("deployStackRG-List-");
            var deploymentStackData = CreateRGDeploymentStackDataWithTemplate();
            _ = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(rg.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = Client.GetArmDeploymentStacks(new ResourceIdentifier(rg.Id));
            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-List-");
            var deploymentStackData = CreateDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            _ = (await subscription.GetArmDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = subscription.GetArmDeploymentStacks();
            int count = 0;
            await foreach (var deploymentStack in deploymentStacks)
            {
                count++;
                await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
            }

            Assert.AreEqual(count, 1);
            await rg.DeleteAsync(WaitUntil.Completed);
        }

        /* Sub Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-CreateOrUpdate-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            Assert.AreEqual(deploymentStackName, deploymentStack.Data.Name);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }

        [TestCase]
        [RecordedTest]
        public async Task ValidateSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-CreateOrUpdate-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            Assert.AreEqual(deploymentStackName, deploymentStack.Data.Name);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-Get-");
            var deploymentStackData = CreateDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            var deploymentStack = (await subscription.GetArmDeploymentStacks().CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStackGet = (await subscription.GetArmDeploymentStackAsync(deploymentStackName)).Value;

            AssertValidDeploymentStack(deploymentStack, deploymentStackGet);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListSub()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();

            string deploymentStackName = Recording.GenerateAssetName("deployStackSub-List-");
            var deploymentStackData = CreateSubDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            var stack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id));
            int count = 0;
            await foreach (var deploymentStack in deploymentStacks)
            {
                count++;
            }

            await stack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);

            // There are more stacks in the sub than just the one created for the test:
            Assert.GreaterOrEqual(count, 1);
        }

        /* MG Scoped Deployment Stack Tests */

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackExMG-CreateOrUpdate-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(managementGroup.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            Assert.AreEqual(deploymentStackName, deploymentStack.Data.Name);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }

        [TestCase]
        [RecordedTest]
        public async Task GetMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackMG-Get-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            var deploymentStack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(managementGroup.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStackGet = (await Client.GetArmDeploymentStackAsync(new ResourceIdentifier(managementGroup.Id), deploymentStackName)).Value;

            AssertValidDeploymentStack(deploymentStack, deploymentStackGet);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListMG()
        {
            ManagementGroupResource managementGroup = Client.GetManagementGroupResource(ManagementGroupResource.CreateResourceIdentifier("StacksSDKTest"));

            string deploymentStackName = Recording.GenerateAssetName("deployStackExMG-List-");
            var deploymentStackData = CreateMGDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            _ = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(managementGroup.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = Client.GetArmDeploymentStacks(new ResourceIdentifier(managementGroup.Id));
            int count = 0;
            await foreach (var deploymentStack in deploymentStacks)
            {
                count++;
                await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
            }

            Assert.AreEqual(count, 1);
        }

        private static void AssertValidDeploymentStack(ArmDeploymentStackResource model, ArmDeploymentStackResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.Location, getResult.Data.Location);
            Assert.AreEqual(model.Data.Tags, getResult.Data.Tags);

            Assert.AreEqual(model.Data.ActionOnUnmanage.Resources, getResult.Data.ActionOnUnmanage.Resources);
            Assert.AreEqual(model.Data.ActionOnUnmanage.ResourceGroups, getResult.Data.ActionOnUnmanage.ResourceGroups);
            Assert.AreEqual(model.Data.ActionOnUnmanage.ManagementGroups, getResult.Data.ActionOnUnmanage.ManagementGroups);
            Assert.AreEqual(model.Data.DenySettings.Mode, getResult.Data.DenySettings.Mode);
            Assert.AreEqual(model.Data.DenySettings.ApplyToChildScopes, getResult.Data.DenySettings.ApplyToChildScopes);
            Assert.AreEqual(model.Data.DenySettings.ExcludedPrincipals, getResult.Data.DenySettings.ExcludedPrincipals);
            Assert.AreEqual(model.Data.DenySettings.ExcludedActions, getResult.Data.DenySettings.ExcludedActions);
            Assert.AreEqual(model.Data.BypassStackOutOfSyncError, getResult.Data.BypassStackOutOfSyncError);
        }
    }
}
