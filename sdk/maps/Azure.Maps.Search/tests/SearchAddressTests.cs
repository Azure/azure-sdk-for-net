// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Linq;
using Azure.Maps.Search.Models;

namespace Azure.Maps.Search.Tests
{
    public class SearchAddressTests: SearchClientLiveTestsBase
    {
        public SearchAddressTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CanSearchAddress()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Seattle");
            Assert.AreEqual("Washington", searchResult.Value.Results.First().Address.CountrySubdivisionName);
        }

        [RecordedTest]
        public async Task CanSearchMunicipality()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Redmond", new SearchAddressOptions {
                EntityType = GeographicEntityType.Municipality
            });
            Assert.AreEqual("Redmond, WA", searchResult.Value.Results.First().Address.FreeformAddress);
        }

        [RecordedTest]
        public async Task CanSearchAddressBiasedAroundCoordinates()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Road", new SearchAddressOptions {
                Coordinates = new LatLon(25.04, 121.56),
                Language = "en"
            });
            Assert.AreEqual("Xinyi District", searchResult.Value.Results.First().Address.MunicipalitySubdivision);

            searchResult = await client.SearchAddressAsync("Road", new SearchAddressOptions {
                Coordinates = new LatLon(47.6773, -122.0910)
            });
            Assert.AreEqual("Redmond", searchResult.Value.Results.First().Address.Municipality);
        }

        [RecordedTest]
        public async Task CanSearchAddressRestrictedByRegion()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Road", new SearchAddressOptions {
                CountryFilter = new[]{ "FJI" }
            });
            Assert.AreEqual("Fiji", searchResult.Value.Results.First().Address.Country);

            searchResult = await client.SearchAddressAsync("Road", new SearchAddressOptions {
                CountryFilter = new[]{ "NZ" }
            });
            Assert.AreEqual("New Zealand", searchResult.Value.Results.First().Address.Country);
        }

        [RecordedTest]
        public async Task CanSearchAddressRestrictedByBoundingBox()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Moke", new SearchAddressOptions {
                BoundingBox = new BoundingBox(northWest: new LatLon(-44.9905, -191.4481), southEast: new LatLon(-45.0128, -191.4148))
            });

            Assert.AreEqual("Moke Lake Road", searchResult.Value.Results.First().Address.StreetName);
        }

        [RecordedTest]
        public async Task CanSearchStructuredAddress()
        {
            var client = CreateClient();
            var address = new StructuredAddress {
                CountryCode = "US",
                StreetNumber = "15127",
                StreetName = "NE 24th Street",
                Municipality = "Redmond",
                CountrySubdivision = "WA",
                PostalCode = "98052"
            };
            var searchResult = await client.SearchStructuredAddressAsync(address);
            Assert.AreEqual("15127 Northeast 24th Street, Redmond, WA 98052", searchResult.Value.Results.First().Address.FreeformAddress);
        }

        [RecordedTest]
        public async Task CanSearchStructuredPartialAddress()
        {
            var client = CreateClient();
            var address = new StructuredAddress {
                CountryCode = "NZ",
                Municipality = "Closeburn"
            };
            var searchResult = await client.SearchStructuredAddressAsync(address);
            Assert.AreEqual("South Island", searchResult.Value.Results.First().Address.CountrySubdivision);
        }

        [RecordedTest]
        public async Task CanSearchAddressBatch()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressBatchAsync(new[] {
                new SearchAddressQuery("Microsoft Campus"),
                new SearchAddressQuery("Millenium", new SearchAddressOptions { CountryFilter = new[] { "US" }}),
            });

            Assert.AreEqual("Redmond", searchResult.Value.BatchItems.First().Results.First().Address.Municipality);
            Assert.AreEqual("Tucson", searchResult.Value.BatchItems[1].Results.First().Address.Municipality);
        }

        [RecordedTest]
        public async Task CanPollSearchAddressBatch()
        {
            var client = CreateClient();
            var operation = await client.StartSearchAddressBatchAsync(new[]{
                new SearchAddressQuery("Microsoft Campus"),
                new SearchAddressQuery("Millenium", new SearchAddressOptions { CountryFilter = new[] { "US" }}),
            });

            var searchResult = await operation.WaitForCompletionAsync();
            Assert.AreEqual("Redmond", searchResult.Value.BatchItems.First().Results.First().Address.Municipality);
            Assert.AreEqual("Tucson", searchResult.Value.BatchItems[1].Results.First().Address.Municipality);
        }
    }
}
