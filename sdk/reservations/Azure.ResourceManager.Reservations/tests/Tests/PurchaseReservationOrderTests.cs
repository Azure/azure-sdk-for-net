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
            var purchaseRequestContent = TestHelpers.CreatePurchaseRequestContent("Shared", "Monthly");
            var response = await Tenant.CalculateReservationOrderAsync(purchaseRequestContent);
            Assert.NotNull(response.Value.Properties.ReservationOrderId);
            var purchaseResponse = await Collection.CreateOrUpdateAsync(WaitUntil.Completed, (Guid)response.Value.Properties.ReservationOrderId, purchaseRequestContent);

            TestCreatePurchaseResponse(purchaseResponse, purchaseRequestContent, response.Value.Properties.ReservationOrderId.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task TestPurchaseReservationOrderSharedScopeUpfront()
        {
            var purchaseRequestContent = TestHelpers.CreatePurchaseRequestContent("Shared", "Upfront");
            var response = await Tenant.CalculateReservationOrderAsync(purchaseRequestContent);
            Assert.NotNull(response.Value.Properties.ReservationOrderId);
            var purchaseResponse = await Collection.CreateOrUpdateAsync(WaitUntil.Completed, (Guid)response.Value.Properties.ReservationOrderId, purchaseRequestContent);

            TestCreatePurchaseResponse(purchaseResponse, purchaseRequestContent, response.Value.Properties.ReservationOrderId.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task TestPurchaseReservationOrderSingleScopeMonthly()
        {
            var purchaseRequestContent = TestHelpers.CreatePurchaseRequestContent("Single", "Monthly");
            var response = await Tenant.CalculateReservationOrderAsync(purchaseRequestContent);
            Assert.NotNull(response.Value.Properties.ReservationOrderId);
            var purchaseResponse = await Collection.CreateOrUpdateAsync(WaitUntil.Completed, (Guid)response.Value.Properties.ReservationOrderId, purchaseRequestContent);

            TestCreatePurchaseResponse(purchaseResponse, purchaseRequestContent, response.Value.Properties.ReservationOrderId.ToString());
        }

        [TestCase]
        [RecordedTest]
        public async Task TestPurchaseReservationOrderSingleScopeUpfront()
        {
            var purchaseRequestContent = TestHelpers.CreatePurchaseRequestContent("Single", "Upfront");
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
            Assert.AreEqual("microsoft.capacity", purchaseResponse.Value.Data.ResourceType.Namespace);
            Assert.AreEqual("reservationOrders", purchaseResponse.Value.Data.ResourceType.Type);
            Assert.AreEqual(purchaseRequest.DisplayName, purchaseResponse.Value.Data.DisplayName);
            Assert.AreEqual(reservationOrderId, purchaseResponse.Value.Data.Name);
            Assert.AreEqual(3, purchaseResponse.Value.Data.OriginalQuantity);
            Assert.AreEqual(purchaseRequest.Term.ToString(), purchaseResponse.Value.Data.Term.ToString());
            Assert.IsNotNull(purchaseResponse.Value.Data.Reservations);
            Assert.AreEqual(1, purchaseResponse.Value.Data.Reservations.Count);
        }
    }
}
