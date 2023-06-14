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
            var response = await Collection.GetAsync(Guid.Parse("8d233700-d9f3-4021-aba1-f9350f3ac0dc"));
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
            var response = await Collection.GetAsync(Guid.Parse("8d233700-d9f3-4021-aba1-f9350f3ac0dc"));
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
            Assert.AreEqual(53, reservationResources.Count);

            var reservation = reservationResources[0];
            Assert.IsNotNull(reservation);
            Assert.IsNotNull(reservation.Data);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/5e500b18-4fb6-4a63-b6d8-8469a09c5e60/reservations/48f6eeec-cf66-4a23-a4be-81d4d7000beb", reservation.Data.Id.ToString());
            Assert.AreEqual("microsoft.capacity/reservationOrders/reservations", reservation.Data.ResourceType.ToString());
            Assert.AreEqual("48f6eeec-cf66-4a23-a4be-81d4d7000beb", reservation.Data.Name);
            Assert.IsNotNull(reservation.Data.Properties);
            Assert.AreEqual(AppliedScopeType.Shared, reservation.Data.Properties.AppliedScopeType);
            Assert.AreEqual(3, reservation.Data.Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Expired, reservation.Data.Properties.ProvisioningState);
            Assert.AreEqual("testVM", reservation.Data.Properties.DisplayName);
            Assert.AreEqual(ReservedResourceType.VirtualMachines, reservation.Data.Properties.ReservedResourceType);
            Assert.AreEqual(false, reservation.Data.Properties.IsRenewEnabled);
            Assert.AreEqual(ReservationTerm.P1Y, reservation.Data.Properties.Term);
            Assert.AreEqual(false, reservation.Data.Properties.IsArchived);
        }

        private void TestReservationReponse(ReservationDetailData responseData)
        {
            Assert.IsNotNull(responseData);
            Assert.AreEqual("/providers/microsoft.capacity/reservationOrders/8d233700-d9f3-4021-aba1-f9350f3ac0dc/reservations/ec1a9023-ec6b-44a7-8a49-1402bc2d766b", responseData.Id.ToString());
            Assert.AreEqual("microsoft.capacity/reservationOrders/reservations", responseData.ResourceType.ToString());
            Assert.AreEqual("ec1a9023-ec6b-44a7-8a49-1402bc2d766b", responseData.Name);
            Assert.AreEqual(10, responseData.Version);
            Assert.IsNotNull(responseData.Properties);
            Assert.AreEqual(AppliedScopeType.Shared, responseData.Properties.AppliedScopeType);
            Assert.AreEqual(3, responseData.Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Expired, responseData.Properties.ProvisioningState);
            Assert.AreEqual("testingCreateTipVM", responseData.Properties.DisplayName);
            Assert.AreEqual(ReservedResourceType.VirtualMachines, responseData.Properties.ReservedResourceType);
            Assert.AreEqual(InstanceFlexibility.On, responseData.Properties.InstanceFlexibility);
            Assert.AreEqual("Reserved VM Instance, Standard_B1ls, EU West, 1 Year", responseData.Properties.SkuDescription);
            Assert.AreEqual(false, responseData.Properties.IsRenewEnabled);
            Assert.AreEqual(ReservationTerm.P1Y, responseData.Properties.Term);
            Assert.AreEqual(ReservationBillingPlan.Monthly, responseData.Properties.BillingPlan);
            Assert.AreEqual("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee", responseData.Properties.BillingScopeId.ToString());
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
