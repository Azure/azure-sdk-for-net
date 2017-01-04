// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using System.Linq;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class SubscriptionsTests
    {
        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanListSubscriptions()
        {
            var authenticated = TestHelper.Authenticate();
            var subscriptions = authenticated.Subscriptions.List();
            Assert.True(subscriptions.Count > 0);
        }

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanListLocations()
        {
            var authenticated = TestHelper.Authenticate();
            var subscription = authenticated.Subscriptions.List().First();
            var locations = subscription.ListLocations();
            Assert.True(locations.Count > 0);
        }
    }
}
