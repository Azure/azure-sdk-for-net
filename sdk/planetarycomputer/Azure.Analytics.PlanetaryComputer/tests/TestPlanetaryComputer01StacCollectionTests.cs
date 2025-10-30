// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Additional tests for STAC Collection operations.
    /// Based on Python test: test_planetary_computer_01_stac_collection.py
    /// Complements existing StacClientTests.cs with collection listing and metadata operations.
    /// </summary>
    [AsyncOnly]
    public class TestPlanetaryComputer01StacCollectionTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer01StacCollectionTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Test listing all STAC collections.
        /// Python equivalent: test_01_list_collections
        /// C# method: GetCollections(sign=null, durationInMinutes=null)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Collections")]
        public async Task Test01_01_ListCollections()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            TestContext.WriteLine("Testing GetCollections (list all STAC collections)");

            // Act
            Response<StacCatalogCollections> response = await stacClient.GetCollectionsAsync();

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollections");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacCatalogCollections collections = response.Value;
            Assert.IsNotNull(collections, "Collections should not be null");
            Assert.IsNotNull(collections.Collections, "Collections array should not be null");

            // Verify collections array exists
            int collectionCount = collections.Collections.Count;
            TestContext.WriteLine($"Number of collections: {collectionCount}");

            // Verify we have at least one collection
            Assert.Greater(collectionCount, 0, "Should have at least one collection");

            // Verify first collection has required STAC properties
            if (collectionCount > 0)
            {
                StacCollectionResource firstCollection = collections.Collections[0];

                Assert.IsNotNull(firstCollection.Id, "Collection should have 'id' property");
                string collectionId = firstCollection.Id;
                ValidateNotNullOrEmpty(collectionId, "collection.id");

                TestContext.WriteLine($"First collection ID: {collectionId}");

                // Verify other STAC collection properties
                Assert.IsNotNull(firstCollection.Type, "Collection should have 'type' property");
                Assert.IsNotNull(firstCollection.Links, "Collection should have 'links' property");
                Assert.IsNotNull(firstCollection.StacVersion, "Collection should have 'stac_version' property");

                if (firstCollection.Title != null)
                {
                    string title = firstCollection.Title;
                    TestContext.WriteLine($"First collection title: {title}");
                }
            }

            TestContext.WriteLine($"Successfully listed {collectionCount} collections");
        }

        /// <summary>
        /// Test getting a specific STAC collection by ID.
        /// Python equivalent: test_03_get_collection
        /// C# method: GetCollection(collectionId, sign=null, durationInMinutes=null)
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("GetCollection")]
        public async Task Test01_03_GetCollection()
        {
            // Arrange
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Testing GetCollection for collection: {collectionId}");

            // Act
            Response<StacCollectionResource> response = await stacClient.GetCollectionAsync(collectionId);

            // Assert
            ValidateResponse(response.GetRawResponse(), "GetCollection");
            Assert.AreEqual(200, response.GetRawResponse().Status, "Expected successful response");

            StacCollectionResource collection = response.Value;
            Assert.IsNotNull(collection, "Collection should not be null");

            // Verify collection ID matches
            Assert.IsNotNull(collection.Id, "Response should contain 'id' property");
            string returnedId = collection.Id;
            Assert.AreEqual(collectionId, returnedId, "Returned collection ID should match requested ID");

            // Verify STAC collection required properties
            Assert.IsNotNull(collection.Type, "Collection should have 'type' property");
            Assert.AreEqual("Collection", collection.Type, "Type should be 'Collection'");

            Assert.IsNotNull(collection.StacVersion, "Collection should have 'stac_version' property");
            ValidateNotNullOrEmpty(collection.StacVersion, "stac_version");
            TestContext.WriteLine($"STAC version: {collection.StacVersion}");

            Assert.IsNotNull(collection.Links, "Collection should have 'links' property");
            Assert.Greater(collection.Links.Count, 0, "Links should have at least one item");

            Assert.IsNotNull(collection.Extent, "Collection should have 'extent' property");
            Assert.IsNotNull(collection.License, "Collection should have 'license' property");

            // Log additional properties
            if (collection.Title != null)
            {
                TestContext.WriteLine($"Collection title: {collection.Title}");
            }

            if (collection.Description != null)
            {
                string description = collection.Description;
                if (description.Length > 100)
                {
                    description = description.Substring(0, 100) + "...";
                }
                TestContext.WriteLine($"Collection description: {description}");
            }

            TestContext.WriteLine($"Successfully retrieved collection: {returnedId}");
        }
    }
}
