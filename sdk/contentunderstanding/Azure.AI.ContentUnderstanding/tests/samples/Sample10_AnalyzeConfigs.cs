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
            byte[] fileBytes = File.ReadAllBytes(filePath);
            BinaryData binaryData = BinaryData.FromBytes(fileBytes);

            // Analyze with prebuilt-documentSearch which has formulas, layout, and OCR enabled
            // These configs enable extraction of charts, annotations, hyperlinks, and formulas
            Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                binaryData);

            AnalyzeResult result = operation.Value;
            #endregion

            #region Assertion:ContentUnderstandingAnalyzeWithConfigs
            Assert.IsTrue(File.Exists(filePath), $"Sample file not found at {filePath}");
            Assert.IsTrue(fileBytes.Length > 0, "File should not be empty");
            Assert.IsNotNull(binaryData, "Binary data should not be null");
            Console.WriteLine($"File loaded: {filePath} ({fileBytes.Length} bytes)");

            Assert.IsNotNull(operation, "Analysis operation should not be null");
            Assert.IsTrue(operation.HasCompleted, "Operation should be completed");
            Assert.IsTrue(operation.HasValue, "Operation should have a value");
            Assert.IsNotNull(operation.GetRawResponse(), "Analysis operation should have a raw response");
            Assert.IsTrue(operation.GetRawResponse().Status >= 200 && operation.GetRawResponse().Status < 300,
                $"Response status should be successful, but was {operation.GetRawResponse().Status}");
            Console.WriteLine("Analysis operation properties verified");

            Assert.IsNotNull(result, "Analysis result should not be null");
            Assert.IsNotNull(result.Contents, "Result should contain contents");
            Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
            Assert.AreEqual(1, result.Contents.Count, "PDF file should have exactly one content element");
            Console.WriteLine($"Analysis result contains {result.Contents.Count} content(s)");

            // Verify document content type
            var firstDocContent = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(firstDocContent, "Content should be DocumentContent");
            Assert.IsTrue(firstDocContent!.StartPageNumber >= 1, "Start page should be >= 1");
            Assert.IsTrue(firstDocContent.EndPageNumber >= firstDocContent.StartPageNumber, "End page should be >= start page");
            int totalPages = firstDocContent.EndPageNumber - firstDocContent.StartPageNumber + 1;
            Console.WriteLine($"Document has {totalPages} page(s) from {firstDocContent.StartPageNumber} to {firstDocContent.EndPageNumber}");

            Console.WriteLine("Document features analysis with configs completed successfully");
            #endregion

            #region Snippet:ContentUnderstandingExtractCharts
            // Extract charts from document content (enabled by EnableFigureAnalysis config)
            DocumentContent documentContent = (DocumentContent)result.Contents!.First();
            if (documentContent.Figures != null)
            {
                foreach (DocumentFigure figure in documentContent.Figures)
                {
                    if (figure is DocumentChartFigure chart)
                    {
                        Console.WriteLine($"  Chart ID: {chart.Id}");
                        Console.WriteLine($"    Description: {chart.Description ?? "(not available)"}");
                        Console.WriteLine($"    Caption: {chart.Caption?.Content ?? "(not available)"}");
                    }
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractCharts
            var docContentCharts = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContentCharts, "Content should be DocumentContent");
            Console.WriteLine("\nChart Extraction Verification:");

            // Charts are optional - GPT sometimes does not detect them
            if (docContentCharts!.Figures != null && docContentCharts.Figures.Count > 0)
            {
                Console.WriteLine($"Found {docContentCharts.Figures.Count} figure(s)");

                var chartFiguresAssert = docContentCharts.Figures
                    .Where(f => f is DocumentChartFigure)
                    .Cast<DocumentChartFigure>()
                    .ToList();

                if (chartFiguresAssert.Count == 0)
                {
                    Console.WriteLine("⚠️ Warning: No charts detected in sample_document_features. pdf");
                    Console.WriteLine("   GPT sometimes does not detect charts - this is acceptable");
                }
                else
                {
                    Console.WriteLine($"Found {chartFiguresAssert.Count} chart(s)");

                    int chartIndex = 1;
                    foreach (var chart in chartFiguresAssert)
                    {
                        Assert.IsNotNull(chart, $"Chart {chartIndex} should not be null");
                        Assert.IsNotNull(chart.Id, $"Chart {chartIndex} ID should not be null");
                        Assert.IsFalse(string.IsNullOrWhiteSpace(chart.Id),
                            $"Chart {chartIndex} ID should not be empty");
                        Console.WriteLine($"  Chart {chartIndex}: ID = '{chart.Id}'");

                        // Verify description if present
                        if (!string.IsNullOrWhiteSpace(chart.Description))
                        {
                            Assert.IsTrue(chart.Description.Length > 0,
                                $"Chart {chartIndex} description should not be empty when present");
                            Console.WriteLine($"    Description: {chart.Description.Substring(0, Math.Min(50, chart.Description.Length))}{(chart.Description.Length > 50 ? "..." : "")}");
                        }
                        else
                        {
                            Console.WriteLine($"    Description: (not available)");
                        }

                        // Verify caption if present
                        if (chart.Caption != null)
                        {
                            Assert.IsNotNull(chart.Caption, $"Chart {chartIndex} caption object should not be null");

                            if (!string.IsNullOrWhiteSpace(chart.Caption.Content))
                            {
                                Assert.IsTrue(chart.Caption.Content.Length > 0,
                                    $"Chart {chartIndex} caption content should not be empty when present");
                                Console.WriteLine($"    Caption: {chart.Caption.Content}");
                            }
                            else
                            {
                                Console.WriteLine($"    Caption: (empty)");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"    Caption: (not available)");
                        }

                        chartIndex++;
                    }

                    Console.WriteLine($"Verified {chartFiguresAssert.Count} chart(s)");
                }
            }
            else
            {
                Console.WriteLine("⚠️ Warning: No figures detected in sample_document_features. pdf");
                Console.WriteLine("   GPT sometimes does not detect charts - this is acceptable");
            }
            #endregion

            #region Snippet:ContentUnderstandingExtractHyperlinks
            // Extract hyperlinks from document content (enabled by EnableLayout config)
            DocumentContent docContent = (DocumentContent)result.Contents!.First();
            Console.WriteLine($"Found {docContent.Hyperlinks?.Count ?? 0} hyperlink(s)");
            foreach (var hyperlink in docContent.Hyperlinks ?? Enumerable.Empty<DocumentHyperlink>())
            {
                Console.WriteLine($"  URL: {hyperlink.Url ?? "(not available)"}");
                Console.WriteLine($"    Content: {hyperlink.Content ?? "(not available)"}");
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractHyperlinks
            var docContentHyperlinks = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContentHyperlinks, "Content should be DocumentContent");
            Console.WriteLine("\n🔗 Hyperlink Extraction Verification:");

            // Hyperlinks should not be empty for sample_document_features.pdf
            Assert.IsNotNull(docContentHyperlinks!.Hyperlinks, "Hyperlinks should not be null");
            Assert.IsTrue(docContentHyperlinks.Hyperlinks.Count > 0,
                "sample_document_features. pdf should contain hyperlinks");
            Console.WriteLine($"Found {docContentHyperlinks.Hyperlinks.Count} hyperlink(s)");

            int hyperlinkIndex = 1;
            int hyperlinksWithUrl = 0;
            int hyperlinksWithContent = 0;
            int hyperlinksWithBoth = 0;

            foreach (var hyperlink in docContentHyperlinks.Hyperlinks)
            {
                Assert.IsNotNull(hyperlink, $"Hyperlink {hyperlinkIndex} should not be null");

                // At least one of URL or Content should be present
                Assert.IsTrue(!string.IsNullOrEmpty(hyperlink.Url) || !string.IsNullOrEmpty(hyperlink.Content),
                    $"Hyperlink {hyperlinkIndex} should have either URL or Content");

                bool hasUrl = !string.IsNullOrEmpty(hyperlink.Url);
                bool hasContent = !string.IsNullOrEmpty(hyperlink.Content);

                if (hasUrl) hyperlinksWithUrl++;
                if (hasContent) hyperlinksWithContent++;
                if (hasUrl && hasContent) hyperlinksWithBoth++;

                Console.WriteLine($"  Hyperlink {hyperlinkIndex}:");

                if (hasUrl)
                {
                    Assert.IsTrue(hyperlink.Url!.Length > 0,
                        $"Hyperlink {hyperlinkIndex} URL should not be empty when present");

                    // Verify URL format (basic validation)
                    Assert.IsTrue(Uri.IsWellFormedUriString(hyperlink.Url, UriKind.RelativeOrAbsolute),
                        $"Hyperlink {hyperlinkIndex} URL should be well-formed: {hyperlink.Url}");

                    Console.WriteLine($"    URL: {hyperlink.Url}");
                }
                else
                {
                    Console.WriteLine($"    URL: (not available)");
                }

                if (hasContent)
                {
                    Assert.IsTrue(hyperlink.Content!.Length > 0,
                        $"Hyperlink {hyperlinkIndex} content should not be empty when present");
                    Console.WriteLine($"    Content: {hyperlink.Content}");
                }
                else
                {
                    Console.WriteLine($"    Content: (not available)");
                }

                hyperlinkIndex++;
            }

            Console.WriteLine($"\nHyperlink statistics:");
            Console.WriteLine($"  Total: {docContentHyperlinks.Hyperlinks.Count}");
            Console.WriteLine($"  With URL: {hyperlinksWithUrl} ({(double)hyperlinksWithUrl / docContentHyperlinks.Hyperlinks.Count * 100:F1}%)");
            Console.WriteLine($"  With content: {hyperlinksWithContent} ({(double)hyperlinksWithContent / docContentHyperlinks.Hyperlinks.Count * 100:F1}%)");
            Console.WriteLine($"  With both: {hyperlinksWithBoth} ({(double)hyperlinksWithBoth / docContentHyperlinks.Hyperlinks.Count * 100:F1}%)");
            Console.WriteLine($"Verified {docContentHyperlinks.Hyperlinks.Count} hyperlink(s)");
            #endregion

            #region Snippet:ContentUnderstandingExtractFormulas
            // Extract formulas from document pages (enabled by EnableFormula config)
            DocumentContent content = (DocumentContent)result.Contents!.First();
            var allFormulas = new List<DocumentFormula>();
            foreach (var page in content.Pages ?? Enumerable.Empty<DocumentPage>())
            {
                allFormulas.AddRange(page.Formulas ?? Enumerable.Empty<DocumentFormula>());
            }

            Console.WriteLine($"Found {allFormulas.Count} formula(s)");
            foreach (var formula in allFormulas)
            {
                Console.WriteLine($"  Formula Kind: {formula.Kind}");
                Console.WriteLine($"    LaTeX: {formula.Value ?? "(not available)"}");
                Console.WriteLine($"    Confidence: {formula.Confidence?.ToString("F2") ?? "N/A"}");
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractFormulas
            var docContentFormulas = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContentFormulas, "Content should be DocumentContent");
            Console.WriteLine("\n🧮 Formula Extraction Verification:");

            // Formulas should not be empty for sample_document_features. pdf
            var allFormulasAssert = new System.Collections.Generic.List<DocumentFormula>();
            Assert.IsNotNull(docContentFormulas!.Pages, "Pages should not be null");
            Assert.IsTrue(docContentFormulas.Pages.Count > 0, "Should have at least one page");

            int pagesWithFormulas = 0;
            foreach (var page in docContentFormulas.Pages)
            {
                if (page.Formulas != null && page.Formulas.Count > 0)
                {
                    pagesWithFormulas++;
                    allFormulasAssert.AddRange(page.Formulas);
                    Console.WriteLine($"  Page {page.PageNumber}: {page.Formulas.Count} formula(s)");
                }
            }

            Assert.IsTrue(allFormulasAssert.Count > 0,
                "sample_document_features.pdf should contain formulas");
            Console.WriteLine($"Found {allFormulasAssert.Count} formula(s) across {pagesWithFormulas} page(s)");

            int formulaIndex = 1;
            var formulaKinds = new System.Collections.Generic.Dictionary<string, int>();
            int formulasWithValue = 0;
            int formulasWithConfidence = 0;

            foreach (var formula in allFormulasAssert)
            {
                Assert.IsNotNull(formula, $"Formula {formulaIndex} should not be null");
                Assert.IsNotNull(formula.Kind, $"Formula {formulaIndex} kind should not be null");

                // Track formula kinds
                if (!formulaKinds.ContainsKey(formula.Kind.ToString()))
                    formulaKinds[formula.Kind.ToString()] = 0;
                formulaKinds[formula.Kind.ToString()]++;

                Console.WriteLine($"  Formula {formulaIndex}: Kind = {formula.Kind}");

                // Value (LaTeX) is optional but should be validated if present
                if (!string.IsNullOrWhiteSpace(formula.Value))
                {
                    formulasWithValue++;
                    Assert.IsTrue(formula.Value.Length > 0,
                        $"Formula {formulaIndex} value should not be empty when present");
                    Console.WriteLine($"    LaTeX: {formula.Value}");
                }
                else
                {
                    Console.WriteLine($"    LaTeX: (not available)");
                }

                // Confidence is optional but should be in valid range if present
                if (formula.Confidence.HasValue)
                {
                    formulasWithConfidence++;
                    Assert.IsTrue(formula.Confidence.Value >= 0 && formula.Confidence.Value <= 1,
                        $"Formula {formulaIndex} confidence should be between 0 and 1, but was {formula.Confidence.Value}");
                    Console.WriteLine($"    Confidence: {formula.Confidence.Value:F2}");
                }
                else
                {
                    Console.WriteLine($"    Confidence: (not available)");
                }

                formulaIndex++;
            }

            Console.WriteLine($"\nFormula statistics:");
            Console.WriteLine($"  Total formulas: {allFormulasAssert.Count}");
            Console.WriteLine($"  Pages with formulas: {pagesWithFormulas}");
            Console.WriteLine($"  With LaTeX value: {formulasWithValue} ({(double)formulasWithValue / allFormulasAssert.Count * 100:F1}%)");
            Console.WriteLine($"  With confidence: {formulasWithConfidence} ({(double)formulasWithConfidence / allFormulasAssert.Count * 100:F1}%)");
            Console.WriteLine($"  Formula kinds:");
            foreach (var kind in formulaKinds.OrderByDescending(k => k.Value))
            {
                Console.WriteLine($"    {kind.Key}: {kind.Value} ({(double)kind.Value / allFormulasAssert.Count * 100:F1}%)");
            }
            Console.WriteLine($"Verified {allFormulasAssert.Count} formula(s)");
            #endregion

            #region Snippet:ContentUnderstandingExtractAnnotations
            // Extract annotations from document content (enabled by EnableLayout config)
            DocumentContent document = (DocumentContent)result.Contents!.First();
            Console.WriteLine($"Found {document.Annotations?.Count ?? 0} annotation(s)");
            foreach (var annotation in document.Annotations ?? Enumerable.Empty<DocumentAnnotation>())
            {
                Console.WriteLine($"  Annotation ID: {annotation.Id}");
                Console.WriteLine($"    Kind: {annotation.Kind}");
                Console.WriteLine($"    Author: {annotation.Author ?? "(not available)"}");
                Console.WriteLine($"    Comments: {annotation.Comments?.Count ?? 0}");
                foreach (var comment in annotation.Comments ?? Enumerable.Empty<DocumentAnnotationComment>())
                {
                    Console.WriteLine($"      - {comment.Message}");
                }
            }
            #endregion

            #region Assertion:ContentUnderstandingExtractAnnotations
            var docContentAnnotations = result.Contents?.FirstOrDefault() as DocumentContent;
            Assert.IsNotNull(docContentAnnotations, "Content should be DocumentContent");
            Console.WriteLine("\nAnnotation Extraction Verification:");

            // Annotations should not be empty for sample_document_features.pdf
            Assert.IsNotNull(docContentAnnotations!.Annotations, "Annotations should not be null");
            Assert.IsTrue(docContentAnnotations.Annotations.Count > 0,
                "sample_document_features.pdf should contain annotations");
            Console.WriteLine($"Found {docContentAnnotations.Annotations.Count} annotation(s)");

            int annotationIndex = 1;
            var annotationKinds = new System.Collections.Generic.Dictionary<string, int>();
            int annotationsWithAuthor = 0;
            int annotationsWithComments = 0;
            int totalComments = 0;

            foreach (var annotation in docContentAnnotations!.Annotations)
            {
                Assert.IsNotNull(annotation, $"Annotation {annotationIndex} should not be null");
                Assert.IsNotNull(annotation.Id, $"Annotation {annotationIndex} ID should not be null");
                Assert.IsFalse(string.IsNullOrWhiteSpace(annotation.Id),
                    $"Annotation {annotationIndex} ID should not be empty");
                Assert.IsNotNull(annotation.Kind, $"Annotation {annotationIndex} kind should not be null");
                Assert.IsFalse(string.IsNullOrWhiteSpace(annotation.Kind.ToString()),
                    $"Annotation {annotationIndex} kind should not be empty");

                // Track annotation kinds
                if (!annotationKinds.ContainsKey(annotation.Kind.ToString()))
                    annotationKinds[annotation.Kind.ToString()] = 0;
                annotationKinds[annotation.Kind.ToString()]++;

                Console.WriteLine($"  Annotation {annotationIndex}:");
                Console.WriteLine($"    ID: {annotation.Id}");
                Console.WriteLine($"    Kind: {annotation.Kind}");

                // Verify author if present
                if (!string.IsNullOrWhiteSpace(annotation.Author))
                {
                    annotationsWithAuthor++;
                    Assert.IsTrue(annotation.Author.Length > 0,
                        $"Annotation {annotationIndex} author should not be empty when present");
                    Console.WriteLine($"    Author: {annotation.Author}");
                }
                else
                {
                    Console.WriteLine($"    Author: (not available)");
                }

                // Validate comments structure if present
                if (annotation.Comments != null && annotation.Comments.Count > 0)
                {
                    annotationsWithComments++;
                    totalComments += annotation.Comments.Count;

                    Assert.IsTrue(annotation.Comments.Count > 0,
                        $"Annotation {annotationIndex} comments should not be empty when not null");
                    Console.WriteLine($"    Comments: {annotation.Comments.Count}");

                    int commentIndex = 1;
                    foreach (var comment in annotation.Comments)
                    {
                        Assert.IsNotNull(comment,
                            $"Annotation {annotationIndex} comment {commentIndex} should not be null");
                        Assert.IsNotNull(comment.Message,
                            $"Annotation {annotationIndex} comment {commentIndex} message should not be null");
                        Assert.IsFalse(string.IsNullOrWhiteSpace(comment.Message),
                            $"Annotation {annotationIndex} comment {commentIndex} message should not be empty");

                        Console.WriteLine($"      {commentIndex}. {comment.Message}");

                        // Verify author if present in comment
                        if (!string.IsNullOrWhiteSpace(comment.Author))
                        {
                            Console.WriteLine($"         Author: {comment.Author}");
                        }

                        commentIndex++;
                    }
                }
                else
                {
                    Console.WriteLine($"    Comments: (none)");
                }

                annotationIndex++;
            }

            Console.WriteLine($"\nAnnotation statistics:");
            Console.WriteLine($"  Total annotations: {docContentAnnotations.Annotations.Count}");
            Console.WriteLine($"  With author: {annotationsWithAuthor} ({(double)annotationsWithAuthor / docContentAnnotations.Annotations.Count * 100:F1}%)");
            Console.WriteLine($"  With comments: {annotationsWithComments} ({(double)annotationsWithComments / docContentAnnotations.Annotations.Count * 100:F1}%)");
            Console.WriteLine($"  Total comments: {totalComments}");
            if (annotationsWithComments > 0)
            {
                Console.WriteLine($"  Average comments per annotation: {(double)totalComments / annotationsWithComments:F1}");
            }
            Console.WriteLine($"  Annotation kinds:");
            foreach (var kind in annotationKinds.OrderByDescending(k => k.Value))
            {
                Console.WriteLine($"    {kind.Key}: {kind.Value} ({(double)kind.Value / docContentAnnotations.Annotations.Count * 100:F1}%)");
            }
            Console.WriteLine($"Verified {docContentAnnotations.Annotations.Count} annotation(s)");
            #endregion
        }
    }
}
