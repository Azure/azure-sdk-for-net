// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using Azure.Maps.Search.Models;
using Azure.Core.GeoJson;
using System;

namespace Azure.Maps.Search.Tests
{
    public class FuzzySearchTests: SearchClientLiveTestsBase
    {
        public FuzzySearchTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanSearchFuzzy()
        {
            var client = CreateClient();
            var fuzzySearchResponse = await client.FuzzySearchAsync("Milford", new FuzzySearchOptions { CountryFilter = new[] { "NZ" } });
            Assert.AreEqual("Milford", fuzzySearchResponse.Value.Results[0].Address.Municipality);
            Assert.AreEqual("Milford Sound", fuzzySearchResponse.Value.Results[1].Address.Municipality);
        }

        [RecordedTest]
        public async Task CanSearchFuzzyBiasedAroundCoordinates()
        {
            var client = CreateClient();
            #region Snippet:FuzzySearch
            var fuzzySearchResponse = await client.FuzzySearchAsync("coffee", new FuzzySearchOptions {
                Coordinates = new GeoPosition(121.56, 25.04),
                Language = "en"
            });
            #endregion
            Assert.AreEqual("CAFE_PUB", fuzzySearchResponse.Value.Results[0].PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("Taipei City", fuzzySearchResponse.Value.Results[0].Address.Municipality);
        }

        [RecordedTest]
        public void InvalidFuzzySearchTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.FuzzySearchAsync("", new FuzzySearchOptions {}));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task CanBatchSearchFuzzy()
        {
            var client = CreateClient();
            var fuzzySearchBatchResp = await client.FuzzyBatchSearchAsync(new[] {
                new FuzzySearchQuery("coffee", new FuzzySearchOptions { Coordinates = new GeoPosition(121.56, 25.04), Language = "en" }),
                new FuzzySearchQuery("pizza", new FuzzySearchOptions { Coordinates = new GeoPosition(121.56, 25.04) })
            });
            Assert.AreEqual("CAFE_PUB", fuzzySearchBatchResp.Value.Results[0].Results[0].PointOfInterest.Classifications[0].Code);
            Assert.AreEqual("Taipei City", fuzzySearchBatchResp.Value.Results[0].Results[0].Address.Municipality);
            Assert.AreEqual("RESTAURANT", fuzzySearchBatchResp.Value.Results[1].Results[0].PointOfInterest.Classifications[0].Code);
            Assert.AreEqual("Taipei City", fuzzySearchBatchResp.Value.Results[1].Results[0].Address.Municipality);
        }

        [RecordedTest]
        public async Task CanPollFuzzySearchBatch()
        {
            var client = CreateClient();
            var operation = await client.StartFuzzyBatchSearchAsync(new[] {
                new FuzzySearchQuery("coffee", new FuzzySearchOptions { Coordinates = new GeoPosition(121.56, 25.04), Language = "en" }),
                new FuzzySearchQuery("pizza", new FuzzySearchOptions { Coordinates = new GeoPosition(121.56, 25.04) }),
            });

            // delay 400 ms for the task to complete
            await Task.Delay(400);
            var fuzzySearchBatchResp = operation.WaitForCompletion();

            Assert.AreEqual("CAFE_PUB", fuzzySearchBatchResp.Value.Results[0].Results[0].PointOfInterest.Classifications[0].Code);
            Assert.AreEqual("Taipei City", fuzzySearchBatchResp.Value.Results[0].Results[0].Address.Municipality);
            Assert.AreEqual("RESTAURANT", fuzzySearchBatchResp.Value.Results[1].Results[0].PointOfInterest.Classifications[0].Code);
            Assert.AreEqual("Taipei City", fuzzySearchBatchResp.Value.Results[1].Results[0].Address.Municipality);
        }
    }
}
