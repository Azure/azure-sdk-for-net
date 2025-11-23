// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to create a classifier to categorize documents.
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
        Console.WriteLine("Azure Content Understanding Sample: Create Classifier");
        Console.WriteLine("=============================================================");
        Console.WriteLine();

        try
        {
            // Step 1: Load configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var endpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"];
            if (string.IsNullOrEmpty(endpoint))
            {
                Console.Error.WriteLine("Error: AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required.");
                Environment.Exit(1);
            }

            if (!Uri.TryCreate(endpoint.Trim(), UriKind.Absolute, out var endpointUri))
            {
                Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
                Environment.Exit(1);
            }

            // Step 2: Create the client
            var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            ContentUnderstandingClient client = !string.IsNullOrEmpty(apiKey)
                ? new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey))
                : new ContentUnderstandingClient(endpointUri, new DefaultAzureCredential());

            await CreateDocumentClassifier(client);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }

    static async Task CreateDocumentClassifier(ContentUnderstandingClient client)
    {
        var analyzerId = $"sdk_sample_classifier_{Guid.NewGuid():N}";

        Console.WriteLine($"Creating classifier '{analyzerId}'...");
        Console.WriteLine();
        Console.WriteLine("Classifier Configuration:");
        Console.WriteLine(new string('=', 60));

        // Define content categories for classification
        var categories = new Dictionary<string, ContentCategoryDefinition>
        {
            ["Loan_Application"] = new ContentCategoryDefinition
            {
                Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation."
            },
            ["Invoice"] = new ContentCategoryDefinition
            {
                Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
            },
            ["Bank_Statement"] = new ContentCategoryDefinition
            {
                Description = "Official statements issued by banks that summarize account activity over a period, including deposits, withdrawals, fees, and balances."
            }
        };

        Console.WriteLine("   Content Categories:");
        foreach (var kvp in categories)
        {
            Console.WriteLine($"   • {kvp.Key}");
            var desc = kvp.Value.Description;
            if (desc != null && desc.Length > 80)
            {
                Console.WriteLine($"     {desc.Substring(0, 80)}...");
            }
            else if (desc != null)
            {
                Console.WriteLine($"     {desc}");
            }
        }

        Console.WriteLine(new string('=', 60));

        try
        {
            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true,
                EnableSegment = true // Automatically split and classify multi-document files
            };

            foreach (var kvp in categories)
            {
                config.ContentCategories.Add(kvp.Key, kvp.Value);
            }

            var classifier = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Custom classifier for financial document categorization",
                Config = config
            };
            classifier.Models.Add("completion", "gpt-4.1");
            classifier.Tags.Add("sample_type", "classifier_demo");
            classifier.Tags.Add("document_type", "financial");

            Console.WriteLine($"\nStarting classifier creation operation...");
            var createOperation = await client.CreateAnalyzerAsync(
                WaitUntil.Completed,
                analyzerId,
                classifier);

            var result = createOperation.Value;
            Console.WriteLine($"\nClassifier '{analyzerId}' created successfully!");

            if (result.Warnings != null && result.Warnings.Count > 0)
            {
                Console.WriteLine("\n⚠️  Warnings encountered while creating the classifier:");
                foreach (var warning in result.Warnings)
                {
                    Console.WriteLine($"   - {warning.Message}");
                }
            }

            // Retrieve the full analyzer details
            Console.WriteLine($"\nRetrieving classifier details...");
            var analyzerDetails = await client.GetAnalyzerAsync(analyzerId);

            Console.WriteLine("\nClassifier Properties:");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine($"   Analyzer ID: {analyzerDetails.Value.AnalyzerId}");
            Console.WriteLine($"   Description: {analyzerDetails.Value.Description}");
            Console.WriteLine($"   Base Analyzer: {analyzerDetails.Value.BaseAnalyzerId}");
            Console.WriteLine($"   Status: {analyzerDetails.Value.Status}");

            if (analyzerDetails.Value.Config != null)
            {
                if (analyzerDetails.Value.Config.EnableSegment.HasValue)
                {
                    Console.WriteLine($"   Enable Segment: {analyzerDetails.Value.Config.EnableSegment.Value}");
                }
                if (analyzerDetails.Value.Config.ContentCategories != null && analyzerDetails.Value.Config.ContentCategories.Count > 0)
                {
                    Console.WriteLine($"   Categories: {analyzerDetails.Value.Config.ContentCategories.Count}");
                    foreach (var catName in analyzerDetails.Value.Config.ContentCategories.Keys)
                    {
                        Console.WriteLine($"     • {catName}");
                    }
                }
            }

            if (analyzerDetails.Value.Models != null && analyzerDetails.Value.Models.Count > 0)
            {
                Console.WriteLine($"   Models: {string.Join(", ", analyzerDetails.Value.Models.Values)}");
            }

            if (analyzerDetails.Value.Tags != null && analyzerDetails.Value.Tags.Count > 0)
            {
                Console.WriteLine($"   Tags: {string.Join(", ", analyzerDetails.Value.Tags.Keys)}");
            }

            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\nUsage Tips:");
            Console.WriteLine("   • Use this classifier with AnalyzeAsync() or AnalyzeBinaryAsync()");
            Console.WriteLine("   • Set EnableSegment=true to classify different document types in a single file");
            Console.WriteLine("   • Each segment in the result will have a 'category' field with the classification");
            Console.WriteLine("   • You can add up to 200 content categories per classifier");

            // Clean up
            Console.WriteLine($"\nCleaning up: Deleting classifier '{analyzerId}'...");
            await client.DeleteAnalyzerAsync(analyzerId);
            Console.WriteLine($"Classifier '{analyzerId}' deleted successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n❌ Error creating classifier: {e.Message}");
            Console.WriteLine("\nThis error may occur if:");
            Console.WriteLine("   - The GPT-4.1 model deployment is not configured (run GetDefaults sample)");
            Console.WriteLine("   - You don't have permission to create analyzers");
            Console.WriteLine("   - The analyzer ID already exists (try running the sample again)");
            throw;
        }
    }
}

