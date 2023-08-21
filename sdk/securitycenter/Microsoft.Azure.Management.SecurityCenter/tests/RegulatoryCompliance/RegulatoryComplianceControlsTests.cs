// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SecurityCenter.Tests
{
    public class RegulatoryComplianceControlsTests : TestBase
    {
        #region Test setup
        private static readonly string regulatoryComplianceStandardName = "PCI DSS 4";
        private static readonly string regulatoryComplianceControlName = "1.1.1";
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
        public async Task RegulatoryComplianceControls_ListWithODataFilter()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var regulatoryComplianceControls = await securityCenterClient.RegulatoryComplianceControls.ListAsync(regulatoryComplianceStandardName, $"state ne 'Passed'");
                ValidateRegulatoryComplianceControls(regulatoryComplianceControls);
            }
        }

        [Fact]
        public async Task RegulatoryComplianceControls_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var regulatoryComplianceControls = await securityCenterClient.RegulatoryComplianceControls.ListAsync(regulatoryComplianceStandardName);
                ValidateRegulatoryComplianceControls(regulatoryComplianceControls);
            }
        }


        [Fact]
        public async Task RegulatoryComplianceControls_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var regulatoryComplianceControl = await securityCenterClient.RegulatoryComplianceControls.GetAsync(regulatoryComplianceStandardName, regulatoryComplianceControlName);
                ValidateRegulatoryComplianceControl(regulatoryComplianceControl);
            }
        }

        #endregion


        #region Validations

        private void ValidateRegulatoryComplianceControls(IPage<RegulatoryComplianceControl> regulatoryComplianceControls)
        {
            Assert.True(regulatoryComplianceControls.IsAny(), "regulatoryComplianceControls should not be empty");

            regulatoryComplianceControls.ForEach(ValidateRegulatoryComplianceControl);
        }

        private void ValidateRegulatoryComplianceControl(RegulatoryComplianceControl regulatoryComplianceControl)
        {
            Assert.NotNull(regulatoryComplianceControl);
        }

        #endregion
    }
}

