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
    public class ApplicationCollectionTests : ResourcesTestBase
    {
        public ApplicationCollectionTests(bool isAsync)
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
            string appDefName = Recording.GenerateAssetName("appDef-C-");
            ArmApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ArmApplicationDefinitionResource appDef = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-C-");
            ArmApplicationData applicationData = CreateApplicationData(appDef.Id, new ResourceIdentifier(subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-1-")), Recording.GenerateAssetName("s1"));
            ArmApplicationResource application = (await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, applicationData)).Value;
            Assert.AreEqual(appName, application.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, null, applicationData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRG()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-L-");
            ArmApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ArmApplicationDefinitionResource appDef = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-L-");
            ArmApplicationData applicationData = CreateApplicationData(appDef.Id, new ResourceIdentifier(subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-2-")), Recording.GenerateAssetName("s2"));
            _ = await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, applicationData);
            int count = 0;
            await foreach (var tempApplication in rg.GetArmApplications().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-L-");
            ArmApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ArmApplicationDefinitionResource appDef = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-L-");
            ArmApplicationData applicationData = CreateApplicationData(appDef.Id, new ResourceIdentifier(subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-3-")), Recording.GenerateAssetName("s3"));
            _ = await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, applicationData);
            int count = 0;
            await foreach (var tempApplication in subscription.GetArmApplicationsAsync())
            {
                if (tempApplication.Data.ApplicationDefinitionId == appDef.Id)
                {
                    count++;
                }
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task Get()
        {
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(AzureLocation.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, rgData);
            ResourceGroupResource rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-G-");
            ArmApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ArmApplicationDefinitionResource appDef = (await rg.GetArmApplicationDefinitions().CreateOrUpdateAsync(WaitUntil.Completed, appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-G-");
            ArmApplicationData applicationData = CreateApplicationData(appDef.Id, new ResourceIdentifier(subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-4-")), Recording.GenerateAssetName("s4"));
            ArmApplicationResource application = (await rg.GetArmApplications().CreateOrUpdateAsync(WaitUntil.Completed, appName, applicationData)).Value;
            ArmApplicationResource getApplication = await rg.GetArmApplications().GetAsync(appName);
            AssertValidApplication(application, getApplication);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetArmApplications().GetAsync(null));
        }

        private static void AssertValidApplication(ArmApplicationResource model, ArmApplicationResource getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.ResourceType, getResult.Data.ResourceType);
            if (model.Data.Plan != null || getResult.Data.Plan != null)
            {
                Assert.NotNull(model.Data.Plan);
                Assert.NotNull(getResult.Data.Plan);
                Assert.AreEqual(model.Data.Plan.Name, getResult.Data.Plan.Name);
                Assert.AreEqual(model.Data.Plan.Product, getResult.Data.Plan.Product);
                Assert.AreEqual(model.Data.Plan.PromotionCode, getResult.Data.Plan.PromotionCode);
                Assert.AreEqual(model.Data.Plan.Publisher, getResult.Data.Plan.Publisher);
                Assert.AreEqual(model.Data.Plan.Version, getResult.Data.Plan.Version);
            }
            Assert.AreEqual(model.Data.Kind, getResult.Data.Kind);
            Assert.AreEqual(model.Data.Identity, getResult.Data.Identity);
            Assert.AreEqual(model.Data.ManagedResourceGroupId, getResult.Data.ManagedResourceGroupId);
            Assert.AreEqual(model.Data.ApplicationDefinitionId, getResult.Data.ApplicationDefinitionId);
            Assert.AreEqual(model.Data.Parameters.ToArray(), getResult.Data.Parameters.ToArray());
            Assert.AreEqual(model.Data.Outputs.ToArray(), getResult.Data.Outputs.ToArray());
            Assert.AreEqual(model.Data.ProvisioningState, getResult.Data.ProvisioningState);
            if (model.Data.BillingDetails != null || getResult.Data.BillingDetails != null)
            {
                Assert.NotNull(model.Data.BillingDetails);
                Assert.NotNull(getResult.Data.BillingDetails);
                Assert.AreEqual(model.Data.BillingDetails.ResourceUsageId, getResult.Data.BillingDetails.ResourceUsageId);
            }
            if (model.Data.JitAccessPolicy != null || getResult.Data.JitAccessPolicy != null)
            {
                Assert.NotNull(model.Data.JitAccessPolicy);
                Assert.NotNull(getResult.Data.JitAccessPolicy);
                Assert.AreEqual(model.Data.JitAccessPolicy.JitAccessEnabled, getResult.Data.JitAccessPolicy.JitAccessEnabled);
                Assert.AreEqual(model.Data.JitAccessPolicy.JitApprovalMode, getResult.Data.JitAccessPolicy.JitApprovalMode);
                Assert.AreEqual(model.Data.JitAccessPolicy.JitApprovers.Count, getResult.Data.JitAccessPolicy.JitApprovers.Count);
                for (int i = 0; i < model.Data.JitAccessPolicy.JitApprovers.Count; ++i)
                {
                    Assert.AreEqual(model.Data.JitAccessPolicy.JitApprovers[i].DisplayName, getResult.Data.JitAccessPolicy.JitApprovers[i].DisplayName);
                    Assert.AreEqual(model.Data.JitAccessPolicy.JitApprovers[i].ApproverType, getResult.Data.JitAccessPolicy.JitApprovers[i].ApproverType);
                }
                Assert.AreEqual(model.Data.JitAccessPolicy.MaximumJitAccessDuration, getResult.Data.JitAccessPolicy.MaximumJitAccessDuration);
            }
            Assert.AreEqual(model.Data.PublisherTenantId, getResult.Data.PublisherTenantId);
            Assert.AreEqual(model.Data.Authorizations.Count, getResult.Data.Authorizations.Count);
            for (int i = 0; i < model.Data.Authorizations.Count; ++i)
            {
                Assert.AreEqual(model.Data.Authorizations[i].PrincipalId, getResult.Data.Authorizations[i].PrincipalId);
                Assert.AreEqual(model.Data.Authorizations[i].RoleDefinitionId, getResult.Data.Authorizations[i].RoleDefinitionId);
            }
            Assert.AreEqual(model.Data.ManagementMode, getResult.Data.ManagementMode);
            if (model.Data.CustomerSupport != null || getResult.Data.CustomerSupport != null)
            {
                Assert.NotNull(model.Data.CustomerSupport);
                Assert.NotNull(getResult.Data.CustomerSupport);
                Assert.AreEqual(model.Data.CustomerSupport.ContactName, getResult.Data.CustomerSupport.ContactName);
                Assert.AreEqual(model.Data.CustomerSupport.Email, getResult.Data.CustomerSupport.Email);
                Assert.AreEqual(model.Data.CustomerSupport.Phone, getResult.Data.CustomerSupport.Phone);
            }
            if (model.Data.SupportUris != null || getResult.Data.SupportUris != null)
            {
                Assert.NotNull(model.Data.SupportUris);
                Assert.NotNull(getResult.Data.SupportUris);
                Assert.AreEqual(model.Data.SupportUris.AzureGovernmentUri, getResult.Data.SupportUris.AzureGovernmentUri);
                Assert.AreEqual(model.Data.SupportUris.AzurePublicCloudUri, getResult.Data.SupportUris.AzurePublicCloudUri);
            }
            if (model.Data.Artifacts != null || getResult.Data.Artifacts != null)
            {
                Assert.NotNull(model.Data.Artifacts);
                Assert.NotNull(getResult.Data.Artifacts);
                Assert.AreEqual(model.Data.Artifacts.Count, getResult.Data.Artifacts.Count);
                for (int i = 0; i < model.Data.Artifacts.Count; ++i)
                {
                    Assert.AreEqual(model.Data.Artifacts[i].Name, getResult.Data.Artifacts[i].Name);
                    Assert.AreEqual(model.Data.Artifacts[i].Uri, getResult.Data.Artifacts[i].Uri);
                    Assert.AreEqual(model.Data.Artifacts[i].ArtifactType, getResult.Data.Artifacts[i].ArtifactType);
                }
            }
            if (model.Data.CreatedBy != null || getResult.Data.CreatedBy != null)
            {
                Assert.NotNull(model.Data.CreatedBy);
                Assert.NotNull(getResult.Data.CreatedBy);
                Assert.AreEqual(model.Data.CreatedBy.ObjectId, getResult.Data.CreatedBy.ObjectId);
                Assert.AreEqual(model.Data.CreatedBy.Puid, getResult.Data.CreatedBy.Puid);
                Assert.AreEqual(model.Data.CreatedBy.ApplicationId, getResult.Data.CreatedBy.ApplicationId);
            }
            if (model.Data.UpdatedBy != null || getResult.Data.UpdatedBy != null)
            {
                Assert.NotNull(model.Data.UpdatedBy);
                Assert.NotNull(getResult.Data.UpdatedBy);
                Assert.AreEqual(model.Data.UpdatedBy.ObjectId, getResult.Data.UpdatedBy.ObjectId);
                Assert.AreEqual(model.Data.UpdatedBy.Puid, getResult.Data.UpdatedBy.Puid);
                Assert.AreEqual(model.Data.UpdatedBy.ApplicationId, getResult.Data.UpdatedBy.ApplicationId);
            }
        }
    }
}
