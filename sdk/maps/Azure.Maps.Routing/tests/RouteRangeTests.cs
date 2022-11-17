// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Routing.Tests
{
    public class RouteRangeTests : RouteClientLiveTestsBase
    {
        public RouteRangeTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetRouteRange()
        {
            var client = CreateClient();
            // The route range within
            var options = new RouteRangeOptions(123.75, 46)
            {
                TimeBudget = new TimeSpan(0, 20, 0)
            };
            var result = await client.GetRouteRangeAsync(options);

            Assert.AreEqual("0.0.1", result.Value.FormatVersion);
            Assert.IsNotNull(result.Value.ReachableRange.Center);
            Assert.AreEqual(50, result.Value.ReachableRange.Boundary.Count);
        }

        [RecordedTest]
        public void CanGetRouteRangeError()
        {
            var client = CreateClient();
            var options = new RouteRangeOptions(123.75, 46);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetRouteRangeAsync(options));
            Assert.AreEqual(400, ex.Status);
        }
    }
}
