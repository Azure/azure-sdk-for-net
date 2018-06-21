// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Reservations.Tests.Helpers;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;
using System.Collections.Generic;

namespace Reservations.Tests.ScenarioTests
{
    public class ReservationOrderTests : TestBase
    {
        string ReservationOrderId = Common.ReservationOrderId;

        internal static void ValidateReservationOrder(ReservationOrderResponse ReservationOrder)
        {
            Assert.NotNull(ReservationOrder);
            Assert.NotNull(ReservationOrder.Etag);
            Assert.NotNull(ReservationOrder.Id);
            Assert.NotNull(ReservationOrder.Name);
            Assert.NotNull(ReservationOrder.Type);
        }

        [Fact]
        public void TestGetReservationOrder()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservationOrder = reservationsClient.ReservationOrder.Get(ReservationOrderId);
                ValidateReservationOrder(reservationOrder);
            }
        }

        [Fact]
        public void TestListReservationOrders()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservationOrderList = reservationsClient.ReservationOrder.List();
                var enumerator = reservationOrderList.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    ValidateReservationOrder(enumerator.Current);
                }
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(Reservations.Tests.ScenarioTests.ReservationOrderTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}