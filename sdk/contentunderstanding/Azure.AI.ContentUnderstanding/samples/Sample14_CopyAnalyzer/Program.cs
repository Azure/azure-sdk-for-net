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
/// This sample demonstrates how to copy an analyzer from source to target within the same resource.
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
        // Generate unique analyzer IDs
        string sourceAnalyzerId = $"my_analyzer_source_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        string targetAnalyzerId = $"my_analyzer_target_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";

        // Step 1: Create the source analyzer
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
                }
            })
        {
            Name = "company_schema",
            Description = "Schema for extracting company information"
        };

        var sourceAnalyzer = new ContentAnalyzer
        {
            BaseAnalyzerId = "prebuilt-document",
            Description = "Source analyzer for copying",
            Config = sourceConfig,
            FieldSchema = sourceFieldSchema
        };
        sourceAnalyzer.Models.Add("completion", "gpt-4.1");
        sourceAnalyzer.Tags.Add("modelType", "in_development");

        var createOperation = await client.CreateAnalyzerAsync(
            WaitUntil.Completed,
            sourceAnalyzerId,
            sourceAnalyzer);
        var sourceResult = createOperation.Value;
        Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' created successfully!");

        // Get the source analyzer to see its description and tags before copying
        var sourceResponse = await client.GetAnalyzerAsync(sourceAnalyzerId);
        ContentAnalyzer sourceAnalyzerInfo = sourceResponse.Value;
        Console.WriteLine($"Source analyzer description: {sourceAnalyzerInfo.Description}");
        Console.WriteLine($"Source analyzer tags: {string.Join(", ", sourceAnalyzerInfo.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");

        try
        {
            // Step 2: Copy the source analyzer to target
            // Note: This copies within the same resource. For cross-resource copying, use GrantCopyAuth sample.
            await client.CopyAnalyzerAsync(
                WaitUntil.Completed,
                targetAnalyzerId,
                sourceAnalyzerId);

            // Get the target analyzer first to get its BaseAnalyzerId
            var targetResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
            ContentAnalyzer targetAnalyzer = targetResponse.Value;

            // Update the target analyzer with a production tag
            var updatedAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = targetAnalyzer.BaseAnalyzerId
            };
            updatedAnalyzer.Tags["modelType"] = "model_in_production";

            await client.UpdateAnalyzerAsync(targetAnalyzerId, updatedAnalyzer);

            // Get the target analyzer again to verify the update
            var updatedResponse = await client.GetAnalyzerAsync(targetAnalyzerId);
            ContentAnalyzer updatedTargetAnalyzer = updatedResponse.Value;
            Console.WriteLine($"Updated target analyzer description: {updatedTargetAnalyzer.Description}");
            Console.WriteLine($"Updated target analyzer tag: {updatedTargetAnalyzer.Tags["modelType"]}");
        }
        finally
        {
            // Clean up: delete both analyzers
            try
            {
                await client.DeleteAnalyzerAsync(sourceAnalyzerId);
                Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
            }
            catch
            {
                // Ignore cleanup errors
            }

            try
            {
                await client.DeleteAnalyzerAsync(targetAnalyzerId);
                Console.WriteLine($"Target analyzer '{targetAnalyzerId}' deleted successfully.");
            }
            catch
            {
                // Ignore cleanup errors
            }
        }
        // === END SNIPPET ===
    }
}
