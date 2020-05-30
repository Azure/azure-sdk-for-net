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
        private static readonly DateTime DueDate = DateTime.Parse("5/9/2020");
        private const string BillingAccountName = "c96f6d74-3523-5a58-106d-1bdafab4211f:2f5f0dad-af26-4a54-8145-1a1cf8b93eea_2019-05-31";
        private const string BillingProfileName = "FQWV-S4GU-BG7-TGB";
        private const string InvoiceNumber = "T000154489";
        private const string InvoiceStatus = "Paid";

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
                var invoice = billingMgmtClient.Invoices.Get(BillingAccountName, InvoiceNumber);

                // Verify the response
                Assert.NotNull(invoice);
                Assert.Contains(BillingProfileName, invoice.BillingProfileId);
                Assert.Equal(InvoiceNumber, invoice.Name);
                Assert.Equal(InvoiceStatus, invoice.Status);
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
                var invoices = billingMgmtClient.Invoices.ListByBillingAccount(BillingAccountName, "2019-12-01", "2020-11-01");

                // Verify the response
                Assert.NotNull(invoices);
                var invoice = Assert.Single(invoices);
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
                var invoices = billingMgmtClient.Invoices.ListByBillingProfile(BillingAccountName, BillingProfileName, "2019-12-01", "2020-11-01");

                // Verify the response
                Assert.NotNull(invoices);
                var invoice = Assert.Single(invoices);
                Assert.Contains(BillingProfileName, invoice.BillingProfileId);
                Assert.Equal(InvoiceNumber, invoice.Name);
                Assert.Equal(InvoiceStatus, invoice.Status);
                Assert.Equal(DueDate.Date, invoice.DueDate.Value.Date);
            }
        }
    }
}
