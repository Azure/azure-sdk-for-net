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

        private static string ResourceGroup = "ndicola-pfsense";
        private static string WorkspaceName = "ndicola-pfsense";

        public static TestEnvironment TestEnvironment { get; private set; }

        private static SecurityInsightsClient GetSecurityInsightsClient(MockContext context)
        {
            if (TestEnvironment == null && HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                TestEnvironment = TestEnvironmentFactory.GetTestEnvironment();
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
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(ResourceGroup, WorkspaceName, IncidentId, IncidentBody);
                var IncidentCommentId = Guid.NewGuid().ToString();
                SecurityInsightsClient.IncidentComments.CreateComment(ResourceGroup, WorkspaceName, IncidentId, IncidentCommentId, "sdk test comment");
                var incidentComments = SecurityInsightsClient.IncidentComments.ListByIncident(ResourceGroup, WorkspaceName, IncidentId);
                ValidateIncidentComments(incidentComments);
                SecurityInsightsClient.Incidents.Delete(ResourceGroup, WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void IncidentComments_CreateComment()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(ResourceGroup, WorkspaceName, IncidentId, IncidentBody);
                var IncidentCommentId = Guid.NewGuid().ToString();
                var incidentComment = SecurityInsightsClient.IncidentComments.CreateComment(ResourceGroup, WorkspaceName, IncidentId, IncidentCommentId, "sdk test comment");
                ValidateIncidentComment(incidentComment);
                SecurityInsightsClient.Incidents.Delete(ResourceGroup, WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void IncidentComments_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(ResourceGroup, WorkspaceName, IncidentId, IncidentBody);
                var IncidentCommentId = Guid.NewGuid().ToString();
                SecurityInsightsClient.IncidentComments.CreateComment(ResourceGroup, WorkspaceName, IncidentId, IncidentCommentId, "sdk test comment");
                var incidentComment = SecurityInsightsClient.IncidentComments.Get(ResourceGroup, WorkspaceName, IncidentId, IncidentCommentId);
                ValidateIncidentComment(incidentComment);
                SecurityInsightsClient.Incidents.Delete(ResourceGroup, WorkspaceName, IncidentId);

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
