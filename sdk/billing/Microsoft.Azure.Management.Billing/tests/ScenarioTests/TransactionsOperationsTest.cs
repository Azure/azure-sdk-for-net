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
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";
        private const string InvoiceId = "G000492901";
        private const string InvoiceSectionName = "ICYS-ZE5B-PJA-PGB";
        private const string TransactionName = "98ce813f-facd-43d4-a8fe-b6958fc0f5cf";

        [Fact]
        public void ListTransactionsByInvoiceTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the transactions
                var transactions = billingMgmtClient.Transactions.ListByInvoice(BillingAccountName, InvoiceId);

                // Verify the response
                Assert.NotNull(transactions);
                Assert.Equal(2, transactions.Count());
                var transaction = Assert.Single(transactions.Where(t => t.Name == TransactionName));
                Assert.Contains(BillingProfileName, transaction.BillingProfileId);
                Assert.Contains(InvoiceSectionName, transaction.InvoiceSectionId);
            }
        }
    }
}
