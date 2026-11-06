// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class GetDocumentMockTests : ClientTestBase
    {
        public GetDocumentMockTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task AuthorizationAndSelectedFieldsAreSentTogether(bool elevatedRead)
        {
            var transport = new MockTransport(
                SearchTestHelpers.CreateMockJsonResponse(200, "{\"id\":\"1\"}"));
            SearchClient client = CreateClient(transport);
            var options = new GetDocumentOptions
            {
                QuerySourceAuthorization = "user-token",
                EnableElevatedRead = elevatedRead,
                SelectedFields = { "id", "title" }
            };

            Response<SearchDocument> response = await client.GetDocumentAsync<SearchDocument>(
                "1", options, CancellationToken.None);

            Assert.AreEqual("1", response.Value["id"]);
            MockRequest request = transport.Requests.Single();
            Assert.IsTrue(request.Headers.TryGetValue("x-ms-query-source-authorization", out string authorization));
            Assert.AreEqual("user-token", authorization);
            Assert.IsTrue(request.Headers.TryGetValue("x-ms-enable-elevated-read", out string elevated));
            Assert.AreEqual(elevatedRead ? "true" : "false", elevated);
            Assert.That(Uri.UnescapeDataString(request.Uri.ToUri().Query), Does.Contain("$select=id,title"));
        }

        [TestCase(true)]
        [TestCase(false)]
        public async Task UnspecifiedAuthorizationOmitsHeaders(bool nullOptions)
        {
            var transport = new MockTransport(
                SearchTestHelpers.CreateMockJsonResponse(200, "{\"id\":\"1\"}"));
            SearchClient client = CreateClient(transport);
            Response<SearchDocument> response;
            if (nullOptions)
            {
                response = await client.GetDocumentAsync<SearchDocument>("1", null);
            }
            else
            {
                response = await client.GetDocumentAsync<SearchDocument>(
                    "1", new GetDocumentOptions { SelectedFields = { "id" } });
            }

            Assert.AreEqual("1", response.Value["id"]);
            MockRequest request = transport.Requests.Single();
            Assert.IsFalse(request.Headers.TryGetValue("x-ms-query-source-authorization", out _));
            Assert.IsFalse(request.Headers.TryGetValue("x-ms-enable-elevated-read", out _));
            string query = Uri.UnescapeDataString(request.Uri.ToUri().Query);
            if (nullOptions)
            {
                Assert.That(query, Does.Not.Contain("$select"));
            }
            else
            {
                Assert.That(query, Does.Contain("$select=id"));
            }
        }

        private SearchClient CreateClient(MockTransport transport) =>
            InstrumentClient(new SearchClient(
                new Uri("https://fake-search.search.windows.net"),
                "test-index",
                new AzureKeyCredential("fake-api-key"),
                new SearchClientOptions { Transport = transport }));
    }
}
