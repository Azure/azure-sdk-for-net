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
/// This sample demonstrates how to grant copy authorization and copy an analyzer from a source resource to a target resource.
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
        // Get source endpoint from configuration
        // Note: configuration is already loaded in Main method
        string sourceEndpoint = configuration["AZURE_CONTENT_UNDERSTANDING_ENDPOINT"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_ENDPOINT is required");
        string? sourceKey = configuration["AZURE_CONTENT_UNDERSTANDING_KEY"];
        // Create source client
        var sourceClientOptions = new ContentUnderstandingClientOptions();
        ContentUnderstandingClient sourceClient = !string.IsNullOrEmpty(sourceKey)
            ? new ContentUnderstandingClient(new Uri(sourceEndpoint), new AzureKeyCredential(sourceKey), sourceClientOptions)
            : new ContentUnderstandingClient(new Uri(sourceEndpoint), new DefaultAzureCredential(), sourceClientOptions);
        // Generate unique analyzer IDs
        string sourceAnalyzerId = $"my_analyzer_source_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        string targetAnalyzerId = $"my_analyzer_target_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
        // Get source and target resource information from configuration
        string sourceResourceId = configuration["AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_SOURCE_RESOURCE_ID is required");
        string sourceRegion = configuration["AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_SOURCE_REGION is required");
        string targetEndpoint = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_ENDPOINT is required");
        string targetResourceId = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_RESOURCE_ID is required");
        string targetRegion = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_REGION"] ?? throw new InvalidOperationException("AZURE_CONTENT_UNDERSTANDING_TARGET_REGION is required");
        string? targetKey = configuration["AZURE_CONTENT_UNDERSTANDING_TARGET_KEY"];
        // Create target client
        var targetClientOptions = new ContentUnderstandingClientOptions();
        ContentUnderstandingClient targetClient = !string.IsNullOrEmpty(targetKey)
            ? new ContentUnderstandingClient(new Uri(targetEndpoint), new AzureKeyCredential(targetKey), targetClientOptions)
            : new ContentUnderstandingClient(new Uri(targetEndpoint), new DefaultAzureCredential(), targetClientOptions);
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
            Description = "Source analyzer for cross-resource copying",
            Config = sourceConfig,
            FieldSchema = sourceFieldSchema
        };
        sourceAnalyzer.Models.Add("completion", "gpt-4.1");
        var createOperation = await sourceClient.CreateAnalyzerAsync(
            WaitUntil.Completed,
            sourceAnalyzerId,
            sourceAnalyzer);
        var sourceResult = createOperation.Value;
        Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' created successfully!");
        try
        {
            // Step 2: Grant copy authorization
            var copyAuth = await sourceClient.GrantCopyAuthorizationAsync(
                sourceAnalyzerId,
                targetResourceId,
                targetRegion);
            Console.WriteLine("Copy authorization granted successfully!");
            Console.WriteLine($"  Target Azure Resource ID: {copyAuth.Value.TargetAzureResourceId}");
            Console.WriteLine($"  Target Region: {targetRegion}");
            Console.WriteLine($"  Expires at: {copyAuth.Value.ExpiresAt}");
            // Step 3: Copy the analyzer to target resource
            var copyOperation = await targetClient.CopyAnalyzerAsync(
                WaitUntil.Completed,
                targetAnalyzerId,
                sourceAnalyzerId,
                sourceResourceId,
                sourceRegion);
            var targetResult = copyOperation.Value;
            Console.WriteLine($"Target analyzer '{targetAnalyzerId}' copied successfully to target resource!");
            Console.WriteLine($"Target analyzer description: {targetResult.Description}");
        }
        finally
        {
            // Clean up: delete both analyzers
            try
            {
                await sourceClient.DeleteAnalyzerAsync(sourceAnalyzerId);
                Console.WriteLine($"Source analyzer '{sourceAnalyzerId}' deleted successfully.");
            }
            catch
            {
                // Ignore cleanup errors
            }
            try
            {
                await targetClient.DeleteAnalyzerAsync(targetAnalyzerId);
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
