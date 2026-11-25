// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    [TestFixture(true)]
    [TestFixture(false)]
    public class SearchOptionsMockTests : ClientTestBase
    {
        private static readonly string s_endpoint = "https://fake-search.search.windows.net/";
        private static readonly string s_apiKey = "FakeApiKey";

        public SearchOptionsMockTests(bool isAsync) : base(isAsync)
        {
        }

        private SearchClient CreateTestClient(
            MockTransport transport,
            SearchClientOptions.ServiceVersion serviceVersion = SearchClientOptions.LatestVersion)
        {
            var options = new SearchClientOptions(serviceVersion)
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
            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.MoreLikeThis = "hotel-42"),
                "\"moreLikeThis\":\"hotel-42\"")
                .SetName("Serializes_MoreLikeThis");

            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.AgenticOptions = new AgenticSearchOptions { MaxRuntimeInSeconds = 30 }),
                "\"agenticOptions\":{\"maxRuntimeInSeconds\":30}")
                .SetName("Serializes_AgenticOptions");

            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.QueryType = SearchQueryType.Agentic),
                "\"queryType\":\"agentic\"")
                .SetName("Serializes_AgenticQueryType");

            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.VectorSearch = new VectorSearchOptions
                {
                    Queries =
                    {
                        new VectorizedQuery(new[] { 0.1f, 0.2f })
                        {
                            Fields = { "contentVector" },
                            TopicGraph = new BalancedVectorQueryTopicGraph { MinDiversityPoolSize = 1000 }
                        }
                    }
                }),
                "\"topicGraph\":{\"kind\":\"balanced\",\"minDiversityPoolSize\":1000}")
                .SetName("Serializes_VectorTopicGraph");

            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.VectorSearch = new VectorSearchOptions
                {
                    Queries =
                    {
                        new VectorizedQuery(new[] { 0.1f, 0.2f })
                        {
                            Fields = { "contentVector" },
                            TopicGraph = new DiverseVectorQueryTopicGraph { DiversityFactor = 0.5f, MinDiversityPoolSize = 1000 }
                        }
                    }
                }),
                "\"topicGraph\":{\"kind\":\"diverse\",\"diversityFactor\":0.5,\"minDiversityPoolSize\":1000}")
                .SetName("Serializes_DiverseVectorTopicGraph");

            yield return new TestCaseData(
                (Action<SearchOptions>)(o => o.VectorSearch = new VectorSearchOptions
                {
                    Queries =
                    {
                        new VectorizedQuery(new[] { 0.1f, 0.2f })
                        {
                            Fields = { "contentVector" },
                            TopicGraph = new NoneVectorQueryTopicGraph()
                        }
                    }
                }),
                "\"topicGraph\":{\"kind\":\"none\"}")
                .SetName("Serializes_DisabledVectorTopicGraph");

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
            await client.SearchAsync<SearchDocument>(searchOptions.MoreLikeThis is null ? "*" : null, searchOptions);

            // Assert: check the request body contains the expected JSON fragment
            var request = transport.Requests.Single();
            string requestBody = GetRequestContent(request.Content);

            Assert.That(requestBody, Does.Contain(expectedJsonFragment),
                $"Request body did not contain expected JSON fragment.\n" +
                $"Expected fragment: {expectedJsonFragment}\n" +
                $"Actual body: {requestBody}");
        }

        [TestCase(SearchClientOptions.ServiceVersion.V2026_10_01, null)]
        [TestCase(SearchClientOptions.ServiceVersion.V2026_10_01, "hotels")]
        [TestCase(SearchClientOptions.ServiceVersion.V2026_11_01_Preview, null)]
        [TestCase(SearchClientOptions.ServiceVersion.V2026_11_01_Preview, "hotels")]
        public async Task UntouchedSemanticFieldsStayOmittedAfterContinuation(
            SearchClientOptions.ServiceVersion serviceVersion,
            string configurationName)
        {
            SearchOptions options = new SearchOptions
            {
                SemanticSearch = new SemanticSearchOptions { SemanticConfigurationName = configurationName }
            };
            string continuation = SearchContinuationToken.Serialize(new Uri(s_endpoint), options);
            var transport = new MockTransport(_ =>
            {
                var response = new MockResponse(200);
                response.SetContent("{\"value\":[]}");
                return response;
            });
            SearchClient client = CreateTestClient(transport, serviceVersion);

            foreach (SearchOptions requestOptions in new[] { options, new SearchOptions(continuation) })
            {
                await client.SearchAsync<SearchDocument>("hotel", requestOptions);
            }

            foreach (Request request in transport.Requests)
            {
                using JsonDocument json = JsonDocument.Parse(GetRequestContent(request.Content));
                Assert.IsFalse(json.RootElement.TryGetProperty("semanticFields", out _));
                if (configurationName != null)
                {
                    Assert.AreEqual(configurationName, json.RootElement.GetProperty("semanticConfiguration").GetString());
                }
            }
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task ExplicitSemanticFieldsSurviveContinuation(bool empty)
        {
            SearchOptions options = new SearchOptions
            {
                SemanticSearch = new SemanticSearchOptions { SemanticFields = { "description", "title" } }
            };
            if (empty)
            {
                options.SemanticSearch.SemanticFields.Clear();
            }
            string continuation = SearchContinuationToken.Serialize(new Uri(s_endpoint), options);
            var transport = new MockTransport(_ =>
            {
                var response = new MockResponse(200);
                response.SetContent("{\"value\":[]}");
                return response;
            });
            SearchClient client = CreateTestClient(transport);

            foreach (SearchOptions requestOptions in new[] { options, new SearchOptions(continuation) })
            {
                await client.SearchAsync<SearchDocument>("hotel", requestOptions);
            }

            foreach (Request request in transport.Requests)
            {
                using JsonDocument json = JsonDocument.Parse(GetRequestContent(request.Content));
                Assert.AreEqual(empty ? "" : "description,title", json.RootElement.GetProperty("semanticFields").GetString());
            }
        }

        private static string GetRequestContent(RequestContent content)
        {
            if (content == null)
                return string.Empty;
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
