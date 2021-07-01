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
    public class IotSecuritySolutionsAnalyticsRecommendationTests : TestBase
    {
        #region Test setup

        private static readonly string SubscriptionId = "075423e9-7d33-4166-8bdf-3920b04e3735";
        private static readonly string AggregatedRecommendationName = "IoT_OpenPorts";
        private static readonly string ResourceGroupName = "ResourceGroup-CUS";
        private static readonly string SolutionName = "IotHub-CUS";
        private static readonly string AscLocation = "centralus";
        private static TestEnvironment TestEnvironment { get; set; }

        private static SecurityCenterClient GetSecurityCenterClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                TestEnvironment.SubscriptionId = SubscriptionId;
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
        public void IotSecuritySolutionsAnalyticsRecommendation_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                var ret = securityCenterClient.IotSecuritySolutionsAnalyticsRecommendation.Get(ResourceGroupName, SolutionName, AggregatedRecommendationName);
                Assert.NotNull(ret);
            }
        }

        [Fact]
        public void IotSecuritySolutionsAnalyticsRecommendation_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var securityCenterClient = GetSecurityCenterClient(context);
                securityCenterClient.SubscriptionId = SubscriptionId;

                var ret = securityCenterClient.IotSecuritySolutionsAnalyticsRecommendation.List(ResourceGroupName, SolutionName);
                Validate(ret);
            }
        }
        #endregion

        #region Validations
        private static void Validate(IPage<IoTSecurityAggregatedRecommendation> ret)
        {
            Assert.True(ret.IsAny());
            foreach (var item in ret)
            {
                Assert.NotNull(item);
            }
        }
        #endregion
    }
}
