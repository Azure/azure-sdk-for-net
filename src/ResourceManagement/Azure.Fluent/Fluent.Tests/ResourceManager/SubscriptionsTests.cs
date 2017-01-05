// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
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
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var authenticated = TestHelper.Authenticate(context);
                var subscriptions = authenticated.Subscriptions.List();
                Assert.True(subscriptions.Count > 0);
            }
        }

        [Fact]
        public void CanListLocations()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var authenticated = TestHelper.Authenticate(context);
                var subscription = authenticated.Subscriptions.List().First();
                // TODO - ans - Method below throws exception as the method is not implemented.
                //var locations = subscription.ListLocations();
                //Assert.True(locations.Count > 0);
            }
        }
    }
}