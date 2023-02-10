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
            var response = await Collection.GetAsync(Guid.Parse("838f3bcf-5af0-4606-ae23-cdea328acd51"));
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/838f3bcf-5af0-4606-ae23-cdea328acd51", response.Value.Data.Id.ToString());
            Assert.AreEqual("Microsoft.Capacity/reservationOrders", response.Value.Data.ResourceType.ToString());
            Assert.AreEqual("838f3bcf-5af0-4606-ae23-cdea328acd51", response.Value.Data.Name);
            Assert.AreEqual(4, response.Value.Data.Version);
            Assert.AreEqual("testVM", response.Value.Data.DisplayName);
            Assert.AreEqual(ReservationTerm.P1Y, response.Value.Data.Term);
            Assert.AreEqual(ReservationProvisioningState.Failed, response.Value.Data.ProvisioningState);
            Assert.IsNotNull(response.Value.Data.Reservations);
            Assert.AreEqual(1, response.Value.Data.Reservations.Count);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/838f3bcf-5af0-4606-ae23-cdea328acd51/reservations/2b3dce9f-0539-418f-9b30-594f0c089698", response.Value.Data.Reservations[0].Id.ToString());
            Assert.AreEqual(1, response.Value.Data.OriginalQuantity);
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
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/c848cae0-7ade-43c8-a42c-52cc53413a72", result[0].Data.Id.ToString());
            Assert.AreEqual("Microsoft.Capacity/reservationOrders", result[0].Data.ResourceType.ToString());
            Assert.AreEqual("c848cae0-7ade-43c8-a42c-52cc53413a72", result[0].Data.Name);
            Assert.AreEqual(9, result[0].Data.Version);
            Assert.AreEqual("testVM", result[0].Data.DisplayName);
            Assert.AreEqual(ReservationTerm.P1Y, result[0].Data.Term);
            Assert.AreEqual(ReservationProvisioningState.Succeeded, result[0].Data.ProvisioningState);
            Assert.IsNotNull(result[0].Data.Reservations);
            Assert.AreEqual(1, result[0].Data.Reservations.Count);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/c848cae0-7ade-43c8-a42c-52cc53413a72/reservations/34a9427a-0966-4186-86dd-bbcf720913c0", result[0].Data.Reservations[0].Id.ToString());
            Assert.AreEqual(1, result[0].Data.OriginalQuantity);
            Assert.AreEqual(ReservationBillingPlan.Upfront, result[0].Data.BillingPlan);
        }
    }
}
