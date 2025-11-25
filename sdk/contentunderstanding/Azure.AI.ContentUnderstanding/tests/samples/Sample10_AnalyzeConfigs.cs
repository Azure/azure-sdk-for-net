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
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        [RecordedTest]
        public async Task AnalyzeConfigsAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingAnalyzeWithConfigs
#if SNIPPET
            string filePath = "<filePath>";
#else
            string filePath = ContentUnderstandingClientTestEnvironment.CreatePath("sample_document_features.pdf");
#endif
            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
            BinaryData binaryData = BinaryData.FromBytes(fileBytes);

            // Analyze with prebuilt-documentSearch which has formulas, layout, and OCR enabled
            // These configs enable extraction of charts, annotations, hyperlinks, and formulas
            AnalyzeResultOperation operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                binaryData);

            AnalyzeResult result = operation.Value;
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeWithConfigs
            Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            TestContext.WriteLine("✅ Analysis operation properties verified");
            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            #endregion

            #region Snippet:ContentUnderstandingExtractCharts
            // Extract charts from document content
            if (result.Contents?.FirstOrDefault() is DocumentContent documentContent)
            {
                if (documentContent.Figures != null && documentContent.Figures.Count > 0)
                {
                    var chartFigures = documentContent.Figures
                        .Where(f => f is DocumentChartFigure)
                        .Cast<DocumentChartFigure>()
                        .ToList();

                    Console.WriteLine($"Found {chartFigures.Count} chart(s)");
                    foreach (var chart in chartFigures)
                    {
                        Console.WriteLine($"  Chart ID: {chart.Id}");
                        if (!string.IsNullOrEmpty(chart.Description))
                        {
                            Console.WriteLine($"    Description: {chart.Description}");
                        }
                        if (chart.Caption != null && !string.IsNullOrEmpty(chart.Caption.Content))
                        {
                            Console.WriteLine($"    Caption: {chart.Caption.Content}");
                        }
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractCharts
            var docContentCharts = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContentCharts, "Content should be DocumentContent");

            // Charts are optional - validate structure if present
            if (docContentCharts!.Figures != null && docContentCharts.Figures.Count > 0)
            {
                var chartFiguresAssert = docContentCharts.Figures
                    .Where(f => f is DocumentChartFigure)
                    .Cast<DocumentChartFigure>()
                    .ToList();

                foreach (var chart in chartFiguresAssert)
                {
                    Assert.IsNotNull(chart.Id, "Chart ID should not be null");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(chart.Id), "Chart ID should not be empty");

                    // Description and Caption are optional, no assertion needed
                }

                Console.WriteLine($"✓ Verified {chartFiguresAssert.Count} chart(s)");
            }
            #endregion

            #region Snippet:ContentUnderstandingExtractHyperlinks
            // Extract hyperlinks from document content
            if (result.Contents?.FirstOrDefault() is DocumentContent docContent)
            {
                if (docContent.Hyperlinks != null && docContent.Hyperlinks.Count > 0)
                {
                    Console.WriteLine($"Found {docContent.Hyperlinks.Count} hyperlink(s)");
                    foreach (var hyperlink in docContent.Hyperlinks)
                    {
                        Console.WriteLine($"  URL: {hyperlink.Url ?? "(not available)"}");
                        Console.WriteLine($"    Content: {hyperlink.Content ?? "(not available)"}");
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractHyperlinks
            var docContentHyperlinks = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContentHyperlinks, "Content should be DocumentContent");

            // Hyperlinks are optional - validate structure if present
            if (docContentHyperlinks!.Hyperlinks != null && docContentHyperlinks.Hyperlinks.Count > 0)
            {
                foreach (var hyperlink in docContentHyperlinks.Hyperlinks)
                {
                    Assert.IsNotNull(hyperlink, "Hyperlink should not be null");

                    // At least one of URL or Content should be present
                    Assert.IsTrue(!string.IsNullOrEmpty(hyperlink.Url) || !string.IsNullOrEmpty(hyperlink.Content),
                        "Hyperlink should have either URL or Content");
                }

                Console.WriteLine($"✓ Verified {docContentHyperlinks.Hyperlinks.Count} hyperlink(s)");
            }
            #endregion

            #region Snippet:ContentUnderstandingExtractFormulas
            // Extract formulas from document pages
            if (result.Contents?.FirstOrDefault() is DocumentContent content)
            {
                var allFormulas = new System.Collections.Generic.List<DocumentFormula>();
                if (content.Pages != null)
                {
                    foreach (var page in content.Pages)
                    {
                        if (page.Formulas != null)
                        {
                            allFormulas.AddRange(page.Formulas);
                        }
                    }
                }

                if (allFormulas.Count > 0)
                {
                    Console.WriteLine($"Found {allFormulas.Count} formula(s)");
                    foreach (var formula in allFormulas)
                    {
                        Console.WriteLine($"  Formula Kind: {formula.Kind}");
                        Console.WriteLine($"    LaTeX: {formula.Value ?? "(not available)"}");
                        if (formula.Confidence.HasValue)
                        {
                            Console.WriteLine($"    Confidence: {formula.Confidence.Value:F2}");
                        }
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractFormulas
            var docContentFormulas = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContentFormulas, "Content should be DocumentContent");

            // Formulas are optional - validate structure if present
            var allFormulasAssert = new System.Collections.Generic.List<DocumentFormula>();
            if (docContentFormulas!.Pages != null)
            {
                foreach (var page in docContentFormulas.Pages)
                {
                    if (page.Formulas != null)
                    {
                        allFormulasAssert.AddRange(page.Formulas);
                    }
                }
            }

            if (allFormulasAssert.Count > 0)
            {
                foreach (var formula in allFormulasAssert)
                {
                    Assert.IsNotNull(formula, "Formula should not be null");
                    Assert.IsNotNull(formula.Kind, "Formula kind should not be null");

                    // Value (LaTeX) is optional but should be validated if present
                    if (!string.IsNullOrEmpty(formula.Value))
                    {
                        Assert.IsTrue(formula.Value.Length > 0, "Formula value should not be empty");
                    }

                    // Confidence is optional but should be in valid range if present
                    if (formula.Confidence.HasValue)
                    {
                        Assert.IsTrue(formula.Confidence.Value >= 0 && formula.Confidence.Value <= 1,
                            "Formula confidence should be between 0 and 1");
                    }
                }

                Console.WriteLine($"✓ Verified {allFormulasAssert.Count} formula(s)");
            }
            #endregion

            #region Snippet:ContentUnderstandingExtractAnnotations
            // Extract annotations from document content
            if (result.Contents?.FirstOrDefault() is DocumentContent document)
            {
                if (document.Annotations != null && document.Annotations.Count > 0)
                {
                    Console.WriteLine($"Found {document.Annotations.Count} annotation(s)");
                    foreach (var annotation in document.Annotations)
                    {
                        Console.WriteLine($"  Annotation ID: {annotation.Id}");
                        Console.WriteLine($"    Kind: {annotation.Kind}");
                        if (!string.IsNullOrEmpty(annotation.Author))
                        {
                            Console.WriteLine($"    Author: {annotation.Author}");
                        }
                        if (annotation.Comments != null && annotation.Comments.Count > 0)
                        {
                            Console.WriteLine($"    Comments: {annotation.Comments.Count}");
                            foreach (var comment in annotation.Comments)
                            {
                                Console.WriteLine($"      - {comment.Message}");
                            }
                        }
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractAnnotations
            var docContentAnnotations = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContentAnnotations, "Content should be DocumentContent");

            // Annotations are optional - validate structure if present
            if (docContentAnnotations!.Annotations != null && docContentAnnotations.Annotations.Count > 0)
            {
                foreach (var annotation in docContentAnnotations.Annotations)
                {
                    Assert.IsNotNull(annotation, "Annotation should not be null");
                    Assert.IsNotNull(annotation.Id, "Annotation ID should not be null");
                    Assert.IsFalse(string.IsNullOrWhiteSpace(annotation.Id),
                        "Annotation ID should not be empty");
                    Assert.IsNotNull(annotation.Kind, "Annotation kind should not be null");

                    // Author is optional, no assertion needed

                    // Validate comments structure if present
                    if (annotation.Comments != null && annotation.Comments.Count > 0)
                    {
                        foreach (var comment in annotation.Comments)
                        {
                            Assert.IsNotNull(comment, "Comment should not be null");
                            Assert.IsNotNull(comment.Message, "Comment message should not be null");
                        }
                    }
                }

                Console.WriteLine($"✓ Verified {docContentAnnotations.Annotations.Count} annotation(s)");
            }
            #endregion
        }
    }
}
