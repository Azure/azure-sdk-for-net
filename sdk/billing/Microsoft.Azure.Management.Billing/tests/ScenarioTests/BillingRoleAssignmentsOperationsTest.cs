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
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingAccountRoleAssignmentName = "50000000-aaaa-bbbb-cccc-100000000000_9ae0765f-fe58-40d0-9657-55bd0c421523";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";
        private const string BillingProfileRoleAssignmentName = "40000000-aaaa-bbbb-cccc-100000000000_9ae0765f-fe58-40d0-9657-55bd0c421523";
        private const string InvoiceSectionName = "CGPK-BEXW-PJA-TGB";
        private const string InvoiceSectionRoleAssignmentName = "30000000-aaaa-bbbb-cccc-100000000000_9ae0765f-fe58-40d0-9657-55bd0c421523";

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
                Assert.True(billingRoleAssignments.Any());
                Assert.Contains(billingRoleAssignments, role => role.Name == BillingAccountRoleAssignmentName);
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
                Assert.True(billingRoleAssignments.Any());
                Assert.Contains(billingRoleAssignments, role => role.Name == BillingProfileRoleAssignmentName);
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
                Assert.True(billingRoleAssignments.Any());
                Assert.Contains(billingRoleAssignments, role => role.Name == InvoiceSectionRoleAssignmentName);
            }
        }
    }
}
