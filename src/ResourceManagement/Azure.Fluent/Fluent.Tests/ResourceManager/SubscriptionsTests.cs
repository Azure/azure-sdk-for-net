// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class SubscriptionsTests
    {
        [Fact]
        public void CanListSubscriptions()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                Assert.True(0 < azure.Subscriptions.List().Count);
                var subscription = azure.GetCurrentSubscription();
                Assert.NotNull(subscription);
                Assert.Equal(subscription.SubscriptionId.ToLowerInvariant(), azure.SubscriptionId.ToLowerInvariant());
            }
        }

        [Fact]
        public void CanListLocations()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var azure = TestHelper.CreateRollupClient();
                var subscription = azure.GetCurrentSubscription();
                Assert.NotNull(subscription);

                var locations = subscription.ListLocations();
                Assert.True(locations.Count > 0);

                foreach (var location in locations)
                {
                    Region region = Region.Create(location.Name);
                    Assert.NotNull(region);
                    Assert.Equal(region, location.Region);
                    Assert.Equal(region.Name.ToLowerInvariant(), location.Name.ToLowerInvariant());
                }

                var uswest = subscription.GetLocationByRegion(Region.USWest);
                Assert.NotNull(uswest);
                Assert.Equal(Region.USWest.Name.ToLowerInvariant(), uswest.Name);
            }
        }
    }
}