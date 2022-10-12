// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using Azure.Maps.Search.Models;
using NUnit.Framework;

namespace Azure.Maps.Search.Tests
{
    public class GeoJsonSearchTests: SearchClientLiveTestsBase
    {
        public GeoJsonSearchTests(bool isAsync) : base(isAsync)
        {
            CompareBodies = false;
        }

        [RecordedTest]
        public async Task CanDescribeSearchResultReferencedGeometry()
        {
            // Get Client
            var client = CreateClient();

            #region Snippet:GetPolygons
            // Get Addresses
            Response<SearchAddressResult> searchResult = await client.SearchAddressAsync("Seattle");

            // Extract geometry ids from addresses
            string geometry0Id = searchResult.Value.Results[0].DataSources.Geometry.Id;
            string geometry1Id = searchResult.Value.Results[1].DataSources.Geometry.Id;

            // Extract position coordinates
            GeoPosition positionCoordinates = searchResult.Value.Results[0].Position;

            // Get polygons from geometry ids
            PolygonResult polygonResponse = await client.GetPolygonsAsync(new[] { geometry0Id, geometry1Id });

            // Get polygons objects
            IReadOnlyList<PolygonObject> polygonList = polygonResponse.Polygons;
            #endregion
            List<String> providerIds = new List<string>();
            foreach (PolygonObject polygon in polygonList) {
                providerIds.Add(polygon.ProviderId);
            }
            CollectionAssert.Contains(providerIds, geometry0Id);
        }

