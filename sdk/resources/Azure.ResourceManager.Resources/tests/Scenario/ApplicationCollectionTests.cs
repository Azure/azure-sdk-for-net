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
            Assert.That(application.Data.Name, Is.EqualTo(appName));
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
            Assert.That(count, Is.EqualTo(1));
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
            Assert.That(count, Is.EqualTo(1));
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
            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Name, Is.EqualTo(model.Data.Name));
                Assert.That(getResult.Data.Id, Is.EqualTo(model.Data.Id));
                Assert.That(getResult.Data.ResourceType, Is.EqualTo(model.Data.ResourceType));
            });
            if (model.Data.Plan != null || getResult.Data.Plan != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Data.Plan, Is.Not.Null);
                    Assert.That(getResult.Data.Plan, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.Data.Plan.Name, Is.EqualTo(model.Data.Plan.Name));
                    Assert.That(getResult.Data.Plan.Product, Is.EqualTo(model.Data.Plan.Product));
                    Assert.That(getResult.Data.Plan.PromotionCode, Is.EqualTo(model.Data.Plan.PromotionCode));
                    Assert.That(getResult.Data.Plan.Publisher, Is.EqualTo(model.Data.Plan.Publisher));
                    Assert.That(getResult.Data.Plan.Version, Is.EqualTo(model.Data.Plan.Version));
                });
            }

            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.Kind, Is.EqualTo(model.Data.Kind));
                Assert.That(getResult.Data.Identity, Is.EqualTo(model.Data.Identity));
                Assert.That(getResult.Data.ManagedResourceGroupId, Is.EqualTo(model.Data.ManagedResourceGroupId));
                Assert.That(getResult.Data.ApplicationDefinitionId, Is.EqualTo(model.Data.ApplicationDefinitionId));
                Assert.That(getResult.Data.Parameters.ToArray(), Is.EqualTo(model.Data.Parameters.ToArray()));
                Assert.That(getResult.Data.Outputs.ToArray(), Is.EqualTo(model.Data.Outputs.ToArray()));
                Assert.That(getResult.Data.ProvisioningState, Is.EqualTo(model.Data.ProvisioningState));
            });
            if (model.Data.BillingDetails != null || getResult.Data.BillingDetails != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Data.BillingDetails, Is.Not.Null);
                    Assert.That(getResult.Data.BillingDetails, Is.Not.Null);
                });
                Assert.That(getResult.Data.BillingDetails.ResourceUsageId, Is.EqualTo(model.Data.BillingDetails.ResourceUsageId));
            }
            if (model.Data.JitAccessPolicy != null || getResult.Data.JitAccessPolicy != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Data.JitAccessPolicy, Is.Not.Null);
                    Assert.That(getResult.Data.JitAccessPolicy, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.Data.JitAccessPolicy.JitAccessEnabled, Is.EqualTo(model.Data.JitAccessPolicy.JitAccessEnabled));
                    Assert.That(getResult.Data.JitAccessPolicy.JitApprovalMode, Is.EqualTo(model.Data.JitAccessPolicy.JitApprovalMode));
                    Assert.That(getResult.Data.JitAccessPolicy.JitApprovers, Has.Count.EqualTo(model.Data.JitAccessPolicy.JitApprovers.Count));
                });
                for (int i = 0; i < model.Data.JitAccessPolicy.JitApprovers.Count; ++i)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(getResult.Data.JitAccessPolicy.JitApprovers[i].DisplayName, Is.EqualTo(model.Data.JitAccessPolicy.JitApprovers[i].DisplayName));
                        Assert.That(getResult.Data.JitAccessPolicy.JitApprovers[i].ApproverType, Is.EqualTo(model.Data.JitAccessPolicy.JitApprovers[i].ApproverType));
                    });
                }
                Assert.That(getResult.Data.JitAccessPolicy.MaximumJitAccessDuration, Is.EqualTo(model.Data.JitAccessPolicy.MaximumJitAccessDuration));
            }

            Assert.Multiple(() =>
            {
                Assert.That(getResult.Data.PublisherTenantId, Is.EqualTo(model.Data.PublisherTenantId));
                Assert.That(getResult.Data.Authorizations, Has.Count.EqualTo(model.Data.Authorizations.Count));
            });
            for (int i = 0; i < model.Data.Authorizations.Count; ++i)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.Data.Authorizations[i].PrincipalId, Is.EqualTo(model.Data.Authorizations[i].PrincipalId));
                    Assert.That(getResult.Data.Authorizations[i].RoleDefinitionId, Is.EqualTo(model.Data.Authorizations[i].RoleDefinitionId));
                });
            }
            Assert.That(getResult.Data.ManagementMode, Is.EqualTo(model.Data.ManagementMode));
            if (model.Data.CustomerSupport != null || getResult.Data.CustomerSupport != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Data.CustomerSupport, Is.Not.Null);
                    Assert.That(getResult.Data.CustomerSupport, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.Data.CustomerSupport.ContactName, Is.EqualTo(model.Data.CustomerSupport.ContactName));
                    Assert.That(getResult.Data.CustomerSupport.Email, Is.EqualTo(model.Data.CustomerSupport.Email));
                    Assert.That(getResult.Data.CustomerSupport.Phone, Is.EqualTo(model.Data.CustomerSupport.Phone));
                });
            }
            if (model.Data.SupportUris != null || getResult.Data.SupportUris != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Data.SupportUris, Is.Not.Null);
                    Assert.That(getResult.Data.SupportUris, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.Data.SupportUris.AzureGovernmentUri, Is.EqualTo(model.Data.SupportUris.AzureGovernmentUri));
                    Assert.That(getResult.Data.SupportUris.AzurePublicCloudUri, Is.EqualTo(model.Data.SupportUris.AzurePublicCloudUri));
                });
            }
            if (model.Data.Artifacts != null || getResult.Data.Artifacts != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Data.Artifacts, Is.Not.Null);
                    Assert.That(getResult.Data.Artifacts, Is.Not.Null);
                });
                Assert.That(getResult.Data.Artifacts, Has.Count.EqualTo(model.Data.Artifacts.Count));
                for (int i = 0; i < model.Data.Artifacts.Count; ++i)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(getResult.Data.Artifacts[i].Name, Is.EqualTo(model.Data.Artifacts[i].Name));
                        Assert.That(getResult.Data.Artifacts[i].Uri, Is.EqualTo(model.Data.Artifacts[i].Uri));
                        Assert.That(getResult.Data.Artifacts[i].ArtifactType, Is.EqualTo(model.Data.Artifacts[i].ArtifactType));
                    });
                }
            }
            if (model.Data.CreatedBy != null || getResult.Data.CreatedBy != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Data.CreatedBy, Is.Not.Null);
                    Assert.That(getResult.Data.CreatedBy, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.Data.CreatedBy.ObjectId, Is.EqualTo(model.Data.CreatedBy.ObjectId));
                    Assert.That(getResult.Data.CreatedBy.Puid, Is.EqualTo(model.Data.CreatedBy.Puid));
                    Assert.That(getResult.Data.CreatedBy.ApplicationId, Is.EqualTo(model.Data.CreatedBy.ApplicationId));
                });
            }
            if (model.Data.UpdatedBy != null || getResult.Data.UpdatedBy != null)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(model.Data.UpdatedBy, Is.Not.Null);
                    Assert.That(getResult.Data.UpdatedBy, Is.Not.Null);
                });
                Assert.Multiple(() =>
                {
                    Assert.That(getResult.Data.UpdatedBy.ObjectId, Is.EqualTo(model.Data.UpdatedBy.ObjectId));
                    Assert.That(getResult.Data.UpdatedBy.Puid, Is.EqualTo(model.Data.UpdatedBy.Puid));
                    Assert.That(getResult.Data.UpdatedBy.ApplicationId, Is.EqualTo(model.Data.UpdatedBy.ApplicationId));
                });
            }
        }
    }
}
