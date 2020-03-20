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
    public class BillingRoleAssignmentsOperationsTest : TestBase
    {
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingAccountRoleAssignmentName = "50000000-aaaa-bbbb-cccc-100000000000_5c4fad53-9cfb-4e22-9635-e7f420ab3ca7";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        private const string BillingProfileRoleAssignmentName = "40000000-aaaa-bbbb-cccc-100000000000_5c4fad53-9cfb-4e22-9635-e7f420ab3ca7";
        private const string InvoiceSectionName = "ICYS-ZE5B-PJA-PGB";
        private const string InvoiceSectionRoleAssignmentName = "30000000-aaaa-bbbb-cccc-100000000000_5c4fad53-9cfb-4e22-9635-e7f420ab3ca7";

        [Fact]
        public void GetBillingRoleAssignmentByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role assignment
                var billingRoleAssignment = billingMgmtClient.BillingRoleAssignments.GetByBillingAccount(BillingAccountName, BillingAccountRoleAssignmentName);

                // Verify the response
                Assert.NotNull(billingRoleAssignment);
                Assert.Equal(BillingAccountRoleAssignmentName, billingRoleAssignment.Name);
            }
        }

        [Fact]
        public void GetBillingRoleAssignmentByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role assignment
                var billingRoleAssignment = billingMgmtClient.BillingRoleAssignments.GetByBillingProfile(BillingAccountName, BillingProfileName, BillingProfileRoleAssignmentName);

                // Verify the response
                Assert.NotNull(billingRoleAssignment);
                Assert.Equal(BillingProfileRoleAssignmentName, billingRoleAssignment.Name);
            }
        }

        [Fact]
        public void GetBillingRoleAssignmentByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role assignment
                var billingRoleAssignment = billingMgmtClient.BillingRoleAssignments.GetByInvoiceSection(BillingAccountName, BillingProfileName, InvoiceSectionName, InvoiceSectionRoleAssignmentName);

                // Verify the response
                Assert.NotNull(billingRoleAssignment);
                Assert.Equal(InvoiceSectionRoleAssignmentName, billingRoleAssignment.Name);
            }
        }

        [Fact]
        public void ListBillingRoleAssignmentsByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role assignments
                var billingRoleAssignments = billingMgmtClient.BillingRoleAssignments.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(billingRoleAssignments);
                Assert.True(billingRoleAssignments.Value.Count > 0);
                Assert.Contains(billingRoleAssignments.Value, role => role.Name == BillingAccountRoleAssignmentName);
            }
        }

        [Fact]
        public void ListBillingRoleAssignmentsByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role assignments
                var billingRoleAssignments = billingMgmtClient.BillingRoleAssignments.ListByBillingProfile(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(billingRoleAssignments);
                Assert.True(billingRoleAssignments.Value.Count > 0);
                Assert.Contains(billingRoleAssignments.Value, role => role.Name == BillingProfileRoleAssignmentName);
            }
        }

        [Fact]
        public void ListBillingRoleAssignmentsByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role assignments
                var billingRoleAssignments = billingMgmtClient.BillingRoleAssignments.ListByInvoiceSection(BillingAccountName, BillingProfileName, InvoiceSectionName);

                // Verify the response
                Assert.NotNull(billingRoleAssignments);
                Assert.True(billingRoleAssignments.Value.Count > 0);
                Assert.Contains(billingRoleAssignments.Value, role => role.Name == InvoiceSectionRoleAssignmentName);
            }
        }
    }
}
