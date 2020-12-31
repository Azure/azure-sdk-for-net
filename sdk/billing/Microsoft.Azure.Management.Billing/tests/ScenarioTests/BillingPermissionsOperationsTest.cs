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
    public class BillingPermissionsOperationsTest : TestBase
    {
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";
        private const string InvoiceSectionName = "CGPK-BEXW-PJA-TGB";
        private const string OrganizationViewPermission = "50000000-aaaa-bbbb-cccc-200000000001";
        private const string ViewBillingProfilePermission = "40000000-aaaa-bbbb-cccc-200000000006";
        private const string ViewInvoiceSectionPropertiesPermission = "30000000-aaaa-bbbb-cccc-200000000001";

        [Fact]
        public void ListByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing permissions
                var billingPermissions = billingMgmtClient.BillingPermissions.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(billingPermissions);
                Assert.True(billingPermissions.Any());
                Assert.Contains(OrganizationViewPermission, billingPermissions.First().Actions);
            }
        }

        [Fact]
        public void ListByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing permissions
                var billingPermissions = billingMgmtClient.BillingPermissions.ListByBillingProfile(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(billingPermissions);
                Assert.True(billingPermissions.Any());
                Assert.Contains(ViewBillingProfilePermission, billingPermissions.First().Actions);
            }
        }


        [Fact]
        public void ListByCustomerTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing permissions
                var billingPermissions = billingMgmtClient.BillingPermissions.ListByCustomer(BillingAccountName, InvoiceSectionName);

                // Verify the response
                Assert.NotNull(billingPermissions);
                Assert.True(billingPermissions.Any());
                // There are no permissions for Customer for a non partner account
                Assert.True(billingPermissions.First().Actions.Count == 0);
            }
        }

        [Fact]
        public void ListByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing permissions
                var billingPermissions = billingMgmtClient.BillingPermissions.ListByInvoiceSections(BillingAccountName, BillingProfileName, InvoiceSectionName);

                // Verify the response
                Assert.NotNull(billingPermissions);
                Assert.True(billingPermissions.Any());
                Assert.Contains(ViewInvoiceSectionPropertiesPermission, billingPermissions.First().Actions);
            }
        }
    }
}
