// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class BookmarksTests : TestBase
    {
        #region Test setup

        #endregion

        #region Bookmarks

        [Fact]
        public void Bookmarks_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var BookmarkId = Guid.NewGuid().ToString();
                var BookmarkBody = BookmarksUtils.GetDefaultBookmarkProperties();
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);

                var Bookmarks = SecurityInsightsClient.Bookmarks.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateBookmarks(Bookmarks);

                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
            }
        }

        [Fact]
        public void Bookmarks_CreateorUpdate()
        {
            
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var BookmarkId = Guid.NewGuid().ToString();
                var BookmarkBody = BookmarksUtils.GetDefaultBookmarkProperties();
                var Bookmark = SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);
                ValidateBookmark(Bookmark);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
            }
        }

        [Fact]
        public void Bookmarks_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var BookmarkId = Guid.NewGuid().ToString();
                var BookmarkBody = BookmarksUtils.GetDefaultBookmarkProperties();
                SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);
                var Bookmark = SecurityInsightsClient.Bookmarks.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
                ValidateBookmark(Bookmark);

            }
        }

        [Fact]
        public void Bookmarks_Delete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var BookmarkId = Guid.NewGuid().ToString();
                var BookmarkBody = BookmarksUtils.GetDefaultBookmarkProperties();
                SecurityInsightsClient.Bookmarks.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId, BookmarkBody);
                SecurityInsightsClient.Bookmarks.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, BookmarkId);
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

        private void ValidateBookmarkExpand(BookmarkExpandResponse BookmarkExpand)
        {
            Assert.NotNull(BookmarkExpand);
        }

        #endregion
    }
}
