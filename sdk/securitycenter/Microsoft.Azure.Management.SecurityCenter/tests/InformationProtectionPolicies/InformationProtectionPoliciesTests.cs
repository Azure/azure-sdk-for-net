// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using Xunit;

namespace SecurityCenter.Tests
{
    public class InformationProtectionPoliciesTests : TestBase
    {
        #region Test setup

        private static string Scope = "providers/Microsoft.Management/managementGroups/72f988bf-86f1-41af-91ab-2d7cd011db47";

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

        #region Information Protection Policies Tests

        [Fact]
        public async Task InformationProtectionPolicies_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);

                var informationProtectionPolicies = await securityCenterClient.InformationProtectionPolicies.ListAsync(Scope);
                ValidateInformationProtectionPolicies(informationProtectionPolicies);
            }
        }

        [Fact]
        public async Task InformationProtectionPolicy_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var effectiveInformationProtectionPolicy = await securityCenterClient.InformationProtectionPolicies.GetAsync(Scope, InformationProtectionPolicyName.Effective);
                ValidateInformationProtectionPolicy(effectiveInformationProtectionPolicy);
            }
        }

        #endregion

        #region Validations

        private void ValidateInformationProtectionPolicies(IPage<InformationProtectionPolicy> informationProtectionPoliciesPage)
        {
            Assert.True(informationProtectionPoliciesPage.IsAny());

            informationProtectionPoliciesPage.ForEach(ValidateInformationProtectionPolicy);
        }

        private void ValidateInformationProtectionPolicy(InformationProtectionPolicy informationProtectionPolicy)
        {
            Assert.NotNull(informationProtectionPolicy);
        }

        #endregion
    }
}
