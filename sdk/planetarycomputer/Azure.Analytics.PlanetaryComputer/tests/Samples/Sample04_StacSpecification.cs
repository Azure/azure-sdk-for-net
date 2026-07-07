// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests.Samples
{
    /// <summary>
    /// Samples demonstrating STAC API specification compliance and advanced search capabilities.
    /// </summary>
    public partial class Sample04_StacSpecification : PlanetaryComputerTestBase
    {
        public Sample04_StacSpecification(bool isAsync) : base(isAsync) { }
        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetConformanceClasses()
        {
            #region Snippet:Sample04_GetConformance
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Get STAC API conformance classes
            Response<StacConformanceClasses> response = await stacClient.GetConformanceClassAsync();
            StacConformanceClasses conformance = response.Value;

            Console.WriteLine($"STAC API Conformance Classes ({conformance.ConformsTo.Count}):");
            foreach (Uri conformsTo in conformance.ConformsTo)
            {
                Console.WriteLine($"  - {conformsTo}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ValidateStacCompliance()
        {
            #region Snippet:Sample04_ValidateCompliance
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            string collectionId = "naip";

            // Get a collection and validate STAC compliance
            Response<StacCollectionResource> response = await stacClient.GetCollectionAsync(collectionId);
            StacCollectionResource collection = response.Value;

            // Check required STAC Collection properties
            Console.WriteLine($"Collection ID: {collection.Id}");
            Console.WriteLine($"Type: {collection.Type}"); // Should be "Collection"
            Console.WriteLine($"STAC Version: {collection.StacVersion}");
            Console.WriteLine($"Description: {collection.Description}");
            Console.WriteLine($"License: {collection.License}");

            // Verify extent (spatial and temporal)
            Console.WriteLine($"Spatial Extent: {collection.Extent.Spatial}");
            Console.WriteLine($"Temporal Extent: {collection.Extent.Temporal}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task SearchWithSpatialFilter()
        {
            #region Snippet:Sample04_SearchSpatial
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Search for items within a bounding box using CQL2-JSON
            var searchParams = new StacSearchParameters();
            searchParams.Collections.Add("naip");
            searchParams.FilterLang = FilterLanguage.Cql2Json;

            // Define a spatial filter for Atlanta, Georgia area
            searchParams.Filter["op"] = BinaryData.FromString("\"s_intersects\"");
            searchParams.Filter["args"] = BinaryData.FromObjectAsJson(new object[]
            {
                new Dictionary<string, string> { ["property"] = "geometry" },
                new Dictionary<string, object>
                {
                    ["type"] = "Polygon",
                    ["coordinates"] = new[]
                    {
                        new[]
                        {
                            new[] { -84.46, 33.60 },
                            new[] { -84.39, 33.60 },
                            new[] { -84.39, 33.67 },
                            new[] { -84.46, 33.67 },
                            new[] { -84.46, 33.60 }
                        }
                    }
                }
            });

            searchParams.Limit = 10;

            Response<StacItemCollectionResource> response = await stacClient.SearchAsync(searchParams);
            StacItemCollectionResource results = response.Value;

            Console.WriteLine($"Found {results.Features.Count} items in the specified area");
            foreach (StacItemResource item in results.Features)
            {
                Console.WriteLine($"  Item: {item.Id}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task SearchWithTemporalFilter()
        {
            #region Snippet:Sample04_SearchTemporal
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Search for items within a date range
            var searchParams = new StacSearchParameters();
            searchParams.Collections.Add("naip");
            searchParams.Datetime = "2021-01-01T00:00:00Z/2022-12-31T23:59:59Z";
            searchParams.Limit = 10;

            Response<StacItemCollectionResource> response = await stacClient.SearchAsync(searchParams);
            StacItemCollectionResource results = response.Value;

            Console.WriteLine($"Found {results.Features.Count} items in date range");
            foreach (StacItemResource item in results.Features)
            {
                Console.WriteLine($"  Item: {item.Id}");
                if (item.Properties?.Datetime != null)
                {
                    Console.WriteLine($"    Date: {item.Properties.Datetime:yyyy-MM-dd}");
                }
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task SearchWithSorting()
        {
            #region Snippet:Sample04_SearchSorted
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Search with sorting by datetime (descending - newest first)
            var searchParams = new StacSearchParameters();
            searchParams.Collections.Add("naip");
            searchParams.SortBy.Add(new StacSortExtension("datetime", StacSearchSortingDirection.Desc));
            searchParams.Limit = 5;

            Response<StacItemCollectionResource> response = await stacClient.SearchAsync(searchParams);
            StacItemCollectionResource results = response.Value;

            Console.WriteLine("Items sorted by datetime (newest first):");
            foreach (StacItemResource item in results.Features)
            {
                Console.WriteLine($"  {item.Id} - {item.Properties?.Datetime:yyyy-MM-dd}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetItemCollection()
        {
            #region Snippet:Sample04_GetItemCollection
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Get items from a specific collection
            string collectionId = "naip";
            Response<StacItemCollectionResource> response = await stacClient.GetItemCollectionAsync(
                collectionId,
                limit: 10);

            StacItemCollectionResource items = response.Value;

            Console.WriteLine($"Retrieved {items.Features.Count} items from '{collectionId}' collection");
            foreach (StacItemResource item in items.Features)
            {
                Console.WriteLine($"\nItem: {item.Id}");
                Console.WriteLine($"  Collection: {item.Collection}");
                Console.WriteLine($"  Assets: {string.Join(", ", item.Assets.Keys.Take(5))}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetSpecificItem()
        {
            #region Snippet:Sample04_GetItem
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Get a specific item by ID
            string collectionId = "naip";
            string itemId = "tx_m_2609719_se_14_060_20201216";

            Response<StacItemResource> response = await stacClient.GetItemAsync(collectionId, itemId);
            StacItemResource item = response.Value;

            Console.WriteLine($"Item ID: {item.Id}");
            Console.WriteLine($"Collection: {item.Collection}");
            Console.WriteLine($"Datetime: {item.Properties?.Datetime}");

            Console.WriteLine($"\nAvailable Assets:");
            foreach (var asset in item.Assets)
            {
                Console.WriteLine($"  {asset.Key}: {asset.Value.Href}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetCollectionQueryables()
        {
            #region Snippet:Sample04_GetQueryables
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Get queryable properties for a collection
            string collectionId = "naip";
            Response<QueryableDefinitionsResponse> response =
                await stacClient.GetCollectionQueryablesAsync(collectionId);

            IReadOnlyDictionary<string, BinaryData> queryables = response.Value.AdditionalProperties;

            // Parse the properties schema
            var propertiesJson = JsonDocument.Parse(queryables["properties"]).RootElement;

            Console.WriteLine($"Queryable properties for '{collectionId}':");
            foreach (var property in propertiesJson.EnumerateObject())
            {
                Console.WriteLine($"  - {property.Name}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ComplexSearchQuery()
        {
            #region Snippet:Sample04_ComplexSearch
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Build a complex search with multiple filters
            var searchParams = new StacSearchParameters();
            searchParams.Collections.Add("naip");
            searchParams.FilterLang = FilterLanguage.Cql2Json;

            // Combine spatial, temporal, and collection filters
            searchParams.Filter["op"] = BinaryData.FromString("\"and\"");
            searchParams.Filter["args"] = BinaryData.FromObjectAsJson(new object[]
            {
                // Collection filter
                new Dictionary<string, object>
                {
                    ["op"] = "=",
                    ["args"] = new object[]
                    {
                        new Dictionary<string, string> { ["property"] = "collection" },
                        "naip"
                    }
                },
                // Spatial filter
                new Dictionary<string, object>
                {
                    ["op"] = "s_intersects",
                    ["args"] = new object[]
                    {
                        new Dictionary<string, string> { ["property"] = "geometry" },
                        new Dictionary<string, object>
                        {
                            ["type"] = "Polygon",
                            ["coordinates"] = new[]
                            {
                                new[]
                                {
                                    new[] { -84.46, 33.60 },
                                    new[] { -84.39, 33.60 },
                                    new[] { -84.39, 33.67 },
                                    new[] { -84.46, 33.67 },
                                    new[] { -84.46, 33.60 }
                                }
                            }
                        }
                    }
                },
                // Temporal start filter
                new Dictionary<string, object>
                {
                    ["op"] = ">=",
                    ["args"] = new object[]
                    {
                        new Dictionary<string, string> { ["property"] = "datetime" },
                        "2021-01-01T00:00:00Z"
                    }
                },
                // Temporal end filter
                new Dictionary<string, object>
                {
                    ["op"] = "<=",
                    ["args"] = new object[]
                    {
                        new Dictionary<string, string> { ["property"] = "datetime" },
                        "2022-12-31T23:59:59Z"
                    }
                }
            });

            // Sort results and limit
            searchParams.SortBy.Add(new StacSortExtension("datetime", StacSearchSortingDirection.Desc));
            searchParams.Limit = 50;

            Response<StacItemCollectionResource> response = await stacClient.SearchAsync(searchParams);
            StacItemCollectionResource results = response.Value;

            Console.WriteLine($"Complex search found {results.Features.Count} items");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task IterateCollectionsAndItems()
        {
            #region Snippet:Sample04_IterateCollections
            // Create a Planetary Computer client
#if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

#else

            var client = GetTestClient();

#endif
            StacClient stacClient = client.GetStacClient();

            // Get all collections
            Response<StacCatalogCollections> collectionsResponse = await stacClient.GetCollectionsAsync();
            StacCatalogCollections collections = collectionsResponse.Value;

            Console.WriteLine($"Available Collections ({collections.Collections.Count}):");

            // Iterate through first 5 collections and show sample items
            foreach (StacCollectionResource collection in collections.Collections.Take(5))
            {
                Console.WriteLine($"\nCollection: {collection.Id}");
                Console.WriteLine($"  Title: {collection.Title}");
                Console.WriteLine($"  License: {collection.License}");

                // Get a few items from this collection
                Response<StacItemCollectionResource> itemsResponse =
                    await stacClient.GetItemCollectionAsync(collection.Id, limit: 3);

                Console.WriteLine($"  Sample Items ({itemsResponse.Value.Features.Count}):");
                foreach (StacItemResource item in itemsResponse.Value.Features)
                {
                    Console.WriteLine($"    - {item.Id}");
                }
            }
            #endregion
        }
    }
}
