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
    public class TransactionsOperationsTest : TestBase
    {
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        private const string InvoiceSectionName = "ICYS-ZE5B-PJA-PGB";
        private const string TransactionName = "98ce813f-facd-43d4-a8fe-b6958fc0f5cf";

        [Fact]
        public void ListTransactionsByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the transactions
                var transactions = billingMgmtClient.Transactions.ListByBillingAccount(BillingAccountName, "2018-12-01", "2019-11-18");

                // Verify the response
                Assert.NotNull(transactions);
                Assert.Equal(2, transactions.Count());
                var transaction = Assert.Single(transactions.Where(t => t.Name == TransactionName));
                Assert.Contains(BillingProfileName, transaction.BillingProfileId);
                Assert.Contains(InvoiceSectionName, transaction.InvoiceSectionId);
            }
        }

        [Fact]
        public void ListTransactionsByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory =
                Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                // Get the transactions
                var transactions = billingMgmtClient.Transactions.ListByBillingProfile(BillingAccountName, BillingProfileName, "2018-12-01", "2019-11-18");

                // Verify the response
                Assert.NotNull(transactions);
                Assert.Equal(2, transactions.Value.Count);
                var transaction = Assert.Single(transactions.Value.Where(t => t.Name == TransactionName));
                Assert.Contains(BillingProfileName, transaction.BillingProfileId);
                Assert.Contains(InvoiceSectionName, transaction.InvoiceSectionId);
            }
        }

        [Fact]
        public void ListTransactionsByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the transactions
                var transactions = billingMgmtClient.Transactions.ListByInvoiceSection(BillingAccountName, BillingProfileName, InvoiceSectionName, "2018-12-01", "2019-11-18");

                // Verify the response
                Assert.NotNull(transactions);
                Assert.Equal(2, transactions.Value.Count);
                var transaction = Assert.Single(transactions.Value.Where(t => t.Name == TransactionName));
                Assert.Contains(BillingProfileName, transaction.BillingProfileId);
                Assert.Contains(InvoiceSectionName, transaction.InvoiceSectionId);
            }
        }
    }
}
