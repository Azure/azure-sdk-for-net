// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Tests
{
    public class DeploymentCollectionTests : ResourcesTestBase
    {
        public DeploymentCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-C-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deployName, deploymentData)).Value;
            Assert.AreEqual(deployName, deployment.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetDeployments().CreateOrUpdateAsync(null, deploymentData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetDeployments().CreateOrUpdateAsync(deployName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task List()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-L-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            _ = await rg.GetDeployments().CreateOrUpdateAsync(deployName, deploymentData);
            int count = 0;
            await foreach (var tempDeployment in rg.GetDeployments().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string deployName = Recording.GenerateAssetName("deployEx-G-");
            DeploymentInput deploymentData = CreateDeploymentData(CreateDeploymentProperties());
            Deployment deployment = (await rg.GetDeployments().CreateOrUpdateAsync(deployName, deploymentData)).Value;
            Deployment getDeployment = await rg.GetDeployments().GetAsync(deployName);
            AssertValidDeployment(deployment, getDeployment);
        }

        private static void AssertValidDeployment(Deployment model, Deployment getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
            Assert.AreEqual(model.Data.Location, getResult.Data.Location);
            if (model.Data.Properties != null || getResult.Data.Properties != null)
            {
                Assert.NotNull(model.Data.Properties);
                Assert.NotNull(getResult.Data.Properties);
                Assert.AreEqual(model.Data.Properties.ProvisioningState, getResult.Data.Properties.ProvisioningState);
                Assert.AreEqual(model.Data.Properties.CorrelationId, getResult.Data.Properties.CorrelationId);
                Assert.AreEqual(model.Data.Properties.Timestamp, getResult.Data.Properties.Timestamp);
                Assert.AreEqual(model.Data.Properties.Duration, getResult.Data.Properties.Duration);
                Assert.AreEqual(model.Data.Properties.Outputs, getResult.Data.Properties.Outputs);
                //Assert.AreEqual(model.Data.Properties.Providers, getResult.Data.Properties.Providers);
                //Assert.AreEqual(model.Data.Properties.Dependencies, getResult.Data.Properties.Dependencies);
                if (model.Data.Properties.TemplateLink != null || getResult.Data.Properties.TemplateLink != null)
                {
                    Assert.NotNull(model.Data.Properties.TemplateLink);
                    Assert.NotNull(getResult.Data.Properties.TemplateLink);
                    Assert.AreEqual(model.Data.Properties.TemplateLink.Uri, getResult.Data.Properties.TemplateLink.Uri);
                    Assert.AreEqual(model.Data.Properties.TemplateLink.ContentVersion, getResult.Data.Properties.TemplateLink.ContentVersion);
                    Assert.AreEqual(model.Data.Properties.TemplateLink.QueryString, getResult.Data.Properties.TemplateLink.QueryString);
                    Assert.AreEqual(model.Data.Properties.TemplateLink.RelativePath, getResult.Data.Properties.TemplateLink.RelativePath);
                }
                Assert.AreEqual(model.Data.Properties.Parameters, getResult.Data.Properties.Parameters);
                if (model.Data.Properties.ParametersLink != null || getResult.Data.Properties.ParametersLink != null)
                {
                    Assert.NotNull(model.Data.Properties.ParametersLink);
                    Assert.NotNull(getResult.Data.Properties.ParametersLink);
                    Assert.AreEqual(model.Data.Properties.ParametersLink.Uri, getResult.Data.Properties.ParametersLink.Uri);
                    Assert.AreEqual(model.Data.Properties.ParametersLink.ContentVersion, getResult.Data.Properties.ParametersLink.ContentVersion);
                }
                Assert.AreEqual(model.Data.Properties.Mode, getResult.Data.Properties.Mode);
                if (model.Data.Properties.DebugSetting != null || getResult.Data.Properties.DebugSetting != null)
                {
                    Assert.NotNull(model.Data.Properties.DebugSetting);
                    Assert.NotNull(getResult.Data.Properties.DebugSetting);
                    Assert.AreEqual(model.Data.Properties.DebugSetting.DetailLevel, getResult.Data.Properties.DebugSetting.DetailLevel);
                }
                if (model.Data.Properties.OnErrorDeployment != null || getResult.Data.Properties.OnErrorDeployment != null)
                {
                    Assert.NotNull(model.Data.Properties.OnErrorDeployment);
                    Assert.NotNull(getResult.Data.Properties.OnErrorDeployment);
                    Assert.AreEqual(model.Data.Properties.OnErrorDeployment.DeploymentName, getResult.Data.Properties.OnErrorDeployment.DeploymentName);
                    Assert.AreEqual(model.Data.Properties.OnErrorDeployment.ProvisioningState, getResult.Data.Properties.OnErrorDeployment.ProvisioningState);
                    Assert.AreEqual(model.Data.Properties.OnErrorDeployment.Type, getResult.Data.Properties.OnErrorDeployment.Type);
                }
                Assert.AreEqual(model.Data.Properties.TemplateHash, getResult.Data.Properties.TemplateHash);
                if (model.Data.Properties.OutputResources != null || getResult.Data.Properties.OutputResources != null)
                {
                    Assert.NotNull(model.Data.Properties.OutputResources);
                    Assert.NotNull(getResult.Data.Properties.OutputResources);
                    Assert.AreEqual(model.Data.Properties.OutputResources.Count, getResult.Data.Properties.OutputResources.Count);
                    for (int i = 0; i < model.Data.Properties.OutputResources.Count; ++i)
                    {
                        Assert.AreEqual(model.Data.Properties.OutputResources[i].Id, getResult.Data.Properties.OutputResources[i].Id);
                    }
                }
                if (model.Data.Properties.ValidatedResources != null || getResult.Data.Properties.ValidatedResources != null)
                {
                    Assert.NotNull(model.Data.Properties.ValidatedResources);
                    Assert.NotNull(getResult.Data.Properties.ValidatedResources);
                    Assert.AreEqual(model.Data.Properties.ValidatedResources.Count, getResult.Data.Properties.ValidatedResources.Count);
                    for (int i = 0; i < model.Data.Properties.ValidatedResources.Count; ++i)
                    {
                        Assert.AreEqual(model.Data.Properties.ValidatedResources[i].Id, getResult.Data.Properties.ValidatedResources[i].Id);
                    }
                }
                //Assert.AreEqual(model.Data.Properties.Error, getResult.Data.Properties.Error);
            }
            Assert.AreEqual(model.Data.Tags, getResult.Data.Tags);
        }
    }
}
