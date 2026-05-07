// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Data-driven mock tests that validate SearchOptions properties are correctly
    /// serialized into the HTTP request body. Uses <see cref="TestCaseSource"/> so
    /// adding coverage for a new property is a single line addition.
    ///
    /// Follows the existing <see cref="SearchMockTests"/> pattern — no recordings,
    /// no live resources. Extends <see cref="ClientTestBase"/> for sync/async variants.
    /// </summary>
    public class SearchOptionsMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://fake-search.search.windows.net/";
        private static readonly string s_apiKey = "FakeApiKey";

        public SearchOptionsMockTests(bool isAsync) : base(isAsync)
        {
        }

        private SearchClient CreateTestClient(MockTransport transport)
        {
            var options = new SearchClientOptions()
            {
                Transport = transport,
            };

            return InstrumentClient(
                new SearchClient(new Uri(s_endpoint), "test-index", new AzureKeyCredential(s_apiKey), options));
        }

        /// <summary>
        /// Data source for SearchOptions property serialization tests.
        /// Each entry: (propertyDescription, searchOptionsConfigurator, expectedJsonFragment).
        ///
        /// To add coverage for a new property, add one yield return line.
        /// </summary>
        public static IEnumerable<TestCaseData> SearchOptionProperties()
        {
            // Filter
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.Filter = "rating gt 4"),
                "\"filter\":\"rating gt 4\"")
                .SetName("Serializes_Filter");

            // IncludeTotalCount
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.IncludeTotalCount = true),
                "\"count\":true")
                .SetName("Serializes_IncludeTotalCount");

            // Skip
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.Skip = 10),
                "\"skip\":10")
                .SetName("Serializes_Skip");

            // Size
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.Size = 25),
                "\"top\":25")
                .SetName("Serializes_Size");

            // QueryType
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.QueryType = SearchQueryType.Full),
                "\"queryType\":\"full\"")
                .SetName("Serializes_QueryType");

            // SearchMode
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.SearchMode = SearchMode.All),
                "\"searchMode\":\"all\"")
                .SetName("Serializes_SearchMode");

            // ScoringProfile
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.ScoringProfile = "myProfile"),
                "\"scoringProfile\":\"myProfile\"")
                .SetName("Serializes_ScoringProfile");

            // HighlightPreTag
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.HighlightPreTag = "<b>"),
                "\"highlightPreTag\":\"<b>\"")
                .SetName("Serializes_HighlightPreTag");

            // HighlightPostTag
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.HighlightPostTag = "</b>"),
                "\"highlightPostTag\":\"</b>\"")
                .SetName("Serializes_HighlightPostTag");

            // MinimumCoverage
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.MinimumCoverage = 80.0),
                "\"minimumCoverage\":80")
                .SetName("Serializes_MinimumCoverage");

            // ScoringStatistics
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.ScoringStatistics = ScoringStatistics.Global),
                "\"scoringStatistics\":\"global\"")
                .SetName("Serializes_ScoringStatistics");

            // SessionId
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.SessionId = "session123"),
                "\"sessionId\":\"session123\"")
                .SetName("Serializes_SessionId");

            // HighlightFields (comma-joined on wire)
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.HighlightFields.Add("description")),
                "\"highlight\":\"description\"")
                .SetName("Serializes_HighlightFields");

            // SearchFields (comma-joined on wire)
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.SearchFields.Add("description")),
                "\"searchFields\":\"description\"")
                .SetName("Serializes_SearchFields");

            // Select (comma-joined on wire)
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.Select.Add("hotelId")),
                "\"select\":\"hotelId\"")
                .SetName("Serializes_Select");

            // OrderBy (comma-joined on wire)
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.OrderBy.Add("rating desc")),
                "\"orderby\":\"rating desc\"")
                .SetName("Serializes_OrderBy");

            // Facets (JSON array on wire)
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.Facets.Add("category")),
                "\"facets\":[\"category\"]")
                .SetName("Serializes_Facets");

            // ScoringParameters (JSON array on wire)
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.ScoringParameters.Add("mylocation--122.2,44.8")),
                "\"scoringParameters\":[\"mylocation--122.2,44.8\"]")
                .SetName("Serializes_ScoringParameters");
        }

        /// <summary>
        /// Validates that each SearchOptions property correctly serializes into the
        /// HTTP request body sent to the service.
        /// </summary>
        [TestCaseSource(nameof(SearchOptionProperties))]
        public async Task PropertySerializesCorrectly(
            Action<SearchOptions> configure,
            string expectedJsonFragment)
        {
            // Arrange: create a mock response (the content doesn't matter — we're testing the request)
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent("{\"value\":[]}");

            var transport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(transport);

            var searchOptions = new SearchOptions();
            configure(searchOptions);

            // Act: trigger the search request
            await client.SearchAsync<SearchDocument>("*", searchOptions);

            // Assert: check the request body contains the expected JSON fragment
            var request = transport.Requests.Single();
            string requestBody = GetRequestContent(request.Content);

            Assert.That(requestBody, Does.Contain(expectedJsonFragment),
                $"Request body did not contain expected JSON fragment.\n" +
                $"Expected fragment: {expectedJsonFragment}\n" +
                $"Actual body: {requestBody}");
        }

        private static string GetRequestContent(RequestContent content)
        {
            if (content == null) return string.Empty;
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
