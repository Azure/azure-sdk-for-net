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
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Data, Is.Not.Null);
            Assert.That(response.Value.Data.Id.ToString(), Is.EqualTo("/providers/microsoft.capacity/reservationOrders/8d233700-d9f3-4021-aba1-f9350f3ac0dc"));
            Assert.That(response.Value.Data.ResourceType.ToString(), Is.EqualTo("microsoft.capacity/reservationOrders"));
            Assert.That(response.Value.Data.Name, Is.EqualTo("8d233700-d9f3-4021-aba1-f9350f3ac0dc"));
            Assert.That(response.Value.Data.Version, Is.EqualTo(21));
            Assert.That(response.Value.Data.DisplayName, Is.EqualTo("testingCreateTipVM"));
            Assert.That(response.Value.Data.Term, Is.EqualTo(ReservationTerm.P1Y));
            Assert.That(response.Value.Data.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Cancelled));
            Assert.That(response.Value.Data.Reservations, Is.Not.Null);
            Assert.That(response.Value.Data.Reservations.Count, Is.EqualTo(1));
            Assert.That(response.Value.Data.Reservations[0].Id.ToString(), Is.EqualTo("/providers/Microsoft.Capacity/reservationOrders/8d233700-d9f3-4021-aba1-f9350f3ac0dc/reservations/ec1a9023-ec6b-44a7-8a49-1402bc2d766b"));
            Assert.That(response.Value.Data.OriginalQuantity, Is.EqualTo(3));
            Assert.That(response.Value.Data.BillingPlan, Is.EqualTo(ReservationBillingPlan.Monthly));
        }

        [TestCase]
        [RecordedTest]
        public async Task TestGetReservationOrders()
        {
            AsyncPageable<ReservationOrderResource> response = Collection.GetAllAsync();
            List<ReservationOrderResource> result = await response.ToEnumerableAsync();
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count > 0, Is.True);
            Assert.That(result[0].Data, Is.Not.Null);
            Assert.That(result[0].Data.Id.ToString(), Is.EqualTo("/providers/microsoft.capacity/reservationOrders/5e500b18-4fb6-4a63-b6d8-8469a09c5e60"));
            Assert.That(result[0].Data.ResourceType.ToString(), Is.EqualTo("microsoft.capacity/reservationOrders"));
            Assert.That(result[0].Data.Name, Is.EqualTo("5e500b18-4fb6-4a63-b6d8-8469a09c5e60"));
            Assert.That(result[0].Data.Version, Is.EqualTo(21));
            Assert.That(result[0].Data.DisplayName, Is.EqualTo("testVM"));
            Assert.That(result[0].Data.Term, Is.EqualTo(ReservationTerm.P1Y));
            Assert.That(result[0].Data.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Cancelled));
            Assert.That(result[0].Data.Reservations, Is.Not.Null);
            Assert.That(result[0].Data.Reservations.Count, Is.EqualTo(1));
            Assert.That(result[0].Data.Reservations[0].Id.ToString(), Is.EqualTo("/providers/Microsoft.Capacity/reservationOrders/5e500b18-4fb6-4a63-b6d8-8469a09c5e60/reservations/48f6eeec-cf66-4a23-a4be-81d4d7000beb"));
            Assert.That(result[0].Data.OriginalQuantity, Is.EqualTo(3));
            Assert.That(result[0].Data.BillingPlan, Is.EqualTo(ReservationBillingPlan.Monthly));
        }
    }
}
