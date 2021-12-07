// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using Azure.Maps.Search.Models;

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
            var reverseResult = await client.ReverseSearchAddressAsync(new LatLon(24.0, 121.0), new ReverseSearchOptions {
                Language = "en"
            });
            Assert.AreEqual("Nantou County", reverseResult.Value.Addresses.First().Address.Municipality);
        }

        [RecordedTest]
        public async Task CanResolveCoordinatesToCrossStreetAddress()
        {
            var client = CreateClient();
            var reverseResult = await client.ReverseSearchCrossStreetAddressAsync(new LatLon(24.0, 121.0), new ReverseSearchCrossStreetOptions {
                Language = "en"
            });
            Assert.AreEqual("Niuwei Road Lane 1 \u0026 Niuwei Road", reverseResult.Value.Addresses.First().Address.StreetName);
        }

        [RecordedTest]
        public async Task CanBatchResolveCoordinatesToAddress()
        {
            var client = CreateClient();
            var reverseResult = await client.ReverseSearchAddressBatchAsync(new[] {
                new ReverseSearchAddressQuery(new LatLon(24.0, 121.0), new ReverseSearchOptions { Language = "en" }),
                new ReverseSearchAddressQuery(new LatLon(47.606038, -122.333345)),
            });
            Assert.AreEqual("Nantou County", reverseResult.Value.BatchItems.First().Addresses.First().Address.Municipality);
            Assert.AreEqual("Seattle", reverseResult.Value.BatchItems[1].Addresses.First().Address.Municipality);
        }

        [RecordedTest]
        public async Task CanPoolReverseSearchAddressBatch()
        {
            var client = CreateClient();
            var operation = await client.StartReverseSearchAddressBatchAsync(new[] {
                new ReverseSearchAddressQuery(new LatLon(24.0, 121.0), new ReverseSearchOptions { Language = "en" }),
                new ReverseSearchAddressQuery(new LatLon(47.606038, -122.333345)),
            });

            var reverseResult = await operation.WaitForCompletionAsync();
            Assert.AreEqual("Nantou County", reverseResult.Value.BatchItems.First().Addresses.First().Address.Municipality);
            Assert.AreEqual("Seattle", reverseResult.Value.BatchItems[1].Addresses.First().Address.Municipality);
        }
    }
}