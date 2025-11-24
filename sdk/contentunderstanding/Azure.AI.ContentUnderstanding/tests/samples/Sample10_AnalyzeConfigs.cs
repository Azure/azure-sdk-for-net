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
            BinaryData bytesSource = BinaryData.FromBytes(fileBytes);

            // Analyze with prebuilt-documentSearch which has formulas, layout, and OCR enabled
            // These configs enable extraction of charts, annotations, hyperlinks, and formulas
            Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
                WaitUntil.Completed,
                "prebuilt-documentSearch",
                "application/pdf",
                bytesSource);

            AnalyzeResult result = operation.Value;
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
        }
    }
}
