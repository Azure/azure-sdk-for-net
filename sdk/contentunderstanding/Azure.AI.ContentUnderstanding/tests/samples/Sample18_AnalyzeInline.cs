// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        [ServiceVersion(Min = ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
        public async Task AnalyzeInlineAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

#if SNIPPET
            Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/sample_invoice.pdf");
#else
            Uri uriSource = ContentUnderstandingClientTestEnvironment.CreateUri("invoice.pdf");
#endif

            #region Snippet:ContentUnderstandingAnalyzeInlineAsync
            // Inline analysis returns AnalysisResult directly (HTTP 200) with no polling.
            // Non-Succeeded inline operation status values throw RequestFailedException, like a failed LRO.
            Response<AnalysisResult> inlineResponse = await client.AnalyzeInlineAsync(
                "prebuilt-layout",
                inputs: new[]
                {
                    new AnalysisInput
                    {
                        Uri = uriSource
                    }
                });

            AnalysisResult inlineResult = inlineResponse.Value;
            #endregion

            #region Snippet:ContentUnderstandingAnalyzeInlineGetUsageDetails
            // Inline analyze reports DocumentPages*Inline meters (see pricing docs for which
            // meter applies). This sample prints the standard inline page meter.
            UsageDetails? usage = inlineResponse.GetUsageDetails();
            if (usage != null)
            {
                Console.WriteLine($"Document pages (standard inline): {usage.DocumentPagesStandardInline}");
                Console.WriteLine($"Contextualization tokens: {usage.ContextualizationTokens}");
            }
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeInlineAsync
            Assert.IsNotNull(inlineResponse, "Inline response should not be null");
            Assert.IsNotNull(inlineResponse.GetRawResponse(), "Inline raw response should not be null");
            Assert.AreEqual(200, inlineResponse.GetRawResponse().Status, "Inline analyze should return HTTP 200");

            Assert.IsNotNull(inlineResult, "Inline result should not be null");
            Assert.IsNotNull(inlineResult.Contents, "Inline result contents should not be null");
            Assert.IsTrue(inlineResult.Contents!.Count > 0, "Inline result should contain at least one content item");

            AnalysisContent firstContent = inlineResult.Contents.First();
            Assert.IsNotNull(firstContent.Markdown, "Inline markdown should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(firstContent.Markdown), "Inline markdown should not be empty");
            Assert.IsNotNull(usage, "Inline usage details should be available after a succeeded analyze");
            Assert.IsNotNull(usage!.DocumentPagesStandardInline, "prebuilt-layout inline should bill DocumentPagesStandardInline");
            Assert.Greater(usage.DocumentPagesStandardInline!.Value, 0, "Inline standard page meter should be positive");
            Assert.IsNull(usage.DocumentPagesStandard, "LRO DocumentPagesStandard should not be set for inline analyze");
            Assert.IsNull(usage.DocumentPagesMinimalInline, "prebuilt-layout should not bill the minimal inline meter");
            Assert.IsNull(usage.DocumentPagesBasicInline, "prebuilt-layout should not bill the basic inline meter");
            #endregion
        }
    }
}
