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
    public class GetReservationTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }
        private ReservationOrderCollection Collection { get; set; }

        public GetReservationTests(bool isAsync) : base(isAsync)
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
        public async Task TestGetSingleReservation()
        {
            var response = await Collection.GetAsync(Guid.Parse("545d132c-6066-47ad-9f39-e67e542caef2"));
            TestReservationOrderReponse(response);

            var fullyQualifiedId = response.Value.Data.Reservations[0].Id.ToString();
            var reservationId = fullyQualifiedId.Substring(fullyQualifiedId.LastIndexOf("/") + 1);
            var reservationResponse = await response.Value.GetReservationDetails().GetAsync(Guid.Parse(reservationId));
            var reservation = reservationResponse.Value;

            TestReservationReponse(reservation.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListReservations()
        {
            var response = await Collection.GetAsync(Guid.Parse("545d132c-6066-47ad-9f39-e67e542caef2"));
            TestReservationOrderReponse(response);

            var fullyQualifiedId = response.Value.Data.Reservations[0].Id.ToString();
            var reservationId = fullyQualifiedId.Substring(fullyQualifiedId.LastIndexOf("/"));
            AsyncPageable<ReservationDetailResource> reservationResponse = response.Value.GetReservationDetails().GetAllAsync();
            List<ReservationDetailResource> reservationResources = await reservationResponse.ToEnumerableAsync();

            Assert.IsNotNull(reservationResources);
            Assert.AreEqual(1, reservationResources.Count);

            var reservation = reservationResources[0];
            TestReservationReponse(reservation.Data);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestListAllReservations()
        {
            AsyncPageable<ReservationDetailResource> reservationResponse = Tenant.GetReservationDetailsAsync();
            List<ReservationDetailResource> reservationResources = await reservationResponse.ToEnumerableAsync();

            Assert.IsNotNull(reservationResources);
            Assert.AreEqual(21, reservationResources.Count);

            var reservation = reservationResources[0];

            Assert.IsNotNull(reservation);
            Assert.IsNotNull(reservation.Data);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/764dd4d6-926e-45c7-a9ce-4457f0fe497a/reservations/41728910-39bd-461e-bb94-bbf2176cbaed", reservation.Data.Id.ToString());
            Assert.AreEqual("Microsoft.Capacity/reservationOrders/reservations", reservation.Data.ResourceType.ToString());
            Assert.AreEqual("764dd4d6-926e-45c7-a9ce-4457f0fe497a/41728910-39bd-461e-bb94-bbf2176cbaed", reservation.Data.Name);
            Assert.IsNotNull(reservation.Data.Properties);
            Assert.AreEqual(AppliedScopeType.Shared, reservation.Data.Properties.AppliedScopeType);
            Assert.AreEqual(1, reservation.Data.Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Failed, reservation.Data.Properties.ProvisioningState);
            Assert.AreEqual("testVM", reservation.Data.Properties.DisplayName);
            Assert.AreEqual(ReservedResourceType.VirtualMachines, reservation.Data.Properties.ReservedResourceType);
            Assert.AreEqual(false, reservation.Data.Properties.IsRenewEnabled);
            Assert.AreEqual(ReservationTerm.P1Y, reservation.Data.Properties.Term);
            Assert.AreEqual(false, reservation.Data.Properties.IsArchived);
        }

        private void TestReservationReponse(ReservationDetailData responseData)
        {
            Assert.IsNotNull(responseData);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/545d132c-6066-47ad-9f39-e67e542caef2/reservations/c2e14316-531b-4c13-8fc4-f8e1857fb1d2", responseData.Id.ToString());
            Assert.AreEqual("Microsoft.Capacity/reservationOrders/reservations", responseData.ResourceType.ToString());
            Assert.AreEqual("545d132c-6066-47ad-9f39-e67e542caef2/c2e14316-531b-4c13-8fc4-f8e1857fb1d2", responseData.Name);
            Assert.AreEqual(9, responseData.Version);
            Assert.IsNotNull(responseData.Properties);
            Assert.AreEqual(AppliedScopeType.Single, responseData.Properties.AppliedScopeType);
            Assert.AreEqual(1, responseData.Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Succeeded, responseData.Properties.ProvisioningState);
            Assert.AreEqual("testVM", responseData.Properties.DisplayName);
            Assert.AreEqual(ReservedResourceType.VirtualMachines, responseData.Properties.ReservedResourceType);
            Assert.AreEqual(InstanceFlexibility.On, responseData.Properties.InstanceFlexibility);
            Assert.AreEqual("Reserved VM Instance, Standard_B1ls, US West, 1 Year", responseData.Properties.SkuDescription);
            Assert.AreEqual(false, responseData.Properties.IsRenewEnabled);
            Assert.AreEqual(ReservationTerm.P1Y, responseData.Properties.Term);
            Assert.AreEqual(ReservationBillingPlan.Upfront, responseData.Properties.BillingPlan);
            Assert.AreEqual("/subscriptions/6d5e2387-bdf5-4ca1-83db-795fd2398b93", responseData.Properties.BillingScopeId.ToString());
            Assert.AreEqual(false, responseData.Properties.IsArchived);
        }

        private void TestReservationOrderReponse(Response<ReservationOrderResource> response)
        {
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.IsNotNull(response.Value.Data.Reservations);
            Assert.AreEqual(1, response.Value.Data.Reservations.Count);
        }
    }
}
