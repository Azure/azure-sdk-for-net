// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class SavingsPlansOrdersTests : BillingBenefitsManagementTestBase
    {
        private TenantResource _tenant;

        public SavingsPlansOrdersTests(bool isAsync) : base(isAsync)
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
                _tenant = tenantResources.ToArray()[0];
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetSavingsPlanOrder()
        {
            var response = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a");

            ValidateResponseProperties(response);

            // Expand 'schedule'
            var response2 = await _tenant.GetBillingBenefitsSavingsPlanOrderAsync("b538c0a7-b852-4ff8-aa3a-1d91dad90d2a", "schedule");
            Assert.IsNotNull(response2.Value.Data.PlanInformation);
            Assert.IsNotNull(response2.Value.Data.PlanInformation.NextPaymentDueOn);
            Assert.IsNotNull(response2.Value.Data.PlanInformation.PricingCurrencyTotal);
            Assert.IsNotNull(response2.Value.Data.PlanInformation.StartOn);
            Assert.IsNotNull(response2.Value.Data.PlanInformation.Transactions);
            Assert.Greater(response2.Value.Data.PlanInformation.Transactions.Count, 0);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestElevateSavingsPlanOrder()
        {
            var resource = BillingBenefitsSavingsPlanOrderResource.CreateResourceIdentifier("36c74101-dda7-4bb9-8403-3baf1661b065");
            var modelResource = Client.GetBillingBenefitsSavingsPlanOrderResource(resource);
            var response = await modelResource.ElevateAsync();

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.NotNull(response.Value);
            Assert.IsNotEmpty(response.Value.Id);
            Assert.That(response.Value.Id.ToString().Contains("/providers/Microsoft.BillingBenefits/savingsplanorders/"), Is.True);
            Assert.That(response.Value.Id.ToString().Contains("/providers/Microsoft.Authorization/roleAssignments/"), Is.True);
            Assert.IsNotEmpty(response.Value.Name);
            Assert.IsNotEmpty(response.Value.PrincipalId);
            Assert.IsNotEmpty(response.Value.RoleDefinitionId);
            Assert.That(response.Value.RoleDefinitionId.ToString().Contains("/providers/Microsoft.Authorization/roleDefinitions/"), Is.True);
            Assert.IsNotEmpty(response.Value.Scope);
            Assert.That(response.Value.Scope.ToString().Contains("/providers/Microsoft.BillingBenefits/savingsplanorders/"), Is.True);
        }

        [TestCase]
        [RecordedTest]
        public async Task ListSavingsPlanOrders()
        {
            var orderModelCollection = _tenant.GetBillingBenefitsSavingsPlanOrders();
            List<BillingBenefitsSavingsPlanOrderResource> orderResources = await orderModelCollection.GetAllAsync().ToEnumerableAsync();

            Assert.Greater(orderResources.Count, 0);
            orderResources.ForEach(model =>
            {
                ValidateResponseProperties(model);
            });
        }

        private void ValidateResponseProperties(BillingBenefitsSavingsPlanOrderResource model)
        {
            Assert.That(model.HasData, Is.True);
            Assert.That(model.Data.BillingScopeId.ToString(), Is.EqualTo("eef82110-c91b-4395-9420-fcfcbefc5a47"));
            Assert.NotNull(model.Data.Id);
            Assert.IsNotEmpty(model.Data.Name);
            Assert.IsNotEmpty(model.Data.DisplayName);
            Assert.NotNull(model.Data.ResourceType);
            Assert.That(model.Data.ResourceType.Namespace, Is.EqualTo("microsoft.billingbenefits"));
            Assert.That(model.Data.ResourceType.Type, Is.EqualTo("savingsPlanOrders"));
            Assert.NotNull(model.Data.Sku);
            Assert.That(model.Data.Sku.Name, Is.EqualTo("Compute_Savings_Plan"));
            Assert.That(model.Data.SkuName, Is.EqualTo("Compute_Savings_Plan"));
            Assert.NotNull(model.Data.Term);
            Assert.NotNull(model.Data.BenefitStartOn);
            Assert.IsNotEmpty(model.Data.BillingAccountId);
            Assert.IsNotEmpty(model.Data.BillingProfileId);
            Assert.NotNull(model.Data.SavingsPlans);
            Assert.That(model.Data.SavingsPlans.Count, Is.EqualTo(1));
        }
    }
}
