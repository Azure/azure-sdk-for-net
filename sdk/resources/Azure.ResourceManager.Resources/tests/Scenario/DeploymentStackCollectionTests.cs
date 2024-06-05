// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
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

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-CreateOrUpdate-");
            var deploymentStackData = CreateDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            ArmDeploymentStackResource deploymentStack =  (await Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData)).Value;

            Assert.AreEqual(deploymentStackName, deploymentStack.Data.Name);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-List-");
            var deploymentStackData = CreateDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            _ = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id));
            int count = 0;
            await foreach (var deploymentStack in deploymentStacks)
            {
                count++;
                await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
            }

            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-Get-");
            var deploymentStackData = CreateDeploymentStackDataWithTemplate(AzureLocation.WestUS);
            var deploymentStack = (await Client.GetArmDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed, deploymentStackName, deploymentStackData)).Value;

            var deploymentStackGet = (await Client.GetArmDeploymentStackAsync(new ResourceIdentifier(subscription.Id), deploymentStackName)).Value;

            AssertValidDeploymentStack(deploymentStack, deploymentStackGet);

            await deploymentStack.DeleteAsync(WaitUntil.Completed, unmanageActionResources: UnmanageActionResourceMode.Delete, unmanageActionResourceGroups: UnmanageActionResourceGroupMode.Delete, unmanageActionManagementGroups: UnmanageActionManagementGroupMode.Delete);
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
