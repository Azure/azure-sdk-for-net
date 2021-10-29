// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-1-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-C-");
            ApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ApplicationDefinition appDef = (await rg.GetApplicationDefinitions().CreateOrUpdateAsync(appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-C-");
            ApplicationData applicationData = CreateApplicationData(appDef.Id, subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-1-"), Recording.GenerateAssetName("s1"));
            Application application = (await rg.GetApplications().CreateOrUpdateAsync(appName, applicationData)).Value;
            Assert.AreEqual(appName, application.Data.Name);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetApplications().CreateOrUpdateAsync(null, applicationData));
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetApplications().CreateOrUpdateAsync(appName, null));
        }

        [TestCase]
        [RecordedTest]
        public async Task ListByRG()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-2-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-L-");
            ApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ApplicationDefinition appDef = (await rg.GetApplicationDefinitions().CreateOrUpdateAsync(appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-L-");
            ApplicationData applicationData = CreateApplicationData(appDef.Id, subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-2-"), Recording.GenerateAssetName("s2"));
            _ = await rg.GetApplications().CreateOrUpdateAsync(appName, applicationData);
            int count = 0;
            await foreach (var tempApplication in rg.GetApplications().GetAllAsync())
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListBySubscription()
        {
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-3-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-L-");
            ApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ApplicationDefinition appDef = (await rg.GetApplicationDefinitions().CreateOrUpdateAsync(appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-L-");
            ApplicationData applicationData = CreateApplicationData(appDef.Id, subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-3-"), Recording.GenerateAssetName("s3"));
            _ = await rg.GetApplications().CreateOrUpdateAsync(appName, applicationData);
            int count = 0;
            await foreach (var tempApplication in subscription.GetApplicationsAsync())
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
            Subscription subscription = await Client.GetDefaultSubscriptionAsync();
            string rgName = Recording.GenerateAssetName("testRg-4-");
            ResourceGroupData rgData = new ResourceGroupData(Location.WestUS2);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(rgName, rgData);
            ResourceGroup rg = lro.Value;
            string appDefName = Recording.GenerateAssetName("appDef-G-");
            ApplicationDefinitionData appDefData = CreateApplicationDefinitionData(appDefName);
            ApplicationDefinition appDef = (await rg.GetApplicationDefinitions().CreateOrUpdateAsync(appDefName, appDefData)).Value;
            string appName = Recording.GenerateAssetName("application-G-");
            ApplicationData applicationData = CreateApplicationData(appDef.Id, subscription.Id + Recording.GenerateAssetName("/resourceGroups/managed-4-"), Recording.GenerateAssetName("s4"));
            Application application = (await rg.GetApplications().CreateOrUpdateAsync(appName, applicationData)).Value;
            Application getApplication = await rg.GetApplications().GetAsync(appName);
            AssertValidApplication(application, getApplication);
            Assert.ThrowsAsync<ArgumentNullException>(async () => _ = await rg.GetApplications().GetAsync(null));
        }

        private static void AssertValidApplication(Application model, Application getResult)
        {
            Assert.AreEqual(model.Data.Name, getResult.Data.Name);
            Assert.AreEqual(model.Data.Id, getResult.Data.Id);
            Assert.AreEqual(model.Data.Type, getResult.Data.Type);
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
            Assert.AreEqual(model.Data.Parameters, getResult.Data.Parameters);
            Assert.AreEqual(model.Data.Outputs, getResult.Data.Outputs);
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
                    Assert.AreEqual(model.Data.JitAccessPolicy.JitApprovers[i].Type, getResult.Data.JitAccessPolicy.JitApprovers[i].Type);
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
            if (model.Data.SupportUrls != null || getResult.Data.SupportUrls != null)
            {
                Assert.NotNull(model.Data.SupportUrls);
                Assert.NotNull(getResult.Data.SupportUrls);
                Assert.AreEqual(model.Data.SupportUrls.GovernmentCloud, getResult.Data.SupportUrls.GovernmentCloud);
                Assert.AreEqual(model.Data.SupportUrls.PublicAzure, getResult.Data.SupportUrls.PublicAzure);
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
                    Assert.AreEqual(model.Data.Artifacts[i].Type, getResult.Data.Artifacts[i].Type);
                }
            }
            if (model.Data.CreatedBy != null || getResult.Data.CreatedBy != null)
            {
                Assert.NotNull(model.Data.CreatedBy);
                Assert.NotNull(getResult.Data.CreatedBy);
                Assert.AreEqual(model.Data.CreatedBy.Oid, getResult.Data.CreatedBy.Oid);
                Assert.AreEqual(model.Data.CreatedBy.Puid, getResult.Data.CreatedBy.Puid);
                Assert.AreEqual(model.Data.CreatedBy.ApplicationId, getResult.Data.CreatedBy.ApplicationId);
            }
            if (model.Data.UpdatedBy != null || getResult.Data.UpdatedBy != null)
            {
                Assert.NotNull(model.Data.UpdatedBy);
                Assert.NotNull(getResult.Data.UpdatedBy);
                Assert.AreEqual(model.Data.UpdatedBy.Oid, getResult.Data.UpdatedBy.Oid);
                Assert.AreEqual(model.Data.UpdatedBy.Puid, getResult.Data.UpdatedBy.Puid);
                Assert.AreEqual(model.Data.UpdatedBy.ApplicationId, getResult.Data.UpdatedBy.ApplicationId);
            }
        }
    }
}
