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
using System.Reflection;
using Microsoft.Azure.Management.Billing.Models;

namespace Billing.Tests.ScenarioTests
{
    public class BillingProfilesOperationsTest : TestBase
    {
        private const string BillingAccountName = "09fdb330-0b61-5cf6-3e5a-92828b8da4c0:83025e81-32ed-47e8-b420-359f05267fb9_2019-05-31";
        private const string BillingProfileName = "TSYB-SQXK-BG7-PKDK-SGB";
        private const string BillingProfileCurrency = "USD";

        [Fact]
        public void ListBillingProfilesByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the Billing Profiles
                var billingProfiles = billingMgmtClient.BillingProfiles.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(billingProfiles);
                var billingProfile = Assert.Single(billingProfiles);
                Assert.Equal(BillingProfileName, billingProfile.Name);
                Assert.Equal(BillingProfileCurrency, billingProfile.Currency);
            }
        }

        [Fact]
        public void GetBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the billing profile
                var billingProfile = billingMgmtClient.BillingProfiles.Get(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(billingProfile);
                Assert.Equal(BillingProfileName, billingProfile.Name);
                Assert.Equal(BillingProfileCurrency, billingProfile.Currency);
            }
        }

        [Fact]
        public void CreateBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var BillingProfileFriendlyName = "Test_" + Guid.NewGuid().ToString();
                var firstName = "First";
                var lastName = "Last";

                var address = new AddressDetails
                {
                    AddressLine1 = "1 Microsoft Way",
                    CompanyName = "Contoso Inc.",
                    City = "Redmond",
                    Region = "WA",
                    Country = "US",
                    PostalCode = "98052",
                    FirstName = firstName,
                    LastName = lastName
                };
                var invoiceEmailOptIn = true;
                var enabledAzurePlans = new AzurePlan[]
                {
                    new AzurePlan { SkuId = "0001" },
                    new AzurePlan { SkuId = "0002" }
                };
                var poNumber = Guid.NewGuid().ToString();
                var displayName = Guid.NewGuid().ToString();

                // Get the billing profile
                var billingProfile = billingMgmtClient.BillingProfiles.CreateOrUpdate(
                    BillingAccountName,
                    BillingProfileFriendlyName,
                    new BillingProfile
                    {
                        BillTo = address,
                        EnabledAzurePlans = enabledAzurePlans,
                        InvoiceEmailOptIn = invoiceEmailOptIn,
                        PoNumber = poNumber,
                        DisplayName = displayName
                    });

                // Verify the response
                Assert.NotNull(billingProfile);
                Assert.Equal(BillingProfileName, billingProfile.Name);
                Assert.Equal(BillingProfileCurrency, billingProfile.Currency);
                Assert.Equal(displayName, billingProfile.DisplayName);
                Assert.Equal(enabledAzurePlans.Length, billingProfile.EnabledAzurePlans.Count);
                Assert.Equal(poNumber, billingProfile.PoNumber);
                Assert.NotNull(billingProfile.BillTo);
                Assert.Equal(address.AddressLine1, billingProfile.BillTo.AddressLine1);
            }
        }

        [Fact]
        public void UpdateExistingBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var poNumber = Guid.NewGuid().ToString();
                var displayName = Guid.NewGuid().ToString();

                // Get the billing profile
                var billingProfile = billingMgmtClient.BillingProfiles.CreateOrUpdate(
                    BillingAccountName,
                    BillingProfileName,
                    new BillingProfile
                    {
                        DisplayName = displayName,
                        PoNumber = poNumber
                    });

                // Verify the response
                Assert.NotNull(billingProfile);
                Assert.Equal(BillingProfileName, billingProfile.Name);
                Assert.Equal(BillingProfileCurrency, billingProfile.Currency);
                Assert.Equal(displayName, billingProfile.DisplayName);
                Assert.Equal(poNumber, billingProfile.PoNumber);
            }
        }
    }
}
