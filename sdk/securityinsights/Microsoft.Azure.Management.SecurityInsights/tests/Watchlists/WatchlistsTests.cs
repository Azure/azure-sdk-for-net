// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class WatchlistsTests : TestBase
    {
        #region Test setup

        #endregion

        #region Watchlists

        [Fact]
        public void Watchlists_List()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var WatchlistId = Guid.NewGuid().ToString();
                var WatchlistProperties = new Watchlist()
                {
                    DisplayName = "SDK Test",
                    Provider = "SDK Test",
                    Source = "sdktest",
                    ItemsSearchKey = "ipaddress"
                };

                var Watchlist = SecurityInsightsClient.Watchlists.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistProperties);
                
                var Watchlists = SecurityInsightsClient.Watchlists.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName);
                ValidateWatchlists(Watchlists);
                SecurityInsightsClient.Watchlists.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId);

            }
        }

        [Fact]
        public void Watchlists_CreateorUpdate()
        {

            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var WatchlistId = Guid.NewGuid().ToString();
                var WatchlistProperties = new Watchlist()
                {
                    DisplayName = "SDK Test",
                    Provider = "SDK Test",
                    Source = "sdktest",
                    ItemsSearchKey = "ipaddress"
                };

                var Watchlist = SecurityInsightsClient.Watchlists.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistProperties);
                ValidateWatchlist(Watchlist);
                SecurityInsightsClient.Watchlists.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId);
            }
        }

        [Fact]
        public void Watchlists_Get()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var WatchlistId = Guid.NewGuid().ToString();
                var WatchlistProperties = new Watchlist()
                {
                    DisplayName = "SDK Test",
                    Provider = "SDK Test",
                    Source = "sdktest",
                    ItemsSearchKey = "ipaddress"
                };

                SecurityInsightsClient.Watchlists.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistProperties);
                var Watchlist = SecurityInsightsClient.Watchlists.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId);
                ValidateWatchlist(Watchlist);
                SecurityInsightsClient.Watchlists.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId);
            }
        }

            [Fact]
            public void Watchlists_Delete()
            {
                using (var context = MockContext.Start(this.GetType()))
                {
                    var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                    var WatchlistId = Guid.NewGuid().ToString();
                    var WatchlistProperties = new Watchlist()
                    {
                        DisplayName = "SDK Test",
                        Provider = "SDK Test",
                        Source = "sdktest",
                        ItemsSearchKey = "ipaddress"
                    };

                    var Watchlist = SecurityInsightsClient.Watchlists.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistProperties);
                    SecurityInsightsClient.Watchlists.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId);
                }
            }

            #endregion

            #region Validations

            private void ValidateWatchlists(IPage<Watchlist> WatchlistPage)
            {
                Assert.True(WatchlistPage.IsAny());

                WatchlistPage.ForEach(ValidateWatchlist);
            }

            private void ValidateWatchlist(Watchlist Watchlist)
            {
                Assert.NotNull(Watchlist);
            }

            #endregion
        }
    }
