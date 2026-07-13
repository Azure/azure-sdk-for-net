// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if AZURE_SEARCH_PREVIEW

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Mock-transport tests for the page-level <c>@search.debug</c> envelope on
    /// <see cref="SearchResults{T}.DebugInfo"/>. Preview-only.
    /// </summary>
    [TestFixture(true)]
    [TestFixture(false)]
    public class SearchDebugInfoMockTests : ClientTestBase
    {
        private static readonly Uri s_endpoint = new("https://fake-search.search.windows.net/");
        private static readonly AzureKeyCredential s_credential = new("FakeApiKey");

        public SearchDebugInfoMockTests(bool isAsync) : base(isAsync)
        {
        }

        private SearchClient CreateTestClient(MockTransport transport) =>
            InstrumentClient(new SearchClient(
                s_endpoint,
                "test-index",
                s_credential,
                new SearchClientOptions { Transport = transport }));

        [Test]
        public async Task DebugInfo_QueryRewrites_PopulatedFromResponse()
        {
            const string responseBody = @"{
                ""@search.debug"": {
                    ""queryRewrites"": {
                        ""text"": {
                            ""inputQuery"": ""best hotels"",
                            ""rewrites"": [""top rated hotels"", ""finest hotels"", ""luxury hotels""]
                        },
                        ""vectors"": []
                    }
                },
                ""value"": []
            }";

            MockResponse mockResponse = new(200);
            mockResponse.SetContent(responseBody);
            MockTransport transport = new(new[] { mockResponse });

            SearchClient client = CreateTestClient(transport);
            Response<SearchResults<SearchDocument>> response = await client.SearchAsync<SearchDocument>("best hotels");

            SearchResults<SearchDocument> results = response.Value;
            Assert.IsNotNull(results.DebugInfo, "DebugInfo should be populated from @search.debug.");
            Assert.IsNotNull(results.DebugInfo.QueryRewrites, "QueryRewrites should be populated.");

            QueryRewritesValuesDebugInfo text = results.DebugInfo.QueryRewrites.Text;
            Assert.IsNotNull(text, "QueryRewrites.Text should be populated.");
            Assert.AreEqual("best hotels", text.InputQuery);
            CollectionAssert.AreEqual(
                new[] { "top rated hotels", "finest hotels", "luxury hotels" },
                text.Rewrites.ToArray());
        }

        [Test]
        public async Task DebugInfo_Missing_LeavesPropertyNull()
        {
            const string responseBody = @"{ ""value"": [] }";

            MockResponse mockResponse = new(200);
            mockResponse.SetContent(responseBody);
            MockTransport transport = new(new[] { mockResponse });

            SearchClient client = CreateTestClient(transport);
            Response<SearchResults<SearchDocument>> response = await client.SearchAsync<SearchDocument>("*");

            Assert.IsNull(response.Value.DebugInfo, "DebugInfo should be null when @search.debug is absent.");
        }

        [Test]
        public async Task DebugInfo_ExposedOnPage()
        {
            const string responseBody = @"{
                ""@search.debug"": {
                    ""queryRewrites"": {
                        ""text"": { ""inputQuery"": ""q"", ""rewrites"": [""r1""] },
                        ""vectors"": []
                    }
                },
                ""value"": []
            }";

            MockResponse mockResponse = new(200);
            mockResponse.SetContent(responseBody);
            MockTransport transport = new(new[] { mockResponse });

            SearchClient client = CreateTestClient(transport);
            Response<SearchResults<SearchDocument>> response = await client.SearchAsync<SearchDocument>("q");

            Page<SearchResult<SearchDocument>> page = response.Value.GetResults().AsPages().First();
            SearchResultsPage<SearchDocument> typedPage = (SearchResultsPage<SearchDocument>)page;

            Assert.IsNotNull(typedPage.DebugInfo, "SearchResultsPage<T>.DebugInfo should forward to underlying results.");
            Assert.AreEqual("q", typedPage.DebugInfo.QueryRewrites.Text.InputQuery);
        }
    }
}

#endif
