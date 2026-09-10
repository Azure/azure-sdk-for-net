// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    public class AnalyzeInlineConvenienceTests
    {
        private const string FailedInlineBody = """
            {
              "status": "Failed",
              "error": {
                "code": "InternalServerError",
                "message": "An unexpected error occurred."
              }
            }
            """;

        private const string SucceededInlineBody = """
            {
              "status": "Succeeded",
              "result": {
                "analyzerId": "prebuilt-layout",
                "apiVersion": "2026-06-01-preview",
                "createdAt": "2026-07-29T00:00:00Z",
                "contents": [
                  {
                    "kind": "document",
                    "markdown": "# Invoice",
                    "startPageNumber": 1,
                    "endPageNumber": 1
                  }
                ]
              }
            }
            """;

        [Test]
        public void AnalyzeInline_ThrowsRequestFailedException_WhenOperationStateFailed()
        {
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent(FailedInlineBody);
            MockTransport mockTransport = new MockTransport(mockResponse);

            ContentUnderstandingClient client = CreateClient(mockTransport);

            RequestFailedException ex = Assert.Throws<RequestFailedException>(() =>
                client.AnalyzeInline(
                    "prebuilt-layout",
                    new[] { new AnalysisInput { Uri = new Uri("https://example.com/doc.pdf") } }))!;

            Assert.AreEqual(200, ex.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task AnalyzeInlineAsync_ThrowsRequestFailedException_WhenOperationStateFailed()
        {
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent(FailedInlineBody);
            MockTransport mockTransport = new MockTransport(mockResponse);

            ContentUnderstandingClient client = CreateClient(mockTransport);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.AnalyzeInlineAsync(
                    "prebuilt-layout",
                    new[] { new AnalysisInput { Uri = new Uri("https://example.com/doc.pdf") } }))!;

            Assert.AreEqual(200, ex.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public void AnalyzeBinaryInline_ThrowsRequestFailedException_WhenOperationStateFailed()
        {
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent(FailedInlineBody);
            MockTransport mockTransport = new MockTransport(mockResponse);

            ContentUnderstandingClient client = CreateClient(mockTransport);

            RequestFailedException ex = Assert.Throws<RequestFailedException>(() =>
                client.AnalyzeBinaryInline(
                    "prebuilt-layout",
                    BinaryData.FromString("fake-pdf-bytes")))!;

            Assert.AreEqual(200, ex.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public async Task AnalyzeBinaryInlineAsync_ThrowsRequestFailedException_WhenOperationStateFailed()
        {
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent(FailedInlineBody);
            MockTransport mockTransport = new MockTransport(mockResponse);

            ContentUnderstandingClient client = CreateClient(mockTransport);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.AnalyzeBinaryInlineAsync(
                    "prebuilt-layout",
                    BinaryData.FromString("fake-pdf-bytes")))!;

            Assert.AreEqual(200, ex.Status);
            Assert.AreEqual(1, mockTransport.Requests.Count);
        }

        [Test]
        public void AnalyzeInline_ReturnsAnalysisResult_WhenOperationStateSucceeded()
        {
            MockResponse mockResponse = new MockResponse(200);
            mockResponse.SetContent(SucceededInlineBody);
            MockTransport mockTransport = new MockTransport(mockResponse);

            ContentUnderstandingClient client = CreateClient(mockTransport);

            Response<AnalysisResult> response = client.AnalyzeInline(
                "prebuilt-layout",
                new[] { new AnalysisInput { Uri = new Uri("https://example.com/doc.pdf") } });

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual("prebuilt-layout", response.Value.AnalyzerId);
            Assert.AreEqual(1, response.Value.Contents!.Count);
        }

        private static ContentUnderstandingClient CreateClient(MockTransport transport)
        {
            return new ContentUnderstandingClient(
                new Uri("https://example.com"),
                new AzureKeyCredential("fake-key"),
                new ContentUnderstandingClientOptions(
                    ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)
                {
                    Transport = transport
                });
        }
    }
}
