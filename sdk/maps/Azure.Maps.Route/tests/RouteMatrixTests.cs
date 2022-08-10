// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using Azure.Maps.Route.Models;
using NUnit.Framework;

namespace Azure.Maps.Route.Tests
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
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791)
                }),
                Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
            };
            var result = await client.SyncRequestRouteMatrixAsync(routeMatrixQuery);

            Assert.AreEqual("0.0.1", result.Value.FormatVersion);
            Assert.AreEqual(2, result.Value.Matrix.Count);
            Assert.AreEqual(1, result.Value.Matrix[0].Count);
            Assert.AreEqual(2, result.Value.Summary.SuccessfulRoutes);
            Assert.AreEqual(2, result.Value.Summary.TotalRoutes);
        }

        [RecordedTest]
        public async Task CanSyncRequestRouteMatrixWithOptions()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791)
                }),
                Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
            };
            var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
            {
                WaitForResults = true,
                TravelTimeType = TravelTimeType.All,
            };

            var result = await client.SyncRequestRouteMatrixAsync(routeMatrixOptions);

            Assert.AreEqual("0.0.1", result.Value.FormatVersion);
            Assert.AreEqual(2, result.Value.Matrix.Count);
            Assert.AreEqual(1, result.Value.Matrix[0].Count);
            Assert.AreEqual(2, result.Value.Summary.SuccessfulRoutes);
            Assert.AreEqual(2, result.Value.Summary.TotalRoutes);
        }

        [RecordedTest]
        public void SyncRequestRouteMatrixError()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791)
                }),
                Destinations = new GeoPointCollection(new List<GeoPoint>() {}),
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.SyncRequestRouteMatrixAsync(routeMatrixQuery));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task CanStartRequestRouteMatrix()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791)
                }),
                Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767)}),
            };
            var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
            {
                TravelTimeType = TravelTimeType.All,
            };
            var operation = await client.StartRequestRouteMatrixAsync(routeMatrixOptions);
            // Sleep 400ms to wait for batch request to propagate
            Thread.Sleep(400);
            var result = operation.WaitForCompletion();

            Assert.AreEqual("0.0.1", result.Value.FormatVersion);
            Assert.AreEqual(2, result.Value.Matrix.Count);
            Assert.AreEqual(1, result.Value.Matrix[0].Count);
            Assert.AreEqual(2, result.Value.Summary.SuccessfulRoutes);
            Assert.AreEqual(2, result.Value.Summary.TotalRoutes);
        }

        [RecordedTest]
        public void StartRequestRouteMatrixError()
        {
            var client = CreateClient();
            var routeMatrixQuery = new RouteMatrixQuery
            {
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791)
                }),
                Destinations = new GeoPointCollection(new List<GeoPoint>() {}),
            };
            var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
            {
                TravelTimeType = TravelTimeType.All,
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRequestRouteMatrixAsync(routeMatrixOptions));
            Assert.AreEqual(400, ex.Status);
        }
    }
}
