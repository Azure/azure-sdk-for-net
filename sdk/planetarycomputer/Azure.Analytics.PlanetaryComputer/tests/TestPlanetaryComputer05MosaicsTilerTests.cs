// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for Mosaics Tiler operations using TilerClient.
    /// Tests are mapped from Python tests in test_planetary_computer_05_mosaics_tiler.py.
    /// </summary>
    [Category("Tiler")]
    [Category("Mosaics")]
    [AsyncOnly]
    public class TestPlanetaryComputer05MosaicsTilerTests : PlanetaryComputerTestBase
    {
        public TestPlanetaryComputer05MosaicsTilerTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Tests registering a mosaics search with STAC search parameters.
        /// Maps to Python test: test_01_register_mosaics_search
        /// </summary>
        [Test]
        [Category("RegisterSearch")]
        public async Task Test05_01_RegisterMosaicsSearch()
        {
            // Arrange
            var client = GetTestClient();
            var tilerClient = client.GetTilerClient();
            string collectionId = TestEnvironment.CollectionId;

            TestContext.WriteLine($"Input - collection_id: {collectionId}");

            // Create search parameters - filter to 2021-2022 date range with CQL2-Text
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            var sortBy = new[]
            {
                new StacSortExtension("datetime", StacSearchSortingDirection.Desc)
            };

            TestContext.WriteLine($"Filter: {filter}");
            TestContext.WriteLine($"Filter Language: cql2-text");

            // Act - Use convenience method instead of JSON serialization
            Response<TilerMosaicSearchRegistrationResult> response = await tilerClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text,
                sortBy: sortBy
            );

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);

            TilerMosaicSearchRegistrationResult result = response.Value;
            ValidateNotNullOrEmpty(result.SearchId, "Search ID");

            TestContext.WriteLine($"Search ID: {result.SearchId}");

            // Search ID should be a non-empty string (typically a hash)
            Assert.That(result.SearchId.Length, Is.GreaterThan(0), "Search ID should not be empty");

            // In live mode, verify search ID format (typically alphanumeric hash)
            if (Mode == RecordedTestMode.Live)
            {
                Assert.That(result.SearchId, Does.Match(@"^[a-zA-Z0-9]+$"),
                    "Search ID should be alphanumeric (hash format)");
            }
        }

        /// <summary>
        /// Tests getting mosaics search info after registration.
        /// Maps to Python test: test_02_get_mosaics_search_info
        /// </summary>
        [Test]
        [Category("SearchInfo")]
        public async Task Test05_02_GetMosaicsSearchInfo()
        {
            // Arrange
            var client = GetTestClient();
            var tilerClient = client.GetTilerClient();
            string collectionId = TestEnvironment.CollectionId;

            // First, register a search to get a search ID with CQL2-Text
            string filter = $"collection = '{collectionId}' AND datetime >= TIMESTAMP('2021-01-01T00:00:00Z') AND datetime <= TIMESTAMP('2022-12-31T23:59:59Z')";

            Response<TilerMosaicSearchRegistrationResult> registerResponse = await tilerClient.RegisterMosaicsSearchAsync(
                filter: filter,
                filterLanguage: FilterLanguage.Cql2Text
            );

            ValidateResponse(registerResponse);
            string searchId = registerResponse.Value.SearchId;

            TestContext.WriteLine($"Registered Search ID: {searchId}");

            // Act - Get search info for the registered search
            Response<TilerStacSearchRegistration> response = await tilerClient.GetMosaicsSearchInfoAsync(searchId);

            // Assert
            ValidateResponse(response, "GetMosaicsSearchInfo");

            TilerStacSearchRegistration searchInfo = response.Value;
            Assert.IsNotNull(searchInfo, "Search info should not be null");

            TestContext.WriteLine($"Search registration retrieved successfully");
            TestContext.WriteLine($"Search info retrieved for search ID: {searchId}");
        }
    }
}
