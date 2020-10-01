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
        private const string BillingAccountName = "c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31";
        private const string BillingProfileName = "RZKZ-H3N4-BG7-TGB";
        private const string InvoiceId = "T000492114";
        private const string InvoiceSectionName = "L6E4-BU47-PJA-TGB";
        private const string TransactionName = "a587112e-5509-4621-b53d-53b1bcd92744";

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
                Assert.Equal(3, transactions.Count());
                var transaction = Assert.Single(transactions.Where(t => t.Name == TransactionName));
                Assert.Contains(BillingProfileName, transaction.BillingProfileId);
                Assert.Contains(InvoiceSectionName, transaction.InvoiceSectionId);
            }
        }
    }
}
