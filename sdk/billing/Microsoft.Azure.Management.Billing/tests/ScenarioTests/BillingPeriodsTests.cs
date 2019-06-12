// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Billing.Tests.Helpers;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Management.Billing.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;

namespace Billing.Tests.ScenarioTests
{
    public class BillingPeriodsTests : TestBase
    {
        const string RangeFilter = "billingPeriodEndDate gt 2017-01-31";
        const string BillingPeriodName = "201705-1";

        [Fact]
        public void ListBillingPeriodsTest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var billingPeriods = billingMgmtClient.BillingPeriods.List();
                Assert.NotNull(billingPeriods);
                Assert.True(billingPeriods.Any());
            }
        }

        [Fact]
        public void ListBillingPeriodsWithQueryParametersTest()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var billingPeriods = billingMgmtClient.BillingPeriods.List(RangeFilter, null, 1);
                Assert.NotNull(billingPeriods);
                Assert.Single(billingPeriods);
                var billingPeriod = billingPeriods.First();
                Assert.True(billingPeriod.BillingPeriodStartDate.Value <= billingPeriod.BillingPeriodEndDate.Value);
                Assert.NotNull(billingPeriod.Name);
            }
        }

        [Fact]
        public void GetBillingPeriodWithName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var billingPeriod = billingMgmtClient.BillingPeriods.Get(BillingPeriodName);
                Assert.NotNull(billingPeriod);
                Assert.Equal(BillingPeriodName, billingPeriod.Name);
                Assert.True(billingPeriod.BillingPeriodStartDate.Value <= billingPeriod.BillingPeriodEndDate.Value);
                Assert.NotNull(billingPeriod.Name);
                Assert.NotNull(billingPeriod.InvoiceIds);
                Assert.Equal(1, billingPeriod.InvoiceIds.Count);
            }
        }

        [Fact]
        public void GetBillingPeriodsNoResult()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            string rangeFilter = "billingPeriodEndDate lt 2017-01-01";
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                try
                {
                    var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                    billingMgmtClient.BillingPeriods.List(rangeFilter, null, 1);
                    Assert.False(true, "ErrorResponseException should have been thrown");
                }
                catch (ErrorResponseException e)
                {
                    Assert.NotNull(e.Body);
                    Assert.NotNull(e.Body.Error);
                    Assert.Equal("ResourceNotFound", e.Body.Error.Code);
                    Assert.False(string.IsNullOrWhiteSpace(e.Body.Error.Message));
                }
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            System.Type something = typeof(Billing.Tests.ScenarioTests.BillingPeriodsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }

    }
}