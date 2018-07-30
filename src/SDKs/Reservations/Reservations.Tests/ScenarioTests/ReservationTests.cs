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
    public class ReservationTests : TestBase
    {
        
        string ReservationOrderId = Common.ReservationOrderId;
        string ReservationId = Common.ReservationId;

        internal void ValidateReservation(ReservationResponse Reservation)
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

        [Fact]
        public void TestSplitAndMerge()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(ReservationOrderId);
                var enumerator1 = reservations.GetEnumerator();
                ReservationResponse validReservation = null;
                while (enumerator1.MoveNext())
                {
                    var currentReservation = enumerator1.Current;
                    if (String.Equals(currentReservation.Properties.ProvisioningState, "Succeeded"))
                    {
                        validReservation = currentReservation;
                        break;
                    }
                }
                Assert.NotNull(validReservation);

                ReservationId = validReservation.Id.Split('/')[6];

                // Begin split test
                SplitRequest Split = new SplitRequest(
                        new List<int?>() { 1, 1 },
                        CreateResourceId(ReservationOrderId, ReservationId)
                );
                var splitResponse = reservationsClient.Reservation.Split(ReservationOrderId, Split);
                Assert.NotNull(splitResponse);
                Assert.True(splitResponse.Any());

                var enumerator2 = splitResponse.GetEnumerator();
                ReservationResponse splitReservation1 = null;
                ReservationResponse splitReservation2 = null;
                while (enumerator2.MoveNext())
                {
                    var currentReservation = enumerator2.Current;
                    if (String.Equals(currentReservation.Properties.ProvisioningState, "Succeeded"))
                    {
                        if (splitReservation1 == null)
                        {
                            splitReservation1 = currentReservation;
                        }

                        else
                        {
                            splitReservation2 = currentReservation;
                        }
                    }
                }

                var splitReservationId1 = splitReservation1.Id.Split('/')[6];
                var splitReservationId2 = splitReservation2.Id.Split('/')[6];

                // Begin merge test
                MergeRequest Merge = new MergeRequest(
                        new List<string>()
                        {
                            CreateResourceId(ReservationOrderId, splitReservationId1),
                            CreateResourceId(ReservationOrderId, splitReservationId2)
                        }
                );
                var mergeResponse = reservationsClient.Reservation.Merge(ReservationOrderId, Merge);
                var enumerator3 = splitResponse.GetEnumerator();

                ReservationResponse mergedReservation = null;
                while (enumerator3.MoveNext())
                {
                    var currentReservation = enumerator3.Current;
                    if (String.Equals(currentReservation.Properties.ProvisioningState, "Succeeded"))
                    {
                        mergedReservation = currentReservation;
                    }
                }

                Assert.NotNull(mergedReservation);
                ValidateReservation(mergedReservation);
                ReservationId = mergedReservation.Id.Split('/')[6];

            }
        }
        
        [Fact]
        public void TestGetReservation()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservation = reservationsClient.Reservation.Get(ReservationId, ReservationOrderId);
                ValidateReservation(reservation);
            }
        }

        [Fact]
        public void TestUpdateReservationToShared()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(ReservationOrderId);
                var enumerator1 = reservations.GetEnumerator();
                ReservationResponse validReservation = null;
                while (enumerator1.MoveNext())
                {
                    var currentReservation = enumerator1.Current;
                    if (String.Equals(currentReservation.Properties.ProvisioningState, "Succeeded"))
                    {
                        validReservation = currentReservation;
                        break;
                    }
                }
                Assert.NotNull(validReservation);

                ReservationId = validReservation.Id.Split('/')[6];
                Patch Patch = new Patch(AppliedScopeType.Shared, null, InstanceFlexibility.On);
                var reservation = reservationsClient.Reservation.Update(ReservationOrderId, ReservationId, Patch);
                ValidateReservation(reservation);
            }
        }

        [Fact]
        public void TestUpdateReservationToSingle()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(ReservationOrderId);
                var enumerator1 = reservations.GetEnumerator();
                ReservationResponse validReservation = null;
                while (enumerator1.MoveNext())
                {
                    var currentReservation = enumerator1.Current;
                    if (String.Equals(currentReservation.Properties.ProvisioningState, "Succeeded"))
                    {
                        validReservation = currentReservation;
                        break;
                    }
                }
                Assert.NotNull(validReservation);

                ReservationId = validReservation.Id.Split('/')[6];
                Patch Patch = new Patch(AppliedScopeType.Single, new List<string>() { $"/subscriptions/{Common.SubscriptionId}" }, InstanceFlexibility.On);
                var reservation = reservationsClient.Reservation.Update(ReservationOrderId, ReservationId, Patch);
                ValidateReservation(reservation);
            }
        }

        [Fact]
        public void TestListReservations()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var ReservationList = reservationsClient.Reservation.List(ReservationOrderId);
                Assert.NotNull(ReservationList);
                Assert.True(ReservationList.Any());
                var enumerator = ReservationList.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    ValidateReservation(enumerator.Current);
                }
            }
        }

        [Fact]
        public void TestListReservationRevisions()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var revisions = reservationsClient.Reservation.ListRevisions(ReservationId, ReservationOrderId);
                Assert.NotNull(revisions);
                Assert.True(revisions.Any());
                var enumerator = revisions.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    ValidateReservation(enumerator.Current);
                }
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(Reservations.Tests.ScenarioTests.ReservationTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }

        private string CreateResourceId(string ReservationOrderId, string ReservationId)
        {
            return string.Format("/providers/Microsoft.Capacity/reservationOrders/{0}/reservations/{1}", ReservationOrderId, ReservationId);
        }
    }
}