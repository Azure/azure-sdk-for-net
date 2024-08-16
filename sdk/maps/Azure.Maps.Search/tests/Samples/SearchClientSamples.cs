// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
#region Snippet:SearchImportNamespaces
using Azure.Maps.Search.Models;
#endregion
using Azure.Core.TestFramework;
#region Snippet:SearchSasAuthImportNamespaces
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
#endregion

using NUnit.Framework;
using Azure.Core.GeoJson;
using Azure.Maps.Search.Models.Queries;
using Azure.Maps.Search.Models.Options;

namespace Azure.Maps.Search.Tests
{
    public class SearchClientSamples: SamplesBase<SearchClientTestEnvironment>
    {
        public void SearchClientViaSubscriptionKey()
        {
            #region Snippet:InstantiateSearchClientViaSubscriptionKey
            // Create a SearchClient that will authenticate through Subscription Key (Shared key)
            AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
            MapsSearchClient client = new MapsSearchClient(credential);
            #endregion
        }

        public void SearchClientViaMicrosoftEntra()
        {
            #region Snippet:InstantiateSearchClientViaMicrosoftEntra
            // Create a MapsSearchClient that will authenticate through Microsoft Entra
            DefaultAzureCredential credential = new DefaultAzureCredential();
            string clientId = "<My Map Account Client Id>";
            MapsSearchClient client = new MapsSearchClient(credential, clientId);
            #endregion
        }

        public void SearchClientViaSas()
        {
            #region Snippet:InstantiateSearchClientViaSas
            // Get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // Authenticate your client
            ArmClient armClient = new ArmClient(cred);

            string subscriptionId = "MyMapsSubscriptionId";
            string resourceGroupName = "MyMapsResourceGroupName";
            string accountName = "MyMapsAccountName";

            // Get maps account resource
            ResourceIdentifier mapsAccountResourceId = MapsAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
            MapsAccountResource mapsAccount = armClient.GetMapsAccountResource(mapsAccountResourceId);

            // Assign SAS token information
            // Every time you want to SAS token, update the principal ID, max rate, start and expiry time
            string principalId = "MyManagedIdentityObjectId";
            int maxRatePerSecond = 500;

            // Set start and expiry time for the SAS token in round-trip date/time format
            DateTime now = DateTime.Now;
            string start = now.ToString("O");
            string expiry = now.AddDays(1).ToString("O");

            MapsAccountSasContent sasContent = new MapsAccountSasContent(MapsSigningKey.PrimaryKey, principalId, maxRatePerSecond, start, expiry);
            Response<MapsAccountSasToken> sas = mapsAccount.GetSas(sasContent);

            // Create a SearchClient that will authenticate via SAS token
            AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
            MapsSearchClient client = new MapsSearchClient(sasCredential);
            #endregion
        }

         [Test]
        public void GetGeocoding()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetGeocoding
            var query = "15171 NE 24th St, Redmond, WA 98052, United States";
            Response <GeocodingResponse> result = client.GetGeocoding(query);
            Console.WriteLine("Result for query: \"{0}\"", query);
            Console.WriteLine(result);
            #endregion
        }

        [Test]
        public void GetGeocodingBatch()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetGeocodingBatch
            List<GeocodingQuery> queries = new List<GeocodingQuery>
                    {
                        new GeocodingQuery()
                        {
                            Query ="15171 NE 24th St, Redmond, WA 98052, United States"
                        },
                        new GeocodingQuery()
                        {
                             Coordinates = new GeoPosition(121.5, 25.0)
                        },
                    };
            Response<GeocodingBatchResponse> results = client.GetGeocodingBatch(queries);
            Console.WriteLine(results);
            #endregion
        }

        [Test]
        public void GetPolygon()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetPolygon
            GetPolygonOptions options = new GetPolygonOptions()
            {
                Coordinates = new GeoPosition(121.5, 25.0)
            };
            Response<Boundary> result = client.GetPolygon(options);
            Console.WriteLine(result);
            #endregion
        }

        [Test]
        public void GetReverseGeocoding()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetReverseGeocoding
            GeoPosition coordinates = new GeoPosition(-122.138685, 47.6305637);
            Response<GeocodingResponse> result = client.GetReverseGeocoding(coordinates);
            #endregion
        }

        [Test]
        public void GetReverseGeocodingBatch()
        {
            var clientOptions = new MapsSearchClientOptions()
            {
                Endpoint = TestEnvironment.Endpoint
            };
            var clientId = TestEnvironment.MapAccountClientId;
            var client = new MapsSearchClient(TestEnvironment.Credential, clientId, clientOptions);
            #region Snippet:GetReverseGeocodingBatch
            List<ReverseGeocodingQuery> items = new List<ReverseGeocodingQuery>
                    {
                        new ReverseGeocodingQuery()
                        {
                            Coordinates = new GeoPosition(121.53, 25.0)
                        },
                        new ReverseGeocodingQuery()
                        {
                            Coordinates = new GeoPosition(121.5, 25.0)
                        },
                    };
            Response<GeocodingBatchResponse> result = client.GetReverseGeocodingBatch(items);
            #endregion
        }
    }
}
