// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Routing.Tests
{
    public class RouteMatrixTests : RouteClientLiveTestsBase
    {
        public RouteMatrixTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanSyncRequestRouteMatrix()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875)
                },
                Destinations = new List<GeoPosition>()
                {
                    new GeoPosition(1, 13.5471),
                    new GeoPosition(123.767, 45.90625),
                },
            };
            var result = await client.GetImmediateRouteMatrixAsync(routeMatrixQuery);

            Assert.Multiple(() =>
            {
                Assert.That(result.Value.FormatVersion, Is.EqualTo("0.0.1"));
                Assert.That(result.Value.Matrix, Has.Count.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(result.Value.Matrix[0], Has.Count.EqualTo(2));
                Assert.That(result.Value.Summary.SuccessfulRoutes, Is.EqualTo(2));
                Assert.That(result.Value.Summary.TotalRoutes, Is.EqualTo(4));
            });
        }

        [RecordedTest]
        public async Task CanSyncRequestRouteMatrixWithOptions()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875)
                },
                Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625) },
            };
            var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
            {
                TravelTimeType = TravelTimeType.All,
            };

            var result = await client.GetImmediateRouteMatrixAsync(routeMatrixOptions);

            Assert.Multiple(() =>
            {
                Assert.That(result.Value.FormatVersion, Is.EqualTo("0.0.1"));
                Assert.That(result.Value.Matrix, Has.Count.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(result.Value.Matrix[0], Has.Count.EqualTo(1));
                Assert.That(result.Value.Summary.SuccessfulRoutes, Is.EqualTo(2));
                Assert.That(result.Value.Summary.TotalRoutes, Is.EqualTo(2));
            });
        }

        [RecordedTest]
        public void SyncRequestRouteMatrixError()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(45.9375, 123.751),
                    new GeoPosition(45.96875, 123.791)
                },
                Destinations = new List<GeoPosition>(),
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetImmediateRouteMatrixAsync(routeMatrixQuery));
            Assert.That(ex.Status, Is.EqualTo(400));
        }

        [RecordedTest]
        public async Task CanRequestRouteMatrix()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875)
                },
                Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625)},
            };
            var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
            {
                TravelTimeType = TravelTimeType.All,
            };
            var operation = await client.GetRouteMatrixAsync(WaitUntil.Started, routeMatrixOptions);
            // Sleep 400ms to wait for batch request to propagate
            Thread.Sleep(400);
            var result = operation.WaitForCompletion();

            Assert.Multiple(() =>
            {
                Assert.That(result.Value.FormatVersion, Is.EqualTo("0.0.1"));
                Assert.That(result.Value.Matrix, Has.Count.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(result.Value.Matrix[0], Has.Count.EqualTo(1));
                Assert.That(result.Value.Summary.SuccessfulRoutes, Is.EqualTo(2));
                Assert.That(result.Value.Summary.TotalRoutes, Is.EqualTo(2));
            });
        }

        [RecordedTest]
        public void RequestRouteMatrixError()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875)
                },
                Destinations = new List<GeoPosition>() {},
            };
            var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
            {
                TravelTimeType = TravelTimeType.All,
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetRouteMatrixAsync(WaitUntil.Started, routeMatrixOptions));
            Assert.That(ex.Status, Is.EqualTo(400));
        }
    }
}
