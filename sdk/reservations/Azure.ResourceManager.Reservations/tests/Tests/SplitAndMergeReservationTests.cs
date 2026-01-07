// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Reservations.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Reservations.Tests
{
    public class SplitAndMergeReservationTests : ReservationsManagementClientBase
    {
        private TenantResource Tenant { get; set; }
        private ReservationOrderCollection Collection { get; set; }
        private const string ReservationOrderId = "8c8a563e-a762-4872-a3ea-4d6bfd9efdc0";
        public SplitAndMergeReservationTests(bool isAsync) : base(isAsync)
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
        public async Task TestSplitReservationOrder()
        {
            var response = await Collection.GetAsync(Guid.Parse(ReservationOrderId));

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.IsNotNull(response.Value.Data.Reservations);
            Assert.That(response.Value.Data.Reservations.Count, Is.EqualTo(1));

            var fullyQualifiedId = response.Value.Data.Reservations[0].Id.ToString();
            var reservationId = fullyQualifiedId.Substring(fullyQualifiedId.LastIndexOf("/") + 1);
            var reservationResponse = await response.Value.GetReservationDetails().GetAsync(Guid.Parse(reservationId));
            var reservation = reservationResponse.Value;

            Assert.IsNotNull(reservation.Data);
            Assert.IsNotNull(reservation.Data.Properties);
            Assert.IsNotNull(reservation.Data.Properties.Quantity);
            Assert.Greater(reservation.Data.Properties.Quantity, 1);

            var splitContent = new SplitContent
            {
                ReservationId = new ResourceIdentifier(fullyQualifiedId)
            };
            splitContent.Quantities.Add(1);
            splitContent.Quantities.Add((int)reservation.Data.Properties.Quantity - 1);

            var splitResponse = await response.Value.SplitReservationAsync(WaitUntil.Completed, splitContent);

            Assert.IsNotNull(splitResponse.Value);
            Assert.That(splitResponse.Value.Count, Is.EqualTo(3));
            Assert.That(splitResponse.Value[0].Properties.Quantity, Is.EqualTo(1));
            Assert.That(splitResponse.Value[0].Properties.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Succeeded));
            Assert.That(splitResponse.Value[1].Properties.Quantity, Is.EqualTo((int)reservation.Data.Properties.Quantity - 1));
            Assert.That(splitResponse.Value[1].Properties.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Succeeded));
            Assert.That(splitResponse.Value[2].Properties.Quantity, Is.EqualTo((int)reservation.Data.Properties.Quantity));
            Assert.That(splitResponse.Value[2].Properties.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Cancelled));
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMergeReservationOrder()
        {
            var response = await Collection.GetAsync(Guid.Parse(ReservationOrderId));

            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.IsNotNull(response.Value.Data.Reservations);

            var fullyQualifiedId1 = response.Value.Data.Reservations[0].Id.ToString();

            AsyncPageable<ReservationDetailResource> reservationResponse = response.Value.GetReservationDetails().GetAllAsync();
            List<ReservationDetailResource> reservationResources = await reservationResponse.ToEnumerableAsync();

            Assert.That(reservationResources.Count, Is.EqualTo(3));

            // Find the two sub RIs
            List<ReservationDetailResource> subRIs = reservationResources.FindAll(i => i.Data.Properties.ProvisioningState == ReservationProvisioningState.Succeeded);
            var mergeContent = new MergeContent();
            foreach (var ri in subRIs)
            {
                mergeContent.Sources.Add(ri.Id.ToString());
            }
            var mergeResponse = await response.Value.MergeReservationAsync(WaitUntil.Completed, mergeContent);

            Assert.IsNotNull(mergeResponse.Value);
            Assert.That(mergeResponse.Value.Count, Is.EqualTo(3));
            Assert.That(mergeResponse.Value[0].Properties.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Cancelled));
            Assert.That(mergeResponse.Value[1].Properties.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Cancelled));
            Assert.That(mergeResponse.Value[2].Properties.Quantity, Is.EqualTo(mergeResponse.Value[1].Properties.Quantity + mergeResponse.Value[0].Properties.Quantity));
            Assert.That(mergeResponse.Value[2].Properties.ProvisioningState, Is.EqualTo(ReservationProvisioningState.Succeeded));
        }
    }
}
