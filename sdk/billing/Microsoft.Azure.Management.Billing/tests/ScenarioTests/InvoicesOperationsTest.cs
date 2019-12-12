// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Billing.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Management.Billing.Models;

namespace Billing.Tests.ScenarioTests
{
    public class InvoicesOperationsTest : TestBase
    {
        private static readonly DateTime DueDate = DateTime.Parse("11/15/2019");
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        private const string InvoiceNumber = "G000492901";
        private const string InvoiceStatus = "OverDue";

        [Fact]
        public void GetInvoiceByInvoiceNumberTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the invoice
                var invoice = billingMgmtClient.Invoices.Get(BillingAccountName, BillingProfileName, InvoiceNumber);

                // Verify the response
                Assert.NotNull(invoice);
                Assert.Contains(BillingProfileName, invoice.BillingProfileId);
                Assert.Equal(InvoiceNumber, invoice.Name);
                Assert.Equal(InvoiceStatus, invoice.Status);
                Assert.Equal(DueDate.Date, invoice.DueDate.Value.Date);
            }
        }

        [Fact]
        public void ListInvoicesByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the invoices
                var invoices = billingMgmtClient.Invoices.ListByBillingAccount(BillingAccountName, "2019-08-01", "2019-11-01");

                // Verify the response
                Assert.NotNull(invoices);
                var invoice = Assert.Single(invoices.Value);
                Assert.Contains(BillingProfileName, invoice.BillingProfileId);
                Assert.Equal(InvoiceNumber, invoice.Name);
                Assert.Equal(InvoiceStatus, invoice.Status);
                Assert.Equal(DueDate.Date, invoice.DueDate.Value.Date);
            }
        }

        [Fact]
        public void ListInvoicesByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the invoices
                var invoices = billingMgmtClient.Invoices.ListByBillingProfile(BillingAccountName, BillingProfileName, "2019-08-01", "2019-11-01");

                // Verify the response
                Assert.NotNull(invoices);
                var invoice = Assert.Single(invoices.Value);
                Assert.Contains(BillingProfileName, invoice.BillingProfileId);
                Assert.Equal(InvoiceNumber, invoice.Name);
                Assert.Equal(InvoiceStatus, invoice.Status);
                Assert.Equal(DueDate.Date, invoice.DueDate.Value.Date);
            }
        }
    }
}
