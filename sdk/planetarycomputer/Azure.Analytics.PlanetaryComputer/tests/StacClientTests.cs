// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests
{
    /// <summary>
    /// Tests for the STAC (SpatioTemporal Asset Catalog) client functionality.
    /// These tests verify operations for retrieving and searching STAC collections and items.
    /// </summary>
    public class StacClientTests : PlanetaryComputerTestBase
    {
        public StacClientTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Tests the GetCollections operation to retrieve all available STAC collections.
        /// </summary>
        [Test]
        [Category("STAC")]
        [Category("Collections")]
        public async Task GetCollectionsTest()
        {
            PlanetaryComputerProClient client = GetTestClient();
            StacClient stacClient = client.GetStacClient();

            // Call GetCollections async - instrumentation automatically calls sync version when IsAsync=false
            Response response = await stacClient.GetCollectionsAsync(sign: null, durationInMinutes: null, context: null);

            // Validate response using base class helper methods
            ValidateResponse(response, "GetCollections");
            Assert.AreEqual(200, response.Status, "Expected successful response");
            Assert.IsNotNull(response.Content, "Response content should not be null");

            TestContext.WriteLine($"Successfully retrieved collections. Status: {response.Status}");
        }
    }
}
