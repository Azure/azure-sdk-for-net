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

            // Archving a `Cancelled` RI
            var cancelledReservation = reservationResources.Find(item => item.Data.Properties.ProvisioningState.Equals(ReservationProvisioningState.Cancelled));
            var response1 = await cancelledReservation.ArchiveAsync();
            Assert.AreEqual(200, response1.Status);

            // Unarchving
            var response2 = await cancelledReservation.UnarchiveAsync();
            Assert.AreEqual(200, response2.Status);

            // Archving a `Failed` RI
            var failedReservation = reservationResources.Find(item => item.Data.Properties.ProvisioningState.Equals(ReservationProvisioningState.Failed));
            var response3 = await failedReservation.ArchiveAsync();
            Assert.AreEqual(200, response3.Status);

            // Unarchving
            var response4 = await failedReservation.UnarchiveAsync();
            Assert.AreEqual(200, response4.Status);
        }
    }
}
