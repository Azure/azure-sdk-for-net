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
    public class BillingRoleDefinitionsOperationsTest : TestBase
    {
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingAccountRoleDefinitionName = "50000000-aaaa-bbbb-cccc-100000000000";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";
        private const string BillingProfileRoleDefinitionName = "40000000-aaaa-bbbb-cccc-100000000000";
        private const string InvoiceSectionName = "CGPK-BEXW-PJA-TGB";
        private const string InvoiceSectionRoleDefinitionName = "30000000-aaaa-bbbb-cccc-100000000000";

        [Fact]
        public void GetBillingRoleDefinitionByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role Definition
                var billingRoleDefinition = billingMgmtClient.BillingRoleDefinitions.GetByBillingAccount(BillingAccountName, BillingAccountRoleDefinitionName);

                // Verify the response
                Assert.NotNull(billingRoleDefinition);
                Assert.Equal(BillingAccountRoleDefinitionName, billingRoleDefinition.Name);
            }
        }

        [Fact]
        public void GetBillingRoleDefinitionByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role Definition
                var billingRoleDefinition = billingMgmtClient.BillingRoleDefinitions.GetByBillingProfile(BillingAccountName, BillingProfileName, BillingProfileRoleDefinitionName);

                // Verify the response
                Assert.NotNull(billingRoleDefinition);
                Assert.Equal(BillingProfileRoleDefinitionName, billingRoleDefinition.Name);
            }
        }

        [Fact]
        public void GetBillingRoleDefinitionByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role Definition
                var billingRoleDefinition = billingMgmtClient.BillingRoleDefinitions.GetByInvoiceSection(BillingAccountName, BillingProfileName, InvoiceSectionName, InvoiceSectionRoleDefinitionName);

                // Verify the response
                Assert.NotNull(billingRoleDefinition);
                Assert.Equal(InvoiceSectionRoleDefinitionName, billingRoleDefinition.Name);
            }
        }

        [Fact]
        public void ListBillingRoleDefinitionsByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role Definitions
                var billingRoleDefinitions = billingMgmtClient.BillingRoleDefinitions.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(billingRoleDefinitions);
                Assert.True(billingRoleDefinitions.Any());
                Assert.Contains(billingRoleDefinitions, role => role.Name == BillingAccountRoleDefinitionName);
            }
        }

        [Fact]
        public void ListBillingRoleDefinitionsByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role Definitions
                var billingRoleDefinitions = billingMgmtClient.BillingRoleDefinitions.ListByBillingProfile(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(billingRoleDefinitions);
                Assert.True(billingRoleDefinitions.Any());
                Assert.Contains(billingRoleDefinitions, role => role.Name == BillingProfileRoleDefinitionName);
            }
        }

        [Fact]
        public void ListBillingRoleDefinitionsByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing role Definitions
                var billingRoleDefinitions = billingMgmtClient.BillingRoleDefinitions.ListByInvoiceSection(BillingAccountName, BillingProfileName, InvoiceSectionName);

                // Verify the response
                Assert.NotNull(billingRoleDefinitions);
                Assert.True(billingRoleDefinitions.Any());
                Assert.Contains(billingRoleDefinitions, role => role.Name == InvoiceSectionRoleDefinitionName);
            }
        }
    }
}
