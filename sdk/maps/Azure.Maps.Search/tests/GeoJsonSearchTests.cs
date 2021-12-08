// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Maps.Search.Models;

namespace Azure.Maps.Search.Tests
{
    public class GeoJsonSearchTests: SearchClientLiveTestsBase
    {
        public GeoJsonSearchTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanDescribeSearchResultReferencedGeometry()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Seattle");
            var geometry0Id = searchResult.Value.Results.First().DataSources.Geometry.Id;
            var geometry1Id = searchResult.Value.Results[1].DataSources.Geometry.Id;

            // Seattle municipality geometry
            var polygonResponse = await client.ListPolygonsAsync(new[] { geometry0Id, geometry1Id });
            Assert.IsInstanceOf(typeof(GeoJsonMultiPolygon), polygonResponse.Value.Polygons.First().GeometryData.Features.First().Geometry);
            Assert.IsInstanceOf(typeof(GeoJsonPolygon), polygonResponse.Value.Polygons[1].GeometryData.Features.First().Geometry);

            var multiPolygon = polygonResponse.Value.Polygons.First().GeometryData.Features.First().Geometry as GeoJsonMultiPolygon;
            var polygon = polygonResponse.Value.Polygons[1].GeometryData.Features.First().Geometry as GeoJsonPolygon;
            Assert.IsTrue(multiPolygon.Coordinates.Count > 0);
            Assert.IsTrue(polygon.Coordinates.Count > 0);
        }

