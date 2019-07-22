// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Reservations.Tests.Helpers;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Reservations.Tests.ScenarioTests
{
    public class ReservationOrderTests : ReservationsTestBase
    {
        [Fact]
        public void TestReservationOrderOperations()
        {
            var reservationOrder = PurchaseReservationOrder();
            string reservationOrderId = ExtractIdsFromOrder(reservationOrder).Item1;

            TestGetReservationOrder(reservationOrderId);
            TestListReservationOrders();
        }

        private void TestGetReservationOrder(string reservationOrderId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservationOrder = reservationsClient.ReservationOrder.Get(reservationOrderId);
                ValidateReservationOrder(reservationOrder);
            }
        }

        private void TestListReservationOrders()
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
    }
}