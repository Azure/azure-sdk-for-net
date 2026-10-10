// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task ClassifyInPageSegmentsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            string defaultId = $"test_in_page_classifier_{Recording.Random.NewGuid():N}";
            string analyzerId = Recording.GetVariable("inPageClassifierId", defaultId) ?? defaultId;

            #region Snippet:ContentUnderstandingClassifyInPageSegments
            var config = new ContentAnalyzerConfig
            {
                // Return full content details (markdown, spans, sources, and per-segment
                // metadata) in the result. Required to inspect the segments below.
                ShouldReturnDetails = true,
                // Enable classification-based segmentation: the input is split into segments,
                // each classified against the ContentCategories defined below.
                EnableSegment = true,
                // Allow a segment to cover only part of a page, so multiple documents that
                // share one page can be separated. When false (the default), segments break
                // on whole-page boundaries only.
                AllowInPageSegments = true,
                // Return grounding source and confidence for extracted fields.
                EstimateFieldSourceAndConfidence = true
            };
            config.ContentCategories.Add("Invoice", new ContentCategoryDefinition
            {
                Description = "An invoice requesting payment for goods or services, with line items, totals, and payment terms."
            });
            config.ContentCategories.Add("BankStatement", new ContentCategoryDefinition
            {
                Description = "A bank account statement listing balances, deposits, withdrawals, fees, and transactions."
            });

            var classifier = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Classify financial documents that may share a page.",
                Config = config
            };
#if SNIPPET
            string completionModel = "<completion-model-name>";
#else
            string completionModel = ModelProfile.CompletionModel;
            string completionModelDeployment = ModelProfile.CompletionDeployment
                ?? throw new InvalidOperationException("CU_COMPLETION_MODEL_DEPLOYMENT must be configured for this live test.");
            Response<ContentUnderstandingDefaults> defaults = await client.GetDefaultsAsync();
            var modelDeployments = new Dictionary<string, string>(defaults.Value.ModelDeployments)
            {
                [completionModel] = completionModelDeployment
            };
            await client.UpdateDefaultsAsync(modelDeployments);
#endif
            classifier.Models["completion"] = completionModel;

            await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                classifier);

            try
            {
#if SNIPPET
                string filePath = "<path-to-pdf-with-multiple-documents-on-one-page>";
#else
                string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("mixed_financial_docs_in_page.pdf");
#endif
                BinaryData documentData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

                Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    documentData);

                DocumentContent document = operation.Value.Contents
                    .OfType<DocumentContent>()
                    .First();

                foreach (DocumentContentSegment segment in document.Segments)
                {
                    Console.WriteLine($"Category: {segment.Category}");
                    Console.WriteLine($"  Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
                    Console.WriteLine($"  Confidence: {segment.Confidence:P1}");
                    Console.WriteLine($"  Source: {segment.Source}");
                    Console.WriteLine($"  Span: offset={segment.Span.Offset}, length={segment.Span.Length}");
                }

#if !SNIPPET
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(document.StartPageNumber, Is.EqualTo(1));
                Assert.That(document.EndPageNumber, Is.EqualTo(1));
                Assert.That(document.Segments, Has.Count.EqualTo(2));
                Assert.That(document.Segments.Select(segment => segment.Category),
                    Is.EquivalentTo(new[] { "Invoice", "BankStatement" }));
                Assert.That(document.Segments.All(segment => segment.StartPageNumber == 1 && segment.EndPageNumber == 1), Is.True);
                // Enable once the service returns segment-level Confidence for in-page classification.
#if KNOWN_SERVICE_ISSUE
                Assert.That(document.Segments.All(segment => segment.Confidence.HasValue), Is.True);
#endif
                Assert.That(document.Segments.All(segment => !string.IsNullOrWhiteSpace(segment.Source)), Is.True);
                Assert.That(document.Segments.All(segment => segment.Span is not null && segment.Span.Length > 0), Is.True);
                Assert.That(document.Segments.Select(segment => segment.Source).Distinct().Count(), Is.EqualTo(2));

                DocumentContentSegment invoiceSegment = document.Segments.Single(segment => segment.Category == "Invoice");
                DocumentContentSegment bankStatementSegment = document.Segments.Single(segment => segment.Category == "BankStatement");
                Assert.That(invoiceSegment.Span.Offset, Is.EqualTo(0));
                Assert.That(invoiceSegment.Span.Length, Is.EqualTo(687));
                Assert.That(bankStatementSegment.Span.Offset, Is.EqualTo(687));
                Assert.That(bankStatementSegment.Span.Length, Is.EqualTo(964));
                Assert.That(invoiceSegment.Span.Offset + invoiceSegment.Span.Length, Is.EqualTo(bankStatementSegment.Span.Offset));
                Assert.That(bankStatementSegment.Span.Offset + bankStatementSegment.Span.Length, Is.EqualTo(document.Markdown.Length));

                string invoiceMarkdown = document.Markdown.Substring(invoiceSegment.Span.Offset, invoiceSegment.Span.Length);
                string bankStatementMarkdown = document.Markdown.Substring(bankStatementSegment.Span.Offset, bankStatementSegment.Span.Length);
                Assert.That(invoiceMarkdown, Does.Contain("INVOICE"));
                Assert.That(bankStatementMarkdown, Does.Contain("CONTOSO BANK"));
#endif
            }
            finally
            {
                await client.DeleteAnalyzerAsync(analyzerId);
            }
            #endregion
        }
    }
}
