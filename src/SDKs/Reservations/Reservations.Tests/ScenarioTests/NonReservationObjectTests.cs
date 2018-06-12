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
    public class NonReservationObjectTests : TestBase
    {

        string SubscriptionId = Common.SubscriptionId;

        [Fact]
        public void TestGetCatalog()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var catalog = reservationsClient.GetCatalog(SubscriptionId, ReservedResourceType.VirtualMachines, "westus");
                Assert.True(catalog.All(x =>
                    x.ResourceType != null &&
                    x.Name != null &&
                    x.SkuProperties != null &&
                    x.Locations != null &&
                    x.Terms != null
                ));

                catalog = reservationsClient.GetCatalog(SubscriptionId, ReservedResourceType.SqlDatabases, "southeastasia");
                Assert.True(catalog.All(x =>
                    x.ResourceType != null &&
                    x.Name != null &&
                    x.SkuProperties != null &&
                    x.Locations != null &&
                    x.Terms != null
                ));

                catalog = reservationsClient.GetCatalog(SubscriptionId, ReservedResourceType.SuseLinux);
                Assert.True(catalog.All(x =>
                    x.ResourceType != null &&
                    x.Name != null &&
                    x.SkuProperties != null &&
                    x.Locations == null &&
                    x.Terms != null
                ));
            }
        }

        [Fact]
        public void TestGetAppliedReservations()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var appliedReservations = reservationsClient.GetAppliedReservationList(SubscriptionId);
                Assert.NotNull(appliedReservations.Id);
                Assert.NotNull(appliedReservations.Name);
                Assert.NotNull(appliedReservations.Type);
                string reservationOrderIdPattern = @"^\/providers\/Microsoft\.Capacity\/reservationorders\/[\w-]+$";
                Assert.True(appliedReservations.ReservationOrderIds.Value.All(x => 
                    x is string &&
                    Regex.Match(x, reservationOrderIdPattern).Success
                ));
            }
        }

            
        [Fact]
        public void TestListOperations()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var reservationsClient = ReservationsTestUtilities.GetAzureReservationAPIClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var operations = reservationsClient.Operation.List();
                Assert.NotNull(operations);
                Assert.True(operations.Any());
                var enumerator = operations.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    var operation = enumerator.Current;
                    Assert.NotNull(operation.Name);
                    Assert.NotNull(operation.Display.Provider);
                    Assert.NotNull(operation.Display.Resource);
                    Assert.NotNull(operation.Display.Operation);
                    Assert.NotNull(operation.Display.Description);
                }
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(Reservations.Tests.ScenarioTests.ReservationTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }

    }
}