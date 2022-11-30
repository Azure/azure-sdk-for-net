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
        private const string ReservationOrderId = "55940ea5-f1ab-4dc6-804e-44ffe25c6769";
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

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.IsNotNull(response.Value.Data.Reservations);
            Assert.AreEqual(1, response.Value.Data.Reservations.Count);

            var fullyQualifiedId = response.Value.Data.Reservations[0].Id.ToString();
            var reservationId = fullyQualifiedId.Substring(fullyQualifiedId.LastIndexOf("/") + 1);
            var reservationResponse = await response.Value.GetReservationDetails().GetAsync(Guid.Parse(reservationId));
            var reservation = reservationResponse.Value;

            Assert.IsNotNull(reservation.Data);
            Assert.IsNotNull(reservation.Data.Properties);
            Assert.IsNotNull(reservation.Data.Properties.Quantity);
            Assert.IsTrue(reservation.Data.Properties.Quantity > 1);

            var splitContent = new SplitContent
            {
                ReservationId = new ResourceIdentifier(fullyQualifiedId)
            };
            splitContent.Quantities.Add(1);
            splitContent.Quantities.Add((int)reservation.Data.Properties.Quantity - 1);

            var splitResponse = await response.Value.SplitReservationAsync(WaitUntil.Completed, splitContent);

            Assert.IsNotNull(splitResponse.Value);
            Assert.AreEqual(3, splitResponse.Value.Count);
            Assert.AreEqual(1, splitResponse.Value[0].Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Succeeded, splitResponse.Value[0].Properties.ProvisioningState);
            Assert.AreEqual(9, splitResponse.Value[1].Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Succeeded, splitResponse.Value[1].Properties.ProvisioningState);
            Assert.AreEqual(10, splitResponse.Value[2].Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Cancelled, splitResponse.Value[2].Properties.ProvisioningState);
        }

        [TestCase]
        [RecordedTest]
        public async Task TestMergeReservationOrder()
        {
            var response = await Collection.GetAsync(Guid.Parse(ReservationOrderId));

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Data);
            Assert.IsNotNull(response.Value.Data.Reservations);
            Assert.AreEqual(3, response.Value.Data.Reservations.Count);

            var fullyQualifiedId1 = response.Value.Data.Reservations[0].Id.ToString();

            AsyncPageable<ReservationDetailResource> reservationResponse = response.Value.GetReservationDetails().GetAllAsync();
            List<ReservationDetailResource> reservationResources = await reservationResponse.ToEnumerableAsync();

            Assert.AreEqual(3, reservationResources.Count);

            // Find the two sub RIs
            List<ReservationDetailResource> subRIs = reservationResources.FindAll(i => i.Data.Properties.ProvisioningState == ReservationProvisioningState.Succeeded);
            var mergeContent = new MergeContent();
            foreach (var ri in subRIs)
            {
                mergeContent.Sources.Add(ri.Id.ToString());
            }
            var mergeResponse = await response.Value.MergeReservationAsync(WaitUntil.Completed, mergeContent);

            Assert.IsNotNull(mergeResponse.Value);
            Assert.AreEqual(3, mergeResponse.Value.Count);
            Assert.AreEqual(1, mergeResponse.Value[0].Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Cancelled, mergeResponse.Value[0].Properties.ProvisioningState);
            Assert.AreEqual(9, mergeResponse.Value[1].Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Cancelled, mergeResponse.Value[1].Properties.ProvisioningState);
            Assert.AreEqual(10, mergeResponse.Value[2].Properties.Quantity);
            Assert.AreEqual(ReservationProvisioningState.Succeeded, mergeResponse.Value[2].Properties.ProvisioningState);
        }
    }
}
