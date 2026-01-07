// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
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
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-");
            var deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            ArmDeploymentResource deployment = (await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            int count = 0;
            await foreach (var tempDeploymentOperation in deployment.GetDeploymentOperationsAsync())
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(2)); //One deployment contains two operations: Create and EvaluteDeploymentOutput
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-");
            var deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            ArmDeploymentResource deployment = (await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            await foreach (var tempDeploymentOperation in deployment.GetDeploymentOperationsAsync())
            {
                var getDeploymentOperation = await deployment.GetDeploymentOperationAsync(tempDeploymentOperation.OperationId);
                AssertValidDeploymentOperation(tempDeploymentOperation, getDeploymentOperation);
            }
        }

        private static void AssertValidDeploymentOperation(ArmDeploymentOperation model, ArmDeploymentOperation getResult)
        {
            Assert.That(getResult.Id, Is.EqualTo(model.Id));
            Assert.That(getResult.OperationId, Is.EqualTo(model.OperationId));
            if (model.Properties != null || getResult.Properties != null)
            {
                Assert.That(model.Properties, Is.Not.Null);
                Assert.That(getResult.Properties, Is.Not.Null);
                Assert.That(getResult.Properties.ProvisioningState, Is.EqualTo(model.Properties.ProvisioningState));
                Assert.That(getResult.Properties.ProvisioningOperation, Is.EqualTo(model.Properties.ProvisioningOperation));
                Assert.That(getResult.Properties.Timestamp, Is.EqualTo(model.Properties.Timestamp));
                Assert.That(getResult.Properties.Duration, Is.EqualTo(model.Properties.Duration));
                //Assert.AreEqual(model.Properties.ServiceRequestId, getResult.Properties.ServiceRequestId); // The list item from ArmDeploymentResource.GetDeploymentOperations() no longer has values for ServiceRequestId since version 2022-09-01.
                Assert.That(getResult.Properties.StatusCode, Is.EqualTo(model.Properties.StatusCode));
                //Assert.AreEqual(model.Data.Properties.StatusMessage, getResult.Data.Properties.StatusMessage);
                if (model.Properties.TargetResource != null || getResult.Properties.TargetResource != null)
                {
                    Assert.That(model.Properties.TargetResource, Is.Not.Null);
                    Assert.That(getResult.Properties.TargetResource, Is.Not.Null);
                    Assert.That(getResult.Properties.TargetResource.Id, Is.EqualTo(model.Properties.TargetResource.Id));
                    Assert.That(getResult.Properties.TargetResource.ResourceName, Is.EqualTo(model.Properties.TargetResource.ResourceName));
                    Assert.That(getResult.Properties.TargetResource.ResourceType, Is.EqualTo(model.Properties.TargetResource.ResourceType));
                }
                if (model.Properties.Request != null || getResult.Properties.Request != null)
                {
                    Assert.That(model.Properties.Request, Is.Not.Null);
                    Assert.That(getResult.Properties.Request, Is.Not.Null);
                    Assert.That(getResult.Properties.Request.Content, Is.EqualTo(model.Properties.Request.Content));
                }
                if (model.Properties.Response != null || getResult.Properties.Response != null)
                {
                    Assert.That(model.Properties.Response, Is.Not.Null);
                    Assert.That(getResult.Properties.Response, Is.Not.Null);
                    Assert.That(getResult.Properties.Response.Content, Is.EqualTo(model.Properties.Response.Content));
                }
            }
        }
    }
}
