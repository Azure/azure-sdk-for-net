// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to analyze a document using the prebuilt-documentSearch analyzer.
///
/// Prerequisites:
///     - Azure subscription
///     - Microsoft Foundry resource
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
        // Load configuration
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

        // Trim and validate endpoint
        endpoint = endpoint.Trim();
        if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var endpointUri))
        {
            Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
            Console.Error.WriteLine("Endpoint must be a valid absolute URI (e.g., https://your-resource.services.ai.azure.com/)");
            Environment.Exit(1);
        }

        // Create client with appropriate authentication
        var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
        ContentUnderstandingClient client;
        if (!string.IsNullOrEmpty(apiKey))
        {
            client = new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey));
        }
        else
        {
            var credential = new DefaultAzureCredential();
            client = new ContentUnderstandingClient(endpointUri, credential);
        }

        // === EXTRACTED SNIPPET CODE ===
        string filePath = Path.Combine(AppContext.BaseDirectory, "sample_files", "sample_document_features.pdf");
        if (!File.Exists(filePath))
        {
            Console.Error.WriteLine($"Error: Sample file not found at {filePath}");
            Console.Error.WriteLine("Please ensure the sample file is copied to the output directory.");
            Environment.Exit(1);
        }
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
        // === END SNIPPET ===
    }
}
