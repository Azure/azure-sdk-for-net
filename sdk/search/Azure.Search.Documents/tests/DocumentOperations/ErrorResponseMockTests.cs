// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Mock tests that validate SDK error-handling behavior for common
    /// failure scenarios. Uses <see cref="MockTransport"/> with pre-built
    /// error responses — no live resources needed.
    ///
    /// Tests verify that <see cref="RequestFailedException"/> is raised
    /// with correct status code and message propagation.
    /// </summary>
    [Category("ErrorHandling")]
    public class ErrorResponseMockTests : ClientTestBase
    {
        public ErrorResponseMockTests(bool isAsync) : base(isAsync)
        {
        }

        private SearchClient CreateTestClient(MockTransport transport)
        {
            var options = new SearchClientOptions()
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

        private Indexes.SearchIndexClient CreateTestIndexClient(MockTransport transport)
        {
            var options = new SearchClientOptions()
            {
                Transport = transport,
            };

            return InstrumentClient(
                new Indexes.SearchIndexClient(
                    new Uri("https://fake-search.search.windows.net"),
                    new AzureKeyCredential("fake-api-key"),
                    options));
        }

        [Test]
        public void GetDocument_404_ThrowsRequestFailedException()
        {
            var mockResponse = SearchTestHelpers.CreateMockJsonResponse(404,
                @"{""error"":{""code"":""IndexNotFound"",""message"":""The index 'test-index' does not exist.""}}");

            var transport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(transport);

            var ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.GetDocumentAsync<SearchDocument>("missing-doc-id"));

            Assert.AreEqual(404, ex.Status);
            Assert.AreEqual("IndexNotFound", ex.ErrorCode);
            Assert.That(ex.Message, Does.Contain("test-index"));
        }

        [Test]
        public void Search_400_BadFilter_ThrowsRequestFailedException()
        {
            var mockResponse = SearchTestHelpers.CreateMockJsonResponse(400,
                @"{""error"":{""code"":""InvalidArgument"",""message"":""Invalid expression: Syntax error at position 5 in 'bad ><>< filter'.""}}");

            var transport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(transport);

            var searchOptions = new SearchOptions { Filter = "bad ><>< filter" };

            var ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.SearchAsync<SearchDocument>("*", searchOptions));

            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual("InvalidArgument", ex.ErrorCode);
            Assert.That(ex.Message, Does.Contain("bad ><>< filter"));
        }

        [Test]
        public void Search_403_Forbidden_ThrowsRequestFailedException()
        {
            var mockResponse = SearchTestHelpers.CreateMockJsonResponse(403,
                @"{""error"":{""code"":""Forbidden"",""message"":""The API key is not authorized for this operation.""}}");

            var transport = new MockTransport(new[] { mockResponse });
            var client = CreateTestClient(transport);

            var ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.SearchAsync<SearchDocument>("*"));

            Assert.AreEqual(403, ex.Status);
            Assert.AreEqual("Forbidden", ex.ErrorCode);
            Assert.That(ex.Message, Does.Contain("not authorized"));
        }

        [Test]
        public void Search_503_ServiceUnavailable_ThrowsRequestFailedException()
        {
            // Simulate all retries exhausted by providing enough 503s
            var responses = new[]
            {
                SearchTestHelpers.CreateMockJsonResponse(503, @"{""error"":{""code"":""ServiceUnavailable"",""message"":""Service is busy.""}}"),
                SearchTestHelpers.CreateMockJsonResponse(503, @"{""error"":{""code"":""ServiceUnavailable"",""message"":""Service is busy.""}}"),
                SearchTestHelpers.CreateMockJsonResponse(503, @"{""error"":{""code"":""ServiceUnavailable"",""message"":""Service is busy.""}}"),
            };

            var transport = new MockTransport(responses);
            var options = new SearchClientOptions()
            {
                Transport = transport,
                Retry = { MaxRetries = 0 }, // No retries to fail fast in test
            };

            var client = InstrumentClient(
                new SearchClient(
                    new Uri("https://fake-search.search.windows.net"),
                    "test-index",
                    new AzureKeyCredential("fake-api-key"),
                    options));

            var ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.SearchAsync<SearchDocument>("*"));

            Assert.AreEqual(503, ex.Status);
            Assert.AreEqual("ServiceUnavailable", ex.ErrorCode);
            Assert.That(ex.Message, Does.Contain("busy"));
        }
    }
}
