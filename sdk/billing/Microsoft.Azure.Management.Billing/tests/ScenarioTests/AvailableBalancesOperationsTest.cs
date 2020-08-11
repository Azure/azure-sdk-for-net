// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Billing.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using System.Reflection;

namespace Billing.Tests.ScenarioTests
{
    public class AvailableBalancesOperationsTest : TestBase
    {
        private const string BillingAccountName = "c017063b-18ad-5e26-f4af-a4d7eff204cb:171df24e-c924-4c58-9daa-a0bdb1686fef_2019-05-31";
        private const string BillingProfileName = "RZKZ-H3N4-BG7-TGB";
        private const string BillingProfileCurrency = "USD";

        [Fact]
        public void GetAvailableBalanceTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the available balance
                var availableBalance = billingMgmtClient.AvailableBalances.Get(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(availableBalance);
                Assert.Equal(372.8, availableBalance.Amount.Value);
                Assert.Equal(BillingProfileCurrency, availableBalance.Amount.Currency);
            }
        }
    }
}
