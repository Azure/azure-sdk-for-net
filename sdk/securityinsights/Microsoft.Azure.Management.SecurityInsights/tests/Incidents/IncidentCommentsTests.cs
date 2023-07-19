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
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class IncidentCommentsTests : TestBase
    {
        #region Test setup

        #endregion

        #region IncidentComments

        [Fact]
        public void IncidentComments_ListByIncident()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                var IncidentCommentId = Guid.NewGuid().ToString();
                SecurityInsightsClient.IncidentComments.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentCommentId, "sdk test comment");
                var incidentComments = SecurityInsightsClient.IncidentComments.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
                ValidateIncidentComments(incidentComments);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void IncidentComments_CreateComment()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                var IncidentCommentId = Guid.NewGuid().ToString();
                var incidentComment = SecurityInsightsClient.IncidentComments.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentCommentId, "sdk test comment");
                ValidateIncidentComment(incidentComment);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void IncidentComments_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var IncidentId = Guid.NewGuid().ToString();
                var IncidentBody = new Incident()
                {
                    Title = "SDKCreateIncidentTest",
                    Status = "Active",
                    Severity = "Low"
                };

                SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);
                var IncidentCommentId = Guid.NewGuid().ToString();
                SecurityInsightsClient.IncidentComments.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentCommentId, "sdk test comment");
                var incidentComment = SecurityInsightsClient.IncidentComments.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentCommentId);
                ValidateIncidentComment(incidentComment);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);

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
