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
            Assert.That(reservationResources.Count, Is.EqualTo(1));

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
            Assert.That(reservationResources.Count, Is.EqualTo(53));

            var reservation = reservationResources[0];
            Assert.IsNotNull(reservation);
            Assert.IsNotNull(reservation.Data);
            Assert.That(reservation.Data.Id.ToString(), Is.EqualTo("/providers/microsoft.capacity/reservationOrders/5e500b18-4fb6-4a63-b6d8-8469a09c5e60/reservations/48f6eeec-cf66-4a23-a4be-81d4d7000beb"));
            Assert.That(reservation.Data.ResourceType.ToString(), Is.EqualTo("microsoft.capacity/reservationOrders/reservations"));
            Assert.That(reservation.Data.Name, Is.EqualTo("48f6eeec-cf66-4a23-a4be-81d4d7000beb"));
            Assert.IsNotNull(reservation.Data.Properties);
            Assert.That(reservation.Data.Properties.AppliedScopeType, Is.EqualTo(AppliedScopeType.Shared));
            Assert.That(reservation.Data.Properties.Quantity, Is.EqualTo(3));
            Assert.That(reservation.Data.Properties.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Expired));
            Assert.That(reservation.Data.Properties.DisplayName, Is.EqualTo("testVM"));
            Assert.That(reservation.Data.Properties.ReservedResourceType, Is.EqualTo(ReservedResourceType.VirtualMachines));
            Assert.That(reservation.Data.Properties.IsRenewEnabled, Is.EqualTo(false));
            Assert.That(reservation.Data.Properties.Term, Is.EqualTo(ReservationTerm.P1Y));
            Assert.That(reservation.Data.Properties.IsArchived, Is.EqualTo(false));
        }

        private void TestReservationReponse(ReservationDetailData responseData)
        {
            Assert.IsNotNull(responseData);
            Assert.That(responseData.Id.ToString(), Is.EqualTo("/providers/microsoft.capacity/reservationOrders/8d233700-d9f3-4021-aba1-f9350f3ac0dc/reservations/ec1a9023-ec6b-44a7-8a49-1402bc2d766b"));
            Assert.That(responseData.ResourceType.ToString(), Is.EqualTo("microsoft.capacity/reservationOrders/reservations"));
            Assert.That(responseData.Name, Is.EqualTo("ec1a9023-ec6b-44a7-8a49-1402bc2d766b"));
            Assert.That(responseData.Version, Is.EqualTo(10));
            Assert.IsNotNull(responseData.Properties);
            Assert.That(responseData.Properties.AppliedScopeType, Is.EqualTo(AppliedScopeType.Shared));
            Assert.That(responseData.Properties.Quantity, Is.EqualTo(3));
            Assert.That(responseData.Properties.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Expired));
            Assert.That(responseData.Properties.DisplayName, Is.EqualTo("testingCreateTipVM"));
            Assert.That(responseData.Properties.ReservedResourceType, Is.EqualTo(ReservedResourceType.VirtualMachines));
            Assert.That(responseData.Properties.InstanceFlexibility, Is.EqualTo(InstanceFlexibility.On));
            Assert.That(responseData.Properties.SkuDescription, Is.EqualTo("Reserved VM Instance, Standard_B1ls, EU West, 1 Year"));
            Assert.That(responseData.Properties.IsRenewEnabled, Is.EqualTo(false));
            Assert.That(responseData.Properties.Term, Is.EqualTo(ReservationTerm.P1Y));
            Assert.That(responseData.Properties.BillingPlan, Is.EqualTo(ReservationBillingPlan.Monthly));
            Assert.That(responseData.Properties.BillingScopeId.ToString(), Is.EqualTo("/subscriptions/aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"));
            Assert.That(responseData.Properties.IsArchived, Is.EqualTo(false));
        }

        private void TestReservationOrderReponse(Response<ReservationOrderResource> response)
        {
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.IsNotNull(response.Value.Data.Reservations);
            Assert.That(response.Value.Data.Reservations.Count, Is.EqualTo(1));
        }
    }
}
