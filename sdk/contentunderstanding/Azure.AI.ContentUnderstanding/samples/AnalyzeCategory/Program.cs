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
/// This sample demonstrates how to create a classifier to categorize financial documents without automatic page segmentation.
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
        Console.WriteLine("Azure Content Understanding Sample: Analyze Category");
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
            var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            Console.WriteLine($"  API Key: {(string.IsNullOrEmpty(apiKey) ? "(not set, using DefaultAzureCredential)" : "***")}");
            Console.WriteLine();

            // Step 2: Create the client
            Console.WriteLine("Step 2: Creating Content Understanding client...");
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

            // Step 3: Create analyzer
            var analyzerId = $"financial_doc_classifier_{Guid.NewGuid():N}";
            Console.WriteLine($"Step 3: Creating analyzer '{analyzerId}'...");
            Console.WriteLine("  Categories: Invoice, Bank Statement, Loan Application");
            Console.WriteLine("  Note: EnableSegment=false - document will be classified as a single unit");
            Console.WriteLine();

            var config = new ContentAnalyzerConfig
            {
                ReturnDetails = true
            };
            config.EnableSegment = false; // Disable automatic segmentation - entire document is classified as one unit
            config.ContentCategories.Add("Loan application", new ContentCategoryDefinition
            {
                Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation."
            });
            config.ContentCategories.Add("Invoice", new ContentCategoryDefinition
            {
                Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
            });
            config.ContentCategories.Add("Bank Statement", new ContentCategoryDefinition
            {
                Description = "Official statements issued by banks that summarize account activity over a period, including deposits, withdrawals, fees, and balances."
            });

            var analyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = $"Custom analyzer for financial document categorization without segmentation",
                Config = config
            };
            analyzer.Models.Add("completion", "gpt-4.1");
            analyzer.Tags.Add("demo_type", "category_classification_without_segmentation");

            try
            {
                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    analyzer);

                var createdAnalyzer = createOperation.Value;
                Console.WriteLine($"  Analyzer '{analyzerId}' created successfully!");
                Console.WriteLine($"  Status: {createdAnalyzer.Status}");

                if (createdAnalyzer.Warnings != null && createdAnalyzer.Warnings.Count > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("⚠️  Warnings encountered while building the analyzer:");
                    foreach (var warning in createdAnalyzer.Warnings)
                    {
                        Console.WriteLine($"  - {warning}");
                    }
                }
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to create analyzer: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 4: Test files to classify
            // Note: With EnableSegment=false, each document will be classified as a single unit.
            // Even mixed_financial_docs.pdf (which contains multiple document types) will be
            // classified as one category covering all pages, not segmented by page content.
            var testFiles = new[]
            {
                "sample_invoice.pdf",
                "sample_bank_statement.pdf",
                "mixed_financial_docs.pdf" // Will be classified as a unit, not segmented
            };

            var samplesDir = AppContext.BaseDirectory;
            var outputDir = Path.Combine(samplesDir, "sample_output");
            Directory.CreateDirectory(outputDir);

            // Step 5: Classify each document
            foreach (var testFile in testFiles)
            {
                var testFilePath = Path.Combine(samplesDir, "sample_files", testFile);

                if (!File.Exists(testFilePath))
                {
                    Console.WriteLine($"⚠️  Skipping {testFile} - file not found");
                    continue;
                }

                Console.WriteLine("=============================================================");
                Console.WriteLine($"Analyzing: {testFile}");
                Console.WriteLine("=============================================================");

                // Read and analyze the document
                var pdfBytes = await File.ReadAllBytesAsync(testFilePath);

                AnalyzeResult analyzeResult;
                try
                {
                    var analyzeOperation = await client.AnalyzeBinaryAsync(
                        WaitUntil.Completed,
                        analyzerId,
                        "application/pdf",
                        BinaryData.FromBytes(pdfBytes));

                    analyzeResult = analyzeOperation.Value;
                    Console.WriteLine("Classification completed!");
                    Console.WriteLine();
                }
                catch (RequestFailedException ex)
                {
                    Console.Error.WriteLine($"  Failed to analyze document: {ex.Message}");
                    Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                    continue;
                }

                // Display classification results
                Console.WriteLine("Classification Results:");
                Console.WriteLine(new string('-', 60));

                foreach (var content in analyzeResult.Contents ?? Enumerable.Empty<MediaContent>())
                {
                    if (content is DocumentContent docContent)
                    {
                        // When EnableSegment=false, the document is classified as a single unit
                        // Display the page range for the entire document
                        Console.WriteLine($"\nPages: {docContent.StartPageNumber}-{docContent.EndPageNumber}");

                        // Note: segments may still exist but won't be automatically created by category
                        if (docContent.Segments != null && docContent.Segments.Count > 0)
                        {
                            Console.WriteLine($"\nFound {docContent.Segments.Count} segment(s):");
                            for (int i = 0; i < docContent.Segments.Count; i++)
                            {
                                var segment = docContent.Segments[i];
                                Console.WriteLine($"  Segment {i + 1}:");
                                Console.WriteLine($"    Category: {segment.Category ?? "(unknown)"}");
                                Console.WriteLine($"    Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
                                Console.WriteLine($"    Segment ID: {segment.SegmentId ?? "(not available)"}");
                            }
                        }
                    }
                }

                Console.WriteLine();

                // Save results to JSON file
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var resultFilename = $"analyze_category_{testFile.Replace(".pdf", "")}_{timestamp}.json";
                var resultFile = Path.Combine(outputDir, resultFilename);

                try
                {
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                    };
                    var jsonString = JsonSerializer.Serialize(analyzeResult, options);
                    await File.WriteAllTextAsync(resultFile, jsonString);
                    Console.WriteLine($"Results saved to: {resultFile}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠️  Failed to save results: {ex.Message}");
                }

                Console.WriteLine();
            }

            // Step 6: Cleanup
            Console.WriteLine("=============================================================");
            Console.WriteLine($"Deleting analyzer '{analyzerId}' (demo cleanup)...");
            try
            {
                await client.DeleteAnalyzerAsync(analyzerId);
                Console.WriteLine($"Analyzer '{analyzerId}' deleted successfully!");
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to delete analyzer: {ex.Message}");
            }
            Console.WriteLine("=============================================================");

            Console.WriteLine();
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
}

