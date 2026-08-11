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
    public class AnalyzeBinaryOverloadTests
    {
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
        public void AnalyzeBinaryInline_ScalarOverloadsCompileAndRoute()
        {
            MockTransport mockTransport = new MockTransport(
                CreateInlineResponse(),
                CreateInlineResponse(),
                CreateInlineResponse());
            ContentUnderstandingClient client = CreateClient(mockTransport);
            BinaryData input = BinaryData.FromString("fake-pdf-bytes");

            client.AnalyzeBinaryInline("prebuilt-layout", input, null);
            client.AnalyzeBinaryInline("prebuilt-layout", input, default);
            client.AnalyzeBinaryInline(
                "prebuilt-layout",
                input,
                contentRange: ContentRange.Pages(1, 3));

            Assert.IsFalse(mockTransport.Requests[0].Uri.Query.Contains("range="));
            Assert.IsFalse(mockTransport.Requests[1].Uri.Query.Contains("range="));
            StringAssert.Contains("range=1-3", Uri.UnescapeDataString(mockTransport.Requests[2].Uri.Query));
        }

        [Test]
        public async Task AnalyzeBinaryInline_OptionsOverloadsCompileAndRoute()
        {
            MockTransport mockTransport = new MockTransport(CreateInlineResponse(), CreateInlineResponse());
            ContentUnderstandingClient client = CreateClient(mockTransport);
            BinaryData input = BinaryData.FromString("fake-pdf-bytes");

            client.AnalyzeBinaryInline(new AnalyzeBinaryOptions("sync-analyzer", input)
            {
                ContentRange = ContentRange.Page(2),
                ContentType = "application/pdf",
                ProcessingLocation = ProcessingLocation.Geography,
                AllowInputTruncation = true
            });
            await client.AnalyzeBinaryInlineAsync(new AnalyzeBinaryOptions("async-analyzer", input));

            StringAssert.Contains("sync-analyzer", mockTransport.Requests[0].Uri.ToString());
            StringAssert.Contains("range=2", Uri.UnescapeDataString(mockTransport.Requests[0].Uri.Query));
            StringAssert.Contains("allowInputTruncation=true", mockTransport.Requests[0].Uri.Query);
            StringAssert.Contains("processingLocation=geography", mockTransport.Requests[0].Uri.Query);
            Assert.IsTrue(mockTransport.Requests[0].Headers.TryGetValue("Content-Type", out string? contentType));
            Assert.AreEqual("application/pdf", contentType);
            StringAssert.Contains("async-analyzer", mockTransport.Requests[1].Uri.ToString());
            Assert.IsFalse(mockTransport.Requests[1].Uri.Query.Contains("range="));
        }

        [Test]
        public async Task AnalyzeBinary_LroOverloadsCompileAndRoute()
        {
            MockTransport mockTransport = new MockTransport(
                CreateLroResponse(),
                CreateLroResponse(),
                CreateLroResponse(),
                CreateLroResponse());
            ContentUnderstandingClient client = CreateClient(mockTransport);
            BinaryData input = BinaryData.FromString("fake-pdf-bytes");

            client.AnalyzeBinary(WaitUntil.Started, "scalar-null", input, null);
            client.AnalyzeBinary(WaitUntil.Started, "scalar-default", input, default);
            await client.AnalyzeBinaryAsync(
                WaitUntil.Started,
                "scalar-range",
                input,
                contentRange: ContentRange.Page(4));
            await client.AnalyzeBinaryAsync(
                WaitUntil.Started,
                new AnalyzeBinaryOptions("options-analyzer", input)
                {
                    ContentRange = ContentRange.Pages(2, 3),
                    AllowInputTruncation = false
                });

            Assert.IsFalse(mockTransport.Requests[0].Uri.Query.Contains("range="));
            Assert.IsFalse(mockTransport.Requests[1].Uri.Query.Contains("range="));
            StringAssert.Contains("range=4", Uri.UnescapeDataString(mockTransport.Requests[2].Uri.Query));
            StringAssert.Contains("options-analyzer", mockTransport.Requests[3].Uri.ToString());
            StringAssert.Contains("range=2-3", Uri.UnescapeDataString(mockTransport.Requests[3].Uri.Query));
            StringAssert.Contains("allowInputTruncation=false", mockTransport.Requests[3].Uri.Query);
        }

        [Test]
        public async Task AnalyzeBinary_ProtocolOverloadsPassAllowInputTruncation()
        {
            MockTransport mockTransport = new MockTransport(CreateLroResponse(), CreateInlineResponse());
            ContentUnderstandingClient client = CreateClient(mockTransport);
            BinaryData input = BinaryData.FromString("fake-pdf-bytes");

            await client.AnalyzeBinaryAsync(
                WaitUntil.Started,
                "protocol-lro",
                "application/pdf",
                RequestContent.Create(input),
                allowInputTruncation: true);
            await client.AnalyzeBinaryInlineAsync(
                "protocol-inline",
                RequestContent.Create(input),
                "application/pdf",
                allowInputTruncation: false);

            StringAssert.Contains("allowInputTruncation=true", mockTransport.Requests[0].Uri.Query);
            StringAssert.Contains("allowInputTruncation=false", mockTransport.Requests[1].Uri.Query);
        }

        private static MockResponse CreateInlineResponse()
        {
            var response = new MockResponse(200);
            response.SetContent(SucceededInlineBody);
            return response;
        }

        private static MockResponse CreateLroResponse()
        {
            var response = new MockResponse(202);
            response.AddHeader("Operation-Location", "https://example.com/operations/123");
            return response;
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
