// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Maps.Search.Models;
using NUnit.Framework;
using System.Linq;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientSamples: SamplesBase<SearchClientTestEnvironment>
    {
        [Test]
        public void SearchingAnAddress()
        {
            #region Snippet:SearchAddress
            var client = new SearchClient(endpoint: new Uri(TestEnvironment.Endpoint), credential: new DefaultAzureCredential());
            SearchAddressResult searchResponse = client.SearchAddress("Seattle");

            var primaryResult = searchResponse.Results.First();
            Console.WriteLine("Country: " + primaryResult.Address.CountryCodeISO3);
            Console.WriteLine("State: " + primaryResult.Address.CountrySubdivision);
            #endregion
        }
    }
}
