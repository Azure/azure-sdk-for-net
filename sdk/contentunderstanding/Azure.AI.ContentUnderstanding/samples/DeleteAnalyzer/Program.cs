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
/// This sample demonstrates how to delete a custom analyzer using the Delete API.
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
/// 2. Create a custom analyzer (for deletion demo)
/// 3. Delete the analyzer using the delete API
/// </summary>
class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=============================================================");
        Console.WriteLine("Azure Content Understanding Sample: Delete Analyzer");
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

            // Step 3: Create a temporary analyzer for deletion demo
            Console.WriteLine("Step 3: Creating temporary analyzer for deletion demo...");

            // Generate a unique analyzer ID using timestamp
            // Note: Analyzer IDs cannot contain hyphens
            string analyzerId = $"sdk_sample_analyzer_to_delete_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
            Console.WriteLine($"  Analyzer ID: {analyzerId}");

            // Create a simple custom analyzer
            var tempAnalyzer = new ContentAnalyzer
            {
                BaseAnalyzerId = "prebuilt-document",
                Description = "Temporary analyzer for deletion demo",
                Config = new ContentAnalyzerConfig
                {
                    ReturnDetails = true
                },
                FieldSchema = new ContentFieldSchema(
                    new Dictionary<string, ContentFieldDefinition>
                    {
                        ["demo_field"] = new ContentFieldDefinition
                        {
                            Type = ContentFieldType.String,
                            Method = GenerationMethod.Extract,
                            Description = "Demo field for deletion"
                        }
                    })
                {
                    Name = "demo_schema",
                    Description = "Schema for deletion demo"
                }
            };

            // Add required model mappings
            tempAnalyzer.Models["completion"] = "gpt-4.1";
            tempAnalyzer.Models["embedding"] = "text-embedding-3-large";

            try
            {
                var createOperation = await client.CreateAnalyzerAsync(
                    WaitUntil.Completed,
                    analyzerId,
                    tempAnalyzer,
                    allowReplace: true);

                var createdAnalyzer = createOperation.Value;
                Console.WriteLine($"  ✅ Analyzer '{analyzerId}' created successfully!");
                Console.WriteLine($"  Status: {createdAnalyzer.Status}");
                Console.WriteLine();
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to create analyzer: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }

            // Step 4: Delete the analyzer
            Console.WriteLine("Step 4: Deleting the analyzer...");
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
                throw;
            }

            Console.WriteLine("=============================================================");
            Console.WriteLine("✓ Sample completed successfully");
            Console.WriteLine("=============================================================");
            Console.WriteLine();
            Console.WriteLine("This sample demonstrated:");
            Console.WriteLine("  1. Creating a temporary custom analyzer");
            Console.WriteLine("  2. Deleting the analyzer using the Delete API");
            Console.WriteLine();
            Console.WriteLine("Related samples:");
            Console.WriteLine("  - To create analyzers: see CreateAnalyzer sample");
            Console.WriteLine("  - To list analyzers: see ListAnalyzers sample");
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

