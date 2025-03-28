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
            Assert.AreEqual("1 Microsoft Way", response.Value.Features[0].Properties.Address.AddressLine);
            Assert.AreEqual("98052", response.Value.Features[0].Properties.Address.PostalCode);
            Assert.AreEqual("Redmond", response.Value.Features[0].Properties.Address.Locality);
        }

        [RecordedTest]
        public void InvalidGetGeocodingTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetGeocodingAsync());
            Assert.AreEqual(400, ex.Status);
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
            Assert.AreEqual(3, response.Value.Summary.SuccessfulRequests);
            Assert.AreEqual(3, response.Value.Summary.TotalRequests);
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
            Assert.AreEqual(4, response.Value.Summary.TotalRequests);
            Assert.AreEqual(3, response.Value.Summary.SuccessfulRequests);
        }

        [RecordedTest]
        public void InvalidGetGeocodingBatchTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetGeocodingBatchAsync(new List<GeocodingQuery>()));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task GetReverseGeocodingTest()
        {
            var client = CreateClient();
            GeoPosition coordinates = new GeoPosition(-122.34255, 47.0);
            var response = await client.GetReverseGeocodingAsync(coordinates);
            Assert.AreEqual("Graham", response.Value.Features[0].Properties.Address.Locality);
            Assert.AreEqual("United States", response.Value.Features[0].Properties.Address.CountryRegion.Name);
            Assert.AreEqual("68th Ave E", response.Value.Features[0].Properties.Address.StreetName);
            Assert.AreEqual("28218", response.Value.Features[0].Properties.Address.StreetNumber);
            Assert.AreEqual("US", response.Value.Features[0].Properties.Address.CountryRegion.Iso);
        }

        [RecordedTest]
        public void InvalidGetReverseGeocodingTest()
        {
            var client = CreateClient();
            // "The provided coordinates in query are invalid, out of range, or not in the expected format"
            GeoPosition coordinates = new GeoPosition(121.0, -100.0);
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetReverseGeocodingAsync(coordinates));
            Assert.AreEqual(400, ex.Status);
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
            Assert.AreEqual(2, response.Value.Summary.SuccessfulRequests);
            Assert.AreEqual(2, response.Value.Summary.TotalRequests);
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
            Assert.AreEqual(2, response.Value.Summary.SuccessfulRequests);
            Assert.AreEqual(3, response.Value.Summary.TotalRequests);
        }
    }
}
