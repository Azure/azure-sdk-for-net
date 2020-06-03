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
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";
        private const string BillingSubscriptionName = "0195fcc8-69cd-4440-852b-237bdae4e36c";
        private const string InvoiceSectionName = "CGPK-BEXW-PJA-TGB";

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
                
                // Set the subscription id.
                billingMgmtClient.SubscriptionId = BillingSubscriptionName;

                // Get the agreements
                var billingSubscription = billingMgmtClient.BillingSubscriptions.Get(BillingAccountName);

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
                Assert.True(billingSubscriptions.Any());
                Assert.Contains(billingSubscriptions, bs => bs.BillingProfileId.Contains(BillingProfileName));
                Assert.Contains(billingSubscriptions, bs => bs.InvoiceSectionId.Contains(InvoiceSectionName));
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
                Assert.True(billingSubscriptions.Any());
                Assert.Contains(billingSubscriptions, bs => bs.BillingProfileId.Contains(BillingProfileName));
                Assert.Contains(billingSubscriptions, bs => bs.InvoiceSectionId.Contains(InvoiceSectionName));
            }
        }
    }
}
