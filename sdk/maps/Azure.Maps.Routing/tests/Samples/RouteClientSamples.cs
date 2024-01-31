// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
#region Snippet:RouteImportNamespaces
using Azure.Core.GeoJson;
using Azure.Maps.Routing;
using Azure.Maps.Routing.Models;
#endregion
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:RouteSasAuthImportNamespaces
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
#endregion

namespace Azure.Maps.Routing.Tests
{
    public class RouteClientSamples : SamplesBase<RouteClientTestEnvironment>
    {
        public void RouteClientViaAAD()
        {
            #region Snippet:InstantiateRouteClientViaAAD
            // Create a MapsRoutingClient that will authenticate through Active Directory
#if SNIPPET
            TokenCredential credential = new DefaultAzureCredential();
            string clientId = "<Your Map ClientId>";
#else
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
#endif
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);
            #endregion
        }

        public void RouteClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateRouteClientViaSubscriptionKey
            // Create a MapsRoutingClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsRoutingClient client = new MapsRoutingClient(credential);
            #endregion
        }

        public void RouteClientViaSas()
        {
            #region Snippet:InstantiateRouteClientViaSas
            // Get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // Authenticate your client
            ArmClient armClient = new ArmClient(cred);

            string subscriptionId = "MyMapsSubscriptionId";
            string resourceGroupName = "MyMapsResourceGroupName";
            string accountName = "MyMapsAccountName";

            // Get maps account resource
            ResourceIdentifier mapsAccountResourceId = MapsAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            MapsAccountResource mapsAccount = armClient.GetMapsAccountResource(mapsAccountResourceId);

            // Assign SAS token information
            // Every time you want to SAS token, update the principal ID, max rate, start and expiry time
            string principalId = "MyManagedIdentityObjectId";
            int maxRatePerSecond = 500;

            // Set start and expiry time for the SAS token in round-trip date/time format
            DateTime now = DateTime.Now;
            string start = now.ToString("O");
            string expiry = now.AddDays(1).ToString("O");

            MapsAccountSasContent sasContent = new MapsAccountSasContent(MapsSigningKey.PrimaryKey, principalId, maxRatePerSecond, start, expiry);
            Response<MapsAccountSasToken> sas = mapsAccount.GetSas(sasContent);

            // Create a SearchClient that will authenticate via SAS token
            AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
            MapsRoutingClient client = new MapsRoutingClient(sasCredential);
            #endregion
        }

        [Test]
        public void GetRouteDirections()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:GetDirections
            // Create origin and destination routing points
            List<GeoPosition> routePoints = new List<GeoPosition>()
            {
                new GeoPosition(123.751, 45.9375),
                new GeoPosition(123.791, 45.96875),
                new GeoPosition(123.767, 45.90625)
            };

            // Create Route direction query object
            RouteDirectionQuery query = new RouteDirectionQuery(routePoints);
            Response<RouteDirections> result = client.GetDirections(query);

            // Route direction result
            Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
            Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
            Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeDuration);

            // Route points
            foreach (RouteLeg leg in result.Value.Routes[0].Legs)
            {
                Console.WriteLine("Route path:");
                foreach (GeoPosition point in leg.Points)
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
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:RouteDirectionsWithOptions
            // Create origin and destination routing points
            List<GeoPosition> routePoints = new List<GeoPosition>()
            {
                new GeoPosition(123.751, 45.9375),
                new GeoPosition(123.791, 45.96875),
                new GeoPosition(123.767, 45.90625)
            };

            RouteDirectionOptions options = new RouteDirectionOptions()
            {
                RouteType = RouteType.Fastest,
                UseTrafficData = true,
                TravelMode = TravelMode.Bicycle,
                Language = RoutingLanguage.EnglishUsa,
            };

            // Create Route direction query object
            RouteDirectionQuery query = new RouteDirectionQuery(routePoints);
            Response<RouteDirections> result = client.GetDirections(query);

            // Route direction result
            Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
            Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
            Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeDuration);

            // Route points
            foreach (RouteLeg leg in result.Value.Routes[0].Legs)
            {
                Console.WriteLine("Route path:");
                foreach (GeoPosition point in leg.Points)
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
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:CatchRouteException
            try
            {
                // An empty route points list
                List<GeoPosition> routePoints = new List<GeoPosition>() { };
                RouteDirectionQuery query = new RouteDirectionQuery(routePoints);

                Response<RouteDirections> result = client.GetDirections(query);
                // Do something with result ...
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.ToString());
            }
            #endregion
        }

        public void GetDirectionsImmediateBatch()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:GetDirectionsImmediateBatch
            // Create a list of route direction queries
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

            queries.Add(new RouteDirectionQuery(
                new List<GeoPosition>()
                {
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
            Response<RouteDirectionsBatchResult> response = client.GetDirectionsImmediateBatch(queries);
            #endregion

            #region Snippet:RouteDirectionsBatchResult
            for (int i = 0; i < response.Value.Results.Count; i++)
            {
                RouteDirectionsBatchItemResponse result = response.Value.Results[i];
                Console.WriteLine($"Batch item result {0}:", i);

                foreach (RouteData route in result.Routes)
                {
                    Console.WriteLine($"Total length: {0} meters, travel time: {1} seconds",
                        route.Summary.LengthInMeters, route.Summary.TravelTimeDuration
                    );

                    Console.WriteLine($"Route path:");
                    for (int legIndex = 0; legIndex < route.Legs.Count; legIndex++)
                    {
                        Console.WriteLine($"Leg {0}", legIndex);
                        foreach (GeoPosition point in route.Legs[legIndex].Points)
                        {
                            Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
                        }
                    }
                }
            }
            #endregion
        }

        public async void RequestRouteDirectionsBatch()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:AsyncRequestRouteDirectionsBatch
            // Create a list of route direction queries
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

            queries.Add(new RouteDirectionQuery(
                new List<GeoPosition>()
                {
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

            // Invoke asynchronous route direction batch request, we can get the result later via assigning `WaitUntil.Started`
            GetDirectionsOperation operation = await client.GetDirectionsBatchAsync(WaitUntil.Started, queries);

            // After a while, get the result back
            Response<RouteDirectionsBatchResult> result = operation.WaitForCompletion();
            #endregion
        }

        [Test]
        public void RequestRouteDirectionsBatchWithOperationId()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:AsyncRequestRouteDirectionsBatchWithOperationId
            // Create a list of route direction queries
            IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

            queries.Add(new RouteDirectionQuery(
                new List<GeoPosition>()
                {
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
            GetDirectionsOperation operation = client.GetDirectionsBatch(WaitUntil.Started, queries);

            // Get the operation ID and store somewhere
            string operationId = operation.Id;
            #endregion

            // Sleep a while to prevent live test failure
            Thread.Sleep(500);

            #region Snippet:AsyncRequestRouteDirectionsBatchWithOperationId2
            // Within 14 days, users can retrive the cached result with operation ID
            // The `endpoint` argument in `client` should be the same!
            GetDirectionsOperation newRouteDirectionOperation = new GetDirectionsOperation(client, operationId);
            Response<RouteDirectionsBatchResult> result = newRouteDirectionOperation.WaitForCompletion();
            #endregion
        }

        [Test]
        public void SimpleRequestRouteMatrix()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:GetImmediateRouteMatrix
            // A simple route matrix request
            RouteMatrixQuery routeMatrixQuery = new RouteMatrixQuery
            {
                // two origin points
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875)
                },
                // one destination point
                Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625) },
            };
            Response<RouteMatrixResult> result = client.GetImmediateRouteMatrix(routeMatrixQuery);
            #endregion

            Assert.AreEqual(2, result.Value.Matrix.Count);
            Assert.AreEqual(1, result.Value.Matrix[0].Count);
            Assert.AreEqual(2, result.Value.Summary.SuccessfulRoutes);
            Assert.AreEqual(2, result.Value.Summary.TotalRoutes);
        }

        [Test]
        public void RequestRouteMatrixWithOptions()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:SyncRouteMatrixWithOptions
            // route matrix query
            RouteMatrixQuery routeMatrixQuery = new RouteMatrixQuery
            {
                // two origin points
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875)
                },
                // one destination point
                Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625) },
            };

            // Add more options for route matrix request
            RouteMatrixOptions options = new RouteMatrixOptions(routeMatrixQuery)
            {
                UseTrafficData = true,
                RouteType = RouteType.Economy
            };
            options.Avoid.Add(RouteAvoidType.Ferries);
            options.Avoid.Add(RouteAvoidType.UnpavedRoads);

            Response<RouteMatrixResult> result = client.GetImmediateRouteMatrix(options);
            #endregion
        }

        [Test]
        public void RequestRouteMatrix()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:SimpleAsyncRouteMatrixRequest
            // Instantiate route matrix query
            RouteMatrixQuery routeMatrixQuery = new RouteMatrixQuery
            {
                // two origin points
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875)
                },
                // one destination point
                Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625) },
            };

            // Instantiate route matrix options
            RouteMatrixOptions routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
            {
                TravelTimeType = TravelTimeType.All,
            };

            // Invoke an long-running operation route matrix request and directly wait for completion
            GetRouteMatrixOperation result = client.GetRouteMatrix(WaitUntil.Completed, routeMatrixOptions);
            #endregion

            Assert.AreEqual(2, result.Value.Matrix.Count);
            Assert.AreEqual(1, result.Value.Matrix[0].Count);
            Assert.AreEqual(2, result.Value.Summary.SuccessfulRoutes);
            Assert.AreEqual(2, result.Value.Summary.TotalRoutes);
        }

        [Test]
        public void RequestRouteMatrixWithOperationId()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            // Instantiate route matrix query
            RouteMatrixQuery routeMatrixQuery = new RouteMatrixQuery
            {
                // two origin points
                Origins = new List<GeoPosition>()
                {
                    new GeoPosition(123.751, 45.9375),
                    new GeoPosition(123.791, 45.96875)
                },
                // one destination point
                Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625) },
            };

            // Instantiate route matrix options
            RouteMatrixOptions routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery);

            #region Snippet:AsyncRouteMatrixRequestWithOperationId
            // Invoke an async route matrix request and get the result later via assigning `WaitUntil.Started`
            GetRouteMatrixOperation operation = client.GetRouteMatrix(WaitUntil.Started, routeMatrixOptions);

            // Get the operation ID and store somewhere
            string operationId = operation.Id;
            #endregion

            // Sleep a while to prevent live test failure
            Thread.Sleep(500);

            #region Snippet:AsyncRouteMatrixRequestWithOperationId2
            // Within 14 days, users can retrive the cached result with operation ID
            // The `endpoint` argument in `client` should be the same!
            GetRouteMatrixOperation newRouteMatrixOperation = new GetRouteMatrixOperation(client, operationId);
            Response<RouteMatrixResult> result = newRouteMatrixOperation.WaitForCompletion();
            #endregion

            #region Snippet:RouteMatrixResult
            // Route matrix result summary
            Console.WriteLine($"Total request routes: {0}, Successful routes: {1}",
                result.Value.Summary.TotalRoutes,
                result.Value.Summary.SuccessfulRoutes);

            // Route matrix result
            foreach (IList<RouteMatrix> routeResult in result.Value.Matrix)
            {
                Console.WriteLine("Route result:");
                foreach (RouteMatrix route in routeResult)
                {
                    RouteLegSummary summary = route.Summary;
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
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:SimpleRouteRange
            // Search from a point of time budget that can be reached in 2000 seconds
            RouteRangeOptions options = new RouteRangeOptions(123.75, 46)
            {
                TimeBudget = new TimeSpan(0, 20, 0)
            };
            Response<RouteRangeResult> result = client.GetRouteRange(options);
            #endregion

            Assert.IsNotNull(result.Value.ReachableRange.Center);
            Assert.IsTrue(result.Value.ReachableRange.Boundary.Count > 10);
        }

        [Test]
        public void GetRouteRangeWithComplexOptions()
        {
            TokenCredential credential = TestEnvironment.Credential;
            string clientId = TestEnvironment.MapAccountClientId;
            MapsRoutingClient client = new MapsRoutingClient(credential, clientId);

            #region Snippet:ComplexRouteRange
            GeoPosition geoPosition = new GeoPosition(123.75, 46);
            // Search from a point of distance budget that can be reached in 6075.35 meters,
            // And departure time after 2 hours later in car
            RouteRangeOptions options = new RouteRangeOptions(geoPosition)
            {
                DistanceBudgetInMeters = 6075.38,
                DepartAt = DateTimeOffset.Now.AddHours(2),
                RouteType = RouteType.Shortest,
                TravelMode = TravelMode.Car
            };
            Response<RouteRangeResult> result = client.GetRouteRange(options);
            #endregion

            #region Snippet:ReachableRouteRangeResult
            // Suppose we have `result` as the return value from client.GetRouteRange(options)
            Console.WriteLine("Center point (Lat, Long): ({0}, {1})",
                result.Value.ReachableRange.Center.Longitude,
                result.Value.ReachableRange.Center.Latitude);

            Console.WriteLine("Reachable route range polygon:");
            foreach (GeoPosition point in result.Value.ReachableRange.Boundary)
            {
                Console.WriteLine($"({point.Longitude}, {point.Latitude})");
            }
            #endregion
        }
    }
}
