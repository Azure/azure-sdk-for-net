// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        // Define content categories for classification
        var categories = new Dictionary<string, ContentCategory>
        {
            ["Loan_Application"] = new ContentCategory
            {
                Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation."
            },
            ["Invoice"] = new ContentCategory
            {
                Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
            },
            ["Bank_Statement"] = new ContentCategory
            {
                Description = "Official statements issued by banks that summarize account activity over a period, including deposits, withdrawals, fees, and balances."
            }
        };
        // Create analyzer configuration
        var config = new ContentAnalyzerConfig
        {
            ReturnDetails = true,
            EnableSegment = true // Enable automatic segmentation by category
        };
        // Add categories to config
        foreach (var kvp in categories)
        {
            config.ContentCategories.Add(kvp.Key, kvp.Value);
        }
        // Create the classifier analyzer
        var classifier = new ContentAnalyzer
        {
            BaseAnalyzerId = "prebuilt-document",
            Description = "Custom classifier for financial document categorization",
            Config = config
        };
        classifier.Models.Add("completion", "gpt-4.1");
        // Create the classifier
        string analyzerId = $"my_classifier_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        var operation = await client.CreateAnalyzerAsync(
            WaitUntil.Completed,
            analyzerId,
            classifier);
        ContentAnalyzer result = operation.Value;
        Console.WriteLine($"Classifier '{analyzerId}' created successfully!");

        // Read the sample file
        string filePath = Path.Combine(AppContext.BaseDirectory, "sample_files", "sample_invoice.pdf");
        if (!File.Exists(filePath))
        {
            Console.Error.WriteLine($"Error: Sample file not found at {filePath}");
            Console.Error.WriteLine("Please ensure the sample file is copied to the output directory.");
            Environment.Exit(1);
        }
        byte[] fileBytes = File.ReadAllBytes(filePath);

        // Analyze a document (EnableSegment=false means entire document is one category)
        AnalyzeResultOperation analyzeOperation = await client.AnalyzeBinaryAsync(
            WaitUntil.Completed,
            analyzerId,
            "application/pdf",
            BinaryData.FromBytes(fileBytes));
        var analyzeResult = analyzeOperation.Value;
        // Display classification results
        if (analyzeResult.Contents?.FirstOrDefault() is DocumentContent docContent)
        {
            Console.WriteLine($"Pages: {docContent.StartPageNumber}-{docContent.EndPageNumber}");
            // With EnableSegment=false, the document is classified as a single unit
            if (docContent.Segments != null && docContent.Segments.Count > 0)
            {
                foreach (var segment in docContent.Segments)
                {
                    Console.WriteLine($"Category: {segment.Category ?? "(unknown)"}");
                    Console.WriteLine($"Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
                }
            }
        }

        // Analyze a document (EnableSegment=true automatically segments by category)
        AnalyzeResultOperation analyzeOperation2 = await client.AnalyzeBinaryAsync(
            WaitUntil.Completed,
            analyzerId,
            "application/pdf",
            BinaryData.FromBytes(fileBytes));
        var analyzeResult2 = analyzeOperation2.Value;
        // Display classification results with automatic segmentation
        if (analyzeResult2.Contents?.FirstOrDefault() is DocumentContent docContent2)
        {
            if (docContent2.Segments != null && docContent2.Segments.Count > 0)
            {
                Console.WriteLine($"Found {docContent2.Segments.Count} segment(s):");
                foreach (var segment in docContent2.Segments)
                {
                    Console.WriteLine($"  Category: {segment.Category ?? "(unknown)"}");
                    Console.WriteLine($"  Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
                    Console.WriteLine($"  Segment ID: {segment.SegmentId ?? "(not available)"}");
                }
            }
        }

        // Clean up: delete the classifier (for testing purposes only)
        // In production, classifiers are typically kept and reused
        await client.DeleteAnalyzerAsync(analyzerId);
        Console.WriteLine($"Classifier '{analyzerId}' deleted successfully.");
        // === END SNIPPET ===
    }
}
