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
            Assert.AreEqual(applicationDefinitionName, applicationDefinition.Data.Name);
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
            Assert.AreEqual(count, 1);
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
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            Assert.AreEqual(model.Data.LockLevel, getResult.Data.LockLevel);
            Assert.AreEqual(model.Data.DisplayName, getResult.Data.DisplayName);
            Assert.AreEqual(model.Data.IsEnabled, getResult.Data.IsEnabled);
            Assert.AreEqual(model.Data.Authorizations, getResult.Data.Authorizations);
            if (model.Data.Authorizations != null || getResult.Data.Authorizations != null)
            {
                Assert.NotNull(model.Data.Authorizations);
                Assert.NotNull(getResult.Data.Authorizations);
                Assert.AreEqual(model.Data.Authorizations.Count, getResult.Data.Authorizations.Count);
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
                Assert.AreEqual(model.Data.Artifacts.Count, getResult.Data.Artifacts.Count);
                for (int i = 0; i < model.Data.Artifacts.Count; ++i)
                {
                    ArmApplicationDefinitionArtifact modelArtifacts = model.Data.Artifacts[i], getResultArtifacts = getResult.Data.Artifacts[i];
                    AssertValidArtifacts(modelArtifacts, getResultArtifacts);
                }
            }
            Assert.AreEqual(model.Data.Description, getResult.Data.Description);
            Assert.AreEqual(model.Data.PackageFileUri, getResult.Data.PackageFileUri);
            Assert.AreEqual(model.Data.MainTemplate, getResult.Data.MainTemplate);
            Assert.AreEqual(model.Data.CreateUiDefinition, getResult.Data.CreateUiDefinition);
            if (model.Data.NotificationPolicy != null || getResult.Data.NotificationPolicy != null)
            {
                Assert.NotNull(model.Data.NotificationPolicy);
                Assert.NotNull(getResult.Data.NotificationPolicy);
                if (model.Data.NotificationPolicy.NotificationEndpoints != null || getResult.Data.NotificationPolicy.NotificationEndpoints != null)
                {
                    Assert.NotNull(model.Data.NotificationPolicy.NotificationEndpoints);
                    Assert.NotNull(getResult.Data.NotificationPolicy.NotificationEndpoints);
                    Assert.AreEqual(model.Data.NotificationPolicy.NotificationEndpoints.Count, getResult.Data.NotificationPolicy.NotificationEndpoints.Count);
                    for (int i = 0; i < model.Data.NotificationPolicy.NotificationEndpoints.Count; ++i)
                    {
                        Assert.AreEqual(model.Data.NotificationPolicy.NotificationEndpoints[i].Uri, getResult.Data.NotificationPolicy.NotificationEndpoints[i].Uri);
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
                    Assert.AreEqual(model.Data.LockingPolicy.AllowedActions.Count, getResult.Data.LockingPolicy.AllowedActions.Count);
                    for (int i = 0; i < model.Data.LockingPolicy.AllowedActions.Count; ++i)
                    {
                        Assert.AreEqual(model.Data.LockingPolicy.AllowedActions[i], getResult.Data.LockingPolicy.AllowedActions[i]);
                    }
                }
            }
            if (model.Data.DeploymentPolicy != null || getResult.Data.DeploymentPolicy != null)
            {
                Assert.NotNull(model.Data.DeploymentPolicy);
                Assert.NotNull(getResult.Data.DeploymentPolicy);
                Assert.AreEqual(model.Data.DeploymentPolicy.DeploymentMode, getResult.Data.DeploymentPolicy.DeploymentMode);
            }
            if (model.Data.ManagementPolicy != null || getResult.Data.ManagementPolicy != null)
            {
                Assert.NotNull(model.Data.ManagementPolicy);
                Assert.NotNull(getResult.Data.ManagementPolicy);
                Assert.AreEqual(model.Data.ManagementPolicy.Mode, getResult.Data.ManagementPolicy.Mode);
            }
            if (model.Data.Policies != null || getResult.Data.Policies != null)
            {
                Assert.NotNull(model.Data.Policies);
                Assert.NotNull(getResult.Data.Policies);
                Assert.AreEqual(model.Data.Policies.Count, getResult.Data.Policies.Count);
                for (int i = 0; i < model.Data.Policies.Count; ++i)
                {
                    ArmApplicationPolicy policy = model.Data.Policies[i], getPolicy = getResult.Data.Policies[i];
                    AssertValidPolicy(policy, getPolicy);
                }
            }
        }

        private static void AssertValidAuthorizations(ArmApplicationAuthorization model, ArmApplicationAuthorization getResult)
        {
            Assert.AreEqual(model.PrincipalId, getResult.PrincipalId);
            Assert.AreEqual(model.RoleDefinitionId, getResult.RoleDefinitionId);
        }

        private static void AssertValidArtifacts(ArmApplicationDefinitionArtifact model, ArmApplicationDefinitionArtifact getResult)
        {
            Assert.AreEqual(model.Name, getResult.Name);
            Assert.AreEqual(model.Uri, getResult.Uri);
            Assert.AreEqual(model.ArtifactType, getResult.ArtifactType);
        }

        private static void AssertValidPolicy(ArmApplicationPolicy model, ArmApplicationPolicy getResult)
        {
            Assert.AreEqual(model.Name, getResult.Name);
            Assert.AreEqual(model.Parameters, getResult.Parameters);
            Assert.AreEqual(model.PolicyDefinitionId, getResult.PolicyDefinitionId);
        }
    }
}
