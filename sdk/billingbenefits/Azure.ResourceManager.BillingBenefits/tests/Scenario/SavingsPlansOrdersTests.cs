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
            Assert.That(response2.Value.Data.PlanInformation, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(response2.Value.Data.PlanInformation.NextPaymentDueOn, Is.Not.Null);
                Assert.That(response2.Value.Data.PlanInformation.PricingCurrencyTotal, Is.Not.Null);
                Assert.That(response2.Value.Data.PlanInformation.StartOn, Is.Not.Null);
                Assert.That(response2.Value.Data.PlanInformation.Transactions, Is.Not.Null);
            });
            Assert.That(response2.Value.Data.PlanInformation.Transactions, Is.Not.Empty);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestElevateSavingsPlanOrder()
        {
            var resource = BillingBenefitsSavingsPlanOrderResource.CreateResourceIdentifier("36c74101-dda7-4bb9-8403-3baf1661b065");
            var modelResource = Client.GetBillingBenefitsSavingsPlanOrderResource(resource);
            var response = await modelResource.ElevateAsync();

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value, Is.Not.Null);
                Assert.That((string)response.Value.Id, Is.Not.Empty);
            });
            Assert.That(response.Value.Id.ToString(), Does.Contain("/providers/Microsoft.BillingBenefits/savingsplanorders/"));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Id.ToString(), Does.Contain("/providers/Microsoft.Authorization/roleAssignments/"));
                Assert.That(response.Value.Name, Is.Not.Empty);
                Assert.That(response.Value.PrincipalId, Is.Not.Empty);
                Assert.That((string)response.Value.RoleDefinitionId, Is.Not.Empty);
                Assert.That(response.Value.RoleDefinitionId.ToString(), Does.Contain("/providers/Microsoft.Authorization/roleDefinitions/"));
                Assert.That((string)response.Value.Scope, Is.Not.Empty);
                Assert.That(response.Value.Scope.ToString(), Does.Contain("/providers/Microsoft.BillingBenefits/savingsplanorders/"));
            });
        }

        [TestCase]
        [RecordedTest]
        public async Task ListSavingsPlanOrders()
        {
            var orderModelCollection = _tenant.GetBillingBenefitsSavingsPlanOrders();
            List<BillingBenefitsSavingsPlanOrderResource> orderResources = await orderModelCollection.GetAllAsync().ToEnumerableAsync();

            Assert.That(orderResources, Is.Not.Empty);
            orderResources.ForEach(model =>
            {
                ValidateResponseProperties(model);
            });
        }

        private void ValidateResponseProperties(BillingBenefitsSavingsPlanOrderResource model)
        {
            Assert.Multiple(() =>
            {
                Assert.That(model.HasData, Is.True);
                Assert.That(model.Data.BillingScopeId.ToString(), Is.EqualTo("eef82110-c91b-4395-9420-fcfcbefc5a47"));
                Assert.That(model.Data.Id, Is.Not.Null);
                Assert.That(model.Data.Name, Is.Not.Empty);
                Assert.That(model.Data.DisplayName, Is.Not.Empty);
                Assert.That(model.Data.ResourceType, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(model.Data.ResourceType.Namespace, Is.EqualTo("microsoft.billingbenefits"));
                Assert.That(model.Data.ResourceType.Type, Is.EqualTo("savingsPlanOrders"));
                Assert.That(model.Data.Sku, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(model.Data.Sku.Name, Is.EqualTo("Compute_Savings_Plan"));
                Assert.That(model.Data.SkuName, Is.EqualTo("Compute_Savings_Plan"));
                Assert.That(model.Data.Term, Is.Not.Null);
                Assert.That(model.Data.BenefitStartOn, Is.Not.Null);
                Assert.That((string)model.Data.BillingAccountId, Is.Not.Empty);
                Assert.That((string)model.Data.BillingProfileId, Is.Not.Empty);
                Assert.That(model.Data.SavingsPlans, Is.Not.Null);
            });
            Assert.That(model.Data.SavingsPlans.Count, Is.EqualTo(1));
        }
    }
}
