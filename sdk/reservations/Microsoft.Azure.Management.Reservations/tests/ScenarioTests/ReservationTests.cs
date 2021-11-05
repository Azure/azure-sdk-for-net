// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Reservations;
using Microsoft.Azure.Management.Reservations.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Reservations.Tests.Helpers;
using Xunit;

namespace Reservations.Tests.ScenarioTests
{
    public class ReservationTests : ReservationsTestBase
    {

        [Fact]
        public void TestReservationOperations()
        {
            var reservationOrder = PurchaseReservationOrder();

            var idTuple = ExtractIdsFromOrder(reservationOrder);
            string reservationOrderId = idTuple.Item1;
            string reservationId = idTuple.Item2;

            TestGetReservation(reservationOrderId, reservationId);
            TestGetAvailableScopes(reservationOrderId, reservationId);
            TestUpdateReservationToShared(reservationOrderId, reservationId);
            TestUpdateReservationToSingle(reservationOrderId, reservationId);
            TestUpdateRenewalOn(reservationOrderId, reservationId);
            TestUpdateRenewalOff(reservationOrderId, reservationId);
            TestUpdateRenewalProperties(reservationOrderId, reservationId);

            TestSplitAndMerge(reservationOrderId);
            TestListReservations(reservationOrderId);
            TestListReservationRevisions(reservationOrderId, reservationId);
        }

        private void TestSplitAndMerge(string reservationOrderId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(reservationOrderId);
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

                var reservationId = validReservation.Id.Split('/')[6];

                // Begin split test
                SplitRequest Split = new SplitRequest(
                        new List<int?>() { 1, 2 },
                        CreateResourceId(reservationOrderId, reservationId)
                );
                var splitResponse = reservationsClient.Reservation.Split(reservationOrderId, Split);
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
                            CreateResourceId(reservationOrderId, splitReservationId1),
                            CreateResourceId(reservationOrderId, splitReservationId2)
                        }
                );
                var mergeResponse = reservationsClient.Reservation.Merge(reservationOrderId, Merge);
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
            }
        }
        
        private void TestGetReservation(string reservationOrderId, string reservationId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservation = reservationsClient.Reservation.Get(reservationId, reservationOrderId);
                ValidateReservation(reservation);
            }
        }

        private void TestGetAvailableScopes(string reservationOrderId, string reservationId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var scopeList = new List<string>();
                scopeList.Add($"/subscriptions/{Common.SubscriptionId}");
                var requestProperties = new AvailableScopeRequestProperties(scopeList);
                var body = new AvailableScopeRequest(requestProperties);
                var res = reservationsClient.Reservation.AvailableScopes(reservationOrderId, reservationId, body);
            }
        }

        private void TestUpdateReservationToShared(string reservationOrderId, string reservationId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(reservationOrderId);
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

                reservationId = validReservation.Id.Split('/')[6];
                Patch Patch = new Patch(AppliedScopeType.Shared, null, InstanceFlexibility.On);
                var reservation = reservationsClient.Reservation.Update(reservationOrderId, reservationId, Patch);
                ValidateReservation(reservation);
            }
        }

        private void TestUpdateReservationToSingle(string reservationOrderId, string reservationId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(reservationOrderId);
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

                reservationId = validReservation.Id.Split('/')[6];
                Patch Patch = new Patch(AppliedScopeType.Single, new List<string>() { $"/subscriptions/{Common.SubscriptionId}" }, InstanceFlexibility.On);
                var reservation = reservationsClient.Reservation.Update(reservationOrderId, reservationId, Patch);
                ValidateReservation(reservation);
            }
        }

        private void TestUpdateRenewalOn(string reservationOrderId, string reservationId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(reservationOrderId);
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

                reservationId = validReservation.Id.Split('/')[6];
                Patch Patch = new Patch(renew: true);
                var reservation = reservationsClient.Reservation.Update(reservationOrderId, reservationId, Patch);
                ValidateReservation(reservation);
                Assert.True(reservation.Properties.Renew);
            }
        }

        private void TestUpdateRenewalOff(string reservationOrderId, string reservationId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(reservationOrderId);
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

                reservationId = validReservation.Id.Split('/')[6];
                Patch Patch = new Patch(renew: false);
                var reservation = reservationsClient.Reservation.Update(reservationOrderId, reservationId, Patch);
                ValidateReservation(reservation);
                Assert.False(reservation.Properties.Renew);
            }
        }

        private void TestUpdateRenewalProperties(string reservationOrderId, string reservationId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var reservations = reservationsClient.Reservation.List(reservationOrderId);
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

                reservationId = validReservation.Id.Split('/')[6];
                var renewProperties = new PatchPropertiesRenewProperties()
                {
                    PurchaseProperties = CreatePurchaseRequestBody()
                };
                Patch Patch = new Patch(renew: true, renewProperties: renewProperties);
                var reservation = reservationsClient.Reservation.Update(reservationOrderId, reservationId, Patch);
                var reservationWithRenewProperties = reservationsClient.Reservation.Get(reservationId, reservationOrderId, "renewProperties");
                ValidateReservation(reservationWithRenewProperties);
                Assert.True(reservationWithRenewProperties.Properties.Renew);
                Assert.NotNull(reservationWithRenewProperties.Properties.RenewProperties);
            }
        }

        private void TestListReservations(string reservationOrderId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var ReservationList = reservationsClient.Reservation.List(reservationOrderId);
                Assert.NotNull(ReservationList);
                Assert.True(ReservationList.Any());
                var enumerator = ReservationList.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    ValidateReservation(enumerator.Current);
                }
            }
        }

        private void TestListReservationRevisions(string reservationOrderId, string reservationId)
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var revisions = reservationsClient.Reservation.ListRevisions(reservationId, reservationOrderId);
                Assert.NotNull(revisions);
                Assert.True(revisions.Any());
                var enumerator = revisions.GetEnumerator();
                if (enumerator.MoveNext())
                {
                    ValidateReservation(enumerator.Current);
                }
            }
        }
    }
}
