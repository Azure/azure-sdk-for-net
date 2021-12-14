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
    public class WatchlistItemsTests : TestBase
    {
        #region Test setup

        #endregion

        #region WatchlistItems

        [Fact]
        public void WatchlistItems_List()
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

                var WatchlistItemId = Guid.NewGuid().ToString();
                IDictionary<string, string> d = new Dictionary<string, string>();
                d.Add("ipaddress", "1.1.1.2");
                var WatchlistItemProperties = new WatchlistItem()
                { 
                    ItemsKeyValue = d
                };
                SecurityInsightsClient.WatchlistItems.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistItemId, WatchlistItemProperties);

                var WatchlistItems = SecurityInsightsClient.WatchlistItems.List(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId);
                ValidateWatchlistItems(WatchlistItems);
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
                SecurityInsightsClient.Watchlists.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistProperties);

                var WatchlistItemId = Guid.NewGuid().ToString();
                IDictionary<string, string> d = new Dictionary<string, string>();
                d.Add("ipaddress", "1.1.1.2");
                var WatchlistItemProperties = new WatchlistItem()
                {
                    ItemsKeyValue = d
                };
                
                var WatchlistItem = SecurityInsightsClient.WatchlistItems.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistItemId, WatchlistItemProperties);
                ValidateWatchlistItem(WatchlistItem);
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

                var WatchlistItemId = Guid.NewGuid().ToString();
                IDictionary<string, string> d = new Dictionary<string, string>();
                d.Add("ipaddress", "1.1.1.2");
                var WatchlistItemProperties = new WatchlistItem()
                {
                    ItemsKeyValue = d
                };
                SecurityInsightsClient.WatchlistItems.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistItemId, WatchlistItemProperties);
                
                var WatchlistItem = SecurityInsightsClient.WatchlistItems.Get(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistItemId);
                ValidateWatchlistItem(WatchlistItem);
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
                    SecurityInsightsClient.Watchlists.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistProperties);

                    var WatchlistItemId = Guid.NewGuid().ToString();
                    IDictionary<string, string> d = new Dictionary<string, string>();
                    d.Add("ipaddress", "1.1.1.2");
                    var WatchlistItemProperties = new WatchlistItem()
                    {
                        ItemsKeyValue = d
                    };
                    SecurityInsightsClient.WatchlistItems.CreateOrUpdate(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistItemId, WatchlistItemProperties);
                    SecurityInsightsClient.WatchlistItems.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId, WatchlistItemId);
                    SecurityInsightsClient.Watchlists.Delete(TestHelper.ResourceGroup, TestHelper.WorkspaceName, WatchlistId);
                }
            }

            #endregion

            #region Validations

            private void ValidateWatchlistItems(IPage<WatchlistItem> WatchlistItems)
            {
                Assert.True(WatchlistItems.IsAny());

                WatchlistItems.ForEach(ValidateWatchlistItem);
            }

            private void ValidateWatchlistItem(WatchlistItem WatchlistItem)
            {
                Assert.NotNull(WatchlistItem);
            }

            #endregion
        }
    }
