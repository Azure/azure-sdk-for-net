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
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        private const string InvoiceSectionName = "ICYS-ZE5B-PJA-PGB";
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
                Assert.True(billingPermissions.Value.Count > 0);
                Assert.Contains(OrganizationViewPermission, billingPermissions.Value.First().Actions);
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
                Assert.True(billingPermissions.Value.Count > 0);
                Assert.Contains(ViewBillingProfilePermission, billingPermissions.Value.First().Actions);
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
                Assert.True(billingPermissions.Value.Count > 0);
                // There are no permissions for Customer for a non partner account
                Assert.True(billingPermissions.Value.First().Actions.Count == 0);
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
                Assert.True(billingPermissions.Value.Count > 0);
                Assert.Contains(ViewInvoiceSectionPropertiesPermission, billingPermissions.Value.First().Actions);
            }
        }
    }
}
