// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Deployments.Tests
{
    public class DeploymentCollectionTests : DeploymentsTestBase
    {
        public DeploymentCollectionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-C-");
            var deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            ArmDeploymentResource deployment = (await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            Assert.That(deployment.Data.Name, Is.EqualTo(deployName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, null, deploymentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateWithLocation()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string deployName = Recording.GenerateAssetName("deployEx-C-");
            var deploymentData = CreateDeploymentData(CreateDeploymentPropertiesAtSub(), AzureLocation.JapanEast);
            ArmDeploymentResource deployment = (await subscription.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            Assert.That(deployment.Data.Name, Is.EqualTo(deployName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, null, deploymentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await subscription.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateUsingString()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployExName = Recording.GenerateAssetName("deployEx-C-");
            var deploymentData = CreateDeploymentData(CreateDeploymentPropertiesUsingString());
            ArmDeploymentResource deployment = (await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployExName, deploymentData)).Value;
            Assert.That(deployment.Data.Name, Is.EqualTo(deployExName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, null, deploymentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployExName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdateUsingJsonElement()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployExName = Recording.GenerateAssetName("deployEx-C-");
            var deploymentData = CreateDeploymentData(CreateDeploymentPropertiesUsingJsonElement());
            ArmDeploymentResource deployment = (await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployExName, deploymentData)).Value;
            Assert.That(deployment.Data.Name, Is.EqualTo(deployExName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, null, deploymentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployExName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-L-");
            var deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            _ = await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData);
            int count = 0;
            await foreach (var tempDeployment in rg.GetArmDeployments().GetAllAsync())
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(1));
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-G-");
            var deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            ArmDeploymentResource deployment = (await rg.GetArmDeployments().CreateOrUpdateAsync(WaitUntil.Completed, deployName, deploymentData)).Value;
            ArmDeploymentResource getDeployment = await rg.GetArmDeployments().GetAsync(deployName);
            AssertValidDeployment(deployment, getDeployment);
        }

        private static void AssertValidDeployment(ArmDeploymentResource model, ArmDeploymentResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.Location, Is.EqualTo(model.Data.Location));
            if (model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.That(getResult.Data.Properties.ProvisioningState, Is.EqualTo(model.Data.Properties.ProvisioningState));
                Assert.That(getResult.Data.Properties.CorrelationId, Is.EqualTo(model.Data.Properties.CorrelationId));
                Assert.That(getResult.Data.Properties.Timestamp, Is.EqualTo(model.Data.Properties.Timestamp));
                Assert.That(getResult.Data.Properties.Duration, Is.EqualTo(model.Data.Properties.Duration));
                Assert.That(getResult.Data.Properties.Outputs.ToArray(), Is.EqualTo(model.Data.Properties.Outputs.ToArray()));
                //Assert.AreEqual(model.Data.Properties.Providers, getResult.Data.Properties.Providers);
                //Assert.AreEqual(model.Data.Properties.Dependencies, getResult.Data.Properties.Dependencies);
                if (model.Data.Properties.TemplateLink != null || getResult.Data.Properties.TemplateLink != null)
                {
                    Assert.NotNull(model.Data.Properties.TemplateLink);
                    Assert.NotNull(getResult.Data.Properties.TemplateLink);
                    Assert.That(getResult.Data.Properties.TemplateLink.Uri, Is.EqualTo(model.Data.Properties.TemplateLink.Uri));
                    Assert.That(getResult.Data.Properties.TemplateLink.ContentVersion, Is.EqualTo(model.Data.Properties.TemplateLink.ContentVersion));
                    Assert.That(getResult.Data.Properties.TemplateLink.QueryString, Is.EqualTo(model.Data.Properties.TemplateLink.QueryString));
                    Assert.That(getResult.Data.Properties.TemplateLink.RelativePath, Is.EqualTo(model.Data.Properties.TemplateLink.RelativePath));
                }
                Assert.That(getResult.Data.Properties.Parameters.ToArray(), Is.EqualTo(model.Data.Properties.Parameters.ToArray()));
                if (model.Data.Properties.ParametersLink != null || getResult.Data.Properties.ParametersLink != null)
                {
                    Assert.NotNull(model.Data.Properties.ParametersLink);
                    Assert.NotNull(getResult.Data.Properties.ParametersLink);
                    Assert.That(getResult.Data.Properties.ParametersLink.Uri, Is.EqualTo(model.Data.Properties.ParametersLink.Uri));
                    Assert.That(getResult.Data.Properties.ParametersLink.ContentVersion, Is.EqualTo(model.Data.Properties.ParametersLink.ContentVersion));
                }
                Assert.That(getResult.Data.Properties.Mode, Is.EqualTo(model.Data.Properties.Mode));
                if (model.Data.Properties.DebugSetting != null || getResult.Data.Properties.DebugSetting != null)
                {
                    Assert.NotNull(model.Data.Properties.DebugSetting);
                    Assert.NotNull(getResult.Data.Properties.DebugSetting);
                    Assert.That(getResult.Data.Properties.DebugSetting.DetailLevel, Is.EqualTo(model.Data.Properties.DebugSetting.DetailLevel));
                }
                if (model.Data.Properties.ErrorDeployment != null || getResult.Data.Properties.ErrorDeployment != null)
                {
                    Assert.NotNull(model.Data.Properties.ErrorDeployment);
                    Assert.NotNull(getResult.Data.Properties.ErrorDeployment);
                    Assert.That(getResult.Data.Properties.ErrorDeployment.DeploymentName, Is.EqualTo(model.Data.Properties.ErrorDeployment.DeploymentName));
                    Assert.That(getResult.Data.Properties.ErrorDeployment.ProvisioningState, Is.EqualTo(model.Data.Properties.ErrorDeployment.ProvisioningState));
                    Assert.That(getResult.Data.Properties.ErrorDeployment.DeploymentType, Is.EqualTo(model.Data.Properties.ErrorDeployment.DeploymentType));
                }
                Assert.That(getResult.Data.Properties.TemplateHash, Is.EqualTo(model.Data.Properties.TemplateHash));
                if (model.Data.Properties.OutputResources != null || getResult.Data.Properties.OutputResources != null)
                {
                    Assert.NotNull(model.Data.Properties.OutputResources);
                    Assert.NotNull(getResult.Data.Properties.OutputResources);
                    Assert.That(getResult.Data.Properties.OutputResources.Count, Is.EqualTo(model.Data.Properties.OutputResources.Count));
                    for (int i = 0; i < model.Data.Properties.OutputResources.Count; ++i)
                    {
                        Assert.That(getResult.Data.Properties.OutputResources[i].Id, Is.EqualTo(model.Data.Properties.OutputResources[i].Id));
                    }
                }
                if (model.Data.Properties.ValidatedResources != null || getResult.Data.Properties.ValidatedResources != null)
                {
                    Assert.NotNull(model.Data.Properties.ValidatedResources);
                    Assert.NotNull(getResult.Data.Properties.ValidatedResources);
                    Assert.That(getResult.Data.Properties.ValidatedResources.Count, Is.EqualTo(model.Data.Properties.ValidatedResources.Count));
                    for (int i = 0; i < model.Data.Properties.ValidatedResources.Count; ++i)
                    {
                        Assert.That(getResult.Data.Properties.ValidatedResources[i].Id, Is.EqualTo(model.Data.Properties.ValidatedResources[i].Id));
                    }
                }
                //Assert.AreEqual(model.Data.Properties.Error, getResult.Data.Properties.Error);
            }
            Assert.That(getResult.Data.Tags, Is.EqualTo(model.Data.Tags));
        }
    }
}