        [RecordedTest]
        public void InvalidSearchAddressTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.SearchAddressAsync(""));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public void InvalidGetPolygonsTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetPolygonsAsync(new string[] {}));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public void InvalidSearchInsideGeometryTest()
        {
            var client = CreateClient();
            var polygonString = @"
            {
                ""type"": ""Polygon"",
                ""coordinates"": [
                    [
                        [
                            -122.43576049804686,
                            37.752415234354402
                        ],
                        [
                            -122.4330139159,
                            37.706604725423119
                        ],
                        [
                            -122.36434936523438,
                            37.712059855877314
                        ],
                        [
                            -122.43576049804686,
                            37.752415234354402
                        ]
                    ]
                ]
            }";
            GeoPolygon polygon = JsonSerializer.Deserialize<GeoPolygon>(polygonString);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.SearchInsideGeometryAsync("", polygon));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task CanSearchInsidePolygon()
        {
            var client = CreateClient();
            var polygonString = @"
            {
                ""type"": ""Polygon"",
                ""coordinates"": [
                    [
                        [
                            -122.43576049804686,
                            37.752415234354402
                        ],
                        [
                            -122.4330139159,
                            37.706604725423119
                        ],
                        [
                            -122.36434936523438,
                            37.712059855877314
                        ],
                        [
                            -122.43576049804686,
                            37.752415234354402
                        ]
                    ]
                ]
            }";
            GeoPolygon polygon = JsonSerializer.Deserialize<GeoPolygon>(polygonString);
            var searchResponse = await client.SearchInsideGeometryAsync("coffee", polygon);
            Assert.AreEqual("San Francisco", searchResponse.Value.Results.First().Address.Municipality);
            Assert.IsNotNull("CAFE_PUB", searchResponse.Value.Results.First().PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchInsideRawGeoJsonPolygon()
        {
            var client = CreateClient();
            var polygonString = @"
            {
                ""type"": ""Polygon"",
                ""coordinates"": [
                    [
                    [
                        -122.43576049804686,
                        37.7524152343544
                    ],
                    [
                        -122.4330139159,
                        37.706604725423119
                    ],
                    [
                        -122.36434936523438,
                        37.712059855877314
                    ],
                    [
                        -122.43576049804686,
                        37.7524152343544
                    ]
                    ]
                ]}
            ";
            GeoPolygon polygon = JsonSerializer.Deserialize<GeoPolygon>(polygonString);
            var searchResponse = await client.SearchInsideGeometryAsync("coffee", polygon);
            Assert.AreEqual("San Francisco", searchResponse.Value.Results.First().Address.Municipality);
            Assert.AreEqual("CAFE_PUB", searchResponse.Value.Results.First().PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchInsideGeometryCollection()
        {
            var client = CreateClient();

            #region Snippet:SearchInsideGeometry
            GeoPolygon sfPolygon = new GeoPolygon(new[]
            {
                new GeoPosition(-122.43576049804686, 37.752415234354402),
                new GeoPosition(-122.4330139160, 37.706604725423119),
                new GeoPosition(-122.36434936523438, 37.712059855877314),
                new GeoPosition(-122.43576049804686, 37.7524152343544)
            });

            GeoPolygon taipeiPolygon = new GeoPolygon(new[]
            {
                new GeoPosition(121.56, 25.04),
                new GeoPosition(121.565, 25.04),
                new GeoPosition(121.565, 25.045),
                new GeoPosition(121.56, 25.045),
                new GeoPosition(121.56, 25.04)
            });

            // Search coffee shop in Both polygons, return results in en-US
            Response<SearchAddressResult> searchResponse = await client.SearchInsideGeometryAsync("coffee", new GeoCollection(new[] { sfPolygon, taipeiPolygon }), new SearchInsideGeometryOptions
            {
                Language = SearchLanguage.EnglishUsa
            });

            // Get Taipei Cafe and San Francisco cafe and print first place
            SearchAddressResultItem taipeiCafe = searchResponse.Value.Results.Where(addressItem => addressItem.SearchAddressResultType == "POI" && addressItem.Address.Municipality == "Taipei City").First();
            SearchAddressResultItem sfCafe = searchResponse.Value.Results.Where(addressItem => addressItem.SearchAddressResultType == "POI" && addressItem.Address.Municipality == "San Francisco").First();

            Console.WriteLine("Possible Coffee shop in the Polygons:");
            Console.WriteLine("Coffee shop address in Taipei: {0}", taipeiCafe.Address.FreeformAddress);
            Console.WriteLine("Coffee shop address in San Francisco: {0}", sfCafe.Address.FreeformAddress);
            #endregion
            Assert.AreEqual("CAFE_PUB", sfCafe.PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("CAFE_PUB", taipeiCafe.PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchInsideRawGeoJsonGeometryCollection()
        {
            var client = CreateClient();
            var geometricCollectionString = @"
            {
                ""type"": ""GeometryCollection"",
                ""geometries"": [
                    {
                        ""type"": ""Polygon"",
                        ""coordinates"": [
                            [
                                [-122.43576049804686,37.752415234354402],
                                [-122.4330139159,37.706604725423119],
                                [-122.36434936523438,37.712059855877314],
                                [-122.43576049804686,37.752415234354402]
                            ]
                        ]
                    },
                    {
                        ""type"": ""Polygon"",
                        ""coordinates"": [
                            [
                                [121.56,25.04],
                                [121.565,25.04],
                                [121.565,25.045],
                                [121.56,25.045],
                                [121.56,25.04]
                            ]
                        ]
                    }
                ]
            }";
            var json = JsonSerializer.Deserialize<JsonElement>(geometricCollectionString, new JsonSerializerOptions {});
            GeoCollection geoCollection = JsonSerializer.Deserialize<GeoCollection>(geometricCollectionString, new JsonSerializerOptions {});
            var searchResponse = await client.SearchInsideGeometryAsync("coffee", geoCollection, new SearchInsideGeometryOptions
            {
                Language = SearchLanguage.EnglishUsa
            });
            var taipeiCafe = searchResponse.Value.Results.Where(addressItem => addressItem.SearchAddressResultType == "POI" && addressItem.Address.Municipality == "Taipei City").First();
            var sfCafe = searchResponse.Value.Results.Where(addressItem => addressItem.SearchAddressResultType == "POI" && addressItem.Address.Municipality == "San Francisco").First();
            Assert.AreEqual("CAFE_PUB", sfCafe.PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("CAFE_PUB", taipeiCafe.PointOfInterest.Classifications.First().Code);
        }
    }
}
