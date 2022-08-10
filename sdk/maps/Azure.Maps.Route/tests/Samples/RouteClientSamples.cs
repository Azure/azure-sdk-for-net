// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
#region Snippet:RouteImportNamespace
using Azure.Core.GeoJson;
using Azure.Maps.Route;
using Azure.Maps.Route.Models;
#endregion
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Maps.Route.Tests
{
    public class RouteClientSamples : SamplesBase<RouteClientTestEnvironment>
    {
        public void RouteClientViaAAD()
        {
            #region Snippet:InstantiateRouteClientViaAAD
            // Create a MapsRouteClient that will authenticate through Active Directory
            var credential = new DefaultAzureCredential();
            var clientId = "<My Map Account Client Id>";
            MapsRouteClient client = new MapsRouteClient(credential, clientId);
            #endregion
        }

        public void RouteClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateRouteClientViaSubscriptionKey
            // Create a MapsRouteClient that will authenticate through Subscription Key (Shared key)
            var credential = new AzureKeyCredential("<My Subscription Key>");
            MapsRouteClient client = new MapsRouteClient(credential);
            #endregion
        }

        [Test]
        public void GetRouteDirections()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:GetDirections
            // Create origin and destination routing points
            var routePoints = new List<GeoPosition>() {
                new GeoPosition(123.751, 45.9375),
                new GeoPosition(123.791, 45.96875),
                new GeoPosition(123.767, 45.90625)
            };

            // Create Route direction query object
            var query = new RouteDirectionQuery(routePoints);
            var result = client.GetDirections(query);

            // Route direction result
            Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
            Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
            Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeInSeconds);

            // Route points
            foreach (var leg in result.Value.Routes[0].Legs)
            {
                Console.WriteLine("Route path:");
                foreach (var point in leg.Points)
                {
                    Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
                }
            }
            #endregion

            Assert.IsTrue(result.Value.Routes.Count > 0);
        }

        [Test]
        public void GetRouteDirectionsWithOptions()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:RouteDirectionsWithOptions
            // Create origin and destination routing points
            var routePoints = new List<GeoPosition>() {
                new GeoPosition(123.751, 45.9375),
                new GeoPosition(123.791, 45.96875),
                new GeoPosition(123.767, 45.90625)
            };

            var options = new RouteDirectionOptions()
            {
                RouteType = RouteType.Fastest,
                UseTrafficData = true,
                TravelMode = TravelMode.Bicycle,
                Language = "en-US",
            };

            // Create Route direction query object
            var query = new RouteDirectionQuery(routePoints);
            var result = client.GetDirections(query);

            // Route direction result
            Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
            Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
            Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeInSeconds);

            // Route points
            foreach (var leg in result.Value.Routes[0].Legs)
            {
                Console.WriteLine("Route path:");
                foreach (var point in leg.Points)
                {
                    Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
                }
            }
            #endregion

            Assert.IsTrue(result.Value.Routes.Count > 0);
        }

        [Test]
        public void GetRouteDirectionsError()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:CatchRouteException
            try
            {
                // An empty route points list
                var routePoints = new List<GeoPosition>() { };
                var query = new RouteDirectionQuery(routePoints);

                var result = client.GetDirections(query);
                // Do something with result ...
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        public void SyncRequestRouteDirectionsBatch()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:SyncRequestRouteDirectionsBatch
            // Create a list of route direction queries
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

            queries.Add(new RouteDirectionQuery(
                new List<GeoPosition>() {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875),
                    new GeoPosition(123.767, 45.90625)
                },
                new RouteDirectionOptions()
                {
                    TravelMode = TravelMode.Bicycle,
                    RouteType = RouteType.Economy,
                    UseTrafficData = false,
                })
            );
            queries.Add(new RouteDirectionQuery(new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.767, 45.90625) }));

            // Call synchronous route direction batch request
            var response = client.SyncRequestRouteDirectionsBatch(queries);
            #endregion

            #region Snippet:RouteDirectionsBatchResult
            for (int i = 0; i < response.Value.Results.Count; i++)
            {
                var result = response.Value.Results[i];
                Console.WriteLine($"Batch item result {0}:", i);

                foreach (var route in result.Routes)
                {
                    Console.WriteLine($"Total length: {0} meters, travel time: {1} seconds",
                        route.Summary.LengthInMeters, route.Summary.TravelTimeInSeconds
                    );

                    Console.WriteLine($"Route path:");
                    for (int legIndex = 0; legIndex < route.Legs.Count; legIndex++)
                    {
                        Console.WriteLine($"Leg {0}", legIndex);
                        foreach (var point in route.Legs[legIndex].Points)
                        {
                            Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
                        }
                    }
                }
            }
            #endregion
        }

        public async void StartRequestRouteDirectionsBatch()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:AsyncRequestRouteDirectionsBatch
            // Create a list of route direction queries
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

            queries.Add(new RouteDirectionQuery(
                new List<GeoPosition>() {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875),
                    new GeoPosition(123.767, 45.90625)
                },
                new RouteDirectionOptions()
                {
                    TravelMode = TravelMode.Bicycle,
                    RouteType = RouteType.Economy,
                    UseTrafficData = false,
                })
            );
            queries.Add(new RouteDirectionQuery(new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.767, 45.90625) }));

            // Invoke asynchronous route direction batch request
            var operation = await client.StartRequestRouteDirectionsBatchAsync(queries);

            // After a while, get the result back
            var result = operation.WaitForCompletion();
            #endregion
        }

        [Test]
        public void StartRequestRouteDirectionsBatchWithOperationId()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:AsyncRequestRouteDirectionsBatchWithOperationId
            // Create a list of route direction queries
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

            queries.Add(new RouteDirectionQuery(
                new List<GeoPosition>() {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875),
                    new GeoPosition(123.767, 45.90625)
                },
                new RouteDirectionOptions()
                {
                    TravelMode = TravelMode.Bicycle,
                    RouteType = RouteType.Economy,
                    UseTrafficData = false,
                })
            );
            queries.Add(new RouteDirectionQuery(new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.767, 45.90625) }));

            // Invoke asynchronous route direction batch request
            var operation = client.StartRequestRouteDirectionsBatch(queries);

            // Get the operation ID and store somewhere
            var operationId = operation.Id;
            #endregion

            // Sleep a while to prevent live test failure
            Thread.Sleep(500);

            #region Snippet:AsyncRequestRouteDirectionsBatchWithOperationId2
            // Within 14 days, users can retrive the cached result with operation ID
            // The `endpoint` argument in `client` should be the same!
            var newRouteDirectionOperation = new RequestRouteDirectionsOperation(client, operationId);
            var result = newRouteDirectionOperation.WaitForCompletion();
            #endregion
        }

        [Test]
        public void SimpleRequestRouteMatrix()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:SimpleSyncRouteMatrix
            // A simple route matrix request
            var routeMatrixQuery = new RouteMatrixQuery
            {
                // two origin points
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791)
                }),
                // one destination point
                Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
            };
            var result = client.SyncRequestRouteMatrix(routeMatrixQuery);
            #endregion

            Assert.AreEqual(2, result.Value.Matrix.Count);
            Assert.AreEqual(1, result.Value.Matrix[0].Count);
            Assert.AreEqual(2, result.Value.Summary.SuccessfulRoutes);
            Assert.AreEqual(2, result.Value.Summary.TotalRoutes);
        }

        [Test]
        public void RequestRouteMatrixWithOptions()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:SyncRouteMatrixWithOptions
            // route matrix query
            var routeMatrixQuery = new RouteMatrixQuery
            {
                // two origin points
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791)
                }),
                // one destination point
                Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
            };

            // Add more options for route matrix request
            var options = new RouteMatrixOptions(routeMatrixQuery)
            {
                UseTrafficData = true,
                RouteType = RouteType.Economy
            };
            options.Avoid.Add(RouteAvoidType.Ferries);
            options.Avoid.Add(RouteAvoidType.UnpavedRoads);

            var result = client.SyncRequestRouteMatrix(options);
            #endregion
        }

        [Test]
        public void StartRequestRouteMatrix()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:SimpleAsyncRouteMatrixRequest
            // Instantiate route matrix query
            var routeMatrixQuery = new RouteMatrixQuery
            {
                // two origin points
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791)
                }),
                // one destination point
                Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
            };

            // Instantiate route matrix options
            var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
            {
                TravelTimeType = TravelTimeType.All,
            };

            // Invoke an async route matrix request
            var operation = client.StartRequestRouteMatrix(routeMatrixOptions);

            // A moment later, get the result from the operation
            var result = operation.WaitForCompletion();
            #endregion

            Assert.AreEqual(2, result.Value.Matrix.Count);
            Assert.AreEqual(1, result.Value.Matrix[0].Count);
            Assert.AreEqual(2, result.Value.Summary.SuccessfulRoutes);
            Assert.AreEqual(2, result.Value.Summary.TotalRoutes);
        }

        [Test]
        public void StartRequestRouteMatrixWithOperationId()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            // Instantiate route matrix query
            var routeMatrixQuery = new RouteMatrixQuery
            {
                // two origin points
                Origins = new GeoPointCollection(new List<GeoPoint>() {
                    new GeoPoint(45.9375, 123.751),
                    new GeoPoint(45.96875, 123.791) }),
                // one destination point
                Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
            };

            // Instantiate route matrix options
            var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery);

            #region Snippet:AsyncRouteMatrixRequestWithOperationId
            // Invoke an async route matrix request
            var operation = client.StartRequestRouteMatrix(routeMatrixOptions);

            // Get the operation ID and store somewhere
            var operationId = operation.Id;
            #endregion

            // Sleep a while to prevent live test failure
            Thread.Sleep(500);

            #region Snippet:AsyncRouteMatrixRequestWithOperationId2
            // Within 14 days, users can retrive the cached result with operation ID
            // The `endpoint` argument in `client` should be the same!
            var newRouteMatrixOperation = new RequestRouteMatrixOperation(client, operationId);
            var result = newRouteMatrixOperation.WaitForCompletion();
            #endregion

            #region Snippet:RouteMatrixResult
            // Route matrix result summary
            Console.WriteLine($"Total request routes: {0}, Successful routes: {1}",
                result.Value.Summary.TotalRoutes,
                result.Value.Summary.SuccessfulRoutes);

            // Route matrix result
            foreach (var routeResult in result.Value.Matrix)
            {
                Console.WriteLine("Route result:");
                foreach (var route in routeResult)
                {
                    var summary = route.Response.Summary;
                    Console.WriteLine($"Travel time: {summary.TravelTimeInSeconds} seconds");
                    Console.WriteLine($"Travel length: {summary.LengthInMeters} meters");
                    Console.WriteLine($"Departure at: {summary.DepartureTime.ToString()} meters");
                    Console.WriteLine($"Arrive at: {summary.ArrivalTime.ToString()} meters");
                }
            }
            #endregion
        }

        [Test]
        public void GetRouteRange()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:SimpleRouteRange
            // Search from a point of time budget that can be reached in 2000 seconds
            var options = new RouteRangeOptions(46, 123.75)
            {
                TimeBudget = new TimeSpan(0, 20, 0)
            };
            var result = client.GetRouteRange(options);
            #endregion

            Assert.IsNotNull(result.Value.ReachableRange.Center);
            Assert.IsTrue(result.Value.ReachableRange.Boundary.Count > 10);
        }

        [Test]
        public void GetRouteRangeWithComplexOptions()
        {
            var credential = new DefaultAzureCredential();
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsRouteClient(credential, clientId);

            #region Snippet:ComplexRouteRange
            var geoPoint = new GeoPosition(123.75, 46);
            // Search from a point of distance budget that can be reached in 6075.35 meters,
            // And departure time after 2 hours later in car
            var options = new RouteRangeOptions(geoPoint)
            {
                DistanceBudgetInMeters = 6075.38,
                DepartAt = DateTimeOffset.Now.AddHours(2),
                RouteType = RouteType.Shortest,
                TravelMode = TravelMode.Car
            };
            var result = client.GetRouteRange(options);
            #endregion

            #region Snippet:ReachableRouteRangeResult
            // Suppose we have `result` as the return value from client.GetRouteRange(options)
            Console.WriteLine("Center point (Lat, Long): ({0}, {1})",
                result.Value.ReachableRange.Center.Longitude,
                result.Value.ReachableRange.Center.Latitude);

            Console.WriteLine("Reachable route range polygon:");
            foreach (var point in result.Value.ReachableRange.Boundary)
            {
                Console.WriteLine($"({point.Longitude}, {point.Latitude})");
            }
            #endregion
        }
    }
}
