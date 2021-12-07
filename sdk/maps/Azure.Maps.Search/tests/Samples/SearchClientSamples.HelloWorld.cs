// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using Azure.Core.TestFramework;
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
            var endpoint = TestEnvironment.Endpoint;
            var clientId = TestEnvironment.MapAccountClientId;

            #region Snippet:SearchingAnAddress
            var client = new SearchClient(new DefaultAzureCredential(), endpoint, clientId);
            SearchAddressResult searchResponse = client.SearchAddress("Seattle");

            var primaryResult = searchResponse.Results.First();
            Console.WriteLine("Country: " + primaryResult.Address.CountryCodeISO3);
            Console.WriteLine("State: " + primaryResult.Address.CountrySubdivision);
            #endregion
        }
    }
}
