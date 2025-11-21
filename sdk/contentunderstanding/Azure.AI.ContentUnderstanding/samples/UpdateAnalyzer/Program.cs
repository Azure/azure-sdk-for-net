// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

/// <summary>
/// This sample demonstrates how to update a custom analyzer using the Update API.
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
/// 1. Create an initial analyzer
/// 2. Get the analyzer to verify initial state
/// 3. Update the analyzer with new description and tags
/// 4. Get the analyzer again to verify changes persisted
/// 5. Clean up the created analyzer
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Update Analyzer");
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

            // Step 3: Create initial analyzer
            Console.WriteLine("Step 3: Creating initial analyzer...");

            // Generate a unique analyzer ID using timestamp
            string analyzerId = $"sdk_sample_analyzer_for_update_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            Console.WriteLine($"  Analyzer ID: {analyzerId}");

            var initialAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Initial description",
                Config = new ContentAnalyzerConfig
                {
                    EnableFormula = true,
                    EnableLayout = true,
                    EnableOcr = true,
                    EstimateFieldSourceAndConfidence = true,
                    ReturnDetails = true
                },
                FieldSchema = new ContentFieldSchema(
                    new Dictionary<string, ContentFieldDefinition>
                    {
                        ["total_amount"] = new ContentFieldDefinition
                        {
                            Description = "Total amount of this document",
                            Method = GenerationMethod.Extract,
                            Type = ContentFieldType.Number
                        },
                        ["company_name"] = new ContentFieldDefinition
                        {
                            Description = "Name of the company",
                            Method = GenerationMethod.Extract,
                            Type = ContentFieldType.String
                        }
                    })
                {
                    Description = "Schema for update demo",
                    Name = "update_demo_schema"
                }
            };

            // Add required model mappings
            initialAnalyzer.Models["completion"] = "gpt-4.1";
            initialAnalyzer.Models["embedding"] = "text-embedding-3-large";

            // Add initial tags
            initialAnalyzer.Tags["tag1"] = "tag1_initial_value";
            initialAnalyzer.Tags["tag2"] = "tag2_initial_value";

            try
            {
                Console.WriteLine("  Creating analyzer (this may take a few moments)...");
                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    initialAnalyzer,
                    allowReplace: true);

                var createdAnalyzer = createOperation.Value;
                Console.WriteLine($"  Analyzer '{analyzerId}' created successfully!");
                Console.WriteLine($"  Status: {createdAnalyzer.Status}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to create analyzer: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 4: Get the analyzer before update
            Console.WriteLine("Step 4: Getting analyzer before update...");
            ContentAnalyzer analyzerBeforeUpdate;
            try
            {
                analyzerBeforeUpdate = await client.GetAnalyzerAsync(analyzerId);
                Console.WriteLine("  Initial analyzer state:");
                Console.WriteLine($"    Description: {analyzerBeforeUpdate.Description}");
                Console.WriteLine($"    Tags: {string.Join(", ", analyzerBeforeUpdate.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to get analyzer: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 5: Update the analyzer
            Console.WriteLine("Step 5: Updating analyzer with new description and tags...");

            Console.WriteLine("  Changes to apply:");
            Console.WriteLine($"    New Description: Updated description");
            Console.WriteLine($"    Tag Updates: tag1 (updated), tag2 (removed), tag3 (added)");
            Console.WriteLine();

            try
            {
                // Create a ContentAnalyzer object with the fields to update
                // Note: The service currently requires baseAnalyzerId and models even in PATCH requests
                var updatedAnalyzer = new ContentAnalyzer
                {
                    BaseAnalyzerId = analyzerBeforeUpdate.BaseAnalyzerId,
                    Description = "Updated description"
                };

                // Update tags
                updatedAnalyzer.Tags["tag1"] = "tag1_updated_value";
                updatedAnalyzer.Tags["tag2"] = "";  // Empty string to remove tag
                updatedAnalyzer.Tags["tag3"] = "tag3_value";

                // Update models (required by service)
                // updatedAnalyzer.Models["completion"] = "gpt-4.1";
                // updatedAnalyzer.Models["embedding"] = "text-embedding-3-large";

                // Use the convenience method that accepts ContentAnalyzer directly
                await client.UpdateAnalyzerAsync(
                    analyzerId,
                    updatedAnalyzer);

                Console.WriteLine("  Analyzer updated successfully!");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to update analyzer: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 6: Get the analyzer after update to verify changes persisted
            Console.WriteLine("Step 6: Getting analyzer after update to verify changes...");
            try
            {
                var analyzerAfterUpdate = await client.GetAnalyzerAsync(analyzerId);
                Console.WriteLine("  Updated analyzer state:");
                Console.WriteLine($"    Description: {analyzerAfterUpdate.Value.Description}");
                Console.WriteLine($"    Tags: {string.Join(", ", analyzerAfterUpdate.Value.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to get analyzer after update: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 7: Clean up (delete the created analyzer)
            Console.WriteLine("Step 7: Cleaning up (deleting analyzer)...");
            try
            {
                await client.DeleteAnalyzerAsync(analyzerId);
                Console.WriteLine($"  Analyzer '{analyzerId}' deleted successfully!");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to delete analyzer: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                // Don't throw - cleanup failure shouldn't fail the sample
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine("Sample completed successfully");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
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

