// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
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
    public class TestPlanetaryComputer04StacSpecificationTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer04StacSpecificationTests(bool isAsync) : base(isAsync)
        {
        }

        public TestPlanetaryComputer04StacSpecificationTests() : base(true)
        {
        }

        /// <summary>
        /// Test getting STAC conformance classes.
        /// Python equivalent: test_01_get_conformance_class
        /// C# method: GetConformanceClass()
        /// </summary>
        [RecordedTest]
        [Category("STAC")]
        [Category("Conformance")]
        public async Task Test04_01_GetConformanceClass()
        {
            // Arrange
            PlanetaryComputerClient client = GetTestClient();
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
        [RecordedTest]
        [Category("STAC")]
        [Category("Specification")]
        public async Task Test04_04_GetCollection_SpecificationCompliance()
        {
            // Arrange
            PlanetaryComputerClient client = GetTestClient();
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
    }
}
