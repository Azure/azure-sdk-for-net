// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    internal class SearchMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://search.cognitiveservices.azure.com/";
        private static readonly string s_apiKey = "FakeapiKey";

        public SearchMockTests(bool isAsync) : base(isAsync)
        {
        }

        private SearchClient CreateTestClient(HttpPipelineTransport transport)
        {
            var options = new SearchClientOptions(SearchClientOptions.ServiceVersion.V2023_11_01)
            {
                Transport = transport
            };

            var client = InstrumentClient(new SearchClient(new Uri(s_endpoint), "fakeIndex", new AzureKeyCredential(s_apiKey), options));

            return client;
        }

        [Test]
        public async Task ValueFacets()
        {
            var mockResponse = new MockResponse(200);

            var content = @"{
                    ""@search.facets"":{
                        ""category"":[
                            {""count"":2,""value"":""Luxury""},
                            {""count"":1,""value"":""Boutique""},
                            {""count"":1,""value"":""Budget""}
                            ]},
                        ""value"":[
                            {""@search.score"":1.0,""hotelId"":""3"",""hotelName"":""EconoStay"",""description"":""Very popular hotel in town"",""descriptionFr"":""H\u00f4tel le plus populaire en ville"",""category"":""Boutique"",""tags"":[""wifi"",""budget""],""parkingIncluded"":true,""smokingAllowed"":false,""lastRenovationDate"":""1995-07-01T00:00:00Z"",""rating"":4,""location"":{""type"":""Point"",""coordinates"":[-122.131577,46.678581],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}},""geoLocation"":{""type"":""Point"",""coordinates"":[-122.131577,46.678581],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}},""address"":null,""rooms"":[]},
                            {""@search.score"":1.0,""hotelId"":""2"",""hotelName"":""Roach Motel"",""description"":""Cheapest hotel in town. Infact, a motel."",""descriptionFr"":""H\u00f4tel le moins cher en ville. Infact, un motel."",""category"":""Budget"",""tags"":[""motel"",""budget""],""parkingIncluded"":true,""smokingAllowed"":true,""lastRenovationDate"":""1982-04-28T00:00:00Z"",""rating"":1,""location"":{""type"":""Point"",""coordinates"":[-122.131577,49.678581],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}},""geoLocation"":{""type"":""Point"",""coordinates"":[-122.131577,49.678581],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}},""address"":null,""rooms"":[]},
                            {""@search.score"":1.0,""hotelId"":""4"",""hotelName"":""Express Rooms"",""description"":""Pretty good hotel"",""descriptionFr"":""Assez bon h\u00f4tel"",""category"":""Luxury"",""tags"":[""wifi"",""budget""],""parkingIncluded"":true,""smokingAllowed"":false,""lastRenovationDate"":""1995-07-01T00:00:00Z"",""rating"":4,""location"":{""type"":""Point"",""coordinates"":[-122.131577,48.678581],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}},""geoLocation"":{""type"":""Point"",""coordinates"":[-122.131577,48.678581],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}},""address"":null,""rooms"":[]},
                            {""@search.score"":1.0,""hotelId"":""1"",""hotelName"":""Fancy Stay"",""description"":""Best hotel"",""descriptionFr"":null,""category"":""Luxury"",""tags"":[""pool"",""view"",""wifi"",""concierge""],""parkingIncluded"":false,""smokingAllowed"":false,""lastRenovationDate"":""2010-06-27T00:00:00Z"",""rating"":5,""location"":{""type"":""Point"",""coordinates"":[-122.131577,47.678581],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}},""geoLocation"":{""type"":""Point"",""coordinates"":[-122.131577,47.678581],""crs"":{""type"":""name"",""properties"":{""name"":""EPSG:4326""}}},""address"":null,""rooms"":[]}
                            ]}";

            mockResponse.SetContent(content);

            var mockTransport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(mockTransport);
            Response<SearchResults<Hotel>> response =
                await client.SearchAsync<Hotel>(
                    "*",
                    new SearchOptions
                    {
                        Facets = new[]
                        {
                            "category,sort:count",
                        }
                    });

            AssertFacetsEqual(
                GetFacetsForField(response.Value.Facets, "category", 3),
                MakeValueFacet(2, "Luxury"),
                MakeValueFacet(1, "Boutique"),
                MakeValueFacet(1, "Budget"));
        }

        public FacetResult MakeValueFacet(int count, object value) => SearchModelFactory.FacetResult(count, new Dictionary<string, object>()
        {
            ["value"] = value
        });

        private void AssertFacetsEqual(ICollection<FacetResult> actualFacets, params FacetResult[] expectedFacets)
        {
            Assert.AreEqual(actualFacets.Count, expectedFacets.Length);
            int i = 0;
            foreach (FacetResult actualFacet in actualFacets)
            {
                FacetResult expectedFacet = expectedFacets[i++];
                Assert.AreEqual(expectedFacet.Count, actualFacet.Count);
                CollectionAssert.IsSubsetOf(actualFacet.Keys, expectedFacet.Keys);
                foreach (string key in expectedFacet.Keys)
                {
                    Assert.AreEqual(
                        expectedFacet[key],
                        actualFacet.TryGetValue(key, out object value) ? value : null);
                }
            }
        }

        private ICollection<FacetResult> GetFacetsForField(IDictionary<string, IList<FacetResult>> facets, string expectedField, int expectedCount)
        {
            Assert.True(facets.ContainsKey(expectedField), $"Expecting facets to contain {expectedField}");
            ICollection<FacetResult> fieldFacets = facets[expectedField];
            Assert.AreEqual(expectedCount, fieldFacets.Count);
            return fieldFacets;
        }
    }
}
