// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for STAC Specification compliance.
    /// Based on Python test: test_planetary_computer_04_stac_specification.py
    /// Tests STAC API conformance, collection/item retrieval, and search operations.
    /// </summary>
    [AsyncOnly]
    public class TestPlanetaryComputer04StacSpecificationTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer04StacSpecificationTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Test getting STAC conformance classes.
        /// Python equivalent: test_01_get_conformance_class
        /// C# method: GetConformanceClass()
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Conformance")]
        public async Task Test04_01_GetConformanceClass()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            TestContext.WriteLine("Testing GetConformanceClass (STAC API conformance)");

            // Act
            Response<StacConformanceClasses> response = await stacClient.GetConformanceClassAsync();

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetConformanceClass");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacConformanceClasses conformance = response.Value;
            Assert.IsNotNull(conformance, "Conformance should not be null");
            Assert.IsNotNull(conformance.ConformsTo, "ConformsTo should not be null");

            int conformanceCount = conformance.ConformsTo.Count;
            Assert.Greater(conformanceCount, 0, "Should have at least one conformance class");

            TestContext.WriteLine($"Number of conformance classes: {conformanceCount}");

            // Log all conformance classes
            for (int i = 0; i < conformance.ConformsTo.Count; i++)
            {
                TestContext.WriteLine($"  [{i}]: {conformance.ConformsTo[i]}");
            }

            // Check for core STAC conformance classes (from Python test)
            string[] expectedUris = new[]
            {
                "http://www.opengis.net/spec/ogcapi-features-1/1.0/conf/core",
                "https://api.stacspec.org/v1.0.0/core",
                "https://api.stacspec.org/v1.0.0/collections",
                "https://api.stacspec.org/v1.0.0/item-search"
            };

            // Validate that all expected URIs are present
            var foundUris = new System.Collections.Generic.List<string>();
            foreach (string expectedUri in expectedUris)
            {
                if (conformance.ConformsTo.Any(uri => uri.ToString() == expectedUri))
                {
                    foundUris.Add(expectedUri);
                    TestContext.WriteLine($"Supports: {expectedUri}");
                }
            }

            Assert.AreEqual(expectedUris.Length, foundUris.Count,
                $"Expected all {expectedUris.Length} core STAC URIs, found {foundUris.Count}: {string.Join(", ", foundUris)}");

            TestContext.WriteLine($"Successfully retrieved {conformanceCount} conformance classes");
        }

        /// <summary>
        /// Test getting a specific STAC collection (duplicate of StacCollectionTests for categorization).
        /// Python equivalent: test_04_get_collection
        /// C# method: GetCollection(collectionId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Specification")]
        public async Task Test04_04_GetCollection_SpecificationCompliance()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollection for STAC spec compliance: {collectionId}");

            // Act
            Response<StacCollectionResource> response = await stacClient.GetCollectionAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollection");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacCollectionResource collection = response.Value;

            // Verify STAC Collection spec compliance
            Assert.IsNotNull(collection.Id, "Collection must have 'id'");
            Assert.AreEqual("Collection", collection.Type, "Type must be 'Collection'");
            Assert.IsNotNull(collection.StacVersion, "Collection must have 'stac_version'");
            Assert.That(collection.StacVersion, Does.Match(@"^\d+\.\d+\.\d+"), "STAC version should be in format X.Y.Z");

            Assert.IsNotNull(collection.Description, "Collection must have 'description'");
            Assert.IsNotNull(collection.License, "Collection must have 'license'");
            Assert.IsNotNull(collection.Extent, "Collection must have 'extent'");

            // Verify extent structure
            Assert.IsNotNull(collection.Extent.Spatial, "Extent must have 'spatial' property");
            Assert.IsNotNull(collection.Extent.Temporal, "Extent must have 'temporal' property");

            Assert.IsNotNull(collection.Links, "Collection must have 'links'");
            Assert.Greater(collection.Links.Count, 0, "Collection should have at least one link");

            TestContext.WriteLine($"Collection '{collectionId}' is STAC {collection.StacVersion} compliant");
        }

        /// <summary>
        /// Test listing STAC collections.
        /// Python equivalent: test_03_list_collections
        /// C# method: GetCollections()
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Collections")]
        public async Task Test04_03_ListCollections()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine("Testing GetCollections (list STAC collections)");

            // Act
            Response<StacCatalogCollections> response = await stacClient.GetCollectionsAsync();

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollections");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacCatalogCollections collectionsResponse = response.Value;
            Assert.IsNotNull(collectionsResponse, "Collections response should not be null");
            Assert.IsNotNull(collectionsResponse.Collections, "Collections should not be null");
            Assert.Greater(collectionsResponse.Collections.Count, 0, "Should have at least one collection");
            Assert.GreaterOrEqual(collectionsResponse.Collections.Count, 5, $"Expected at least 5 collections, got {collectionsResponse.Collections.Count}");

            TestContext.WriteLine($"Retrieved {collectionsResponse.Collections.Count} collections");

            // Log first 5 collections with details
            for (int i = 0; i < Math.Min(5, collectionsResponse.Collections.Count); i++)
            {
                StacCollectionResource collection = collectionsResponse.Collections[i];
                TestContext.WriteLine($"\nCollection {i + 1}:");
                TestContext.WriteLine($"  ID: {collection.Id}");
                if (!string.IsNullOrEmpty(collection.Title))
                {
                    TestContext.WriteLine($"  Title: {collection.Title}");
                }
                if (!string.IsNullOrEmpty(collection.Description))
                {
                    string desc = collection.Description.Length > 150
                        ? collection.Description.Substring(0, 150) + "..."
                        : collection.Description;
                    TestContext.WriteLine($"  Description: {desc}");
                }
                if (!string.IsNullOrEmpty(collection.License))
                {
                    TestContext.WriteLine($"  License: {collection.License}");
                }
            }

            // Validate collection structure
            StacCollectionResource firstCollection = collectionsResponse.Collections[0];
            Assert.IsNotNull(firstCollection.Id, "Collection should have id");
            Assert.IsNotEmpty(firstCollection.Id, "Collection ID should not be empty");
            Assert.IsNotNull(firstCollection.Extent, "Collection should have extent");

            // Validate that the test collection is in the list
            bool foundTestCollection = collectionsResponse.Collections.Any(c => c.Id == collectionId);
            Assert.IsTrue(foundTestCollection, $"{collectionId} collection should be present");
        }

        /// <summary>
        /// Test searching STAC items with spatial filter.
        /// Python equivalent: test_05_search_items_with_spatial_filter
        /// C# method: Search(StacSearchParameters)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Search")]
        public async Task Test04_05_SearchItemsWithSpatialFilter()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine("Testing Search with spatial filter (CQL2-JSON)");

            // Create search with spatial filter using CQL2-JSON (matching Python implementation)
            var searchParams = new StacSearchParameters();
            searchParams.Collections.Add(collectionId);
            searchParams.FilterLang = FilterLanguage.Cql2Json;

            // Build CQL2-JSON filter as a dictionary - the entire filter structure goes into the Filter dictionary
            searchParams.Filter["op"] = BinaryData.FromString("\"and\"");
            searchParams.Filter["args"] = BinaryData.FromObjectAsJson(new object[]
            {
                new Dictionary<string, object>
                {
                    ["op"] = "=",
                    ["args"] = new object[]
                    {
                        new Dictionary<string, string> { ["property"] = "collection" },
                        collectionId
                    }
                },
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
                                    new[] { -84.46416308610219, 33.6033686729869 },
                                    new[] { -84.38815071170247, 33.6033686729869 },
                                    new[] { -84.38815071170247, 33.6713179813099 },
                                    new[] { -84.46416308610219, 33.6713179813099 },
                                    new[] { -84.46416308610219, 33.6033686729869 }
                                }
                            }
                        }
                    }
                },
                new Dictionary<string, object>
                {
                    ["op"] = ">=",
                    ["args"] = new object[]
                    {
                        new Dictionary<string, string> { ["property"] = "datetime" },
                        "2021-01-01T00:00:00Z"
                    }
                },
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

            searchParams.SortBy.Add(new StacSortExtension("datetime", StacSearchSortingDirection.Desc));
            searchParams.Limit = 50;

            // Act
            Response<StacItemCollectionResource> response = await stacClient.SearchAsync(searchParams);

            // Assert
            ValidateResponse(response.GetRawResponse(), "Search");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacItemCollectionResource searchResponse = response.Value;
            Assert.IsNotNull(searchResponse, "Search response should not be null");
            Assert.IsNotNull(searchResponse.Features, "Response should have features");
            Assert.GreaterOrEqual(searchResponse.Features.Count, 2, $"Expected at least 2 items in spatial search, got {searchResponse.Features.Count}");

            TestContext.WriteLine($"Search returned {searchResponse.Features.Count} items");

            // Log details of first few items
            for (int i = 0; i < Math.Min(3, searchResponse.Features.Count); i++)
            {
                StacItemResource item = searchResponse.Features[i];
                TestContext.WriteLine($"\nItem {i + 1}:");
                TestContext.WriteLine($"  ID: {item.Id}");
                TestContext.WriteLine($"  Collection: {item.Collection}");
                if (item.Geometry != null)
                {
                    TestContext.WriteLine($"  Geometry type: {item.Geometry.GetType().Name}");
                }
            }

            // Validate items are from the correct collection
            if (searchResponse.Features.Count > 0)
            {
                StacItemResource firstItem = searchResponse.Features[0];
                Assert.IsNotNull(firstItem.Id, "Item should have id");
                Assert.IsNotNull(firstItem.Collection, "Item should have collection");
                Assert.AreEqual(collectionId, firstItem.Collection, "Item collection should match search collection");
            }
        }

        /// <summary>
        /// Test listing items in a collection.
        /// Python equivalent: test_06_get_item_collection
        /// C# method: GetItemCollection(collectionId, limit)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Items")]
        public async Task Test04_06_GetItemCollection()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetItemCollection for collection: {collectionId}");

            // Act
            Response<StacItemCollectionResource> response = await stacClient.GetItemCollectionAsync(collectionId, limit: 10);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetItemCollection");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacItemCollectionResource itemsResponse = response.Value;
            Assert.IsNotNull(itemsResponse, "Items response should not be null");
            Assert.IsNotNull(itemsResponse.Features, "Response should have features");
            Assert.GreaterOrEqual(itemsResponse.Features.Count, 5, $"Expected at least 5 items, got {itemsResponse.Features.Count}");

            TestContext.WriteLine($"Retrieved {itemsResponse.Features.Count} items from collection {collectionId}");

            // Log first few items
            for (int i = 0; i < Math.Min(5, itemsResponse.Features.Count); i++)
            {
                StacItemResource item = itemsResponse.Features[i];
                TestContext.WriteLine($"\nItem {i + 1}:");
                TestContext.WriteLine($"  ID: {item.Id}");
                TestContext.WriteLine($"  Collection: {item.Collection}");
                if (item.Assets != null)
                {
                    var assetKeys = item.Assets.Keys.Take(5).ToList();
                    TestContext.WriteLine($"  Assets: {string.Join(", ", assetKeys)}");
                }
            }

            // Validate items have expected asset types
            if (itemsResponse.Features.Count > 0)
            {
                StacItemResource firstItem = itemsResponse.Features[0];
                Assert.IsNotNull(firstItem.Assets, "Item should have assets");
                Assert.GreaterOrEqual(firstItem.Assets.Count, 2, $"Expected at least 2 assets, got {firstItem.Assets.Count}");

                // Check for common assets
                string[] commonAssets = new[] { "image", "tilejson", "thumbnail", "rendered_preview" };
                var foundAssets = commonAssets.Where(asset => firstItem.Assets.ContainsKey(asset)).ToList();
                Assert.GreaterOrEqual(foundAssets.Count, 1, $"Expected at least one common asset type, found: {string.Join(", ", foundAssets)}");
            }
        }

        /// <summary>
        /// Test getting queryable properties for a collection.
        /// Python equivalent: test_07_get_collection_queryables
        /// C# method: GetCollectionQueryables(collectionId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Queryables")]
        public async Task Test04_07_GetCollectionQueryables()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollectionQueryables for collection: {collectionId}");

            // Act
            Response<IReadOnlyDictionary<string, BinaryData>> response = await stacClient.GetCollectionQueryablesAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollectionQueryables");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            IReadOnlyDictionary<string, BinaryData> queryables = response.Value;
            Assert.IsNotNull(queryables, "Queryables should not be null");

            TestContext.WriteLine($"Retrieved queryables for collection: {collectionId}");

            // The queryables is a JSON Schema object - check the schema structure
            Assert.IsTrue(queryables.ContainsKey("$schema"), "Queryables should have '$schema' key");
            Assert.IsTrue(queryables.ContainsKey("properties"), "Queryables should have 'properties' key");

            // Parse the properties to count the actual queryable fields
            var propertiesJson = JsonDocument.Parse(queryables["properties"]).RootElement;
            int propertyCount = propertiesJson.EnumerateObject().Count();

            Assert.GreaterOrEqual(propertyCount, 3, $"Expected at least 3 queryable properties, got {propertyCount}");
            TestContext.WriteLine($"Found {propertyCount} queryable properties in schema");

            // Log the queryable property names
            TestContext.WriteLine("Available queryable properties:");
            foreach (var prop in propertiesJson.EnumerateObject())
            {
                TestContext.WriteLine($"  - {prop.Name}");
            }

            // Log first 15 queryable properties
            int count = 0;
            foreach (var kvp in queryables.Take(15))
            {
                TestContext.WriteLine($"\nQueryable {++count}: {kvp.Key}");
                try
                {
                    var propJson = JsonDocument.Parse(kvp.Value).RootElement;
                    if (propJson.TryGetProperty("description", out var desc))
                    {
                        TestContext.WriteLine($"  Description: {desc.GetString()}");
                    }
                    if (propJson.TryGetProperty("type", out var type))
                    {
                        TestContext.WriteLine($"  Type: {type.GetString()}");
                    }
                    if (propJson.TryGetProperty("$ref", out var refProp))
                    {
                        TestContext.WriteLine($"  Reference: {refProp.GetString()}");
                    }
                }
                catch
                {
                    // Skip if not valid JSON object
                }
            }
        }

        /// <summary>
        /// Test searching items with temporal filter.
        /// Python equivalent: test_08_search_items_with_temporal_filter
        /// C# method: Search(StacSearchParameters)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Search")]
        public async Task Test04_08_SearchItemsWithTemporalFilter()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine("Testing Search with temporal filter");

            // Create search with temporal range
            var searchParams = new StacSearchParameters();
            searchParams.Collections.Add(collectionId);
            searchParams.Datetime = "2021-01-01T00:00:00Z/2022-12-31T00:00:00Z";
            searchParams.Limit = 10;

            // Act
            Response<StacItemCollectionResource> response = await stacClient.SearchAsync(searchParams);

            // Assert
            ValidateResponse(response.GetRawResponse(), "Search");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacItemCollectionResource searchResponse = response.Value;
            Assert.IsNotNull(searchResponse, "Search response should not be null");
            Assert.IsNotNull(searchResponse.Features, "Response should have features");
            Assert.GreaterOrEqual(searchResponse.Features.Count, 5, $"Expected at least 5 items in temporal search, got {searchResponse.Features.Count}");

            TestContext.WriteLine($"Temporal search returned {searchResponse.Features.Count} items");

            // Validate temporal filtering - all items should have datetime
            for (int i = 0; i < Math.Min(3, searchResponse.Features.Count); i++)
            {
                StacItemResource item = searchResponse.Features[i];
                TestContext.WriteLine($"\nItem {i + 1}: {item.Id}");
                Assert.IsNotNull(item.Properties, "Item should have properties");

                // Access datetime from AdditionalProperties if not a direct property
                if (item.Properties.Datetime != null)
                {
                    TestContext.WriteLine($"  Datetime: {item.Properties.Datetime}");
                }
                else if (item.Properties.AdditionalProperties.ContainsKey("datetime"))
                {
                    TestContext.WriteLine($"  Datetime: {item.Properties.AdditionalProperties["datetime"]}");
                }
            }
        }

        /// <summary>
        /// Test searching items with sorting.
        /// Python equivalent: test_09_search_items_with_sorting
        /// C# method: Search(StacSearchParameters)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Search")]
        public async Task Test04_09_SearchItemsWithSorting()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine("Testing Search with sorting");

            // Search with descending sort by datetime
            var searchParamsDesc = new StacSearchParameters();
            searchParamsDesc.Collections.Add(collectionId);
            searchParamsDesc.SortBy.Add(new StacSortExtension("datetime", StacSearchSortingDirection.Desc));
            searchParamsDesc.Limit = 5;

            // Act - DESC sort
            Response<StacItemCollectionResource> responseDesc = await stacClient.SearchAsync(searchParamsDesc);

            // Assert - DESC sort
            ValidateResponse(responseDesc.GetRawResponse(), "Search DESC");
            Assert.AreEqual(200, responseDesc.GetRawResponse().Status, "Expected successful response");

            StacItemCollectionResource searchResponseDesc = responseDesc.Value;
            Assert.IsNotNull(searchResponseDesc, "Search response should not be null");
            Assert.IsNotNull(searchResponseDesc.Features, "Response should have features");
            Assert.GreaterOrEqual(searchResponseDesc.Features.Count, 3, $"Expected at least 3 items in DESC sort, got {searchResponseDesc.Features.Count}");

            TestContext.WriteLine($"Search with DESC sorting returned {searchResponseDesc.Features.Count} items");
            foreach (var item in searchResponseDesc.Features)
            {
                TestContext.WriteLine($"Item: {item.Id}");
                if (item.Properties != null && item.Properties.Datetime != null)
                {
                    TestContext.WriteLine($"  Datetime: {item.Properties.Datetime}");
                }
            }

            // Search with ascending sort
            var searchParamsAsc = new StacSearchParameters();
            searchParamsAsc.Collections.Add(collectionId);
            searchParamsAsc.SortBy.Add(new StacSortExtension("datetime", StacSearchSortingDirection.Asc));
            searchParamsAsc.Limit = 5;

            // Act - ASC sort
            Response<StacItemCollectionResource> responseAsc = await stacClient.SearchAsync(searchParamsAsc);

            // Assert - ASC sort
            ValidateResponse(responseAsc.GetRawResponse(), "Search ASC");
            Assert.AreEqual(200, responseAsc.GetRawResponse().Status, "Expected successful response");

            StacItemCollectionResource searchResponseAsc = responseAsc.Value;
            Assert.IsNotNull(searchResponseAsc, "ASC search response should not be null");
            Assert.IsNotNull(searchResponseAsc.Features, "ASC response should have features");
            Assert.GreaterOrEqual(searchResponseAsc.Features.Count, 3, $"Expected at least 3 items in ASC sort, got {searchResponseAsc.Features.Count}");

            TestContext.WriteLine($"\nSearch with ASC sorting returned {searchResponseAsc.Features.Count} items");
            foreach (var item in searchResponseAsc.Features)
            {
                TestContext.WriteLine($"Item: {item.Id}");
                if (item.Properties != null && item.Properties.Datetime != null)
                {
                    TestContext.WriteLine($"  Datetime: {item.Properties.Datetime}");
                }
            }
        }

        /// <summary>
        /// Test getting a specific STAC item.
        /// Python equivalent: test_12_get_item
        /// C# method: GetItem(collectionId, itemId)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Items")]
        public async Task Test04_12_GetItem()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetItem for collection: {collectionId}");

            // First, get an item ID from the collection
            Response<StacItemCollectionResource> itemsResponse = await stacClient.GetItemCollectionAsync(collectionId, limit: 1);

            Assert.Greater(itemsResponse.Value.Features.Count, 0, "Should have at least one item to test");

            string itemId = itemsResponse.Value.Features[0].Id;
            TestContext.WriteLine($"Getting item: {itemId}");

            // Act - Get the specific item
            Response<StacItemResource> response = await stacClient.GetItemAsync(collectionId, itemId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetItem");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacItemResource item = response.Value;
            Assert.IsNotNull(item, "Item should not be null");
            Assert.AreEqual(itemId, item.Id, "Item ID should match requested ID");
            Assert.AreEqual(collectionId, item.Collection, "Item collection should match");

            // Validate item structure
            Assert.IsNotNull(item.Geometry, "Item should have geometry");
            Assert.IsNotNull(item.Properties, "Item should have properties");
            Assert.IsNotNull(item.Assets, "Item should have assets");
            Assert.GreaterOrEqual(item.Assets.Count, 2, $"Expected at least 2 assets, got {item.Assets.Count}");

            TestContext.WriteLine($"Retrieved item: {item.Id}");
            TestContext.WriteLine($"  Collection: {item.Collection}");

            if (item.Properties != null && item.Properties.Datetime != null)
            {
                TestContext.WriteLine($"  Datetime: {item.Properties.Datetime}");
            }

            if (item.Assets != null)
            {
                var assetKeys = item.Assets.Keys.ToList();
                TestContext.WriteLine($"  Assets ({assetKeys.Count}): {string.Join(", ", assetKeys)}");

                // Validate common asset types
                string[] commonAssets = new[] { "image", "tilejson", "thumbnail", "rendered_preview" };
                var foundAssets = commonAssets.Where(asset => item.Assets.ContainsKey(asset)).ToList();
                TestContext.WriteLine($"  Found common assets: {string.Join(", ", foundAssets)}");
            }
        }
    }
}
