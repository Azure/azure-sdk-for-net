// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        [ServiceVersion(Min = ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
        public async Task AnalyzeBinaryInlineAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

#if SNIPPET
            string filePath = "<localDocumentFilePath>";
#else
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_invoice.pdf");
#endif
            BinaryData binaryData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

            #region Snippet:ContentUnderstandingAnalyzeBinaryInlineAsync
            Response<AnalysisResult> inlineResponse = await client.AnalyzeBinaryInlineAsync(
                "prebuilt-layout",
                binaryData);

            AnalysisResult inlineResult = inlineResponse.Value;
            #endregion

            #region Snippet:ContentUnderstandingAnalyzeBinaryInlineGetUsageDetails
            // Inline analyze reports DocumentPages*Inline meters (see pricing docs for which
            // meter applies). This sample prints the standard inline page meter.
            UsageDetails? usage = inlineResponse.GetUsageDetails();
            if (usage != null)
            {
                Console.WriteLine($"Document pages (standard inline): {usage.DocumentPagesStandardInline}");
                Console.WriteLine($"Contextualization tokens: {usage.ContextualizationTokens}");
            }
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeBinaryInlineAsync
            Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
            Assert.IsNotNull(inlineResponse, "Inline binary response should not be null");
            Assert.IsNotNull(inlineResponse.GetRawResponse(), "Inline binary raw response should not be null");
            Assert.AreEqual(200, inlineResponse.GetRawResponse().Status, "Inline binary analyze should return HTTP 200");

            Assert.IsNotNull(inlineResult, "Inline binary result should not be null");
            Assert.IsNotNull(inlineResult.Contents, "Inline binary result contents should not be null");
            Assert.IsTrue(inlineResult.Contents!.Count > 0, "Inline binary result should contain at least one content item");

            AnalysisContent firstContent = inlineResult.Contents.First();
            Assert.IsNotNull(firstContent.Markdown, "Inline binary markdown should not be null");
            Assert.IsFalse(string.IsNullOrWhiteSpace(firstContent.Markdown), "Inline binary markdown should not be empty");
            Assert.IsNotNull(usage, "Inline binary usage details should be available after a succeeded analyze");
            Assert.IsNotNull(usage!.DocumentPagesStandardInline, "prebuilt-layout inline should bill DocumentPagesStandardInline");
            Assert.Greater(usage.DocumentPagesStandardInline!.Value, 0, "Inline standard page meter should be positive");
            Assert.IsNull(usage.DocumentPagesStandard, "LRO DocumentPagesStandard should not be set for inline analyze");
            #endregion

            #region Snippet:ContentUnderstandingAnalyzeBinaryInlineWithOptionsAsync
            Response<AnalysisResult> optionsResponse = await client.AnalyzeBinaryInlineAsync(
                new AnalyzeBinaryOptions("prebuilt-layout", binaryData)
                {
                    ContentType = "application/pdf"
                });

            AnalysisResult optionsResult = optionsResponse.Value;
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeBinaryInlineWithOptionsAsync
            Assert.AreEqual(200, optionsResponse.GetRawResponse().Status, "Options-bag inline analyze should return HTTP 200");
            Assert.IsNotNull(optionsResult.Contents, "Options-bag inline result contents should not be null");
            Assert.IsTrue(optionsResult.Contents!.Count > 0, "Options-bag inline result should contain at least one content item");
            #endregion
        }

        [RecordedTest]
        [ServiceVersion(Min = ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)]
        public async Task AnalyzeBinaryInlineWithContentRangeAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("mixed_financial_invoices.pdf");
            BinaryData binaryData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

            #region Snippet:ContentUnderstandingAnalyzeBinaryInlineWithContentRangeAsync
            Response<AnalysisResult> rangeResponse = await client.AnalyzeBinaryInlineAsync(
                "prebuilt-layout",
                binaryData,
                contentRange: ContentRange.Pages(1, 3));

            DocumentContent rangeDocument = (DocumentContent)rangeResponse.Value.Contents!.First();
            Console.WriteLine($"Inline pages: {rangeDocument.StartPageNumber}-{rangeDocument.EndPageNumber} ({rangeDocument.Pages!.Count} pages)");
            #endregion

            Assert.AreEqual(200, rangeResponse.GetRawResponse().Status);
            Assert.AreEqual(3, rangeDocument.Pages!.Count, "ContentRange.Pages(1, 3) should return 3 pages");
            Assert.AreEqual(1, rangeDocument.StartPageNumber);
            Assert.AreEqual(3, rangeDocument.EndPageNumber);
            Assert.IsFalse(string.IsNullOrWhiteSpace(rangeDocument.Markdown));
        }
    }
}
