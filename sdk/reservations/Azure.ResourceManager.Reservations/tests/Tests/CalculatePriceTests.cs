// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class CalculatePriceTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }

        public CalculatePriceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();

                AsyncPageable<TenantResource> tenantResourcesResponse = ArmClient.GetTenants().GetAllAsync();
                List<TenantResource> tenantResources = await tenantResourcesResponse.ToEnumerableAsync();
                Tenant = tenantResources.ToArray()[0];
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSharedScopeMonthly()
        {
            var billingPlan = "Monthly";
            var response = await Tenant.CalculateReservationOrderAsync(CreatePurchaseRequestContent("Shared", billingPlan));
            TestCalculatePriceResponse(response, billingPlan);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSharedScopeUpfront()
        {
            var billingPlan = "Upfront";
            var response = await Tenant.CalculateReservationOrderAsync(CreatePurchaseRequestContent("Shared", billingPlan));
            TestCalculatePriceResponse(response, billingPlan);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSingleScopeMonthly()
        {
            var billingPlan = "Monthly";
            var response = await Tenant.CalculateReservationOrderAsync(CreatePurchaseRequestContent("Single", billingPlan));
            TestCalculatePriceResponse(response, billingPlan);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSingleScopeUpfront()
        {
            var billingPlan = "Upfront";
            var response = await Tenant.CalculateReservationOrderAsync(CreatePurchaseRequestContent("Single", billingPlan));
            TestCalculatePriceResponse(response, billingPlan);
        }

        private void TestCalculatePriceResponse(Response<CalculatePriceResult> response, string billingPlan)
        {
            var price = response.Value;

            // Should return 200 with monthly price
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("USD", price.Properties.BillingCurrencyTotal.CurrencyCode);
            Assert.IsTrue(price.Properties.BillingCurrencyTotal.Amount > 0);
            Assert.AreEqual("USD", price.Properties.PricingCurrencyTotal.CurrencyCode);
            Assert.IsTrue(price.Properties.PricingCurrencyTotal.Amount > 0);
            Assert.IsNotEmpty(price.Properties.ReservationOrderId.ToString());

            if (billingPlan.Equals("Upfront"))
            {
                Assert.IsEmpty(price.Properties.PaymentSchedule);
            }
            else
            {
                Assert.AreEqual(12, price.Properties.PaymentSchedule.Count);
                foreach (var item in price.Properties.PaymentSchedule)
                {
                    Assert.AreEqual("USD", item.PricingCurrencyTotal.CurrencyCode);
                    Assert.IsTrue(item.PricingCurrencyTotal.Amount > 0);
                    Assert.IsNotNull(item.DueOn);
                    Assert.AreEqual(PaymentStatus.Scheduled, item.Status);
                }
            }
        }

        private ReservationPurchaseContent CreatePurchaseRequestContent(string scope, string billingPlan)
        {
            var request = new ReservationPurchaseContent
            {
                Sku = new ReservationsSkuName("Standard_B1ls"),
                Location = new Core.AzureLocation("westus"),
                ReservedResourceType = new ReservedResourceType("VirtualMachines"),
                BillingScopeId = new Core.ResourceIdentifier("/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93"),
                Term = new ReservationTerm("P1Y"),
                BillingPlan = new ReservationBillingPlan(billingPlan),
                Quantity = 1,
                DisplayName = "testVM",
                AppliedScopeType = new AppliedScopeType(scope),
                IsRenewEnabled = false,
                ReservedResourceProperties = new PurchaseRequestPropertiesReservedResourceProperties(new InstanceFlexibility("On")),
            };

            if (scope.Equals("Single"))
            {
                request.AppliedScopes.Add("/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93");
            }

            return request;
        }
    }
}
