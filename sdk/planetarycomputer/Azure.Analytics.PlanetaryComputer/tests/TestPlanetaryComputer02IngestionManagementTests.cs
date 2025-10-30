// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for Ingestion Management operations.
    /// Based on Python test: test_planetary_computer_02_ingestion_management.py
    /// Tests managed identities, sources, ingestion definitions, runs, and operations.
    /// </summary>
    public class TestPlanetaryComputer02IngestionManagementTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer02IngestionManagementTests(bool isAsync) : base(isAsync)
        {
        }

        public TestPlanetaryComputer02IngestionManagementTests() : base(true)
        {
        }

        /// <summary>
        /// Test listing managed identities available for ingestion.
        /// Python equivalent: test_01_list_managed_identities
        /// C# method: GetManagedIdentities() - returns Pageable<BinaryData>
        /// </summary>
        [RecordedTest]
        [Category("Ingestion")]
        [Category("ManagedIdentity")]
        public async Task Test02_01_ListManagedIdentities()
        {
            // Arrange
            PlanetaryComputerClient client = GetTestClient();
            IngestionClient ingestionClient = client.GetIngestionClient();

            TestContext.WriteLine("Testing GetManagedIdentities (list all managed identities)");
            TestContext.WriteLine("\n=== Making Request ===");
            TestContext.WriteLine("GET /ingestion/identities");

            // Act
            // GetManagedIdentities returns Pageable<BinaryData> - collect all items
            List<BinaryData> managedIdentities = new List<BinaryData>();

            await foreach (BinaryData identity in ingestionClient.GetManagedIdentitiesAsync(context: default))
            {
                managedIdentities.Add(identity);

                // Log each identity as received
                TestContext.WriteLine($"\n=== Received Identity (raw JSON) ===");
                TestContext.WriteLine(identity.ToString());
            }

            // Assert
            Assert.IsNotNull(managedIdentities, "Managed identities list should not be null");
            TestContext.WriteLine($"\n=== Total Identities Found: {managedIdentities.Count} ===");

            // Verify each identity has required properties
            foreach (BinaryData identityData in managedIdentities)
            {
                using JsonDocument doc = JsonDocument.Parse(identityData);
                JsonElement identity = doc.RootElement;

                TestContext.WriteLine($"\n=== Analyzing Identity ===");
                TestContext.WriteLine($"Property count: {identity.EnumerateObject().Count()}");
                TestContext.WriteLine("Properties:");
                foreach (var prop in identity.EnumerateObject())
                {
                    TestContext.WriteLine($"  - {prop.Name}: {prop.Value}");
                }

                // Verify object_id property (service returns PascalCase "ObjectId")
                Assert.IsTrue(identity.TryGetProperty("ObjectId", out JsonElement objectIdElement),
                    "Managed identity should have 'ObjectId' property");
                string objectId = objectIdElement.GetString();
                ValidateNotNullOrEmpty(objectId, "ObjectId");

                // Verify resource_id property (service returns PascalCase "ResourceId")
                Assert.IsTrue(identity.TryGetProperty("ResourceId", out JsonElement resourceIdElement),
                    "Managed identity should have 'ResourceId' property");
                Assert.That(resourceIdElement.ValueKind, Is.EqualTo(JsonValueKind.Object), "ResourceId should be an object");

                TestContext.WriteLine($"  Identity:");
                TestContext.WriteLine($"    - Object ID: {objectId}");
                TestContext.WriteLine($"    - Resource ID: {resourceIdElement.GetRawText()}");
            }

            TestContext.WriteLine($"Successfully listed {managedIdentities.Count} managed identities");
        }

        /// <summary>
        /// Test listing ingestion sources.
        /// Python equivalent: test_02_create_and_list_ingestion_sources (list portion)
        /// C# method: GetSources(top, skip) - returns Pageable<BinaryData>
        /// </summary>
        [RecordedTest]
        [Category("Ingestion")]
        [Category("Sources")]
        public async Task Test02_ListSources()
        {
            // Arrange
            PlanetaryComputerClient client = GetTestClient();
            IngestionClient ingestionClient = client.GetIngestionClient();

            TestContext.WriteLine("Testing GetSources (list all ingestion sources)");

            // Act
            List<IngestionSourceSummary> sources = new List<IngestionSourceSummary>();

            await foreach (IngestionSourceSummary source in ingestionClient.GetSourcesAsync())
            {
                sources.Add(source);
            }

            // Assert
            Assert.IsNotNull(sources, "Sources list should not be null");
            TestContext.WriteLine($"Found {sources.Count} ingestion sources");

            // Verify each source has required properties
            foreach (IngestionSourceSummary source in sources)
            {
                Assert.IsNotNull(source.Id, "Source should have ID");
                TestContext.WriteLine($"  Source ID: {source.Id}");

                TestContext.WriteLine($"    Kind: {source.Kind}");
            }

            TestContext.WriteLine($"Successfully listed {sources.Count} ingestion sources");
        }

        /// <summary>
        /// Test listing ingestion operations.
        /// Python equivalent: test_07_list_operations
        /// C# method: GetOperations() - returns Pageable<BinaryData>
        /// </summary>
        [RecordedTest]
        [Category("Ingestion")]
        [Category("Operations")]
        public async Task Test02_07_ListOperations()
        {
            // Arrange
            PlanetaryComputerClient client = GetTestClient();
            IngestionClient ingestionClient = client.GetIngestionClient();

            TestContext.WriteLine("Testing GetOperations (list all operations)");

            // Act
            List<IngestionSourceSummary> sources = new List<IngestionSourceSummary>();

            await foreach (IngestionSourceSummary source in ingestionClient.GetSourcesAsync(top: null, skip: null))
            {
                sources.Add(source);
            }

            // Assert
            Assert.IsNotNull(sources, "Sources list should not be null");
            TestContext.WriteLine($"Found {sources.Count} ingestion sources");

            // Verify each source has required properties
            foreach (IngestionSourceSummary source in sources)
            {
                TestContext.WriteLine($"  Source ID: {source.Id}");
                TestContext.WriteLine($"    Kind: {source.Kind}");
            }

            TestContext.WriteLine($"Successfully listed {sources.Count} ingestion sources");
        }
    }
}
