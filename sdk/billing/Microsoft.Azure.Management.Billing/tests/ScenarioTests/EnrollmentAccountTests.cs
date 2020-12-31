// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Billing.Tests.Helpers;
using Microsoft.Azure.Management.Billing;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;

namespace Billing.Tests.ScenarioTests
{
    public class EnrollmentAccountTests : TestBase
    {
        const string EnrollmentAccountName = "c8a9f59a-2d9b-4086-91c8-8988cae3bec3";

        [Fact]
        public void ListEnrollmentAccounts()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var enrollmentAccounts = billingMgmtClient.EnrollmentAccounts.List();
                Assert.NotNull(enrollmentAccounts);
                Assert.True(enrollmentAccounts.Any());
            }
        }

        [Fact]
        public void GetEnrollmentAccountWithName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var billingMgmtClient = BillingTestUtilities.GetBillingManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                var enrollmentAccount = billingMgmtClient.EnrollmentAccounts.Get(EnrollmentAccountName);
                Assert.NotNull(enrollmentAccount);
                Assert.Equal(EnrollmentAccountName, enrollmentAccount.Name);
                Assert.NotNull(enrollmentAccount.Name);
                Assert.NotNull(enrollmentAccount.PrincipalName);
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(Billing.Tests.ScenarioTests.EnrollmentAccountTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}