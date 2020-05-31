// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
using Enumerable = System.Linq.Enumerable;

namespace Billing.Tests.ScenarioTests
{
    public class BillingAccountsOperationsTest : TestBase
    {
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string BillingProfileName = "DSNH-WUZE-BG7-TGB";

        [Fact]
        public void ExpandBillingAccountByAllTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the Billing Accounts and expand soldTo,billingProfiles,billingProfiles/invoiceSections
                var billingAccount = billingMgmtClient.BillingAccounts.Get(BillingAccountName, "soldTo,billingProfiles,billingProfiles/invoiceSections");

                // Verify the response
                Assert.NotNull(billingAccount);
                Assert.Equal(BillingAccountName, billingAccount.Name);
                Assert.NotNull(billingAccount.SoldTo);
                Assert.NotNull(billingAccount.BillingProfiles.Value);
                Assert.Equal(1, billingAccount.BillingProfiles.Value.Count);
                Assert.NotNull(billingAccount.BillingProfiles.Value[0].InvoiceSections);
                Assert.Equal(3, billingAccount.BillingProfiles.Value[0].InvoiceSections.Value.Count);
            }
        }

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
                Assert.Equal(1, billingAccount.BillingProfiles.Value.Count);
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
                var billingProfile = Assert.Single(billingAccount.BillingProfiles.Value);
                Assert.Equal(BillingProfileName, billingProfile.Name);
                Assert.True(billingProfile.InvoiceSections.Value.Count > 0);
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
                var billingAccount = Assert.Single(billingAccounts);
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
                var billingAccount = Assert.Single(billingAccounts);
                Assert.Equal(BillingAccountName, billingAccount.Name);
                var billingProfile = Assert.Single(billingAccount.BillingProfiles.Value);
                Assert.Equal(BillingProfileName, billingProfile.Name);
                Assert.True(billingProfile.InvoiceSections.Value.Count > 0);
            }
        }

        [Fact]
        public void ListInvoiceSectionsByCreateSubscriptionPermissionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            var invoiceSectionDisplayName = "CGPK-BEXW-PJA-TGB";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the Billing Accounts
                var invoiceSections = billingMgmtClient.BillingAccounts.ListInvoiceSectionsByCreateSubscriptionPermission(BillingAccountName);

                // Verify the response
                Assert.NotNull(invoiceSections);
                Assert.Equal(9, invoiceSections.Count());
                var invoiceSection =
                    invoiceSections.Where(i => i.InvoiceSectionDisplayName == invoiceSectionDisplayName);
            }
        }

        [Fact]
        public void UpdateBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var addressLine2 = "New Address line";
                var address = new AddressDetails
                {
                    AddressLine1 = "1 Microsoft Way",
                    AddressLine2 = addressLine2,
                    CompanyName = "Contoso Inc.",
                    City = "Redmond",
                    Region = "WA",
                    Country = "US",
                    PostalCode = "98052",
                    FirstName = "First",
                    LastName = "Last"
                };
                var displayName = Guid.NewGuid().ToString();

                // Get the Billing Accounts
                var billingAccount = billingMgmtClient.BillingAccounts.Update(
                    BillingAccountName,
                    new BillingAccountUpdateRequest
                    {
                        DisplayName = displayName,
                        SoldTo = address
                    });

                // Verify the response
                Assert.NotNull(billingAccount);
                Assert.Equal(BillingAccountName, billingAccount.Name );
                Assert.NotNull(billingAccount.SoldTo);
                Assert.Equal(address.FirstName, billingAccount.SoldTo.FirstName);
                Assert.Equal(address.LastName, billingAccount.SoldTo.LastName);
                Assert.Equal(address.AddressLine1, billingAccount.SoldTo.AddressLine1);
                Assert.Equal(address.AddressLine2, billingAccount.SoldTo.AddressLine2);
            }
        }
    }
}
