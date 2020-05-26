// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Consumption.Tests.Helpers;
using Microsoft.Azure.Management.Consumption;
using Microsoft.Azure.Management.Consumption.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Net;
using Xunit;

namespace Consumption.Tests.ScenarioTests
{
    public class ReservationSummariesTests : TestBase
    {
        protected const string reservationOrderId = "ca69259e-bd4f-45c3-bf28-3f353f9cce9b";
        protected const string reservationId = "f37f4b70-52ba-4344-a8bd-28abfd21d640";

        [Fact]
        public void ListReservationSummariesMonthlyWithReservationOrderIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservationSummariesMonthly = consumptionMgmtClient.ReservationsSummaries.ListByReservationOrder(reservationOrderId, grain: "monthly");

                Assert.NotNull(reservationSummariesMonthly);
                Assert.True(reservationSummariesMonthly.Any());
                foreach (var item in reservationSummariesMonthly)
                {
                    ValidateProperties(item);
                }
            }
        }

        [Fact]
        public void ListReservationSummariesMonthlyWithReservationOrderIdAndReservationIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservationSummariesMonthly = consumptionMgmtClient.ReservationsSummaries.ListByReservationOrderAndReservation(reservationOrderId, reservationId, grain: "monthly");

                Assert.NotNull(reservationSummariesMonthly);
                Assert.True(reservationSummariesMonthly.Any());
                foreach (var item in reservationSummariesMonthly)
                {
                    ValidateProperties(item);
                }
            }
        }

        [Fact]
        public void ListReservationSummariesDailyWithReservationOrderIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var startEndDateFilter = "properties/UsageDate ge 2017-10-01 AND properties/UsageDate le 2017-12-07";
                var reservationSummariesDaily = consumptionMgmtClient.ReservationsSummaries.ListByReservationOrder(reservationOrderId, grain: "daily",filter: startEndDateFilter);

                Assert.NotNull(reservationSummariesDaily);
                Assert.True(reservationSummariesDaily.Any());
                foreach (var item in reservationSummariesDaily)
                {
                    ValidateProperties(item);
                }
            }
        }

        [Fact]
        public void ListReservationSummariesDailyWithReservationOrderIdAndReservationIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var startEndDateFilter = "properties/UsageDate ge 2017-10-01 AND properties/UsageDate le 2017-12-07";
                var reservationSummariesDaily = consumptionMgmtClient.ReservationsSummaries.ListByReservationOrderAndReservation(reservationOrderId, reservationId, grain: "daily", filter: startEndDateFilter);

                Assert.NotNull(reservationSummariesDaily);
                Assert.True(reservationSummariesDaily.Any());
                foreach (var item in reservationSummariesDaily)
                {
                    ValidateProperties(item);
                }
            }
        }

        private static void ValidateProperties(ReservationSummary item)
        {
            Assert.NotNull(item);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Type);
            Assert.NotNull(item.ReservationOrderId);
            Assert.NotNull(item.ReservationId);
            Assert.NotNull(item.SkuName);
            Assert.NotNull(item.ReservedHours);
            Assert.NotNull(item.UsageDate);
            Assert.NotNull(item.UsedHours);
            Assert.NotNull(item.MaxUtilizationPercentage);
            Assert.NotNull(item.MinUtilizationPercentage);
            Assert.NotNull(item.AvgUtilizationPercentage);
        }
    }
}

