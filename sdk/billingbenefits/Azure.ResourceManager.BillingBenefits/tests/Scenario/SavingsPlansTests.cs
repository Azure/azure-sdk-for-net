// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.BillingBenefits;
using Azure.ResourceManager.BillingBenefits.Models;
using Azure.ResourceManager.BillingBenefits.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class SavingsPlansTests : BillingBenefitsManagementTestBase
    {
        private TenantResource Tenant { get; set; }

        public SavingsPlansTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await CreateCommonClient();

                AsyncPageable<TenantResource> tenantResourcesResponse = Client.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                Tenant = tenantResources.ToArray()[0];
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListSavingsPlans()
        {
            var response = Tenant.GetSavingsPlanModelsAsync();
            List<SavingsPlanModelResource> savingsPlanModelResources = await response.ToEnumerableAsync();

            Assert.Greater(savingsPlanModelResources.Count, 0);
            savingsPlanModelResources.ForEach(model =>
            {
                Assert.IsTrue(model.HasData);
                Assert.AreEqual("/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47", model.Data.BillingScopeId);
                Assert.NotNull(model.Data.Commitment);
                Assert.NotNull(model.Data.Id);
                Assert.IsNotEmpty(model.Data.Name);
                Assert.IsNotEmpty(model.Data.DisplayName);
                Assert.NotNull(model.Data.ResourceType);
                Assert.AreEqual("microsoft.billingbenefits", model.Data.ResourceType.Namespace);
                Assert.AreEqual("savingsPlanOrders/savingsPlans", model.Data.ResourceType.Type);
                Assert.NotNull(model.Data.Sku);
                Assert.AreEqual("Compute_Savings_Plan", model.Data.Sku.Name);
                Assert.AreEqual("Compute_Savings_Plan", model.Data.SkuName);
                Assert.NotNull(model.Data.Term);
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListSavingsPlansWithSelectedState()
        {
            var response = Tenant.GetSavingsPlanModelsAsync(selectedState: "Succeeded");
            List<SavingsPlanModelResource> savingsPlanModelResources = await response.ToEnumerableAsync();

            Assert.Greater(savingsPlanModelResources.Count, 0);
            savingsPlanModelResources.ForEach(model =>
            {
                Assert.IsTrue(model.HasData);
                Assert.AreEqual(ProvisioningState.Succeeded, model.Data.ProvisioningState);
            });
        }
    }
}
