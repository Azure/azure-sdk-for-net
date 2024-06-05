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
            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-C-");
            var stackId = "/subscription/" + subscription.Id +  "/Microsoft.Resources/deploymentStacks/" + deploymentStackName;
            var deploymentStackData = CreateDeploymentStackDataWithEmptyTemplate(stackId, "westus");
            DeploymentStackResource deploymentStack =  (await Client.GetDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData)).Value;

            Assert.AreEqual(deploymentStackName, deploymentStack.Data.Name);
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-C-");
            var stackId = "/subscription/" + subscription.Id +  "/Microsoft.Resources/deploymentStacks/" + deploymentStackName;
            var deploymentStackData = CreateDeploymentStackDataWithEmptyTemplate(stackId, "westus");
            _ = (await Client.GetDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData)).Value;

            var deploymentStacks = Client.GetDeploymentStacks(new ResourceIdentifier(subscription.Id));
            int count = 0;
            await foreach (var deploymentStack in deploymentStacks)
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string deploymentStackName = Recording.GenerateAssetName("deployStackEx-C-");
            var stackId = "/subscription/" + subscription.Id +  "/Microsoft.Resources/deploymentStacks/" + deploymentStackName;
            var deploymentStackData = CreateDeploymentStackDataWithEmptyTemplate(stackId, "westus");
            var deploymentStack = (await Client.GetDeploymentStacks(new ResourceIdentifier(subscription.Id)).CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData)).Value;

            var deploymentStackGet = Client.GetDeploymentStack(new ResourceIdentifier(subscription.Id), deploymentStackName);
            AssertValidDeploymentStack(deploymentStack, deploymentStackGet);
        }

        [TestCase]
        [RecordedTest]
        public async Task Export()
        {
            // SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            // string deploymentStackName = Recording.GenerateAssetName("deployStackEx-C-");
            // var stackId = "/subscription/" + subscription.Id +  "/Microsoft.Resources/deploymentStacks/" + deploymentStackName;
            // var deploymentStackData = CreateDeploymentStackDataWithEmptyTemplate(stackId, "westus");
            // var deploymentStackCollection = Client.GetDeploymentStacks(new ResourceIdentifier(subscription.Id));
            
            // var _ = await deploymentStackCollection.CreateOrUpdateAsync(WaitUntil.Completed ,deploymentStackName, deploymentStackData);
            // var deploymentStackTemplate = deploymentStackCollection.Get()

            // var deploymentStackGet = Client.GetDeploymentStack(new ResourceIdentifier(subscription.Id), deploymentStackName);
            // AssertValidDeploymentStack(deploymentStack, deploymentStackGet);
        }


        private static void AssertValidDeploymentStack(DeploymentStackResource model, DeploymentStackResource getResult)
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
