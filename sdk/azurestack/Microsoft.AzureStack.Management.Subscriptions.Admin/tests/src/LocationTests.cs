// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

using Microsoft.AzureStack.Management.Subscriptions.Admin;
using Microsoft.AzureStack.Management.Subscriptions.Admin.Models;
using System.Linq;
using Xunit;

namespace Subscriptions.Tests
{
    public class LocationTests : SubscriptionsTestBase
    {

        private void ValidateLocation(Location item) {
            // Location
            Assert.NotNull(item);
            Assert.NotNull(item.Id);
            Assert.NotNull(item.Name);
            Assert.NotNull(item.DisplayName);
        }

        private void AssertSame(Location expected, Location given) {
            // Location
            Assert.Equal(expected.Id, given.Id);
            Assert.Equal(expected.Name, given.Name);
            Assert.Equal(expected.DisplayName, given.DisplayName);
            Assert.Equal(expected.Latitude, given.Latitude);
            Assert.Equal(expected.Longitude, given.Longitude);
        }

        [Fact]
        public void TestListLocations()
        {
            RunTest((client) =>
            {
                var locations = client.Locations.List();
                locations.ForEach(ValidateLocation);
            });
        }

        [Fact]
        public void TestGetAllLocations()
        {
            RunTest((client) =>
            {
                var locations = client.Locations.List();
                locations.ForEach((loc) =>
                {
                    var result = client.Locations.Get(loc.Name);
                    AssertSame(loc, result);
                });
            });
        }

        [Fact]
        public void TestGetLocation()
        {
            RunTest((client) =>
            {
                var loc = client.Locations.List().First();
                var result = client.Locations.Get(loc.Name);
                AssertSame(loc, result);
            });
        }
    }
}
