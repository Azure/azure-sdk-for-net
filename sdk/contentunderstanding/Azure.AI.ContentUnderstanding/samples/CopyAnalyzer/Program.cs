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
/// This sample demonstrates how to copy an analyzer from source to target using CopyAnalyzer API.
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
        Console.WriteLine("Azure Content Understanding Sample: Copy Analyzer");
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

            var baseAnalyzerId = $"sdk_sample_custom_analyzer_{Guid.NewGuid():N}";
            var sourceAnalyzerId = $"{baseAnalyzerId}_source";
            var targetAnalyzerId = $"{baseAnalyzerId}_target";

            // Step 3: Create the source analyzer
            Console.WriteLine("Step 3: Creating source analyzer...");
            Console.WriteLine($"  Analyzer ID: {sourceAnalyzerId}");
            Console.WriteLine($"  Tag: 'modelType': 'in_development'");
            Console.WriteLine();

            var sourceConfig = new ContentAnalyzerConfig
            {
                EnableFormula = false,
                EnableLayout = true,
                EnableOcr = true,
                EstimateFieldSourceAndConfidence = true,
                ReturnDetails = true
            };

            var sourceFieldSchema = new ContentFieldSchema(
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
                    },
                    ["document_summary"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Generate,
                        Description = "A concise summary of the document's main content"
                    },
                    ["key_insights"] = new ContentFieldDefinition
                    {
                        Type = ContentFieldType.String,
                        Method = GenerationMethod.Generate,
                        Description = "Key business insights or actionable items from the document"
                    }
                })
            {
                Name = "company_schema",
                Description = "Schema for extracting company information"
            };

            var sourceAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Source analyzer for extracting company information",
                Config = sourceConfig,
                FieldSchema = sourceFieldSchema
            };
            sourceAnalyzer.Models.Add("completion", "gpt-4.1");
            sourceAnalyzer.Tags.Add("modelType", "in_development");

            try
            {
                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    sourceAnalyzerId,
                    sourceAnalyzer);

                var sourceResult = createOperation.Value;
                Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' created successfully!");

                // Retrieve the full analyzer details
                Console.WriteLine($"\nRetrieving source analyzer details using GetAnalyzer...");
                var sourceAnalyzerDetails = await client.GetAnalyzerAsync(sourceAnalyzerId);
                Console.WriteLine($"\n=== Source Analyzer Details ===");
                Console.WriteLine($"Analyzer ID: {sourceAnalyzerDetails.Value.AnalyzerId}");
                Console.WriteLine($"Description: {sourceAnalyzerDetails.Value.Description}");
                Console.WriteLine($"Tags: {string.Join(", ", sourceAnalyzerDetails.Value.Tags?.Keys ?? Array.Empty<string>())}");
                Console.WriteLine($"=== End Source Analyzer Details ===\n");

                // Step 4: Copy the source analyzer to target
                Console.WriteLine("Step 4: Copying analyzer...");
                Console.WriteLine($"  Source: {sourceAnalyzerId}");
                Console.WriteLine($"  Target: {targetAnalyzerId}");
                Console.WriteLine();

                try
                {
                    var copyOperation = await client.CopyAnalyzerAsync(
                        WaitUntil.Completed,
                        targetAnalyzerId,
                        sourceAnalyzerId);

                    var targetResult = copyOperation.Value;
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' copied successfully!");

                    // Retrieve the full analyzer details
                    Console.WriteLine($"\nRetrieving target analyzer details using GetAnalyzer...");
                    var targetAnalyzerDetails = await client.GetAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"\n=== Target Analyzer Details (before update) ===");
                    Console.WriteLine($"Analyzer ID: {targetAnalyzerDetails.Value.AnalyzerId}");
                    Console.WriteLine($"Description: {targetAnalyzerDetails.Value.Description}");
                    Console.WriteLine($"Tags: {string.Join(", ", targetAnalyzerDetails.Value.Tags?.Keys ?? Array.Empty<string>())}");
                    Console.WriteLine($"=== End Target Analyzer Details ===\n");

                    // Step 5: Update the target analyzer to add the "modelType": "in_production" tag
                    Console.WriteLine("Step 5: Updating target analyzer...");
                    Console.WriteLine($"  Analyzer ID: {targetAnalyzerId}");
                    Console.WriteLine($"  Tag: 'modelType': 'in_production'");
                    Console.WriteLine();
                    var updatedTargetAnalyzer = new ContentAnalyzer();
                    updatedTargetAnalyzer.Tags.Add("modelType", "in_production");
                    await client.UpdateAnalyzerAsync(targetAnalyzerId, updatedTargetAnalyzer);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' updated successfully!");

                    // Retrieve the updated analyzer details
                    Console.WriteLine($"\nRetrieving updated target analyzer details...");
                    var finalTargetAnalyzerDetails = await client.GetAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"\n=== Target Analyzer Details (after update) ===");
                    Console.WriteLine($"Analyzer ID: {finalTargetAnalyzerDetails.Value.AnalyzerId}");
                    Console.WriteLine($"Description: {finalTargetAnalyzerDetails.Value.Description}");
                    Console.WriteLine($"Tags: {string.Join(", ", finalTargetAnalyzerDetails.Value.Tags?.Keys ?? Array.Empty<string>())}");
                    Console.WriteLine($"=== End Target Analyzer Details ===\n");

                    // Step 6: Clean up
                    Console.WriteLine("Step 6: Cleaning up...");
                    Console.WriteLine($"  Deleting source analyzer: {sourceAnalyzerId}");
                    await client.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully!");

                    Console.WriteLine($"  Deleting target analyzer: {targetAnalyzerId}");
                    await client.DeleteAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully!");
                }
                catch (RequestFailedException ex)
                {
                    Console.WriteLine($"Error copying analyzer: {ex.Message}");
                    Console.WriteLine($"  Status: {ex.Status}");
                    Console.WriteLine($"  Error Code: {ex.ErrorCode}");
                    
                    if (ex.Status == 404)
                    {
                        Console.WriteLine();
                        Console.WriteLine("⚠️  404 Error - Possible causes:");
                        Console.WriteLine("  1. The copy operation may not be supported on this service endpoint");
                        Console.WriteLine("  2. The source analyzer may not be accessible for copying");
                        Console.WriteLine("  3. Required permissions may be missing (need 'Cognitive Services User' role)");
                        Console.WriteLine("  4. The API version may not support copy operations");
                        Console.WriteLine();
                        Console.WriteLine("  Troubleshooting:");
                        Console.WriteLine("  - Verify the endpoint supports analyzer copy operations");
                        Console.WriteLine("  - Check that you have 'Cognitive Services User' role assigned");
                        Console.WriteLine("  - Try using GrantCopyAuth sample for cross-resource copy scenarios");
                    }
                    else
                    {
                        Console.WriteLine("Note: The copy operation may not be available on all service endpoints.");
                    }
                    
                    // Clean up source analyzer before raising
                    Console.WriteLine($"\nDeleting source analyzer '{sourceAnalyzerId}' (cleanup after error)...");
                    await client.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully!");
                    throw;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Unexpected error copying analyzer: {e.Message}");
                    Console.WriteLine($"  Type: {e.GetType().Name}");
                    // Clean up source analyzer before raising
                    Console.WriteLine($"\nDeleting source analyzer '{sourceAnalyzerId}' (cleanup after error)...");
                    await client.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully!");
                    throw;
                }
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"Failed to create source analyzer: {ex.Message}");
                throw;
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
            Environment.Exit(1);
        }
    }
}

