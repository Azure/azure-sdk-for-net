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
    public class GetReservationOrderTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }
        private ReservationOrderCollection Collection { get; set; }

        public GetReservationOrderTests(bool isAsync) : base(isAsync)
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
        public async Task TestGetSingleReservationOrder()
        {
            var response = await Collection.GetAsync(Guid.Parse("8d233700-d9f3-4021-aba1-f9350f3ac0dc"));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/8d233700-d9f3-4021-aba1-f9350f3ac0dc", response.Value.Data.Id.ToString());
            Assert.AreEqual("microsoft.capacity/reservationOrders", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("8d233700-d9f3-4021-aba1-f9350f3ac0dc", response.Value.Data.Name);
            Assert.AreEqual(21, response.Value.Data.Version);
            Assert.AreEqual("testingCreateTipVM", response.Value.Data.DisplayName);
            Assert.AreEqual(ReservationTerm.P1Y, response.Value.Data.Term);
            Assert.AreEqual(ReservationProvisioningState.Cancelled, response.Value.Data.ProvisioningState);
            Assert.IsNotNull(response.Value.Data.Reservations);
            Assert.AreEqual(1, response.Value.Data.Reservations.Count);
            Assert.AreEqual("/providers/Microsoft.Capacity/reservationOrders/8d233700-d9f3-4021-aba1-f9350f3ac0dc/reservations/ec1a9023-ec6b-44a7-8a49-1402bc2d766b", response.Value.Data.Reservations[0].Id.ToString());
            Assert.AreEqual(3, response.Value.Data.OriginalQuantity);
            Assert.AreEqual(ReservationBillingPlan.Monthly, response.Value.Data.BillingPlan);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetReservationOrders()
        {
            AsyncPageable<ReservationOrderResource> response = Collection.GetAllAsync();
            List<ReservationOrderResource> result = await response.ToEnumerableAsync();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.IsNotNull(result[0].Data);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/5e500b18-4fb6-4a63-b6d8-8469a09c5e60", result[0].Data.Id.ToString());
            Assert.AreEqual("microsoft.capacity/reservationOrders", result[0].Data.ResourceType.ToString());
            Assert.AreEqual("5e500b18-4fb6-4a63-b6d8-8469a09c5e60", result[0].Data.Name);
            Assert.AreEqual(21, result[0].Data.Version);
            Assert.AreEqual("testVM", result[0].Data.DisplayName);
            Assert.AreEqual(ReservationTerm.P1Y, result[0].Data.Term);
            Assert.AreEqual(ReservationProvisioningState.Cancelled, result[0].Data.ProvisioningState);
            Assert.IsNotNull(result[0].Data.Reservations);
            Assert.AreEqual(1, result[0].Data.Reservations.Count);
            Assert.AreEqual("/providers/Microsoft.Capacity/reservationOrders/5e500b18-4fb6-4a63-b6d8-8469a09c5e60/reservations/48f6eeec-cf66-4a23-a4be-81d4d7000beb", result[0].Data.Reservations[0].Id.ToString());
            Assert.AreEqual(3, result[0].Data.OriginalQuantity);
            Assert.AreEqual(ReservationBillingPlan.Monthly, result[0].Data.BillingPlan);
        }
    }
}
