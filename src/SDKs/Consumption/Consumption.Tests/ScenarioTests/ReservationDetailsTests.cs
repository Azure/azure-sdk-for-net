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
    public class ReservationDetailsTests : TestBase
    {
        protected const string reservationOrderIdScope = "providers/Microsoft.Capacity/reservationorders/ca69259e-bd4f-45c3-bf28-3f353f9cce9b";
        protected const string reservationOrderIdWithReservationIdScope = "providers/Microsoft.Capacity/reservationorders/ca69259e-bd4f-45c3-bf28-3f353f9cce9b/reservations/f37f4b70-52ba-4344-a8bd-28abfd21d640";
        protected const string startEndDateFilter = "properties/UsageDate ge 2017-10-01 AND properties/UsageDate le 2017-12-07";
        [Fact]
        public void ListReservationDetailsWithReservationOrderIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
               
                var reservationDetails = consumptionMgmtClient.ReservationsDetails.List(reservationOrderIdScope, startEndDateFilter);

                Assert.NotNull(reservationDetails);
                Assert.True(reservationDetails.Any());
                foreach (var item in reservationDetails)
                {
                    ValidateProperties(item);
                }
            }
        }

        [Fact]
        public void ListReservationDetailsWithReservationOrderIdAndReservationIdTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var consumptionMgmtClient = ConsumptionTestUtilities.GetConsumptionManagementClient(
                    context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var reservationDetails = consumptionMgmtClient.ReservationsDetails.List(reservationOrderIdWithReservationIdScope, startEndDateFilter);

                Assert.NotNull(reservationDetails);
                Assert.True(reservationDetails.Any());
                foreach (var item in reservationDetails)
                {
                    ValidateProperties(item);
                }
            }
        }
        private static void ValidateProperties(
            ReservationDetails item,
            bool includeMeterDetails = false)
        {
            Assert.NotNull(item);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.Type);
            Assert.NotNull(item.ReservationOrderId);
            Assert.NotNull(item.ReservationId);
            Assert.NotNull(item.UsageDate);
            Assert.NotNull(item.SkuName);
            Assert.NotNull(item.InstanceId);
            Assert.NotNull(item.TotalReservedQuantity);
            Assert.NotNull(item.ReservedHours);
            Assert.NotNull(item.UsedHours);
          
        }
    }
}
