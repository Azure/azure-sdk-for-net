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
        public void RouteClientViaAAD()
        {
            #region Snippet:InstantiateRouteClientViaAAD
            // Create a MapsRouteClient that will authenticate through Active Directory
            var credential = new DefaultAzureCredential();
            var clientId = "<My Map Account Client Id>";
            MapsRouteClient client = new MapsRouteClient(credential, clientId);
            #endregion
        }

        public void RouteClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateRouteClientViaSubscriptionKey
            // Create a MapsRouteClient that will authenticate through Subscription Key (Shared key)
            var credential = new AzureKeyCredential("<My Subscription Key>");
            MapsRouteClient client = new MapsRouteClient(credential);
            #endregion
        }
        
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
