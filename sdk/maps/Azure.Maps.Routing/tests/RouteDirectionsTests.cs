// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Routing.Tests
{
    public class RouteDirectionsTests : RouteClientLiveTestsBase
    {
        public RouteDirectionsTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanGetRouteDirection()
        {
            var client = CreateClient();
            var routePoints = new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.791, 45.96875), new GeoPosition(123.767, 45.90625) };
            var query = new RouteDirectionQuery(routePoints);
            var result = await client.GetDirectionsAsync(query);

            Assert.AreEqual("0.0.12", result.Value.FormatVersion);
            Assert.AreEqual(1, result.Value.Routes.Count);
            Assert.AreEqual(14128, result.Value.Routes[0].Summary.LengthInMeters);
            Assert.AreEqual(1404, result.Value.Routes[0].Summary.TravelTimeInSeconds);
            Assert.AreEqual(1, result.Value.Routes[0].Sections.Count);
            Assert.AreEqual(0, result.Value.OptimizedWaypoints.Count);
            Assert.IsNull(result.Value.Report);
        }

        [RecordedTest]
        public async Task CanGetDirectionsImmediateBatch()
        {
            var client = CreateClient();
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();
            queries.Add(new RouteDirectionQuery(
                new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.791, 45.96875), new GeoPosition(123.767, 45.90625) },
                new RouteDirectionOptions()
                {
                    TravelMode = TravelMode.Bicycle,
                    RouteType = RouteType.Economy,
                    UseTrafficData = false,
                })
            );
            queries.Add(new RouteDirectionQuery(new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.767, 45.90625) }));
            var result = await client.GetDirectionsImmediateBatchAsync(queries);

            Assert.AreEqual(2, result.Value.Results.Count);
            Assert.AreEqual(1, result.Value.Results[0].Routes.Count);
            Assert.AreEqual(1, result.Value.Results[1].Routes.Count);
            Assert.AreEqual(14128, result.Value.Results[0].Routes[0].Summary.LengthInMeters);
            Assert.AreEqual(2549, result.Value.Results[0].Routes[0].Summary.TravelTimeInSeconds);
            Assert.AreEqual(2, result.Value.Results[0].Routes[0].Legs.Count);
        }

        [RecordedTest]
        public void GetDirectionsImmediateBatchError()
        {
            var client = CreateClient();
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetDirectionsImmediateBatchAsync(queries));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task CanRequestRouteDirectionsBatch()
        {
            var client = CreateClient();
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();
            queries.Add(new RouteDirectionQuery(
                new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.791, 45.96875), new GeoPosition(123.767, 45.90625) },
                new RouteDirectionOptions()
                {
                    TravelMode = TravelMode.Bicycle,
                    RouteType = RouteType.Economy,
                    UseTrafficData = false,
                })
            );
            queries.Add(new RouteDirectionQuery(new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.767, 45.90625) }));

            var operation = await client.GetDirectionsBatchAsync(WaitUntil.Completed, queries);
            var result = operation.WaitForCompletion();

            Assert.AreEqual(2, result.Value.Results.Count);
            Assert.AreEqual(14128, result.Value.Results[0].Routes[0].Summary.LengthInMeters);
            Assert.AreEqual(2549, result.Value.Results[0].Routes[0].Summary.TravelTimeInSeconds);
            Assert.AreEqual(2, result.Value.Results[0].Routes[0].Legs.Count);
        }
    }
}
