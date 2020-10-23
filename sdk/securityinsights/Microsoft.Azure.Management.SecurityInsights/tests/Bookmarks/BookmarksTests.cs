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
    public class BookmarksTests : TestBase
    {
        #region Test setup

        private static string SubscriptionId = "6b1ceacd-5731-4780-8f96-2078dd96fd96";
        private static string ResourceGroup = "CXP-Nicholas";
        private static string WorkspaceName = "SecureScoreData-t4ah4xsttcevs";
        private static string BookmarkId = Guid.NewGuid().ToString();
        private static string BookmarkId2 = "f7579d0c-ecd4-4c04-851d-30629979febd";
        private static string ObjectId = "f7579d0c-ecd4-4c04-851d-30629979febd";

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

        #region Bookmarks

        [Fact]
        public void Bookmarks_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var Bookmarks = SecurityInsightsClient.Bookmarks.List(ResourceGroup, WorkspaceName);
                ValidateBookmarks(Bookmarks);
            }
        }

        [Fact]
        public void Bookmarks_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                var UserInfo = new UserInfo()
                {
                    ObjectId = Guid.Parse(ObjectId)
                };
                var BookmarkBody = new Bookmark()
                {
                    DisplayName = "SDKTestBookmark",
                    Query = "SecurityEvent | take 10"
                };

                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(ResourceGroup, WorkspaceName, BookmarkId, BookmarkBody);
                ValidateBookmark(Bookmark);
            }
        }

        [Fact]
        public void Bookmarks_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);

                var Bookmark = SecurityInsightsClient.Bookmarks.Get(ResourceGroup, WorkspaceName, BookmarkId2);
                ValidateBookmark(Bookmark);

            }
        }

        [Fact]
        public void Bookmarks_Delete()
        {
            Thread.Sleep(5000);
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = GetSecurityInsightsClient(context);
                SecurityInsightsClient.Bookmarks.Delete(ResourceGroup, WorkspaceName, BookmarkId);
            }
        }

        #endregion

        #region Validations

        private void ValidateBookmarks(IPage<Bookmark> Bookmarkpage)
        {
            Assert.True(Bookmarkpage.IsAny());

            Bookmarkpage.ForEach(ValidateBookmark);
        }

        private void ValidateBookmark(Bookmark Bookmark)
        {
            Assert.NotNull(Bookmark);
        }

        #endregion
    }
}
