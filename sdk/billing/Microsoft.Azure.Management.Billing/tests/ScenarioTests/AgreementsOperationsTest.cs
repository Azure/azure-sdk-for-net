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
    public class AgreementsOperationsTest : TestBase
    {
        private const string BillingAccountName = "692a1ef6-595a-5578-8776-de10c9d64861:5869ea10-a21e-423f-9213-2ca0d1938908_2019-05-31";
        private const string AgreementStatus = "Active";
        private const string AgreementAcceptanceMode = "ClickToAccept";
        private const string AgreementCategory = "MicrosoftCustomerAgreement";

        [Fact]
        public void ListAgreementsByBillingAccountTest()
        {
            var something = typeof(Billing.Tests.ScenarioTests.OperationsTests);
            string executingAssemblyPath = something.GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create client
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // Get the agreements
                var agreements = billingMgmtClient.Agreements.ListByBillingAccount(BillingAccountName);

                // Verify the response
                Assert.NotNull(agreements);
                Assert.NotEmpty(agreements);
                var agreement = Assert.Single(agreements);
                Assert.NotNull(agreement.AcceptanceMode);
                Assert.NotNull(agreement.AgreementLink);
                Assert.NotNull(agreement.Category);
                Assert.NotNull(agreement.EffectiveDate);
                Assert.NotNull(agreement.ExpirationDate);
                Assert.NotNull(agreement.Name);
                Assert.NotNull(agreement.Status);
                Assert.Equal(AgreementStatus, agreement.Status);
                Assert.Equal(AgreementAcceptanceMode, agreement.AcceptanceMode);
                Assert.Equal(AgreementCategory, agreement.Category);
            }
        }
    }
}
