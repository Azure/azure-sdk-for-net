// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
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
    public class IotSecuritySolutionsAnalyticsAggregatedAlertTests : TestBase
    {
        #region Test setup

        private static readonly string AggregatedAlertName = "IoT_SuspiciousUseradd/2019-09-15";
        private static readonly string ResourceGroupName = "ResourceGroup-CUS";
        private static readonly string SolutionName = "IotHub-CUS";
        private static readonly string AscLocation = "centralus";
        private static TestEnvironment TestEnvironment { get; set; }

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

        #endregion

        #region Tests

        [Fact]
        public void IotSecuritySolutionsAnalyticsAggregatedAlert_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.Get(ResourceGroupName, SolutionName, AggregatedAlertName);
                Assert.NotNull(ret);
            }
        }

        [Fact]
        public void IotSecuritySolutionsAnalyticsAggregatedAlert_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.List(ResourceGroupName, SolutionName);
                Validate(ret);
            }
        }

        [Fact]
        public void IotSecuritySolutionsAnalyticsAggregatedAlert_Dismiss()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.IotSecuritySolutionsAnalyticsAggregatedAlert.Dismiss(ResourceGroupName, SolutionName, AggregatedAlertName);
            }
        }

        #endregion

        #region Validations
        private static void Validate(IPage<IoTSecurityAggregatedAlert> ret)
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
