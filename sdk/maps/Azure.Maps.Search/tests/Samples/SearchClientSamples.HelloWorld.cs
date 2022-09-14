// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using Azure.Maps.Search;
using Azure.Maps.Search.Models;
using NUnit.Framework;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientSamples: SamplesBase<SearchClientTestEnvironment>
    {
        public void SearchClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateSearchClientViaSubscriptionKey
            // Create a SearchClient that will authenticate through Subscription Key (Shared key)
            var credential = new AzureKeyCredential("<My Subscription Key>");
            MapsSearchClient client = new MapsSearchClient(credential);
            #endregion
        }

        public void SearchClientViaAAD()
        {
            #region Snippet:InstantiateSearchClientViaAAD
            // Create a MapsSearchClient that will authenticate through AAD
            var credential = new DefaultAzureCredential();
            var clientId = "<My Map Account Client Id>";
            MapsSearchClient client = new MapsSearchClient(credential, clientId);
            #endregion
        }

        [Test]
        public async Task GetPolygons()
        {
            var endpoint = TestEnvironment.Endpoint;
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(endpoint, TestEnvironment.Credential, clientId);
            var searchResult = await client.SearchAddressAsync("Seattle");
            var geometry0Id = searchResult.Value.Results.First().DataSources.Geometry.Id;
            var geometry1Id = searchResult.Value.Results[1].DataSources.Geometry.Id;
            // Seattle municipality geometry
            var polygonResponse = await client.GetPolygonsAsync(new[] { geometry0Id, geometry1Id });
        }

        [Test]
        public async Task FuzzySearch()
        {
            var endpoint = TestEnvironment.Endpoint;
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(endpoint, TestEnvironment.Credential, clientId);
            var fuzzySearchResponse = await client.FuzzySearchAsync("coffee", new FuzzySearchOptions {
                Coordinates = new GeoPosition(121.56, 25.04),
                Language = "en"
            });
        }

        [Test]
        public async Task ReverseSearchCrossStreetAddress()
        {
            var endpoint = TestEnvironment.Endpoint;
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(endpoint, TestEnvironment.Credential, clientId);
            var reverseResult = await client.ReverseSearchCrossStreetAddressAsync(new ReverseSearchCrossStreetOptions {
                coordinates = new GeoPosition(121.0, 24.0),
                Language = "en"
            });
        }

        [Test]
        public async Task SearchStructuredAddress()
        {
            var endpoint = TestEnvironment.Endpoint;
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(endpoint, TestEnvironment.Credential, clientId);
            var address = new StructuredAddress {
                CountryCode = "US",
                StreetNumber = "15127",
                StreetName = "NE 24th Street",
                Municipality = "Redmond",
                CountrySubdivision = "WA",
                PostalCode = "98052"
            };
            var searchResult = await client.SearchStructuredAddressAsync(address);
        }

        [Test]
        public async Task SearchInsideGeometry()
        {
            var endpoint = TestEnvironment.Endpoint;
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(endpoint, TestEnvironment.Credential, clientId);
           var sfPolygon = new GeoPolygon(new[]
            {
                new GeoPosition(-122.43576049804686, 37.752415234354402),
                new GeoPosition(-122.4330139160, 37.706604725423119),
                new GeoPosition(-122.36434936523438, 37.712059855877314),
                new GeoPosition(-122.43576049804686, 37.7524152343544)
            });

            var taipeiPolygon = new GeoPolygon(new[]
            {
                new GeoPosition(121.56, 25.04),
                new GeoPosition(121.565, 25.04),
                new GeoPosition(121.565, 25.045),
                new GeoPosition(121.56, 25.045),
                new GeoPosition(121.56, 25.04)
            });

            var searchResponse = await client.SearchInsideGeometryAsync("coffee", new GeoCollection(new[] { sfPolygon, taipeiPolygon }), new SearchInsideGeometryOptions {
                Language = "en"
            });
        }

        [Test]
        public void SearchingAnAddress()
        {
            var endpoint = TestEnvironment.Endpoint;
            var clientId = TestEnvironment.MapAccountClientId;

            // #region Snippet:SearchingAnAddress
            var client = new MapsSearchClient(endpoint, TestEnvironment.Credential, clientId);
            SearchAddressResult searchResponse = client.SearchAddress("Seattle");

            var primaryResult = searchResponse.Results.First();
            Console.WriteLine("Country: " + primaryResult.Address.CountryCodeIso3);
            Console.WriteLine("State: " + primaryResult.Address.CountrySubdivision);
            // #endregion
        }
    }
}
