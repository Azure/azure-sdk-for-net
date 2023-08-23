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
    public class RegulatoryComplianceAssessmentsTests : TestBase
    {
        #region Test setup
        private static readonly string regulatoryComplianceStandardName = "PCI-DSS-4";
        private static readonly string regulatoryComplianceControlName = "1.2.1";
        private static readonly string regulatoryComplianceAssessmentName = "9f3f4bdc-b40a-75fe-8a18-873f31667d72";
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
        public async Task RegulatoryComplianceAssessments_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var regulatoryComplianceAssessment = await securityCenterClient.RegulatoryComplianceAssessments.GetAsync(regulatoryComplianceStandardName, regulatoryComplianceControlName, regulatoryComplianceAssessmentName);
                ValidateRegulatoryComplianceAssessment(regulatoryComplianceAssessment);
            }
        }

        [Fact]
        public async Task RegulatoryComplianceAssessments_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var regulatoryComplianceAssessments = await securityCenterClient.RegulatoryComplianceAssessments.ListAsync(regulatoryComplianceStandardName, regulatoryComplianceControlName);
                ValidateRegulatoryComplianceAssessments(regulatoryComplianceAssessments);
            }
        }
        #endregion



        #region Validations

        private void ValidateRegulatoryComplianceAssessments(IPage<RegulatoryComplianceAssessment> regulatoryComplianceAssessments)
        {
            Assert.True(regulatoryComplianceAssessments.IsAny(), "Got empty list");

            regulatoryComplianceAssessments.ForEach(ValidateRegulatoryComplianceAssessment);
        }

        private void ValidateRegulatoryComplianceAssessment(RegulatoryComplianceAssessment regulatoryComplianceAssessment)
        {
            Assert.NotNull(regulatoryComplianceAssessment);
        }

        #endregion
    }
}