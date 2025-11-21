// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to create a custom analyzer using the CreateAnalyzer API.
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
///
/// This sample demonstrates:
/// 1. Authenticate with Azure AI Content Understanding
/// 2. Create a custom analyzer with field schema using object model
/// 3. Wait for analyzer creation to complete
/// 4. Clean up by deleting the created analyzer
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Create Custom Analyzer");
        Console.WriteLine("=============================================================");
        Console.WriteLine();

        try
        {
            // Step 1: Load configuration from multiple sources
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

            // Trim and validate endpoint
            endpoint = endpoint.Trim();
            if (!Uri.TryCreate(endpoint, UriKind.Absolute, out var endpointUri))
            {
                Console.Error.WriteLine($"Error: Invalid endpoint URL: {endpoint}");
                Console.Error.WriteLine("Endpoint must be a valid absolute URI (e.g., https://your-resource.cognitiveservices.azure.com/)");
                Environment.Exit(1);
            }

            Console.WriteLine($"  Endpoint: {endpoint}");
            Console.WriteLine();

            // Step 2: Create the client with appropriate authentication
            Console.WriteLine("Step 2: Creating Content Understanding client...");
            var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            ContentUnderstandingClient client;

            if (!string.IsNullOrEmpty(apiKey))
            {
                // Use API key authentication
                Console.WriteLine("  Authentication: API Key");
                client = new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey));
            }
            else
            {
                // Use DefaultAzureCredential
                Console.WriteLine("  Authentication: DefaultAzureCredential");
                client = new ContentUnderstandingClient(endpointUri, new DefaultAzureCredential());
            }
            Console.WriteLine();

            // Step 3: Define the custom analyzer
            Console.WriteLine("Step 3: Defining custom analyzer...");

            // Generate a unique analyzer ID using timestamp
            // Note: Analyzer IDs cannot contain hyphens
            string analyzerId = $"sdk_sample_custom_analyzer_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            Console.WriteLine($"  Analyzer ID: {analyzerId}");

            // Create field schema with custom fields
            var fieldSchema = new ContentFieldSchema(
                new Dictionary<string, ContentFieldDefinition>
                {
                    ["company_name"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Extract,
                        Description = "Name of the company"
                    },
                    ["total_amount"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.Number,
                        Method = GenerationMethod.Extract,
                        Description = "Total amount on the document"
                    }
                })
            {
                Name = "company_schema",
                Description = "Schema for extracting company information"
            };

            // Create analyzer configuration
            var config = new ContentAnalyzerConfig
            {
                EnableFormula = true,
                EnableLayout = true,
                EnableOcr = true,
                EstimateFieldSourceAndConfidence = true,
                ReturnDetails = true
            };

            // Create the custom analyzer object
            // Note: Use "prebuilt-document" as the base analyzer for custom document analyzers
            // (not "prebuilt-documentAnalyzer" which is a different prebuilt)
            var customAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Custom analyzer for extracting company information",
                Config = config,
                FieldSchema = fieldSchema
            };

            // Add model mappings for completion and embedding models (required for custom analyzers)
            // Use Add method to safely add keys to the dictionary
            customAnalyzer.Models.Add("completion", "gpt-4.1");
            customAnalyzer.Models.Add("embedding", "text-embedding-3-large");

            Console.WriteLine("  Analyzer configuration:");
            Console.WriteLine($"    Base Analyzer: {customAnalyzer.BaseAnalyzerId}");
            Console.WriteLine($"    Description: {customAnalyzer.Description}");
            Console.WriteLine($"    Fields: {fieldSchema.Fields.Count}");
            Console.WriteLine($"    Models: {customAnalyzer.Models.Count}");
            Console.WriteLine();

            // Step 4: Create the analyzer
            Console.WriteLine("Step 4: Creating custom analyzer...");
            Console.WriteLine("  This may take a few moments...");

            ContentAnalyzer? result = null;
            bool created = false;
            try
            {
                var operation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    customAnalyzer,
                    allowReplace: true);

                result = operation.Value;
                created = true;
                Console.WriteLine($"  ✅ Analyzer '{analyzerId}' created successfully!");
                Console.WriteLine($"  Status: {result.Status}");
                Console.WriteLine($"  Created at: {result.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to create analyzer: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 5: Use the analyzer to analyze an invoice
            if (created && result != null)
            {
                Console.WriteLine("Step 5: Using the custom analyzer to analyze an invoice...");
                var fileUrl = "https://github.com/Azure-Samples/azure-ai-content-understanding-python/raw/refs/heads/main/data/invoice.pdf";
                Console.WriteLine($"  URL: {fileUrl}");
                Console.WriteLine($"  Analyzing...");

                try
                {
                    var analyzeOperation = await client.AnalyzeAsync(
                        WaitUntil.Completed,
                        analyzerId,
                        inputs: new[] { new AnalyzeInput { Url = new Uri(fileUrl) } });

                    var analyzeResult = analyzeOperation.Value;
                    Console.WriteLine("  ✅ Analysis completed successfully!");
                    Console.WriteLine();

                    // Display extracted custom fields
                    if (analyzeResult.Contents != null && analyzeResult.Contents.Count > 0)
                    {
                        var content = analyzeResult.Contents.First();
                        if (content.Fields != null && content.Fields.Count > 0)
                        {
                            Console.WriteLine("  📋 Extracted Custom Fields:");
                            Console.WriteLine("  " + "-".PadRight(38, '-'));

                            // Extract the custom fields we defined
                            if (content.Fields.TryGetValue("company_name", out var companyNameField))
                            {
                                var companyName = companyNameField is StringField sf ? sf.ValueString : null;
                                Console.WriteLine($"    Company Name: {companyName ?? "(not found)"}");
                            }

                            if (content.Fields.TryGetValue("total_amount", out var totalAmountField))
                            {
                                var totalAmount = totalAmountField is NumberField nf ? nf.ValueNumber : null;
                                Console.WriteLine($"    Total Amount: {totalAmount?.ToString("F2") ?? "(not found)"}");
                            }

                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("  No fields extracted");
                            Console.WriteLine();
                        }
                    }
                }
                catch (RequestFailedException ex)
                {
                    Console.Error.WriteLine($"  Failed to analyze with custom analyzer: {ex.Message}");
                    Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                    // Continue to cleanup even if analysis fails
                }
            }

            // Step 6: Clean up (delete the created analyzer)
            if (created && result != null)
            {
                Console.WriteLine("Step 6: Cleaning up (deleting analyzer)...");
                try
                {
                    await client.DeleteAnalyzerAsync(analyzerId);
                    Console.WriteLine($"  ✅ Analyzer '{analyzerId}' deleted successfully!");
                    Console.WriteLine();
                }
                catch (RequestFailedException ex)
                {
                    Console.Error.WriteLine($"  Failed to delete analyzer: {ex.Message}");
                    Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                    // Don't throw - cleanup failure shouldn't fail the sample
                }
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine("✓ Sample completed successfully");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("This sample demonstrated:");
            Console.WriteLine("  1. Creating a custom analyzer with field schema");
            Console.WriteLine("  2. Using the custom analyzer to extract structured fields");
            Console.WriteLine("  3. Cleaning up by deleting the analyzer");
            Console.WriteLine();
            Console.WriteLine("Next steps:");
            Console.WriteLine("  - To retrieve analyzers: see ListAnalyzers sample");
            Console.WriteLine("  - To analyze with prebuilt analyzers: see AnalyzeBinary or AnalyzeUrl samples");
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
            if (ex.InnerException != null)
            {
                Console.Error.WriteLine($"  Inner Exception: {ex.InnerException.Message}");
                Console.Error.WriteLine($"  Inner Type: {ex.InnerException.GetType().Name}");
            }
            Console.Error.WriteLine($"  Stack Trace: {ex.StackTrace}");
            Environment.Exit(1);
        }
    }
}

