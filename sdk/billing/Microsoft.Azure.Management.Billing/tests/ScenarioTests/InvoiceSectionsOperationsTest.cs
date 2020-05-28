// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Billing.Tests.Helpers;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Management.Billing.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;

namespace Billing.Tests.ScenarioTests
{
    public class InvoiceSectionsOperationsTest : TestBase
    {
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";
        private const string InvoiceSectionDisplayName = "Canary Test EA Transition 2";
        private const string InvoiceSectionName = "ICYS-ZE5B-PJA-PGB";
        private const string NewInvoiceSectionDisplayName = "SDK Test";
        
        [Fact]
        public void GetInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the invoice section
                var invoiceSection = billingMgmtClient.InvoiceSections.Get(BillingAccountName, BillingProfileName, InvoiceSectionName);

                // Verify the response
                Assert.NotNull(invoiceSection);
                Assert.Equal(InvoiceSectionDisplayName, invoiceSection.DisplayName);
            }
        }

        [Fact]
        public void ListInvoiceSectionsByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // List the invoice sections
                var invoiceSections = billingMgmtClient.InvoiceSections.ListByBillingProfile(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(invoiceSections);
                Assert.Equal(7, invoiceSections.Count());
                var invoiceSection = Assert.Single(invoiceSections.Where(i => i.Name == InvoiceSectionName));
                Assert.Equal(InvoiceSectionDisplayName, invoiceSection.DisplayName);
            }
        }
    }
}
