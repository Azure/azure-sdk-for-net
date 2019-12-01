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
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
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
                Assert.Equal(7, invoiceSections.Value.Count);
                var invoiceSection = Assert.Single(invoiceSections.Value.Where(i => i.Name == InvoiceSectionName));
                Assert.Equal(InvoiceSectionDisplayName, invoiceSection.DisplayName);
            }
        }
    }
}