        [RecordedTest]
        public async Task CanSearchInsidePolygon()
        {
            var client = CreateClient();
            var polygon = new GeoJsonPolygon(new[] {
                new[] {
                    new[] { -122.43576049804686, 37.7524152343544 },
                    new[] { -122.43301391601563, 37.706604725423119 },
                    new[] { -122.36434936523438, 37.712059855877314 },
                    new[] { -122.43576049804686, 37.7524152343544 }
                }
            });

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
                        -122.43301391601563,
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

            var json = JsonSerializer.Deserialize<JsonElement>(polygonString, new JsonSerializerOptions {});
            var polygon = GeoJsonPolygon.FromJsonElement(json);
            var searchResponse = await client.SearchInsideGeometryAsync("coffee", polygon);
            Assert.AreEqual("San Francisco", searchResponse.Value.Results.First().Address.Municipality);
            Assert.AreEqual("CAFE_PUB", searchResponse.Value.Results.First().PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchInsideGeometryCollection()
        {
            var client = CreateClient();

            var sfPolygon = new GeoJsonPolygon(new[] {
                new[] {
                    new[] { -122.43576049804686, 37.7524152343544 },
                    new[] { -122.43301391601563, 37.706604725423119 },
                    new[] { -122.36434936523438, 37.712059855877314 },
                    new[] { -122.43576049804686, 37.7524152343544 }
                }
            });

            var taipeiPolygon = new GeoJsonPolygon(new[] {
                new[] {
                    new[] { 121.56, 25.04 },
                    new[] { 121.565, 25.04 },
                    new[] { 121.565, 25.045 },
                    new[] { 121.56, 25.045 },
                    new[] { 121.56, 25.04 },
                }
            });

            var searchResponse = await client.SearchInsideGeometryAsync("coffee", new SearchInsideGeometryCollection(new[] { sfPolygon, taipeiPolygon }), new SearchInsideGeometryOptions {
                Language = "en"
            });
            var taipeiCaffe = searchResponse.Value.Results.Where(addressItem => addressItem.Type == "POI" && addressItem.Address.Municipality == "Taipei City").First();
            var sfCaffe = searchResponse.Value.Results.Where(addressItem => addressItem.Type == "POI" && addressItem.Address.Municipality == "San Francisco").First();
            Assert.AreEqual("CAFE_PUB", sfCaffe.PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("CAFE_PUB", taipeiCaffe.PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchInsideRawGeoJsonGeometryCollection()
        {
            var client = CreateClient();

            var geometryCollectionString = @"
            {
                ""type"": ""GeometryCollection"",
                ""geometries"": [
                {
                    ""type"": ""Polygon"",
                    ""coordinates"": [
                    [
                        [
                            -122.43576049804686,
                            37.7524152343544
                        ],
                        [
                            -122.43301391601563,
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
                    ]
                },
                {
                    ""type"": ""Polygon"",
                    ""coordinates"": [
                    [
                        [
                            121.56,
                            25.04
                        ],
                        [
                            121.565,
                            25.04
                        ],
                        [
                            121.565,
                            25.045
                        ],
                        [
                            121.56,
                            25.045
                        ],
                        [
                            121.56,
                            25.04
                        ]
                    ]
                    ]
                }]
            }
            ";

            var json = JsonSerializer.Deserialize<JsonElement>(geometryCollectionString, new JsonSerializerOptions {});
            var geometryCollection = SearchInsideGeometryCollection.FromJsonElement(json);
            var searchResponse = await client.SearchInsideGeometryAsync("coffee", geometryCollection, new SearchInsideGeometryOptions {
                Language = "en"
            });
            var taipeiCaffe = searchResponse.Value.Results.Where(addressItem => addressItem.Type == "POI" && addressItem.Address.Municipality == "Taipei City").First();
            var sfCaffe = searchResponse.Value.Results.Where(addressItem => addressItem.Type == "POI" && addressItem.Address.Municipality == "San Francisco").First();
            Assert.AreEqual("CAFE_PUB", sfCaffe.PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("CAFE_PUB", taipeiCaffe.PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchInsideFeatureCollection()
        {
            var client = CreateClient();
            var polygon = new GeoJsonPolygon(new[] {
                new[] {
                    new[] { -122.43576049804686, 37.7524152343544 },
                    new[] { -122.43301391601563, 37.706604725423119 },
                    new[] { -122.36434936523438, 37.712059855877314 },
                    new[] { -122.43576049804686, 37.7524152343544 }
                }
            });
            var searchResponse = await client.SearchInsideGeometryAsync("coffee", new SearchInsideFeatureCollection(new List<GeoJsonFeature> {
                new GeoJsonPolygonFeature(polygon) {
                    Properties = new GeoJsonObject()
                },
                new GeoJsonCircleFeature(new GeoJsonPoint(new[] { -122.1269, 47.6397 })){
                    Properties = new GeoJsonCircleFeatureProperties {
                        Radius = 100,
                        SubType = "Circle"
                    }
                }
            }));

            Assert.AreEqual("San Francisco", searchResponse.Value.Results.First().Address.Municipality);
            Assert.IsNotNull("CAFE_PUB", searchResponse.Value.Results.First().PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchInsideRawGeoJsonFeatureCollection()
        {
            var client = CreateClient();
            var featureCollectionString = @"
            {
                ""type"": ""FeatureCollection"",
                ""features"": [
                {
                    ""type"": ""Feature"",
                    ""geometry"": {
                    ""type"": ""Polygon"",
                    ""coordinates"": [
                        [
                        [
                            -122.43576049804686,
                            37.7524152343544
                        ],
                        [
                            -122.43301391601563,
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
                    ]
                    },
                    ""properties"": {}
                },
                {
                    ""type"": ""Feature"",
                    ""geometry"": {
                    ""type"": ""Point"",
                    ""coordinates"": [
                        -122.126986,
                        47.639754
                    ]
                    },
                    ""properties"": {
                        ""subType"": ""Circle"",
                        ""radius"": 100
                    }
                }
                ]
            }";

            var json = JsonSerializer.Deserialize<JsonElement>(featureCollectionString, new JsonSerializerOptions {});
            var featureCollection = SearchInsideFeatureCollection.FromJsonElement(json);
            var searchResponse = await client.SearchInsideGeometryAsync("coffee", featureCollection);

            Assert.AreEqual("San Francisco", searchResponse.Value.Results.First().Address.Municipality);
            Assert.IsNotNull("CAFE_PUB", searchResponse.Value.Results.First().PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchPointOfInterestAlongRoute()
        {
            var client = CreateClient();

            var lineString = new GeoJsonLineString(new[] {
                new[] { 121.03684902191162, 24.809729582963467 },
                new[] { 121.03638768196106, 24.808979706076794 },
                new[] { 121.03898406028748, 24.808083743328694 },
                new[] { 121.03933811187744, 24.808940751309397 },
                new[] { 121.03684902191162, 24.809729582963467 }
            });

            var searchResult = await client.SearchPointOfInterestAlongRouteAsync("park", 1000, lineString);
            Assert.AreEqual("PARK_RECREATION_AREA", searchResult.Value.Results.First().PointOfInterest.Classifications.First().Code);
        }

        [RecordedTest]
        public async Task CanSearchPointOfInterestAlongRawGeoJsonRoute()
        {
            var client = CreateClient();

            var rawLineString = @"
            {
                ""type"": ""LineString"",
                ""coordinates"": [
                    [
                        121.03684902191162,
                        24.809729582963467
                    ],
                    [
                        121.03638768196106,
                        24.808979706076794
                    ],
                    [
                        121.03898406028748,
                        24.808083743328694
                    ],
                    [
                        121.03933811187744,
                        24.808940751309397
                    ],
                    [
                        121.03684902191162,
                        24.809729582963467
                    ]
                ]
            }";

            var json = JsonSerializer.Deserialize<JsonElement>(rawLineString, new JsonSerializerOptions {});
            var lineString = GeoJsonLineString.FromJsonElement(json);

            var searchResult = await client.SearchPointOfInterestAlongRouteAsync("park", 1000, lineString);
            Assert.AreEqual("PARK_RECREATION_AREA", searchResult.Value.Results.First().PointOfInterest.Classifications.First().Code);
        }
    }
}
