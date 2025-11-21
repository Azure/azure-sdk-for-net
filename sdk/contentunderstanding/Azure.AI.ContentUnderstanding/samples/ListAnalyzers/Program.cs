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
/// This sample demonstrates how to list all available content analyzers.
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
        Console.WriteLine("Azure Content Understanding Sample: List Analyzers");
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
                // This supports multiple authentication mechanisms:
                // - Environment variables
                // - Managed Identity
                // - Visual Studio
                // - Azure CLI
                // - Azure PowerShell
                // - Interactive browser
                Console.WriteLine("  Authentication: DefaultAzureCredential");
                client = new ContentUnderstandingClient(endpointUri, new DefaultAzureCredential());
            }
            Console.WriteLine();

            // Step 3: List all available analyzers
            Console.WriteLine("Step 3: Listing all available analyzers...");
            var analyzers = new List<ContentAnalyzer>();

            try
            {
                await foreach (var analyzer in client.GetAnalyzersAsync())
                {
                    analyzers.Add(analyzer);
                }

                Console.WriteLine($"  Found {analyzers.Count} analyzer(s)");
            }
            catch (RequestFailedException ex)
            {
                Console.Error.WriteLine($"  Failed to list analyzers: {ex.Message}");
                Console.Error.WriteLine($"  Status: {ex.Status}, Error Code: {ex.ErrorCode}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"  Unexpected error while listing analyzers: {ex.GetType().Name}");
                Console.Error.WriteLine($"  Message: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine($"  Inner Exception: {ex.InnerException.Message}");
                }
                Console.Error.WriteLine($"  Stack Trace: {ex.StackTrace}");
                throw;
            }

            Console.WriteLine();

            // Step 4: Display summary
            Console.WriteLine("Step 4: Summary...");
            Console.WriteLine($"  Total analyzers: {analyzers.Count}");

            var prebuiltCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") == true);
            var customCount = analyzers.Count(a => a.AnalyzerId?.StartsWith("prebuilt-") != true);
            Console.WriteLine($"  Prebuilt analyzers: {prebuiltCount}");
            Console.WriteLine($"  Custom analyzers: {customCount}");
            Console.WriteLine();

            // Step 5: Display detailed information about each analyzer
            if (analyzers.Count > 0)
            {
                Console.WriteLine("Step 5: Displaying analyzer details...");
                Console.WriteLine("=============================================================");
                Console.WriteLine();

                for (int i = 0; i < analyzers.Count; i++)
                {
                    var analyzer = analyzers[i];
                    Console.WriteLine($"Analyzer {i + 1}:");
                    Console.WriteLine($"  ID: {analyzer.AnalyzerId}");
                    Console.WriteLine($"  Description: {analyzer.Description ?? "(none)"}");
                    Console.WriteLine($"  Status: {analyzer.Status}");
                    Console.WriteLine($"  Created at: {analyzer.CreatedAt:yyyy-MM-dd HH:mm:ss} UTC");
                    Console.WriteLine($"  Last modified: {analyzer.LastModifiedAt:yyyy-MM-dd HH:mm:ss} UTC");

                    // Check if it's a prebuilt analyzer
                    if (analyzer.AnalyzerId?.StartsWith("prebuilt-") == true)
                    {
                        Console.WriteLine("  Type: Prebuilt analyzer");
                    }
                    else
                    {
                        Console.WriteLine("  Type: Custom analyzer");
                    }

                    // Show tags if available
                    if (analyzer.Tags?.Count > 0)
                    {
                        Console.WriteLine($"  Tags: {string.Join(", ", analyzer.Tags.Select(kvp => $"{kvp.Key}={kvp.Value}"))}");
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No analyzers found in this Content Understanding resource.");
                Console.WriteLine();
            }

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

