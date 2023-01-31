// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
#region Snippet:SearchImportNamespace
using Azure.Core.GeoJson;
using Azure.Maps.Search;
using Azure.Maps.Search.Models;
#endregion
using Azure.Core.TestFramework;

using NUnit.Framework;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientSamples: SamplesBase<SearchClientTestEnvironment>
    {
        public void SearchClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateSearchClientViaSubscriptionKey
            // Create a SearchClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsSearchClient client = new MapsSearchClient(credential);
            #endregion
        }

        public void SearchClientViaAAD()
        {
            #region Snippet:InstantiateSearchClientViaAAD
            // Create a MapsSearchClient that will authenticate through AAD
            DefaultAzureCredential credential = new DefaultAzureCredential();
            string clientId = "<My Map Account Client Id>";
            MapsSearchClient client = new MapsSearchClient(credential, clientId);
            #endregion
        }

        [Test]
        public async Task GetPolygons()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            var searchResult = await client.SearchAddressAsync("Seattle");
            var geometry0Id = searchResult.Value.Results[0].DataSources.Geometry.Id;
            var geometry1Id = searchResult.Value.Results[1].DataSources.Geometry.Id;
            // Seattle municipality geometry
            var polygonResponse = await client.GetPolygonsAsync(new[] { geometry0Id, geometry1Id });
        }

        [Test]
        public void GetImmediateFuzzyBatchSearch()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetImmediateFuzzyBatchSearch
            List<FuzzySearchQuery> queries = new List<FuzzySearchQuery>
            {
                new FuzzySearchQuery("coffee", new FuzzySearchOptions()
                {
                    BoundingBox = new GeoBoundingBox(121.53, 25.0, 121.56, 25.04)
                }),
                new FuzzySearchQuery("amusement park", new FuzzySearchOptions()
                {
                    BoundingBox = new GeoBoundingBox(121.5, 25.0, 121.6, 25.1)
                }),
            };
            Response<SearchAddressBatchResult> fuzzySearchResults = client.GetImmediateFuzzyBatchSearch(queries);

            // Print out the results for all queries
            foreach (SearchAddressBatchItemResponse resultItemResponse in fuzzySearchResults.Value.Results)
            {
                Console.WriteLine("The possible results for {0}:", resultItemResponse.Query);
                SearchAddressResultItem resultItem = resultItemResponse.Results[0];
                Console.WriteLine("Coordinate: {0}, Address: {1}",
                    resultItem.Position, resultItem.Address.FreeformAddress);
            }
            #endregion
        }

        [Test]
        public void FuzzyBatchSearch()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:FuzzyBatchSearch
            List<FuzzySearchQuery> queries = new List<FuzzySearchQuery>
            {
                new FuzzySearchQuery("coffee", new FuzzySearchOptions()
                {
                    BoundingBox = new GeoBoundingBox(121.53, 25.0, 121.56, 25.04)
                }),
                new FuzzySearchQuery("amusement park", new FuzzySearchOptions()
                {
                    BoundingBox = new GeoBoundingBox(121.5, 25.0, 121.6, 25.1)
                }),
            };
            FuzzySearchBatchOperation operation = client.FuzzyBatchSearch(WaitUntil.Started, queries);

            // After a while, get the result back
            Response<SearchAddressBatchResult> result = operation.WaitForCompletion();
            #endregion
        }

        [Test]
        public void FuzzyBatchSearchWithOperationId()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:FuzzyBatchSearchWithOperationId
            List<FuzzySearchQuery> queries = new List<FuzzySearchQuery>
            {
                new FuzzySearchQuery("coffee", new FuzzySearchOptions()
                {
                    BoundingBox = new GeoBoundingBox(121.53, 25.0, 121.56, 25.04)
                }),
                new FuzzySearchQuery("amusement park", new FuzzySearchOptions()
                {
                    BoundingBox = new GeoBoundingBox(121.5, 25.0, 121.6, 25.1)
                }),
            };
            FuzzySearchBatchOperation operation = client.FuzzyBatchSearch(WaitUntil.Started, queries);

            // Get the operation ID and store somewhere
            string operationId = operation.Id;
            #endregion
            // Sleep a while to prevent live test failure
            Thread.Sleep(500);
            #region Snippet:FuzzyBatchSearchWithOperationId2
            // Within 14 days, users can retrive the cached result with operation ID
            // The `endpoint` argument in `clientOptions` should be the same!
            FuzzySearchBatchOperation newFuzzySearchBatchOperation = new FuzzySearchBatchOperation(client, operationId);
            Response<SearchAddressBatchResult> searchResults = newFuzzySearchBatchOperation.WaitForCompletion();

            // Show the results
            foreach (SearchAddressBatchItemResponse searchResult in searchResults.Value.Results)
            {
                Console.WriteLine("Result for query: \"{0}\"", searchResult.Query);
                SearchAddressResultItem result = searchResult.Results[0];
                Console.WriteLine("Coordinate: {0}, Address: {1}",
                    result.Position, result.Address.FreeformAddress);
            }
            #endregion
        }

        [Test]
        public async Task ReverseSearchCrossStreetAddress()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:ReverseSearchCrossStreetAddressAsync
            Response<ReverseSearchCrossStreetAddressResult> searchResult = await client.ReverseSearchCrossStreetAddressAsync(new ReverseSearchCrossStreetOptions
            {
                Coordinates = new GeoPosition(-121.89, 37.337),
                Language = SearchLanguage.EnglishUsa
            });

            ReverseSearchCrossStreetAddressResultItem address = searchResult.Value.Addresses[0];
            Console.WriteLine("Coordinate {0} => Cross street address is: {1}",
                address.Position, address.Address.FreeformAddress);
            #endregion
        }

        [Test]
        public async Task ReverseSearchAddressBatch()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);

            #region Snippet:ReverseSearchAddressBatchAsync
            List<ReverseSearchAddressQuery> queries = new List<ReverseSearchAddressQuery>
            {
                new ReverseSearchAddressQuery(new ReverseSearchOptions()
                {
                    Coordinates = new GeoPosition(121.0, 24.0),
                    Language = SearchLanguage.EnglishUsa
                }),
                new ReverseSearchAddressQuery(new ReverseSearchOptions()
                {
                    Coordinates = new GeoPosition(-3.707, 40.4168),
                    StreetNumber = 5
                })
            };

            // Reverse search address batch will return `ReverseSearchAddressBatchOperation` object
            ReverseSearchAddressBatchOperation operation = await client.ReverseSearchAddressBatchAsync(WaitUntil.Started, queries);

            // After a while, get the result back from `ReverseSearchAddressBatchOperation`
            Response<ReverseSearchAddressBatchResult> result = await operation.WaitForCompletionAsync().ConfigureAwait(false);
            #endregion
        }

        [Test]
        public async Task ReverseSearchAddressBatchWithOperationId()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);

            #region Snippet:ReverseSearchAddressBatchAsyncWithOperationId
            List<ReverseSearchAddressQuery> queries = new List<ReverseSearchAddressQuery>
            {
                new ReverseSearchAddressQuery(new ReverseSearchOptions()
                {
                    Coordinates = new GeoPosition(121.0, 24.0),
                    Language = SearchLanguage.EnglishUsa
                }),
                new ReverseSearchAddressQuery(new ReverseSearchOptions()
                {
                    Coordinates = new GeoPosition(-3.707, 40.4168),
                    StreetNumber = 5
                })
            };

            // Reverse search address batch will return `ReverseSearchAddressBatchOperation` object
            ReverseSearchAddressBatchOperation operation = await client.ReverseSearchAddressBatchAsync(WaitUntil.Started, queries);

            // Get the operation ID and store somewhere
            string operationId = operation.Id;
            #endregion
            // Sleep a while to prevent live test failure
            Thread.Sleep(500);
            #region Snippet:ReverseSearchAddressBatchAsyncWithOperationId2
            // Within 14 days, users can retrive the cached result with operation ID
            // The `endpoint` argument in `clientOptions` should be the same!
            ReverseSearchAddressBatchOperation newReverseSearchAddressBatchOperation = new ReverseSearchAddressBatchOperation(client, operationId);
            Response<ReverseSearchAddressBatchResult> searchResults = newReverseSearchAddressBatchOperation.WaitForCompletion();

            // Show the results
            foreach (ReverseSearchAddressBatchItemResponse searchResult in searchResults.Value.Results)
            {
                Console.WriteLine("Result for query: \"{0}\"", searchResult.Query);
                // Print out first result
                ReverseSearchAddressItem address = searchResult.Addresses[0];
                Console.WriteLine("Country: {0}", address.Address.Country);
                Console.WriteLine("Address: {0}", address.Address.FreeformAddress);
            }
            #endregion
        }

        [Test]
        public void GetImmediateSearchAddressBatch()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);

            #region Snippet:GetImmediateSearchAddressBatch
            List<SearchAddressQuery> queries = new List<SearchAddressQuery>
            {
                new SearchAddressQuery("1301 Alaskan Way, Seattle, WA 98101"),
                new SearchAddressQuery("350 S 5th St, Minneapolis, MN 55415")
            };
            SearchAddressBatchResult searchResults = client.GetImmediateSearchAddressBatch(queries);

            foreach (SearchAddressBatchItemResponse searchResult in searchResults.Results)
            {
                Console.WriteLine("Result for query: \"{0}\"", searchResult.Query);
                foreach (SearchAddressResultItem result in searchResult.Results)
                {
                    Console.WriteLine("Coordinate (Lat, Lon): ({0}, {1})",
                        result.Position.Latitude, result.Position.Longitude);
                }
            }
            #endregion
        }

        [Test]
        public void SearchAddressBatch()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);

            #region Snippet:SearchAddressBatch
            List<SearchAddressQuery> queries = new List<SearchAddressQuery>
            {
                new SearchAddressQuery("1301 Alaskan Way, Seattle, WA 98101"),
                new SearchAddressQuery("350 S 5th St, Minneapolis, MN 55415")
            };

            // Invoke asynchronous search address batch request, we can get the result later via assigning `WaitUntil.Started`
            SearchAddressBatchOperation operation = client.SearchAddressBatch(WaitUntil.Started, queries);

            // After a while, get the result back
            Response<SearchAddressBatchResult> result = operation.WaitForCompletion();
            #endregion
        }

        [Test]
        public void SearchAddressBatchWithOperationId()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);

            #region Snippet:SearchAddressBatchWithOperationId
            List<SearchAddressQuery> queries = new List<SearchAddressQuery>
            {
                new SearchAddressQuery("1301 Alaskan Way, Seattle, WA 98101"),
                new SearchAddressQuery("350 S 5th St, Minneapolis, MN 55415")
            };

            // Invoke asynchronous search address batch request, we can get the result later via assigning `WaitUntil.Started`
            SearchAddressBatchOperation operation = client.SearchAddressBatch(WaitUntil.Started, queries);

            // Get the operation ID and store somewhere
            string operationId = operation.Id;
            #endregion
            // Sleep a while to prevent live test failure
            Thread.Sleep(500);
            #region Snippet:SearchAddressBatchWithOperationId2
            // Within 14 days, users can retrive the cached result with operation ID
            // The `endpoint` argument in `clientOptions` should be the same!
            SearchAddressBatchOperation newSearchAddressBatchOperation = new SearchAddressBatchOperation(client, operationId);
            Response<SearchAddressBatchResult> searchResults = newSearchAddressBatchOperation.WaitForCompletion();

            // Show the results
            foreach (SearchAddressBatchItemResponse searchResult in searchResults.Value.Results)
            {
                Console.WriteLine("Result for query: \"{0}\"", searchResult.Query);
                foreach (SearchAddressResultItem result in searchResult.Results)
                {
                    Console.WriteLine("Coordinate (Lat, Lon): ({0}, {1})",
                        result.Position.Latitude, result.Position.Longitude);
                }
            }
            #endregion
        }

        [Test]
        public void SearchPointOfInterest()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);

            #region Snippet:SearchPointOfInterest
            Response<SearchAddressResult> searchResult = client.SearchPointOfInterest("juice bars");

            SearchAddressResultItem resultItem = searchResult.Value.Results[0];
            Console.WriteLine("First result - Coordinate: {0}, Address: {1}",
                resultItem.Position, resultItem.Address.FreeformAddress);
            #endregion
        }
    }
}
