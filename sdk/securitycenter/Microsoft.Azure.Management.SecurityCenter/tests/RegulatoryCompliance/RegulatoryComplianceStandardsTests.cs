// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SecurityCenter.Tests
{
    public class RegulatoryComplianceStandardsTests: TestBase
    {
        #region Test setup
        private static readonly string regulatoryComplianceStandardName = "Microsoft-cloud-security-benchmark";
        private static readonly string AscLocation = "centralus";
        private static TestEnvironment TestEnvironment { get; set; }
        #endregion

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

            securityCenterClient.AscLocation = AscLocation;

            return securityCenterClient;
        }

        #region Tests
        [Fact]
        public async Task RegulatoryComplianceStandards_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = await securityCenterClient.RegulatoryComplianceStandards.GetAsync(regulatoryComplianceStandardName);
                Assert.NotNull(ret);
            }
        }

        [Fact]
        public async Task RegulatoryComplianceStandards_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = await securityCenterClient.RegulatoryComplianceStandards.ListAsync();
                Assert.True(ret.IsAny(), "Got empty list");
                foreach (var item in ret)
                {
                    Assert.NotNull(item);
                }
            }
        }
        #endregion
    }
}

