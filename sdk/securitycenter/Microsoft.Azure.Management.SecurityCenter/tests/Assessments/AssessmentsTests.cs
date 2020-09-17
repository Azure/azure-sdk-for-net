// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Security;
using Microsoft.Azure.Management.Security.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityCenter.Tests.Helpers;
using System.Net;
using Xunit;

namespace SecurityCenter.Tests
{
    public class AssessmentsTests : TestBase
    {
        #region Test setup
        private static readonly string SubscriptionId = "487bb485-b5b0-471e-9c0d-10717612f869";
        private static readonly string ResourceGroupName = "myService1";
        private static readonly string VirtualMachineName = "syslogmyservice1vm";
        // Adaptive Network Hardening recommendations should be applied on internet facing virtual machines
        private static readonly string AssessmentName = "f9f0eed0-f143-47bf-b856-671ea2eeed62";
        
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
        public void Assessments_ListAll()
        {
            string scope = $"subscriptions/{SubscriptionId}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.Assessments.List(scope);
                Validate(ret);
            }
        }

        [Fact]
        public void Assessments_Get()
        {
            string scope = $"subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/virtualMachines/{VirtualMachineName}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.Assessments.Get(scope, AssessmentName);
                Assert.NotNull(ret);
            }
        }

        [Fact]
        public void Assessments_Get_ExpandMetadata()
        {
            string scope = $"subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/virtualMachines/{VirtualMachineName}";

            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.Assessments.Get(scope, AssessmentName, expand: "metadata");
                Assert.NotNull(ret.Metadata);
            }
        }

        #endregion

        #region Validations
        private static void Validate(IPage<SecurityAssessment> ret)
        {
            Assert.True(ret.IsAny(), "Got empty list");
            foreach (var item in ret)
            {
                Assert.NotNull(item);
            }
        }
        #endregion
    }
}
