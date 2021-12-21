// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
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
    public class IncidentRelationsTests : TestBase
    {
        #region Test setup

        #endregion

        #region IncidentRelations

        [Fact]
        public void IncidentRelations_List()
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
                var Incident = SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);

                var Labels = new List<string>();
                var BookmarkId = Guid.NewGuid().ToString();
                var BookmarkBody = new Bookmark()
                {
                    DisplayName = "SDKTestBookmark",
                    Query = "SecurityEvent | take 10",
                    Labels = Labels,
                    EventTime = DateTime.Now,
                };
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);
                
                var IncidentReltationName = Guid.NewGuid().ToString();
                var IncidentRelation = SecurityInsightsClient.IncidentRelations.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentReltationName, Bookmark.Id);
                
                var IncidentRelations = SecurityInsightsClient.IncidentRelations.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
                ValidateIncidentRelations(IncidentRelations);

                SecurityInsightsClient.IncidentRelations.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentReltationName);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void IncidentRelations_CreateorUpdate()
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
                var Incident = SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);

                var Labels = new List<string>();
                var BookmarkId = Guid.NewGuid().ToString();
                var BookmarkBody = new Bookmark()
                {
                    DisplayName = "SDKTestBookmark",
                    Query = "SecurityEvent | take 10",
                    Labels = Labels,
                    EventTime = DateTime.Now,
                };
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);

                var IncidentReltationName = Guid.NewGuid().ToString();
                var IncidentRelation = SecurityInsightsClient.IncidentRelations.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentReltationName, Bookmark.Id);
                ValidateIncidentRelation(IncidentRelation);

                SecurityInsightsClient.IncidentRelations.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentReltationName);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void IncidentRelations_Get()
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
                var Incident = SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);

                var Labels = new List<string>();
                var BookmarkId = Guid.NewGuid().ToString();
                var BookmarkBody = new Bookmark()
                {
                    DisplayName = "SDKTestBookmark",
                    Query = "SecurityEvent | take 10",
                    Labels = Labels,
                    EventTime = DateTime.Now,
                };
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);

                var IncidentReltationName = Guid.NewGuid().ToString();
                SecurityInsightsClient.IncidentRelations.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentReltationName, Bookmark.Id);
                var IncidentRelation = SecurityInsightsClient.IncidentRelations.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentReltationName);
                ValidateIncidentRelation(IncidentRelation);

                SecurityInsightsClient.IncidentRelations.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentReltationName);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);

            }
        }

        [Fact]
        public void IncidentRelations_Delete()
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
                var Incident = SecurityInsightsClient.Incidents.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentBody);

                var Labels = new List<string>();
                var BookmarkId = Guid.NewGuid().ToString();
                var BookmarkBody = new Bookmark()
                {
                    DisplayName = "SDKTestBookmark",
                    Query = "SecurityEvent | take 10",
                    Labels = Labels,
                    EventTime = DateTime.Now,
                };
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);

                var IncidentRelationName = Guid.NewGuid().ToString();
                SecurityInsightsClient.IncidentRelations.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentRelationName, Bookmark.Id);
                SecurityInsightsClient.IncidentRelations.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId, IncidentRelationName);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        #endregion

        #region Validations

        private void ValidateIncidentRelations(IPage<Relation> IncidentRelation)
        {
            Assert.True(IncidentRelation.IsAny());

            IncidentRelation.ForEach(ValidateIncidentRelation);
        }

        private void ValidateIncidentRelation(Relation IncidentRelation)
        {
            Assert.NotNull(IncidentRelation);
        }

        #endregion
    }
}
