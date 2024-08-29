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
            Response<GeocodingResponse> searchResult = client.GetGeocoding("1 Microsoft Way, Redmond, WA 98052");
            for (int i = 0; i < searchResult.Value.Features.Count; i++)
            {
                Console.WriteLine("Coordinate:" + string.Join(",", searchResult.Value.Features[i].Geometry.Coordinates));
            }
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
                             AddressLine = "400 Broad St"
                        },
                    };
            Response<GeocodingBatchResponse> results = client.GetGeocodingBatch(queries);

            //Print coordinates
            for (var i = 0; i < results.Value.BatchItems.Count; i++)
            {
                for (var j = 0; j < results.Value.BatchItems[i].Features.Count; j++)
                {
                    Console.WriteLine("Coordinates: " + string.Join(",", results.Value.BatchItems[i].Features[j].Geometry.Coordinates));
                }
            }
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
                Coordinates = new GeoPosition(-122.204141, 47.61256),
                ResultType = BoundaryResultTypeEnum.Locality,
                Resolution = ResolutionEnum.Small,
            };
            Response<Boundary> result = client.GetPolygon(options);
            var count = ((GeoJsonPolygon)((GeoJsonGeometryCollection)result.Value.Geometry).Geometries[0]).Coordinates.Count;
            for (var i = 0; i < count; i++)
            {
                var coorCount = ((GeoJsonPolygon)((GeoJsonGeometryCollection)result.Value.Geometry).Geometries[0]).Coordinates[i].Count;
                for (var j = 0; j < coorCount; j++)
                {
                    Console.WriteLine(string.Join(",", ((GeoJsonPolygon)((GeoJsonGeometryCollection)result.Value.Geometry).Geometries[0]).Coordinates[i][j]));
                }
            }
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

            //Print addresses
            for (int i = 0; i < result.Value.Features.Count; i++)
            {
                Console.WriteLine(result.Value.Features[i].Properties.Address.FormattedAddress);
            }
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
                            Coordinates = new GeoPosition(-122.349309, 47.620498)
                        },
                        new ReverseGeocodingQuery()
                        {
                            Coordinates = new GeoPosition(-122.138679, 47.630356),
                            ResultTypes = new List<ReverseGeocodingResultTypeEnum>(){ ReverseGeocodingResultTypeEnum.Address, ReverseGeocodingResultTypeEnum.Neighborhood }
                        },
                    };
            Response<GeocodingBatchResponse> result = client.GetReverseGeocodingBatch(items);

            //Print addresses
            for (var i = 0; i < result.Value.BatchItems.Count; i++)
            {
                Console.WriteLine(result.Value.BatchItems[i].Features[0].Properties.Address.AddressLine);
                Console.WriteLine(result.Value.BatchItems[i].Features[0].Properties.Address.Neighborhood);
            }
            #endregion
        }
    }
}
