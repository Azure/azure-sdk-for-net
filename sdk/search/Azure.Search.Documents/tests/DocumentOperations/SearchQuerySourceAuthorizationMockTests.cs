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
    /// Preview-only search operation tests. These tests only compile and run
    /// in preview builds (when the package version contains a pre-release suffix).
    ///
    /// GA Promotion Workflow:
    /// 1. Remove the #if AZURE_SEARCH_PREVIEW / #endif wrappers from this file
    /// 2. Move test methods to SearchTests.cs (or keep here without #if — team choice)
    /// 3. Change [ServiceVersion(Min = CurrentPreviewVersion)] to the new GA version
    /// 4. Update CurrentGAVersion in SearchTestBase
    /// </summary>
    [TestFixture(true)]
    [TestFixture(false)]
    public class SearchQuerySourceAuthorizationMockTests : ClientTestBase
    {
        public SearchQuerySourceAuthorizationMockTests(bool isAsync) : base(isAsync)
        {
        }

        private SearchClient CreateTestClient(MockTransport transport)
        {
            var options = new SearchClientOptions
            {
                Transport = transport,
            };

            return InstrumentClient(
                new SearchClient(
                    new Uri("https://fake-search.search.windows.net"),
                    "test-index",
                    new AzureKeyCredential("fake-api-key"),
                    options));
        }

        [Test]
        public async Task SearchSendsQuerySourceAuthorizationHeader()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent("{\"value\":[]}");
            var transport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(transport);

            await client.SearchAsync<SearchDocument>(
                "*",
                querySourceAuthorization: "my-auth-token",
                enableElevatedRead: true,
                options: new SearchOptions { Size = 1 });

            MockRequest request = transport.Requests.Single();
            Assert.IsTrue(
                request.Headers.TryGetValue("x-ms-query-source-authorization", out string authValue),
                "Expected x-ms-query-source-authorization header.");
            Assert.AreEqual("my-auth-token", authValue);

            Assert.IsTrue(
                request.Headers.TryGetValue("x-ms-enable-elevated-read", out string elevatedValue),
                "Expected x-ms-enable-elevated-read header.");
            Assert.AreEqual("true", elevatedValue);
        }

        [Test]
        public async Task SearchOmitsHeadersWhenNull()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent("{\"value\":[]}");
            var transport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(transport);

            await client.SearchAsync<SearchDocument>("*");

            MockRequest request = transport.Requests.Single();
            Assert.IsFalse(
                request.Headers.TryGetValue("x-ms-query-source-authorization", out _),
                "x-ms-query-source-authorization header should not be present when null.");
            Assert.IsFalse(
                request.Headers.TryGetValue("x-ms-enable-elevated-read", out _),
                "x-ms-enable-elevated-read header should not be present when null.");
        }

        [Test]
        public async Task GetDocumentSendsQuerySourceAuthorizationHeader()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent("{\"id\":\"1\",\"title\":\"Test\"}");
            var transport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(transport);

            await client.GetDocumentAsync<SearchDocument>(
                "1",
                querySourceAuthorization: "my-auth-token",
                enableElevatedRead: true);

            MockRequest request = transport.Requests.Single();
            Assert.IsTrue(
                request.Headers.TryGetValue("x-ms-query-source-authorization", out string authValue),
                "Expected x-ms-query-source-authorization header.");
            Assert.AreEqual("my-auth-token", authValue);

            Assert.IsTrue(
                request.Headers.TryGetValue("x-ms-enable-elevated-read", out string elevatedValue),
                "Expected x-ms-enable-elevated-read header.");
            Assert.AreEqual("true", elevatedValue);
        }

        [Test]
        public async Task GetDocumentOmitsHeadersWhenNull()
        {
            var mockResponse = new MockResponse(200);
            mockResponse.SetContent("{\"id\":\"1\",\"title\":\"Test\"}");
            var transport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(transport);

            await client.GetDocumentAsync<SearchDocument>("1");

            MockRequest request = transport.Requests.Single();
            Assert.IsFalse(
                request.Headers.TryGetValue("x-ms-query-source-authorization", out _),
                "x-ms-query-source-authorization header should not be present when null.");
            Assert.IsFalse(
                request.Headers.TryGetValue("x-ms-enable-elevated-read", out _),
                "x-ms-enable-elevated-read header should not be present when null.");
        }

        [Test]
        public async Task SearchPaginationCarriesSecurityHeaders()
        {
            // First page: includes @search.nextPageParameters to trigger a second request
            var page1 = new MockResponse(200);
            page1.SetContent(
                "{\"value\":[{\"@search.score\":1.0,\"id\":\"1\"}]," +
                "\"@odata.nextLink\":\"https://fake-search.search.windows.net/indexes/test-index/docs?api-version=2026-05-01-Preview\"," +
                "\"@search.nextPageParameters\":{\"search\":\"*\",\"skip\":1}}");

            // Second page: no nextPageParameters
            var page2 = new MockResponse(200);
            page2.SetContent("{\"value\":[{\"@search.score\":1.0,\"id\":\"2\"}]}");

            var transport = new MockTransport(new[] { page1, page2 });
            var client = CreateTestClient(transport);

            Response<SearchResults<SearchDocument>> response = await client.SearchAsync<SearchDocument>(
                "*",
                querySourceAuthorization: "my-auth-token",
                enableElevatedRead: true);

            // Drain all pages to trigger the second request
            var allResults = new System.Collections.Generic.List<SearchResult<SearchDocument>>();
            await foreach (SearchResult<SearchDocument> result in response.Value.GetResultsAsync())
            {
                allResults.Add(result);
            }

            Assert.AreEqual(2, allResults.Count);
            Assert.AreEqual(2, transport.Requests.Count, "Expected two HTTP requests (page 1 + page 2).");

            // Verify the SECOND request also carries the security headers
            MockRequest secondRequest = transport.Requests[1];
            Assert.IsTrue(
                secondRequest.Headers.TryGetValue("x-ms-query-source-authorization", out string authValue),
                "Second page request should carry x-ms-query-source-authorization header.");
            Assert.AreEqual("my-auth-token", authValue);

            Assert.IsTrue(
                secondRequest.Headers.TryGetValue("x-ms-enable-elevated-read", out string elevatedValue),
                "Second page request should carry x-ms-enable-elevated-read header.");
            Assert.AreEqual("true", elevatedValue);
        }
    }
}
#endif
