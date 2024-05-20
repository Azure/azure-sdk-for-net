// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Maps.Search.Models;
using NUnit.Framework;

namespace Azure.Maps.Search.Tests
{
    public class MapsSearchTests: SearchClientLiveTestsBase
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
            List<GeocodingBatchRequestItem> queries = new List<GeocodingBatchRequestItem>
                    {
                        new GeocodingBatchRequestItem()
                        {
                            Query ="400 Broad St, Seattle, WA 98109"
                        },
                        new GeocodingBatchRequestItem()
                        {
                            Query ="400 Broad St, Seattle, WA 98109"
                        },
                           new GeocodingBatchRequestItem()
                        {
                            Query ="350 5th Ave, New York, NY 10118"
                        },
                    };
            GeocodingBatchRequestBody body = new GeocodingBatchRequestBody(queries);
            var response = await client.GetGeocodingBatchAsync(body);
            Assert.AreEqual(3, response.Value.Summary.SuccessfulRequests);
            Assert.AreEqual(3, response.Value.Summary.TotalRequests);
        }

        [RecordedTest]
        public async Task GetGeocodingBatchOneInvalidQueryTest()
        {
            var client = CreateClient();
            List<GeocodingBatchRequestItem> queries = new List<GeocodingBatchRequestItem>
                    {
                        new GeocodingBatchRequestItem()
                        {
                            Query ="400 Broad St, Seattle, WA 98109"
                        },
                        new GeocodingBatchRequestItem()
                        {
                            Query ="400 Broad St, Seattle, WA 98109"
                        },
                        new GeocodingBatchRequestItem()
                        {
                            Query ="350 5th Ave, New York, NY 10118"
                        },
                        new GeocodingBatchRequestItem()
                        {
                            Query =""
                        },
                    };
            GeocodingBatchRequestBody body = new GeocodingBatchRequestBody(queries);
            var response = await client.GetGeocodingBatchAsync(body);
            Assert.AreEqual(4, response.Value.Summary.TotalRequests);
            Assert.AreEqual(3, response.Value.Summary.SuccessfulRequests);
        }

        [RecordedTest]
        public void InvalidGetGeocodingBatchTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetGeocodingBatchAsync(new GeocodingBatchRequestBody()));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task GetReverseGeocodingTest()
        {
            var client = CreateClient();
            IList<double> coordinates = new[] { -122.34255, 47.65555 };
            var response = await client.GetReverseGeocodingAsync(coordinates);
            Assert.AreEqual("Seattle", response.Value.Features[0].Properties.Address.Locality);
        }

        [RecordedTest]
        public void InvalidGetReverseGeocodingTest()
        {
            var client = CreateClient();
            // "The provided coordinates in query are invalid, out of range, or not in the expected format"
            IList<double> coordinates = new[] { 121.0, -100.0 };
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.GetReverseGeocodingAsync(coordinates));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task GetReverseGeocodingBatchTest()
        {
            var client = CreateClient();
            List<ReverseGeocodingBatchRequestItem> items = new List<ReverseGeocodingBatchRequestItem>
                    {
                        new ReverseGeocodingBatchRequestItem()
                        {
                            Coordinates = new[] { -122.34255, 47.65555 }
                        },
                        new ReverseGeocodingBatchRequestItem()
                        {
                            Coordinates = new[] { -122.34255, 47.65555 }
                        },
                    };
            ReverseGeocodingBatchRequestBody body = new ReverseGeocodingBatchRequestBody(items);
            var response = await client.GetReverseGeocodingBatchAsync(body);
            Assert.AreEqual(2, response.Value.Summary.SuccessfulRequests);
            Assert.AreEqual(2, response.Value.Summary.TotalRequests);
        }

        [RecordedTest]
        public async Task GetReverseGeocodingBatchOneInvalidItemTest()
        {
            var client = CreateClient();
            List<ReverseGeocodingBatchRequestItem> items = new List<ReverseGeocodingBatchRequestItem>
                    {
                        new ReverseGeocodingBatchRequestItem()
                        {
                            Coordinates = new[] { -122.34255, 47.65555 }
                        },
                        new ReverseGeocodingBatchRequestItem()
                        {
                            Coordinates = new[] { -122.34255, 47.65555 }
                        },
                        new ReverseGeocodingBatchRequestItem()
                        {
                            Coordinates = new[] { 2.294911, 148.858561 }
                        },
                    };
            ReverseGeocodingBatchRequestBody body = new ReverseGeocodingBatchRequestBody(items);
            var response = await client.GetReverseGeocodingBatchAsync(body);
            Assert.AreEqual(2, response.Value.Summary.SuccessfulRequests);
            Assert.AreEqual(3, response.Value.Summary.TotalRequests);
        }
    }
}
