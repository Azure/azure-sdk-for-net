// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using Azure.Maps.Search.Models;
using NUnit.Framework;

namespace Azure.Maps.Search.Tests
{
    public class ReverseSearchAddressTests: SearchClientLiveTestsBase
    {
        public ReverseSearchAddressTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanResolveCoordinatesToAddress()
        {
            var client = CreateClient();
            #region Snippet:ReverseSearchAddressAsync
            Response<ReverseSearchAddressResult> reverseResult = await client.ReverseSearchAddressAsync(new ReverseSearchOptions
            {
                Coordinates = new GeoPosition(121.0, 24.0),
                Language = SearchLanguage.EnglishUsa
            });
            #endregion
            Assert.AreEqual("Nantou County", reverseResult.Value.Addresses[0].Address.Municipality);
        }

        [RecordedTest]
        public void InvalidReverseSearchAddressTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.ReverseSearchAddressAsync(new ReverseSearchOptions { Coordinates = new GeoPosition(121.0, -1000.0) }));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task CanResolveCoordinatesToCrossStreetAddress()
        {
            var client = CreateClient();
            #region Snippet:ReverseSearchCrossStreetAddress
            var reverseResult = await client.ReverseSearchCrossStreetAddressAsync(new ReverseSearchCrossStreetOptions
            {
                Coordinates = new GeoPosition(121.0, 24.0),
                Language = SearchLanguage.EnglishUsa
            });
            #endregion
            Assert.AreEqual("Niuwei Road Lane 1 \u0026 Niuwei Road", reverseResult.Value.Addresses[0].Address.StreetName);
        }

        [RecordedTest]
        public void InvalidCrossStreetSearchAddressTest()
        {
            var client = CreateClient();
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.ReverseSearchCrossStreetAddressAsync(new ReverseSearchCrossStreetOptions { Coordinates = new GeoPosition(121.0, -1000.0) }));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task CanBatchResolveCoordinatesToAddress()
        {
            var client = CreateClient();
            #region Snippet:GetImmediateReverseSearchAddressBatchAsync
            var reverseResult = await client.GetImmediateReverseSearchAddressBatchAsync(new[] {
                new ReverseSearchAddressQuery(new ReverseSearchOptions { Coordinates = new GeoPosition(121.0, 24.0), Language = "en" }),
                new ReverseSearchAddressQuery(new ReverseSearchOptions { Coordinates = new GeoPosition(-122.333345, 47.606038) }),
            });
            #endregion
            Assert.AreEqual("Nantou County", reverseResult.Value.Results[0].Addresses[0].Address.Municipality);
            Assert.AreEqual("Seattle", reverseResult.Value.Results[1].Addresses[0].Address.Municipality);
        }

        [RecordedTest]
        public async Task CanPoolReverseSearchAddressBatch()
        {
            var client = CreateClient();
            var operation = await client.ReverseSearchAddressBatchAsync(WaitUntil.Started, new[] {
                new ReverseSearchAddressQuery(new ReverseSearchOptions { Coordinates = new GeoPosition(121.0, 24.0), Language = "en" }),
                new ReverseSearchAddressQuery(new ReverseSearchOptions { Coordinates = new GeoPosition(-122.333345, 47.606038) }),
            });
            // delay 400 ms for the task to complete
            await Task.Delay(400);
            var reverseResult = operation.WaitForCompletion();
            Assert.AreEqual("Nantou County", reverseResult.Value.Results[0].Addresses[0].Address.Municipality);
            Assert.AreEqual("Seattle", reverseResult.Value.Results[1].Addresses[0].Address.Municipality);
        }
    }
}
