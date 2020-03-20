// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Billing.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Billing.Tests.ScenarioTests
{
    public class BillingSubscriptionsOperationsTest : TestBase
    {
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        private const string BillingSubscriptionName = "8d974561-9387-46ad-8593-527f5b6bf775";
        private const string InvoiceSectionName = "LE7E-3FVV-PJA-PGB";

        [Fact]
        public void GetBillingSubscriptionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var billingSubscription = billingMgmtClient.BillingSubscriptions.Get(BillingAccountName, BillingProfileName, InvoiceSectionName, BillingSubscriptionName);

                // Verify the response
                Assert.NotNull(billingSubscription);
                Assert.Contains(BillingProfileName, billingSubscription.BillingProfileId);
                Assert.Contains(InvoiceSectionName, billingSubscription.InvoiceSectionId);
                Assert.Contains(BillingSubscriptionName, billingSubscription.Name);
            }
        }

        [Fact]
        public void ListBillingSubscriptionsByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var billingSubscriptions = billingMgmtClient.BillingSubscriptions.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(billingSubscriptions);
                Assert.True(billingSubscriptions.Any());
                Assert.Contains(billingSubscriptions, bs => bs.BillingProfileId.Contains(BillingProfileName));
                Assert.Contains(billingSubscriptions, bs => bs.InvoiceSectionId.Contains(InvoiceSectionName));
            }
        }

        [Fact]
        public void ListBillingSubscriptionsByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var billingSubscriptions = billingMgmtClient.BillingSubscriptions.ListByBillingProfile(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(billingSubscriptions);
                Assert.True(billingSubscriptions.Value.Any());
                Assert.Contains(billingSubscriptions.Value, bs => bs.BillingProfileId.Contains(BillingProfileName));
                Assert.Contains(billingSubscriptions.Value, bs => bs.InvoiceSectionId.Contains(InvoiceSectionName));
            }
        }

        [Fact]
        public void ListBillingSubscriptionsByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var billingSubscriptions = billingMgmtClient.BillingSubscriptions.ListByInvoiceSection(BillingAccountName, BillingProfileName, InvoiceSectionName);

                // Verify the response
                Assert.NotNull(billingSubscriptions);
                Assert.True(billingSubscriptions.Value.Any());
                Assert.Contains(billingSubscriptions.Value, bs => bs.BillingProfileId.Contains(BillingProfileName));
                Assert.Contains(billingSubscriptions.Value, bs => bs.InvoiceSectionId.Contains(InvoiceSectionName));
            }
        }
    }
}
