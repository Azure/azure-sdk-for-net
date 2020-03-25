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
using Microsoft.Azure.Management.Billing.Models;

namespace Billing.Tests.ScenarioTests
{
    public class PoliciesOperationsTest : TestBase
    {
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        private const string MarketplacePurchasesPolicy = "AllAllowed";
        private const string ReservationPurchasesPolicy = "Allowed";
        private const string ViewChargesPolicy = "NotAllowed";

        [Fact]
        public void GetPoliciesByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the policies
                var policies = billingMgmtClient.Policies.GetByBillingProfile(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(policies);
                Assert.Equal(MarketplacePurchasesPolicy, policies.MarketplacePurchases);
                Assert.Equal(ReservationPurchasesPolicy, policies.ReservationPurchases);
                Assert.Equal(ViewChargesPolicy, policies.ViewCharges);
            }
        }

        [Fact]
        public void UpdatePoliciesByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var policy = new Policy
                {
                    ReservationPurchases = ReservationPurchasesPolicy,
                    MarketplacePurchases = MarketplacePurchasesPolicy,
                    ViewCharges = ViewChargesPolicy
                };

                // Update the policies
                var policies = billingMgmtClient.Policies.Update(BillingAccountName, BillingProfileName, policy);

                // Verify the response
                Assert.NotNull(policies);
                Assert.Equal(MarketplacePurchasesPolicy, policies.MarketplacePurchases);
                Assert.Equal(ReservationPurchasesPolicy, policies.ReservationPurchases);
                Assert.Equal(ViewChargesPolicy, policies.ViewCharges);
            }
        }
    }
}
