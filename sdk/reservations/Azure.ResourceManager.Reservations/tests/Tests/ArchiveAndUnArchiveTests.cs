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
    public class ArchiveAndUnArchiveTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }
        private ReservationOrderCollection Collection { get; set; }

        public ArchiveAndUnArchiveTests(bool isAsync) : base(isAsync)
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
        public async Task TestArchiveAndUnArchiveReservation()
        {
            AsyncPageable<ReservationDetailResource> reservationResponse = Tenant.GetReservationDetailsAsync();
            List<ReservationDetailResource> reservationResources = await reservationResponse.ToEnumerableAsync();

            // Archiving a 'Expired' RI
            var cancelledReservation = reservationResources.Find(item => item.Data.Properties.ProvisioningState.Equals(ReservationProvisioningState.Expired));
            var response1 = await cancelledReservation.ArchiveAsync();
            Assert.That(response1.Status, Is.EqualTo(200));

            // Unarchiving
            var response2 = await cancelledReservation.UnarchiveAsync();
            Assert.That(response2.Status, Is.EqualTo(200));

            // Archiving a 'Expired' RI
            var failedReservation = reservationResources.Find(item => item.Data.Properties.ProvisioningState.Equals(ReservationProvisioningState.Expired));
            var response3 = await failedReservation.ArchiveAsync();
            Assert.That(response3.Status, Is.EqualTo(200));

            // Unarchiving
            var response4 = await failedReservation.UnarchiveAsync();
            Assert.That(response4.Status, Is.EqualTo(200));
        }
    }
}
