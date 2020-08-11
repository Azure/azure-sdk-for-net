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

namespace Billing.Tests.ScenarioTests
{
    public class BillingProfilesOperationsTest : TestBase
    {
        private const string BillingAccountName = "1f434626-12ea-5b95-6758-0c4b6432b3ae:d0f4c360-b456-4844-b6e2-040c0d6b0cd7_2019-05-31";
        private const string BillingProfileName = "DRWP-ID5F-BG7-TGB";
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
                Assert.Equal(5, billingProfiles.Count());
                var billingProfile = Assert.Single(billingProfiles.Where(i => i.Name == BillingProfileName));
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
                var BillingProfileFriendlyName = "Test_BillingProfile2020GA" ;
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
                var poNumber = "1234567";
                var displayName = "NewBillingProfileDisplayName";

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
                Assert.Equal(BillingProfileFriendlyName, billingProfile.Name);
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
                var poNumber = "8901234";
                var displayName = "UpdatedBillingProfileDisplayName";
                var billingProfileName = "Test_BillingProfile2020GA";

                // Get the billing profile
                var billingProfile = billingMgmtClient.BillingProfiles.CreateOrUpdate(
                    BillingAccountName,
                    billingProfileName,
                    new BillingProfile
                    {
                        DisplayName = displayName,
                        PoNumber = poNumber
                    });

                // Verify the response
                Assert.NotNull(billingProfile);
                Assert.Equal(billingProfileName, billingProfile.Name);
                Assert.Equal(BillingProfileCurrency, billingProfile.Currency);
                Assert.Equal(displayName, billingProfile.DisplayName);
                Assert.Equal(poNumber, billingProfile.PoNumber);
            }
        }
    }
}
