// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class CompliancesTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var securityCenterClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityCenterClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityCenterClient>(handlers: handler);

            securityCenterClient.AscLocation = "centralus";

            return securityCenterClient;
        }

        #endregion

        #region Compliances Tests

        [Fact]
        public void Compliances_List()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var compliances = securityCenterClient.Compliances.List($"/subscriptions/{SubscriptionId}");
                ValidateCompliances(compliances);
            }
        }

        [Fact]
        public void Compliances_Get()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var compliance = securityCenterClient.Compliances.Get($"/subscriptions/{SubscriptionId}", "2018-07-05Z");
                ValidateCompliance(compliance);
            }
        }

        #endregion

        #region Validations

        private void ValidateCompliances(IPage<Compliance> CompliancesPage)
        {
            Assert.True(CompliancesPage.IsAny());

            CompliancesPage.ForEach(ValidateCompliance);
        }

        private void ValidateCompliance(Compliance compliance)
        {
            Assert.NotNull(compliance);
        }

        #endregion
    }
}
