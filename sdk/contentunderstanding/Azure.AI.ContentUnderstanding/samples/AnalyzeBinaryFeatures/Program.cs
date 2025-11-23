// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates additional features on prebuilt-documentSearch to show results for charts, hyperlinks, and PDF annotations from PDF.
///
/// Prerequisites:
///     - Azure subscription
///     - Azure Content Understanding resource
///     - .NET 8.0 SDK or later
///
/// Setup:
///     Set the following environment variables or add them to appsettings.json:
///     - AZURE_CONTENT_UNDERSTANDING_ENDPOINT (required)
///     - AZURE_CONTENT_UNDERSTANDING_KEY (optional - DefaultAzureCredential will be used if not set)
///
/// To run:
///     dotnet run
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Analyze Binary Features");
        Console.WriteLine("=============================================================");
        Console.WriteLine();

        try
        {
            // Step 1: Load configuration
            Console.WriteLine("Step 1: Loading configuration...");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var endpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"];
            if (string.IsNullOrEmpty(endpoint))
            {
                Console.Error.WriteLine("Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required.");
                Console.Error.WriteLine("Please set it in environment variables or appsettings.json");
                Environment.Exit(1);
            }

            endpoint = endpoint.Trim();
            if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var endpointUri))
            {
                Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
                Console.Error.WriteLine("Endpoint must be a valid absolute URI (e.g., https://your-resource.cognitiveservices.azure.com/)");
                Environment.Exit(1);
            }

            Console.WriteLine($"  Endpoint: {endpoint}");
            Console.WriteLine();

            // Step 2: Create the client
            Console.WriteLine("Step 2: Creating Content Understanding client...");
            var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            ContentUnderstandingClient client;

            if (!string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("  Authentication: API Key");
                client = new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey));
            }
            else
            {
                Console.WriteLine("  Authentication: DefaultAzureCredential");
                client = new ContentUnderstandingClient(endpointUri, new DefaultAzureCredential());
            }
            Console.WriteLine();

            // Step 3: Read the PDF file
            Console.WriteLine("Step 3: Reading PDF file...");
            string pdfPath = Path.Combine(AppContext.BaseDirectory, "sample_files", "sample_document_features.pdf");

            if (!File.Exists(pdfPath))
            {
                Console.Error.WriteLine($"Error: Sample file not found at {pdfPath}");
                Console.Error.WriteLine("Next step: Run 'dotnet build' to copy the sample file to the output directory.");
                Environment.Exit(1);
            }

            byte[] pdfBytes = await File.ReadAllBytesAsync(pdfPath);
            Console.WriteLine($"  File: {pdfPath}");
            Console.WriteLine($"  Size: {pdfBytes.Length:N0} bytes");
            Console.WriteLine();

            // Step 4: Analyze document
            Console.WriteLine("Step 4: Analyzing document...");
            Console.WriteLine("  Analyzer: prebuilt-documentSearch");
            Console.WriteLine("  This sample demonstrates additional features: charts, hyperlinks, and PDF annotations.");
            Console.WriteLine();

            AnalyzeResult result;
            try
            {
                var operation = await client.AnalyzeBinaryAsync(
                    WaitUntil.Completed,
                    "prebuilt-documentSearch",
                    "application/pdf",
                    BinaryData.FromBytes(pdfBytes));

                result = operation.Value;
                Console.WriteLine("  Analysis completed successfully");
                Console.WriteLine($"  Result: AnalyzerId={result.AnalyzerId}, Contents count={result.Contents?.Count ?? 0}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to analyze document: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 5: Get document content
            if (result.Contents == null || result.Contents.Count == 0)
            {
                Console.WriteLine("Error: No content returned from analysis");
                return;
            }

            var content = result.Contents.First();
            if (content is not DocumentContent documentContent)
            {
                Console.WriteLine("Error: Expected document content");
                return;
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine("DOCUMENT ANALYSIS RESULTS");
            Console.WriteLine("=============================================================");
            Console.WriteLine($"Start page: {documentContent.StartPageNumber}");
            Console.WriteLine($"End page: {documentContent.EndPageNumber}");
            Console.WriteLine($"Total pages: {documentContent.EndPageNumber - documentContent.StartPageNumber + 1}");
            Console.WriteLine();

            // Step 6: Extract and display charts
            DisplayCharts(documentContent);

            // Step 7: Extract and display annotations
            DisplayAnnotations(documentContent);

            // Step 8: Extract and display hyperlinks
            DisplayHyperlinks(documentContent);

            // Step 9: Extract and display formulas
            DisplayFormulas(documentContent);

            // Step 10: Markdown content note
            Console.WriteLine("=============================================================");
            Console.WriteLine("MARKDOWN CONTENT");
            Console.WriteLine("=============================================================");
            Console.WriteLine("Note: Markdown content is available in the result and contains embedded");
            Console.WriteLine("representations of charts, annotations, and hyperlinks.");
            Console.WriteLine("See AnalyzeBinary sample for how to extract and display markdown content.");
            Console.WriteLine("=============================================================");
            Console.WriteLine();

            // Step 11: Save result as JSON
            await SaveResultAsJson(result, "analyze_binary_features");

            Console.WriteLine("=============================================================");
            Console.WriteLine("✓ Sample completed successfully");
            Console.WriteLine("=============================================================");
        }
        catch (RequestFailedException ex) when (ex.Status == 401)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ Authentication failed");
            Console.Error.WriteLine($"  Error: {ex.Message}");
            Console.Error.WriteLine("  Please check your credentials and ensure they are valid.");
            Environment.Exit(1);
        }
        catch (RequestFailedException ex)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ Service request failed");
            Console.Error.WriteLine($"  Status: {ex.Status}");
            Console.Error.WriteLine($"  Error Code: {ex.ErrorCode}");
            Console.Error.WriteLine($"  Message: {ex.Message}");
            Environment.Exit(1);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine();
            Console.Error.WriteLine("✗ An unexpected error occurred");
            Console.Error.WriteLine($"  Error: {ex.Message}");
            Console.Error.WriteLine($"  Type: {ex.GetType().Name}");
            Environment.Exit(1);
        }
    }

    static void DisplayCharts(DocumentContent documentContent)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("CHARTS EXTRACTION");
        Console.WriteLine("=============================================================");

        if (documentContent.Figures == null || documentContent.Figures.Count == 0)
        {
            Console.WriteLine("No figures found in the document");
            Console.WriteLine();
            return;
        }

        // Filter for chart figures
        var chartFigures = documentContent.Figures
            .Where(f => f is DocumentChartFigure)
            .Cast<DocumentChartFigure>()
            .ToList();

        Console.WriteLine($"Found {chartFigures.Count} chart(s) in the document");
        Console.WriteLine();

        for (int i = 0; i < chartFigures.Count; i++)
        {
            var chart = chartFigures[i];
            Console.WriteLine($"Chart {i + 1}:");
            Console.WriteLine($"  ID: {chart.Id}");
            Console.WriteLine($"  Source: {chart.Source ?? "(not available)"}");

            if (!string.IsNullOrEmpty(chart.Description))
            {
                Console.WriteLine($"  Description: {chart.Description}");
            }

            if (chart.Caption != null && !string.IsNullOrEmpty(chart.Caption.Content))
            {
                Console.WriteLine($"  Caption: {chart.Caption.Content}");
            }

            if (chart.Span != null)
            {
                Console.WriteLine($"  Location in markdown: offset={chart.Span.Offset}, length={chart.Span.Length}");
            }

            // The chart content contains Chart.js configuration
            if (chart.Content != null && chart.Content.Count > 0)
            {
                Console.WriteLine($"  Chart.js Config:");
                foreach (var kvp in chart.Content)
                {
                    try
                    {
                        var jsonString = kvp.Value.ToString();
                        var jsonDoc = JsonDocument.Parse(jsonString);
                        var formattedJson = JsonSerializer.Serialize(jsonDoc, new JsonSerializerOptions { WriteIndented = true });
                        Console.WriteLine($"  {formattedJson}");
                    }
                    catch
                    {
                        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
                    }
                }
            }

            Console.WriteLine();
        }
    }

    static void DisplayAnnotations(DocumentContent documentContent)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("ANNOTATIONS EXTRACTION");
        Console.WriteLine("=============================================================");

        if (documentContent.Annotations == null || documentContent.Annotations.Count == 0)
        {
            Console.WriteLine("No annotations found in the document");
            Console.WriteLine();
            return;
        }

        Console.WriteLine($"Found {documentContent.Annotations.Count} annotation(s) in the document");
        Console.WriteLine();

        for (int i = 0; i < documentContent.Annotations.Count; i++)
        {
            var annotation = documentContent.Annotations[i];
            Console.WriteLine($"Annotation {i + 1}:");
            Console.WriteLine($"  ID: {annotation.Id}");
            Console.WriteLine($"  Kind: {annotation.Kind}");

            if (annotation.Spans != null && annotation.Spans.Count > 0)
            {
                Console.WriteLine($"  Spans ({annotation.Spans.Count}):");
                foreach (var span in annotation.Spans)
                {
                    Console.WriteLine($"    - offset={span.Offset}, length={span.Length}");
                }
            }

            if (annotation.Comments != null && annotation.Comments.Count > 0)
            {
                Console.WriteLine($"  Comments ({annotation.Comments.Count}):");
                foreach (var comment in annotation.Comments)
                {
                    Console.WriteLine($"    - {comment.Message}");
                }
            }

            if (!string.IsNullOrEmpty(annotation.Author))
            {
                Console.WriteLine($"  Author: {annotation.Author}");
            }

            if (annotation.CreatedAt.HasValue)
            {
                Console.WriteLine($"  Created at: {annotation.CreatedAt.Value}");
            }

            if (annotation.Tags != null && annotation.Tags.Count > 0)
            {
                Console.WriteLine($"  Tags: {string.Join(", ", annotation.Tags)}");
            }

            if (!string.IsNullOrEmpty(annotation.Source))
            {
                Console.WriteLine($"  Source: {annotation.Source}");
            }

            Console.WriteLine();
        }
    }

    static void DisplayHyperlinks(DocumentContent documentContent)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("HYPERLINKS EXTRACTION");
        Console.WriteLine("=============================================================");

        if (documentContent.Hyperlinks == null || documentContent.Hyperlinks.Count == 0)
        {
            Console.WriteLine("No hyperlinks found in the document");
            Console.WriteLine();
            return;
        }

        Console.WriteLine($"Found {documentContent.Hyperlinks.Count} hyperlink(s) in the document");
        Console.WriteLine();

        for (int i = 0; i < documentContent.Hyperlinks.Count; i++)
        {
            var hyperlink = documentContent.Hyperlinks[i];
            Console.WriteLine($"Hyperlink {i + 1}:");
            Console.WriteLine($"  Content: {hyperlink.Content ?? "(not available)"}");
            Console.WriteLine($"  URL: {hyperlink.Url ?? "(not available)"}");

            if (hyperlink.Span != null)
            {
                Console.WriteLine($"  Location in markdown: offset={hyperlink.Span.Offset}, length={hyperlink.Span.Length}");
            }

            if (!string.IsNullOrEmpty(hyperlink.Source))
            {
                Console.WriteLine($"  Source: {hyperlink.Source}");
            }

            Console.WriteLine();
        }
    }

    static void DisplayFormulas(DocumentContent documentContent)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("FORMULAS EXTRACTION");
        Console.WriteLine("=============================================================");

        // Collect all formulas from all pages
        var allFormulas = new List<DocumentFormula>();
        if (documentContent.Pages != null)
        {
            foreach (var page in documentContent.Pages)
            {
                if (page.Formulas != null)
                {
                    allFormulas.AddRange(page.Formulas);
                }
            }
        }

        if (allFormulas.Count == 0)
        {
            Console.WriteLine("No formulas found in the document");
            Console.WriteLine();
            return;
        }

        Console.WriteLine($"Found {allFormulas.Count} formula(s) in the document");
        Console.WriteLine();
        Console.WriteLine("Note: LaTeX values may contain extra spaces (e.g., '\\frac { 1 } { n }').");
        Console.WriteLine("      This is expected from PDF extraction and will still render correctly.");
        Console.WriteLine();

        for (int i = 0; i < allFormulas.Count; i++)
        {
            var formula = allFormulas[i];
            Console.WriteLine($"Formula {i + 1}:");
            Console.WriteLine($"  Kind: {formula.Kind}");
            Console.WriteLine($"  LaTeX: {formula.Value ?? "(not available)"}");

            if (formula.Confidence.HasValue)
            {
                Console.WriteLine($"  Confidence: {formula.Confidence.Value}");
            }

            if (formula.Span != null)
            {
                Console.WriteLine($"  Location in markdown: offset={formula.Span.Offset}, length={formula.Span.Length}");
            }

            if (!string.IsNullOrEmpty(formula.Source))
            {
                Console.WriteLine($"  Source: {formula.Source}");
            }

            Console.WriteLine();
        }
    }

    static async Task SaveResultAsJson(AnalyzeResult result, string filenamePrefix)
    {
        Console.WriteLine();
        Console.WriteLine("=============================================================");
        Console.WriteLine("SAVING ANALYZE RESULT AS JSON");
        Console.WriteLine("=============================================================");

        try
        {
            var outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
            Directory.CreateDirectory(outputDir);

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var filename = $"{filenamePrefix}_{timestamp}.json";
            var filepath = Path.Combine(outputDir, filename);

            // Convert result to JSON
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };

            var jsonString = JsonSerializer.Serialize(result, options);
            await File.WriteAllTextAsync(filepath, jsonString);

            Console.WriteLine($"✓ Saved to: {filepath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️  Failed to save JSON: {ex.Message}");
        }

        Console.WriteLine("=============================================================");
    }
}

