// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentOperationCollectionTests : ResourcesTestBase
    {
        public DeploymentOperationCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployExName = Recording.GenerateAssetName("deployEx-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deployExName, deploymentData)).Value;
            int count = 0;
            await foreach (var tempDeploymentOperation in deployment.GetDeploymentOperations().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 2); //One deployment contains two operations: Create and EvaluteDeploymentOutput
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployExName = Recording.GenerateAssetName("deployEx-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deployExName, deploymentData)).Value;
            await foreach (var tempDeploymentOperation in deployment.GetDeploymentOperations().GetAllAsync())
            {
                DeploymentOperation getDeploymentOperation = await deployment.GetDeploymentOperations().GetAsync(tempDeploymentOperation.Data.OperationId);
                AssertValidDeploymentOperation(tempDeploymentOperation, getDeploymentOperation);
            }
        }

        private static void AssertValidDeploymentOperation(DeploymentOperation model, DeploymentOperation getResult)
        {
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.OperationId, getResult.Data.OperationId);
            if (model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.AreEqual(model.Data.Properties.ProvisioningState, getResult.Data.Properties.ProvisioningState);
                Assert.AreEqual(model.Data.Properties.ProvisioningOperation, getResult.Data.Properties.ProvisioningOperation);
                Assert.AreEqual(model.Data.Properties.Timestamp, getResult.Data.Properties.Timestamp);
                Assert.AreEqual(model.Data.Properties.Duration, getResult.Data.Properties.Duration);
                Assert.AreEqual(model.Data.Properties.ServiceRequestId, getResult.Data.Properties.ServiceRequestId);
                Assert.AreEqual(model.Data.Properties.StatusCode, getResult.Data.Properties.StatusCode);
                //Assert.AreEqual(model.Data.Properties.StatusMessage, getResult.Data.Properties.StatusMessage);
                if (model.Data.Properties.TargetResource != null || getResult.Data.Properties.TargetResource != null)
                {
                    Assert.NotNull(model.Data.Properties.TargetResource);
                    Assert.NotNull(getResult.Data.Properties.TargetResource);
                    Assert.AreEqual(model.Data.Properties.TargetResource.Id, getResult.Data.Properties.TargetResource.Id);
                    Assert.AreEqual(model.Data.Properties.TargetResource.ResourceName, getResult.Data.Properties.TargetResource.ResourceName);
                    Assert.AreEqual(model.Data.Properties.TargetResource.ResourceType, getResult.Data.Properties.TargetResource.ResourceType);
                }
                if (model.Data.Properties.Request != null || getResult.Data.Properties.Request != null)
                {
                    Assert.NotNull(model.Data.Properties.Request);
                    Assert.NotNull(getResult.Data.Properties.Request);
                    Assert.AreEqual(model.Data.Properties.Request.Content, getResult.Data.Properties.Request.Content);
                }
                if (model.Data.Properties.Response != null || getResult.Data.Properties.Response != null)
                {
                    Assert.NotNull(model.Data.Properties.Response);
                    Assert.NotNull(getResult.Data.Properties.Response);
                    Assert.AreEqual(model.Data.Properties.Response.Content, getResult.Data.Properties.Response.Content);
                }
            }
        }
    }
}
