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
    public class PurchaseReservationOrderTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }
        private ReservationOrderCollection Collection { get; set; }

        public PurchaseReservationOrderTests(bool isAsync) : base(isAsync)
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
                Collection = Tenant.GetReservationOrders();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestPurchaseReservationOrderSharedScopeMonthly()
        {
            var purchaseRequestContent = CreatePurchaseRequestContent("Shared", "Monthly");
            var response = await Tenant.CalculateReservationOrderAsync(purchaseRequestContent);
            Assert.NotNull(response.Value.Properties.ReservationOrderId);
            var purchaseResponse = await Collection.CreateOrUpdateAsync(WaitUntil.Completed, (Guid)response.Value.Properties.ReservationOrderId, purchaseRequestContent);

            TestCreatePurchaseResponse(purchaseResponse, purchaseRequestContent, response.Value.Properties.ReservationOrderId.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task TestPurchaseReservationOrderSharedScopeUpfront()
        {
            var purchaseRequestContent = CreatePurchaseRequestContent("Shared", "Upfront");
            var response = await Tenant.CalculateReservationOrderAsync(purchaseRequestContent);
            Assert.NotNull(response.Value.Properties.ReservationOrderId);
            var purchaseResponse = await Collection.CreateOrUpdateAsync(WaitUntil.Completed, (Guid)response.Value.Properties.ReservationOrderId, purchaseRequestContent);

            TestCreatePurchaseResponse(purchaseResponse, purchaseRequestContent, response.Value.Properties.ReservationOrderId.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task TestPurchaseReservationOrderSingleScopeMonthly()
        {
            var purchaseRequestContent = CreatePurchaseRequestContent("Single", "Monthly");
            var response = await Tenant.CalculateReservationOrderAsync(purchaseRequestContent);
            Assert.NotNull(response.Value.Properties.ReservationOrderId);
            var purchaseResponse = await Collection.CreateOrUpdateAsync(WaitUntil.Completed, (Guid)response.Value.Properties.ReservationOrderId, purchaseRequestContent);

            TestCreatePurchaseResponse(purchaseResponse, purchaseRequestContent, response.Value.Properties.ReservationOrderId.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task TestPurchaseReservationOrderSingleScopeUpfront()
        {
            var purchaseRequestContent = CreatePurchaseRequestContent("Single", "Upfront");
            var response = await Tenant.CalculateReservationOrderAsync(purchaseRequestContent);
            Assert.NotNull(response.Value.Properties.ReservationOrderId);
            var purchaseResponse = await Collection.CreateOrUpdateAsync(WaitUntil.Completed, (Guid)response.Value.Properties.ReservationOrderId, purchaseRequestContent);

            TestCreatePurchaseResponse(purchaseResponse, purchaseRequestContent, response.Value.Properties.ReservationOrderId.ToString());
        }

        private void TestCreatePurchaseResponse(ArmOperation<ReservationOrderResource> purchaseResponse, ReservationPurchaseContent purchaseRequest, string reservationOrderId)
        {
            Assert.IsTrue(purchaseResponse.HasCompleted);
            Assert.IsTrue(purchaseResponse.HasValue);
            Assert.AreEqual(purchaseRequest.BillingPlan.ToString(), purchaseResponse.Value.Data.BillingPlan.ToString());
            Assert.AreEqual(string.Format("/providers/microsoft.capacity/reservationOrders/{0}", reservationOrderId), purchaseResponse.Value.Data.Id.ToString());
            Assert.AreEqual("Microsoft.Capacity", purchaseResponse.Value.Data.ResourceType.Namespace);
            Assert.AreEqual("reservationOrders", purchaseResponse.Value.Data.ResourceType.Type);
            Assert.AreEqual(purchaseRequest.DisplayName, purchaseResponse.Value.Data.DisplayName);
            Assert.AreEqual(reservationOrderId, purchaseResponse.Value.Data.Name);
            Assert.AreEqual(1, purchaseResponse.Value.Data.OriginalQuantity);
            Assert.AreEqual(purchaseRequest.Term.ToString(), purchaseResponse.Value.Data.Term.ToString());
            Assert.IsNotNull(purchaseResponse.Value.Data.Reservations);
            Assert.AreEqual(1, purchaseResponse.Value.Data.Reservations.Count);
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
