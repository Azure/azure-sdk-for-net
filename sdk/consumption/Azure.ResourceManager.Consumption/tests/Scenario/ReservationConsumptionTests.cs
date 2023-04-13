// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Consumption.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Consumption.Tests
{
    internal class ReservationConsumptionTests : ConsumptionManagementTestBase
    {
        protected ResourceIdentifier _reservationOrderId;
        protected ResourceIdentifier _reservationId;
        private const string _filter = "properties/usageDate ge 2023-04-01 AND properties/usageDate le 2023-12-01";

        public ReservationConsumptionTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp()
        {
            _reservationId = new ResourceIdentifier("<reservation-id>");
            _reservationOrderId = new ResourceIdentifier("<reservation-id>");
        }

        [RecordedTest]
        [Ignore("Current tenants have not reservation resource")]
        public async Task GetReservationDetails()
        {
            ReservationConsumptionResource reservation = Client.GetReservationConsumptionResource(_reservationId);
            var list = await reservation.GetReservationDetailsAsync(_filter).ToEnumerableAsync();
            ValidateConsumptionReservationDetail(list.FirstOrDefault());
        }

        [RecordedTest]
        [Ignore("Current tenants have not reservation resource")]
        public async Task GetReservationSummaries()
        {
            ReservationConsumptionResource reservation = Client.GetReservationConsumptionResource(_reservationId);
            var monthlyList = await reservation.GetReservationSummariesAsync(ReservationSummaryDataGrain.MonthlyGrain, _filter).ToEnumerableAsync();
            ValidateConsumptionReservationSummary(monthlyList.FirstOrDefault());

            var daylyList = await reservation.GetReservationSummariesAsync(ReservationSummaryDataGrain.DailyGrain, _filter).ToEnumerableAsync();
            ValidateConsumptionReservationSummary(daylyList.FirstOrDefault());
        }

        private void ValidateConsumptionReservationDetail(ConsumptionReservationDetail detail)
        {
            Assert.IsNotNull(detail);
            Assert.AreEqual(_reservationId, detail.ReservationId);
            Assert.AreEqual(_reservationOrderId, detail.ReservationOrderId);
        }

        private void ValidateConsumptionReservationSummary(ConsumptionReservationSummary detail)
        {
            Assert.IsNotNull(detail);
            Assert.AreEqual(_reservationId, detail.ReservationId);
            Assert.AreEqual(_reservationOrderId, detail.ReservationOrderId);
            Assert.IsNotEmpty(detail.SkuName);
            Assert.IsNotEmpty(detail.Kind);
        }
    }
}
