// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Reservations.Tests.Helper;
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
            var response = await Tenant.CalculateReservationOrderAsync(TestHelpers.CreatePurchaseRequestContent("Shared", billingPlan));
            TestCalculatePriceResponse(response, billingPlan);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSharedScopeUpfront()
        {
            var billingPlan = "Upfront";
            var response = await Tenant.CalculateReservationOrderAsync(TestHelpers.CreatePurchaseRequestContent("Shared", billingPlan));
            TestCalculatePriceResponse(response, billingPlan);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSingleScopeMonthly()
        {
            var billingPlan = "Monthly";
            var response = await Tenant.CalculateReservationOrderAsync(TestHelpers.CreatePurchaseRequestContent("Single", billingPlan));
            TestCalculatePriceResponse(response, billingPlan);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSingleScopeUpfront()
        {
            var billingPlan = "Upfront";
            var response = await Tenant.CalculateReservationOrderAsync(TestHelpers.CreatePurchaseRequestContent("Single", billingPlan));
            TestCalculatePriceResponse(response, billingPlan);
        }

        private void TestCalculatePriceResponse(Response<CalculatePriceResult> response, string billingPlan)
        {
            var price = response.Value;

            // Should return 200 with monthly price
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(price.Properties.BillingCurrencyTotal.CurrencyCode, Is.EqualTo("USD"));
            Assert.That(price.Properties.BillingCurrencyTotal.Amount > 0, Is.True);
            Assert.That(price.Properties.PricingCurrencyTotal.CurrencyCode, Is.EqualTo("USD"));
            Assert.That(price.Properties.PricingCurrencyTotal.Amount > 0, Is.True);
            Assert.That(price.Properties.ReservationOrderId.ToString(), Is.Not.Empty);

            if (billingPlan.Equals("Upfront"))
            {
                Assert.That(price.Properties.PaymentSchedule, Is.Empty);
            }
            else
            {
                Assert.That(price.Properties.PaymentSchedule.Count, Is.EqualTo(12));
                foreach (var item in price.Properties.PaymentSchedule)
                {
                    Assert.That(item.PricingCurrencyTotal.CurrencyCode, Is.EqualTo("USD"));
                    Assert.That(item.PricingCurrencyTotal.Amount > 0, Is.True);
                    Assert.That(item.DueOn, Is.Not.Null);
                    Assert.That(item.Status, Is.EqualTo(PaymentStatus.Scheduled));
                }
            }
        }
    }
}
