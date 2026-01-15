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
    public class ApplicationDefinitionCollectionTests : ResourcesTestBase
    {
        public ApplicationDefinitionCollectionTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
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
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-C-");
            ArmApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            ArmApplicationDefinitionResource applicationDefinition = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, applicationDefinitionData)).Value;
            Assert.That(applicationDefinition.Data.Name, Is.EqualTo(applicationDefinitionName));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, null, applicationDefinitionData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, null));
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
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-L-");
            ArmApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            _ = await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, applicationDefinitionData);
            int count = 0;
            await foreach (var tempApplicationDefinition in rg.GetArmApplicationDefinitions().GetAllAsync())
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
            string applicationDefinitionName = Recording.GenerateAssetName("appDef-G-");
            ArmApplicationDefinitionData applicationDefinitionData = CreateApplicationDefinitionData(applicationDefinitionName);
            ArmApplicationDefinitionResource applicationDefinition = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, applicationDefinitionName, applicationDefinitionData)).Value;
            ArmApplicationDefinitionResource getApplicationDefinition = await rg.GetArmApplicationDefinitions().GetAsync(applicationDefinitionName);
            AssertValidApplicationDefinition(applicationDefinition, getApplicationDefinition);
        }

        private static void AssertValidApplicationDefinition(ArmApplicationDefinitionResource model, ArmApplicationDefinitionResource getResult)
        {
            Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
            Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
            Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            Assert.That(getResult.Data.LockLevel, Is.EqualTo(model.Data.LockLevel));
            Assert.That(getResult.Data.DisplayName, Is.EqualTo(model.Data.DisplayName));
            Assert.That(getResult.Data.IsEnabled, Is.EqualTo(model.Data.IsEnabled));
            Assert.That(getResult.Data.Authorizations, Is.EqualTo(model.Data.Authorizations));
            if (model.Data.Authorizations != null || getResult.Data.Authorizations != null)
            {
                Assert.NotNull(model.Data.Authorizations);
                Assert.NotNull(getResult.Data.Authorizations);
                Assert.That(getResult.Data.Authorizations.Count, Is.EqualTo(model.Data.Authorizations.Count));
                for (int i = 0; i < model.Data.Authorizations.Count; ++i)
                {
                    ArmApplicationAuthorization modelAuthorizations = model.Data.Authorizations[i], getResultAuthorizations = getResult.Data.Authorizations[i];
                    AssertValidAuthorizations(modelAuthorizations, getResultAuthorizations);
                }
            }
            if (model.Data.Artifacts != null || getResult.Data.Artifacts != null)
            {
                Assert.NotNull(model.Data.Artifacts);
                Assert.NotNull(getResult.Data.Artifacts);
                Assert.That(getResult.Data.Artifacts.Count, Is.EqualTo(model.Data.Artifacts.Count));
                for (int i = 0; i < model.Data.Artifacts.Count; ++i)
                {
                    ArmApplicationDefinitionArtifact modelArtifacts = model.Data.Artifacts[i], getResultArtifacts = getResult.Data.Artifacts[i];
                    AssertValidArtifacts(modelArtifacts, getResultArtifacts);
                }
            }
            Assert.That(getResult.Data.Description, Is.EqualTo(model.Data.Description));
            Assert.That(getResult.Data.PackageFileUri, Is.EqualTo(model.Data.PackageFileUri));
            Assert.That(getResult.Data.MainTemplate, Is.EqualTo(model.Data.MainTemplate));
            Assert.That(getResult.Data.CreateUiDefinition, Is.EqualTo(model.Data.CreateUiDefinition));
            if (model.Data.NotificationPolicy != null || getResult.Data.NotificationPolicy != null)
            {
                Assert.NotNull(model.Data.NotificationPolicy);
                Assert.NotNull(getResult.Data.NotificationPolicy);
                if (model.Data.NotificationPolicy.NotificationEndpoints != null || getResult.Data.NotificationPolicy.NotificationEndpoints != null)
                {
                    Assert.NotNull(model.Data.NotificationPolicy.NotificationEndpoints);
                    Assert.NotNull(getResult.Data.NotificationPolicy.NotificationEndpoints);
                    Assert.That(getResult.Data.NotificationPolicy.NotificationEndpoints.Count, Is.EqualTo(model.Data.NotificationPolicy.NotificationEndpoints.Count));
                    for (int i = 0; i < model.Data.NotificationPolicy.NotificationEndpoints.Count; ++i)
                    {
                        Assert.That(getResult.Data.NotificationPolicy.NotificationEndpoints[i].Uri, Is.EqualTo(model.Data.NotificationPolicy.NotificationEndpoints[i].Uri));
                    }
                }
            }
            if (model.Data.LockingPolicy != null || getResult.Data.LockingPolicy != null)
            {
                Assert.NotNull(model.Data.LockingPolicy);
                Assert.NotNull(getResult.Data.LockingPolicy);
                if (model.Data.LockingPolicy.AllowedActions != null || getResult.Data.LockingPolicy.AllowedActions != null)
                {
                    Assert.NotNull(model.Data.LockingPolicy.AllowedActions);
                    Assert.NotNull(getResult.Data.LockingPolicy.AllowedActions);
                    Assert.That(getResult.Data.LockingPolicy.AllowedActions.Count, Is.EqualTo(model.Data.LockingPolicy.AllowedActions.Count));
                    for (int i = 0; i < model.Data.LockingPolicy.AllowedActions.Count; ++i)
                    {
                        Assert.That(getResult.Data.LockingPolicy.AllowedActions[i], Is.EqualTo(model.Data.LockingPolicy.AllowedActions[i]));
                    }
                }
            }
            if (model.Data.DeploymentPolicy != null || getResult.Data.DeploymentPolicy != null)
            {
                Assert.NotNull(model.Data.DeploymentPolicy);
                Assert.NotNull(getResult.Data.DeploymentPolicy);
                Assert.That(getResult.Data.DeploymentPolicy.DeploymentMode, Is.EqualTo(model.Data.DeploymentPolicy.DeploymentMode));
            }
            if (model.Data.ManagementPolicy != null || getResult.Data.ManagementPolicy != null)
            {
                Assert.NotNull(model.Data.ManagementPolicy);
                Assert.NotNull(getResult.Data.ManagementPolicy);
                Assert.That(getResult.Data.ManagementPolicy.Mode, Is.EqualTo(model.Data.ManagementPolicy.Mode));
            }
            if (model.Data.Policies != null || getResult.Data.Policies != null)
            {
                Assert.NotNull(model.Data.Policies);
                Assert.NotNull(getResult.Data.Policies);
                Assert.That(getResult.Data.Policies.Count, Is.EqualTo(model.Data.Policies.Count));
                for (int i = 0; i < model.Data.Policies.Count; ++i)
                {
                    ArmApplicationPolicy policy = model.Data.Policies[i], getPolicy = getResult.Data.Policies[i];
                    AssertValidPolicy(policy, getPolicy);
                }
            }
        }

        private static void AssertValidAuthorizations(ArmApplicationAuthorization model, ArmApplicationAuthorization getResult)
        {
            Assert.That(getResult.PrincipalId, Is.EqualTo(model.PrincipalId));
            Assert.That(getResult.RoleDefinitionId, Is.EqualTo(model.RoleDefinitionId));
        }

        private static void AssertValidArtifacts(ArmApplicationDefinitionArtifact model, ArmApplicationDefinitionArtifact getResult)
        {
            Assert.That(getResult.Name, Is.EqualTo(model.Name));
            Assert.That(getResult.Uri, Is.EqualTo(model.Uri));
            Assert.That(getResult.ArtifactType, Is.EqualTo(model.ArtifactType));
        }

        private static void AssertValidPolicy(ArmApplicationPolicy model, ArmApplicationPolicy getResult)
        {
            Assert.That(getResult.Name, Is.EqualTo(model.Name));
            Assert.That(getResult.Parameters, Is.EqualTo(model.Parameters));
            Assert.That(getResult.PolicyDefinitionId, Is.EqualTo(model.PolicyDefinitionId));
        }
    }
}
