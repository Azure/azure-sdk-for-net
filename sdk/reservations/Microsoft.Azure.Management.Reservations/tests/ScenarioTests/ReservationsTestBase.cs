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
using System.Text.RegularExpressions;

namespace Reservations.Tests.ScenarioTests
{
    public class ReservationsTestBase : TestBase
    {
        protected string SubscriptionId = Common.SubscriptionId;

        protected static void ValidateReservationOrder(ReservationOrderResponse ReservationOrder)
        {
            Assert.NotNull(ReservationOrder);
            Assert.NotNull(ReservationOrder.Etag);
            Assert.NotNull(ReservationOrder.Id);
            Assert.NotNull(ReservationOrder.Name);
            Assert.NotNull(ReservationOrder.Type);
        }

        protected static void ValidateReservation(ReservationResponse Reservation)
        {
            Assert.NotNull(Reservation);
            Assert.NotNull(Reservation.Id);
            Assert.NotNull(Reservation.Etag);
            Assert.NotNull(Reservation.Name);
            Assert.NotNull(Reservation.Properties);
            Assert.NotNull(Reservation.Sku);
            Assert.NotNull(Reservation.Type);

            Assert.NotNull(Reservation.Properties.InstanceFlexibility);
            Assert.NotNull(Reservation.Properties.ReservedResourceType);
            Assert.NotNull(Reservation.Properties.SkuDescription);
        }

        private PurchaseRequest CreatePurchaseRequestBody()
        {
            return new PurchaseRequest
            {
                Sku = new SkuName { Name = "Standard_F1" },
                Location = "eastus",
                ReservedResourceType = "VirtualMachines",
                BillingScopeId = $"/subscriptions/{SubscriptionId}",
                Term = "P1Y",
                Quantity = 3,
                DisplayName = "TestPurchaseReservation",
                AppliedScopeType = "Single",
                AppliedScopes = new List<string> { $"/subscriptions/{SubscriptionId}" },
                ReservedResourceProperties =
                    new PurchaseRequestPropertiesReservedResourceProperties { InstanceFlexibility = "On" }
            };
        }

        protected ReservationOrderResponse PurchaseReservationOrder()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var calculateRequest = CreatePurchaseRequestBody();
                var calculateResponse = reservationsClient.ReservationOrder.Calculate(calculateRequest);

                var reservationOrderId = calculateResponse?.Properties?.ReservationOrderId;
                Assert.NotNull(reservationOrderId);

                var purchaseResponse = reservationsClient.ReservationOrder.Purchase(reservationOrderId, calculateRequest);
                ValidateReservationOrder(purchaseResponse);

                return purchaseResponse;
            }
        }

        protected Tuple<string,string> ExtractIdsFromOrder(ReservationOrderResponse order)
        {
            var reservationId = order.ReservationsProperty.First().Id;
            string reservationIdPattern = @"/providers/microsoft.capacity/reservationOrders/([\w-]+)/reservations/([\w-]+)";
            
            Match match = Regex.Match(reservationId, reservationIdPattern);
            return new Tuple<string, string>(match.Groups[1].Value, match.Groups[2].Value);
        }

        protected static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(Reservations.Tests.ScenarioTests.ReservationTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }

        protected string CreateResourceId(string ReservationOrderId, string ReservationId)
        {
            return string.Format("/providers/Microsoft.Capacity/reservationOrders/{0}/reservations/{1}", ReservationOrderId, ReservationId);
        }
    }
}