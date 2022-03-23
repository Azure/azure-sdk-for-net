// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class BookmarkRelationsTests : TestBase
    {
        #region Test setup

        #endregion

        #region BookmarkRelations

        [Fact]
        public void BookmarkRelations_List()
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
                    EventTime = DateTime.Now
                };
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);
                
                var BookmarkReltationName = Guid.NewGuid().ToString();
                var BookmarkRelation = SecurityInsightsClient.BookmarkRelations.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName, Incident.Id);

                var BookmarkRelations = SecurityInsightsClient.BookmarkRelations.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                ValidateBookmarkRelations(BookmarkRelations);

                SecurityInsightsClient.BookmarkRelations.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void BookmarkRelations_CreateorUpdate()
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
                    EventTime = DateTime.Now
                };
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);

                var BookmarkReltationName = Guid.NewGuid().ToString();
                var BookmarkRelation = SecurityInsightsClient.BookmarkRelations.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName, Incident.Id);
                ValidateBookmarkRelation(BookmarkRelation);

                SecurityInsightsClient.BookmarkRelations.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        [Fact]
        public void BookmarkRelations_Get()
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
                    EventTime = DateTime.Now
                };
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);

                var BookmarkReltationName = Guid.NewGuid().ToString();
                SecurityInsightsClient.BookmarkRelations.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName, Incident.Id);
                var BookmarkRelation = SecurityInsightsClient.BookmarkRelations.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName);
                ValidateBookmarkRelation(BookmarkRelation);

                SecurityInsightsClient.BookmarkRelations.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);

            }
        }

        [Fact]
        public void BookmarkRelations_Delete()
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
                    EventTime = DateTime.Now
                };
                SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);

                var BookmarkReltationName = Guid.NewGuid().ToString();
                SecurityInsightsClient.BookmarkRelations.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName, Incident.Id);
                SecurityInsightsClient.BookmarkRelations.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkReltationName);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                SecurityInsightsClient.Incidents.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, IncidentId);
            }
        }

        #endregion

        #region Validations

        private void ValidateBookmarkRelations(IPage<Relation> BookmarkRelation)
        {
            Assert.True(BookmarkRelation.IsAny());

            BookmarkRelation.ForEach(ValidateBookmarkRelation);
        }

        private void ValidateBookmarkRelation(Relation BookmarkRelation)
        {
            Assert.NotNull(BookmarkRelation);
        }

        #endregion
    }
}
