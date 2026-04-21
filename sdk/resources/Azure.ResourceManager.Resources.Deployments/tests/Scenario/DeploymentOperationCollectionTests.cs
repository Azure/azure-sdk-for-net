// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources._Deployments;
using Azure.ResourceManager.Resources._Deployments.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Deployments.Tests
{
    public class DeploymentOperationCollectionTests : DeploymentsTestBase
    {
        public DeploymentOperationCollectionTests(bool isAsync)
            : base(isAsync)
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
            DeploymentResource deployment = (await Client.GetDeployments(rg.Id).CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            TenantResource tenant = null;
            await foreach (var t in Client.GetTenants().GetAllAsync())
            {
                tenant = t;
                break;
            }
            int count = 0;
            await foreach (var tempDeploymentOperation in tenant.GetAllAsync(rgName, deployName, subscription.Id.SubscriptionId))
            {
                count++;
            }
            Assert.AreEqual(count, 2); //One deployment contains two operations: Create and EvaluteDeploymentOutput
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
            DeploymentResource deployment = (await Client.GetDeployments(rg.Id).CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            TenantResource tenant = null;
            await foreach (var t in Client.GetTenants().GetAllAsync())
            {
                tenant = t;
                break;
            }
            await foreach (var tempDeploymentOperation in tenant.GetAllAsync(rgName, deployName, subscription.Id.SubscriptionId))
            {
                var getDeploymentOperation = await tenant.GetAsync(rgName, deployName, tempDeploymentOperation.OperationId, subscription.Id.SubscriptionId);
                AssertValidDeploymentOperation(tempDeploymentOperation, getDeploymentOperation);
            }
        }

        private static void AssertValidDeploymentOperation(ArmDeploymentOperation model, ArmDeploymentOperation getResult)
        {
            Assert.AreEqual(model.Id, getResult.Id);
            Assert.AreEqual(model.OperationId, getResult.OperationId);
            if (model.Properties != null || getResult.Properties != null)
            {
                Assert.NotNull(model.Properties);
                Assert.NotNull(getResult.Properties);
                Assert.AreEqual(model.Properties.ProvisioningState, getResult.Properties.ProvisioningState);
                Assert.AreEqual(model.Properties.ProvisioningOperation, getResult.Properties.ProvisioningOperation);
                Assert.AreEqual(model.Properties.Timestamp, getResult.Properties.Timestamp);
                Assert.AreEqual(model.Properties.Duration, getResult.Properties.Duration);
                //Assert.AreEqual(model.Properties.ServiceRequestId, getResult.Properties.ServiceRequestId); // The list item from ArmDeploymentResource.GetDeploymentOperations() no longer has values for ServiceRequestId since version 2022-09-01.
                Assert.AreEqual(model.Properties.StatusCode, getResult.Properties.StatusCode);
                //Assert.AreEqual(model.Data.Properties.StatusMessage, getResult.Data.Properties.StatusMessage);
                if (model.Properties.TargetResource != null || getResult.Properties.TargetResource != null)
                {
                    Assert.NotNull(model.Properties.TargetResource);
                    Assert.NotNull(getResult.Properties.TargetResource);
                    Assert.AreEqual(model.Properties.TargetResource.Id, getResult.Properties.TargetResource.Id);
                    Assert.AreEqual(model.Properties.TargetResource.ResourceName, getResult.Properties.TargetResource.ResourceName);
                    Assert.AreEqual(model.Properties.TargetResource.ResourceType, getResult.Properties.TargetResource.ResourceType);
                }
                if (model.Properties.RequestContent != null || getResult.Properties.RequestContent != null)
                {
                    Assert.NotNull(model.Properties.RequestContent);
                    Assert.NotNull(getResult.Properties.RequestContent);
                    Assert.AreEqual(model.Properties.RequestContent.ToString(), getResult.Properties.RequestContent.ToString());
                }
                if (model.Properties.ResponseContent != null || getResult.Properties.ResponseContent != null)
                {
                    Assert.NotNull(model.Properties.ResponseContent);
                    Assert.NotNull(getResult.Properties.ResponseContent);
                    Assert.AreEqual(model.Properties.ResponseContent.ToString(), getResult.Properties.ResponseContent.ToString());
                }
            }
        }
    }
}
