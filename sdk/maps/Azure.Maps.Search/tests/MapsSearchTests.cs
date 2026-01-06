// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using Azure.Maps.Search.Models;
using NUnit.Framework;

namespace Azure.Maps.Search.Tests
{
    public class MapsSearchTests : SearchClientLiveTestsBase
    {
        public MapsSearchTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetGeocodingTest()
        {
            var client = CreateClient();
            var query = "1 Microsoft Way, Redmond, WA 98052";
            var response = await client.GetGeocodingAsync(query);
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Features[0].Properties.Address.AddressLine, Is.EqualTo("1 Microsoft Way"));
                Assert.That(response.Value.Features[0].Properties.Address.PostalCode, Is.EqualTo("98052"));
                Assert.That(response.Value.Features[0].Properties.Address.Locality, Is.EqualTo("Redmond"));
            });
        }

        [RecordedTest]
        public void InvalidGetGeocodingTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetGeocodingAsync());
            Assert.That(ex.Status, Is.EqualTo(400));
        }

        [RecordedTest]
        public async Task GetGeocodingBatchTest()
        {
            var client = CreateClient();
            List<GeocodingQuery> queries = new List<GeocodingQuery>
                    {
                        new GeocodingQuery()
                        {
                            Query ="400 Broad St, Seattle, WA 98109"
                        },
                        new GeocodingQuery()
                        {
                            Query ="400 Broad St, Seattle, WA 98109"
                        },
                           new GeocodingQuery()
                        {
                            Query ="350 5th Ave, New York, NY 10118"
                        },
                    };
            var response = await client.GetGeocodingBatchAsync(queries);
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Summary.SuccessfulRequests, Is.EqualTo(3));
                Assert.That(response.Value.Summary.TotalRequests, Is.EqualTo(3));
            });
        }

        [RecordedTest]
        public async Task GetGeocodingBatchOneInvalidQueryTest()
        {
            var client = CreateClient();
            List<GeocodingQuery> queries = new List<GeocodingQuery>
                    {
                        new GeocodingQuery()
                        {
                            Query ="400 Broad St, Seattle, WA 98109"
                        },
                        new GeocodingQuery()
                        {
                            Query ="400 Broad St, Seattle, WA 98109"
                        },
                        new GeocodingQuery()
                        {
                            Query ="350 5th Ave, New York, NY 10118"
                        },
                        new GeocodingQuery()
                        {
                            Query =""
                        },
                    };
            var response = await client.GetGeocodingBatchAsync(queries);
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Summary.TotalRequests, Is.EqualTo(4));
                Assert.That(response.Value.Summary.SuccessfulRequests, Is.EqualTo(3));
            });
        }

        [RecordedTest]
        public void InvalidGetGeocodingBatchTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetGeocodingBatchAsync(new List<GeocodingQuery>()));
            Assert.That(ex.Status, Is.EqualTo(400));
        }

        [RecordedTest]
        public async Task GetReverseGeocodingTest()
        {
            var client = CreateClient();
            GeoPosition coordinates = new GeoPosition(-122.34255, 47.0);
            var response = await client.GetReverseGeocodingAsync(coordinates);
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Features[0].Properties.Address.Locality, Is.EqualTo("Graham"));
                Assert.That(response.Value.Features[0].Properties.Address.CountryRegion.Name, Is.EqualTo("United States"));
                Assert.That(response.Value.Features[0].Properties.Address.StreetName, Is.EqualTo("68th Ave E"));
                Assert.That(response.Value.Features[0].Properties.Address.StreetNumber, Is.EqualTo("28218"));
                Assert.That(response.Value.Features[0].Properties.Address.CountryRegion.Iso, Is.EqualTo("US"));
            });
        }

        [RecordedTest]
        public void InvalidGetReverseGeocodingTest()
        {
            var client = CreateClient();
            // "The provided coordinates in query are invalid, out of range, or not in the expected format"
            GeoPosition coordinates = new GeoPosition(121.0, -100.0);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetReverseGeocodingAsync(coordinates));
            Assert.That(ex.Status, Is.EqualTo(400));
        }

        [RecordedTest]
        public async Task GetReverseGeocodingBatchTest()
        {
            var client = CreateClient();
            List<ReverseGeocodingQuery> items = new List<ReverseGeocodingQuery>
                    {
                        new ReverseGeocodingQuery()
                        {
                            Coordinates = new GeoPosition(-122.34255, 47.0)
                        },
                        new ReverseGeocodingQuery()
                        {
                            Coordinates = new GeoPosition(-122.34255, 47.0)
                        },
                    };
            var response = await client.GetReverseGeocodingBatchAsync(items);
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Summary.SuccessfulRequests, Is.EqualTo(2));
                Assert.That(response.Value.Summary.TotalRequests, Is.EqualTo(2));
            });
        }

        [RecordedTest]
        public async Task GetReverseGeocodingBatchOneInvalidItemTest()
        {
            var client = CreateClient();
            List<ReverseGeocodingQuery> items = new List<ReverseGeocodingQuery>
                    {
                        new ReverseGeocodingQuery()
                        {
                            Coordinates = new GeoPosition(-122.34255, 47.0)
                        },
                        new ReverseGeocodingQuery()
                        {
                            Coordinates = new GeoPosition(-122.34255, 47.0)
                        },
                        new ReverseGeocodingQuery()
                        {
                            Coordinates = new GeoPosition(2.0, 148.0)
                        },
                    };
            var response = await client.GetReverseGeocodingBatchAsync(items);
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Summary.SuccessfulRequests, Is.EqualTo(2));
                Assert.That(response.Value.Summary.TotalRequests, Is.EqualTo(3));
            });
        }
    }
}
