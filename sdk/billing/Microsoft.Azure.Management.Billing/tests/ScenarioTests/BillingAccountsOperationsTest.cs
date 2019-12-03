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
    public class BillingAccountsOperationsTest : TestBase
    {
        private const string BillingAccountName = "723c8ce0-33ba-5ba7-ef23-e1b72f15f1d8:4ce5b530-c82b-44e8-97ec-49f3cce9f14d_2019-05-31";
        private const string BillingProfileName = "H6RI-TXWC-BG7-PGB";
        
        [Fact]
        public void ExpandBillingAccountByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the Billing Accounts and expand billing profiles
                var billingAccount = billingMgmtClient.BillingAccounts.Get(BillingAccountName, "billingProfiles");

                // Verify the response
                Assert.NotNull(billingAccount);
                Assert.Equal(BillingAccountName, billingAccount.Name);
                Assert.Equal(1, billingAccount.BillingProfiles.Count);
            }
        }

        [Fact]
        public void ExpandBillingAccountByInvoiceSectionsTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the Billing Accounts and expand invoice sections
                var billingAccount = billingMgmtClient.BillingAccounts.Get(BillingAccountName, "billingProfiles/invoiceSections");

                // Verify the response
                Assert.NotNull(billingAccount);
                Assert.Equal(BillingAccountName, billingAccount.Name);
                var billingProfile = Assert.Single(billingAccount.BillingProfiles);
                Assert.Equal(BillingProfileName, billingProfile.Name);
                Assert.True(billingProfile.InvoiceSections.Count > 0);
            }
        }

        [Fact]
        public void GetBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the Billing Accounts
                var billingAccount = billingMgmtClient.BillingAccounts.Get(BillingAccountName);

                // Verify the response
                Assert.NotNull(billingAccount);
                Assert.Equal(BillingAccountName, billingAccount.Name);
            }
        }

        [Fact]
        public void ListBillingAccountsTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the Billing Accounts
                var billingAccounts = billingMgmtClient.BillingAccounts.List();

                // Verify the response
                Assert.NotNull(billingAccounts);
                var billingAccount = Assert.Single(billingAccounts.Value);
                Assert.Equal(BillingAccountName, billingAccount.Name);
            }
        }

        [Fact]
        public void ListBillingAccountsAndExpandTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the Billing Accounts
                var billingAccounts = billingMgmtClient.BillingAccounts.List("billingProfiles/invoiceSections");

                // Verify the response
                Assert.NotNull(billingAccounts);
                var billingAccount = Assert.Single(billingAccounts.Value);
                Assert.Equal(BillingAccountName, billingAccount.Name);
                var billingProfile = Assert.Single(billingAccount.BillingProfiles);
                Assert.Equal(BillingProfileName, billingProfile.Name);
                Assert.True(billingProfile.InvoiceSections.Count > 0);
            }
        }
    }
}
