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
/// This sample demonstrates how to grant copy authorization and copy an analyzer from source to target.
///
/// Prerequisites:
///     - Azure subscription
///     - Azure Content Understanding resource (source and target)
///     - .NET 8.0 SDK or later
///
/// Setup:
///     Set the following environment variables or add them to appsettings.json:
///     - AZURE_CONTENT_UNDERSTANDING_ENDPOINT (required) - Source endpoint
///     - AZURE_CONTENT_UNDERSTANDING_KEY (optional - DefaultAzureCredential will be used if not set)
///     - AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID (required) - Full Azure Resource Manager resource ID of source
///     - AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION (required) - Azure region of source resource
///     - AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT (required) - Target endpoint for cross-subscription copy
///     - AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID (required) - Full Azure Resource Manager resource ID of target
///     - AZURE_CONTENT_UNDERSTANDING_TARGET_REGION (required) - Azure region of target resource
///     - AZURE_CONTENT_UNDERSTANDING_TARGET_KEY (optional) - Target API key if different from source
///
/// To run:
///     dotnet run
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Grant Copy Authorization");
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

            // Step 2: Create the source client with appropriate authentication
            Console.WriteLine("Step 2: Creating Content Understanding client...");
            var apiKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
            ContentUnderstandingClient sourceClient;

            if (!string.IsNullOrEmpty(apiKey))
            {
                // Use API key authentication
                Console.WriteLine("  Authentication: API Key");
                sourceClient = new ContentUnderstandingClient(endpointUri, new AzureKeyCredential(apiKey));
            }
            else
            {
                // Use DefaultAzureCredential
                Console.WriteLine("  Authentication: DefaultAzureCredential");
                sourceClient = new ContentUnderstandingClient(endpointUri, new DefaultAzureCredential());
            }
            Console.WriteLine();

            var baseAnalyzerId = $"sdk_sample_custom_analyzer_{Guid.NewGuid():N}";
            var sourceAnalyzerId = $"{baseAnalyzerId}_source";
            var targetAnalyzerId = $"{baseAnalyzerId}_target";

            // Step 3: Create the source analyzer
            Console.WriteLine("Step 3: Creating source analyzer...");
            Console.WriteLine($"  Analyzer ID: {sourceAnalyzerId}");
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

            try
            {
                var createOperation = await sourceClient.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    sourceAnalyzerId,
                    sourceAnalyzer);

                var sourceResult = createOperation.Value;
                Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' created successfully!");

                // Step 4: Grant copy authorization
                Console.WriteLine("Step 4: Granting copy authorization...");
                var sourceResourceId = configuration["AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID"];
                var sourceRegion = configuration["AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION"];
                var targetResourceId = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID"];
                var targetRegion = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_REGION"];

                if (string.IsNullOrEmpty(sourceResourceId) || string.IsNullOrEmpty(sourceRegion) ||
                    string.IsNullOrEmpty(targetResourceId) || string.IsNullOrEmpty(targetRegion))
                {
                    Console.Error.WriteLine();
                    Console.Error.WriteLine("Error: Source and target resource IDs and regions are required for cross-subscription copy.");
                    Console.Error.WriteLine();
                    Console.Error.WriteLine("Required environment variables:");
                    Console.Error.WriteLine("  - AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID (required)");
                    Console.Error.WriteLine("    Example: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.CognitiveServices/accounts/{name}");
                    Console.Error.WriteLine("  - AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION (required)");
                    Console.Error.WriteLine("    Example: eastus");
                    Console.Error.WriteLine("  - AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT (required)");
                    Console.Error.WriteLine("    Example: https://target-resource.cognitiveservices.azure.com/");
                    Console.Error.WriteLine("  - AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID (required)");
                    Console.Error.WriteLine("  - AZURE_CONTENT_UNDERSTANDING_TARGET_REGION (required)");
                    Console.Error.WriteLine("  - AZURE_CONTENT_UNDERSTANDING_TARGET_KEY (optional) - Target API key if different from source");
                    Console.Error.WriteLine();
                    Console.Error.WriteLine("Note: Both source and target AI Foundry Resources require 'Cognitive Services User' role");
                    Console.Error.WriteLine("      for cross-subscription copy.");
                    Console.Error.WriteLine();
                    Console.Error.WriteLine("For same-resource copy, use the CopyAnalyzer sample instead.");
                    await sourceClient.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Environment.Exit(1);
                }

                Console.WriteLine($"  Source Resource ID: {sourceResourceId}");
                Console.WriteLine($"  Source Region: {sourceRegion}");
                Console.WriteLine($"  Target Resource ID: {targetResourceId}");
                Console.WriteLine($"  Target Region: {targetRegion}");
                Console.WriteLine();
                var copyAuth = await sourceClient.GrantCopyAuthorizationAsync(
                    sourceAnalyzerId,
                    targetResourceId,
                    targetRegion);

                Console.WriteLine("Copy authorization granted successfully!");
                Console.WriteLine();
                Console.WriteLine("Authorization details:");
                Console.WriteLine($"  Source: {copyAuth.Value.Source ?? "(not available)"}");
                Console.WriteLine($"  Target Azure Resource ID: {copyAuth.Value.TargetAzureResourceId}");
                Console.WriteLine($"  Target Region: {targetRegion}");
                Console.WriteLine($"  Expires at: {copyAuth.Value.ExpiresAt}");
                Console.WriteLine();

                // Step 5: Create target client for cross-subscription copy
                Console.WriteLine("Step 5: Creating target client for cross-subscription copy...");
                var targetEndpoint = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT"];
                if (string.IsNullOrEmpty(targetEndpoint))
                {
                    Console.Error.WriteLine("Error: AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT is required.");
                    Console.Error.WriteLine("Please set it in environment variables or appsettings.json");
                    await sourceClient.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Environment.Exit(1);
                }

                if (!Uri.TryCreate(targetEndpoint.Trim(), UriKind.Absolute, out var targetEndpointUri))
                {
                    Console.Error.WriteLine($"Error: Invalid target endpoint URL: {targetEndpoint}");
                    Console.Error.WriteLine("Endpoint must be a valid absolute URI (e.g., https://your-resource.cognitiveservices.azure.com/)");
                    await sourceClient.DeleteAnalyzerAsync(sourceAnalyzerId);
                    Environment.Exit(1);
                }

                Console.WriteLine($"  Target Endpoint: {targetEndpoint}");
                Console.WriteLine($"  Target Region: {targetRegion}");
                Console.WriteLine();

                var targetKey = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_KEY"];
                ContentUnderstandingClient targetClient = !string.IsNullOrEmpty(targetKey)
                    ? new ContentUnderstandingClient(targetEndpointUri, new AzureKeyCredential(targetKey))
                    : new ContentUnderstandingClient(targetEndpointUri, new DefaultAzureCredential());

                // Step 6: Copy the source analyzer to target
                Console.WriteLine("Step 6: Copying analyzer to target subscription...");
                Console.WriteLine($"  Source Analyzer ID: {sourceAnalyzerId}");
                Console.WriteLine($"  Target Analyzer ID: {targetAnalyzerId}");
                Console.WriteLine($"  Source Resource ID: {sourceResourceId}");
                Console.WriteLine($"  Source Region: {sourceRegion}");
                Console.WriteLine($"  Target Region: {targetRegion}");
                Console.WriteLine();

                try
                {
                    var copyOperation = await targetClient.CopyAnalyzerAsync(
                        WaitUntil.Completed,
                        targetAnalyzerId,
                        sourceAnalyzerId,
                        sourceResourceId,
                        sourceRegion);

                    var targetResult = copyOperation.Value;
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' copied successfully to target subscription!");

                    // Step 7: Get the target analyzer
                    Console.WriteLine("Step 7: Retrieving target analyzer...");
                    Console.WriteLine($"  Analyzer ID: {targetAnalyzerId}");
                    Console.WriteLine();
                    var retrievedAnalyzer = await targetClient.GetAnalyzerAsync(targetAnalyzerId);

                    Console.WriteLine($"\n=== Target Analyzer Details ===");
                    Console.WriteLine($"Analyzer ID: {retrievedAnalyzer.Value.AnalyzerId}");
                    Console.WriteLine($"Description: {retrievedAnalyzer.Value.Description}");
                    Console.WriteLine($"Status: {retrievedAnalyzer.Value.Status}");
                    Console.WriteLine($"Created at: {retrievedAnalyzer.Value.CreatedAt}");
                    Console.WriteLine($"Last modified: {retrievedAnalyzer.Value.LastModifiedAt}");
                    if (retrievedAnalyzer.Value.Tags != null && retrievedAnalyzer.Value.Tags.Count > 0)
                    {
                        Console.WriteLine($"Tags: {string.Join(", ", retrievedAnalyzer.Value.Tags.Keys)}");
                    }
                    if (retrievedAnalyzer.Value.BaseAnalyzerId != null)
                    {
                        Console.WriteLine($"Base analyzer ID: {retrievedAnalyzer.Value.BaseAnalyzerId}");
                    }
                    if (retrievedAnalyzer.Value.FieldSchema != null)
                    {
                        Console.WriteLine($"Field schema name: {retrievedAnalyzer.Value.FieldSchema.Name}");
                        Console.WriteLine($"Field schema description: {retrievedAnalyzer.Value.FieldSchema.Description}");
                        if (retrievedAnalyzer.Value.FieldSchema.Fields != null)
                        {
                            Console.WriteLine($"Number of fields: {retrievedAnalyzer.Value.FieldSchema.Fields.Count}");
                            foreach (var kvp in retrievedAnalyzer.Value.FieldSchema.Fields)
                            {
                                Console.WriteLine($"  - {kvp.Key}: {kvp.Value.Type} ({kvp.Value.Method})");
                            }
                        }
                    }
                    if (retrievedAnalyzer.Value.Models != null && retrievedAnalyzer.Value.Models.Count > 0)
                    {
                        Console.WriteLine($"Models: {string.Join(", ", retrievedAnalyzer.Value.Models.Values)}");
                    }
                    Console.WriteLine($"=== End Target Analyzer Details ===\n");

                    // Step 8: Update the target analyzer tags
                    Console.WriteLine("Step 8: Updating target analyzer tags...");
                    Console.WriteLine($"  Analyzer ID: {targetAnalyzerId}");
                    Console.WriteLine();
                    var updatedTargetAnalyzer = new ContentAnalyzer();
                    updatedTargetAnalyzer.Tags.Add("copiedFrom", sourceAnalyzerId);
                    await targetClient.UpdateAnalyzerAsync(targetAnalyzerId, updatedTargetAnalyzer);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' updated successfully!");

                    // Step 9: Clean up the target analyzer
                    Console.WriteLine("Step 9: Cleaning up target analyzer...");
                    Console.WriteLine($"  Deleting analyzer: {targetAnalyzerId}");
                    await targetClient.DeleteAnalyzerAsync(targetAnalyzerId);
                    Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully from target subscription!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error copying analyzer: {e.Message}");
                    Console.WriteLine("Note: The copy operation may not be available on all service endpoints or may require additional permissions.");
                    throw;
                }

                // Step 10: Clean up the source analyzer
                Console.WriteLine();
                Console.WriteLine("Step 10: Cleaning up source analyzer...");
                Console.WriteLine($"  Deleting analyzer: {sourceAnalyzerId}");
                await sourceClient.DeleteAnalyzerAsync(sourceAnalyzerId);
                Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully!");
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

