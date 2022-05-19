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
        public TenantResource Tenant { get; set; }

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
            var requestContent = new PurchaseRequestContent(
                sku: new ReservationsSkuName("Standard_B1ls"),
                location: new Core.AzureLocation("westus"),
                reservedResourceType: new ReservedResourceType("VirtualMachines"),
                billingScopeId: "/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93",
                term: new ReservationTerm("P1Y"),
                billingPlan: new ReservationBillingPlan("Monthly"),
                quantity: 1,
                displayName: "testVM",
                appliedScopeType: new AppliedScopeType("Shared"),
                renew: false,
                reservedResourceProperties: new PurchaseRequestPropertiesReservedResourceProperties(new InstanceFlexibility("On")),
                appliedScopes: null);

            var response = await Tenant.CalculateReservationOrderAsync(requestContent);
            testForMonthly(response);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSharedScopeUpfront()
        {
            var requestContent = new PurchaseRequestContent(
                sku: new ReservationsSkuName("Standard_B1ls"),
                location: new Core.AzureLocation("westus"),
                reservedResourceType: new ReservedResourceType("VirtualMachines"),
                billingScopeId: "/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93",
                term: new ReservationTerm("P1Y"),
                billingPlan: new ReservationBillingPlan("Upfront"),
                quantity: 1,
                displayName: "testVM",
                appliedScopeType: new AppliedScopeType("Shared"),
                renew: false,
                reservedResourceProperties: new PurchaseRequestPropertiesReservedResourceProperties(new InstanceFlexibility("On")),
                appliedScopes: null);

            var response = await Tenant.CalculateReservationOrderAsync(requestContent);
            testForUpfront(response);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSingleScopeMonthly()
        {
            var appliedScopes = new List<string>();
            appliedScopes.Add("/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93");
            var requestContent = new PurchaseRequestContent(
                sku: new ReservationsSkuName("Standard_B1ls"),
                location: new Core.AzureLocation("westus"),
                reservedResourceType: new ReservedResourceType("VirtualMachines"),
                billingScopeId: "/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93",
                term: new ReservationTerm("P1Y"),
                billingPlan: new ReservationBillingPlan("Monthly"),
                quantity: 1,
                displayName: "testVM",
                appliedScopeType: new AppliedScopeType("Single"),
                renew: false,
                reservedResourceProperties: new PurchaseRequestPropertiesReservedResourceProperties(new InstanceFlexibility("On")),
                appliedScopes: appliedScopes);

            var response = await Tenant.CalculateReservationOrderAsync(requestContent);
            testForMonthly(response);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestCalculatePriceForSingleScopeUpfront()
        {
            var appliedScopes = new List<string>();
            appliedScopes.Add("/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93");
            var requestContent = new PurchaseRequestContent(
                sku: new ReservationsSkuName("Standard_B1ls"),
                location: new Core.AzureLocation("westus"),
                reservedResourceType: new ReservedResourceType("VirtualMachines"),
                billingScopeId: "/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93",
                term: new ReservationTerm("P1Y"),
                billingPlan: new ReservationBillingPlan("Upfront"),
                quantity: 1,
                displayName: "testVM",
                appliedScopeType: new AppliedScopeType("Single"),
                renew: false,
                reservedResourceProperties: new PurchaseRequestPropertiesReservedResourceProperties(new InstanceFlexibility("On")),
                appliedScopes: appliedScopes);

            var response = await Tenant.CalculateReservationOrderAsync(requestContent);
            testForUpfront(response);
        }

        private void testForUpfront(Response<CalculatePriceResponse> response)
        {
            var price = response.Value;

            // Should return 200 with monthly price
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("USD", price.Properties.BillingCurrencyTotal.CurrencyCode);
            Assert.IsTrue(price.Properties.BillingCurrencyTotal.Amount > 0);
            Assert.AreEqual("USD", price.Properties.PricingCurrencyTotal.CurrencyCode);
            Assert.IsTrue(price.Properties.PricingCurrencyTotal.Amount > 0);
            Assert.IsNotEmpty(price.Properties.ReservationOrderId);
            Assert.IsEmpty(price.Properties.PaymentSchedule);
        }

        private void testForMonthly(Response<CalculatePriceResponse> response)
        {
            var price = response.Value;

            // Should return 200 with monthly price
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("USD", price.Properties.BillingCurrencyTotal.CurrencyCode);
            Assert.IsTrue(price.Properties.BillingCurrencyTotal.Amount > 0);
            Assert.AreEqual("USD", price.Properties.PricingCurrencyTotal.CurrencyCode);
            Assert.IsTrue(price.Properties.PricingCurrencyTotal.Amount > 0);
            Assert.IsNotEmpty(price.Properties.ReservationOrderId);
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
}
