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
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";
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
