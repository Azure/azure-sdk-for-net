// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Tests
{
    public class AnalyzeOverloadTests
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
        public void AnalyzeOptions_RequiresAnalyzerIdAndInputs()
        {
            Assert.Throws<ArgumentNullException>(() => new AnalyzeOptions(null!, new[] { new AnalysisInput() }));
            Assert.Throws<ArgumentException>(() => new AnalyzeOptions("", new[] { new AnalysisInput() }));
            Assert.Throws<ArgumentNullException>(() => new AnalyzeOptions("prebuilt-layout", null!));
        }

        [Test]
        public void AnalyzeOptions_ModelDeployments_AllowsDictionaryReplacement()
        {
            var options = new AnalyzeOptions("prebuilt-layout", new[] { new AnalysisInput() });
            var replacements = new Dictionary<string, string> { ["gpt-5.2"] = "my-gpt" };

            options.ModelDeployments = replacements;

            Assert.AreSame(replacements, options.ModelDeployments);
            Assert.AreEqual("my-gpt", options.ModelDeployments["gpt-5.2"]);
        }

        [Test]
        public void AnalyzeInline_ScalarOverloadsCompileAndRoute()
        {
            MockTransport mockTransport = new MockTransport(CreateInlineResponse(), CreateInlineResponse());
            ContentUnderstandingClient client = CreateClient(mockTransport);
            AnalysisInput[] inputs =
            {
                new AnalysisInput { Uri = new Uri("https://example.com/doc.pdf") }
            };

            client.AnalyzeInline("prebuilt-layout", inputs);
            client.AnalyzeInline(
                "prebuilt-layout",
                inputs,
                modelDeployments: new Dictionary<string, string> { ["gpt-5.2"] = "my-gpt" },
                processingLocation: ProcessingLocation.Geography);

            StringAssert.Contains("prebuilt-layout", mockTransport.Requests[0].Uri.ToString());
            Assert.IsFalse(mockTransport.Requests[0].Uri.Query.Contains("allowInputTruncation="));
            Assert.IsFalse(mockTransport.Requests[0].Uri.Query.Contains("processingLocation="));

            StringAssert.Contains("processingLocation=geography", mockTransport.Requests[1].Uri.Query);
            Assert.IsFalse(mockTransport.Requests[1].Uri.Query.Contains("allowInputTruncation="));
            string scalarBody = GetRequestContent(mockTransport.Requests[1].Content);
            StringAssert.Contains("\"modelDeployments\"", scalarBody);
            StringAssert.Contains("\"gpt-5.2\"", scalarBody);
            StringAssert.Contains("\"my-gpt\"", scalarBody);
        }

        [Test]
        public async Task AnalyzeInline_OptionsOverloadsCompileAndRoute()
        {
            MockTransport mockTransport = new MockTransport(CreateInlineResponse(), CreateInlineResponse());
            ContentUnderstandingClient client = CreateClient(mockTransport);
            AnalysisInput[] inputs =
            {
                new AnalysisInput { Uri = new Uri("https://example.com/doc.pdf") }
            };

            client.AnalyzeInline(new AnalyzeOptions("sync-analyzer", inputs)
            {
                ProcessingLocation = ProcessingLocation.Geography,
                AllowInputTruncation = true,
                ModelDeployments =
                {
                    ["gpt-5.2"] = "sync-gpt"
                }
            });
            await client.AnalyzeInlineAsync(new AnalyzeOptions("async-analyzer", inputs));

            StringAssert.Contains("sync-analyzer", mockTransport.Requests[0].Uri.ToString());
            StringAssert.Contains(":analyzeInline", mockTransport.Requests[0].Uri.ToString());
            StringAssert.Contains("allowInputTruncation=true", mockTransport.Requests[0].Uri.Query);
            StringAssert.Contains("processingLocation=geography", mockTransport.Requests[0].Uri.Query);
            string optionsBody = GetRequestContent(mockTransport.Requests[0].Content);
            StringAssert.Contains("\"modelDeployments\"", optionsBody);
            StringAssert.Contains("\"sync-gpt\"", optionsBody);

            StringAssert.Contains("async-analyzer", mockTransport.Requests[1].Uri.ToString());
            Assert.IsFalse(mockTransport.Requests[1].Uri.Query.Contains("allowInputTruncation="));
            Assert.IsFalse(mockTransport.Requests[1].Uri.Query.Contains("processingLocation="));
        }

        [Test]
        public async Task Analyze_LroOverloadsCompileAndRoute()
        {
            MockTransport mockTransport = new MockTransport(
                CreateLroResponse(),
                CreateLroResponse(),
                CreateLroResponse());
            ContentUnderstandingClient client = CreateClient(mockTransport);
            AnalysisInput[] inputs =
            {
                new AnalysisInput { Uri = new Uri("https://example.com/doc.pdf") }
            };

            client.Analyze(WaitUntil.Started, "scalar-analyzer", inputs);
            await client.AnalyzeAsync(
                WaitUntil.Started,
                "scalar-deployments",
                inputs,
                modelDeployments: new Dictionary<string, string> { ["text-embedding-3-large"] = "embed" },
                processingLocation: ProcessingLocation.DataZone);
            await client.AnalyzeAsync(
                WaitUntil.Started,
                new AnalyzeOptions("options-analyzer", inputs)
                {
                    AllowInputTruncation = false,
                    ProcessingLocation = ProcessingLocation.Global,
                    ModelDeployments =
                    {
                        ["gpt-5.2"] = "options-gpt"
                    }
                });

            StringAssert.Contains("scalar-analyzer", mockTransport.Requests[0].Uri.ToString());
            StringAssert.Contains(":analyze", mockTransport.Requests[0].Uri.ToString());
            Assert.IsFalse(mockTransport.Requests[0].Uri.ToString().Contains("analyzeInline"));
            Assert.IsFalse(mockTransport.Requests[0].Uri.Query.Contains("allowInputTruncation="));

            StringAssert.Contains("scalar-deployments", mockTransport.Requests[1].Uri.ToString());
            StringAssert.Contains("processingLocation=dataZone", mockTransport.Requests[1].Uri.Query);
            Assert.IsFalse(mockTransport.Requests[1].Uri.Query.Contains("allowInputTruncation="));
            StringAssert.Contains("\"text-embedding-3-large\"", GetRequestContent(mockTransport.Requests[1].Content));

            StringAssert.Contains("options-analyzer", mockTransport.Requests[2].Uri.ToString());
            StringAssert.Contains("allowInputTruncation=false", mockTransport.Requests[2].Uri.Query);
            StringAssert.Contains("processingLocation=global", mockTransport.Requests[2].Uri.Query);
            StringAssert.Contains("\"options-gpt\"", GetRequestContent(mockTransport.Requests[2].Content));
        }

        [Test]
        public async Task Analyze_ProtocolOverloadsPassAllowInputTruncation()
        {
            MockTransport mockTransport = new MockTransport(CreateLroResponse(), CreateInlineResponse());
            ContentUnderstandingClient client = CreateClient(mockTransport);
            RequestContent content = RequestContent.Create(BinaryData.FromString(
                """{"inputs":[{"url":"https://example.com/doc.pdf"}]}"""));

            await client.AnalyzeAsync(
                WaitUntil.Started,
                "protocol-lro",
                content,
                allowInputTruncation: true);
            await client.AnalyzeInlineAsync(
                "protocol-inline",
                content,
                allowInputTruncation: false);

            StringAssert.Contains("allowInputTruncation=true", mockTransport.Requests[0].Uri.Query);
            StringAssert.Contains("allowInputTruncation=false", mockTransport.Requests[1].Uri.Query);
        }

        private static string GetRequestContent(RequestContent content)
        {
            if (content == null)
            {
                return string.Empty;
            }

            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            return Encoding.UTF8.GetString(stream.ToArray());
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
