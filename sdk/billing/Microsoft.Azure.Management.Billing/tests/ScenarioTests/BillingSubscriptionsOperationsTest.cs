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
    public class BillingSubscriptionsOperationsTest : TestBase
    {
        private const string BillingAccountName = "4b15e98a-cb13-5f5d-0d2c-64eea298c8d4:277f7747-44f1-446f-88b0-d27d655c60cd_2019-05-31";
        private const string BillingProfileName = "KKMM-ZUHC-BG7-TGB";
        private const string BillingSubscriptionName = "ce294754-54f1-41f0-853b-57415ca15600";
        private const string InvoiceSectionName = "UCAF-IQUR-PJA-TGB";
        private const string SourceInvoiceSectionId =
            "/providers/Microsoft.Billing/billingAccounts/4b15e98a-cb13-5f5d-0d2c-64eea298c8d4:277f7747-44f1-446f-88b0-d27d655c60cd_2019-05-31/billingProfiles/KKMM-ZUHC-BG7-TGB/invoiceSections/UCAF-IQUR-PJA-TGB";
        private const string DestinationInvoiceSectionId =
            "/providers/Microsoft.Billing/billingAccounts/4b15e98a-cb13-5f5d-0d2c-64eea298c8d4:277f7747-44f1-446f-88b0-d27d655c60cd_2019-05-31/billingProfiles/KKMM-ZUHC-BG7-TGB/invoiceSections/WOEH-SLEK-DHR-TGB";

        [Fact]
        public void GetBillingSubscriptionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                
                // Set the subscription id.
                billingMgmtClient.SubscriptionId = BillingSubscriptionName;

                // Get the agreements
                var billingSubscription = billingMgmtClient.BillingSubscriptions.Get(BillingAccountName);

                // Verify the response
                Assert.NotNull(billingSubscription);
                Assert.Contains(BillingProfileName, billingSubscription.BillingProfileId);
                Assert.Contains(InvoiceSectionName, billingSubscription.InvoiceSectionId);
                Assert.Contains(BillingSubscriptionName, billingSubscription.Name);
            }
        }

        [Fact]
        public void ListBillingSubscriptionsByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var billingSubscriptions = billingMgmtClient.BillingSubscriptions.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(billingSubscriptions);
                Assert.True(billingSubscriptions.Any());
                Assert.Contains(billingSubscriptions, bs => bs.BillingProfileId.Contains(BillingProfileName));
                Assert.Contains(billingSubscriptions, bs => bs.InvoiceSectionId.Contains(InvoiceSectionName));
            }
        }

        [Fact]
        public void ListBillingSubscriptionsByBillingProfileTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var billingSubscriptions = billingMgmtClient.BillingSubscriptions.ListByBillingProfile(BillingAccountName, BillingProfileName);

                // Verify the response
                Assert.NotNull(billingSubscriptions);
                Assert.True(billingSubscriptions.Any());
                Assert.Contains(billingSubscriptions, bs => bs.BillingProfileId.Contains(BillingProfileName));
                Assert.Contains(billingSubscriptions, bs => bs.InvoiceSectionId.Contains(InvoiceSectionName));
            }
        }

        [Fact]
        public void ListBillingSubscriptionsByInvoiceSectionTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var billingSubscriptions = billingMgmtClient.BillingSubscriptions.ListByInvoiceSection(BillingAccountName, BillingProfileName, InvoiceSectionName);

                // Verify the response
                Assert.NotNull(billingSubscriptions);
                Assert.True(billingSubscriptions.Any());
                Assert.Contains(billingSubscriptions, bs => bs.BillingProfileId.Contains(BillingProfileName));
                Assert.Contains(billingSubscriptions, bs => bs.InvoiceSectionId.Contains(InvoiceSectionName));
            }
        }

        [Fact]
        public void MoveBillingSubscriptionsTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var billingSubscription = billingMgmtClient.BillingSubscriptions.Move(
                    BillingAccountName, new TransferBillingSubscriptionRequestProperties
                    {
                        DestinationInvoiceSectionId = DestinationInvoiceSectionId
                    });

                // Verify the response
                Assert.NotNull(billingSubscription);
                Assert.Contains(billingSubscription.InvoiceSectionId, DestinationInvoiceSectionId);

                // restore
                billingSubscription = billingMgmtClient.BillingSubscriptions.Move(
                    BillingAccountName, new TransferBillingSubscriptionRequestProperties
                    {
                        DestinationInvoiceSectionId = SourceInvoiceSectionId
                    });

                // Verify the response
                Assert.NotNull(billingSubscription);
                Assert.Contains(billingSubscription.InvoiceSectionId, SourceInvoiceSectionId);
            }
        }

        [Fact]
        public void UpdateBillingSubscriptionsTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            var costCenterNew = "CostCenterNew";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var updatedBillingsubscription = billingMgmtClient.BillingSubscriptions.Update(
                    BillingAccountName, 
                    new BillingSubscription
                    {
                        CostCenter = costCenterNew
                    });

                // Verify the response
                Assert.NotNull(updatedBillingsubscription);
                Assert.NotNull(updatedBillingsubscription.CostCenter);
                Assert.Equal(updatedBillingsubscription.CostCenter, costCenterNew);

                //restore
                var costCenterOld = "CostCenterOld";
                updatedBillingsubscription = billingMgmtClient.BillingSubscriptions.Update(
                    BillingAccountName,
                    new BillingSubscription
                    {
                        CostCenter = costCenterOld
                    });

                // Verify the response
                Assert.NotNull(updatedBillingsubscription);
                Assert.NotNull(updatedBillingsubscription.CostCenter);
                Assert.Equal(updatedBillingsubscription.CostCenter, costCenterOld);
            }
        }

        [Fact]
        public void ValidateBillingSubscriptionsMoveEligibilityTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory =
                Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
            
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context,
                    new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                // Get the agreements
                var validateSubscriptionTransferEligibilityResult = billingMgmtClient.BillingSubscriptions.ValidateMove(
                    BillingAccountName,
                    new TransferBillingSubscriptionRequestProperties()
                    {
                        DestinationInvoiceSectionId = DestinationInvoiceSectionId
                    });

                // Verify the response
                Assert.NotNull(validateSubscriptionTransferEligibilityResult);
                Assert.NotNull(validateSubscriptionTransferEligibilityResult.IsMoveEligible);
                Assert.True(validateSubscriptionTransferEligibilityResult.IsMoveEligible.Value);
            }
        }
    }
}
