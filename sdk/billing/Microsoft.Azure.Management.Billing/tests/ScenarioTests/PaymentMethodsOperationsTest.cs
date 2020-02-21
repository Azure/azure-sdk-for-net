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
    public class PaymentMethodsOperationsTest : TestBase
    {
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        private const string CreditsPaymentMethod = "Credits";
        private const string ExpirationDate = "10/2020";
        private const string PaymentMethodCurrency = "USD";

        [Fact]
        public void ListPaymentMethodsByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the payment methods
                var paymentMethods = billingMgmtClient.PaymentMethods.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(paymentMethods);
                Assert.Equal(2, paymentMethods.Count());
                var credit = Assert.Single(paymentMethods.Where(pm => pm.PaymentMethodType == "Credits"));
                Assert.Equal(CreditsPaymentMethod, credit.Details);
                Assert.Equal(ExpirationDate, credit.Expiration);
                Assert.Equal(PaymentMethodCurrency, credit.Currency);
            }
        }

        [Fact]
        public void ListPaymentMethodsByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the payment methods
                var paymentMethods = billingMgmtClient.PaymentMethods.ListByBillingProfile(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(paymentMethods);
                Assert.Equal(2, paymentMethods.Count());
                var credit = Assert.Single(paymentMethods.Where(pm => pm.PaymentMethodType == "Credits"));
                Assert.Equal(CreditsPaymentMethod, credit.Details);
                Assert.Equal(ExpirationDate, credit.Expiration);
                Assert.Equal(PaymentMethodCurrency, credit.Currency);
                
            }
        }
    }
}
