// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using Azure.Core.TestFramework;
using Azure.Maps.Search.Models;
using NUnit.Framework;

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
            #region Snippet:SearchAddress
            Response<SearchAddressResult> searchResult = await client.SearchAddressAsync("Seattle");

            SearchAddressResultItem resultItem = searchResult.Value.Results[0];
            Console.WriteLine("First result - Coordinate: {0}, Address: {1}",
                resultItem.Position, resultItem.Address.FreeformAddress);
            #endregion
            Assert.AreEqual("Washington", searchResult.Value.Results[0].Address.CountrySubdivisionName);
        }

        [RecordedTest]
        public async Task CanSearchMunicipality()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Redmond", new SearchAddressOptions
            {
                EntityType = GeographicEntity.Municipality
            });
            Assert.AreEqual("Redmond, WA", searchResult.Value.Results[0].Address.FreeformAddress);
        }

        [RecordedTest]
        public async Task CanSearchAddressBiasedAroundCoordinates()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Road", new SearchAddressOptions
            {
                Coordinates = new GeoPosition(121.56, 25.04),
                Language = SearchLanguage.EnglishUsa
            });
            Assert.AreEqual("Xinyi District", searchResult.Value.Results[0].Address.MunicipalitySubdivision);

            searchResult = await client.SearchAddressAsync("Road", new SearchAddressOptions
            {
                Coordinates = new GeoPosition(-122.0910, 47.6773)
            });
            Assert.AreEqual("Redmond", searchResult.Value.Results[0].Address.Municipality);
        }

        [RecordedTest]
        public async Task CanSearchAddressRestrictedByRegion()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Road", new SearchAddressOptions
            {
                CountryFilter = new[] { "FJI" }
            });
            Assert.AreEqual("Fiji", searchResult.Value.Results[0].Address.Country);

            searchResult = await client.SearchAddressAsync("Road", new SearchAddressOptions
            {
                CountryFilter = new[] { "NZ" }
            });
            Assert.AreEqual("New Zealand", searchResult.Value.Results[0].Address.Country);
        }

        [RecordedTest]
        public async Task CanSearchAddressRestrictedByBoundingBox()
        {
            var client = CreateClient();
            var searchResult = await client.SearchAddressAsync("Moke", new SearchAddressOptions {
                BoundingBox = new GeoBoundingBox(-191.4481, -45.0128, -191.4148, -44.990)
            });

            Assert.AreEqual("Moke Lake Road", searchResult.Value.Results[0].Address.StreetName);
        }

        [RecordedTest]
        public async Task CanSearchStructuredAddress()
        {
            var client = CreateClient();
            #region Snippet:SearchStructuredAddress
            var address = new StructuredAddress
            {
                CountryCode = "US",
                StreetNumber = "15127",
                StreetName = "NE 24th Street",
                Municipality = "Redmond",
                CountrySubdivision = "WA",
                PostalCode = "98052"
            };
            Response<SearchAddressResult> searchResult = await client.SearchStructuredAddressAsync(address);

            SearchAddressResultItem resultItem = searchResult.Value.Results[0];
            Console.WriteLine("First result - Coordinate: {0}, Address: {1}",
                resultItem.Position, resultItem.Address.FreeformAddress);
            #endregion
            Assert.AreEqual("15127 Northeast 24th Street, Redmond, WA 98052", resultItem.Address.FreeformAddress);
        }

        [RecordedTest]
        public void InvalidSearchStructuredAddressTest()
        {
            var client = CreateClient();
            var address = new StructuredAddress { CountryCode = "" };
            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.SearchStructuredAddressAsync(address));
            Assert.AreEqual(400, ex.Status);
        }

        [RecordedTest]
        public async Task CanSearchStructuredPartialAddress()
        {
            var client = CreateClient();
            var address = new StructuredAddress
            {
                CountryCode = "NZ",
                Municipality = "Closeburn"
            };
            var searchResult = await client.SearchStructuredAddressAsync(address);
            Assert.AreEqual("South Island", searchResult.Value.Results[0].Address.CountrySubdivision);
        }

        [RecordedTest]
        public async Task CanSearchAddressBatch()
        {
            var client = CreateClient();
            var searchResult = await client.GetImmediateSearchAddressBatchAsync(new[]
            {
                new SearchAddressQuery("Microsoft Campus"),
                new SearchAddressQuery("Millenium", new SearchAddressOptions { CountryFilter = new[] { "US" }}),
            });

            Assert.AreEqual(2, searchResult.Value.Results.Count);
            Assert.AreEqual("Tucson", searchResult.Value.Results[1].Results[0].Address.Municipality);
        }

        [RecordedTest]
        public async Task CanPollSearchAddressBatch()
        {
            var client = CreateClient();
            var operation = await client.SearchAddressBatchAsync(WaitUntil.Started, new[]
            {
                new SearchAddressQuery("Microsoft Campus"),
                new SearchAddressQuery("Millenium", new SearchAddressOptions { CountryFilter = new[] { "US" }}),
            });

            // delay 400 ms for the task to complete
            await Task.Delay(400);
            var searchResult = operation.WaitForCompletion();
            Assert.AreEqual(2, searchResult.Value.Results.Count);
            Assert.AreEqual("Tucson", searchResult.Value.Results[1].Results[0].Address.Municipality);
        }
    }
}
