// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using SecurityInsights.Tests.Helpers;
using Xunit;

namespace SecurityInsights.Tests
{
    public class IncidentCommentsTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "6b1ceacd-5731-4780-8f96-2078dd96fd96";
        private static string ResourceGroup = "CXP-Nicholas";
        private static string WorkspaceName = "SecureScoreData-t4ah4xsttcevs";
        private static string IncidentId = "a0c942f3-d316-4af7-9c6b-90420f79d35e";
        private static string IncidentCommentId = "ecd61c6b-98a8-4dfe-bd24-7b7ad98d0522";
        private static string NewIncidentCommentId = Guid.NewGuid().ToString();
        
        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityInsightsClient GetSecurityInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
                TestEnvironment.SubscriptionId = SubscriptionId;
            }

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK, IsPassThrough = true };

            var SecurityInsightsClient = HttpMockServer.Mode == HttpRecorderMode.Record
                ? context.GetServiceClient<SecurityInsightsClient>(TestEnvironment, handlers: handler)
                : context.GetServiceClient<SecurityInsightsClient>(handlers: handler);

            return SecurityInsightsClient;
        }

        #endregion

        #region IncidentComments

        [Fact]
        public void IncidentComments_ListByIncident()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var incidentComments = SecurityInsightsClient.IncidentComments.ListByIncident(ResourceGroup, WorkspaceName, IncidentId);
                ValidateIncidentComments(incidentComments);
            }
        }

        [Fact]
        public void IncidentComments_CreateComment()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var incidentComment = SecurityInsightsClient.IncidentComments.CreateComment(ResourceGroup, WorkspaceName, IncidentId, NewIncidentCommentId, "sdk test comment");
                ValidateIncidentComment(incidentComment);
            }
        }

        [Fact]
        public void IncidentComments_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);

                var incidentComment = SecurityInsightsClient.IncidentComments.Get(ResourceGroup, WorkspaceName, IncidentId, IncidentCommentId);
                ValidateIncidentComment(incidentComment);

            }
        }

        #endregion

        #region Validations

        private void ValidateIncidentComments(IPage<IncidentComment> incidentComments)
        {
            Assert.True(incidentComments.IsAny());

            incidentComments.ForEach(ValidateIncidentComment);
        }

        private void ValidateIncidentComment(IncidentComment incidentComment)
        {
            Assert.NotNull(incidentComment);
        }

        #endregion
    }
}
