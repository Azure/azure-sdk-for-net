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
            Assert.AreEqual("Milford", fuzzySearchResponse.Value.Results.First().Address.Municipality);
            Assert.AreEqual("Milford Sound", fuzzySearchResponse.Value.Results[1].Address.Municipality);
        }

        [RecordedTest]
        public async Task CanSearchFuzzyBiasedAroundCoordinates()
        {
            var client = CreateClient();
            var fuzzySearchResponse = await client.FuzzySearchAsync("coffee", new FuzzySearchOptions {
                Coordinates = new GeoPosition(121.56, 25.04),
                Language = "en"
            });
            Assert.AreEqual("CAFE_PUB", fuzzySearchResponse.Value.Results.First().PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("Taipei City", fuzzySearchResponse.Value.Results.First().Address.Municipality);
        }

        [RecordedTest]
        public async Task CanBatchSearchFuzzy()
        {
            var client = CreateClient();
            var fuzzySearchBatchResp = await client.FuzzySearchBatchAsync(new[] {
                new FuzzySearchQuery("coffee", new FuzzySearchOptions { Coordinates = new GeoPosition(121.56, 25.04), Language = "en" }),
                new FuzzySearchQuery("pizza", new FuzzySearchOptions { Coordinates = new GeoPosition(121.56, 25.04) })
            });
            Assert.AreEqual("CAFE_PUB", fuzzySearchBatchResp.Value.BatchItems.First().Results.First().PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("Taipei City", fuzzySearchBatchResp.Value.BatchItems.First().Results.First().Address.Municipality);
            Assert.AreEqual("RESTAURANT", fuzzySearchBatchResp.Value.BatchItems[1].Results.First().PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("Taipei City", fuzzySearchBatchResp.Value.BatchItems[1].Results.First().Address.Municipality);
        }

        [RecordedTest]
        public async Task CanPollFuzzySearchBatch()
        {
            var client = CreateClient();
            var operation = await client.StartFuzzySearchBatchAsync(new[] {
                new FuzzySearchQuery("coffee", new FuzzySearchOptions { Coordinates = new GeoPosition(121.56, 25.04), Language = "en" }),
                new FuzzySearchQuery("pizza", new FuzzySearchOptions { Coordinates = new GeoPosition(121.56, 25.04) }),
            });

            var fuzzySearchBatchResp = await operation.WaitForCompletionAsync();
            Assert.AreEqual("CAFE_PUB", fuzzySearchBatchResp.Value.BatchItems.First().Results.First().PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("Taipei City", fuzzySearchBatchResp.Value.BatchItems.First().Results.First().Address.Municipality);
            Assert.AreEqual("RESTAURANT", fuzzySearchBatchResp.Value.BatchItems[1].Results.First().PointOfInterest.Classifications.First().Code);
            Assert.AreEqual("Taipei City", fuzzySearchBatchResp.Value.BatchItems[1].Results.First().Address.Municipality);
        }
    }
}