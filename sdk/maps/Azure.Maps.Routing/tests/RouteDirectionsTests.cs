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

            Assert.That(result.Value.FormatVersion, Is.EqualTo("0.0.12"));
            Assert.That(result.Value.Routes.Count, Is.EqualTo(1));
            Assert.That(result.Value.Routes[0].Summary.LengthInMeters, Is.EqualTo(14128));
            Assert.That(result.Value.Routes[0].Summary.TravelTimeInSeconds, Is.EqualTo(1404));
            Assert.That(result.Value.Routes[0].Sections.Count, Is.EqualTo(1));
            Assert.That(result.Value.OptimizedWaypoints.Count, Is.EqualTo(0));
            Assert.That(result.Value.Report, Is.Null);
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

            Assert.That(result.Value.Results.Count, Is.EqualTo(2));
            Assert.That(result.Value.Results[0].Routes.Count, Is.EqualTo(1));
            Assert.That(result.Value.Results[1].Routes.Count, Is.EqualTo(1));
            Assert.That(result.Value.Results[0].Routes[0].Summary.LengthInMeters, Is.EqualTo(14128));
            Assert.That(result.Value.Results[0].Routes[0].Summary.TravelTimeInSeconds, Is.EqualTo(2549));
            Assert.That(result.Value.Results[0].Routes[0].Legs.Count, Is.EqualTo(2));
        }

        [RecordedTest]
        public void GetDirectionsImmediateBatchError()
        {
            var client = CreateClient();
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetDirectionsImmediateBatchAsync(queries));
            Assert.That(ex.Status, Is.EqualTo(400));
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

            Assert.That(result.Value.Results.Count, Is.EqualTo(2));
            Assert.That(result.Value.Results[0].Routes[0].Summary.LengthInMeters, Is.EqualTo(14128));
            Assert.That(result.Value.Results[0].Routes[0].Summary.TravelTimeInSeconds, Is.EqualTo(2549));
            Assert.That(result.Value.Results[0].Routes[0].Legs.Count, Is.EqualTo(2));
        }
    }
}
